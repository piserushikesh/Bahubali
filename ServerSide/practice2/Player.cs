namespace practice1.serverSide.models;
using System;
using System.ComponentModel.DataAnnotations;
public class Player
{
    public int playerId{get;set;}

    [Required]
    public string playerName{get;set;} ="";

    [Required]
    public string country{get;set;} ="";

     [Required]
     public string dob{get;set;} ="";

}