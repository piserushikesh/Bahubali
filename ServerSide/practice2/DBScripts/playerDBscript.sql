DROP DATABASE IF EXISTS playerinfo;

create database playerinfo;
use playerinfo;
create table players(playerid integer primary key auto_increment,playername varchar(50),country varchar(30), DOB date);

insert into players values(10,"Sachin Tendulkar","India","75-12-11");
insert into players(playername,country,DOB) values("Virat Kohli","India","87-08-04");