select Country_Name, Player_name
from Players
right JOIN Countries  on players.country_id = countries.country_id