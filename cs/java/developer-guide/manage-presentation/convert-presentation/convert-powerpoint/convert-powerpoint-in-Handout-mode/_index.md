---
title: Převod PowerPoint prezentací do režimu letáku pomocí Javy
linktitle: Režim letáku
type: docs
weight: 150
url: /cs/java/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim letáku
- leták
- PPT
- PPTX
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Převádějte prezentace na letáky v Javě. Nastavte snímky na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, s ukázkovým kódem v Javě. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace do výstupních formátů, které podporují režim letáku. V tomto režimu jsou více snímků uspořádány na jedné stránce, což je užitečné pro tisk materiálů prezentací pro konference, semináře a podobné akce.

Režim letáku je konfigurován pomocí metody `setSlidesLayoutOptions`, která je k dispozici v [IPdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihtmloptions/) a [ITiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiffoptions/). Pro definování rozvržení letáku použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handoutlayoutingoptions/).

## **Export v režimu letáku**

Pro export prezentace v režimu letáku nastavte metodu `setSlidesLayoutOptions` pro cílové exportní možnosti a přiřaďte instanci [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handoutlayoutingoptions/), která určuje počet snímků na stránku a související parametry zobrazení.

Níže je ukázka kódu, která ukazuje, jak převést prezentaci do PDF v režimu letáku.

```java
// Načíst prezentaci.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Nastavit možnosti exportu.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 snímky na jedné stránce vodorovně
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // tisk čísel snímků
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
Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při vykreslování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu letáku?**

Aspose.Slides podporuje [presets](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) a 9 (horizontal/vertical).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur je přísně řízen třídou [HandoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handouttype/); libovolná rozvržení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu letáku?**

Ano. Skryté snímky můžete povolit pomocí metody `setShowHiddenSlides` v nastaveních exportu pro cílový formát, jako jsou [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/).