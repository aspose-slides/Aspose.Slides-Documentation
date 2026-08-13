---
title: แปลง PPT และ PPTX ไปเป็น JPG ใน .NET
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/net/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น JPG
- การนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึก PowerPoint เป็น JPG
- บันทึกการนำเสนอเป็น JPG
- บันทึกสไลด์เป็น JPG
- บันทึก PPT เป็น JPG
- บันทึก PPTX เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) ไปเป็นภาพ JPG คุณภาพสูงใน C# ด้วย Aspose.Slides สำหรับ .NET โดยใช้ตัวอย่างโค้ดที่รวดเร็วและเชื่อถือได้"
---
## **บทนำ**

การแปลงการนำเสนอ PowerPoint และ OpenDocument ไปเป็นภาพ JPG ช่วยให้การแชร์สไลด์ง่ายขึ้น ปรับประสิทธิภาพการทำงาน และฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชันได้ Aspose.Slides for .NET ช่วยให้คุณแปลงไฟล์ PPTX, PPT และ ODP ไปเป็นภาพ JPEG คุณภาพสูง คู่มือฉบับนี้อธิบายวิธีต่าง ๆ สำหรับการแปลง

ด้วยคุณลักษณะเหล่านี้ คุณสามารถสร้างโปรแกรมดูสไลด์ของคุณเองและสร้างรูปย่อสำหรับแต่ละสไลด์ได้ง่าย ซึ่งอาจเป็นประโยชน์หากคุณต้องการปกป้องสไลด์จากการคัดลอกหรือแสดงการนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides อนุญาตให้คุณแปลงทั้งการนำเสนอหรือสไลด์เฉพาะหนึ่งเป็นรูปแบบภาพ

## **แปลงสไลด์การนำเสนอเป็นภาพ JPG**

ขั้นตอนการแปลงไฟล์ PPT, PPTX หรือ ODP ไปเป็น JPG มีดังนี้:

1. สร้างออบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. ดึงออบเจกต์สไลด์ประเภท [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide) จากคอลเลกชัน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/properties/slides)
3. สร้างภาพของสไลด์โดยใช้เมธอด [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/#getimage_5)
4. เรียกเมธอด [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/#save_3) บนออบเจกต์ภาพ โดยระบุชื่อไฟล์ผลลัพธ์และรูปแบบภาพเป็นอาร์กิวเมนต์

{{% alert color="info" %}} 
**หมายเหตุ:** การแปลง PPT, PPTX หรือ ODP ไปเป็น JPG แตกต่างจากการแปลงเป็นฟอร์แมตอื่นใน Aspose.Slides .NET API สำหรับฟอร์แมตอื่น ๆ คุณมักใช้เมธอด [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/#save_5) อย่างไรก็ตามสำหรับการแปลงเป็น JPG คุณต้องใช้เมธอด [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/#save_3)
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // สร้างภาพสไลด์ตามสเกลที่ระบุ.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **แปลงสไลด์เป็น JPG พร้อมกำหนดขนาดตามต้องการ**

เพื่อเปลี่ยนขนาดของภาพ JPG ที่สร้างขึ้น คุณสามารถตั้งค่าขนาดภาพโดยส่งค่าเข้าเมธอด [ISlide.GetImage(Size)](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/#getimage_6) วิธีนี้ช่วยให้คุณสร้างภาพที่มีความกว้างและความสูงที่กำหนดไว้ล่วงหน้า เพื่อให้ผลลัพธ์ตรงตามความต้องการด้านความละเอียดและอัตราส่วนภาพ ความยืดหยุ่นนี้เป็นประโยชน์อย่างยิ่งเมื่อสร้างภาพสำหรับเว็บแอปพลิเคชัน รายงาน หรือเอกสาร ที่ต้องการขนาดภาพที่แม่นยำ

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // สร้างภาพสไลด์ตามขนาดที่ระบุ.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **แสดงคอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for .NET มีฟีเจอร์ที่ช่วยให้คุณเรนเดอร์คอมเมนต์บนสไลด์ของการนำเสนอเมื่อแปลงเป็นภาพ JPG ฟังก์ชันนี้มีประโยชน์ในการเก็บคอมเมนต์, ฟีดแบ็ก หรือการสนทนาที่ผู้ร่วมงานเพิ่มใน PowerPoint โดยเปิดใช้งานตัวเลือกนี้ คอมเมนต์จะปรากฏในภาพที่สร้าง ทำให้ตรวจสอบและแชร์ฟีดแบ็กได้ง่ายโดยไม่ต้องเปิดไฟล์ต้นฉบับ

สมมติว่ามีไฟล์การนำเสนอ “sample.pptx” ที่มีสไลด์ที่มีคอมเมนต์:

![สไลด์ที่มีคอมเมนต์](slide_with_comments.png)

โค้ด C# ด้านล่างแปลงสไลด์เป็นภาพ JPG พร้อมคงคอมเมนต์ไว้:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // กำหนดตัวเลือกสำหรับคอมเมนต์ของสไลด์.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // แปลงสไลด์แรกเป็นภาพ.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

ผลลัพธ์:

![ภาพ JPG ที่มีคอมเมนต์](image_with_comments.png)

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่น ๆ สำหรับการแปลง PPT, PPTX หรือ ODP เป็นภาพ เช่น:

- [แปลง PowerPoint เป็น GIF](/slides/th/net/convert-powerpoint-to-animated-gif/)
- [แปลง PowerPoint เป็น PNG](/slides/th/net/convert-powerpoint-to-png/)
- [แปลง PowerPoint เป็น TIFF](/slides/th/net/convert-powerpoint-to-tiff/)
- [แปลง PowerPoint เป็น SVG](/slides/th/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
เพื่อดูว่า Aspose.Slides แปลง PowerPoint ไปเป็นภาพ JPG อย่างไร ลองใช้เครื่องแปลงออนไลน์ฟรี: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/th/conversion/pptx-to-jpg) และ [PPT to JPG](https://products.aspose.app/slides/th/conversion/ppt-to-jpg) 
{{% /alert %}} 

![ตัวแปลงออนไลน์ฟรี PPTX to JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}
Aspose มีแอปเว็บ [Collage ฟรี](https://products.aspose.app/slides/th/collage) ให้คุณรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ  

โดยใช้หลักการเดียวกับบทความนี้ คุณสามารถแปลงภาพจากฟอร์แมตหนึ่งไปยังอีกฟอร์แมตหนึ่งได้ สำหรับข้อมูลเพิ่มเติม ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

### วิธีนี้รองรับการแปลงเป็นชุดได้หรือไม่?

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG พร้อมกันในหนึ่งขั้นตอน

### การแปลงรองรับ SmartArt, แผนภูมิ, และวัตถุซับซ้อนอื่น ๆ หรือไม่?

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง และอื่น ๆ อย่างไรก็ตามความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยจาก PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

### มีข้อจำกัดเรื่องจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?

Aspose.Slides เองไม่ได้กำหนดขีดจำกัดที่เข้มงวดสำหรับจำนวนสไลด์ที่คุณจะประมวลผล อย่างไรก็ตามคุณอาจเจอข้อผิดพลาด out-of-memory เมื่อทำงานกับการนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง