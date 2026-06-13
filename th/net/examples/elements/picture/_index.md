---
title: รูปภาพ
type: docs
weight: 50
url: /th/net/examples/elements/picture/
keywords:
- รูปภาพ
- กรอบรูปภาพ
- เพิ่มรูปภาพ
- เข้าถึงรูปภาพ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำงานกับรูปภาพใน Aspose.Slides for .NET: แทรก, ตัด, บีบอัด, ปรับสีใหม่ และส่งออกภาพด้วยตัวอย่าง C# สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้สาธิตวิธีการแทรกและเข้าถึงรูปภาพจากภาพในหน่วยความจำโดยใช้ **Aspose.Slides for .NET** ตัวอย่างด้านล่างสร้างภาพในหน่วยความจำ วางลงบนสไลด์และดึงออกมา.

## **เพิ่มรูปภาพ**

โค้ดนี้สร้างบิตแมพขนาดเล็ก แปลงเป็นสตรีม แล้วแทรกเป็นกรอบรูปภาพบนสไลด์แรก.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // สร้างภาพในหน่วยความจำแบบง่าย.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // แปลงบิตแมพเป็น MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // เพิ่มภาพลงในงานนำเสนอ.
    var image = presentation.Images.AddImage(imageStream);

    // แทรกกรอบรูปภาพแสดงภาพบนสไลด์แรก.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **เข้าถึงรูปภาพ**

ตัวอย่างนี้ตรวจสอบให้แน่ใจว่าสไลด์มีกรอบรูปภาพแล้วเข้าถึงกรอบรูปแรกที่พบ.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // ตรวจสอบว่ามีกรอบรูปภาพอย่างน้อยหนึ่งกรอบเพื่อทำงานด้วย.
    using var bitmap = new Bitmap(40, 40);

    // แปลงบิตแมพเป็น MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // เพิ่มภาพลงในงานนำเสนอ.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // เข้าถึงกรอบรูปภาพแรกบนสไลด์.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```