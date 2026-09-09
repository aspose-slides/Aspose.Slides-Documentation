---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกการพูดใน Python
linktitle: PowerPoint เป็น PDF พร้อมบันทึกการพูด
type: docs
weight: 50
url: /th/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกงานนำเสนอเป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- บันทึกการพูด
- PDF พร้อมบันทึกการพูด
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX เป็น PDF พร้อมบันทึกการพูดโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java. กำหนดตำแหน่งบันทึกและรักษาบันทึกที่ยาวไว้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกการพูดโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถใส่บันทึกไว้ใต้แต่ละสไลด์และอนุญาตให้บันทึกที่ยาวต่อเนื่องไปยังหน้าต่อไปได้ สำหรับการตั้งค่าอื่น ๆ ของการส่งออก PDF ดูที่ [Convert PowerPoint to PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกการพูด**

ใช้เมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพื่อส่งออกงานนำเสนอ PPT หรือ PPTX เป็น PDF เพื่อรวมบันทึกการพูด ให้สร้างอ็อบเจกต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) และกำหนดตำแหน่งบันทึกด้วยเมธอด [setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) กำหนดเลย์เอาต์นี้ให้กับ [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) โดยใช้ [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

ตัวอย่างต่อไปนี้โหลด `sample.pptx` และส่งออกเป็น `output.pdf` พร้อมบันทึกการพูดใต้สไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # กำหนดตัวเลือก PDF สำหรับการแสดงบันทึกการพูด.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกการพูด.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
คุณยังสามารถลองใช้ [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion) ได้เช่นกัน.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้บันทึกการพูดที่ยาวถูกตัดออกได้อย่างไร?**

ใช้ [NotesPositions.BottomFull](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomFull) เช่นในตัวอย่างด้านบน การตั้งค่านี้จะแสดงบันทึกทั้งหมดโดยใช้หน้าพิเศษเมื่อจำเป็น

**ฉันสามารถเก็บสไลด์แต่ละสไลด์และบันทึกของมันไว้บนหน้าเดียวได้หรือไม่?**

ใช้ [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomTruncated) การตั้งค่านี้จำกัดบันทึกให้อยู่บนหน้าเดียว ดังนั้นบันทึกที่ไม่พออาจถูกตัดทอน

**ฉันจะส่งออกสไลด์โดยไม่มีบันทึกการพูดได้อย่างไร?**

ละเว้นการกำหนดค่าเลย์เอาต์บันทึกและใช้การส่งออก PDF มาตรฐานตามที่อธิบายใน [Convert PowerPoint to PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).