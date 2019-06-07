# Liftų valdymo sistema

Programą galima paleisti per Visual Studio. (Liftai0513 katalogas, LiftaiMVC.sln)


Darbas kurtas waterfall metodu, iš pradžių aprašant sistemą ir kuriant UML diagramas.
Realizuota naudojantis MVC sistema (Visual Studio, ASP.NET)

Pradinis sistemos aprašymas:
Kuriama liftų valdymo sistema, kuri padeda valdyti liftų priežiūrą ir tvarkymą. Pagrindiniai sistemos vartotojai yra tokie: administratorius, operatorius ir meistras. Taip pat, prie sistemos turi būti prijungti valdomi liftai
Prisijungęs prie sistemos, sistemos vartotojas gali peržiūrėti pastatų bei liftų sąrašus ir, jei reikia, detalesnę informaciją apie pasirinktą pastatą arba liftą.
Administratorius, prisijungęs prie sistemos, gali sukurti, redaguoti bei pašalinti sistemos vartotojus, pastatus ir liftus. Administratorius taip pat gali sukurti ir redaguoti meistrų darbo grafikus.
Prie sistemos prijungtas liftas gali, priklausomai nuo aplinkybių, pakeisti savo būseną. Jeigu būsena pasikeičia iš veikiantis į bet kokią kitą, automatiškai sukuriamas darbas su atitinkamu prioritetu ir įdedamas į darbų eilę. Lifto keleivis gali paspausti avarinio iškvietimo mygtuką, tuomet liftas išsiunčia pranešimą operatoriui, kuris patvirtina arba atmeta avarinį iškvietimą.
Operatorius, prisijungęs prie sistemos, gali matyti dirbančių meistrų sąrašą, gauti avarinio iškvietimo pranešimus iš lifto ir, atsižvelgęs į situaciją, juos patvirtinti ir įdėti į darbų eilę arba atmesti (jeigu toks darbas jau sukurtas ar apgaulingas pranešimas). Operatorius dar gali inicijuoti lifto sistemos perkrovimą, jei mano, kad gedimas sisteminis, o ne mechaninis bei nusiųsti liftui pranešimą, kad išjungtų avarinius stabdžius, jeigu liftas yra saugus naudoti.
Prisijungęs prie sistemos meistras gali peržiūrėti savo darbo grafiką, peržiūrėti jam priskirtą darbą, pakeisti savo būseną, priklausomai nuo atliekamų veiksmų, darbo metu redaguoti informaciją apie liftą bei, jeigu yra laisvas prisiskirti naują darbą iš darbų sąrašo (automatiškai priskiriamas aukščiausiai eilėje esantis darbas, meistrui tik parodomas pranešimas).

Ne visa sistema buvo realizuota. Realizuotos šios dalys:
1. Sistemos vartotojas gali peržiūrėti liftų sąrašą, kurti naują liftą, šalinti liftą, peržiūrėti detalią lifto informaciją ir ją redaguoti.
2. Sukurtas lifto API. T.y. mygtukai atitinka lifto siunčiamus signalus. Signalai (pagalba, sugedęs liftas) sukuria naują užduotį.
3. Meistrui priskiriama darbo užduotis, jei tokių yra. Jei jų nėra, bus priskirta, kai atsiras nauja darbo užduotis.

Bendradarbiai:
Martynas Rutkus
Tautvydas Korkuzas
Kamilė Tumšytė
Kamilė Nanartonytė (realizavau 1-ą punktą iš 3, padėjau kolegoms, padariau pradinį programos karkasą)


