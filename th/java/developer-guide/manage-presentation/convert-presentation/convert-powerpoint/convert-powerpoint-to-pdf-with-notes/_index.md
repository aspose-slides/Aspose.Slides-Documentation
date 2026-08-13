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
- บันทึกย่อของผู้พูด
- PDF พร้อมบันทึกย่อ
- Java
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกย่อโดยใช้ Aspose.Slides สำหรับ Java. รักษาการจัดวางและบันทึกย่อของผู้พูดสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกย่อโดยใช้ Aspose.Slides คู่มือฉบับนี้จะอธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้แล้ว คุณจะสามารถ：

- ดำเนินการแปลงเพื่อนำสไลด์ PowerPoint ไปเป็นเอกสาร PDF พร้อมคงบันทึกย่อของผู้พูดไว้
- ปรับแต่งไฟล์ PDF ผลลัพธ์ให้บันทึกย่อของผู้พูดถูกรวมและจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกย่อ**

วิธี `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกย่อของผู้พูด ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ กำหนดค่าตัวเลือกการจัดวางด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกย่อ แล้วบันทึกไฟล์เป็น PDF โค้ดตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ตัวอย่าง ไปเป็น PDF ในมุมมองสไลด์บันทึกย่อ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// กำหนดค่า PDF options สำหรับการแสดงบันทึกย่อของผู้พูด.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงบันทึกย่อของผู้พูดด้านล่างสไลด์.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกย่อของผู้พูด.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 

คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 

{{% /alert %}}