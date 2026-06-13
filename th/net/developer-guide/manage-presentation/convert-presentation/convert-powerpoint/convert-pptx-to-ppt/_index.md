---
title: แปลง PPTX เป็น PPT ใน .NET
linktitle: PPTX เป็น PPT
type: docs
weight: 21
url: /th/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "แปลง PPTX เป็น PPT ด้วย Aspose.Slides สำหรับ .NET อย่างง่ายดาย—รับประกันความเข้ากันได้อย่างไร้รอยต่อกับรูปแบบ PowerPoint พร้อมคงโครงสร้างและคุณภาพของการนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลง PowerPoint Presentation ในรูปแบบ PPTX ไปเป็นรูปแบบ PPT ด้วย C#. หัวข้อที่ครอบคลุมมีดังต่อไปนี้

- แปลง PPTX เป็น PPT ด้วย C#

## **แปลง PPTX เป็น PPT ใน .NET**

สำหรับตัวอย่างโค้ด C# ที่แปลง PPTX เป็น PPT โปรดดูส่วนด้านล่างคือ[แปลง PPTX เป็น PPT](#convert-pptx-to-ppt). โค้ดจะโหลดไฟล์ PPTX แล้วบันทึกเป็นรูปแบบ PPT เท่านั้น การระบุรูปแบบการบันทึกที่แตกต่างกัน คุณยังสามารถบันทึกไฟล์ PPTX เป็นรูปแบบอื่น ๆ เช่น PDF, XPS, ODP, HTML เป็นต้น ตามที่อธิบายในบทความเหล่านี้

- [แปลง PPTX เป็น PDF ใน .NET](/slides/th/net/convert-powerpoint-to-pdf/)
- [แปลง PPTX เป็น XPS ใน .NET](/slides/th/net/convert-powerpoint-to-xps/)
- [แปลง PPTX เป็น HTML ใน .NET](/slides/th/net/convert-powerpoint-to-html/)
- [แปลง PPTX เป็น ODP ใน .NET](/slides/th/net/save-presentation/)
- [แปลง PPTX เป็น PNG ใน .NET](/slides/th/net/convert-powerpoint-to-png/)

## **แปลง PPTX เป็น PPT**
เพื่อแปลง PPTX เป็น PPT เพียงส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด[**Save**](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/)ของคลาส[**Presentation**](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ตัวอย่างโค้ด C# ด้านล่างจะแปลง Presentation จาก PPTX เป็น PPT ด้วยตัวเลือกเริ่มต้น

```c#
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation("presentation.pptx");

// บันทึกการนำเสนอ PPTX เป็นรูปแบบ PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **คำถามที่พบบ่อย**

**เอฟเฟกต์และคุณลักษณะทั้งหมดของ PPTX จะคงไว้เมื่อบันทึกเป็นรูปแบบ PPT รุ่นเก่า (97–2003) หรือไม่?**

ไม่เสมอไป เนื่องจากรูปแบบ PPT ขาดความสามารถใหม่ ๆ บางอย่าง (เช่น เอฟเฟกต์บางประเภท, วัตถุ, และพฤติกรรม) ทำให้คุณลักษณะบางอย่างอาจถูกทำให้เรียบง่ายหรือแปลงเป็นภาพระหว่างการแปลง

**ฉันสามารถแปลงสไลด์ที่เลือกเท่านั้นเป็น PPT แทนการแปลงทั้งการนำเสนอได้หรือไม่?**

การบันทึกโดยตรงจะกระทำต่อการนำเสนอทั้งหมด หากต้องการแปลงเฉพาะสไลด์ ให้สร้างการนำเสนอใหม่ที่มีเฉพาะสไลด์นั้น ๆ แล้วบันทึกเป็น PPT; หรือใช้บริการ/API ที่รองรับการแปลงตามสไลด์

**การนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตรวจสอบว่าไฟล์ถูกป้องกันหรือไม่, เปิดไฟล์ด้วยรหัสผ่าน, และยังสามารถ[กำหนดการตั้งค่าการป้องกัน/การเข้ารหัส](/slides/th/net/password-protected-presentation/)สำหรับ PPT ที่บันทึกได้