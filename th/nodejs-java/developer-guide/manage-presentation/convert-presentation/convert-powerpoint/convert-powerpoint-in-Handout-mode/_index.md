---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout โดยใช้ JavaScript
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารสรุป
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารสรุป ตั้งค่าจำนวนสไลด์ต่อหน้า รักษาโน้ต ส่งออกเป็น PDF หรือรูปภาพด้วย Aspose.Slides สำหรับ Node.js พร้อมโค้ดตัวอย่าง ลองใช้งานฟรี"
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารสรุปสำหรับพิมพ์ในโหมด Handout โหมดนี้อนุญาตให้คุณกำหนดว่าหลายสไลด์จะแสดงบนหน้าหนึ่งอย่างไร ทำให้เป็นประโยชน์สำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้โหมดนี้ได้โดยการตั้งค่าวิธี `setSlidesLayoutOptions` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/),[RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/),[HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/),และ[TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) 

## **การส่งออกโหมด Handout**

ในการกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ  

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout  

```js
// โหลดงานนำเสนอ.
let presentation = new asposeSlides.Presentation("sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 สไลด์ต่อหน้าในแนวนอน
slidesLayoutOptions.setPrintSlideNumbers(true);                                // พิมพ์หมายเลขสไลด์
slidesLayoutOptions.setPrintFrameSlide(true);                                  // พิมพ์กรอบรอบสไลด์
slidesLayoutOptions.setPrintComments(false);                                   // ไม่มีคอมเมนต์

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// ส่งออกงานนำเสนอเป็น PDF ด้วยการจัดวางที่เลือก.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่าเมธอด `setSlidesLayoutOptions` มีให้ใช้เฉพาะรูปแบบเอาต์พุตบางรูปแบบ เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นรูปภาพ 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของภาพย่อสไลด์ต่อหน้าในโหมด Handout คือเท่าไหร่?**  
Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).  

**ฉันสามารถกำหนดตารางแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**  
ไม่ได้ จำนวนและการจัดเรียงภาพย่อถูกควบคุมอย่างเคร่งครัดโดยการนับประเภท [HandoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handouttype/); ไม่รองรับการจัดเรียงแบบกำหนดเอง.  

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**  
ได้ ใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/),[HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/),หรือ[TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/).