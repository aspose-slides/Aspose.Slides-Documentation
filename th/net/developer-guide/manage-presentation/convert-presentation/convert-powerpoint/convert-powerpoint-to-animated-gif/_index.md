---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF แบบเคลื่อนไหวใน .NET
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF แบบเคลื่อนไหว
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น GIF
- งานนำเสนอเป็น GIF
- สไลด์เป็น GIF
- PPT เป็น GIF
- PPTX เป็น GIF
- บันทึก PPT เป็น GIF
- บันทึก PPTX เป็น GIF
- ส่งออก PPT เป็น GIF
- ส่งออก PPTX เป็น GIF
- การตั้งค่าเริ่มต้น
- การตั้งค่ากำหนดเอง
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF แบบเคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET. ผลลัพธ์เร็วและคุณภาพสูง."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF แบบเคลื่อนไหวได้ด้วยไม่กี่บรรทัดของโค้ดเท่านั้น นี่เป็นประโยชน์เมื่อคุณต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่มีขนาดเบา รองรับกว้างขวางและสามารถฝังในเว็บเพจ, เมสเซนเจอร์ หรือเอกสารได้ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF โดยใช้การตั้งค่าเริ่มต้นและวิธีปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกต่าง ๆ เช่น ขนาดเฟรม, ความหน่วงของสไลด์, และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/gifoptions/).

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

ตัวอย่างโค้ดใน C# นี้แสดงวิธีการแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

GIF แบบเคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น 

{{%  alert  title="TIP"  color="primary"  %}} 
หากคุณต้องการปรับแต่งพารามิเตอร์สำหรับ GIF คุณสามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/gifoptions) ดูตัวอย่างโค้ดด้านล่าง 
{{% /alert %}} 

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ากำหนดเอง**

ตัวอย่างโค้ดนี้แสดงวิธีการแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ากำหนดเองใน C#:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // ขนาดของ GIF ที่ได้
        DefaultDelay = 2000, // ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนที่จะเปลี่ยนไปสไลด์ถัดไป
        TransitionFps = 35 // เพิ่ม FPS เพื่อคุณภาพการเคลื่อนไหวของการเปลี่ยนแปลงที่ดีขึ้น
    });
}
```

{{% alert title="Info" color="info" %}}
คุณอาจต้องการลองใช้ตัวแปลง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ฟรีที่พัฒนาโดย Aspose 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ถ้าแบบอักษรที่ใช้ในงานนำเสนอไม่ได้ติดตั้งบนระบบจะเป็นอย่างไร?**

ติดตั้งแบบอักษรที่ขาดหายไปหรือ [กำหนดแบบอักษรสำรอง](/slides/th/net/powerpoint-fonts/) Aspose.Slides จะทำการแทนที่ แต่รูปลักษณ์อาจแตกต่างกัน สำหรับการสร้างแบรนด์ ควรตรวจสอบให้แน่ใจว่าแบบอักษรที่ต้องการพร้อมใช้งานอย่างชัดเจนเสมอ

**ฉันสามารถซ้อนลายน้ำบนเฟรมของ GIF ได้หรือไม่?**

ใช่. [เพิ่มวัตถุ/โลโก้ที่เป็นโปร่งแสงบางส่วน](/slides/th/net/watermark/) ไปยังสไลด์หลักหรือสไลด์แต่ละสไลด์ก่อนทำการส่งออก — ลายน้ำจะปรากฏบนทุกเฟรม