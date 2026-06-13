---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอโดยใช้ PHP
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/php-java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, อ่าน, อัปเดต, และลบแท็กและข้อมูลกำหนดเองใน Aspose.Slides สำหรับ PHP ผ่าน Java, พร้อมตัวอย่างสำหรับการนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลแบบกำหนดเองในงานนำเสนอ PowerPoint อย่างไร โดยสรุปสั้น ๆ เกี่ยวกับการจัดเก็บข้อมูลในไฟล์ PPTX และชี้ให้เห็นว่าข้อมูลเฉพาะของการนำเสนอสามารถอยู่ในรูปของแท็กและส่วน XML แบบกำหนดเอง และอธิบายว่าแท็กเป็นคู่คีย์‑ค่าแบบสตริง

บทความยังแสดงวิธีการอ่านค่าของแท็กและวิธีการเพิ่มแท็กลงในงานนำเสนอ สไลด์แต่ละสไลด์ หรือรูปทรง นอกจากนี้ยังครอบคลุมงานทั่วไปในการจัดการแท็ก เช่น การลบแท็กทั้งหมด การลบแท็กโดยใช้ชื่อ และการดึงรายการชื่อแท็ก

## **การจัดเก็บข้อมูลในไฟล์การนำเสนอ**

ไฟล์ PPTX—ไฟล์ที่มีนามสกุล .pptx—ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML ฟอร์แมต Office Open XML กำหนดโครงสร้างของข้อมูลที่อยู่ในงานนำเสนอ

เมื่อ *slide* เป็นหนึ่งในองค์ประกอบของงานนำเสนอ *slide part* จะบรรจุเนื้อหาของสไลด์เดียว Slide part สามารถมีความสัมพันธ์ที่ชัดเจนกับหลายส่วน—เช่น User Defined Tags—ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลแบบกำหนดเอง (เฉพาะของการนำเสนอ) หรือข้อมูลของผู้ใช้สามารถอยู่ในรูปของแท็ก ([TagCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/)) และ CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpartcollection/))

{{% alert color="primary" %}} 
แท็กโดยพื้นฐานคือค่าคู่คีย์‑สตริง
{{% /alert %}} 

## **รับค่าแท็ก**

ใน Slides แท็กสอดคล้องกับเมธอด [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getKeywords) และ [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#setKeywords) ตัวอย่างโค้ดต่อไปนี้จะแสดงวิธีการดึงค่าของแท็กด้วย Aspose.Slides for PHP via Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มแท็กในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กในงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองส่วน:

- ชื่อของคุณสมบัติแบบกำหนดเอง - `MyTag`
- ค่า ของคุณสมบัติแบบกำหนดเอง - `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอบางชุดตามกฎหรือคุณสมบัติเฉพาะ คุณอาจได้รับประโยชน์จากการเพิ่มแท็กลงในงานนำเสนนั้น ๆ ตัวอย่างเช่น หากต้องการจัดกลุ่มงานนำเสนอจากประเทศในอเมริกาเหนือทั้งหมด คุณสามารถสร้างแท็ก “North American” แล้วกำหนดค่าเป็นประเทศที่เกี่ยวข้อง (สหรัฐอเมริกา, เม็กซิโก, แคนาดา)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการเพิ่มแท็กลงใน [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ด้วย Aspose.Slides for PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

สามารถตั้งค่าแท็กสำหรับ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) ได้เช่นกัน:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ใด ๆ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ข้อจำกัด**

แท็กที่ถูกเพิ่มผ่านคอลเลกชันแท็กข้อมูลแบบกำหนดเองโดยใช้ `getCustomData()->getTags()` จะถูกเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น โดยจะ **ไม่** ถูกถ่ายโอนไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุแบบกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุแบบกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `$shape->setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ สไลด์ หรือรูปทรงได้ในการดำเนินการเดียวหรือไม่?**

ได้ คอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/)) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/clear/) ซึ่งจะลบคู่คีย์‑ค่าทั้งหมดในครั้งเดียว

**ฉันจะลบแท็กเดี่ยวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้เมธอด [remove(name)](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/remove/) บนคอลเลกชันแท็กเพื่อทำการลบแท็กโดยใช้คีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือกรองได้อย่างไร?**

ใช้เมธอด [getNamesOfTags](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/getnamesoftags/) บนคอลเลกชันแท็ก จะได้อาร์เรย์ที่ประกอบด้วยชื่อแท็กทั้งหมด