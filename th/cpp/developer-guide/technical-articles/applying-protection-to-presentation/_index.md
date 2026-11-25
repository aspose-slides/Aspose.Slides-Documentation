---
title: จำกัดการแก้ไขการนำเสนอด้วยการล็อกรูปร่างใน C++
linktitle: จำกัดการแก้ไขการนำเสนอ
type: docs
weight: 10
url: /th/cpp/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันการแก้ไข
- ล็อกรูปร่าง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีล็อคและปลดล็อครูปร่างในไฟล์ PPTX ด้วย Aspose.Slides for C++ เพื่อจำกัดการเลือก, การเคลื่อนที่, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้ Aspose.Slides for C++ ที่พบบ่อยคือการสร้าง, อัปเดต, และบันทึกการนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับการนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปร่างสามารถช่วยรักษาเค้าโครงและเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายว่ารูปร่างถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปร่างในไฟล์ PPTX การล็อกเหล่านี้ช่วยจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละอัน

## **โครงสร้างของสไลด์**

สไลด์การนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for C++, แต่ละองค์ประกอบบนสไลด์จะถูกแสดงด้วยอ็อบเจ็กต์ที่ทำตามอินเตอร์เฟซ [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

รูปแบบรูปร่างที่ต่างกันจะเปิดเผยตัวเลือกการล็อกที่ต่างกัน อินเตอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) เป็นอินเตอร์เฟซฐานสำหรับการล็อกรูปร่าง Aspose.Slides for C++ ให้บริการอินเตอร์เฟซการล็อกต่อไปนี้

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) ล็อก autoshapes
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) ล็อก connector shapes
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) ล็อก graphical objects
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) ล็อก group shapes
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) ล็อก picture frames

เพื่อใช้การล็อกบน [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนแต่ละรูปร่างที่รองรับ

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขการนำเสนอที่เข้ากันได้ใช้การล็อกรูปร่างเพื่อจำกัดการดำเนินการแก้ไขแต่ละอย่าง การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [presentation protection settings](/slides/th/cpp/password-protected-presentation/) ที่แยกจากกัน

### **ใช้การป้องกันกับรูปร่าง PPTX**

Aspose.Slides for C++ มีอินเตอร์เฟซ [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) เพื่อทำงานกับรูปร่างบนสไลด์

ตัวอย่างส่งค่า `true` ไปยัง [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) และ [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) สำหรับ autoshapes พร้อมด้วยการล็อกที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames คอมโพเน้นท์ connectors ใช้ [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) เพื่อการเคลื่อนที่; กลุ่มยังใช้ [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดการนำเสนอ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปร่างใน collection ของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้Applied รูปร่างที่อยู่นอกสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่เดินทางผ่านรูปร่างลูกภายในกลุ่ม

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

### **ลบการป้องกัน**

เพื่อยกเลิกการล็อกรูปร่าง ให้ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีการล็อกรูปร่างและล้างข้อจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) นอกจากนี้ยังล้าง [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) และบันทึกสำเนาของการนำเสนอ การตั้งค่าล็อกอื่น ๆ จะไม่ถูกเปลี่ยนแปลง

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

### **รักษาการครอบรูปภาพไว้**

วางไฟล์รูปภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างทำการครอบ 12% จากด้านซ้ายและ 8% จากด้านขวา, แล้วเรียก [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) บนการล็อก picture frame เพื่อรักษาการครอบและจำกัดการครอบเพิ่มเติม

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

`PictureLocked.pptx` จะบันทึกการล็อกการครอบเป็น `true` ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกภาพ

### **รักษา Diagram ให้อยู่ในกลุ่ม**

ตัวอย่างทำการรวมสี่เหลี่ยมและลูกศรเป็นกลุ่ม, แล้วเรียก [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) บนล็อกของกลุ่มเพื่อให้ส่วนประกอบของ diagram อยู่ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงใช้ได้

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

`DiagramLocked.pptx` จะบันทึกการล็อกการยกเลิกการจัดกลุ่มเป็น `true` ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือก diagram ทั้งหมด

### **รายงานการล็อกรูปร่างที่มีอยู่**

เพื่อสำรวจเทมเพลต, เปิดมันและอ่านอ็อบเจ็กต์ล็อกของแต่ละรูปร่าง [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) จะคืนค่า `true` เมื่อฟล็อกทั้งหมดบนอ็อบเจ็กต์นั้นถูกปิดและ `false` เมื่อมีอย่างน้อยหนึ่งฟล็อกเปิด กลุ่มและลูกของมันมีอ็อบเจ็กต์ล็อกแยกกัน ดังนั้นต้องตรวจสอบลูกแม้ว่ากลุ่มจะไม่มีล็อกใด ๆ

ตัวอย่างนี้ตรวจสอบการเคลื่อนที่สำหรับ autoshapes, picture frames, และ groups, การครอบสำหรับรูปภาพ, และการยกเลิกการจัดกลุ่มสำหรับ groups. มันจะรายงานฟล็อกที่รู้จักและทำเครื่องหมายประเภทรูปร่างที่ไม่ตรวจสอบ

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

สมมติว่า slide 1 ของ `Sample.pptx` มี group ชื่อ `Layout` ที่ล็อกการยกเลิกการจัดกลุ่ม, ภาพชื่อ `Photo` ภายในที่ล็อกการครอบ, และสี่เหลี่ยมที่ไม่ได้ล็อกชื่อ `Free`. รายงานจะข้าม `Free` และพิมพ์บรรทัดสองบรรทัดต่อไปนี้:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

รายงานอ่านฟล็อกระดับรูปร่างที่จัดเก็บโดยไม่เปลี่ยนแปลงหรือบันทึกการนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าแยกต่างหาก และการบังคับใช้แต่ละฟล็อกขึ้นอยู่กับโปรแกรมแก้ไข

### **สรุป**

Aspose.Slides for C++ ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละอันหรือใช้ข้อจำกัดเดียวกันทั่วทั้งสไลด์ เลือกล็อกที่สนับสนุนโดยแต่ละประเภทรูปร่าง และตั้งค่าของมันเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปร่างและการป้องกันด้วยรหัสผ่านในไฟล์การนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปร่างจำกัดการดำเนินการแก้ไขเฉพาะ, ในขณะที่ [password protection](/slides/th/cpp/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขไฟล์การนำเสนอ คุณสามารถใช้ทั้งสองอย่างร่วมกันในไฟล์เดียวได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ได้ ให้ใช้การล็อกเฉพาะกับรูปร่างบนสไลด์ที่เลือก วิธีนี้จะไม่เปลี่ยนแปลงการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปร่างแต่ละอันภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชันที่คืนค่าจากเมธอด [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) ของกลุ่มและใช้การล็อกที่เหมาะสมกับแต่ละรูปร่างลูก ทำซ้ำสำหรับกลุ่มที่ซ้อนกันตามการเดินทางในตัวอย่างการรายงาน