---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกข้อความใน .NET
linktitle: PowerPoint เป็น TIFF พร้อมบันทึกข้อความ
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
- PowerPoint พร้อมบันทึกข้อความ
- งานนำเสนอพร้อมบันทึกข้อความ
- สไลด์พร้อมบันทึกข้อความ
- PPT พร้อมบันทึกข้อความ
- PPTX พร้อมบันทึกข้อความ
- TIFF พร้อมบันทึกข้อความ
- .NET
- C#
- Aspose.Slides
description: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกข้อความโดยใช้ Aspose.Slides สำหรับ .NET เรียนรู้วิธีส่งออกสไลด์พร้อมบันทึกเสียงพูดอย่างมีประสิทธิภาพ
---
## **บทนำ**

Aspose.Slides for .NET ให้วิธีแก้ง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมบันทึกข้อความเป็นรูปแบบ TIFF รูปแบบนี้ได้รับการใช้งานอย่างกว้างขวางสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บเอกสารอย่างถาวร ด้วย Aspose.Slides คุณไม่เพียงแต่สามารถส่งออกงานนำเสนอทั้งหมดพร้อมบันทึกเสียงพูดเท่านั้น แต่ยังสามารถสร้างภาพย่อสไลด์ในมุมมอง Notes Slide ได้อีกด้วย กระบวนการแปลงง่ายและมีประสิทธิภาพโดยใช้เมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดภาพ TIFF พร้อมคงบันทึกข้อความและการจัดวางไว้

## **แปลงงานนำเสนอเป็น TIFF พร้อมบันทึกข้อความ**

การบันทึกไฟล์ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกข้อความโดยใช้ Aspose.Slides for .NET มีขั้นตอนดังนี้:

1. ทำการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) : โหลดไฟล์ PowerPoint หรือ OpenDocument
2. กำหนดค่าเลือกการจัดรูปแบบผลลัพธ์ : ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อระบุว่าบันทึกข้อความและความคิดเห็นจะแสดงอย่างไร
3. บันทึกงานนำเสนอเป็น TIFF : ส่งตัวเลือกที่กำหนดไว้ให้กับเมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/save/index)

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ดังต่อไปนี้:

![สไลด์งานนำเสนอพร้อมบันทึกข้อความของผู้พูด](slide_with_notes.png)

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // กำหนดค่าตัวเลือก TIFF พร้อมการจัดวางบันทึกข้อความ.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // แสดงบันทึกข้อความด้านล่างสไลด์.
        }
    };

    // บันทึกงานนำเสนอเป็น TIFF พร้อมบันทึกข้อความของผู้พูด.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

ผลลัพธ์:

![ภาพ TIFF พร้อมบันทึกข้อความของผู้พูด](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
ลองดู Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ได้เลย
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมตำแหน่งของพื้นที่บันทึกข้อความใน TIFF ที่ได้หรือไม่?**

ใช่ ใช้ [notes layout settings](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) เพื่อเลือกตัวเลือกเช่น `None`, `BottomTruncated` หรือ `BottomFull` ซึ่งตามลำดับจะซ่อนบันทึกข้อความ, จัดให้พอดีในหน้าเดียว, หรือให้บันทึกข้อความไหลต่อไปยังหน้าเพิ่มเติม

**ฉันจะลดขนาดไฟล์ TIFF ที่มีบันทึกข้อความโดยไม่เสียคุณภาพที่มองเห็นได้อย่างไร?**

เลือกใช้ [efficient compression](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/compressiontype/) (เช่น `LZW` หรือ `RLE`), ตั้งค่า DPI ที่เหมาะสมและหากยอมรับได้ ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/pixelformat/) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับขาวดำ) การลด [image dimensions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/imagesize/) เพียงเล็กน้อยก็ช่วยได้โดยไม่ทำให้ความอ่านง่ายเสียอย่างชัดเจน

**ฟอนต์ในบันทึกข้อความส่งผลต่อผลลัพธ์หรือไม่ หากฟอนต์เดิมไม่มีในระบบ?**

ใช่ ฟอนต์ที่ขาดหายจะทำให้เกิด [substitution](/slides/th/net/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมตริกซ์ข้อความและรูปแบบการแสดงผล เพื่อลดผลกระทบนี้ ให้ [supply the required fonts](/slides/th/net/custom-font/) หรือตั้งค่า [fallback font](/slides/th/net/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการ.