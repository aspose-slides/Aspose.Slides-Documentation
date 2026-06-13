---
title: แปลง PPTX เป็น PPT บน Android
linktitle: PPTX เป็น PPT
type: docs
weight: 21
url: /th/androidjava/convert-pptx-to-ppt/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPTX
- PPTX เป็น PPT
- บันทึก PPTX เป็น PPT
- ส่งออก PPTX เป็น PPT
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลง PPTX เป็น PPT อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java—รับรองความเข้ากันได้อย่างราบรื่นกับรูปแบบ PowerPoint พร้อมคงรักษาโครงร่างและคุณภาพของการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลง PowerPoint Presentation ในรูปแบบ PPTX เป็นรูปแบบ PPT ด้วย Java หัวข้อที่ครอบคลุมมีดังต่อไปนี้

- แปลง PPTX เป็น PPTด้วย Java

## **แปลง PPTX เป็น PPT บน Android**

สำหรับตัวอย่างโค้ด Java ที่แปลง PPTX เป็น PPT โปรดดูส่วนต่อไปนี้ คือ [แปลง PPTX เป็น PPT](#convert-pptx-to-ppt) มันทำการโหลดไฟล์ PPTX แล้วบันทึกเป็นรูปแบบ PPT โดยการระบุรูปแบบการบันทึกที่แตกต่าง คุณยังสามารถบันทึกไฟล์ PPTX เป็นรูปแบบอื่น ๆ เช่น PDF, XPS, ODP, HTML เป็นต้น ตามที่ได้อธิบายไว้ในบทความเหล่านี้

- [แปลง PPTX เป็น PDF บน Android](/slides/th/androidjava/convert-powerpoint-to-pdf/)
- [แปลง PPTX เป็น XPS บน Android](/slides/th/androidjava/convert-powerpoint-to-xps/)
- [แปลง PPTX เป็น HTML บน Android](/slides/th/androidjava/convert-powerpoint-to-html/)
- [แปลง PPTX เป็น ODP บน Android](/slides/th/androidjava/save-presentation/)
- [แปลง PPTX เป็น PNG บน Android](/slides/th/androidjava/convert-powerpoint-to-png/)

## **แปลง PPTX เป็น PPT**
เพื่อแปลง PPTX เป็น PPT เพียงส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด **Save** ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ตัวอย่างโค้ด Java ด้านล่างจะแปลง Presentation จาก PPTX เป็น PPT ด้วยตัวเลือกเริ่มต้น

```java
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation presentation = new Presentation("template.pptx");

// บันทึกการนำเสนอเป็น PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **คำถามที่พบบ่อย**

**เอฟเฟกต์และฟีเจอร์ทั้งหมดของ PPTX จะคงอยู่เมื่อบันทึกเป็นรูปแบบ PPT รุ่นเก่า (97–2003) หรือไม่?**

ไม่เสมอไป รูปแบบ PPT ขาดความสามารถใหม่บางอย่าง (เช่น เอฟเฟกต์บางอย่าง, วัตถุ, และพฤติกรรม) ดังนั้นฟีเจอร์อาจถูกทำให้เรียบง่ายหรือแปลงเป็นภาพระหว่างการแปลง

**ฉันสามารถแปลงเฉพาะสไลด์ที่เลือกเป็น PPT แทนการแปลงทั้งหมดของการนำเสนอได้หรือไม่?**

การบันทึกโดยตรงจะบันทึกทั้งการนำเสนอทั้งหมด หากต้องการแปลงสไลด์เฉพาะ ให้สร้างการนำเสนอใหม่ที่มีสไลด์เหล่านั้นเท่านั้นและบันทึกเป็น PPT; หรือใช้บริการ/API ที่รองรับการแปลงตามสไลด์

**การนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตรวจจับได้ว่าไฟล์ถูกป้องกันหรือไม่, เปิดด้วยรหัสผ่าน, และยังสามารถ [กำหนดค่าการป้องกัน/การเข้ารหัส](/slides/th/androidjava/password-protected-presentation/) สำหรับ PPT ที่บันทึก