---
title: แปลง PPTX เป็น PPT ด้วย JavaScript
linktitle: PPTX เป็น PPT
type: docs
weight: 21
url: /th/nodejs-java/convert-pptx-to-ppt/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPTX
- PPTX เป็น PPT
- บันทึก PPTX เป็น PPT
- ส่งออก PPTX เป็น PPT
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลง PPTX เป็น PPT ด้วย Aspose.Slides อย่างง่ายดาย—รับรองความเข้ากันได้อย่างราบรื่นกับรูปแบบ PowerPoint พร้อมคงไว้ซึ่งการออกแบบและคุณภาพของงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลง PowerPoint Presentation ในรูปแบบ PPTX ไปเป็นรูปแบบ PPT ด้วย JavaScript รายการต่อไปนี้จะถูกครอบคลุม

- แปลง PPTX เป็น PPT ด้วย JavaScript

## **Java แปลง PPTX เป็น PPT**

สำหรับตัวอย่างโค้ด JavaScript เพื่อแปลง PPTX เป็น PPT โปรดดูส่วนด้านล่างคือ [Convert PPTX to PPT](#convert-pptx-to-ppt) ซึ่งเพียงโหลดไฟล์ PPTX แล้วบันทึกเป็นรูปแบบ PPT โดยกำหนดรูปแบบการบันทึกที่ต่างกัน คุณยังสามารถบันทึกไฟล์ PPTX เป็นรูปแบบอื่น ๆ เช่น PDF, XPS, ODP, HTML ฯลฯ ตามที่อธิบายในบทความเหล่านี้

- [แปลง PPTX เป็น PDF ด้วย JavaScript](/slides/th/nodejs-java/convert-powerpoint-to-pdf/)
- [แปลง PPTX เป็น XPS ด้วย JavaScript](/slides/th/nodejs-java/convert-powerpoint-to-xps/)
- [แปลง PPTX เป็น HTML ด้วย JavaScript](/slides/th/nodejs-java/convert-powerpoint-to-html/)
- [แปลง PPTX เป็น ODP ด้วย JavaScript](/slides/th/nodejs-java/save-presentation/)
- [แปลง PPTX เป็น PNG ด้วย JavaScript](/slides/th/nodejs-java/convert-powerpoint-to-png/)

## **แปลง PPTX เป็น PPT**

เพื่อแปลง PPTX เป็น PPT เพียงส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด **Save** ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ตัวอย่างโค้ด JavaScript ด้านล่างจะแปลง Presentation จาก PPTX ไปเป็น PPT ด้วยตัวเลือกเริ่มต้น

```javascript
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นไฟล์ PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// บันทึกงานนำเสนอเป็น PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **คำถามที่พบบ่อย**

**เอฟเฟกต์และคุณลักษณะทั้งหมดของ PPTX จะคงอยู่เมื่อบันทึกเป็นรูปแบบ PPT ดั้งเดิม (97–2003) หรือไม่?**

ไม่เสมอไป รูปแบบ PPT ขาดความสามารถใหม่บางอย่าง (เช่น เอฟเฟกต์บางประเภท, วัตถุ, และพฤติกรรม) ทำให้คุณลักษณะบางอย่างอาจถูกทำให้เรียบหรือแปลงเป็นภาพระหว่างการแปลง

**ฉันสามารถแปลงเฉพาะสไลด์ที่เลือกเป็น PPT แทนการแปลงทั้งหมดของงานนำเสนอได้หรือไม่?**

การบันทึกโดยตรงจะใช้กับงานนำเสนอทั้งหมด หากต้องการแปลงสไลด์เฉพาะ ให้สร้างงานนำเสนอใหม่ที่มีเฉพาะสไลด์นั้นแล้วบันทึกเป็น PPT; หรือใช้บริการ/API ที่รองรับพารามิเตอร์การแปลงต่อสไลด์

**งานนำเสนอที่ป้องกันด้วยรหัสผ่านได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตรวจจับว่าไฟล์ถูกป้องกันหรือไม่, เปิดด้วยรหัสผ่าน, และยังสามารถ [กำหนดค่าการป้องกัน/การเข้ารหัส](/slides/th/nodejs-java/password-protected-presentation/) สำหรับ PPT ที่บันทึกได้