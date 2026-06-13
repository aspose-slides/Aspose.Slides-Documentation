---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกย่อใน Java
linktitle: PowerPoint เป็น TIFF พร้อมบันทึกย่อ
type: docs
weight: 100
url: /th/java/convert-powerpoint-to-tiff-with-notes/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- งานนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- PowerPoint พร้อมบันทึกย่อ
- งานนำเสนอพร้อมบันทึกย่อ
- สไลด์พร้อมบันทึกย่อ
- PPT พร้อมบันทึกย่อ
- PPTX พร้อมบันทึกย่อ
- TIFF พร้อมบันทึกย่อ
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกยโดยใช้ Aspose.Slides สำหรับ Java เรียนรู้วิธีส่งออกสไลด์พร้อมบันทึกย่อของผู้พูดอย่างมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides for Java ให้วิธีแก้ง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX และ ODP) พร้อมบันทึกย่อเป็นรูปแบบ TIFF รูปแบบนี้ถูกใช้กันอย่างแพร่หลายสำหรับการเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บเอกสารอย่างถาวร ด้วย Aspose.Slides คุณไม่เพียงแต่สามารถส่งออกงานนำเสนอทั้งหมดพร้อมบันทึกย่อของผู้พูดเท่านั้น แต่ยังสามารถสร้างภาพย่อสไลด์ในมุมมอง Notes Slide ได้อีกด้วย ขั้นตอนการแปลงนั้นง่ายและมีประสิทธิภาพ โดยใช้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดภาพ TIFF พร้อมคงบันทึกย่อและเค้าโครงไว้

## **แปลงงานนำเสนอเป็น TIFF พร้อมบันทึกย่อ**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกย่อโดยใช้ Aspose.Slides for Java ทำได้ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) : โหลดไฟล์ PowerPoint หรือ OpenDocument
2. กำหนดตัวเลือกเค้าโครงผลลัพธ์ : ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) เพื่อระบุวิธีการแสดงบันทึกย่อและคอมเมนต์
3. บันทึกงานนำเสนอเป็น TIFF : ส่งตัวเลือกที่กำหนดไปยังเมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 

สมมติว่าเรามีไฟล์ “speaker_notes.pptx” ที่มีสไลด์ดังต่อไปนี้:

![The presentation slide with speaker notes](slide_with_notes.png)

โค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide ด้วยเมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) :

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงบันทึกย่อด้านล่างสไลด์.

    // กำหนดค่าตัวเลือก TIFF ด้วยการจัดเค้าโครงบันทึกย่อ.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF พร้อมบันทึกย่อของผู้พูด.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="เคล็ดลับ" color="primary" %}}
ลองดู Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมตำแหน่งของพื้นที่บันทึกย่อใน TIFF ที่ได้หรือไม่?**

ได้ ใช้ [การตั้งค่าเค้าโครงบันทึกย่อ](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อเลือกตัวเลือกเช่น `None`, `BottomTruncated` หรือ `BottomFull` ซึ่งจะซ่อนบันทึกย่อ, ทำให้บันทึกย่อพอดีในหน้าเดียว, หรือให้บันทึกย่อไหลต่อไปในหน้าถัดไปตามลำดับ

**ฉันจะลดขนาดไฟล์ TIFF ที่มีบันทึกย่อโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?**

เลือก [การบีบอัดที่มีประสิทธิภาพ](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ที่เหมาะสม, และหากยอมรับได้ ให้ใช้ [รูปแบบพิกเซล](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับภาพขาวดำ) การลด [มิติของภาพ](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) เพียงเล็กน้อยก็ช่วยได้โดยไม่ส่งผลต่อความสามารถในการอ่านอย่างชัดเจน

**ฟอนต์ในบันทึกย่อจะส่งผลต่อผลลัพธ์หรือไม่ หากฟอนต์ต้นฉบับไม่มีในระบบ?**

ใช่ ฟอนต์ที่หายไปจะทำให้เกิด [การแทนที่](/slides/th/java/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกซ์และรูปลักษณ์ของข้อความ เพื่อหลีกเลี่ยงปัญหานี้ ให้ [จัดหา ฟอนต์ที่จำเป็น](/slides/th/java/custom-font/) หรือกำหนด [ฟอนต์สำรองเริ่มต้น](/slides/th/java/fallback-font/) เพื่อให้ใช้แบบอักษรที่ต้องการได้