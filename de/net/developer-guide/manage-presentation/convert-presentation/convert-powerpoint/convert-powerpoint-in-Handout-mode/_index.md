---
title: PowerPoint-Präsentationen im Handout‑Modus in .NET konvertieren
linktitle: Handout‑Modus
type: docs
weight: 150
url: /de/net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout‑Modus
- Handout
- PowerPoint
- Präsentation
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Präsentationen in Handouts in .NET konvertieren. Folien pro Seite festlegen, Notizen beibehalten, mit Aspose.Slides in PDF oder Bilder exportieren, inkl. Beispiel‑C#‑Code. Kostenlos testen."
---
## **Einführung**

Aspose.Slides ermöglicht das Konvertieren von Präsentationen in Ausgab Formate, die den Handout‑Modus unterstützen. In diesem Modus werden mehrere Folien auf einer einzigen Seite angeordnet, was für den Druck von Präsentationsmaterialien für Konferenzen, Seminare und ähnliche Veranstaltungen nützlich ist.

Der Handout‑Modus wird über die Eigenschaft `SlidesLayoutOptions` konfiguriert, die in [IPdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/itiffoptions/) verfügbar ist. Um das Handout‑Layout zu definieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/handoutlayoutingoptions/).

Um die Handout‑Seitengröße und Ausrichtung vor dem Export festzulegen, siehe [Notes Page Size](/slides/de/net/notes-size/).

## **Handout‑Modus‑Export**

Um eine Präsentation im Handout‑Modus zu exportieren, setzen Sie die Eigenschaft `SlidesLayoutOptions` für die Ziel‑Export‑Optionen und weisen ein [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/handoutlayoutingoptions/)‑Objekt zu, das die Anzahl der Folien pro Seite und verwandte Anzeigeparameter definiert.

Nachfolgend ein Code‑Beispiel, das zeigt, wie eine Präsentation in PDF im Handout‑Modus konvertiert wird.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Beachten Sie, dass die Eigenschaft `SlidesLayoutOptions` nur für bestimmte Ausgab Formate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.

{{% /alert %}} 

## **FAQ**

### Was ist die maximale Anzahl von Folien‑Miniaturansichten pro Seite im Handout‑Modus?

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/de/net/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

### Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?

Nein. Die Anzahl und Anordnung der Miniaturansichten wird strikt durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/de/net/aspose.slides.export/handouttype/) gesteuert; willkürliche Layouts werden nicht unterstützt.

### Kann ich verborgene Folien in die Handout‑Ausgabe einbeziehen?

Ja. Aktivieren Sie die Option `ShowHiddenSlides` in den Export‑Einstellungen für das Ziel‑Format, etwa [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/).