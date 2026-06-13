---
title: แปลง ODP เป็น PPTX ใน Java
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/java/convert-odp-to-pptx/
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
- Java
- Aspose.Slides
description: "แปลง ODP เป็น PPTX ด้วย Aspose.Slides for Java. ตัวอย่างโค้ด Java ที่สะอาด เคล็ดลับการทำแบตช์ และผลลัพธ์คุณภาพสูง - ไม่ต้องใช้ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ ODP เป็นรูปแบบ PPTX โดยใช้ Aspose.Slides.

## **แปลง ODP เป็นงานนำเสนอ PPTX/PPT**
Aspose.Slides สำหรับ Java มีคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่แสดงถึงไฟล์งานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) สามารถเข้าถึง ODP ผ่านคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) เมื่อสร้างอ็อบเจกต์ได้แล้ว ตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ODP เป็นงานนำเสนอ PPTX

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
คุณสามารถเยี่ยมชมแอปเว็บ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/th/conversion/) ซึ่งสร้างด้วย **Aspose.Slides API.** แอปนี้แสดงวิธีการแปลง ODP เป็น PPTX ด้วย Aspose.Slides API.

## **คำถามที่พบบ่อย**

**จำเป็นต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่ Aspose.Slides ทำงานแบบอิสระและไม่ต้องการแอปพลิเคชันของบุคคลที่สามเพื่ออ่านหรือเขียน ODP/PPTX.

**สไลด์หลัก, การจัดวาง, และธีมจะถูกเก็บรักษาไว้ในระหว่างการแปลงหรือไม่?**

ใช่ ไลบรารีใช้โมเดลอ็อบเจกต์งานนำเสนอเต็มรูปแบบและรักษาโครงสร้าง รวมถึงสไลด์หลักและการจัดวาง เพื่อให้การออกแบบยังคงถูกต้องหลังการแปลง.

**ฉันสามารถแปลงไฟล์ ODP ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่ Aspose.Slides รองรับการตรวจจับการป้องกัน การเปิดและทำงานกับ [protected presentations](/slides/th/java/password-protected-presentation/) (รวมถึง ODP) เมื่อคุณให้รหัสผ่าน รวมถึงการกำหนดค่าการเข้ารหัสและการเข้าถึงคุณสมบัติเขียนเอกสาร.

**Aspose.Slides เหมาะกับบริการแปลงบนคลาวด์หรือ REST-based หรือไม่?**

ใช่ คุณสามารถใช้ไลบรารีในระบบของคุณเองหรือ [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/) (REST API) ทั้งสองตัวเลือกสนับสนุนการแปลง ODP → PPTX.