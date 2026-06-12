---
title: PowerPoint-presentaties converteren in Handout-modus met PHP
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PPT
- PPTX
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Convert presentaties naar handouts in PHP. Stel dia's per pagina in, bewaar notities, exporteer naar PDF of afbeeldingen met Aspose.Slides voor PHP, inclusief voorbeeldcode. Probeer het gratis."
---
## **Introductie**

Aspose.Slides biedt de mogelijkheid om presentaties te converteren naar verschillende formaten, inclusief het maken van handouts voor afdrukken in Handout-modus. Deze modus stelt u in staat om te bepalen hoe meerdere dia’s op één pagina worden weergegeven, wat handig is voor conferenties, seminars en andere evenementen. U kunt deze modus inschakelen door de `setSlidesLayoutOptions`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/), en [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/)‑klassen in te stellen.

## **Export van handout-modus**

Om de Handout-modus te configureren, gebruikt u het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/handoutlayoutingoptions/)‑object, dat bepaalt hoeveel dia’s op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder staat een code‑voorbeeld dat laat zien hoe u een presentatie naar PDF converteert in Handout-modus.

```php
// Laad een presentatie.
$presentation = new Presentation("sample.pptx");

// Stel de exportopties in.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // druk dia-nummers af
$slidesLayoutOptions->setPrintFrameSlide(true);                      // druk een frame rond de dia's af
$slidesLayoutOptions->setPrintComments(false);                       // geen opmerkingen

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Exporteer de presentatie naar PDF met de gekozen lay-out.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de `setSlidesLayoutOptions`‑methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal diathumbnails per pagina in Handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/php-java/aspose.slides/handouttype/) tot 9 thumbnails per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia’s per pagina?**

Nee. Het aantal en de volgorde van de thumbnails worden strikt bepaald door de [HandoutType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/handouttype/)‑klasse; willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia’s opnemen in de Handout-uitvoer?**

Ja. Schakel de verborgen dia’s in met de `setShowHiddenSlides`‑methode in de exportinstellingen voor het doelformaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/), of [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/).