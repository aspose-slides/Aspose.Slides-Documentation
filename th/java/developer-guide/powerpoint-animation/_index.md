---
title: ปรับปรุงการนำเสนอ PowerPoint ด้วยภาพเคลื่อนไหวใน Java
linktitle: ภาพเคลื่อนไหว PowerPoint
type: docs
weight: 150
url: /th/java/powerpoint-animation/
keywords:
- เพิ่มภาพเคลื่อนไหว
- อัปเดตภาพเคลื่อนไหว
- เปลี่ยนภาพเคลื่อนไหว
- ลบภาพเคลื่อนไหว
- จัดการภาพเคลื่อนไหว
- ควบคุมภาพเคลื่อนไหว
- เอฟเฟกต์ภาพเคลื่อนไหว
- ภาพเคลื่อนไหว PowerPoint
- ไทม์ไลน์ภาพเคลื่อนไหว
- ภาพเคลื่อนไหวเชิงโต้ตอบ
- ภาพเคลื่อนไหวแบบกำหนดเอง
- ภาพเคลื่อนไหวของรูปทรง
- แผนภูมิที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- รูปทรงที่เคลื่อนไหว
- วัตถุ OLE ที่เคลื่อนไหว
- ภาพที่เคลื่อนไหว
- ตารางที่เคลื่อนไหว
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ Java ในการจัดการภาพเคลื่อนไหว PowerPoint บทสรุปทั่วไปนี้เน้นคุณลักษณะสำคัญและให้ข้อมูลเชิงลึกเพื่อปรับปรุงการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากการนำเสนอถูกออกแบบให้แสดงบางอย่าง รูปลักษณ์และพฤติกรรมเชิงโต้ตอบของมันจึงต้องคำนึงถึงตลอดกระบวนการสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอน่าสนใจและดึงดูดผู้ชม Aspose.Slides มีตัวเลือกหลากหลายเพื่อเพิ่มภาพเคลื่อนไหวให้กับงานนำเสนอ PowerPoint:

- ใช้เอฟเฟกต์ภาพเคลื่อนไหว PowerPoint ประเภทต่าง ๆ กับรูปทรง, แผนภูมิ, ตาราง, วัตถุ OLE, และองค์ประกอบอื่น ๆ ของการนำเสนอ
- ใช้เอฟเฟกต์ภาพเคลื่อนไหวหลายแบบบนรูปทรงเดียว
- ใช้ไทม์ไลน์ของภาพเคลื่อนไหวเพื่อควบคุมเอฟเฟกต์
- สร้างภาพเคลื่อนไหวแบบกำหนดเอง

ใน Aspose.Slides สามารถนำเอฟเฟกต์ภาพเคลื่อนไหวไปใช้กับรูปทรงได้หลายแบบ เนื่องจากทุกองค์ประกอบบนสไลด์ ไม่ว่าจะเป็นข้อความ, รูปภาพ, วัตถุ OLE หรือ ตาราง ต่างก็ถือเป็นรูปทรง ดังนั้นจึงสามารถใส่เอฟเฟกต์ภาพเคลื่อนไหวให้กับองค์ประกอบใดก็ได้บนสไลด์

## **เอฟเฟกต์ภาพเคลื่อนไหว**
Aspose.Slides รองรับ **เอฟเฟกต์ภาพเคลื่อนไหวกว่า 150 รายการ** รวมถึงเอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball, Zoom และเอฟเฟกต์เฉพาะเช่น OLEObjectShow, OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟกต์ได้ที่ [**EffectType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttype/)​enumeration

นอกจากนี้ยังสามารถใช้เอฟเฟกต์เหล่านี้ร่วมกันได้:

- [ColorEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/SetEffect)

## **ภาพเคลื่อนไหวแบบกำหนดเอง**
คุณสามารถสร้าง **ภาพเคลื่อนไหวแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้  
วิธีการคือการรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นภาพเคลื่อนไหวใหม่

[**Behavior**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Behavior) เป็นหน่วยสร้างของเอฟเฟกต์ภาพเคลื่อนไหว PowerPoint ทุกเอฟเฟกต์จริง ๆ แล้วคือชุดของพฤติกรรมที่ประกอบเป็นกลยุทธ์เดียว คุณสามารถรวมพฤติกรรมเป็นภาพเคลื่อนไหวแบบกำหนดเองหนึ่งครั้งและนำไปใช้ซ้ำในงานนำเสนออื่น ๆ หากคุณเพิ่มพฤติกรรมใหม่เข้าไปในเอฟเฟกต์ภาพเคลื่อนไหวมาตรฐานของ PowerPoint จะกลายเป็นภาพเคลื่อนไหวแบบกำหนดเองอีกชุดหนึ่ง ตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรม “repeat” ให้กับภาพเคลื่อนไหวเพื่อให้มันทำซ้ำหลายรอบ

[**Animation Point**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Point) คือจุดที่พฤติกรรมควรจะถูกนำไปใช้

## **ไทม์ไลน์ของภาพเคลื่อนไหว**
[**Sequence**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Sequence) เป็นคอลเลกชันของเอฟเฟกต์ภาพเคลื่อนไหวที่นำไปใช้กับรูปทรงที่ระบุ

[**Timeline**](https://reference.aspose.com/slides/th/java/com.aspose.slides/AnimationTimeLine) เป็นชุดของ Sequence ที่ใช้ในสไลด์หนึ่ง ๆ มันเป็นเอนจิ้นภาพเคลื่อนไหวตั้งแต่ PowerPoint 2002 ในเวอร์ชัน PowerPoint ก่อนหน้า การเพิ่มเอฟเฟกต์ภาพเคลื่อนไหวลงในงานนำเสนอเป็นเรื่องยากและต้องอาศัยวิธีแก้ปัญหาต่าง ๆ ไทม์ไลน์เข้ามาแทนที่คลาส AnimationSettings เก่าและให้โมเดลวัตถุที่ชัดเจนยิ่งขึ้นสำหรับภาพเคลื่อนไหว PowerPoint สไลด์หนึ่งสามารถมี ไทม์ไลน์ภาพเคลื่อนไหวได้ เพียงหนึ่งชุดเท่านั้น

## **ภาพเคลื่อนไหวเชิงโต้ตอบ**
[**Trigger**](https://reference.aspose.com/slides/th/java/com.aspose.slides/EffectTriggerType) ให้คุณกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะทำให้ภาพเคลื่อนไหวบางอย่างเริ่มทำงาน Trigger ถูกเพิ่มเข้ามาในรุ่น PowerPoint ล่าสุดเท่านั้น

## **ภาพเคลื่อนไหวของรูปทรง**
Aspose.Slides รองรับการใส่ภาพเคลื่อนไหวให้กับรูปทรง ซึ่งอาจเป็นข้อความ, สี่เหลี่ยม, เส้น, เฟรม, วัตถุ OLE ฯลฯ

{{% alert color="primary" %}} 
อ่านต่อ [**เกี่ยวกับการเคลื่อนไหวของรูปทรง**](/slides/th/java/shape-animation/).
{{% /alert %}}

## **แผนภูมิที่เคลื่อนไหว**
หากต้องการสร้างแผนภูมิที่เคลื่อนไหว คุณควรใช้คลาสเดียวกันกับรูปทรง อย่างไรก็ตาม PowerPoint animation สามารถใช้ได้เฉพาะบนหมวดหมู่ของแผนภูมิหรือซีรีส์ของแผนภูมิ คุณยังสามารถใส่เอฟเฟกต์ภาพเคลื่อนไหวให้กับองค์ประกอบหมวดหมู่หรือซีรีส์ได้เช่นกัน

{{% alert color="primary" %}} 
อ่านต่อ [**เกี่ยวกับแผนภูมิที่เคลื่อนไหว**](/slides/th/java/animated-charts/).
{{% /alert %}}

## **ข้อความที่เคลื่อนไหว**
นอกจากข้อความที่เคลื่อนไหวแล้ว คุณยังสามารถใส่ภาพเคลื่อนไหวให้กับย่อหน้าหนึ่งได้อีกด้วย

{{% alert color="primary" %}} 
อ่านต่อ [**เกี่ยวกับข้อความที่เคลื่อนไหว**](/slides/th/java/animated-text/).
{{% /alert %}}

## **FAQ**

**ภาพเคลื่อนไหวจะถูกเก็บไว้เมื่อนำออกเป็น PDF หรือไม่?**

ไม่ PDF เป็นรูปแบบคงที่ ดังนั้นภาพเคลื่อนไหวและ [slide transitions](/slides/th/java/slide-transition/) จะไม่ทำงาน หากต้องการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/java/export-to-html5/), [animated GIF](/slides/th/java/convert-powerpoint-to-animated-gif/) หรือ [video](/slides/th/java/convert-powerpoint-to-video/) แทน

**ฉันสามารถแปลงงานนำเสนอที่เคลื่อนไหวเป็นวิดีโอและกำหนดอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ได้ คุณสามารถ [render the presentation as frames](/slides/th/java/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยกำหนด FPS และความละเอียด ภาพเคลื่อนไหวและการเปลี่ยนสไลด์จะถูกเล่นระหว่างการเรนเดอร์

**ภาพเคลื่อนไหวจะคงอยู่เมื่อติดต่อกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?**

PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/java/open-presentation/) และ [writing](/slides/th/java/save-presentation/) แต่ความแตกต่างของฟอร์แมตอาจทำให้บางเอฟเฟกต์แสดงผลหรือทำงานต่างกันเล็กน้อย ควรตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง