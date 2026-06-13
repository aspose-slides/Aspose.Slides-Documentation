---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกใน PHP
linktitle: PowerPoint ไปเป็น TIFF พร้อมบันทึก
type: docs
weight: 100
url: /th/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปเป็น TIFF
- งานนำเสนอไปเป็น TIFF
- สไลด์ไปเป็น TIFF
- PPT ไปเป็น TIFF
- PPTX ไปเป็น TIFF
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
- PHP
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เรียนรู้วิธีส่งออกสไลด์พร้อมบันทึกของผู้พูดอย่างมีประสิทธิภาพ."
---
## **Introduction**

Aspose.Slides for PHP via Java ให้โซลูชันที่ง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX และ ODP) พร้อมบันทึกเป็นรูปแบบ TIFF รูปแบบนี้ใช้กันอย่างแพร่หลายสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บถาวรเอกสาร ด้วย Aspose.Slides คุณไม่เพียงแต่สามารถส่งออกงานนำเสนอทั้งหมดพร้อมบันทึกของผู้พูดเท่านั้น แต่ยังสามารถสร้างรูปย่อสไลด์ในมุมมอง Notes Slide ได้ กระบวนการแปลงง่ายและมีประสิทธิภาพ โดยใช้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดภาพ TIFF พร้อมคงบันทึกและรูปแบบไว้

## **Convert a Presentation to TIFF with Notes**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกโดยใช้ Aspose.Slides for PHP via Java มีขั้นตอนดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) : โหลดไฟล์ PowerPoint หรือ OpenDocument
2. ตั้งค่าตัวเลือกการจัดเรียงเลย์เอาต์ของผลลัพธ์ : ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) เพื่อกำหนดวิธีการแสดงบันทึกและคอมเมนต์
3. บันทึกงานนำเสนอเป็น TIFF : ส่งตัวเลือกที่กำหนดไว้ให้เมธอด [save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save)

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ดังต่อไปนี้:

![The presentation slide with speaker notes](slide_with_notes.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide โดยใช้เมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions):

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // แสดงบันทึกใต้สไลด์.

    // กำหนดค่าตัวเลือก TIFF ด้วยการจัดรูปแบบบันทึก.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF พร้อมบันทึกของผู้พูด.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
ลองใช้ Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) .
{{% /alert %}}

## **FAQ**

**Can I control the position of the notes area in the resulting TIFF?**

ได้ ใช้ [notes layout settings](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) เพื่อเลือกตัวเลือก เช่น `None` (ซ่อนบันทึก) , `BottomTruncated` (บันทึกพอดีหน้าเดียว) หรือ `BottomFull` (ให้บันทึกไหลต่อไปยังหน้าเพิ่มเติม)

**How can I reduce the size of a TIFF file with notes without visible loss of quality?**

เลือกใช้ [efficient compression](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/setcompressiontype/) ที่เหมาะสม (เช่น `LZW` หรือ `RLE`) ตั้งค่า DPI ที่เหมาะสม และหากยอมรับได้ ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/setpixelformat/) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับภาพขาวดำ) การลด [image dimensions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/setimagesize/) เล็กน้อยก็ช่วยได้โดยไม่ทำให้ความสามารถในการอ่านลดลงอย่างเห็นได้ชัด

**Does the font in the notes affect the result if the original fonts are missing from the system?**

ใช่ ฟอนต์ที่หายไปจะทำให้เกิดการ [substitution](/slides/th/php-java/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกซ์และลักษณะของข้อความ เพื่อหลีกเลี่ยงปัญหานี้ ให้ [supply the required fonts](/slides/th/php-java/custom-font/) หรือกำหนด [fallback font](/slides/th/php-java/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.