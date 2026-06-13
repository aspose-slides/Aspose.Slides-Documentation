---
title: จัดการซูเปอร์สคริปต์และซับสคริปต์ใน Python
linktitle: ซูเปอร์สคริปต์และซับสคริปต์
type: docs
weight: 80
url: /th/python-net/superscript-and-subscript/
keywords:
- ซูเปอร์สคริปต์
- ซับสคริปต์
- เพิ่มซูเปอร์สคริปต์
- เพิ่มซับสคริปต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เชี่ยวชาญการใช้ซูเปอร์สคริปต์และซับสคริปต์ใน Aspose.Slides สำหรับ Python ผ่าน .NET และยกระดับการนำเสนอของคุณด้วยการจัดรูปแบบข้อความระดับมืออาชีพเพื่อให้มีผลกระทบสูงสุด"
---
## **ภาพรวม**

Aspose.Slides มีคุณลักษณะสำหรับรวมข้อความยกระดับบนและระดับล่างลงในงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ของคุณ ไม่ว่าจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรืออธิบายเนื้อหาด้วยหมายเหตุ การจัดรูปแบบพิเศษเหล่านี้ช่วยให้คงความชัดเจนและความแม่นยำได้อย่างดี ในบทความนี้ คุณจะได้เรียนรู้วิธีใช้สไตล์ยกระดับบนและระดับล่างอย่างราบรื่นเพื่อให้ได้ผลลัพธ์ระดับมืออาชีพในทุกสไลด์

## **เพิ่มข้อความยกระดับบนและระดับล่าง**

คุณสามารถเพิ่มข้อความยกระดับบนและระดับล่างให้กับส่วนของย่อหน้าใดก็ได้ ใน Aspose.Slides ให้ใช้คุณสมบัติ `escapement` ของคลาส [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) เพื่อควบคุมสิ่งนี้

`escapement` เป็นเปอร์เซ็นต์ตั้งแต่ **-100% ถึง 100%**:

- **> 0** → ยกระดับบน (เช่น 25% = ยกเล็กน้อย; 100% = ยกเต็มระดับ)
- **0** → เส้นฐาน (ไม่มีการยกหรือห้อย)
- **< 0** → ห้อยระดับล่าง (เช่น -25% = ห้อยเล็กน้อย; -100% = ห้อยเต็มระดับ)

ขั้นตอน:

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และรับสไลด์หนึ่งสไลด์
2. เพิ่มรูปสี่เหลี่ยม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) แล้วเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของมัน
3. ลบย่อหน้าที่มีอยู่เดิม
4. สำหรับยกระดับบน: สร้างย่อหน้าและส่วน, ตั้งค่า `portion.portion_format.escapement` เป็นค่าระหว่าง **0 และ 100**, ตั้งข้อความ, แล้วเพิ่มส่วนนั้น
5. สำหรับห้อยระดับล่าง: สร้างย่อหน้าและส่วนอีกหนึ่ง, ตั้งค่า `escapement` เป็นค่าระหว่าง **-100 และ 0**, ตั้งข้อความ, แล้วเพิ่มส่วนนั้น
6. บันทึกงานนำเสนอเป็นไฟล์ PPTX

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # รับสไลด์หนึ่ง
    slide = presentation.slides[0]

    # สร้างกล่องข้อความ
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # สร้างย่อหน้าสำหรับข้อความซูเปอร์สคริปต์
    superscript_paragraph = slides.Paragraph()

    # สร้างส่วนข้อความที่มีข้อความปกติ
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # สร้างส่วนข้อความที่มีข้อความซูเปอร์สคริปต์
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # สร้างย่อหน้าสำหรับข้อความซับสคริปต์
    subscript_paragraph = slides.Paragraph()

    # สร้างส่วนข้อความที่มีข้อความปกติ
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # สร้างส่วนข้อความที่มีข้อความซับสคริปต์
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # เพิ่มย่อหน้าเข้าไปในกล่องข้อความ
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ยกระดับบน/ห้อยระดับล่างในตารางและคอนเทนเนอร์อื่น ๆ ไม่ใช่แค่กล่องข้อความทั่วไปได้หรือไม่?**

ได้ คุณสามารถจัดรูปแบบข้อความเป็นยกระดับบนหรือห้อยระดับล่างภายในวัตถุใด ๆ ที่เปิดเผย [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) (รวมถึงเซลล์ตาราง) การจัดรูปแบบจะถูกนำไปใช้กับส่วนของข้อความภายในเฟรมนั้น

**การยกระดับบน/ห้อยระดับล่างจะคงอยู่เมื่อต экспort ไปเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ได้ Aspose.Slides จะคงการจัดรูปแบบยกระดับบน/ห้อยระดับล่างไว้เมื่อตีออกเป็นรูปแบบทั่วไปเช่น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/th/python-net/convert-powerpoint-to-html/), และ [รูปภาพ raster](/slides/th/python-net/convert-powerpoint-to-png/) เนื่องจากกระบวนการเรนเดอร์เคารพการจัดรูปแบบข้อความในระดับส่วน

**ฉันสามารถรวมยกระดับบน/ห้อยระดับล่างกับไฮเปอร์ลิงก์ในส่วนข้อความเดียวกันได้หรือไม่?**

ได้ [Hyperlinks](/slides/th/python-net/manage-hyperlinks/) ถูกกำหนดระดับส่วน (fragment) ดังนั้นส่วนหนึ่งสามารถมีไฮเปอร์ลิงก์และพร้อมกันนั้นมีการจัดรูปแบบเป็นยกระดับบนหรือหอยระดับล่างได้