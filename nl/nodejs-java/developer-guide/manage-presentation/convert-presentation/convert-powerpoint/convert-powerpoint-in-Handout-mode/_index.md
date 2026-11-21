---
title: PowerPoint-presentaties converteren in Handout-modus met JavaScript
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PPT
- PPTX
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer presentaties naar handouts. Stel dia's per pagina in, behoud aantekeningen, exporteer naar PDF of afbeeldingen met Aspose.Slides voor Node.js, met voorbeeldcode. Probeer het gratis."
---
## **Inleiding**

Aspose.Slides biedt de mogelijkheid om presentaties te converteren naar verschillende formaten, inclusief het maken van hand‑outs voor afdrukken in Handout‑modus. Deze modus stelt je in staat om te configureren hoe meerdere dia's op één pagina worden weergegeven, wat handig is voor conferenties, seminars en andere evenementen. Je kunt deze modus inschakelen door de `setSlidesLayoutOptions`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/) en [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) classes in te stellen.

Om de afmetingen en oriëntatie van de handoutpagina vóór het exporteren in te stellen, zie [Notes Page Size](/slides/nl/nodejs-java/notes-size/).

## **Handout‑modus export**

Om Handout‑modus te configureren, gebruik je het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/handoutlayoutingoptions/) object, dat bepaalt hoeveel dia's op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder staat een code‑voorbeeld dat toont hoe je een presentatie naar PDF convert in Handout‑modus.

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
slidesLayoutOptions.setPrintSlideNumbers(true);                                // print dia-nummers
slidesLayoutOptions.setPrintFrameSlide(true);                                  // print een kader rond dia's
slidesLayoutOptions.setPrintComments(false);                                   // geen commentaren

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
Houd er rekening mee dat de `setSlidesLayoutOptions`‑methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout‑modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale volgorde: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, zoals 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van miniaturen worden strikt bepaald door de [HandoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/handouttype/) enumeratie; willekeurige indelingen worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de Handout‑uitvoer?**

Ja. Gebruik de `setShowHiddenSlides`‑methode in de exportinstellingen voor het doelformaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/).