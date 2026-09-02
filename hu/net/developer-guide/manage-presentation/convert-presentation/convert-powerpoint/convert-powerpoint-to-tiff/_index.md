---
title: PowerPoint bemutatók konvertálása TIFF-be .NET-ben
titlelink: PowerPoint TIFF-be
type: docs
weight: 90
url: /hu/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertálása
- OpenDocument konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint TIFF-be
- bemutató TIFF-be
- dia TIFF-be
- PPT TIFF-be
- PPTX TIFF-be
- PPT mentése TIFF-ként
- PPTX mentése TIFF-ként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhat egyszerűen PowerPoint (PPT, PPTX) bemutatókat magas minőségű TIFF képekké az Aspose.Slides for .NET segítségével. C# kódrészletek."
---
## **Bevezetés**

A TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képfájl-formátum, amely kimagasló minőségéről és a grafika részletes megőrzéséről ismert. Tervezők, fotósok és asztali kiadók gyakran választják a TIFF-et, hogy megőrizzék a rétegeket, a színpontosságot és az eredeti beállításokat képeiken.

Az Aspose.Slides segítségével egyszerűen konvertálhatja PowerPoint-diái (PPT, PPTX) és OpenDocument-diái (ODP) közvetlenül magas minőségű TIFF képekké, biztosítva, hogy a bemutatók maximális vizuális hűséggel maradjanak.

## **Bemutató konvertálása TIFF formátumba**

A [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódus használatával, amely a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályban érhető el, gyorsan konvertálhat egy teljes PowerPoint bemutatót TIFF-be. Az eredményül kapott TIFF képek az alapértelmezett diamérethez igazodnak.

Az alábbi C# kód bemutatja, hogyan konvertálhatunk egy PowerPoint bemutatót TIFF formátumba:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy Presentation osztály példányt, amely egy bemutató fájlt (PPT, PPTX, ODP stb.) képviseli.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Mentse a bemutatót TIFF formátumba.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Bemutató konvertálása fekete-fehér TIFF-be**

A [BwConversionMode](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/bwconversionmode/) tulajdonság a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) osztályban lehetővé teszi, hogy meghatározza az algoritmust, amely a színes dia vagy kép fekete-fehér TIFF-be konvertálásakor használatos. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [CompressionType](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/compressiontype/) tulajdonság `CCITT4` vagy `CCITT3` értékre van állítva.

{{% alert color="info" title="Note" %}}

A [TiffOptions.BwConversionMode](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/bwconversionmode/) egy exportszintű beállítás, amely egy pixelkonvertálási algoritmust választ a teljes TIFF képhez. Ahhoz, hogy egy egyedi alakzat megjelenését szabályozza fekete-fehér megjelenítési mód aktiválásakor, használja az [IShape.BlackWhiteMode](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/blackwhitemode/). Tekintse meg a [Control Black-and-White Rendering for Shapes](/slides/hu/net/shape-formatting/#control-black-and-white-rendering-for-shapes) oldalt példákért.

{{% /alert %}}

Tegyük fel, hogy van egy "sample.pptx" fájl a következő diával:

![A presentation slide](slide_black_and_white.png)

Az alábbi C# kód bemutatja, hogyan konvertálhatjuk a színes diát fekete-fehér TIFF-be:

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

Az eredmény:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Bemutató konvertálása egyedi méretű TIFF-be**

Ha egy meghatározott méretű TIFF képre van szüksége, a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) osztályban elérhető tulajdonságokkal beállíthatja a kívánt értékeket. Például az [ImageSize](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/imagesize/) tulajdonság lehetővé teszi a létrehozandó kép méretének meghatározását.

Az alábbi C# kód bemutatja, hogyan konvertálhatunk egy PowerPoint bemutatót egyedi méretű TIFF képekké:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy Presentation osztály példányt, amely egy bemutató fájlt (PPT, PPTX, ODP stb.) képvisel.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Állítsa be a tömörítési típust.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Tömörítési típusok:
        Default - Megadja az alapértelmezett tömörítési sémát (LZW).
        None - Megadja, hogy nincs tömörítés.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // A mélység a tömörítési típustól függ, és nem állítható manuálisan.

    // Állítsa be a kép DPI-jét.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Állítsa be a kép méretét.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Mentse a bemutatót TIFF formátumba a megadott mérettel.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Bemutató konvertálása egyedi képpontformátumú TIFF-be**

A [PixelFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/pixelformat/) tulajdonság a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions) osztályból lehetővé teszi, hogy megadja a kívánt képpontformátumot a létrehozandó TIFF képhez.

Az alábbi C# kód bemutatja, hogyan konvertálhatunk egy PowerPoint bemutatót egyedi képpontformátumú TIFF képre:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Létrehozza a Presentation osztályt, amely egy bemutató fájlt (PPT, PPTX, ODP stb.) képvisel.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat tartalmazza a következő értékeket (ahogy a dokumentációban szerepel):
        Format1bppIndexed - 1 bit per pixel, indexált.
        Format4bppIndexed - 4 bit per pixel, indexált.
        Format8bppIndexed - 8 bit per pixel, indexált.
        Format24bppRgb    - 24 bit per pixel, RGB.
        Format32bppArgb   - 32 bit per pixel, ARGB.
    */

    // Mentse a bemutatót TIFF formátumba a megadott képmérettel.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}

Nézze meg az Aspose ingyenes [PowerPoint poszter konvertálóját](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **GYIK**

**Átkonvertálhatok egy egyedi diát a teljes PowerPoint bemutató helyett TIFF-be?**

Igen. Az Aspose.Slides lehetővé teszi, hogy a PowerPoint és OpenDocument bemutatók egyedi diáit külön-külön TIFF képpé konvertálja.

**Van korlátozás a diák számában a bemutató TIFF-be konvertálásakor?**

Nem, az Aspose.Slides nem szab korlátozást a diák számára. Bármilyen méretű bemutatót konvertálhat TIFF formátumba.

**A PowerPoint animációk és áttűnési effektusok megmaradnak a diák TIFF-be konvertálásakor?**

Nem, a TIFF egy statikus képformátum. Ezért az animációk és áttűnési effektusok nem maradnak meg; csak a diák statikus pillanatképe kerül exportálásra.