---
title: Převod PowerPoint prezentací do TIFF v JavaScriptu
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
- prezentace do TIFF
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
description: "Naučte se snadno převádět PowerPoint (PPT, PPTX) prezentace na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro Node.js s příklady kódu v JavaScriptu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý pro svou vynikající kvalitu a podrobnou zachování grafiky. Návrháři, fotografové a desktopeři často volí TIFF k zachování vrstev, přesnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo do vysoce kvalitních TIFF obrázků, čímž zajistíte, že vaše prezentace si zachová maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Vzniklé TIFF obrázky odpovídají výchozí velikosti snímku.

Tento JavaScript kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) vám umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku do černobílého TIFF. Všimněte si, že toto nastavení se použije pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) je nastavení úrovně exportu, které vybírá algoritmus převodu pixelů pro celý TIFF obrázek. Pro určení, jak má jednotlivý tvar vypadat v režimu černobílého zobrazení, použijte [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Viz [Control Black-and-White Rendering for Shapes](/slides/cs/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Předpokládejme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento JavaScript kód ukazuje, jak převést barevný snímek do černobílého TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setImageSize) vám umožňuje definovat velikost výsledného obrázku.

Tento JavaScript kód ukazuje, jak převést PowerPoint prezentaci do TIFF obrázků s vlastní velikostí:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Nastavte typ komprese.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Typy komprese:
        Default - Určuje výchozí schéma komprese (LZW).
        None - Určuje, že se žádná komprese neprovádí.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka barev je řízena formátem pixelu (viz příklad níže); CCITT3 a CCITT4 vždy vytvářejí 1 bit na pixel.

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

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) můžete určit preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento JavaScript kód ukazuje, jak převést PowerPoint prezentaci do TIFF obrázku s vlastním formátem pixelů:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert title="Tip" color="info" %}}
Vyzkoušejte zdarma konvertor Aspose pro převod PowerPoint na plakát: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides vám umožňuje převádět jednotlivé snímky z PowerPoint i OpenDocument prezentací do TIFF obrázků samostatně.

**Je nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovají se animace a přechodové efekty PowerPointu při převodu snímků do TIFF?**

Ne, TIFF je formát statického obrázku. Animace a přechodové efekty tedy nejsou zachovány; jsou exportovány pouze statické snímky snímků.