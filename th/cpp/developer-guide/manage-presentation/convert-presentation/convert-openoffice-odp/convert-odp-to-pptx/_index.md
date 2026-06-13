---
title: แปลง ODP เป็น PPTX ใน C++
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/cpp/convert-odp-to-pptx/
keywords:
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง ODP
- OpenDocument เป็น PPTX
- ODP เป็น PPTX
- บันทึก ODP เป็น PPTX
- ส่งออก ODP ไปยัง PPTX
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "แปลง ODP เป็น PPTX ด้วย Aspose.Slides สำหรับ C++. ตัวอย่างโค้ดที่สะอาด, เคล็ดลับการประมวลผลเป็นชุด, และผลลัพธ์คุณภาพสูง—ไม่จำเป็นต้องใช้ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงการนำเสนอ ODP เป็นรูปแบบ PPTX โดยใช้ Aspose.Slides.

## **การแปลง ODP เป็น PPTX**

Aspose.Slides สำหรับ .NET มีคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ. [**Presentation**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) คลาสนี้สามารถเข้าถึง ODP ผ่านคอนสตรัคเตอร์ Presentation เมื่อสร้างอ็อบเจ็กต์ได้แล้ว. ตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอ ODP เป็นการนำเสนอ PPTX.

``` cpp
// เส้นทางไปยังไดเรกทอรีเอกสาร.
String dataDir = GetDataPath();

// เปิดไฟล์ ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// กำลังบันทึกการนำเสนอ ODP เป็นรูปแบบ PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **ตัวอย่างสด**

คุณสามารถเข้าเยี่ยมชมแอปเว็บ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/th/conversion/) ที่สร้างขึ้นด้วย **Aspose.Slides API** แอปนี้แสดงให้เห็นว่า การแปลง ODP เป็น PPTX สามารถทำได้ด้วย Aspose.Slides API.

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่. Aspose.Slides ทำงานแบบอิสระและไม่ต้องการแอปพลิเคชันของบุคคลที่สามเพื่ออ่านหรือเขียน ODP/PPTX.

**สไลด์มาสเตอร์, เค้าโครง, และธีมจะถูกเก็บรักษาไว้ระหว่างการแปลงหรือไม่?**

ใช่. ไลบรารีใช้โมเดลอ็อบเจ็กต์การนำเสนอแบบเต็มและรักษาโครงสร้างรวมถึงสไลด์มาสเตอร์และเค้าโครงไว้ ดังนั้นการออกแบบจะคงความถูกต้องหลังจากการแปลง.

**ฉันสามารถแปลงไฟล์ ODP ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่. Aspose.Slides รองรับการตรวจจับการป้องกัน, การเปิดและทำงานกับ [protected presentations](/slides/th/cpp/password-protected-presentation/) (รวมถึง ODP) เมื่อคุณให้รหัสผ่าน, รวมถึงการกำหนดค่าเข้ารหัสและการเข้าถึงคุณสมบัติเข้าเอกสาร.

**Aspose.Slides เหมาะสำหรับบริการแปลงบนคลาวด์หรือบริการที่ใช้ REST หรือไม่?**

ใช่. คุณสามารถใช้ไลบรารีในเครื่องของคุณเองในแบ็กเอนด์หรือ [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/) (REST API); ทั้งสองตัวเลือกสนับสนุนการแปลง ODP → PPTX.