---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกบน Android
linktitle: PowerPoint เป็น TIFF พร้อมบันทึก
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
- PowerPoint พร้อมบันทึก
- งานนำเสนอพร้อมบันทึก
- สไลด์พร้อมบันทึก
- PPT พร้อมบันทึก
- PPTX พร้อมบันทึก
- TIFF พร้อมบันทึก
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. เรียนรู้วิธีส่งออกสไลด์พร้อมบันทึกของผู้พูดอย่างมีประสิทธิภาพ."
---
## **บทนำ**

Aspose.Slides for Android via Java ให้โซลูชันที่ง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) ที่มีบันทึกเป็นรูปแบบ TIFF. รูปแบบนี้ถูกใช้อย่างกว้างขวางสำหรับการจัดเก็บภาพคุณภาพสูง, การพิมพ์, และการเก็บเอกสาร. ด้วย Aspose.Slides, คุณสามารถส่งออกงานนำเสนอทั้งหมดพร้อมบันทึกของผู้พูดได้อย่างไม่เพียงเท่านั้น แต่ยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide อีกด้วย. กระบวนการแปลงนั้นง่ายและมีประสิทธิภาพ, ใช้วิธี `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ TIFF พร้อมคงบันทึกและรูปแบบไว้

## **แปลงงานนำเสนอเป็น TIFF พร้อมบันทึก**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกโดยใช้ Aspose.Slides for Android via Java ประกอบด้วยขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/): โหลดไฟล์ PowerPoint หรือ OpenDocument.
2. กำหนดตัวเลือกการจัดวางผลลัพธ์: ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) เพื่อระบุว่าบันทึกและความคิดเห็นควรแสดงอย่างไร.
3. บันทึกงานนำเสนอเป็น TIFF: ส่งผ่านตัวเลือกที่กำหนดไว้ไปยังเมธอด [save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์งานนำเสนอที่มีบันทึกผู้พูด](slide_with_notes.png)

โค้ดสแนปด้านล่างแสดงวิธีการแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide โดยใช้เมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // แสดงบันทึกด้านล่างสไลด์.

    // กำหนดตัวเลือก TIFF พร้อมการจัดวางบันทึก.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF พร้อมบันทึกของผู้พูด.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ภาพ TIFF ที่มีบันทึกผู้พูด](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
ตรวจสอบ Aspose [ตัวแปลง PowerPoint เป็นโปสเตอร์ ฟรี](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมตำแหน่งของส่วนบันทึกใน TIFF ที่ได้หรือไม่?**

ใช่. ใช้ [notes layout settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อเลือกระหว่างตัวเลือกเช่น `None`, `BottomTruncated`, หรือ `BottomFull` ซึ่งตามลำดับจะซ่อนบันทึก, ปรับให้พอดีหนึ่งหน้า, หรือให้บันทึกไหลต่อไปยังหน้าเพิ่มเติม.

**ฉันจะลดขนาดไฟล์ TIFF ที่มีบันทึกโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?**

เลือก [efficient compression](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ที่เหมาะสม, และถ้าตอบรับได้ ใช้ [pixel format](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับสีโมโนโครม). การลดขนาด [image dimensions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) เล็กน้อยก็ช่วยได้โดยไม่ทำให้การอ่านได้ชัดเจนลดลง.

**แบบอักษรในบันทึกมีผลต่อผลลัพธ์หรือไม่หากแบบอักษรดั้งเดิมไม่มีในระบบ?**

ใช่. แบบอักษรที่ขาดหายจะทำให้เกิด [การแทนที่](/slides/th/androidjava/font-selection-sequence/), ซึ่งอาจเปลี่ยนเมทริกซ์ข้อความและรูปลักษณ์. เพื่อหลีกเลี่ยงสิ่งนี้, ให้ [จัดหาแบบอักษรที่จำเป็น](/slides/th/androidjava/custom-font/) หรือกำหนดค่า [แบบอักษรสำรอง](/slides/th/androidjava/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.