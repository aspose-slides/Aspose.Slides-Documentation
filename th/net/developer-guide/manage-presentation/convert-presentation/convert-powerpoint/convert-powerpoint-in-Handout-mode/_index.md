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
- Handout
- PowerPoint
- งานนำเสนอ
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอเป็น handout ใน .NET ตั้งค่าจำนวนสไลด์ต่อหน้า เก็บบันทึก ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# ทดลองใช้ฟรี."
---
## **บทนำ**

Aspose.Slides ช่วยให้คุณสามารถแปลงงานนำเสนอเป็นรูปแบบผลลัพธ์ที่รองรับโหมด Handoutได้ ในโหมดนี้สไลด์หลายหน้าจะถูกจัดเรียงบนหน้ากระดาษเดียว ซึ่งเป็นประโยชน์สำหรับการพิมพ์วัสดุนำเสนอสำหรับการประชุม สัมมนา และกิจกรรมที่คล้ายกัน.

โหมด Handout ถูกกำหนดค่าผ่านคุณสมบัติ `SlidesLayoutOptions` ซึ่งมีใน [IPdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/). เพื่อกำหนดรูปแบบ Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/handoutlayoutingoptions/) .

เพื่อกำหนดขนาดและแนวการวางหน้าของ Handout ก่อนการส่งออก โปรดดูที่ [ขนาดหน้าบันทึก](/slides/th/net/notes-size/).

## **การส่งออกโหมด Handout**

เพื่อส่งออกงานนำเสนอในโหมด Handout ให้ตั้งค่าคุณสมบัติ `SlidesLayoutOptions` สำหรับตัวเลือกการส่งออกเป้าหมายและกำหนดอ็อบเจ็กต์ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/handoutlayoutingoptions/) ที่กำหนดจำนวนสไลด์ต่อหน้าและพารามิเตอร์การแสดงผลที่เกี่ยวข้อง.

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// โหลดงานนำเสนอ.
using var presentation = new Presentation("sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // สไลด์ 4 หน้าต่อหน้าในแนวนอน
        PrintSlideNumbers = true,                   // พิมพ์หมายเลขสไลด์
        PrintFrameSlide = true,                     // พิมพ์กรอบรอบสไลด์
        PrintComments = false                       // ไม่มีคอมเมนต์
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่าคุณสมบัติ `SlidesLayoutOptions` มีให้เฉพาะสำหรับรูปแบบผลลัพธ์บางอย่าง เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ. 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

### จำนวนสูงสุดของภาพย่อสไลด์ต่อหน้าในโหมด Handout คือเท่าไร?

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/net/aspose.slides.export/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า โดยจัดตามแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

### ฉันสามารถกำหนดตารางที่กำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?

ไม่. จำนวนและลำดับของภาพย่อถูกควบคุมโดยอย่างเคร่งครัดโดย enumeration [HandoutType](https://reference.aspose.com/slides/th/net/aspose.slides.export/handouttype/); การจัดเรียงแบบอิสระไม่รองรับ.

### ฉันสามารถรวมสไลด์ที่ซ่อนไว้ในผลลัพธ์ Handout ได้หรือไม่?

ได้. เปิดใช้งานตัวเลือก `ShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/).