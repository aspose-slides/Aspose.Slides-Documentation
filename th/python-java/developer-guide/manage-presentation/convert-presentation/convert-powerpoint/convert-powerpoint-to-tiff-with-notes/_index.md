---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกใน Python
linktitle: PowerPoint เป็น TIFF พร้อมบันทึก
type: docs
weight: 100
url: /th/python-java/convert-powerpoint-to-tiff-with-notes/
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
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น TIFF พร้อมบันทึกโดยใช้ Aspose.Slides for Python via Java. เรียนรู้วิธีส่งออกสไลด์พร้อมบันทึกของผู้พูดอย่างมีประสิทธิภาพ."
---
## **บทนำ**

Aspose.Slides for Python via Java ให้โซลูชันง่ายสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) พร้อมบันทึกเป็นรูปแบบ TIFF รูปแบบนี้ใช้กันอย่างกว้างขวางสำหรับการจัดเก็บภาพคุณภาพสูง, การพิมพ์, และการเก็บเอกสาร. ใช้วิธีการ [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพื่อส่งออกสไลด์และบันทึกของผู้พูดเป็นไฟล์ TIFF หน้าหลายหน้าไฟล์เดียว.

## **แปลงงานนำเสนอเป็น TIFF พร้อมบันทึก**

การบันทึกงานนำเสนอ PowerPoint หรือ OpenDocument เป็น TIFF พร้อมบันทึกโดยใช้ Aspose.Slides for Python via Java มีขั้นตอนดังต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/): โหลดไฟล์ PowerPoint หรือ OpenDocument.
1. กำหนดค่าตัวเลือกการจัดวางผลลัพธ์: ใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) เพื่อระบุว่าจะให้บันทึกและความคิดเห็นแสดงอย่างไร.
1. บันทึกงานนำเสนอเป็น TIFF: ส่งตัวเลือกที่กำหนดให้กับวิธีการ [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save).

สมมติว่าเรามีไฟล์ "speaker_notes.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์งานนำเสนอพร้อมบันทึกของผู้พูด](slide_with_notes.png)

โค้ดตัวอย่างด้านล่างนี้แสดงวิธีการแปลงงานนำเสนอเป็นภาพ TIFF ในมุมมองสไลด์บันทึกโดยใช้วิธีการ [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # แสดงบันทึกของผู้พูดทั้งหมดด้านล่างแต่ละสไลด์.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # กำหนดค่าความละเอียดของ TIFF และการจัดวางบันทึก.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # บันทึกงานนำเสนอเป็น TIFF พร้อมบันทึกของผู้พูด.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ภาพ TIFF พร้อมบันทึกของผู้พูด](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
ลองดู Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมตำแหน่งของพื้นที่บันทึกใน TIFF ที่ได้หรือไม่?**

ใช่. ตั้งค่า [setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) พร้อมกับ [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomTruncated) เพื่อให้บันทึกพอดีในหน้าเดียว, อาจทำให้ถูกตัด, หรือใช้ [NotesPositions.BottomFull](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomFull) เพื่อแสดงบันทึกทั้งหมดโดยใช้หน้าพิเศษเมื่อต้องการ. เพื่อส่งออกสไลด์โดยไม่มีบันทึก, ให้ละเว้นการกำหนดค่าการจัดวางบันทึกตามที่แสดงใน [Convert PowerPoint to TIFF](/slides/th/python-java/convert-powerpoint-to-tiff/).

**ฉันจะลดขนาดไฟล์ TIFF ที่มีบันทึกโดยไม่สูญเสียคุณภาพภาพได้อย่างไร?**

ใช้การบีบอัดแบบไม่สูญเสียข้อมูล [LZW compression](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffcompressiontypes/#LZW) ผ่าน [setCompressionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setCompressionType). การลดความละเอียดหรือความลึกของสีสามารถลดขนาดไฟล์เพิ่มเติมได้, แต่อาจส่งผลต่อคุณภาพภาพและความอ่านได้ของบันทึก. ดู [TIFF export settings](/slides/th/python-java/convert-powerpoint-to-tiff/) สำหรับตัวเลือกเพิ่มเติม.

**แบบอักษรในบันทึกมีผลต่อผลลัพธ์หรือไม่หากแบบอักษรต้นฉบับไม่มีในระบบ?**

ใช่. แบบอักษรที่หายไปจะทำให้เกิดการ [font substitution](/slides/th/python-java/font-selection-sequence/), ซึ่งอาจเปลี่ยนเมตริกของข้อความและลักษณะการแสดง. [Supply the required fonts](/slides/th/python-java/custom-font/) เพื่อรักษาแบบอักษรที่ต้องการ.