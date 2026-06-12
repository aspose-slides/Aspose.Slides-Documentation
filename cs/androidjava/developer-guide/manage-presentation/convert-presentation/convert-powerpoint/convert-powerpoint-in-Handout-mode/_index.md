---
title: Převod prezentací PowerPoint v režimu Handout na Androidu
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim handout
- podklad
- PPT
- PPTX
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Převádějte prezentace na podklady v Javě. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides pro Android, včetně ukázkového kódu. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim umožňuje nakonfigurovat, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další akce. Tento režim můžete aktivovat nastavením metody `setSlidesLayoutOptions` v rozhraních [IPdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihtmloptions/) a [ITiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiffoptions/).

## **Export v režimu Handout**

Pro nastavení režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handoutlayoutingoptions/), který určuje, kolik snímků je umístěno na jedné stránce a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```java
// Načtěte prezentaci.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Nastavte možnosti exportu.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 snímky na jedné stránce horizontálně
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // vytisknout čísla snímků
	slidesLayoutOptions.setPrintFrameSlide(true);                     // vytisknout rám kolem snímků
	slidesLayoutOptions.setPrintComments(false);                      // žádné komentáře

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportujte prezentaci do PDF s vybraným rozložením.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při renderování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [presets](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur jsou přísně řízeny třídou [HandoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handouttype/); libovolné rozvržení není podporováno.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Skryté snímky můžete povolit pomocí metody `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/).