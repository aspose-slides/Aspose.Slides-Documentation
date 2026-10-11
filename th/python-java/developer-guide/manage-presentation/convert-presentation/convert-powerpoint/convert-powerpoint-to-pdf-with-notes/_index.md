---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตใน Python
linktitle: PowerPoint ไปเป็น PDF พร้อมโน้ต
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
- โน้ตผู้พูด
- PDF พร้อมโน้ต
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX ไปเป็น PDF พร้อมโน้ตผู้พูดโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java. กำหนดตำแหน่งโน้ตและรักษาโน้ตยาวไว้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตผู้พูดโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถรวมโน้ตใต้แต่ละสไลด์และให้โน้ตที่ยาวต่อเนื่องไปยังหน้าเพิ่มเติม สำหรับการตั้งค่าอื่น ๆ ของการส่งออก PDF ดูที่ [แปลง PowerPoint เป็น PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).

หากต้องการตั้งค่าขนาดและแนวตั้งของหน้โน้ตก่อนการส่งออก ดูที่ [ขนาดหน้าบันทึก](/slides/th/python-java/notes-size/).

## **แปลง PowerPoint เป็น PDF พร้อมโน้ต**

ใช้เมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพื่อส่งออกงานนำเสนอ PPT หรือ PPTX เป็น PDF เพื่อรวมโน้ตผู้พูด ให้สร้างอ็อบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) และกำหนดตำแหน่งโน้ตด้วยเมธอด [setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) จากนั้นกำหนดเค้าโครงนี้ให้กับ [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) ด้วยการใช้ [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

ตัวอย่างต่อไปนี้โหลดไฟล์ `sample.pptx` และส่งออกเป็น `output.pdf` พร้อมโน้ตผู้พูดที่อยู่ใต้สไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # กำหนดตัวเลือก PDF สำหรับการแสดงโน้ตผู้พูด.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # บันทึกการนำเสนอเป็น PDF พร้อมโน้ตผู้พูด.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
คุณยังสามารถลองใช้ [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion) ได้เช่นกัน.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีป้องกันไม่ให้โน้ตผู้พูดที่ยาวถูกตัดออก?**

ใช้ [NotesPositions.BottomFull](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomFull) เช่นในตัวอย่างข้างต้น การตั้งค่านี้จะแสดงโน้ตทั้งหมด โดยใช้หน้าพิเศษเพิ่มเติมเมื่อจำเป็น

**ฉันสามารถเก็บแต่ละสไลด์และโน้ตของมันบนหน้าเดียวได้หรือไม่?**

ใช้ [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomTruncated) การตั้งค่านี้จำกัดโน้ตให้แสดงบนหนึ่งหน้า ดังนั้นโน้ตที่ไม่พอดีอาจถูกตัดทอนได้

**ฉันจะส่งออกสไลด์โดยไม่มีโน้ตผู้พูดได้อย่างไร?**

ละเว้นการกำหนดค่าเลเอาท์โน้ตและใช้การส่งออก PDF มาตรฐานที่อธิบายไว้ใน [แปลง PowerPoint เป็น PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).