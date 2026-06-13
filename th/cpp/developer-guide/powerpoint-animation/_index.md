---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยการเคลื่อนไหวใน C++
linktitle: การเคลื่อนไหว PowerPoint
type: docs
weight: 150
url: /th/cpp/powerpoint-animation/
keywords:
- เพิ่มการเคลื่อนไหว
- ปรับปรุงการเคลื่อนที่
- เปลี่ยนการเคลื่อนที่
- ลบการเคลื่อนที่
- จัดการการเคลื่อนที่
- ควบคุมการเคลื่อนที่
- เอฟเฟ็กต์การเคลื่อนที่
- การเคลื่อนไหว PowerPoint
- ไทม์ไลน์การเคลื่อนที่
- การเคลื่อนที่เชิงโต้ตอบ
- การเคลื่อนที่แบบกำหนดเอง
- การเคลื่อนที่ของรูปร่าง
- แผนภูมิเคลื่อนไหว
- ข้อความเคลื่อนไหว
- รูปร่างเคลื่อนไหว
- วัตถุ OLE เคลื่อนไหว
- รูปภาพเคลื่อนไหว
- ตารางเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและควบคุมเอฟเฟ็กต์การเคลื่อนไหวขั้นสูงใน Aspose.Slides สำหรับ C++ เพื่อสร้างการนำเสนอ PowerPoint และ OpenDocument ที่มีความเคลื่อนไหว."
---
## **บทนำ**

เนื่องจากการนำเสนอมีจุดมุ่งหมายเพื่อแสดงบางอย่าง การปรากฏภาพและพฤติกรรมเชิงโต้ตอบของมันจึงถูกพิจารณาตลอดเวลาที่สร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอดูน่าสนใจและดึงดูดผู้ชม Aspose.Slides for C++ มีตัวเลือกหลากหลายเพื่อเพิ่มการเคลื่อนไหวให้กับการนำเสนอ PowerPoint:
- ใช้เอฟเฟ็กต์การเคลื่อนไหวของ PowerPoint ประเภทต่าง ๆ กับรูปร่าง, แผนภูมิ, ตาราง, วัตถุ OLE และส่วนประกอบอื่น ๆ ของการนำเสนอ.
- ใช้เอฟเฟ็กต์การเคลื่อนไหวของ PowerPoint หลายแบบบนรูปร่างหนึ่งอัน.
- ใช้ไทม์ไลน์การเคลื่อนไหวเพื่อควบคุมเอฟเฟ็กต์การเคลื่อนไหว.
- สร้างการเคลื่อนไหวแบบกำหนดเอง.

ใน Aspose.Slides for C++ สามารถใช้เอฟเฟ็กต์การเคลื่อนไหวต่าง ๆ กับรูปร่างได้ เนื่องจากทุกองค์ประกอบบนสไลด์รวมถึงข้อความ, ภาพ, วัตถุ OLE, ตาราง ฯลฯ ถูกพิจารณาเป็นรูปร่าง ดังนั้นเราจึงสามารถใช้เอฟเฟ็กต์การเคลื่อนไหวกับทุกองค์ประกอบของสไลด์ได้.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation) **namespace** ให้คลาสสำหรับทำงานกับการเคลื่อนไหวของ PowerPoint.

## **เอฟเฟ็กต์การเคลื่อนไหว**

Aspose.Slides รองรับ **150+ เอฟเฟ็กต์การเคลื่อนไหว**, รวมถึงเอฟเฟ็กต์พื้นฐานเช่น Bounce, PathFootball, Zoom effect และเอฟเฟ็กต์เฉพาะเช่น OLEObjectShow, OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟ็กต์การเคลื่อนไหวได้ใน enumeration [**EffectType**](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

นอกจากนี้ เอฟเฟ็กต์การเคลื่อนไหวเหล่านี้สามารถใช้ร่วมกันได้:
- [ColorEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.set_effect)

## **การเคลื่อนไหวแบบกำหนดเอง**

สามารถสร้าง **การเคลื่อนไหวแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้ หากคุณรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นการเคลื่อนไหวแบบกำหนดเองใหม่

[**Behavior**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.behavior) เป็นหน่วยการสร้างของเอฟเฟ็กต์การเคลื่อนไหวของ PowerPoint ทุกเอฟเฟ็กต์การเคลื่อนไหวจริงๆ แล้วเป็นชุดของพฤติกรรมที่ประกอบเป็นกลยุทธ์เดียว คุณสามารถรวมพฤติกรรมเข้าด้วยกันเป็นการเคลื่อนไหวแบบกำหนดเองหนึ่งครั้งและนำไปใช้ใหม่ในงานนำเสนออื่น หากคุณเพิ่มพฤติกรรมใหม่ลงในเอฟเฟ็กต์การเคลื่อนไหวมาตรฐานของ PowerPoint มันจะกลายเป็นการเคลื่อนไหวแบบกำหนดเองอีกหนึ่งตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรมการทำซ้ำให้กับการเคลื่อนไหวเพื่อให้มันทำซ้ำหลายครั้ง

[**Animation Point**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.point) คือจุดที่ต้องใช้พฤติกรรม

## **ไทม์ไลน์การเคลื่อนไหว**

[**Sequence**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.sequence) คือการประมวลรวมของเอฟเฟ็กต์การเคลื่อนไหวที่นำไปใช้กับรูปร่างหนึ่ง

[**AnimationTimeLine**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.animation_time_line) คือชุดของ Sequence ที่ใช้ในสไลด์หนึ่ง มันเป็นเอนจินการเคลื่อนที่ที่มีตั้งแต่ PowerPoint 2002 ในรุ่น PowerPoint ก่อนหน้านี้ การเพิ่มเอฟเฟ็กต์การเคลื่อนที่ลงในงานนำเสนอเป็นเรื่องท้าทายและทำได้เฉพาะด้วยวิธีแก้ปัญหาต่าง ๆ ไทม์ไลน์มาทดแทนคลาส AnimationSettings เก่าและให้โมเดลวัตถุที่ชัดเจนยิ่งขึ้นสำหรับการเคลื่อนที่ของ PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์การเคลื่อนที่ได้เพียงหนึ่งชุด

## **การเคลื่อนไหวแบบโต้ตอบ**

[**EffectTriggerType**](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) อนุญาตให้กำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะทำให้การเคลื่อนที่บางอย่างเริ่มทำงาน ตัวกระตุ้นถูกเพิ่มในรุ่น PowerPoint ล่าสุดเท่านั้น.

## **การเคลื่อนไหวของรูปร่าง**

Aspose.Slides อนุญาตให้ใช้การเคลื่อนที่กับรูปร่างที่อาจเป็นข้อความ, สี่เหลี่ยม, เส้น, กรอบ, วัตถุ OLE ฯลฯ.

{{% alert color="primary" %}} 
อ่านเพิ่มเติม [**เกี่ยวกับการเคลื่อนไหวของรูปร่าง**](/slides/th/cpp/shape-animation/).
{{% /alert %}}

## **แผนภูมิที่เคลื่อนไหว**

เพื่อสร้างแผนภูมิที่เคลื่อนไหว คุณควรใช้คลาสเดียวกันกับที่ใช้กับรูปร่าง อย่างไรก็ตาม สามารถใช้การเคลื่อนที่ของ PowerPoint ได้เฉพาะกับหมวดหมู่แผนภูมิหรือซีรีส์ของแผนภูมิ คุณยังสามารถใช้เอฟเฟกต์การเคลื่อนที่กับองค์ประกอบหมวดหมู่หรือองค์ประกอบซีรีส์ได้.

{{% alert color="primary" %}} 
อ่านเพิ่มเติม [**เกี่ยวกับแผนภูมิที่เคลื่อนไหว**](/slides/th/cpp/animated-charts/).
{{% /alert %}}

## **ข้อความที่เคลื่อนไหว**

นอกจากข้อความที่เคลื่อนไหวแล้ว ยังสามารถใช้การเคลื่อนที่กับย่อหน้าด้วย.

{{% alert color="primary" %}} 
อ่านเพิ่มเติม [**เกี่ยวกับข้อความที่เคลื่อนไหว**](/slides/th/cpp/animated-text/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การเคลื่อนที่จะยังคงอยู่เมื่อส่งออกเป็น PDF หรือไม่?**

ไม่. PDF เป็นรูปแบบคงที่ ดังนั้นการเคลียนและ [การเปลี่ยนสไลด์](/slides/th/cpp/slide-transition/) จะไม่ทำงาน หากคุณต้องการเคลื่อนที่ ให้ส่งออกเป็น [HTML5](/slides/th/cpp/export-to-html5/), [GIF ที่เคลื่อนไหว](/slides/th/cpp/convert-powerpoint-to-animated-gif/) หรือ [วิดีโอ](/slides/th/cpp/convert-powerpoint-to-video/) แทน.

**ฉันสามารถแปลงงานนำเสนอที่เคลื่อนไหวเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ได้. คุณสามารถ [เรนเดอร์งานนำเสนอเป็นเฟรม](/slides/th/cpp/convert-powerpoint-to-video/) และเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด การเคลื่อนที่และการเปลี่ยนสไลด์จะถูกเล่นระหว่างการเรนเดอร์.

**การเคลื่อนที่จะคงอยู่เมื่อทำงานกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?**

PPT, PPTX, และ ODP รองรับสำหรับ [การอ่าน](/slides/th/cpp/open-presentation/) และ [การเขียน](/slides/th/cpp/save-presentation/), แต่ความแตกต่างของรูปแบบอาจทำให้เอฟเฟ็กต์บางอย่างดูหรือทำงานแตกต่างกันเล็กน้อย ให้ตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง.