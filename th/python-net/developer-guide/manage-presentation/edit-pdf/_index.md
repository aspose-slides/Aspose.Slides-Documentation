---
title: แก้ไขเอกสาร PDF ใน Python
linktitle: แก้ไข PDF
type: docs
weight: 65
url: /th/python-net/edit-pdf/
keywords:
- แก้ไข PDF
- แทนที่ข้อความ PDF
- PDF เป็น PPTX
- PPTX เป็น PDF
- Python
- Aspose.Slides
description: "แก้ไขเอกสาร PDF ด้วย Python โดยนำเข้าไปใน Aspose.Slides, แทนที่ข้อความ, และบันทึกการนำเสนอที่แก้ไขแล้วกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้คุณแก้ไขเนื้อหา PDF โดยการนำเข้าหน้าของมันเป็นสไลด์ ปรับการนำเสนอ และส่งออกกลับเป็น PDF บทความนี้แสดงตัวอย่างการแทนที่ข้อความอย่างง่าย การนำเสนอจะอยู่ในหน่วยความจำ ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวเป็นสิ่งเลือกได้

## **แทนที่ข้อความใน PDF**

Use [add_from_pdf](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_from_pdf/) to import the pages, [replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_text/) to update the text, and [save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) to export the result.

ตัวอย่างต่อไปนี้คาดว่า `input.pdf` มีคำว่า "Draft" เป็นข้อความที่แก้ไขได้หลังการนำเข้า โดยจะเปลี่ยนคำนั้นเป็น "Final" และเขียนผลลัพธ์ลงใน `edited.pdf` การลบสไลด์แรกก่อนทำการนำเข้าจะช่วยป้องกันไม่ให้มีหน้าว่างเพิ่มเติมในผลลัพธ์ การค้นหาจะตรงกับคำเต็มโดยคำนึงถึงตัวอักษรตัวพิมพ์ใหญ่/เล็ก; `None` หมายความว่าไม่ต้องการ callback ผลลัพธ์

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

สำหรับตัวเลือกเพิ่มเติม ดู [ค้นหาและแทนที่ข้อความ](/slides/th/python-net/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/python-net/convert-powerpoint-to-pdf/)

{{% alert color="info" title="Note" %}}
การแทนที่ข้อความทำงานกับข้อความที่นำเข้ามา ไม่ใช่ข้อความที่อยู่ในภาพที่สแกน การแปลงอาจส่งผลต่อเลเอาต์และรูปแบบ ดังนั้นควรตรวจสอบผลลัพธ์โดยเฉพาะเมื่อข้อความแทนที่ยาวกว่าข้อความต้นฉบับ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องบันทึกไฟล์ PPTX ก่อนส่งออกเป็น PDF หรือไม่?**

ไม่. คุณสามารถแก้ไขและส่งออกการนำเสนอเดียวกันได้ในหน่วยความจำ การบันทึกสำเนา PPTX ทำได้เฉพาะเมื่อคุณต้องการแก้ไขต่อใน PowerPoint; ดู [บันทึกการนำเสนอ](/slides/th/python-net/save-presentation/).

**ทำไมข้อความบางส่วนอาจไม่ถูกเปลี่ยนแปลง?**

ตัวอย่างนี้ตรงกับคำเต็ม "Draft" โดยคำนึงถึงตัวอักษรตัวพิมพ์ใหญ่/เล็ก ข้อความที่นำเข้ามาเป็นรูปภาพหรือที่แยกเป็นกรอบข้อความหลายกรอบอาจไม่ตรงกับการค้นหา ตรวจสอบข้อมูลที่นำเข้าและปรับการค้นหาให้เหมาะกับเอกสารของคุณ.