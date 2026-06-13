---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.7.0
linktitle: Aspose.Slides สำหรับ .NET 14.7.0
type: docs
weight: 90
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้ระบบเสียหายใน Aspose.Slides สำหรับ .NET เพื่อการย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) หรือ[removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำมาพร้อมกับ Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **ลบคอนสตรัคเตอร์และองค์ประกอบ**
#### **ลบคอนสตรัคเตอร์ของบาง Subtype ของ TransitionValueBase และ TransitionValueFactory**
คอนสตรัคเตอร์ของบาง Subtype ของ TransitionValueBase (โดยเฉพาะ CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) ไม่มีประโยชน์ใน Public API ดังนั้นจึงถูกลบออก

คลาสที่เกี่ยวข้อง TransitionValueFactory และอินเทอร์เฟซ ITransitionValueFactory ถูกลบออกด้วยเหตุผลเดียวกัน

#### **ลบองค์ประกอบ SoundAction จากการนับจำนวน Aspose.Slides.SlideShow.TransitionType**
องค์ประกอบ SoundAction ไม่ถูกต้องและไม่ได้ใช้ การตั้งค่าเสียงถูกกำหนดโดยคุณสมบัติ SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName

### **เพิ่มคลาสและอินเทอร์เฟซ**
#### **เพิ่มคลาส FlyThroughTransition และอินเทอร์เฟซ IFlyThroughTransition**
คลาส Aspose.Slides.SlideShow.FlyThroughTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IFlyThroughTransition) เกี่ยวข้องกับประเภทการเปลี่ยนผ่าน Flythrough ที่สนับสนุนตั้งแต่รุ่นนี้

#### **เพิ่มคลาส GlitterTransition, อินเทอร์เฟซ IGlitterTransition และการนับจำนวน TransitionPattern**
คลาส Aspose.Slides.SlideShow.GlitterTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IGlitterTransition) เกี่ยวข้องกับประเภทการเปลี่ยนผ่าน Glitter ที่สนับสนุนตั้งแต่รุ่นนี้

การนับจำนวน Aspose.Slides.SlideShow.TransitionPattern ถูกใช้ในคลาสนี้และระบุรูปแบบเรขาคณิตที่ต่อกันเพื่อเติมพื้นที่ขนาดใหญ่

#### **เพิ่มคลาส LeftRightDirectionTransition, อินเทอร์เฟซ ILeftRightDirectionTransition และการนับจำนวน TransitionLeftRightDirectionType**
คลาส Aspose.Slides.SlideShow.LeftRightDirectionTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.ILeftRightDirectionTransition) เกี่ยวข้องกับประเภทการเปลี่ยนผ่าน Conveyor, Ferris, Flip, Gallery และ Switch ทั้งหมดรองรับตั้งแต่รุ่นนี้

การนับจำนวน Aspose.Slides.SlideShow.TransitionLeftRightDirectionType ถูกใช้ในคลาสนี้และระบุทิศทางที่จำกัดไว้ที่ค่าซ้ายและขวา

#### **เพิ่มองค์ประกอบใหม่ในการนับจำนวน Aspose.Slides.SlideShow.TransitionType**
การนับจำนวน Aspose.Slides.SlideShow.TransitionType ได้รับการขยายด้วยองค์ประกอบใหม่

- องค์ประกอบใหม่ที่เกี่ยวข้องกับการเปลี่ยนผ่านของ PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window
- องค์ประกอบใหม่ที่เกี่ยวข้องกับการเปลี่ยนผ่านของ PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind

#### **เพิ่มคลาส RevealTransition และอินเทอร์เฟซ IRevealTransition**
คลาส Aspose.Slides.SlideShow.RevealTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IRevealTransition) เกี่ยวข้องกับประเภทการเปลี่ยนผ่าน Reveal ที่สนับสนุนตั้งแต่รุ่นนี้

#### **เพิ่มคลาส RippleTransition, อินเทอร์เฟซ IRippleTransition และการนับจำนวน TransitionCornerAndCenterDirectionType**
คลาส Aspose.Slides.SlideShow.RippleTransition (และอินเทอร์เฟซ Aspose.Slides.SlideShow.IRippleTransition) เกี่ยวข้องกับประเภทการเปลี่ยนผ่าน Ripple ที่สนับสนุนตั้งแต่รุ่นนี้

การนับจำนวน Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType ถูกใช้ในคลาสนี้และระบุทิศทางที่จำกัดไว้ที่มุมและศูนย์กลาง