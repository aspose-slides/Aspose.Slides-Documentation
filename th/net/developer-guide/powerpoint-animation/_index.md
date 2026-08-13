---
title: ปรับปรุงการนำเสนอ PowerPoint ด้วยแอนิเมชันใน .NET
linktitle: แอนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/net/powerpoint-animation/
keywords:
- เพิ่มแอนิเมชัน
- อัปเดตแอนิเมชัน
- เปลี่ยนแอนิเมชัน
- ลบแอนิเมชัน
- จัดการแอนิเมชัน
- ควบคุมแอนิเมชัน
- เอฟเฟกต์แอนิเมชัน
- แอนิเมชัน PowerPoint
- ไทม์ไลน์แอนิเมชัน
- แอนิเมชันแบบโต้ตอบ
- แอนิเมชันแบบกำหนดเอง
- แอนิเมชันรูปทรง
- แผนภูมิแอนิเมชัน
- ข้อความแอนิเมชัน
- รูปทรงแอนิเมชัน
- วัตถุ OLE แอนิเมชัน
- ภาพแอนิเมชัน
- ตารางแอนิเมชัน
- การนำเสนอ PowerPoint
- .NET
- C#
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ .NET ในการจัดการแอนิเมชัน PowerPoint ภาพรวมทั่วไปนี้เน้นคุณลักษณะสำคัญและให้ข้อมูลเชิงลึกเพื่อปรับปรุงการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากการนำเสนอมีจุดประสงค์เพื่อแสดงข้อมูล ลักษณะการมองเห็นและพฤติกรรมโต้ตอบจึงได้รับการพิจารณาตลอดกระบวนการสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสดดึงดูดความสนใจและน่าติดตามสำหรับผู้ชม Aspose.Slides for .NET มีตัวเลือกหลากหลายเพื่อเพิ่มแอนิเมชันให้กับการนำเสนอ PowerPoint:

- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint ประเภทต่าง ๆ กับรูปร่าง, แผนภูมิ, ตาราง, วัตถุ OLE และองค์ประกอบการนำเสนออื่น ๆ
- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint หลายแบบบนรูปร่างเดียว
- ใช้ไทม์ไลน์ของแอนิเมชันเพื่อควบคุมเอฟเฟกต์แอนิเมชัน
- สร้างแอนิเมชันแบบกำหนดเอง

ใน Aspose.Slides for .NET สามารถใช้เอฟเฟกต์แอนิเมชันต่าง ๆ กับรูปร่างได้ เนื่องจากทุกองค์ประกอบบนสไลด์ รวมถึงข้อความ, รูปภาพ, วัตถุ OLE และตาราง ถือเป็นรูปร่าง จึงสามารถใช้เอฟเฟกต์แอนิเมชันกับองค์ประกอบใดก็ได้บนสไลด์

[Aspose.Slides.Animation](https://reference.aspose.com/slides/th/net/aspose.slides.animation/) namespace ให้คลาสสำหรับทำงานกับแอนิเมชัน PowerPoint.

## **เอฟเฟกต์แอนิเมชัน**

Aspose.Slides รองรับ **เอฟเฟกต์แอนิเมชันกว่า 150 รายการ** รวมถึงเอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball, และ Zoom รวมถึงเอฟเฟกต์เฉพาะเช่น OLEObjectShow และ OLEObjectOpen คุณสามารถดูรายการครบถ้วนของเอฟเฟกต์แอนิเมชันได้ใน enumeration [EffectType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttype).

นอกจากนี้ เอฟเฟกต์แอนิเมชันเหล่านี้สามารถใช้ร่วมกับรายการต่อไปนี้:

- [ColorEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/seteffect)

## **แอนิเมชันแบบกำหนดเอง**

สามารถสร้าง **แอนิเมชันแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้ โดยการรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นแอนิเมชันแบบกำหนดใหม่

[Behaviour](https://reference.aspose.com/slides/th/net/aspose.slides.animation/behavior) คือส่วนประกอบพื้นฐานของเอฟเฟกต์แอนิเมชัน PowerPoint ทุกเอฟเฟกต์แอนิเมชันโดยพื้นฐานคือชุดของพฤติกรรมที่ประกอบเป็นกลยุทธ์เดียว คุณสามารถรวมพฤติกรรมเป็นแอนิเมชันแบบกำหนดเองหนึ่งครั้งแล้วนำมาใช้ซ้ำในงานนำเสนออื่น หากคุณเพิ่มพฤติกรรมใหม่เข้าไปในเอฟเฟกต์แอนิเมชัน PowerPoint มาตรฐาน จะกลายเป็นแอนิเมชันแบบกำหนดเองอีกหนึ่งแบบ ตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรม repeat ให้กับแอนิเมชันเพื่อให้ทำซ้ำหลายครั้ง

[Animation Point](https://reference.aspose.com/slides/th/net/aspose.slides.animation/point) คือจุดที่ควรใช้พฤติกรรม

## **ไทม์ไลน์แอนิเมชัน**

[Sequence](https://reference.aspose.com/slides/th/net/aspose.slides.animation/sequence) คือคอลเลกชันของเอฟเฟกต์แอนิเมชันที่ใช้กับรูปร่างเฉพาะ

[Timeline](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animationtimeline) คือชุดของ sequence ที่ใช้ในสไลด์เฉพาะ เป็นเอ็นจินแอนิเมชันที่ถูกนำเข้ามาใน PowerPoint 2002 ในรุ่นก่อนๆ ของ PowerPoint การเพิ่มเอฟเฟกต์แอนิเมชันให้กับการนำเสนออาจเป็นเรื่องยากและทำได้เพียงด้วยวิธีแก้ปัญหาต่างๆ ไทม์ไลน์จะแทนที่คลาส AnimationSettings เก่าและให้โมเดลอ็อบเจ็กต์ที่ชัดเจนขึ้นสำหรับแอนิเมชัน PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์แอนิเมชันได้หนึ่งชุดเท่านั้น

## **แอนิเมชันแบบโต้ตอบ**

[Trigger](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttriggertype) ให้คุณกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะเริ่มแอนิเมชันเฉพาะ Triggers ถูกนำเข้ามาในรุ่นล่าสุดของ PowerPoint.

## **แอนิเมชันรูปทรง**

Aspose.Slides ให้คุณเพิ่มแอนิเมชันให้กับรูปร่าง ซึ่งอาจรวมถึงข้อความ, สี่เหลี่ยม, เส้น, เฟรม, วัตถุ OLE และอื่น ๆ

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับการทำแอนิเมชันรูปทรง**](/slides/th/net/shape-animation/).
{{% /alert %}}

## **แผนภูมิแบบแอนิเมชัน**

เพื่อสร้างแผนภูมิแบบแอนิเมชัน คุณควรใช้คลาสเดียวกับที่ใช้กับรูปร่าง อย่างไรก็ตาม แอนิเมชัน PowerPoint สามารถใช้ได้กับหมวดหมู่แผนภูมิหรือซีรีส์ของแผนภูมิเท่านั้น คุณยังสามารถใช้เอฟเฟกต์แอนิเมชันกับองค์ประกอบของหมวดหมู่หรือของซีรีส์ได้

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับแผนภูมิแบบแอนิเมชัน**](/slides/th/net/animated-charts/).
{{% /alert %}}

## **ข้อความแบบแอนิเมชัน**

นอกจากข้อความแบบแอนิเมชัน ยังก็สามารถใช้แอนิเมชันกับย่อหน้าได้

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับข้อความแบบแอนิเมชัน**](/slides/th/net/animated-text/).
{{% /alert %}}

## **FAQ**

### การแอนิเมชันจะคงอยู่เมื่อส่งออกเป็น PDF หรือไม่?

ไม่ PDF เป็นรูปแบบแบบสถิตย์ ดังนั้นแอนิเมชันและ [slide transitions](/slides/th/net/slide-transition/) จะไม่ทำงาน หากต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/net/export-to-html5/), [animated GIF](/slides/th/net/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/net/convert-powerpoint-to-video/) แทน

### ฉันสามารถแปลงการนำเสนอที่เป็นแอนิเมชันเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?

ได้ คุณสามารถ [render the presentation as frames](/slides/th/net/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด การแอนิเมชันและการเปลี่ยนสไลด์จะถูกเล่นขณะเรนเดอร์

### แอนิเมชันจะคงที่เมื่อทำงานกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?

PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/net/open-presentation/) และ [writing](/slides/th/net/save-presentation/) แต่ความแตกต่างของฟอร์แมตอาจทำให้เอฟเฟกต์บางอย่างดูหรือทำงานแตกต่างกันเล็กน้อย ควรตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง