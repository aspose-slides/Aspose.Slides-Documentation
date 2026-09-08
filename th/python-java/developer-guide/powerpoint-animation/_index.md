---
title: เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยการเคลื่อนไหวใน Python ผ่าน Java
linktitle: การเคลื่อนไหว PowerPoint
type: docs
weight: 150
url: /th/python-java/powerpoint-animation/
keywords:
- เพิ่มการเคลื่อนไหว
- อัปเดตการเคลื่อนไหว
- เปลี่ยนการเคลื่อน​ภาพ
- ลบการเคลื่อนไหวย
- จัดการการเคลื่อนไหว
- ควบคุมการเคลื่อนไหว
- เอฟเฟ็กต์การเคลื่อนไหว
- การเคลื่อนไหว PowerPoint
- ไทม์ไลน์การเคลื่อนไหว
- การเคลื่อนไหวเชิงโต้ตอบ
- การเคลื่อนไหวแบบกำหนดเอง
- การเคลื่อนไหวของรูปร่าง
- แผนภูมิที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- รูปร่างที่เคลื่อนไหว
- ออบเจ็กต์ OLE ที่เคลื่อนไหว
- รูปภาพที่เคลื่อนไหว
- ตารางที่เคลื่อนไหว
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สำรวจความสามารถของ Aspose.Slides สำหรับ Python ผ่าน Java ในการจัดการการเคลื่อนไหวของ PowerPoint ภาพรวมทั่วไปนี้เน้นคุณลักษณะสำคัญและมอบข้อมูลเชิงลึกเพื่อเพิ่มประสิทธิภาพการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากงานนำเสนอมีวัตถุประสงค์เพื่อแสดงข้อมูล ลักษณะการแสดงผลและพฤติกรรมเชิงโต้ตอบจึงได้รับการพิจารณาตลอดกระบวนการสร้าง

**การเคลื่อนไหวใน PowerPoint** มีบทบาทสำคัญในการทำให้งานนำเสนอน่าสนใจและดึงดูดผู้ชม Aspose.Slides มีตัวเลือกหลากหลายเพื่อเพิ่มการเคลื่อนไหวให้กับงานนำเสนอ PowerPoint:

- ใช้เอฟเฟ็กต์การเคลื่อนไหวของ PowerPoint แบบต่าง ๆ กับรูปทรง แผนภูมิ ตาราง ออบเจ็กต์ OLE และองค์ประกอบอื่น ๆ ของงานนำเสนอ
- ใช้เอฟเฟ็กต์การเคลื่อนไหวหลายรายการบนรูปทรงเดียว
- ใช้ไทม์ไลน์การเคลื่อนไหวเพื่อควบคุมเอฟเฟ็กต์การเคลื่อนไหว
- สร้างการเคลื่อนไหวแบบกำหนดเอง

ใน Aspose.Slides สามารถนำเอฟเฟ็กต์การเคลื่อนไหวต่าง ๆ ไปใช้กับรูปทรงได้ เนื่องจากทุกองค์ประกอบบนสไลด์ รวมถึงข้อความ รูปภาพ ออบเจ็กต์ OLE และตาราง ต่างถูกถือเป็นรูปทรง ทำให้เอฟเฟ็กต์การเคลื่อนไหวสามารถใช้กับองค์ประกอบใดก็ได้บนสไลด์

## **Animation Effects**
Aspose.Slides รองรับเอฟเฟ็กต์การเคลื่อนไหวกว่า 150 รายการ รวมถึงเอฟเฟ็กต์พื้นฐานเช่น Bounce, PathFootball, Zoom และเอฟเฟ็กต์เฉพาะเช่น OLEObjectShow, OLEObjectOpen คุณสามารถดูรายการเต็มของเอฟเฟ็กต์การเคลื่อนไหวได้ใน enumeration [EffectType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttype/)

นอกจากนี้ เอฟเฟ็กต์การเคลื่อนไหวเหล่านี้สามารถใช้ร่วมกับรายการต่อไปนี้ได้:
- [ColorEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/seteffect/)

## **Custom Animation**
คุณสามารถสร้างการเคลื่อนไหวแบบกำหนดเองใน Aspose.Slides ได้ หากคุณรวมพฤติกรรมหลายอย่างเข้าด้วยกันเป็นการเคลื่อนไหวแบบกำหนดใหม่

[Behavior](https://reference.aspose.com/slides/th/python-java/aspose.slides/behavior/) คือหน่วยย่อยของเอฟเฟ็กต์การเคลื่อนไหวใน PowerPoint ทุกเอฟเฟ็กต์การเคลื่อนไหวจริง ๆ แล้วเป็นชุดของพฤติกรรมที่รวมเป็นกลยุทธ์เดียว คุณสามารถรวมพฤติกรรมเข้าด้วยกันเป็นการเคลื่อนไหวแบบกำหนดเองหนึ่งครั้งและนำไปใช้ซ้ำในงานนำเสนออื่น หากคุณเพิ่มพฤติกรรมใหม่เข้าไปในเอฟเฟ็กต์การเคลื่อนไหวมาตรฐานของ PowerPoint จะกลายเป็นการเคลื่อนไหวแบบกำหนดเองใหม่ ตัวอย่างเช่น คุณสามารถเพิ่มพฤติกรรม repeat ให้กับการเคลื่อนไหเพื่อให้ทำซ้ำหลายครั้ง

[Point](https://reference.aspose.com/slides/th/python-java/aspose.slides/point/) คือจุดที่ควรนำพฤติกรรมไปใช้

## **Animation Time Line**
[Sequence](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/) คือคอลเลกชันของเอฟเฟ็กต์การเคลื่อนไหวที่นำไปใช้กับรูปทรงเฉพาะ

[AnimationTimeLine](https://reference.aspose.com/slides/th/python-java/aspose.slides/animationtimeline/) เป็นชุดของ Sequences ที่ใช้ในสไลด์เฉพาะ มันเป็นเอนจินการเคลื่อนไหวตั้งแต่ PowerPoint 2002 ในเวอร์ชัน PowerPoint ก่อนหน้า การเพิ่มเอฟเฟ็กต์การเคลื่อนไหวให้กับงานนำเสนอเป็นเรื่องยากและทำได้เฉพาะด้วยวิธีแก้ไขต่าง ๆ ไทม์ไลน์เข้ามาแทนที่คลาส AnimationSettings เก่าและให้โมเดลวัตถุที่ชัดเจนยิ่งขึ้นสำหรับการเคลื่อนไหวใน PowerPoint สไลด์หนึ่งสามารถมีไทม์ไลน์การเคลื่อนไหวได้ เพียง หนึ่ง เท่านั้น

## **Interactive Animation**
[EffectTriggerType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttriggertype/) อนุญาตให้กำหนดการกระทำของผู้ใช้ (เช่น การคลิกปุ่ม) ที่จะทำให้การเคลื่อนไหวบางอย่างเริ่มต้น ตัวกระตุ้นถูกเพิ่มเข้ามาในเวอร์ชันล่าสุดของ PowerPoint เท่านั้น

## **Shape Animation**
Aspose.Slides สามารถนำการเคลื่อนไหวไปใช้กับรูปทรงได้ ซึ่งอาจเป็นข้อความ, สี่เหลี่ยม, เส้น, เฟรม, ออบเจ็กต์ OLE ฯลฯ

{{% alert color="info" title="หมายเหตุ" %}} 
อ่านเพิ่มเติม [เกี่ยวกับการเคลื่อนไหวของรูปทรง](/slides/th/python-java/shape-animation/).
{{% /alert %}}

## **Animated Charts**
ในการสร้างแผนภูมิที่มีการเคลื่อนไหว คุณควรใช้คลาสเดียวกับที่ใช้กับรูปทรง อย่างไรก็ตาม สามารถใช้การเคลื่อนไหวของ PowerPoint กับหมวดหมู่หรือชุดข้อมูลของแผนภูมิเท่านั้น คุณยังสามารถนำเอฟเฟ็กต์การเคลื่อนไหวไปใช้กับองค์ประกอบของหมวดหมู่หรือชุดข้อมูลได้

{{% alert color="info" title="หมายเหตุ" %}} 
อ่านเพิ่มเติม [เกี่ยวกับแผนภูมิที่มีการเคลื่อนไหว](/slides/th/python-java/animated-charts/).
{{% /alert %}}

## **Animated Text**
นอกจากข้อความที่มีการเคลื่อนไหวแล้ว ยังสามารถนำการเคลื่อนไหวไปใช้กับย่อหน้าได้

{{% alert color="info" title="หมายเหตุ" %}} 
อ่านเพิ่มเติม [เกี่ยวกับข้อความที่มีการเคลื่อนไหว](/slides/th/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**การเคลื่อนไหวจะถูกเก็บไว้เมื่อส่งออกเป็น PDF หรือไม่?**

ไม่ PDF เป็นรูปแบบคงที่ ดังนั้นการเคลื่อนไหวและ [slide transitions](/slides/th/python-java/slide-transition/) จะไม่ทำงาน หากต้องการการเคลื่อนไหว ให้ส่งออกเป็น [HTML5](/slides/th/python-java/export-to-html5/), [animated GIF](/slides/th/python-java/convert-powerpoint-to-animated-gif/), หรือ [video](/slides/th/python-java/convert-powerpoint-to-video/) แทน

**ฉันสามารถแปลงงานนำเสนอที่มีการเคลื่อนไหวเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ได้ คุณสามารถ [เรนเดอร์งานนำเสนอเป็นเฟรม](/slides/th/python-java/convert-powerpoint-to-video/) แล้วเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด การเคลื่อนไหวและ slide transitions จะถูกเล่นระหว่างการเรนเดอร์

**การเคลื่อนไหวจะคงสภาพเดิมเมื่อทำงานกับ ODP (ไม่ใช่แค่ PPTX) หรือไม่?**

PPT, PPTX, และ ODP รองรับสำหรับ [การอ่าน](/slides/th/python-java/open-presentation/) และ [การบันทึก](/slides/th/python-java/save-presentation/) แต่ความแตกต่างของรูปแบบทำให้บางเอฟเฟ็กต์อาจแสดงหรือทำงานต่างกันเล็กน้อย ควรตรวจสอบกรณีสำคัญด้วยตัวอย่างจริง