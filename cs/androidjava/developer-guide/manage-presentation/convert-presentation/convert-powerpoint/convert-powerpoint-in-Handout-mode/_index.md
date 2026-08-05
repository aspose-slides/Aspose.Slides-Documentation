---
title: Převod PowerPoint prezentací do režimu Handout na Androidu
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Převádějte prezentace na podklady v Javě. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků s Aspose.Slides pro Android, včetně ukázkového kódu. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, kolik snímků se zobrazí na jedné stránce, což je užitečné pro konference, semináře a další akce. Tento režim můžete aktivovat nastavením metody `setSlidesLayoutOptions` v rozhraních [IPdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihtmloptions/), a [ITiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiffoptions/).

## **Export v režimu Handout**

Pro nastavení režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handoutlayoutingoptions/), který určuje, kolik snímků bude umístěno na jedné stránce a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```java
// Načíst prezentaci.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Nastavit možnosti exportu.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 snímky na jedné stránce horizontálně
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // vytisknout čísla snímků
	slidesLayoutOptions.setPrintFrameSlide(true);                     // vytisknout rámeček kolem snímků
	slidesLayoutOptions.setPrintComments(false);                      // žádné komentáře

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportovat prezentaci do PDF s vybraným rozvržením.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 

Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici jen pro některé výstupní formáty, jako PDF, HTML, TIFF a při vykreslování jako obrázky.

{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [presety](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur je řízeno výhradně třídou [HandoutType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handouttype/); vlastní rozvržení není podporováno.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Povolení skrytých snímků provedete pomocí metody `setShowHiddenSlides` v nastaveních exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/), nebo [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/).