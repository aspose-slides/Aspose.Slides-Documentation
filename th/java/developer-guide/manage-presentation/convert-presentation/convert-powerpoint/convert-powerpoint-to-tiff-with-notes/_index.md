---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตใน Java
linktitle: PowerPoint เป็น TIFF พร้อมโน้ต
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
- PowerPoint พร้อมโน้ต
- งานนำเสนอพร้อมโน้ต
- สไลด์พร้อมโน้ต
- PPT พร้อมโน้ต
- PPTX พร้อมโน้ต
- TIFF พร้อมโน้ต
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตด้วย Aspose.Slides สำหรับ Java. เรียนรู้วิธีการส่งออกสไลด์พร้อมโน้ตของผู้พูดอย่างมีประสิทธิภาพ."
---
## **บทนำ**

Aspose.Slides for Java ให้วิธีแก้ง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX และ ODP) พร้อมโน้ตเป็นรูปแบบ TIFF. รูปแบบนี้ใช้กันอย่างแพร่หลายสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บเอกสาร. ด้วย Aspose.Slides คุณสามารถส่งออกงานนำเสนอทั้งหมดพร้อมโน้ตของผู้พูดได้รวมถึงสร้างภาพย่อสไลด์ในมุมมอง Notes Slide. กระบวนการแปลงง่ายและมีประสิทธิภาพ โดยใช้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ TIFF ขณะรักษาโน้ตและการจัดวางไว้

## **แปลงงานนำเสนอเป็น TIFF พร้อมโน้ต**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมโน้ตด้วย Aspose.Slides for Java มีขั้นตอนดังต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/): โหลดไฟล์ PowerPoint หรือ OpenDocument
1. กำหนดค่าตัวเลือกการจัดวางผลลัพธ์: ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) เพื่อระบุวิธีการแสดงโน้ตและคอมเมนต์
1. บันทึกงานนำเสนอเป็น TIFF: ส่งตัวเลือกที่กำหนดให้เมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์งานนำเสนอพร้อมโน้ตพูด](slide_with_notes.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide โดยใช้เมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงโน้ตด้านล่างสไลด์.

    // กำหนดค่าตัวเลือก TIFF พร้อมการจัดวางโน้ต.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF พร้อมโน้ตของผู้พูด.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ภาพ TIFF พร้อมโน้ตพูด](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
ตรวจสอบ Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) .
{{% /alert %}}

## **FAQ**

### ฉันสามารถควบคุมตำแหน่งของพื้นที่โน้ตใน TIFF ที่ได้หรือไม่?

ใช่. ใช้ [notes layout settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อเลือกตัวเลือกเช่น `None`, `BottomTruncated`, หรือ `BottomFull` ซึ่งลำดับตามการซ่อนโน้ต, จัดให้พอดีในหน้าเดียว, หรือให้โน้ตไหลต่อไปยังหน้าเพิ่มเติม

### ฉันจะลดขนาดไฟล์ TIFF ที่มีโน้ตโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?

เลือก [efficient compression](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ที่เหมาะสม, และหากยอมรับได้ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ที่ต่ำกว่ (เช่น 8 bpp หรือ 1 bpp สำหรับโมโนโครม). การลด [image dimensions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) เล็กน้อยก็ช่วยได้โดยไม่ทำให้การอ่านรู้สึกแย่ลง

### ฟอนท์ในโน้ตมีผลต่อผลลัพธ์หรือไม่หากฟอนท์เดิมไม่มีในระบบ?

ใช่. ฟอนท์ที่หายไปจะทำให้เกิด [substitution](/slides/th/java/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกซ์และลักษณะของข้อความ. เพื่อหลีกเลี่ยงนี้, [supply the required fonts](/slides/th/java/custom-font/) หรือกำหนด [fallback font](/slides/th/java/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.