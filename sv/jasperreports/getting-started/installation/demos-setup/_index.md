---
title: Demoinställning
type: docs
weight: 70
url: /sv/jasperreports/demos-setup/
description: "Ställ in demo-projekten från nedladdningen av Aspose.Slides för JasperReports, ändra exporterarklassen de använder och bygg dem med Ant."
---
## **Vad demonstrationerna är**

*samples*-mappen i nedladdningen av Aspose.Slides för JasperReports innehåller åtta demoprojekt: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* och *xmldatasource*. De är standard‑JasperReports‑demoer som har modifierats för att lägga till ett `ppt`‑byggmål som exporterar den fyllda rapporten till PPT. Nedladdningen innehåller inga exporterade presentationer; du skapar dem genom att bygga en demo.

## **Ändra exporterklassen innan du bygger**

Som levererat använder demonas Java‑kod `com.aspose.slides.jasperreports.JRPptExporter`, en klass som de nuvarande JAR‑filerna inte innehåller, så demona kompilerar inte. I demo‑applikationsklassen (t.ex. *ShapesApp.java* i *shapes*-demon) ersätt `JRPptExporter` med `ASPptExporter`, PPT‑exportören i samma paket. *fonts*-demon importerar hela paketet, så endast klassnamnet i koden ändras.

Demoerna använder också JasperReports‑klasser som senare versioner har tagit bort, såsom `JExcelApiExporter` och `JRExporterParameter.FONT_MAP`. Med förändringen ovan kompilerar demona enligt följande:

| JasperReports‑version | Demo som kompilerar |
| :- | :- |
| 5.5.1 | alla åtta |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* och *xmldatasource* |
| 6.16.0 | *charts* |

## **Bygg en demo**

Varje *build.xml* för demon förväntar sig mappstrukturen för ett JasperReports‑projekt: den kompilerar mot *../../../build/classes* och JAR‑filerna i *../../../lib*, relativt till demomappen.

1. Kopiera demomappen till *demo/samples* i din JasperReports‑projektmapp.
2. Kopiera *aspose.slides.jasperreports.library-xx.x.jar* från nedladdningens *lib*-undermapp som matchar din JasperReports‑version till *lib*-mappen i JasperReports‑projektet. Se [Installing Aspose.Slides for JasperReports](/slides/sv/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Placera JAR‑filen för din JasperReports‑version och de JAR‑filer den beror på i samma *lib*-mapp. Förutom demofilerna lägger *build.xml* bara *build/classes* och JAR‑filerna under *lib* på classpath, och *build/classes* innehåller JasperReports‑klasser först efter att du kompilerat JasperReports från källkod.
4. *charts*, *subreport* och *text*-demoerna läser HSQLDB‑exempeldatabasen för JasperReports (`jdbc:hsqldb:hsql://localhost`), så starta dess server först, enligt *samples/Readme.txt* i nedladdningen. De övriga demoerna kräver ingen databas.
5. I demomappen, kompilera applikationen, kompilera rapportdesignen, fyll den och exportera den till PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

`ppt`‑målet skriver presentationen bredvid den fyllda rapporten, med samma namn som rapporten (t.ex. *LandscapeReport.ppt*).

Två demoer kräver mer än stegen ovan:

- *images*-demon laddar en bild från `http://jasperreports.sourceforge.net/jasperreports.png` när den exporterar. Den adressen omdirigeras nu till HTTPS, så `ppt`‑steget skriver ingen presentation förrän du ändrar adressen till `https://` i *ImagesReport.jrxml*. Med JasperReports 6.4.0 misslyckas exporten av bilden även via HTTPS.
- *xmldatasource*-rapporten använder typsnittet Arial. På ett system utan Arial skriver `ant fill` att typsnittet "inte är tillgängligt för JVM" och skapar ingen fylld rapport, så `ant ppt` har inget att exportera. Bygget rapporterar ändå framgång, så kontrollera utdata för varje steg.