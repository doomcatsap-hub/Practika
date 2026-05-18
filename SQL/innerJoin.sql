select Player_name, Hero_name from players 
join MatchPlayers on MatchPlayers.player_id = players.Player_id and side = 'Radiant' 
join Heroes on heroes.Hero_id = MatchPlayers.Hero_id;

