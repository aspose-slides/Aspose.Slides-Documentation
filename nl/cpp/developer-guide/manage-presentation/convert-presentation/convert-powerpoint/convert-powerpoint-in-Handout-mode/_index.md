---
title: PowerPoint-presentaties converteren in Handout-modus met C++
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PPT
- PPTX
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Converteer presentaties naar hand-outs in C++. Stel dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, met voorbeeldcode. Probeer het gratis."
---
## **Introductie**

Aspose.Slides biedt de mogelijkheid om presentaties te converteren naar verschillende formaten, inclusief het maken van hand-outs voor afdrukken in Handout-modus. Deze modus laat je configureren hoe meerdere dia's op één pagina worden weergegeven, wat handig is voor conferenties, seminars en andere evenementen. Je kunt deze modus inschakelen door de `set_SlidesLayoutOptions`‑methode aan te roepen in de [IPdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ihtmloptions/) en [ITiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/itiffoptions/) interfaces.

Om de afmetingen en oriëntatie van de hand-outpagina in te stellen vóór het exporteren, zie [Grootte van notitiepagina](/slides/nl/cpp/notes-size/).

## **Handout-modus export**

Om Handout-modus te configureren, gebruik je het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handoutlayoutingoptions/) object, dat bepaalt hoeveel dia's op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder staat een codevoorbeeld dat laat zien hoe je een presentatie naar PDF converteert in Handout-modus.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Een presentatie laden.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // dia‑nummers afdrukken
slidesLayoutOptions->set_PrintFrameSlide(true);                      // een kader rond de dia's afdrukken
slidesLayoutOptions->set_PrintComments(false);                       // geen commentaren

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

### Wat is het maximale aantal dia‑miniaturen per pagina in Handout-modus?

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale volgorde: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

### Kan ik een eigen raster definiëren, bijvoorbeeld 5 of 8 dia's per pagina?

Nee. Het aantal en de volgorde van miniaturen worden strikt bepaald door de [HandoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handouttype/)‑enumeratie; willekeurige lay-outs worden niet ondersteund.

### Kan ik verborgen dia's opnemen in de Handout‑output?

Ja. Gebruik de `set_ShowHiddenSlides`‑methode in de exportinstellingen voor het doelformaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/).