---
title: แปลงงานพรีเซนเทชั่น PowerPoint ในโหมด Handout ด้วย PHP
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/php-java/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานพรีเซนเทชั่น
- โหมด Handout
- Handout
- PPT
- PPTX
- PowerPoint
- พรีเซนเทชั่น
- PHP
- Aspose.Slides
description: "แปลงงานพรีเซนเทชั่นเป็นแฮนด์เอาท์ด้วย PHP ตั้งค่าจำนวนสไลด์ต่อหน้า รักษาโน้ต ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides สำหรับ PHP พร้อมตัวอย่างโค้ด ทดลองใช้งานฟรี"
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานพรีเซนเทชั่นเป็นรูปแบบต่าง ๆ รวมถึงการสร้างแฮนด์เอาท์เพื่อพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดวิธีที่หลายสไลด์ปรากฏบนหน้าหนึ่ง ทำให้เหมาะสำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้ได้โดยการตั้งค่าเมธอด `setSlidesLayoutOptions` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/)

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานพรีเซนเทชั่นเป็น PDFในโหมด Handout

```php
// โหลดงานพรีเซนเทชั่น.
$presentation = new Presentation("sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 สไลด์ต่อหน้าหนึ่งในแนวนอน
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // พิมพ์เลขสไลด์
$slidesLayoutOptions->setPrintFrameSlide(true);                      // พิมพ์กรอบล้อมรอบสไลด์
$slidesLayoutOptions->setPrintComments(false);                       // ไม่มีคอมเมนต์

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// ส่งออกงานพรีเซนเทชั่นเป็น PDF ด้วยการจัดเรียงที่เลือก.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
โปรดทราบว่าเมธอด `setSlidesLayoutOptions` มีให้เฉพาะรูปแบบผลลัพธ์บางรูปแบบเท่านั้น เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของภาพย่อสไลด์ต่อหน้าหนึ่งในโหมด Handout คือเท่าไหร่?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/php-java/aspose.slides/handouttype/) ที่มีจำนวนภาพย่อสูงสุด 9 รายการต่อหน้า พร้อมการจัดเรียงในแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

**ฉันสามารถกำหนดกริดแบบกำหนดเองได้หรือไม่ เช่น 5 หรือ 8 สไลด์ต่อหน้า?**

ไม่ได้ จำนวนและการจัดเรียงของภาพย่อถูกควบคุมอย่างเคร่งครัดโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/handouttype/) ; การจัดเรียงแบบอิสระไม่สนับสนุน

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. เปิดใช้สไลด์ที่ซ่อนอยู่ด้วยเมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/).