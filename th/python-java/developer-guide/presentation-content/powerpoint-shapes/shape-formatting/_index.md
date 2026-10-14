---
title: จัดรูปแบบรูปทรง PowerPoint ใน Python ผ่าน Java
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/python-java/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- เอฟเฟ็กต์สเก็ตช์
- เส้นรูปทรงสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมเท็กซ์เจอร์
- การเติมสีทึบ
- ความโปร่งใสของรูปทรง
- การแสดงผลรูปทรงสีขาว-ดำ
- การแสดงผลรูปทรงระดับสีเทา
- การหมุนรูปทรง
- เอฟเฟ็กต์เบเวล 3 มิติ
- เอฟเฟ็กต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้น และเอฟเฟ็กต์สำหรับไฟล์ PPT, PPTX และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟ็กต์กับเส้นรอบ นอกจากนี้คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมการเติมส่วนภายในของรูปทรง

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java ให้คลาสและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ด้วย Aspose.Slides คุณสามารถกำหนดสไตล์เส้นที่กำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) ของรูปทรง  
1. ตั้งค่าความกว้างของเส้น  
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) ของเส้น  
1. ตั้งค่าสีของเส้นสำหรับรูปทรง  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบสี่เหลี่ยม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
presentation = Presentation()
try:
    # รับสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปของประเภท Rectangle
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # กำหนดสีเติมสำหรับรูปทรงสี่เหลี่ยม
    shape.getFillFormat().setFillType(FillType.NoFill)

    # ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # กำหนดสีสำหรับเส้นของสี่เหลี่ยม
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The formatted lines in the presentation](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นรูปทรง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นรูปทรงดูเหมือนถูกวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) อ่านค่าที่กำหนดโดยชัดเจน และลบเอฟเฟกต์ด้วย [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None):

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

    # เข้าถึงรูปแบบเส้นของรูปทรงและรูปแบบสเก็ตช์ของมัน.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # ใช้เอฟเฟกต์สเก็ตช์.
    sketch_format.setSketchType(LineSketchType.Curved)

    # อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปทรง.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # ลบเอฟเฟกต์สเก็ตช์.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

ค่าที่คืนจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), เข้าถึง `LineFormatEffectiveData.getSketchFormat`, แล้วอ่าน `SketchFormatEffectiveData.getSketchType` ค่าที่มีประสิทธิผลจะแสดงการจัดรูปแบบที่จริง ๆ ถูกนำไปใช้หลังจากสืบทอดเสร็จสิ้น:

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

## **จัดรูปแบบสไตล์การเชื่อมต่อ (Join Styles)**

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round  
* Miter  
* Bevel  

โดยค่าเริ่มต้น PowerPoint จะใช้การตั้งค่า **Round** เมื่อเชื่อมเส้นสองเส้นที่มุม (เช่น ที่มุมของรูปทรง) อย่างไรก็ตาม หากคุณวาดรูปทรงที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter** แทน

![The join style in the presentation](join-style-powerpoint.png)

โค้ด Python ต่อไปนี้สาธิตการสร้างสี่เหลี่ยมสามรูป (ตามภาพด้านบน) โดยใช้การตั้งค่า Join Type เป็น Miter, Bevel, และ Round ตามลำดับ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปสามรูปประเภท Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # กำหนดสีเติมสำหรับแต่ละรูปทรงสี่เหลี่ยม.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # กำหนดความกว้างของเส้น.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # กำหนดสีสำหรับเส้นของแต่ละสี่เหลี่ยม.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # กำหนดสไตล์การเชื่อมต่อ.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # เพิ่มข้อความให้แต่ละสี่เหลี่ยม.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เติมสีแบบไล่ระดับ (Gradient Fill)**

ใน PowerPoint, Gradient Fill คือตัวเลือกการจัดรูปแบบที่ให้คุณใช้การไล่สีอย่างต่อเนื่องกับรูปทรง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่าที่สีหนึ่งค่อย ๆ ผสมลายเข้าสู่สีถัดไป

วิธีการใช้ Gradient Fill กับรูปทรงด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`  
1. ใช้วิธีการ [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) ของคอลเลกชัน GradientStop ที่เปิดเผยโดยคลาส [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) เพื่อเพิ่มสีสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนดไว้  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีใช้ Gradient Fill กับวงรี:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปประเภท Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # ใช้การจัดรูปแบบ Gradient กับวงรี.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # กำหนดทิศทางของ Gradient.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # เพิ่มจุดหยุด Gradient สองจุด.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The ellipse with gradient fill](gradient-fill.png)

หาก Gradient ดูแตกต่างในภาพที่ส่งออกเทียบกับใน PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยน Gradient Fill ที่เก็บไว้ในงานนำเสนอ

## **เติมลวดลาย (Pattern Fill)**

ใน PowerPoint, Pattern Fill คือตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, แถบ, รูลูกไม้ หรือการตรวจสอบ—กับรูปทรง คุณสามารถกำหนดสีของพื้นหน้าและพื้นหลังของลวดลายได้ตามต้องการ

Aspose.Slides มีลวดลายที่กำหนดไว้ล่วงหน้ากว่า 45 แบบที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้กับงานนำเสนอของคุณ แม้จะเลือกลวดลากำหนดไว้แล้ว คุณก็ยังสามารถระบุสีที่แน่นอนที่ต้องการใช้ได้

วิธีการใช้ Pattern Fill กับรูปทรงด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`  
1. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า  
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) ของลวดลาย  
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) ของลวดลาย  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้สาธิตการใช้ Pattern Fill กับสี่เหลี่ยม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปประเภท Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # ตั้งค่าสไตล์ลวดลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลวดลาย.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The rectangle with pattern fill](pattern-fill.png)

## **เติมรูปภาพ (Picture Fill)**

ใน PowerPoint, Picture Fill คือตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพเข้าไปในรูปทรง—โดยใช้รูปภาพเป็นพื้นหลังของรูปทรง

วิธีการใช้ Aspose.Slides เพื่อทำ Picture Fill กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) ของรูปทรงเป็น `Picture`  
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นที่คุณต้องการ)  
1. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) จากรูปภาพที่คุณต้องการใช้  
1. ส่งภาพนี้ให้เมธอด `SlidesPicture.setImage`  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

สมมติว่าเรามีไฟล์ "lotus.png" พร้อมรูปภาพต่อไปนี้:

![The lotus picture](lotus.png)

โค้ด Python ต่อไปนี้แสดงวิธีเติมรูปภาพลงในรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปประเภท Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # ตั้งค่าชนิดการเติมเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # ตั้งค่าโหมดการเติมรูปภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # โหลดภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # ตั้งค่ารูปภาพ.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งรูปภาพเป็นเท็กซ์เจอร์แบบกระเบื้องและกำหนดพฤติกรรมการกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`  
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): กำหนดการจัดตำแหน่งของกระเบื้องภายในรูปทรง  
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่ากระเบื้องจะถูกพลิกแนวนอน, แนวตั้ง หรือทั้งสองอย่าง  
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): กำหนดค่าการเลื่อนแนวนอนของกระเบื้อง (หน่วยเป็นพอยต์) จากจุดกำเนิดของรูปทรง  
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): กำหนดค่าการเลื่อนแนวตั้งของกระเบื้อง (หน่วยเป็นพอยต์) จากจุดกำเนิดของรูปทรง  
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์  
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมพร้อม Picture Fill แบบกระเบื้องและกำหนดตัวเลือกการกระเบื้อง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    first_slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปสี่เหลี่ยม.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # โหลดภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # กำหนดภาพให้กับรูปทรง.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการกระเบื้อง.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The tile options](tile-options.png)

## **เติมสีทึบ (Solid Color Fill)**

ใน PowerPoint, Solid Color Fill คือการจัดรูปแบบที่เติมสีเดียวอย่างสม่ำเสมอลงในรูปทรง สีพื้นหลังแบบเรียบนี้จะถูกใช้โดยไม่มีการไล่สี, เท็กซ์เจอร์ หรือ ลวดลายใด ๆ

เพื่อใช้ Solid Color Fill กับรูปทรงด้วย Aspose.Slides ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) ของรูปทรงเป็น `Solid`  
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้สาธิตการใช้ Solid Color Fill กับสี่เหลี่ยมในสไลด์ PowerPoint:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปประเภท Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ตั้งค่าชนิดการเติมเป็น Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # ตั้งค่าสีเติม.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The shape with solid color fill](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส (Set Transparency)**

ใน PowerPoint เมื่อคุณใช้สีทึบ, Gradient, Picture หรือ Texture Fill กับรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าความโปร่งใสสูงจะทำให้รูปทรงใสมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ใต้หน้าต่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าระดับความโปร่งใสโดยปรับค่า alpha ของสีที่ใช้สำหรับการเติม วิธีทำคือ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) เป็น `Solid`  
1. ใช้ [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้สีเติมแบบโปร่งใสกับสี่เหลี่ยม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปสี่เหลี่ยมสีทึบ.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # เพิ่มออโต้ชาปสี่เหลี่ยมแบบโปร่งใสเหนือรูปทรงสีทึบ.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The transparent shape](shape-transparency.png)

## **หมุนรูปทรง (Rotate Shapes)**

Aspose.Slides ให้คุณหมุนรูปทรงในงานนำเสนอ PowerPoint ซึ่งมีประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพตามแนวจัดหรือความต้องการด้านออกแบบ

เพื่อหมุนรูปทรงบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้สาธิตการหมุนรูปทรงด้วยมุม 5 องศา:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มออโต้ชาปประเภท Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # หมุนรูปทรง 5 องศา.
    shape.setRotation(5)

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The shape rotation](shape-rotation.png)

## **เพิ่มเอฟเฟกต์เบเวล 3 มิติ (Add 3D Bevel Effects)**

Aspose.Slides ให้คุณทำเอฟเฟกต์เบเวล 3 มิติให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์เบเวล 3 มิติให้กับรูปทรง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) ของรูปทรงเพื่อระบุการตั้งค่าเบเวล  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์เบเวล 3 มิติกับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปทรงลงในสไลด์.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The 3D bevel effect](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ (Add 3D Rotation Effects)**

Aspose.Slides ให้คุณทำเอฟเฟกต์การหมุน 3 มิติให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)

เพื่อใช้การหมุน 3 มิติกับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามตำแหน่งดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3 มิติ  
1. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้สาธิตการใช้เอฟเฟกต์การหมุน 3 มิติกับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The 3D rotation effect](3D-rotation-effect.png)

## **ควบคุมการแสดงผลสีขาว-ดำของรูปทรง (Control Black-and-White Rendering for Shapes)**

เมธอด [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) ระบุว่ารูปทรงแต่ละอันจะแสดงผลอย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว-ดำ มันไม่ได้เปิดใช้งานการแสดงผลสีขาว-ดำโดยอัตโนมัติ และไม่ได้เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่น ๆ ของรูปทรงในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้สีดำและสีขาวเท่านั้น, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` คงสีปกติ, `Hidden` ไม่แสดงรูปทรงในโหมดสีขาว-ดำ, `NotDefined` หมายความว่าไม่มีการกำหนดโหมดระดับรูปทรง

โค้ด Python ต่อไปนี้สร้างรูปทรงสีและทำให้มันแสดงเป็นสีเทาในโหมดแสดงผลสีขาว-ดำ:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # เก็บการเติมสีส้มในโหมดสี, แต่เรนเดอร์รูปทรงด้วยสีเทาในโหมดสีขาว-ดำ.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ในโหมดสีปกติ สี่เหลี่ยมยังคงสีส้ม ในเวิร์กโฟลว์แสดงผลสีขาว-ดำ มันใช้สีเทาเพราะโหมดถูกตั้งเป็น `Gray` ซึ่งช่วยให้คุณเก็บสไลด์สีเต็มไว้พร้อมกำหนดการแสดงผลที่แตกต่างสำหรับการพิมพ์, การแสดงตัวอย่าง หรือเวิร์กโฟลว์อื่น ๆ ที่เคารพการตั้งค่าแสดงผลสีขาว-ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ (Reset Formatting)**

โค้ด Python ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทรงทั้งหมดที่มีตัวแทนใน [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) ไปยังค่าตั้งต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # รีเซ็ตแต่ละรูปทรงบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย (FAQ)**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบค่อนข้างน้อย ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ไฟล์ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปทรง เช่น สี, เอฟเฟกต์และการไล่สีจะถูกเก็บเป็นเมตาดาทาและเพิ่มขนาดไฟล์อย่างน้อยมาก

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ให้ถือว่าสไตล์เท่ากันและจัดกลุ่มรูปทรงเหล่านั้น ซึ่งช่วยให้ง่ายต่อการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ จัดเก็บรูปทรงตัวอย่างพร้อมสไตล์ที่ต้องการในเทมเพลตสไลด์เดคหรือไฟล์เทมเพลต .POTX เมื่อต้องการสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปทรงที่สไตล์ต้องการ และนำไปใช้ใหม่ตามที่ต้องการ