namespace PlayersController;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using practice1.serverSide.models;
using practice1.serverSide.DAL;




[ApiController]
[Route("api/[controller]")]

public class PlayersController : ControllerBase
{
   
    private readonly ILogger<PlayersController> _logger;

    public PlayersController(ILogger<PlayersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors]
    public IEnumerable<Player> GetAllPlayers()
    {
        List<Player> players = PlayersDataAccess.GetAllPlayers();
        return players;
    }
    
    [Route("{id}")]
    [HttpGet]
    [EnableCors()]
    public ActionResult<Player> GetPlayerById(int id)
    {
        Player players= PlayersDataAccess.GetPlayerById(id);
        return players;
    }

    [HttpPost]
    [EnableCors()]
    public IActionResult AddNewPlayer(Player player )
    {
        PlayersDataAccess.AddNewPlayer(player);
        return Ok(new { message = "Player Added Successsfully!!!!"});
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public ActionResult<Player> DeletePlayerById(int id)
    {
        PlayersDataAccess.DeletePlayerById(id);
        return Ok(new {message="Deleted!!!!!!!!"});
    }
}
