---
title: "จำกัดการแก้ไขการนำเสนอด้วยการล็อกรูปทรงใน .NET"
linktitle: "จำกัดการแก้ไขการนำเสนอ"
type: docs
weight: 70
url: /th/net/applying-protection-to-presentation/
keywords:
  - "ป้องกันการแก้ไข"
  - "ปกป้องจากการแก้ไข"
  - "ล็อกรูปทรง"
  - "ล็อกตำแหน่ง"
  - "ล็อกการเลือก"
  - "ล็อกการปรับขนาด"
  - "ล็อกการจัดกลุ่ม"
  - "PowerPoint"
  - "PPTX"
  - "การนำเสนอ"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปทรงในไฟล์ PPTX ด้วย Aspose.Slides สำหรับ .NET เพื่อจำกัดการเลือก, การเคลื่อนที่, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นฐาน**

การใช้งานทั่วไปของ Aspose.Slides for .NET คือการสร้าง, ปรับปรุง และบันทึกการนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับการนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยคงไว้ซึ่งเค้าโครงและเนื้อหาที่ตั้งใจไว้

บทความนี้อธิบายว่ารูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปทรงในไฟล์ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์การนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น รูปทรงอัตโนมัติ, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for .NET แต่ละองค์ประกอบบนสไลด์จะแสดงผลโดยออบเจ็กต์ที่ทำการดำเนินการตามอินเตอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

รูปทรงประเภทต่าง ๆ มีตัวเลือกการล็อกที่แตกต่างกัน อินเตอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) เป็นอินเตอร์เฟซพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for .NET มีอินเตอร์เฟซการล็อกต่อไปนี้:
- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) ล็อกรูปทรงอัตโนมัติ.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) ล็อกรูปทรงตัวเชื่อมต่อ.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) ล็อกรูปทรงที่จัดกลุ่ม.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) ล็อกกรอบรูปภาพ.  

เพื่อใช้การล็อกบนทั้งหมดของ [การนำเสนอ](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ของมันและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละแบบ

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขการนำเสนอที่รองรับจะใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละรายการ การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [การตั้งค่าการป้องกันการนำเสนอ](/slides/th/net/password-protected-presentation/) ที่แยกกัน

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for .NET มีอินเตอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างตั้งค่า [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/) , [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) , และ [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) เป็น `true` สำหรับรูปทรงอัตโนมัติ พร้อมกับการล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และกรอบรูปภาพ ตัวเชื่อมต่อใช้ [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) สำหรับการเคลื่อนที่; กลุ่มยังใช้ [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดการนำเสนอ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกใช้ รูปทรงที่นอกสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่เดินทางผ่านรูปทรงลูกภายในกลุ่ม

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

เพื่อทำการลบการล็อกรูปทรง ให้ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีการล็อกรูปทรงและลบข้อจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) , และ [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) นอกจากนี้ยังลบการล็อก [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) และบันทึกสำเนาของการนำเสนอ การตั้งค่าการล็อกอื่น ๆ จะไม่ถูกเปลี่ยนแปลง

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

### **คงการตัดรูปภาพ**

วางรูปภาพที่ชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างทำการตัด 12% จากด้านซ้ายและ 8% จากด้านขวา แล้วตั้งค่า [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) บนกรอบรูปภาพ ธงนี้จำกัดการตัดต่อในภายหลังและคงการตัดที่มีอยู่

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` เก็บการล็อกการตัดเป็น `true` ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกรูปภาพ

### **คงแผนภาพเป็นกลุ่ม**

ตัวอย่างทำการจัดกลุ่มสี่เหลี่ยมและลูกศร, แล้วตั้งค่า [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) บนกลุ่มเองเพื่อคงส่วนประกอบของแผนภาพไว้ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงสามารถทำได้

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` เก็บการล็อกการยกเลิกการจัดกลุ่มเป็น `true` ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกแผนภาพทั้งหมด

### **สรุป**

Aspose.Slides for .NET ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันบนหลายสไลด์ เลือกการล็อกที่รองรับโดยแต่ละประเภทของรูปทรง และตั้งค่าของพวกมันเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในการนำเสนอเดียวกันได้หรือไม่?**

ได้. การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ, ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/net/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขการนำเสนอ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์บางสไลด์โดยไม่กระทบต่อสไลด์อื่นได้หรือไม่?**

ได้. ให้ใช้การล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือกเท่านั้น การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชัน [รูปทรง](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) ของกลุ่มและตั้งค่าการล็อกที่เหมาะสมให้กับรูปทรงลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นจึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละอัน