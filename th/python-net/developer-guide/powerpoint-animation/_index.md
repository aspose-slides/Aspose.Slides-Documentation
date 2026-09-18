---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยแอนิเมชันใน Python
linktitle: แอนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/python-net/powerpoint-animation/
keywords:
- เพิ่มแอนิเมชัน
- ปรับปรุงแอนิเมชัน
- เปลี่ยนแอนิเมชัน
- ลบแอนิเมชัน
- จัดการแอนิเมชัน
- ควบคุมแอนิเมชัน
- เอฟเฟกต์แอนิเมชัน
- แอนิเมชัน PowerPoint
- ไทม์ไลน์แอนิเมชัน
- แอนิเมชันเชิงโต้ตอบ
- แอนิเมชันแบบกำหนดเอง
- แอนิเมชันรูปทรง
- แผนภูมิแบบแอนิเมชัน
- ข้อความแบบแอนิเมชัน
- รูปทรงแบบแอนิเมชัน
- วัตถุ OLE แบบแอนิเมชัน
- รูปภาพแบบแอนิเมชัน
- ตารางแบบแอนิเมชัน
- การนำเสนอ PowerPoint
- Python
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ Python via .NET ในการจัดการแอนิเมชัน PowerPoint ภาพรวมทั่วไปนี้เน้นคุณลักษณะสำคัญและให้ข้อมูลเชิงลึกเพื่อเพิ่มคุณภาพการนำเสนอของคุณ"
---
## **บทนำ**

การนำเสนอออกแบบมาเพื่อสื่อสารข้อมูล ดังนั้นลักษณะทางภาพและพฤติกรรมแบบโต้ตอบจึงเป็นสิ่งที่ต้องคำนึงถึงอย่างสำคัญระหว่างการสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสดงดึงดูดความสนใจและน่าสนใจสำหรับผู้ชม Aspose.Slides for Python via .NET มีตัวเลือกหลากหลายเพื่อเพิ่มแอนิเมชันให้กับการนำเสนอ PowerPoint คุณสามารถ:

- ใช้เอฟเฟกต์แอนิเมชันต่าง ๆ ไปใช้กับรูปทรง, แผนภูมิ, ตาราง, วัตถุ OLE และองค์ประกอบอื่น ๆ
- ใช้หลายเอฟเฟกต์แอนิเมชันบนรูปทรงเดียว
- ควบคุมเอฟเฟกต์ผ่านไทม์ไลน์ของแอนิเมชัน
- สร้างแอนิเมชันแบบกำหนดเอง

ใน Aspose.Slides for Python via .NET เอฟเฟกต์แอนิเมชันสามารถนำไปใช้กับรูปทรงได้ เพราะทุกองค์ประกอบบนสไลด์รวมถึงข้อความ, รูปภาพ, วัตถุ OLE และตารางถือเป็นรูปทรง คุณจึงสามารถนำเอฟเฟกต์แอนิเมชันไปใช้กับองค์ประกอบใด ๆ บนสไลด์ได้

[aspose.slides.animation](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/) namespace ให้คลาสสำหรับทำงานกับแอนิเมชัน PowerPoint

## **การติดตั้ง**

```bash
pip install aspose.slides
```

## **เพิ่มเอฟเฟกต์แอนิเมชันให้กับรูปทรงใน Python**

เอฟเฟกต์แอนิเมชันอยู่ในลำดับหลักของสไลด์ เพิ่มรูปทรงแล้วเรียก `add_effect` บน `slide.timeline.main_sequence` โดยส่งประเภทเอฟเฟกต์, ชนิดย่อย และทริกเกอร์ที่เริ่มต้นมัน

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

ไฟล์ที่บันทึกไว้มีเอฟเฟกต์หนึ่งตัวบนสไลด์แรก: สี่เหลี่ยมผืนผ้าบินเข้าจากด้านซ้ายในระยะสองวินาทีเมื่อผู้นำเสนอคลิก การเปิดไฟล์อีกครั้งและอ่าน `slide.timeline.main_sequence` จะคืนค่าเอฟเฟกต์นั้น ทำให้แอนิเมชันคงอยู่ในการเดินทางรอบแทนที่จะมีแค่ในหน่วยความจำเท่านั้น

## **เอฟเฟกต์แอนิเมชัน**

Aspose.Slides รองรับ **150+ animation effects** รวมถึงเอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball, และ Zoom รวมถึงเอฟเฟกต์พิเศษเช่น OLEObjectShow และ OLEObjectOpen คุณสามารถดูรายการทั้งหมดได้ใน enumeration [EffectType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effecttype/)

นอกจากนี้เอฟเฟกต์แอนิเมชันเหล่านี้ยังสามารถรวมกับเอฟเฟกต์ต่อไปนี้ได้:

- [ColorEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/seteffect/)

## **แอนิเมชันแบบกำหนดเอง**

สำหรับตัวอย่าง Python ที่สมบูรณ์ซึ่งสร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมและเส้นทางการเคลื่อนที่ที่แก้ไขได้ ดูที่ [Custom Animation](/slides/th/python-net/custom-animation/)

คุณสามารถสร้าง **custom animations** ของคุณเองใน Aspose.Slides โดยการรวมหลายพฤติกรรมเข้าด้วยกันเป็นเอฟเฟกต์เดียว

[Behavior](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behavior/) คือบล็อคการสร้างของเอฟเฟกต์แอนิเมชัน PowerPoint ผสานพฤติกรรมเพื่อปรับแต่งเอฟเฟกต์ หรือเพิ่มพฤติกรรมเพื่อขยายเอฟเฟกต์ที่กำหนดไว้ล่วงหน้า การทำซ้ำถูกกำหนดผ่านการตั้งค่าตามเวลาแทนการใช้พฤติกรรมซ้ำแยกกัน

[Animation Point](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/point/) เป็นจุดที่ระบุช่วงเวลา หรือ ตำแหน่งที่พฤติกรรมถูกนำไปใช้ (คีย์เฟรม)

## **ไทม์ไลน์ของแอนิเมชัน**

[Sequence](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/sequence/) คือคอล렉ชันของเอฟเฟกต์แอนิเมชันที่สามารถทำเป้าหมายกับรูปทรงต่าง ๆ

[Timeline](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/animationtimeline/) คือชุดของลำดับที่ใช้บนสไลด์เฉพาะ มันถูกนำมาใช้ครั้งแรกใน PowerPoint 2002 ในเวอร์ชันก่อนหน้านี้ของ PowerPoint การเพิ่มเอฟเฟกต์แอนิเมชันทำได้ยากและมักต้องใช้วิธีแก้ปัญหาไทม์ไลน์แทนคลาส `AnimationSettings` เก่าและให้โมเดลวัตถุที่ชัดเจนขึ้นสำหรับแอนิเมชัน PowerPoint แต่ละสไลด์สามารถมีไทม์ไลน์แอนิเมชันได้เพียงหนึ่งลำดับ

## **แอนิเมชันแบบโต้ตอบ**

[Trigger](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effecttriggertype/) ช่วยให้คุณกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่เริ่มแอนิเมชันเฉพาะ การเพิ่ม Trigger มีเฉพาะในเวอร์ชันล่าสุดของ PowerPoint

## **แอนิเมชันรูปทรง**

Aspose.Slides ทำให้คุณสามารถนำแอนิเมชันไปใช้กับรูปทรง—เช่น ข้อความ, สี่เหลี่ยม, เส้น, เฟรม, วัตถุ OLE และอื่น ๆ

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**About Shape Animation**](/slides/th/python-net/shape-animation/)
{{% /alert %}}

## **แผนภูมิแอนิเมชัน**

เพื่อสร้างแผนภูมิที่มีแอนิเมชัน ให้ใช้คลาสเดียวกันกับที่ใช้กับรูปทรง อย่างไรก็ตามแอนิเมชัน PowerPoint สามารถนำไปใช้ได้เฉพาะกับประเภทของแผนภูมิหรือซีรีส์ของแผนภูมิเท่านั้น คุณยังสามารถนำเอฟเฟกต์แอนิเมชันไปใช้กับองค์ประกอบประเภทเดียวหรือซีรีส์เดียวได้

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**About Animated Charts**](/slides/th/python-net/animated-charts/)
{{% /alert %}}

## **ข้อความแอนิเมชัน**

นอกจากการทำแอนิเมชันกับข้อความแล้ว คุณยังสามารถนำแอนิเมชันไปใช้กับย่อหน้าได้

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**About Animated Text**](/slides/th/python-net/animated-text/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Will animations be preserved when exporting to PDF?**

ไม่. PDF เป็นรูปแบบคงที่ ดังนั้นแอนิเมชันและ [slide transitions](/slides/th/python-net/slide-transition/) จะไม่เล่น หากต้องการเคลื่อนไหวให้ส่งออกเป็น [HTML5](/slides/th/python-net/export-to-html5/), [animated GIF](/slides/th/python-net/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/python-net/convert-powerpoint-to-video/) แทน

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

ได้ คุณสามารถ [render the presentation as frames](/slides/th/python-net/convert-powerpoint-to-video/) และเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด แอนิเมชันและการเปลี่ยนสไลด์จะเล่นระหว่างการเรนเดอร์

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/python-net/open-presentation/) และ [writing](/slides/th/python-net/save-presentation/) แต่ไม่ได้รับการรับประกันว่าจะแอนิเมชันจะคงอยู่ ข้อมูลแอนิเมชันแบบกำหนดเองอาจหายไปเมื่อแปลงเป็น ODP ดู [Custom Animation](/slides/th/python-net/custom-animation/) สำหรับตัวอย่างและแนวทางการตรวจสอบความเข้ากันได้ของรูปแบบ