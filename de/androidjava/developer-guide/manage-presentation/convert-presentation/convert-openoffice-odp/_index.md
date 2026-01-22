---
title: OpenDocument-Präsentationen auf Android konvertieren
linktitle: OpenDocument konvertieren
type: docs
weight: 10
url: /de/androidjava/convert-openoffice-odp/
keywords:
- ODP konvertieren
- ODP zu Bild
- ODP zu GIF
- ODP zu HTML
- ODP zu JPG
- ODP zu MD
- ODP zu PDF
- ODP zu PNG
- ODP zu PPT
- ODP zu PPTX
- ODP zu TIFF
- ODP zu Video
- ODP zu Word
- ODP zu XPS
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides für Android ermöglicht das einfache Konvertieren von ODP in PDF, HTML und Bildformate. Steigern Sie Ihre Java-Anwendungen mit schneller und genauer Präsentationskonvertierung."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) ermöglicht das Konvertieren von OpenDocument-Präsentationen (ODP) in zahlreiche Formate (HTML, PDF, TIFF, SWF, XPS usw.). Die API, die zum Konvertieren von ODP-Dateien in andere Dokumentformate verwendet wird, ist dieselbe wie die für PowerPoint-Konvertierungen (PPT und PPTX).

Beispielsweise können Sie eine ODP-Präsentation in PDF wie folgt konvertieren:
```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Was passiert, wenn sich das Format meiner ODP-Datei nach der Konvertierung ändert?**

ODP und PowerPoint verwenden unterschiedliche Präsentationsmodelle, und einige Elemente - wie Tabellen, benutzerdefinierte Schriftarten oder Füllstile - werden möglicherweise nicht exakt gleich dargestellt. Es wird empfohlen, die Ausgabe zu prüfen und bei Bedarf Layout oder Formatierung im Code anzupassen.

**Benötige ich OpenOffice oder LibreOffice, um ODP-Konvertierungen durchzuführen?**

Nein, Aspose.Slides ist eine eigenständige Bibliothek und erfordert keine Installation von OpenOffice oder LibreOffice auf Ihrem System.

**Kann ich das Ausgabeformat bei der ODP-Konvertierung anpassen (z.B. PDF-Optionen festlegen)?**

Ja, Aspose.Slides bietet umfangreiche Optionen zur Anpassung der Ausgabe. Beispielsweise können Sie beim Speichern als PDF Kompression, Bildqualität, Textdarstellung und mehr über die [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑Klasse steuern.

**Ist Aspose.Slides für serverseitige oder cloudbasierte ODP-Verarbeitung geeignet?**

Absolut. Aspose.Slides ist für den Einsatz sowohl auf Desktop- als auch auf Server-Umgebungen konzipiert, einschließlich cloudbasierter Plattformen wie Azure, AWS und Docker-Container, ohne UI-Abhängigkeiten.