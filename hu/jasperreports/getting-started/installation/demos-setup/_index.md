---
title: Demók beállítása
type: docs
weight: 70
url: /hu/jasperreports/demos-setup/
---
Az Aspose.Slides for JasperReports‑hez mellékelt összes demó módosított szabványos demó. Jobb, ha az összes demót átmásolod a JasperReports demó mappájába:
...\jasperreports-x.x.x\demo\samples\

Használd a szabványos parancsok sorrendjét a jelentések építéséhez és exportálásához:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

Ne felejtsd el futtatni az HSQLDB‑t a teszt adatbázissal, hogy a jelentéseket adatokkal töltsd fel, és másold az aspose.slides.jasperreports.library-xx.x.jar fájlt a \lib\JasperReports X.X.X - X.X.X mappából az aspose‑slides‑xx.x‑jasperreports.zip‑ből a &#60;InstallDir&#62;\lib könyvtárba.

{{% /alert %}} 

A legtöbb demó (kivéve a Chartokat) már rendelkezik generált prezentációval, így kihagyhatod az összes „ant” lépést, és azonnal ellenőrizheted az eredményeket.