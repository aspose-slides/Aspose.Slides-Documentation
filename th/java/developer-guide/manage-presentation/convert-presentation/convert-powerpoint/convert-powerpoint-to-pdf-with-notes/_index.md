---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกอธิบายใน Java
linktitle: PowerPoint เป็น PDF พร้อมบันทึกอธิบาย
type: docs
weight: 50
url: /th/java/convert-powerpoint-to-pdf-with-notes/
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
- บันทึกอธิบาย
- PDF พร้อมบันทึกอธิบาย
- Java
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกอธิบายโดยใช้ Aspose.Slides สำหรับ Java. รักษาเค้าโครงและบันทึกอธิบายสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกอธิบายโดยใช้ Aspose.Slides คู่มือนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำภารกิจนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้แล้วคุณจะสามารถ:

- ดำเนินกระบวนการแปลงเพื่อแปลงสไลด์ PowerPoint ให้เป็นเอกสาร PDF พร้อมรักษาบันทึกอธิบายไว้
- ปรับแต่งไฟล์ PDF ที่สร้างขึ้นเพื่อให้บันทึกอธิบายถูกใส่และจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกอธิบาย**

เมธอด `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกอธิบาย ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ กำหนดตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกอธิบาย แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำแบบตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึกอธิบาย

```java
Presentation presentation = new Presentation("sample.pptx");

// กำหนดค่าตัวเลือก PDF สำหรับการแสดงบันทึกอธิบาย.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงบันทึกอธิบายด้านล่างสไลด์.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกอธิบาย.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}