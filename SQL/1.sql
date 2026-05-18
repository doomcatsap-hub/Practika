
select * from players where country_id = (select country_id from Countries where Country_Name = 'Russia') order by MMR desc