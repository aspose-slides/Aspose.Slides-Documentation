---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกเสียงพูดบน Android
linktitle: PowerPoint เป็น PDF พร้อมบันทึกเสียงพูด
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
- บันทึกเสียงพูด
- PDF พร้อมบันทึก
- Android
- Java
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกเสียงพูดโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. รักษาการจัดวางและบันทึกเสียงพูดสำหรับงานนำเสนอมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PDF พร้อมบันทึกเสียงพูดโดยใช้ Aspose.Slides คู่มือฉบับนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่อตอนจบบทความนี้ คุณจะสามารถ:

- ดำเนินการกระบวนการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint ให้เป็นเอกสาร PDF ขณะคงบันทึกเสียงพูดไว้
- ปรับแต่ง PDF ที่ได้เพื่อให้แน่ใจว่าบันทึกเสียงพูดถูกรวมอยู่และจัดรูปแบบตามความต้องการของคุณ

หากต้องการตั้งขนาดและแนวหน้าบันทึกก่อนการส่งออก ดูที่ [ขนาดหน้าบันทึก](/slides/th/androidjava/notes-size/).

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกเสียงพูด**

`save` method ในคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกเสียงพูด ด้วย Aspose.Slides คุณเพียงแค่โหลดงานนำเสนอ กำหนดค่าตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกเสียงพูด แล้วบันทึกไฟล์เป็น PDF โค้ดตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึก

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// กำหนดค่าตัวเลือก PDF สำหรับการเรนเดอร์บันทึกเสียงพูด.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // เรนเดอร์บันทึกเสียงพูดใต้สไลด์.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกเสียงพูด.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
คุณอาจต้องการดู Aspose [เครื่องแปลง PowerPoint เป็น PDF ออนไลน์](https://products.aspose.app/slides/th/conversion).
{{% /alert %}}