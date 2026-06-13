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
- เปลี่ยนแปลงคุณสมบัติ
- ปรับแก้คุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น"
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides ซึ่งอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็มอ่านคุณสมบัติของเอกสารและอัปเดตคุณสมบัติเหล่านั้นเมื่อต้องการ

ตัวอย่างเหล่านี้อ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับทำงานกับเมตาดาต้าการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนจะทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่น ๆ) ในขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอโดยไม่ต้องโหลดการนำเสนอได้ ดูโค้ด PHP นี้:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **รับคุณสมบัติการนำเสนอ**

โค้ด PHP นี้แสดงวิธีการรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

คุณอาจต้องการดู [คุณสมบัติต่าง ๆ ภายใต้ DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#DocumentProperties--) class.

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ที่ช่วยให้คุณสามารถเปลี่ยนแปลงคุณสมบัติการนำเสนอได้

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติเอกสารแสดงดังต่อไปนี้

![คุณสมบัติเ�เอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีการแก้ไขคุณสมบัติการนำเสนอบางส่วน:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติเอกสารจะแสดงด้านล่าง

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

หากต้องการข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะความปลอดภัยของมัน คุณอาจพบว่าลิงก์เหล่านี้เป็นประโยชน์:

- [ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่](https://docs.aspose.com/slides/th/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียน (อ่านอย่างเดียว) หรือไม่](https://docs.aspose.com/slides/th/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านก่อนโหลดหรือไม่](https://docs.aspose.com/slides/th/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [ยืนยันรหัสผ่านที่ใช้ป้องกันการนำเสนอ](https://docs.aspose.com/slides/th/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบว่าแบบอักษรถูกฝังและเป็นแบบไหนได้อย่างไร?**

มองหาข้อมูลแบบอักษรที่ฝังอยู่ระดับการนำเสนอ จากนั้นเปรียบเทียบรายการนั้นกับชุดแบบอักษรที่ใช้จริงในเนื้อหาเพื่อระบุว่าแบบอักษรใดสำคัญต่อการเรนเดอร์

**ฉันจะตรวจสอบอย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่และจำนวนเท่าไหร่?**

วนลูปผ่าน [slide collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) และตรวจสอบแต่ละสไลด์ของ [visibility flag](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/gethidden/)

**ฉันสามารถตรวจจับว่ามีการใช้ขนาดและการวางแนวสไลด์กำหนดเองหรือไม่ และว่ามีความแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้เลย. เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getslidesize/) และการวางแนวปัจจุบันกับค่ามาตรฐาน ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก

**มีวิธีรวดเร็วในการดูว่าชาร์ตอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้. ไปตาม [charts](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/) ทั้งหมด ตรวจสอบ [data source](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getdatasourcetype/) ของพวกมัน และบันทึกว่าข้อมูลเป็นภายในหรือเชื่อมโยง รวมถึงลิงก์ที่เสีย

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนอ็อบเจกต์และตรวจหาภาพขนาดใหญ่ ความโปร่งใส เงา แอนิเมชัน และมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุตำแหน่งที่อาจทำให้ประสิทธิภาพลดลง