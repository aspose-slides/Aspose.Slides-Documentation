---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกผู้พูดใน PHP
linktitle: PowerPoint เป็น PDF พร้อมบันทึกผู้พูด
type: docs
weight: 50
url: /th/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- สไลด์เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกงานนำเสนอเป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- บันทึกผู้พูด
- PDF พร้อมบันทึก
- PHP
- Aspose.Slides
description: "แปลงไฟล์รูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java. คงรูปแบบการจัดวางและบันทึกผู้พูดสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides คู่มือนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้แล้ว คุณจะสามารถ:

- ทำกระบวนการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint เป็นเอกสาร PDF พร้อมคงบันทึกผู้พูดไว้
- ปรับแต่ง PDF ที่ส่งออกเพื่อให้บันทึกผู้พูดถูกรวมและจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกผู้พูด**

เมธอด `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) สามารถใช้แปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกผู้พูดได้ ด้วย Aspose.Slides เพียงโหลดงานนำเสนอ ตั้งค่าตัวเลือกการจัดเรียงโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกผู้พูด หลังจากนั้นบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดด้านล่างแสดงวิธีแปลงงานนำเสนอตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึกผู้พูด

```php
$presentation = new Presentation("sample.pptx");

// กำหนดค่าตัวเลือก PDF สำหรับการเรนเดอร์บันทึกผู้พูด.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // เรนเดอร์บันทึกผู้พูดไว้ด้านล่างของสไลด์.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกผู้พูด.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
คุณอาจต้องการลองใช้ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion) 
{{% /alert %}}