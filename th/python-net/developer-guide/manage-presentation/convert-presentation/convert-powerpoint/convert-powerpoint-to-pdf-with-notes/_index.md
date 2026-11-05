---
title: แปลงการนำเสนอเป็น PDF พร้อมบันทึกย่อใน Python
linktitle: การนำเสนอเป็น PDF พร้อมบันทึกย่อ
type: docs
weight: 50
url: /th/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลง PPT
- แปลง PPTX
- แปลง ODP
- PowerPoint เป็น PDF
- OpenDocument เป็น PDF
- การนำเสนอเป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- ODP เป็น PDF
- บันทึกย่อของผู้พูด
- PDF พร้อมบันทึกย่อ
- Python
- Aspose.Slides
description: "แปลงรูปแบบ PPT, PPTX และ ODP เป็น PDF พร้อมบันทึกย่อโดยใช้ Aspose.Slides สำหรับ Python. คงรูปแบบและบันทึกย่อของผู้พูดสำหรับการนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงการนำเสนอ PowerPoint ไปเป็นรูปแบบ PDF พร้อมบันทึกย่อโดยใช้ Aspose.Slides คู่มือนี้จะอธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความคุณจะสามารถ:

- ดำเนินการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint ให้เป็นเอกสาร PDF พร้อมคงบันทึกย่อไว้
- ปรับแต่ง PDF ที่ส่งออกเพื่อให้แน่ใจว่าบันทึกย่อรวมอยู่และจัดรูปแบบตามความต้องการของคุณ

เพื่อกำหนดขนาดและทิศทางของหน้าบันทึกย่อก่อนการส่งออก ดูที่ [ขนาดหน้าบันทึกย่อ](/slides/th/python-net/notes-size/).

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกย่อ**

เมธอด `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สามารถใช้เพื่อแปลงการนำเสนอ PPT หรือ PPTX ไปเป็น PDF พร้อมบันทึกย่อได้ ด้วย Aspose.Slides คุณเพียงโหลดการนำเสนอ ตั้งค่าตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมบันทึกย่อ แล้วบันทึกไฟล์เป็น PDF โค้ดตัวอย่างต่อไปนี้จะแสดงวิธีแปลงการนำเสนอแบบตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึกย่อ

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # กำหนดตัวเลือก PDF สำหรับการเรนเดอร์บันทึกย่อของผู้พูด.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # บันทึกการนำเสนอเป็น PDF พร้อมบันทึกย่อของผู้พูด.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
คุณอาจต้องการลองใช้ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion).
{{% /alert %}}