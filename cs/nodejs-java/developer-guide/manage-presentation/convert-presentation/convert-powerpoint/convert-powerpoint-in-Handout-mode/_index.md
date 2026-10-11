---
title: Převod prezentací PowerPoint do režimu Handout pomocí JavaScriptu
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- převod PowerPoint
- převod prezentace
- režim handout
- podklad
- PPT
- PPTX
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte prezentace na podklady. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides pro Node.js, včetně ukázkového kódu. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další akce. Tento režim můžete povolit nastavením metody `setSlidesLayoutOptions` ve třídách [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/).

Pro nastavení rozměrů a orientace stránky podkladu před exportem viz [Velikost stránky poznámek](/slides/cs/nodejs-java/notes-size/).

## **Export v režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handoutlayoutingoptions/), který určuje, kolik snímků bude umístěno na jedné stránce a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// Načíst prezentaci.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 snímky na jedné stránce vodorovně
slidesLayoutOptions.setPrintSlideNumbers(true);                                // vytisknout čísla snímků
slidesLayoutOptions.setPrintFrameSlide(true);                                  // vytisknout rám kolem snímků
slidesLayoutOptions.setPrintComments(false);                                   // žádné komentáře

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při renderování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránce v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handouttype/) až 9 miniatur na stránku s vodorovným nebo svislým uspořádáním: 1, 2, 3, 4 (vodorovně/svisle), 6 (vodorovně/svisle) a 9 (vodorovně/svisle).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur je řízen striktně výčtem [HandoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handouttype/); libovolná rozvržení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Použijte metodu `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/).