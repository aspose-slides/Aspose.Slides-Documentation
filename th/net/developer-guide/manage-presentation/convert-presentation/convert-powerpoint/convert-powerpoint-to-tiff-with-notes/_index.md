---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตใน .NET
linktitle: PowerPoint เป็น TIFF พร้อมโน้ต
type: docs
weight: 100
url: /th/net/convert-powerpoint-to-tiff-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตด้วย Aspose.Slides สำหรับ .NET เรียนรู้วิธีส่งออกสไลด์พร้อมโน้ตของผู้พูดอย่างมีประสิทธิภาพ"
---
## **Introduction**

Aspose.Slides for .NET ให้โซลูชั่นง่าย ๆ สำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมโน้ตเป็นรูปแบบ TIFF รูปแบบนี้ได้รับการใช้งานอย่างกว้างขวางสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บเอกสารอย่างถาวร ด้วย Aspose.Slides คุณไม่เพียงแต่สามารถส่งออกงานนำเสนอทั้งหมดพร้อมโน้ตของผู้พูดได้เท่านั้น แต่ยังสามารถสร้างภาพย่อสไลด์ในมุมมอง Notes Slide ได้อีกด้วย กระบวนการแปลงง่ายและมีประสิทธิภาพ โดยใช้เมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดภาพ TIFF พร้อมคงรักษาโน้ตและการจัดวางไว้

## **Convert a Presentation to TIFF with Notes**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมโน้ตโดยใช้ Aspose.Slides for .NET ทำได้ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) : โหลดไฟล์ PowerPoint หรือ OpenDocument
1. กำหนดตัวเลือกการจัดวางผลลัพธ์ : ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อระบุวิธีการแสดงโน้ตและคอมเมนต์
1. บันทึกงานนำเสนอเป็น TIFF : ส่งตัวเลือกที่กำหนดไว้ให้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/save/index)

สมมติว่าเรามีไฟล์ “speaker_notes.pptx” ที่มีสไลด์ต่อไปนี้:

![สไลด์งานนำเสนอพร้อมโน้ตของผู้พูด](slide_with_notes.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // กำหนดตัวเลือก TIFF พร้อมการจัดเรียงโน้ต
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // แสดงโน้ตใต้สไลด์
        }
    };

    // บันทึกงานนำเสนอเป็น TIFF พร้อมโน้ตของผู้พูด
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

ผลลัพธ์:

![ภาพ TIFF พร้อมโน้ตของผู้พูด](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
ตรวจสอบ Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) .
{{% /alert %}}

## **FAQ**

### ฉันสามารถควบคุมตำแหน่งของพื้นที่โน้ตใน TIFF ที่สร้างได้หรือไม่?

ใช่. ใช้ [notes layout settings](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) เพื่อเลือกตัวเลือกเช่น `None`, `BottomTruncated`, หรือ `BottomFull` ซึ่งจะแสดงโน้ตเป็นการซ่อน, จัดให้พอดีในหน้าหนึ่ง, หรือให้โน้ตไหลต่อในหน้าถัดไปตามลำดับ

### ฉันจะลดขนาดไฟล์ TIFF ที่มีโน้ตโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?

เลือก [efficient compression](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/compressiontype/) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ให้เหมาะสม, และหากยอมรับได้ ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/pixelformat/) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับโมโนโครม) การลด [image dimensions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/imagesize/) อย่างเล็กน้อยก็ช่วยได้โดยไม่ทำให้ความอ่านง่ายเสียหายอย่างชัดเจน

### ฟอนต์ในโน้ตมีผลต่อผลลัพธ์หรือไม่หากฟอนต์ต้นฉบับไม่มีในระบบ?

ใช่. ฟอนต์ที่หายไปจะทำให้เกิด [substitution](/slides/th/net/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกซ์และรูปลักษณ์ของข้อความ เพื่อหลีกเลี่ยงนี้ให้ [supply the required fonts](/slides/th/net/custom-font/) หรือกำหนด [fallback font](/slides/th/net/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการได้.