---
title: Převod prezentací PowerPoint do TIFF v JavaScriptu
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /cs/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do TIFF
- prezentaci do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro Node.js, s příklady kódu v JavaScriptu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný, bezztrátový rastrový formát obrázků známý pro svou výjimečnou kvalitu a detailní zachování grafiky. Návrháři, fotografové a desktopoví vydavatelé často volí TIFF, aby zachovali vrstvy, přesnost barev a původní nastavení ve svých obrázcích.

Pomocí Aspose.Slides můžete snadno převést své snímky PowerPoint (PPT, PPTX) a OpenDocument (ODP) přímo do vysoce kvalitních TIFF obrázků, což zajišťuje, že vaše prezentace zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) můžete rychle převést celou prezentaci PowerPoint do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento kód v JavaScriptu ukazuje, jak převést prezentaci PowerPoint do TIFF:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Uložte prezentaci jako TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do černobílého TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) umožňuje specifikovat algoritmus použité při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se uplatňuje pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

Řekněme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento kód v JavaScriptu ukazuje, jak převést barevný snímek na černobílý TIFF:

```js
let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setImageSize) umožňuje definovat velikost výsledného obrázku.

Tento kód v JavaScriptu ukazuje, jak převést prezentaci PowerPoint do TIFF obrázků s vlastní velikostí:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Nastavte typ komprese.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Typy komprese:
        Default - Určuje výchozí schéma komprese (LZW).
        None - Určuje žádnou kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nemůže být nastavena ručně.

    // Nastavte DPI obrázku.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Nastavte velikost obrázku.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci jako TIFF s určenou velikostí.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrázku**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) třídy [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) můžete specifikovat preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento kód v JavaScriptu ukazuje, jak převést prezentaci PowerPoint do TIFF obrázku s vlastním formátem pixelů:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexovaný.
        Format4bppIndexed - 4 bity na pixel, indexovaný.
        Format8bppIndexed - 8 bitů na pixel, indexovaný.
        Format24bppRgb    - 24 bitů na pixel, RGB.
        Format32bppArgb   - 32 bitů na pixel, ARGB.
    */

    /// Uložte prezentaci jako TIFF s určenou velikostí obrázku.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Podívejte se na [ZDARMA převodník PowerPoint na plakát](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online) od Aspose.
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé prezentace PowerPoint do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z prezentací PowerPoint a OpenDocument do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovají se animace a přechodové efekty PowerPointu při převodu snímků do TIFF?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; jsou exportovány pouze statické snímky.