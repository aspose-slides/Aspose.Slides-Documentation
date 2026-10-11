---
title: Převod PowerPoint prezentací do režimu Handout pomocí Javy
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/java/convert-powerpoint-in-handout-mode/
keywords:
- převod PowerPoint
- převod prezentace
- režim handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Převádějte prezentace do handoutů v Javě. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, s ukázkovým kódem v Javě. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace do výstupních formátů, které podporují režim Handout. V tomto režimu jsou na jedné stránce uspořádány více snímků, což je užitečné pro tisk materiálů prezentace na konferencích, seminářích a podobných akcích.

Režim Handout se konfiguruje pomocí metody `setSlidesLayoutOptions`, která je k dispozici v [IPdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihtmloptions/) a [ITiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiffoptions/). Pro definování rozvržení handoutu použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handoutlayoutingoptions/).

Pro nastavení rozměrů a orientace stránky handoutu před exportem se podívejte na [Velikost stránky poznámek](/slides/cs/java/notes-size/).

## **Export v režimu Handout**

Pro export prezentace v režimu Handout nastavte metodu `setSlidesLayoutOptions` pro cílové exportní možnosti a přiřaďte instanci [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handoutlayoutingoptions/), která určuje počet snímků na stránce a související parametry zobrazení.

Níže je ukázka kódu, která ukazuje, jak převést prezentaci do PDF v režimu Handout.

```java
import com.aspose.slides.*;

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

{{% alert color="warning" title="Warning" %}}
Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při vykreslování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránce v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handouttype/) až 9 miniatur na stránku s vodorovným nebo svislým uspořádáním: 1, 2, 3, 4 (vodorovně/svisle), 6 (vodorovně/svisle) a 9 (vodorovně/svisle).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur je přísně řízen třídou [HandoutType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handouttype/); libovolné rozvržení není podporováno.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Povolit skryté snímky můžete pomocí metody `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/).