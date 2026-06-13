---
title: จัดการรูปทรงในงานนำเสนอด้วย Python
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/python-net/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงงานนำเสนอ
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- โคลนรูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ Interop Shape ID
- ข้อความแทนของรูปทรง
- รูปแบบเลเอาต์ของรูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การสร้าง, แก้ไขและปรับแต่งรูปทรงใน Aspose.Slides สำหรับ Python ผ่าน .NET และส่งมอบงานนำเสนอ PowerPoint และ OpenDocument ที่มีประสิทธิภาพสูง"
---
## **ภาพรวม**

คู่มือนี้แนะนำการจัดการรูปทรงใน Aspose.Slides สำหรับ Python ผ่าน .NET. เรียนรู้รูปแบบการใช้งานจริงสำหรับการค้นหารูปทรง (รวมถึงโดยข้อความแทน), การทำสำเนา, การลบหรือซ่อน, การจัดลำดับใหม่, การจัดแนวและการพลิก, การอ่าน ID และการจัดรูปแบบตามเลเอาต์, และการส่งออกรูปทรงแต่ละอันเป็น SVG โดยใช้ API ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/)

## **ค้นหารูปทรงบนสไลด์**

PowerPoint ระบุรูปทรงโดยใช้ ID ภายในเท่านั้น. กำหนดข้อความแทน (Alt Text) ที่ไม่ซ้ำกันให้กับรูปทรงเป้าหมายใน PowerPoint, จากนั้นเปิดการพรีเซนเทชันด้วย Aspose.Slides for Python, วนลูปผ่านรูปทรงบนสไลด์, และเลือกรูปทรงที่ข้อความแทนตรงกัน. วิธี `find_shape` ได้ทำตามกระบวนการนี้และคืนค่ารูปทรงที่ตรงกัน.

```py
import aspose.slides as slides

# ค้นหารูปทรงบนสไลด์โดยใช้ข้อความแทนของมัน.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # ค้นหารูปทรงที่มีข้อความแทน "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **โคลนรูปทรง**

เพื่อโคลนรูปทรงจากสไลด์ต้นฉบับไปยังสไลด์ใหม่ใน Aspose.Slides, ทำตามขั้นตอนต่อไปนี้:

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) จากไฟล์ต้นฉบับ
1. ดึงสไลด์ต้นฉบับโดยใช้ดัชนีและคอลเลกชันรูปทรงของมัน
1. รับเลเอาท์เปล่าวัลจากมาสเตอร์สไลด์
1. เพิ่มสไลด์เปล่าโดยใช้เลเอาท์นั้นและดึงรูปทรงของสไลด์ใหม่
1. โคลนรูปทรงเข้าสู่สไลด์เป้าหมาย
1. บันทึกพรีเซนเทชันเป็น PPTX

โค้ดตัวอย่างต่อไปนี้จะแสดงการโคลนรูปทรงจากสไลด์หนึ่งไปยังอีกสไลด์หนึ่ง.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบรูปทรง**

Aspose.Slides ให้คุณลบรูปทรงใด ๆ จากสไลด์ได้. ตัวอย่างเช่น เพื่อลบรูปทรงจากสไลด์แรกโดยใช้ข้อความแทน, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดไฟล์
1. เข้าถึงสไลด์แรกจากคอลเลกชันสไลด์
1. ค้นหารูปทรงโดยค่าข้อความแทน
1. ลบรูปทรงออกจากคอลเลกชันรูปทรงของสไลด์
1. บันทึกพรีเซนเทชันลงดิสก์ในรูปแบบ PPTX

```py
import aspose.slides as slides

# ค้นหารูปทรงบนสไลด์โดยใช้ข้อความแทนของมัน.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # ค้นหารูปทรงที่มีข้อความแทน "User Defined".
    shape = find_shape(slide, "User Defined")
    # ลบรูปทรง.
    slide.shapes.remove(shape)
    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ซ่อนรูปทรง**

Aspose.Slides ให้คุณซ่อนรูปทรงใด ๆ บนสไลด์ได้. ตัวอย่างเช่น เพื่ซ่อนรูปทรงบนสไลด์แรกโดยใช้ข้อความแทน, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดไฟล์
1. เข้าถึงสไลด์แรกจากคอลเลกชันสไลด์
1. ค้นหารูปทรงโดยค่าข้อความแทน
1. ซ่อนรูปทรง
1. บันทึกพรีเซนเทชันลงดิสก์ในรูปแบบ PPTX

```py
# ค้นหารูปทรงบนสไลด์โดยใช้ข้อความแทนของมัน.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # ค้นหารูปทรงที่มีข้อความแทน "User Defined".
    shape = find_shape(slide, "User Defined")
    # ซ่อนรูปทรง.
    shape.hidden = True
    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนลำดับของรูปทรง**

Aspose.Slides อนุญาตให้ผู้พัฒนาจัดลำดับรูปทรงใหม่ (เปลี่ยน z-order). การจัดลำดับกำหนดว่ารูปทรงอันใดอยู่ด้านหน้าหรือด้านหลัง. ตัวอย่างเช่น เพื่อจัดลำดับรูปทรงสองอันบนสไลด์แรก, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปทรงแรก (เช่น สี่เหลี่ยม)
1. เพิ่มรูปทรงที่สอง (เช่น สามเหลี่ยม)
1. จัดลำดับรูปทรงใหม่โดยย้ายรูปทรงที่สองไปยังตำแหน่งแรกในคอลเลกชัน
1. บันทึกพรีเซนเทชันลงดิสก์

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # เพิ่มรูปทรงสองอันไปยังสไลด์.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # ย้ายรูปทรงที่สองไปยังตำแหน่งแรก.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **รับ Interop Shape ID**

Aspose.Slides ให้คุณดึงตัวระบุที่ไม่ซ้ำของรูปทรงในระดับสไลด์, แตกต่างจากคุณสมบัติ `unique_id` ที่เป็นเอกลักษณ์ทั่วทั้งพรีเซนเทชัน. คุณสมบัติ `office_interop_shape_id` มีอยู่ในคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) และค่าของมันตรงกับ `Id` ของอ็อบเจ็กต์ `Microsoft.Office.Interop.PowerPoint.Shape`. ตัวอย่างโค้ดด้านล่างแสดงวิธีการนี้.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # รับตัวระบุที่ไม่ซ้ำของรูปทรงภายในสไลด์.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **ตั้งค่าข้อความแทนสำหรับรูปทรง**

Aspose.Slides อนุญาตให้ผู้พัฒนาตั้งค่าข้อความแทนสำหรับรูปทรงใด ๆ. คุณสามารถใช้ข้อความแทนเพื่อระบุและค้นหารูปทรงในพรีเซนเทชัน. คุณสมบัตินี้สามารถอ่านและเขียนได้ผ่านทั้ง Aspose.Slides และ Microsoft PowerPoint. โดยการกำหนดแท็กข้อความแทนให้กับรูปทรง, คุณสามารถลบ, ซ่อน, หรือจัดลำดับใหม่ของรูปทรงเหล่านั้นในภายหลัง.

เพื่อกำหนดข้อความแทนของรูปทรง, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปทรงลงในสไลด์
1. ตั้งค่าข้อความแทน
1. บันทึกพรีเซนเทชันลงดิสก์

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # เพิ่มรูปทรง.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # ตั้งค่าข้อความแทนสำหรับรูปทรง.
    shape.alternative_text = "User Defined"
    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงรูปแบบเลเอาท์สำหรับรูปทรง**

Aspose.Slides มี API ง่าย ๆ สำหรับการเข้าถึงรูปแบบเลเอาท์ของรูปทรง. ส่วนนี้แสดงวิธีการเข้าถึงรูปแบบเลเอาท์.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **เรนเดอร์รูปทรงเป็น SVG**

Aspose.Slides รองรับการเรนเดอร์รูปทรงเป็น SVG. วิธี `write_as_svg` (และโอเวอร์โหลดต่าง ๆ) ในคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ให้คุณบันทึกเนื้อหารูปทรงเป็นไฟล์ภาพ SVG. โค้ดตัวอย่างด้านล่างแสดงวิธีส่งออกรูปทรงเป็นไฟล์ SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # รับรูปทรงแรกบนสไลด์แรก.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **จัดแนวรูปทรง**

โดยใช้วิธี `align_shape` ในคลาส [SlidesUtil](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/) คุณสามารถ:

* จัดแนวรูปทรงสัมพันธ์กับขอบของสไลด์ (ดูตัวอย่างที่ 1)
* จัดแนวรูปทรงสัมพันธ์กัน (ดูตัวอย่างที่ 2)

Enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapesalignmenttype/) กำหนดตัวเลือกการจัดแนวที่มีให้.

**ตัวอย่าง 1**

โค้ด Python นี้แสดงวิธีจัดแนวรูปทรงที่มีดัชนี 1, 2, และ 4 ไปยังขอบบนของสไลด์:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**ตัวอย่าง 2**

ตัวอย่าง Python นี้แสดงวิธีจัดแนวรูปทรงทั้งหมดในคอลเลกชันสัมพันธ์กับรูปทรงที่อยู่ด้านล่างสุดในคอลเลกชันนั้น:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **คุณสมบัติการพลิก**

ใน Aspose.Slides, คลาส [ShapeFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapeframe/) ให้การควบคุมการสะท้อนแนวราบและแนวตั้งของรูปทรงผ่านคุณสมบัติ `flip_h` และ `flip_v`. ทั้งสองเป็นประเภท [NullableBool](https://reference.aspose.com/slides/th/python-net/aspose.slides/nullablebool/) ซึ่งรับค่า `TRUE` เพื่อระบุการพลิก, `FALSE` สำหรับไม่พลิก, หรือ `NOT_DEFINED` เพื่อใช้ค่าเริ่มต้น. ค่าเหล่านี้เข้าถึงได้จาก [Frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/frame/) ของรูปทรง.

เพื่อปรับการตั้งค่าการพลิก, สร้างอินสแตนซ์ใหม่ของ [ShapeFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapeframe/) ด้วยตำแหน่งและขนาดปัจจุบันของรูปทรง, ค่าที่ต้องการสำหรับ `flip_h` และ `flip_v`, และมุมการหมุน. กำหนดอินสแตนซ์นี้ให้กับ [Frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/frame/) ของรูปทรงและบันทึกพรีเซนเทชันเพื่อใช้การแปลงสะท้อนและบันทึกผลลัพธ์ลงไฟล์เอาต์พุต.

สมมติว่าเรามีไฟล์ sample.pptx ที่สไลด์แรกมีรูปทรงเดียวที่ตั้งค่าการพลิกเป็นค่าเริ่มต้น, ดังแสดงด้านล่าง.

![The shape to be flipped](shape_to_be_flipped.png)

โค้ดตัวอย่างต่อไปนี้ดึงคุณสมบัติการพลิกปัจจุบันของรูปทรงและพลิกรูปทั้งแนวนอนและแนวตั้ง.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # ดึงคุณสมบัติการพลิกแนวนอนของรูปทรง.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # ดึงคุณสมบัติการพลิกแนวตั้งของรูปทรง.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # พลิกแนวนอนและแนวตั้ง.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The flipped shape](flipped_shape.png)

## **FAQ**

**ฉันสามารถรวมรูปทรง (union/intersect/subtract) บนสไลด์เหมือนในโปรแกรมแก้ไขเดสก์ท็อปได้หรือไม่?**

ไม่มี API การดำเนินการบูลีนในตัว. คุณสามารถทำให้คล้ายกันโดยสร้างรูปร่างขอบที่ต้องการด้วยตนเอง—เช่น คำนวนเรขาคณิตที่ได้ (ผ่าน [GeometryPath](https://reference.aspose.com/slides/th/python-net/aspose.slides/geometrypath/)) และสร้างรูปทรงใหม่ที่มีคอนทัวร์นั้น, พร้อมทางเลือกการลบรูปทรงเดิมออก.

**ฉันจะควบคุมลำดับการซ้อน (z-order) ให้รูปทรงอยู่ “บนสุด” ตลอดได้อย่างไร?**

เปลี่ยนลำดับการแทรก/ย้ายภายในคอลเลกชัน [shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/shapes/) ของสไลด์. เพื่อผลลัพธ์คาดเดาได้, ทำการสรุปลำดับ z-order หลังจากการแก้ไขสไลด์ทั้งหมดเสร็จสิ้น.

**ฉันสามารถ “ล็อก” รูปทรงเพื่อป้องกันผู้ใช้จากการแก้ไขใน PowerPoint ได้หรือไม่?**

ได้. ตั้งค่า [shape-level protection flags](/slides/th/python-net/applying-protection-to-presentation/) (เช่น ล็อกการเลือก, การเคลื่อนย้าย, การปรับขนาด, การแก้ไขข้อความ). หากต้องการ สามารถกำหนดข้อจำกัดเดียวกันบนมาสเตอร์หรือเลเอาท์. หมายเหตุว่าการป้องกันนี้เป็นระดับ UI ไม่ได้เป็นมาตรการความปลอดภัย; หากต้องการระดับความปลอดภัยที่สูงกว่า, ควรผสานกับการจำกัดระดับไฟล์เช่น [คำแนะนำให้อ่านอย่างเดียวหรือรหัสผ่าน](/slides/th/python-net/password-protected-presentation/)