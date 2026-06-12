---
title: "PowerPoint-presentaties converteren in Handout-modus met Java"
linktitle: "Handout-modus"
type: docs
weight: 150
url: /nl/java/convert-powerpoint-in-Handout-mode/
keywords:
- "PowerPoint converteren"
- "presentatie converteren"
- "handout-modus"
- "handout"
- "PPT"
- "PPTX"
- "PowerPoint"
- "presentatie"
- "Java"
- "Aspose.Slides"
description: "Converteer presentaties naar handouts in Java. Stel het aantal dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, inclusief voorbeeld-Java-code. Probeer het gratis."
---
## **Introductie**

Aspose.Slides stelt je in staat om presentaties te converteren naar uitvoerformaten die de Handout-modus ondersteunen. In deze modus worden meerdere dia's op één pagina gerangschikt, wat handig is voor het afdrukken van presentatiemateriaal voor conferenties, seminars en soortgelijke evenementen.

De Handout-modus wordt geconfigureerd via de `setSlidesLayoutOptions`-methode, die beschikbaar is in [IPdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihtmloptions/) en [ITiffOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiffoptions/). Om de handout-indeling te definiëren, gebruik je het object [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handoutlayoutingoptions/).

## **Exporteren in Handout-modus**

Om een presentatie in Handout-modus te exporteren, stel je de `setSlidesLayoutOptions`-methode in voor de doel-exportopties en wijs je een [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handoutlayoutingoptions/) instantie toe die het aantal dia's per pagina en gerelateerde weergave‑parameters definieert.

Hieronder staat een codevoorbeeld dat laat zien hoe je een presentatie naar PDF converteert in Handout-modus.

```java
// Laad een presentatie.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Stel de exportopties in.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // print dia‐nummers
    slidesLayoutOptions.setPrintFrameSlide(true);                     // print een kader rond dia's
    slidesLayoutOptions.setPrintComments(false);                      // geen opmerkingen

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exporteer de presentatie naar PDF met de gekozen lay‑out.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de `setSlidesLayoutOptions`-methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van de miniaturen worden strikt bepaald door de [HandoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handouttype/)-klasse; willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de Handout-uitvoer?**

Ja. Schakel de verborgen dia's in met de `setShowHiddenSlides`-methode in de exportinstellingen voor het doel‑formaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tiffoptions/).