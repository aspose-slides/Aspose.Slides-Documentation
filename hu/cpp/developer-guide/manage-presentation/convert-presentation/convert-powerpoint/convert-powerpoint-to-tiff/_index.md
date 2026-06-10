---
title: PowerPoint prezentációk konvertálása TIFF formátumba C++-ban
titlelink: PowerPoint TIFF-re
type: docs
weight: 90
url: /hu/cpp/convert-powerpoint-to-tiff/
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
- PPT mentése TIFF-ként
- PPTX mentése TIFF-ként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan konvertálhatja egyszerűen a PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for C++ használatával, kódrészletekkel."
---
## **Bevezetés**

TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képformátum, amely kivételes minőségéről és a grafika részletes megőrzéséről ismert. A tervezők, fényképészek és asztali kiadványszerkesztők gyakran választják a TIFF-et a rétegek, a színpontosság és az eredeti beállítások megőrzésére a képeikben.

Az Aspose.Slides segítségével könnyedén konvertálhatja PowerPoint diáját (PPT, PPTX) és OpenDocument diákat (ODP) közvetlenül magas minőségű TIFF képekké, biztosítva, hogy a bemutatók maximális vizuális hitelességet tartsanak meg.

## **Prezentáció konvertálása TIFF formátumba**

Az [Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust használva, amelyet a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály biztosít, gyorsan konvertálhatja egy teljes PowerPoint prezentációt TIFF-be. A keletkező TIFF képek az alapértelmezett dia méretnek felelnek meg.

Ez a C++ kód bemutatja, hogyan konvertálja a PowerPoint prezentációt TIFF-be:

```cpp
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Mentse a prezentációt TIFF formátumban.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Prezentáció konvertálása fekete-fehér TIFF-be**

A [set_BwConversionMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) metódus a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban lehetővé teszi, hogy meghatározza az algoritmust, amelyet a színes dia vagy kép fekete-fehér TIFF-be történő konvertálásához használ. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [set_CompressionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) metódus `CCITT4` vagy `CCITT3` értékre van állítva.

Tegyük fel, hogy van egy „sample.pptx” fájl a következő diával:

![A presentation slide](slide_black_and_white.png)

Ez a C++ kód bemutatja, hogyan konvertálja a színes diát fekete-fehér TIFF-be:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Az eredmény:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Prezentáció konvertálása TIFF-be egyedi mérettel**

Ha egy adott méretű TIFF képre van szüksége, a kívánt értékeket a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban elérhető metódusokkal állíthatja be. Például a [set_ImageSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_imagesize/) metódus lehetővé teszi a keletkező kép méretének meghatározását.

Ez a C++ kód bemutatja, hogyan konvertálja a PowerPoint prezentációt egyedi méretű TIFF képekké:

```cpp
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Állítsa be a tömörítési típust.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Tömörítési típusok:
    Default - Megadja az alapértelmezett tömörítési sémát (LZW).
    None - Nincs tömörítés.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// A mélység a tömörítési típustól függ, és nem állítható be manuálisan.

// Állítsa be a kép DPI-jét.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Állítsa be a kép méretét.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Mentse a prezentációt TIFF formátumban a megadott mérettel.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Prezentáció konvertálása TIFF-be egyedi képpontformátummal**

A [set_PixelFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) metódust a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályból használva megadhatja a kívánt képpontformátumot a keletkező TIFF képhez.

Ez a C++ kód bemutatja, hogyan konvertálja a PowerPoint prezentációt egyedi képpontformátumú TIFF képre:

```cpp
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat a következő értékeket tartalmazza (a dokumentáció szerint):
    Format1bppIndexed - 1 bit per pixel, indexelt.
    Format4bppIndexed - 4 bit per pixel, indexelt.
    Format8bppIndexed - 8 bit per pixel, indexelt.
    Format24bppRgb    - 24 bit per pixel, RGB.
    Format32bppArgb   - 32 bit per pixel, ARGB.
*/

// Mentse a prezentációt TIFF formátumban a megadott képmérettel.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="primary" %}}

Tekintse meg az Aspose ingyenes [PowerPoint poszter konvertálóját](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **GYIK**

**Át tudok konvertálni egyetlen diát a teljes PowerPoint prezentáció helyett TIFF-be?**

Igen. Az Aspose.Slides lehetővé teszi, hogy egyedi diákat konvertáljon PowerPoint és OpenDocument prezentációkból TIFF képpé külön-külön.

**Van korlátozás a diák számában, amikor egy prezentációt TIFF-be konvertálunk?**

Nem, az Aspose.Slides nem szab korlátozást a diák számára. Bármilyen méretű prezentációt konvertálhat TIFF formátumba.

**Megmaradnak-e a PowerPoint animációk és átmenet hatások a diák TIFF-be konvertálásakor?**

Nem, a TIFF egy statikus képformátum. Ezért az animációk és átmenet hatások nem maradnak meg; csak a diák statikus pillanatképei exportálódnak.