---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อครูปร่างใน C++
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 10
url: /th/cpp/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อกรูปร่าง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปร่างในงานนำเสนอ PPTX ด้วย Aspose.Slides สำหรับ C++ เพื่อจำกัดการเลือก การเคลื่อนที่ การปรับขนาด และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้ Aspose.Slides for C++ ที่พบบ่อยคือการสร้าง ปรับปรุง และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่ ผู้ใช้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปร่างสามารถช่วยรักษาเค้าโครงและเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายว่ารูปร่างถูกจัดเรียงบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปร่างในงานนำเสนอ PPTX การล็อกเหล่านี้ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for C++ แต่ละองค์ประกอบบนสไลด์จะแสดงโดยอ็อบเจ็กต์ที่ implements อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทรูปร่างต่าง ๆ จะเปิดตัวเลือกการล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) เป็นอินเทอร์เฟซฐานสำหรับการล็อกรูปร่าง Aspose.Slides for C++ มีอินเทอร์เฟซการล็อกต่อไปนี้:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) ล็อก autoshapes
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) ล็อก connector shapes
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) ล็อก graphical objects
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) ล็อก group shapes
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) ล็อก picture frames

เพื่อใช้การล็อกทั่วทั้ง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), ให้วนรอบสไลด์และตั้งค่าการล็อกที่เหมาะสมบนรูปร่างที่สนับสนุนแต่ละประเภท

## **ใช้และลบการป้องกัน**

การล็อกรูปร่างจำกัดการดำเนินการเช่น การเลือก การย้าย และการปรับขนาดรูปร่าง แต่ไม่ได้ทำให้ทั้งงานนำเสนอไม่สามารถแก้ไขได้

### **ใช้การป้องกันกับรูปร่าง PPTX**

Aspose.Slides for C++ มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) เพื่อทำงานกับรูปร่างบนสไลด์

ตัวอย่างนี้ส่งค่า `true` ไปยัง [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) และ [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) สำหรับ autoshapes พร้อมการล็อกที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames ตัวเชื่อมต่อใช้ [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) สำหรับการเคลื่อนที่; กลุ่มรูปยังใช้ [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างนี้โหลดงานนำเสนอ PPTX ที่มีอยู่ ตรวจสอบรูปร่างในคอลเลคชันของแต่ละสไลด์ และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปร่างที่อยู่นอกสี่ประเภทที่รองรับจะคงสภาพเดิม ลูปจะไม่ไล่รูปร่างลูกภายในกลุ่ม

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

เพื่อเอาการล็อกรูปร่างออก ให้ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปร่างและล้างการจำกัดการเลือก การเคลื่อนที่ และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) นอกจากนี้ยังล้าง [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) และบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงอยู่ตามเดิม

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

### **สรุป**

Aspose.Slides for C++ ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละอันหรือใช้การจำกัดเดียวกันบนหลายสไลด์ เลือกการล็อกที่รองรับโดยแต่ละประเภทของรูปร่าง และตั้งค่าของมันเป็น `false` เมื่อคุณต้องการเอาการจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปร่างกับการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ใช่ การล็อกรูปร่างจำกัดการดำเนินการแก้ไขเฉพาะ ส่วน [password protection](/slides/th/cpp/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่น ๆ ได้หรือไม่?**

ใช่ ให้ใช้การล็อกเฉพาะกับรูปร่างบนสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าล็อกบนสไลด์อื่น ๆ

**ฉันจะใช้การล็อกกับรูปร่างแต่ละอันภายในกลุ่มอย่างไร?**

วนรอบคอลเลคชันที่ส่งคืนโดยเมธอด [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) ของกลุ่มและใช้การล็อกที่เหมาะสมกับรูปร่างลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลคชันของสไลด์เท่านั้น จึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละตัว