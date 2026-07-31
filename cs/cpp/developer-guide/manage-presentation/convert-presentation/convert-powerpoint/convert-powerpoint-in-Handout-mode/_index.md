---
title: Převod PowerPoint prezentací do režimu Handout pomocí C++
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/cpp/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Převádějte prezentace na handouty v C++. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření výtisků pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další akce. Tento režim můžete povolit nastavením metody `set_SlidesLayoutOptions` v rozhraních [IPdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ihtmloptions/), a [ITiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/itiffoptions/) .

## **Export v režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handoutlayoutingoptions/), který určuje, kolik snímků je umístěno na jedné stránce, a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```cpp
// Načíst prezentaci.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Nastavit exportní volby.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 snímky na jedné stránce horizontálně
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // vytisknout čísla snímků
slidesLayoutOptions->set_PrintFrameSlide(true);                      // vytisknout rámeček kolem snímků
slidesLayoutOptions->set_PrintComments(false);                       // žádné komentáře

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportovat prezentaci do PDF s vybraným rozložením.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Vezměte na vědomí, že metoda `set_SlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, například PDF, HTML, TIFF, a při vykreslování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur jsou přísně řízeny výčtem [HandoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handouttype/) ; volné rozvržení není podporováno.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Použijte metodu `set_ShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/), nebo [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/).