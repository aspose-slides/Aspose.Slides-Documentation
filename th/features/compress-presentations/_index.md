---
title: บีบอัดการนำเสนอ
description: ลดขนาดการนำเสนอด้วยการบีบอัดภาพและบันทึกการตั้งค่า.
type: docs
url: /th/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Overview**

บีบอัดรูปภาพ, ลบพื้นที่รูปที่ถูกครอปเมื่อไม่จำเป็นอีกต่อไป, และเลือกการตั้งค่าการบีบอัดการนำเสนอก่อนบันทึก. สิ่งนี้มีประโยชน์สำหรับสไลด์ที่มีภาพถ่ายขนาดใหญ่หรือสื่อที่ซ้ำกัน. จำนวนที่ประหยัดได้ขึ้นอยู่กับเนื้อหาและการตั้งค่าที่คุณเลือก.

## **Usage example**

ตัวอย่าง C# นี้ใช้ Aspose.Slides for .NET. มันสร้างไฟล์ PNG แบบไล่สีขนาด 1600 × 900 พิกเซลอย่างชัดเจน, ใส่ลงในกรอบรูปขนาดเล็ก, และบันทึกเป็น *before.pptx*. จากนั้นบีบอัดรูปนั้นให้มีความละเอียดเป้าหมายที่ 96 DPI และบันทึกเป็น *compressed.pptx*. เปรียบเทียบขนาดไฟล์และภาพตัวอย่างทั้งสอง: การประหยัดขึ้นอยู่กับรูปต้นฉบับและขนาดที่แสดงผล.  
For setup, see [ติดตั้ง Aspose.Slides for .NET](/slides/th/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **นี่เป็นสวิตช์การปรับแต่งไฟล์ทั้งหมดหรือไม่?**

Aspose.Slides for .NET 26.11 เพิ่ม [Compress.CompressPresentation](/slides/th/net/low-code-presentation-operations/#compress-the-whole-presentation) ซึ่งรวมการลบเลย์เอาต์/มาสเตอร์ที่ไม่ได้ใช้, การตัดชุดฟอนต์ฝังและการบีบอัดภาพที่ 150 DPI. มันจะลบพื้นที่รูปที่ถูกครอปอย่างถาวร. สำหรับการประมวลผลเฉพาะรูปภาพ, ใช้ Compress.CompressImages; สำหรับการควบคุมที่ละเอียดขึ้น, รักษาเวิร์กโฟลว์ต่อรูปตามข้างต้น. ตัวช่วยใหม่เหล่านี้จำเพาะสำหรับเวอร์ชัน .NET ที่ระบุ; ตรวจสอบคู่มือที่สอดคล้องสำหรับ SDK อื่น ๆ.

### **การบีบอัดภาพทำให้ข้อความหรือแผนภูมิที่แก้ไขได้เปลี่ยนแปลงหรือไม่?**

การบีบอัดรูปภาพมุ่งเป้าที่ข้อมูลรูปภาพ, ไม่ใช่ข้อความหรือข้อมูลแผนภูมิที่สามารถแก้ไขได้. ตรวจสอบรูปภาพเนื่องจากการปรับขนาดหรือการบีบอัดใหม่อาจทำให้รายละเอียดลดลง.

### **ฉันควรเลือกความละเอียดสำหรับภาพในการนำเสนออย่างไร?**

เลือกเป้าหมายตามขนาดรูปที่แสดงและการใช้งานบนหน้าจอหรือการพิมพ์ที่ตั้งใจ. ควรเก็บความละเอียดสูงขึ้นสำหรับจอแสดงผลขนาดใหญ่, การพิมพ์และแผนภูมิที่ละเอียด, และเปรียบเทียบผลลัพธ์ที่เรนเดอร์ก่อนทิ้งไฟล์ต้นฉบับ.

## **Guides**

- [เพิ่มประสิทธิภาพการจัดการภาพในการนำเสนอใน .NET](/slides/th/net/image/)

Related feature: [ลบมาสเตอร์, เลย์เอาต์และสื่อที่ไม่ได้ใช้](/slides/th/features/remove-unused-content/).

## Runnable .NET examples

- [ลดขนาดการนำเสนอ](/slides/th/net/examples/optimization-batch/compression/)