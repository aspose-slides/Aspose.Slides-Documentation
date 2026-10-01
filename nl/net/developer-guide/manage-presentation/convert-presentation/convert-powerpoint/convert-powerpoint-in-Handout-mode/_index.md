---
title: PowerPoint-presentaties converteren in Handout-modus in .NET
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PowerPoint
- presentatie
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Converteer presentaties naar handouts in .NET. Stel aantal dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, met voorbeeld C#-code. Probeer gratis."
---
## **Introductie**

Aspose.Slides stelt u in staat presentaties te converteren naar uitvoerformaten die Handout-modus ondersteunen. In deze modus worden meerdere dia’s op één pagina gerangschikt, wat handig is voor het afdrukken van presentatiematerialen voor conferenties, seminars en soortgelijke evenementen.

Handout-modus wordt geconfigureerd via de `SlidesLayoutOptions`‑eigenschap, die beschikbaar is in [IPdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ihtmloptions/), en [ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/). Om de handout‑lay-out te definiëren, gebruikt u het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handoutlayoutingoptions/)‑object.

Om de afmetingen en oriëntatie van de handout‑pagina in te stellen vóór export, zie [Notes Page Size](/slides/nl/net/notes-size/).

## **Handout-modus Export**

Om een presentatie in Handout-modus te exporteren, stelt u de `SlidesLayoutOptions`‑eigenschap in voor de gewenste exportopties en kent u een [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handoutlayoutingoptions/)‑instance toe die het aantal dia’s per pagina en gerelateerde weergave‑parameters definieert.

Hieronder staat een codevoorbeeld dat laat zien hoe u een presentatie naar PDF converteert in Handout-modus.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Laad een presentatie.
using var presentation = new Presentation("sample.pptx");

// Stel de exportopties in.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 dia's op één pagina horizontaal
        PrintSlideNumbers = true,                   // print dia-nummers
        PrintFrameSlide = true,                     // print een kader om de dia's
        PrintComments = false                       // geen opmerkingen
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de `SlidesLayoutOptions`‑eigenschap alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

### Wat is het maximale aantal dia‑miniatuur‑beelden per pagina in Handout-modus?

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale volgorde: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

### Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia’s per pagina?

Nee. Het aantal en de volgorde van de miniaturen worden strikt beheerst door de [HandoutType](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handouttype/)‑enumeratie; willekeurige lay‑outs worden niet ondersteund.

### Kan ik verborgen dia’s opnemen in de Handout‑uitvoer?

Ja. Schakel de `ShowHiddenSlides`‑optie in de exportinstellingen in voor het gewenste formaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/htmloptions/), of [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/).