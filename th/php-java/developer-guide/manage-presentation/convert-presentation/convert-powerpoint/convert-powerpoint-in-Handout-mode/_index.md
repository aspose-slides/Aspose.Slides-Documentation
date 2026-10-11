---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย PHP
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/php-java/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- ชุดแจก
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นชุดแจกใน PHP ตั้งค่าจำนวนสไลด์ต่อหน้า เก็บบันทึก ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides สำหรับ PHP พร้อมตัวอย่างโค้ด ทดลองใช้ฟรี"
---
## **บทนำ**

Aspose.Slides มีความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่างๆ รวมถึงการสร้างชุดแจกสำหรับการพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดว่าหลายๆ สไลด์จะแสดงบนหน้าหนึ่งอย่างไร ซึ่งเป็นประโยชน์สำหรับการประชุม สัมมนา หรือกิจกรรมอื่นๆ คุณสามารถเปิดใช้งานโหมดนี้โดยตั้งค่าวิธี `setSlidesLayoutOptions` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) 

เพื่อกำหนดขนาดและทิศทางของหน้าชุดแจกก่อนทำการส่งออก ดูที่ [Notes Page Size](/slides/th/php-java/notes-size/).

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดว่ามีกี่สไลด์ที่จะวางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่นๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```php
// โหลดงานนำเสนอ.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 สไลด์ต่อหน้าหนึ่งแนวนอน
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // พิมพ์เลขสไลด์
$slidesLayoutOptions->setPrintFrameSlide(true);                      // พิมพ์กรอบรอบสไลด์
$slidesLayoutOptions->setPrintComments(false);                       // ไม่แสดงความคิดเห็น

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
โปรดทราบว่าวิธี `setSlidesLayoutOptions` มีให้ใช้เฉพาะรูปแบบเอาต์พุตบางประเภทเท่านั้น เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของภาพย่อสไลด์ต่อหน้าที่โหมด Handout สามารถรองรับได้เท่าไหร่?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/php-java/aspose.slides/handouttype/) สูงสุดถึง 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

**ฉันสามารถกำหนดกริดแบบกำหนดเองได้หรือไม่ เช่น 5 หรือ 8 สไลด์ต่อหน้า?**

ไม่ได้ จำนวนและการจัดเรียงของภาพย่อถูกควบคุมอย่างเข้มงวดโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/handouttype/) ; การจัดวางแบบกำหนดเองจะไม่รองรับ.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. เปิดใช้สไลด์ที่ซ่อนอยู่โดยใช้วิธี `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/).