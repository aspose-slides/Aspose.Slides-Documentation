---
title: Převod prezentací PowerPoint do režimu Handout pomocí C++
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/cpp/convert-powerpoint-in-Handout-mode/
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
description: "Převádějte prezentace na podklady v C++. Nastavte snímky na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků s Aspose.Slides, s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim umožňuje nastavit, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další události. Tento režim můžete povolit nastavením metody `set_SlidesLayoutOptions` v rozhraních [IPdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ihtmloptions/) a [ITiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/itiffoptions/).

## **Export v režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handoutlayoutingoptions/), který určuje, kolik snímků je umístěno na jedné stránce a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```cpp
// Načíst prezentaci.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Nastavit možnosti exportu.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 snímky na jedné stránce horizontálně
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // tisknout čísla snímků
slidesLayoutOptions->set_PrintFrameSlide(true);                      // tisknout rámec kolem snímků
slidesLayoutOptions->set_PrintComments(false);                       // žádné komentáře

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportovat prezentaci do PDF s vybraným rozvržením.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 

Mějte na paměti, že metoda `set_SlidesLayoutOptions` je k dispozici jen pro některé výstupní formáty, například PDF, HTML, TIFF a při vykreslování jako obrázky.

{{% /alert %}} 

## **Časté dotazy**

**Jaký je maximální počet náhledů snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [presets](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handouttype/) až 9 náhledů na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání náhledů je přísně řízen výčtem [HandoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handouttype/); libovolné rozvržení není podporováno.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Použijte metodu `set_ShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/).