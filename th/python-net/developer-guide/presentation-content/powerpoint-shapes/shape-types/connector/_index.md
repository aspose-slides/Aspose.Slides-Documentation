---
title: จัดการคอนเน็กเตอร์ในงานนำเสนอด้วย Python
linktitle: คอนเน็กเตอร์
type: docs
weight: 10
url: /th/python-net/connector/
keywords:
- คอนเน็กเตอร์
- ประเภทคอนเน็กเตอร์
- จุดคอนเน็กเตอร์
- เส้นคอนเน็กเตอร์
- มุมคอนเน็กเตอร์
- เชื่อมโยงรูปร่าง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มความสามารถให้แอป Python วาด เชื่อมต่อ และกำหนดเส้นอัตโนมัติในสไลด์ PowerPoint และ OpenDocument — ควบคุมคอนเน็กเตอร์ตรง พับและโค้งได้เต็มที่"
---
## **บทนำ**

คอนเน็กเตอร์ของ PowerPoint คือเส้นพิเศษที่เชื่อมระหว่างรูปร่างสองรูป และคงการแนบไว้เมือรูปถูกย้ายหรือปรับตำแหน่งบนสไลด์ คอนเน็กเตอร์จะเชื่อมต่อกับ **จุดเชื่อมต่อ** (จุดสีเขียว) บนรูปร่าง จุดเชื่อมต่อจะปรากฏเมื่อเคอร์เซอร์เข้าใกล้ **ตัวจัดการการปรับ** (จุดสีเหลือง) ที่มีในคอนเน็กเตอร์บางประเภท ช่วยให้คุณปรับตำแหน่งและรูปร่างของคอนเน็กเตอร์ได้

## **ประเภทคอนเน็กเตอร์**

ใน PowerPoint คุณสามารถใช้คอนเน็กเตอร์ได้สามประเภท: เส้นตรง, พับ (มุม) และโค้ง

Aspose.Slides รองรับประเภทคอนเน็กเตอร์ต่อไปนี้:

| ประเภทคอนเน็กเตอร์ | รูปภาพ | จำนวนจุดปรับ |
| ------------------- | ------- | ------------ |
| `ShapeType.LINE` | ![ตัวเชื่อมเส้นตรง](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![ตัวเชื่อมตรง 1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![ตัวเชื่อมโค้ง 2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![ตัวเชื่อมโค้ง 3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![ตัวเชื่อมโค้ง 4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![ตัวเชื่อมโค้ง 5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![ตัวเชื่อมโค้ง 2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![ตัวเชื่อมโค้ง 3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![ตัวเชื่อมโค้ง 4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![ตัวเชื่อมโค้ง 5](shapetype.curvedconnector5.png) | 3 |

## **เชื่อมโยงรูปร่างด้วยคอนเน็กเตอร์**

ส่วนนี้แสดงวิธีเชื่อมรูปร่างด้วยคอนเน็กเตอร์ใน Aspose.Slides คุณจะเพิ่มคอนเน็กเตอร์ลงในสไลด์แล้วแนบจุดเริ่มต้นและจุดสิ้นสุดกับรูปร่างเป้าหมาย การใช้จุดเชื่อมต่อทำให้คอนเน็กเตอร์ “ติด” กับรูปร่างแม้เมื่อรูปร่างย้ายหรือเปลี่ยนขนาด

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. ดึงอ้างอิงสไลด์ตามดัชนี  
1. เพิ่มสองอ็อบเจ็กต์[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์โดยใช้เมธอด`add_auto_shape`ของอ็อบเจ็กต์[ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/)  
1. เพิ่มคอนเน็กเตอร์โดยใช้เมธอด`add_connector`ของอ็อบเจ็กต์[ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/)และระบุประเภทคอนเน็กเตอร์  
1. เชื่อมรูปร่างด้วยคอนเน็กเตอร์  
1. เรียกเมธอด`reroute`เพื่อให้คอนเน็กเตอร์ใช้เส้นทางสั้นที่สุด  
1. บันทึกไฟล์พรีเซนเทชัน  

โค้ด Python ด้านล่างแสดงวิธีเพิ่มคอนเน็กเตอร์โค้งระหว่างรูปร่างสองรูป (วงรีและสี่เหลี่ยม):

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อสร้างไฟล์ PPTX.
with slides.Presentation() as presentation:

    # เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์แรก.
    shapes = presentation.slides[0].shapes

    # เพิ่ม AutoShape รูปร่างวงรี.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # เพิ่ม AutoShape รูปสี่เหลี่ยม.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # เพิ่มคอนเน็กเตอร์ลงในสไลด์.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # เชื่อมต่อรูปร่างด้วยคอนเน็กเตอร์.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # เรียก reroute เพื่อกำหนดเส้นทางสั้นที่สุด.
    connector.reroute()

    # บันทึกงานนำเสนอ.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
เมธอด`connector.reroute`จะทำการกำหนดเส้นทางใหม่ให้คอนเน็กเตอร์โดยบังคับให้ใช้เส้นทางสั้นที่สุดระหว่างรูปร่าง เมธอดนี้อาจเปลี่ยนค่า`start_shape_connection_site_index`และ`end_shape_connection_site_index`ได้
{{% /alert %}}

## **ระบุจุดเชื่อมต่อ**

ส่วนนี้อธิบายวิธีแนบคอนเน็กเตอร์กับจุดเชื่อมต่อเฉพาะบนรูปร่างใน Aspose.Slides โดยการกำหนดจุดเชื่อมต่อที่แม่นยำ คุณสามารถควบคุมการกำหนดเส้นทางและการจัดวางคอนเน็กเตอร์ ทำให้ไดอะแกรมในพรีเซนเทชันของคุณดูเรียบร้อยและคาดเดาได้

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. ดึงอ้างอิงสไลด์ตามดัชนี  
1. เพิ่มสองอ็อบเจ็กต์[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์โดยใช้เมธอด`add_auto_shape`ของอ็อบเจ็กต์[ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/)  
1. เพิ่มคอนเน็กเตอร์โดยใช้เมธอด`add_connector`ของอ็อบเจ็กต์[ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/)และระบุประเภทคอนเน็กเตอร์  
1. เชื่อมรูปร่างด้วยคอนเน็กเตอร์  
1. ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปร่าง  
1. บันทึกไฟล์พรีเซนเทชัน  

โค้ด Python ด้านล่างแสดงวิธีระบุจุดเชื่อมต่อที่ต้องการ:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อสร้างไฟล์ PPTX.
with slides.Presentation() as presentation:

    # เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์แรก.
    shapes = presentation.slides[0].shapes

    # เพิ่ม AutoShape รูปวงรี.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # เพิ่ม AutoShape รูปสี่เหลี่ยม.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # เพิ่มคอนเน็กเตอร์ลงในคอลเลกชันรูปร่างของสไลด์.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # เชื่อมต่อรูปร่างด้วยคอนเน็กเตอร์.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # กำหนดดัชนีไซต์เชื่อมต่อที่ต้องการบนรูปวงรี.
    site_index = 6

    # ตรวจสอบว่าดัชนีที่ต้องการอยู่ในจำนวนไซต์ที่มีอยู่.
    if  ellipse.connection_site_count > site_index:
        # กำหนดไซต์เชื่อมต่อที่ต้องการบน AutoShape วงรี.
        connector.start_shape_connection_site_index = site_index

    # บันทึกงานนำเสนอ.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **ปรับจุดคอนเน็กเตอร์**

คุณสามารถแก้ไขคอนเน็กเตอร์ได้โดยใช้จุดปรับค่า จุดปรับค่าเฉพาะคอนเน็กเตอร์ที่เปิดให้ปรับได้เท่านั้นที่สามารถแก้ไขได้ ดูตารางในส่วน[ประเภทคอนเน็กเตอร์](/slides/th/python-net/connector/#connector-types)เพื่อทราบว่าคอนเน็กเตอร์ใดรองรับการปรับค่า

### **กรณีง่าย**

พิจารณากรณีที่คอนเน็กเตอร์ระหว่างรูปร่างสองรูป (A และ B) ตัดกับรูปร่างที่สาม (C):

![การกีดขวางคอนเน็กเตอร์](connector-obstruction.png)

ตัวอย่างโค้ด:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

เพื่อหลีกเลี่ยงรูปร่างที่สาม ให้ปรับคอนเน็กเตอร์โดยย้ายส่วนตั้งฉากให้เลื่อนไปทางซ้าย:

![การแก้ไขการกีดขวางคอนเน็กเตอร์](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **กรณีซับซ้อน**

สำหรับการปรับขั้นสูง พิจารณาข้อควรทราบต่อไปนี้  

- จุดปรับของคอนเน็กเตอร์ถูกกำหนดโดยสูตรที่ระบุตำแหน่ง การเปลี่ยนจุดนี้สามารถเปลี่ยนรูปร่างโดยรวมของคอนเน็กเตอร์ได้  
- จุดปรับถูกจัดเก็บในอาร์เรย์ที่มีลำดับแน่นอน ตั้งแต่จุดเริ่มต้นถึงจุดสิ้นสุดของคอนเน็กเตอร์  
- ค่าจุดปรับเป็นเปอร์เซ็นต์ของความกว้าง/สูงของรูปร่างคอนเน็กเตอร์  
  - รูปร่างถูกจำกัดโดยจุดเริ่มต้นและสิ้นสุดของคอนเน็กเตอร์และสเกลด้วย 1000  
  - จุดปรับที่หนึ่ง, สองและสาม แทนเปอร์เซ็นต์ของความกว้าง, ความสูง และอีกครั้งของความกว้าง ตามลำดับ  
- เมื่อคำนวณพิกัดของจุดปรับ ต้องคำนึงถึงการหมุนและการสะท้อนของคอนเน็กเตอร์ **หมายเหตุ:** สำหรับคอนเน็กเตอร์ทั้งหมดที่ระบุใน[ประเภทคอนเน็กเตอร์](/slides/th/python-net/connector/#connector-types) มุมการหมุนเป็น 0  

#### **กรณี 1**

พิจารณากรณีที่อ็อบเจ็กต์กรอบข้อความสองอันเชื่อมต่อด้วยคอนเน็กเตอร์:

![รูปร่างที่เชื่อมต่อกัน](connector-shape-complex.png)

ตัวอย่างโค้ด:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อสร้างไฟล์ PPTX.
with slides.Presentation() as presentation:

    # รับสไลด์แรก.
    slide = presentation.slides[0]

    # รับสไลด์แรก.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # เพิ่มคอนเน็กเตอร์.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # ตั้งค่าทิศทางของคอนเน็กเตอร์.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # ตั้งค่าสีของคอนเน็กเตอร์.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # ตั้งค่าความหนาของเส้นคอนเน็กเตอร์.
    connector.line_format.width = 3

    # เชื่อมโยงรูปร่างด้วยคอนเน็กเตอร์.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # รับจุดปรับของคอนเน็กเตอร์.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**การปรับค่า**  

เปลี่ยนค่าจุดปรับของคอนเน็กเตอร์โดยเพิ่มเปอร์เซ็นต์ความกว้าง 20% และเปอร์เซ็นต์ความสูง 200% ตามลำดับ:

```python
    # เปลี่ยนค่าของจุดปรับ
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

ผลลัพธ์:

![การปรับคอนเน็กเตอร์ 1](connector-adjusted-1.png)

เพื่อสร้างโมเดลที่ช่วยให้คำนวณพิกัดและรูปร่างของส่วนต่าง ๆ ของคอนเน็กเตอร์ ให้สร้างรูปร่างที่สอดคล้องกับส่วนแนวตั้งของคอนเน็กเตอร์ที่`connector.adjustments[0]`:

```python
    # วาดส่วนแนวตั้งของคอนเน็กเตอร์.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

ผลลัพธ์:

![การปรับคอนเน็กเตอร์ 2](connector-adjusted-2.png)

#### **กรณี 2**

ใน**กรณี 1** เราได้สาธิตการปรับคอนเน็กเตอร์อย่างง่ายโดยใช้หลักการพื้นฐาน ในสถานการณ์ทั่วไป คุณต้องคำนึงถึงการหมุนของคอนเน็กเตอร์และการตั้งค่าการแสดงผล (ควบคุมโดย`connector.rotation`,`connector.frame.flip_h`และ`connector.frame.flip_v`) วิธีทำมีดังนี้

แรก สร้างอ็อบเจ็กต์กรอบข้อความใหม่(**To 1**)บนสไลด์ (สำหรับการเชื่อมต่อ) แล้วเพิ่มคอนเน็กเตอร์สีเขียวใหม่ที่เชื่อมต่อกับอ็อบเจ็กต์ที่มีอยู่

```python
    # สร้างอ็อบเจ็กต์ปลายทางใหม่.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # สร้างคอนเน็กเตอร์ใหม่.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # เชื่อมต่ออ็อบเจ็กต์โดยใช้คอนเน็กเตอร์ที่สร้างใหม่.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # รับจุดปรับของคอนเน็กเตอร์.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # เปลี่ยนค่าของจุดปรับ.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

ผลลัพธ์:

![การปรับคอนเน็กเตอร์ 3](connector-adjusted-3.png)

ต่อมา สร้างรูปร่างที่สอดคล้องกับส่วน**แนวนอน**ของคอนเน็กเตอร์ที่ผ่านจุดปรับของคอนเน็กเตอร์ใหม่ `connector.adjustments[0]` ใช้ค่าจาก`connector.rotation`,`connector.frame.flip_h`และ`connector.frame.flip_v`และใช้สูตรการแปลงพิกัดมาตรฐานสำหรับการหมุนโดยอาศัยจุดศูนย์กลาง `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

ในกรณีของเรา มุมการหมุนของอ็อบเจ็กต์คือ 90 องศาและคอนเน็กเตอร์แสดงเป็นแนวตั้ง ดังนั้นโค้ดที่สอดคล้องคือ:

```python
    # บันทึกพิกัดของคอนเน็กเตอร์.
    x = connector.x
    y = connector.y
    
    # แก้ไขพิกัดของคอนเน็กเตอร์หากมันถูกพลิก.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # ใช้ค่าจุดปรับเป็นพิกัด.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # แปลงพิกัดเพราะ sin(90°) = 1 และ cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # กำหนดความกว้างของส่วนแนวนอนโดยใช้ค่าจุดปรับที่สอง.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

ผลลัพธ์:

![การปรับคอนเน็กเตอร์ 4](connector-adjusted-4.png)

เราสาธิตการคำนวณที่เกี่ยวข้องกับการปรับค่าแบบง่ายและจุดปรับที่ซับซ้อน (คำนึงถึงการหมุน) ด้วยความรู้นี้ คุณสามารถพัฒนาโมเดลของคุณเองหรือเขียนโค้ดเพื่อให้ได้อ็อบเจ็กต์`GraphicsPath`หรือแม้แต่ตั้งค่าจุดปรับของคอนเน็กเตอร์ตามพิกัดสไลด์ที่เฉพาะเจาะจง

## **ค้นหามุมของเส้นคอนเน็กเตอร์**

ใช้ตัวอย่างด้านล่างเพื่อคำนวณมุมของเส้นคอนเน็กเตอร์บนสไลด์ด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีอ่านจุดเริ่มและจุดสิ้นสุดของคอนเน็กเตอร์และคำนวณทิศทางเพื่อให้สามารถจัดแนวลูกศร, ป้ายข้อความและรูปร่างอื่น ๆ ได้อย่างแม่นยำ

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. ดึงอ้างอิงสไลด์ตามดัชนี  
1. เข้าถึงรูปแบบเส้นคอนเน็กเตอร์  
1. ใช้ความกว้างและความสูงของเส้นและของกรอบรูปร่างเพื่อคำนวณมุม  

โค้ด Python ด้านล่างแสดงวิธีคำนวณมุมสำหรับรูปแบบเส้นคอนเน็กเตอร์:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบว่าคอนเน็กเตอร์สามารถ “ติด” กับรูปร่างเฉพาะได้หรือไม่?**  

ตรวจสอบว่ารูปร่างเปิดให้ใช้งาน[จุดเชื่อมต่อ](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/connection_site_count/)หรือไม่ หากไม่มีหรือจำนวนเป็นศูนย์ การติดจะไม่ใช้งานได้ในกรณีนั้น ให้ใช้ปลายอิสระและกำหนดตำแหน่งด้วยตนเอง ควรตรวจสอบจำนวนจุดก่อนทำการแนบ

**ถ้าฉันลบรูปร่างที่เชื่อมต่ออยู่ คอนเน็กเตอร์จะเกิดอะไรขึ้น?**  

ทั้งสองปลายจะถูกแยกออก คอนเน็กเตอร์จะคงอยู่บนสไลด์เป็นเส้นธรรมดาที่มีปลายอิสระ คุณสามารถลบมันหรือกำหนดการเชื่อมต่อใหม่ และหากจำเป็นให้ใช้[reroute](https://reference.aspose.com/slides/th/python-net/aspose.slides/connector/reroute/)

**การเชื่อมคอนเน็กเตอร์จะคงอยู่เมื่อนำสไลด์ไปคัดลอกยังพรีเซนเทชันอื่นหรือไม่?**  

โดยทั่วไปจะคงอยู่ หากรูปร่างเป้าหมายถูกคัดลอกไปพร้อมกัน หากสไลด์ถูกแทรกเข้าไฟล์อื่นโดยไม่มีรูปร่างที่เชื่อมต่อ ปลายจะกลายเป็นอิสระและคุณจะต้องแนบใหม่อีกครั้ง