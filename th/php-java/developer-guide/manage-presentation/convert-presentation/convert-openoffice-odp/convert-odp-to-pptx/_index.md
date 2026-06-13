---
title: แปลง ODP เป็น PPTX ใน PHP
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/php-java/convert-odp-to-pptx/
keywords:
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง ODP
- OpenDocument เป็น PPTX
- ODP เป็น PPTX
- บันทึก ODP เป็น PPTX
- ส่งออก ODP เป็น PPTX
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลง ODP เป็น PPTX ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ตัวอย่างโค้ดที่สะอาด เรียบง่าย เคล็ดลับการทำเป็นชุด และผลลัพธ์คุณภาพสูง - ไม่ต้องใช้ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงการนำเสนอ ODP ให้เป็นรูปแบบ PPTX โดยใช้ Aspose.Slides.

## **แปลง ODP เป็นการนำเสนอ PPTX/PPT**

Aspose.Slides for PHP via Java มีคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่เป็นตัวแทนของไฟล์การนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ตอนนี้ยังสามารถเข้าถึง ODP ผ่านคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) เมื่อสร้างอ็อบเจ็กต์ ตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอ ODP เป็นการนำเสนอ PPTX.

```php
// เปิดไฟล์ ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # บันทึกการนำเสนอ ODP เป็นรูปแบบ PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **ตัวอย่างสด**

คุณสามารถเยี่ยมชมแอปเว็บ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/th/conversion/) ที่สร้างด้วย **Aspose.Slides API.** แอปนี้แสดงวิธีการแปลง ODP เป็น PPTX สามารถทำได้ด้วย Aspose.Slides API.

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่. Aspose.Slides ทำงานแบบอิสระและไม่ต้องการแอปพลิเคชันของบุคคลที่สามเพื่ออ่านหรือเขียน ODP/PPTX.

**สไลด์มาสเตอร์, เลย์เอาต์, และธีมจะถูกรักษาไว้ระหว่างการแปลงหรือไม่?**

ใช่. ไลบรารีใช้โมเดลออบเจ็กต์การนำเสนอแบบเต็มและรักษาโครงสร้างไว้ รวมถึงสไลด์มาสเตอร์และเลย์เอาต์ ทำให้การออกแบบยังคงถูกต้องหลังการแปลง.

**ฉันสามารถแปลงไฟล์ ODP ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่. Aspose.Slides รองรับการตรวจจับการป้องกัน, การเปิดและทำงานกับ [protected presentations](/slides/th/php-java/password-protected-presentation/) (รวมถึง ODP) เมื่อคุณระบุรหัสผ่าน, รวมถึงการกำหนดค่าการเข้ารหัสและการเข้าถึงคุณสมบัติของเอกสาร.

**Aspose.Slides เหมาะสำหรับบริการแปลงบนคลาวด์หรือแบบ REST หรือไม่?**

ใช่. คุณสามารถใช้ไลบรารีในเครื่องในแบ็กเอนด์ของคุณเองหรือ [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/) (REST API); ทั้งสองตัวเลือกรองรับการแปลง ODP → PPTX.