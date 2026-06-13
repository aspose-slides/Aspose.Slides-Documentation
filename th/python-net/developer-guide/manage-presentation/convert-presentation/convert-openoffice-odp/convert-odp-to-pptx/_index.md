---
title: แปลง ODP เป็น PPTX ใน Python
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/python-net/convert-odp-to-pptx/
keywords:
- แปลง OpenDocument
- แปลง ODP
- OpenDocument ไปยัง PPTX
- ODP ไปยัง PPTX
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลง ODP เป็น PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ตัวอย่างโค้ดที่เรียบง่าย เคล็ดลับการประมวลผลเป็นชุด และผลลัพธ์คุณภาพสูง - ไม่ต้องใช้ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ ODP เป็นรูปแบบ PPTX ด้วย Aspose.Slides

## **ส่งออก ODP เป็น PPTX**

Aspose.Slides สำหรับ Python ผ่าน .NET มีคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ [**Presentation**](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) คลาสนี้ตอนนี้สามารถเข้าถึง ODP ผ่านคอนสตรัคเตอร์ Presentation เมื่อสร้างออบเจกต์ ตัวอย่างต่อไปนี้แสดงวิธีแปลง Presentation ของ ODP ให้เป็น Presentation ของ PPTX

```py
# นำเข้า Aspose.Slides สำหรับ Python ผ่าน .NET โมดูล
import aspose.slides as slides

# เปิดไฟล์ ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# บันทึกงานนำเสนอ ODP ไปเป็นรูปแบบ PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตัวอย่างสด**

คุณสามารถเยี่ยมชม [**Aspose.Slides Conversion**](https://products.aspose.app/slides/th/conversion/) เว็บแอปซึ่งสร้างด้วย **Aspose.Slides API.** แอปนี้แสดงวิธีการแปลง ODP เป็น PPTX ด้วย Aspose.Slides API

## **คำถามที่พบบ่อย**

**ฉันต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่ Aspose.Slides ทำงานแบบอิสระและไม่ต้องการแอปพลิเคชันของบุคคลที่สามเพื่ออ่านหรือเขียน ODP/PPTX

**สไลด์มาสเตอร์ รูปแบบและธีมจะถูกเก็บรักษาไว้ระหว่างการแปลงหรือไม่?**

ใช่ ไลบรารีใช้โมเดลอ็อบเจกต์ของงานนำเสนอเต็มรูปแบบและคงโครงสร้างรวมถึงสไลด์มาสเตอร์และเลเอาต์ไว้จึงทำให้การออกแบบถูกต้องหลังการแปลง

**ฉันสามารถแปลงไฟล์ ODP ที่มีการตั้งรหัสผ่านได้หรือไม่?**

ใช่ Aspose.Slides รองรับการตรวจจับการป้องกัน การเปิดและทำงานกับ [protected presentations](/slides/th/python-net/password-protected-presentation/) (รวมถึง ODP) หากคุณระหัสผ่าน รวมถึงการตั้งค่าการเข้ารหัสและการเข้าถึงคุณสมบัติของเอกสาร

**Aspose.Slides เหมาะสำหรับบริการแปลงบนคลาวด์หรือ REST หรือไม่?**

ใช่ คุณสามารถใช้ไลบรารีในเครื่องของคุณเองในแบ็กเอนด์หรือ [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/) (REST API) ทั้งสองตัวเลือกรองรับการแปลง ODP → PPTX