---
title: PowerPoint-Präsentationen im Handout-Modus in .NET konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout-Modus
- Handout
- PowerPoint
- Präsentation
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Präsentationen in Handouts in .NET konvertieren. Folien pro Seite festlegen, Notizen beibehalten, zu PDF oder Bildern mit Aspose.Slides exportieren, mit Beispiel-C#-Code. Jetzt kostenlos testen."
---

## **Handout-Modus Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite erscheinen, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die `SlidesLayoutOptions`‑Eigenschaft in den [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) Schnittstellen setzen.

Um den Handout‑Modus zu konfigurieren, verwenden Sie das [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/)‑Objekt, das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Nachfolgend ein Codebeispiel, das zeigt, wie eine Präsentation im Handout‑Modus in PDF konvertiert wird.
```c#
// Präsentation laden.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 Folien horizontal auf einer Seite
        PrintSlideNumbers = true,                   // Foliennummern drucken
        PrintFrameSlide = true,                     // Rahmen um Folien drucken
        PrintComments = false                       // keine Kommentare
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 

Beachten Sie, dass die `SlidesLayoutOptions`‑Eigenschaft nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.

{{% /alert %}} 

## **FAQ**

**Wie viele Folien‑Miniaturansichten maximal pro Seite sind im Handout‑Modus möglich?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten wird strikt durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in das Handout‑Ergebnis einbeziehen?**

Ja. Aktivieren Sie die `ShowHiddenSlides`‑Option in den Exporteinstellungen für das Ziel­format, z. B. [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).