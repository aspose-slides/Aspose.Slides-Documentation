---
title: OpenDocument-Präsentationen in .NET konvertieren
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
description: "Aspose.Slides für .NET ermöglicht das einfache Konvertieren von ODP zu PDF, HTML und Bildformaten. Steigern Sie Ihre .NET-Anwendungen mit schneller und genauer Präsentationskonvertierung."
---

## **Übersicht**

Aspose.Slides for .NET bietet eine leistungsfähige API zum Konvertieren von OpenDocument‑Präsentationen (ODP) in verschiedene andere Formate. Ähnlich dem Ansatz, der für PowerPoint‑Dateien (PPT und PPTX) verwendet wird, können Entwickler ODP‑Dokumente ganz einfach in Formate wie HTML, PDF, TIFF, JPG, XPS und mehr exportieren.

Diese Beispiele zeigen, wie ODP‑Dokumente in andere Formate konvertiert werden (einfach die Quelle auf eine ODP‑Datei ändern):

- [ODP in HTML konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP in PDF konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP in TIFF konvertieren](/slides/de/net/convert-powerpoint-to-tiff/)
- [ODP in SWF konvertieren](/slides/de/net/convert-powerpoint-to-swf-flash/)
- [ODP in XPS konvertieren](/slides/de/net/convert-powerpoint-to-xps/)
- [ODP in PDF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-to-pdf-with-notes/)
- [ODP in TIFF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-to-tiff-with-notes/)

Zum Beispiel erfordert das Konvertieren einer ODP‑Präsentation in PDF nur wenige Codezeilen in C#:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **OpenDocument‑Präsentation in verschiedenen Anwendungen**

Wenn eine OpenDocument‑Präsentation (ODP) in PowerPoint geöffnet wird, kann die ursprüngliche Formatierung aus der Anwendung, in der sie erstellt wurde, verloren gehen. Dies liegt daran, dass die OpenDocument‑Präsentations‑App und die PowerPoint‑App unterschiedliche Funktionen und Rendering‑Verhalten bieten.

Einige Unterschiede:

- In PowerPoint werden Tabellen typischerweise zuletzt gerendert und können andere Formen überlagern, unabhängig von ihrer Reihenfolge auf der ODP‑Folien.
- Bildfüllung für ODP‑Tabellen wird in PowerPoint nicht unterstützt.
- Vertikale Textrotation (270°, gestapelt) und verteilter Ausrichtungsmodus werden in LibreOffice/OpenOffice Impress nicht unterstützt.
- Bildfüllung, Farbverlauffüllung und Musterfüllung für Text werden in LibreOffice/OpenOffice Impress nicht unterstützt.

MS PowerPoint und LibreOffice/OpenOffice Impress verarbeiten Listen ebenfalls unterschiedlich. Eine in PowerPoint erstellte ODP‑Datei wird in LibreOffice/OpenOffice Impress möglicherweise nicht korrekt dargestellt und umgekehrt.

Das Bild unten zeigt, wie eine Liste aussieht, wenn sie in LibreOffice Impress erstellt wird:

![Beispiel für ODP‑Liste](odp-list-example.png)

Aspose.Slides speichert ODP‑Listen so, dass sie korrekt in LibreOffice/OpenOffice Impress angezeigt werden.

[Mehr über das OpenDocument‑Format und PowerPoint erfahren](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Was ist, wenn sich das Format meiner ODP‑Datei nach der Konvertierung ändert?**

ODP und PowerPoint verwenden unterschiedliche Präsentationsmodelle, und einige Elemente – wie Tabellen, benutzerdefinierte Schriften oder Füllstile – werden möglicherweise nicht exakt gleich gerendert. Es wird empfohlen, die Ausgabe zu prüfen und Layout oder Formatierung im Code bei Bedarf anzupassen.

**Benötige ich OpenOffice oder LibreOffice, um ODP‑Konvertierung zu verwenden?**

Nein, Aspose.Slides for .NET ist eine eigenständige Bibliothek und erfordert keine Installation von OpenOffice oder LibreOffice auf Ihrem System.

**Kann ich das Ausgabeformat während der ODP‑Konvertierung anpassen (z. B. PDF‑Optionen festlegen)?**

Ja, Aspose.Slides bietet umfangreiche Optionen zur Anpassung der Ausgabe. Zum Beispiel können Sie beim Speichern als PDF Komprimierung, Bildqualität, Text‑Rendering und mehr über die [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse steuern.

**Ist Aspose.Slides für die serverseitige oder cloudbasierte ODP‑Verarbeitung geeignet?**

Absolut. Aspose.Slides for .NET ist so konzipiert, dass es sowohl in Desktop‑ als auch in Serverumgebungen funktioniert, einschließlich cloudbasierter Plattformen wie Azure, AWS und Docker‑Container, ohne UI‑Abhängigkeiten.