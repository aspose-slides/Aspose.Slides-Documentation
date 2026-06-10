---
title: PowerPoint-prezentációk konvertálása TIFF formátumba .NET-ben
titlelink: PowerPoint TIFF-re
type: docs
weight: 90
url: /hu/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint TIFF-re
- prezentáció TIFF-re
- dia TIFF-re
- PPT TIFF-re
- PPTX TIFF-re
- PPT mentése TIFFként
- PPTX mentése TIFFként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhat egyszerűen PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for .NET használatával. C# kódpéldák."
---
## **Bevezetés**

A TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képformátum, amely kivételes minőségéről és a grafika részletes megőrzéséről ismert. Tervezők, fotósok és asztali kiadók gyakran választják a TIFF-et, hogy megőrizzék a rétegeket, a színpontosságot és az eredeti beállításokat képeikben.

Az Aspose.Slides segítségével könnyedén konvertálhatja PowerPoint‑diait (PPT, PPTX) és OpenDocument‑diait (ODP) közvetlenül magas minőségű TIFF képekké, biztosítva, hogy bemutatói a lehető legnagyobb vizuális hűséget megőrizzék. 

## **Prezentáció konvertálása TIFF formátumba**

A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályban a [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódus használatával gyorsan konvertálhatja az egész PowerPoint‑prezentációt TIFF‑be. A kapott TIFF képek az alapértelmezett diaméretnek felelnek meg.

```cs
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képviseli.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Mentse a prezentációt TIFF formátumba.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Prezentáció konvertálása fekete-fehér TIFF formátumba**

A [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) osztályban a [BwConversionMode](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/bwconversionmode/) tulajdonság lehetővé teszi, hogy megadja az algoritmust, amelyet egy színes dia vagy kép fekete‑fehér TIFF‑be konvertálásakor használ. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [CompressionType](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/compressiontype/) tulajdonság `CCITT4` vagy `CCITT3` értékre van állítva.

Tegyük fel, hogy van egy "sample.pptx" fájlunk a következő diával:

![Egy prezentációs dia](slide_black_and_white.png)

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

Az eredmény:

![Fekete-fehér TIFF](TIFF_black_and_white.png)

## **Prezentáció konvertálása egyéni méretű TIFF‑be**

Ha speciális méretű TIFF‑képre van szüksége, a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) osztályban elérhető tulajdonságok segítségével állíthatja be a kívánt értékeket. Például az [ImageSize](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/imagesize/) tulajdonság lehetővé teszi a létrehozott kép méretének meghatározását.

```cs
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) reprezentál.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Állítsa be a tömörítési típust.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Tömörítési típusok:
        Default - Az alapértelmezett tömörítési séma (LZW) meghatározása.
        None - Nincs tömörítés.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // A mélység a tömörítési típustól függ, és nem állítható manuálisan.

    // Állítsa be a kép DPI értékét.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Állítsa be a kép méretét.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Mentse a prezentációt TIFF formátumba a megadott mérettel.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Prezentáció konvertálása egyéni képpontformátumú TIFF‑be**

A [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions) osztályban található [PixelFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/pixelformat/) tulajdonság használatával megadhatja a kívánt képpontformátumot a létrehozott TIFF‑képhez.

```cs
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) reprezentál.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    Az ImagePixelFormat a következő értékeket tartalmazza (a dokumentáció szerint):
        Format1bppIndexed - 1 bit per pixel, indexelt.
        Format4bppIndexed - 4 bit per pixel, indexelt.
        Format8bppIndexed - 8 bit per pixel, indexelt.
        Format24bppRgb    - 24 bit per pixel, RGB.
        Format32bppArgb   - 32 bit per pixel, ARGB.
    */

    // Mentse a prezentációt TIFF formátumba a megadott képmérettel.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tipp" color="primary" %}}
Tekintse meg az Aspose [INGYENES PowerPoint‑Poszter konvertálót](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Átkonvertálhatok egyetlen diát az egész PowerPoint‑prezentáció helyett TIFF‑be?**

Igen. Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑ és OpenDocument‑prezentációkból származó egyedi diákat különálló TIFF‑képekké konvertálja.

**Van valamilyen korlát a diák számában a prezentáció TIFF‑be konvertálásakor?**

Nem, az Aspose.Slides nem szab korlátozást a diák számára. Bármilyen méretű prezentációt konvertálhat TIFF formátumba.

**A PowerPoint‑animációk és áttűnési hatások megmaradnak a diák TIFF‑be konvertálásakor?**

Nem, a TIFF statikus képformátum. Ezért az animációk és áttűnési hatások nem maradnak meg; csak a diák statikus pillanatképei kerülnek exportálásra.