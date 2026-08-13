---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF เคลื่อนไหวใน .NET
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF เคลื่อนไหว
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
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF เคลื่อนไหวง่าย ๆ ด้วย Aspose.Slides สำหรับ .NET. ผลลัพธ์รวดเร็วและคุณภาพสูง."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF เคลื่อนไหวได้ด้วยเพียงไม่กี่บรรทัดของโค้ด สิ่งนี้มีประโยชน์เมื่อคุณต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่มีน้ำหนักเบาและรองรับโดยกว้าง สามารถฝังในหน้าเว็บ, แอปแชท หรือเอกสารได้ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF โดยใช้การตั้งค่าเริ่มต้นและวิธีปรับแต่งผลลัพธ์โดยกำหนดค่าตัวเลือกเช่น ขนาดเฟรม, ความล่าช้าของสไลด์, และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/gifoptions/).

## **แปลงงานนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

โค้ดตัวอย่างใน C# นี้แสดงวิธีการแปลงงานนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

GIF เคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น. 

{{%  alert  title="TIP"  color="info"  %}} 

หากคุณต้องการปรับแต่งพารามิเตอร์สำหรับ GIF คุณสามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/gifoptions) ดูโค้ดตัวอย่างด้านล่าง. 

{{% /alert %}} 

## **แปลงงานนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่ากำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีการแปลงงานนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่ากำหนดเองใน C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // ขนาดของ GIF ที่ได้  
        DefaultDelay = 2000, // ระยะเวลาที่แต่ละสไลด์จะแสดงจนกว่าจะเปลี่ยนเป็นสไลด์ต่อไป
        TransitionFps = 35 // เพิ่ม FPS เพื่อคุณภาพการเปลี่ยนผ่านที่ดีกว่า
    });
}
```

{{% alert title="Info" color="info" %}}

คุณอาจต้องการดูตัวแปลง Text to GIF ฟรีที่พัฒนาโดย Aspose. 

{{% /alert %}}

## **คำถามที่พบบ่อย**

### ถ้าแบบอักษรที่ใช้ในงานนำเสนอไม่ได้ติดตั้งบนระบบจะทำอย่างไร?

ติดตั้งแบบอักษรที่ขาดหายไปหรือ[กำหนดค่าฟอนต์สำรอง](/slides/th/net/powerpoint-fonts/). Aspose.Slides จะทำการทดแทน แต่การแสดงผลอาจแตกต่างกัน สำหรับการสร้างแบรนด์ ควรตรวจสอบให้แน่ใจว่าแบบอักษรที่จำเป็นพร้อมใช้อย่างชัดเจน.

### ฉันสามารถวางลายน้ำบนเฟรมของ GIF ได้หรือไม่?

ใช่. [เพิ่มวัตถุ/โลโก้ที่โปร่งแสงบางส่วน](/slides/th/net/watermark/) ไปยังหน้าหลักหรือหน้ารายการแต่ละหน้า ก่อนทำการส่งออก — ลายน้ำจะปรากฏบนทุกเฟรม.