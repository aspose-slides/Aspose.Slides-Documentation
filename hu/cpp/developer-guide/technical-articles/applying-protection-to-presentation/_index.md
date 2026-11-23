---
title: A bemutató szerkesztéseinek korlátozása alakzatzárolásokkal C++ esetén
linktitle: A bemutató szerkesztésének korlátozása
type: docs
weight: 10
url: /hu/cpp/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztés ellen
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- méretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX bemutatókban az Aspose.Slides for C++ segítségével, hogy korlátozzuk a kijelölést, mozgatást, átméretezést és csoportosítást."
---
## **Háttér**

Az Aspose.Slides for C++ gyakori felhasználási módja a PowerPoint (PPTX) bemutatók létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a bemutatókat, az alakzatok módosításának korlátozása segíthet megőrizni a kívánt elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak rendszerezve az alakzatok a diákon, és hogyan lehet alkalmazni és eltávolítani az alakzatzárolásokat egy PPTX bemutatóban. Ezek a zárak lehetővé teszik, hogy meghatározott szerkesztési műveleteket korlátozzunk az egyes alakzatokon.

## **Dia összetétele**

Egy bemutató dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkockák, videó keretek, összekötők és egyéb elemek, amelyek a bemutató építéséhez szükségesek. Az Aspose.Slides for C++-ben a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interfészt, vagy egy olyan osztályból származik, amely ezt teszi.

A különböző alakzattípusok különböző zárolási lehetőségeket kínálnak. A [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) interfész az alakzatzárolások alapinterfésze. Az Aspose.Slides for C++ a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) az automatikus alakzatokat zárolja.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) a csatlakozó alakzatokat zárolja.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) a grafikus objektumokat zárolja.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) a csoportos alakzatokat zárolja.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) a képkockákat zárolja.

A [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) zárak alkalmazásához iteráljon a diákon, és állítsa be a megfelelő zárolásokat az egyes támogatott alakzatokon.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis bemutató szerkesztők alakzatzárolásokat használnak az egyes szerkesztési műveletek korlátozására. A fájl titkosítás és a dokumentumszintű írásvédelem külön [bemutatóvédelmi beállítások](/slides/hu/cpp/password-protected-presentation/) beállítás.

### **Alkalmazzon védelmet a PPTX alakzatokra**

Az Aspose.Slides for C++ biztosítja a [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interfészt a dián lévő alakzatok kezeléséhez.

A példában `true` értéket adunk a [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) és [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) metódusoknak az automatikus alakzatokhoz, a csoportos alakzatok, csatlakozók és képkockák esetén ekvivalens zárolásokkal. A csatlakozók a mozgáshoz a [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) metódust használják; a csoportok pedig a [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) metódust a csoportosítás korlátozásához.

A példa betölti egy meglévő PPTX bemutatót, ellenőrzi minden dia alakzatalapkészletét, és ment egy másolatot a felvett korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanok maradnak. A ciklus nem járja be egy csoporton belüli gyermek alakzatokat.

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

Az alakzatzárolás eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy bemutatót alakzatzárolásokkal, és törli a kiválasztás, mozgás és átméretezés korlátozásait a [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) segítségével. Emellett törli az [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) beállítást, és ment egy másolatot a bemutatóból. A többi zárolási beállítás változatlan marad.

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

Helyezzen egy `photo.jpg` nevű fotót a munkakönyvtárba. A példa 12%-ot vág le balról és 8%-ot jobbról, majd meghívja a [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) metódust a képkocka zároláson, hogy megőrizze a vágást és korlátozza a további vágást.

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

`PictureLocked.pptx` a vágászárat `true` értékkel tárolja. PowerPointban a **Crop** parancs le van tiltva, amikor a fotó ki van jelölve.

### **Diagram csoportos megtartása**

A példa összegrupposít egy téglalapot és egy nyilat, majd meghívja a [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) metódust a csoport zároláson, hogy a diagram komponensei együtt maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

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

`DiagramLocked.pptx` az egyesítés felbontásának zárolását `true` értékkel tárolja. PowerPointban a **Ungroup** parancs le van tiltva, amikor a teljes diagram ki van jelölve.

### **Következtetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy meghatározott szerkesztési műveleteket korlátozzon az egyes alakzatokon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon. Válassza ki az egyes alakzattípusok által támogatott zárolásokat, és állítsa értéküket `false`-ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárolásokat és jelszóvédelmet ugyanabban a bemutatóban?**

Igen. Az alakzatzárolások meghatározott szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/cpp/password-protected-presentation/) korlátozhatja a bemutató megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést egyes diákon anélkül, hogy másokra hatással lenne?**

Igen. Csak a kiválasztott diák alakzatain alkalmazza a zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egy csoporton belüli egyes alakzatokra?**

Iteráljon a csoport által visszaadott [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) metódus által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermek alakzatra. Ismételje ezt minden beágyazott csoportra. A fenti példák csak a dia alakzatalapkészletét dolgozzák fel, így nem állítják be a zárolásokat az egyes csoporttagokra.