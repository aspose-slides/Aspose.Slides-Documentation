---
title: เปรียบเทียบสไลด์การนำเสนอใน Python
linktitle: เปรียบเทียบสไลด์
type: docs
weight: 50
url: /th/python-java/compare-slides/
keywords:
- เปรียบเทียบสไลด์
- การเปรียบเทียบสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เปรียบเทียบการนำเสนอ PowerPoint และ OpenDocument อย่างอัตโนมัติด้วย Aspose.Slides สำหรับ Python ผ่าน Java. ระบุความแตกต่างของสไลด์ในโค้ดอย่างรวดเร็ว."
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณเปรียบเทียบสไลด์, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์โดยใช้เมธอด [equals](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#equals) ที่มาจากคลาส [BaseSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/) เมธอดนี้จะคืนค่า `True` เมื่อสไลด์ที่เปรียบเทียบมีโครงสร้างและเนื้อหาคงที่เหมือนกัน

## **เปรียบเทียบสองสไลด์**

เมธอด [equals](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#equals) ในคลาส [BaseSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/) จะคืนค่า `True` สำหรับสไลด์, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์ที่มีโครงสร้างและเนื้อหาคงที่เหมือนกัน

สองสไลด์ถือว่าเท่ากันถ้ารูปร่าง, สไตล์, ข้อความ, แอนิเมชัน และการตั้งค่าอื่น ๆ ของทั้งสองสอดคล้องกัน การเปรียบเทียบจะไม่พิจารณาค่าตัวระบุเฉพาะ เช่น ID ของสไลด์ หรือเนื้อหาแบบไดนามิกเช่นวันที่ปัจจุบันในตัวแทนวันที่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**การที่สไลด์ถูกซ่อนส่งผลต่อการเปรียบเทียบสไลด์เองหรือไม่?**

[Hidden status](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getHidden) เป็นคุณสมบัติระดับการนำเสนอ/การเล่น ไม่ใช่เนื้อหาทางภาพ ความเท่าเทียมของสองสไลด์ที่ระบุจะกำหนดโดยโครงสร้างและเนื้อหาคงที่; การที่สไลด์หนึ่งถูกซ่อนเพียงอย่างเดียวไม่ทำให้สไลด์แตกต่างกัน

**ไฮเปอร์ลิงก์และพารามิเตอร์ของมันถูกพิจารณาหรือไม่?**

ใช่ ลิงก์เป็นส่วนหนึ่งของเนื้อหาคงที่ของสไลด์ หาก URL หรือการกระทำของไฮเปอร์ลิงก์แตกต่างกัน จะถือว่าเป็นความแตกต่างของเนื้อหาคงที่

**หากแผนภูมิเชื่อมโยงกับไฟล์ Excel ภายนอก เนื้อหาในไฟล์นั้นจะถูกนำมาพิจารณาหรือไม่?**

ไม่ การเปรียบเทียบทำบนพื้นฐานของสไลด์เอง แหล่งข้อมูลภายนอกโดยทั่วไปจะไม่ถูกอ่านในระหว่างการเปรียบเทียบ; จะพิจารณาเฉพาะสิ่งที่อยู่ในโครงสร้างและสถานะคงที่ของสไลด์เท่านั้น