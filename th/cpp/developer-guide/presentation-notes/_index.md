---
title: จัดการบันทึกการนำเสนอใน C++
linktitle: บันทึกการนำเสนอ
type: docs
weight: 110
url: /th/cpp/presentation-notes/
keywords:
- บันทึก
- สไลด์บันทึก
- เพิ่มบันทึก
- ลบบันทึก
- สไตล์บันทึก
- บันทึกหลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งบันทึกการนำเสนอด้วย Aspose.Slides สำหรับ C++. ทำงานกับบันทึก PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์บันทึกจากงานนำเสนอ ในหัวข้อนี้ เราจะอธิบายคุณลักษณะนี้ รวมถึงวิธีลบบันทึกและวิธีใช้สไตล์ให้กับสไลด์บันทึกในงานนำเสนอ Aspose.Slides อนุญาตให้คุณลบบันทึกจากสไลด์ใดก็ได้และยังสามารถใช้การจัดรูปแบบกับบันทึกที่มีอยู่ได้ นักพัฒนาสามารถลบบันทึกได้ตามวิธีต่อไปนี้:

- ลบบันทึกจากสไลด์เฉพาะในงานนำเสนอ
- ลบบันทึกจากสไลด์ทั้งหมดในงานนำเสนอ

## **ลบบันทึกจากสไลด์เฉพาะ**
บันทึกของสไลด์ที่กำหนดสามารถลบได้ตามตัวอย่างด้านล่าง:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **ลบบันทึกจากสไลด์ทั้งหมด**
บันทึกของสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **เพิ่มสไตล์บันทึก**
คุณสมบัติ NotesStyle ได้ถูกเพิ่มเข้าไปในอินเตอร์เฟซ IMasterNotesSlide และคลาส MasterNotesSlide ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความบันทึก การทำงานถูกแสดงในตัวอย่างด้านล่าง.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **คำถามที่พบบ่อย**

**ออบเจ็กต์ API ใดที่ให้เข้าถึงบันทึกของสไลด์เฉพาะ?**

บันทึกจะเข้าถึงผ่านผู้จัดการบันทึกของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/cpp/aspose.slides/notesslidemanager/get_notesslide/) ที่คืนค่าอ็อบเจกต์บันทึก หรือ `null` หากไม่มีบันทึก

**มีความแตกต่างในการสนับสนุนบันทึกระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานหรือไม่?**

ไลบรารีนี้รองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่ 97 จนถึงรุ่นใหม่) และ ODP; บันทึกได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องอิงกับการติดตั้ง PowerPoint.