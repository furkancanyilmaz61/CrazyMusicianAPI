using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrazyMusicianAPI.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private static List<Musician> musicians = new List<Musician>
        {
            new Musician { Id = 1, Name = "Ahmet Calgi", Job = "Unlu Calgi Calar", FunFact = "Her zaman yanlis nota calar, ama cok eglenceli" },
            new Musician { Id = 2, Name = "Zeynep Melodi", Job = "Populer Melodi Yazari", FunFact = "Sarkilari yanlis anlasilir ama cok populer" },
            new Musician { Id = 3, Name = "Cemil Akor", Job = "Cilgin Akorist", FunFact = "Akorlari sik degistirir, ama sasirtici derecede yetenekli" },
            new Musician { Id = 4, Name = "Fatma Nota", Job = "Supriz Nota Ureticisi", FunFact = "Nota uretirken surekli suprizler hazirlar" },
            new Musician { Id = 5, Name = "Hasan Ritim", Job = "Ritim Canavari", FunFact = "Her ritmi kendi tarzinda yapar, hic uymaz ama komiktir" },
            new Musician { Id = 6, Name = "Elif Armoni", Job = "Armoni Ustasi", FunFact = "Armonilerini bazen yanlis calar, ama cok yaraticidir" },
            new Musician { Id = 7, Name = "Ali Perde", Job = "Perde Uygulayici", FunFact = "Her perdeyi farkli sekilde calar, her zaman suprizlidir" },
            new Musician { Id = 8, Name = "Ayse Rezonans", Job = "Rezonans Uzmani", FunFact = "Rezonans konusunda uzman, ama bazen cok gurultu cikarir" },
            new Musician { Id = 9, Name = "Murat Ton", Job = "Tonlama Meraklisi", FunFact = "Tonlamalarindaki farkliliklar bazen komik, ama oldukca ilginc" },
            new Musician { Id = 10, Name = "Selin Akor", Job = "Akor Sihirbazi", FunFact = "Akorlari degistirdiginde bazen sihirli bir hava yaratir" }
        };

        // GET: api/musicians
        [HttpGet]
        public ActionResult<IEnumerable<Musician>> GetMusicians()
        {
            return Ok(musicians);
        }

        // GET: api/musicians/1
        [HttpGet("{id}")]
        public ActionResult<Musician> GetMusicianById(int id)
        {
            var musician = musicians.FirstOrDefault(x => x.Id == id);
            if (musician == null)
                return NotFound();
            return Ok(musician);
        }

        // POST: api/musicians
        [HttpPost]
        public ActionResult AddMusician([FromBody] Musician musician)
        {
            musicians.Add(musician);
            return CreatedAtAction(nameof(GetMusicianById), new { id = musician.Id }, musician);
        }

        // PUT: api/musicians/1
        [HttpPut("{id}")]
        public ActionResult UpdateMusician(int id, [FromBody] Musician updatedMusician)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
                return NotFound();

            musician.Name = updatedMusician.Name;
            musician.Job = updatedMusician.Job;
            musician.FunFact = updatedMusician.FunFact;
            return NoContent();
        }

        // DELETE: api/musicians/1
        [HttpDelete("{id}")]
        public ActionResult DeleteMusician(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);

            if (musician == null)
                return NotFound();

            musicians.Remove(musician);
            return NoContent();
        }
    }
}
