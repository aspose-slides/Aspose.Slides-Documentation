---
title: ข้อจำกัดของ API
type: docs
weight: 320
url: /th/nodejs-java/api-limitations/
keywords:
- ข้อจำกัดของ API
- รูปแบบการส่งออก
- แอปพลิเคชัน
- ผู้ผลิต
- คุณสมบัติของเอกสาร
- เมตาดาต้า
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "รู้จักข้อจำกัดของ Aspose.Slides for Node.js: การส่งออกรายการกำหนดเมตาดาต้า Application/Producer แบบคงที่ในไฟล์ PPT, PPTX, ODP และ PDF—ช่วยให้คุณวางแผนการผสานรวมโดยไม่มีความประหลาดใจ."
---
## **ภาพรวม**

เมื่อการนำเสนอถูกสร้างหรือส่งออกด้วย Aspose.Slides, ข้อมูลเมตาเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวข้องกับฟิลด์เมตา `Application`, `Creator`, และ `Producer` ในไฟล์ PPTX และ PDF

## **Application และ Producer**

เมื่อคุณสร้างหรือส่งออกการนำเสนอด้วย Aspose.Slides for Node.js via Java, ข้อมูลเมตาเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์มักทำให้เกิดคำถาม:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกครั้งสุดท้ายของการนำเสนอ **PPTX** ใน Aspose.Slides for Node.js via Java ค่าดังกล่าวเป็นค่าคงที่และแสดงผู้จัดจำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้คุณจะใช้ [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** ระบุเอนจินการเรนเดอร์ที่สร้างไฟล์สุดท้ายระหว่างการส่งออก ในการส่งออก **PDF**, เมตาใช้ฟิลด์ **Creator** และ **Producer** กับ Aspose.Slides for Node.js via Java ทั้งสองฟิลด์นี้เป็นค่าคงที่และสะท้อนไลบรารีและเวอร์ชันของมัน

## **สิ่งที่ถูกจำกัด**

คุณไม่สามารถเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบข้างต้นได้ สำหรับ **PPTX**, คุณสมบัติ Application จะถูกเขียนเป็น "Aspose.Slides for Node.js via Java" สำหรับ **PDF**, คุณสมบัติ Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for Node.js via Java x.x.x." พฤติกรรมนี้เป็นการออกแบบมาโดยเฉพาะและใช้ได้โดยไม่คำนึงว่าคุณโหลดหรือบันทึกไฟล์อย่างไรและไม่คำนึงค่าที่กำหนดโดยใช้ [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).