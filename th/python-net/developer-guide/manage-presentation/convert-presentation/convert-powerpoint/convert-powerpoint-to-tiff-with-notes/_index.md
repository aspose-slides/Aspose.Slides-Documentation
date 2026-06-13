---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตใน Python
linktitle: PowerPoint เป็น TIFF พร้อมโน้ต
type: docs
weight: 100
url: /th/python-net/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint พร้อมโน้ต
- งานนำเสนอพร้อมโน้ต
- สไลด์พร้อมโน้ต
- PPT พร้อมโน้ต
- PPTX พร้อมโน้ต
- TIFF พร้อมโน้ต
- Python
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตโดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เรียนรู้วิธีส่งออกสไลด์พร้อมโน้ตของผู้บรรยายอย่างมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides for Python via .NET ให้วิธีแก้ไขอย่างง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมโน้ตเป็นรูปแบบ TIFF รูปแบบนี้ถูกใช้กันอย่างแพร่หลายสำหรับการจัดเก็บภาพคุณภาพสูง การพิมพ์ และการเก็บเอกสารอย่างถาวร ด้วย Aspose.Slides คุณสามารถส่งออกงานนำเสนอทั้งหมดพร้อมโน้ตของผู้บรรยายได้เท่านั้น แต่ยังสามารถสร้างรูปย่อของสไลด์ในมุมมอง Notes Slide ได้อีกด้วย กระบวนการแปลงเป็นเรื่องง่ายและมีประสิทธิภาพ โดยใช้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดภาพ TIFF พร้อมคงไว้ซึ่งโน้ตและเลย์เอาต์

## **แปลงงานนำเสนอเป็น TIFF พร้อมโน้ต**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมโน้ตโดยใช้ Aspose.Slides for Python via .NET มีขั้นตอนดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อโหลดไฟล์ PowerPoint หรือ OpenDocument
1. กำหนดค่าตัวเลือกการจัดวางผลลัพธ์: ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อระบุวิธีการแสดงโน้ตและคอมเมนต์
1. บันทึกงานนำเสนอเป็น TIFF: ส่งตัวเลือกที่กำหนดให้เมธอด [save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) 

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ดังต่อไปนี้:

![The presentation slide with speaker notes](slide_with_notes.png)

โค้ดสแนปด้านล่างแสดงวิธีแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมอง Notes Slide โดยใช้คุณสมบัติ [slides_layout_options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/slides_layout_options/)

```py
# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # แสดงโน้ตด้านล่างสไลด์.
    
    # กำหนดค่าตัวเลือก TIFF พร้อมการจัดวางโน้ต.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # บันทึกงานนำเสนอเป็น TIFF พร้อมโน้ตของผู้บรรยาย.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

ผลลัพธ์:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

ดู Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online)

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมตำแหน่งของพื้นที่โน้ตใน TIFF ที่ได้หรือไม่?**

ได้ คุณสามารถใช้ [notes layout settings](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) เพื่อเลือกตัวเลือกเช่น `NONE` (ซ่อนโน้ต) `BOTTOM_TRUNCATED` (ใส่โน้ตในหน้าหนึ่ง) หรือ `BOTTOM_FULL` (ให้โน้ตลื่นต่อไปยังหน้าถัดไป)

**ฉันจะลดขนาดไฟล์ TIFF ที่มีโน้ตโดยไม่สูญเสียคุณภาพที่มองเห็นได้อย่างไร?**

เลือกใช้ [efficient compression](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/compression_type/) (เช่น `LZW` หรือ `RLE`) ตั้งค่า DPI ที่เหมาะสม และหากยอมรับได้ ให้ใช้ [pixel format](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/pixel_format/) ที่ต่ำกว่า (เช่น 8 bpp หรือ 1 bpp สำหรับโมโนโครม) การลดขนาด [image dimensions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/image_size/) เล็กน้อยก็ช่วยได้โดยไม่กระทบต่อการอ่านอย่างชัดเจน

**ฟอนต์ในโน้ตมีผลต่อผลลัพธ์หรือไม่ หากฟอนต์ต้นฉบับไม่มีในระบบ?**

มี ฟอนต์ที่หายไปจะกระตุ้นการ [substitution](/slides/th/python-net/font-selection-sequence/) ซึ่งอาจเปลี่ยนเมทริกซ์และลักษณะของข้อความ เพื่อหลีกเลี่ยงนี้ ให้ [supply the required fonts](/slides/th/python-net/custom-font/) หรือกำหนด [fallback font](/slides/th/python-net/fallback-font/) เริ่มต้นเพื่อให้ใช้แบบอักษรที่ต้องการได้