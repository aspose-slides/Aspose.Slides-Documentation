---
title: แปลง ODP เป็น PPTX บน Android
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/androidjava/convert-odp-to-pptx/
keywords:
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง ODP
- OpenDocument เป็น PPTX
- ODP เป็น PPTX
- บันทึก ODP เป็น PPTX
- ส่งออก ODP เป็น PPTX
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลง ODP เป็น PPTX ด้วย Aspose.Slides สำหรับ Android ตัวอย่างโค้ด Java ที่สะอาด เรียบง่าย คำแนะนำการประมวลผลเป็นชุด และผลลัพธ์คุณภาพสูง - ไม่ต้องใช้ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ ODP เป็นรูปแบบ PPTX โดยใช้ Aspose.Slides.

## **แปลง ODP เป็นงานนำเสนอ PPTX/PPT**

Aspose.Slides สำหรับ Android ผ่าน Java มีคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่แทนไฟล์งานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) สามารถเข้าถึง ODP ผ่านคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) เมื่อตัวอ็อบเจกต์ถูกสร้าง ตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ODP เป็นงานนำเสนอ PPTX.

```java
// เปิดไฟล์ ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// บันทึกงานนำเสนอ ODP เป็นรูปแบบ PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างสด**

คุณสามารถเข้าไปที่แอปเว็บ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/th/conversion/) ซึ่งสร้างด้วย **Aspose.Slides API.** แอปนี้แสดงวิธีการแปลง ODP เป็น PPTX ด้วย Aspose.Slides API.

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่ Aspose.Slides ทำงานได้โดยอิสระและไม่ต้องการแอปพลิเคชันของบุคคลที่สามเพื่ออ่านหรือเขียน ODP/PPTX.

**สไลด์แม่, การจัดวาง, และธีมถูกเก็บรักษาไว้ระหว่างการแปลงหรือไม่?**

ใช่ ไลบรารีใช้โมเดลอ็อบเจกต์ของงานนำเสนอแบบเต็มและรักษาโครงสร้างรวมถึงสไลด์แม่และการจัดวางไว้ ทำให้การออกแบบยังคงถูกต้องหลังการแปลง.

**ฉันสามารถแปลงไฟล์ ODP ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่ Aspose.Slides รองรับการตรวจจับการป้องกัน, การเปิดและทำงานกับ [protected presentations](/slides/th/androidjava/password-protected-presentation/) (รวมถึง ODP) เมื่อคุณใส่รหัสผ่าน รวมถึงการกำหนดค่าการเข้ารหัสและการเข้าถึงคุณสมบัติบัญญัติ.

**Aspose.Slides เหมาะสำหรับบริการแปลงบนคลาวด์หรือ REST-based หรือไม่?**

ใช่ คุณสามารถใช้ไลบรารีในเครื่องในแบ็คเอนด์ของคุณเองหรือ [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/) (REST API); ทั้งสองตัวเลือกรองรับการแปลง ODP → PPTX.