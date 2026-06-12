---
title: Převod prezentací PowerPoint do režimu Handout pomocí JavaScriptu
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim Handout
- podklad
- PPT
- PPTX
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte prezentace na podklady. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides pro Node.js, s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další akce. Tento režim můžete povolit nastavením metody `setSlidesLayoutOptions` ve třídách [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/).

## **Export v režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handoutlayoutingoptions/), který určuje, kolik snímků bude umístěno na jedné stránce a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```js
// Načíst prezentaci.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Nastavit možnosti exportu.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 snímky na jedné stránce vodorovně
slidesLayoutOptions.setPrintSlideNumbers(true);                                // vytisknout čísla snímků
slidesLayoutOptions.setPrintFrameSlide(true);                                  // vytisknout rámeček kolem snímků
slidesLayoutOptions.setPrintComments(false);                                   // žádné komentáře

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exportovat prezentaci do PDF s vybraným rozvržením.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při renderování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur jsou přísně řízeny výčtem [HandoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handouttype/); libovolné rozvržení není podporováno.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Použijte metodu `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/).