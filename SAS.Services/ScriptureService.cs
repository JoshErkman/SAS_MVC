using SAS.Data;
using SAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Services
{
    class ScriptureService
    {
        private readonly Guid _userId;

        public ScriptureService(Guid userId)
        {
            _userId = userId;
        }

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
                                    CreatedUTC = e.CreatedUTC
                                }
                         );

                return query.ToArray();
            }
        }
    }
}
