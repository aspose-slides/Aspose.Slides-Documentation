---
title: เพิ่มการนำเสนอ PowerPoint ด้วยการเคลื่อนไหวใน JavaScript
linktitle: การเคลื่อนไหว PowerPoint
type: docs
weight: 150
url: /th/nodejs-java/powerpoint-animation/
keywords:
- เพิ่มการเคลื่อนไหว
- อัพเดตการเคลื่อนไหว
- เปลี่ยนการเคลื่อนไหว
- ลบการเคลื่อนไหว
- จัดการการเคลื่อนไหว
- ควบคุมการเคลื่อนไหว
- เอฟเฟกต์การเคลื่อนไหว
- การเคลื่อนไหว PowerPoint
- ไทม์ไลน์การเคลื่อนไหว
- การเคลื่อนไหวแบบโต้ตอบ
- การเคลื่อนไหวแบบกำหนดเอง
- การเคลื่อนไหวของรูปร่าง
- แผนภูมิเคลื่อนไหว
- ข้อความเคลื่อนไหว
- รูปร่างเคลื่อนไหว
- วัตถุ OLE เคลื่อนไหว
- รูปภาพเคลื่อนไหว
- ตารางเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้ Aspose.Slides for Node.js ผ่าน Java เพื่อจัดการการเคลื่อนไหวของ PowerPoint บทสรุปนี้เน้นคุณลักษณะสำคัญและให้ข้อมูลเชิงลึกเพื่อปรับปรุงการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากการนำเสนอมีวัตถุประสงค์เพื่อแสดงข้อมูล รูปลักษณ์ด้านภาพและพฤติกรรมแบบโต้ตอบจึงต้องได้รับการพิจารณาเสมอในระหว่างการสร้าง

**การเคลื่อนไหวของ PowerPoint** มีบทบาทสำคัญในการทำให้การนำเสนอดึงดูดความสนใจและน่าสนใจสำหรับผู้ชม Aspose.Slides for Node.js via Java มีตัวเลือกหลากหลายสำหรับการเพิ่มการเคลื่อนไหวในงานนำเสนอ PowerPoint:

- ใช้เอฟเฟกต์การเคลื่อนไหวของ PowerPoint ประเภทต่าง ๆ กับรูปร่าง, ชาร์ต, ตาราง, วัตถุ OLE, และส่วนประกอบการนำเสนออื่น ๆ
- ใช้หลายเอฟเฟกต์การเคลื่อนไหวของ PowerPoint บนรูปร่างเดียว
- ใช้ไทม์ไลน์การเคลื่อนไหวเพื่อควบคุมเอฟเฟกต์การเคลื่อนไหว
- สร้างการเคลื่อนไหวแบบกำหนดเอง

ใน Aspose.Slides for Node.js via Java สามารถใช้เอฟเฟกต์การเคลื่อนไหวต่าง ๆ กับรูปร่างได้ เนื่องจากทุกส่วนบนสไลด์รวมถึงข้อความ, รูปภาพ, วัตถุ OLE, และตาราง ถูกพิจารณาเป็นรูปร่าง จึงสามารถใช้เอฟเฟกต์การเคลื่อนไหวกับส่วนใดส่วนหนึ่งบนสไลด์ได้

## **เอฟเฟกต์การเคลื่อนไหว**
Aspose.Slides รองรับ **เอฟเฟกต์การเคลื่อนไหวกว่า 150 รายการ** รวมถึงเอฟเฟกต์พื้นฐานเช่น Bounce, PathFootball, และ Zoom และเอฟเฟกต์เฉพาะเช่น OLEObjectShow และ OLEObjectOpen คุณสามารถพบรายการทั้งหมดได้ในเอ็นุมเมอเรชัน [EffectType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttype/)

นอกจากนี้เอฟเฟกต์การเคลื่อนไหวเหล่านี้สามารถใช้ร่วมกับพฤติกรรมต่อไปนี้ได้:

- [เอฟเฟกต์สี](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ColorEffect)
- [เอฟเฟกต์คำสั่ง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/CommandEffect)
- [เอฟเฟกต์ตัวกรอง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FilterEffect)
- [เอฟเฟกต์การเคลื่อนที่](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MotionEffect)
- [เอฟเฟกต์คุณสมบัติ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PropertyEffect)
- [เอฟเฟกต์การหมุน](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/RotationEffect)
- [เอฟเฟกต์การสเกล](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ScaleEffect)
- [เอฟเฟกต์การตั้งค่า](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SetEffect)

## **การเคลื่อนไหวแบบกำหนดเอง**

สำหรับตัวอย่าง JavaScript แบบสมบูรณ์ที่สร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมและเส้นทางการเคลื่อนที่ที่แก้ไขได้, ดูที่ [การเคลื่อนไหวแบบกำหนดเอง](/slides/th/nodejs-java/custom-animation/)

สามารถสร้าง **การเคลื่อนไหวแบบกำหนดเอง** ของคุณเองใน Aspose.Slides ได้ โดยการรวมหลายพฤติกรรมเข้าด้วยกันเป็นการเคลื่อนไหวแบบกำหนดใหม่

[Behavior](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behavior/) เป็นบล็อกการสร้างของเอฟเฟกต์การเคลื่อนไหวของ PowerPoint ผสานพฤติกรรมเพื่อปรับแต่งเอฟเฟกต์ หรือเพิ่มพฤติกรรมเพื่อขยายเอฟเฟกต์ที่กำหนดไว้ การทำซ้ำถูกกำหนดผ่านการตั้งค่าเวลาแทนการใช้พฤติกรรมทำซ้ำแยกต่างหาก

[Animation Point](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/point/) คือจุดที่ควรใช้พฤติกรรม

## **ไทม์ไลน์การเคลื่อนไหว**
[Sequence](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/) เป็นคอลเลกชันของเอฟเฟกต์การเคลื่อนไหวที่สามารถกำหนดเป้าหมายไปที่รูปร่างต่าง ๆ

[Timeline](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/animationtimeline/) เป็นชุดของลำดับที่ใช้ในสไลด์เฉพาะ มันเป็นเอนจินการเคลื่อนไหวที่แนะนำใน PowerPoint 2002 ในเวอร์ชันก่อนหน้าของ PowerPoint การเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับงานนำเสนอเป็นเรื่องยากและทำได้เฉพาะด้วยวิธีแก้ปัญหาต่าง ๆ ไทม์ไลน์ให้โมเดลวัตถุที่ชัดเจนขึ้นสำหรับการเคลื่อนไหวของ PowerPoint สไลด์สามารถมีไทม์ไลน์การเคลื่อนไหวได้เพียงหนึ่งชุด

## **การเคลื่อนไหวแบบโต้ตอบ**
[Trigger](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttriggertype/) ให้คุณกำหนดการกระทำของผู้ใช้ เช่น การคลิกปุ่ม เพื่อเริ่มการเคลื่อนไหวเฉพาะ

## **การเคลื่อนไหวของรูปร่าง**
Aspose.Slides อนุญาตให้คุณใช้การเคลื่อนไหวกับรูปร่าง ซึ่งอาจรวมถึงข้อความ, สี่เหลี่ยม, เส้น, เฟรม, วัตถุ OLE และอื่น ๆ

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**เกี่ยวกับการเคลื่อนไหวของรูปร่าง**](/slides/th/nodejs-java/shape-animation/).
{{% /alert %}}

## **แผนภูมิเคลื่อนไหว**
เพื่อสร้างแผนภูมิที่เคลื่อนไหว คุณควรใช้คลาสเดียวกับรูปร่าง อย่างไรก็ตาม การเคลื่อนไหวของ PowerPoint สามารถใช้ได้กับหมวดหมู่แผนภูมิหรือชุดข้อมูลแผนภูมิเท่านั้น คุณยังสามารถใช้เอฟเฟกต์การเคลื่อนไหวกับองค์ประกอบหมวดหมู่หรือชุดข้อมูลได้

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**เกี่ยวกับแผนภูมิเคลื่อนไหว**](/slides/th/nodejs-java/animated-charts/).
{{% /alert %}}

## **ข้อความเคลื่อนไหว**
นอกจากการเคลื่อนไหวข้อความแล้ว คุณยังสามารถใช้การเคลื่อนไหวกับย่อหน้าหนึ่งได้

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติม [**เกี่ยวกับข้อความเคลื่อนไหว**](/slides/th/nodejs-java/animated-text/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การเคลื่อนไหวจะยังคงอยู่เมื่อนำออกเป็น PDF หรือไม่?**

ไม่. PDF เป็นรูปแบบสถิต ดังนั้นการเคลื่อนไหวและ [การเปลี่ยนสไลด์](/slides/th/nodejs-java/slide-transition/) จะไม่ทำงาน หากต้องการการเคลื่อนที่ ให้ส่งออกเป็น [HTML5](/slides/th/nodejs-java/export-to-html5/), [GIF เคลื่อนไหว](/slides/th/nodejs-java/convert-powerpoint-to-animated-gif/), หรือ [วิดีโอ](/slides/th/nodejs-java/convert-powerpoint-to-video/) แทน

**ฉันสามารถแปลงการนำเสนอที่มีการเคลื่อนไหวเป็นวิดีโอและควบคุมอัตราเฟรมและขนาดเฟรมได้หรือไม่?**

ใช่. คุณสามารถ [เรนเดอร์การนำเสนอเป็นเฟรม](/slides/th/nodejs-java/convert-powerpoint-to-video/) และเข้ารหัสเป็นวิดีโอ (เช่น ผ่าน ffmpeg) โดยเลือก FPS และความละเอียด การเคลื่อนไหวและการเปลี่ยนสไลด์จะเล่นระหว่างการเรนเดอร์

**การเคลื่อนไหวจะคงอยู่เมื่อทำงานกับ ODP (ไม่ใช่เพียง PPTX) หรือไม่?**

PPT, PPTX, และ ODP รองรับสำหรับ [การอ่าน](/slides/th/nodejs-java/open-presentation/) และ [การเขียน](/slides/th/nodejs-java/save-presentation/) แต่ไม่รับประกันว่าจะคงการเคลื่อนไหวไว้ได้ ข้อมูลการเคลื่อนไหวแบบกำหนดเองอาจสูญหายเมื่อแปลงเป็น ODP ดูที่ [การเคลื่อนไหวแบบกำหนดเอง](/slides/th/nodejs-java/custom-animation/) สำหรับตัวอย่างและแนวทางตรวจสอบความเข้ากันได้ของรูปแบบ