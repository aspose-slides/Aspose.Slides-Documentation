---
title: Převést prezentace PowerPoint do TIFF v C++
titlelink: PowerPoint na TIFF
type: docs
weight: 90
url: /cs/cpp/convert-powerpoint-to-tiff/
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
- C++
- Aspose.Slides
description: "Zjistěte, jak snadno převést prezentace PowerPoint (PPT, PPTX) na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro C++, s ukázkami kódu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný, bezztrátový rastrový formát obrázků, známý pro svou vynikající kvalitu a podrobnou zachování grafiky. Designéři, fotografové a desktopoví vydavatelé často volí TIFF pro zachování vrstev, přesnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo na vysoce kvalitní TIFF obrázky, což zajistí, že vaše prezentace si zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento C++ kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Uložte prezentaci jako TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Převod prezentace do černobílého TIFF**

Metoda [set_BwConversionMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/) umožňuje specifikovat algoritmus použitý při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se použije pouze tehdy, když je metoda [set_CompressionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) nastavena na `CCITT4` nebo `CCITT3`.

Předpokládejme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento C++ kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/). Například metoda [set_ImageSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_imagesize/) vám umožní definovat velikost výsledného obrázku.

Tento C++ kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Nastavte typ komprese.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
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
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Nastavte velikost obrázku.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Uložte prezentaci jako TIFF s určenou velikostí.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Převod prezentace do TIFF s vlastním pixelformátem obrázku**

Pomocí metody [set_PixelFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/) můžete specifikovat preferovaný pixelformát pro výsledný TIFF obrázek.

Tento C++ kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním pixelformátem:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
    Format1bppIndexed - 1 bit na pixel, indexováno.
    Format4bppIndexed - 4 bity na pixel, indexováno.
    Format8bppIndexed - 8 bitů na pixel, indexováno.
    Format24bppRgb    - 24 bitů na pixel, RGB.
    Format32bppArgb   - 32 bitů na pixel, ARGB.
*/

// Uložte prezentaci jako TIFF s určenou velikostí obrázku.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="primary" %}}
Podívejte se na Aspose’s [BEZPLATNÝ konvertor PowerPoint na plakát](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z PowerPoint a OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaké omezení počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Jsou animace a přechodové efekty PowerPointu zachovány při převodu snímků do TIFF?**

Ne, TIFF je formát statického obrázku. Proto nejsou animace a přechodové efekty zachovány; exportují se jen statické snímky snímků.