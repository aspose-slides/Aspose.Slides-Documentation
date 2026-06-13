---
title: รูปร่างการนำเสนอแบบกลุ่มใน C++
linktitle: กลุ่มรูปร่าง
type: docs
weight: 40
url: /th/cpp/group/
keywords:
- รูปร่างกลุ่ม
- กลุ่มรูปร่าง
- เพิ่มกลุ่ม
- ข้อความแทน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดกลุ่มและยกเลิกการจัดกลุ่มรูปร่างในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++ — คำแนะนำทีละขั้นตอนที่เร็วและฟรีพร้อมโค้ด C++"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับรูปร่างกลุ่มใน Aspose.Slides แสดงวิธีการเพิ่มรูปร่างกลุ่มลงในสไลด์ วางรูปร่างภายใน และบันทึกรันการนำเสนอที่อัปเดต นอกจากนี้ยังสาธิตวิธีการเข้าถึงรูปร่างที่เก็บไว้ในกลุ่มและอ่านค่า `AlternativeText` ของพวกมัน อีกทั้งบทความยังสรุปคุณสมบัติที่เกี่ยวข้องของรูปร่างกลุ่ม เช่น กลุ่มซ้อนกัน ลำดับ z‑order และตัวเลือกการล็อกสั้นๆ

## **เพิ่มรูปร่างกลุ่ม**
Aspose.Slides รองรับการทำงานกับรูปร่างกลุ่มบนสไลด์ ฟีเจอร์นี้ช่วยให้นักพัฒนาสร้างการนำเสนอที่มีความหลากหลายมากขึ้น Aspose.Slides for C++ รองรับการเพิ่มหรือเข้าถึงรูปร่างกลุ่ม สามารถเพิ่มรูปร่างลงในรูปร่างกลุ่มที่เพิ่มไว้เพื่อเติมข้อมูลหรือเข้าถึงคุณสมบัติใด ๆ ของรูปร่างกลุ่ม เพื่อเพิ่มรูปร่างกลุ่มลงในสไลด์โดยใช้ Aspose.Slides for C++:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงของสไลด์โดยใช้ Index
1. เพิ่มรูปร่างกลุ่มลงในสไลด์
1. เพิ่มรูปร่างลงในรูปร่างกลุ่มที่เพิ่มไว้
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มรูปร่างกลุ่มลงในสไลด์

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **เข้าถึงคุณสมบัติ AltText**
หัวข้อนี้แสดงขั้นตอนง่าย ๆ พร้อมตัวอย่างโค้ด สำหรับการเพิ่มรูปร่างกลุ่มและการเข้าถึงคุณสมบัติ AltText ของรูปร่างกลุ่มบนสไลด์ เพื่อเข้าถึง AltText ของรูปร่างกลุ่มในสไลด์โดยใช้ Aspose.Slides for C++:

1. สร้างอินสแตนซ์ของคลาส `Presentation` ที่เป็นตัวแทนไฟล์ PPTX
1. รับอ้างอิงของสไลด์โดยใช้ Index
1. เข้าถึงคอลเลกชันของรูปร่างบนสไลด์
1. เข้าถึงรูปร่างกลุ่ม
1. เข้าถึงคุณสมบัติ AltText

ตัวอย่างด้านล่างเข้าถึงข้อความแทนของรูปร่างกลุ่ม

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

ใช่. [GroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/groupshape/) มีเมธอด [get_ParentGroup](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/get_parentgroup/) ซึ่งบ่งชี้การสนับสนุนโครงสร้างแบบลำดับชั้นโดยตรง (กลุ่มหนึ่งสามารถเป็นลูกของกลุ่มอื่นได้).

**How do I control the group’s z-order relative to other objects on the slide?**

ใช้ [GroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/groupshape/)’s [Z-Order position](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/get_zorderposition/) เพื่อดูตำแหน่งของมันในลำดับการแสดงผล.

**Can I prevent moving/editing/ungrouping?**

ใช่. ส่วนล็อกของกลุ่มเปิดเผยผ่าน [get_GroupShapeLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/groupshape/get_groupshapelock/) ซึ่งทำให้คุณสามารถจำกัดการดำเนินการบนวัตถุได้.