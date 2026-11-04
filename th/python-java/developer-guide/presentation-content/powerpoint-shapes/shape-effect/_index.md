---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอโดยใช้ Python ผ่าน Java
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/python-java/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์การเรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที"
---
## **บทนำ**

ขณะที่เอฟเฟกต์ใน PowerPoint สามารถทำให้รูปร่างโดดเด่นได้ แต่จะแตกต่างจาก [การเติม](/slides/th/python-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่เชื่อถือได้บนรูปร่าง เพิ่มแสงเรืองรอบรูปร่าง ฯลฯ

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างหนึ่งรูปได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **การตั้งค่าที่กำหนดล่วงหน้า** ตัวเลือกการตั้งค่าที่กำหนดล่วงหน้าคือการผสมผสานของสองหรือมากกว่าเอฟเฟกต์ที่ทราบว่าดูดี วิธีนี้เมื่อเลือกการตั้งค่าที่กำหนดล่วงหน้า คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) ที่ทำให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Python via Java รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถกำหนดค่าสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงหน้าต่างเด่นขึ้นจากพื้นหลังสไลด์ เงาจะขยายเกินขอบของรูปร่าง สร้างความรู้สึกว่ารูปร่างถูกยกขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยมผืนผ้า:

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

เมื่อทำสำเนาสไตล์การออกแบบของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงหน้าต่างดูถูกฝังลงในพื้นผิว เงานอกขยายออกมานอกรูปร่างและทำให้ดูเหมือนยกขึ้น ในขณะที่เงาภายในทำให้ขอบด้านในของรูปร่างมืดลง

เรียกใช้งาน [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) แล้วกำหนดค่าการเงาที่คืนค่ามาจาก [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะให้ขอบที่นุ่มนวลขึ้น

ตัวอย่าง Python นี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางของเงาเป็น 225 องศา ระยะทาง 7 จุด และรัศมีเบลอร์ 6 จุด:

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

หากต้องการลบเงาภายในให้เรียกใช้งาน [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) บนรูปแบบเอฟเฟกต์ของรูปร่าง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Python via Java คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปร่างโดยปรับพารามิเตอร์เช่น ระยะทาง ความโปร่งใส และขนาด เอฟเฟกต์นี้ทำให้การนำเสนอของคุณดูมีความหรูหราและเป็นมืออาชีพยิ่งขึ้น ใช้งานง่ายด้วยโค้ดที่เรียบง่าย ทำให้สามารถนำไปใช้ได้อย่างรวดเร็วบนหลายองค์ประกอบเพื่อการออกแบบที่สม่ำเสมอ

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปร่าง:

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

## **ใช้เอฟเฟกต์การเรืองแสง**

เพื่อใช้เอฟเฟกต์การเรืองแสงกับรูปร่างใน Aspose.Slides for Python via Java คุณสามารถเพิ่มออร่าอันอ่อนโยนรอบรูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างเด่นขึ้นและเพิ่มองค์ประกอบที่ดึงดูดสายตาให้กับการนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้รูปลักษณ์โดยรวมของสไลด์ดูสว่างและเป็นมืออาชีพ

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟกต์การเรืองแสง](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) กับรูปร่าง:

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

![เอฟเฟกต์การเรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Python via Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปร่าง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะสำหรับการออกแบบที่ต้องการความอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้เอฟเฟกต์ที่ต้องการบนรูปร่างต่าง ๆ ในการนำเสนอของคุณ

โค้ด Python นี้แสดงวิธีใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปร่าง:

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

ใช้เบลอรูปทรงเพื่อทำให้การเติมและเส้นขอบของรูปร่างดูนุ่มลงโดยยังคงให้รูปทรงสามารถแก้ไขได้ เรียกใช้งาน [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) บนรูปแบบเอฟเฟกต์ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว) ให้ใช้ค่าที่ไม่เป็นลบ ค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนแปลงลักษณะ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) ควบคุมขอบที่มองเห็นของเอฟเฟกต์ เมื่อ `False` เบลอจะถูกตัดให้ตรงกับขอบที่ทาสีเดิมรวมถึงเส้นขอบ เมื่อ `True` เบลอสามารถขยายเกินขอบเหล่านั้นได้ ทั้งสองค่าจะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้การเติม เส้นขอบ และมิติของรูปร่างเดียวกันตลอด แถวบนใช้ `grow = False` แถวล่างใช้ `grow = True`

![สี่เหลี่ยมเดิมเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด พร้อมการเปิด/ปิดการขยาย](shape_blur_comparison.png)

โค้ด Python นี้สร้างสี่เหลี่ยมสีนส้มพร้อมเส้นขอบสีน้ำเงินเข้ม ใช้เบลอ 5 จุด แล้วอัปเดตเป็นเบลอ 15 จุดโดยเรียกใช้งาน [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง บันทึกสถานะที่เบลอทั้งสอง แล้วเรียกใช้งาน [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปร่างโดยไม่มีเบลอ

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

เบลอรูปทรงส่งผลต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบของรูปร่างจางหายไปขณะที่เบลอเงาจะทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟกต์การแปลงภาพทำงานกับเนื้อหาภาพ ตัวอย่างนี้ใช้เบลอโดยตรงกับรูปแบบเอฟเฟกต์ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**  
ใช่ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และการเรืองแสงบนรูปร่างเดียวเพื่อสร้างลุคที่มีพลวัตมากขึ้น

**รูปร่างใดบ้างที่ฉันสามารถใช้เอฟเฟกต์ได้?**  
คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภท รวมถึงออโต้ชเป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้หรือไม่?**  
ได้ คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมดโดยรวม