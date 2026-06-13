---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกย่อใน C++
linktitle: PowerPoint ไปเป็น TIFF พร้อมบันทึกย่อ
type: docs
weight: 100
url: /th/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- การนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
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
- C++
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกย่อโดยใช้ Aspose.Slides สำหรับ C++. เรียนรู้วิธีส่งออกสไลด์พร้อมบันทึกย่อของวิทยากรอย่างมีประสิทธิภาพ."
---
## **บทนำ**

Aspose.Slides for C++ ให้วิธีแก้ที่เรียบง่ายสำหรับการแปลงการนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมบันทึกย่อเป็นรูปแบบ TIFF รูปแบบนี้ถูกใช้กันอย่างกว้างขวางสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บเอกสารแบบถาวร ด้วย Aspose.Slides คุณไม่เพียงแต่สามารถส่งออกการนำเสนอทั้งหมดพร้อมบันทึกย่อของวิทยากรเท่านั้น แต่ยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide ได้ กระบวนการแปลงเป็นเรื่องง่ายและมีประสิทธิภาพ โดยใช้เมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อแปลงการนำเสนอทั้งหมดเป็นชุดของภาพ TIFF พร้อมคงบันทึกย่อและเค้าโครงไว้

## **แปลงการนำเสนอเป็น TIFF พร้อมบันทึกย่อ**

การบันทึกการนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกย่อโดยใช้ Aspose.Slides for C++ มีขั้นตอนดังต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/): โหลดไฟล์ PowerPoint หรือ OpenDocument
1. กำหนดค่าตัวเลือกการจัดเรียงเลย์เอาต์ของผลลัพธ์: ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) เพื่อระบุว่าบันทึกย่อและความคิดเห็นจะแสดงอย่างไร
1. บันทึกการนำเสนอเป็น TIFF: ส่งตัวเลือกที่กำหนดค่าไปยังเมธอด [Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/)

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอพร้อมบันทึกย่อของวิทยากร](slide_with_notes.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีการแปลงการนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide ด้วยเมธอด [set_SlidesLayoutOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // แสดงบันทึกย่อด้านล่างสไลด์.

// กำหนดค่าตัวเลือก TIFF พร้อมการจัดเลย์เอาต์บันทึกย่อ.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// บันทึกการนำเสนอเป็น TIFF พร้อมบันทึกย่อของวิทยากร.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

ผลลัพธ์:

![ภาพ TIFF พร้อมบันทึกย่อของวิทยากร](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
ดู Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมตำแหน่งของพื้นที่บันทึกย่อใน TIFF ที่ได้หรือไม่?**

ได้. ใช้ [notes layout settings](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) เพื่อเลือกจากตัวเลือกเช่น `None`, `BottomTruncated`, หรือ `BottomFull` ซึ่งจะซ่อนบันทึกย่อ, จัดให้พอดีในหน้าหนึ่ง, หรือให้บันทึกย่อไหลต่อบนหลายหน้า ตามลำดับ.

**ฉันจะลดขนาดไฟล์ TIFF ที่มีบันทึกย่อโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?**

เลือก [efficient compression](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) ที่มีประสิทธิภาพ (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ให้อยู่ในระดับที่เหมาะสม, และหากยอมรับได้ ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับสีขาวดำ). การลดขนาด [image dimensions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_imagesize/) เล็กน้อยก็สามารถช่วยได้โดยไม่ทำให้ความอ่านง่ายสังเกตได้อย่างชัดเจน.

**ฟอนต์ในบันทึกย่อจะมีผลต่อผลลัพธ์หรือไม่หากฟอนต์ต้นฉบับไม่มีในระบบ?**

ได้. ฟอนต์ที่ขาดจะทำให้เกิดการ [substitution](/slides/th/cpp/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกซ์และลักษณะของข้อความ. เพื่อหลีกเลี่ยงสิ่งนี้, [supply the required fonts](/slides/th/cpp/custom-font/) หรือกำหนด [fallback font](/slides/th/cpp/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.