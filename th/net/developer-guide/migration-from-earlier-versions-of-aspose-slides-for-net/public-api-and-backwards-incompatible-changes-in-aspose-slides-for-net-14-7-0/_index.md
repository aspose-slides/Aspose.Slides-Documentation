---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.7.0
linktitle: Aspose.Slides สำหรับ .NET 14.7.0
type: docs
weight: 90
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการหยุดทำงานใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}}

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)หรือ[ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **ตัวสร้างและองค์ประกอบที่ถูกลบ**
#### **ลบตัวสร้างบางชนิดของ TransitionValueBase Subtype และ TransitionValueFactory**
ตัวสร้างของบางชนิดย่อยของ TransitionValueBase (โดยเฉพาะ CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) ไม่มีประโยชน์ใน Public API จึงถูกลบออก

คลาสที่เกี่ยวข้อง TransitionValueFactory และอินเทอร์เฟซ ITransitionValueFactory ถูกลบออกด้วยเหตุผลเดียวกัน
#### **ลบองค์ประกอบ SoundAction จาก enumeration Aspose.Slides.SlideShow.TransitionType**
องค์ประกอบ SoundAction ไม่ถูกต้องและไม่ได้ใช้ การตั้งค่าเสียงกำหนดโดยคุณสมบัติ SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName
### **เพิ่มคลาสและอินเทอร์เฟซ**
#### **เพิ่มคลาส FlyThroughTransition และอินเทอร์เฟซ IFlyThroughTransition**
คลาส Aspose.Slides.SlideShow.FlyThroughTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IFlyThroughTransition) เกี่ยวกับประเภทการเปลี่ยนแปลง Flythrough ที่รองรับตั้งแต่รุ่นนี้
#### **เพิ่มคลาส GlitterTransition, อินเทอร์เฟซ IGlitterTransition และ enumeration TransitionPattern**
คลาส Aspose.Slides.SlideShow.GlitterTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IGlitterTransition) เกี่ยวกับประเภทการเปลี่ยนแปลง Glitter ที่รองรับตั้งแต่รุ่นนี้

enumeration Aspose.Slides.SlideShow.TransitionPattern ถูกใช้ในคลาสนี้และระบุรูปแบบเรขาคณิตที่นำมาประกอบกันเพื่อเติมพื้นที่ที่ใหญ่กว่า
#### **เพิ่มคลาส LeftRightDirectionTransition, อินเทอร์เฟซ ILeftRightDirectionTransition และ enumeration TransitionLeftRightDirectionType**
คลาส Aspose.Slides.SlideShow.LeftRightDirectionTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.ILeftRightDirectionTransition) เกี่ยวกับประเภทการเปลี่ยนแปลง Conveyor, Ferris, Flip, Gallery และ Switch ทั้งหมดรองรับตั้งแต่รุ่นนี้

enumeration Aspose.Slides.SlideShow.TransitionLeftRightDirectionType ถูกใช้ในคลาสนี้และระบุทิศทางที่จำกัดให้เป็นค่า left และ right
#### **เพิ่มองค์ประกอบใหม่ใน enumeration Aspose.Slides.SlideShow.TransitionType**
enumeration Aspose.Slides.SlideShow.TransitionType ได้รับการขยายด้วยองค์ประกอบใหม่

- องค์ประกอบใหม่ที่เกี่ยวข้องกับการเปลี่ยนแปลง PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- องค์ประกอบใหม่ที่เกี่ยวข้องกับการเปลี่ยนแปลง PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **เพิ่มคลาส RevealTransition และอินเทอร์เฟซ IRevealTransition**
คลาส Aspose.Slides.SlideShow.RevealTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IRevealTransition) เกี่ยวกับประเภทการเปลี่ยนแปลง Reveal ที่รองรับตั้งแต่รุ่นนี้
#### **เพิ่มคลาส RippleTransition, อินเทอร์เฟซ IRippleTransition และ enumeration TransitionCornerAndCenterDirectionType**
คลาส Aspose.Slides.SlideShow.RippleTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IRippleTransition) เกี่ยวกับประเภทการเปลี่ยนแปลง Ripple ที่รองรับตั้งแต่รุ่นนี้

enumeration Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType ถูกใช้ในคลาสนี้และระบุทิศทางที่จำกัดให้เป็นมุมและศูนย์กลาง