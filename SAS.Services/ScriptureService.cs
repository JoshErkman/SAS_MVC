using SAS.Data;
using SAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Services
{
    public class ScriptureService
    {
        private readonly Guid _userId;

        public ScriptureService(Guid userId)
        {
            _userId = userId;
        }

        // POST
        public bool CreateScripture(ScriptureCreate model)
        {
            var entity =
                new Scripture()
                {
                    OwnerId = _userId,
                    Book = model.Book,
                    Chapter = model.Chapter,
                    Verses = model.Verses,
                    Content = model.Content,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Scriptures.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET
        public IEnumerable<ScriptureListItem> GetScriptures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Scriptures
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ScriptureListItem
                                {
                                    ScriptureId = e.ScriptureId,
                                    Book = e.Book,
                                    Chapter = e.Chapter,
                                    Verses = e.Verses,
                                    IsStarred = e.IsStarred,
                                    CreatedUTC = e.CreatedUTC
                                }
                         );

                return query.ToArray();
            }
        }

        // GET
        public ScriptureDetail GetScriptureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scriptures
                        .Single(e => e.ScriptureId == id && e.OwnerId == _userId);
                return
                    new ScriptureDetail
                    {
                        ScriptureId = entity.ScriptureId,
                        Book = entity.Book,
                        Chapter = entity.Chapter,
                        Verses = entity.Verses,
                        Content = entity.Content,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateScripture(ScriptureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scriptures
                        .Single(e => e.ScriptureId == model.ScriptureId && e.OwnerId == _userId);

                entity.Book = model.Book;
                entity.Chapter = model.Chapter;
                entity.Verses = model.Verses;
                entity.Content = model.Content;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;
                entity.IsStarred = model.IsStarred;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteScripture(int scriptureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scriptures
                        .Single(e => e.ScriptureId == scriptureId && e.OwnerId == _userId);

                ctx.Scriptures.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
