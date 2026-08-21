---
title: Převod PowerPoint prezentací do TIFF v .NET
titlelink: PowerPoint do TIFF
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
- PowerPoint do TIFF
- prezentace do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak snadno převést PowerPoint (PPT, PPTX) prezentace na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro .NET. Příklady kódu v C#."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků známý pro vynikající kvalitu a podrobnou zachování grafiky. Návrháři, fotografové i desktopoví publikátoři často volí TIFF k zachování vrstev, věrnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPointové snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [Uložit](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) můžete rychle převést celou PowerPointovou prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento C# kód ukazuje, jak převést PowerPointovou prezentaci do TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Uložte prezentaci jako TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Převod prezentace do černobílého TIFF**

Vlastnost [BwConversionMode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/bwconversionmode/) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/) vám umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se použije jen tehdy, když je vlastnost [CompressionType](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/compressiontype/) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Poznámka" %}}

[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/bwconversionmode/) je nastavení na úrovni exportu, které vybírá algoritmus převodu pixelů pro celý TIFF obrázek. Pro definování, jak má být zobrazen konkrétní tvar v režimu černobílého zobrazení, použijte [IShape.BlackWhiteMode](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/blackwhitemode/). Viz [Ovládání černobílého vykreslování pro tvary](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.

{{% /alert %}}

Předpokládejme, že máme soubor **sample.pptx** s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento C# kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí vlastností dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/). Například vlastnost [ImageSize](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/imagesize/) vám umožňuje definovat velikost výsledného obrázku.

Tento C# kód ukazuje, jak převést PowerPointovou prezentaci na TIFF obrázky s vlastní velikostí:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Nastavte typ komprese.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Typy komprese:
        Default - Určuje výchozí kompresní schéma (LZW).
        None - Určuje, že není použita žádná komprese.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nelze ji nastavit ručně.

    // Nastavte DPI obrázku.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Nastavte velikost obrázku.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Uložte prezentaci jako TIFF s určenou velikostí.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrázku**

Pomocí vlastnosti [PixelFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/pixelformat/) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions) můžete určit požadovaný formát pixelů pro vzniklý TIFF obrázek.

Tento C# kód ukazuje, jak převést PowerPointovou prezentaci na TIFF obrázek s vlastním formátem pixelů:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexováno.
        Format4bppIndexed - 4 bity na pixel, indexováno.
        Format8bppIndexed - 8 bitů na pixel, indexováno.
        Format24bppRgb    - 24 bitů na pixel, RGB.
        Format32bppArgb   - 32 bitů na pixel, ARGB.
    */

    // Uložte prezentaci jako TIFF s určenou velikostí obrázku.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Rada" color="info" %}}

Vyzkoušejte bezplatný převodník Aspose **PowerPoint na Poster** [ZDARMA PowerPoint na Poster převodník](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPointové prezentace do TIFF?**

Ano. Aspose.Slides vám umožňuje převádět jednotlivé snímky z PowerPointových i OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovají se při převodu snímků do TIFF animace a přechodové efekty PowerPointu?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; exportují se jen statické snímky.