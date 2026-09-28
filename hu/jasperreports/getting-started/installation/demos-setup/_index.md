---
title: Demók beállítása
type: docs
weight: 70
url: /hu/jasperreports/demos-setup/
description: "Állítsa be a demó projekteket az Aspose.Slides for JasperReports letöltésből, módosítsa a használt exportáló osztályt, és építse fel őket Ant-tal."
---
## **Mi a demók**

Az Aspose.Slides for JasperReports letöltés *samples* mappája nyolc demo projektet tartalmaz: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* és *xmldatasource*. Ezek szabványos JasperReports demók, melyekhez hozzáadták a `ppt` buildcélt, amely a kitöltött jelentést PPT‑ként exportálja. A letöltés nem tartalmaz exportált bemutatókat; azokat a demó felépítésével hozhatja létre.

## **Módosítsa az exportáló osztályt a build előtt**

Az eredeti csomagban a demók Java kódja a `com.aspose.slides.jasperreports.JRPptExporter` osztályt használja, amely a jelenlegi jar‑okban nincs benne, ezért a demók nem fordulnak le. A demo alkalmazásosztályában (például a *shapes* demó *ShapesApp.java* fájljában) cserélje le a `JRPptExporter`‑t `ASPptExporter`‑re, amely a PPT exportálót tartalmazza ugyanabban a csomagban. A *fonts* demó az egész csomagot importálja, ezért csak az osztály neve változik a kódban.

A demók emellett olyan JasperReports osztályokat is használnak, amelyeket a későbbi JasperReports verziók eltávolítottak, például a `JExcelApiExporter` és a `JRExporterParameter.FONT_MAP`. A fenti módosítással a demók a következőképpen fordulnak le:

| JasperReports verzió | Demók, amelyek lefordulnak |
| :- | :- |
| 5.5.1 | mind a nyolc |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* és *xmldatasource* |
| 6.16.0 | *charts* |

## **Demo felépítése**

Minden demó *build.xml* fájlja a JasperReports projekt mappaszerkezetét várja: a *../../../build/classes* és a *../../../lib* könyvtárakban lévő jar‑ok ellen fordul, a demó mappájához relatív úton.

1. Másolja a demó mappát a JasperReports projekt mappájába a *demo/samples* alá.
2. Másolja az *aspose.slides.jasperreports.library-xx.x.jar* fájlt a letöltés *lib* almappájából, amely az Ön JasperReports verziójának megfelelő, a JasperReports projekt *lib* mappájába. Lásd [Installing Aspose.Slides for JasperReports](/slides/hu/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Helyezze a saját JasperReports verziójának jar‑ját és a függő jar‑okat ugyanabba a *lib* mappába. A demó fájlok mellett a *build.xml* csak a *build/classes* és a *lib* alatti jar‑okat teszi az osztályútra, és a *build/classes* csak akkor tartalmaz JasperReports osztályokat, ha a JasperReports‑t forrásból fordítja.
4. A *charts*, *subreport* és *text* demók a JasperReports HSQLDB példányadatbázisát (`jdbc:hsqldb:hsql://localhost`) olvassák, ezért előbb indítsa el a szervert, ahogyan a letöltés *samples/Readme.txt* fájljában le van írva. A többi demónak nincs szüksége adatbázisra.
5. A demó mappában fordítsa le az alkalmazást, a jelentés tervezést, töltse ki, és exportálja PPT‑be:

```bash
ant javac
ant compile
ant fill
ant ppt
```

A `ppt` cél a kitöltött jelentés mellé írja a bemutatót, a jelentés nevével (például *LandscapeReport.ppt*).

Két demó több lépést igényel a fentiek mellett:

- A *images* demó egy képet tölt be a `http://jasperreports.sourceforge.net/jasperreports.png` címről exportálás közben. Ez a cím most HTTPS‑re irányít, ezért a `ppt` lépés nem ír bemutatót, amíg a címet `https://`‑ra nem módosítja a *ImagesReport.jrxml* fájlban. JasperReports 6.4.0 esetén a kép exportálása még HTTPS‑en sem sikerül.
- A *xmldatasource* jelentés az Arial betűtípust használja. Egy olyan rendszerben, ahol nincs Arial, az `ant fill` azt jelzi, hogy a betűtípus "nem érhető el a JVM‑nek", és nem ír kitöltött jelentést, így az `ant ppt` nem tud exportálni semmit. A build mégis sikeresnek jelentkezik, ezért ellenőrizze az egyes lépések kimenetét.