---
title: Převod PowerPoint prezentací do TIFF na Androidu
titlelink: PowerPoint na TIFF
type: docs
weight: 90
url: /cs/androidjava/convert-powerpoint-to-tiff/
keywords:
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na TIFF
- prezentace na TIFF
- snímek na TIFF
- PPT na TIFF
- PPTX na TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- Android
- Java
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro Android s ukázkami kódu v Javě."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, který je známý vynikající kvalitou a podrobným zachováním grafiky. Návrháři, fotografové a desktopeři často volí TIFF, aby zachovali vrstvy, přesnost barev a původní nastavení ve svých obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace zachovají maximální vizuální věrnost. 

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) poskytnuté třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Vzniklé TIFF obrázky odpovídají výchozí velikosti snímku.

Tento kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Uložte prezentaci jako TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do černobílého TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/) vám umožňuje specifikovat algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se použije jen tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

Předpokládejme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) vám umožňuje definovat velikost výsledného obrázku.

Tento kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Nastavte typ komprese.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Typy komprese:
        Default - Specifikuje výchozí kompresní schéma (LZW).
        None - Specifikuje žádnou kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nelze ji nastavit ručně.

    // Nastavte DPI obrázku.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Nastavte velikost obrázku.
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci jako TIFF s určenou velikostí.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Převod prezentace do TIFF s vlastním formátem pixelů**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/) můžete specifikovat preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním formátem pixelů:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexováno.
        Format4bppIndexed - 4 bity na pixel, indexováno.
        Format8bppIndexed - 8 bitů na pixel, indexováno.
        Format24bppRgb    - 24 bitů na pixel, RGB.
        Format32bppArgb   - 32 bitů na pixel, ARGB.
    */
    
    // Uložte prezentaci jako TIFF s určenou velikostí obrázku.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Vyzkoušejte bezplatný konvertor PowerPoint na poster od Aspose [BEZPLATNÝ konvertor PowerPoint na poster](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides umožňuje samostatně převádět jednotlivé snímky z PowerPoint a OpenDocument prezentací do TIFF obrázků.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides nekladá žádná omezení na počet snímků. Můžete převést prezentace libovolné velikosti do formátu TIFF.

**Zachovají se animace a přechodové efekty PowerPointu při převodu snímků do TIFF?**

Ne, TIFF je formát statických obrázků. Animace a přechodové efekty nejsou zachovány; exportovány jsou pouze statické snímky snímků.