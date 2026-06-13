---
title: แปลงการนำเสนอ PowerPoint ไปเป็น TIFF พร้อมบันทึกย่อใน JavaScript
linktitle: PowerPoint ไปเป็น TIFF พร้อมบันทึกย่อ
type: docs
weight: 100
url: /th/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปเป็น TIFF
- การนำเสนอไปเป็น TIFF
- สไลด์ไปเป็น TIFF
- PPT ไปเป็น TIFF
- PPTX ไปเป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- PowerPoint พร้อมบันทึกย่อ
- การนำเสนอพร้อมบันทึกย่อ
- สไลด์พร้อมบันทึกย่อ
- PPT พร้อมบันทึกย่อ
- PPTX พร้อมบันทึกย่อ
- TIFF พร้อมบันทึกย่อ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint ไปเป็น TIFF พร้อมบันทึกย่อใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เรียนรู้วิธีส่งออกสไลด์พร้อมบันทึกย่อได้อย่างมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides for Node.js via Java ให้โซลูชันง่ายสำหรับการแปลงการนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมบันทึกย่อเป็นรูปแบบ TIFF รูปแบบนี้ถูกใช้กันอย่างแพร่หลายสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บถาวรเอกสาร ด้วย Aspose.Slides คุณสามารถไม่เพียงส่งออกการนำเสนอทั้งหมดพร้อมบันทึกย่อนำเสนอเท่านั้น แต่ยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide กระบวนการแปลงง่ายและมีประสิทธิภาพ โดยใช้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อแปลงการนำเสนอทั้งหมดเป็นชุดภาพ TIFF พร้อมคงบันทึกย่อและเค้าโครงไว้

## **แปลงการนำเสนอเป็น TIFF พร้อมบันทึกย่อ**

การบันทึกการนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกย่อโดยใช้ Aspose.Slides for Node.js via Java เกี่ยวข้องกับขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) : โหลดไฟล์ PowerPoint หรือ OpenDocument
1. กำหนดค่าตัวเลือกการจัดวางผลลัพธ์ : ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) เพื่อระบุวิธีการแสดงบันทึกย่อและความคิดเห็น
1. บันทึกการนำเสนอเป็น TIFF : ส่งตัวเลือกที่กำหนดให้กับเมธอด [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save)

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอพร้อมบันทึกย่อ](slide_with_notes.png)

```js
// สร้างอินสแตนซ์ของคลาส Presentation ซึ่งเป็นตัวแทนของไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // แสดงบันทึกย่อใต้สไลด์.

    // กำหนดค่าตัวเลือก TIFF พร้อมการจัดวางบันทึกย่อ.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกการนำเสนอเป็น TIFF พร้อมบันทึกย่อนำเสนอ.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ภาพ TIFF พร้อมบันทึกย่อ](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
ลองดู Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online)  
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมตำแหน่งของพื้นที่บันทึกย่อใน TIFF ที่ได้หรือไม่?**

ใช่ ใช้ [notes layout settings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) เพื่อเลือกตัวเลือกเช่น `None`, `BottomTruncated` หรือ `BottomFull` ซึ่งจะซ่อนบันทึกย่อ, จัดให้พอดีหนึ่งหน้า, หรือให้บันทึกย่อไหลต่อไปยังหน้าต่อไปตามลำดับ

**ฉันจะลดขนาดไฟล์ TIFF ที่มีบันทึกย่อโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?**

เลือก [efficient compression](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ที่เหมาะสม, และหากยอมรับได้ ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับโมโนโครม) การลดขนาด [image dimensions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/setimagesize/) เล็กน้อยก็ช่วยได้โดยไม่กระทบความอ่านได้อย่างชัดเจน

**ฟอนต์ในบันทึกย่อจะส่งผลต่อผลลัพธ์หรือไม่ หากฟอนต์ต้นฉบับไม่มีในระบบ?**

ใช่ ฟอนต์ที่หายไปจะทำให้เกิด [substitution](/slides/th/nodejs-java/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกซ์และรูปแบบของข้อความ เพื่อหลีกเลี่ยงนี้ให้ [supply the required fonts](/slides/th/nodejs-java/custom-font/) หรือกำหนด [fallback font](/slides/th/nodejs-java/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.