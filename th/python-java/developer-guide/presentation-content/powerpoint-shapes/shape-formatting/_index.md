---
title: จัดรูปแบบรูปทรง PowerPoint ใน Python ผ่าน Java
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/python-java/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตซ์
- เส้นรูปทรงสเก็ตซ์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- เติมแบบไล่สี
- เติมแบบลาย
- เติมรูปภาพ
- เติมเท็กซ์เจอร์
- เติมสีทึบ
- ความโปร่งแสงของรูปทรง
- การเรนเดอร์รูปทรงสีขาว‑ดำ
- การเรนเดอร์รูปทรงระดับสีเทา
- หมุนรูปทรง
- เอฟเฟกต์เบเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้น, และเอฟเฟ็กต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปทรงใน PowerPoint ด้วยการปรับเส้นขอบ การเติมสี และเอฟเฟกต์ Aspose.Slides for Python via Java ให้คุณควบคุมการตั้งค่าเหล่านี้โดยใช้โปรแกรม รวมถึงการใส่ความโปร่งใส การหมุน และการจัดรูปแบบ 3D

![ตัวเลือกการจัดรูปแบบรูปทรงใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java ให้คลาสและเมธอดที่ทำให้คุณสามารถจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) เพื่อควบคุมเส้นขอบของรูปทรง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าที่ไม่มีการเติมสีพร้อมเส้นขอบสีน้ำเงินแบบจุดประหลาด [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) เลือกเส้นแบบหนา‑บางแบบผสม ในขณะที่ [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) กำหนดความกว้างเป็น 7 จุดและ [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) เลือกรูปแบบการจุด

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

### **กำหนดรูปแบบจุดประหลาดของเส้นแบบกำหนดเอง**

ใช้ [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวและช่องว่างของจุดที่ต้องการ เช่น สำหรับเส้นขอบแบรนด์หรือแผนภาพทางเทคนิค การกำหนดรูปแบบจะเปลี่ยนสไตล์การจุดของเส้นเป็นอัตโนมัติเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/)

รายการในอาร์เรย์สลับระหว่างความยาวของจุดและช่องว่าง เริ่มจากจุด แต่ละค่าคือหลายเท่าของความกว้างของเส้น: `[4, 2]` ที่ความกว้าง 3 จุดจะให้จุดที่ยาว 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ของค่าที่เป็นจำนวนจริงและไม่เป็นลบเพื่อกำหนดส่วนจุด‑ช่องว่างที่สมบูรณ์ ตัวอย่างใช้ค่าบวกเพื่อให้จุดและช่องว่างทั้งหมดมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นที่มีความยาวเท่ากันและปลายนิ้วเรียบ เส้นสามแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำรูปแบบแรกโดยเพิ่มความกว้างเป็นสองเท่า ทำให้ความยาวของจุดและช่องว่างเพิ่มเป็นสองเท่า ส่วนเส้นที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
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

หากต้องการกลับไปใช้สไตล์จุดที่กำหนดไว้ล่วงหน้าให้ส่ง [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) ไปยัง [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**

![รูปแบบจุดประหลาดสามแบบ เส้นที่กว้างกว่าโดยใช้รูปแบบแรก และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **กำหนดลักษณะปลายเส้น**

ใช้ [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) เพื่อกำหนดปลายของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) มีลักษณะปลายสามแบบชัดเจน:

- `Flat`: เส้นหยุดที่จุดสุดท้าย
- `Round`: ปลายครึ่งวงกลมขยายออกนอกจุดสุดท้ายครึ่งความกว้างของเส้น
- `Square`: ปลายสี่เหลี่ยมขยายออกนอกจุดสุดท้ายครึ่งความกว้างของเส้น

คลาสยังมี `NotDefined` ซึ่งหมายความว่าไม่มีการกำหนดลักษณะปลายอย่างชัดเจน

ปลายต่างจากหัวลูกศรซึ่งเพิ่มสัญลักษณ์ที่ปลายเส้น และการเชื่อมต่อซึ่งควบคุมมุมที่เชื่อมระหว่างส่วนของเส้น ตัวอย่างนี้ปิดการใช้หัวลูกศรผ่าน [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) และ [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) เพื่อให้เปรียบเทียบเฉพาะรูปแบบปลาย

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกัน ความกว้าง 20 จุด จากบนลงล่างใช้ปลาย flat, round, และ square ตามลำดับ จุดสุดท้ายของเส้นมีพิกัดแนวนอนเดียวกัน; ปลาย round และ square จะขยายออกนอกจุดสุดท้าย 10 จุด

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

![ปลาย flat, round และ square บนเส้นหนาแบบเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตซ์กับเส้นของรูปทรง**

เอฟเฟกต์สเก็ตซ์ทำให้เส้นของรูปทรงดูเหมือนเขียนด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) เพื่อเข้าถึงการตั้งค่าสเก็ตซ์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)

โค้ด Python ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยตรง, และลบเอฟเฟกต์ด้วย [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)

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

ค่าที่ส่งคืนโดย [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปทรง ถ้าการจัดรูปแบบเส้นสามารถสืบทอดจากธีม มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) แล้วอ่านประเภทสเก็ตซ์จากการจัดรูปแบบเส้นที่มีผลลัพธ์ตามที่แสดงด้านล่าง ค่าที่มีผลแสดงการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดถูกแก้ไข ตัวอย่างนี้ต้องมีงานนำเสนอที่มีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรกและพิมพ์ค่าทั้งสอง

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

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมว่าต้นส่วนของเส้นขอบสองส่วนมาบรรจบกันที่มุมอย่างไร ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมที่ทำให้เรียบ

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำ 3 รูปที่มีเส้นขอบสีน้ำเงินความกว้าง 15 จุด ใช้ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) เพื่อกำหนดค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) ตามลำดับ เพื่อเปรียบเทียบว่ามุมถูกวาดอย่างไร

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

### **จำกัดการเชื่อมต่อแบบ Miter ที่มุมแหลม**

ใช้ [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) ร่วมกับ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) ที่ตั้งเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมแหลมสามารถยื่นออกได้

ขีดจำกัดคืออัตราส่วนของระยะห่างระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวของมิตเตอร์ได้สูงสุดถึงแปดเท่าของความกว้างของเส้น; ค่าดังกล่าวไม่ใช่หน่วยเป็นจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขีดจำกัดที่ใหญ่ขึ้นจะทำให้จุดแหลมขึ้น การตั้งค่านี้มีผลต่อการเชื่อมต่อแบบ miter เท่านั้น และการเปลี่ยนแปลงจะไม่มีผลตั้งแต่มุมยังคงอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมที่ไม่มีการเติมสีสองรูปที่มีเส้นขอบความกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ขีดจำกัด `2` และด้านขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาวมิตเตอร์ต่อความกว้างของเส้นประมาณ `4.12` ดังนั้น PowerPoint จะทำการ bevel ที่ยอดซ้ายและรักษายอดขวาไว้

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

![ยอดที่ทำ bevel ด้วย miter limit 2 และยอดแหลมด้วย miter limit 8 ใน PowerPoint](miter-limits.png)

## **การเติมแบบไล่สี (Gradient Fill)**

การเติมไล่สีผสมสีภายในรูปทรง ตัวอย่างนี้เติมวงรีด้วยไล่สีเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat) วิธี [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) จะวางจุดสีที่ตำแหน่ง 0 และ 1 ซึ่งเป็นจุดเริ่มต้นและสิ้นสุดของไล่สี การลบจุดสีที่มีอยู่เดิมทำให้ใช้เฉพาะสองสีนี้เท่านั้น

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

![วงรีที่มีการเติมไล่สี](gradient-fill.png)

หากไล่สีแสดงผลต่างกันในภาพที่ส่งออกเทียบกับ PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่สีที่เก็บอยู่ในงานนำเสนอ

### **กำหนดมุมไล่สีเชิงเส้น**

ใช้ [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) เพื่อควบคุมทิศทางของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` จากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน มุมที่เป็นเศษส่วนก็รองรับ มุมที่อยู่นอกช่วง `[0, 360)` จะถูกทำให้เป็นหนึ่งรอบ เช่น `-45` กลายเป็น `315` และ `360` กลายเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกรูปที่มีจุดสีแดง เขียว และน้ำเงินที่ตำแหน่ง `0`, `0.5`, และ `1` เหมือนกัน การสเกลถูกปิดเพื่อให้เปรียบเทียบมุมโดยไม่สนอัตราส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และในแถวที่สองคือ `135`, `180`, `270`

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

![ไล่สีเชิงเส้นที่มุม 0, 45, และ 90 องศาในแถวบน, และ 135, 180, และ 270 องศาในแถวล่าง](linear-gradient-angles.png)

### **สเกลไล่สีเชิงเส้นตามรูปทรง**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) รับค่า [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) กำหนดเป็น `False_` เพื่อคงมุมไล่สีเชิงเรขาคณิตเมื่อตัวรูปทรงเปลี่ยนอัตราส่วน, หรือ `True_` เพื่อสเกลไล่สีตามความกว้างและความสูงของรูปทรง เมื่อเปิดการสเกล มุมที่มองเห็นอาจแตกต่างจากมุมที่กำหนดบนรูปทรงที่ไม่ใช่สี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและจุดสีเดียวกันกับการเปรียบเทียบมุม คอลัมน์ซ้ายใช้ `False_`; คอลัมน์ขวาใช้ `True_` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างอยู่เหนือสี่เหลี่ยมสูง ทั้งสองเริ่มจากขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมตอบสนองต่อการปรับขนาดโดยไม่เปลี่ยนการตั้งค่าไล่สี

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

ผลลัพธ์ใน PowerPoint, โดยปิดการสเกลด้านซ้ายและเปิดการสเคลด้านขวา:

![สี่เหลี่ยมกว้างและสูงที่มีไล่สี 45 องศา, เปรียบเทียบ LinearGradientScaled False ด้านซ้ายกับ True ด้านขวา](linear-gradient-scaling.png)

เมื่อปิดการสเกล แถบสีทแยงมุมคงทิศทางเดิมในทั้งสองสี่เหลี่ยม เมื่อเปิดการสเกล แถบสีจะยืดตามอัตราส่วนของรูปทรง ช่วยทำสำเนาไล่สีของเทมเพลตเมื่อปรับรูปทรงให้มีขนาดต่างกัน บนสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่ทำให้ลักษณะของไล่สี `45` องศานี้เปลี่ยน

ทั้งมุมและการสเกลใช้กับไล่สีเชิงเส้น ไม่ใช้กับการเติม [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)

### **ผสานมุมกับทิศทางไล่สี**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) เลือกสไตล์ไล่สีจากคลาส [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) ไม่ใช่ตัวแทนของมุมเชิงตัวเลข สำหรับไล่สีเชิงเส้น รูปแบบมุมอาจเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) ควรรักษาทิศทางไม่เปลี่ยนเมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันในลำดับที่ตรงกันสลับกัน สี่เหลี่ยมสองรูปมีรูปลักษณ์เดียวกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

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

## **การเติมแบบลาย (Pattern Fill)**

การเติมแบบลายใช้การออกแบบสองสี เช่น จุด, แถบ, หรือตาราง ตัวอย่างนี้ใช้ [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) เพื่อเลือกลาย trellis. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) ให้พื้นหลังสีเทอ่อน, และ [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) ให้สีเหลืองสำหรับลาย

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

## **การเติมรูปภาพ (Picture Fill)**

การเติมรูปภาพใช้รูปภาพภายในรูปทรง ตัวอย่างนี้ต้องการรูปภาพ локал иใช้ [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) เพื่อโหลดเข้าคอลเลคชันรูปภาพของงานนำเสนอ การตั้งค่า [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) เป็นโหมดซ้ำจะทำให้รูปภาพปรากฏหลายครั้งภายในสี่เหลี่ยม รูปภาพต้นแบบที่ใช้แสดงด้านล่าง:

![รูปภาพบัว lotus](lotus.png)

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

![รูปทรงที่มีการเติมรูปภาพ](picture-fill.png)

### **ทำให้รูปภาพเป็นเท็กซ์เจอร์แบบซ้ำ**

หากต้องการตั้งค่ารูปภาพเป็นเท็กซ์เจอร์แบบซ้ำและปรับพฤติกรรมการซ้ำ สามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): กำหนดโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุตำแหน่งการจัดแนวของเท็กซ์เจอร์ภายในรูปทรง
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่าการซ้ำจะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): กำหนดการยกเลิกแนวนอนของเท็กซ์เจอร์ (หน่วยจุด) จากจุดกำเนิดของรูปทรง
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): กำหนดการยกเลิกแนวตั้งของเท็กซ์เจอร์ (หน่วยจุด) จากจุดกำเนิดของรูปทรง
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของเท็กซ์เจอร์เป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของเท็กซ์เจอร์เป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการรูปภาพ локал иกำหนดให้ [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) ซ้ำที่ 50% ของขนาดดั้งเดิม การยกเลิก `−32` จุดจะเลื่อนเท็กซ์เจอร์ทำให้ซ้อนได้ทั้งแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการพลิกในทิศทางทั้งสองกำหนดวิธีการจัดเรียงเท็กซ์เจอร์ที่ซ้ำ

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

![ตัวเลือกการซ้ำเท็กซ์เจอร์](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

การเติมสีทึบให้รูปทรงสีเดียวสม่ำเสมอ ตัวอย่างนี้ใช้ [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) เพื่อกำหนดโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) จากนั้นบันทึกสี่เหลี่ยมในงานนำเสนอ

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

![รูปทรงที่เติมสีทึบ](solid-color-fill.png)

## **ใช้พื้นหลังสไลด์เป็นการเติมรูปทรง**

ใช้ [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) เมื่อรูปทรงต้องการให้ตรงกับพื้นหลังสไลด์ เช่น ในเทมเพลตงานนำเสนอ ตั้งค่า [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) เป็น [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) ก่อนเพื่อเอาการเติมที่กำหนดไว้ออก ด้วยการผสมนี้ รูปทรงจะใช้พื้นหลังสไลด์แทนการเติมตามสไตล์ของมันเอง การเปิดฟลักนี้ตามลำพังไม่ได้ลบการเติมที่กำหนดไว้ก่อนหน้า

นี่แตกต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) : การเติมพื้นหลังจะครอบวัตถุที่อยู่ด้านหลังรูปทรงด้วยพื้นที่พื้นหลังของสไลด์เดียวกัน, ส่วน NoFill จะทำให้วัตถุเหล่านั้นยังมองเห็นได้ ไร่กราดิเอนท์ยังคงจัดตำแหน่งตามสไลด์แทนที่จะเริ่มใหม่ภายในแต่ละรูปทรง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สืบทอดโดยสไลด์และวางแถบสีม่วงด้านหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, และสี่เหลี่ยมขวาสลับจากการเติมพื้นหลังเป็นการเติมสีส้มที่กำหนดอย่างชัดเจน

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

    # สืบทอดไล่สีจากมาสเตอร์.
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

    # เพิ่มอ็อบเจ็กต์นี้เป็นอันดับแรกเพื่อให้แสดงอยู่ด้านหลังสี่เหลี่ยม.
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

    # ปิดการเติมพื้นหลังก่อนที่จะใช้การเติมแบบชัดเจน.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์จากซ้ายไปขวา: **การเติมพื้นหลัง**, **ไม่มีการเติม**, และ **การเติมที่กำหนดโดยชัดเจน** แถบสีม่วงซ่อนอยู่หลังสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นได้ผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มที่กำหนดบนแถบสีม่วง](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปทรงใช้พื้นหลังที่สไลด์กำหนดแล้ว; ตัวอย่างนี้ไม่ได้กำหนดพื้นหลังของสไลด์และเลย์เอาต์เพื่อให้มาสเตอร์จัดหาให้

## **กำหนดความโปร่งใส**

สำหรับการเติมสีทึบ ส่วนประกอบอัลฟาของสีควบคุมความทึบ: 0 คือโปร่งใสเต็มที่และ 255 คือทึบเต็มที่ ตัวอย่างนี้ใช้ค่าอัลฟา 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างมองเห็นอยู่ สีถูกกำหนดผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor)

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

![รูปทรงที่โปร่งใส](shape-transparency.png)

## **หมุนรูปทรง**

ใช้ [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) เพื่อหมุนรูปทรงในระนาบสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

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

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์เบเวล 3D**

ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) เพื่อให้รูปทรงมีความลึกและขอบเบเวล ตัวอย่างนี้สร้างวงรีสีเขียวกับเส้นขอบสีส้ม ใช้ [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) กำหนดความลึกเป็น 4 จุดและใช้ [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) เพื่อใส่เบเวลด้านบนแบบวงกลมที่มีความกว้างและความสูง 6 จุด กล้องแบบออร์โธกราฟิกที่มองหน้าและแสงสามจุดทำให้เบเวลมองเห็นได้

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

![เอฟเฟกต์เบเวล 3D](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3D**

มุมมอง 3D ของรูปทรงควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) กับมุมละติจูด, ลองจิจูด, และรอบการหมุนที่ 40°, 35°, และ 20° ตามลำดับ เลือกกล้องแบบอิซอเมตริกผ่าน [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) และแสงสมดุลผ่าน [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) จากนั้นบันทึกสี่เหลี่ยมที่จัดรูปแบบ

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

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **ควบคุมการแสดงผลสีขาว‑ดำสำหรับรูปทรง**

เมธอด [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) ระบุว่ารูปทรงแต่ละอันจะถูกเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว‑ดำ ไม่ได้เปิดใช้งานการแสดงผลสีขาว‑ดำโดยอัตโนมัติและไม่เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่น ๆ ของรูปทรงในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับสีเดียว, `Color` รักษาสีปกติ, และ `Hidden` ไม่แสดงรูปทรงในโหมดสีขาว‑ดำ `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปทรง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) ตั้งค่าเป็นสีเทา รูปที่บันทึกจะคงสีส้มสำหรับการแสดงสีปกติและขอให้แอปพลิเคชันที่เคารพการตั้งค่าสีขาว‑ดำใช้สีเทา:

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

ในโหมดสีปกติ สี่เหลี่ยมคงสีส้มไว้ ในเวิร์กโฟลว์การแสดงสีขาว‑ดำ จะใช้สีเทาเพราะโหมดตั้งเป็น `Gray` สิ่งนี้ทำให้คุณคงสไลด์สีเต็มในขณะที่กำหนดลักษณะเฉพาะสำหรับการพิมพ์, การพรีวิว, หรือเวิร์กโฟลว์อื่น ๆ ที่เคารพการตั้งค่าสีขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) เพื่อคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของ placeholder ในสไลด์จาก placeholder ที่สอดคล้องในเลย์เอาต์ ตัวอย่างนี้ต้องมีงานนำเสนอที่มี placeholder เชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปทรงที่ไม่มี placeholder ที่สอดคล้องในเลย์เอาต์จะไม่ถูกรีเซ็ต

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

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังอยู่ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพถูกจัดเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สCorresponding match ทั้งหมดตรงกัน ให้ถือว่ารูปแบบเป็นแบบเดียวกันและจัดกลุ่มรูปทรงเหล่านั้นเชิงตรรกะ ซึ่งทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์หรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปทรงที่สไตล์ไว้ที่ต้องการ, และนำไปใช้ใหม่ตามที่ต้องการ.