---
title: จัดการรูปร่างการนำเสนอใน Python
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/python-net/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ Interop Shape ID
- ข้อความแทนรูปร่าง
- รูปแบบเลย์เอาต์ของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, คัดลอก, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และพลิกรูปร่างการนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET แสดงรูปร่างบนสไลด์เป็น [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/) ที่เรียงลำดับ คอลเลกชันเป็นทั้งที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งกำเนิดของลำดับการซ้อนกัน: ดัชนี `0` คือรูปร่างที่อยู่ด้านหลังสุด ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้าสุด

บทความนี้ปฏิบัติตามโมเดลนั้น โดยเริ่มอธิบายวิธีระบุรูปร่างอย่างแม่นยำ จากนั้นแสดงการคัดลอก ลบ ซ่อน และจัดลำดับรูปร่างใหม่ ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์ การส่งออกเป็น SVG การจัดแนว และการตั้งค่าการพลิก พอตัวอย่างแต่ละอันเป็นอิสระ คุณจึงสามารถใช้เฉพาะการดำเนินการที่ workflow ของคุณต้องการได้

## **ระบุและค้นหารูปร่าง**

ดัชนีของคอลเลกชันสะดวกขณะประมวลผลไฟล์ที่ทราบ แต่ไม่เป็นตัวระบุที่คงที่ การเพิ่ม ลบ หรือจัดลำดับรูปร่างใหม่อาจทำให้ดัชนีเปลี่ยน เลือกตัวระบุตามวิธีการสร้างและดูแลพรีเซนเทชัน:

- [Shape.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/name/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและง่ายต่อการตรวจสอบใน Selection Pane ของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับประกันว่าจะเป็นเอกลักษณ์ ดังนั้นควรกำหนดแนวปฏิบัติการตั้งชื่อหากโค้ดพึ่งพา
- [Shape.alternative_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/alternative_text/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนใส่ไว้แล้วระบุรูปร่าง มันมองเห็นได้โดยผู้ใช้ อาจแปลเป็นหลายภาษา หรือแก้ไขเพื่อการเข้าถึง และไม่รับประกันว่าจะเป็นเอกลักษณ์ อย่าเปลี่ยนข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลอย่างเงียบๆ
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/office_interop_shape_id/) เป็นตัวระบุแบบอ่านเท่านั้นที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint ใช้ ใช้เมื่อผสานกับ PowerPoint หรือเมื่อต้องการอ้างอิงที่ไม่กำกวมตลอดอายุของรูปร่าง รูปร่างที่คัดลอกหรือสร้างใหม่จะเป็นรูปร่างที่แตกต่างและได้รับ ID ของตนเอง

คุณสมบัติ [Shape.unique_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/unique_id/) ที่เกี่ยวข้องมีขอบเขตระดับพรีเซนเทชัน แต่ออกแบบมาสำหรับแอดอินและอาจถูกกำหนดใหม่ ไม่ควรถือเป็นคีย์ภายนอกถาวร หากต้องการอัตลักษณ์ระยะยาวควรเก็บแมปปิ้งในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาโดย `name` ด้วยการเปรียบเทียบตรงและรายงาน Interop ID ระดับสไลด์ เมื่อเทมเพลตไม่มีรูปร่างที่คาดหวัง โค้ดจะรายงานผลนั้นแทนการดำเนินต่อด้วยอ็อบเจ็กต์ที่ผิดพลาด

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

เมื่อการดำเนินการเจาะจงประเภทของรูปร่าง ให้ตรวจสอบประเภทก่อนใช้สมาชิกเฉพาะประเภท ตัวอย่างนี้จะอัปเดตข้อความและข้อความแทนเมื่อวัตถุที่ตั้งชื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)

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

## **แก้ไขคอลเลกชันรูปร่าง**

เมธอดเพิ่ม คัดลอก ลบ และจัดลำดับทำงานบนคอลเลกชันโดยทันที หากการดำเนินการเปลี่ยนจำนวนหรือลำดับของรูปร่าง อย่าอ้างอิงดัชนีที่จับไว้ก่อนการดำเนินการนั้นต่อไป

### **คัดลอกรูปร่าง**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_clone/) สร้างสำเนาอิสระและต่อท้ายลงในคอลเลกชันเป้าหมาย [ShapeCollection.insert_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/insert_clone/) ก็สร้างสำเนาเช่นกันแต่วางที่ดัชนี z‑order ที่ระบุ การโอเวอร์โหลดที่รับพิกัดจะย้ายคล็อนโดยไม่เปลี่ยนขนาด; การโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างสร้างสไลด์ปลายทาง คัดลอกสี่เหลี่ยมที่มีป้ายเป็นหน้าสไลด์และใส่คล็อนที่สองไว้ด้านหลัง การเปลี่ยนแปลงใด ๆ กับคล็อนใดคล็อนได้ไม่ส่งผลต่อรูปร่างต้นฉบับ

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

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร่าง รวมถึงชื่อและข้อความแทน ให้กำหนดตัวระบุตรรกะใหม่ให้กับคล็อนเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์ ทรัพยากรที่ใช้โดยรูปร่างซับซ้อนจัดการโดยพรีเซนเทชัน แต่คล็อนยังคงเป็นรายการคอลเลกชันใหม่พร้อมอัตลักษณ์รูปร่างใหม่

### **ลบรูปร่าง**

[ShapeCollection.remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/remove/) ลบอ็อบเจ็กต์รูปร่างเฉพาะออกจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการระหว่างการวนผ่านโดยใช้ดัชนี ให้วนจากท้ายสุดเพื่อให้ดัชนีที่เหลืออยู่ยังคงถูกต้อง

ตัวอย่างนี้ลบทุกรูปร่างที่มีชื่อที่กำหนด มันอ่าน `slide.shapes[index]` ไม่ใช่รายการคอลเลกชันคงที่และไม่ได้แคสต์รูปร่างโดยไม่จำเป็น

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

หลังการลบ จำนวนรูปร่างและดัชนีของรูปร่างที่เหลือจะเปลี่ยน การอ้างอิงไปยังรูปร่างที่ไม่ได้รับผลกระทบยังคงเชื่อถือได้กว่าดัชนีที่บันทึกไว้ ควรคำนึงถึงคอนเนคเตอร์, แอนิเมชันและคุณลักษณะพรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงถึงอ็อบเจ็กต์ที่ลบ; การลบรูปร่างที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะของสไลด์

### **ซ่อนรูปร่าง**

การตั้งค่า [Shape.hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/hidden/) เป็น `True` ทำให้รูปร่างอยู่ในคอลเลกชันแต่ไม่แสดงในการนำเสนอแบบปกติ ดัชนี, การจัดรูปแบบและเนื้อหายังคงพร้อมให้โค้ดเข้าถึง ดังนั้นการซ่อนจึงเหมาะกับองค์ประกอบที่อาจต้องการเปิดใช้งานใหม่ในภายหลัง

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

การซ่อนไม่ใช่การลบหรือความปลอดภัย อ็อบเจ็กต์ยังคงสามารถค้นหาและเปิดซ่อนได้โดยผู้ใช้หรือโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **เปลี่ยนลำดับ Z**

รูปร่างที่ทับซ้อนกันจะถูกวาดตามลำดับคอลเลกชัน [ShapeCollection.reorder](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/reorder/) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่คัดลอก ดัชนี `0` คือด้านหลัง; `len(slide.shapes) - 1` คือด้านหน้า

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

สี่เหลี่ยมถูกสร้างขึ้นเป็นอันดับแรกและเริ่มต้นอยู่ด้านหลังวงรี การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า สรุปลำดับ z‑order หลังจากเพิ่มหรือคัดลอกรูปร่างที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะต่อหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนสแต็กที่ต้องการ

## **ตรวจสอบรูปร่างบนสไลด์ Layout**

สไลด์ปกติ, สไลด์ Layout, และสไลด์ Master มีคอลเลกชันรูปร่างแยกกัน รูปร่างในคอลเลกชัน Layout ไม่ใช่วัตถุเดียวกับรูปร่างที่อยู่ในตำแหน่งเดียวกันบนสไลด์ปกติ ให้ตรวจสอบรูปร่าง Layout เมื่อคุณต้องการทำความเข้าใจหรือเปลี่ยนการจัดรูปแบบที่ Layout จัดให้

ตัวอย่างต่อไปนี้อ่าน [Shape.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/fill_format/) และ [Shape.line_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/line_format/) ของแต่ละรูปร่าง Layout โดยไม่สมมติว่าทุกรูปร่างเป็น `AutoShape`

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

การแก้ไข Layout อาจส่งผลต่อหลายสไลด์ที่ใช้ Layout นั้น ก่อนเปลี่ยนรูปร่าง Layout ให้ตรวจสอบว่าสไลด์ปกติสืบทอดอ็อบเจ็กต์หรือมีการเขียนทับในระดับท้องถิ่น และทดสอบทุกสไลด์ที่ใช้ Layout นี้

## **ส่งออกรูปร่างเป็น SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/write_as_svg/) เขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งลงในสตรีม ผลลัพธ์จะมีเพียงรูปร่าง ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปร่างข้างเคียง

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

ให้เปิดพรีเซนเทชันขณะเรนเดอร์ ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปร่างและทรัพยากรเช่น ฟอนต์และรูปภาพ หากต้องการภาพรวมทั้งหมดให้ส่งออกสไลด์แทนการส่งออกรูปร่างเดี่ยว ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมนั้น

## **จัดแนวรูปร่าง**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/align_shapes/) มีโอเวอร์โหลดที่จัดแนวทั้งทั้งหมดหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นกึ่งกลาง หรือโหมดการกระจาย ตั้งค่า `align_to_slide` เป็น `True` เพื่อใช้ขอบสไลด์; ตั้งเป็น `False` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน

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

การจัดแนวเปลี่ยนตำแหน่ง ไม่ใช่ลำดับ Z การจัดแนวเชิงสัมพันธ์ทั่วไปต้องการอย่างน้อยสองรูปร่าง ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างเพียงพอเพื่อกำหนดช่องว่าง คำนวณดัชนีใหม่หากแก้ไขคอลเลกชันก่อนเรียกเมธอด

## **พลิกรูปร่าง**

[ShapeFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `flip_h` และ `flip_v` ใช้ [NullableBool](https://reference.aspose.com/slides/th/python-net/aspose.slides/nullablebool/): `TRUE` เปิดการพลิก, `FALSE` ปิดการพลิก, และ `NOT_DEFINED` รักษาสถานะที่ไม่ได้กำหนดหรือค่าเริ่มต้น

พรีเซนเทชันอินพุตด้านล่างมีรูปร่างที่ไม่ได้พลิก

![รูปร่างก่อนการพลิก](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่นทั้งหมดและแทนที่เฉพาะการตั้งค่าการพลิกสองค่า ซึ่งสำคัญเพราะการกำหนด [Shape.frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/frame/) ใหม่จะทับกรอบทั้งหมด

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

รูปร่างที่บันทึกไว้ถูกสะท้อนแนวนอนและแนวตั้งพร้อมคงตำแหน่ง, ขนาดและการหมุน

![รูปร่างหลังการพลิก](flipped_shape.png)

## **FAQ**

**ควรใช้ดัชนีของคอลเลกชันเป็นตัวระบุรูปร่างหรือไม่?**

ใช้ได้เฉพาะการประมวลผลระยะสั้นเมื่อคอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี แนะนำให้ใช้ `name` หรือ `alternative_text` ที่ผ่านการตรวจสอบเป็นแนวปฏิบัติสำหรับเทมเพลตที่สร้างโดยผู้เขียน หรือ `office_interop_shape_id` สำหรับงานที่ต้องอ้างอิงระดับสไลด์

**การซ่อนรูปร่างทำให้มันหายไปจากลำดับ Z หรือไม่?**

ไม่ การซ่อนรูปร่างยังคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน สามารถค้นหา, จัดลำดับใหม่, แก้ไขหรือทำให้มองเห็นได้อีกครั้ง

**ทำไมรูปร่างที่คัดลอกจึงปรากฏอยู่หน้ารูปร่างอื่น?**

`add_clone` จะต่อท้ายคล็อนที่ปลายคอลเลกชันซึ่งเป็นด้านหน้าของลำดับ Z ใช้ `insert_clone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว