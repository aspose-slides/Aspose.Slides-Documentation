---
title: แก้ไขเอกสาร PDF ใน Python ผ่าน Java
linktitle: แก้ไข PDF
type: docs
weight: 65
url: /th/python-java/edit-pdf/
keywords:
- แก้ไข PDF
- แทนที่ข้อความ PDF
- PDF เป็น PPTX
- PPTX เป็น PDF
- Python
- Java
- Aspose.Slides
description: "แก้ไขเอกสาร PDF ใน Python ผ่าน Java โดยนำเข้าไปใน Aspose.Slides, แทนที่ข้อความ, และบันทึกการนำเสนอที่แก้ไขแล้วกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ให้คุณแก้ไขเนื้อหา PDF โดยการนำเข้าหน้าที่เป็นสไลด์, แก้ไขการนำเสนอ, และส่งออกกลับเป็น PDF. บทความนี้แสดงการแทนที่ข้อความอย่างง่าย. การนำเสนอจะคงอยู่ในหน่วยความจำ, ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวเป็นเรื่องที่ไม่จำเป็น.

## **แทนที่ข้อความใน PDF**

ใช้ [addFromPdf](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addFromPdf) เพื่อนำเข้าหน้าที่, [replaceText](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#replaceText) เพื่ออัปเดตข้อความ, และ [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อส่งออกผลลัพธ์.

ตัวอย่างต่อไปนี้คาดว่า `input.pdf` มีคำว่า "Draft" เป็นข้อความที่สามารถแก้ไขได้หลังการนำเข้า. มันจะแทนที่คำนั้นด้วย "Final" และเขียนเป็น `edited.pdf`. การลบสไลด์เริ่มต้นก่อนการนำเข้าเพื่อป้องกันไม่ให้มีหน้าว่างเพิ่มในผลลัพธ์. การค้นหาจะจับคู่คำทั้งหมดที่มีตัวอักษรตรงกัน; `None` หมายถึงไม่ต้องการ callback ผลลัพธ์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

สำหรับตัวเลือกเพิ่มเติม, ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/python-java/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
การแทนที่ข้อความทำงานกับข้อความที่นำเข้า, ไม่ใช่ข้อความในภาพสแกน. การแปลงอาจส่งผลต่อการจัดวางและรูปแบบ, ดังนั้นควรตรวจสอบผลลัพธ์, โดยเฉพาะเมื่อข้อความที่แทนที่ยาวกว่าเดิม.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ผมต้องบันทึกไฟล์ PPTX ก่อนส่งออก PDF หรือไม่?**

ไม่. คุณสามารถแก้ไขและส่งออกการนำเสนอเดียวกันในหน่วยความจำได้. บันทึกสำเนา PPTX เฉพาะเมื่อคุณต้องการแก้ไขต่อใน PowerPoint; ดูที่ [บันทึกการนำเสนอ](/slides/th/python-java/save-presentation/).

**ทำไมข้อความบางส่วนอาจไม่เปลี่ยนแปลง?**

ตัวอย่างจับคู่คำเต็ม "Draft" โดยตรงตามตัวพิมพ์. ข้อความที่นำเข้าเป็นภาพหรือถูกแยกเป็นกรอบข้อความหลายส่วนอาจไม่ตรงกับการค้นหา. ตรวจสอบเนื้อหาที่นำเข้าและปรับการค้นหาให้เหมาะกับเอกสารของคุณ.