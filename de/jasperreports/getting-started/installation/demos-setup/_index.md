---
title: Demos Einrichtung
type: docs
weight: 70
url: /de/jasperreports/demos-setup/
---
Alle mit Aspose.Slides für JasperReports bereitgestellten Demos sind geänderte Standard‑Demos. Es ist besser, alle Demos in den JasperReports‑Demo‑Ordner zu kopieren:
...\jasperreports-x.x.x\demo\samples\

Verwenden Sie die standardmäßige Befehlssequenz zum Erstellen und Exportieren von Berichten:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
Bitte vergessen Sie nicht, HSQLDB mit der Testdatenbank zu starten, um die Berichte mit Daten zu füllen, und kopieren Sie aspose.slides.jasperreports.library-xx.x.jar aus dem \lib\JasperReports X.X.X - X.X.X‑Ordner von aspose-slides-xx.x-jasperreports.zip in das Verzeichnis &#60;InstallDir&#62;\lib.
{{% /alert %}} 
Die meisten Demos (außer Charts) enthalten bereits erzeugte Präsentationen, sodass Sie alle „ant“-Schritte überspringen und die Ergebnisse sofort überprüfen können.