---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย .NET
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/net/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารสรุป
- PowerPoint
- งานนำเสนอ
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารสรุปใน .NET ตั้งค่าจำนวนสไลด์ต่อหน้า เก็บบันทึกย่อ ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# ใช้ได้ฟรี"
---
## **บทนำ**

Aspose.Slides ให้คุณแปลงงานนำเสนอเป็นรูปแบบผลลัพธ์ที่รองรับโหมด Handout. ในโหมดนี้ สไลด์หลาย ๆ หน้า จะถูกจัดเรียงบนหน้าเดียว ซึ่งเป็นประโยชน์สำหรับการพิมพ์วัสดุนำเสนอสำหรับการประชุม สัมมนา และกิจกรรมที่คล้ายกัน.

โหมด Handout ถูกกำหนดค่าผ่านคุณสมบัติ `SlidesLayoutOptions` ซึ่งมีให้ใช้ใน [IPdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/). เพื่อกำหนดเลย์เอาต์ของ handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/handoutlayoutingoptions/)  

## **การส่งออกในโหมด Handout**

เพื่อส่งออกรูปแบบงานนำเสนอในโหมด Handout ให้ตั้งค่าคุณสมบัติ `SlidesLayoutOptions` สำหรับตัวเลือกการส่งออกเป้าหมายและกำหนดอินสแตนซ์ของ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/handoutlayoutingoptions/) ที่กำหนดจำนวนสไลด์ต่อหน้าและพารามิเตอร์การแสดงผลที่เกี่ยวข้อง

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```c#
// โหลดงานนำเสนอ.
using var presentation = new Presentation("sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 สไลด์ต่อหน้าในแนวนอน
        PrintSlideNumbers = true,                   // พิมพ์หมายเลขสไลด์
        PrintFrameSlide = true,                     // พิมพ์กรอบรอบสไลด์
        PrintComments = false                       // ไม่มีคอมเมนต์
    }
};

// ส่งออกงานนำเสนอเป็น PDF ด้วยเลย์เอาต์ที่เลือก.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่า​คุณสมบัติ `SlidesLayoutOptions` มีให้ใช้เฉพาะกับรูปแบบผลลัพธ์บางประเภท เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของภาพย่อสไลด์ต่อหน้าที่รองรับในโหมด Handout คือเท่าใด?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/net/aspose.slides.export/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง)

**ฉันสามารถกำหนดตารางแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**

ไม่ได้. จำนวนและการจัดเรียงของภาพย่อถูกควบคุมโดยการอธิบายของ [HandoutType](https://reference.aspose.com/slides/th/net/aspose.slides.export/handouttype/) อย่างเคร่งครัด; ไม่รองรับการจัดวางแบบสุ่ม

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. เปิดใช้งานตัวเลือก `ShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/)