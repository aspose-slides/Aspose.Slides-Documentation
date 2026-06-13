---
title: ข้อจำกัดของ API
type: docs
weight: 320
url: /th/net/api-limitations/
keywords:
- ข้อจำกัดของ API
- รูปแบบการส่งออก
- แอปพลิเคชัน
- ผู้ผลิต
- คุณสมบัติเอกสาร
- เมตาดาต้า
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "รู้จักข้อจำกัดของ Aspose.Slides for .NET: การส่งออกตั้งค่าข้อมูลเมตา Application/Producer แบบคงที่ใน PPT, PPTX, ODP, และ PDF—ช่วยให้คุณวางแผนการรวมระบบได้โดยไม่มีความประหลาดใจ."
---
## **ภาพรวม**

เมื่อการนำเสนอถูกสร้างหรือส่งออกด้วย Aspose.Slides, ข้อมูลเมตาเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวกับฟิลด์เมตา `Application`, `Creator` และ `Producer` ในไฟล์ PPTX และ PDF

## **แอปพลิเคชันและผู้ผลิต**

เมื่อคุณสร้างหรือส่งออกการนำเสนอด้วย Aspose.Slides for .NET, ข้อมูลเมตาเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์มักทำให้เกิดคำถาม:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกรายการนำเสนอ **PPTX** ครั้งล่าสุด ใน Aspose.Slides for .NET ค่าที่นี้เป็นค่าคงที่และแสดงผู้จัดจำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้ว่าคุณจะตั้งค่า [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/th/net/aspose.slides/documentproperties/nameofapplication/) ก็ตาม

**Producer** ระบุเครื่องยนต์การเรนเดอร์ที่สร้างไฟล์ขั้นสุดท้ายระหว่างการส่งออก ในการส่งออก **PDF**, เมตาใช้ฟิลด์ **Creator** และ **Producer** ด้วย Aspose.Slides for .NET ทั้งสองฟิลด์นี้เป็นค่าคงที่และสะท้อนไลบรารีและเวอร์ชันของมัน

**สิ่งที่จำกัด**

คุณไม่สามารถทำการเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบที่กล่าวมาข้างต้นได้ สำหรับ **PPTX**, คุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for .NET" สำหรับ **PDF**, คุณสมบัติ Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for .NET x.x.x" พฤติกรรมนี้ออกแบบมาโดยเจตนาและใช้ได้ไม่ว่าคุณจะโหลดหรือบันทึกไฟล์อย่างไรและไม่ว่าค่าที่กำหนดให้กับ [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/th/net/aspose.slides/documentproperties/nameofapplication/) จะเป็นอะไร