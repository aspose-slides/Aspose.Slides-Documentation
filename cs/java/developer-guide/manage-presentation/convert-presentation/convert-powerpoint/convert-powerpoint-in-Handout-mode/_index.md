---
title: Převod PowerPoint prezentací do režimu Výtisk pomocí Javy
linktitle: Režim Výtisk
type: docs
weight: 150
url: /cs/java/convert-powerpoint-in-Handout-mode/
keywords:
- převod PowerPoint
- převod prezentace
- režim výtisku
- výtisk
- PPT
- PPTX
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Převod prezentací na výtisky v Javě. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, s ukázkovým kódem v Javě. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides umožňuje převádět prezentace do výstupních formátů, které podporují režim Výtisků. V tomto režimu jsou na jedné stránce uspořádány více snímků, což je užitečné pro tisk materiálů prezentace pro konference, semináře a podobné akce.

Režim Výtisků se nastavuje pomocí metody `setSlidesLayoutOptions`, která je k dispozici v [IPdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihtmloptions/) a [ITiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiffoptions/). Pro definování rozložení výtisku použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handoutlayoutingoptions/).

## **Export v režimu Výtisků**

Pro export prezentace v režimu Výtisků nastavte metodu `setSlidesLayoutOptions` pro cílové možnosti exportu a přiřaďte instanci [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handoutlayoutingoptions/), která určuje počet snímků na stránku a související parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Výtisků.

```java
// Načíst prezentaci.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Nastavit možnosti exportu.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 snímky na jedné stránce horizontálně
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // tisknout čísla snímků
    slidesLayoutOptions.setPrintFrameSlide(true);                     // tisknout rámec kolem snímků
    slidesLayoutOptions.setPrintComments(false);                      // žádné komentáře

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exportovat prezentaci do PDF s vybraným rozložením.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 

Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, například PDF, HTML, TIFF a při vykreslování jako obrázky.

{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu Výtisků?**

Aspose.Slides podporuje [presets](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur je řízen přísně třídou [HandoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handouttype/); libovolná rozložení nejsou podporována.

**Mohu zahrnout skryté snímky ve výstupu Výtisků?**

Ano. Povolení skrytých snímků provedete pomocí metody `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/).