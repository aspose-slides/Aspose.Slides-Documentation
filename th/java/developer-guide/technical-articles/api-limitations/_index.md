---
title: ข้อจำกัดของเมตาดาต้าเอาต์พุต
type: docs
weight: 320
url: /th/java/api-limitations/
keywords:
- ข้อจำกัดของ API
- รูปแบบการส่งออก
- แอปพลิเคชัน
- ผู้ผลิต
- คุณสมบัติของเอกสาร
- เมตาดาต้า
- เครื่องสร้าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "Aspose.Slides for Java จะเขียนเมตาดาต้าแอปพลิเคชัน, ผู้สร้าง, และผู้ผลิตแบบคงที่ลงในไฟล์ PPTX, PDF และ ODP ที่บันทึก ซึ่งไม่ขึ้นกับชื่อแอปพลิเคชันที่คุณตั้งค่า"
---
## **ภาพรวม**

เมื่อสร้างหรือส่งออกรายการนำเสนอด้วย Aspose.Slides ข้อมูลเมทาดาต้าเชิงเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวกับฟิลด์เมทาดาต้า `Application`, `Creator`, `Producer` และ generator ในไฟล์ PPTX, PDF และ ODP

## **แอปพลิเคชันและผู้ผลิต**

เมื่อคุณสร้างหรือส่งออกรายการนำเสนอด้วย Aspose.Slides for Java ข้อมูลเมทาดาต้าเชิงเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์มักทำให้เกิดคำถาม:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกรายการนำเสนอ **PPTX** ครั้งล่าสุด ใน Aspose.Slides for Java ค่านี้ถูกกำหนดคงที่และแสดงชื่อไลบรารีแทนชื่อแอปของคุณ แม้ว่าคุณจะใช้ [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)

**Producer** ระบุเอนจินเรนเดอร์ที่สร้างไฟล์สุดท้ายระหว่างการส่งออก ในการส่งออก **PDF** เมทาดาต้าใช้ฟิลด์ **Creator** และ **Producer** ด้วย Aspose.Slides for Java ทั้งสองฟิลด์นี้ถูกกำหนดคงที่และสอดคล้องกับไลบรารีและเวอร์ชันของมัน

**สิ่งที่จำกัด**

คุณไม่สามารถเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบข้างต้นได้ สำหรับ **PPTX** ค่าของคุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for Java" สำหรับ **PDF** ค่าของคุณสมบัติ Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for Java" ตามด้วยเวอร์ชันของไลบรารี สำหรับ **ODP** ฟิลด์ generator จะถูกเขียนเป็น "Aspose.Slides for Java" ตามด้วยเวอร์ชันของไลบรารี พฤติกรรมนี้เป็นการออกแบบและใช้ได้ไม่ว่าจะโหลดหรือบันทึกไฟล์อย่างไร และไม่ว่าจะกำหนดค่าใด ๆ ด้วย [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)

ข้อจำกัดนี้ไม่ได้ใช้กับไฟล์ **PPT**: ในไฟล์ PPT ชื่อแอปพลิเคชันที่คุณตั้งค่าด้วย [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) จะถูกบันทึกไว้