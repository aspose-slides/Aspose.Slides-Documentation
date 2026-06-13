---
title: จัดการคุณสมบัติพรีเซนเทชันใน PHP
linktitle: คุณสมบัติเพรีเซนเทชัน
type: docs
weight: 70
url: /th/php-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติพรีเซนเทชัน
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "ควบคุมคุณสมบัติพรีเซนเทชันใน Aspose.Slides for PHP via Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระบบระเบียบมากขึ้น"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ API ของ Aspose.Slides

Aspose.Slides ให้คุณทำงานกับคุณสมบัติของเอกสารพรีเซนเทชันผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/)  ตัวอินสแตนซ์ของคลาสนี้จะถูกคืนค่าจากเมธอด [Presentation::getDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="primary" %}} 

กรุณาทราบว่า ฟิลด์ **Application** และ **Producer** ไม่สามารถแก้ไขได้ เนื่องจากฟิลด์เหล่านี้จะแสดงเป็น “Aspose Ltd.” และ “Aspose.Slides for PHP via Java x.x.x” เสมอ

{{% /alert %}} 

## **จัดการคุณสมบัติพรีเซนเทชัน**

Microsoft PowerPoint มีฟีเจอร์ให้เพิ่มคุณสมบัติบางอย่างลงในไฟล์พรีเซนเทชัน คุณสมบัติเบื้องต้นเหล่านี้ช่วยให้ข้อมูลที่เป็นประโยชน์ถูกจัดเก็บร่วมกับเอกสาร (ไฟล์พรีเซนเทชัน) มีคุณสมบัติของเอกสารสองประเภทดังต่อไปนี้

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** properties มีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเอกสาร, ชื่อผู้เขียน, สถิติของเอกสาร ฯลฯ  **Custom** properties คือคุณสมบัติที่ผู้ใช้กำหนดเป็นคู่ **Name/Value** ซึ่งทั้งชื่อและค่าได้รับการกำหนดโดยผู้ใช้  ด้วย Aspose.Slides for PHP via Java นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติ built-in และ custom ได้

## **คุณสมบัติของเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 รองรับการจัดการคุณสมบัติของไฟล์พรีเซนเทชัน เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ตามที่แสดงด้านล่าง:

|**Selecting Advanced Properties menu item**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

เมื่อคุณเลือกเมนู **Advanced Properties** จะปรากฏหน้าต่างที่ให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ตามรูปด้านล่าง:

|**Properties Dialog**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **Properties Dialog** ข้างต้นคุณจะเห็นแท็บหลายหน้า เช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom**  แท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติ custom ของไฟล์ PowerPoint

### ทำงานกับคุณสมบัติของเอกสารโดยใช้ Aspose.Slides for PHP via Java

อย่างที่อธิบายไว้ก่อนหน้านี้ Aspose.Slides for PHP via Java รองรับคุณสมบัติของเอกสารสองประเภท คือ **Built-in** และ **Custom**  ดังนั้นนักพัฒนาสามารถเข้าถึงคุณสมบัติเหล่านี้ได้ผ่าน API ของ Aspose.Slides for PHP via Java  Aspose.Slides for PHP via Java มีคลาส [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties) ซึ่งแสดงคุณสมบัติของเอกสารที่เชื่อมโยงกับไฟล์พรีเซนเทชันผ่านคุณสมบัติ **Presentation.DocumentProperties**

นักพัฒนาสามารถใช้คุณสมบัติ **DocumentProperties** ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติของไฟล์พรีเซนเทชันตามที่อธิบายด้านล่าง

## **เข้าถึง Built-in Properties**

คุณสมบัติที่เปิดโดยอ็อบเจ็กต์ [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties) มี: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** และ **Title**

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนพรีเซนเทชัน
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงถึงออบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # แสดงคุณสมบัติ built-in
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

## **แก้ไข Built-in Properties**

การแก้ไขคุณสมบัติ built‑in ของไฟล์พรีเซนเทชันทำได้ง่ายเท่ากับการเข้าถึง เพียงกำหนดค่าเป็นสตริงให้กับคุณสมบัติที่ต้องการแล้วค่าจะถูกอัปเดต ตัวอย่างด้านล่างแสดงวิธีการแก้ไขคุณสมบัติเบื้องต้นของไฟล์พรีเซนเทชันโดยใช้ Aspose.Slides for PHP via Java

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # ตั้งค่าคุณสมบัติ built-in
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # บันทึกพรีเซนเทชันของคุณเป็นไฟล์
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ตัวอย่างนี้แก้ไขคุณสมบัติ built‑in ของพรีเซนเทชันและผลลัพธ์สามารถดูได้ดังต่อไปนี้:

|**Built-in document properties after modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่ม Custom Document Properties**

Aspose.Slides for PHP via Java ยังอนุญาตให้ผู้พัฒนาเพิ่มค่า custom ให้กับคุณสมบัติของพรีเซนเทชัน ตัวอย่างด้านล่างแสดงวิธีการตั้งค่าคุณสมบัติ custom สำหรับพรีเซนเทชัน

```php
  $pres = new Presentation();
  try {
    # ดึงคุณสมบัติเอกสาร
    $dProps = $pres->getDocumentProperties();
    # เพิ่มคุณสมบัติ custom
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # ดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # ลบคุณสมบัติที่เลือก
    $dProps->removeCustomProperty($getPropertyName);
    # บันทึกพรีเซนเทชัน
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Custom Document Properties Added**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไข Custom Properties**

Aspose.Slides for PHP via Java ยังให้ผู้พัฒนาสามารถเข้าถึงค่า custom properties ได้ ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไข custom properties ทั้งหมดของพรีเซนเทชัน

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # เข้าถึงและแก้ไขคุณสมบัติ custom
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # แสดงชื่อและค่าของคุณสมบัติ custom
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # แก้ไขค่าของคุณสมบัติ custom
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # บันทึกพรีเซนเทชันของคุณเป็นไฟล์
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ตัวอย่างนี้แก้ไข custom properties ของ [PPTX](https://docs.fileformat.com/presentation/pptx/)  รูปต่อไปนี้แสดง custom properties ของพรีเซนเทชันก่อนและหลังการแก้ไข:

|**Custom Properties before Modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="primary" %}} 

เมธอดใหม่ [readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) และ [writeBindedPresentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) ถูกเพิ่มเข้าไปในคลาส [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo)  ส่วนการทำงานของตัว setter ของคุณสมบัติ [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#setLastSavedTime) ถูกเปลี่ยนแปลง

{{% /alert %}} 

เมธอดใหม่สองตัวคือ [readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) และ [updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) ถูกเพิ่มในคลาส [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo)  พวกมันให้การเข้าถึงคุณสมบัติของเอกสารได้อย่างรวดเร็วและสามารถเปลี่ยนแปลงอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดพรีเซนเทชันทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าบางอย่าง, แล้วอัปเดตเอกสาร ซึ่งสามารถทำได้ดังนี้:

```php
  # อ่านข้อมูลของพรีเซนเทชัน
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # ดึงคุณสมบัติปัจจุบัน
  $props = $info->readDocumentProperties();
  # ตั้งค่าค่าใหม่ของฟิลด์ Author และ Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # อัปเดตพรีเซนเทชันด้วยค่าที่ใหม่
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของพรีเซนเทชันที่กำหนดเป็นเทมเพลตเพื่ออัปเดตคุณสมบัติในพรีเซนเทชันอื่น ๆ:

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

สามารถสร้างเทมเพลตใหม่จากศูนย์แล้วใช้เพื่ออัปเดตพรีเซนเทชันหลายไฟล์ได้:

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

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มีคุณสมบัติ LanguageId (ที่เปิดโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่จะตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด PHP ด้านล่างแสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint: xxx ทำไม LanguageId ถึงไม่มีในคลาส Java PortionFormat?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// ตั้งค่า Id ของภาษาการตรวจสอบ

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด PHP นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับพรีเซนเทชัน PowerPoint ทั้งหมด:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # ตรวจสอบภาษาของ portion แรก
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **FAQ**

**จะลบคุณสมบัติ built‑in ออกจากพรีเซนเทชันได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนที่ไม่สามารถแยกออกจากพรีเซนเทชันได้อย่างสมบูรณ์ แต่คุณสามารถเปลี่ยนค่า หรือกำหนดค่าเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**ถ้าฉันเพิ่ม custom property ที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

ถ้าคุณเพิ่ม custom property ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คค่าก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติของพรีเซนเทชันโดยไม่ต้องโหลดพรีเซนเทชันทั้งหมดได้หรือไม่?**

ได้ คุณสามารถเข้าถึงคุณสมบัติโดโดยใช้เมธอด `getPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `readDocumentProperties` ที่มาจากคลาส [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ช่วยประหยัดหน่วยความจำและเพิ่มประสิทธิภาพการทำงาน