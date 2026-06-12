---
title: "PowerPoint-presentaties converteren in Handout-modus met C++"
linktitle: "Handout-modus"
type: docs
weight: 150
url: /nl/cpp/convert-powerpoint-in-Handout-mode/
keywords:
  - "PowerPoint converteren"
  - "presentatie converteren"
  - "handout-modus"
  - "handout"
  - PPT
  - PPTX
  - PowerPoint
  - presentatie
  - C++
  - Aspose.Slides
description: "Converteer presentaties naar hand-outs in C++. Stel dia's per pagina in, bewaar notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, met voorbeeldcode. Probeer het gratis."
---
## **Inleiding**

Aspose.Slides biedt de mogelijkheid om presentaties te converteren naar diverse formaten, inclusief het maken van hand-outs voor afdrukken in Handout‑modus. Deze modus laat u configureren hoe meerdere dia’s op één pagina verschijnen, wat handig is voor conferenties, seminars en andere evenementen. U kunt deze modus inschakelen door de `set_SlidesLayoutOptions`‑methode in de [IPdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ihtmloptions/) en [ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) interfaces in te stellen.

## **Export in Handout‑modus**

Om de Handout‑modus te configureren, gebruikt u het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handoutlayoutingoptions/)‑object, dat bepaalt hoeveel dia’s op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder staat een code‑voorbeeld dat laat zien hoe u een presentatie naar PDF converteert in Handout‑modus.

```cpp
// Laad een presentatie.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Stel de exportopties in.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // druk dia-nummers af
slidesLayoutOptions->set_PrintFrameSlide(true);                      // druk een kader rond de dia's af
slidesLayoutOptions->set_PrintComments(false);                       // geen opmerkingen

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exporteer de presentatie naar PDF met de gekozen lay-out.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de `set_SlidesLayoutOptions`‑methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximum aantal miniatuur‑dia’s per pagina in Handout‑modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia’s per pagina?**

Nee. Het aantal en de ordening van miniaturen worden strikt beheerd door de [HandoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handouttype/)‑enumeratie; willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia’s opnemen in de Handout‑output?**

Ja. Gebruik de `set_ShowHiddenSlides`‑methode in de export‑instellingen voor het doelformaat, bijvoorbeeld [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/).