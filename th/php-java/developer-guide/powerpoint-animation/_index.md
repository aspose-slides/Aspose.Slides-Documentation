---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยแอนิเมชันใน PHP
linktitle: แอนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/php-java/powerpoint-animation/
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
- แอนิเมชันของรูปร่าง
- แผนภูมิเคลื่อนไหว
- ข้อความเคลื่อนไหว
- รูปร่างเคลื่อนไหว
- วัตถุ OLE เคลื่อนไหว
- รูปภาพเคลื่อนไหว
- ตารางเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides for PHP via Java ในการจัดการแอนิเมชัน PowerPoint คุณลักษณะสำคัญและข้อมูลเชิงลึกเพื่อเพิ่มประสิทธิภาพการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากการนำเสนอมีจุดประสงค์เพื่อแสดงข้อมูล รูปลักษณ์และพฤติกรรมเชิงโต้ตอบจึงถูกพิจารณาเสมอในขณะสร้าง

**PowerPoint animation** มีบทบาทสำคัญเพื่อทำให้การนำเสนอดูน่าสนใจและดึงดูดผู้ชม Aspose.Slides for PHP via Java มีตัวเลือกหลากหลายเพื่อ **เพิ่มแอนิเมชัน** ให้กับงานนำเสนอ PowerPoint:

- นำเอา **เอฟเฟกต์แอนิเมชัน PowerPoint** ประเภทต่าง ๆ ไปใช้กับ **รูปร่าง**, **แผนภูมิ**, **ตาราง**, **OLE Objects** และองค์ประกอบการนำเสนออื่น ๆ
- ใช้ **เอฟเฟกต์แอนิเมชันหลาย ๆ อย่าง** บนรูปร่างเดียว
- ใช้ **ไทม์ไลน์แอนิเมชัน** เพื่อควบคุมเอฟเฟกต์แอนิเมชัน
- **สร้างแอนิเมชันแบบกำหนดเอง**

ใน Aspose.Slides for PHP via Java สามารถใช้เอฟเฟกต์แอนิเมชันต่าง ๆ กับรูปร่างได้ ทุกองค์ประกอบบนสไลด์รวมถึงข้อความ, รูปภาพ, OLE Object, ตาราง ฯลฯ ถูกมองว่าเป็นรูปร่าง ดังนั้นเราจึงสามารถนำเอฟเฟกต์แอนิเมชันไปใช้กับทุกองค์ประกอบของสไลด์ได้

## **เอฟเฟกต์แอนิเมชัน**
Aspose.Slides รองรับ **เอฟเฟกต์แอนิเมชันกว่า 150 รายการ** รวมถึงเอฟเฟกต์พื้นฐานเช่น **Bounce**, **PathFootball**, **Zoom** และเอฟเฟกต์เฉพาะเช่น **OLEObjectShow**, **OLEObjectOpen** คุณสามารถดูรายการเต็มของเอฟเฟกต์แอนิเมชันได้ใน Enum **[EffectType](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttype/)**

นอกจากนี้ยังสามารถผสาน **เอฟเฟกต์แอนิเมชัน** เหล่านี้ร่วมกับ:

- [ColorEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/SetEffect)

## **แอนิเมชันแบบกำหนดเอง**
คุณสามารถ **สร้างแอนิเมชันแบบกำหนดเอง** ของคุณเองใน Aspose.Slides  
ซึ่งทำได้โดยการผสาน **พฤติกรรมหลายอย่าง** เข้าด้วยกันเป็นแอนิเมชันใหม่

**[Behavior](https://reference.aspose.com/slides/th/php-java/aspose.slides/Behavior)** คือหน่วยย่อยของเอฟเฟกต์แอนิเมชัน PowerPoint ทุกเอฟเฟกต์เป็นชุดของพฤติกรรมที่ประกอบเป็นกลยุทธ์เดียว คุณสามารถผสานพฤติกรรมเป็น **แอนิเมชันแบบกำหนดเอง** หนึ่งครั้งแล้วใช้ซ้ำในงานนำเสนออื่นได้ หากคุณเพิ่มพฤติกรรมใหม่เข้าไปในเอฟเฟกต์แอนิเมชันมาตรฐาน – จะกลายเป็นแอนิเมชันแบบกำหนดเองอีกหนึ่งตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรม **repeat** ให้กับแอนิเมชันเพื่อให้ทำซ้ำหลายครั้ง

**[Animation Point](https://reference.aspose.com/slides/th/php-java/aspose.slides/Point)** คือจุดที่พฤติกรรมจะถูกนำไปใช้

## **ไทม์ไลน์แอนิเมชัน**
**[Sequence](https://reference.aspose.com/slides/th/php-java/aspose.slides/Sequence)** คือคอลเลกชันของเอฟเฟกต์แอนิเมชันที่ใช้กับรูปร่างหนึ่งรูป

**[Timeline](https://reference.aspose.com/slides/th/php-java/aspose.slides/AnimationTimeLine)** คือชุดของ **Sequences** ที่ใช้ในสไลด์หนึ่งสไลด์เป็นตัวแทนของเอนจินแอนิเมชันตั้งแต่ PowerPoint 2002 ในรุ่น PowerPoint เก่า การเพิ่มเอฟเฟกต์แอนิเมชันทำได้ยากและต้องอาศัยวิธีแก้ต่างๆ ไทม์ไลน์จึงมาแทนที่คลาส **AnimationSettings** เก่าและให้โมเดลวัตถุที่ชัดเจนยิ่งขึ้นสำหรับแอนิเมชัน PowerPoint สไลด์หนึ่งสามารถมี **ไทม์ไลน์แอนิเมชันได้เพียงหนึ่งชุด**

## **แอนิเมชันเชิงโต้ตอบ**
**[Trigger](https://reference.aspose.com/slides/th/php-java/aspose.slides/EffectTriggerType)** ช่วยกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่ทำให้แอนิเมชันบางส่วนเริ่มทำงาน Trigger ถูกเพิ่มเข้ามาใน PowerPoint รุ่นล่าสุดเท่านั้น

## **แอนิเมชันของรูปร่าง**
Aspose.Slides รองรับการนำแอนิเมชันไปใช้กับรูปร่างต่าง ๆ ซึ่งอาจเป็นข้อความ, สี่เหลี่ยม, เส้น, เฟรม, OLE Object ฯลฯ

{{% alert color="primary" %}} 
อ่านเพิ่มเติม[**เกี่ยวกับแอนิเมชันของรูปร่าง**](/slides/th/php-java/shape-animation/).
{{% /alert %}}

## **แอนิเมชันของแผนภูมิ**
เพื่อสร้างแผนภูมิแบบเคลื่อนไหว ให้ใช้คลาสต่าง ๆ เหมือนกับการทำแอนิเมชันกับรูปร่าง อย่างไรก็ตาม คุณสามารถใช้แอนิเมชัน PowerPoint เฉพาะกับ **หมวดหมู่ของแผนภูมิ** หรือ **ซีรีส์ของแผนภูมิ** ได้ คุณยังสามารถนำเอฟเฟกต์แอนิเมชันไปใช้กับ **องค์ประกอบของหมวดหมู่** หรือ **องค์ประกอบของซีรีส์** ได้เช่นกัน

{{% alert color="primary" %}} 
อ่านเพิ่มเติม[**เกี่ยวกับแผนภูมิแบบเคลื่อนไหว**](/slides/th/php-java/animated-charts/).
{{% /alert %}}

## **ข้อความเคลื่อนไหว**
นอกจากข้อความเคลื่อนไหวแล้ว ยังสามารถนำแอนิเมชันไปใช้กับ **ย่อหน้า** ได้อีกด้วย

{{% alert color="primary" %}} 
อ่านเพิ่มเติม[**เกี่ยวกับข้อความเคลื่อนไหว**](/slides/th/php-java/animated-text/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**แอนิเมชันจะคงอยู่เมื่อนำออกเป็น PDF หรือไม่?**

ไม่ PDF เป็นรูปแบบแบบคงที่ ดังนั้นแอนิเมชันและ [slide transitions](/slides/th/php-java/slide-transition/) จะไม่ทำงาน หากต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/php-java/export-to-html5/), [animated GIF](/slides/th/php-java/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/php-java/convert-powerpoint-to-video/) แทน

**ฉันสามารถแปลงการนำเสนอที่มีแอนิเมชันเป็นวิดีโอและกำหนดอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ได้ คุณสามารถ [render the presentation as frames](/slides/th/php-java/convert-powerpoint-to-video/) และเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด แอนิเมชันและการเปลี่ยนสไลด์จะถูกเล่นระหว่างการเรนเดอร์

**แอนิเมชันจะคงอยู่เมื่อตั้งค่าเป็น ODP (ไม่ใช่แค่ PPTX) หรือไม่?**

รองรับการ **อ่าน** [/slides/th/php-java/open-presentation/]และ **เขียน** [/slides/th/php-java/save-presentation/] ของ PPT, PPTX, และ ODP แต่ความแตกต่างของรูปแบบอาจทำให้เอฟเฟกต์บางอย่างแสดงหรือทำงานแตกต่างกันเล็กน้อย ควรตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง