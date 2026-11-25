---
title: "จำกัดการแก้ไขการนำเสนอด้วยการล็อครูปร่างใน .NET"
linktitle: "จำกัดการแก้ไขการนำเสนอ"
type: docs
weight: 70
url: /th/net/applying-protection-to-presentation/
keywords:
- "ป้องกันการแก้ไข"
- "ป้องกันจากการแก้ไข"
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
description: "เรียนรู้วิธีล็อกและปลดล็อครูปร่างในงานนำเสนอ PPTX ด้วย Aspose.Slides สำหรับ .NET เพื่อจำกัดการเลือก, การเคลื่อนที่, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นฐาน**

การใช้ Aspose.Slides for .NET อย่างทั่วไปคือการสร้าง, ปรับปรุงและบันทึกไฟล์นำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับไฟล์นำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปร่างสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ต้องการได้

บทความนี้อธิบายว่ารูปร่างถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปร่างในไฟล์ PPTX การล็อกเหล่านี้ทำให้คุณสามารถจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละอันได้

## **องค์ประกอบของสไลด์**

สไลด์นำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for .NET แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยอ็อบเจ็กต์ที่ทำงานตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทรูปร่างต่าง ๆ จะเปิดเผยตัวเลือกล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) เป็นอินเทอร์เฟซฐานสำหรับการล็อกรูปร่าง Aspose.Slides for .NET มีอินเทอร์เฟซล็อกดังต่อไปนี้

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) ล็อก autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) ล็อก connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) ล็อก graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) ล็อก group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) ล็อก picture frames.  

เพื่อใช้ล็อกบน [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนรูปร่างที่รองรับแต่ละประเภท

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขนำเสนอที่รองรับจะใช้การล็อกรูปร่างเพื่อจำกัดการดำเนินการแก้ไขแต่ละอย่าง การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [presentation protection settings](/slides/th/net/password-protected-presentation/) ที่แยกจากกัน

### **ใช้การป้องกันกับรูปร่าง PPTX**

Aspose.Slides for .NET มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) เพื่อทำงานกับรูปร่างบนสไลด์

ตัวอย่างตั้งค่า [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), และ [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) ให้เป็น `true` สำหรับ autoshapes พร้อมล็อกที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames. Connectors ใช้ [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) เพื่อการเคลื่อนที่; กลุ่มยังใช้ [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดไฟล์ PPTX ที่มีอยู่, ตรวจสอบรูปร่างในคอลเลกชันรูปร่างของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ รูปร่างที่ไม่อยู่ในสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปนี้จะไม่เดินทางผ่านรูปร่างลูกภายในกลุ่ม

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

เพื่อยกเลิกการล็อกรูปร่าง ให้ตั้งค่าค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดไฟล์นำเสนอที่มีการล็อกรูปร่างและล้างข้อจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) อีกทั้งยังล้าง [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) และบันทึกสำเนาของการนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงอยู่เช่นเดิม

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

### **รักษาการครอบรูปภาพ**

วางไฟล์รูปชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างทำการครอบ 12% จากด้านซ้ายและ 8% จากด้านขวา แล้วตั้งค่า [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) บน picture frame ธงนี้จำกัดการครอบต่อไปและรักษาการครอบที่มีอยู่

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

`PictureLocked.pptx` บันทึกสถานะล็อคการครอบเป็น `true` ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกรูปภาพ

### **เก็บ Diagram ให้เป็นกลุ่ม**

ตัวอย่างสร้างกลุ่มจากสี่เหลี่ยมและลูกศรแล้วตั้งค่า [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) บนกลุ่มเองเพื่อเก็บส่วนประกอบของ Diagram ไว้ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงใช้งานได้

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

`DiagramLocked.pptx` บันทึกสถานะล็อคการยกเลิกการจัดกลุ่มเป็น `true` ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือก Diagram ทั้งหมด

### **รายงานการล็อกรูปร่างที่มีอยู่**

เพื่อทบทวนแม่แบบ ให้เปิดและอ่านอ็อบเจ็กต์ล็อกของแต่ละรูปร่าง [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) จะเป็น `true` เมื่อธงทั้งหมดบนอ็อบเจ็กต์นั้นถูกปิดและเป็น `false` เมื่อมีอย่างน้อยหนึ่งธงเปิด กลุ่มและลูกของมันมีอ็อบเจ็กต์ล็อกแยกกัน ดังนั้นจึงต้องตรวจสอบลูกแม้เมื่อกลุ่มไม่มีล็อก

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

สมมติว่าหน้าสไลด์ที่ 1 ของ `Sample.pptx` มีกลุ่มชื่อ `Layout` ที่ล็อกการยกเลิกการจัดกลุ่ม, ภาพชื่อ `Photo` ภายในที่ล็อกการครอบ, และสี่เหลี่ยมที่ไม่มีล็อกชื่อ `Free` รายงานจะข้าม `Free` และพิมพ์สองบรรทัดต่อไปนี้:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

รายงานอ่านธงการแก้ไขระดับรูปร่างที่จัดเก็บโดยไม่เปลี่ยนแปลงหรือบันทึกการนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าแยกต่างหากและการบังคับใช้แต่ละธงขึ้นอยู่กับโปรแกรมแก้ไข

### **สรุป**

Aspose.Slides for .NET ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละอันหรือใช้ข้อจำกัดเดียวกันข้ามหลายสไลด์ เลือกล็อกที่รองรับโดยแต่ละประเภทของรูปร่างและตั้งค่าของมันเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปร่างและการป้องกันด้วยรหัสผ่านในไฟล์นำเสนอเดียวกันได้หรือไม่?**

ใช่ การล็อกรูปร่างจำกัดการดำเนินการแก้ไขบางอย่าง ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/net/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขไฟล์นำเสนอ คุณสามารถใช้ทั้งสองอย่างพร้อมกันในไฟล์เดียวได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ใช่ ให้ใช้ล็อกเฉพาะกับรูปร่างบนสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะใช้ล็อกกับรูปร่างแต่ละอันภายในกลุ่มอย่างไร?**

วนลูปผ่านคอลเลกชัน [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) ของกลุ่มและตั้งค่าล็อกที่เหมาะสมกับรูปร่างลูกแต่ละอัน ทำซ้ำขั้นตอนนี้สำหรับกลุ่มที่ซ้อนกันตามลำดับการเดินทางในตัวอย่างรายงาน