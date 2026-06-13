---
title: ข้อจำกัดของ API
type: docs
weight: 320
url: /th/cpp/api-limitations/
keywords:
- ข้อจำกัดของ API
- รูปแบบการส่งออก
- แอปพลิเคชัน
- ผู้ผลิต
- คุณสมบัติของเอกสาร
- ข้อมูลเมตา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ทราบข้อจำกัดของ Aspose.Slides for C++: การส่งออกกำหนดเมตาดาต้า Application/Producer แบบคงที่ในรูปแบบ PPT, PPTX, ODP, และ PDF—ช่วยให้คุณวางแผนการรวมระบบได้โดยไม่มีความประหลาดใจ"
---
## **ภาพรวม**

เมื่อสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides ข้อมูลเมตาเทคนิคบางส่วนจะถูกบันทึกลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวข้องกับฟิลด์เมตา `Application`, `Creator` และ `Producer` ในไฟล์ PPTX และ PDF

## **Application และ Producer**

เมื่อคุณสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides for C++ ข้อมูลเมตาเทคนิคบางส่วนจะถูกบันทึกลงในไฟล์ ฟิลด์สองรายการมักทำให้เกิดคำถาม:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกล่าสุดของงานนำเสนอ **PPTX** ใน Aspose.Slides for C++ ค่าดังกล่าวถูกกำหนดเป็นค่าคงที่และแสดงผู้จัดจำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้คุณจะใช้[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/th/cpp/aspose.slides/documentproperties/set_nameofapplication/)

**Producer** ระบุเอนจินการเรนเดอร์ที่สร้างไฟล์ขั้นสุดท้ายระหว่างการส่งออก ในการส่งออก **PDF** ข้อมูลเมตาใช้ฟิลด์ **Creator** และ **Producer** ด้วย Aspose.Slides for C++ ทั้งสองฟิลด์นี้เป็นค่าคงที่และสะท้อนไลบรารีพร้อมเวอร์ชันของมัน

## **สิ่งที่จำกัด**

คุณไม่สามารถทำการแทนที่ฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบดังกล่าวได้ สำหรับ **PPTX** ค่าคุณสมบัติ Application จะถูกบันทึกเป็น “Aspose.Slides for C++” สำหรับ **PDF** ค่าคุณสมบัติ Creator และ Producer จะถูกบันทึกเป็น “Aspose.Slides for C++ x.x.x” พฤติกรรมนี้เป็นการออกแบบมาโดยตั้งใจและจะใช้ไม่ว่าคุณจะโหลดหรือบันทึกไฟล์อย่างไร รวมถึงไม่ว่าโค้ดจะตั้งค่าโดยใช้[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/th/cpp/aspose.slides/documentproperties/set_nameofapplication/)