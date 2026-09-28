---
title: Einrichtung der Demos
type: docs
weight: 70
url: /de/jasperreports/demos-setup/
aliases:
  - /de/jasperreports/demos-einrichtung/
description: "Richten Sie die Demo-Projekte aus dem Aspose.Slides for JasperReports-Download ein, ändern Sie die von ihnen verwendete Exporter-Klasse und bauen Sie sie mit Ant."
---
## **Was die Demos sind**

Der *samples*-Ordner des Aspose.Slides for JasperReports‑Downloads enthält acht Demo‑Projekte: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* und *xmldatasource*. Es handelt sich um Standard‑JasperReports‑Demos, die geändert wurden, um ein `ppt`‑Build‑Target hinzuzufügen, das den ausgefüllten Bericht nach PPT exportiert. Der Download enthält keine exportierten Präsentationen; Sie erzeugen sie, indem Sie eine Demo bauen.

## **Exporter‑Klasse vor dem Build ändern**

Im ausgelieferten Zustand verwendet der Java‑Code der Demos `com.aspose.slides.jasperreports.JRPptExporter`, eine Klasse, die in den aktuellen JARs nicht enthalten ist, sodass die Demos nicht kompiliert werden. Ersetzen Sie in der Anwendungs‑Klasse der Demo (z. B. *ShapesApp.java* in der *shapes*-Demo) `JRPptExporter` durch `ASPptExporter`, den PPT‑Exporter im selben Paket. Die *fonts*-Demo importiert das gesamte Paket, sodass nur der Klassenname im Code geändert wird.

Die Demos verwenden zudem JasperReports‑Klassen, die in späteren JasperReports‑Versionen entfernt wurden, z. B. `JExcelApiExporter` und `JRExporterParameter.FONT_MAP`. Mit der vorgenannten Änderung kompilieren die Demos wie folgt:

| JasperReports‑Version | Demos, die kompilieren |
| :- | :- |
| 5.5.1 | alle acht |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* und *xmldatasource* |
| 6.16.0 | *charts* |

## **Demo bauen**

Die *build.xml* jeder Demo erwartet die Ordnerstruktur eines JasperReports‑Projekts: Sie kompiliert gegen *../../../build/classes* und die JARs in *../../../lib*, relativ zum Demo‑Ordner.

1. Kopieren Sie den Demo‑Ordner nach *demo/samples* in Ihren JasperReports‑Projektordner.
2. Kopieren Sie *aspose.slides.jasperreports.library-xx.x.jar* aus dem *lib*-Unterordner des Downloads, der Ihrer JasperReports‑Version entspricht, in den *lib*-Ordner des JasperReports‑Projekts. Siehe [Installing Aspose.Slides for JasperReports](/slides/de/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Legen Sie das JAR Ihrer JasperReports‑Version und die davon abhängigen JARs in denselben *lib*-Ordner. Neben den Demo‑Dateien fügt *build.xml* nur *build/classes* und die JARs unter *lib* zum Klassenpfad hinzu, und *build/classes* enthält JasperReports‑Klassen erst, nachdem Sie JasperReports aus dem Quellcode kompiliert haben.
4. Die Demos *charts*, *subreport* und *text* lesen die HSQLDB-Beispieldatenbank von JasperReports (`jdbc:hsqldb:hsql://localhost`), daher starten Sie zuerst deren Server, wie in *samples/Readme.txt* des Downloads beschrieben. Die anderen Demos benötigen keine Datenbank.
5. Im Demo‑Ordner kompilieren Sie die Anwendung, kompilieren das Bericht‑Design, füllen es und exportieren es nach PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Das `ppt`‑Target schreibt die Präsentation neben dem gefüllten Bericht, benannt nach dem Bericht (z. B. *LandscapeReport.ppt*).

Zwei Demos benötigen mehr als die oben genannten Schritte:

- Die *images*-Demo lädt beim Export ein Bild von `http://jasperreports.sourceforge.net/jasperreports.png`. Diese Adresse leitet jetzt zu HTTPS um, sodass der `ppt`‑Schritt keine Präsentation erzeugt, bis Sie die Adresse in *ImagesReport.jrxml* zu `https://` ändern. Mit JasperReports 6.4.0 schlägt das Exportieren dieses Bildes selbst über HTTPS fehl.
- Der *xmldatasource*-Report verwendet die Schriftart Arial. Auf einem System ohne Arial gibt `ant fill` aus, dass die Schriftart "is not available to the JVM" sei, und erzeugt keinen gefüllten Bericht, sodass `ant ppt` nichts zu exportieren hat. Der Build meldet trotzdem Erfolg, prüfen Sie also die Ausgabe jedes Schrittes.