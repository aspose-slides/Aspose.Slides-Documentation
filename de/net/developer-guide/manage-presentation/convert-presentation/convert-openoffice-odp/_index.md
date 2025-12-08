---
title: OpenDocument‑Präsentationen (ODP) in C# konvertieren
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
description: "Aspose.Slides für .NET ermöglicht die einfache Konvertierung von ODP in PDF, HTML und Bildformate. Steigern Sie Ihre .NET-Anwendungen mit schneller und genauer Präsentationskonvertierung."
---

## **Übersicht**

Aspose.Slides für .NET bietet eine robuste API zum Konvertieren von OpenDocument‑Präsentationen (ODP) in verschiedene andere Formate. Analog zum Ansatz für PowerPoint‑Dateien (PPT und PPTX) können Entwickler ODP‑Dokumente einfach in Formate wie HTML, PDF, TIFF, JPG, XPS und mehr exportieren.

Diese Beispiele zeigen, wie ODP‑Dokumente in andere Formate konvertiert werden (nur die Quelle zur ODP‑Datei ändern):

- [ODP in HTML konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP in PDF konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP in TIFF konvertieren](/slides/de/net/convert-powerpoint-to-tiff/)
- [ODP in SWF konvertieren](/slides/de/net/convert-powerpoint-to-swf-flash/)
- [ODP in XPS konvertieren](/slides/de/net/convert-powerpoint-to-xps/)
- [ODP in PDF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-to-pdf-with-notes/)
- [ODP in TIFF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-to-tiff-with-notes/)

Zum Beispiel erfordert die Konvertierung einer ODP‑Präsentation in PDF nur wenige Code‑Zeilen in C#:
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **OpenDocument‑Präsentation in verschiedenen Anwendungen**

Wenn eine OpenDocument‑Präsentationsdatei (ODP) in PowerPoint geöffnet wird, kann die ursprüngliche Formatierung aus der Anwendung, in der sie erstellt wurde, verloren gehen. Das liegt daran, dass die OpenDocument‑Präsentations‑App und die PowerPoint‑App unterschiedliche Funktionen und Rendering‑Verhalten bieten.

Einige Unterschiede:

- In PowerPoint werden Tabellen normalerweise zuletzt gerendert und können andere Formen überlagern, unabhängig von ihrer Reihenfolge auf der ODP‑Folien.
- Bildfüllung für ODP‑Tabellen wird in PowerPoint nicht unterstützt.
- Vertikale Textrotation (270°, gestapelt) und verteilte Ausrichtung werden in LibreOffice/OpenOffice Impress nicht unterstützt.
- Bildfüllung, Farbverlauffüllung und Musterfüllung für Text werden in LibreOffice/OpenOffice Impress nicht unterstützt.

MS PowerPoint und LibreOffice/OpenOffice Impress behandeln Listen ebenfalls unterschiedlich. Eine in PowerPoint erstellte ODP‑Datei wird in LibreOffice/OpenOffice Impress möglicherweise nicht korrekt angezeigt und umgekehrt.

Das Bild unten zeigt, wie eine Liste aussieht, wenn sie in LibreOffice Impress erstellt wurde:

![ODP list example](odp-list-example.png)

Aspose.Slides speichert ODP‑Listen so, dass sie in LibreOffice/OpenOffice Impress korrekt angezeigt werden.

[Weitere Informationen zum OpenDocument‑Format und zu PowerPoint]https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0

## **FAQ**

**Was passiert, wenn sich die Formatierung meiner ODP‑Datei nach der Konvertierung ändert?**

ODP und PowerPoint verwenden unterschiedliche Präsentationsmodelle, und einige Elemente – wie Tabellen, benutzerdefinierte Schriften oder Füllstile – werden möglicherweise nicht exakt gleich gerendert. Es wird empfohlen, die Ausgabe zu überprüfen und Layout oder Formatierung bei Bedarf im Code anzupassen.

**Muss OpenOffice oder LibreOffice installiert sein, um ODP‑Konvertierung zu nutzen?**

Nein, Aspose.Slides für .NET ist eine eigenständige Bibliothek und erfordert keine Installation von OpenOffice oder LibreOffice auf Ihrem System.

**Kann ich das Ausgabeformat während der ODP‑Konvertierung anpassen (z. B. PDF‑Optionen festlegen)?**

Ja, Aspose.Slides bietet umfangreiche Optionen zur Anpassung der Ausgabe. Beispielsweise können Sie beim Speichern als PDF Kompression, Bildqualität, Text‑Rendering und mehr über die [PdfOptions]https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/‑Klasse steuern.

**Ist Aspose.Slides für serverseitige oder cloud‑basierte ODP‑Verarbeitung geeignet?**

Absolut. Aspose.Slides für .NET ist sowohl für Desktop‑ als auch für Serverumgebungen konzipiert, einschließlich cloud‑basierter Plattformen wie Azure, AWS und Docker‑Containern, ohne UI‑Abhängigkeiten.