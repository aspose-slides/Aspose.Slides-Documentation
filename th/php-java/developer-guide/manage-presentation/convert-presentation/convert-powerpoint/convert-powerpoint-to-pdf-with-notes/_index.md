---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกใน PHP
linktitle: PowerPoint เป็น PDF พร้อมบันทึก
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
- บันทึกประกาศ
- PDF พร้อมบันทึก
- PHP
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java. รักษาเลเอาต์และบันทึกประกาศสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกประกาศโดยใช้ Aspose.Slides คู่มือฉบับนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้ คุณจะสามารถ:

- ดำเนินการแปลงเพื่อแปลงสไลด์ PowerPoint ให้เป็นเอกสาร PDF โดยคงบันทึกประกาศไว้
- ปรับแต่งไฟล์ PDF ผลลัพธ์เพื่อให้บันทึกประกาศถูกรวมอยู่และจัดรูปแบบตามความต้องการของคุณ

เพื่อกำหนดขนาดและทิศทางของหน้าบันทึกก่อนส่งออก ดูที่[ขนาดหน้าบันทึก](/slides/th/php-java/notes-size/)

## **แปลง PowerPoint เป็น PDF พร้อมบันทึก**

เมธอด `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) สามารถใช้เพื่แปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกประกาศ ด้วย Aspose.Slides คุณเพียงแค่นำเข้าการนำเสนอ กำหนดตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกประกาศ แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึก

```php
$presentation = new Presentation("sample.pptx");

// กำหนดตัวเลือก PDF สำหรับการเรนเดอร์บันทึกผู้บรรยาย.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // แสดงบันทึกผู้บรรยายใต้สไลด์.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Save the presentation to PDF with speaker notes.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion).
{{% /alert %}}