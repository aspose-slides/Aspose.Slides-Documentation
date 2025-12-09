---
title: OpenDocument‑Präsentationen in .NET konvertieren
linktitle: OpenDocument konvertieren
type: docs
weight: 10
url: /de/net/convert-openoffice-odp/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides für .NET ermöglicht das einfache Konvertieren von ODP zu PDF, HTML und Bildformaten. Steigern Sie Ihre .NET‑Anwendungen mit schneller und genauer Präsentationskonvertierung."
---

## **Übersicht**

Aspose.Slides for .NET bietet eine robuste API zum Konvertieren von OpenDocument‑Präsentationen (ODP) in verschiedene andere Formate. Ähnlich wie beim Umgang mit PowerPoint‑Dateien (PPT und PPTX) können Entwickler ODP‑Dokumente einfach in Formate wie HTML, PDF, TIFF, JPG, XPS und mehr exportieren.

Diese Beispiele zeigen, wie ODP‑Dokumente in andere Formate konvertiert werden (einfach die Quelle auf die ODP‑Datei ändern):

- [ODP in HTML konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP in PDF konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP in TIFF konvertieren](/slides/de/net/convert-powerpoint-to-tiff/)
- [ODP in SWF konvertieren](/slides/de/net/convert-powerpoint-to-swf-flash/)
- [ODP in XPS konvertieren](/slides/de/net/convert-powerpoint-to-xps/)
- [ODP in PDF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-to-pdf-with-notes/)
- [ODP in TIFF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-to-tiff-with-notes/)

Zum Beispiel erfordert das Konvertieren einer ODP‑Präsentation in PDF nur wenige Zeilen C#‑Code:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **OpenDocument‑Präsentation in verschiedenen Anwendungen**

Wenn eine OpenDocument‑Präsentation (ODP) in PowerPoint geöffnet wird, kann das ursprüngliche Layout aus der Anwendung, in der sie erstellt wurde, verloren gehen. Das liegt daran, dass die OpenDocument‑Präsentations‑App und die PowerPoint‑App unterschiedliche Funktionen und Rendering‑Verhalten bieten.

Einige Unterschiede sind:

- In PowerPoint werden Tabellen normalerweise zuletzt gerendert und können andere Formen überlagern, unabhängig von ihrer Reihenfolge auf der ODP‑Folie.
- Bildfüllung für ODP‑Tabellen wird in PowerPoint nicht unterstützt.
- Vertikale Textrotation (270 °, gestapelt) und verteilte Ausrichtung werden in LibreOffice/OpenOffice Impress nicht unterstützt.
- Bildfüllung, Farbverlauffüllung und Musterfüllung für Text werden in LibreOffice/OpenOffice Impress nicht unterstützt.

MS PowerPoint und LibreOffice/OpenOffice Impress behandeln Listen ebenfalls unterschiedlich. Eine in PowerPoint erstellte ODP‑Datei wird in LibreOffice/OpenOffice Impress möglicherweise nicht korrekt angezeigt und umgekehrt.

Das Bild unten zeigt, wie eine Liste aussieht, wenn sie in LibreOffice Impress erstellt wurde:

![ODP‑Listenbeispiel](odp-list-example.png)

Aspose.Slides speichert ODP‑Listen so, dass sie in LibreOffice/OpenOffice Impress korrekt angezeigt werden.

[Erfahren Sie mehr über das OpenDocument‑Format und PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Was kann ich tun, wenn sich das Layout meiner ODP‑Datei nach der Konvertierung ändert?**

ODP und PowerPoint verwenden unterschiedliche Präsentationsmodelle, und einige Elemente – etwa Tabellen, benutzerdefinierte Schriften oder Füllstile – werden möglicherweise nicht exakt gleich gerendert. Es wird empfohlen, die Ausgabe zu überprüfen und bei Bedarf das Layout oder die Formatierung im Code anzupassen.

**Muss ich OpenOffice oder LibreOffice installiert haben, um ODP‑Konvertierungen zu nutzen?**

Nein, Aspose.Slides for .NET ist eine eigenständige Bibliothek und erfordert keine Installation von OpenOffice oder LibreOffice auf Ihrem System.

**Kann ich das Ausgabeformat während der ODP‑Konvertierung anpassen (z. B. PDF‑Optionen festlegen)?**

Ja, Aspose.Slides bietet umfangreiche Optionen zum Anpassen der Ausgabe. Beispielsweise können Sie beim Speichern als PDF die Kompression, Bildqualität, Text‑Rendering und mehr über die [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse steuern.

**Ist Aspose.Slides für serverseitige oder cloudbasierte ODP‑Verarbeitung geeignet?**

Absolut. Aspose.Slides for .NET ist für den Einsatz sowohl in Desktop‑ als auch in Serverumgebungen konzipiert, einschließlich cloudbasierter Plattformen wie Azure, AWS und Docker‑Containern, ohne jegliche UI‑Abhängigkeiten.