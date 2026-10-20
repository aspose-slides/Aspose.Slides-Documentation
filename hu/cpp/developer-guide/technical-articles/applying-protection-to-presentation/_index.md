---
title: Prezentáció szerkesztésének korlátozása alakzatzárolásokkal C++-ban
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 10
url: /hu/cpp/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védés a szerkesztéstől
- alakzat zárolása
- pozíció zárolása
- kiválasztás zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for C++ segítségével, hogy korlátozza a kiválasztást, mozgatást, átméretezést és a csoportosítást."
---
## **Háttér**

Az Aspose.Slides for C++ gyakori felhasználása a PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, a formák módosításának korlátozása segíthet megőrizni a kívánt elrendezést és tartalmat.

Ez a cikk bemutatja, hogyan vannak a formák elrendezve a diákon, és hogyan alkalmazhatók és távolíthatók el a formazárolások egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy bizonyos szerkesztési műveleteket korlátozzon az egyes formákon.

## **Dia felépítése**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus formák, táblázatok, OLE‑objektumok, csoportosított formák, képkockák, videokockák, összekötők és egyéb elemek, amelyek a prezentáció felépítéséhez szükségesek. Az Aspose.Slides for C++‑ban egy dia minden eleme egy objektummal van reprezentálva, amely megvalósítja az [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interfészt, vagy örökli azt egy osztályból.

A különböző forma típusok különböző zárolási lehetőségeket kínálnak. Az [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) interfész a formazárolások alapinterfésze. Az Aspose.Slides for C++ a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) zárolja az automatikus formákat.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) zárolja a csatlakozó formákat.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) zárolja a csoportosított formákat.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) zárolja a képkockákat.

A [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) zárolások alkalmazásához iteráljon a diákon, és állítsa be a megfelelő zárolásokat minden támogatott formán.

## **Védelem alkalmazása és eltávolítása**

A formazárolások korlátozzák az olyan műveleteket, mint a formák kiválasztása, mozgatása és átméretezése. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Védelem alkalmazása PPTX formákra**

Az Aspose.Slides for C++ biztosítja az [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interfészt a dián lévő formákkal való munkához.

A példa `true` értéket ad át a [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), a [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/), és a [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) metódusoknak az automatikus formák esetében, valamint ekvivalens zárolásokat a csoportosított formák, csatlakozók és képkockák számára. A csatlakozók a [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) metódust használják a mozgáshoz; a csoportok pedig a [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) metódust használják a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi a formákat minden dia forma gyűjteményében, és elment egy másolatot a alkalmazott korlátozásokkal. A négy kezelt típuson kívüli formák változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekformákat.

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

A formazárolás eltávolításához állítsa az értékét `false`‑ra. A következő példa betölt egy prezentációt formazárolásokkal, és törli a kiválasztás, mozgás és átméretezés korlátozásait az [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), az [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), az [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), és az [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) segítségével. Emellett törli a [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) beállítást, és elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Következtetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy egyes formákon korlátozza a specifikus szerkesztési műveleteket, vagy ugyanazokat a korlátozásokat alkalmazza a diákon át. Válassza ki az egyes forma típusok által támogatott zárolásokat, és állítsa értéküket `false`‑ra, amikor el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Összekapcsolhatom a formazárolókat és a jelszóvédelmet ugyanabban a prezentációban?**

Igen. A formazárolások specifikus szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/cpp/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést egyes diákon anélkül, hogy a többit befolyásolnám?**

Igen. Csak a kiválasztott diákon lévő formákra alkalmazzon zárolásokat. Ez nem módosítja a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egy csoporton belüli egyedi formákra?**

Iteráljon a csoport [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermekformára. Ismételje meg ezt minden beágyazott csoportnál. A fenti példák csak a dia forma gyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyes csoporttagokra.