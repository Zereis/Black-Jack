using BlackJackDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameCardLib
{
    // App call this class to call the DAL for registering players
    public class RegisterPlayer
    {
        PlayerDatabase playerDatabase = new PlayerDatabase();
        // insert to table
        public void callRegister(int id, string name)
        {
            Players test = new Players();
            test.id = id;
            test.name = name;


            playerDatabase.Register(test);
        }
        // Update player info using reference ID on player
        public void callUpdate(int newID, string newName)
        {
            Players test = new Players();

            playerDatabase.Update(newID, newName, test);

        }
        // delete player info using reference ID on player
        public void callDelete(int id)
        {
            Players test = new Players();
            playerDatabase.Delete(id, test);
        }
    }
}
