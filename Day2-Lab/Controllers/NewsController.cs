using Day2_Lab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
            => Ok(NewsData.NewsList);


        [HttpGet("title")]
        public IActionResult GetByTitle(string title)
        {
            var news = NewsData.NewsList.FirstOrDefault(x => x.Title == title);

            if (news is not null)
                Ok(news);

            return NotFound();
        }
        [HttpGet("author")]
        public IActionResult GetByAuthor(string author)
        {
            var news = NewsData.NewsList.FirstOrDefault(x => x.Author == author);

            if (news is not null)
                Ok(news);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(News news)
        {
            if(news is not null)
            { 
            NewsData.NewsList.Add(news);
            return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(News news)
        {
            if (news is not null)
            {
                if (NewsData.NewsList.FirstOrDefault(x => x.ID == news.ID) is not null)
                {
                    var newsDb = NewsData.NewsList.FirstOrDefault(x => x.ID == news.ID);
                    newsDb.Title = news.Title;
                    newsDb.Description = news.Description;
                    newsDb.Author = news.Author;
                    NewsData.NewsList.Add(newsDb);
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var news = NewsData.NewsList.FirstOrDefault(x => x.ID == id);
            if (news is not null)
            {
                NewsData.NewsList.Remove(news);
                return Ok();
            }
            return BadRequest();
        }
    }
}
