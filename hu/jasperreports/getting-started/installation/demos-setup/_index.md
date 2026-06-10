---
title: Demók beállítása
type: docs
weight: 70
url: /hu/jasperreports/demos-setup/
---
Az Aspose.Slides for JasperReports által biztosított összes demó módosított standard demó. A legjobb, ha az összes demót a JasperReports demó mappájába másolja:
...\jasperreports-x.x.x\demo\samples\

Használja a szabványos parancssorozatot a jelentések felépítéséhez és exportálásához:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 
Kérjük, ne felejtse el elindítani a HSQLDB-t a tesztadatbázissal, hogy a jelentéseket adatokkal töltse fel, és másolja az aspose.slides.jasperreports.library-xx.x.jar fájlt a \lib\JasperReports X.X.X - X.X.X mappából, amely az aspose-slides-xx.x-jasperreports.zip-ben található, a &#60;InstallDir&#62;\lib könyvtárba.
{{% /alert %}} 

A legtöbb demó (kivéve a Diagramok) már rendelkezik legenerált prezentációkkal, így kihagyhatja az összes “ant” lépést, és azonnal ellenőrizheti az eredményeket.