---
title: "ปรับแต่งรูปร่างการนำเสนอใน Python"
linktitle: "รูปร่างกำหนดเอง"
type: docs
weight: 20
url: /th/python-net/custom-shape/
keywords:
- "รูปร่างกำหนดเอง"
- "เพิ่มรูปร่าง"
- "สร้างรูปร่าง"
- "เปลี่ยนรูปร่าง"
- "เรขาคณิตของรูปร่าง"
- "เส้นทางเรขาคณิต"
- "จุดของเส้นทาง"
- "จุดแก้ไข"
- "เพิ่มจุด"
- "ลบจุด"
- "การดำเนินการแก้ไข"
- "มุมโค้ง"
- "PowerPoint"
- "การนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างประกอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปร่างการนำเสนอใน Aspose.Slides ด้วยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต มันแสดงวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่, ดำเนินการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปร่าง

นอกจากนี้ยังสาธิตวิธีการสร้างรูปร่างแบบกำหนดเองและแบบประกอบ, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปเรขาคณิตของรูปร่างเป็นแบบปิดหรือไม่, และสกัดส่วนประกอบของรูปร่างสำหรับการวิเคราะห์คอนทัวร์

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยมจัตุรัส:

* ย้ายมุมเข้าด้านในหรือออกไปด้านนอก.
* ปรับความโค้งที่จุดหนึ่ง.
* เพิ่มจุดใหม่.

การแก้ไขจุดทำให้คุณสามารถปรับเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นพื้นฐานสำหรับรูปร่างใหม่ได้

## **เคล็ดลับการแก้ไขรูปร่าง**

![ภาพรวม](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint โปรดจำแนวคิดต่อไปนี้ไว้ในใจ:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้.
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อโดยส่วนต่าง ๆ.
* ส่วนหนึ่งอาจเป็นเส้นตรงหรือโค้ง จุดยึดและตัวควบคุมกำหนดรูปร่างของส่วนนั้น.
* จุดยึดมีอยู่ในรูปแบบจุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม, ส่วนที่ต่อกันอาจพบกันเป็นมุม.
  * ที่จุดเรียบ, ตัวควบคุมสองตัวจะอยู่ในแนวเดียวกันและห่างจากจุดยึดเท่า ๆ กัน.
  * ที่จุดตรง, ตัวควบคุมสองตัวอยู่ในแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจต่างกัน.
* การย้ายจุดยึดหรือปรับตัวควบคุมของมันจะเปลี่ยนโครงร่างของรูปร่าง.

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ให้ใช้

* ตัวอย่างของ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) แทนเส้นทางเรขาคณิตของวัตถุ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)  
* เพื่อตัวรับ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), คุณสามารถใช้เมธอด [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)  
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ให้กับรูปร่าง, คุณสามารถใช้เมธอดเหล่านี้: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) สำหรับรูปร่างที่มีเส้นทางเดียวและ [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) สำหรับรูปร่างที่มีหลายเส้นทาง.  
* เพื่อเพิ่มส่วน, คุณสามารถใช้เมธอดภายใต้ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).  
* โดยใช้คุณสมบัติ [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) และ [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต.  
* โดยใช้คุณสมบัติ [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) คุณสามารถรับเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) เป็นอาเรย์ของส่วนเส้นทาง.

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต. การอับโหลดที่รับดัชนีจะใส่ส่วนที่ตำแหน่งศูนย์ฐานในอาเรย์ของส่วนเส้นทาง.

| Operation | Method |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| เพิ่มหรือแทรกเส้นโค้งคิวบิก Bézier ที่มีจุดควบคุมสองจุดและจุดสิ้นสุด. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| เพิ่มหรือแทรกเส้นโค้งควอดราติก Bézier ที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| เพิ่มส่วนโค้งฮาล์กแบบวงรีด้วยขนาดและมุมที่กำหนดเป็นองศา. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| ปิดรูปภาพปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| ตั้งค่าจุดเริ่มต้นของรูปภาพ. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| ลบส่วนที่ตำแหน่งศูนย์ฐาน. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

ตัวอย่างนี้ใส่จุดสองจุดลงในรูปร่างสี่เหลี่ยมผืนผ้าโดยใช้ [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) และนำเส้นทางที่แก้ไขไปใช้ด้วย [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). พิกัดเป็นค่าเฉพาะของรูปร่าง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของมัน, ห่างจากซ้าย 100 จุดและจากด้านบน 50 จุด. ดัชนีส่วน 1 และ 4 วางจุดบนขอบบนและล่าง, ดึงขอบเหล่านั้นเข้าด้านใน.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![ตัวอย่าง 1](custom_shape_1.png)

## **ลบจุดออกจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยการลบส่วนที่ตำแหน่งศูนย์ฐาน 2 ด้วย [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). การนำเส้นทางที่แก้ไขไปใช้ด้วย [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) จะอัปเดตคอนทัวร์ของรูปร่าง.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```

![ตัวอย่าง 2](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุด กำหนดจุดสุดยอดและส่วนโค้ง; ขั้นที่ 72 องศาจัดให้จุดสุดยอดห้าจุดกระจายเท่า ๆ กัน. เส้นทางถูกปิดด้วย [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) และนำไปใช้กับรูปร่างสี่เหลี่ยมผืนผ้าโดยใช้ [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), แทนที่โครงร่างเดิม.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```

![ตัวอย่าง 3](custom_shape_3.png)

## **สร้างรูปร่างกำหนดเองแบบผสม**

ตัวอย่างนี้กำหนดออบเจกต์สองอันของ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ที่ปิดสำหรับสามส่วนบนและล่างของรูปร่าง. การนำสองเส้นทางไปใช้ด้วย [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) จะสร้างรูปร่างผสมเดียวที่มีช่องว่างครอบสามส่วนกลางของมัน.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```

![ตัวอย่าง 4](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองที่มีมุมโค้ง**

ตัวอย่างนี้ผสานส่วนตรงกับ [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) เพื่อสร้างรูปร่างที่มีมุมโค้งเข้าภายใน. ขนาดมุมแต่ละอันกำหนดความกว้างและความสูงของส่วนโค้งเป็นจุด, และการสวิง -90 องศาจะวาดส่วนสี่วงรีในทางหมุนทวนเข็มนาฬิกา. เส้นทางที่เสร็จสมบูรณ์ถูกนำไปใช้ด้วย [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), และการนำเสนอจะบันทึกในรูปแบบ PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าแต่ละอันลงท้ายด้วยส่วนปิดหรือไม่. มันอ่านค่า [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) และเปรียบเทียบคำสั่งของส่วนสุดท้าย [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) กับ [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่างเปล่า. การตรวจสอบนี้ดูที่คำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบทุกรูปย่อยภายในเส้นทาง. ตัวอย่างพิมพ์ค่า `True` สำหรับสี่เหลี่ยม.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **สกัดและตรวจสอบส่วนประกอบของรูปร่าง**

ใช้ [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) เพื่อทำการตรวจสอบรูปร่างที่มีอยู่เป็นส่วนประกอบที่มีจุดเส้นทางและประเภทจุด. แต่ละ [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) ที่ส่งกลับจะเปิดเผยอาเรย์ [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) และ [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) . การแสดงผลนี้เป็นประโยชน์สำหรับการวิเคราะห์คอนทัวร์หรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง.

ตัวอย่างนี้เปิดไฟล์การนำเสนอ, ค้นหารูปร่างเรขาคณิตแรกโดยตรงบนสไลด์แรก, และพิมพ์ส่วนเส้นทางของมัน. ใช้การนำเสนอที่มีรูปร่างที่มีส่วนตรงและโค้งเพื่อดูผลลัพธ์ของทั้งสองประเภท. มันไม่ได้ค้นหาภายในกลุ่ม.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # รักษาประเภทส่วน, ไม่รวมแฟล็ก.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

อาเรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` อธิบายบทบาทของมัน. ประเภท `0` เริ่มรูป, และประเภท `1` วาดเส้นจากจุดก่อนหน้าสู่จุดปัจจุบัน. ส่วนคิวบิก Bézier จะเริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` สามรายการต่อเนื่อง: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่. ลูปจะใช้รายการสามนี้ร่วมกันและตรวจสอบจุดสิ้นสุดสำหรับการปิด.

ประเภทจุดยังมีฟลักซ์. ใช้หน้ากาก `0x07` เพื่อระบุประเภทส่วน, และทดสอบ `0x80` แยกต่างหากเพื่อค้นหา subpath ที่ปิด. ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดสิ้นสุดของเส้นที่ปิด subpath, และ `131` (`0x83`) หมายถึงจุดสิ้นสุดของ Bézier ที่ปิดหนึ่ง. การเปรียบเทียบค่าเดิมเพียง `1` หรือ `3` จะพลาดกรณีเหล่านี้. ฟลักซ์อื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนพื้นฐาน.

**พิกัดและการแปลง.** จุดวัดเป็นจุด (1/72 นิ้ว), โดย X เพิ่มไปทางขวาและ Y เพิ่มลงล่าง. สำหรับรูปร่างที่ไม่ได้เป็นกลุ่ม, พิกัดที่สกัดออกมามีตำแหน่ง [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) รวมอยู่แล้วและสะท้อนความกว้างและความสูงปัจจุบันของมัน. ตัวอย่างเช่น สี่เหลี่ยมที่ยังไม่หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบคอนทัวร์ `(100, 200)`–`(220, 280)`. อย่าเพิ่มตำแหน่งของรูปร่างอีกครั้ง. ให้ลบ X และ Y ของมันเพื่อให้ได้พิกัดสัมพันธ์กับเฟรมที่ไม่ได้หมุน.

จุดที่สกัดออกมาไม่ได้ใช้การ [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) หรือการพลิกแนวนอนและแนวตั้งของรูปร่าง. เพื่อทำให้คอนทัวร์ที่แสดงตรงกัน, ให้ใช้การแปลงเหล่านั้นรอบศูนย์กลางของรูปร่าง. สำหรับรูปร่างที่เป็นกลุ่ม, ยังต้องคำนึงถึงการแมปพิกัดกลุ่มและการแปลง; อย่าสันนิษฐานว่าจุดที่สกัดเป็นพิกัดสุดท้ายบนสไลด์หรือทำการแปลงการเคลื่อนหรือสเกลซ้ำหากมันได้สะท้อนอยู่แล้วในเฟรมของลูก.

**การตรวจสอบกับการแก้ไข.** อาเรย์ที่สกัดอธิบายคอนทัวร์; การเปลี่ยนแปลงพวกมันจะไม่อัปเดตรูปร่างเดิม. เลือกวิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาเรย์จุด/ประเภท. ใช้ [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรือต้องการแก้ไขเรขาคณิตของมัน. นำเส้นทางที่แก้ไขไปใช้ผ่าน [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) หรือ [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **คำถามที่พบบ่อย**

**จะเกิดอะไรขึ้นกับการเติมสีและโครงร่างหลังจากแทนที่เรขาคณิต?**

สไตล์ยังคงอยู่กับรูปร่าง; เพียงคอนทัวร์เท่านั้นที่เปลี่ยน. การเติมสีและโครงร่างจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่.

**จะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้คุณสมบัติ [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเพราะมันผูกกับระบบพิกัดของรูปร่างเอง.

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ "ล็อค" ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออกพื้นที่ [slide](/slides/th/python-net/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/python-net/create-shape-thumbnails/) เองเป็นรูปแบบแรสเตอร์; สิ่งนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น.