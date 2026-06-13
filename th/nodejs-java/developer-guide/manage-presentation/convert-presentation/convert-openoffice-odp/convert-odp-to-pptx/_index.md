---
title: แปลง ODP เป็น PPTX ด้วย JavaScript
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/nodejs-java/convert-odp-to-pptx/
keywords:
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง ODP
- OpenDocument ไปยัง PPTX
- ODP ไปยัง PPTX
- บันทึก ODP เป็น PPTX
- ส่งออก ODP ไปยัง PPTX
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลง ODP เป็น PPTX ด้วย Aspose.Slides สำหรับ Node.js ตัวอย่างโค้ด JavaScript ที่สะอาด แนวทางการทำเป็นชุด และผลลัพธ์คุณภาพสูง — ไม่ต้องใช้ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ ODP เป็นรูปแบบ PPTX โดยใช้ Aspose.Slides.

## **แปลง ODP เป็น PPTX/PPT งานนำเสนอ**

Aspose.Slides สำหรับ Node.js ผ่าน Java มีคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่แสดงถึงไฟล์งานนำเสนอ. คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) สามารถเข้าถึง ODP ผ่านคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) เมื่อสร้างอ็อบเจ็กต์. ตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ODP ไปเป็นงานนำเสนอ PPTX.

```javascript
// เปิดไฟล์ ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// บันทึกงานนำเสนอ ODP เป็นรูปแบบ PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **ตัวอย่างสด**

คุณสามารถเยี่ยมชมแอปเว็บ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/th/conversion/) ซึ่งสร้างด้วย **Aspose.Slides API** แอปนี้แสดงวิธีการแปลง ODP เป็น PPTX ด้วย Aspose.Slides API.

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่. Aspose.Slides ทำงานแบบอิสระและไม่ต้องการแอปพลิเคชันจากบุคคลที่สามเพื่ออ่านหรือเขียน ODP/PPTX.

**สไลด์แม่, การจัดวางและธีมจะถูกเก็บไว้ระหว่างการแปลงหรือไม่?**

ใช่. ไลบรารีใช้โมเดลอ็อบเจ็กต์ของงานนำเสนอแบบเต็มและรักษาโครงสร้างรวมถึงสไลด์แม่และการจัดวางไว้ ทำให้การออกแบบยังคงถูกต้องหลังจากการแปลง.

**ฉันสามารถแปลงไฟล์ ODP ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่. Aspose.Slides รองรับการตรวจจับการป้องกัน, การเปิดและทำงานกับ [protected presentations](/slides/th/nodejs-java/password-protected-presentation/) (รวมถึง ODP) เมื่อคุณให้รหัสผ่าน, รวมถึงการกำหนดค่าการเข้ารหัสและการเข้าถึงคุณสมบัติของเอกสาร.

**Aspose.Slides เหมาะสำหรับบริการแปลงบนคลาวด์หรือแบบ REST หรือไม่?**

ใช่. คุณสามารถใช้ไลบรารีในเครื่องในแบ็กเอนด์ของคุณเองหรือ [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/) (REST API); ทั้งสองตัวเลือกรองรับการแปลง ODP → PPTX.