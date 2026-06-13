---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกผู้พูดบน Android
linktitle: PowerPoint เป็น PDF พร้อมบันทึกผู้พูด
type: docs
weight: 50
url: /th/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- PDF พร้อมบันทึกผู้พูด
- Android
- Java
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. รักษาเลย์เอาต์และบันทึกผู้พูดสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PDF พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides คู่มือฉบับนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เม้ตอนจบบทความนี้ คุณจะสามารถ:

- ดำเนินการแปลงเพื่อนำสไลด์ PowerPoint ไปเป็นเอกสาร PDF ขณะรักษาบันทึกผู้พูดไว้
- ปรับแต่ง PDF ผลลัพธ์เพื่อให้แน่ใจว่าบันทึกผู้พูดถูกรวมและจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกผู้พูด**

`save` method ในคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) สามารถใช้ในการแปลงงานนำเสนอ PPT หรือ PPTX ไปเป็น PDF พร้อมบันทึกผู้พูด ด้วย Aspose.Slides คุณเพียงแค่โหลดงานนำเสนอ, กำหนดตัวเลือกการวางเลย์เอาต์โดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกผู้พูด, แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ตัวอย่างไปเป็น PDF ในมุมมองสไลด์บันทึกผู้พูด

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// กำหนดค่า PDF options สำหรับการแสดงบันทึกผู้พูด.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงบันทึกผู้พูดด้านล่างสไลด์.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกผู้พูด.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}