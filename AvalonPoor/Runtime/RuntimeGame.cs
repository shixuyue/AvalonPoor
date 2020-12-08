using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvalonPoor.DeafultRoles;
using AvalonPoor.Models;

namespace AvalonPoor.Runtime
{
    public class RuntimeGame
    {
        public Guid gameId;
        public List<Player> players = new List<Player> { };

        private int gameSize;
        private List<Role> gameBoard;
        private List<Role> AvailableRoles;
        private Random random;

        public RuntimeGame(List<Role> gameBoard, Guid gameId)
        {
            this.gameSize = gameBoard.Count;
            this.gameBoard = gameBoard;
            this.gameId = gameId;
            this.random = new Random();
            this.AvailableRoles = gameBoard;
        }

        public void Join(Player player)
        {
            bool isNewPlayer = !players.Select(p => p.PlayerId).ToList().Contains(player.PlayerId);
            if (players.Count >= gameSize && isNewPlayer)
            {
                throw new Exception("The game is full");
            }
            if (isNewPlayer)
            {
                Role role = ChooseARole();
                player.Role = role;
                players.Add(player);
            }
        }

        public string Pick(Guid playerId)
        {
            Player player = GetPlayer(playerId);
            if(player == null)
            {
                throw new Exception("No Matched player");
            }
            if (player.Role != null)
            {
                throw new Exception("You already have a role");
            }

            Role role = ChooseARole();
            players.Where(p => p.PlayerId == player.PlayerId).FirstOrDefault().Role = role;
            return Enum.GetName(typeof(RoleIndentity), role.RoleIndentity);
        }

        private Role ChooseARole()
        {
            int index = random.Next(AvailableRoles.Count);
            Role role = AvailableRoles[index];
            AvailableRoles.RemoveAt(index);
            return role;
        }

        private Player GetPlayer(Guid playerId)
        {
            return this.players.Where(p => p.PlayerId == playerId).FirstOrDefault();
        }
    }
}
