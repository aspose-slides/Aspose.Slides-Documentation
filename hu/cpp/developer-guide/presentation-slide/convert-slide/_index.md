---
title: Prezentációs diák képekké konvertálása C++-ban
linktitle: Dia képpé
type: docs
weight: 41
url: /hu/cpp/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képbe
- dia mentése képként
- dia EMF-be
- dia PNG-be
- dia JPEG-be
- dia bitmapbe
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP prezentációk diáját PNG, JPEG, GIF, TIFF, EMF és egyéb képadatformátumokba C++-ban az Aspose.Slides for C++ segítségével."
---
## **Bevezetés**

Az Aspose.Slides for C++ képes megjeleníteni egyedi diákot PowerPoint és OpenDocument bemutatókból PNG, JPEG, GIF, TIFF és más képformátumokban.

A dia képpé konvertálásához kövesse az alábbi lépéseket:

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztállyal.
2. Válassza ki a megjeleníteni kívánt diát.
3. Szükség esetén konfigurálja a renderelést a [RenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/renderingoptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztállyal.
4. Hívja meg a [ISlide::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) metódust. Ez egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumot ad vissza.
5. Hívja meg az [IImage::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/save/) metódust, és adja meg a kimeneti formátumot egy [ImageFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imageformat/) értékkel.

## **Dia konvertálása PNG képpé**

A legegyszerűbb konvertálás az alapértelmezett renderelési beállításokat használja. Az eredményül kapott [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektum memóriában feldolgozható vagy fájlba menthető.

Az alábbi C++ példa rendereli az első diát, és PNG képként menti el:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Dia(k) konvertálása egyedi méretű képekké**

Használja a [ISlide::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) túlterhelést, amely egy [Size](https://reference.aspose.com/slides/hu/cpp/system.drawing/size/) értéket fogad, hogy a diát pontos pixelmérettel renderelje.

Az alábbi példa 1820 × 1040 méretű JPEG képet hoz létre:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Dia(k) konvertálása képekké jegyzetekkel és megjegyzésekkel**

Alapértelmezés szerint a diaképek nem tartalmazzák a jegyzeteket vagy megjegyzéseket. Rendeljen egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) objektumot a [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) metódushoz, hogy szabályozza, hol jelenjenek meg a jegyzetek és megjegyzések.

Az alábbi példa a levágott jegyzeteket a dia alá, a megjegyzéseket pedig jobbra helyezi:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Dia‑képre konvertálás során ne állítsa be a [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) metódust a [BottomFull](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notespositions/) értékre. A jegyzetek több szöveget is tartalmazhatnak, mint amennyit a rögzített képméret befogad. Használja helyette a [BottomTruncated](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notespositions/) értéket.
{{% /alert %}}

## **Dia(k) konvertálása képekké TIFF beállítások használatával**

A [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) osztály lehetővé teszi a renderelt TIFF kép méretének, felbontásának és egyéb tulajdonságainak szabályozását.

Az alábbi példa az első diát 2160 × 2880 méretű, 300 DPI felbontású TIFF képként rendereli:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Az összes dia képekké konvertálása**

Iteráljon a dia gyűjteményén, hogy az egész prezentációt képsorozattá konvertálja. A rejtett diák is belekerülnek, hacsak nem hagyja ki őket kifejezetten.

Az alábbi példa minden diát JPEG képként renderel, a vízszintes és függőleges méretezési tényezőkkel 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Enhanced Metafile (EMF) létrehozása**

Az Enhanced Metafile (EMF) akkor hasznos, ha vektoros grafikát kell cserélni a Microsoft Office‑szal vagy más, Windows metafájlokat támogató Windows alkalmazásokkal. A pixel alapú képekhez képest egy EMF megmaradhatja a vektoros rajzolási műveleteket, amelyek méretezése nem jár olyan mértékű élességveszteséggel. Az EMF azonban elsősorban kompatibilitási formátum Windows metafájl támogatással rendelkező alkalmazások számára, nem pedig univerzális csereformátum. Továbbá a komplex diatartalom, például bitmap képek és egyes hatások, vektor metafájl tárolóban raszter elemekként tárolhatók.

### **Dia exportálása EMF‑be**

A [ISlide::WriteAsEmf](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/writeasemf/) metódus egy [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) objektumot EMF formátumban egy cél streambe ír. Az alábbi példa betölt egy prezentációt, kiválasztja az első diát, és egy EMF fájl streambe írja:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

A hívó tulajdonolja a [ISlide::WriteAsEmf](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/writeasemf/) metódusnak átadott streamet, és be kell zárnia vagy el kell pusztítania. Az Aspose.Slides a stream aktuális pozíciójában ír, és a streamet nyitva hagyja.

### **SVG kép konvertálása EMF‑be és hozzáadása a prezentációhoz**

Használja a [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/writeasemf/) metódust az SVG tartalom EMF‑re konvertálásához. A kapott bájtok a [IImageCollection::AddImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/addimage/) segítségével hozzáadhatók a prezentációhoz, és egy diára a [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addpictureframe/) metódussal helyezhetők el.

Az alábbi példa egy [SvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/svgimage/) objektumot hoz létre SVG markupból, memóriában EMF‑re konvertálja, az első diára helyezi be a metafájlt, és elmenti a prezentációt:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

A [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/writeasemf/) nem veszi át a cél stream tulajdonjogát. Írás után a stream pozíciója a generált adat vége. A példa a [MemoryStream::ToArray](https://reference.aspose.com/slides/hu/cpp/system.io/memorystream/toarray/) metódust hívja a teljes puffer lekéréséhez a stream aktuális pozíciójától függetlenül, majd ezt a byte tömböt adja át a [IImageCollection::AddImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/addimage/) metódusnak. Hagyja a streamet nyitva, amíg a fogyasztó be nem fejezte a olvasást, majd ezután zárja be.

Az EMF generálás elérhető az Aspose.Slides for C++ által támogatott operációs rendszereken, de a renderelés platformonként eltérhet, ha betűtípusok vagy natív grafikai függőségek hiányoznak. Telepítse a forrás tartalom által használt betűtípusokat, vagy állítson be megfelelő helyettesítéseket, kövesse az Aspose.Slides for C++ [platformkövetelményeket](/slides/hu/cpp/system-requirements/), és ellenőrizze az eredményt a cél EMF‑fogyasztó alkalmazásban. A Linux és macOS alkalmazások gyakran korlátozott vagy nem konzisztens támogatással rendelkeznek a Windows metafájlok megjelenítésére és szerkesztésére.

## **Színes Emoji renderelés**

{{% alert title="Note" color="info" %}}
A színes emoji‑k helyes rendereléséhez a prezentációban használt emoji betűtípusokat telepíteni kell, és elérhetőnek kell lenniük a konvertálást végző rendszeren. Például, ha a prezentáció **Segoe UI Emoji** betűtípust használ, és ez hiányzik, az emojik monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Támogatja-e az Aspose.Slides a diaok animációval történő renderelését?**

Nem. A [ISlide::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/getimage/) metódus a dia statikus képét rendereli, és nem exportál animációkat.

**Exportálhatók-e a rejtett diák képekként?**

Igen. A rejtett diák ugyanúgy renderelhetők, mint a normál diák. Vegye őket fel a feldolgozási ciklusba, ahogy a fenti példában látható.

**Megmaradnak-e az árnyékok és egyéb hatások a dia képekben?**

Igen. Az Aspose.Slides árnyékokat, átlátszóságot és egyéb támogatott grafikai hatásokat renderel a dia képeiben.