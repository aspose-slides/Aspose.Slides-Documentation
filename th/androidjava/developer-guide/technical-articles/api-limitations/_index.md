---
title: ข้อจำกัด API
type: docs
weight: 320
url: /th/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "รู้จักข้อจำกัดของ Aspose.Slides for Android: การส่งออกตั้งค่าข้อมูลเมตา Application/Producer อย่างคงที่ใน PPT, PPTX, ODP และ PDF—ช่วยให้คุณวางแผนการผสานได้โดยไม่มีความประหลาดใจ."
---
## **ภาพรวม**

เมื่อสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides จะมีข้อมูลเมตาเทคนิคบางอย่างถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวข้องกับฟิลด์เมตา `Application`, `Creator` และ `Producer` ในไฟล์ PPTX และ PDF

## **Application และ Producer**

เมื่อคุณสร้างหรือส่งออกงานนำเสนอด้วย Aspose.Slides for Android via Java ข้อมูลเมตาเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์มักทำให้เกิดคำถาม:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกงานนำเสนอ **PPTX** ครั้งล่าสุด ใน Aspose.Slides for Android via Java ค่าตัวนี้ถูกกำหนดไว้ล่วงหน้าและแสดงผู้จัดจำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้ว่าคุณจะใช้[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)ก็ตาม

**Producer** ระบุเอนจินการเรนเดอร์ที่สร้างไฟล์สุดท้ายในระหว่างการส่งออก ในการส่งออก **PDF** เมตาจะใช้ฟิลด์ **Creator** และ **Producer** กับ Aspose.Slides for Android via Java ทั้งสองฟิลด์นี้ถูกกำหนดไว้ล่วงหน้าและบ่งบอกไลบรารีและเวอร์ชันของมัน

**สิ่งที่จำกัด**

คุณไม่สามารถเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบที่กล่าวมาข้างต้นได้ สำหรับ **PPTX** ค่าของคุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for Android via Java" สำหรับ **PDF** ค่า Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for Android via Java x.x.x." พฤติกรรมนี้เป็นการออกแบบและจะเกิดขึ้นไม่ว่าคุณจะโหลดหรือบันทึกไฟล์อย่างไร หรือค่าที่กำหนดโดยการใช้[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).