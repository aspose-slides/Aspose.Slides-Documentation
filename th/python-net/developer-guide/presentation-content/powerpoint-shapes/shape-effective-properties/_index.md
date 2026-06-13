---
title: รับคุณสมบัติรูปร่างที่ Effective จากงานนำเสนอด้วย Python
linktitle: คุณสมบัติ Effective
type: docs
weight: 50
url: /th/python-net/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างเบเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบว่า Aspose.Slides สำหรับ Python ผ่าน .NET คำนวณและใช้คุณสมบัติรูปร่างที่ Effective เพื่อการเรนเดอร์ PowerPoint ที่แม่นยำ"
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** กับ **effective** ค่า local คือค่าที่ตั้งโดยตรงในระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติส่วนของสไลด์
1. รูปแบบข้อความของรูปแบบต้นแบบบนเลย์เอาต์หรือสไลด์มาสเตอร์ เมื่อรูปทรงกรอบข้อความของส่วนมีค่าเหล่านั้น
1. การตั้งค่าข้อความระดับโลกในงานนำเสนอ

ค่าที่เป็น local สามารถกำหนดหรือละเว้นได้ในทุกระดับ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบขั้นสุดท้าย “ตามที่แสดงผล” มันจะทำการแก้ไขสายการสืบทอดและส่งคืนค่าที่ **effective** คุณสามารถรับค่าเหล่านี้ได้โดยการเรียกเมธอด `get_effective` บนวัตถุรูปแบบ local

ตัวอย่างต่อไปนี้แสดงวิธีรับค่า effective โดยสมมติว่ารูปแรกบนสไลด์แรกเป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่มีกรอบข้อความและมีอย่างน้อยหนึ่งส่วน

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}

ข้อมูลการจัดรูปแบบที่ effective แสดงผลการคำนวณปัจจุบันหลังจากนำการสืบทอดมาใช้ ในการทำงานปัจจุบันบางอ็อบเจ็กต์ข้อมูล effective เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/iportionformateffectivedata/) อาจถูกเก็บแคชภายใน การเรียก `get_effective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบพาเรนต์หรือการสืบทอดจะรีเฟรชข้อมูลแคช และอ็อบเจ็กต์ที่ได้ก่อนหน้านี้อาจไม่แสดงสถานะเดิมอีกต่อไป หากคุณต้องการเก็บค่าที่ effective ไว้ใช้ในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนต์ สีเติม สไตล์ฟอนต์ หรือการจัดแนว ไปยังอ็อบเจ็กต์ข้อมูลของคุณเอง

{{% /alert %}}

## **รับคุณสมบัติ Effective ของกล้อง**

Aspose.Slides ให้คุณรับคุณสมบัติ effective ของกล cámara ได้ชนิด [ICameraEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/icameraeffectivedata/) แทนอ็อบเจ็กต์ไม่เปลี่ยนแปลงที่มีคุณสมบัติกล้องที่ effective ตัวอย่าง [ICameraEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/icameraeffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติ effective ของกล้อง โดยสมมติว่ารูปแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **รับคุณสมบัติ Effective ของ Light Rig**

Aspose.Slides ให้คุณรับคุณสมบัติ effective ของ Light Rig ได้ชนิด [ILightRigEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ilightrigeffectivedata/) แทนอ็อบเจ็กต์ไม่เปลี่ยนแปลงที่มีคุณสมบัติ Light Rig ที่ effective ตัวอย่าง [ILightRigEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ilightrigeffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติ effective ของ Light Rig โดยสมมติว่ารูปแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **รับคุณสมบัติ Effective ของ Bevel Shape**

Aspose.Slides ให้คุณรับคุณสมบัติ effective ของ bevel รูปได้ชนิด [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapebeveleffectivedata/) แทนอ็อบเจ็กต์ไม่เปลี่ยนแปลงที่มีคุณสมบัติเส้นลายนูนที่ effective ตัวอย่าง [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapebeveleffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติ effective ของ bevel ด้านบนของรูป โดยสมมติว่ารูปแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **รับคุณสมบัติ Effective ของ Text Frame**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของ Text Frame ได้ ชนิด [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/itextframeformateffectivedata/) มีคุณสมบัติการจัดรูปแบบ Text Frame ที่ effective

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติการจัดรูปแบบ Text Frame ที่ effective โดยสมมติว่ารูปแรกบนสไลด์แรกเป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่มีกรอบข้อความ

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **รับคุณสมบัติ Effective ของ Text Style**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของ Text Style ได้ ชนิด [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/itextstyleeffectivedata/) มีคุณสมบัติสไตล์ข้อความที่ effective

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติ Text Style ที่ effective โดยสมมติว่ารูปแรกบนสไลด์แรกเป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่มีกรอบข้อความ

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **รับค่า Effective ของความสูงฟอนต์**

ด้วย Aspose.Slides คุณสามารถรับความสูงฟอนต์ที่ effective ได้ โค้ดต่อไปนี้สาธิตว่าความสูงฟอนต์ของส่วน (portion) ที่ effective จะเปลี่ยนแปลงอย่างไรหลังจากตั้งค่าความสูงฟอนต์ local ที่ระดับโครงสร้างการนำเสนอต่าง ๆ

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **รับ Effective Fill Format สำหรับตาราง**

ด้วย Aspose.Slides คุณสามารถรับการเติมรูปแบบที่ effective สำหรับส่วนต่าง ๆ ของตารางได้ ชนิด [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ifillformateffectivedata/) มีคุณสมบัติการเติมที่ effective การจัดรูปแบบเซลล์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบแถว แถวมีลำดับความสำคัญสูงกว่าคอลัมน์ และคอลัมน์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบตารางทั้งหมด

ดังนั้นคุณสมบัติ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/icellformateffectivedata/) จะถูกใช้ในการวาดเซลล์ตาราง โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับการเติมรูปแบบที่ effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปแรกบนสไลด์แรกเป็น [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/)

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **คำถามที่พบบ่อย**

**`get_effective` คืนค่าภาพถ่าย (snapshot) หรือไม่?**

ไม่เสมอ ข้อมูลที่ effective แสดงการคำนวณรูปแบบหลังจากนำการสืบทอดมาใช้ แต่บางอ็อบเจ็กต์ข้อมูล effective อาจถูกแคชภายใน การเรียก `get_effective` ครั้งต่อมาหลังจากเปลี่ยนแปลงรูปแบบพาเรนต์หรือการสืบทอดอาจคำนวณรูปแบบใหม่และรีเฟรชแคช ดังนั้นอ็อบเจ็กต์ที่ได้ก่อนหน้านี้ไม่ควรถือว่าเป็นภาพถ่ายที่คงที่

**เมื่อไรที่ควรอ่านคุณสมบัติ effective อีกครั้ง?**

ให้เรียก `get_effective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบ local, สไตล์พาเรนต์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบมาสเตอร์ หรือค่าเริ่มต้นระดับงานนำเสนอ การเรียกครั้งถัดไปจะประเมินลำดับชั้นของรูปแบบใหม่และคืนค่าที่ effective ปัจจุบัน

**การเปลี่ยนแปลงหรือการลบสไลด์เลย์เอาต์/มาสเตอร์จะมีผลต่อคุณสมบัติ effective ที่เคยดึงมาแล้วหรือไม่?**

ใช่ แต่การเปลี่ยนแปลงจะแสดงผลในการเรียก `get_effective` ครั้งถัดไป หากแหล่งข้อมูลรูปแบบพาเรนต์ถูกเปลี่ยนหรือถูกลบ ข้อมูลที่ effective ที่เคยดึงมาอาจล้าสมัย เมื่อเรียก `get_effective` อีกครั้ง Aspose.Slides จะประเมินต้นไม้ของรูปแบบใหม่และค่า‑ฟอนต์, สี, ขนาด หรือค่าอื่น ๆ อาจเปลี่ยนแปลง

**ฉันสามารถแก้ไขค่าได้ผ่านอ็อบเจ็กต์ข้อมูล effective หรือไม่?**

ไม่ได้ อ็อบเจ็กต์ข้อมูลที่ effective เฉพาะการเปิดเผยค่าที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในอ็อบเจ็กต์การจัดรูปแบบ local แล้วจึงดึงค่าที่ effective ใหม่อีกครั้ง

**ถ้าคุณสมบัติไม่ได้ถูกตั้งค่าในระดับรูป, เลย์เอาต์/มาสเตอร์ หรือการตั้งค่าระดับโลก จะเกิดอะไรขึ้น?**

ค่าที่ effective จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่แก้ไขแล้วจะกลายเป็นส่วนหนึ่งของข้อมูลที่ effective ปัจจุบัน

**จากค่าฟอนต์ที่ effective, ฉันจะบอกได้หรือไม่ว่าค่ามาจากระดับใด?**

ไม่ได้โดยตรง ข้อมูลที่ effective คืนค่าที่สุดท้าย เพื่อตรวจสอบแหล่งที่มาต้องตรวจสอบค่าที่ local ที่ portion, paragraph, text frame, แล้วถึงสไตล์ข้อความที่เลย์เอาต์, มาสเตอร์ และระดับงานนำเสนอ เพื่อดูว่าการกำหนดที่ชัดเจนแรกปรากฏที่ระดับใด

**ทำไมค่าที่ effective บางครั้งดูเหมือนกับค่าที่ local?**

เพราะค่าที่ local กลายเป็นค่าที่สุดท้าย (ไม่มีการสืบทอดระดับสูงที่จำเป็น) ในกรณีนั้นค่าที่ effective จะตรงกับค่าที่ local

**เมื่อไรที่ควรใช้คุณสมบัติ effective และเมื่อไรที่ควรทำงานเฉพาะกับค่า local?**

ใช้ข้อมูลที่ effective เมื่อต้องการผลลัพธ์ “ตามที่แสดงผล” หลังจากการสืบทอดทั้งหมด เช่น การจัดสี, ระยะเยื้อง หรือขนาด หากต้องการเก็บค่าดังกล่าวไว้โดยไม่สนใจการเปลี่ยนแปลงรูปแบบในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการไปยังอ็อบเจ็กต์ของคุณเอง หากต้องการเปลี่ยนรูปแบบที่ระดับเฉพาะให้แก้ไขค่าที่ local แล้วอ่านข้อมูลที่ effective อีกครั้ง (ถ้าต้องการ) เพื่อตรวจสอบผลลัพธ์.