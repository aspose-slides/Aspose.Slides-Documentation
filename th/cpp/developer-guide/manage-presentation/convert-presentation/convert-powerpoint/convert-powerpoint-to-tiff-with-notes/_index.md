---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกย่อใน C++
linktitle: PowerPoint เป็น TIFF พร้อมบันทึกย่อ
type: docs
weight: 100
url: /th/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกย่อโดยใช้ Aspose.Slides สำหรับ C++. เรียนรู้วิธีส่งออกรายการสไลด์พร้อมบันทึกย่อนักพูดอย่างมีประสิทธิภาพ."
---
## **บทนำ**

Aspose.Slides for C++ ให้วิธีแก้ไขง่าย ๆ สำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมบันทึกย่อเป็นรูปแบบ TIFF. รูปแบบนี้ได้รับการใช้งานอย่างกว้างขวางสำหรับการเก็บภาพคุณภาพสูง, การพิมพ์, และการจัดเก็บเอกสาร. ด้วย Aspose.Slides คุณสามารถไม่เพียงส่งออกงานนำเสนอทั้งหมดพร้อมบันทึกย่อของผู้พูดเท่านั้น แต่ยังสามารถสร้างภาพย่อสไลด์ในมุมมอง Notes Slide ได้อีกด้วย. กระบวนการแปลงเป็นเรื่องง่ายและมีประสิทธิภาพ, ใช้วิธี `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ TIFF ขณะคงบันทึกย่อและการจัดวางไว้.

## **แปลงงานนำเสนอเป็น TIFF พร้อมบันทึกย่อ**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกย่อโดยใช้ Aspose.Slides for C++ ประกอบด้วยขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/): โหลดไฟล์ PowerPoint หรือ OpenDocument.
1. กำหนดตัวเลือกการจัดวางผลลัพธ์: ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) เพื่อระบุว่าบันทึกย่อและความคิดเห็นจะแสดงอย่างไร.
1. บันทึกงานนำเสนอเป็น TIFF: ส่งตัวเลือกที่กำหนดไว้ไปยังเมธอด [Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/).

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอพร้อมบันทึกย่อของผู้พูด](slide_with_notes.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีการแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide โดยใช้เมธอด [set_SlidesLayoutOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // แสดงบันทึกย่อด้านล่างสไลด์

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

ผลลัพธ์:

![ภาพ TIFF พร้อมบันทึกย่อของผู้พูด](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
ลองดู Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฉันสามารถควบคุมตำแหน่งของพื้นที่บันทึกย่อใน TIFF ที่ได้หรือไม่?

ใช่. ใช้ [notes layout settings](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) เพื่อเลือกตัวเลือกเช่น `None`, `BottomTruncated`, หรือ `BottomFull` ซึ่งตามลำดับจะซ่อนบันทึกย่อ, จัดให้พอดีในหน้าเดียว, หรืออนุญาตให้บันทึกย่อไหลต่อเนื่องไปยังหน้าเพิ่มเติม.

### ฉันจะลดขนาดไฟล์ TIFF ที่มีบันทึกย่อโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?

เลือกการบีบอัดที่ [efficient compression](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ที่สมเหตุสมผล, และหากยอมรับได้ ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) ที่ต่ำลง (เช่น 8 bpp หรือ 1 bpp สำหรับโหมดขาวดำ). การลดขนาด [image dimensions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_imagesize/) เล็กน้อยก็สามารถช่วยได้โดยไม่ทำให้ความอ่านง่ายลดลงอย่างชัดเจน.

### ฟอนต์ในบันทึกย่อมีผลต่อผลลัพธ์หรือไม่หากฟอนต์เดิมไม่มีในระบบ?

ใช่. ฟอนต์ที่หายไปจะทำให้เกิด [substitution](/slides/th/cpp/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกของข้อความและรูปลักษณ์. เพื่อหลีกเลี่ยงสิ่งนี้, ให้ [supply the required fonts](/slides/th/cpp/custom-font/) หรือกำหนด [fallback font](/slides/th/cpp/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.