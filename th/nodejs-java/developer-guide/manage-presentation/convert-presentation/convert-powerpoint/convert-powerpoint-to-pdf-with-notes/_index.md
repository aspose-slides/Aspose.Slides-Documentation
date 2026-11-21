---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตใน JavaScript
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
- โน้ตผู้บรรยาย
- PDF พร้อมโน้ต
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมโน้ตใน JavaScript โดยใช้ Aspose.Slides สำหรับ Node.js. รักษาเค้าโครงและโน้ตผู้บรรยายสำหรับการนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกคำพูดผู้บรรยายโดยใช้ Aspose.Slides คู่มือนี้จะอธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านบทความจนจบแล้ว คุณจะสามารถ:

- ทำกระบวนการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint เป็นเอกสาร PDF พร้อมคงบันทึกคำพูดผู้บรรยายไว้
- ปรับแต่ง PDF ที่ออกมาให้แน่ใจว่าบันทึกคำพูดผู้บรรยายรวมอยู่และจัดรูปแบบตามความต้องการของคุณ

เพื่อกำหนดขนาดหน้าโน้ตและหน้าต่างก่อนการส่งออก โปรดดูที่ [Notes Page Size](/slides/th/nodejs-java/notes-size/).

## **แปลง PowerPoint เป็น PDF พร้อมโน้ต**

`save` เมธอดในคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกคำพูดผู้บรรยายได้ ด้วย Aspose.Slides คุณเพียงแค่โหลดงานนำเสนอ กำหนดค่าตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) เพื่อรวมบันทึกคำพูดผู้บรรยาย แล้วบันทึกไฟล์เป็น PDF โค้ดตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอแบบตัวอย่างเป็น PDF ในมุมมองสไลด์โน้ต

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// กำหนดค่าตัวเลือก PDF สำหรับการแสดงโน้ตผู้บรรยาย.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // แสดงโน้ตผู้บรรยายด้านล่างสไลด์.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion).
{{% /alert %}}