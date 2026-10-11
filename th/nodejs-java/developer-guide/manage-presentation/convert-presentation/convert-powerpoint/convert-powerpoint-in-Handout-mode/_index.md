---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout โดยใช้ JavaScript
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด handout
- handout
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารแจกมือ กำหนดจำนวนสไลด์ต่อหน้า เก็บโน้ต ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides สำหรับ Node.js พร้อมโค้ดตัวอย่าง ทดลองใช้ฟรี."
---
## **บทนำ**

Aspose.Slides มีความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารแจกมือพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณตั้งค่าว่าจะให้สไลด์หลายสไลด์ปรากฏบนหน้าหนึ่งอย่างไร ซึ่งเป็นประโยชน์สำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้ได้โดยการตั้งค่าเมธอด `setSlidesLayoutOptions` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) 

เพื่อกำหนดขนาดและทิศทางของหน้าสำหรับเอกสารแจกมือก่อนการส่งออก ดูที่ [Notes Page Size](/slides/th/nodejs-java/notes-size/).

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่จะวางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 สไลด์ต่อหน้าในแนวนอน
slidesLayoutOptions.setPrintSlideNumbers(true);                                // พิมพ์หมายเลขสไลด์
slidesLayoutOptions.setPrintFrameSlide(true);                                  // พิมพ์กรอบรอบสไลด์
slidesLayoutOptions.setPrintComments(false);                                   // ไม่มีคอมเมนต์

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
โปรดทราบว่าเมธอด `setSlidesLayoutOptions` มีให้ใช้เฉพาะบางรูปแบบผลลัพธ์เท่านั้น เช่น PDF, HTML, TIFF และเมื่อแสดงผลเป็นภาพ
{{% /alert %}} 

## **FAQ**

**จำนวนภาพย่อสไลด์สูงสุดต่อหน้าหนึ่งในโหมด Handout คือเท่าใด?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handouttype/) มากสุด 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) และ 9 (horizontal/vertical).

**ฉันสามารถกำหนดกริดที่กำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**

ไม่. จำนวนและการจัดเรียงของภาพย่อถูกควบคุมโดย enumeration [HandoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handouttype/) อย่างเคร่งครัด; ไม่รองรับการจัดวางแบบกำหนดเอง.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. ใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/).