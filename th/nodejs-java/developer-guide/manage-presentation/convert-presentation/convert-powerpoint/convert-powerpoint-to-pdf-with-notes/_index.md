---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตด้วย JavaScript
linktitle: PowerPoint เป็น PDF พร้อมโน้ต
type: docs
weight: 50
url: /th/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- โน้ตของผู้บรรยาย
- PDF พร้อมโน้ต
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมโน้ตด้วย JavaScript โดยใช้ Aspose.Slides สำหรับ Node.js รักษาเลย์เอาต์และโน้ตของผู้บรรยายสำหรับการนำเสนอระดับมืออาชีพ"
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมโน้ตของผู้บรรยายโดยใช้ Aspose.Slides คู่มือฉบับนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้ คุณจะสามารถ:

- ดำเนินการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint เป็นเอกสาร PDF พร้อมคงโน้ตของผู้บรรยายไว้
- ปรับแต่งไฟล์ PDF ที่ได้เพื่อให้แน่ใจว่าโน้ตของผู้บรรยายถูกรวมอยู่และจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมโน้ต**

`save` method ในคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมโน้ตของผู้บรรยาย ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ กำหนดค่าตัวเลือกการจัดรูปแบบโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) เพื่อรวมโน้ตของผู้บรรยาย แล้วบันทึกไฟล์เป็น PDF โค้ดตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ตัวอย่างเป็น PDF ในมุมมองสไลด์โน้ต

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// ตั้งค่าตัวเลือก PDF สำหรับการเรนเดอร์โน้ตของผู้บรรยาย.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // เรนเดอร์โน้ตของผู้บรรยายด้านล่างสไลด์.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// บันทึกงานนำเสนอเป็น PDF พร้อมโน้ตของผู้บรรยาย.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}