---
title: ทำให้การแปลโลคัลไลซ์งานนำเสนอเป็นอัตโนมัติใน C++
linktitle: การแปลโลคัลไลซ์งานนำเสนอ
type: docs
weight: 100
url: /th/cpp/presentation-localization/
keywords:
- เปลี่ยนภาษา
- การตรวจสอบการสะกด
- รหัสภาษา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ทำให้การแปลโลคัลไลซ์สไลด์ของ PowerPoint และ OpenDocument ใน C++ โดยใช้ Aspose.Slides อย่างอัตโนมัติ พร้อมตัวอย่างโค้ดและเคล็ดลับเพื่อการเปิดตัวทั่วโลกที่เร็วขึ้น."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการตั้งค่า `LanguageId` สำหรับข้อความในงานพรีเซนเทชันโดยใช้ Aspose.Slides ซึ่งแสดงวิธีการเปิดงานพรีเซนเทชัน, เพิ่มรูปร่างที่มีข้อความ, กำหนดตัวระบุภาษาให้กับส่วนของข้อความ, และบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **เปลี่ยนภาษาสำหรับงานพรีเซนเทชันและข้อความในรูปร่าง**
- สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- เพิ่ม AutoShape ประเภท Rectangle ไปยังสไลด์
- เพิ่มข้อความบางส่วนลงใน TextFrame
- ตั้งค่า Language Id ให้กับข้อความ
- บันทึกงานพรีเซนเทชันเป็นไฟล์ PPTX

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **คำถามที่พบบ่อย**

**การระบุ Language ID ทำให้เกิดการแปลอัตโนมัติของข้อความหรือไม่?**

ไม่. [Language ID](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/) ใน Aspose.Slides จะเก็บข้อมูลภาษาสำหรับการตรวจสอบการสะกดและการตรวจสอบไวยากรณ์ แต่ไม่ได้ทำการแปลหรือเปลี่ยนแปลงเนื้อหาข้อความ มันเป็นเมตาดาต้าที่ PowerPoint เข้าใจเพื่อการตรวจสอบ

**การระบุ Language ID มีผลต่อการแทรก hyphenation และการตัดบรรทัดระหว่างการแสดงผลหรือไม่?**

ใน Aspose.Slides, [Language ID](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/) ใช้สำหรับการตรวจสอบไวยากรณ์. คุณภาพของ hyphenation และการตัดบรรทัดขึ้นอยู่กับการมีอยู่ของ [proper fonts](/slides/th/cpp/powerpoint-fonts/) และการตั้งค่า layout/line-break สำหรับระบบการเขียน. เพื่อให้การแสดงผลถูกต้อง, ให้ทำให้ฟอนต์ที่ต้องการพร้อมใช้งาน, กำหนด [font substitution rules](/slides/th/cpp/font-substitution/), และ/หรือ [embed fonts](/slides/th/cpp/embedded-font/) ลงในงานพรีเซนเทชัน

**ฉันสามารถตั้งค่าภาษาต่างๆ ภายในย่อนเดียวได้หรือไม่?**

ได้. [Language ID](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/) ถูกนำไปใช้ระดับส่วนของข้อความ, ดังนั้นย่อหนึ่งย่อสามารถผสมหลายภาษาโดยมีการตั้งค่าการตรวจสอบไวยากรณ์ที่แตกต่างกันได้