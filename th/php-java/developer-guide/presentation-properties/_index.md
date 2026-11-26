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
- คุณสมบัติมาตรฐาน
- คุณสมบัติกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมทาดาต้าเอกสาร
- แก้ไขเมทาดาต้า
- ภาษาการพิสูจน์
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides for PHP via Java และทำให้การค้นหา, การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides for PHP via Java สนับสนุนคุณสมบัติเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมทาดาต้าการนำเสนอ เช่น ผู้แต่ง, ชื่อเรื่อง, และค่าที่กำหนดโดยผู้ใช้

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารการนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) อินสแตนซ์ของคลาสนี้จะถูกคืนค่าจาก [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้ พวกมันสมมติว่า PHP/Java Bridge และ wrapper Aspose.Slides PHP ได้รับการเริ่มต้นแล้ว

{{% alert color="info" title="หมายเหตุ" %}}
Aspose.Slides จัดการเมทาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกการนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติการนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลอธิบายควบคู่กับเนื้อหาการนำเสนอ พวกมันแบ่งเป็นสองประเภท

- **Built-in properties** มีเมทาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้แต่ง, และสถิติเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่กำหนดโดยผู้ใช้

Aspose.Slides for PHP via Java ให้เข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อตรวจสอบเมทาดาต้าเอกสาร การสนทนาจะจัดข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติกำหนดโดยผู้ใช้

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดทำหน้าที่ปกป้องทั้งเนื้อหาและคุณสมบัติเอกสารโดยทั่วไป เมื่อทำการเข้ารหัสงานนำเสนอหลังจากเรียก [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ด้วย `false` คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถเรียก [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `true` เพื่ออ่านเมทาดาต้าสาธารณะโดยไม่ต้องใส่รหัสผ่านเปิด

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ถอดรหัสใด ๆ หากคุณสมบัติถูกเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้เข้ารหัส ตัวเลือกจะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างต้องการงานนำเสนอที่เข้ารหัสซึ่งคุณสมบัติเอกสารถูกปล่อยให้เป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) แล้วอ่านคุณสมบัติ built‑in ผ่าน [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties):

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

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และอ็อบเจกต์อื่น ๆ ของการนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) เสมอก่อนทำการดำเนินการที่ต้องใช้โมเดลอ็อบเจกต์การนำเสนอเต็มรูปแบบ

{{% alert color="warning" title="คำเตือน" %}}
เมทาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่ากำหนดเอง การเข้ารหัสคุณสมบัติที่เป็นข้อมูลละเอียดอ่อนพร้อมกับงานนำเสนอ ปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบจัดการเอกสารมีความต้องการเฉพาะที่จะเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดหลังจากเรียก [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `true` มีจุดประสงค์เพื่ออ่านเมทาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกคุณสมบัติที่เปลี่ยนแปลงจากอ็อบเจกต์ที่โหลดเฉพาะเมทาดาต้านี้ได้ เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดที่ถูกต้องและการโหลดเต็มรูปแบบ

ตัวอย่างต้องการไฟล์ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านเปิดที่ทราบ มันเปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) แล้วอัปเดตคุณสมบัติ built‑in สาธารณะ จากนั้นบันทึกผลลัพธ์ แล้วใช้ [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมทาดาต้าสาธารณะโดยไม่มีรหัสผ่านเพื่อตรวจสอบค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาการนำเสนอ จะต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึงคุณสมบัติ Built‑in**

คลาส [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) เปิดเผยเมทาดาต้า built‑in ผ่านเมธอด getter รวมถึง [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle), และ [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมทาดาต้าที่เก็บไว้บนคอนโซล ค่าเหล่านี้ขึ้นอยู่กับงานนำเข้าที่ให้; บางฟิลด์อาจว่างเปล่า

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

### **รายงานหมายเลขรีวิżและเวลาแก้ไข**

เพื่อรายงานหมายเลขรีวิżและเวลาการแก้ไขรวมของแต่ละไฟล์ PPTX ในโฟลเดอร์ `presentations` ให้ใช้ [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่าน [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) โดยไม่โหลดสไลด์สำหรับการแก้ไข API PHP via Java จะคืนค่เวลาแก้ไขเป็นมิลลิวินาที ตัวอย่างแปลงค่าดังกล่าวเป็นชั่วโมง, นาที, และวินาที และรวมจำนวนวันสำหรับระยะเวลาที่เกิน 24 ชั่วโมง

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

สำหรับงานนำเสนอที่มีหมายเลขรีวิż 17 และบันทึกเวลาการแก้ไขเป็น 1 วัน, 2 ชั่วโมง, และ 5 นาที รายงานจะแสดงผลลัพธ์ดังต่อไปนี้

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) อ่านค่าที่แอปพลิเคชันสามารถเปลี่ยนได้ด้วย [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) ตัวเลขรีวิż เพียงอย่างเดียวไม่สามารถบ่งบอกจำนวนครั้งที่บันทึกงานนำเสนอหรือสร้างประวัติเวอร์ชันได้

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) อ่านระยะเวลาแก้ไขที่บันทึกในไฟล์ งานนำเสนออาจมีระยะเวลาที่เก็บเป็นศูนย์ (`00:00:00`) แม้ว่าจะมีการแก้ไข

## **แก้ไขคุณสมบัติ Built‑in**

เพื่ออัปเดตเมทาดาต้า built‑in ให้ใช้เมธอด setter บนวัตถุที่ได้จาก [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่, เรียก [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments), และ [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager) จากนั้นบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) PPTX ที่บันทึกจะมีเมทาดาต้าใหม่

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

## **จัดการฐานลิงก์ (Hyperlink Base)**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) คืนค่าฐานระดับเอกสารสำหรับลิงก์เชิงสัมพันธ์ ใช้ [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) เพื่อเปลี่ยนหรือเคลียร์ฐาน นี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์เชื่อมโยงไปยังตำแหน่งอื่น มันแยกจาก [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) ของลิงก์แต่ละรายการ: การเปลี่ยนฐานไม่ได้เขียนทับที่อยู่ลิงก์ที่จัดเก็บไว้หรือเปลี่ยนปลายทางแบบเต็มรูปแบบ

ตัวอย่างต้องการงานนำเสนอที่มีลิงก์เชิงสัมพันธ์ เช่น `target.html` และลิงก์เต็มรูปแบบ เช่น `https://example.org/absolute.html` อ่านฐานที่มีอยู่, กำหนดฐานใหม่, บันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า จากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าว่างในไฟล์บันทึกแยกต่างหาก แทนที่ฐานตัวอย่างด้วยตำแหน่งไฟล์เชื่อมโยงของคุณ

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

ข้อความตรวจสอบสองข้อความควรพิมพ์ `true` การเคลียร์ฐานทำให้ที่อยู่ลิงก์แต่ละรายการยังคงเหมือนเดิม

ลิงก์เชิงสัมพันธ์ `target.pptx` เปิด `old/target.pptx` เมื่อฐานชี้ไปยังโฟลเดอร์ `old` หลังเปลี่ยนฐานเป็นโฟลเดอร์ `new` บันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์เต็มรูปแบบยังคงเปิดไฟล์เดิม ทดสอบลิงก์เชิงสัมพันธ์ใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่มคุณสมบัติ Presentation กุญแจกำหนดเอง**

คุณสมบัติกำหนดเองเก็บเมทาดาต้าที่ไม่มีฟิลด์ built‑in ที่สอดคล้องกัน เมธอด [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) ให้คุณกำหนดค่าโดยชื่อตามคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่าข้อความสองค่าและค่าตัวเลขเวอร์ชัน, แล้วบันทึกงานนำเสนอด้วย [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) การกำหนดค่าที่มีชื่อซ้ำจะทับค่าเดิมของคุณสมบัตินั้น

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

## **เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติกำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) เพื่อวนลูปผ่านพวกมัน [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) รับดัชนีเริ่มต้นที่ศูนย์และคืนชื่อที่ใช้โดย [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทุกอย่างด้วยสตริงลำดับเลขโดยไม่คำนึงถึงประเภทเดิม, แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติกำหนดเอง ลูปจะไม่ทำการใด ๆ

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

ลองแอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built‑in จากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่าหรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็กคุณสมบัติก่อนหน้า เพราะ Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอได้โดยไม่โหลดงานนำเสนอทั้งหมดหรือไม่?**

ได้ ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) แล้วตามด้วย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมทาดาต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ดูตัวอย่างการรายงานเต็มรูปแบบและข้อจำกัดตามรูปแบบได้ใน [Build a Lightweight Presentation Inventory](/slides/th/php-java/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสเปิดได้หรือไม่?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ด้วย `false` และต้องโหลดหลังจากเรียก [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `true`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document‑properties‑only ได้หรือไม่?**

ไม่ได้ ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสจำเป็นต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดที่ถูกต้อง