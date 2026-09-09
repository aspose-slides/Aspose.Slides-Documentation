---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยแอนิเมชันใน Python ผ่าน Java
linktitle: แอนิเมชัน PowerPoint
type: docs
weight: 150
url: /th/python-java/powerpoint-animation/
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
- Python
- Java
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ Python ผ่าน Java ในการจัดการแอนิเมชัน PowerPoint ภาพรวมทั่วไปนี้เน้นคุณลักษณะสำคัญและให้ข้อมูลเชิงลึกเพื่อเพิ่มคุณภาพการนำเสนอของคุณ"
---
## **บทนำ**

ทั้งลักษณะการแสดงผลและพฤติกรรมเชิงโต้ตอบจะถูกพิจารณาเมื่อต้องสร้างงานนำเสนอ

**แอนิเมชัน PowerPoint** มีบทบาทสำคัญในการทำให้การนำเสนอโดดเด่นและดึงดูดผู้ชม Aspose.Slides มีตัวเลือกมากมายเพื่อเพิ่มแอนิเมชันให้กับงานนำเสนอ PowerPoint:

- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint หลากหลายประเภทกับรูปทรง, แผนภูมิ, ตาราง, วัตถุ OLE และองค์ประกอบการนำเสนออื่น ๆ
- ใช้เอฟเฟกต์แอนิเมชัน PowerPoint หลายอย่างบนรูปทรงเดียว
- ใช้ไทม์ไลน์แอนิเมชันเพื่อควบคุมเอฟเฟกต์แอนิเมชัน
- สร้างแอนิเมชันแบบกำหนดเอง

ใน Aspose.Slides สามารถใช้เอฟเฟกต์แอนิเมชันต่าง ๆ กับรูปทรงได้ เนื่องจากทุกองค์ประกอบบนสไลด์ รวมถึงข้อความ รูปภาพ วัตถุ OLE และตาราง ถูกพิจารณาเป็นรูปทรง ดังนั้นเอฟเฟกต์แอนิเมชันจึงสามารถนำไปใช้กับองค์ประกอบใด ๆ บนสไลด์ได้

## **เอฟเฟกต์แอนิเมชัน**
Aspose.Slides รองรับ **เอฟเฟกต์แอนิเมชันกว่า 150 ประการ**, รวมถึงเอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball และ Zoom รวมถึงเอฟเฟกต์พิเศษเช่น OLEObjectShow และ OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟกต์แอนิเมชันได้ใน enumeration [EffectType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttype/)

นอกจากนี้เอฟเฟกต์แอนิเมชันต่อไปนี้สามารถใช้ร่วมกับรายการด้านบนได้:
- [ColorEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/seteffect/)

## **แอนิเมชันแบบกำหนดเอง**
คุณสามารถสร้าง **แอนิเมชันแบบกำหนดเอง** ของคุณเองใน Aspose.Slides ได้
คุณทำได้โดยการรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นแอนิเมชันแบบกำหนดเองใหม่

[Behavior](https://reference.aspose.com/slides/th/python-java/aspose.slides/behavior/) เป็นบล็อกพื้นฐานของเอฟเฟกต์แอนิเมชัน PowerPoint ใด ๆ
แต่ละเอฟเฟกต์แอนิเมชันประกอบด้วยชุดของพฤติกรรมที่รวมกันเป็นกลยุทธ์เดียว
คุณสามารถรวมพฤติกรรมเป็นแอนิเมชันแบบกำหนดเองหนึ่งครั้งและใช้ซ้ำในงานนำเสนออื่นได้
การเพิ่มพฤติกรรมใหม่ให้กับเอฟเฟกต์แอนิเมชัน PowerPoint มาตรฐานจะสร้างแอนิเมชันแบบกำหนดเองอีกหนึ่งชุด
เช่น คุณสามารถเพิ่มพฤติกรรมการทำซ้ำเพื่อให้แอนิเมชันทำซ้ำหลายครั้ง

[Point](https://reference.aspose.com/slides/th/python-java/aspose.slides/point/) คือจุดที่ควรนำพฤติกรรมไปใช้

## **ไทม์ไลน์แอนิเมชัน**
[Sequence](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/) คือคอลเลกชันของเอฟเฟกต์แอนิเมชันที่นำไปใช้กับรูปทรงเฉพาะ

[AnimationTimeLine](https://reference.aspose.com/slides/th/python-java/aspose.slides/animationtimeline/) คือชุดของ Sequence ที่ใช้บนสไลด์เฉพาะ มันเป็นตัวเอนจินแอนิเมชันที่แนะนำใน PowerPoint 2002 ในเวอร์ชัน PowerPoint ก่อนหน้านี้ การเพิ่มเอฟเฟกต์แอนิเมชันเข้ากับงานนำเสนอเป็นเรื่องท้าทายและต้องอาศัยวิธีแก้ไข ไทม์ไลน์แทนที่คลาส AnimationSettings เก่าและให้โมเดลวัตถุที่ชัดเจนขึ้นสำหรับแอนิเมชัน PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์แอนิเมชันได้เพียงหนึ่งชุด

## **แอนิเมชันเชิงโต้ตอบ**
[EffectTriggerType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttriggertype/) ให้คุณกำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) เพื่อเริ่มแอนิเมชันเฉพาะ Triggers ถูกเพิ่มเข้ามาเฉพาะในเวอร์ชัน PowerPoint ล่าสุด

## **แอนิเมชันรูปทรง**
Aspose.Slides อนุญาตให้คุณนำแอนิเมชันไปใช้กับรูปทรง ซึ่งสามารถแทนข้อความ สี่เหลี่ยมผืนผ้า เส้น เฟรม วัตถุ OLE และองค์ประกอบอื่น ๆ

{{% alert color="info" title="หมายเหตุ" %}}
อ่านเพิ่มเติม [เกี่ยวกับแอนิเมชันรูปทรง](/slides/th/python-java/shape-animation/).
{{% /alert %}}

## **แผนภูมิแอนิเมชัน**
เพื่อสร้างแผนภูมิที่มีแอนิเมชัน ให้ใช้คลาสเดียวกับรูปทรง อย่างไรก็ตาม การใช้แอนิเมชัน PowerPoint สามารถทำได้เฉพาะบนหมวดหมู่ของแผนภูมิหรือซีรีส์ของแผนภูมิเท่านั้น คุณยังสามารถนำเอฟเฟกต์แอนิเมชันไปใช้กับองค์ประกอบหมวดหมู่หรือองค์ประกอบซีรีส์ได้

{{% alert color="info" title="หมายเหตุ" %}}
อ่านเพิ่มเติม [เกี่ยวกับแผนภูมิแอนิเมชัน](/slides/th/python-java/animated-charts/).
{{% /alert %}}

## **ข้อความแอนิเมชัน**
นอกจากการทำแอนิเมชันให้กับข้อความแล้ว คุณยังสามารถนำแอนิเมชันไปใช้กับย่อหน้าได้

{{% alert color="info" title="หมายเหตุ" %}}
อ่านเพิ่มเติม [เกี่ยวกับข้อความแอนิเมชัน](/slides/th/python-java/animated-text/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การแอนิเมชันจะคงอยู่เมื่อส่งออกเป็น PDF หรือไม่?**

ไม่ PDF เป็นรูปแบบคงที่ ดังนั้นแอนิเมชันและ [การเปลี่ยนสไลด์](/slides/th/python-java/slide-transition/) จะไม่ทำงาน หากคุณต้องการการเคลื่อนที่ ให้ส่งออกเป็น [HTML5](/slides/th/python-java/export-to-html5/), [GIF แบบเคลื่อนไหว](/slides/th/python-java/convert-powerpoint-to-animated-gif/), หรือ [วิดีโอ](/slides/th/python-java/convert-powerpoint-to-video/) แทน

**สามารถแปลงงานนำเสนอที่มีแอนิเมชันเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ได้ คุณสามารถ [แปลงงานนำเสนอเป็นเฟรม](/slides/th/python-java/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ด้วย ffmpeg) โดยเลือก FPS และความละเอียด การแอนิเมชันและการเปลี่ยนสไลด์จะถูกเล่นขณะเรนเดอร์

**แอนิเมชันจะคงเดิมเมื่อติดต่อกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?**

PPT, PPTX และ ODP รองรับสำหรับ [การอ่าน](/slides/th/python-java/open-presentation/) และ [การเขียน](/slides/th/python-java/save-presentation/) แต่ความแตกต่างของรูปแบบหมายความว่าเอฟเฟกต์บางอย่างอาจดูหรือทำงานแตกต่างกันเล็กน้อย ตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง