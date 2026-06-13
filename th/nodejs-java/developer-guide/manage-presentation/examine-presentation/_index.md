---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน JavaScript
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/nodejs-java/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
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
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย JavaScript เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ฉลาดขึ้น"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีการกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติของเอกสาร, และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น.

ตัวอย่างเหล่านี้อ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับทำงานกับเมตาดาทาของการนำเสนอ.

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนจะทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนอนั้นอยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่น ๆ) ในขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอ ดูโค้ด JavaScript ตัวนี้:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **รับคุณสมบัติการนำเสนอ**

โค้ด JavaScript นี้แสดงวิธีการรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

คุณอาจต้องการดูคุณสมบัติภายใต้คลาส [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--).

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) ที่ช่วยให้คุณสามารถทำการเปลี่ยนแปลงคุณสมบัติการนำเสนอได้.

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติของเอกสารแสดงด้านล่างนี้.

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีการแก้ไขคุณสมบัติบางอย่างของการนำเสนอ:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนคุณสมบัติเอกสารแสดงด้านล่างนี้.

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะความปลอดภัยของมัน คุณอาจพบว่าลิงก์เหล่านี้เป็นประโยชน์:

- [การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่](https://docs.aspose.com/slides/th/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [การตรวจสอบว่าการนำเสนอถูกป้องกันการเขียน (อ่านอย่างเดียว)](https://docs.aspose.com/slides/th/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [การตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านก่อนโหลด](https://docs.aspose.com/slides/th/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [การยืนยันรหัสผ่านที่ใช้ในการป้องกันการนำเสนอ](https://docs.aspose.com/slides/th/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**ฉันจะตรวจสอบว่าฟอนต์ถูกฝังอยู่หรือไม่และเป็นฟอนต์ใด?**

มองหาข้อมูล [embedded-font information](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) ระดับการนำเสนอ จากนั้นเปรียบเทียบรายการเหล่านั้นกับชุดของ [fonts actually used across content](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getfonts/) เพื่อระบุฟอนต์ใดที่สำคัญต่อการแสดงผล.

**ฉันจะตรวจสอบอย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไหร่?**

วนลูปผ่าน [slide collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/gethidden/) ของแต่ละสไลด์.

**ฉันสามารถตรวจจับได้หรือไม่ว่าขนาดและแนวตั้งของสไลด์ที่กำหนดเองถูกใช้และว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้เลย เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslidesize/) และแนวตั้งกับค่ามาตรฐาน; สิ่งนี้ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก.

**มีวิธีรวดเร็วในการตรวจสอบว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้เลย เรียกดู [charts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/) ทั้งหมด, ตรวจสอบ [data source](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ของพวกมัน, และบันทึกว่าข้อมูลเป็นภายในหรืออ้างอิงลิงก์ รวมถึงลิงก์ที่เสียหาย.

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนวัตถุและมองหารูปภาพขนาดใหญ่, ความโปร่งใส, เงา, เอฟเฟกต์การเคลื่อนไหว และสื่อมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดที่อาจทำให้ประสิทธิภาพช้า.