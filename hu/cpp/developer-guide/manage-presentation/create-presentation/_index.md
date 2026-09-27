---
title: Bemutatók létrehozása C++ nyelven
linktitle: Bemutató létrehozása
type: docs
weight: 10
url: /hu/cpp/create-presentation/
keywords:
- bemutató létrehozása
- új bemutató
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Hozzon létre bemutatókat C++ nyelven az Aspose.Slides segítségével — készítsen PPT, PPTX és ODP fájlokat, élvezze az OpenDocument támogatást, és mentse őket programozott módon a megbízható eredmények érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre egy bemutatót az Aspose.Slides segítségével, hogyan adhat hozzá egy szövegdobozt az első diájához, és hogyan mentheti az eredményt fájlként. A végén egy rövid GYIK a formátumokra, sablonokra, diákméretezésre, mértékegységekre, memóriahasználatra, szálkezelésre, licencelésre, digitális aláírásokra és a VBA támogatásra vonatkozó gyakori kérdéseket tárgyalja.

Mielőtt elkezdené, adja hozzá az Aspose.Slides‑t a projektjéhez: NuGet‑ből egy Windows‑os Visual Studio projekthez, vagy a ZIP‑csomagból CMake‑el Linuxon. Lásd a [Telepítés](/slides/hu/cpp/installation/).

## **PowerPoint bemutató létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból. Egy új bemutató már tartalmaz egy üres diát.  
2. Szerezze meg azt a diát a [Presentation::get_Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slide/) metódussal, valamint annak indexét, 0.  
3. Adjon hozzá egy téglalapot a [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addautoshape/) metódussal, és állítsa be a szövegét a [ITextFrame::set_Text](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/set_text/) metódussal.  
4. Mentse a bemutatót PPTX fájlként a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódussal.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

A téglalap bal felső sarka 50 pont távolságra van a dia bal szélétől és 50 ponttól a dia felső szélétől, a téglalap 400 pont széles és 100 pont magas. A program a *hello.pptx* fájlt a munkakönyvtárba menti, egyetlen diával, amely a téglalapot és annak szövegét tartalmazza. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelő vízjelet helyez el; lásd a [Licencelés](/slides/hu/cpp/licensing/).

## **GYIK**

### Milyen formátumokba menthetek egy új bemutatót?

Menthet [PPTX, PPT, és ODP](/slides/hu/cpp/save-presentation/) formátumokba, és exportálhat [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/hu/cpp/convert-powerpoint-to-xps/), [HTML](/slides/hu/cpp/convert-powerpoint-to-html/), [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) és [képek](/slides/hu/cpp/convert-powerpoint-to-png/) formátumokba, többek között.

### Kezdhetek sablonnal (POTX/POTM) és menthetek egy hagyományos PPTX‑be?

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/cpp/supported-file-formats/).

### Hogyan szabályozhatom a dia méretét/méretarányát a bemutató létrehozásakor?

Állítsa be a [dia méretét](/slides/hu/cpp/slide-size/) (beleértve az 4:3 és 16:9 előre beállított vagy egyéni méreteket), és válassza ki, hogyan skálázódjon a tartalom.

### Milyen egységekben mérik a méreteket és koordinátákat?

Pontokban: 1 hüvelyk = 72 egység.

### Hogyan kezeljek nagyon nagy bemutatókat (számos médiafájllal) a memóriahasználat csökkentése érdekében?

Használja a [BLOB‑kezelési stratégiákat](/slides/hu/cpp/manage-blob/), korlátozza a memóriában tárolást ideiglenes fájlokkal, és részesítse előnyben a fájlalapú munkafolyamatokat a tisztán memóriában lévő adatfolyamok helyett.

### Létrehozhatok/menthetek bemutatókat párhuzamosan?

Nem működhet ugyanazon a [Presentation](/slides/hu/cpp/presentation/) példányon [több szálból](/slides/hu/cpp/multithreading/). Futtasson külön, elszigetelt példányokat szálanként vagy folyamatként.

### Hogyan távolíthatom el a próbaverzió vízjelét és korlátozásait?

[Alkalmazzon licencet](/slides/hu/cpp/licensing/) egyszer a folyamat során. A licenc XML‑nek változatlanul kell maradnia, és a licenc beállítását szinkronizálni kell, ha több szál is érintett.

### Digitálisan aláírhatom a létrehozott PPTX‑et?

Igen. A [digitális aláírások](/slides/hu/cpp/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatottak a bemutatókban.

### Támogatottak a makrók (VBA) a létrehozott bemutatókban?

Igen. [Létrehozhat/szerkeszthet VBA projekteket](/slides/hu/cpp/presentation-via-vba/) és menthet makrókkal rendelkező fájlokat, például PPTM/PPSM.