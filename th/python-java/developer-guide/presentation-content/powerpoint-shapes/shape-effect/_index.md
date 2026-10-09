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
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที"
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถทำให้รูปทรงเด่นขึ้นได้ แต่มันแตกต่างจาก [เติมสี](/slides/th/python-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่สมจริงบนรูปทรง กระจายแสงเรืองแสงของรูปทรง ฯลฯ

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูป

การผสมผสานของเอฟเฟกต์บางอย่างดูดีกว่าที่อื่น ด้วยเหตุนี้ PowerPoint จึงให้ตัวเลือกในส่วน **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่รู้ว่าให้ผลลัพธ์ที่สวยงาม ด้วยวิธีนี้ การเลือก Preset จะช่วยให้คุณไม่ต้องเสียเวลากับการทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Python ผ่าน Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นขึ้นบนพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้ดูเหมือนรูปทรงลอยขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของเทมเพลตของคุณ

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

เมื่อต้องทำสำเนาลักษณะการออกแบบของเทมเพลต ให้ใช้เงาภายในเพื่อทำให้การ์ดหรือแผงดูหุบลง เงานอกจะขยายออกนอกรูปทรงและทำให้ดูเหมือนลอยขึ้น ส่วนเงาภายในจะทำให้ขอบภายในมีการเงา

เรียกใช้ [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) จากนั้นกำหนดค่าการเงาที่ส่งกลับโดย [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะทำให้ขอบดูอ่อนช้อยขึ้น

โค้ด Python ตัวอย่างนี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางของเงา 225 องศา ระยะห่าง 7 จุด และรัศมีเบลอร์ 6 จุด:

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

เพื่อลบเงาภายใน ให้เรียกใช้ [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) บน EffectFormat ของรูปทรง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Python ผ่าน Java คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใส, และขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามให้กับงานนำเสนอโดยทำให้รูปทรงดูเรียบหรูและมีความเป็นมืออาชีพ การใช้งานง่ายด้วยโค้ดไม่กี่บรรทัด ทำให้คุณสามารถนำไปใช้กับหลาย ๆ องค์ประกอบได้อย่างรวดเร็วเพื่อให้การออกแบบสอดคล้องกัน

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

## **ใช้เอฟเฟกต์เรืองแสง**

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปทรงใน Aspose.Slides for Python ผ่าน Java คุณสามารถเพิ่มออร่าที่อ่อนโยนและเปล่งแสงไปรอบ ๆ รูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปทรงเด่นขึ้นและเพิ่มองค์ประกอบที่น่าดึงดูดให้กับงานนำเสนอของคุณ การนำไปใช้ง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้สไลด์ของคุณดูสวยงามยิ่งขึ้น

โค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) กับรูปทรง:

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

![เอฟเฟกต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Python ผ่าน Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปทรงได้ เอฟเฟกต์นี้ให้ลักษณะที่ละเอียดอ่อนและเป็นมืออาชีพ เหมาะสำหรับการออกแบบที่ต้องการความอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้ผลลัพธ์ที่ต้องการกับรูปทรงหลากหลายในงานนำเสนอของคุณ

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

![เอฟเฟ็กต์ขอบนุ่ม](soft_edges_effect.png)

## **FAQ**

**ฉันสามารถใช้เอฟเฟกต์หลายแบบกับรูปทรงเดียวได้หรือไม่?**

ได้ คุณสามารถผสมผสานเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสง บนรูปทรงเดียวเพื่อให้ลักษณะดูมีชีวิตชีวามากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงต่าง ๆ รวมถึง autoshapes, charts, tables, pictures, SmartArt objects, OLE objects, และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่ม เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด