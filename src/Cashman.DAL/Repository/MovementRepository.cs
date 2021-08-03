using System.Collections.Generic;
using Cashman.BLL.Entities;
using Cashman.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Linq;
using Cashman.BLL.Services;
using System;

namespace Cashman.DAL.Repository
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
    {
        public MovementRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override bool Add(Movement entity)
        {
            _connection.Execute("START TRANSACTION;");

            string Query = "INSERT INTO movement(Type, Description, Notes, Amount, DateTime, Done)";
            Query+= " VALUES ("; 
            Query+= $"{((int)entity.Type)}, '{entity.Description}', '{entity.Notes}', {entity.Amount}, '{entity.DateTime.ToString("yyyy'-'MM'-'dd' 'hh':'mm':'ss")}', {entity.Done} "; 
            Query+= "); "; 

            int rowsAffected = _connection.Execute(Query); 
            entity.ID = _connection.Query<int>("SELECT max(ID) AS lastInsert FROM movement").FirstOrDefault();
            _connection.Execute("COMMIT; "); 
            return rowsAffected > 0; 
        }

        public override IEnumerable<Movement> Get()
        {
            string Query = "SELECT * FROM movement; "; 
            var movements = _connection.Query<Movement>(Query); 
            return movements; 
        }

        public override Movement GetById(int id)
        {
            string Query = $"SELECT * FROM movement WHERE ID = {id}; "; 
            var movement = _connection.Query<Movement>(Query).FirstOrDefault(); 
            return movement; 
        }

        public override bool Remove(int id)
        {
            string Query = $"DELETE FROM movement WHERE ID = {id}"; 
            int rowsAffected = _connection.Execute(Query); 
            return rowsAffected > 0; 
        }

        public override bool Update(Movement entity)
        {
            string Query = "UPDATE movement SET "; 
            Query+= $"Description = '{entity.Description}', "; 
            Query+= $"Amount = {entity.Amount}, "; 
            Query+= $"DateTime = '{entity.DateTime.ToString("yyyy'-'MM'-'dd' 'hh':'mm':'ss")}', "; 
            Query+= $"Done = {entity.Done}, ";
            Query+= $"Notes = '{entity.Notes}', "; 
            Query+= $"Type = {(int) entity.Type} ";
            Query+= $" WHERE movement.ID = {entity.ID} ; ";  
            
            int rowsAffected = _connection.Execute(Query);
            return rowsAffected > 0;
        }
    }
}