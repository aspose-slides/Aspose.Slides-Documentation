---
title: Alakzatzárolásokkal korlátozni a bemutató szerkesztését C++-ban
linktitle: Bemutató szerkesztésének korlátozása
type: docs
weight: 10
url: /hu/cpp/applying-protection-to-presentation/
keywords:
- szerkesztések megelőzése
- védelem a szerkesztés ellen
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX bemutatókban az Aspose.Slides for C++ segítségével, hogy korlátozzuk a kijelölést, mozgást, átméretezést és csoportosítást."
---
## **Háttér**

Az Aspose.Slides for C++ gyakori felhasználása, hogy PowerPoint (PPTX) bemutatókat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a bemutatókat, az alakzatok módosításának korlátozása segíthet megőrizni a szándékolt elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan szerveződnek az alakzatok a diákon, és hogyan alkalmazhatók és távolíthatók el az alakzatzárak egy PPTX bemutatóban. Ezek a zárak lehetővé teszik, hogy egyedi alakzatok esetén korlátozza a konkrét szerkesztési műveleteket.

## **Dia összetétele**

Egy bemutató dia összetevőiből áll, például automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkeretek, videokeretek, csatlakozók és más elemek, amelyeket a bemutató összeállításához használnak. Az Aspose.Slides for C++-ban a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) felületet, vagy egy olyan osztályból származik, amely megvalósítja azt.

A különböző alakzat típusok különböző zárolási lehetőségeket kínálnak. A [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) felület az alakzatzárak alapfelülete. Az Aspose.Slides for C++ a következő zárolási felületeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) zárolja az automatikus alakzatokat.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) zárolja a csatlakozó alakzatokat.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) zárolja a csoportos alakzatokat.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) zárolja a képkereteket.

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) esetén iteráljon végig a diákon, és állítsa be a megfelelő zárakat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis bemutató szerkesztők alakzatzárokat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítás és a dokumentumszintű írásvédelmi beállítások különálló [bemutató védelmi beállítások](/slides/hu/cpp/password-protected-presentation/) beállítások.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for C++ biztosítja a [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) felületet, amely a dián lévő alakzatokkal való munkához használható.

A példa `true` értéket ad át a [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), a [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) és a [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) metódusoknak automatikus alakzatok esetén, illetve ekvivalens zárakat a csoportos alakzatok, csatlakozók és képkeretek számára. A csatlakozók a [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) metódust használják a mozgatáshoz; a csoportok pedig a [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) metódust a csoportosítás korlátozásához.

A példa betölti a meglévő PPTX bemutatót, ellenőrzi az egyes diák alakzatgyűjteményét, és elment egy másolatot az alkalmazott korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyermek alakzatokat.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Védelem eltávolítása**

Az alakzatzár eltávolításához állítsa az értékét `false`-ra. A következő példa betölti a alakzatzárral ellátott bemutatót, és törli a kijelölés, mozgatás és átméretezés korlátozásait a [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) segítségével. Emellett törli a [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) beállítást, és elment egy másolatot a bemutatóról. A többi zárbeállítás változatlan marad.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Képvágás megőrzése**

Helyezzen egy `photo.jpg` nevű fényképet a munkakönyvtárba. A példa 12%-ot vág le balról és 8%-ot jobb oldalról, majd meghívja a [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) metódust a képkeret záron, hogy megőrizze a vágást és korlátozza a további vágást.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` a vágási zárat `true` értékkel tárolja. PowerPointban a **Crop** parancs le van tiltva, amikor a fénykép ki van választva.

### **Diagram csoportos állapotának megőrzése**

A példa egy téglalapot és egy nyilat csoportosít, majd meghívja a [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) metódust a csoport záron, hogy a diagram elemei együtt maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` a csoportbontás zárral `true` értéket tárol. PowerPointban a **Ungroup** parancs le van tiltva, amikor az egész diagram ki van választva.

### **Meglévő alakzatzárak jelentése**

Egy sablon áttekintéséhez nyissa meg, és olvassa ki az egyes alakzatok zárolási objektumát. A [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) `true` értéket ad vissza, ha az objektum összes jelzője ki van kapcsolva, és `false` értéket, ha legalább egy be van kapcsolva. Egy csoport és annak gyermekei külön zárobjektummal rendelkeznek, ezért ellenőrizze a gyermekeket akkor is, ha a csoportnak nincsenek zárak.

Ez a példa ellenőrzi a mozgást az automatikus alakzatok, képkeretek és csoportok esetén, a vágást a képekhez, és a csoportbontást a csoportoknál. Jelenti az általa felismert jelzőket, és megjelöli azokat az alakzattípusokat, amelyeket nem vizsgál.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

Tegyük fel, hogy a `Sample.pptx` első diáján egy `Layout` nevű csoport van, amelynek a csoportbontás zárolva van, egy `Photo` nevű kép van benne, amelynek a vágás zárolva van, és egy `Free` nevű zárolatlan téglalap. A jelentés kihagyja a `Free`-t és kiírja a következő két sort:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

A jelentés a tárolt alakzatszintű szerkesztési jelzőket olvassa anélkül, hogy módosítaná őket vagy elmentené a bemutatót. A dokumentumszintű írásvédelem egy külön beállítás, és az egyes jelzők érvényesítése az szerkesztőtől függ.

### **Összegzés**

Az Aspose.Slides for C++ lehetővé teszi, hogy egyedi alakzatok esetén korlátozza a konkrét szerkesztési műveleteket, vagy azonos korlátozásokat alkalmazzon a diákon át. Válassza ki az egyes alakzat típusok által támogatott zárakat, és állítsa értéküket `false`-ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárakat és jelszóvédelmet ugyanabban a bemutatóban?**

Igen. Az alakzatzárak a konkrét szerkesztési műveleteket korlátozzák, míg a [jelszóvédelem](/slides/hu/cpp/password-protected-presentation/) korlátozhatja a bemutató megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom-e a szerkesztést konkrét diákon anélkül, hogy más diákra hatna?**

Igen. Csak a kiválasztott diák alakzataira alkalmazza a zárakat. Ez nem módosítja a zárbeállításokat a többi dián.

**Hogyan alkalmazhatok zárakat egy csoporton belüli egyedi alakzatokra?**

Iteráljon a csoport [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárakat minden gyermek alakzatra. Ismételje meg ezt minden beágyazott csoportnál, a jelentési példában bemutatott bejárást követve.