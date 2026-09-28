---
title: ข้อจำกัดเมตาดาต้าเอาต์พุต
type: docs
weight: 320
url: /th/net/api-limitations/
keywords:
- ข้อจำกัด API
- รูปแบบการส่งออก
- แอปพลิเคชัน
- ผู้ผลิต
- คุณสมบัติของเอกสาร
- เมตาดาต้า
- ตัวสร้าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET จะเขียนเมตาดาต้า application, creator, และ producer แบบคงที่ลงในไฟล์ PPTX, PDF, และ ODP ที่บันทึกไว้ ไม่ว่าคุณจะตั้งชื่อแอปพลิเคชันอย่างไร"
---
## **ภาพรวม**

เมื่อสร้างหรือส่งออกการนำเสนอด้วย Aspose.Slides, ข้อมูลเมตาเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวข้องกับฟิลด์เมตา `Application`, `Creator`, `Producer` และ generator ในไฟล์ PPTX, PDF, และ ODP

## **Application และ Producer**

เมื่อคุณสร้างหรือส่งออกการนำเสนอด้วย Aspose.Slides for .NET, ข้อมูลเมตาเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์มักทำให้เกิดคำถาม:

**Application** ระบุตัวโปรแกรมที่สร้างหรือบันทึกครั้งสุดท้ายของการนำเสนอ **PPTX** ใน Aspose.Slides for .NET ค่านี้เป็นค่าคงที่และแสดงชื่อไลบรารีแทนชื่อแอปของคุณ แม้ว่าคุณจะตั้งค่า [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/)

**Producer** ระบุ engine การเรนเดอร์ที่สร้างไฟล์ขั้นสุดท้ายระหว่างการส่งออก ในการส่งออก **PDF**, เมต้าใช้ฟิลด์ **Creator** และ **Producer** ด้วย Aspose.Slides for .NET ทั้งสองฟิลด์นี้เป็นค่าคงที่และแสดงไลบรารีและเวอร์ชันของมัน

## **สิ่งที่จำกัด**

คุณไม่สามารถเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับฟอร์แมตที่กล่าวมาข้างต้น สำหรับ **PPTX**, คุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for .NET" สำหรับ **PDF**, คุณสมบัติ Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for .NET" ตามด้วยเวอร์ชันของไลบรารี สำหรับ **ODP**, ฟิลด์ generator จะถูกเขียนเป็น "Aspose.Slides for .NET" ตามด้วยเวอร์ชันของไลบรารี พฤติกรรมนี้เป็นการออกแบบและจะใช้ไม่ว่าไฟล์จะถูกโหลดหรือบันทึกอย่างไร และไม่ว่าอะไรจะถูกกำหนดให้กับ [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/)

ข้อจำกัดนี้ไม่ใช้กับไฟล์ **PPT**: ในไฟล์ PPT, ชื่อแอปพลิเคชันที่คุณตั้งค่าใน [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) จะถูกบันทึก.