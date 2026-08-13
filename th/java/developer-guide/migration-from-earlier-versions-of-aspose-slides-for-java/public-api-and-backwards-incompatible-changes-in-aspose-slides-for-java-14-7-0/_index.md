---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 14.7.0
linktitle: Aspose.Slides สำหรับ Java 14.7.0
type: docs
weight: 60
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดทันสมัย
- แนวทางเก่า
- แนวทางทันสมัย
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้หยุดทำงานใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ทั้งหมดที่ [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) , ข้อจำกัดใหม่และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน API ของ Aspose.Slides for Java 14.7.0

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
### **คอนสตรัคเตอร์ของบางซับไทป์ของ TransitionValueBase ถูกลบและ TransitionValueFactory ถูกลบ**
คอนสตรัคเตอร์ของบางซับไทป์ของ TransitionValueBase (โดยเฉพาะ CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) ไม่มีประโยชน์ใน API สาธารณะและจึงถูกลบ คลาสที่เกี่ยวข้อง TransitionValueFactory และอินเทอร์เฟซ ITransitionValueFactory ถูกลบด้วยเหตุผลเดียวกัน
### **สมาชิก SoundAction ถูกลบออกจาก enumeration com.aspose.slides.TransitionType**
สมาชิก SoundAction ไม่ถูกต้องและไม่ได้ใช้งาน การตั้งค่าเสียงจะถูกกำหนดโดยคุณสมบัติ SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName
### **คลาส FlyThroughTransition และอินเทอร์เฟซ IFlyThroughTransition ถูกเพิ่ม**
คลาส com.aspose.slides.FlyThroughTransition (และอินเทอร์เฟซ com.aspose.slides.IFlyThroughTransition) เกี่ยวข้องกับประเภทการเปลี่ยนภาพ Flythrough ที่รองรับในรุ่นนี้
### **คลาส GlitterTransition, อินเทอร์เฟซ IGlitterTransition และ enumeration TransitionPattern ถูกเพิ่ม**
คลาส com.aspose.slides.GlitterTransition (และอินเทอร์เฟซ com.aspose.slides.IGlitterTransition) เกี่ยวข้องกับประเภทการเปลี่ยนภาพ Glitter ที่รองรับในรุ่นนี้  enumeration com.aspose.slides.TransitionPattern ถูกใช้ในคลาสนี้และระบุรูปแบบเรขาคณิตที่จัดเรียงต่อกันเพื่อเติมพื้นที่ขนาดใหญ่
### **คลาส LeftRightDirectionTransition, อินเทอร์เฟซ ILeftRightDirectionTransition และ enumeration TransitionLeftRightDirectionType ถูกเพิ่ม**
คลาส com.aspose.slides.LeftRightDirectionTransition (และอินเทอร์เฟซ com.aspose.slides.ILeftRightDirectionTransition) เกี่ยวข้องกับประเภทการเปลี่ยนภาพ Switch, Flip, Ferris, Gallery, Conveyor ที่รองรับในรุ่นนี้  enumeration com.aspose.slides.TransitionLeftRightDirectionType ถูกใช้ในคลาสนี้และระบุทิศทางที่จำกัดให้เป็นค่าซ้ายและขวา
### **สมาชิกใหม่ถูกเพิ่มเข้าไปใน enumeration com.aspose.slides.TransitionType**
enumeration com.aspose.slides.TransitionType ถูกขยายด้วยสมาชิกใหม่  
สมาชิกใหม่ที่เกี่ยวข้องกับการเปลี่ยนภาพ PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.  
สมาชิกใหม่ที่เกี่ยวข้องกับการเปลี่ยนภาพ PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **คลาส RevealTransition และอินเทอร์เฟซ IRevealTransition ถูกเพิ่ม**
คลาส com.aspose.slides.RevealTransition (และอินเทอร์เฟซ com.aspose.slides.IRevealTransition) เกี่ยวข้องกับประเภทการเปลี่ยนภาพ Reveal ที่รองรับในรุ่นนี้  
คลาส RippleTransition, อินเทอร์เฟซ IRippleTransition และ enumeration TransitionCornerAndCenterDirectionType ถูกเพิ่ม  
คลาส com.aspose.slides.RippleTransition (และอินเทอร์เฟซ com.aspose.slides.IRippleTransition) เกี่ยวข้องกับประเภทการเปลี่ยนภาพ Ripple ที่รองรับในรุ่นนี้  enumeration com.aspose.slides.TransitionCornerAndCenterDirectionType ถูกใช้ในคลาสนี้และระบุทิศทางที่จำกัดให้เป็นมุมและศูนย์กลาง
### **คลาส ShredTransition, อินเทอร์เฟซ IShredTransition และ enumeration TransitionShredPattern ถูกเพิ่ม**
คลาส com.aspose.slides.ShredTransition (และอินเทอร์เฟซ com.aspose.slides.IShredTransition) เกี่ยวข้องกับประเภทการเปลี่ยนภาพ Shred ที่รองรับในรุ่นนี้  enumeration com.aspose.slides.TransitionShredPattern ถูกใช้ในคลาสนี้และระบุรูปทรงเรขาคณิตที่จัดเรียงต่อกันเพื่อเติมพื้นที่ขนาดใหญ่