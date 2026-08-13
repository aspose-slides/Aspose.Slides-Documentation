---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตบน Android
linktitle: PowerPoint เป็น TIFF พร้อมโน้ต
type: docs
weight: 100
url: /th/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java เรียนรู้วิธีส่งออกสไลด์พร้อมโน้ตของผู้บรรยายอย่างมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides for Android via Java ให้โซลูชันที่ง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมโน้ตให้เป็นรูปแบบ TIFF รูปแบบนี้ได้รับการใช้กันอย่างกว้างขวางสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บเอกสารอย่างถาวร ด้วย Aspose.Slides คุณไม่เพียงสามารถส่งออกงานนำเสนอทั้งหมดพร้อมโน้ตของผู้บรรยายเท่านั้น แต่ยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide ได้อีกด้วย ขั้นตอนการแปลงนั้นง่ายและมีประสิทธิภาพ โดยใช้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ TIFF พร้อมคงรักษาโน้ตและการจัดวางไว้

## **แปลงงานนำเสนอเป็น TIFF พร้อมโน้ต**

การบันทึกรูปแบบ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมโน้ตโดยใช้ Aspose.Slides for Android via Java ประกอบด้วยขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) : โหลดไฟล์ PowerPoint หรือ OpenDocument
1. กำหนดค่าตัวเลือกการจัดวางผลลัพธ์: ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) เพื่อระบุวิธีการแสดงโน้ตและความคิดเห็น
1. บันทึกงานนำเสนอเป็น TIFF: ส่งตัวเลือกที่กำหนดค่าไว้ให้กับเมธอด [save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ดังต่อไปนี้:

![สไลด์การนำเสนอพร้อมโน้ตของผู้บรรยาย](slide_with_notes.png)

โค้ดตัวอย่างด้านล่างนี้แสดงวิธีการแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide โดยใช้เมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงโน้ตด้านล่างสไลด์

    // กำหนดค่าตัวเลือก TIFF ด้วยการจัดวางโน้ต
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF พร้อมโน้ตของผู้บรรยาย
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ภาพ TIFF พร้อมโน้ตของผู้บรรยาย](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
ตรวจสอบ Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฉันสามารถควบคุมตำแหน่งของพื้นที่โน้ตใน TIFF ที่ได้หรือไม่?

ใช่. ใช้ [notes layout settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อเลือกตัวเลือกเช่น `None`, `BottomTruncated`, หรือ `BottomFull` ซึ่งตามลำดับจะซ่อนโน้ต, จัดให้พอดีในหน้าเดียว, หรือให้โน้ตไหลต่อไปในหลายหน้า.

### ฉันจะลดขนาดของไฟล์ TIFF ที่มีโน้ตโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?

เลือก [การบีบอัดที่มีประสิทธิภาพ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ที่เหมาะสม, และถ้ารับได้ ให้ใช้ [รูปแบบพิกเซล](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ที่ต่ำลง (เช่น 8 bpp หรือ 1 bpp สำหรับโมโนโครม). การลดขนาด [มิติของภาพ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) เล็กน้อยก็ช่วยได้โดยไม่ทำให้การอ่านสาระสำคัญลดลงอย่างชัดเจน.

### ฟอนต์ในโน้ตมีผลต่อผลลัพธ์หรือไม่หากฟอนต์ดั้งเดิมไม่มีในระบบ?

ใช่. ฟอนต์ที่หายไปจะทำให้เกิด [การเปลี่ยนแทน](/slides/th/androidjava/font-selection-sequence/), ซึ่งอาจเปลี่ยนเมตริกของข้อความและลักษณะการแสดงผล. เพื่อหลีกเลี่ยงสิ่งนี้, [จัดให้มีฟอนต์ที่จำเป็น](/slides/th/androidjava/custom-font/) หรือกำหนด [ฟอนต์สำรอง](/slides/th/androidjava/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.