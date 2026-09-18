---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยอนิเมชันใน .NET
linktitle: อนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/net/powerpoint-animation/
keywords:
- เพิ่มอนิเมชัน
- อัปเดตอนิเมชัน
- เปลี่ยนอนิเมชัน
- ลบอนิเมชัน
- จัดการอนิเมชัน
- ควบคุมอนิเมชัน
- เอฟเฟกต์อนิเมชัน
- อนิเมชัน PowerPoint
- ไทม์ไลน์ของอนิเมชัน
- อนิเมชันเชิงโต้ตอบ
- อนิเมชันแบบกำหนดเอง
- อนิเมชันรูปร่าง
- แผนภูมิที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- รูปร่างที่เคลื่อนไหว
- วัตถุ OLE ที่เคลื่อนไหว
- รูปภาพที่เคลื่อนไหว
- ตารางที่เคลื่อนไหว
- การนำเสนอ PowerPoint
- .NET
- C#
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ .NET ในการจัดการอนิเมชัน PowerPoint บทสรุปทั่วไปนี้เน้นคุณลักษณะสำคัญและให้ข้อมูลเชิงลึกเพื่อปรับปรุงการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากการนำเสนอมีจุดประสงค์เพื่อแสดงบางอย่าง ลักษณะภาพและพฤติกรรมเชิงโต้ตอบจะถูกพิจารณาตลอดกระบวนการสร้างเสมอ.

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอน่าดึงดูดและดึงดูดผู้ชม Aspose.Slides for .NET ให้ตัวเลือกหลากหลายเพื่อเพิ่มอนิเมชันให้กับการนำเสนอ PowerPoint:
- ใช้เอฟเฟ็กต์อนิเมชัน PowerPoint ประเภทต่าง ๆ กับรูปร่าง, แผนภูมิ, ตาราง, วัตถุ OLE และองค์ประกอบการนำเสนออื่น ๆ.
- ใช้เอฟเฟ็กต์อนิเมชัน PowerPoint หลายแบบบนรูปร่างเดียว.
- ใช้ไทม์ไลน์ของอนิเมชันเพื่อควบคุมเอฟเฟ็กต์อนิเมชัน.
- สร้างอนิเมชันแบบกำหนดเอง.

ใน Aspose.Slides for .NET สามารถนำเอฟเฟ็กต์อนิเมชันต่าง ๆ ไปใช้กับรูปร่างได้ เนื่องจากทุกองค์ประกอบบนสไลด์รวมถึงข้อความ, รูปภาพ, วัตถุ OLE และตารางถือเป็นรูปร่าง จึงสามารถนำเอฟเฟ็กต์อนิเมชันไปใช้กับองค์ประกอบใดก็ได้บนสไลด์.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/th/net/aspose.slides.animation/) namespace ให้คลาสสำหรับทำงานกับอนิเมชัน PowerPoint.

## **เอฟเฟ็กต์อนิเมชัน**

Aspose.Slides รองรับ **เอฟเฟ็กต์อนิเมชัน 150+** รวมถึงเอฟเฟ็กต์พื้นฐานเช่น Bounce, PathFootball, และ Zoom รวมถึงเอฟเฟ็กต์เฉพาะเช่น OLEObjectShow และ OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟ็กต์อนิเมชันได้ใน enumeration [EffectType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttype).

นอกจากนี้ เอฟเฟ็กต์อนิเมชันเหล่านี้สามารถใช้ร่วมกับรายการต่อไปนี้:
- [ColorEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/seteffect)

## **อนิเมชันแบบกำหนดเอง**

สำหรับตัวอย่าง C# ที่สมบูรณ์ซึ่งสร้าง, ตรวจสอบ, และแก้ไข behavior และเส้นทางการเคลื่อนที่ที่แก้ไขได้ ดูที่ [การสร้างอนิเมชันแบบกำหนดเอง](/slides/th/net/custom-animation/).

คุณสามารถสร้าง **อนิเมชันแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้ โดยการผสานหลาย behavior เข้าด้วยกันเป็นอนิเมชันใหม่.

[Behavior](https://reference.aspose.com/slides/th/net/aspose.slides.animation/behavior) เป็นบล็อกการสร้างของเอฟเฟ็กต์อนิเมชัน PowerPoint. ผสาน behavior เพื่อปรับแต่งเอฟเฟ็กต์ หรือเพิ่ม behavior เพื่อขยายเอฟเฟ็กต์ที่กำหนดไว้ล่วงหน้า การทำซ้ำกำหนดผ่านการตั้งค่าเวลา แทนการใช้ behavior แยกสำหรับการทำซ้ำ.

[Animation Point](https://reference.aspose.com/slides/th/net/aspose.slides.animation/point) คือจุดที่ควรนำ behavior ไปใช้.

## **ไทม์ไลน์ของอนิเมชัน**

[Sequence](https://reference.aspose.com/slides/th/net/aspose.slides.animation/sequence) เป็นคอลเลกชันของเอฟเฟ็กต์อนิเมชันที่สามารถกำหนดเป้าหมายให้กับรูปร่างต่าง ๆ.

[Timeline](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animationtimeline) เป็นชุดของ sequence ที่ใช้ในสไลด์เฉพาะ มันเป็นเอ็นจิ้นของอนิเมชันที่แนะนำครั้งแรกใน PowerPoint 2002 ในเวอร์ชันก่อนหน้าของ PowerPoint การเพิ่มเอฟเฟ็กต์อนิเมชันลงในการนำเสนอเป็นเรื่องยากและทำได้เพียงโดยวิธีแก้ปัญหาต่าง ๆ ไทม์ไลน์แทนที่คลาส AnimationSettings เก่าและให้โมเดลวัตถุที่ชัดเจนขึ้นสำหรับอนิเมชัน PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์ของอนิเมชันได้เพียงหนึ่งชุด.

## **อนิเมชันเชิงโต้ตอบ**

[Trigger](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttriggertype) ให้คุณกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะเริ่มต้นอนิเมชันเฉพาะ Trigger ถูกแนะนำในเวอร์ชันล่าสุดของ PowerPoint.

## **อนิเมชันรูปร่าง**

Aspose.Slides อนุญาตให้คุณเพิ่มอนิเมชันให้กับรูปร่าง ซึ่งอาจรวมถึงข้อความ, สี่เหลี่ยม, เส้น, เฟรม, วัตถุ OLE และอื่น ๆ.

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**เกี่ยวกับอนิเมชันรูปร่าง**](/slides/th/net/shape-animation/).
{{% /alert %}}

## **แผนภูมิที่เคลื่อนไหว**

เพื่อสร้างแผนภูมิที่เคลื่อนไหว คุณควรใช้คลาสเดียวกับที่ใช้กับรูปร่าง อย่างไรก็ตาม อนิเมชัน PowerPoint สามารถใช้ได้เฉพาะกับหมวดหมู่ของแผนภูมิหรือซีรีส์ของแผนภูมิเท่านั้น คุณยังสามารถนำเอฟเฟ็กต์อนิเมชันไปใช้กับองค์ประกอบของหมวดหมู่หรือซีรีส์ได้.

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**เกี่ยวกับแผนภูมิที่เคลื่อนไหว**](/slides/th/net/animated-charts/).
{{% /alert %}}

## **ข้อความที่เคลื่อนไหว**

นอกจากการทำให้ข้อความเคลื่อนไหวแล้ว คุณยังสามารถนำอนิเมชันไปใช้กับย่อหน้าหนึ่งได้.

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**เกี่ยวกับข้อความที่เคลื่อนไหว**](/slides/th/net/animated-text/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การอนิเมชันจะคงอยู่เมื่อส่งออกเป็น PDF หรือไม่?**

ไม่ PDF เป็นรูปแบบที่คงที่ ดังนั้นอนิเมชันและ [slide transitions](/slides/th/net/slide-transition/) จะไม่ทำงาน หากคุณต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/net/export-to-html5/), [animated GIF](/slides/th/net/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/net/convert-powerpoint-to-video/) แทน.

**ฉันสามารถแปลงการนำเสนอที่มีอนิเมชันเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ได้ คุณสามารถ [render the presentation as frames](/slides/th/net/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด การอนิเมชันและ slide transitions จะถูกเล่นระหว่างการเรนเดอร์.

**การอนิเมชันจะคงอยู่เมื่อทำงานกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?**

PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/net/open-presentation/) และ [writing](/slides/th/net/save-presentation/) แต่ไม่ได้รับประกันการคงรักษาอนิเมชัน ข้อมูลอนิเมชันแบบกำหนดเองอาจสูญหายเมื่อตัวแปลงเป็น ODP ดูที่ [Custom Animation](/slides/th/net/custom-animation/) สำหรับตัวอย่างที่ทดสอบและข้อจำกัดของฟอร์แมต.