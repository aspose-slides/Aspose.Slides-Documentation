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
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที"
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถใช้เพื่อทำให้รูปทรงโดดเด่นได้ แต่ก็แตกต่างจาก [fills](/slides/th/python-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงเรืองแสงของรูปทรง เป็นต้น.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้เอฟเฟกต์หนึ่งหรือหลายแบบกับรูปทรงหนึ่งรูปได้.

* การรวมเอฟเฟกต์บางแบบดูดีขึ้นกว่าบางแบบ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการรวมของสองหรือมากกว่าเอฟเฟกต์ที่รู้ว่าดูดี วิธีนี้เมื่อเลือก preset คุณจะไม่ต้องเสียเวลาทดสอบหรือรวมเอฟเฟกต์ต่าง ๆ เพื่อหาการรวมที่ดี.

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint.

## **ใช้เอฟเฟกต์เงา**

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์เงาภายนอก ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) กับสี่เหลี่ยมผืนผ้า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้เอฟเฟกต์การสะท้อน**

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์การสะท้อนกับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้เอฟเฟกต์เรืองแสง**

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์เรืองแสงกับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้เอฟเฟกต์ขอบนุ่ม**

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์ขอบนุ่มกับรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้, คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสง บนรูปทรงเดียวเพื่อสร้างลักษณะที่เคลื่อนไหวมากขึ้น.

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลาย รวมถึง autoshapes, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE, และอื่น ๆ.

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.