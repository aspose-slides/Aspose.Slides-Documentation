---
title: PowerPoint-presentaties omzetten in handout-modus met C++
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint omzetten
- presentatie omzetten
- handout-modus
- handout
- PPT
- PPTX
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Presentaties omzetten naar handouts in C++. Stel dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, met voorbeeldcode. Probeer het gratis."
---
## **Inleiding**

Aspose.Slides biedt de mogelijkheid om presentaties om te zetten naar verschillende formaten, inclusief het maken van handouts voor afdrukken in de handout-modus. Deze modus stelt u in staat om te configureren hoe meerdere dia's op één pagina worden weergegeven, wat nuttig is voor conferenties, seminars en andere evenementen. U kunt deze modus inschakelen door de `set_SlidesLayoutOptions`‑methode in te stellen op de [IPdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ihtmloptions/) en [ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) interfaces.

## **Export van handout-modus**

Om de handout-modus te configureren, gebruikt u het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handoutlayoutingoptions/) object, dat bepaalt hoeveel dia's op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder ziet u een code‑voorbeeld dat laat zien hoe u een presentatie naar PDF converteert in de handout-modus.

```cpp
// Laad een presentatie.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Stel de exportopties in.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // dia‑nummers afdrukken
slidesLayoutOptions->set_PrintFrameSlide(true);                      // een frame rond de dia's afdrukken
slidesLayoutOptions->set_PrintComments(false);                       // geen commentaren

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exporteer de presentatie naar PDF met de gekozen lay‑out.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de `set_SlidesLayoutOptions`‑methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen. 
{{% /alert %}} 

## **FAQ**

**Wat is het maximum aantal dia‑miniaturen per pagina in de handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van de miniaturen worden strikt bepaald door de [HandoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handouttype/) enumeratie; willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de handout-output?**

Ja. Gebruik de `set_ShowHiddenSlides`‑methode in de exportinstellingen voor het doel­formaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/).