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
description: "Tanulja meg, hogyan konvertálhat egyszerűen PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for C++ használatával, kódrészletekkel."
---
## **Bevezetés**

A TIFF (Tagged Image File Format) egy széles körben használt, veszteségmentes raszteres képfájl-formátum, amely kivételes minőségről és a grafika részletes megőrzéséről ismert. A tervezők, fotósok és asztali kiadók gyakran választják a TIFF-et, hogy megőrizzék a rétegeket, a színek pontosságát és az eredeti beállításokat a képeiken.

Az Aspose.Slides segítségével egyszerűen átalakíthatja PowerPoint diáidat (PPT, PPTX) és OpenDocument diákat (ODP) közvetlenül magas minőségű TIFF képekké, ezáltal biztosítva, hogy a bemutatók a lehető legnagyobb vizuális hűséggel maradjanak meg.

## **Prezentáció konvertálása TIFF formátumba**

Az [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály [Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusával gyorsan átalakíthat egy teljes PowerPoint prezentációt TIFF formátumba. A létrejövő TIFF képek az alapértelmezett diaméretnek felelnek meg.

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt TIFF formátumba:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP, stb.) képviseli.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Prezentáció konvertálása fekete-fehér TIFF formátumba**

Az [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban található [set_BwConversionMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) metódus lehetővé teszi, hogy megadja az algoritmust, amelyet színes dia vagy kép fekete-fehér TIFF formátumba konvertálásakor használ. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [set_CompressionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) metódus `CCITT4` vagy `CCITT3` értékre van állítva.

{{% alert color="info" title="Megjegyzés" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) egy export-szintű beállítás, amely a teljes TIFF kép pixelkonverziós algoritmusát választja. Annak meghatározásához, hogyan jelenjen meg egy adott alakzat fekete-fehér megjelenítési mód aktiválásakor, használja az [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_blackwhitemode/)-t. Példákért tekintse meg a [Control Black-and-White Rendering for Shapes](/slides/hu/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) oldalt.
{{% /alert %}}

Tegyük fel, hogy van egy „sample.pptx” fájlunk a következő diával:

![Egy prezentációs dia](slide_black_and_white.png)

Ez a C++ kód bemutatja, hogyan konvertálhatja a színes diát fekete-fehér TIFF formátumba:

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

## **Prezentáció konvertálása TIFF formátumba egyedi mérettel**

Ha egy adott méretű TIFF képre van szüksége, a kívánt értékeket a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban elérhető metódusokkal állíthatja be. Például a [set_ImageSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_imagesize/) metódus lehetővé teszi a létrehozott kép méretének meghatározását.

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt TIFF képekké egyedi mérettel:

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

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP, stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Állítsa be a tömörítési típust.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Tömörítési típusok:
    Default - Az alapértelmezett tömörítési séma meghatározása (LZW).
    None - Nincs tömörítés.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// A mélység a tömörítési típustól függ, és nem állítható be manuálisan.

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

## **Prezentáció konvertálása TIFF formátumba egyedi képpontformátummal**

A [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztály [set_PixelFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) metódusával megadhatja a kívánt pixelformátumot a létrehozott TIFF képhez.

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt TIFF képre egyedi pixelformátummal:

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

// Mentse a prezentációt TIFF formátumba a megadott képmérettel.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tipp" color="info" %}}
Nézze meg az Aspose [INGYENES PowerPoint poszter konvertert](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Konvertálhatok egyetlen diát a teljes PowerPoint prezentáció helyett TIFF formátumba?**

Igen. Az Aspose.Slides lehetővé teszi, hogy egyes diákat a PowerPoint és OpenDocument prezentációkból külön-külön TIFF képekké konvertáljon.

**Van korlátozás a diák számában, amikor egy prezentációt TIFF-be konvertálunk?**

Nem, az Aspose.Slides nem szab korlátozásokat a diák számára. Bármilyen méretű prezentációt konvertálhat TIFF formátumba.

**Megmaradnak a PowerPoint animációk és áttűnési hatások a diák TIFF formátumba konvertálásakor?**

Nem, a TIFF egy statikus képfájl-formátum. Ezért az animációk és áttűnési hatások nem maradnak meg; csak a diák statikus pillanatképei kerülnek exportálásra.