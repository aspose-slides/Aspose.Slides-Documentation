---
title: ทำแอนิเมชันข้อความ PowerPoint ด้วย Python ผ่าน Java
linktitle: ข้อความแอนิเมชัน
type: docs
weight: 60
url: /th/python-java/animated-text/
keywords:
- ข้อความแอนิเมชัน
- แอนิเมชันข้อความ
- ย่อหน้าแอนิเมชัน
- แอนิเมชันย่อหน้า
- เอฟเฟกต์แอนิเมชัน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างข้อความแอนิเมชันแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java พร้อมตัวอย่างโค้ด Python ที่เข้าใจง่ายและได้รับการปรับแต่งให้มีประสิทธิภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับข้อความเคลื่อนไหวใน Aspose.Slides โดยการใช้เอฟเฟกต์แอนิเมชันกับย่อหน้าแต่ละย่อหน้าและการดึงเอฟเฟกต์ที่กำหนดไว้แล้วสำหรับย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้ในการเพิ่มแอนิเมชันระดับย่อหน้าและการตรวจสอบเอฟเฟกต์แอนิเมชันของย่อหน้าที่มีอยู่ในงานนำเสนอ

## **เพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้า**

เมธอด [addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) ของคลาส [Sequence](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/) ช่วยให้คุณสามารถเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # เลือกย่อหน้าที่จะเพิ่มเอฟเฟกต์.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # เพิ่มเอฟเฟกต์แอนิเมชัน Fly ให้กับย่อหน้าที่เลือก.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ดึงเอฟเฟกต์แอนิเมชันของย่อหน้า**

คุณอาจต้องการค้นหาเอฟเฟกต์แอนิเมชันที่เพิ่มลงในย่อหน้า—for example, ในกรณีหนึ่งคุณต้องการดึงเอฟเฟกต์แอนิเมชันจากย่อหน้าเพื่อที่จะใช้เอฟเฟกต์เหล่านั้นกับย่อหน้าอื่นหรือรูปทรองอื่น

Aspose.Slides for Python via Java ให้คุณดึงเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับย่อหน้าที่อยู่ในกรอบข้อความ (shape) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดึงเอฟเฟกต์แอนิเมชันในย่อหน้า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**แอนิเมชันของข้อความต่างจากการเปลี่ยนสไลด์อย่างไร และสามารถใช้ร่วมกันได้หรือไม่?**

แอนิเมชันของข้อความควบคุมพฤติกรรมของอ็อบเจ็กต์ตามช่วงเวลาในสไลด์ ในขณะที่ [transitions](/slides/th/python-java/slide-transition/) ควบคุมวิธีการเปลี่ยนสไลด์ พวกมันทำงานแยกจากกันและสามารถใช้ร่วมกันได้; ลำดับการเล่นจะถูกกำหนดโดยไทม์ไลน์ของแอนิเมชันและการตั้งค่า transition

**แอนิเมชันของข้อความจะถูกรักษาไว้เมื่อส่งออกเป็น PDF หรือรูปภาพหรือไม่?**

ไม่ PDF และรูปภาพแบบแรสเตอร์เป็นแบบคงที่ ดังนั้นคุณจะเห็นสถานะเดียวของสไลด์โดยไม่มีการเคลื่อนไหว หากต้องการเก็บการเคลื่อนไหวให้ใช้การส่งออกเป็น [video](/slides/th/python-java/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/python-java/export-to-html5/)

**แอนิเมชันของข้อความทำงานในเลเอาต์และสไลด์มาสเตอร์ได้หรือไม่?**

เอฟเฟกต์ที่ใช้กับอ็อบเจ็กต์ในเลเอาต์/มาสเตอร์จะสืบทอดไปยังสไลด์ แต่เวลาการทำงานและการโต้ตอบกับแอนิเมชันระดับสไลด์จะขึ้นอยู่กับลำดับสุดท้ายบนสไลด์