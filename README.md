# CsharpHarjoitukset
Ensimmäiset C# harjoitukset löytyvät täältä

## Luokkien periytyminen
luokka voi periä toiselta luokalta kenttiä ja metodeja. Luokkaa, jonka ominaisuuksia peritään (inheritance)
kutsutaan yliluokaksi (superclass, parent class) ja perivää luokkaa aliluokaksi (subclass, child class).
Perimisen keskeinen idea on se, että yliluokassa määritettyjä ominaisuuksia (kenttä) jaa metodeja ei 
tarvitse enää määritellä aliluokassa, rittää että kerrotaan niiden periytyvän yliluokasta. Yliluokalla ja aliluokalla
voi olla saman nimisiä metodeja, jotka toimivat eri tavalla. tätä kutsutaan motedien ylikirjoittamiseksi(method overload).
Jos aliluokassa metodi on kirjoitettu eritavalla kuin yliluokassa, yliluokan määritys syrjäytyy.

