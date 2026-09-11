---
title: จัดรูปแบบรูปร่าง PowerPoint ใน Python ผ่าน Java
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/python-java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างสีขาว-ดำ
- การเรนเดอร์รูปร่างเทา
- หมุนรูปร่าง
- เอฟเฟกต์ขอบ 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP อย่างแม่นยำและควบคุมเต็มรูปแบบ"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้นต่าง ๆ คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับเส้นขอบของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปร่างได้โดยระบุการตั้งค่าที่ควบคุมการเติมสีภายในของรูปร่าง

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java มีคลาสและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกันกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นที่กำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้สรุปขั้นตอนการทำงาน:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[LineStyle](https://reference.aspose.com/slides/th/python-java/aspose.slides/linestyle/)ของรูปร่าง  
1. ตั้งค่าความกว้างของเส้น  
1. ตั้งค่า[DashStyle](https://reference.aspose.com/slides/th/python-java/aspose.slides/linedashstyle/)ของเส้น  
1. ตั้งค่าสีของเส้นสำหรับรูปร่าง  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบ[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)รูปสี่เหลี่ยมผืนผ้า:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมผืนผ้า
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยม
    shape.getFillFormat().setFillType(FillType.NoFill)

    # ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The formatted lines in the presentation](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้[Shape.getLineFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getLineFormat)เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/lineformat/#getSketchFormat)เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ[SketchFormat.setSketchType](https://reference.aspose.com/slides/th/python-java/aspose.slides/sketchformat/#setSketchType)เพื่อเลือกค่าจาก enumeration[LineSketchType](https://reference.aspose.com/slides/th/python-java/aspose.slides/linesketchtype/)

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์[LineSketchType.Curved](https://reference.aspose.com/slides/th/python-java/aspose.slides/linesketchtype/#Curved), อ่านค่าที่กำหนดโดยชัดเจน, และลบเอฟเฟ็กต์ด้วย[LineSketchType.None_](https://reference.aspose.com/slides/th/python-java/aspose.slides/linesketchtype/#None):

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

    # เข้าถึงการจัดรูปแบบเส้นของรูปร่างและรูปแบบสเก็ตช์ของมัน.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # นำเอฟเฟกต์สเก็ตช์ไปใช้.
    sketch_format.setSketchType(LineSketchType.Curved)

    # อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปร่าง.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # ลบเอฟเฟกต์สเก็ตช์.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

ค่าที่คืนจาก[SketchFormat.getSketchType](https://reference.aspose.com/slides/th/python-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้[LineFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/lineformat/#getEffective), เข้าถึง`LineFormatEffectiveData.getSketchFormat`, และอ่าน`SketchFormatEffectiveData.getSketchType` ค่าที่มีผลจริงจะแสดงการจัดรูปแบบที่ถูกนำไปใช้จริงหลังจากสืบทอดเสร็จ:

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

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round  
* Miter  
* Bevel  

โดยค่าเริ่มต้น PowerPoint จะใช้การตั้งค่า**Round** เมื่อเชื่อมเส้นสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมคม คุณอาจต้องการเลือกตัวเลือก**Miter**

![The join style in the presentation](join-style-powerpoint.png)

โค้ด Python ต่อไปนี้สาธิตวิธีสร้างสี่เหลี่ยมสามรายการ (ตามภาพด้านบน) โดยใช้การตั้งค่าการเชื่อมต่อ Miter, Bevel, และ Round:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติสามรูปประเภทสี่เหลี่ยมผืนผ้า
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # ตั้งค่าสีเติมสำหรับแต่ละรูปร่างสี่เหลี่ยม
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # ตั้งค่าความกว้างของเส้น
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # ตั้งค่าสไตล์การเชื่อมต่อ
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # เพิ่มข้อความในแต่ละสี่เหลี่ยม
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เติมสีไล่ระดับ (Gradient Fill)**

ใน PowerPoint, Gradient Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณใส่การไล่สีต่อเนื่องลงในรูปร่าง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่านั้นโดยให้สีหนึ่งค่อย ๆ จางลงเป็นอีกสีหนึ่ง

นี่คือลำดับขั้นตอนการใช้ Gradient Fill กับรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/)ของรูปร่างเป็น`Gradient`  
1. ใช้วิธี[addPresetColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/gradientstopcollection/#addPresetColor)ของคอลเลคชัน GradientStop เพื่อเพิ่มสีที่ต้องการสองสีพร้อมตำแหน่งที่กำหนดในคลาส[GradientFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/gradientformat/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ Gradient Fill กับรูปวงรี:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

    # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
    presentation = Presentation()
    try:
        # ดึงสไลด์แรก
        slide = presentation.getSlides().get_Item(0)

        # เพิ่มรูปร่างอัตโนมัติประเภทวงรี
        shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

        # ใช้การจัดรูปแบบไล่ระดับสีกับวงรี
        shape.getFillFormat().setFillType(FillType.Gradient)
        shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

        # ตั้งค่าทิศทางของการไล่ระดับสี
        shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

        # เพิ่มจุดหยุดไล่ระดับสีสองจุด
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

        # บันทึกไฟล์ PPTX ไปยังดิสก์
        presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

ผลลัพธ์:

![The ellipse with gradient fill](gradient-fill.png)

## **เติมลาย (Pattern Fill)**

ใน PowerPoint, Pattern Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณใส่การออกแบบสองสี—เช่นจุด, ลายเส้น, ลายตะแกรง, หรือลายสลับ—ลงในรูปร่าง คุณสามารถเลือกสีที่กำหนดเองสำหรับสีพื้นหน้าและสีพื้นหลังของลายได้

Aspose.Slides มีลายแบบที่กำหนดล่วงหน้า กว่า 45 แบบที่คุณสามารถใช้กับรูปร่างเพื่อเพิ่มความสวยงามให้กับงานนำเสนอ ของคุณ แม้จะเลือกลายแบบที่กำหนดแล้ว คุณก็ยังสามารถระบุสีที่ต้องการใช้ได้อย่างแม่นยำ

ขั้นตอนการใช้ Pattern Fill กับรูปร่างโดยใช้ Aspose.Slides มีดังนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/)ของรูปร่างเป็น`Pattern`  
1. เลือกสไตล์ลายจากตัวเลือกที่กำหนดล่วงหน้า  
1. ตั้งค่า[Background Color](https://reference.aspose.com/slides/th/python-java/aspose.slides/patternformat/#getBackColor)ของลาย  
1. ตั้งค่า[Foreground Color](https://reference.aspose.com/slides/th/python-java/aspose.slides/patternformat/#getForeColor)ของลาย  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีใช้ Pattern Fill กับสี่เหลี่ยม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมผืนผ้า
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ตั้งค่าประเภทการเติมเป็น Pattern
    shape.getFillFormat().setFillType(FillType.Pattern)

    # ตั้งค่าสไตล์ลาย
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลาย
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The rectangle with pattern fill](pattern-fill.png)

## **เติมรูปภาพ (Picture Fill)**

ใน PowerPoint, Picture Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพภายในรูปร่าง—โดยใช้รูปภาพเป็นพื้นหลังของรูปร่าง

นี่คือวิธีใช้ Aspose.Slides เพื่อเติมรูปภาพลงในรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/)ของรูปร่างเป็น`Picture`  
1. ตั้งค่าโหมดการเติมรูปภาพเป็น`Tile` (หรือโหมดอื่นที่ต้องการ)  
1. สร้างอ็อบเจกต์[PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/)จากภาพที่ต้องการใช้  
1. ส่งภาพไปยังเมธอด`SlidesPicture.setImage`  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

สมมติว่าเรามีไฟล์"lotus.png"พร้อมรูปภาพต่อไปนี้:

![The lotus picture](lotus.png)

โค้ด Python ต่อไปนี้แสดงวิธีเติมรูปร่างด้วยรูปภาพ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมผืนผ้า
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # ตั้งค่าประเภทการเติมเป็น Picture
    shape.getFillFormat().setFillType(FillType.Picture)

    # ตั้งค่าโหมดการเติมรูปภาพ
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # ตั้งค่ารูปภาพ
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งค่ารูปภาพแบบต่อเป็นพื้นผิวและปรับพฤติกรรมการต่อเป็นกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส[PictureFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`  
- [setTileAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#setTileAlignment): กำหนดการจัดแนวของกระเบื้องภายในรูปร่าง  
- [setTileFlip](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมการพลิกกระเบื้องในแนวนอน, แนวตั้ง หรือทั้งสองอย่าง  
- [setTileOffsetX](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าการเลื่อนระดับแนวนอนของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง  
- [setTileOffsetY](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าการเลื่อนระดับแนวตั้งของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง  
- [setTileScaleX](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์  
- [setTileScaleY](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปร่างสี่เหลี่ยมที่ใช้การเติมรูปภาพแบบต่อกระเบื้องและกำหนดตัวเลือกกระเบื้อง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    first_slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมผืนผ้า
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # ตั้งค่าประเภทการเติมของรูปร่างเป็น Picture
    shape.getFillFormat().setFillType(FillType.Picture)

    # โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # กำหนดภาพให้กับรูปร่าง
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการต่อกระเบื้อง
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The tile options](tile-options.png)

## **เติมสีทึบ (Solid Color Fill)**

ใน PowerPoint, Solid Color Fill เป็นตัวเลือกการจัดรูปแบบที่เติมรูปร่างด้วยสีเดียวที่สม่ำเสมอ สีพื้นหลังแบบเรียบนี้ไม่มีการไล่สี, ส纹 หรือลายใด ๆ

เพื่อใช้ Solid Color Fill กับรูปร่างโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/)ของรูปร่างเป็น`Solid`  
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีใช้ Solid Color Fill กับสี่เหลี่ยมในสไลด์ PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมผืนผ้า
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ตั้งค่าประเภทการเติมเป็น Solid
    shape.getFillFormat().setFillType(FillType.Solid)

    # ตั้งค่าสีเติม
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The shape with solid color fill](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส (Set Transparency)**

ใน PowerPoint, เมื่อคุณใช้สีทึบ, ไล่ระดับ, รูปภาพ หรือเทกซ์เจอร์เติมให้กับรูปร่าง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าโปร่งใสที่สูงกว่าจะทำให้รูปร่างดูโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณกำหนดระดับความโปร่งใสโดยปรับค่าอัลฟาในสีที่ใช้เติม นี่คือลำดับขั้นตอน:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/)เป็น`Solid`  
1. ใช้[Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html)เพื่อกำหนดสีพร้อมค่าโปร่งใส (คอมโพเนนต์ `alpha` ควบคุมความโปร่งใส)  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้สีเติมแบบโปร่งใสกับสี่เหลี่ยม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมทึบ
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งแสงเหนือรูปร่างทึบ
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The transparent shape](shape-transparency.png)

## **หมุนรูปร่าง (Rotate Shapes)**

Aspose.Slides ช่วยให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อกำหนดตำแหน่งขององค์ประกอบภาพตามการจัดแนวหรือการออกแบบเฉพาะ

ขั้นตอนการหมุนรูปร่างบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่าคุณสมบัติการหมุนของรูปร่างเป็นมุมที่ต้องการ  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีหมูรูปร่างโดย 5 องศา:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมผืนผ้า
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # หมุนรูปร่างโดย 5 องศา
    shape.setRotation(5)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The shape rotation](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ขอบ 3 มิติ (Add 3D Bevel Effects)**

Aspose.Slides ให้คุณใช้เอฟเฟกต์ขอบ 3 มิติบนรูปร่างโดยกำหนดคุณสมบัติ[ThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/)

ขั้นตอนการเพิ่มเอฟเฟกต์ขอบ 3 มิติให้กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. กำหนดค่า[ThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/)ของรูปร่างเพื่อระบุการตั้งค่าขอบ  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ขอบ 3 มิติบนรูปร่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างลงในสไลด์
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The 3D bevel effect](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ (Add 3D Rotation Effects)**

Aspose.Slides ให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่างโดยกำหนดคุณสมบัติ[ThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/)

ขั้นตอนการใช้การหมุน 3 มิติบนรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)ลงในสไลด์  
1. ใช้เมธอด[setCameraType](https://reference.aspose.com/slides/th/python-java/aspose.slides/camera/#setCameraType)และ[setLightType](https://reference.aspose.com/slides/th/python-java/aspose.slides/lightrig/#setLightType)เพื่อกำหนดการหมุน 3 มิติ  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The 3D rotation effect](3D-rotation-effect.png)

## **ควบคุมการแสดงผลสีขาว-ดำของรูปร่าง (Control Black-and-White Rendering for Shapes)**

เมธอด[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setBlackWhiteMode) กำหนดวิธีที่รูปร่างแต่ละอันจะแสดงผลเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว-ดำ มันไม่ได้เปิดใช้งานการแสดงผลสีขาว-ดำโดยอัตโนมัติ และไม่ได้เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส[BlackWhiteMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้สีดำและสีขาวเท่านั้น, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` รักษาสีปกติ, `Hidden` ไม่แสดงรูปร่างในโหมดสีขาว-ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

โค้ด Python ต่อไปนี้สร้างรูปร่างสีและทำให้แสดงเป็นสีเทาในโหมดแสดงผลสีขาว-ดำ:

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # คงการเติมสีส้มในโหมดสี, แต่เรนเดอร์รูปร่างด้วยสีเทาในโหมดสีขาว-ดำ.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ในโหมดสีปกติ สี่เหลี่ยมยังคงมีสีส้มตามเดิม ในกระบวนการแสดงผลสีขาว-ดำ มันจะใช้สีเทาเนื่องจากโหมดถูกตั้งค่าเป็น `Gray` ซึ่งทำให้คุณสามารถเก็บสไลด์สีเต็มในขณะที่กำหนดลักษณะการแสดงผลที่แตกต่างสำหรับการพิมพ์, การพรีวิว หรือเวิร์กโฟลว์อื่น ๆ ที่เคารพการตั้งค่าแสดงผลสีขาว-ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ (Reset Formatting)**

โค้ด Python ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholder บน[LayoutSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/) ไปยังค่าตั้งต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # รีเซ็ตแต่ละรูปร่างบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย (FAQ)**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบเล็กน้อยมาก ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ไฟล์ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปร่าง เช่น สี, เอฟเฟกต์, และไล่สี จะถูกเก็บเป็นเมตาดาต้าและเพิ่มขนาดไฟล์เพียงเล็กน้อยเท่านั้น

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีรูปแบบการจัดรูปแบบเดียวกันเพื่อจะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกัน ให้นำสไตล์เหล่านั้นถือว่าเหมือนกันและจัดกลุ่มรูปร่างเหล่านั้นแบบตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ คุณสามารถเก็บตัวอย่างรูปร่างพร้อมสไตล์ที่ต้องการในสไลด์แม่แบบหรือไฟล์ .POTX จากนั้นเมื่อต้องสร้างงานนำเสนอใหม่ ให้เปิดแม่แบบนั้น, คัดลอกรูปร่างที่มีสไตล์ที่ต้องการ, และนำการจัดรูปแบบกลับไปใช้ตามที่จำเป็น