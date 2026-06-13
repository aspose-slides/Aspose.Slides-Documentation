---
title: แปลง PPT และ PPTX เป็น JPG ใน .NET
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/net/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น JPG
- งานนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึก PowerPoint เป็น JPG
- บันทึกงานนำเสนอเป็น JPG
- บันทึกสไลด์เป็น JPG
- บันทึก PPT เป็น JPG
- บันทึก PPTX เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน C# ด้วย Aspose.Slides สำหรับ .NET โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้"
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ JPG ช่วยในการแชร์สไลด์, ปรับประสิทธิภาพ, และฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชัน Aspose.Slides for .NET ช่วยให้คุณแปลงไฟล์ PPTX, PPT และ ODP ให้เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีต่าง ๆ สำหรับการแปลง

ด้วยคุณลักษณะเหล่านี้คุณสามารถสร้างตัวดูงานนำเสนอของคุณเองและสร้างภาพย่อสำหรับแต่ละสไลด์ได้ง่าย ซึ่งอาจเป็นประโยชน์หากคุณต้องการปกป้องสไลด์จากการคัดลอกหรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides อนุญาตให้คุณแปลงงานนำเสนอทั้งหมดหรือสไลด์เฉพาะเป็นรูปแบบภาพได้

## **แปลงสไลด์งานนำเสนอเป็นภาพ JPG**

ต่อไปนี้คือขั้นตอนในการแปลงไฟล์ PPT, PPTX หรือ ODP เป็น JPG:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. รับอ็อบเจ็กต์สไลด์ของชนิด [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide) จากคอลเลกชัน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/properties/slides).
3. สร้างภาพของสไลด์โดยใช้เมธอด [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/#getimage_5).
4. เรียกเมธอด [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/#save_3) บนวัตถุภาพ ส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเป็นอาร์กิวเมนต์

{{% alert color="primary" %}} 
**หมายเหตุ:** การแปลง PPT, PPTX หรือ ODP เป็น JPG แตกต่างจากการแปลงเป็นรูปแบบอื่นใน Aspose.Slides .NET API สำหรับรูปแบบอื่นคุณมักใช้เมธอด [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/#save_5) อย่างไรก็ตามสำหรับการแปลงเป็น JPG คุณต้องใช้เมธอด [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/#save_3)
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // สร้างภาพสไลด์ด้วยสเกลที่ระบุ
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **แปลงสไลด์เป็น JPG พร้อมกำหนดมิติที่กำหนดเอง**

หากต้องการเปลี่ยนขนาดของภาพ JPG ที่สร้างขึ้น คุณสามารถตั้งขนาดภาพโดยส่งค่าเข้าเมธอด [ISlide.GetImage(Size)](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/#getimage_6) วิธีนี้ช่วยให้คุณสร้างภาพที่มีความกว้างและความสูงที่ระบุไว้ เพื่อให้ผลลัพธ์ตรงตามความต้องการด้านความละเอียดและอัตราส่วนของคุณ ความยืดหยุ่นนี้มีประโยชน์อย่างยิ่งเมื่อสร้างภาพสำหรับเว็บแอปพลิเคชัน, รายงาน หรือเอกสาร ที่ต้องการขนาดภาพที่แม่นยำ

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // สร้างภาพสไลด์ด้วยขนาดที่ระบุ
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **เรนเดอร์คอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for .NET ให้ฟีเจอร์ที่ช่วยเรนเดอร์คอมเมนต์บนสไลด์ของงานนำเสนอเมื่อแปลงเป็นภาพ JPG ฟังก์ชันนี้มีประโยชน์สำหรับการเก็บคอมเมนต์, ข้อเสนอแนะ หรือการสนทนาที่ผู้ร่วมงานเพิ่มเข้าไปใน PowerPoint ด้วยการเปิดใช้ตัวเลือกนี้ คุณจะทำให้คอมเมนต์ปรากฏในภาพที่สร้างขึ้น ทำให้การตรวจสอบและแชร์ข้อเสนอแนะง่ายขึ้นโดยไม่ต้องเปิดไฟล์งานนำเสนอดั้งเดิม

สมมติว่าเรามีไฟล์งานนำเสนอ “sample.pptx” ที่มีสไลด์ที่มีคอมเมนต์:

![สไลด์ที่มีคอมเมนต์](slide_with_comments.png)

โค้ด C# ด้านล่างจะแปลงสไลด์เป็นภาพ JPG พร้อมคงคอมเมนต์ไว้:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // ตั้งค่าตัวเลือกสำหรับคอมเมนต์ของสไลด์.
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

{{% alert color="primary" %}} 
หากต้องการดูว่า Aspose.Slides แปลง PowerPoint เป็นภาพ JPG อย่างไร ลองใช้คอนเวอร์เตอร์ออนไลน์ฟรี: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/th/conversion/pptx-to-jpg) และ [PPT to JPG](https://products.aspose.app/slides/th/conversion/ppt-to-jpg). 
{{% /alert %}} 

![ตัวแปลงออนไลน์ฟรี PPTX เป็น JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose มีแอปเว็บ [Collage ฟรี](https://products.aspose.app/slides/th/collage). ด้วยบริการออนไลน์นี้คุณสามารถรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ 

โดยใช้หลักการเดียวกันกับที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ ดูข้อมูลเพิ่มเติมได้ที่หน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการดำเนินการเดียว

**การแปลงสนับสนุน SmartArt, แผนภูมิ และวัตถุซับซ้อนอื่น ๆ หรือไม่?**

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมด รวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง และอื่น ๆ อย่างไรก็ตามความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยจาก PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

**มีข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?**

Aspose.Slides เองไม่ได้กำหนดข้อจำกัดที่เข้มงวดต่อจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตามคุณอาจเจอข้อผิดพลาด out-of-memory เมื่อทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง