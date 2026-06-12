---
title: Převést prezentace PowerPoint do TIFF v .NET
titlelink: PowerPoint na TIFF
type: docs
weight: 90
url: /cs/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro .NET. Příklady kódu v C#."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, který je známý svou vynikající kvalitou a detailním zachováním grafiky. Návrháři, fotografové a desktopoví vydavatelé často volí TIFF, aby zachovali vrstvy, přesnost barev a původní nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a snímky OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace si zachovají maximální vizuální věrnost.

## **Převést prezentaci do TIFF**

Pomocí metody [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Vzniklé TIFF obrázky odpovídají výchozí velikosti snímku.

Tento C# kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Uložte prezentaci jako TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Převést prezentaci do černobílého TIFF**

Vlastnost [BwConversionMode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/bwconversionmode/) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/) vám umožňuje určit algoritmus použitý při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení platí pouze když je vlastnost [CompressionType](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/compressiontype/) nastavena na `CCITT4` nebo `CCITT3`.

Předpokládejme, že máme soubor „sample.pptx“ s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento C# kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```cs
TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převést prezentaci do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí vlastností dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/). Například vlastnost [ImageSize](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/imagesize/) vám umožňuje definovat velikost výsledného obrázku.

Tento C# kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Nastavte typ komprese.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Typy komprese:
        Default - Určuje výchozí kompresní schéma (LZW).
        None - Určuje žádnou kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nemůže být nastavena ručně.

    // Nastavte DPI obrázku.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Nastavte velikost obrázku.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Uložte prezentaci jako TIFF se zadanou velikostí.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Převést prezentaci do TIFF s vlastním formátem pixelů obrázku**

Pomocí vlastnosti [PixelFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/pixelformat/) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions) můžete určit preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento C# kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním formátem pixelů:

```cs
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexovaný.
        Format4bppIndexed - 4 bity na pixel, indexovaný.
        Format8bppIndexed - 8 bitů na pixel, indexovaný.
        Format24bppRgb    - 24 bitů na pixel, RGB.
        Format32bppArgb   - 32 bitů na pixel, ARGB.
    */

    // Uložte prezentaci jako TIFF se zadanou velikostí obrázku.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
Podívejte se na Aspose's [ZDARMA konvertor PowerPoint na plakát](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides vám umožňuje převést jednotlivé snímky z PowerPoint a OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovají se při převodu snímků do TIFF animace a přechodové efekty PowerPointu?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; exportovány jsou pouze statické snímky snímků.