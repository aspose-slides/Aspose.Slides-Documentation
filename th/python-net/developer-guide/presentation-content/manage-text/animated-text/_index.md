---
title: แอนิเมตข้อความ PowerPoint ด้วย Python
linktitle: ข้อความที่แอนิเมต
type: docs
weight: 60
url: /th/python-net/animated-text/
keywords:
- ข้อความที่แอนิเมต
- แอนิเมชันข้อความ
- ย่อหน้าแอนิเมต
- แอนิเมชันย่อหน้า
- เอฟเฟ็กต์แอนิเมชัน
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้างข้อความที่เคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python ผ่าน .NET พร้อมตัวอย่างโค้ดที่ทำตามได้ง่ายและผ่านการปรับให้เหมาะสม"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำแอนิเมชันข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python คุณจะได้เรียนรู้การเพิ่มเอฟเฟ็กต์ให้กับย่อหน้าเดี่ยว ปรับการทำงานของทริกเกอร์ และอ่านลำดับแอนิเมชันที่มีอยู่แล้วกลับมา เมื่ออ่านจนจบคุณจะสามารถสร้างเวิร์กฟลอว์แอนิเมชันข้อความที่นำกลับมาใช้ใหม่ได้ ซึ่งสามารถส่งออกเป็นไฟล์ PPTX มาตรฐานและเล่นได้อย่างถูกต้องใน PowerPoint

## **เพิ่มเอฟเฟ็กต์แอนิเมชันให้กับย่อหน้า**

เมธอด [add_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/sequence/add_effect/) ของคลาส [Sequence](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/sequence/) ทำให้คุณสามารถใช้เอฟเฟ็กต์แอนิเมชันกับย่อหน้าเดียวได้ ตัวอย่างโค้ดด้านล่างแสดงวิธีทำเช่นนั้น:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # เลือกย่อหน้าที่จะเพิ่มเอฟเฟ็กต์.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # เพิ่มเอฟเฟ็กต์การแอนิเมชัน Fly ให้กับย่อหน้าที่เลือก.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **ดึงเอฟเฟ็กต์แอนิเมชันของย่อมา**

คุณอาจต้องการระบุว่าเอฟเฟ็กต์แอนิเมชันใดถูกนำไปใช้กับย่อหน้า เช่น หากคุณต้องการคัดลอกเอฟเฟ็กต์เหล่านั้นไปยังย่อหน้าหรือรูปร่างอื่น

Aspose.Slides for Python ให้คุณดึงเอฟเฟ็กต์แอนิเมชันทั้งหมดที่ใช้กับย่อหน้าในกรอบข้อความ (shape) ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงเอฟเฟ็กต์แอนิเมชันของย่อหน้า:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **คำถามที่พบบ่อย**

**การทำแอนิเมชันข้อความต่างจากการเปลี่ยนสไลด์อย่างไร และสามารถใช้ร่วมกันได้หรือไม่?**

แอนิเมชันข้อความควบคุมพฤติกรรมของออบเจกต์ตามเวลาในสไลด์ ส่วน [transitions](/slides/th/python-net/slide-transition/) ควบคุมวิธีการเปลี่ยนสไลด์ ทั้งสองเป็นอิสระและสามารถใช้ร่วมกันได้; ลำดับการเล่นถูกกำหนดโดยไทม์ไลน์ของแอนิเมชันและการตั้งค่า transition

**เอฟเฟ็กต์แอนิเมชันข้อความถูกเก็บไว้เมื่อส่งออกเป็น PDF หรือภาพหรือไม่?**

ไม่. PDF และภาพรัสเตอร์เป็นสเตติก ดังนั้นคุณจะเห็นสถานะเดียวของสไลด์โดยไม่มีการเคลื่อนไหว หากต้องการคงการเคลื่อนไหวให้ใช้การส่งออกเป็น [video](/slides/th/python-net/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/python-net/export-to-html5/)

**แอนิเมชันข้อความทำงานได้ในเลย์เอาต์และสไลด์มาสเตอร์หรือไม่?**

เอฟเฟ็กต์ที่ใช้กับออบเจกต์ในเลย์เอาต์/มาสเตอร์จะสืบทอดไปยังสไลด์ แต่เวลาการทำงานและการโต้ตอบกับแอนิเมชันระดับสไลด์จะขึ้นอยู่กับลำดับสุดท้ายบนสไลด์.