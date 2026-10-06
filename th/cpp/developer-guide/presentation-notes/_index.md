---
title: จัดการโน้ตการนำเสนอใน C++
linktitle: โน้ตการนำเสนอ
type: docs
weight: 110
url: /th/cpp/presentation-notes/
keywords:
- โน้ต
- สไลด์โน้ต
- เพิ่มโน้ต
- ลบโน้ต
- สไตล์โน้ต
- โน้ตมาสเตอร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งโน้ตการนำเสนอด้วย Aspose.Slides สำหรับ C++ ทำงานร่วมกับโน้ต PowerPoint และ OpenDocument อย่างไร้รอยต่อเพื่อเพิ่มประสิทธิภาพของคุณ"
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์โน้ตออกจากงานนำเสนอ ในหัวข้อนี้ เราจะนำเสนอคุณลักษณะนี้ รวมถึงวิธีการลบโน้ตและวิธีการใช้สไตล์กับสไลด์โน้ตในงานนำเสนอ Aspose.Slides ให้คุณลบโน้ตจากสไลด์ใดก็ได้และยังสามารถกำหนดรูปแบบให้กับโน้ตที่มีอยู่ได้ นักพัฒนาสามารถลบโน้ตได้หลายวิธีดังต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในงานนำเสนอ
- ลบโน้ตจากสไลด์ทั้งหมดในงานนำเสนอ

เพื่ออ่านหรือเปลี่ยนขนาดหน้ากระดาษโน้ต เปลี่ยนแนวด้าน และตรวจสอบพฤติกรรมการส่งออก ดูที่ [Notes Page Size](/slides/th/cpp/notes-size/)

## **ลบโน้ตจากสไลด์เฉพาะ**
โน้ตจากสไลด์เฉพาะสามารถลบได้ตามตัวอย่างด้านล่าง:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **ลบโน้ตจากสไลด์ทั้งหมด**
โน้ตจากสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **เพิ่มสไตล์โน้ต**
คุณสมบัติ NotesStyle ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ IMasterNotesSlide และคลาส MasterNotesSlide คุณสมบัตินี้กำหนดสไตล์ของข้อความโน้ต การใช้งานถูกสาธิตในตัวอย่างด้านล่าง

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### องค์ประกอบ API ใดที่ให้การเข้าถึงโน้ตของสไลด์เฉพาะ?

โน้ตสามารถเข้าถึงได้ผ่านผู้จัดการโน้ตของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/cpp/aspose.slides/notesslidemanager/get_notesslide/) ที่คืนค่าออบเจ็กต์โน้ต หรือ `null` หากไม่มีโน้ต

### มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานกับหรือไม่?

ไลบรารีรองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (97‑ใหม่กว่า) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint