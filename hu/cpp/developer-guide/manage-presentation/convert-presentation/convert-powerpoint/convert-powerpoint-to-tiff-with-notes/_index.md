---
title: PowerPoint prezentációk konvertálása TIFF formátumba jegyzetekkel C++-ban
linktitle: PowerPoint TIFF-re jegyzetekkel
type: docs
weight: 100
url: /hu/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertálása
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
- PPT exportálása TIFF-re
- PPTX exportálása TIFF-re
- PowerPoint jegyzetekkel
- prezentáció jegyzetekkel
- dia jegyzetekkel
- PPT jegyzetekkel
- PPTX jegyzetekkel
- TIFF jegyzetekkel
- C++
- Aspose.Slides
description: "PowerPoint prezentációk konvertálása TIFF formátumba jegyzetekkel az Aspose.Slides for C++ használatával. Ismerje meg, hogyan exportálhat diákot előadói jegyzetekkel hatékonyan."
---
## **Bevezetés**

Aspose.Slides for C++ egyszerű megoldást kínál a PowerPoint és OpenDocument bemutatók (PPT, PPTX és ODP) jegyzettel való TIFF formátumba konvertálására. Ez a formátum széles körben használatos magas minőségű képtárolásra, nyomtatásra és dokumentumarchiválásra. Az Aspose.Slides segítségével nem csak az egész bemutatót exportálhatja előadói jegyzetekkel, hanem diaképek miniaturákat is generálhat a Jegyzet Dia nézetben. A konverziós folyamat egyszerű és hatékony, a `Save` metódust használva a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely az egész bemutatót TIFF képsorozattá alakítja, miközben megőrzi a jegyzeteket és az elrendezést.

## **Bemutató konvertálása TIFF formátumba jegyzetekkel**

A PowerPoint vagy OpenDocument bemutató TIFF-be jegyzetekkel mentése az Aspose.Slides for C++ használatával a következő lépéseket igényli:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt: töltse be a PowerPoint vagy OpenDocument fájlt.
1. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztályt annak megadására, hogyan jelenjenek meg a jegyzetek és megjegyzések.
1. Mentse a bemutatót TIFF formátumba: adja át a beállított opciókat a [Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusnak.

Legyen például egy "speaker_notes.pptx" fájlunk a következő diával:

![A bemutató dia előadói jegyzetekkel](slide_with_notes.png)

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // A jegyzeteket a dia alá jeleníti meg.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Az eredmény:

![A TIFF kép előadói jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tipp" color="info" %}}
Tekintse meg az Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

### A jegyzetek területének pozícióját szabályozni tudom a létrehozott TIFF-ben?

Igen. Használja a [jegyzetelrendezési beállításokat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), hogy a `None`, `BottomTruncated` vagy `BottomFull` opciók közül válasszon, melyek rendre a jegyzetek elrejtését, egy oldalon való elhelyezését vagy további oldalakra való áramoltatását teszik lehetővé.

### Hogyan csökkenthetem a jegyzetekkel ellátott TIFF fájl méretét anélkül, hogy látható minőségromlás jelentkezne?

Válasszon egy [hatékony tömörítést](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (pl. `LZW` vagy `RLE`), állítson be ésszerű DPI‑t, és ha elfogadható, használjon alacsonyabb [pixelformátumot](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (például 8 bpp vagy 1 bpp monokróm esetén). A [képméretek](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/set_imagesize/) enyhe csökkentése is segíthet anélkül, hogy jelentősen csökkentené az olvashatóságot.

### Befolyásolja a jegyzetek betűtípusa az eredményt, ha az eredeti betűtípusok hiányoznak a rendszerből?

Igen. A hiányzó betűtípusok [helyettesítést](/slides/hu/cpp/font-selection-sequence/) váltanak ki, ami megváltoztathatja a szövegmetrikákat és a megjelenést. Ennek elkerülése érdekében [szállítson be a szükséges betűtípusokat](/slides/hu/cpp/custom-font/) vagy állítson be egy alapértelmezett [tartalék betűtípust](/slides/hu/cpp/fallback-font/), hogy a kívánt tipográfia legyen használva.