---
title: แปลง PPTX เป็น PPT ด้วย Java
linktitle: PPTX เป็น PPT
type: docs
weight: 21
url: /th/java/convert-pptx-to-ppt/
keywords:
- แปลง PowerPoint
- แปลงพรีเซนเทชัน
- แปลงสไลด์
- แปลง PPTX
- PPTX เป็น PPT
- บันทึก PPTX เป็น PPT
- ส่งออก PPTX เป็น PPT
- PowerPoint
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "ง่ายต่อการแปลง PPTX เป็น PPT ด้วย Aspose.Slides สำหรับ Java—รับประกันความเข้ากันได้อย่างไร้รอยต่อกับรูปแบบ PowerPoint พร้อมคงรักษาเค้าโครงและคุณภาพของพรีเซนเทชันของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงไฟล์พรีเซนเทชัน PowerPoint ในรูปแบบ PPTX เป็นรูปแบบ PPT ด้วย Java หัวข้อที่ครอบคลุมต่อไปนี้

- แปลง PPTX เป็น PPT ใน Java

## **แปลง PPTX เป็น PPT ใน Java**

สำหรับตัวอย่างโค้ด Java ที่ใช้แปลง PPTX เป็น PPT โปรดดูส่วนด้านล่าง เช่น [Convert PPTX to PPT](#convert-pptx-to-ppt) ตัวอย่างนี้เพียงโหลดไฟล์ PPTX แล้วบันทึกในรูปแบบ PPT โดยการระบุรูปแบบการบันทึกที่ต่างกัน คุณยังสามารถบันทึกไฟล์ PPTX ไปยังรูปแบบอื่น ๆ เช่น PDF, XPS, ODP, HTML เป็นต้น ตามที่อธิบายในบทความเหล่านี้  

- [แปลง PPTX เป็น PDF ใน Java](/slides/th/java/convert-powerpoint-to-pdf/)
- [แปลง PPTX เป็น XPS ใน Java](/slides/th/java/convert-powerpoint-to-xps/)
- [แปลง PPTX เป็น HTML ใน Java](/slides/th/java/convert-powerpoint-to-html/)
- [แปลง PPTX เป็น ODP ใน Java](/slides/th/java/save-presentation/)
- [แปลง PPTX เป็น PNG ใน Java](/slides/th/java/convert-powerpoint-to-png/)

## **แปลง PPTX เป็น PPT**
เพื่อแปลง PPTX เป็น PPT เพียงส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด **Save** ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ตัวอย่างโค้ด Java ด้านล่างจะแปลง Presentation จาก PPTX เป็น PPT ด้วยตัวเลือกเริ่มต้น

```java
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation presentation = new Presentation("template.pptx");

// บันทึกพรีเซนเทชันเป็น PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **คำถามที่พบบ่อย**

**เอฟเฟกต์และคุณลักษณะทั้งหมดของ PPTX จะคงอยู่เมื่อบันทึกเป็นรูปแบบ PPT รุ่นเก่า (97–2003) หรือไม่?**

ไม่เสมอไป รูปแบบ PPT ขาดคุณสมบัติบางอย่างที่ใหม่กว่า (เช่น เอฟเฟกต์บางอย่าง, วัตถุ, และพฤติกรรม) ทำให้คุณลักษณะอาจถูกทำให้เรียบง่ายหรือแปลงเป็นภาพระบิดในกระบวนการแปลง

**ฉันสามารถแปลงเฉพาะสไลด์ที่เลือกเป็น PPT แทนที่จะเป็นการนำเสนอทั้งหมดได้หรือไม่?**

การบันทึกโดยตรงจะทำงานกับการนำเสนอทั้งหมด หากต้องการแปลงสไลด์เฉพาะ ให้สร้างการนำเสนอใหม่ที่มีสไลด์เหล่านั้นแล้วบันทึกเป็น PPT หรือใช้บริการ/API ที่รองรับพารามิเตอร์การแปลงต่อสไลด์

**การนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตรวจสอบว่าไฟล์ถูกป้องกันหรือไม่ เปิดไฟล์ด้วยรหัสผ่าน และยังสามารถ [กำหนดค่าการป้องกัน/การเข้ารหัส](/slides/th/java/password-protected-presentation/) สำหรับ PPT ที่บันทึกได้.