---
title: แปลงงานนำเสนอเป็น PDF พร้อมโน้ตใน Python
linktitle: งานนำเสนอเป็น PDF พร้อมโน้ต
type: docs
weight: 50
url: /th/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลง PPT
- แปลง PPTX
- แปลง ODP
- PowerPoint เป็น PDF
- OpenDocument เป็น PDF
- งานนำเสนอเป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- ODP เป็น PDF
- โน้ตของวิทยากร
- PDF พร้อมโน้ต
- Python
- Aspose.Slides
description: "แปลงรูปแบบ PPT, PPTX และ ODP เป็น PDF พร้อมโน้ตโดยใช้ Aspose.Slides สำหรับ Python. รักษาการจัดวางและโน้ตของวิทยากรสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมโน้ตของวิทยากรโดยใช้ Aspose.Slides คู่มือฉบับนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้แล้ว คุณจะสามารถ:

- ดำเนินการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint เป็นเอกสาร PDF พร้อมรักษาโน้ตของวิทยากรไว้
- ปรับแต่ง PDF ผลลัพธ์เพื่อให้แน่ใจว่าโน้ตของวิทยากรจะถูกรวมอยู่และจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมบันทึกย่อ**

เมธอด `save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สามารถใช้แปลงงานนำเสนอ PPT หรือ PPTX ให้เป็น PDF พร้อมโน้ตของวิทยากรได้ ด้วย Aspose.Slides คุณเพียงแค่โหลดงานนำเสนอ กำหนดค่าตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมโน้ตของวิทยากร แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอแบบตัวอย่างให้เป็น PDF ในมุมมองสไลด์โน้ต

```py
with slides.Presentation("sample.pptx") as presentation:

    # กำหนดค่าตัวเลือก PDF สำหรับการแสดงผลโน้ตของวิทยากร.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # บันทึกงานนำเสนอเป็น PDF พร้อมโน้ตของวิทยากร.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}