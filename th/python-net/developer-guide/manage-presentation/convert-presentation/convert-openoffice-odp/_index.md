---
title: แปลงงานนำเสนอ OpenDocument ด้วย Python
linktitle: แปลง OpenDocument
type: docs
weight: 10
url: /th/python-net/convert-openoffice-odp/
keywords:
- แปลง OpenDocument
- แปลง ODP
- ODP เป็น PDF
- ODP เป็น PPT
- ODP เป็น PPTX
- ODP เป็น XPS
- ODP เป็น HTML
- ODP เป็น TIFF
- ODP เป็น SWF
- เอกสาร OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลง OpenDocument ODP เป็น PDF, PPT, PPTX, XPS, HTML, TIFF หรือ SWF ด้วย Python และ Aspose.Slides: ตัวอย่างโค้ด ความแม่นยำสูง การแปลงเป็นชุด และการปรับแต่ง."
---
## **บทนำ**

[**Aspose.Slides API**](https://products.aspose.com/slides/th/python-net/) ช่วยให้คุณแปลงงานนำเสนอ OpenDocument (ODP) ไปเป็นหลายรูปแบบ (HTML, PDF, TIFF, SWF, XPS เป็นต้น) API ที่ใช้แปลงไฟล์ ODP ไปเป็นรูปแบบเอกสารอื่น ๆ มีเหมือนกับที่ใช้สำหรับการแปลง PowerPoint (PPT และ PPTX).

ตัวอย่างเช่น หากคุณต้องการแปลงงานนำเสนอ ODP เป็น PDF คุณสามารถทำได้ดังนี้:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง ODP เป็น PPTX ได้โดยไม่ต้องติดตั้ง LibreOffice หรือ OpenOffice หรือไม่?**

ใช่. Aspose.Slides เป็นไลบรารีที่ทำงานแบบอิสระทั้งหมดที่จัดการทั้งรูปแบบ PowerPoint และ OpenOffice โดยไม่ต้องใช้แอปพลิเคชันภายนอกใด ๆ.

**Aspose.Slides สามารถเปิดและบันทึกไฟล์ ODP/OTP ที่ได้รับการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่. สามารถ [โหลดงานนำเสนอที่เข้ารหัส](/slides/th/python-net/password-protected-presentation/) เมื่อคุณให้รหัสผ่านและยังสามารถบันทึกงานนำเสนอพร้อมการเข้ารหัสและการตั้งค่าการป้องกันได้.

**ฉันสามารถสกัดไฟล์สื่อที่ฝังอยู่ (audio/video) จาก ODP ก่อนแปลงได้หรือไม่?**

ใช่. Aspose.Slides ให้คุณเข้าถึงและสกัด [audio](/slides/th/python-net/audio-frame/) และ [video](/slides/th/python-net/video-frame/) ที่ฝังอยู่ในงานนำเสนอ ซึ่งเป็นประโยชน์สำหรับการประมวลผลก่อนการแปลงหรือการนำไปใช้ใหม่แยกส่วน.

**ฉันสามารถบันทึก ODP ที่แปลงแล้วเป็น Strict Office Open XML ได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX คุณสามารถเปิดใช้ Strict OOXML ผ่าน [save options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/) เพื่อให้สอดคล้องกับข้อกำหนดการปฏิบัติตามที่เคร่งครัดยิ่งขึ้น.