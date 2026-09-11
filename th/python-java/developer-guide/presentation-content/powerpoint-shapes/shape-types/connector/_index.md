---
title: จัดการคอนเนคเตอร์ในงานนำเสนอด้วย Python ผ่าน Java
linktitle: คอนเนคเตอร์
type: docs
weight: 10
url: /th/python-java/connector/
keywords:
- คอนเนคเตอร์
- ประเภทคอนเนคเตอร์
- จุดคอนเนคเตอร์
- เส้นคอนเนคเตอร์
- มุมคอนเนคเตอร์
- ตำแหน่งการเชื่อมต่อ
- จุดปรับค่า
- เชื่อมต่อรูป
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ผูก, ปรับเส้นทางใหม่, ปรับค่าและตรวจสอบคอนเนคเตอร์ PowerPoint แบบตรง, หัก, และโค้งด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

คอนเนคเตอร์คือเส้นที่สามารถผูกติดกับรูปสองอันได้แม้รูปใดรูปหนึ่งจะเคลื่อนที่ จุดปลายของคอนเนคเตอร์จะผูกกับตำแหน่งการเชื่อมต่อที่แสดงเป็นจุดสีเขียวใน PowerPoint คอนเนคเตอร์บางประเภทที่โค้งหรือหักยังเปิดเผยจุดปรับค่า (adjustment points) ที่แสดงเป็นจุดสีส้ม เพื่อควบคุมตำแหน่งของส่วนต่าง ๆ ของคอนเนคเตอร์

Aspose.Slides แทนคอนเนคเตอร์ด้วยคลาส [Connector](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/) คุณสามารถสร้างคอนเนคเตอร์ ผูกปลายของคอนเนคเตอร์กับรูป เลือกตำแหน่งการเชื่อมต่อ ปรับเส้นทางใหม่ และแก้ไขเรขาคณิตของคอนเนคเตอร์ที่มีจุดปรับค่าได้

## **ประเภทคอนเนคเตอร์**

คลาส [ShapeType](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/) มีพรีเซ็ตคอนเนคเตอร์แบบตรง, หัก, และโค้ง ตารางต่อไปนี้แสดงรูปแบบเรขาคณิตของคอนเนคเตอร์ที่มีให้เลือกและจำนวนจุดปรับค่าที่กำหนดไว้ในแต่ละพรีเซ็ต

| ตัวเชื่อม | ภาพ | จำนวนจุดปรับค่า |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

จำนวนและความหมายของจุดปรับค่าขึ้นอยู่กับพรีเซ็ตคอนเนคเตอร์ที่เลือก อย่าเพิ่งสันนิษฐานว่าคอนเนคเตอร์สองประเภทที่แตกต่างกันจะมีโครงสร้างคอลเลกชันเดียวกัน

## **เชื่อมสองรูป**

ใช้ [ShapeCollection.addConnector](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addConnector) เพื่อเพิ่มคอนเนคเตอร์ และใช้ [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/#setStartShapeConnectedTo) กับ [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/#setEndShapeConnectedTo) เพื่อผูกปลายของคอนเนคเตอร์ หลังจากผูกทั้งสองปลายแล้ว [Connector.reroute](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/#reroute) จะเลือกเส้นทางสั้น ๆ ระหว่างรูปสองอัน

ตัวอย่างต่อไปนี้เชื่อมวงรีกับสี่เหลี่ยมโดยใช้คอนเนคเตอร์แบบหัก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
การเรียกใช้ [reroute](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/#reroute) อาจทำให้ค่า [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) และ [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex) เปลี่ยนแปลงได้ ให้กำหนดตำแหน่งเชื่อมต่อที่แน่นอนหลังจากทำการ reroute หากต้องการให้ตำแหน่งเหล่านั้นคงที่
{{% /alert %}}

## **เลือกตำแหน่งการเชื่อมต่อ**

รูปที่สามารถเชื่อมต่อได้จะรายงานจำนวนตำแหน่งผ่าน [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getConnectionSiteCount) ตรวจสอบดัชนีตำแหน่งที่เป็นศูนย์‑เบสก่อนนำไปผูกกับปลายคอนเนคเตอร์; จำนวนตำแหน่งจะแตกต่างกันตามเรขาคณิตของรูป

ตัวอย่างนี้ผูกคอนเนคเตอร์กับตำแหน่งเฉพาะบนวงรีเมื่อมีตำแหน่งนั้นอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ปรับจุดคอนเนคเตอร์**

คอนเนคเตอร์ที่มีจุดปรับค่าจะเปิดเผยค่าผ่าน [GeometryShape.getAdjustments](https://reference.aspose.com/slides/th/python-java/aspose.slides/geometryshape/#getAdjustments) ตรวจสอบทุก [AdjustValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/) และเช็คค่า [getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getType) ก่อนเปลี่ยนค่าด้วย [setRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setRawValue) กฎทั่วไปสำหรับการระบุการปรับค่าของพรีเซ็ตรูปอยู่ในหัวข้อ [Shape Manipulation](/slides/th/python-java/shape-manipulations/)

จำนวน ลำดับ ความหมาย และช่วงค่าที่อนุญาตของการปรับค่าขึ้นกับพรีเซ็ตคอนเนคเตอร์ ชนิดการปรับค่าจะเป็นแบบอ่าน‑เฉพาะ (read‑only) ส่วนค่าการปรับจะสามารถเขียนได้ วิธีการอ่าน‑เฉพาะ [getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getName) ให้ข้อมูลเพิ่มเติมเมื่อคอนเนคเตอร์มีการปรับค่าประเภทเดียวกันหลายรายการ

### **เดินทางไปรอบอุปสรรค**

ในเลย์เอาต์ต่อไปนี้คอนเนคเตอร์ [BentConnector5](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector5) ระหว่างรูปสองอันผ่านรูปที่สาม:

![connector-obstruction](connector-obstruction.png)

โค้ดต่อไปนี้สร้างคอนเนคเตอร์ที่ถูกกีดขวาง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การย้ายการโค้งแนวตั้งทำให้เส้นทางเปลี่ยนเป็นการหลบหลีกอุปสรรค:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

แทนที่จะสันนิษฐานว่าดัชนีคอลเลกชัน `1` คือการโค้งแนวตั้ง ตัวอย่างนี้จะค้นหา [ConnectorBendPositionY](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) แล้วเปลี่ยนค่าเฉพาะเมื่อพบชนิดเชิงความหมายที่คาดหวัง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[BentConnector5](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector5) มีการปรับค่า [ConnectorBendPositionX](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) สองรายการและ [ConnectorBendPositionY](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) หนึ่งรายการ หากชนิดที่ต้องการปรากฏหลายครั้ง ให้ตรวจสอบ [getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getName) และเรขาคณิตที่ทราบของพรีเซ็ตก่อนเลือก หากการปรับค่ารายงานเป็น [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#Custom) ให้ถือว่าความหมายและช่วงค่าเป็นแบบพรีเซ็ตเฉพาะและอย่าเปลี่ยนจนกว่าเงื่อนไขจะเป็นที่ทราบ

## **เชื่อมความสัมพันธ์ระหว่างค่าการปรับกับเรขาคณิตคอนเนคเตอร์**

สำหรับคอนเนคเตอร์หัก ค่าการปรับสามารถใช้ประมาณตำแหน่งของส่วนย่อยต่าง ๆ ได้ การคำนวณเหล่านี้เป็นเรื่องเฉพาะพรีเซ็ตคอนเนคเตอร์:

- [BentConnector4](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector4) ปกติจะเปิดเผยการปรับค่า [ConnectorBendPositionX](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) หนึ่งค่าและ [ConnectorBendPositionY](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) หนึ่งค่า
- สำหรับตำแหน่งโค้งเหล่านี้ การหารค่าที่คืนโดย [getRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getRawValue) ด้วย `100000.0` จะให้ส่วนของความกว้างหรือความสูงของกรอบคอนเนคเตอร์ตามตัวอย่างด้านล่าง
- กรอบคอนเนคเตอร์อาจถูกหมุนหรือพลิก ดังนั้นพิกัดกรอบต้องแปลงก่อนนำไปเปรียบเทียบกับพิกัดสไลด์

ตัวอย่างต่อไปนี้ใช้ [getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getType) เพื่อระบุการปรับค่าก่อน ไม่ได้ใช้ดัชนีคอลเลกชันเป็นตัวระบุตามพกพา

### **คอนเนคเตอร์ที่ไม่ได้หมุน**

เลย์เอาต์เริ่มต้นมีรูปข้อความสองอันที่เชื่อมต่อด้วย [BentConnector4](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

ตัวอย่างนี้ตรวจสอบคอนเนคเตอร์และดึงการปรับค่าโค้งแนวนอนและแนวตั้ง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

เพื่อเปลี่ยนโค้งทั้งสอง ให้ค้นหาชนิดที่คาดหวังแต่ละชนิดและปรับค่าเฉพาะหลังจากพบทั้งสอง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์คือคอนเนคเตอร์ที่ส่วนแนวนอนและแนวตั้งได้เคลื่อนที่:

![connector-adjusted-1](connector-adjusted-1.png)

เมื่อทราบชนิดเชิงความหมายแล้ว ค่าที่ได้สามารถแปลงเป็นพิกัดกรอบคอนเนคเตอร์ ตัวอย่างนี้วาดสี่เหลี่ยมบาง ๆ ทาบบนส่วนแนวตั้งที่ควบคุมโดยการปรับโค้งสองค่า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

รูปช่วยนำทางทำเครื่องหมายส่วนที่คำนวณได้:

![connector-adjusted-2](connector-adjusted-2.png)

### **คอนเนคเตอร์ที่หมุนหรือพลิก**

เมื่อเรขาคณิตคอนเนคเตอร์เดียวกันถูกจัดวางเป็นแนวตั้ง ค่า [Shape.getFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeframe/#getFlipH) และ [ShapeFrame.getFlipV](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeframe/#getFlipV) จะมีผลต่อการแปลงจากพิกัดกรอบคอนเนคเตอร์เป็นพิกัดสไลด์

ตัวอย่างนี้สร้างและปรับคอนเนคเตอร์ที่จัดวางเป็นแนวตั้ง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คอนเนคเตอร์ที่ปรับแล้วปรากฏเป็นแนวตั้งระหว่างรูปสองอัน:

![connector-adjusted-3](connector-adjusted-3.png)

สำหรับมุมหมุนใด ๆ `alpha` ให้หมุนจุดกรอบคอนเนคเตอร์ `(x, y)` รอบศูนย์กลางกรอบ `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

โค้ดต่อไปนี้จัดการกับการวางแนว 90 องศาที่ใช้ในตัวอย่างและวาดแนวนำสีแดงบนส่วนคอนเนคเตอร์ที่สอดคล้องกัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

แนวนำสีแดงทำเครื่องหมายส่วนที่คำนวณได้หลังจากแปลงพิกัด:

![connector-adjusted-4](connector-adjusted-4.png)

สูตรเหล่านี้อธิบายพรีเซ็ตที่ใช้ในตัวอย่าง ไม่ได้เป็นโมเดลคอนเนคเตอร์สากล ตรวจสอบชนิดการปรับ ค่าการหมุนของกรอบ และช่วงค่าที่อนุญาตก่อนนำสูตรเดียวกันไปใช้กับพรีเซ็ตอื่น

## **ค้นหาองศาทิศทางของคอนเนคเตอร์**

ทิศทางของคอนเนคเตอร์ตรงสามารถคำนวณจากความกว้างและความสูง พร้อมการพลิกแนวนอนหรือแนวตั้ง ตัวอย่างต่อไปนี้รายงานมุมตามเข็มนาฬิกาจากแกนแนวนอนบวกในพิกัดสไลด์:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าคอนเนคเตอร์สามารถผูกกับรูปได้หรือไม่?**

ตรวจสอบค่าที่คืนจาก [getConnectionSiteCount](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getConnectionSiteCount) ของรูป หากค่าเป็นบวก หมายความว่ารูปเปิดเผยตำแหน่งการเชื่อมต่อ ตรวจสอบดัชนีตำแหน่งที่เลือกก่อนนำไปผูกกับปลายคอนเนคเตอร์

**ฉันสามารถระบุการปรับค่าคอนเนคเตอร์ตามดัชนีคอลเลกชันได้หรือไม่?**

ดัชนีมีความหมายเฉพาะเมื่อรู้พรีเซ็ตคอนเนคเตอร์และโครงสร้างคอลเลกชัน ตรวจสอบ [AdjustValue.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getType) ก่อนแก้ไขค่า และใช้ [AdjustValue.getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getName) เป็นข้อมูลเพิ่มเติมเมื่อชนิดเชิงความหมายเดียวกันปรากฏหลายครั้ง

**เกิดอะไรขึ้นเมื่อรูปที่เชื่อมต่อถูกลบ?**

ปลายคอนเนคเตอร์ที่เชื่อมโยงกับรูปนั้นจะถูกแยกออก คอนเนคเตอร์จะคงอยู่บนสไลด์และสามารถลบ ย้ายเป็นเส้นอิสระ หรือผูกกับรูปอื่นได้

**การเชื่อมต่อของคอนเนคเตอร์จะคงไว้เมื่อคัดลอกสไลด์หรือไม่?**

โดยทั่วไปการเชื่อมต่อจะคงอยู่เมื่อคัดลอกสไลด์พร้อมกับรูปที่เชื่อมต่อ หากคอนเนคเตอร์ถูกคัดลอกโดยไม่มีรูปเป้าหมายหนึ่งรูป ปลายที่ได้รับผลกระทบจะต้องผูกใหม่อีกครั้ง