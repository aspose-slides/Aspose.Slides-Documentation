---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย JavaScript
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- โหมด Handout
- เอกสารแจก
- PPT
- PPTX
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงการนำเสนอเป็นเอกสารแจก ตั้งค่าจำนวนสไลด์ต่อหน้า รักษาบันทึกหมายเหตุ ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ด ทดลองใช้ฟรี."
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารแจกสำหรับพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดว่าหน้าหนึ่งจะแสดงหลายสไลด์อย่างไร ทำให้เหมาะกับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้ได้โดยตั้งค่าเมธอด `setSlidesLayoutOptions` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) 

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ

```js
// โหลดงานนำเสนอ.
let presentation = new asposeSlides.Presentation("sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 สไลด์ต่อหนึ่งหน้าในแนวนอน
slidesLayoutOptions.setPrintSlideNumbers(true);                                // พิมพ์หมายเลขสไลด์
slidesLayoutOptions.setPrintFrameSlide(true);                                  // พิมพ์กรอบรอบสไลด์
slidesLayoutOptions.setPrintComments(false);                                   // ไม่มีความคิดเห็น

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// ส่งออกงานนำเสนอเป็น PDF พร้อมเค้าโครงที่เลือก.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
โปรดทราบว่าเมธอด `setSlidesLayoutOptions` มีให้ใช้เฉพาะบางรูปแบบผลลัพธ์ เช่น PDF, HTML, TIFF และเมื่อแสดงผลเป็นภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนพรีวิวสไลด์สูงสุดต่อหน้าที่โหมด Handout คือเท่าไหร่?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handouttype/) สูงสุดถึง 9 พรีวิวต่อหน้าโดยจัดเรียงในแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

**ฉันสามารถกำหนดกริดแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**

ไม่ได้ จำนวนและการจัดเรียงพรีวิวถูกควบคุมโดยการระบุค่าใน enumeration [HandoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handouttype/) การจัดวางแบบอิสระไม่รองรับ.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ใช่ ใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/).