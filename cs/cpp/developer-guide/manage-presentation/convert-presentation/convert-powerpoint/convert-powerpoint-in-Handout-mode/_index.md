---
title: Převod prezentací PowerPoint do režimu Handout pomocí C++
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/cpp/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim Handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Převádějte prezentace na podklady v C++. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků s Aspose.Slides, s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Introduction**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další události. Tento režim můžete aktivovat voláním metody `set_SlidesLayoutOptions` v rozhraních [IPdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ihtmloptions/), a [ITiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/itiffoptions/) .

Chcete‑li nastavit rozměry a orientaci stránky podkladu před exportem, viz [Velikost stránky poznámek](/slides/cs/cpp/notes-size/).

## **Handout Mode Export**

Pro nastavení režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handoutlayoutingoptions/), který určuje, kolik snímků je umístěno na jedné stránce a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

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

// Načíst prezentaci.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Nastavit exportní možnosti.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 snímky na jedné stránce vodorovně
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // vytisknout čísla snímků
slidesLayoutOptions->set_PrintFrameSlide(true);                      // vytisknout rám kolem snímků
slidesLayoutOptions->set_PrintComments(false);                       // žádné komentáře

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportovat prezentaci do PDF s vybraným rozložením.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Mějte na paměti, že metoda `set_SlidesLayoutOptions` je k dispozici pouze pro určité výstupní formáty, jako jsou PDF, HTML, TIFF, a při renderování jako obrázky.
{{% /alert %}} 

## **FAQ**

### What is the maximum number of slide thumbnails per page in Handout mode?

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

### Can I define a custom grid, such as 5 or 8 slides per page?

Ne. Počet a uspořádání miniatur je přísně řízen výčtem [HandoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handouttype/) ; libovolná rozvržení nejsou podporována.

### Can I include hidden slides in the Handout output?

Ano. Použijte metodu `set_ShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/), nebo [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/).