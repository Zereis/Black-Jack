using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlackJackDAL
{
    public class PlayerDatabase
    {
        public PlayerDatabase()
        {

        }
        // Register player to the database
        public void Register(Players test)
        {
            playerInfoDataContext db = new playerInfoDataContext();

            db.Players.InsertOnSubmit(test);
            db.SubmitChanges();
        }
        // Update the player info in the database
        public void Update(int newID, string newName, Players test)
        {
            playerInfoDataContext db = new playerInfoDataContext();

            test = db.Players.Single(x => x.id == newID);
            //test.id = newID;
            test.name = newName;

            db.SubmitChanges();
        }
        // Delete a player from the database
        public void Delete(int id, Players test)
        {
            playerInfoDataContext db = new playerInfoDataContext();


            test = db.Players.Single(x => x.id == id);
            db.Players.DeleteOnSubmit(test);

            db.SubmitChanges();
        }
    }
}
