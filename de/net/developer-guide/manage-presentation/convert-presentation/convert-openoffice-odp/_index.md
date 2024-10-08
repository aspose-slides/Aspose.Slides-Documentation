---
title: OpenOffice ODP konvertieren
type: docs
weight: 10
url: /de/net/convert-openoffice-odp/
keywords: "ODP zu PDF konvertieren, ODP zu PPT, ODP zu PPTX, ODP zu XPS, ODP zu HTML, ODP zu TIFF"
description: "Konvertieren Sie ODP zu PDF, ODP zu PPT, ODP zu PPTX, ODP zu HTML und anderen Formaten mit Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) ermöglicht es Ihnen, OpenOffice ODP-Präsentationen in viele Formate zu konvertieren. Die API, die verwendet wird, um ODP-Dateien in andere Dokumentformate zu konvertieren, ist dieselbe, die für PowerPoint (PPT und PPTX) Konvertierungsoperationen verwendet wird.

Diese Beispiele zeigen Ihnen, wie Sie ODP-Dokumente in andere Formate konvertieren können (ändern Sie einfach die Quell-ODP-Datei):

- [ODP zu HTML konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP zu PDF konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP zu TIFF konvertieren](/slides/de/net/convert-powerpoint-to-tiff/)
- [ODP zu SWF Flash konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODP zu XPS konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ODP zu PDF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ODP zu TIFF mit Notizen konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Wenn Sie beispielsweise eine ODP-Präsentation in PDF konvertieren müssen, kann dies so geschehen:

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```


## OpenDocument Präsentation in verschiedenen Anwendungen

Wenn eine OpenDocument Präsentationsdatei in PowerPoint geöffnet wird, kann die Formatierung fehlen, wie sie in der Originalanwendung war, in der sie erstellt wurde, da die OpenDocument Präsentationsanwendung und die PowerPoint-Anwendung unterschiedliche Funktionen und Optionen bieten.

Dies sind einige der Unterschiede:
- In PowerPoint werden alle Tabellen typischerweise zuletzt geladen und überlagern andere Formen (unabhängig von der Anordnung der Formen auf der ODP-Folie).
- Das Bildfüllformat für ODP-Tabellen wird in PowerPoint nicht unterstützt.
- Die vertikale Textrotation (270, gestapelt) und die verteilte Ausrichtung werden in LibreOffice/OpenOffice Impress nicht unterstützt.
- Bildfüllung, Farbverlauffüllung und Mustervollfüllung für Text werden in LibreOffice/OpenOffice Impress nicht unterstützt.

MS PowerPoint und LibreOffice/OpenOffice Impress behandeln Listen ebenfalls unterschiedlich. Eine in PowerPoint erstellte ODP-Datei wird in LibreOffice/OpenOffice nicht korrekt geöffnet und umgekehrt.

Dieses Bild zeigt die Ansicht der Liste, die in LibreOffice Impress erstellt wurde:

![odp-list-example](odp-list-example.png)



**Aspose.Slides** speichert die ODP-Listen, um sicherzustellen, dass sie in LibreOffice/OpenOffice Impress korrekt angezeigt werden.

[Erfahren Sie mehr über das OpenDocument-Format und PowerPoint](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/).