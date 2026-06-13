---
title: แปลง ODP เป็น PPTX ใน .NET
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "แปลง ODP เป็น PPTX ด้วย Aspose.Slides สำหรับ .NET. ตัวอย่างโค้ด C# ที่สะอาด, เคล็ดลับการประมวลผลเป็นชุด, ผลลัพธ์คุณภาพสูง—ไม่ต้องใช้ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ ODP ไปเป็นรูปแบบ PPTX ด้วย Aspose.Slides.

## **การแปลง ODP เป็น PPTX**

Aspose.Slides สำหรับ .NET มีคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ. [**Presentation**](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) คลาสนี้สามารถเข้าถึง ODP ผ่านคอนสตรัคเตอร์ Presentation เมื่อสร้างวัตถุได้แล้ว. ตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ODP เป็นงานนำเสนอ PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>ขั้นตอน: แปลง ODP เป็น PPTX ใน C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>ขั้นตอน: แปลง ODP เป็น PowerPoint ใน C#</strong></a>

```c#
// เปิดไฟล์ ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// บันทึกงานนำเสนอ ODP เป็นรูปแบบ PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **ตัวอย่างสด**

คุณสามารถเยี่ยมชม [**Aspose.Slides Conversion**](https://products.aspose.app/slides/th/conversion/) เว็บแอปที่สร้างด้วย **Aspose.Slides API.** แอปนี้แสดงให้เห็นว่าการแปลง ODP เป็น PPTX สามารถทำได้ด้วย Aspose.Slides API.

## **คำถามที่พบบ่อย**

**ฉันต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่. Aspose.Slides ทำงานแบบอิสระและไม่ต้องการแอปพลิเคชันของบุคคลที่สามในการอ่านหรือเขียน ODP/PPTX.

**สไลด์แม่แบบ, รูปแบบ, และธีมจะถูกรักษาไว้ระหว่างการแปลงหรือไม่?**

ใช่. ไลบรารีใช้โมเดลวัตถุการนำเสนอเต็มรูปแบบและรักษาโครงสร้างรวมถึงสไลด์แม่แบบและเลย์เอาต์ ทำให้การออกแบบคงที่หลังการแปลง.

**ฉันสามารถแปลงไฟล์ ODP ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่. Aspose.Slides รองรับการตรวจจับการป้องกัน, การเปิดและทำงานกับ [protected presentations](/slides/th/net/password-protected-presentation/) (รวมถึง ODP) เมื่อคุณให้รหัสผ่าน, พร้อมกับการกำหนดค่าการเข้ารหัสและการเข้าถึงคุณสมบัติลายสารของเอกสาร.

**Aspose.Slides เหมาะสำหรับบริการแปลงบนคลาวด์หรือแบบ REST หรือไม่?**

ใช่. คุณสามารถใช้ไลบรารีในแบ็กเอนด์ของคุณเองหรือ [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/) (REST API); ทั้งสองตัวเลือกรองรับการแปลง ODP → PPTX.