---
title: PowerPoint prezentációk konvertálása TIFF-re C++-ban
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

A TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képformátum, amely kivételes minőségről és a grafika részletes megőrzéséről ismert. Tervezők, fotósok és asztali kiadók gyakran választják a TIFF‑et a rétegek, a színpontosság és az eredeti beállítások megőrzésére a képeikben.

Az Aspose.Slides segítségével egyszerűen konvertálhatja PowerPoint‑diáit (PPT, PPTX) és OpenDocument‑diákat (ODP) közvetlenül magas minőségű TIFF‑képekké, biztosítva, hogy a bemutatók a maximális vizuális hűséget megtartsák.

## **Prezentáció konvertálása TIFF formátumba**

A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály által biztosított [Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódussal gyorsan konvertálhatja az egész PowerPoint‑prezentációt TIFF‑be. A kapott TIFF‑képek az alapértelmezett dia méretnek felelnek meg.

Ez a C++ kód bemutatja, hogyan konvertáljon PowerPoint‑prezentációt TIFF‑be:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Mentse a prezentációt TIFF formátumban.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Prezentáció konvertálása fekete-fehér TIFF‑be**

A [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban található [set_BwConversionMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) metódus lehetővé teszi az algoritmus megadását, amelyet a színes dia vagy kép fekete‑fehér TIFF‑be konvertálásakor használ. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [set_CompressionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) metódus értéke `CCITT4` vagy `CCITT3`.

Tegyük fel, hogy van egy „sample.pptx” fájlunk a következő diával:

![Egy prezentációs dia](slide_black_and_white.png)

Ez a C++ kód bemutatja, hogyan konvertálja a színes diát fekete‑fehér TIFF‑be:

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

## **Prezentáció konvertálása TIFF‑be egyedi mérettel**

Ha egy adott méretű TIFF‑képre van szüksége, a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztályban elérhető metódusokkal megadhatja a kívánt értékeket. Például a [set_ImageSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_imagesize/) metódus lehetővé teszi a létrehozandó kép méretének meghatározását.

Ez a C++ kód bemutatja, hogyan konvertáljon PowerPoint‑prezentációt egyedi méretű TIFF‑képekre:

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

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Állítsa be a tömörítéstípust.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Tömörítési típusok:
    Default - Az alapértelmezett tömörítési séma (LZW) meghatározása.
    None - Nincs tömörítés.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// A mélység a tömörítéstípustól függ, és nem állítható be manuálisan.

// Állítsa be a kép DPI‑jét.
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

## **Prezentáció konvertálása TIFF‑be egyedi képpontformátummal**

A [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztály [set_PixelFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) metódusával megadhatja a kívánt képpontformátumot a kimeneti TIFF‑képen.

Ez a C++ kód bemutatja, hogyan konvertáljon PowerPoint‑prezentációt egyedi képpontformátummal rendelkező TIFF‑képre:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
Az ImagePixelFormat a következő értékeket tartalmazza (a dokumentáció szerint):
    Format1bppIndexed - 1 bit pixelenként, indexelt.
    Format4bppIndexed - 4 bit pixelenként, indexelt.
    Format8bppIndexed - 8 bit pixelenként, indexelt.
    Format24bppRgb    - 24 bit pixelenként, RGB.
    Format32bppArgb   - 32 bit pixelenként, ARGB.
*/

// Mentse a prezentációt TIFF formátumban a megadott képmérettel.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Tekintse meg az Aspose [INGYENES PowerPoint‑ról poszterre konvertáló eszközét](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

### Konvertálhatok egyetlen diát a teljes PowerPoint‑prezentáció helyett TIFF‑be?

Igen. Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑ és OpenDocument‑prezentációk egyes diáit külön-külön TIFF‑képekké konvertálja.

### Van korlátozás a diák számát illetően, amikor egy prezentációt TIFF‑be konvertálok?

Nem, az Aspose.Slides nem szab korlátozást a diák számára. Bármilyen méretű prezentációt konvertálhat TIFF formátumba.

### A PowerPoint animációk és átmenetek megmaradnak a diák TIFF‑be konvertálásakor?

Nem, a TIFF egy statikus képformátum. Ezért az animációk és átmenetek nem maradnak meg; csak a diák statikus pillanatképei kerülnek exportálásra.