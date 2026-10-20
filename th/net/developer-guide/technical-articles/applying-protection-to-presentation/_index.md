---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน .NET
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 70
url: /th/net/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides สำหรับ .NET เพื่อจำกัดการเลือก, การย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้ Aspose.Slides for .NET อย่างทั่วไปคือการสร้าง, อัปเดต, และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของเวิร์กโฟลว์อัตโนมัติ เมื่อผู้ใช้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจไว้ได้

บทความนี้อธิบายว่ารูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูป

## **องค์ประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น รูปอัตโนมัติ, ตาราง, วัตถุ OLE, กลุ่มรูปทรง, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for .NET แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยอ็อบเจ็กต์ที่ทำงานตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทรูปทรงต่าง ๆ มีตัวเลือกการล็อกที่ต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) เป็นอินเทอร์เฟซพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for .NET มีอินเทอร์เฟซการล็อกต่อไปนี้:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) ล็อกอัตรูป  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) ล็อกตัวเชื่อมต่อ  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) ล็อกวัตถุกราฟิก  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) ล็อกกลุ่มรูปทรง  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) ล็อกกรอบรูปภาพ  

เพื่อใช้การล็อกในทั่ว ๆ ไปบน [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละประเภท

## **ใช้และลบการป้องกัน**

การล็อกรูปทรงจะจำกัดการดำเนินการเช่น การเลือก, การย้าย, และการปรับขนาดรูปทรง แต่ไม่ได้ทำให้งานนำเสนอทั้งหมดไม่สามารถแก้ไขได้

### **ใช้การป้องกันกับรูปแบบ PPTX**

Aspose.Slides for .NET มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างตั้งค่า [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), และ [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) เป็น `true` สำหรับรูปอัตโนมัติ โดยมีการล็อกที่เทียบเท่าสำหรับกลุ่มรูปทรง, ตัวเชื่อมต่อ, และกรอบรูปภาพ ตัวเชื่อมต่อใช้ [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) สำหรับการเคลื่อนที่; กลุ่มรูปทรงยังใช้ [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะคงเดิมไว้ ลูปจะไม่ไล่ผ่านรูปทรงลูกภายในกลุ่ม

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **ลบการป้องกัน**

เพื่อเอาการล็อกรูปทรงออก ให้ตั้งค่าค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างการจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) รวมทั้งล้าง [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าการล็อกอื่น ๆ จะคงไว้ตามเดิม

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **สรุป**

Aspose.Slides for .NET ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูปหรือใช้การจำกัดเดียวกันบนหลายสไลด์ เลือกการล็อกที่สนับสนุนโดยแต่ละประเภทรูปทรง และตั้งค่าของมันเป็น `false` เมื่อต้องการเอาการจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถผสานการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขบางอย่างในขณะที่ [password protection](/slides/th/net/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างร่วมกันในไฟล์เดียวกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่น ๆ ได้หรือไม่?**

ได้ ให้ใช้การล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนแปลงการตั้งค่าการล็อกบนสไลด์อื่น ๆ

**ฉันจะใช้การล็อกบนรูปทรงแต่ละรูปภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชัน [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) ของกลุ่มและตั้งค่าการล็อกที่เหมาะสมกับรูปทรงลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์จึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละตัว