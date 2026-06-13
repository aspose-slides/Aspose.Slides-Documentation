---
title: แปลง PPTX เป็น PPT ด้วย Python
linktitle: PPTX ไปยัง PPT
type: docs
weight: 21
url: /th/python-net/convert-pptx-to-ppt/
keywords:
- PPTX ไปยัง PPT
- แปลง PPTX เป็น PPT
- แปลง PowerPoint
- แปลงการนำเสนอ
- Python
- Aspose.Slides
description: "แปลง PPTX เป็น PPT อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—รับรองความเข้ากันได้อย่างราบรื่นกับรูปแบบ PowerPoint พร้อมคงไว้ซึ่งเค้าโครงและคุณภาพของงานนำเสนอของคุณ."
---
## **ภาพรวม**

Aspose.Slides for Python ให้คุณแปลงงานนำเสนอ PPTX สมัยใหม่เป็นรูปแบบ PPT เดิมทั้งหมดด้วยโค้ด เปิดไฟล์ PPTX แล้วส่งออกเป็น PPT ในขณะที่คงเนื้อหาและเค้าโครงของงานนำเสนอไว้ ทำให้ผลลัพธ์เข้ากันได้กับ PowerPoint รุ่นเก่าเดียวกัน กระบวนการเดียวกันนี้ยังสามารถสร้างผลลัพธ์อื่น ๆ เช่น PDF, XPS, ODP, HTML หรือรูปภาพได้ จึงเหมาะกับสคริปต์, CI pipelines, และการประมวลผลแบบแบช

## **แปลง PPTX เป็น PPT**

เพื่อแปลง PPTX เป็น PPT เพียงส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด [บันทึก](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ตัวอย่าง Python ด้านล่างจะแปลงงานนำเสนอจาก PPTX เป็น PPT ด้วยตัวเลือกเริ่มต้น

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
# บันทึกการนำเสนอเป็นไฟล์ PPT.
presentation = slides.Presentation("presentation.pptx")

presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **คำถามที่พบบ่อย**

**คุณลักษณะและเอฟเฟกต์ทั้งหมดของ PPTX จะคงอยู่เมื่อต保存เป็นรูปแบบ PPT (97–2003) หรือไม่?**

ไม่เสมอไป รูปแบบ PPT ขาดความสามารถบางอย่างที่ใหม่กว่า (เช่น เอฟเฟกต์เฉพาะ, วัตถุบางอย่าง, และพฤติกรรม) ดังนั้นฟีเจอร์อาจถูกทำให้เรียบง่ายหรือแปลงเป็นภาพระหว่างการแปลง

**ฉันสามารถแปลงเฉพาะสไลด์ที่เลือกเป็น PPT แทนการแปลงทั้งงานนำเสนอได้หรือไม่?**

การบันทึกโดยตรงจะทำงานกับงานนำเสนอทั้งหมด เพื่อแปลงสไลด์เฉพาะ ให้สร้างงานนำเสนอใหม่ที่มีสไลด์เหล่านั้นแล้วบันทึกเป็น PPT; หรือใช้บริการ/API ที่รองรับพารามิเตอร์การแปลงต่อสไลด์

**งานนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตรวจสอบว่าไฟล์ได้รับการป้องกันหรือไม่, เปิดด้วยรหัสผ่าน, และยังสามารถ [กำหนดการป้องกัน/การตั้งค่าการเข้ารหัส](/slides/th/python-net/password-protected-presentation/) สำหรับ PPT ที่บันทึกได้

**ดูเพิ่มเติม:**
- [แปลง PPT และ PPTX เป็น PDF ใน Python | ตัวเลือกขั้นสูง](/slides/th/python-net/convert-powerpoint-to-pdf/)
- [แปลงงานนำเสนอ PowerPoint เป็น XPS ใน Python](/slides/th/python-net/convert-powerpoint-to-xps/)
- [แปลงงานนำเสนอ PowerPoint เป็น HTML ใน Python](/slides/th/python-net/convert-powerpoint-to-html/)
- [แปลงสไลด์ PowerPoint เป็น PNG ใน Python](/slides/th/python-net/convert-powerpoint-to-png/)