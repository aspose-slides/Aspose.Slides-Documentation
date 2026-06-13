---
title: สร้างรูปทรงเส้นในงานนำเสนอด้วย Python
linktitle: เส้น
type: docs
weight: 50
url: /th/python-net/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- สไตล์จุดขีด
- หัวศร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การจัดการการตั้งค่าเส้นในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET รองรับการเพิ่มรูปแบบต่าง ๆ ของรูปร่างลงในสไลด์ ในหัวข้อนี้ เราจะเริ่มทำงานกับรูปร่างโดยการเพิ่มเส้นลงในสไลด์ ด้วย Aspose.Slides นักพัฒนาสามารถสร้างเส้นง่าย ๆ ได้เท่านั้น แต่ยังสามารถวาดเส้นสไตล์พิเศษบนสไลด์ได้เช่นกัน.

## **สร้างเส้นธรรมดา**

ใช้ Aspose.Slides เพื่อเพิ่มเส้นธรรมดาลงในสไลด์เป็นตัวแบ่งหรือต่อเชื่อมแบบง่าย เพื่อเพิ่มเส้นธรรมดาลงในสไลด์ที่เลือกในงานนำเสนอ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ชนิด `LINE` โดยใช้เมธอด `add_auto_shape` บนวัตถุ [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/)
4. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง จะมีการเพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape ชนิด LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างเส้นรูปร่างลูกศร**

Aspose.Slides ให้คุณกำหนดค่าคุณสมบัติของเส้นเพื่อทำให้ดูน่าสนใจยิ่งขึ้น ด้านล่างนี้ เราจะกำหนดคุณสมบัติบางอย่างของเส้นให้ดูเหมือนลูกศร ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ชนิด `LINE` โดยใช้เมธอด `add_auto_shape` บนวัตถุ [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/)
4. ตั้งค่า [line style](https://reference.aspose.com/slides/th/python-net/aspose.slides/linestyle/)
5. ตั้งค่าความกว้างของเส้น
6. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/python-net/aspose.slides/linedashstyle/) ของเส้น
7. ตั้งค่า [arrowhead style](https://reference.aspose.com/slides/th/python-net/aspose.slides/linearrowheadstyle/) และความยาวสำหรับจุดเริ่มต้นของเส้น
8. ตั้งค่า [arrowhead style](https://reference.aspose.com/slides/th/python-net/aspose.slides/linearrowheadstyle/) และความยาวสำหรับจุดสิ้นสุดของเส้น
9. บันทึกงานนำเสนอเป็นไฟล์ PPTX

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape ชนิด LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # ปรับรูปแบบให้กับเส้น.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ฉันสามารถแปลงเส้นธรรมดาให้เป็นคอนเนคเตอร์เพื่อให้มัน "snap" ไปที่รูปร่างได้หรือไม่?**

No. เส้นธรรมดา (เป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ชนิด [LINE](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapetype/)) จะไม่เปลี่ยนเป็นคอนเนคเตอร์โดยอัตโนมัติ หากต้องการให้มัน snap ไปที่รูปร่าง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/python-net/aspose.slides/connector/) เฉพาะและ [corresponding APIs](/slides/th/python-net/connector/) สำหรับการเชื่อมต่อ

**ฉันควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดจากธีมและยากที่จะกำหนดค่าที่สุดท้าย?**

[Read the effective properties](/slides/th/python-net/shape-effective-properties/) ผ่านคลาส [ILineFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ilinefillformateffectivedata/) — คลาสเหล่านี้ได้คำนึงถึงการสืบทอดและสไตล์ของธีมแล้ว

**ฉันสามารถล็อกเส้นเพื่อป้องกันการแก้ไข (การย้าย, การปรับขนาด) ได้หรือไม่?**

Yes. รูปร่างมี [lock objects](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/auto_shape_lock/) ที่ช่วยให้คุณ [disallow editing operations](/slides/th/python-net/applying-protection-to-presentation/).