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
- เอฟเฟกต์แสงเรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java - สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที"
---
## **บทนำ**

ขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปทรงเด่นขึ้นได้ แต่แตกต่างจาก [การเติม](/slides/th/python-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่ดูสมจริงบนรูปทรง, ทำให้รูปทรงมีแสงเรืองแสง, ฯลฯ

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงได้

การผสมผสานของเอฟเฟกต์บางอย่างดูดีกว่าที่อื่น ด้วยเหตุนี้ PowerPoint ให้ตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าเอฟเฟกต์ที่ทราบว่าดี วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่างๆ เพื่อหารูปแบบที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) ที่อนุญาตให้คุณใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Python via Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับสี, ทิศทาง, ระยะทางและรัศมีการเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือพาเนลโดดเด่นจากพื้นหลังสไลด์ เงาจะขยายออกเหนือขอบของรูปทรง ทำให้ดูเหมือนว่ารูปทรงยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะและรัศมีการเบลอร์ให้สอดคล้องกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยม:

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

![เอฟเฟกต์เงา](shadow_effect.png)

### **ใช้เงาภายใน**

เมื่อทำการจำลองสไตล์ภาพของเทมเพลต, ใช้เงาภายในเพื่อให้การ์ดหรือพาเนลมีลักษณะกดลงไปข้างใน เงานอกจะขยายออกนอกรูปทรงและทำให้ดูยกขึ้น, ในขณะที่เงาภายในจะทำให้ขอบด้านในของรูปทรงมีเงา

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) แล้วกำหนดค่าการเงาที่คืนจาก [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีการเบลอร์ที่ใหญ่กว่าจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง Python นี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาภายในสีเทาดำและบันทึกเป็นไฟล์ PPTX. ทิศทางของเงาคือ 225 องศา, ระยะห่าง 7 จุด, และรัศมีการเบลอร์ 6 จุด:

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

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

เพื่อลบเงาภายใน, เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) บนฟอร์แมตเอฟเฟกต์ของรูปทรง

### **ใช้, เปลี่ยน, และลบเงา Preset**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), จากนั้นใช้ [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) เพื่อสลับสไตล์, เปลี่ยน Preset บนรูปทรงเดียวกัน. เรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) เพื่อลบเงาโดยคงการเติมและเส้นขอบไว้

ตัวอย่างนี้ทำสำเนาสี่เหลี่ยมในแต่ละขั้นตอนเพื่อให้คุณเปรียบเทียบสี่สถานะทั้งหมดข้างกันบนสไลด์เดียว. เงาแต่ละอันถูกย้ายตำแหน่ง 10 จุด. ทิศทาง 225° จะวางเงาแรกเหนือและทางซ้ายของสี่เหลี่ยม. ทิศทาง 45° จะวางเงาที่สองด้านล่างและทางขวา.

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
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาตกซ้ายบน](preset_shadow_top_left.png) | ![เงาตกขวาล่าง](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Python via Java, คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใส, และขนาด เอฟเฟกต์นี้ช่วยให้การนำเสนอของคุณดูสวยงามยิ่งขึ้นโดยทำให้รูปทรงดูเรียบหรูและเป็นมืออาชีพ ใช้งานง่ายด้วยโค้ดง่ายๆ ทำให้สามารถนำไปใช้รวดเร็วกับหลายองค์ประกอบเพื่อการออกแบบที่สอดคล้องกัน

โค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปทรง:

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

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์แสงเรืองแสง**

เพื่อใช้เอฟเฟกต์แสงเรืองแสงกับรูปทรงใน Aspose.Slides for Python via Java, คุณสามารถเพิ่มออร่านุ่มนวลและสว่างไสวรอบรูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปทรงโดดเด่นและเสริมองค์ประกอบที่ดึงดูดสายตาให้กับการนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดน้อยๆ ทำให้รูปลักษณ์โดยรวมของสไลด์ดีขึ้น

โค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์แสงเรืองแสง](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) กับรูปทรง:

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

![เอฟเฟกต์แสงเรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Python via Java, คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอร์รอบขอบของรูปทรง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะกับการออกแบบที่ต้องการความนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้เอฟเฟกต์ตามต้องการบนรูปทรงหลายแบบในงานนำเสนอของคุณ

โค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปทรง:

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

## **ใช้เอฟเฟกต์เบลอร์**

ใช้การเบลอร์รูปทรงเพื่อทำให้สีเติมและเส้นขอบของรูปทรงนุ่มลงในขณะที่ยังคงให้รูปทรงแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) บนฟอร์แมตเอฟเฟกต์ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ, ค่าที่ใหญ่กว่าจะทำให้เบลอร์แรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใดๆ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ ด้วย `False` เบลอร์จะถูกตัดให้ตรงกับขอบเขตที่วาดไว้เดิมรวมถึงเส้นขอบ ด้วย `True` เบลอร์สามารถขยายเกินขอบเขตเหล่านั้นได้ การตั้งค่าใดๆ ไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้สีเติม, เส้นขอบ, และขนาดรูปทรงเดียวกันทั้งหมด แถวบนใช้ `grow = False`; แถวล่างใช้ `grow = True`.

![สี่เหลี่ยมต้นฉบับเทียบกับรัศมีเบลอร์ 5 และ 15 จุด, พร้อมกำหนดการเพิ่มขนาดปิดและเปิด](shape_blur_comparison.png)

โค้ด Python นี้สร้างสี่เหลี่ยมสีส้มพร้อมเส้นขอบสีน้ำเงินเข้ม, ใช้เบลอร์ 5 จุด, แล้วอัปเดตเป็นเบลอร์ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง บันทึกสถานะเบลอร์ทั้งสอง แล้วเรียก [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปทรงโดยไม่มีเบลอร์

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

การเบลอร์รูปทรงกระทบต่อสีเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบรูปทรงจางหายไป, ส่วนการเบลอร์เงาจะทำให้เงานุ่มลงเท่านั้น เอฟเฟกต์การแปลงรูปภาพทำงานกับเนื้อหารูปภาพ; ตัวอย่างนี้ใช้เบลอร์โดยตรงบนฟอร์แมตเอฟเฟกต์ของรูปทรงโดยไม่แปลงรูปทรงเป็นภาพ

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ใช่, คุณสามารถผสมเอฟเฟกต์ต่างๆ เช่น เงา, การสะท้อน, และแสงเรืองแสงบนรูปทรงเดียวเพื่อให้ดูมีความเคลื่อนไหวมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลายรวมถึงรูปอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่นๆ

**ฉันสามารถใช้เอฟเฟกต์กับกลุ่มรูปทรงได้หรือไม่?**

ใช่, คุณสามารถใช้เอฟเฟกต์กับกลุ่มรูปทรงได้ เอฟเฟกต์จะถูกนำไปใช้กับทั้งกลุ่มโดยรวม