---
title: จัดการคุณสมบัตางานนำเสนอใน PHP
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
- ภาษาตรวจทาน
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ PHP ผ่าน Java และเพิ่มประสิทธิภาพการค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณ"
---
## **บทนำ**

Aspose.Slides for PHP via Java รองรับ **built-in** และ **custom** คุณสมบัติเอกสาร ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาเดตาของงานนำเสนอ เช่น ผู้เขียน ชื่อเรื่อง และค่าที่กำหนดโดยผู้ใช้

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) อินสแตนซ์ของคลาสนี้จะถูกส่งคืนโดย [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีอ่าน แก้ไข และจัดการคุณสมบัติเหล่านี้ โดยสมมติว่า PHP/Java Bridge และตัวห่อ Aspose.Slides PHP ได้รับการตั้งค่าแล้ว

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาเดตาของแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลเชิงบรรยายพร้อมกับเนื้อหางานนำเสนอ พวกมันแบ่งออกเป็นสองประเภท:

- **Built-in properties** มีเมตาเดตามาตรฐาน เช่น ชื่อเรื่อง ผู้เขียน และสถิติเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่กำหนดโดยผู้ใช้

Aspose.Slides for PHP via Java ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาเดตาของเอกสาร กล่องโต้ตอบจะจัดข้อมูลเป็นแท็บ เช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่กำหนดเอง

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่ถูกเข้ารหัส**

รหัสผ่านเปิดทำให้ทั้งเนื้อหางานนำเสนอและคุณสมบัติเอกสารได้รับการปกป้องโดยปกติ เมื่อทำการเข้ารหัสงานนำเสนอหลังจากเรียก [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) ด้วย `false` คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถเรียก [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) ด้วย `true` และอ่านเมตาเดตาสาธารณะโดยไม่ต้องระบุรหัสผ่านเปิด

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ถอดรหัสอะไร หากคุณสมบัติถูกรวมอยู่ในกระบวนการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้ถูกเข้ารหัส ตัวเลือกจะถูกละเว้นและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างต้องมีงานนำเสนอที่เข้ารหัสซึ่งคุณสมบัติเอกสารถูกทำให้เป็นสาธารณะ ตรวจสอบโหมดการโหลดผ่าน [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) แล้วอ่านคุณสมบัติในตัวผ่าน [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

ในโหมดนี้เนื้อหา slide จะไม่ถูกโหลด Slides, masters, layouts, shapes, media และอ็อบเจ็กต์งานนำเสนออื่น ๆ จะไม่พร้อมใช้งาน ควรตรวจสอบ [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) เสมอก่อนทำการใด ๆ ที่ต้องการโมเดลอ็อบเจ็กต์ของงานนำเสนอเต็มรูปแบบ

{{% alert color="warning" title="Warning" %}}
เมตาเดตาสาธารณะอาจเปิดเผยชื่อผู้เขียน ชื่อเรื่อง หัวเรื่อง คำสำคัญ ข้อมูลบริษัท ความคิดเห็น และค่าที่กำหนดเอง เข้ารหัสคุณสมบัติที่สำคัญพร้อมกับงานนำเสนอ ให้ทำให้เป็นสาธารณะเฉพาะเมื่อระบบการจัดทำดัชนี การจัดประเภท การค้นหา หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่มีรหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดหลังจากเรียก [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) ด้วย `true` มีจุดประสงค์เพื่ออ่านเมตาเดตาสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติต่าง ๆ จากอ็อบเจ็กต์แบบเมตาเดตาอย่างเดียวได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดที่ถูกต้องและการโหลดเต็มรูปแบบ

ตัวอย่างต้องมีงานนำเสนอ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านเปิดที่ทราบ เปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), อัปเดตคุณสมบัติในตัวสาธารณะ, แล้วบันทึกผลลัพธ์ จากนั้นใช้ [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาเดตาสาธารณะโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่ :

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
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
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
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ ควรถือว่าคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่านอย่างเดียว

## **เข้าถึงคุณสมบัติในตัว**

คลาส [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) เปิดเผยเมตาเดตาในตัวผ่านเมธอด getter เช่น [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/), และ [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาเดตาที่จัดเก็บลงคอนโซล ค่าต่าง ๆ ขึ้นอยู่กับงานนำเข้าสำหรับบางฟิลด์อาจว่างเปล่า

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **แก้ไขคุณสมบัติในตัว**

เพื่ออัปเดตเมตาเดตาในตัว ให้ใช้เมธอด setter บนวัตถุที่ได้จาก [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่, เรียก [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/), และ [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ไฟล์ PPTX ที่บันทึกจะมีเมตาเดตาใหม่

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **จัดการ Hyperlink Base**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) คืนค่า base ระดับเอกสารสำหรับ hyperlink แบบสัมพันธ์ ใช้ [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) เพื่อเปลี่ยนหรือเคลียร์ค่า นี้เป็นประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งอื่น มันแยกจาก [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) ของ hyperlink individual: การเปลี่ยน base จะไม่เขียนทับที่อยู่ลิงก์ที่จัดเก็บหรือเปลี่ยนปลายทางแบบ absolute

ตัวอย่างต้องมีงานนำเสนอที่มีทั้งลิงก์สัมพันธ์ เช่น `target.html` และลิงก์ absolute เช่น `https://example.org/absolute.html` อ่าน base ที่มีอยู่, กำหนด base ใหม่, แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อเช็คค่า จากนั้นเคลียร์ base ด้วยสตริงว่างและตรวจสอบค่าว่างในไฟล์ที่บันทึกแยกต่างหาก แทนที่ที่อยู่ base ตัวอย่างด้วยตำแหน่งของไฟล์ที่เชื่อมโยงของคุณ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

ข้อความตรวจสอบทั้งสองควรพิมพ์ `true` การเคลียร์ base จะไม่ทำให้ที่อยู่ hyperlink แต่ละตัวเสียหาย

ลิงก์สัมพันธ์ `target.pptx` เปิด `old/target.pptx` เมื่อ base ชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยน base ไปที่โฟลเดอร์ `new`, บันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์ absolute ยังคงเปิดไฟล์เดิม ทดสอบลิงก์สัมพันธ์ของคุณใน PowerPoint ก่อนและหลังการย้ายงานนำเสนอหรือเปลี่ยน base

## **เพิ่มคุณสมบัติการนำเสนอแบบกำหนดเอง**

คุณสมบัติแบบกำหนดเองเก็บเมตาเดตาที่ไม่มีฟิลด์ในตัวที่สอดคล้องกัน วิธี [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) ช่วยให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่าข้อความสองค่าและค่าเวอร์ชันเป็นจำนวนเต็ม, แล้วบันทึกงานนำเสนอด้วย [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) การกำหนดค่าที่มีชื่อซ้ำจะเขียนทับค่าที่มีอยู่

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติแบบกำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) เพื่อวนลูปผ่านมัน [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้โดย [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลขโดยไม่คำนึงถึงประเภทเดิม, แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติแบบกำหนดเอง ลูปจะไม่ทำการเปลี่ยนแปลงใด ๆ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อตรวจสอบวิธีทำงานกับคุณสมบัติเ�เอกสารด้วย Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติในตัวจากงานนำเสนอได้อย่างไร?**

คุณสมบัติในตัวเป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่าของมันหรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติที่กำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติที่กำหนดเองที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?**

ได้ ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) แล้วตามด้วย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) เพื่ออ่านเมตาเดตาเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ดูตัวอย่างการสร้างรายงานแบบน้ำหนักเบาใน [Build a Lightweight Presentation Inventory](/slides/th/php-java/examine-presentation/) สำหรับข้อจำกัดเฉพาะรูปแบบ

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดได้หรือไม่?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) ด้วย `false` และต้องถูกโหลดหลังจากเรียก [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) ด้วย `true`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document-properties-only ได้หรือไม่?**

ไม่ได้ ข้อมูลคุณสมบัติสาธารณะและเข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดที่ถูกต้อง