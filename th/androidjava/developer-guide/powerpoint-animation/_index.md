---
title: เพิ่มการนำเสนอ PowerPoint ด้วยแอนิเมชันบน Android
linktitle: แอนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/androidjava/powerpoint-animation/
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
- แผนภูมิแอนิเมชัน
- ข้อความแอนิเมชัน
- รูปทรงแอนิเมชัน
- วัตถุ OLE แอนิเมชัน
- ภาพแอนิเมชัน
- ตารางแอนิเมชัน
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ Android ผ่าน Java ในการจัดการแอนิเมชัน PowerPoint บทสรุปทั่วไปนี้เน้นคุณลักษณะสำคัญ"
---
## **บทนำ**

เนื่องจากการนำเสนอมีวัตถุประสงค์เพื่อแสดงบางอย่าง ลักษณะภาพและพฤติกรรมเชิงโต้ตอบจึงได้รับการพิจารณาเสมอในขณะสร้าง

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอน่าสนใจและดึงดูดผู้ชม Aspose.Slides for Android via Java มีตัวเลือกมากมายสำหรับการเพิ่มแอนิเมชันในงานนำเสนอ PowerPoint:

- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint ประเภทต่าง ๆ กับรูปร่าง, แผนภูมิ, ตาราง, OLE Objects และองค์ประกอบการนำเสนออื่น ๆ.
- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint หลายแบบบนรูปร่างหนึ่งรูป.
- ใช้ไทม์ไลน์ของแอนิเมชันเพื่อควบคุมเอฟเฟกต์แอนิเมชัน.
- สร้างแอนิเมชันแบบกำหนดเอง.

ใน Aspose.Slides for Android via Java สามารถใช้เอฟเฟกต์แอนิเมชันหลายแบบกับรูปร่างได้ เนื่องจากทุกองค์ประกอบบนสไลด์รวมถึงข้อความ, รูปภาพ, OLE Object, ตาราง เป็นต้น ถูกพิจารณาเป็นรูปร่าง ดังนั้นเราจึงสามารถใช้เอฟเฟกต์แอนิเมชันกับทุกองค์ประกอบของสไลด์ได้

## **เอฟเฟกต์แอนิเมชัน**
Aspose.Slides รองรับ **150+ เอฟเฟกต์แอนิเมชัน**, รวมถึงเอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball, เอฟเฟกต์ Zoom และเอฟเฟกต์เฉพาะเช่น OLEObjectShow, OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟกต์แอนิเมชันได้ใน [**EffectType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttype/)enumeration.

นอกจากนี้ เอฟเฟกต์แอนิเมชันเหล่านี้สามารถนำมาใช้ร่วมกันได้ด้วย:
- [ColorEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SetEffect)

## **แอนิเมชันแบบกำหนดเอง**
คุณสามารถสร้าง **แอนิเมชันแบบกำหนดเอง** ของคุณใน Aspose.Slides ได้  
วิธีนี้ทำได้โดยการรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นแอนิเมชันแบบกำหนดใหม่

[**Behavior**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Behavior) เป็นหน่วยสร้างของเอฟเฟกต์แอนิเมชัน PowerPoint ใด ๆ ทุกเอฟเฟกต์แอนิเมชันจริง ๆ แล้วเป็นชุดของพฤติกรรมที่รวมเป็นกลยุทธ์หนึ่ง คุณสามารถรวมพฤติกรรมเข้ากับแอนิเมชันแบบกำหนดเองครั้งเดียวและใช้ซ้ำในงานนำเสนออื่น หากคุณเพิ่มพฤติกรรมใหม่ลงในเอฟเฟกต์แอนิเมชัน PowerPoint มาตรฐาน จะกลายเป็นแอนิเมชันแบบกำหนดใหม่ ตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรม repeat ให้กับแอนิเมชันเพื่อให้ทำซ้ำหลายครั้ง

[**Animation Point**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Point) คือจุดที่ควรใช้พฤติกรรม

## **ไทม์ไลน์แอนิเมชัน**
[**Sequence**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Sequence) คือคอลเลกชันของเอฟเฟกต์แอนิเมชันที่ใช้กับรูปร่างเฉพาะ

[**Timeline**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AnimationTimeLine) คือชุดของ Sequence ที่ใช้ในสไลด์เฉพาะ เป็นเอนจินแอนิเมชันที่มีตั้งแต่ PowerPoint 2002 ในเวอร์ชัน PowerPoint ก่อนหน้า การเพิ่มเอฟเฟกต์แอนิเมชันเข้าสู่การนำเสนอเป็นเรื่องท้าทายและทำได้เพียงวิธีแก้ปัญหาต่าง ๆ Timeline มาแทนที่คลาส AnimationSettings เก่าและให้โมเดลวัตถุที่ชัดเจนมากขึ้นสำหรับแอนิเมชัน PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์แอนิเมชันได้เพียงหนึ่งชุด

## **แอนิเมชันเชิงโต้ตอบ**
[**Trigger**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/EffectTriggerType) ช่วยกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่ทำให้แอนิเมชันบางอย่างเริ่มทำงาน Triggers ถูกเพิ่มเข้ามาในเวอร์ชัน PowerPoint ล่าสุดเท่านั้น

## **แอนิเมชันรูปร่าง**
Aspose.Slides อนุญาตให้ใช้แอนิเมชันกับรูปร่าง ซึ่งอาจเป็นข้อความ, สี่เหลี่ยม, เส้น, กรอบ, OLE Object เป็นต้น

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับแอนิเมชันรูปร่าง**](/slides/th/androidjava/shape-animation/).
{{% /alert %}}

## **แผนภูมิแอนิเมชัน**
เพื่อสร้างแผนภูมิที่มีแอนิเมชัน คุณควรใช้คลาสเดียวกับที่ใช้กับรูปร่างทั้งหมด อย่างไรก็ตาม สามารถใช้แอนิเมชัน PowerPoint ได้เฉพาะบนหมวดหมู่ของแผนภูมิหรือซีรีส์ของแผนภูมิ คุณยังสามารถใช้เอฟเฟกต์แอนิเมชันกับองค์ประกอบหมวดหมู่หรือซีรีส์ได้เช่นกัน

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับแผนภูมิแอนิเมชัน**](/slides/th/androidjava/animated-charts/).
{{% /alert %}}

## **ข้อความแอนิเมชัน**
นอกจากข้อความแอนิเมชันแล้ว ยังสามารถใช้แอนิเมชันกับย่อหน้าได้เช่นกัน

{{% alert color="info" %}} 
อ่านต่อ [**เกี่ยวกับข้อความแอนิเมชัน**](/slides/th/androidjava/animated-text/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

### การแอนิเมชันจะยังคงอยู่เมื่อนำออกเป็น PDF หรือไม่?
ไม่. PDF เป็นรูปแบบแบบคงที่ ดังนั้นแอนิเมชันและ [slide transitions](/slides/th/androidjava/slide-transition/) จะไม่ทำงาน หากต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/androidjava/export-to-html5/), [animated GIF](/slides/th/androidjava/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/androidjava/convert-powerpoint-to-video/) แทน

### ฉันสามารถแปลงการนำเสนอที่มีแอนิเมชันเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?
ได้. คุณสามารถ [render the presentation as frames](/slides/th/androidjava/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด แอนิเมชันและ slide transitions จะทำงานระหว่างการเรนเดอร์

### แอนิเมชันจะคงอยู่เมื่อติดต่อกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?
รองรับ PPT, PPTX และ ODP สำหรับ [reading](/slides/th/androidjava/open-presentation/) และ [writing](/slides/th/androidjava/save-presentation/) แต่ความแตกต่างของรูปแบบอาจทำให้เอฟเฟกต์บางอย่างแสดงหรือทำงานแตกต่างกันเล็กน้อย ตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง