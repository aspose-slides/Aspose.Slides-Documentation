---
title: ข้อจำกัดของ API
type: docs
weight: 320
url: /th/python-java/api-limitations/
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
- Java
- Aspose.Slides
description: "เรียนรู้เกี่ยวกับข้อจำกัดของ Aspose.Slides for Python via Java: เมตาดาต้า Application, Creator, และ Producer ที่คงที่ในไฟล์ PPTX และ PDF"
---
## **ภาพรวม**

เมื่อการนำเสนอถูกสร้างหรือส่งออกด้วย Aspose.Slides, ข้อมูลเมตาเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวกับฟิลด์เมตาดาต้า `Application`, `Creator`, และ `Producer` ในไฟล์ PPTX และ PDF

## **Application และ Producer**

เมื่อคุณสร้างหรือส่งออกการนำเสนอด้วย Aspose.Slides for Python via Java, ข้อมูลเมตาเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์มักทำให้เกิดคำถาม:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกล่าสุดการนำเสนอ **PPTX** ใน Aspose.Slides for Python via Java ค่าดังกล่าวเป็นค่าคงที่และแสดงผู้จำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้คุณจะใช้[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#setnameofapplication)。

**Producer** ระบุเอนจิ้นการแสดงผลที่สร้างไฟล์สุดท้ายระหว่างการส่งออก ในการส่งออก **PDF** เมตาดาต้าใช้ฟิลด์ **Creator** และ **Producer** กับ Aspose.Slides for Python via Java ทั้งสองฟิลด์เป็นค่าคงที่และสะท้อนไลบรารีและเวอร์ชันของมัน

**ข้อจำกัด**

คุณไม่สามารถเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบข้างต้นได้ สำหรับ **PPTX** คุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for Java" สำหรับ **PDF** คุณสมบัติ Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for Java x.x.x." พฤติกรรมนี้เป็นการออกแบบมาโดยตั้งใจและจะใช้ไม่ว่าคุณจะโหลดหรือบันทึกไฟล์อย่างไร และไม่ว่าค่าที่กำหนดโดย[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#setnameofapplication) จะเป็นเช่นไร

## **คำถามที่พบบ่อย**

**ฉันสามารถแทนที่ค่า Application ในไฟล์ PPTX ด้วยชื่อแอปของฉันได้หรือไม่?**

No. The value is fixed, even if you use[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#setnameofapplication)。

**ฉันสามารถเขียนทับฟิลด์ Creator และ Producer ในการส่งออก PDF ได้หรือไม่?**

No. Both fields are fixed and reflect the library and its version, regardless of how you load or save the presentation.