---
title: จัดการคุณสมบัติงานนำเสนอใน PHP
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/php-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาเดตาเอกสาร
- แก้ไขเมตาเดตา
- ภาษาตรวจสอบคำสะกด
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides for PHP via Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระเบียบและมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **ในตัว** และ **กำหนดเอง**. ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้ง่ายโดยใช้ Aspose.Slides API.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติของเอกสารงานนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/) ตัวอย่างของคลาสนี้จะถูกส่งคืนโดยเมธอด [Presentation::getDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีอ่าน, แก้ไขและจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="หมายเหตุ" %}}
โปรดทราบว่า ฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับฟิลด์เหล่านี้ทุกครั้งที่บันทึก ดังนั้นงานนำเสนอที่บันทึกแล้วจะรายงานเป็น "Aspose.Slides for PHP via Java" และเวอร์ชันของไลบรารีที่สร้างมัน ค่าใด ๆ ที่ส่งให้ `setNameOfApplication` จะถูกละทิ้งเมื่อเขียนงานนำเสนอ
{{% /alert %}} 

## **จัดการคุณสมบัติของงานนำเสนอ**

Microsoft PowerPoint มีคุณลักษณะให้เพิ่มคุณสมบัติบางอย่างลงในไฟล์งานนำเสนอ คุณสมบัติของเอกสารเหล่านี้อนุญาตให้เก็บข้อมูลที่เป็นประโยชน์ไว้พร้อมกับเอกสาร (ไฟล์งานนำเสนอ) มีสองประเภทของคุณสมบัติเบื้องต้นดังต่อไปนี้

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

คุณสมบัติ **ในตัว** มีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเอกสาร, ชื่อผู้เขียน, สถิติของเอกสาร เป็นต้น คุณสมบัติ **กำหนดเอง** คือคุณสมบัติที่ผู้ใช้กำหนดเป็นคู่ **ชื่อ/ค่า**, โดยทั้งชื่อและค่าถูกกำหนดโดยผู้ใช้ โดยใช้ Aspose.Slides for PHP via Java นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติในตัวเช่นเดียวกับคุณสมบัติที่กำหนดเองได้

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 ให้คุณจัดการคุณสมบัติของเอกสารงานนำเสนอได้ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

หลังจากคุณเลือกเมนู **Advanced Properties** จะปรากฏกล่องโต้ตอบที่ให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ดังที่แสดงในรูปต่อไปนี้:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **Properties Dialog** ข้างบน คุณจะเห็นแท็บหลายหน้า เช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom**. แท็บเหล่านี้อนุญาตให้กำหนดข้อมูลประเภทต่าง ๆ ที่เกี่ยวกับไฟล์ PowerPoint ได้ แท็บ **Custom** ใช้เพื่อจัดการคุณสมบัติที่กำหนดเองของไฟล์ PowerPoint

### ทำงานกับคุณสมบัติของเอกสารโดยใช้ Aspose.Slides for PHP via Java

ตามที่อธิบายไว้ข้างต้น Aspose.Slides for PHP via Java รองรับคุณสมบัติของเอกสารสองประเภท คือ **ในตัว** และ **กำหนดเอง** ดังนั้นนักพัฒนาจึงสามารถเข้าถึงคุณสมบัติทั้งสองประเภทโดยใช้ Aspose.Slides for PHP via Java API ได้ Aspose.Slides for PHP via Java มีคลาส [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties) ที่เป็นตัวแทนของคุณสมบัติของเอกสารที่เชื่อมโยงกับไฟล์งานนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**.

นักพัฒนาสามารถใช้คุณสมบัติ **DocumentProperties** ที่เปิดเผยโดยออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติของไฟล์งานนำเสนอได้ตามที่อธิบายด้านล่าง:

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดไฟล์มักจะปกป้องทั้งเนื้อหาและคุณสมบัติของงานนำเสนอ เมื่อทำการเข้ารหัสงานนำเสนอโดยส่งค่า `false` ไปยังเมธอด [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) คุณสมบัติของเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถส่งค่า `true` ไปยังเมธอด [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) เพื่ออ่านเมตาดาต้าสาธารณะโดยไม่ต้องใส่รหัสผ่านเปิดไฟล์

ตัวเลือก “document‑properties‑only” ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ทำการถอดรหัสใด ๆ หากคุณสมบัติกับการเข้ารหัสรวมอยู่ การโหลดโดยไม่ใส่รหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้เข้ารหัส ตัวเลือกจะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างต่อไปตรวจสอบโหมดการโหลดผ่านเมธอด [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) แล้วอ่านคุณสมบัติ **ในตัว** ผ่านเมธอด [Presentation::getDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

ในโหมดนี้ เนื้อหาแบบสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ และออบเจ็กต์อื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ก่อนทำการดำเนินการที่ต้องการแบบจำลองออบเจ็กต์ของงานนำเสนอเต็มรูปแบบเสมอ

{{% alert color="warning" title="คำเตือน" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็นและค่าที่กำหนดเอง ควรเข้ารหัสคุณสมบัติที่สำคัญพร้อมกับงานนำเสนอ เก็บไว้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, จัดประเภท, ค้นหา หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดในโหมด “document‑properties‑only” มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงของคุณสมบัติจากออบเจ็กต์แบบ “metadata‑only” นี้ได้ เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลในงานนำเสนอที่เข้ารหัส ดังนั้นการอัปเดตจำเป็นต้องมีรหัสผ่านเปิดไฟล์ที่ถูกต้องและการโหลดแบบสมบูรณ์

ตัวอย่างต่อไปเปิดงานนำเสนอด้วยเมธอด [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) จากนั้นอัปเดตคุณสมบัติ **ในตัว** สาธารณะและบันทึกผลลัพธ์ หลังจากนั้นใช้เมธอด [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#isEncrypted) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่ใช้รหัสผ่านเพื่อยืนยันค่าที่อัปเดต:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาของงานนำเสนอ มันต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึงคุณสมบัติในตัว**

คุณสมบัติที่เปิดเผยโดยออบเจ็กต์ [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties) มีดังนี้: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ครั้งสุดท้าย), **LastModifiedBy**, **SharedDoc** (แชร์ระหว่างผู้ผลิตหลายคน?), **PresentationFormat**, **Subject** และ **Title**

```php
  # สร้างคลาส Presentation ที่เป็นตัวแทนของงานนำเสนอ
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงไปยังออบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # แสดงคุณสมบัติในตัว
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แก้ไขคุณสมบัติในตัว**

การแก้ไขคุณสมบัติในตัวของไฟล์งานนำเสนอทำได้ง่ายเท่ากับการเข้าถึงคุณสมบัติ คุณสามารถกำหนดค่าแบบสตริงให้กับคุณสมบัติใดก็ได้และค่าจะถูกแก้ไข ตัวอย่างด้านล่างแสดงวิธีการแก้ไขคุณสมบัติเอกสารในตัวของไฟล์งานนำเสนอโดยใช้ Aspose.Slides for PHP via Java

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงไปยังออบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # ตั้งค่าคุณสมบัติในตัว
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # บันทึกงานนำเสนอของคุณลงไฟล์
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ตัวอย่างนี้แก้ไขคุณสมบัติในตัวของงานนำเสนอที่สามารถดูผลลัพธ์ได้ตามรูปด้านล่าง:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติเอกสารที่กำหนดเอง**

Aspose.Slides for PHP via Java ยังอนุญาตให้นักพัฒนาตั้งค่าคุณสมบัติที่กำหนดเองสำหรับงานนำเสนอ ตัวอย่างด้านล่างแสดงวิธีตั้งค่าคุณสมบัติที่กำหนดเองสำหรับงานนำเสนอ

```php
  $pres = new Presentation();
  try {
    # รับคุณสมบัติเอกสาร
    $dProps = $pres->getDocumentProperties();
    # เพิ่มคุณสมบัติที่กำหนดเอง
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # รับชื่อคุณสมบัติที่ดัชนีที่ระบุ
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # ลบคุณสมบัติที่เลือก
    $dProps->removeCustomProperty($getPropertyName);
    # บันทึกงานนำเสนอ
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง**

Aspose.Slides for PHP via Java ยังอนุญาตให้นักพัฒนาถึงค่า ของคุณสมบัติที่กำหนดเองได้ ตัวอย่างด้านล่างแสดงวิธีเข้าถึงและแก้ไขคุณสมบัติที่กำหนดเองทั้งหมดของงานนำเสนอ

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงไปยังออบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # แสดงชื่อและค่าของคุณสมบัติที่กำหนดเอง
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # แก้ไขค่าของคุณสมบัติที่กำหนดเอง
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # บันทึกงานนำเสนอของคุณลงไฟล์
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ตัวอย่างนี้แก้ไขคุณสมบัติที่กำหนดเองของ [PPTX](https://docs.fileformat.com/presentation/pptx/) งานนำเสนอ รูปต่อไปนี้แสดงคุณสมบัติก่อนและหลังการแก้ไข:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" title="หมายเหตุ" %}}
มีการเพิ่มเมธอดใหม่ [readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) และ [writeBindedPresentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) ไปยังคลาส [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo) ส่วนการทำงานของเซตเตอร์ [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#setLastSavedTime) ถูกเปลี่ยนแปลงเช่นกัน
{{% /alert %}} 

เมธอดใหม่สองตัว [readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) และ [updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) ถูกเพิ่มเข้าไปในคลาส [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดงานนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือต้องโหลดคุณสมบัติ, เปลี่ยนค่าและอัปเดตเอกสาร สามารถทำได้ตามตัวอย่างต่อไปนี้:

```php
  # อ่านข้อมูลของงานนำเสนอ
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # รับคุณสมบัติปัจจุบัน
  $props = $info->readDocumentProperties();
  # ตั้งค่าข้อมูลใหม่ของฟิลด์ Author และ Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # อัปเดตงานนำด้วยค่าใหม่
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของงานนำเสนอที่เป็นแม่แบบเพื่ออัปเดตคุณสมบัติในงานนำเสนออื่น ๆ:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้เพื่ออัปเดตหลายงานนำเสนอได้:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **ตั้งค่าภาษาตรวจสอบคำสะกด**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษาตรวจสอบคำสะกดสำหรับเอกสาร PowerPoint ภาษาตรวจสอบคือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด PHP ตัวอย่างนี้แสดงวิธีตั้งค่าภาษาตรวจสอบคำสะกดสำหรับ PowerPoint: xxx ทำไม LanguageId ถึงไม่มีในคลาส PortionFormat ของ Java?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// ตั้งค่า Id ของภาษาตรวจสอบการสะกด

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด PHP ตัวอย่างนี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับงานนำเสนอ PowerPoint ทั้งหมด:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # เพิ่มรูปทรงสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # ตรวจสอบภาษาของส่วนแรก
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Live Example**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติในตัวจากงานนำเสนอได้อย่างไร?**

คุณสมบัติในตัวเป็นส่วนที่สำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**ถ้าฉันเพิ่มคุณสมบัติที่กำหนดเองที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติที่กำหนดเองซึ่งมีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็กคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอทั้งหมดได้หรือไม่?**

ทำได้ ใช้เมธอด [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) แล้วตามด้วย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาต้าโดยไม่ต้องสร้างออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ดูตัวอย่างการรายงานแบบ Light‑weight ใน [Build a Lightweight Presentation Inventory](/slides/th/php-java/examine-presentation/) เพื่อดูข้อจำกัดตามรูปแบบไฟล์

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ได้ใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ คุณสมบัติของเอกสารต้องถูกปิดการเข้ารหัสก่อนที่งานนำเสนอจะถูกเข้ารหัส และงานนำเสนอจะต้องถูกโหลดในโหมด “document‑properties‑only”

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด “document‑properties‑only” ได้หรือไม่?**

ไม่ได้ เนื่องจากข้อมูลคุณสมบัติสาธารณะและเข้ารหัสต้องสอดคล้องกัน การอัปเดตไฟล์ PPTX ที่เข้ารหัสจึงจำเป็นต้องโหลดงานนำเสนอแบบเต็มพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง