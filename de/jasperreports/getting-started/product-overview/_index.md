---
title: Produktübersicht
type: docs
weight: 10
url: /de/jasperreports/product-overview/
description: "Erfahren Sie, was Aspose.Slides for JasperReports macht, welche JasperReports-Versionen und Ausgabeformate es unterstützt und wofür seine beiden JAR-Dateien dienen."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Produktbeschreibung**

Aspose.Slides for JasperReports exportiert Berichte aus JasperReports in PowerPoint‑Präsentationen, in Java‑Anwendungen und in JasperReports Server, ohne Microsoft PowerPoint. Es unterstützt JasperReports 3.7.2 bis 6.16.0, mit einer separaten Jar‑Datei für jeden Versionsbereich – siehe [Installing Aspose.Slides for JasperReports](/slides/de/jasperreports/installing-aspose-slides-for-jasperreports/).

Es exportiert einen ausgefüllten Bericht in vier Formate, eine Folie oder Seite pro Berichtseite:

- PPT – PowerPoint 97–2003‑Präsentation
- PPTX – PowerPoint‑Präsentation (Office Open XML)
- PDF
- HTML

Das Produkt besteht aus zwei Teilen:

- Die Bibliotheks‑Jar fügt die Exporter `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` und `ASHtmlExporter` zur JasperReports Library hinzu.
- Die Server‑Jar stellt Exportaktionen für dieselben vier Formate bereit, die Sie in JasperReports Server registrieren – siehe [Integration with JasperServer](/slides/de/jasperreports/integration-with-jasperserver/).

### **Beispiel für die Ausgabe**

Die Exporter erweitern die eigenen Exporter‑Klassen von JasperReports und werden auf die gleiche Weise verwendet: Sie übergeben ihnen den ausgefüllten Bericht und die Ausgabedatei und rufen dann `exportReport` auf. Ein vollständiges Programm, das einen Bericht füllt und ihn nach PPTX exportiert, finden Sie unter [Ihr erster Export](/slides/de/jasperreports/#your-first-export); für alle vier Formate siehe [PPT, PPTX, PDF- und HTML‑Export](/slides/de/jasperreports/ppt-pptx-pdf-and-html-export/).

![Ein Bericht, der ohne Lizenz in eine Präsentation exportiert wurde, mit dem Evaluierungs‑Wasserzeichen in der Mitte der Folie](product-overview_2.png)