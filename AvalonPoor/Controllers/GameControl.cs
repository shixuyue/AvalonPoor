using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvalonPoor.DeafultRoles;
using AvalonPoor.Models;
using AvalonPoor.Runtime;
using Microsoft.AspNetCore.Mvc;

namespace AvalonPoor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameControlController : ControllerBase
    {
        [HttpGet]
        [Route("Init")]
        public string InitNewGame(int NumberOfPlayers)
        {
            Guid gameId = Guid.NewGuid();
            Games.gameIds.Add(gameId);
            Games.games.Add(new RuntimeGame(RoleGenerator.InitGame(NumberOfPlayers), gameId));
            return $"The new game is started, and its Id is {gameId}";
        }

        [HttpGet]
        [Route("Join")]
        public Player JoinGame(Guid gameId, string displayName)
        {
            if (!Games.gameIds.Contains(gameId))
            {
                throw new Exception("game does not exist");
            }
            Guid playerId = Guid.NewGuid();
            Player player = new Player
            {
                DisplayName = displayName,
                PlayerId = playerId
            };
            RuntimeGame game = Games.games.Where(g => g.gameId == gameId).FirstOrDefault();
            game.Join(player);

            return player;
        }

        [HttpGet]
        [Route("Pick")]
        public string Pick(Guid gameId, Guid playerId)
        {
            if (!Games.gameIds.Contains(gameId))
            {
                throw new Exception("game does not exist");
            }

            RuntimeGame game = Games.games.Where(g => g.gameId == gameId).FirstOrDefault();
            return game.Pick(playerId);
        }

        [HttpGet]
        [Route("ListPlayers")]
        public List<Player> ListPlayers(Guid gameId)
        {
            if (!Games.gameIds.Contains(gameId))
            {
                throw new Exception("game does not exist");
            }

            RuntimeGame game = Games.games.Where(g => g.gameId == gameId).FirstOrDefault();
            return game.players;
        }
    }
}
