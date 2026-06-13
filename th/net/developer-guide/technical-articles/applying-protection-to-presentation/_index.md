---
title: ป้องกันการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน .NET
linktitle: ป้องกันการแก้ไขงานนำเสนอ
type: docs
weight: 70
url: /th/net/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบว่า Aspose.Slides สำหรับ .NET จะแล็อกหรือปลดล็อกรูปทรงในไฟล์ PPT, PPTX และ ODP อย่างไร เพื่อรักษาความปลอดภัยของงานนำเสนอพร้อมให้ทำการแก้ไขที่ควบคุมได้"
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides คือการสร้าง อัปเดต และบันทึกงานนำเสนอ Microsoft PowerPoint (PPTX) เป็นส่วนหนึ่งของเวิร์กโฟลว์อัตโนมัติ ผู้ใช้แอปพลิเคชันที่ใช้ Aspose.Slides ด้วยวิธีนี้จะเข้าถึงงานนำเสนอที่สร้างขึ้น ดังนั้นการป้องกันไม่ให้แก้ไขเป็นความกังวลทั่วไป จำเป็นที่งานนำเสนอที่สร้างโดยอัตโนมัติจะต้องคงรูปแบบและเนื้อหาเดิมไว้

บทความนี้อธิบายว่าโครงสร้างของงานนำเสนอและสไลด์เป็นอย่างไร และ Aspose.Slides for .NET สามารถใช้การป้องกันกับงานนำเสนอและลบการป้องกันนั้นในภายหลังได้อย่างไร มันให้วิธีการสำหรับนักพัฒนาที่จะควบคุมการใช้งานงานนำเสนอที่แอปพลิเคชันของพวกเขาสร้างขึ้น

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes ตาราง วัตถุ OLE รูปร่างที่จัดกลุ่ม picture frames วิดีโอเฟรม connectors และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for .NET แต่ละองค์ประกอบบนสไลด์จะแสดงด้วยอ็อบเจกต์ที่ทำงานตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

โครงสร้างของ PPTX มีความซับซ้อน ดังนั้นจึงไม่เหมือนกับ PPT ที่สามารถใช้การล็อกแบบทั่วไปกับรูปทรงทุกประเภทได้ รูปแบบการล็อกที่ต่างกันต้องใช้ล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseshapelock/) คือคลาสการล็อกทั่วไปสำหรับ PPTX ชนิดของล็อกต่อไปนี้ได้รับการสนับสนุนใน Aspose.Slides for .NET สำหรับ PPTX

- [IAutoShapeLock](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshapelock/) ล็อกรูปทรงอัตโนมัติ  
- [IConnectorLock](https://reference.aspose.com/slides/th/net/aspose.slides/iconnectorlock/) ล็อกรูปร่างเชื่อมต่อ  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/th/net/aspose.slides/igraphicalobjectlock/) ล็อกวัตถุกราฟิก  
- [IGroupShapeLock](https://reference.aspose.com/slides/th/net/aspose.slides/igroupshapelock/) ล็อกกลุ่มรูปทรง  
- [IPictureFrameLock](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframelock/) ล็อกกรอบรูปภาพ  

การกระทำใด ๆ ที่ทำกับอ็อบเจกต์รูปทรงทั้งหมดในอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) จะถูกนำไปใช้กับงานนำเสนอทั้งหมด

## **ใช้และลบการป้องกัน**

การใช้การป้องกันทำให้มั่นใจว่างานนำเสนอไม่สามารถแก้ไขได้ เป็นเทคนิคที่มีประโยชน์สำหรับการปกป้องเนื้อหาของงานนำเสนอ

### **ใช้การป้องกันกับรูปร่าง PPTX**

Aspose.Slides for .NET มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) เพื่อทำงานกับรูปร่างบนสไลด์

ตามที่ได้กล่าวไว้ก่อนหน้า แต่ละคลาสของรูปร่างมีคลาสล็อกที่เกี่ยวข้องสำหรับการป้องกัน บทความนี้เน้นที่ล็อก NoSelect, NoMove, และ NoResize ซึ่งทำให้รูปร่างไม่สามารถเลือก (โดยการคลิกเมาส์หรือวิธีการเลือกอื่น) และไม่สามารถย้ายหรือปรับขนาดได้

ตัวอย่างโค้ดต่อไปนี้ใช้การป้องกันกับรูปทรงทุกประเภทในงานนำเสนอ

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using Presentation presentation = new Presentation("Sample.pptx");

// วนลูปทุกสไลด์ในงานนำเสนอ
foreach (ISlide slide in presentation.Slides)
{
    // วนลูปทุกรูปร่างในสไลด์
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// บันทึกไฟล์งานนำเสนอ
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **ลบการป้องกัน**

หากต้องการปลดล็อกรูปร่าง ให้ตั้งค่าค่าของล็อกที่ได้ใช้เป็น `false` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปลดล็อกรูปร่างในงานนำเสนอที่ถูกล็อก

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// วนลูปทุกสไลด์ในงานนำเสนอ.
foreach (ISlide slide in presentation.Slides)
{
    // วนลูปทุกรูปร่างในสไลด์.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// บันทึกไฟล์งานนำเสนอ.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **สรุป**

Aspose.Slides มีตัวเลือกหลายอย่างสำหรับการปกป้องรูปร่างในงานนำเสนอ คุณสามารถล็อกรูปร่างเดี่ยวหรือวนลูปผ่านรูปร่างทั้งหมดในงานนำเสนอและล็อกแต่ละรูปร่างเพื่อให้ไฟล์ทั้งหมดปลอดภัยอย่างมีประสิทธิภาพ คุณสามารถลบการป้องกันได้โดยตั้งค่าค่าล็อกเป็น `false`

## **คำถามที่พบบ่อย**

**Can I combine shape locks and password protection in the same presentation?**  
ใช่ การล็อกจำกัดการแก้ไขวัตถุภายในไฟล์ในขณะที่ [password protection](/slides/th/net/password-protected-presentation/) ควบคุมการเข้าถึงการเปิดและ/หรือการบันทึกการเปลี่ยนแปลง กลไกเหล่านี้ทำงานเสริมกันและทำงานร่วมกัน

**Can I restrict editing on specific slides without affecting others?**  
ใช่ ให้ใช้การล็อกกับรูปร่างบนสไลด์ที่เลือก; สไลด์ที่เหลือจะยังคงสามารถแก้ไขได้

**Do shape locks apply to grouped objects and connectors?**  
ใช่ มีประเภทการล็อกเฉพาะสำหรับกลุ่ม, connectors, วัตถุกราฟิก, และรูปทรงประเภทอื่น ๆ