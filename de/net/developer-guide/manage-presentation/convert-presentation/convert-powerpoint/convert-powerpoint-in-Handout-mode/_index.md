---
title: Präsentationen im Handout-Modus in C#
type: docs
weight: 150
url: /de/net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertieren
- Handout-Modus
- Handout
- PowerPoint
- PPT
- PPTX
- Präsentation
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Präsentationen im Handout-Modus in C# konvertieren"
---

## **Handout-Modus-Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `SlidesLayoutOptions`‑Eigenschaft in den [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) Schnittstellen festlegen.

Um den Handout‑Modus zu konfigurieren, verwenden Sie das [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) Objekt, das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie Sie eine Präsentation in PDF im Handout‑Modus konvertieren.
```c#
// Präsentation laden.
using var presentation = new Presentation("sample.pptx");

// Exportoptionen festlegen.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 Folien auf einer Seite horizontal
        PrintSlideNumbers = true,                   // Foliennummern drucken
        PrintFrameSlide = true,                     // Rahmen um Folien drucken
        PrintComments = false                       // keine Kommentare
    }
};

// Präsentation mit dem gewählten Layout als PDF exportieren.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
Beachten Sie, dass die `SlidesLayoutOptions`‑Eigenschaft nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Wie hoch ist die maximale Anzahl von Folienminiaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster festlegen, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden ausschließlich durch die [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) Aufzählung gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie die `ShowHiddenSlides`‑Option in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).