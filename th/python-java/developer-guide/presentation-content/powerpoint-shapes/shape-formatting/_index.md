---
title: จัดรูปแบบรูปร่าง PowerPoint ใน Python ผ่าน Java
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/python-java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟ็กต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การแสดงผลรูปร่างสีขาว‑ดำ
- การแสดงผลรูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟ็กต์บีเวิล 3 มิติ
- เอฟเฟ็กต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับเส้นขอบ การเติมสีและเอฟเฟกต์ต่าง ๆ Aspose.Slides สำหรับ Python ผ่าน Java ทำให้คุณสามารถควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งใส การหมุนและการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides สำหรับ Python ผ่าน Java ให้คลาสและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าไม่มีการเติมสีโดยมีเส้นขอบสีน้ำเงินแบบเส้นประ [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) เลือกเส้นผสมหนา‑บางในขณะที่ [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ตั้งความกว้างเป็น 7 จุดและ [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) เลือกรูปแบบเส้นประ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

### **ตั้งค่ารูปแบบเส้นประแบบกำหนดเอง**

ใช้ [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) เมื่อรูปแบบเส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวและช่องว่างของเส้นประที่คุณต้องการ เช่น สำหรับเส้นขอบแบรนด์หรือแผนภูมิเทคนิค การกำหนดรูปแบบจะเปลี่ยนสไตล์เส้นประโดยอัตโนมัติเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/)

รายการในอาร์เรย์สลับกันระหว่างความยาวของเส้นประและช่องว่าง เริ่มด้วยเส้นประ แต่ละค่าจะเป็นผลคูณของความกว้างของเส้น: `[4, 2]` ที่ความกว้าง 3 จุดจะสร้างเส้นประ 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ของค่าที่เป็นจำนวนเต็มบวกหรือศูนย์เพื่อกำหนดส่วนเต็มของเส้นประและช่องว่าง ตัวอย่างใช้ค่าบวกเพื่อให้เส้นประและช่องว่างทั้งหมดมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นที่มีความยาวและปลายเส้นแบบแบนเท่ากัน สามเส้นแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำรูปแบบแรกที่สองเท่าของความกว้าง ทำให้ความยาวของเส้นประและช่องว่างเพิ่มเป็นสองเท่า เส้นที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

```python
import jpype
import asposeslides

if not jpole.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # คืนเส้นสุดท้ายเป็นสไตล์เส้นทึบ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากต้องการกลับไปใช้สไตล์เส้นประที่กำหนดไว้ล่วงหน้า ให้ส่งค่า [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) ไปยัง [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**

![สามรูปแบบเส้นประกำหนดเอง เส้นกว้างขึ้นโดยใช้รูปแบบแรก และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **ตั้งค่าปลายเส้น**

ใช้ [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) เพื่อกำหนดปลายของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) มีสไตล์ปลายสามแบบชัดเจน:

- `Flat`: เส้นสีหยุดที่จุดสุดท้าย
- `Round`: ปลายครึ่งวงกลมต่อออกจากจุดสุดท้ายไปอีกครึ่งความกว้างของเส้น
- `Square`: ปลายสี่เหลี่ยมต่อออกจากจุดสุดท้ายไปอีกครึ่งความกว้างของเส้น

คลาสนี้ยังมีค่า `NotDefined` ซึ่งหมายถึงไม่มีการกำหนดสไตล์ปลายอย่างชัดเจน

ปลายเส้นแตกต่างจากหัวศร ซึ่งจะเพิ่มสัญลักษณ์ที่ปลายเส้นและการเชื่อมต่อซึ่งควบคุมมุมระหว่างส่วนของเส้น ตัวอย่างนี้ปิดการใช้งานหัวศรผ่าน [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) และ [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) เพื่อให้เปรียบเทียบเฉพาะรูปแบบปลายเส้น

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกันโดยมีความกว้าง 20 จุด ตั้งแต่บนลงล่างจะใช้ปลายเส้น Flat, Round, และ Square ตามลำดับ จุดสุดท้ายของเส้นมีพิกัดแนวนอนเดียวกัน; ปลายเส้นแบบ Round และ Square จะยืดออกไปอีก 10 จุดจากแต่ละจุดสุดท้าย

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**

![ปลายเส้น flat, round, และ square บนเส้นหนาแบบเดียวกันใน PowerPoint](line-caps.png)

## **นำเอฟเฟกต์สเก็ตช์ไปใช้กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)

โค้ด Python ด้านล่างแสดงวิธีการใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) , อ่านค่าที่กำหนดอย่างชัดเจน, และลบเอฟเฟกต์ด้วย [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

ค่าที่คืนจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์, หรือเลเอาต์สไลด์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) แล้วอ่านชนิดสเก็ตช์จากการจัดรูปแบบเส้นที่มีผลกลับมาดังที่แสดงด้านล่าง ค่าที่มีผลสะท้อนการจัดรูปแบบที่นำไปใช้จริงหลังจากการสืบทอดได้รับการแก้ไข ตัวอย่างนี้ต้องมีการนำเสนอที่มีรูปร่างอย่างน้อยหนึ่งรูปบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

นี่คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมว่าตัวแบ่งเส้นสองเส้นมาบรรจบกันที่มุมอย่างไร ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมแบน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำสามรูปโดยมีเส้นขอบสีน้ำเงินความกว้าง 15 จุด ใช้ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) เพื่อกำหนดค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) ตามลำดับเพื่อเปรียบเทียบว่ามุมถูกวาดอย่างไร

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **จำกัดการเชื่อมต่อ Miter ที่มุมแหลม**

ใช้ [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) พร้อมกับ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) ตั้งค่าเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมแหลมสามารถขยายออกไปได้

ค่าจำกัดเป็นอัตราส่วนของระยะห่างระหว่างมุมในและมุมนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวของมิตเทอร์สูงถึง 8 เท่าของความกว้างของเส้น; มันไม่ใช่การวัดเป็นจุด หากมุมเกินค่าจำกัด PowerPoint จะใช้การเชื่อมต่อแบบบีเวิลที่มุมนั้น ค่าจำกัดที่ใหญ่กว่าจะทำให้จุดคมขึ้น การตั้งค่านี้มีผลต่อการเชื่อมต่อแบบมิตเทอร์เท่านั้นและการเปลี่ยนแปลงจะไม่มีผลที่มองเห็นได้เมื่อมุมยังคงอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสองสามเหลี่ยมที่เหมือนกันโดยไม่มีการเติมสีโดยมีเส้นขอบความกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ค่าจำกัด `2` และด้านขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาวมิตเทอร์ต่อความกว้างเส้นประมาณ `4.12` ดังนั้น PowerPoint จะบีเวิลยอดซ้ายและคงยอดขวาไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ทางซ้ายและ **miter limit 8** ทางขวา

![ยอดที่บีเวิลด้วย miter limit 2 และยอดแหลมด้วย miter limit 8 ใน PowerPoint](miter-limits.png)

## **การไล่สี**

การไล่สีผสมสีหลายสีทั่วรูปร่าง ตัวอย่างนี้เติมวงรีด้วยไล่สีเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat) เมธอด [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) วางจุดสีที่ 0 และ 1 คือจุดเริ่มต้นและจุดสิ้นสุดของการไล่สี การล้างจุดสีที่มีอยู่เดิมทำให้ใช้เฉพาะสองสีนี้เท่านั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![วงรีที่มีการไล่สี](gradient-fill.png)

หากการไล่สีดูแตกต่างกันในภาพที่ส่งออกกับใน PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการไล่สีที่เก็บในงานนำเสนอ

### **ตั้งมุมไล่สีเชิงเส้น**

ใช้ [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) เพื่อควบคุมทิศทางของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` วิ่งจากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, และ `270` จากล่างขึ้นบน สามเหลี่ยมมุมอาจใช้ได้ มุมที่อยู่นอกช่วง `[0, 360)` จะปรับให้เป็นรอบหนึ่ง ตัวอย่างเช่น `-45` จะเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมสีหกรูปโดยมีจุดสีแดง เขียว และน้ำเงินที่ตำแหน่ง `0`, `0.5`, และ `1` เหมือนกัน การสเกลปิดเพื่อให้มุมเปรียบเทียบได้โดยอิสระจากสัดส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, และ `90` และในแถวล่างคือ `135`, `180`, และ `270`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์ใน PowerPoint:

![ไล่สีเชิงเส้นที่ 0°, 45°, และ 90° ในแถวบน, และ 135°, 180°, และ 270° ในแถวล่าง](linear-gradient-angles.png)

### **สเกลไล่สีเชิงเส้นกับรูปทรง**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) รับค่า [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) ตั้งค่าอย่างชัดเจนเป็น `False_` เพื่อคงมุมไล่สีเรขาคณิตเมื่อตัวรูปทรงเปลี่ยนสัดส่วน หรือเป็น `True_` เพื่อสเกลไล่สีตามความกว้างและสูงของรูปทรง เมื่อสเกลเปิดใช้งานมุมที่มองเห็นอาจต่างจากมุมที่กำหนดบนรูปทรงที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและจุดสีเดียวกับการเปรียบเทียบมุม คอลัมน์ซ้ายใช้ `False_`; คอลัมน์ขวาใช้ `True_` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างเหนือสี่เหลี่ยมสูง ทั้งสองเริ่มจากขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมสีตอบสนองต่อการปรับขนาดอย่างไรโดยไม่เปลี่ยนการตั้งค่าไล่สี

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์ใน PowerPoint, ปิดการสเกลทางซ้ายและเปิดบนทางขวา:

![สี่เหลี่ยมกว้างและสูงที่มีไล่สี 45°, เปรียบเทียบ LinearGradientScaled False ทางซ้ายกับ True ทางขวา](linear-gradient-scaling.png)

เมื่อสเกลปิด การไล่สีทแยงมุมจะคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม เมื่อสเกลเปิด แถบสีจะยืดตามสัดส่วนของรูปทรง ซึ่งช่วยทำซ้ำไล่สีของเทมเพลตเมื่อปรับรูปทรงให้มีขนาดต่างกัน บนสี่เหลี่ยมจัตุรัส การเปิดสเกลไม่ทำให้ไล่สี `45`‑องศานี้เปลี่ยนรูปลักษณ์

การตั้งค่ามุมและสเกลใช้ได้กับไล่สีเชิงเส้นเท่านั้น ไม่ควบคุมการเติม [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)

### **รวมมุมกับทิศทางของไล่สี**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) เลือกรูปแบบไล่สีจากคลาส [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) ซึ่งไม่เป็นตัวแทนของมุมเชิงตัวเลข สำหรับไล่สีเชิงเส้น สไตล์มุมอาจเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) คงทิศทางเมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันแต่สั่งลำดับตรงกันข้าม สี่เหลี่ยมทั้งสองมีลักษณะเดียวกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ได้เปลี่ยนผลลัพธ์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **การเติมลาย**

การเติมลายใช้การออกแบบสองสี เช่น จุด, เส้นแนวนอนหรือเชิงกริด ตัวอย่างนี้ใช้ [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) เพื่อเลือกลาย trellis [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) ให้พื้นหลังสีเทาอ่อน และ [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) ให้สีเหลืองสำหรับลาย

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลาย](pattern-fill.png)

## **การเติมภาพ**

การเติมภาพใช้รูปภาพภายในรูปร่าง ตัวอย่างนี้ต้องการรูปภาพแบบท้องถิ่นและใช้ [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) เพื่อโหลดเข้าคอลเลกชันภาพของงานนำเสนอ การตั้งค่า [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) เป็นโหมดกระเบื้องจะทำซ้ำรูปภาพภายในสี่เหลี่ยม รูปภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปดอกบัว](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![รูปร่างที่มีการเติมภาพ](picture-fill.png)

### **ทำภาพเป็นพื้นผิวแบบปูกระเบื้อง**

หากต้องการตั้งรูปภาพเป็นพื้นผิวแบบกระเบื้องและปรับพฤติกรรมการปูกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งโหมดการเติมภาพ — `Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุการจัดตำแหน่งของกระเบื้องภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่ากระเบื้องจะถูกพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าการเลื่อนแนวนอนของกระเบื้อง (เป็นจุด) จากต้นตอของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าการเลื่อนแนวตั้งของกระเบื้อง (เป็นจุด) จากต้นตอของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการรูปภาพแบบท้องถิ่นและกำหนดค่า [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) ให้ทำซ้ำที่ 50 % ของขนาดต้นฉบับ การเลื่อน `−32` จุดทำให้กระเบื้องย้ายแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการพลิกทั้งสองทิศทางกำหนดวิธีการเรียงลำดับของพื้นผิวที่ทำซ้ำ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ตัวเลือกการปูกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

การเติมสีทึบให้รูปร่างเป็นสีเดียวเดียวที่สม่ำเสมอ ตัวอย่างนี้ใช้ [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) เพื่อกำหนดโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) แล้วบันทึกสี่เหลี่ยมในงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![รูปร่างที่มีการเติมสีทึบ](solid-color-fill.png)

### **คัดลอกรสีขณะคงการอ้างอิงธีม**

ใช้ [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) เพื่อคัดลอกคำจำกัดความสีรวมถึงประเภทสี, การอ้างอิงธีมและการแปลง นี่เป็นประโยชน์เมื่อย้ายสีเติมระหว่างรูปร่างที่ควรยังคงตามธีมของงานนำเสนอเมธอดจะคัดลอกเฉพาะสี ไม่คัดลอกประเภทการเติม, เส้นขอบหรือการจัดรูปแบบอื่น ๆ ของรูปร่าง กำหนดประเภทการเติมของปลายทางอย่างชัดเจนด้วย [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType)

ตัวอย่างนี้สร้างสี่เหลี่ยมสามรูปจากซ้ายไปขวา: ต้นฉบับ, สำเนาที่รับรู้ธีม, และสำเนา RGB คงที่ ต้นฉบับใช้ [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) เพื่ออ้างอิงสีเน้นแรกและเพิ่มการเบลอด้วย [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add) สำเนา RGB ใช้สีเติมที่มีผลของต้นฉบับเพื่อให้ทั้งสามดูเหมือนกันในตอนแรก การเรียก [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) จะตั้งค่า RGB คงที่และลบการแปลงสีที่มีอยู่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # การอ้างอิงธีมจะตามสีเน้นใหม่; ค่ารหัส RGB คงที่จะไม่ทำเช่นนั้น.
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ก่อนการเปลี่ยนธีม ทั้งสามการเติมสีตรงกัน:

![แหล่งที่มา, ปลายทาง copyFrom, และปลายทาง RGB คงที่ที่มีการเติมสีน้ำเงินเดียวกัน](color-copy-before.png)

หลังการเปลี่ยนธีม แหล่งที่มาและสำเนาที่รับรู้ธีมจะใช้สีเน้นใหม่และคงการผสมสีเดิมไว้ ส่วนสำเนา RGB คงที่ยังคงเป็นสีน้ำเงิน:

![แหล่งที่มาและปลายทาง copyFrom ที่เติมด้วยสีส้ม ในขณะที่ปลายทาง RGB คงที่ยังคงเป็นสีน้ำเงิน](color-copy-after.png)

การคัดลอกคำนิยามเป็นอิสระจากต้นฉบับ การเปลี่ยนการอ้างอิงธีมของต้นฉบับ, กำหนดสีอื่น หรือเพิ่ม/ลบการแปลงจะไม่ส่งผลต่อปลายทาง การเปลี่ยนธีมยังคงมีผลต่อรูปร่างทั้งสองเพราะแต่ละรูปร่างอ้างอิงสีธีมเดียวกัน

การบันทึกและเปิดไฟล์ PPTX อีกครั้งจะคงประเภทสีที่คัดลอกได้จาก [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType), การอ้างอิงธีม และคอลเลกชันการแปลงจาก [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform) ; ไม่ได้แปลงเป็น RGB

เมือคัดลอกระหว่างบริบทธีมที่ต่างกัน เช่น งานนำเสนอที่ใช้พาเลตต์สีเน้นต่างกัน การอ้างอิงที่คัดลอกจะอิงกับธีมของปลายทาง การอ้างอิงและการแปลงเดียวกันอาจให้สีที่มองเห็นแตกต่าง ดูที่ [Presentation Theme](/slides/th/python-java/presentation-theme/) เพื่อเรียนรู้การกำหนดสีธีม

## **ใช้พื้นหลังสไลด์เป็นการเติมสีให้รูปร่าง**

ใช้ [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) เมื่อรูปร่างควรตรงกับพื้นหลังสไลด์ ตัวอย่างเช่น ในเทมเพลตงานนำเสนอ กำหนดประเภทการเติมด้วย [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) เป็น [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) ก่อนเพื่อลบการเติมที่กำหนดโดยชัดเจน ด้วยการผสมนี้รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมสไตล์ของตน การเปิดใช้งานแฟลกเพียงอย่างเดียวไม่ได้ลบการเติมที่กำหนดไว้แล้ว

สิ่งนี้แตกต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) : การเติมพื้นหลังจะครอบคลุมวัตถุที่อยู่ด้านหลังรูปร่างด้วยพื้นที่ของพื้นหลังสไลด์ที่สอดคล้องกัน ส่วน NoFill จะทำให้วัตถุเหล่านั้นมองเห็นได้ การไล่สียังคงจัดแนวกับสไลด์แทนที่จะแตกใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สืบทอดโดยสไลด์และวางแถบสีแมจนท์ไว้หลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, และสี่เหลี่ยมขวาสลับจากการเติมพื้นหลังเป็นการเติมสีส้มชัดเจน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # สืบทอดการไล่สีจากมาสเตอร์.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # เพิ่มวัตถุนี้ก่อนเพื่อให้แสดงด้านหลังสี่เหลี่ยม.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # ปิดการเติมพื้นหลังก่อนที่จะใช้การเติมที่กำหนดเอง.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์จากซ้ายไปขวา: **background fill**, **no fill**, และ **explicit fill**. แถบสีแมจนท์ถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังคงมองเห็นผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่เติม, และการเติมสีส้มชัดเจนบนแถบสีม่วง](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลเอาต์ รูปร่างใช้พื้นหลังที่แก้ไขแล้วของสไลด์; ตัวอย่างนี้ทำให้พื้นหลังของสไลด์และเลเอาต์เป็นค่าไม่กำหนดเพื่อให้มาสเตอร์จัดการให้

## **ตั้งค่าความโปร่งใส**

สำหรับการเติมสีทึบ ส่วนประกอบอัลฟาของสีควบคุมความทึบ: 0 คือโปร่งใสเต็มที่และ 255 คือทึบเต็มที่ ตัวอย่างนี้ใช้ค่าอัลฟา 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50 % เพื่อให้สี่เหลี่ยมด้านล่างมองเห็นได้ สีกำหนดผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

ใช้ [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) เพื่อหมุนรูปร่างในระนาบสไลด์ มุมวัดเป็นองศา ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวิล 3 มิติ**

ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) ให้รูปร่างมีความลึกและขอบบีเวิล ตัวอย่างนี้สร้างวงรีสีเขียวโดยมีเส้นขอบส้ม ใช้ [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) ตั้งความลึกเป็น 4 จุดและใช้ [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) เพื่อสร้างบีเวิลบนแบบวงกลมที่กว้างและสูง 6 จุด กล้องออร์โธกราฟิกที่หันหน้าและแสงสามจุดทำให้บีเวิลมองเห็น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![เอฟเฟกต์บีเวิล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปร่างถูกควบคุมด้วยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) ตั้งมุมละติจูด, ลองจิจูดและการหมุนรอบที่ 40, 35, และ 20 องศาตามลำดับ เลือกกล้องไอโซเมตริกด้วย [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) และแสงสมดุลด้วย [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) แล้วบันทึกสี่เหลี่ยมที่จัดรูปแบบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการแสดงผลขาว‑ดำสำหรับรูปร่าง**

เมธอด [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) ระบุว่ารูปร่างแต่ละอันจะถูกแสดงอย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดขาว‑ดำ มันไม่เปิดใช้งานการแสดงผลขาว‑ดำโดยอัตโนมัติและไม่เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่นของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอพพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและขาว, `Black` และ `White` บังคับสีเดียว, `Color` คงสีปกติ, และ `Hidden` ลบรูปร่างในโหมดขาว‑ดำ `NotDefined` หมายถึงไม่ได้กำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมส้มและใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) ตั้งโหมดเป็น `Gray` รูปร่างที่บันทึกยังคงเติมสีส้มสำหรับการแสดงสีปกติและขอให้แอพพลิเคชันที่เคารพการแสดงผลขาว‑ดำใช้สีเทา:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ในโหมดสีปกติ สี่เหลี่ยมยังคงเติมสีส้ม ในขั้นตอนแสดงผลขาว‑ดำ มันใช้สีเทาจากที่ตั้งค่าเป็น `Gray` สิ่งนี้ช่วยให้คุณคงสไลด์สีเต็มเมื่อกำหนดลักษณะเฉพาะสำหรับการพิมพ์, ดูตัวอย่างหรือขั้นตอนอื่นที่เคารพการตั้งค่าการแสดงผลขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) เพื่อคืนตำแหน่ง, ขนาด และการจัดรูปแบบของตำแหน่งตัวยึดสไลด์จากตำแหน่งตัวยึดของเลเอาต์ที่สอดคล้อง ตัวอย่างนี้ต้องการงานนำเสนอที่มีตำแหน่งตัวยึดเชื่อมโยงกับเลเอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตำแหน่งตัวยึดในเลเอาต์จะไม่ถูกรีเซ็ต

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้นและการตั้งค่าเอฟเฟกต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังอยู่ การเติมภาพอาจเพิ่มขนาดไฟล์เพราะภาพถูกเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง — การเติม, เส้นและการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ให้ถือว่าสไตล์เดียวกันและจัดกลุ่มรูปร่างเหล่านั้นเชิงตรรกะ ซึ่งช่วยลดความซับซ้อนในการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บตัวอย่างรูปร่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์หรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์ต้องการและนำการจัดรูปแบบไปใช้ใหม่ตามที่ต้องการ