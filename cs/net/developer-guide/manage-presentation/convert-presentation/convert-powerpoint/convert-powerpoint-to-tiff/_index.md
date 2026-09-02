---
title: Převod PowerPoint prezentací do TIFF v .NET
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
- prezentaci na TIFF
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
description: "Zjistěte, jak snadno převést PowerPoint (PPT, PPTX) prezentace na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro .NET. Příklady kódu v C#."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý pro svou výjimečnou kvalitu a detailní zachování grafiky. Designéři, fotografové a desktopoví vydavatelé často volí TIFF pro zachování vrstev, přesnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a snímky OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, což zajistí, že vaše prezentace zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do formátu TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímků.

Tento C# kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

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

Vlastnost [BwConversionMode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/bwconversionmode/) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/) vám umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se uplatňuje pouze tehdy, když je vlastnost [CompressionType](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/compressiontype/) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Poznámka" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/bwconversionmode/) je nastavení na úrovni exportu, které vybírá algoritmus převodu pixelů pro celý TIFF obrázek. Pro definování, jak by měla vypadat jednotlivá forma při aktivním režimu černobílého zobrazení, použijte [IShape.BlackWhiteMode](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/blackwhitemode/). Viz [Control Black-and-White Rendering for Shapes](/slides/cs/net/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Předpokládejme, že máme soubor "sample.pptx" s následujícím snímkem:

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

Tento C# kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

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
        None - Určuje žádnou kompresi.
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

    // Uložte prezentaci jako TIFF se zadanou velikostí.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Převod prezentace do TIFF s vlastním pixelformátem obrázku**

Pomocí vlastnosti [PixelFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/pixelformat/) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions) můžete určit požadovaný pixelformát pro výsledný TIFF obrázek.

Tento C# kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním pixelformátem:

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

    // Uložte prezentaci jako TIFF se zadanou velikostí obrázku.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Podívejte se na bezplatný konvertor PowerPoint na plakát od Aspose: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z PowerPoint i OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zůstávají animace a přechodové efekty PowerPointu zachovány při převodu snímků do TIFF?**

Ne, TIFF je formát statického obrázku. Proto nejsou animace a přechodové efekty zachovány; exportovány jsou pouze statické snímky snímků.