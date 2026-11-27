---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย Python ผ่าน Java
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/python-java/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรือง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปทรงโดดเด่นได้ แต่พวกมันจะแตกต่างจาก [การเติมสี](/slides/th/python-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงเรืองรอบรูปทรง ฯลฯ

![เอฟเฟ็กต์เงา](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปทร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูปได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงให้ตัวเลือกภายใต้ **Preset** ตัวเลือก Preset คือการผสมผสานของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่รู้ว่าดูดี วิธีนี้การเลือก Preset จะทำให้คุณไม่ต้องเสียเวลาทดลองหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) ที่ช่วยให้คุณใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides สำหรับ Python ผ่าน Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้สอดคล้องกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นเหนือพื้นหลังสไลด์ เงาจะขยายเกินขอบของรูปทรง ทำให้ดูเหมือนรูปทรงยกขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้เข้ากับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟ็กต์เงานอก](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยมผืนผ้า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![เอฟเฟ็กต์เงา](shadow_effect.png)

#### **ควบคุมทิศทางของเงาขณะรูปทรงหมุน**

โดยค่าเริ่มต้น เงานอกจะหมุนพร้อมกับรูปทรง เพื่อทำให้รูปทรงที่มีการหมุนต่างกันดูเหมือนแสงมาจากทิศทางเดียวกัน ให้เรียก [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) ด้วยค่า `False` และใช้ [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) เพื่อตั้งทิศทางเงาให้เหมือนกัน

ตัวอย่างสร้างลูกศรสีน้ำเงินสองลูกพร้อมเงาเทาเบี่ยง 42 จุดไปทางขวา (0°) จากนั้นทำซ้ำสไลด์และหมุนลูกศรทั้งสอง 90° ตามเข็มนาฬิกา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ในสไลด์ที่สอง ลูกศรซ้ายทำเงาตกลงใต้ขณะลูกศรขวายังคงทำเงาตรงขวา ทิศทางที่ตั้งค่าไว้ค้างที่ 0° สำหรับเงาทั้งสอง

![การเรนเดอร์ PowerPoint ก่อนและหลังการหมุน 90°. เงาทั้งสองเริ่มที่ด้านขวา หลังการหมุน เงาจะเคลื่อนลงใต้ลูกศรซ้ายและคงที่ด้านขวาของลูกศรขวา](arrow-shadow-rotation.png)

### **ใช้เงาภายใน**

เมื่อต้องการทำให้การ์ดหรือแผงดูเหมือนสอดเข้ามาในพื้นผิว ให้ใช้เงาภายใน เงานอกจะขยายออกนอกรูปทรงทำให้ดูยกขึ้น ในขณะที่เงาภายในจะทำให้ขอบภายในของรูปทรงมีเงา

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) แล้วกำหนดค่าเงาที่ได้จาก [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีเบลอร์ที่ใหญ่จะทำให้ขอบนุ่มขึ้น

ตัวอย่าง Python นี้สร้างการ์ดสีน้ำเงินอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางเงา 225°, ระยะ 7 จุด และรัศมีเบลอร์ 6 จุด:

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![สี่เหลี่ยมสีน้ำเงินอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) บน EffectFormat ของรูปทรง

### **ใช้, เปลี่ยน, และลบเงาที่กำหนดล่วงหน้า**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) แล้วใช้ [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) หากต้องการเปลี่ยนสไตล์ ให้เปลี่ยน Preset เดิมบนรูปทรงเดียวกัน เรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) เพื่อลบเงาโดยคงการเติมสีและเส้นขอบไว้

ตัวอย่างทำการสำเนาสี่เหลี่ยมในแต่ละขั้นตอนเพื่อให้คุณเปรียบเทียบสี่สถานะบนสไลด์เดียวกัน ทั้งสองเงามีการเบี่ยง 10 จุด ทิศทาง 225° ทำให้เงาแรกอยู่ด้านบนซ้ายของสี่เหลี่ยม ทิศทาง 45° ทำให้เงาที่สองอยู่ด้านล่างขวา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| ต้นฉบับ | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาตำแหน่งบนซ้าย](preset_shadow_top_left.png) | ![เงาตำแหน่งล่างขวา](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใส, และขนาด เอฟเฟกต์นี้ทำให้การนำเสนอของคุณดูหรูหราและเป็นมืออาชีพ ง่ายต่อการทำด้วยโค้ดไม่กี่บรรทัดและสามารถประยุกต์ใช้กับหลายองค์ประกอบเพื่อให้การออกแบบสอดคล้องกัน

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟ็กต์การสะท้อน](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![เอฟเฟ็กต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์แสงเรือง**

เพื่อใช้เอฟเฟกต์แสงเรืองกับรูปทรงใน Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถเพิ่มออร่าระบายแสงรอบรูปทรงโดยปรับสีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปทรงโดดเด่นและเพิ่มความน่าสนใจให้กับสไลด์ของคุณ ง่ายต่อการทำด้วยโค้ดสั้น ๆ ทำให้ภาพรวมของสไลด์ดูสว่างไสว

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟ็กต์แสงเรือง](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) กับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![เอฟเฟ็กต์แสงเรือง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปทรง เอฟเฟกต์นี้ให้รูปลักษณ์ที่ละเอียดอ่อนและสบายตา เหมาะสำหรับการออกแบบที่ต้องการความนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้ผลลัพธ์ที่ต้องการในรูปทรงต่าง ๆ ของการนำเสนอ

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![เอฟเฟกต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอ**

ใช้ Blur ของรูปทรงเพื่อทำให้สีเติมและเส้นขอบของรูปทรงนุ่มลงขณะยังคงให้รูปทรงสามารถแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) บน EffectFormat ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าไม่เป็นลบ ค่าใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) ควบคุมขอบที่มองเห็นของเอฟเฟกต์ ด้วย `False` เบลอจะถูกตัดให้พอดีกับขอบที่วาดเดิมรวมถึงเส้นขอบ ด้วย `True` เบลออาจขยายไปรอบขอบเหล่านั้น การตั้งค่าใด ๆ จะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้การเติมสี เส้นขอบ และขนาดรูปทรงเดียวกันทั้งหมด แถวบนใช้ `grow = False` แถวล่างใช้ `grow = True`

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด โดยที่ grow ปิดและเปิดใช้งาน](shape_blur_comparison.png)

ตัวอย่าง Python นี้สร้างสี่เหลี่ยมส้มพร้อมเส้นขอบสีน้ำเงินเข้ม ใช้เบลอ 5 จุด แล้วอัปเดตเป็นเบลอ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง บันทึกสถานะเบลอทั้งสอง จากนั้นเรียก [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปทรงโดยไม่มีเบลอ

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Blur ของรูปทรงทำให้สีเติมและเส้นขอบอ่อนลงพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบรูปทรงจางหายไป ขณะที่ Blur ของเงาจะทำให้เงานุ่มเท่านั้น เอฟเฟกต์การแปลงรูปภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้ Blur โดยตรงกับ EffectFormat ของรูปทรงโดยไม่ต้องแปลงรูปทรงเป็นภาพ

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมหลายเอฟเฟกต์ เช่น เงา, การสะท้อน, และแสงเรือง บนรูปทรงเดียวกันเพื่อให้ได้ลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลาย เช่น autoshapes, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE ฯลฯ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่เป็นกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่รวมเป็นกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมดโดยรวม