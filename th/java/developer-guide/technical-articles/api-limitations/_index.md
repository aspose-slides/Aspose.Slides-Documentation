---
title: ข้อจำกัดของ API
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
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "รู้จักข้อจำกัดของ Aspose.Slides for Java: การส่งออกกำหนดเมตาดาต้า Application/Producer ให้คงที่ใน PPT, PPTX, ODP และ PDF—ช่วยให้คุณวางแผนการรวมระบบโดยไม่มีเหตุการณ์ไม่คาดฝัน"
---
## **ภาพรวม**

เมื่อสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides เมตาดาต้าเชิงเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวข้องกับฟิลด์เมตาดาต้า `Application`, `Creator` และ `Producer` ในไฟล์ PPTX และ PDF

## **Application และ Producer**

เมื่อคุณสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides for Java เมตาดาต้าเชิงเทคนิคบางส่วนจะถูกเขียนลงในไฟล์ ฟิลด์สองตัวนี้มักทำให้เกิดคำถามบ่อย:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกครั้งสุดท้ายของงานนำเสนอ **PPTX** ใน Aspose.Slides for Java ค่่านี้ถูกกำหนดคงที่และแสดงผู้จำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้คุณจะใช้[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)

**Producer** ระบุเอนจินการเรนเดอร์ที่สร้างไฟล์สุดท้ายในระหว่างการส่งออก ในการส่งออก **PDF** เมตาดาต้าใช้ฟิลด์ **Creator** และ **Producer** กับ Aspose.Slides for Java ทั้งสองฟิลด์นี้ถูกกำหนดคงที่และสะท้อนไลบรารีและเวอร์ชันของมัน

**สิ่งที่จำกัด**

คุณไม่สามารถเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบข้างต้นได้ สำหรับ **PPTX** คุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for Java" สำหรับ **PDF** คุณสมบัติ Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for Java x.x.x." พฤติกรรมนี้ออกแบบมาเช่นนั้นและจะมีผลไม่ว่าคุณจะโหลดหรือบันทึกไฟล์อย่างไร หรือค่าที่กำหนดโดยการใช้[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)