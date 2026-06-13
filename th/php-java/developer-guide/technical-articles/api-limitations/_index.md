---
title: ข้อจำกัดของ API
type: docs
weight: 320
url: /th/php-java/api-limitations/
keywords:
- ข้อจำกัดของ API
- รูปแบบการส่งออก
- แอปพลิเคชัน
- ผู้ผลิต
- คุณสมบัติของเอกสาร
- เมทาดาต้า
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ทราบข้อจำกัดของ Aspose.Slides for PHP: การส่งออกกำหนดเมตาดาต้า Application/Producer ที่คงที่ในไฟล์ PPT, PPTX, ODP และ PDF—ช่วยให้คุณวางแผนการบูรณาการได้โดยไม่มีเซอร์ไพรส์"
---
## **Overview**

เมื่อการนำเสนอถูกสร้างหรือส่งออกด้วย Aspose.Slides ข้อมูลเมตาเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ผลลัพธ์ บทความนี้อธิบายข้อจำกัดที่เกี่ยวข้องกับฟิลด์เมตาดาต้า `Application`, `Creator` และ `Producer` ในไฟล์ PPTX และ PDF

## **Application and Producer**

เมื่อคุณสร้างหรือส่งออกการนำเสนอด้วย Aspose.Slides for PHP via Java ข้อมูลเมตาเทคนิคบางอย่างจะถูกเขียนลงในไฟล์ ฟิลด์สองฟิลด์มักทำให้เกิดคำถาม:

**Application** ระบุโปรแกรมที่สร้างหรือบันทึกการนำเสนอ **PPTX** ครั้งล่าสุด ใน Aspose.Slides for PHP via Java ค่าดังกล่าวถูกกำหนดคงที่และแสดงผู้จัดจำหน่ายไลบรารีแทนชื่อแอปของคุณ แม้ว่าคุณจะใช้ [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/setnameofapplication/)

**Producer** ระบุเครื่องยนต์การเรนเดอร์ที่สร้างไฟล์ขั้นสุดท้ายระหว่างการส่งออก ในการส่งออก **PDF** เมตาดาต้าใช้ฟิลด์ **Creator** และ **Producer** ด้วย Aspose.Slides for PHP via Java ทั้งสองฟิลด์นี้ถูกกำหนดคงที่และสะท้อนไลบรารีพร้อมเวอร์ชันของมัน

**ข้อจำกัด**

คุณไม่สามารถเขียนทับฟิลด์เหล่านี้ผ่าน API สำหรับรูปแบบที่กล่าวมาข้างต้นได้ สำหรับ **PPTX** property Application จะถูกเขียนเป็น "Aspose.Slides for PHP via Java" สำหรับ **PDF** property Creator และ Producer จะถูกเขียนเป็น "Aspose.Slides for PHP via Java x.x.x." พฤติลักษณะนี้เป็นการออกแบบโดยเจตนาและใช้ได้ไม่ว่าคุณจะโหลดหรือบันทึกไฟล์อย่างไร หรือไม่ว่าค่าที่กำหนดโดยการใช้ [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/setnameofapplication/) จะเป็นอย่างไร