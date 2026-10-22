---
title: ปรับแต่งรูปทรงการนำเสนอใน Python ผ่าน Java
linktitle: รูปทรงกำหนดเอง
type: docs
weight: 20
url: /th/python-java/custom-shape/
keywords:
- รูปทรงกำหนดเอง
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
description: "สร้างและปรับแต่งรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปทรงประกอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปทรงการนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปทรงผ่านจุดแก้ไขและเส้นทางเรขาคณิต แสดงวิธีการใช้ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) เพื่อแก้ไขรูปทรงที่มีอยู่ ทำการแก้ไขเส้นทางพื้นฐาน เพิ่มหรือเอาจุดออก และนำเรขาคณิตที่อัปเดตกลับไปใช้กับรูปทรง

มันยังแสดงวิธีการสร้างรูปทรงแบบกำหนดเองและรูปทรงประกอบ สร้างรูปทรงที่มีมุมโค้ง ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่ ตรวจสอบองค์ประกอบของรูปทรง และแปลงโครงร่างข้อความจาก Java AWT เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปทรงโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขรูปสี่เหลี่ยม:

* ย้ายมุมเข้าในหรือออกนอก
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดทำให้คุณปรับเปลี่ยนโครงร่างของรูปทรง หรือใช้รูปทรงที่มีอยู่เป็นฐานสำหรับรูปใหม่

## **เคล็ดลับการแก้ไขรูปทรง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปทรงใน PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปทรง (หรือเส้นทางของมัน) อาจเป็นแบบปิดหรือเปิด
* เส้นทางของรูปทรงประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนต่าง ๆ
* ส่วนอาจเป็นเส้นตรงหรือโค้ง จุดยึดและมือควบคุมกำหนดรูปร่างของส่วน
* จุดยึดมีอยู่ในรูปแบบของจุดมุม จุดตรง หรือจุดเรียบ:
  * ที่จุดมุม ส่วนที่เชื่อมต่ออาจมาบรรจบกันเป็นมุม
  * ที่จุดเรียบ มือควบคุมสองอันจะจัดแนวและห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง มือควบคุมสองอันจัดแนวแต่ระยะห่างจากจุดยึดอาจแตกต่างกัน
* การย้ายจุดยึดหรือปรับมือควบคุมจะเปลี่ยนโครงร่างของรูปทรง

เพื่อแก้ไขรูปทรง PowerPoint ผ่านจุดแก้ไข **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) แทนเส้นทางเรขาคณิตของวัตถุ [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) คุณสามารถใช้เมธอด [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)
* เพื่อตั้งค่า [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ให้กับรูปทรง คุณสามารถใช้เมธอดเหล่านี้: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) สำหรับรูปทรงที่มีเส้นทางเดียวและ [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) สำหรับรูปทรงที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วน คุณสามารถใช้เมธอดภายใต้ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)
* ด้วยเมธอด [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) และ [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต
* ด้วยเมธอด [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) เป็นอาร์เรย์ของส่วนเส้นทาง
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปทรงเพิ่มเติม คุณสามารถอ่าน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) แล้วทำซ้ำส่วนต่าง ๆ บน [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต เมธอดที่รับดัชนีจะทำการแทรกส่วนที่ตำแหน่งตามลำดับศูนย์ฐานในอาร์เรย์ของส่วน

| Operation | Method |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier cubic พร้อมจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier quadratic พร้อมจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| เพิ่มส่วนโค้งวงรีตามขนาดและมุมที่ระบุเป็นองศา | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| ปิดรูปแบบปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| ตั้งค่าจุดเริ่มต้นของรูปแบบ | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| ลบส่วนที่ตำแหน่งดัชนีศูนย์ฐาน | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **เพิ่มจุดกำหนดเองให้กับรูปทรง**

ตัวอย่างนี้แทรกสองจุดเข้าไปในรูปสี่เหลี่ยมโดยใช้ [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) และนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) พิกัดเป็นพิกัดภายในของรูปทรง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของรูปทรง ห่างจากด้านซ้าย 100 จุดและจากด้านบน 55 จุด ดัชนีส่วน 1 และ 4 ทำให้จุดเหล่านั้นอยู่บนขอบบนและล่าง ดึงขอบเหล่านั้นเข้าหากลาง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **ลบจุดออกจากรูปทรง**

ตัวอย่างนี้เปลี่ยนโครงร่างหัวใจโดยลบส่วนที่ตำแหน่งดัชนีศูนย์ฐาน 2 ด้วย [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) การนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) จะอัปเดตเส้นขอบของรูปทรง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **สร้างรูปทรงกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าจุดโดยใช้ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) รัศมีนอกและรัศมีในสลับกันที่ 100 และ 50 จุดกำหนดปลายและรอยแผล; การก้าว 72 องศาทำให้ดาวห้าแฉกกระจายอย่างเท่าเทียม เส้นทางถูกปิดด้วย [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) และนำไปใช้กับรูปสี่เหลี่ยมโดยใช้ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) แทนที่โครงร่างเดิม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **สร้างรูปทรงกำหนดเองแบบประกอบ**

ตัวอย่างนี้กำหนดสองอ็อบเจ็กต์ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ที่ปิดสำหรับส่วนบนและส่วนล่างของรูปทรง การนำทั้งสองเส้นทางไปใช้ด้วย [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปทรงประกอบเดียวที่มีช่องว่างอยู่ตรงกลางสามส่วนของรูปทรง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **สร้างรูปทรงกำหนดเองที่มีมุมโค้ง**

ตัวอย่างนี้ผสมส่วนตรงกับ [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) เพื่อสร้างรูปทรงที่มุมโค้งเข้าด้านใน แต่ละขนาดมุมกำหนดความกว้างและความสูงของโค้งในหน่วยจุด และการสวิง -90 องศาจะวาดส่วนหนึ่งของวงรีตามเข็มนาฬิกา เส้นทางที่เสร็จสมบูรณ์ถูกนำไปใช้ด้วย [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) และการนำเสนอจะถูกบันทึกเป็นรูปแบบ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าเส้นทางเรขาคณิตที่ไม่ว่างเปล่าทุกเส้นทางจบด้วยส่วนปิดหรือไม่ มันอ่าน [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) แล้วเปรียบเทียบคำสั่งของส่วนสุดท้ายที่ [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) กับ [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) จะคืนค่า `False` เมื่อไม่มีเส้นทางที่ไม่ว่างเปล่า การตรวจสอบนี้ดูที่คำสั่งสุดท้ายของแต่ละเส้นทาง ไม่ได้ตรวจสอบทุกส่วนย่อยภายในเส้นทาง ตัวอย่างจะแสดง `True` สำหรับสี่เหลี่ยม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **ดึงข้อมูลและตรวจสอบองค์ประกอบของรูปทรง**

ใช้ [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) เพื่อสแกนรูปทรงที่มีอยู่เป็นองค์ประกอบที่มีจุดเส้นทางและประเภทของจุด แปลงแต่ละองค์ประกอบที่ได้เป็น [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) ด้วย `jpype.JObject` เพื่อดึงอาร์เรย์ของจุดและประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) และ [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) ตัวแทนนี้มีประโยชน์สำหรับการวิเคราะห์โครงร่างหรือส่งเรขาคณิตไปยังเครื่องมือวาดภาพแบบกำหนดเอง

ตัวอย่างเปิดไฟล์ input.pptx ค้นหารูปร่างเรขาคณิตแรกที่อยู่บนสไลด์แรก แล้วพิมพ์ส่วนเส้นทางของมัน ใช้พรีเซนเทชันที่มีรูปทรงที่มีส่วนตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ไม่ได้ค้นหาภายในกลุ่ม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

อาร์เรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของมัน ประเภท `0` เริ่มรูปแบบ และประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน ส่วน Bézier cubic เริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` ติดต่อกันสามรายการ: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่ ลูปจะใช้สามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย การทำ Mask ด้วย `0x07` จะระบุประเภทส่วน และการทดสอบ `0x80` แยกออกมาจะตรวจจับส่วนย่อยที่ปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดสิ้นสุดของเส้นที่ปิดส่วนย่อย และ `131` (`0x83`) หมายถึงจุดสิ้นสุดของ Bézier ที่ปิดส่วนหนึ่ง Java เก็บแฟล็กเหล่านี้ในไบต์ที่เป็น signed; การทำ Mask จะคงค่าบิตตามที่ต้องการ การเปรียบเทียบค่าดิบเพียง `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนพื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นหน่วย point (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง สำหรับรูปทรงที่ไม่ได้อยู่ในกลุ่ม พิกัดที่ดึงออกมาจะรวมตำแหน่งที่คืนค่าโดย [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) และ [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) พร้อมกับความกว้างและความสูงปัจจุบันของมัน ตัวอย่างสี่เหลี่ยมที่ไม่หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` จะมีขอบโครงร่างเป็น `(100, 200)`–`(220, 280)` อย่าเพิ่มตำแหน่งของรูปทรงอีกครั้ง ให้ลบค่า X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่หมุน

พิกัดที่ดึงออกมาไม่ได้บังคับใช้การหมุนของรูปทรงที่คืนค่าจาก [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) หรือการพลิกแนวนอนและแนวตั้ง เพื่อทำให้โครงร่างที่แสดงผลตรงกัน ให้ทำการแปลงเหล่านั้นรอบจุดศูนย์กลางของรูปทรง สำหรับรูปทรงที่อยู่ในกลุ่ม ต้องคำนึงถึงการแมปพิกัดของกลุ่มและการแปลงด้วย อย่าสมมติว่าพิกัดที่ดึงออกมาคือพิกัดสุดท้ายบนสไลด์หรือทำการแปลหรือสเกลซ้ำหากมันได้สะท้อนไว้แล้วในกรอบของลูก

**การตรวจสอบเทียบกับการแก้ไข** อาร์เรย์ที่ดึงออกมานั้นอธิบายโครงร่าง; การเปลี่ยนแปลงอาร์เรย์เหล่านี้จะไม่อัปเดตรูปทรงต้นฉบับ ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาร์เรย์จุด/ประเภท ใช้ [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปทรงหรือเมื่อต้องการแก้ไขเรขาคณิตของมัน แล้วนำเส้นทางที่แก้ไขไปใช้ผ่าน [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) หรือ [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)

## **แปลง Java AWT Shape เป็น GeometryPath**

ตัวอย่างนี้รวมโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต เมธอด [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) ของโครงร่างทำให้ไม่เติมสี [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างโครงร่างข้อความใน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) โดย [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) จะส่งส่วนการย้าย, เส้น, quadratic, cubic, และส่วนปิด ซึ่งตัวอย่างจะทำซ้ำส่วนเหล่านี้บน [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)

ข้อความใช้ฟอนต์ Arial ขนาด 40 จุด โครงร่างเลื่อนแนวนอน 20 จุดและจัดตำแหน่งให้ด้านบนของรูปแบบอยู่ 10 จุดใต้ขอบบนของรูปทรง ส่วนเส้นทางข้อความจะถูกเติมสี ส่วนสี่เหลี่ยมดั้งเดิมยังคงเป็นโครงร่างเท่านั้น การนำทั้งสองเส้นทางไปใช้ด้วย [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปทรงเดียวที่ประกอบด้วยสี่เหลี่ยมและข้อความ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # รับเส้นทางเรขาคณิตของรูปทรง
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # สร้างกราฟิกพาธใหม่ด้วยข้อความ
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # แปลงกราฟิกพาธเป็นเส้นทางเรขาคณิต
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # นำพาธข้อความไปใช้พร้อมกับพาธเรขาคณิตดั้งเดิม
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**อะไรจะเกิดขึ้นกับการเติมสีและโครงร่างหลังจากเปลี่ยนเรขาคณิต?**

สไตล์จะคงอยู่กับรูปทรง; มีเพียงโครงร่างที่เปลี่ยน การเติมสีและโครงร่างจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่

**ฉันจะหมุนรูปทรงกำหนดเองพร้อมกับเรขาคณิตได้อย่างถูกต้องอย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) ของรูปทรง; เรขาคณิตจะหมุนพร้อมกับรูปทรงเนื่องจากผูกกับระบบพิกัดของรูปทรงเอง

**ฉันสามารถแปลงรูปทรงกำหนดเองเป็นภาพเพื่อ “ล็อค” ผลลัพธ์ได้หรือไม่?**

ได้ ส่งออกพื้นที่ [slide](/slides/th/python-java/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/python-java/create-shape-thumbnails/) เองเป็นรูปแบบเรสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น