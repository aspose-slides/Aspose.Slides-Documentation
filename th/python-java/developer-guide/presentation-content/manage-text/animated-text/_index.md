---
title: ทำให้ข้อความ PowerPoint เคลื่อนไหวใน Python ผ่าน Java
linktitle: ข้อความเคลื่อนไหว
type: docs
weight: 60
url: /th/python-java/animated-text/
keywords:
- ข้อความเคลื่อนไหว
- แอนิเมชันข้อความ
- ย่อหน้าเคลื่อนไหว
- แอนิเมชันย่อหน้า
- เอฟเฟกต์แอนิเมชัน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างข้อความเคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java พร้อมตัวอย่างโค้ด Python ที่ทำตามง่ายและได้รับการปรับให้เหมาะสม"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับข้อความที่มีแอนิเมชันใน Aspose.Slides โดยการนำเอฟเฟกต์แอนิเมชันไปใช้กับย่อหน้าแต่ละย่อหน้าและดึงเอฟเฟกต์ที่ได้กำหนดไว้แล้วกับย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้ในการเพิ่มแอนิเมชันระดับย่อหน้าและตรวจสอบเอฟเฟกต์แอนิเมชันของย่อหน้าที่มีอยู่ในงานพรีเซ็นเทชัน

## **เพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้า**

เมธอด [addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) ของคลาส [Sequence](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/) ให้คุณเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # เลือกย่อหน้าที่จะเพิ่มเอฟเฟกต์ให้.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # เพิ่มเอฟเฟกต์แอนิเมชัน Fly ให้กับย่อหน้าที่เลือก.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **รับเอฟเฟกต์แอนิเมชันของย่อหน้า**

คุณอาจต้องการดึงเอฟเฟกต์แอนิเมชันที่ใช้กับย่อมาหนึ่ง เช่น เพื่อนำเอฟเฟกต์เหล่านั้นไปใช้กับย่อหน้าอื่นหรือรูปร่างอื่น

Aspose.Slides for Python via Java ให้คุณดึงเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับย่อหน้าที่อยู่ในกรอบข้อความ (รูปร่าง) ตัวอย่างโค้ดนี้แสดงวิธีการดึงเอฟเฟกต์แอนิเมชันที่ใช้กับย่อหน้า:

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

**แอนิเมชันข้อความต่างจากการเปลี่ยนสไลด์อย่างไร และสามารถใช้ร่วมกันได้หรือไม่?**

แอนิเมชันข้อความจะควบคุมพฤติกรรมของวัตถุตลอดเวลาในสไลด์ ในขณะที่ [การเปลี่ยนสไลด์](/slides/th/python-java/slide-transition/) ควบคุมวิธีการเปลี่ยนสไลด์ ทั้งสองเป็นอิสระต่อกันและสามารถใช้ร่วมกันได้ ลำดับการเล่นถูกกำหนดโดยไทม์ไลน์ของแอนิเมชันและการตั้งค่าการเปลี่ยนสไลด์

**แอนิเมชันข้อความยังคงอยู่เมื่อส่งออกเป็น PDF หรือรูปภาพหรือไม่?**

ไม่ PDF และรูปภาพแบบแรสเตอร์เป็นแบบคงที่ ดังนั้นคุณจะเห็นสไลด์ในสถานะเดียวโดยไม่มีการเคลื่อนไหว หากต้องการเก็บการเคลื่อนไหวให้ใช้การส่งออกเป็น [วิดีโอ](/slides/th/python-java/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/python-java/export-to-html5/)

**แอนิเมชันข้อความทำงานในเลย์เอาต์และมาสเตอร์สไลด์หรือไม่?**

เอฟเฟกต์ที่ใช้กับวัตถุในเลย์เอาต์หรือมาสเตอร์สไลด์จะถูกสืบทอดไปยังสไลด์ แต่เวลาและการโต้ตอบกับแอนิเมชันระดับสไลด์จะขึ้นอยู่กับลำดับสุดท้ายบนสไลด์นั้น