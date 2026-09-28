---
title: Demo's Instelling
type: docs
weight: 70
url: /nl/jasperreports/demos-setup/
description: "Installeer de demoprojecten van de Aspose.Slides for JasperReports-download, wijzig de exporter-klasse die ze gebruiken, en bouw ze met Ant."
---
## **Wat de demo's zijn**

De *samples* map van de Aspose.Slides for JasperReports download bevat acht demoprojecten: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* en *xmldatasource*. Het zijn standaard JasperReports‑demo's, aangepast om een `ppt` build‑target toe te voegen die het ingevulde rapport naar PPT exporteert. De download bevat geen geëxporteerde presentaties; je maakt ze aan door een demo te bouwen.

## **Verander de exporter‑klasse voordat je bouwt**

Zoals geleverd, gebruikt de Java‑code van de demo's `com.aspose.slides.jasperreports.JRPptExporter`, een klasse die niet aanwezig is in de huidige jars, waardoor de demo's niet compileren. In de applicatieklasse van de demo (bijvoorbeeld *ShapesApp.java* in de *shapes*-demo), vervang `JRPptExporter` door `ASPptExporter`, de PPT‑exporter in hetzelfde pakket. De *fonts*-demo importeert het volledige pakket, dus alleen de klassenaam in de code verandert.

De demo's gebruiken ook JasperReports‑klassen die in latere JasperReports‑versies zijn verwijderd, zoals `JExcelApiExporter` en `JRExporterParameter.FONT_MAP`. Met de bovenstaande wijziging compileren de demo's als volgt:

| JasperReports-versie | Demo's die compileren |
| :- | :- |
| 5.5.1 | alle acht |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* en *xmldatasource* |
| 6.16.0 | *charts* |

## **Bouw een demo**

Elke *build.xml* van een demo verwacht de mapstructuur van een JasperReports‑project: hij compileert tegen *../../../build/classes* en de jars in *../../../lib*, relatief ten opzichte van de demomap.

1. Kopieer de demomap naar *demo/samples* in de map van je JasperReports‑project.
2. Kopieer *aspose.slides.jasperreports.library-xx.x.jar* vanuit de *lib* submap van de download die overeenkomt met jouw JasperReports‑versie naar de *lib* map van het JasperReports‑project. Zie [Installatie van Aspose.Slides voor JasperReports](/slides/nl/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Plaats de jar van jouw JasperReports‑versie en de jars waar deze van afhankelijk is in dezelfde *lib* map. Naast de demobestanden zet *build.xml* alleen *build/classes* en de jars onder *lib* op het classpath, en *build/classes* bevat JasperReports‑klassen pas nadat je JasperReports vanaf de bron hebt gecompileerd.
4. De *charts*-, *subreport*- en *text*-demo's lezen de HSQLDB‑voorbeelddatabase van JasperReports (`jdbc:hsqldb:hsql://localhost`), dus start eerst de server, zoals beschreven in *samples/Readme.txt* van de download. De andere demo's hebben geen database nodig.
5. In de demomap compileer je de applicatie, compileer je het rapportontwerp, vul je het, en exporteer je het naar PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Het `ppt`‑target schrijft de presentatie naast het gevulde rapport, benoemd naar het rapport (bijvoorbeeld *LandscapeReport.ppt*).

Twee demo's hebben meer nodig dan de bovenstaande stappen:

- De *images*-demo laadt één afbeelding van `http://jasperreports.sourceforge.net/jasperreports.png` tijdens het exporteren. Dat adres leidt nu door naar HTTPS, waardoor de `ppt`‑stap geen presentatie schrijft totdat **je het adres** wijzigt naar `https://` in *ImagesReport.jrxml*. Met JasperReports 6.4.0 mislukt het exporteren van die afbeelding zelfs via **HTTPS**.
- Het *xmldatasource*-rapport gebruikt het Arial‑lettertype. Op een systeem zonder Arial geeft `ant fill` weer dat het lettertype "niet beschikbaar is voor de JVM" en schrijft geen gevuld rapport, waardoor `ant ppt` niets heeft om te exporteren. De build meldt nog steeds succes, dus controleer de output van elke stap.