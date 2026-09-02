---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน PHP
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาเดต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides อธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติเ�เอกสาร, และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น

ตัวอย่างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับทำงานกับเมตาเดตาของการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่น ๆ) ณ ขณะนั้น

คุณสามารถตรวจสอบรูปแบบของการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอ ดูโค้ด PHP นี้:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **รับคุณสมบัติการนำเสนอ**

โค้ด PHP นี้แสดงวิธีรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

คุณอาจต้องการดู [คุณสมบัติของ DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#DocumentProperties--) class.

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ที่ให้คุณเปลี่ยนแปลงคุณสมบัติการนำเสนอได้

สมมติว่าเรามีไฟล์ PowerPoint ที่มีคุณสมบัติเอกสารดังแสดงด้านล่าง

![Original document properties of the PowerPoint presentation](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีแก้ไขบางคุณสมบัติของการนำเสนอ:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

ผลลัพธ์ของการเปลี่ยนคุณสมบัติเอกสารแสดงด้านล่าง

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะความปลอดภัย คุณอาจพบว่าลิงก์เหล่านี้มีประโยชน์:

- [การป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/)
- [การป้องกันการเขียนของการนำเสนอ](/slides/th/php-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ถูกฝังไว้และเป็นฟอนต์ใดบ้าง?**

ค้นหาข้อมูล [embedded-font]((https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getembeddedfonts/)) ที่ระดับการนำเสนอ แล้วเปรียบเทียบรายการนั้นกับชุด [fonts ที่ถูกใช้จริงในเนื้อหา]((https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getfonts/)) เพื่อระบุฟอนต์ที่สำคัญต่อการเรนเดอร์

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนไว้หรือไม่และมีจำนวนเท่าไหร่?**

วนผ่าน [slide collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag]((https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/gethidden/)) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวสไลด์แบบกำหนดเองและต่างจากค่าเริ่มต้นหรือไม่?**

ได้ เปรียบเทียบ [slide size]((https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getslidesize/)) และการวางแนวปัจจุบันกับค่าพรีเซ็ตมาตรฐาน เพื่อคาดการณ์พฤติกรรมการพิมพ์และการส่งออก

**มีวิธีเร็ว ๆ ที่จะดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่ วนตรวจสอบทุก [chart]((https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/)) ตรวจสอบ [data source]((https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getdatasourcetype/)) ของมัน และบันทึกว่าข้อมูลเป็นภายในหรือเป็นลิงก์ รวมถึงลิงก์ที่เสียหายด้วย

**ฉันจะประเมินสไลด์ที่ “หนัก” ซึ่งอาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ นับจำนวนอ็อบเจ็กต์และตรวจหาภาพขนาดใหญ่, ความโปร่งแสง, เงา, แอนิเมชัน, มัลติมีเดีย แล้วกำหนดคะแนนความซับซ้อนคร่าว ๆ เพื่อระบุจุดที่อาจเป็นคอขวดของประสิทธิภาพ