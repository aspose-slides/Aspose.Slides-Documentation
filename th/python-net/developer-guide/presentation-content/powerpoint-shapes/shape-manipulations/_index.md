---
title: จัดการรูปทรงพรีเซนเทชันใน Python
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/python-net/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงพรีเซนเทชัน
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- คัดลอกรูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ Interop Shape ID
- ข้อความสำรองของรูปทรง
- จุดปรับรูปทรง
- การปรับรูปทรงพรีเซ็ต
- เรขาคณิตรูปทรง
- รูปแบบเลเอาต์ของรูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- พลิกรูปทรง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการระบุ ปรับแต่ง คัดลอก ลบ ซ่อน จัดลำดับใหม่ ส่งออก จัดแนว และพลิกรูปทรงพรีเซนเทชันด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET แสดงรูปทรงบนสไลด์เป็น [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/) ที่จัดลำดับไว้แล้ว คอลเลกชันนี้เป็นทั้งสถานที่ที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งที่มาของลำดับการซ้อนกัน: ดัชนี `0` คือรูปทรงที่อยู่ด้านหลังสุด ส่วนดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าสุด

บทความนี้ปฏิบัติตามโมเดลดังกล่าว โดยอธิบายวิธีระบุรูปทรงอย่างมั่นคงและแก้ไขจุดปรับค่ารูปทรงที่ตั้งไว้ จากนั้นแสดงวิธีคัดลอก, ลบ, ซ่อน, และจัดลำดับรูปทรงใหม่ ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลเอาต์, การส่งออก SVG, การจัดแนว, และการตั้งค่าการพลิกรูปทรง ตัวอย่างแต่ละอันทำงานอิสระกัน ดังนั้นคุณสามารถใช้เพียงส่วนที่ต้องการในเวิร์กโฟลว์ของคุณได้

## **ระบุและค้นหารูปทรง**

ดัชนีของคอลเลกชันสะดวกเมื่อต้องประมวลผลไฟล์ที่รู้จักอยู่แล้ว แต่ไม่ใช่ตัวระบุที่คงที่ การเพิ่ม, ลบ, หรือจัดลำดับรูปทรงใหม่อาจทำให้ดัชนีเปลี่ยน เลือกตัวระบุตามวิธีการสร้างและดูแลพรีเซนเทชัน:

- [Shape.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/name/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและง่ายต่อการตรวจสอบในแผงการเลือกของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับประกันความเป็นเอกลักษณ์ ดังนั้นควรกำหนดแนวปฏิบัติการตั้งชื่อหากโค้ดพึ่งพาชื่อ
- [Shape.alternative_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/alternative_text/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปทรง มันปรากฏต่อผู้ใช้, อาจแปลเป็นหลายภาษา หรือเขียนใหม่เพื่อการเข้าถึง, และไม่ได้รับประกันความเป็นเอกลักษณ์ อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่มีการตรวจสอบ
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/office_interop_shape_id/) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint ใช้ ใช้เมื่อต้องรวมกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ชัดเจนในช่วงอายุของรูปทรง รูปทรงที่คัดลอกหรือสร้างใหม่จะมี ID ที่แตกต่างกัน

คุณสมบัติที่เกี่ยวข้อง [Shape.unique_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/unique_id/) มีขอบเขตระดับพรีเซนเทชัน แต่ถูกออกแบบสำหรับแอดอินและสามารถกำหนดใหม่ได้ ไม่ควรถือเป็นคีย์ภายนอกถาวร หากต้องการอัตลักษณ์ระยะยาวควรเก็บแมปปิ้งไว้ในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาโดย `name` ด้วยการเปรียบเทียบที่ตรงกันเป๊ะและรายงาน interop ID ระดับสไลด์ เมื่อเทมเพลตไม่มีรูปทรงที่คาดไว้ โค้ดจะแจ้งผลนั้นแทนที่จะดำเนินการต่อกับอ็อบเจ็กต์ที่ผิดพลาด

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

เมื่อการดำเนินการเฉพาะรูปทรงประเภทหนึ่ง ให้ตรวจสอบประเภทก่อนใช้งานสมาชิกเฉพาะประเภท ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่อตัวออบเจ็กต์ที่ตั้งชื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **ระบุและแก้ไขการปรับค่ารูปทรงที่ตั้งไว้**

รูปทรงเรขาคณิตที่ตั้งล่วงหน้าสามารถเปิดเผยจุดปรับค่าซึ่งควบคุมคุณลักษณะเช่น ขนาดมุม, อัตราส่วนของลูกศร, หรือมุมของโค้ง เข้าถึงได้ผ่านคอลเลกชันอ่านอย่างเดียว [GeometryShape.adjustments](https://reference.aspose.com/slides/th/python-net/aspose.slides/geometryshape/adjustments/) คอลเลกชันนี้ถูกจัดหาจากรูปทรงเอง แต่ละ [AdjustValue](https://reference.aspose.com/slides/th/python-net/aspose.slides/adjustvalue/) มีค่าเดียวที่สามารถเปลี่ยนแปลงได้

ห้ามพึ่งพาเฉพาะดัชนีคอลเลกชันคงที่ ให้วนรอบผ่านการปรับค่าและตรวจสอบคุณสมบัติอ่านอย่างเดียว [AdjustValue.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/adjustvalue/type/) ซึ่งค่า [ShapeAdjustmentType](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapeadjustmenttype/) บรรยายว่าการปรับค่านั้นควบคุมอะไร คุณสมบัติ [AdjustValue.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/adjustvalue/name/) ให้ข้อมูลระบุตัวเพิ่มและเป็นประโยชน์โดยเฉพาะเมื่อพรีเซ็ตมีการปรับค่ามากกว่าหนึ่งค่าที่มีประเภทเชิงความหมายเดียวกัน

ใช้คุณสมบัติ value ที่ตรงกับความหมายของการปรับค่า:

| ประเภทการปรับค่า | วัตถุประสงค์ | ค่าที่ต้องเปลี่ยน |
|---|---|---|
| `CORNER_SIZE` | ขนาดของมุมโค้ง | [raw_value](https://reference.aspose.com/slides/th/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | ความหนาของหางลูกศร | `raw_value` |
| `ARROWHEAD_LENGTH` | ความยาวของหัวลูกศร | `raw_value` |
| `ARROWHEAD_WIDTH` | ความกว้างของหัวลูกศร | `raw_value` |
| `START_ANGLE` | มุมเริ่มต้นของพายหรือโค้ง | [angle_value](https://reference.aspose.com/slides/th/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | มุมสิ้นสุดของพายหรือโค้ง | `angle_value` |

`type` และ `name` ไม่สามารถกำหนดค่าได้ `raw_value` เป็นจำนวนเต็มแบบอ่าน/เขียนในหน่วยเรขาคณิตดั้งเดิมของพรีเซ็ต, ส่วน `angle_value` เป็นมุมแบบอ่าน/เขียนหน่วยองศา จำนวน, ลำดับ, ความหมายและช่วงค่าที่ถูกต้องของการปรับค่าขึ้นอยู่กับพรีเซ็ต [GeometryShape.shape_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/geometryshape/shape_type/) ค่าเดียวที่ใช้ได้กับพรีเซ็ตหนึ่งอาจไม่ถูกต้องหรือให้ผลแตกต่างกับพรีเซ็ตอื่น

เมื่อ `type` เป็น `ShapeAdjustmentType.CUSTOM` API จะไม่รู้จักความหมายเชิงมาตรฐาน ตรวจสอบ `name`, ประเภทพรีเซ็ต, และค่าที่มีอยู่ แล้วปล่อยให้การปรับค่าไม่เปลี่ยนแปลง เว้นแต่คุณทราบความหมายและช่วงค่าที่คาดหวัง แม้สำหรับประเภทที่รับรู้แล้วก็ตาม ให้ตรวจสอบว่าประเภทเดียวกันปรากฏหลายครั้งหรือไม่ ก่อนเลือกค่า บทความ [Connector](/slides/th/python-net/connector/) แสดงกรณีนี้ที่การปรับค่าการโค้งของคอนเนคเตอร์

ตัวอย่างสมบูรณ์ต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่ปรับแก้ของสามรูปทรงพรีเซ็ต โดยวนรอบทุกการปรับค่า, รายงาน `name` และ `type`, เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน `raw_value`, เปลี่ยนมุมผ่าน `angle_value` และบันทึกผล คอลัมน์ซ้ายคงเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมโค้ง, ลูกศรสี่แบบ, และพายที่ปรับแก้

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มส่วนหัวสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่า.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าทำให้โค้ดชัดเจนเกี่ยวกับเจตนาและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวกันมีความหมายเท่ากันในพรีเซ็ตที่แตกต่างกัน

## **แก้ไข Shape Collection**

วิธีการเพิ่ม, คัดลอก, ลบ, และจัดลำดับทำงานบนคอลเลกชันโดยทันที หากการดำเนินการใดเปลี่ยนจำนวนหรือลำดับของรูปทรง อย่าอ้างอิงดัชนีที่จับไว้ก่อนการดำเนินการนั้นต่อไป

### **คัดลอกรูปทรง**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_clone/) สร้างสำเนาอิสระและเพิ่มต่อท้ายคอลเลกชันเป้าหมาย [ShapeCollection.insert_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/insert_clone/) ก็สร้างสำเนาเช่นกันแต่แทรกที่ดัชนี z‑order ที่ระบุ เวอร์ชันที่รับพิกัดจะย้ายคลอนโดยไม่เปลี่ยนขนาด; เวอร์ชันที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างสร้างสไลด์ปลายทาง, คัดลอกสี่เหลี่ยมที่มีป้ายชื่อไปด้านหน้า, และแทรกคลอนที่สองที่ด้านหลัง การเปลี่ยนแปลงใด ๆ กับคลอนใดคลอนหนึ่งจะไม่แก้ไขรูปทรงต้นฉบับ

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปทรงรวมถึงชื่อและข้อความทางเลือก กำหนดตัวระบุลอจิกใหม่ให้กับคลอนเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์ รายการทรัพยากรที่ใช้โดยรูปทรงซับซ้อนจะถูกพรีเซนเทชันจัดการ แต่คลอนยังคงเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปทรงใหม่

### **ลบรูปทรง**

[ShapeCollection.remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/remove/) ลบอ็อบเจ็กต์รูปทรงเฉพาะออกจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการขณะวนรอบตามดัชนี ให้เริ่มจากด้านหลังเพื่อให้ดัชนีที่เหลือยังคงใช้งานได้

ตัวอย่างนี้ลบทุกรูปทรงที่มีชื่อที่กำหนดไว้ มันอ่าน `slide.shapes[index]` ไม่ใช่รายการคอลเลกชันคงที่และไม่ได้ทำการคาสท์รูปทรงโดยไม่จำเป็น

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

หลังการลบ จำนวนรูปทรงและดัชนีของรูปทรงต่อมาจะเปลี่ยน การอ้างอิงรูปทรงที่ไม่ได้รับผลกระทบจึงเชื่อถือได้มากกว่าการบันทึกดัชนี ควรพิจารณาคอนเนคเตอร์, แอนิเมชัน, และฟีเจอร์พรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงถึงอ็อบเจ็กต์ที่ลบ; การลบรูปทรงที่มองเห็นได้อาจทำให้มากกว่าการเปลี่ยนแปลงลักษณะของสไลด์

### **ซ่อนรูปทรง**

การตั้งค่า [Shape.hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/hidden/) เป็น `True` ทำให้รูปทรงยังคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในสไลด์โชว์ปกติ ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมใช้งานสำหรับโค้ด ดังนั้นการซ่อนจึงเหมาะกับองค์ประกอบที่อาจต้องการเปิดใช้งานใหม่ในภายหลัง

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

การซ่อนไม่ใช่การลบหรือความปลอดภัย อ็อบเจ็กต์ยังคงค้นพบและยกเลิกการซ่อนได้โดยผู้ใช้หรือโดยโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **เปลี่ยน Z‑Order**

รูปทรงที่ทับซ้อนกันจะถูกวาดตามลำดับคอลเลกชัน [ShapeCollection.reorder](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/reorder/) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก ดัชนี `0` คือหลังสุด; `len(slide.shapes) - 1` คือหน้าสุด

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่ด้านหลังวงรี การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า จัดลำดับ z‑order หลังจากเพิ่มหรือคัดลอกรูปทรงที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนสแตกที่ต้องการ

## **ตรวจสอบรูปทรงบน Layout Slides**

สไลด์ปกติ, สไลด์เลเอาต์, และมาสเตอร์สไลด์มีคอลเลกชันรูปทรงแยกกัน รูปทรงในคอลเลกชันเลเอาต์ไม่ใช่อ็อบเจ็กต์เดียวกับรูปทรงที่อยู่ในตำแหน่งเดียวบนสไลด์ปกติ ตรวจสอบรูปทรงเลเอาต์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนแปลงการจัดรูปแบบที่เลเอาต์จัดหาให้

ตัวอย่างต่อไปนี้อ่าน [Shape.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/fill_format/) และ [Shape.line_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/line_format/) ของแต่ละรูปทรงในเลเอาต์โดยไม่สมมติว่าทุกรูปทรงเป็น `AutoShape`

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

การแก้ไขเลเอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้เลเอาต์นั้น ก่อนเปลี่ยนแปลงรูปทรงในเลเอาต์ ให้กำหนดว่ารูปทรงบนสไลด์ปกติสืบทอดอ็อบเจ็กต์นั้นหรือมีการแทนที่ในระดับท้องถิ่น และทดสอบทุกสไลด์ที่ใช้เลเอาต์นั้น

## **ส่งออกรูปทรงเป็น SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/write_as_svg/) เขียนเนื้อหาที่เรนเดอร์ของรูปทรงหนึ่งไปยังสตรีม ผลลัพธ์จะมีเฉพาะรูปทรงนั้น ไม่รวมพื้นหลังสไลด์หรือรูปทรงใกล้เคียงอื่น ๆ

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

ให้เปิดพรีเซนเทชันขณะทำการเรนเดอร์ Output ขึ้นอยู่กับการจัดรูปแบบของรูปทรงและทรัพยากรเช่นฟอนต์และภาพ หากต้องการส่งออกทั้งหมดให้ส่งออกสไลด์แทนการส่งออกรูปทรงเดี่ยว ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมเอง

## **จัดแนวรูปทรง**

การโอเวอร์โหลด [SlideUtil.align_shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/align_shapes/) สามารถจัดแนวทั้งชุดรูปทรงหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลาง, หรือโหมดการกระจาย ตั้งค่า `align_to_slide` เป็น `True` เพื่อใช้ขอบสไลด์; ตั้งค่าเป็น `False` เพื่อจัดแนวรูปทรงที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปทรงให้ชิดขอบบนของสไลด์ ดัชนีปัจจุบันของพวกมันจะถูกแกะออกก่อนการจัดแนว

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

การจัดแนวเปลี่ยนตำแหน่ง ไม่ใช่ z‑order การจัดแนวเชิงสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปทรง ในขณะที่การกระจายแนวนอนหรือแนวตั้งต้องมีรูปทรงจำนวนเพียงพอที่จะกำหนดระยะห่าง หากแก้ไขคอลเลกชันก่อนเรียกเมธอดให้คำนวณดัชนีใหม่

## **พลิกรูปทรง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapeframe/) จัดเก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `flip_h` และ `flip_v` ใช้ [NullableBool](https://reference.aspose.com/slides/th/python-net/aspose.slides/nullablebool/): `TRUE` เปิดการพลิก, `FALSE` ปิดการพลิก, `NOT_DEFINED` คงสถานะที่ไม่ได้กำหนดหรือค่าเริ่มต้น

พรีเซนเทชันตัวอย่างด้านล่างมีรูปทรงที่ยังไม่ได้พลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่นทั้งหมดและแทนที่เฉพาะการตั้งค่าพลิกสองค่านี้เท่านั้น ซึ่งสำคัญเพราะการกำหนดค่าใหม่ให้กับ [Shape.frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/frame/) จะทับกรอบทั้งหมด

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

รูปทรงที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งในขณะที่ตำแหน่ง, ขนาด, และการหมุนยังคงเดิม

![The shape after flipping](flipped_shape.png)

## **FAQ**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปทรงหรือไม่?**

ใช้ได้เฉพาะการประมวลผลสั้น ๆ ที่คอลเลกชันจะไม่เปลี่ยนก่อนใช้ดัชนี แนะนำให้ใช้ `name` หรือ `alternative_text` ที่ผ่านการตรวจสอบสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือ `office_interop_shape_id` สำหรับงานที่เกี่ยวกับ interop ระดับสไลด์

**การซ่อนรูปทรงทำให้มันหายจาก z‑order หรือไม่?**

ไม่ รูปทรงที่ซ่อนไม่หายจากคอลเลกชันและยังคงอยู่ที่ดัชนีเดียวกัน สามารถค้นหา, จัดลำดับใหม่, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง

**ทำไมนำรูปทรงที่คัดลอกได้ปรากฏอยู่ด้านหน้ารูปทรงอื่น?**

`add_clone` จะเพิ่มคลอนต่อท้ายคอลเลกชันซึ่งเป็นด้านหน้าของ z‑order ใช้ `insert_clone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปทรงทั้งหมดแล้ว

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับค่าพรีเซ็ตของรูปทรงได้หรือไม่?**

ได้เฉพาะหลังจากตรวจสอบพรีเซ็ตและโครงสร้างคอลเลกชันอย่างแม่นยำ แนะนำให้วนรอบผ่าน `GeometryShape.adjustments` และตรวจสอบ `AdjustValue.type`; ใช้ `AdjustValue.name` เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏมากกว่าหนึ่งครั้ง