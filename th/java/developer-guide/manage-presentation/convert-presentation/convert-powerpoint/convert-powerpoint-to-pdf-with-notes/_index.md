---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกย่อใน Java
linktitle: PowerPoint เป็น PDF พร้อมบันทึกย่อ
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
- โน้ตของผู้พูด
- PDF พร้อมบันทึกย่อ
- Java
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกย่อโดยใช้ Aspose.Slides สำหรับ Java. รักษาการจัดวางและโน้ตของผู้พูดสำหรับการนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint ให้เป็นรูปแบบ PDF พร้อมบันทึกย่อของผู้พูดโดยใช้ Aspose.Slides คู่มือฉบับนี้จะอธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้ คุณจะสามารถ:

- ดำเนินการกระบวนการแปลงเพื่อแปลงสไลด์ PowerPoint ให้เป็นเอกสาร PDF พร้อมคงบันทึกย่อของผู้พูดไว้
- ปรับแต่ง PDF ที่ส่งออกเพื่อให้แน่ใจว่าบันทึกย่อของผู้พูดถูกรวมและจัดรูปแบบตามความต้องการของคุณ

เพื่อกำหนดขนาดและทิศทางของหน้าบันทึกย่อก่อนการส่งออก ดูที่ [ขนาดหน้าบันทึกย่อ](/slides/th/java/notes-size/)  

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกย่อ**

เมธอด `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX ให้เป็น PDF พร้อมบันทึกย่อของผู้พูด ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ ปรับแต่งตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกย่อของผู้พูด แล้วบันทึกไฟล์เป็น PDF โค้ดตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึกย่อ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// กำหนดตัวเลือก PDF สำหรับการเรนเดอร์บันทึกย่อของผู้พูด.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // เรนเดอร์บันทึกย่อของผู้พูดด้านล่างสไลด์.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกย่อของผู้พูด.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
คุณอาจต้องการลองใช้ Aspose [ตัวแปลง PowerPoint เป็น PDF ออนไลน์](https://products.aspose.app/slides/th/conversion).
{{% /alert %}}