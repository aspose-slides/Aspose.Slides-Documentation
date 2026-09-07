---
title: แปลงการนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกใน Python
linktitle: PowerPoint เป็น PDF พร้อมบันทึก
type: docs
weight: 50
url: /th/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกการนำเสนอเป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- บันทึกของผู้บรรยาย
- PDF พร้อมบันทึก
- Python
- Java
- Aspose.Slides
description: "แปลงการนำเสนอ PPT และ PPTX เป็น PDF พร้อมบันทึกของผู้บรรยายโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java ตั้งค่าตำแหน่งบันทึกและรักษาบันทึกยาวไว้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกของผู้บรรยายโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถใส่บันทึกใต้แต่ละสไลด์และให้บันทึกยาวต่อเนื่องไปยังหน้าถัดไป สำหรับการตั้งค่าอื่น ๆ ของการส่งออกเป็น PDF ดูที่ [Convert PowerPoint to PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกของผู้บรรยาย**

ใช้เมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพื่อส่งออกการนำเสนอ PPT หรือ PPTX เป็น PDF เพื่อรวมบันทึกของผู้บรรยาย ให้สร้างวัตถุ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) และกำหนดค่าเมธอด [setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ของมัน กำหนดเค้าโครงนี้ให้กับ [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) โดยใช้ [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

ตัวอย่างต่อไปนี้โหลด `sample.pptx` และส่งออกเป็น `output.pdf` พร้อมบันทึกของผู้บรรยายใต้สไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # กำหนดตัวเลือก PDF สำหรับการแสดงบันทึกของผู้บรรยาย.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # บันทึกการนำเสนอเป็น PDF พร้อมบันทึกของผู้บรรยาย.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
คุณยังสามารถลองใช้ [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion) ได้.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้บันทึกของผู้บรรยายที่ยาวถูกตัดออกได้อย่างไร?**
ใช้ [NotesPositions.BottomFull](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomFull) เช่นในตัวอย่างข้างต้น การตั้งค่านี้จะแสดงบันทึกทั้งหมด โดยใช้หน้าพิเศษเมื่อจำเป็น

**ฉันสามารถเก็บสไลด์แต่ละสไลด์และบันทึกของมันไว้ในหน้าเดียวได้หรือไม่?**
ใช้ [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomTruncated) การตั้งค่านี้จำกัดบันทึกไว้ในหนึ่งหน้า ดังนั้นบันทึกที่ไม่พอดีอาจถูกตัดทอน

**ฉันจะส่งออกสไลด์โดยไม่มีบันทึกของผู้บรรยายได้อย่างไร?**
ละเว้นการกำหนดค่าเค้าโครงบันทึกและใช้การส่งออก PDF มาตรฐานที่อธิบายไว้ใน [Convert PowerPoint to PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).