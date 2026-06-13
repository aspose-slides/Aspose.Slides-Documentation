---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 14.7.0
linktitle: Aspose.Slides สำหรับ Java 14.7.0
type: docs
weight: 60
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides for Java เพื่อให้การย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณเป็นไปอย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) รวมถึงข้อจำกัดใหม่และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 14.7.0 API

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **ได้ลบคอนสตรัคเตอร์ของบางประเภทย่อยของ TransitionValueBase และได้ลบ TransitionValueFactory**
คอนสตรัคเตอร์ของบางประเภทย่อยของ TransitionValueBase (เช่น CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) ไม่มีความจำเป็นใน Public API จึงถูกลบออกแล้ว คลาสที่เกี่ยวข้อง TransitionValueFactory และอินเทอร์เฟซ ITransitionValueFactory ถูกลบเนื่องจากเหตุผลเดียวกัน
### **ได้ลบสมาชิก SoundAction จาก enumeration com.aspose.slides.TransitionType**
สมาชิก SoundAction ผิดพลาดและไม่ได้ถูกใช้งาน การตั้งค่าเสียงกำหนดโดยคุณสมบัติ SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName
### **ได้เพิ่มคลาส FlyThroughTransition และอินเทอร์เฟซ IFlyThroughTransition**
คลาส com.aspose.slides.FlyThroughTransition (และอินเทอร์เฟซ com.aspose.slides.IFlyThroughTransition) เชื่อมโยงกับประเภทการเปลี่ยนภาพ Flythrough ที่รองรับในรุ่นนี้
### **ได้เพิ่มคลาส GlitterTransition, อินเทอร์เฟซ IGlitterTransition และ enumeration TransitionPattern**
คลาส com.aspose.slides.GlitterTransition (และอินเทอร์เฟซ com.aspose.slides.IGlitterTransition) เชื่อมโยงกับประเภทการเปลี่ยนภาพ Glitter ที่รองรับในรุ่นนี้
enumeration com.aspose.slides.TransitionPattern ใช้ในคลาสนี้และระบุรูปแบบเรขาคณิตที่ต่อกันเป็นแผ่นเพื่อเติมพื้นที่ขนาดใหญ่
### **ได้เพิ่มคลาส LeftRightDirectionTransition, อินเทอร์เฟซ ILeftRightDirectionTransition และ enumeration TransitionLeftRightDirectionType**
คลาส com.aspose.slides.LeftRightDirectionTransition (และอินเทอร์เฟซ com.aspose.slides.ILeftRightDirectionTransition) เชื่อมโยงกับประเภทการเปลี่ยนภาพ Switch, Flip, Ferris, Gallery, Conveyor ที่รองรับในรุ่นนี้
enumeration com.aspose.slides.TransitionLeftRightDirectionType ใช้ในคลาสนี้และระบุทิศทางที่จำกัดอยู่ที่ค่า left และ right
### **ได้เพิ่มสมาชิกใหม่ใน enumeration com.aspose.slides.TransitionType**
enumeration com.aspose.slides.TransitionType ได้ขยายด้วยสมาชิกใหม่
สมาชิกใหม่ที่เกี่ยวข้องกับการเปลี่ยนภาพ PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse
สมาชิกใหม่ที่เกี่ยวข้องกับการเปลี่ยนภาพ PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami
### **ได้เพิ่มคลาส RevealTransition และอินเทอร์เฟซ IRevealTransition**
คลาส com.aspose.slides.RevealTransition (และอินเทอร์เฟซ com.aspose.slides.IRevealTransition) เชื่อมโยงกับประเภทการเปลี่ยนภาพ Reveal ที่รองรับในรุ่นนี้
### **ได้เพิ่มคลาส RippleTransition, อินเทอร์เฟซ IRippleTransition และ enumeration TransitionCornerAndCenterDirectionType**
คลาส com.aspose.slides.RippleTransition (และอินเทอร์เฟซ com.aspose.slides.IRippleTransition) เชื่อมโยงกับประเภทการเปลี่ยนภาพ Ripple ที่รองรับในรุ่นนี้
enumeration com.aspose.slides.TransitionCornerAndCenterDirectionType ใช้ในคลาสนี้และระบุทิศทางที่จำกัดอยู่ที่มุมและศูนย์กลาง
### **ได้เพิ่มคลาส ShredTransition, อินเทอร์เฟซ IShredTransition และ enumeration TransitionShredPattern**
คลาส com.aspose.slides.ShredTransition (และอินเทอร์เฟซ com.aspose.slides.IShredTransition) เชื่อมโยงกับประเภทการเปลี่ยนภาพ Shred ที่รองรับในรุ่นนี้
enumeration com.aspose.slides.TransitionShredPattern ใช้ในคลาสนี้และระบุรูปทรงเรขาคณิตที่ต่อกันเป็นแผ่นเพื่อเติมพื้นที่ขนาดใหญ่