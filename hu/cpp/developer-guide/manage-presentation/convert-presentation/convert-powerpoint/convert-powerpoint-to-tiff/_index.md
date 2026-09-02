---
title: PowerPoint előadások konvertálása TIFF formátumba C++-ban
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
description: "Ismerje meg, hogyan konvertálhat könnyedén PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for C++ segítségével, kódrészletekkel."
---
## **Bevezetés**

TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képfájl formátum, amely kivételes minőségéről és a grafika részletes megőrzéséről ismert. A tervezők, fotósok és asztali kiadók gyakran a TIFF-et választják rétegek, színpontosság és az eredeti beállítások megőrzése érdekében képeikben.

Aspose.Slides segítségével könnyedén konvertálhatja PowerPoint diáját (PPT, PPTX) és OpenDocument diáját (ODP) közvetlenül magas minőségű TIFF képekké, biztosítva, hogy a prezentációk maximális vizuális hűséggel maradjanak meg.

## **Prezentáció konvertálása TIFF formátumba**

A [Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódus használatával, amelyet a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály biztosít, gyorsan konvertálhat egy teljes PowerPoint prezentációt TIFF formátumba. A kapott TIFF képek az alapértelmezett dia méretnek felelnek meg.

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt TIFF-be:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) reprezentál.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Mentse a prezentációt TIFF formátumba.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Prezentáció konvertálása fekete-fehér TIFF formátumba**

A [set_BwConversionMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) metódus a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban lehetővé teszi, hogy megadja az algoritmust, amely színes dia vagy kép fekete-fehér TIFF-be konvertálásakor használatos. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [set_CompressionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) metódus `CCITT4` vagy `CCITT3` értékre van állítva.

{{% alert color="info" title="Megjegyzés" %}}
A [TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) egy export-szintű beállítás, amely a teljes TIFF kép pixelek konvertálási algoritmusát választja. Annak meghatározásához, hogy egy egyedi alakzat hogyan jelenjen meg fekete-fehér megjelenítési mód aktiválása esetén, használja az [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_blackwhitemode/) metódust. Példákért tekintse meg a [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) oldalt.
{{% /alert %}}

Tegyük fel, hogy van egy "sample.pptx" fájl a következő diával:

![Egy prezentáció dia](slide_black_and_white.png)

Ez a C++ kód bemutatja, hogyan konvertálhatja a színes diát fekete-fehér TIFF-be:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Az eredmény:

![Fekete-fehér TIFF](TIFF_black_and_white.png)

## **Prezentáció konvertálása TIFF-be egyéni mérettel**

Ha egyedi méretű TIFF képre van szüksége, a kívánt értékeket a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban elérhető metódusokkal állíthatja be. Például a [set_ImageSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_imagesize/) metódus lehetővé teszi a létrehozott kép méretének meghatározását.

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt TIFF képekké egyéni mérettel:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP, stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Állítsa be a tömörítési típust.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
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

// Állítsa be a kép DPI értékét.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Állítsa be a kép méretét.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Mentse a prezentációt TIFF formátumba a megadott mérettel.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Prezentáció konvertálása TIFF-be egyéni képpont formátummal**

A [set_PixelFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) metódus a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályból lehetővé teszi, hogy meghatározza a kívánt képpont formátumot a létrehozott TIFF képhez.

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt TIFF képre egyéni képpont formátummal:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP, stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
Az ImagePixelFormat a következő értékeket tartalmazza (a dokumentáció szerint):
    Format1bppIndexed - 1 bit képpontonként, indexelt.
    Format4bppIndexed - 4 bit képpontonként, indexelt.
    Format8bppIndexed - 8 bit képpontonként, indexelt.
    Format24bppRgb    - 24 bit képpontonként, RGB.
    Format32bppArgb   - 32 bit képpontonként, ARGB.
*/

// Mentse a prezentációt TIFF formátumba a megadott kép mérettel.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tipp" color="info" %}}
Nézze meg az Aspose [INGYENES PowerPoint poszter konverterét](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Át tudok konvertálni egyetlen diát a teljes PowerPoint prezentáció helyett TIFF-be?**

Igen. Az Aspose.Slides lehetővé teszi, hogy a PowerPoint és OpenDocument prezentációkból származó egyedi diák külön-külön TIFF képekké konvertálhatók.

**Van valamilyen korlát a diák számát illetően a prezentáció TIFF-be konvertálásakor?**

Nem, az Aspose.Slides nem szab korlátozást a diák számára. Bármilyen méretű prezentáció konvertálható TIFF formátumba.

**A PowerPoint animációk és áttűnési hatások megmaradnak a diák TIFF-be konvertálásakor?**

Nem, a TIFF egy statikus képfájl formátum. Ezért az animációk és áttűnési hatások nem maradnak meg; csak a diák statikus pillanatképei exportálódnak.