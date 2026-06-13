---
title: เสริมการนำเสนอ PowerPoint ด้วยแอนิเมชันบน Android
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
- แอนิเมชันรูปทรง
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

เนื่องจากการนำเสนอมีจุดประสงค์เพื่อแสดงสิ่งใดสิ่งหนึ่ง ลักษณะภาพและพฤติกรรมเชิงโต้ตอบจึงได้รับการพิจารณาตลอดเวลาเมื่อสร้างมัน

**PowerPoint animation** มีบทบาทสำคัญในการทำให้การนำเสนอน่าสนใจและดึงดูดผู้ชม. Aspose.Slides for Android via Java มีตัวเลือกหลากหลายในการเพิ่มแอนิเมชันให้กับการนำเสนอ PowerPoint:

- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint ประเภทต่างๆ กับรูปทรง, แผนภูมิ, ตาราง, วัตถุ OLE และองค์ประกอบการนำเสนออื่นๆ
- ใช้หลายเอฟเฟกต์แอนิเมชัน PowerPoint บนรูปทรงเดียว
- ใช้ไทม์ไลน์แอนิเมชันเพื่อควบคุมเอฟเฟกต์แอนิเมชัน
- สร้างแอนิเมชันแบบกำหนดเอง

ใน Aspose.Slides for Android via Java สามารถนำเอฟเฟกต์แอนิเมชันต่าง ๆ ไปใช้กับรูปทรงได้ ทุกองค์ประกอบบนสไลด์รวมถึงข้อความ, รูปภาพ, วัตถุ OLE, ตาราง เป็นต้น ถือเป็นรูปทรง ดังนั้นเราจึงสามารถใช้เอฟเฟกต์แอนิเมชันกับทุกองค์ประกอบของสไลด์

## **เอฟเฟกต์แอนิเมชัน**
Aspose.Slides รองรับ **150+ เอฟเฟกต์แอนิเมชัน**, รวมถึงเอฟเฟกต์แอนิเมชันพื้นฐานเช่น Bounce, PathFootball, Zoom effect และเอฟเฟกต์แอนิเมชันเฉพาะเช่น OLEObjectShow, OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟกต์แอนิเมชันใน [**EffectType**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttype/) enumeration.

นอกจากนี้ เอฟเฟกต์แอนิเมชันเหล่านี้สามารถใช้ร่วมกันกับพวกมันได้:
- [ColorEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SetEffect)

## **แอนิเมชันแบบกำหนดเอง**
เป็นไปได้ที่จะสร้าง **แอนิเมชันแบบกำหนดเอง** ของคุณใน Aspose.Slides วิธีนี้ทำได้โดยการรวมพฤติกรรมหลาย ๆ อย่างเข้าด้วยกันเป็นแอนิเมชันแบบกำหนดใหม่

[**Behavior**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Behavior) เป็นหน่วยสร้างของเอฟเฟกต์แอนิเมชัน PowerPoint ทุกเอฟเฟกต์แอนิเมชันจริง ๆ แล้วคือชุดของพฤติกรรมที่ประกอบเข้าด้วยกันเป็นกลยุทธ์เดียว คุณสามารถรวมพฤติกรรมเข้ากับแอนิเมชันแบบกำหนดเองหนึ่งครั้งและนำกลับมาใช้ใหม่ในงานนำเสนออื่น หากคุณเพิ่มพฤติกรรมใหม่ลงในเอฟเฟกต์แอนิเมชัน PowerPoint มาตรฐาน จะกลายเป็นแอนิเมชันแบบกำหนดเองอีกหนึ่งตัว อย่างเช่น คุณสามารถเพิ่มพฤติกรรมทำซ้ำให้กับแอนิเมชันเพื่อให้ทำซ้ำหลายครั้ง

[**Animation Point**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Point) คือจุดที่ควรนำพฤติกรรมไปใช้

## **ไทม์ไลน์แอนิเมชัน**
[**Sequence**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Sequence) คือคอลเลกชันของเอฟเฟกต์แอนิเมชันที่นำไปใช้กับรูปทรงเฉพาะ

[**Timeline**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AnimationTimeLine) คือชุดของ Sequence ที่ใช้ในสไลด์เฉพาะ เป็นเอนจินแอนิเมชันตั้งแต่ PowerPoint 2002 ในเวอร์ชัน PowerPoint ก่อนหน้านี้ การเพิ่มเอฟเฟกต์แอนิเมชันลงในงานนำเสนอเป็นเรื่องที่ท้าทายและทำได้เพียงด้วยวิธีแก้ปัญหาต่าง ๆ Timeline มาแทนที่คลาส AnimationSettings เก่าและให้โมเดลวัตถุที่ชัดเจนยิ่งขึ้นสำหรับแอนิเมชัน PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์แอนิเมชันได้เพียงหนึ่งเดียว

## **แอนิเมชันเชิงโต้ตอบ**
[**Trigger**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/EffectTriggerType) อนุญาตให้กำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะทำให้แอนิเมชันบางอย่างเริ่มต้น Triggers เพิ่มเข้ามาในรุ่น PowerPoint ล่าสุดเท่านั้น

## **แอนิเมชันรูปทรง**
Aspose.Slides อนุญาตให้ใช้แอนิเมชันกับรูปทรงซึ่งอาจเป็นข้อความ, สี่เหลี่ยม, เส้น, กรอบ, วัตถุ OLE เป็นต้น

{{% alert color="primary" %}} 
Read more [**เกี่ยวกับแอนิเมชันรูปทรง**](/slides/th/androidjava/shape-animation/).
{{% /alert %}}

## **แผนภูมิแบบแอนิเมชัน**
เพื่อสร้างแผนภูมิแบบแอนิเมชัน คุณควรใช้คลาสเดียวกันกับรูปทรงทั้งหมด อย่างไรก็ตาม สามารถใช้แอนิเมชัน PowerPoint ได้เฉพาะบนหมวดหมู่แผนภูมิหรือซีรีส์ของแผนภูมิเท่านั้น คุณยังสามารถนำเอฟเฟกต์แอนิเมชันไปใช้กับองค์ประกอบหมวดหมู่หรือซีรีส์ได้

{{% alert color="primary" %}} 
Read more [**เกี่ยวกับแผนภูมิแบบแอนิเมชัน**](/slides/th/androidjava/animated-charts/).
{{% /alert %}}

## **ข้อความแบบแอนิเมชัน**
ยกเว้นข้อความแบบแอนิเมชันแล้ว ยังสามารถนำแอนิเมชันไปใช้กับย่อหน้าด้วย

{{% alert color="primary" %}} 
Read more [**เกี่ยวกับข้อความแบบแอนิเมชัน**](/slides/th/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**การแอนิเมชันจะคงไว้เมื่อส่งออกเป็น PDF หรือไม่?**

ไม่ PDF เป็นรูปแบบแบบคงที่ ดังนั้นแอนิเมชันและ [slide transitions](/slides/th/androidjava/slide-transition/) จะไม่เล่น หากต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/androidjava/export-to-html5/), [animated GIF](/slides/th/androidjava/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/androidjava/convert-powerpoint-to-video/) แทน

**ฉันสามารถแปลงการนำเสนอแบบแอนิเมชันเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ใช่ คุณสามารถ [render the presentation as frames](/slides/th/androidjava/convert-powerpoint-to-video/) และเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด แอนิเมชันและ slide transitions จะเล่นระหว่างการเรนเดอร์

**แอนิเมชันจะคงสภาพเดิมเมื่อติดตั้งกับ ODP (ไม่ใช่เพียง PPTX) หรือไม่?**

PPT, PPTX, และ ODP รองรับการ [reading](/slides/th/androidjava/open-presentation/) และ [writing](/slides/th/androidjava/save-presentation/) แต่ความแตกต่างของรูปแบบหมายความว่าเอฟเฟกต์บางอย่างอาจแสดงหรือทำงานแตกต่างกันเล็กน้อย ตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง