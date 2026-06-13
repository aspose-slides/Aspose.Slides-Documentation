---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย PHP
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารแจก
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารแจกใน PHP ตั้งค่าสไลด์ต่อหน้า คงบันทึกย่อ ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides สำหรับ PHP พร้อมตัวอย่างโค้ด ทดลองใช้งานฟรี"
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารแจกพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดว่าหน้าหนึ่งจะแสดงสไลด์หลายหน้าอย่างไร ทำให้เหมาะสำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้ได้โดยตั้งค่าวิธี `setSlidesLayoutOptions` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) 

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่จะวางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ  

```php
// โหลดงานนำเสนอ.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // สไลด์ 4 แทบต่อหนึ่งหน้าในแนวนอน
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // พิมพ์หมายเลขสไลด์
$slidesLayoutOptions->setPrintFrameSlide(true);                      // พิมพ์กรอบรอบสไลด์
$slidesLayoutOptions->setPrintComments(false);                       // ไม่มีความคิดเห็น

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่า วิธี `setSlidesLayoutOptions` มีให้ใช้เฉพาะในรูปแบบผลลัพธ์บางรูปแบบเท่านั้น เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของรูปภาพย่อสไลด์ต่อหน้าหนึ่งในโหมด Handout คือเท่าใด?**  
Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/php-java/aspose.slides/handouttype/) สูงสุดถึง 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).  

**ฉันสามารถกำหนดตารางแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**  
ไม่ได้ จำนวนและการจัดเรียงของภาพย่อถูกควบคุมโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/handouttype/) อย่างเคร่งครัด; การจัดวางแบบกำหนดเองไม่ได้รับการสนับสนุน.  

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**  
ได้ สามารถเปิดใช้สไลด์ที่ซ่อนอยู่โดยใช้วิธี `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/).