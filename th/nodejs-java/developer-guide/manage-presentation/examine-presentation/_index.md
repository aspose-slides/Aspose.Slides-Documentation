---
title: ดึงและอัปเดตข้อมูลการนำเสนอด้วย JavaScript
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/nodejs-java/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- ดึงคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาดาทาในงานนำเสนอ PowerPoint และ OpenDocument ด้วย JavaScript เพื่อรับข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายว่าตรวจหาฟอร์แมตปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์ทั้งหมด วิธีอ่านคุณสมบัติของเอกสาร และวิธีอัปเดตคุณสมบัตินั้นเมื่อจำเป็น

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับการทำงานกับเมทาดาทาการนำเสนอ

## **ตรวจสอบฟอร์แมตของการนำเสนอ**

ก่อนที่จะทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในฟอร์แมตใด (PPT, PPTX, ODP และอื่น ๆ) ในขณะนี้

คุณสามารถตรวจสอบฟอร์แมตของการนำเสนอโดยไม่ต้องโหลดการนำเสนอ ดูโค้ด JavaScript นี้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// ไฟล์ PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// ไฟล์ PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ไฟล์ ODP
```

## **รับคุณสมบัติการนำเสนอ**

โค้ด JavaScript นี้แสดงวิธีการรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

คุณอาจต้องการดู [คุณสมบัติภายใต้คลาส DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) 

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) ที่ทำให้คุณสามารถแก้ไขคุณสมบัติการนำเสนอได้

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติของเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนคุณสมบัติของเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะความปลอดภัย คุณอาจพบว่าลิงก์เหล่านี้เป็นประโยชน์:

- [ปกป้องการนำเสนอด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/)
- [ปกป้องการนำเสนอจากการเขียน](/slides/th/nodejs-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบว่าฟอนต์ฝังอยู่หรือไม่และเป็นฟอนต์ใดบ้างได้อย่างไร?**

ค้นหา [ข้อมูลฟอนต์ที่ฝังไว้](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) ที่ระดับการนำเสนอ จากนั้นเปรียบเทียบรายการนั้นกับชุด [ฟอนต์ที่ใช้งานจริงในเนื้อหา](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getfonts/) เพื่อระบุว่าฟอนต์ใดสำคัญต่อการเรนเดอร์

**ฉันจะตรวจสอบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

วนลูปผ่าน [คอลเลกชันสไลด์](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) และตรวจสอบ [แฟล็กการมองเห็น](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/gethidden/) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวสไลด์ที่กำหนดเองหรือไม่ และว่ามีความแตกต่างจากค่าเริ่มต้นหรือไม่?**

ใช่. เปรียบเทียบ [ขนาดสไลด์](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslidesize/) ปัจจุบันและการวางแนวกับค่าตั้งต้นมาตรฐาน; สิ่งนี้ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก

**มีวิธีที่รวดเร็วในการตรวจสอบว่าชาร์ตอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่. ทวนค้นหาทุก [ชาร์ต](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/) ตรวจสอบ [แหล่งข้อมูล](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) แล้วบันทึกว่าข้อมูลเป็นภายในหรือเป็นลิงก์ รวมถึงลิงก์ที่เสียหายด้วย

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจชะลอการเรนเดอร์หรือการส่งออกเป็น PDF ได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนอ็อบเจ็กต์และมองหาภาพขนาดใหญ่, ความโปร่งใส, เงา, การเคลื่อนไหว, และมัลติมีเดีย; จากนั้นกำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดที่อาจทำให้ประสิทธิภาพลดลง