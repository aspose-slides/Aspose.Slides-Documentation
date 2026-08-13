---
title: แปลงการนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตบน Android
linktitle: PowerPoint เป็น PDF พร้อมโน้ต
type: docs
weight: 50
url: /th/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
- สไลด์เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกการนำเสนอเป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- โน้ตการพูด
- PDF พร้อมโน้ต
- Android
- Java
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมโน้ตโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. รักษาเค้าโครงและโน้ตการพูดสำหรับการนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงไฟล์ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกการพูดโดยใช้ Aspose.Slides คู่มือนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้แล้ว คุณจะสามารถ:

- ดำเนินการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint เป็นเอกสาร PDF พร้อมคงบันทึกการพูดไว้
- ปรับแต่ง PDF ที่ส่งออกให้รวมบันทึกการพูดและจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมโน้ต**

เมธอด `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) สามารถใช้แปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกการพูดได้ ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ ตั้งค่าตัวเลือกการจัดเลย์เอาต์โดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกการพูด แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอตัวอย่างเป็น PDF ในมุมมองสไลด์โน้ต

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// กำหนดค่าตัวเลือก PDF สำหรับการเรนเดอร์โน้ตการพูด.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงโน้ตการพูดใต้สไลด์.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// บันทึกการนำเสนอเป็น PDF พร้อมโน้ตการพูด.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}