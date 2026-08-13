---
title: ปรับปรุงการนำเสนอ PowerPoint ด้วยการเคลื่อนไหวใน Java
linktitle: การเคลื่อนไหว PowerPoint
type: docs
weight: 150
url: /th/java/powerpoint-animation/
keywords:
- เพิ่มการเคลื่อนไหว
- อัปเดตการเคลื่อนไหว
- เปลี่ยนการเคลื่อนไหว
- ลบการเคลื่อนไหว
- จัดการการเคลื่อนไหว
- ควบคุมการเคลื่อนไหว
- เอฟเฟกต์การเคลื่อนไหว
- การเคลื่อนไหว PowerPoint
- ไทม์ไลน์การเคลื่อนไหว
- การเคลื่อนไหวเชิงโต้ตอบ
- การเคลื่อนไหวแบบกำหนดเอง
- การเคลื่อนไหวของรูปร่าง
- แผนภูมิที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- รูปร่างที่เคลื่อนไหว
- วัตถุ OLE ที่เคลื่อนไหว
- รูปภาพที่เคลื่อนไหว
- ตารางที่เคลื่อนไหว
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ Java ในการจัดการการเคลื่อนไหว PowerPoint ภาพรวมทั่วไปนี้เน้นคุณลักษณะหลักและให้ข้อมูลเชิงลึกเพื่อปรับปรุงการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากการนำเสนอถูกออกแบบมาเพื่อแสดงบางอย่าง ลักษณะการมองเห็นและพฤติกรรมเชิงโต้ตอบของมันจึงถูกพิจารณาตลอดกระบวนการสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอน่าสนใจและดึงดูดผู้ชม Aspose.Slides มีตัวเลือกหลากหลายเพื่อเพิ่มการเคลื่อนไหวให้กับการนำเสนอ PowerPoint:

- ใช้เอฟเฟกต์การเคลื่อนไหว PowerPoint ประเภทต่าง ๆ กับรูปร่าง, แผนภูมิ, ตาราง, วัตถุ OLE และองค์ประกอบการนำเสนออื่น ๆ
- ใช้เอฟเฟกต์การเคลื่อนไหว PowerPoint หลายแบบบนรูปร่างเดียว
- ใช้ไทม์ไลน์การเคลื่อนไหวเพื่อควบคุมเอฟเฟกต์การเคลื่อนไหว
- สร้างการเคลื่อนไหวแบบกำหนดเอง

ใน Aspose.Slides สามารถนำเอฟเฟกต์การเคลื่อนไหวต่าง ๆ ไปใช้กับรูปร่างได้ เนื่องจากทุกองค์ประกอบบนสไลด์ รวมถึงข้อความ, รูปภาพ, วัตถุ OLE และตาราง ถูกพิจารณาเป็นรูปร่าง ดังนั้นเอฟเฟกต์การเคลื่อนไหวสามารถใช้กับองค์ประกอบใดก็ได้บนสไลด์

## **เอฟเฟกต์การเคลื่อนไหว**
Aspose.Slides รองรับ **150+ animation effects** ได้แก่เอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball, Zoom และเอฟเฟกต์เฉพาะเช่น OLEObjectShow, OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟกต์การเคลื่อนไหวได้ใน [**EffectType**](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttype/)enumeration

นอกจากนี้ เอฟเฟกต์การเคลื่อนไหวเหล่านี้สามารถใช้ร่วมกันได้กับ:
- [ColorEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/SetEffect)

## **การเคลื่อนไหวแบบกำหนดเอง**
เป็นไปได้ที่จะสร้าง **custom animations** ของคุณใน Aspose.Slides  
สิ่งนี้ทำได้โดยการผสานพฤติกรรมหลายอย่างเข้าด้วยกันเป็นการเคลื่อนไหวแบบกำหนดเองใหม่  

[**Behavior**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Behavior) คือหน่วยสร้างของเอฟเฟกต์การเคลื่อนไหว PowerPoint ทุกเอฟเฟกต์การเคลื่อนไหวจริง ๆ แล้วเป็นชุดของพฤติกรรมที่ประกอบเป็นกลยุทธ์หนึ่ง คุณสามารถผสานพฤติกรรมเป็นการเคลื่อนไหวแบบกำหนดเอง หนึ่งครั้ง และใช้ซ้ำในงานนำเสนออื่น ๆ หากคุณเพิ่มพฤติกรรมใหม่ลงในเอฟเฟกต์การเคลื่อนไหว PowerPoint มาตรฐาน – จะกลายเป็นการเคลื่อนไหวแบบกำหนดเองอีกชุด ตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรม repeat ให้กับการเคลื่อนไหวเพื่อให้มันทำซ้ำหลายครั้ง  

[**Animation Point**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Point) คือจุดที่พฤติกรรมควรจะถูกนำไปใช้

## **ไทม์ไลน์การเคลื่อนไหว**
[**Sequence**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Sequence) คือคอลเลกชันของเอฟเฟกต์การเคลื่อนไหวที่นำไปใช้กับรูปร่างเฉพาะ  

[**Timeline**](https://reference.aspose.com/slides/th/java/com.aspose.slides/AnimationTimeLine) คือชุดของ Sequence ที่ใช้ในสไลด์เฉพาะ มันเป็นเครื่องยนต์การเคลื่อนไหวที่มีตั้งแต่ PowerPoint 2002 ในเวอร์ชัน PowerPoint ก่อนหน้า การเพิ่มเอฟเฟกต์การเคลื่อนไหวลงในงานนำเสนอเป็นเรื่องยากและต้องใช้วิธีแก้ปัญหาต่าง ๆ ไทม์ไลน์มาทดแทนคลาส AnimationSettings ที่เก่าและให้โมเดลวัตถุที่ชัดเจนขึ้นสำหรับการเคลื่อนไหว PowerPoint สไลด์หนึ่งสามารถมี เพียงหนึ่ง animation timeline เท่านั้น

## **การเคลื่อนไหวเชิงโต้ตอบ**
[**Trigger**](https://reference.aspose.com/slides/th/java/com.aspose.slides/EffectTriggerType) ช่วยกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะทำให้การเคลื่อนไหวบางอย่างเริ่มต้น Trigger ถูกเพิ่มในรุ่น PowerPoint ล่าสุดเท่านั้น

## **การเคลื่อนไหวของรูปร่าง**
Aspose.Slides อนุญาตให้ใช้การเคลื่อนไหวกับรูปร่าง ซึ่งอาจเป็นข้อความ, สี่เหลี่ยม, เส้น, เฟรม, วัตถุ OLE ฯลฯ  

{{% alert color="info" %}} 
อ่านเพิ่มเติม [**เกี่ยวกับการเคลื่อนไหวของรูปร่าง**](/slides/th/java/shape-animation/)
{{% /alert %}}

## **แผนภูมิที่เคลื่อนไหว**
เพื่อสร้างแผนภูมิที่เคลื่อนไหว คุณควรใช้คลาสเดียวกันกับที่ใช้กับรูปร่าง อย่างไรก็ตาม สามารถใช้การเคลื่อนไหว PowerPoint ได้เฉพาะบนหมวดหมู่ของแผนภูมิหรือซีรีส์ของแผนภูมิ คุณยังสามารถนำเอฟเฟกต์การเคลื่อนไหวไปใช้กับองค์ประกอบหมวดหมู่หรือองค์ประกอบซีรีส์ได้  

{{% alert color="info" %}} 
อ่านเพิ่มเติม [**เกี่ยวกับแผนภูมิที่เคลื่อนไหว**](/slides/th/java/animated-charts/)
{{% /alert %}}

## **ข้อความที่เคลื่อนไหว**
นอกจากข้อความที่เคลื่อนไหวแล้ว ยังสามารถใช้การเคลื่อนไหวกับย่อหน้าด้วย  

{{% alert color="info" %}} 
อ่านเพิ่มเติม [**เกี่ยวกับข้อความที่เคลื่อนไหว**](/slides/th/java/animated-text/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

### การเคลื่อนไหวจะถูกเก็บไว้เมื่อนำออกเป็น PDF หรือไม่?
ไม่ PDF เป็นรูปแบบคงที่ ดังนั้นการเคลื่อนไหวและ [slide transitions](/slides/th/java/slide-transition/) จะไม่ทำงาน หากต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/java/export-to-html5/), [animated GIF](/slides/th/java/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/java/convert-powerpoint-to-video/) แทน

### ฉันสามารถแปลงการนำเสนอที่มีการเคลื่อนไหวเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?
ได้ คุณสามารถ [render the presentation as frames](/slides/th/java/convert-powerpoint-to-video/) และเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด การเคลื่อนไหวและการเปลี่ยนสไลด์จะทำงานระหว่างการเรนเดอร์

### การเคลื่อนไหวจะคงที่เมื่อตั้งค่าไฟล์ ODP (ไม่ใช่แค่ PPTX) หรือไม่?
PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/java/open-presentation/) และ [writing](/slides/th/java/save-presentation/) แต่ความแตกต่างของรูปแบบอาจทำให้เอฟเฟกต์บางอย่างดูหรือทำงานแตกต่างกันเล็กน้อย ควรตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง