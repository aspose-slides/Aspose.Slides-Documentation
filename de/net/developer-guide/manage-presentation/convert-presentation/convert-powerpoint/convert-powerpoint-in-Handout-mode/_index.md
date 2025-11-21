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
description: "Präsentationen in .NET in Handouts konvertieren. Folien pro Seite festlegen, Notizen behalten, zu PDF oder Bildern exportieren mit Aspose.Slides, mit Beispiel-C#-Code. Kostenlos testen."
---

## **Handout-Modus-Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite erscheinen, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `SlidesLayoutOptions`‑Eigenschaft in den Schnittstellen [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/), und [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) festlegen.

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Nachfolgend ein Codebeispiel, das zeigt, wie man eine Präsentation in PDF im Handout‑Modus konvertiert.
```c#
// Load a presentation. → Lade eine Präsentation.
using var presentation = new Presentation("sample.pptx");

// Set the export options. → Lege die Exportoptionen fest.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slides on one page horizontally → 4 Folien pro Seite horizontal
        PrintSlideNumbers = true,                   // print slide numbers → Foliennummern drucken
        PrintFrameSlide = true,                     // print a frame around slides → Rahmen um Folien drucken
        PrintComments = false                       // no comments → keine Kommentare
    }
};

// Export the presentation to PDF with the chosen layout. → Exportiere die Präsentation als PDF mit dem gewählten Layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
Beachten Sie, dass die `SlidesLayoutOptions`‑Eigenschaft nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folien‑Miniaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden streng durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie die Option `ShowHiddenSlides` in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), oder [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).