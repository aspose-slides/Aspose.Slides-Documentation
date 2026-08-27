---
title: จัดการตัวเชื่อมในงานนำเสนอด้วย Python
linktitle: ตัวเชื่อม
type: docs
weight: 10
url: /th/python-net/connector/
keywords:
- ตัวเชื่อม
- ประเภทตัวเชื่อม
- จุดตัวเชื่อม
- เส้นตัวเชื่อม
- มุมตัวเชื่อม
- จุดเชื่อมต่อ
- จุดการปรับ
- เชื่อมต่อรูปร่าง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, แนบ, เปลี่ยนเส้นทาง, ปรับ, และตรวจสอบตัวเชื่อม PowerPoint ที่เป็นแบบตรง, โค้งงอ, และโค้งกับ Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

ตัวเชื่อมคือเส้นที่สามารถเชื่อมต่อกับรูปร่างสองรูปได้แม้ว่าหนึ่งในรูปร่างนั้นเคลื่อนที่ จุดสิ้นสุดของมันเชื่อมต่อกับจุดเชื่อมต่อ ซึ่งแสดงด้วยจุดสีเขียวใน PowerPoint ตัวเชื่อมที่โค้งและบิดบางประเภทยังเปิดเผยจุดการปรับที่แสดงด้วยจุดสีส้ม ซึ่งควบคุมตำแหน่งของส่วนย่อยของตัวเชื่อมแต่ละส่วน  

Aspose.Slides แทนตัวเชื่อมด้วยอินเทอร์เฟซ [IConnector](https://reference.aspose.com/slides/th/python-net/aspose.slides/iconnector/) คุณสามารถสร้างมัน, เชื่อมต่อปลายของมันกับรูปร่าง, เลือกจุดเชื่อมต่อ, ทำการเปลี่ยนเส้นทาง, และแก้ไขรูปทรงของตัวเชื่อมที่มีจุดการปรับได้  

[ShapeType](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapetype/) มีการตั้งค่าตัวเชื่อมแบบตรง, โค้งงอ, และโค้งงอ ลำดับต่อไปนี้แสดงตารางรูปทรงของตัวเชื่อมที่มีให้และจำนวนจุดการปรับที่กำหนดโดยแต่ละการตั้งค่า  

| ตัวเชื่อม | รูปภาพ | จำนวนจุดการปรับ |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

จำนวนและความหมายของจุดการปรับเป็นส่วนหนึ่งของการตั้งค่าตัวเชื่อมที่เลือก อย่าสันนิษฐานว่าประเภทตัวเชื่อมสองแบบที่ต่างกันจะแสดงโครงสร้างคอลเลกชันเดียวกัน  

## **เชื่อมต่อรูปร่างสองรูป**

ใช้ [IShapeCollection.add_connector](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapecollection/add_connector/) เพื่อเพิ่มตัวเชื่อม และกำหนดคุณสมบัติ [start_shape_connected_to](https://reference.aspose.com/slides/th/python-net/aspose.slides/iconnector/start_shape_connected_to/) และ [end_shape_connected_to](https://reference.aspose.com/slides/th/python-net/aspose.slides/iconnector/end_shape_connected_to/) หลังจากที่ปลายทั้งสองเชื่อมต่อแล้ว [IConnector.reroute](https://reference.aspose.com/slides/th/python-net/aspose.slides/iconnector/reroute/) จะเลือกเส้นทางสั้นระหว่างรูปร่าง  

ตัวอย่างต่อไปนี้เชื่อมต่อวงรีและสี่เหลี่ยมผืนผ้าด้วยตัวเชื่อมแบบบิด:  

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="คำเตือน" %}}
การเรียก `reroute` อาจเปลี่ยนค่าของ [start_shape_connection_site_index](https://reference.aspose.com/slides/th/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) และ [end_shape_connection_site_index](https://reference.aspose.com/slides/th/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) . กำหนดจุดเชื่อมต่อเฉพาะหลังจากทำการเปลี่ยนเส้นทางหากจุดเหล่านั้นต้องคงที่  
{{% /alert %}}

## **เลือกจุดเชื่อมต่อ**

แต่ละรูปร่างที่สามารถเชื่อมต่อได้รายงานจำนวนจุดเชื่อมต่อของมันผ่าน [connection_site_count](https://reference.aspose.com/slides/th/python-net/aspose.slides/igeometryshape/connection_site_count/). ตรวจสอบดัชนีจุดที่ต้องการ (เริ่มจากศูนย์) ก่อนกำหนดให้กับปลายของตัวเชื่อม; จำนวนจุดเชื่อมต่อจะแตกต่างกันตามรูปทรงของรูปร่าง  

ตัวอย่างนี้เชื่อมต่อปลายของตัวเชื่อมไปยังจุดเฉพาะบนวงรีเมื่อจุดนั้นมีอยู่:  

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **ปรับจุดเชื่อมต่อ**

ตัวเชื่อมที่มีจุดการปรับจะเปิดเผยจุดเหล่านั้นผ่าน [IGeometryShape.adjustments](https://reference.aspose.com/slides/th/python-net/aspose.slides/igeometryshape/adjustments/). ตรวจสอบแต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/python-net/aspose.slides/iadjustvalue/) และตรวจสอบ [type](https://reference.aspose.com/slides/th/python-net/aspose.slides/iadjustvalue/type/) ก่อนเปลี่ยน [raw_value](https://reference.aspose.com/slides/th/python-net/aspose.slides/iadjustvalue/raw_value/). สำหรับการจัดการรูปร่างทั่วไป ดู [Shape Manipulation](/slides/th/python-net/shape-manipulations/).  

จำนวน, ลำดับ, ความหมายและช่วงค่าที่ถูกต้องของการปรับตัวเชื่อมขึ้นอยู่กับการตั้งค่าตัวเชื่อม. property `type` เป็นแบบอ่านอย่างเดียว, ในขณะที่ค่าการปรับสามารถเขียนได้. property [name](https://reference.aspose.com/slides/th/python-net/aspose.slides/iadjustvalue/name/) ที่เป็นแบบอ่านอย่างเดียวให้ข้อมูลระบุตัวเพิ่มเติมเมื่อตัวเชื่อมมีการปรับมากกว่าหนึ่งรายการที่มีประเภทเชิงความหมายเดียวกัน  

### **เส้นทางรอบอุปสรรค**

ในผังต่อไปนี้ ตัวเชื่อม `ShapeType.BENT_CONNECTOR5` ระหว่างสองรูปร่างเดินผ่านรูปร่างที่สาม:  

![connector-obstruction](connector-obstruction.png)

โค้ดนี้สร้างตัวเชื่อมที่ถูกกีดขวาง:  

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

การย้ายการบิดแนวตั้งทำให้เส้นทางเปลี่ยนไปเพื่อให้ตัวเชื่อมหลีกเลี่ยงอุปสรรค:  

![connector-obstruction-fixed](connector-obstruction-fixed.png)

แทนการสันนิษฐานว่าดัชนีคอลเลกชัน `1` แทนการบิดแนวตั้งเสมอ ตัวอย่างนี้ค้นหา `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` และเปลี่ยนค่าเฉพาะเมื่อพบประเภทเชิงความหมายที่คาดหวัง:  

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

`ShapeType.BENT_CONNECTOR5` มีการปรับ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` สองค่าและ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` หนึ่งค่า หากประเภทที่คุณต้องการปรากฏหลายครั้ง ให้ตรวจสอบ `name` และรูปทรงที่รู้จักของการตั้งค้านั้นก่อนเลือกค่า หากการปรับรายงาน [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapeadjustmenttype/), ให้ถือความหมายและช่วงค่าของมันเป็นแบบเฉพาะการตั้งค่าและอย่าเปลี่ยนจนกว่าจะทราบสัญญานั้น  

## **เชื่อมค่าการปรับกับรูปทรงของตัวเชื่อม**

สำหรับตัวเชื่อมแบบบิด ค่าการปรับสามารถใช้ประมาณตำแหน่งของส่วนย่อยแต่ละส่วน การคำนวณเหล่านี้เป็นเฉพาะของการตั้งค่าตัวเชื่อม:  

- `ShapeType.BENT_CONNECTOR4` โดยทั่วไปเปิดเผยการปรับ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` หนึ่งค่าและ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` หนึ่งค่า.  
- สำหรับตำแหน่งการบิดเหล่านี้ `raw_value / 100000` ให้ผลลัพธ์เป็นเศษส่วนของความกว้างหรือความสูงของกรอบตัวเชื่อมตามตัวอย่างด้านล่าง.  
- กรอบตัวเชื่อมอาจถูกหมุนหรือกลับด้าน ดังนั้นพิกัดกรอบต้องถูกแปลงก่อนที่จะเทียบกับพิกัดสไลด์.  

ตัวอย่างต่อไปนี้ใช้ `type` เพื่อระบุการปรับก่อน พวกมันไม่ได้ถือดัชนีคอลเลกชันเป็นตัวระบุนามที่พกพาได้.  

### **ตัวเชื่อมที่ไม่หมุน**

ผังเริ่มต้นมีรูปร่างข้อความสองรูปเชื่อมต่อด้วย `ShapeType.BENT_CONNECTOR4`:  

![connector-shape-complex](connector-shape-complex.png)

ตัวอย่างนี้ตรวจสอบตัวเชื่อมและดึงการปรับการบิดแนวนอนและแนวตั้ง:  

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

เพื่อเปลี่ยนการบิดทั้งสอง, ค้นหาประเภทที่คาดหวังแต่ละประเภทและแก้ค่าเมื่อพบทั้งสองแล้ว:  

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์คือตัวเชื่อมที่ส่วนแนวนอนและแนวตั้งได้ย้ายตำแหน่ง:  

![connector-adjusted-1](connector-adjusted-1.png)

เมื่อทราบประเภทเชิงความหมายแล้ว, ค่าของมันสามารถแปลงเป็นพิกัดกรอบตัวเชื่อมได้ ตัวอย่างนี้วาดสี่เหลี่ยมผอมเหนือส่วนแนวตั้งที่ควบคุมโดยการบิดสองค่า:  

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

รูปร่างแนวทางทำเครื่องหมายส่วนที่คำนวณได้:  

![connector-adjusted-2](connector-adjusted-2.png)

### **ตัวเชื่อมที่หมุนหรือกลับด้าน**

เมื่อรูปทรงตัวเชื่อมเดียวกันถูกจัดแนวแนวตั้ง, ค่า [frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapeframe/flip_h/), และ [flip_v](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapeframe/flip_v/) มีผลต่อการแปลงจากพิกัดกรอบตัวเชื่อมไปยังพิกัดสไลด์.  

ตัวอย่างนี้สร้างและปรับตัวเชื่อมที่จัดแนวแนวตั้ง:  

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

ตัวเชื่อมที่ปรับแล้วปรากฏเป็นแนวตั้งระหว่างรูปร่าง:  

![connector-adjusted-3](connector-adjusted-3.png)

สำหรับมุมการหมุนใด ๆ `alpha`, ให้หมุนจุดในกรอบตัวเชื่อม `(x, y)` รอบศูนย์กลางกรอบ `(x0, y0)`:  

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`  

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`  

โค้ดต่อไปนี้จัดการการจัดแนว 90 องศาที่ใช้ในตัวอย่างนี้และวาดแนวทางสีแดงเหนือส่วนของตัวเชื่อมที่สอดคล้อง:  

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

แนวทางสีแดงทำเครื่องหมายส่วนที่คำนวณได้หลังจากการแปลงพิกัด:  

![connector-adjusted-4](connector-adjusted-4.png)

สูตรเหล่านี้อธิบายการตั้งค่าที่ใช้ในตัวอย่าง, ไม่ใช่โมเดลตัวเชื่อมสากล. ตรวจสอบประเภทการปรับ, การจัดแนวกรอบ, และช่วงค่าก่อนนำสูตรเดียวกันไปใช้กับการตั้งค่าอื่น.  

## **หามุมทิศทางของตัวเชื่อม**

ทิศทางของตัวเชื่อมตรงสามารถคำนวณจากความกว้างและความสูงของมัน, พร้อมการพลิกแนวนอนและแนวตั้ง. ตัวอย่างต่อไปนี้รายงานมุมตามเข็มนาฬิกาจากแกนแนวนบวกในพิกัดสไลด์:  

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ว่าตัวเชื่อมสามารถเชื่อมต่อกับรูปร่างได้หรือไม่?**  

ตรวจสอบ [connection_site_count](https://reference.aspose.com/slides/th/python-net/aspose.slides/igeometryshape/connection_site_count/) ของรูปร่าง. จำนวนบวกหมายความว่ารูปร่างเปิดเผยจุดเชื่อมต่อ. ตรวจสอบดัชนีจุดที่เลือกก่อนกำหนดให้กับปลายของตัวเชื่อม.  

**ฉันสามารถระบุการปรับของตัวเชื่อมโดยใช้ดัชนีคอลเลกชันได้หรือไม่?**  

ดัชนีมีความหมายเฉพาะเมื่อทราบการตั้งค่าตัวเชื่อมและโครงสร้างคอลเลกชัน. ตรวจสอบ [IAdjustValue.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/iadjustvalue/type/) ก่อนแก้ค่า, และใช้ [IAdjustValue.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/iadjustvalue/name/) เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง.  

**จะเกิดอะไรขึ้นเมื่อรูปร่างที่เชื่อมต่อถูกลบ?**  

ปลายของตัวเชื่อมที่เชื่อมต่อจะถูกตัดการเชื่อม. ตัวเชื่อมยังคงอยู่บนสไลด์และสามารถลบ, ตั้งเป็นเส้นอิสระ, หรือเชื่อมต่อกับรูปร่างอื่นได้.  

**การผูกตัวเชื่อมจะคงไว้เมื่อคัดลอกสไลด์หรือไม่?**  

การผูกโดยทั่วไปจะคงไว้เมื่อคัดลอกรูปร่างที่เชื่อมต่อพร้อมกับสไลด์. หากตัวเชื่อมถูกคัดลอกโดยไม่มีหนึ่งในรูปร่างเป้าหมาย, ปลายที่ได้รับผลกระทบจะต้องเชื่อมต่อใหม่.  