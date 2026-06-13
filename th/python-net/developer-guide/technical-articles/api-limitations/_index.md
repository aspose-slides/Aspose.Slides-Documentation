---
title: ข้อจำกัดของ API
type: docs
weight: 210
url: /th/python-net/api-limitations/
keywords:
- ข้อจำกัดของ API
- รูปแบบการส่งออก
- แอปพลิเคชัน
- ผู้ผลิต
- คุณสมบัติเอกสาร
- เมตาดาต้า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ทราบข้อจำกัดของ Aspose.Slides for Python: การส่งออกตั้งค่าเมตาดาต้า Application/Producer แบบคงที่ในไฟล์ PPT, PPTX, ODP และ PDF—ช่วยให้คุณวางแผนการบูรณาการโดยไม่มีความประหลาดใจ"
---
## **Overview**

เมื่อสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides ข้อมูลเมตาทางเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวกับฟิลด์เมตาดาต้า `Application`, `Creator` และ `Producer` ในไฟล์ PPTX และ PDF

## **Application and Producer**

เมื่อคุณสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides for Python via .NET ข้อมูลเมตาทางเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์ที่มักทำให้เกิดคำถามคือ:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกครั้งล่าสุดของงานนำเสนอ **PPTX** ใน Aspose.Slides for Python via .NET ค่าดังกล่าวถูกกำหนดไว้ตายตัวและแสดงผู้จำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้คุณจะตั้งค่า [DocumentProperties.name_of_application](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/name_of_application/) ก็ตาม

**Producer** ระบุเอนจิ้นการเรนเดอร์ที่สร้างไฟล์ขั้นสุดท้ายระหว่างการส่งออก ในการส่งออก **PDF** เมตาดาต้าใช้ฟิลด์ **Creator** และ **Producer** กับ Aspose.Slides for Python via .NET ทั้งสองฟิลด์นี้ถูกกำหนดไว้ตายตัวและสะท้อนไลบรารีและเวอร์ชันของมัน

**What’s restricted**

คุณไม่สามารถแทนที่ฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบที่กล่าวมาข้างต้นได้ สำหรับ **PPTX** คุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for Python via .NET" สำหรับ **PDF** คุณสมบัติ Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for Python via .NET x.x.x" พฤติกรรมนี้เป็นการออกแบบโดยตั้งใจและใช้ได้ไม่ว่าคุณจะโหลดหรือบันทึกไฟล์อย่างไร หรือค่าที่กำหนดให้กับ [DocumentProperties.name_of_application](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/name_of_application/) จะเป็นอย่างไรก็ตาม