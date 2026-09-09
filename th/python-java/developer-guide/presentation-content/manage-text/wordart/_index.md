---
title: สร้างและใช้เอฟเฟ็กต์ WordArt ใน Python ผ่าน Java
linktitle: WordArt
type: docs
weight: 110
url: /th/python-java/wordart/
keywords:
- WordArt
- สร้าง WordArt
- แม่แบบ WordArt
- เอฟเฟ็กต์ WordArt
- เอฟเฟ็กต์เงา
- เอฟเฟ็กต์การสะท้อน
- เอฟเฟ็กต์แสงเรือง
- การแปลง WordArt
- เอฟเฟ็กต์ 3D
- เอฟเฟ็กต์เงานอก
- เอฟเฟ็กต์เงาภายใน
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟ็กต์ WordArt ใน Aspose.Slides สำหรับ Python ผ่าน Java คำแนะนำทีละขั้นตอนนี้ช่วยนักพัฒนาเพิ่มความโดดเด่นให้กับงานนำเสนอด้วยข้อความระดับมืออาชีพใน Python ผ่าน Java."
---
## **ภาพรวม**

เอฟเฟ็กต์ WordArt ช่วยให้คุณเพิ่มข้อความสไตล์ที่น่าสนใจและสวยงามในงานนำเสนอ PowerPoint ของคุณ ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt ได้โดยโปรแกรมเมชัน เช่นเดียวกับใน Microsoft PowerPoint — โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมการทำงานกับ WordArt รวมถึงวิธีการนำการแปลงข้อความ รูปแบบการเติม สีขอบ เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาในการนำเสนอของคุณมีความแสดงออกและดึงดูดมากขึ้น WordArt ทำให้คุณจัดการข้อความเป็นวัตถุกราฟิก มันประกอบด้วยเอฟเฟ็กต์หรือการปรับพิเศษที่ใช้กับข้อความเพื่อทำให้ดูน่าสนใจหรือเด่นขึ้น

## **สร้างเทมเพลต WordArt ง่ายและนำไปใช้กับข้อความ**

**ใช้ Aspose.Slides**

แรกสุด เราสร้างข้อความง่ายด้วยโค้ด Python นี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
ต่อมา เพิ่มขนาดฟอนต์เพื่อทำให้เอฟเฟ็กต์เด่นชัดขึ้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**ใช้ Microsoft PowerPoint**

ไปที่เมนูเอฟเฟ็กต์ WordArt ใน Microsoft PowerPoint:

![WordArt effects menu in PowerPoint](image-20200930113926-1.png)

จากเมนูด้านขวา คุณสามารถเลือกเอฟเฟ็กต์ WordArt ที่กำหนดล่วงหน้าได้ จากเมนูด้านซ้าย คุณสามารถกำหนดการตั้งค่าสำหรับ WordArt ใหม่

ต่อไปเป็นพารามิเตอร์หรือ ตัวเลือกที่มีให้เลือกบางส่วน:

![WordArt formatting options](image-20200930114015-3.png)

**ใช้ Aspose.Slides**

ที่นี่ เราใช้รูปแบบเติมลาย [PatternStyle.SmallGrid](https://reference.aspose.com/slides/th/python-java/aspose.slides/patternstyle/#SmallGrid) กับข้อความและเพิ่มขอบข้อความสีดำด้วยโค้ดนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

ข้อความที่ได้:

![Text with a pattern fill and black outline](image-20200930114108-4.png)

## **การใช้เอฟเฟ็กต์ WordArt อื่น ๆ**

**ใช้ Microsoft PowerPoint**

จากส่วนติดต่อของโปรแกรม คุณสามารถใช้เอฟเฟ็กต์เหล่านี้กับข้อความ กล่องข้อความ รูปร่าง หรือองค์ประกอบที่คล้ายกัน:

![Text and shape effects in PowerPoint](image-20200930114129-5.png)

ตัวอย่างเช่น เอฟเฟ็กต์เงา (Shadow) การสะท้อน (Reflection) และแสงเรือง (Glow) สามารถนำไปใช้กับข้อความ; เอฟเฟ็กต์รูปแบบ 3 มิติ (3D Format) และการหมุน 3 มิติ (3D Rotation) สามารถนำไปใช้กับกล่องข้อความ; เอฟเฟ็กต์ขอบนุ่ม (Soft Edges) สามารถนำไปใช้กับรูปร่าง (แม้ไม่มีเอฟเฟ็กต์ 3D Format ก็ตาม)

### **การใช้เอฟเฟ็กต์เงา**

โค้ด Python ต่อไปนี้ใช้เงาเฉพาะกับข้อความ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Aspose.Slides API รองรับเงาสามประเภท: [OuterShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/innershadow/), และ [PresetShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/presetshadow/)

ด้วย [PresetShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/presetshadow/) คุณสามารถใช้ค่า preset เพื่อใส่เงาให้กับข้อความได้

**ใช้ Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาประเภทเดียว นี่คือตัวอย่าง:

![Shadow settings in PowerPoint](image-20200930114225-6.png)

**ใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้คุณใช้เงาสองประเภทพร้อมกัน: [InnerShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/innershadow/) และ [PresetShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/presetshadow/)

**หมายเหตุ:**

- เมื่อใช้ [OuterShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/outershadow/) และ [PresetShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/presetshadow/) ร่วมกัน จะใช้เอฟเฟ็กต์ [OuterShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/outershadow/) เท่านั้น
- หากใช้ [OuterShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/outershadow/) และ [InnerShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/innershadow/) พร้อมกัน ผลลัพธ์หรือเอฟเฟ็กต์ที่ใช้จะขึ้นอยู่กับเวอร์ชันของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟ็กต์จะซ้อนกันสองครั้ง แต่ใน PowerPoint 2007 จะใช้เอฟเฟ็กต์ [OuterShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/outershadow/) เพียงอย่างเดียว

### **นำการสะท้อนมาใช้กับข้อความ**

เราติดตั้งการสะท้อนให้กับข้อความผ่านตัวอย่างโค้ดใน Python ผ่าน Java นี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **นำเอฟเฟ็กต์แสงเรือง (Glow) ไปใช้กับข้อความ**

เรานำเอฟเฟ็กต์แสงเรืองไปใช้กับข้อความเพื่อให้ส่องสว่างหรือเด่นขึ้นด้วยโค้ดนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

ผลลัพธ์ของการดำเนินการ:

![Text with a glow effect](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
คุณสามารถเปลี่ยนพารามิเตอร์สำหรับเงา การสะท้อน และแสงเรือง คุณสมบัติของเอฟเฟ็กต์จะถูกตั้งค่าแยกตามส่วนของข้อความแต่ละส่วน
{{% /alert %}}

### **การใช้การแปลงใน WordArt**

ใช้ [TextFrameFormat.setTransform](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setTransform) เพื่อแปลงทั้งบล็อกข้อความ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![Text with an arch transformation](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
ทั้ง Microsoft PowerPoint และ Aspose.Slides for Python via Java มีจำนวนจำกัดของประเภทการแปลงที่กำหนดล่วงหน้า
{{% /alert %}}

**ใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดล่วงหน้า ไปที่: **Format** → **TextEffect** → **Transform**

**ใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง ใช้ค่าสมการ [TextShapeType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textshapetype/)

### **นำเอฟเฟ็กต์ 3D ไปใช้กับข้อความและรูปร่าง**

เรานำเอฟเฟ็กต์ 3D ไปใช้กับรูปร่างข้อความด้วยโค้ดตัวอย่างนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

ข้อความและรูปร่างที่ได้:

![Text shape with 3D effects](image-20200930114816-9.png)

เรานำเอฟเฟ็กต์ 3D ไปใช้กับข้อความด้วยโค้ด Python นี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

ผลลัพธ์ของการดำเนินการ:

![Text with 3D effects](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
การนำเอฟเฟ็กต์ 3D ไปใช้กับข้อความหรือรูปร่างของมัน และการโต้ตอบระหว่างเอฟเฟ็กต์ต่าง ๆ จะอิงตามกฎบางอย่าง

พิจารณาฉากสำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟ็กต์ 3D ประกอบด้วยการแสดงวัตถุ 3D และฉากที่วัตถุถูกวาง

- เมื่อกำหนดฉากให้ทั้งรูปร่างและข้อความ ฉากของรูปร่างจะมีลำดับความสำคัญ — ฉากของข้อความจะถูกละเลย
- เมื่อรูปร่างไม่มีฉากของตนเองแต่มีการแสดง 3D ฉากของข้อความจะถูกนำมาใช้
- หากรูปร่างไม่มีเอฟเฟ็กต์ 3D ตั้งแต่ต้น รูปร่างจะอยู่ในแบบแบนและเอฟเฟ็กต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความเท่านั้น

กฎเหล่านี้เกี่ยวข้องกับเมธอด [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getLightRig) และ [ThreeDFormat.getCamera](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getCamera)
{{% /alert %}}

## **นำเอฟเฟ็กต์ Outer Shadow ไปใช้กับข้อความ**

Aspose.Slides for Python via Java มีคลาส [OuterShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/outershadow/) และ [InnerShadow](https://reference.aspose.com/slides/th/python-java/aspose.slides/innershadow/) ที่อนุญาตให้คุณใส่เอฟเฟ็กต์เงาให้กับข้อความใน [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มรูปร่างสี่เหลี่ยมลงในสไลด์
4. เข้าถึงเฟรมข้อความที่เชื่อมโยงกับรูปร่าง
5. ปิดการเติมสีของรูปร่าง
6. เปิดใช้งานเอฟเฟ็กต์เงา Outer Shadow
7. ตั้งค่ารัศมีการเบลอของเงา
8. ตั้งค่าทิศทางของเงา
9. ตั้งค่าระยะห่างของเงา
10. จัดตำแหน่งเงาที่ด้านบนซ้าย
11. ตั้งค่าสีเงาเป็นสีดำ
12. เขียนไฟล์งานนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)

ตัวอย่างโค้ด Python ผ่าน Java — การดำเนินตามขั้นตอนข้างต้น — แสดงวิธีการใส่เอฟเฟ็กต์ Outer Shadow ให้กับข้อความ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # รับอ้างอิงของสไลด์
    slide = presentation.getSlides().get_Item(0)

    # เพิ่ม AutoShape ประเภทสี่เหลี่ยมผืนผ้า
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # เพิ่ม TextFrame ไปยังสี่เหลี่ยมผืนผ้า
    auto_shape.addTextFrame("Aspose TextBox")

    # ปิดการเติมสีของรูปร่างในกรณีที่ต้องการเงาของข้อความ
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # เพิ่มเงานอกและตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **นำเอฟเฟ็กต์ Inner Shadow ไปใช้กับรูปร่าง**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์
3. เพิ่มรูปร่างสี่เหลี่ยม
4. เปิดใช้งานเอฟเฟ็กต์ Inner Shadow
5. ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
6. ตั้งค่าชนิดสีของเงาให้ใช้สีธีม
7. ตั้งค่าสีธีม
8. เขียนไฟล์งานนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)

ตัวอย่างโค้ด (ตามขั้นตอนข้างต้น) แสดงวิธีการใส่เอฟเฟ็กต์ Inner Shadow ให้กับข้อความในรูปร่างด้วย Python ผ่าน Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # รับอ้างอิงของสไลด์
    slide = presentation.getSlides().get_Item(0)

    # เพิ่ม AutoShape ประเภทสี่เหลี่ยมผืนผ้า
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # เพิ่ม TextFrame ไปยังสี่เหลี่ยมผืนผ้า
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # เปิดใช้งาน InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # ตั้งค่า ColorType เป็น Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # ตั้งค่าสี Scheme
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # บันทึกรายงานนำเสนอ
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้เอฟเฟ็กต์ WordArt กับฟอนต์หรือสคริปต์ที่ต่างกัน (เช่น Arabic, Chinese) ได้หรือไม่?**

ได้, Aspose.Slides รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟ็กต์ WordArt เช่น เงา, เติมสี, และขอบสามารถนำไปใช้ได้โดยไม่คำนึงถึงภาษาที่ใช้ แม้ว่าความพร้อมของฟอนต์และการเรนเดอร์อาจขึ้นอยู่กับฟอนต์ของระบบ

**ฉันสามารถนำเอฟเฟ็กต์ WordArt ไปใช้กับองค์ประกอบของสไลด์มาสเตอร์ได้หรือไม่?**

ได้, คุณสามารถนำเอฟเฟ็กต์ WordArt ไปใช้กับรูปร่างในสไลด์มาสเตอร์ รวมถึงตัวจัดเก็บตำแหน่งหัวข้อ, ส่วนท้าย, หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลย์เอาต์มาสเตอร์จะสะท้อนในสไลด์ที่เชื่อมโยงทั้งหมด

**เอฟเฟ็กต์ WordArt มีผลต่อขนาดไฟล์งานนำเสนอหรือไม่?**

มีผลเล็กน้อย. เอฟเฟ็กต์ WordArt เช่น เงา, แสงเรือง, และการเติมสีไล่ระดับอาจทำให้ไฟล์ขนาดเพิ่มขึ้นเล็กน้อยเนื่องจากเมทาดาต้าการจัดรูปแบบที่เพิ่มขึ้น แต่ส่วนต่างมักไม่สำคัญ

**ฉันสามารถดูตัวอย่างผลของเอฟเฟ็กต์ WordArt ได้โดยไม่บันทึกงานนำเสนอหรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้ [Shape.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) หรือ [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) วิธีนี้ช่วยให้คุณดูตัวอย่างผลในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกงานนำเสนอเต็มรูปแบบ