---
title: Prezentáció információinak lekérése és frissítése C++-ban
linktitle: Prezentáció információi
type: docs
weight: 30
url: /hu/cpp/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel a diákat, a szerkezetet és a metaadatokat PowerPoint és OpenDocument prezentációkban C++ használatával a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni egy bemutató információit az Aspose.Slides-ban. Ismerteti, hogyan lehet meghatározni a bemutató aktuális formátumát a teljes fájl betöltése nélkül, elolvasni a dokumentumtulajdonságokat, és szükség esetén frissíteni azokat.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/documentproperties/) API-kra épülnek, és bemutatják a bemutató metaadataival való munka tipikus műveleteit.

## **Ellenőrizze a bemutató formátumát**

Mielőtt a bemutatóval dolgozna, megtudhatja, hogy milyen formátumú (PPT, PPTX, ODP és egyéb) a bemutató jelenleg.

A bemutató formátumát betöltés nélkül is ellenőrizheti. Lásd ezt a C++ kódot:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Szerezze meg a bemutató tulajdonságait**

Ez a C++ kód megmutatja, hogyan lehet lekérni a bemutató tulajdonságait (információk a bemutatóról):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```

## **A bemutató tulajdonságainak frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) metódust, amely lehetővé teszi a bemutató tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint bemutató a lenti dokumentumtulajdonságokkal.

![A PowerPoint bemutató eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódpélda megmutatja, hogyan szerkeszthet néhány bemutató tulajdonságot:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredménye alább látható.

![A PowerPoint bemutató módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

További információkért egy bemutatóról és annak biztonsági attribútumairól, a következő hivatkozások lehetnek hasznosak:

- [Jelszóval védett bemutatók](/slides/hu/cpp/password-protected-presentation/)
- [Írásvédett bemutatók](/slides/hu/cpp/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva, és melyek azok?**

Keresse a [ágyazott betűkészlet információ](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getembeddedfonts/) a bemutató szintjén, majd hasonlítsa össze ezeket a bejegyzéseket a [valóban a tartalommal használt betűkészletek](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getfonts/) halmazával, hogy azonosítsa, mely betűkészletek kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz-e rejtett diákat, és hány van?**

Iteráljon a [dia gyűjtemény](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidecollection/) kollekción, és vizsgálja meg minden dia [visibility flag](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/get_hidden/) attribútumát.

**Felismerhetem-e, hogy egyéni dia méret és tájolás van használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [slide size and orientation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slidesize/) beállítást a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatás és az export viselkedését.

**Van-e gyors módja annak, hogy megállapítsam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [charts](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/) elemet, ellenőrizze azok [data source](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) beállítását, és vegye fel, hogy az adat belső vagy hivatkozás-alapú, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem a 'nehéz' diákot, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden egyes dián számolja meg az objektumok számát, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzá egy durva komplexitási pontszámot, hogy jelölje a lehetséges teljesítménybeli problémákat.