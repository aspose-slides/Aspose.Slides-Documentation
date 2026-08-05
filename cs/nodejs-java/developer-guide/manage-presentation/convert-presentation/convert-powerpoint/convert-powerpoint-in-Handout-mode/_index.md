---
title: Převod prezentací PowerPoint do režimu Handout pomocí JavaScriptu
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte prezentace na výtisky. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides pro Node.js, s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření výtisků pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, jak se více snímků zobrazí na jedné stránce, což je užitečné pro konference, semináře a další akce. Tento režim můžete povolit nastavením metody `setSlidesLayoutOptions` ve třídách [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/).

## **Export režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handoutlayoutingoptions/), který určuje, kolik snímků je umístěno na jedné stránce a další parametry zobrazení.

Níže je příklad kódu, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```js
// Načíst prezentaci.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Nastavit možnosti exportu.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 snímky na jedné stránce vodorovně
slidesLayoutOptions.setPrintSlideNumbers(true);                                // vytisknout čísla snímků
slidesLayoutOptions.setPrintFrameSlide(true);                                  // vytisknout rámeček okolo snímků
slidesLayoutOptions.setPrintComments(false);                                   // žádné komentáře

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exportovat prezentaci do PDF s vybraným rozvržením.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro určité výstupní formáty, jako jsou PDF, HTML, TIFF, a při vykreslování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet náhledových snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handouttype/) až 9 náhledových snímků na stránku s vodorovným nebo svislým uspořádáním: 1, 2, 3, 4 (vodorovně/svisle), 6 (vodorovně/svisle) a 9 (vodorovně/svisle).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání náhledových snímků je striktně řízen výčtem [HandoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/handouttype/); libovolná rozvržení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Použijte metodu `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/).