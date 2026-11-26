---
title: ปรับแต่งรูปร่างการนำเสนอใน Python ผ่าน Java
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/python-java/custom-shape/
keywords: 
- รูปร่างกำหนดเอง
- เพิ่มรูปร่าง
- สร้างรูปร่าง
- เปลี่ยนรูปร่าง
- เรขาคณิตของรูปร่าง
- เส้นทางเรขาคณิต
- จุดของเส้นทาง
- จุดแก้ไข
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างแบบผสม."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปร่างในการนำเสนอใน Aspose.Slides โดยการแก้ไขรูปทรงของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต มันแสดงวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่, ทำการแก้ไขเส้นทางขั้นพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปร่าง

นอกจากนี้ยังสาธิตวิธีการสร้างรูปร่างกำหนดเองและแบบผสม, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นปิดหรือไม่, ตรวจสอบส่วนประกอบของรูปร่าง, และแปลงเส้นขอบข้อความของ Java AWT ให้เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมเข้าไปหรือออกไป
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดช่วยให้คุณปรับเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นฐานสำหรับรูปร่างใหม่ได้

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อตัดแก้รูปร่างใน PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนต่าง ๆ
* ส่วนหนึ่งอาจเป็นเส้นตรงหรือเส้นโค้ง จุดยึดและตัวควบคุมกำหนดรูปทรงของมัน
* จุดยึดมีสามประเภท: จุดมุม, จุดตรง, หรือจุดเรียบ
  * ที่จุดมุม ส่วนที่เชื่อมต่ออาจตัดกันเป็นมุม
  * ที่จุดเรียบ ตัวควบคุมสองตัวจะเรียงตรงและอยู่ระยะห่างเท่ากันจากจุดยึด
  * ที่จุดตรง ตัวควบคุมสองตัวเรียงตรงแต่ระยะห่างอาจแตกต่างกัน
* การย้ายจุดยึดหรือปรับตัวควบคุมจะเปลี่ยนโครงร่างของรูปร่าง

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** ให้คลาส [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)

* ตัวอย่าง [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) แทนเส้นทางเรขาคณิตของวัตถุ [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) จากอินสแตนซ์ [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), ใช้เมธอด [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ให้กับรูปร่าง, ใช้เมธอด [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) สำหรับรูปร่างที่มีเส้นทางเดียวและ [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วนต่าง ๆ, สามารถใช้เมธอดต่าง ๆ ภายใต้ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)
* ด้วยเมธอด [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) และ [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) คุณสามารถกำหนดลักษณะการวาดของเส้นทางเรขาคณิตได้
* ด้วยเมธอด [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) เป็นอาเรย์ของส่วนเส้นได้
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตเพิ่มเติม, สามารถอ่าน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) แล้วทำซ้ำส่วนต่าง ๆ บน [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การโอเวอร์โหลดที่รับดัชนีจะใส่ส่วนเส้นที่ตำแหน่งนั้นในอาเรย์ส่วนเส้นของเส้นทาง

| การดำเนินการ | เมธอด |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบลูกบาศก์ที่มีจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบควอดราติกที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| เพิ่มโค้งรูปวงรีตามขนาดและมุมที่ระบุ (องศา) | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| ปิดรูปภาพปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| ตั้งค่าจุดเริ่มต้นของรูปภาพ | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| ลบส่วนเส้นที่ตำแหน่งดัชนีศูนย์ | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

ตัวอย่างนี้ใส่สองจุดลงในรูปร่างสี่เหลี่ยมโดยใช้ [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) และนำเส้นทางที่แก้ไขแล้วไปใช้กับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) พิกัดเป็นค่าท้องถิ่นของรูปร่าง: จุดใหม่สองจุดอยู่ที่ศูนย์กลางของรูปร่าง, ห่างจากด้านซ้าย 100 พ้อยnts และจากด้านบน 50 พ้อยnts ดัชนีส่วนเส้น 1 และ 4 วางจุดเหล่านี้บนขอบบนและขอบล่าง, ดึงขอบเหล่านั้นเข้าไป

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

## **ลบจุดออกจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างหัวใจโดยลบส่วนเส้นที่ดัชนีศูนย์ 2 ด้วย [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) การใช้เส้นทางที่แก้ไขแล้วกับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) จะอัปเดตโครงร่างของรูปร่าง

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

## **สร้างรูปร่างกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกโดยใช้ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) รัศมีนอกและรัศมีในสลับกันที่ 100 และ 50 พ้อยnts เพื่อกำหนดปลายและช่องเว้น; การก้าว 72° ทำให้ดาวห้าแฉกกระจายเท่า ๆ กัน เส้นทางถูกปิดด้วย [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) และนำไปใช้กับสี่เหลี่ยมโดยใช้ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) แทนที่โครงร่างเดิม

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

## **สร้างรูปร่างกำหนดเองแบบผสม**

ตัวอย่างนี้กำหนดสองอ็อบเจกต์ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ปิดสำหรับส่วนบนและส่วนล่างของรูปร่าง การใช้ทั้งสองเส้นทางพร้อมกันด้วย [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างผสมเดียวที่มีช่องว่างตรงกลางส่วนที่สามของรูปร่าง

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

## **สร้างรูปร่างกำหนดเองด้วยมุมโค้ง**

ตัวอย่างนี้ผสมส่วนเส้นตรงกับ [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) เพื่อสร้างรูปร่างที่มุมโค้งเข้าด้านใน แต่ละขนาดมุมกำหนดความกว้างและความสูงของโค้งเป็นพ้อยnts, และการสวิง -90° วาดส่วนสี่เหลี่ยมเอ็มลิปส์แบบทวนเข็มนาฬิกา เส้นทางที่สมบูรณ์ถูกนำไปใช้ด้วย [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) และงานนำเสนอจะถูกบันทึกเป็นรูปแบบ PPTX

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

## **ตรวจสอบว่ารูปร่าง Geometry ปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าเส้นทางเรขาคณิตที่ไม่ว่างทั้งหมดจบด้วยส่วนเส้นปิดหรือไม่ มันอ่าน [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) แล้วเปรียบเทียบคำสั่งของส่วนสุดท้าย [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) กับ [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) หากไม่มีเส้นทางที่ไม่ว่าง จะคืนค่า `False` การตรวจสอบนี้ดูคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบทุกส่วนย่อยภายในเส้นทาง ตัวอย่างจะแสดง `True` สำหรับสี่เหลี่ยม

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

## **ตรวจสอบคำสั่ง Geometry Path**

ดาวน์โหลดไฟล์ [contour.pptx](contour.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน รูปแรกบนสไลด์แรกมีขอบด้านบนตรง, เส้นโค้ง Bézier แบบลูกบาศก์, และขอบปิดแบบตรง ใช้เมธอด [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) เพื่ออ่านเส้นทางของรูปร่างและ [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) เพื่ออ่านส่วนเส้นของแต่ละเส้นทางตามลำดับการวาด สำหรับแต่ละส่วนเส้น, เมธอด [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) จะระบุคำสั่งและบ่งบอกวิธีการตีความค่าที่คืนจาก [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

รูปร่างอยู่ที่ตำแหน่ง (200, 100) พ้อยnts บนสไลด์ พิกัดที่รายงานเป็นค่าท้องถิ่นของรูปร่าง, โดย (0, 0) อยู่ที่มุมซ้ายบน, x เพิ่มไปทางขวา, และ y เพิ่มลงด้านล่าง ส่วนเส้นปิดจะกลับไปยังจุดเริ่มต้นโดยไม่มีพิกัดเพิ่มเติม

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **ดึงและตรวจสอบองค์ประกอบรูปร่าง**

ใช้เมธอด [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) เพื่อตรวจสอบรูปร่างที่มีอยู่เป็นองค์ประกอบที่บรรจุดทางและประเภทของจุด แปลงแต่ละองค์ประกอบที่คืนเป็น [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) ด้วย `jpype.JObject` เพื่อดึงอาเรย์ของจุดและประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) และ [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์คอนทัวร์หรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิดไฟล์ input.pptx, ค้นหา GeometryShape แรกบนสไลด์แรกโดยตรง, แล้วพิมพ์ส่วนเส้นของมัน ใช้งานไฟล์นำเสนอที่มีรูปร่างที่มีส่วนเส้นตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ไม่ได้ค้นหาภายในกลุ่ม

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

อาเรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` ระบุบทบาทของจุดนั้น ประเภท `0` เริ่มรูปภาพ, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน ส่วนเส้น Bézier ลูกบาศก์เริ่มจากจุดปลายก่อนหน้าและใช้รายการประเภท `3` สามรายการต่อเนื่อง: สองจุดควบคุมตามด้วยจุดสิ้นสุดใหม่ ลูปจะอ่านสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย ให้ทำมาสก์ด้วย `0x07` เพื่อระบุประเภทส่วนเส้น, และทดสอบ `0x80` แยกต่างหากเพื่อค้นหาส่วนย่อยที่ปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดปลายของเส้นที่ปิดส่วนย่อย, `131` (`0x83`) หมายถึงจุดปลายของ Bézier ที่ปิดส่วนย่อย Java เก็บแฟล็กเหล่านี้ในไบต์ที่เป็น signed; การทำมาสก์จะรักษาค่าบิตตามที่ตั้งใจ การเปรียบเทียบค่าดิบเพียง `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่ส่งผลต่อประเภทส่วนพื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นพ้อยnts (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง สำหรับรูปร่างที่ไม่ได้อยู่ในกลุ่ม, พิกัดที่ดึงออกมาจะรวมตำแหน่งที่คืนจากเมธอด [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) และ [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) และสะท้อนความกว้างและความสูงปัจจุบันของมัน ตัวอย่างเช่น สี่เหลี่ยมที่ไม่ได้หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบคอนทัวร์ `(100, 200)`–`(220, 280)` ไม่ต้องเพิ่มตำแหน่งของรูปร่างอีกครั้ง ให้ลบ X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน

จุดที่ดึงออกมาไม่ได้พิจารณาการหมุนของรูปร่างที่คืนจากเมธอด [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) หรือการพลิกแนวนอน/แนวตั้ง เพื่อสร้างคอนทัวร์ที่แสดงจริง ให้ทำการแปลงเหล่านี้รอบศูนย์กลางของรูปร่าง สำหรับรูปร่างในกลุ่มต้องคำนึงถึงการแมปพิกัดของกลุ่มและการแปลง; อย่าสมมติว่าจุดที่ดึงออกมาเป็นพิกัดสุดท้ายบนสไลด์ หรือทำการแปลงหรือสเกลสองครั้งหากมันถูกสะท้อนแล้วในกรอบของลูก

**การตรวจสอบเทียบกับการแก้ไข** อาเรย์ที่ดึงออกมานำเสนอคอนทัวร์; การเปลี่ยนแปลงอาเรย์เหล่านี้จะไม่อัปเดตรูปร่างเดิม ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาเรย์จุด/ประเภท ใช้เมธอด [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) หากคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดของรูปร่างหรืออยากแก้ไขเรขาคณิตของมัน แล้วใช้เส้นทางที่แก้ไขผ่านเมธอด [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) หรือ [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)

## **แปลง Java AWT Shape เป็น GeometryPath**

ตัวอย่างนี้ผสานโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต วิธี `setFillMode` ของโครงร่างถูกใช้เพื่อปิดการเติมสี [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างโครงร่างข้อความใน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ตัว [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) ให้ข้อมูลการย้าย, เส้น, โค้งควอดราติก, โค้งลูกบาศก์, และส่วนปิด ซึ่งตัวอย่างจะทำซ้ำบน [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)

ข้อความใช้ฟอนต์ Arial ขนาด 40 พ้อยnts โครงร่างถูกย้าย 20 พ้อยnts แนวนอนและวางให้ด้านบนของรูปภาพอยู่ 10 พ้อยnts ต่ำกว่าเส้นบนของรูปร่าง โครงร่างของข้อความถูกเติมสี ในขณะที่สี่เหลี่ยมต้นฉบับคงเป็นเพียงเส้นขอบ การใช้ทั้งสองเส้นทางร่วมกับเมธอด [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างเดียวที่ประกอบด้วยสี่เหลี่ยมและข้อความ

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

    # รับเส้นทางเรขาคณิตของรูปร่าง.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # สร้างกราฟิกพาธใหม่ด้วยข้อความ.
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

    # แปลงกราฟิกพาธเป็นเส้นทางเรขาคณิต.
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

    # นำพาธข้อความไปใช้พร้อมกับเส้นทางเรขาคณิตเดิม.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **คำถามที่พบบ่อย**

**อะไรจะเกิดขึ้นกับการเติมสีและเส้นขอบหลังจากแทนที่เรขาคณิต?**

สไตล์ยังคงอยู่กับรูปร่าง; เพียงแค่คอนทัวร์เปลี่ยนแปลง การเติมสีและเส้นขอบจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเนื่องจากมันผูกกับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นรูปภาพเพื่อ “ล็อก” ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออก [slide](/slides/th/python-java/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/python-java/create-shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; วิธีนี้ช่วยลดความซับซ้อนเมื่อทำงานต่อกับเรขาคณิตที่ซับซ้อน.