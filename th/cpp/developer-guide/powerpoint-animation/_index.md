---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยการเคลื่อนไหวใน C++
linktitle: การเคลื่อนไหว PowerPoint
type: docs
weight: 150
url: /th/cpp/powerpoint-animation/
keywords:
- เพิ่มการเคลื่อนไหว
- อัปเดตการเคลื่อนไหว
- เปลี่ยนการเคลื่อนไหว
- ลบการเคลื่อนไหว
- จัดการการเคลื่อนไหว
- ควบคุมการเคลื่อนไหว
- เอฟเฟ็กต์การเคลื่อนไหว
- การเคลื่อนไหว PowerPoint
- ไทม์ไลน์การเคลื่อนไหว
- การเคลื่อนไหวเชิงโต้ตอบ
- การเคลื่อนไหวแบบกำหนดเอง
- การเคลื่อนไหวของรูปร่าง
- แผนภูมิเคลื่อนที่
- ข้อความเคลื่อนไหว
- รูปร่างเคลื่อนไหว
- วัตถุ OLE เคลื่อนไหว
- ภาพเคลื่อนไหว
- ตารางเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและควบคุมเอฟเฟ็กต์การเคลื่อนไหวขั้นสูงใน Aspose.Slides สำหรับ C++ เพื่อสร้างการนำเสนอ PowerPoint และ OpenDocument แบบไดนามิก"
---
## **บทนำ**

เนื่องจากการนำเสนอถูกออกแบบมาเพื่อแสดงบางอย่าง รูปลักษณ์ที่มองเห็นและพฤติกรรมเชิงโต้ตอบจึงได้รับการพิจารณาตลอดกระบวนการสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอดึงดูดและน่าสนใจสำหรับผู้ชม Aspose.Slides มีตัวเลือกมากมายสำหรับการเพิ่มการเคลื่อนไหวในงานนำเสนอ PowerPoint:

- ใช้เอฟเฟ็กต์การเคลื่อนไหว PowerPoint หลายประเภทกับรูปร่าง แผนภูมิ ตาราง วัตถุ OLE และองค์ประกอบอื่นๆ ของการนำเสนอ
- ใช้เอฟเฟ็กต์การเคลื่อนไหว PowerPoint หลายรายการบนรูปร่างเดียว
- ใช้ไทม์ไลน์การเคลื่อนไหวเพื่อควบคุมเอฟเฟ็กต์การเคลื่อนไหว
- สร้างการเคลื่อนไหวแบบกำหนดเอง

ใน Aspose.Slides สามารถใช้เอฟเฟ็กต์การเคลื่อนไหวต่างๆ กับรูปร่างได้ เนื่องจากทุกองค์ประกอบบนสไลด์ รวมถึงข้อความ รูปภาพ วัตถุ OLE และตาราง ถือเป็นรูปร่าง จึงสามารถใช้เอฟเฟ็กต์การเคลื่อนไหวกับองค์ประกอบใดก็ได้บนสไลด์

เนมสเปซ [Aspose::Slides::Animation](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/) ให้คลาสสำหรับทำงานกับการเคลื่อนไหวใน PowerPoint

## **เอฟเฟ็กต์การเคลื่อนไหว**
Aspose.Slides รองรับ **เอฟเฟ็กต์การเคลื่อนไหวกว่า 150 รายการ** รวมถึงเอฟเฟ็กต์พื้นฐานเช่น Bounce, PathFootball, และ Zoom รวมถึงเอฟเฟ็กต์เฉพาะเช่น OLEObjectShow และ OLEObjectOpen คุณสามารถดูรายการเต็มได้ใน enumeration [EffectType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effecttype/)

นอกจากนี้ เอฟเฟ็กต์การเคลื่อนไหวเหล่านี้สามารถใช้ร่วมกับพฤติกรรมต่อไปนี้:
- [ColorEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/seteffect/)

## **การเคลื่อนไหวแบบกำหนดเอง**

สำหรับตัวอย่าง C++ ฉบับเต็มที่สร้าง ตรวจสอบ และแก้ไขพฤติกรรมและเส้นทางการเคลื่อนไหวที่แก้ไขได้ ดูที่ [Custom Animation](/slides/th/cpp/custom-animation/).

คุณสามารถสร้าง **การเคลื่อนไหวแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้ โดยการรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นการเคลื่อนไหวแบบกำหนดเองใหม่

[Behavior](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/behavior/) เป็นบล็อกพื้นฐานของเอฟเฟ็กต์การเคลื่อนไหว PowerPoint รวมพฤติกรรมเพื่อปรับแต่งเอฟเฟ็กต์ หรือเพิ่มพฤติกรรมเพื่อขยายเอฟเฟ็กต์ที่กำหนดไว้ การทำซ้ำถูกกำหนดผ่านการตั้งค่าเวลาแทนการใช้พฤติกรรมทำซ้ำแยกต่างหาก

[Animation Point](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/point/) คือจุดที่ควรใช้พฤติกรรม

## **ไทม์ไลน์การเคลื่อนไหว**
[Sequence](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/sequence/) คือคอลเลกชันของเอฟเฟ็กต์การเคลื่อนไหวที่สามารถกำหนดเป้าหมายไปยังรูปร่างต่างๆ

[IAnimationTimeLine](https://reference.aspose.com/slides/th/cpp/aspose.slides/ianimationtimeline/) คือชุดของ Sequence ที่ใช้ในสไลด์เฉพาะ มันเป็นเอนจินการเคลื่อนไหวที่เปิดตัวใน PowerPoint 2002 ในเวอร์ชันก่อนหน้าของ PowerPoint การเพิ่มเอฟเฟ็กต์การเคลื่อนไหวในงานนำเสนอเป็นเรื่องที่ท้าทายและทำได้เฉพาะด้วยวิธีแก้ปัญหาต่างๆ ไทม์ไลน์ให้โมเดลวัตถุที่ชัดเจนยิ่งขึ้นสำหรับการเคลื่อนไหวใน PowerPoint สไลด์สามารถมีไทม์ไลน์การเคลื่อนไหวได้เพียงหนึ่งรายการ

## **การเคลื่อนไหวเชิงโต้ตอบ**
[Trigger](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effecttriggertype/) ช่วยให้คุณกำหนดการกระทำของผู้ใช้ เช่น การคลิกปุ่ม เพื่อเริ่มการเคลื่อนไหวเฉพาะ

## **การเคลื่อนไหวของรูปร่าง**
Aspose.Slides ให้คุณเพิ่มการเคลื่อนไหวให้กับรูปร่าง ซึ่งอาจประกอบด้วยข้อความ, สี่เหลี่ยม, เส้น, กรอบ, วัตถุ OLE และอื่นๆ

{{% alert color="info" title="Note" %}}
Read more [**เกี่ยวกับการเคลื่อนไหวของรูปร่าง**](/slides/th/cpp/shape-animation/).
{{% /alert %}}

## **แผนภูมิเคลื่อนไหว**
เพื่อสร้างแผนภูมิเคลื่อนไหว คุณควรใช้คลาสเดียวกับที่ใช้กับรูปร่าง อย่างไรก็ตาม การเคลื่อนไหวใน PowerPoint สามารถใช้ได้กับหมวดหมู่ของแผนภูมิหรือซีรีส์ของแผนภูมิเท่านั้น คุณยังสามารถใช้เอฟเฟ็กต์การเคลื่อนไหวกับองค์ประกอบของหมวดหมู่หรือซีรีส์ได้

{{% alert color="info" title="Note" %}}
Read more [**เกี่ยวกับแผนภูมิเคลื่อนไหว**](/slides/th/cpp/animated-charts/).
{{% /alert %}}

## **ข้อความเคลื่อนไหว**
นอกเหนือจากการเคลื่อนไหวข้อความแล้ว คุณยังสามารถเพิ่มการเคลื่อนไหวให้กับย่อหน้าได้

{{% alert color="info" title="Note" %}}
Read more [**เกี่ยวกับข้อความเคลื่อนไหว**](/slides/th/cpp/animated-text/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การเคลื่อนไหวจะยังคงอยู่เมื่อตัดออกเป็น PDF หรือไม่?**

ไม่ PDF เป็นรูปแบบคงที่ ดังนั้นการเคลื่อนไหวและ [slide transitions](/slides/th/cpp/slide-transition/) จะไม่ทำงาน หากต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/cpp/export-to-html5/), [animated GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/cpp/convert-powerpoint-to-video/) แทน

**ฉันสามารถแปลงการนำเสนอที่มีการเคลื่อนไหวเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ได้ คุณสามารถ [render the presentation as frames](/slides/th/cpp/convert-powerpoint-to-video/) และเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด การเคลื่อนไหวและ slide transitions จะถูกเล่นระหว่างการเรนเดอร์

**การเคลื่อนไหวจะคงอยู่เมื่อติดต่อกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?**

PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/cpp/open-presentation/) และ [writing](/slides/th/cpp/save-presentation/) แต่ไม่ได้รับประกันว่าการเคลื่อนไหวจะคงอยู่ ข้อมูลการเคลื่อนไหวแบบกำหนดเองอาจหายไปเมื่อแปลงเป็น ODP ดูที่ [Custom Animation](/slides/th/cpp/custom-animation/) เพื่อดูตัวอย่างและคำแนะนำในการตรวจสอบความเข้ากันของรูปแบบ