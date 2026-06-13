---
title: แปลง PPTX เป็น PPT ด้วย C++
linktitle: PPTX เป็น PPT
type: docs
weight: 21
url: /th/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "แปลง PPTX เป็น PPT อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++—รับรองความเข้ากันได้อย่างราบรื่นกับรูปแบบ PowerPoint พร้อมคงรักษาโครงร่างและคุณภาพของงานนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลง PowerPoint Presentation ในรูปแบบ PPTX ไปเป็นรูปแบบ PPT โดยใช้ C++. มีหัวข้อดังต่อไปนี้ที่ครอบคลุม

- แปลง PPTX เป็น PPT ด้วย C++

## **แปลง PPTX เป็น PPT ด้วย C++**

สำหรับโค้ดตัวอย่าง C++ ที่แปลง PPTX เป็น PPT โปรดดูส่วนด้านล่างเช่น [แปลง PPTX เป็น PPT](#convert-pptx-to-ppt) โค้ดจะทำการโหลดไฟล์ PPTX แล้วบันทึกเป็นรูปแบบ PPT เท่านั้น โดยการระบุรูปแบบการบันทึกที่ต่างกัน คุณยังสามารถบันทึกไฟล์ PPTX เป็นรูปแบบอื่น ๆ อีกหลายรูปแบบ เช่น PDF, XPS, ODP, HTML เป็นต้น ตามที่อธิบายในบทความเหล่านี้

- [แปลง PPTX เป็น PDF ด้วย C++](/slides/th/cpp/convert-powerpoint-to-pdf/)
- [แปลง PPTX เป็น XPS ด้วย C++](/slides/th/cpp/convert-powerpoint-to-xps/)
- [แปลง PPTX เป็น HTML ด้วย C++](/slides/th/cpp/convert-powerpoint-to-html/)
- [แปลง PPTX เป็น ODP ด้วย C++](/slides/th/cpp/save-presentation/)
- [แปลง PPTX เป็น PNG ด้วย C++](/slides/th/cpp/convert-powerpoint-to-png/)

## **แปลง PPTX เป็น PPT**
เพื่อแปลง PPTX เป็น PPT เพียงส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด **Save** ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/) โค้ดตัวอย่าง C++ ด้านล่างแปลง Presentation จาก PPTX เป็น PPT โดยใช้ตัวเลือกค่าเริ่มต้น

```cpp
// โหลดไฟล์ PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// บันทึกในรูปแบบ PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **คำถามที่พบบ่อย**

**เอฟเฟกต์และฟีเจอร์ทั้งหมดของ PPTX จะคงอยู่เมื่อต้องบันทึกเป็นรูปแบบ PPT แบบเก่า (97–2003) หรือไม่?**

ไม่ได้เสมอไป รูปแบบ PPT ไม่มีความสามารถใหม่บางอย่าง (เช่น เอฟเฟกต์บางอย่าง, วัตถุ, และการทำงาน) ดังนั้นฟีเจอร์อาจถูกทำให้เรียบง่ายหรือแปลงเป็นภาพระหว่างการแปลง

**ฉันสามารถแปลงเฉพาะสไลด์ที่เลือกเป็น PPT แทนการแปลงทั้งหมดของงานนำเสนอได้หรือไม่?**

การบันทึกโดยตรงจะบันทึกงานนำเสนอทั้งหมด เพื่อแปลงสไลด์เฉพาะ ให้สร้างงานนำเสนอใหม่ที่มีสไลด์เหล่านั้นแล้วบันทึกเป็น PPT; อีกวิธีหนึ่งคือใช้บริการ/API ที่รองรับพารามิเตอร์การแปลงต่อสไลด์

**งานนำเสนอที่ป้องกันด้วยรหัสผ่านได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตรวจจับได้ว่าไฟล์ถูกป้องกันหรือไม่, เปิดไฟล์ด้วยรหัสผ่าน, และยังสามารถ [กำหนดค่าการป้องกัน/การเข้ารหัส](/slides/th/cpp/password-protected-presentation/) สำหรับ PPT ที่บันทึกได้.