---
title: ปรับแต่งรูปทรงการนำเสนอใน Python
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/python-net/custom-shape/
keywords:
- รูปร่างกำหนดเอง
- เพิ่มรูปทรง
- สร้างรูปทรง
- เปลี่ยนรูปทรง
- เรขาคณิตรูปทรง
- เส้นทางเรขาคณิต
- จุดเส้นทาง
- จุดแก้ไข
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและปรับแต่งรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET: เส้นทางเรขาคณิต, มุมโค้ง, รูปทรงผสม."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปทรงการนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปทรงผ่านจุดแก้ไขและเส้นทางเรขาคณิต. มันแสดงวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) เพื่อแก้ไขรูปทรงที่มีอยู่, ทำการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปทรง.

มันยังสาธิตวิธีสร้างรูปทรงแบบกำหนดเองและแบบผสม, สร้างรูปทรงที่มีมุมโค้ง, ตรวจสอบว่ารูปทรงเรขาคณิตย์เป็นปิดหรือไม่, และสกัดส่วนประกอบของรูปทรงสำหรับการวิเคราะห์โค้ง.

## **เปลี่ยนรูปทรงโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมเข้าไปหรือออกจากศูนย์.
* ปรับความโค้งที่จุดใดจุดหนึ่ง.
* เพิ่มจุดใหม่.

การแก้ไขจุดช่วยให้คุณปรับเปลี่ยนโครงร่างของรูปทรงหรือใช้รูปทรงที่มีอยู่เป็นฐานสำหรับรูปใหม่.

## **เคล็ดลับการแก้ไขรูปทรง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปทรงใน PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปทรง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิด.
* เส้นทางของรูปทรงประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนเส้น.
* ส่วนเส้นสามารถเป็นตรงหรือโค้ง. จุดยึดและตัวควบคุมกำหนดรูปร่างของมัน.
* จุดยึดมีอยู่เป็นจุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม, ส่วนเส้นที่ต่อกันสามารถพบกันที่มุม.
  * ที่จุดเรียบ, ตัวควบคุมสองตัวจะอยู่ในแนวเดียวกันและห่างจากจุดยึดเท่ากัน.
  * ที่จุดตรง, ตัวควบคุมสองตัวอยู่ในแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจต่างกัน.
* การย้ายจุดยึดหรือปรับตัวควบคุมจะเปลี่ยนโครงร่างของรูปทรง.

เพื่อแก้ไขรูปทรง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) แสดงถึงเส้นทางเรขาคณิตของอ็อบเจกต์ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), คุณสามารถใช้เมธอด [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ให้กับรูปทรง, คุณสามารถใช้เมธอดเหล่านี้: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) สำหรับรูปทรงที่มีเส้นทางเดียวและ [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) สำหรับรูปทรงที่มีหลายเส้นทาง.
* เพื่อเพิ่มส่วนเส้น, คุณสามารถใช้เมธอดภายใต้ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* โดยใช้คุณสมบัติ [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) และ [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต.
* ด้วยคุณสมบัติ [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) เป็นอาเรย์ของส่วนเส้น.

## **การดำเนินการแก้ไขง่ายๆ**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต. การโอเวอร์โหลดที่รับดัชนีจะใส่ส่วนเส้นที่ตำแหน่งนั้นในอาเรย์ส่วนเส้นของเส้นทางโดยใช้ดัชนีเริ่มจากศูนย์.

| การดำเนินการ | วิธี |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| เพิ่มหรือแทรกโค้ง Bézier แบบคิวบิกที่มีจุดควบคุมสองจุดและจุดสิ้นสุด. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| เพิ่มหรือแทรกโค้ง Bézier แบบควอดราติกที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| เพิ่มส่วนโค้งวงรีโดยระบุขนาดและมุมเป็นองศา. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| ปิดรูปภาพปัจจุบันโดยเชื่อมต่อจุดสิ้นสุดกับจุดเริ่มต้น. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| ตั้งค่าจุดเริ่มต้นของรูปภาพ. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| ลบส่วนเส้นที่ตำแหน่งดัชนีเริ่มจากศูนย์. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **เพิ่มจุดกำหนดเองให้กับรูปทรง**

ตัวอย่างนี้แทรกสองจุดเข้าไปในรูปสี่เหลี่ยมโดยใช้ [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) และนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). พิกัดเป็นค่าท้องถิ่นของรูปทรง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลาง, ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด. ดัชนีส่วนเส้น 1 และ 4 ทำให้จุดเหล่านั้นอยู่บนขอบบนและล่าง, ดึงขอบเหล่านั้นเข้ามา.

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

![example1_image](custom_shape_1.png)

## **ลบจุดจากรูปทรง**

ตัวอย่างนี้เปลี่ยนครอบรูปร่างหัวใจโดยลบส่วนเส้นที่ดัชนีเริ่มจากศูนย์ 2 ด้วย [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). การนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) จะอัปเดตโครงร่างของรูปทรง.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **สร้างรูปทรงกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดจุดยอดและช่องเว้า; ขั้น 72 องศาทำให้จุดยอดห้าแฉกกระจายอย่างสม่ำเสมอ. เส้นทางถูกปิดด้วย [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) และนำไปใช้กับรูปสี่เหลี่ยมโดยใช้ [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), แทนที่โครงร่างเดิม.

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
![example3_image](custom_shape_3.png)

## **สร้างรูปทรงกำหนดเองแบบผสม**

ตัวอย่างนี้กำหนดสองอ็อบเจกต์ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ปิดสำหรับส่วนบนและส่วนล่างของรูปทรง. การนำสองเส้นทางไปใช้พร้อมกันด้วย [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) จะสร้างรูปทรงผสมเดียวที่มีช่องว่างครึ่งกลาง.

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
![example4_image](custom_shape_4.png)

## **สร้างรูปทรงกำหนดเองที่มุมโค้ง**

ตัวอย่างนี้ผสมส่วนเส้นตรงกับ [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) เพื่อสร้างรูปทรงที่มุมโค้งเข้าด้านใน. ขนาดแต่ละมุมกำหนดความกว้างและความสูงของส่วนโค้งเป็นจุด, และการสวิง -90 องศาวาดวงรีสี่เหลี่ยมส่วนที่อายุแต่งตามเข็มนาฬิกา. เส้นทางที่เสร็จสมบูรณ์ถูกนำไปใช้ด้วย [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), แล้วบันทึกการนำเสนอเป็นรูปแบบ PPTX.

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

## **ตรวจสอบว่ารูปทรงเรขาคณิตเป็นแบบปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างสิ้นสุดด้วยส่วนเส้นปิดหรือไม่. มันอ่านค่า [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) และเปรียบเทียบคำสั่งของส่วนเส้นสุดท้ายกับ [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) ที่เป็น [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่าง. การตรวจสอบนี้ตรวจสอบคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบทุกส่วนย่อยภายในเส้นทาง. ตัวอย่างพิมพ์ `True` สำหรับสี่เหลี่ยม.

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

## **ตรวจสอบคำสั่งของ Geometry Path**

ดาวน์โหลดไฟล์ [contour.pptx](contour.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของคุณ. รูปทรงแรกบนสไลด์แรกมีขอบบนตรง, โค้ง Bézier แบบคิวบิก, และขอบปิดตรง. ใช้เมธอด [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) เพื่ออ่านเส้นทางของมัน. สำหรับแต่ละเส้นทาง, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) จะ列出ส่วนเส้นตามลำดับการวาด. คำสั่งของส่วนเส้นแต่ละอันที่ [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) จะกำหนดวิธีการแปลความหมายของ [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

รูปทรงตั้งอยู่ที่ (200, 100) จุดบนสไลด์. ค่าพิกัดที่รายงานเป็นค่าท้องถิ่นของรูปทรง. มุมบนซ้ายของมันเป็น (0, 0), ค่า x เพิ่มไปทางขวา, ค่า y เพิ่มลงล่าง. ส่วนเส้นปิดจะย้อนกลับไปยังจุดเริ่มต้นโดยไม่มีพิกัดเพิ่ม.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **สกัดและตรวจสอบส่วนประกอบของรูปทรง**

ใช้เมธอด [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) เพื่อสกัดรูปทรงที่มีอยู่เป็นส่วนประกอบที่บรรจุดเส้นทางและชนิดจุด. แต่ละ [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) ที่คืนค่าจะแสดงอาเรย์ [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) และ [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์โค้งหรือการส่งเรขาคณิตไปยังเครื่องมือวาดภาพแบบกำหนดเอง.

ตัวอย่างเปิดไฟล์พรีเซนเทชัน, ค้นหารูปทรงเรขาคณิตแรกบนสไลด์แรก, และพิมพ์ส่วนเส้นของมัน. ใช้พรีเซนเทชันที่มีรูปทรงที่มีส่วนเส้นตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท. มันจะไม่ค้นหาภายในกลุ่ม.

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
                point_type = types[i] & 0x07  #  เก็บประเภทส่วนเส้น, ไม่รวมธง.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  #  ใช้จุดควบคุมทั้งสองและจุดสิ้นสุด.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

อาเรย์สอดคล้องตามดัชนี: `points[i]` เป็นจุดและ `types[i]` บรรยายบทบาทของมัน. ชนิด `0` เริ่มรูปภาพ, ชนิด `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน. ส่วนเส้น Bézier แบบคิวบิกเริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการชนิด `3` สามรายการต่อเนื่อง: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่. ลูปจะรับสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดว่าปิดหรือไม่.

ชนิดจุดยังมีธง. ใช้การมาสก์ `0x07` เพื่อระบุชนิดส่วนเส้น, และทดสอบ `0x80` แยกต่างหากเพื่อตรวจจับเส้นทางย่อยที่ปิด. ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดสิ้นสุดของเส้นที่ปิดเส้นทางย่อย, และ `131` (`0x83`) หมายถึงจุดสิ้นสุดของ Bézier ที่ปิดเส้นทาง. การเปรียบเทียบค่าดิบเพียงกับ `1` หรือ `3` จะทำให้พลาดกรณีเหล่านี้. ธงอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนชนิดส่วนเส้นพื้นฐาน.

**พิกัดและการแปลง.** จุดวัดเป็น points (1/72 นิ้ว), โดย X เพิ่มไปทางขวาและ Y เพิ่มลงล่าง. สำหรับรูปทรงที่ไม่ได้จัดกลุ่ม, พิกัดที่สกัดออกมาได้รวมตำแหน่ง [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) ของมันแล้วและสะท้อนความกว้างและความสูงปัจจุบัน. ตัวอย่างเช่น สี่เหลี่ยมที่ไม่หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบโค้ง `(100, 200)`–`(220, 280)`. อย่าเพิ่มตำแหน่งของรูปทรงอีกครั้ง. ให้ลบค่า X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน.

จุดที่สกัดจะไม่รวมการแปลง [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) หรือการพลิกแนวนอนและแนวตั้งของรูปทรง. หากต้องการแสดงโค้งที่เห็นได้, ให้ทำการแปลงเหล่านั้นรอบศูนย์กลางของรูปทรง. สำหรับรูปทรงที่อยู่ในกลุ่ม, ต้องคำนึงถึงการแมปพิกัดของกลุ่มและการแปลงเหล่านั้น; อย่าสันนิษฐานว่าจุดที่สกัดเป็นพิกัดสุดท้ายบนสไลด์หรือทำการแปลหรือสเกลซ้ำหากมันได้สะท้อนอยู่แล้วในกรอบของลูก.

**การตรวจสอบเทียบกับการแก้ไข.** อาเรย์ที่สกัดบรรยายโค้ง; การเปลี่ยนแปลงอาเรย์เหล่านี้จะไม่อัปเดตรูปทรงต้นฉบับ. ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาเรย์จุด/ชนิด. ใช้เมธอด [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปทรงหรืออยากแก้ไขเรขาคณิตของมัน. นำเส้นทางที่แก้ไขไปใช้ผ่าน [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) หรือ [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **คำถามที่พบบ่อย**

**สิ่งที่จะเกิดขึ้นกับการเติมสีและเส้นขอบหลังจากเปลี่ยนเรขาคณิตคืออะไร?**

สไตล์ยังคงอยู่กับรูปทรง; เพียงโครงร่างเท่านั้นที่เปลี่ยน. การเติมสีและเส้นขอบจะถูกใช้โดยอัตโนมัติกับเรขาคณิตใหม่.

**ฉันจะหมุนรูปทรงกำหนดเองพร้อมกับเรขาคณิตย์อย่างถูกต้องได้อย่างไร?**

ใช้คุณสมบัติ [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) ของรูปทรง; เรขาคณิตย์จะหมุนตามรูปทรงเนื่องจากผูกไว้กับระบบพิกัดของรูปทรงเอง.

**ฉันสามารถแปลงรูปทรงกำหนดเองเป็นภาพเพื่อ “ล็อก” ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออก [slide](/slides/th/python-net/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/python-net/create-shape-thumbnails/) เองเป็นรูปแบบแรสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น.