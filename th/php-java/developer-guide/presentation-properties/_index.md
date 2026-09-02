---
title: จัดการคุณสมบัติการนำเสนอใน PHP
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/php-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติแบบกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาทาเอกสาร
- แก้ไขเมตาดาทา
- ภาษาการตรวจสอบ
- ภาษาตั้งค่าเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ PHP ผ่าน Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระเบียบมากขึ้น."
---
## **Introduction**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom** ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API

Aspose.Slides ให้คุณทำงานกับคุณสมบัติของเอกสารงานนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/) อินสแตนซ์ของคลาสนี้จะถูกส่งคืนโดยเมธอด [Presentation::getDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข และจัดการคุณสมบัติเหล่านั้น

{{% alert color="info" title="Note" %}}
โปรดทราบว่าฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับค่าเหล่านี้ทุกครั้งที่บันทึก ดังนั้นงานนำเสนอที่บันทึกแล้วจะรายงานเป็น "Aspose.Slides for PHP via Java" พร้อมกับเวอร์ชันของไลบรารีที่ใช้สร้าง หากส่งค่าใด ๆ ไปยัง `setNameOfApplication` ค่านั้นจะถูกละทิ้งเมื่อเขียนงานนำเสนอ
{{% /alert %}} 

## **Manage Presentation Properties**

Microsoft PowerPoint มีคุณสมบัติในการเพิ่มคุณสมบัติบางอย่างลงในไฟล์งานนำเสนอ คุณสมบัติของเอกสารเหล่านี้ช่วยให้สามารถเก็บข้อมูลที่เป็นประโยชน์ไปพร้อมกับเอกสาร (ไฟล์งานนำเสนอ) มีสองประเภทของคุณสมบัติเอกสารดังต่อไปนี้

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

คุณสมบัติ **Built-in** มีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเรื่อง, ชื่อผู้เขียน, สถิติของเอกสาร เป็นต้น คุณสมบัติ **Custom** คือคุณสมบัติที่ผู้ใช้กำหนดเป็นคู่ **Name/Value** โดยทั้งชื่อและค่าเป็นที่กำหนดโดยผู้ใช้ โดยใช้ Aspose.Slides for PHP via Java นักพัฒนา สามารถเข้าถึงและแก้ไขค่าของคุณสมบัติ Built-in รวมถึง Custom ได้

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 ให้การจัดการคุณสมบัติของไฟล์งานนำเสนอ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

หลังจากเลือกเมนู **Advanced Properties** จะปรากฏกล่องโต้ตอบที่ให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ตามรูปด้านล่าง:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **Properties Dialog** ข้างต้น คุณจะพบแท็บหลายหน้า เช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ช่วยกำหนดข้อมูลประเภทต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint แท็บ **Custom** ใช้จัดการคุณสมบัติแบบกำหนดเองของไฟล์ PowerPoint

### ทำงานกับ Document Properties โดยใช้ Aspose.Slides for PHP via Java

ตามที่เราได้อธิบายไว้ก่อนหน้า Aspose.Slides for PHP via Java รองรับคุณสมบัติเอกสารสองประเภท คือ **Built-in** และ **Custom** ดังนั้นนักพัฒนาจึงสามารถเข้าถึงคุณสมบัติทั้งสองประเภทโดยใช้ API ของ Aspose.Slides for PHP via Java Aspose.Slides for PHP via Java มีคลาส [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties) ที่แสดงคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์งานนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**

นักพัฒนาสามารถใช้คุณสมบัติ **DocumentProperties** ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติของไฟล์งานนำเสนอได้ตามที่อธิบายด้านล่าง

## **Access Built-in Properties**

คุณสมบัติที่เปิดเผยโดยอ็อบเจ็กต์ [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties) มีดังนี้: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ล่าสุด), **LastModifiedBy**, **SharedDoc** (แชร์ระหว่างผู้ผลิตหลายคนหรือไม่?), **PresentationFormat**, **Subject** และ **Title**

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของการนำเสนอ
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
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

## **Modify Built-in Properties**

การแก้ไขคุณสมบัติ Built-in ของไฟล์งานนำเสนอทำได้ง่ายเช่นเดียวกับการเข้าถึง เพียงกำหนดค่าเป็นสตริงให้กับคุณสมบัติที่ต้องการ ค่านั้นก็จะถูกเปลี่ยนแปลง ตัวอย่างต่อไปนี้แสดงวิธีการแก้ไขคุณสมบัติเอกสาร Built-in ของไฟล์งานนำเสนอโดยใช้ Aspose.Slides for PHP via Java

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # ตั้งค่าคุณสมบัติในตัว
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # บันทึกการนำเสนอของคุณลงไฟล์
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ตัวอย่างนี้แก้ไขคุณสมบัติ Built-in ของงานนำเสนอโดยผลลัพธ์ที่ได้แสดงดังต่อไปนี้:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides for PHP via Java ยังอนุญาตให้นักพัฒนาสร้างค่าคุณสมบัติแบบกำหนดเองสำหรับ Document ของงานนำเสนอ ตัวอย่างต่อไปนี้แสดงวิธีการตั้งค่าคุณสมบัติแบบกำหนดเองสำหรับงานนำเสนอ

```php
  $pres = new Presentation();
  try {
    # ดึงคุณสมบัติเอกสาร
    $dProps = $pres->getDocumentProperties();
    # เพิ่มคุณสมบัติแบบกำหนดเอง
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # ดึงชื่อคุณสมบัติที่ตำแหน่งดัชนีเฉพาะ
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # ลบคุณสมบัติที่เลือก
    $dProps->removeCustomProperty($getPropertyName);
    # บันทึกการนำเสนอ
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

## **Access and Modify Custom Properties**

Aspose.Slides for PHP via Java ยังอนุญาตให้นักพัฒนาดึงค่าและแก้ไขคุณสมบัติแบบกำหนดเอง ตัวอย่างต่อไปนี้แสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเองทั้งหมดของงานนำเสนอ

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # สร้างอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    $dp = $pres->getDocumentProperties();
    # เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # แก้ไขค่าของคุณสมบัติแบบกำหนดเอง
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # บันทึกการนำเสนอของคุณลงไฟล์
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ตัวอย่างนี้แก้ไขคุณสมบัติแบบกำหนดเองของ [PPTX ](https://docs.fileformat.com/presentation/pptx/) งานนำเสนอ รูปภาพต่อไปนี้แสดงคุณสมบัติแบบกำหนดเองก่อนและหลังการแก้ไข:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" title="Note" %}}
เมธอดใหม่ [readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) และ [writeBindedPresentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) ถูกเพิ่มเข้าไปในคลาส [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo) ส่วนตรรกะของตัวเซ็ตเตอร์ [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#setLastSavedTime) ถูกเปลี่ยนแปลง
{{% /alert %}} 

เมธอดใหม่สองตัว [readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) และ [updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) ถูกเพิ่มเข้าไปในคลาส [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/PresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดงานนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, แก้ไขค่าบางอย่างและอัปเดตเอกสาร ซึ่งสามารถทำได้ดังนี้:

```php
  # อ่านข้อมูลของงานนำเสนอ
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # รับคุณสมบัติปัจจุบัน
  $props = $info->readDocumentProperties();
  # ตั้งค่าค่าใหม่ของฟิลด์ Author และ Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # อัปเดตงานนำเสนอด้วยค่าที่ใหม่
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของงานนำเสนอหนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในงานนำเสนออื่น ๆ:

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

## **Set Proofing Language**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด PHP นี้แสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

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
    $portionFormat->setLanguageId("zh-CN");// ตั้งค่า Id ของภาษาพิสูจน์อักษร

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Default Language**

โค้ด PHP นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับงานนำเสนอ PowerPoint ทั้งหมด:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # เพิ่มรูปทรงสี่เหลี่ยมใหม่พร้อมข้อความ
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

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

คุณสมบัติ Built-in เป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่าของมันหรือกำหนดค่าเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**What happens if I add a custom property that already exists?**

หากคุณเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**Can I access presentation properties without fully loading the presentation?**

ได้ ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) แล้วตามด้วย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาทาเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ดูตัวอย่างการสร้างรายงานแบบเบาในบทความ [Build a Lightweight Presentation Inventory](/slides/th/php-java/examine-presentation/) เพื่อรายละเอียดเพิ่มเติมและข้อจำกัดตามรูปแบบไฟล์.