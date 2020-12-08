using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvalonPoor.Models;

namespace AvalonPoor.DeafultRoles
{
    public static class RoleGenerator
    {
        public static List<Role> InitGame(int number)
        {
            List<Role> roles = new List<Role> { };
            if(number == 8)
            {
                List<RoleIndentity> gameSet = new List<RoleIndentity> { 
                    RoleIndentity.Assassin, RoleIndentity.Mordred, RoleIndentity.Morgana, 
                    RoleIndentity.Merlin, RoleIndentity.Percival,
                    RoleIndentity.Villager, RoleIndentity.Villager, RoleIndentity.Villager
                };

                foreach(var role in gameSet)
                {
                    roles.Add(GenerateRole(role));
                }
            }
            return roles;
        }
        private static Role GenerateRole(RoleIndentity indentity)
        {
            switch (indentity)
            {
                case RoleIndentity.Assassin:
                    return new Role
                    {
                        RoleIndentity = RoleIndentity.Assassin,
                        IndentityProperties = new IndentityProperties
                        {
                            IsEvil = true,
                            IsKnownToMerlin = true,
                            RoleID = Guid.NewGuid()
                        }
                    };
                case RoleIndentity.Evil:
                    return new Role
                    {
                        RoleIndentity = RoleIndentity.Evil,
                        IndentityProperties = new IndentityProperties
                        {
                            IsEvil = true,
                            IsKnownToMerlin = true,
                            RoleID = Guid.NewGuid()
                        }
                    };
                case RoleIndentity.Villager:
                    return new Role
                    {
                        RoleIndentity = RoleIndentity.Villager,
                        IndentityProperties = new IndentityProperties
                        {
                            RoleID = Guid.NewGuid()
                        }
                    };
                case RoleIndentity.Morgana:
                    return new Role
                    {
                        RoleIndentity = RoleIndentity.Morgana,
                        IndentityProperties = new IndentityProperties
                        {
                            IsEvil = true,
                            IsKnownToMerlin = true,
                            IsKnownToPercival = true,
                            RoleID = Guid.NewGuid()
                        }
                    };
                case RoleIndentity.Mordred:
                    return new Role
                    {
                        RoleIndentity = RoleIndentity.Mordred,
                        IndentityProperties = new IndentityProperties
                        {
                            IsEvil = true,
                            RoleID = Guid.NewGuid()
                        }
                    };
                case RoleIndentity.Merlin:
                    return new Role
                    {
                        RoleIndentity = RoleIndentity.Merlin,
                        IndentityProperties = new IndentityProperties
                        {
                            IsKnownToPercival = true,
                            RoleID = Guid.NewGuid()
                        }
                    };
                case RoleIndentity.Percival:
                    return new Role
                    {
                        RoleIndentity = RoleIndentity.Percival,
                        IndentityProperties = new IndentityProperties
                        {
                            RoleID = Guid.NewGuid()
                        }
                    };
                default:
                    throw new Exception("Unknown Role") { };
            }
        }
    }
}
