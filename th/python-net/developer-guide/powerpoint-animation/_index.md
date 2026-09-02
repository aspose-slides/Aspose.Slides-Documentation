---
title: ปรับปรุงงานนำเสนอ PowerPoint ด้วยอนิเมชันใน Python
linktitle: อนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/python-net/powerpoint-animation/
keywords:
- เพิ่มอนิเมชัน
- อัปเดตอนิเมชัน
- เปลี่ยนอนิเมชัน
- ลบอนิเมชัน
- จัดการอนิเมชัน
- ควบคุมอนิเมชัน
- เอฟเฟกต์อนิเมชัน
- อนิเมชัน PowerPoint
- ไทม์ไลน์อนิเมชัน
- อนิเมชันเชิงโต้ตอบ
- อนิเมชันแบบกำหนดเอง
- อนิเมชันรูปทรง
- แผนภูมิที่มีอนิเมชัน
- ข้อความที่มีอนิเมชัน
- รูปทรงที่มีอนิเมชัน
- วัตถุ OLE ที่มีอนิเมชัน
- รูปภาพที่มีอนิเมชัน
- ตารางที่มีอนิเมชัน
- งานนำเสนอ PowerPoint
- Python
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ Python ผ่าน .NET ในการจัดการอนิเมชัน PowerPoint ภาพรวมทั่วไปนี้เน้นคุณลักษณะหลักและให้แนวคิดเพื่อปรับปรุงงานนำเสนอของคุณ"
---
## **บทนำ**

งานนำเสนอถูกออกแบบเพื่อสื่อสารข้อมูล ดังนั้นลักษณะภาพและพฤติกรรมเชิงโต้ตอบจึงเป็นสิ่งสำคัญที่ต้องคำนึงถึงระหว่างการสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้งานนำเสนอน่าสนใจและดึงดูดผู้ชม Aspose.Slides for Python via .NET มีตัวเลือกหลากหลายในการเพิ่มอนิเมชันให้กับงานนำเสนอ PowerPoint คุณสามารถ:
- ใช้เอฟเฟกต์อนิเมชันต่างๆ กับรูปทรง แผนภูมิ ตาราง วัตถุ OLE และองค์ประกอบอื่นๆ
- ใช้หลายเอฟเฟกต์อนิเมชันบนรูปทรงเดียว
- ควบคุมเอฟเฟกต์ผ่านไทม์ไลน์ของอนิเมชัน
- สร้างอนิเมชันแบบกำหนดเอง

ใน Aspose.Slides for Python via .NET สามารถใช้เอฟเฟกต์อนิเมชันกับรูปทรงได้ เนื่องจากทุกองค์ประกอบบนสไลด์—including ข้อความ รูปภาพ วัตถุ OLE และตาราง—ถูกพิจารณาเป็นรูปทรง คุณจึงสามารถใช้เอฟเฟกต์อนิเมชันกับองค์ประกอบใดก็ได้บนสไลด์

เนมสเปซ [aspose.slides.animation](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/) ให้คลาสสำหรับทำงานกับอนิเมชัน PowerPoint

## **การติดตั้ง**

```bash
pip install aspose.slides
```

## **เพิ่มเอฟเฟกต์อนิเมชันให้กับรูปทรงใน Python**

เอฟเฟกต์อนิเมชันอยู่ในลำดับหลักของสไลด์ เพิ่มรูปทรง แล้วเรียก `add_effect` บน `slide.timeline.main_sequence` พร้อมระบุประเภทของเอฟเฟกต์ ชนิดย่อย และทริกเกอร์ที่เริ่มต้นมัน

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

ไฟล์ที่บันทึกจะมีเอฟเฟกต์หนึ่งบนสไลด์แรก: สี่เหลี่ยมจะบินเข้ามาจากด้านซ้ายในระยะเวลา 2 วินาทีเมื่อผู้เสนอคลิก การเปิดไฟล์ใหม่และอ่าน `slide.timeline.main_sequence` จะส่งคืนเอฟเฟกต์นั้น ทำให้อนิเมชันคงอยู่ระหว่างการบันทึกและเปิดใหม่ ไม่ใช่แค่ในหน่วยความจำ

## **เอฟเฟกต์อนิเมชัน**

Aspose.Slides รองรับ **เอฟเฟกต์อนิเมชันกว่า 150 รายการ** รวมถึงเอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball, และ Zoom รวมถึงเอฟเฟกต์เฉพาะเช่น OLEObjectShow และ OLEObjectOpen คุณสามารถดูรายการเต็มได้ใน enumeration [EffectType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effecttype/)

นอกจากนี้ เอฟเฟกต์อนิเมชันเหล่านี้สามารถผสานกับเอฟเฟกต์ต่อไปนี้ได้:
- [ColorEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/seteffect/)

## **อนิเมชันแบบกำหนดเอง**

คุณสามารถสร้าง **อนิเมชันแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้โดยการรวมพฤติกรรมหลายอย่างเป็นเอฟเฟกต์เดียว

[Behavior](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behavior/) คือบล็อกพื้นฐานของเอฟเฟ็กต์อนิเมชัน PowerPoint ทุกเอฟเฟกต์อนิเมชันโดยพื้นฐานคือชุดของพฤติกรรมที่จัดเรียงเป็นกลยุทธ์หรือไทม์ไลน์หนึ่ง คุณสามารถประกอบพฤติกรรมเป็นอนิเมชันแบบกำหนดเองหนึ่งครั้งแล้วนำไปใช้ซ้ำในงานนำเสนออื่น หากคุณเพิ่มพฤติกรรมใหม่ให้กับเอฟเฟกต์อนิเมชัน PowerPoint มาตรฐาน มันจะกลายเป็นอนิเมชันแบบกำหนดเอง เช่น การเพิ่มพฤติกรรม repeat เพื่อให้อนิเมชันเล่นหลายครั้ง

[Animation Point](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/point/) ระบุตำแหน่งหรือช่วงเวลาที่พฤติกรรมถูกนำมาใช้ (คีย์เฟรม)

## **ไทม์ไลน์ของอนิเมชัน**

[Sequence](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/sequence/) คือชุดของเอฟเฟกต์อนิเมชันที่นำไปใช้กับรูปทรงเฉพาะ

[Timeline](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/animationtimeline/) คือชุดของ sequence ที่ใช้บนสไลด์เฉพาะ มันถูกแนะนำใน PowerPoint 2002 ในเวอร์ชันก่อนของ PowerPoint การเพิ่มเอฟเฟกต์อนิเมชันทำได้ยากและมักต้องใช้วิธีแก้ไข Timeline แทนคลาส `AnimationSettings` เก่และให้โมเดลวัตถุที่ชัดเจนขึ้นสำหรับอนิเมชัน PowerPoint แต่ละสไลด์สามารถมีไทม์ไลน์ของอนิเมชันได้เพียงหนึ่งชุด

## **อนิเมชันเชิงโต้ตอบ**

[Trigger](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effecttriggertype/) ให้คุณกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่เริ่มต้นอนิเมชันเฉพาะ Trigger ถูกเพิ่มเข้ามาในเวอร์ชันล่าสุดของ PowerPoint เท่านั้น

## **อนิเมชันรูปทรง**

Aspose.Slides ให้คุณนำอนิเมชันไปใช้กับรูปทรงต่างๆ เช่น ข้อความ สี่เหลี่ยม เส้น กรอบ วัตถุ OLE และอื่นๆ

{{% alert color="primary" %}}
อ่านเพิ่มเติม [**เกี่ยวกับอนิเมชันรูปทรง**](/slides/th/python-net/shape-animation/)
{{% /alert %}}

## **แผนภูมิที่มีอนิเมชัน**

ในการสร้างแผนภูมิที่มีอนิเมชัน ให้ใช้คลาสเดียวกับที่ใช้กับรูปทรง อย่างไรก็ตาม อนิเมชัน PowerPoint สามารถนำไปใช้ได้เฉพาะกับหมวดหมู่ของแผนภูมิหรือซีรีส์ของแผนภูมิ คุณยังสามารถใช้เอฟเฟกต์อนิเมชันกับองค์ประกอบหมวดหมู่หรือซีรีส์เดี่ยวได้

{{% alert color="primary" %}}
อ่านเพิ่มเติม [**เกี่ยวกับแผนภูมิที่มีอนิเมชัน**](/slides/th/python-net/animated-charts/)
{{% /alert %}}

## **ข้อความที่มีอนิเมชัน**

นอกจากการทำอนิเมชันให้กับข้อความแล้ว คุณยังสามารถนำอนิเมชันไปใช้กับย่อหน้าด้วย

{{% alert color="primary" %}}
อ่านเพิ่มเติม [**เกี่ยวกับข้อความที่มีอนิเมชัน**](/slides/th/python-net/animated-text/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

### การแปลงเป็น PDF จะคงอนิเมชันไว้หรือไม่?

ไม่ PDF เป็นรูปแบบคงที่ ดังนั้นอนิเมชันและ [slide transitions](/slides/th/python-net/slide-transition/) จะไม่เล่น หากคุณต้องการการเคลื่อนไหว ให้แปลงเป็น [HTML5](/slides/th/python-net/export-to-html5/), [animated GIF](/slides/th/python-net/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/python-net/convert-powerpoint-to-video/) แทน

### ฉันสามารถแปลงงานนำเสนอที่มีอนิเมชันเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?

ใช่ คุณสามารถ [render the presentation as frames](/slides/th/python-net/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ใช้ ffmpeg) โดยเลือก FPS และความละเอียด การเล่นอนิเมชันและ slide transitions จะทำในระหว่างการเรนเดอร์

### การทำงานกับ ODP จะคงอนิเมชันไว้เหมือนกับ PPTX หรือไม่?

PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/python-net/open-presentation/) และ [writing](/slides/th/python-net/save-presentation/) แต่ความแตกต่างของรูปแบบอาจทำให้บางเอฟเฟกต์ดูหรือทำงานแตกต่างกันเล็กน้อย ตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง