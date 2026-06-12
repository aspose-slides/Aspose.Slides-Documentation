---
title: PowerPoint-presentaties converteren in handout-modus in .NET
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
description: "Converteer presentaties naar handouts in .NET. Stel het aantal dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, met voorbeeldcode in C#. Probeer het gratis."
---
## **Introductie**

Aspose.Slides stelt u in staat presentaties te converteren naar uitvoerformaten die de Handout-modus ondersteunen. In deze modus worden meerdere dia's op één pagina geplaatst, wat handig is voor het afdrukken van presentatiematerialen voor conferenties, seminars en soortgelijke evenementen.

De Handout-modus wordt geconfigureerd via de eigenschap `SlidesLayoutOptions`, die beschikbaar is in [IPdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ihtmloptions/), en [ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/). Om de handout‑indeling te definiëren, gebruikt u het object [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handoutlayoutingoptions/).

## **Export in Handout-modus**

Om een presentatie in Handout-modus te exporteren, stelt u de eigenschap `SlidesLayoutOptions` in voor de doel‑exportopties en wijst u een instantie van [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handoutlayoutingoptions/) toe die het aantal dia's per pagina en gerelateerde weergave‑parameters definieert.

Hieronder ziet u een codevoorbeeld dat laat zien hoe u een presentatie naar PDF converteert in Handout-modus.

```c#
// Laad een presentatie.
using var presentation = new Presentation("sample.pptx");

// Stel de exportopties in.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 dia's op één pagina horizontaal
        PrintSlideNumbers = true,                   // dia‑nummers afdrukken
        PrintFrameSlide = true,                     // een kader om de dia's afdrukken
        PrintComments = false                       // geen opmerkingen
    }
};

// Exporteer de presentatie naar PDF met de gekozen lay-out.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de eigenschap `SlidesLayoutOptions` alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definieren, bijvoorbeeld 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van de miniaturen worden strikt bepaald door de enumeratie [HandoutType](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handouttype/); willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de Handout-uitvoer?**

Ja. Schakel de optie `ShowHiddenSlides` in de exportinstellingen voor het doelformaat in, bijvoorbeeld [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/htmloptions/), of [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/).