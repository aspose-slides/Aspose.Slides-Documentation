---  
title: แปลง PPTX เป็น PPT ด้วย PHP  
linktitle: PPTX เป็น PPT  
type: docs  
weight: 21  
url: /th/php-java/convert-pptx-to-ppt/  
keywords:  
- แปลง PowerPoint  
- แปลง การนำเสนอ  
- แปลง สไลด์  
- แปลง PPTX  
- PPTX เป็น PPT  
- บันทึก PPTX เป็น PPT  
- ส่งออก PPTX เป็น PPT  
- PowerPoint  
- การนำเสนอ  
- PHP  
- Aspose.Slides  
description: "แปลง PPTX เป็น PPT ด้วย Aspose.Slides อย่างง่ายดาย — รับรองความเข้ากันได้อย่างราบรื่นกับรูปแบบ PowerPoint พร้อมรักษาเลเอาต์และคุณภาพของการนำเสนอของคุณ"  
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลง PowerPoint Presentation ในรูปแบบ PPTX เป็น PPT โดยใช้ PHP หัวข้อต่อไปนี้จะถูกครอบคลุม

- แปลง PPTX เป็น PPT

## **แปลง PPTX เป็น PPT ใน PHP**

สำหรับตัวอย่างโค้ด Java ที่จะแปลง PPTX เป็น PPT โปรดดูส่วนด้านล่างคือ [Convert PPTX to PPT](#convert-pptx-to-ppt) ซึ่งเพียงโหลดไฟล์ PPTX แล้วบันทึกเป็นรูปแบบ PPT โดยการระบุรูปแบบการบันทึกที่แตกต่าง คุณยังสามารถบันทึกไฟล์ PPTX เป็นรูปแบบอื่น ๆ อีกหลายรูปแบบ เช่น PDF, XPS, ODP, HTML เป็นต้น ตามที่อธิบายในบทความเหล่านี้

- [แปลง PPTX เป็น PDF ด้วย PHP](/slides/th/php-java/convert-powerpoint-to-pdf/)
- [แปลง PPTX เป็น XPS ด้วย PHP](/slides/th/php-java/convert-powerpoint-to-xps/)
- [แปลง PPTX เป็น HTML ด้วย PHP](/slides/th/php-java/convert-powerpoint-to-html/)
- [แปลง PPTX เป็น ODP ด้วย PHP](/slides/th/php-java/save-presentation/)
- [แปลง PPTX เป็น PNG ด้วย PHP](/slides/th/php-java/convert-powerpoint-to-png/)

## **แปลง PPTX เป็น PPT**
เพื่อแปลง PPTX เป็น PPT เพียงแค่ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังวิธี **Save** ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ตัวอย่างโค้ด PHP ด้านล่างจะแปลง Presentation จาก PPTX เป็น PPT ด้วยตัวเลือกเริ่มต้น

```php
  # สร้างอ็อบเจกต์ Presentation ที่เป็นไฟล์ PPTX
  $presentation = new Presentation("template.pptx");
  # บันทึกการนำเสนอเป็น PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **คำถามที่พบบ่อย**

**ฟีเจอร์และเอฟเฟกต์ทั้งหมดของ PPTX จะคงอยู่เมื่อลงรูปแบบ PPT แบบเก่า (97–2003) หรือไม่?**

ไม่เสมอไป รูปแบบ PPT ขาดความสามารถใหม่บางอย่าง (เช่น เอฟเฟกต์บางประเภท วัตถุ และพฤติกรรม) ดังนั้นฟีเจอร์อาจถูกทำให้เรียบง่ายหรือแปลงเป็นภาพระหว่างการแปลง

**ฉันสามารถแปลงเฉพาะสไลด์ที่เลือกเป็น PPT แทนการแปลงทั้งงานนำเสนอได้หรือไม่?**

การบันทึกโดยตรงจะทำกับงานนำเสนอทั้งหมด หากต้องการแปลงสไลด์ที่ระบุเฉพาะ ให้สร้างงานนำเสนอใหม่ที่มีสไลด์เหล่านั้นแล้วบันทึกเป็น PPT; หรือใช้บริการ/API ที่รองรับพารามิเตอร์การแปลงต่อสไลด์

**รองรับงานนำเสนอที่มีการป้องกันด้วยรหัสผ่านหรือไม่?**

ใช่ คุณสามารถตรวจจับได้ว่าไฟล์ถูกป้องกันหรือไม่ เปิดไฟล์ด้วยรหัสผ่าน และยังสามารถ [กำหนดการตั้งค่าการป้องกัน/การเข้ารหัส](/slides/th/php-java/password-protected-presentation/) สำหรับ PPT ที่บันทึกได้