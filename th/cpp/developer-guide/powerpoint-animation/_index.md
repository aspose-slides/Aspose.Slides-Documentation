---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยแอนิเมชันใน C++
linktitle: แอนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/cpp/powerpoint-animation/
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
- แอนิเมชันเชิงโต้ตอบ
- แอนิเมชันแบบกำหนดเอง
- แอนิเมชันรูปร่าง
- แผนภูมิที่แอนิเมชัน
- ข้อความที่แอนิเมชัน
- รูปร่างที่แอนิเมชัน
- วัตถุ OLE ที่แอนิเมชัน
- ภาพที่แอนิเมชัน
- ตารางที่แอนิเมชัน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและควบคุมเอฟเฟกต์แอนิเมชันขั้นสูงใน Aspose.Slides สำหรับ C++ เพื่อสร้างการนำเสนอ PowerPoint และ OpenDocument ที่มีความไดนามิก"
---
## **บทนำ**

เนื่องจากการนำเสนอมีวัตถุประสงค์เพื่อแสดงสิ่งใดสิ่งหนึ่ง การออกแบบรูปลักษณ์ที่มองเห็นได้และพฤติกรรมเชิงโต้ตอบจึงได้รับการพิจารณาตลอดเวลาในการสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอดึงดูดความสนใจและน่าสนใจสำหรับผู้ชม Aspose.Slides for C++ มีตัวเลือกหลากหลายในการเพิ่มแอนิเมชันให้กับการนำเสนอ PowerPoint:
- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint ประเภทต่าง ๆ กับรูปร่าง, แผนภูมิ, ตาราง, วัตถุ OLE และองค์ประกอบการนำเสนออื่น ๆ
- ใช้แอนิเมชัน PowerPoint หลายเอฟเฟกต์บนรูปร่างเดียว
- ใช้ไทม์ไลน์แอนิเมชันเพื่อควบคุมเอฟเฟกต์แอนิเมชัน
- สร้างแอนิเมชันแบบกำหนดเอง

ใน Aspose.Slides for C++ สามารถใช้เอฟเฟกต์แอนิเมชันต่าง ๆ กับรูปร่างได้ เนื่องจากทุกองค์ประกอบบนสไลด์รวมถึงข้อความ, รูปภาพ, วัตถุ OLE, ตาราง ฯลฯ ถือเป็นรูปร่าง ดังนั้นเราจึงสามารถใช้เอฟเฟกต์แอนิเมชันกับทุกองค์ประกอบของสไลด์ได้

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation) **namespace** ให้คลาสสำหรับทำงานกับแอนิเมชัน PowerPoint.

## **เอฟเฟกต์แอนิเมชัน**
Aspose.Slides รองรับ **150+ เอฟเฟกต์แอนิเมชัน**, รวมถึงเอฟเฟกต์แอนิเมชันพื้นฐานเช่น Bounce, PathFootball, Zoom และเอฟเฟกต์แอนิเมชันเฉพาะเช่น OLEObjectShow, OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟกต์แอนิเมชันได้ใน [**EffectType**](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)enumeration.

นอกจากนี้ เอฟเฟกต์แอนิเมชันเหล่านี้สามารถใช้ร่วมกับกันได้:
- [ColorEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.set_effect)

## **แอนิเมชันแบบกำหนดเอง**
คุณสามารถสร้าง **แอนิเมชันแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้ การทำเช่นนี้สามารถทำได้โดยการรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นแอนิเมชันแบบกำหนดเองใหม่

[**Behavior**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.behavior) เป็นหน่วยการสร้างของเอฟเฟกต์แอนิเมชัน PowerPoint ทุกประเภท เอฟเฟกต์แอนิเมชันทั้งหมดจริง ๆ แล้วคือชุดของพฤติกรรมที่ประกอบเป็นกลยุทธ์หนึ่ง คุณสามารถรวมพฤติกรรมเข้ากับแอนิเมชันแบบกำหนดเองหนึ่งครั้งและใช้ซ้ำในงานนำเสนออื่น หากคุณเพิ่มพฤติกรรมใหม่เข้าไปในเอฟเฟกต์แอนิเมชัน PowerPoint มาตรฐาน จะกลายเป็นแอนิเมชันแบบกำหนดเองอีกหนึ่งตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรมการทำซ้ำให้กับแอนิเมชันเพื่อให้มันทำซ้ำหลายครั้ง

[**Animation Point**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.point) คือจุดที่ควรนำพฤติกรรมไปใช้

## **ไทม์ไลน์แอนิเมชัน**
[**Sequence**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.sequence) คือคอลเลกชันของเอฟเฟกต์แอนิเมชันที่นำไปใช้กับรูปร่างเฉพาะ

[**AnimationTimeLine**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.animation_time_line) คือชุดของ Sequence ที่ใช้ในสไลด์เฉพาะ มันเป็นเครื่องยนต์แอนิเมชันที่มีตั้งแต่ PowerPoint 2002 ในเวอร์ชัน PowerPoint ก่อนหน้า การเพิ่มเอฟเฟกต์แอนิเมชันลงในงานนำเสนอเป็นเรื่องท้าทายและทำได้เฉพาะด้วยวิธีแก้ปัญหาต่าง ๆ ไทม์ไลน์มาแทนที่คลาส AnimationSettings เก่าและให้โมเดลออบเจกต์ที่ชัดเจนมากขึ้นสำหรับแอนิเมชัน PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์แอนิเมชันได้เพียงหนึ่งเท่านั้น

## **แอนิเมชันเชิงโต้ตอบ**
[**EffectTriggerType**](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) อนุญาตให้กำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะทำให้แอนิเมชันบางอย่างเริ่มต้น ตัวกระตุ้น (Triggers) ถูกเพิ่มในเวอร์ชัน PowerPoint ล่าสุดเท่านั้น

## **แอนิเมชันรูปร่าง**
Aspose.Slides อนุญาตให้ใช้แอนิเมชันกับรูปร่าง ซึ่งอาจเป็นข้อความ, สี่เหลี่ยม, เส้น, กรอบ, วัตถุ OLE ฯลฯ

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับแอนิเมชันรูปร่าง**](/slides/th/cpp/shape-animation/)
{{% /alert %}}

## **กราฟแอนิเมชัน**
เพื่อสร้างกราฟที่มีแอนิเมชัน คุณควรใช้คลาสเดียวกันกับการทำงานกับรูปร่าง อย่างไรก็ตาม สามารถใช้แอนิเมชัน PowerPoint ได้เฉพาะกับประเภทของกราฟหรือซีรีส์ของกราฟ คุณยังสามารถใช้เอฟเฟกต์แอนิเมชันกับองค์ประกอบของประเภทหรือซีรีส์ได้

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับกราฟแอนิเมชัน**](/slides/th/cpp/animated-charts/)
{{% /alert %}}

## **ข้อความแอนิเมชัน**
นอกจากข้อความแอนิเมชันแล้ว ยังสามารถใช้แอนิเมชันกับย่อหน้าด้วย

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับข้อความแอนิเมชัน**](/slides/th/cpp/animated-text/)
{{% /alert %}}

## **FAQ**

### การแอนิเมชันจะคงอยู่เมื่อส่งออกเป็น PDF หรือไม่?
ไม่ PDF เป็นรูปแบบที่คงที่ ดังนั้นแอนิเมชันและ [slide transitions](/slides/th/cpp/slide-transition/) จะไม่ทำงาน หากต้องการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/cpp/export-to-html5/), [animated GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/cpp/convert-powerpoint-to-video/) แทน

### ฉันสามารถแปลงการนำเสนอแอนิเมชันเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?
ได้ คุณสามารถ [render the presentation as frames](/slides/th/cpp/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด แอนิเมชันและการเปลี่ยนสไลด์จะถูกเล่นระหว่างการเรนเดอร์

### แอนิเมชันจะคงที่อยู่เมื่อติดต่อกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?
PPT, PPTX และ ODP รองรับการ [reading](/slides/th/cpp/open-presentation/) และ [writing](/slides/th/cpp/save-presentation/) แต่ความแตกต่างของรูปแบบทำให้เอฟเฟกต์บางอย่างอาจแสดงหรือทำงานต่างกันเล็กน้อย ตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง