---
title: ป้องกันการนำเสนอด้วยรหัสผ่านใน PHP
linktitle: การป้องกันรหัสผ่าน
type: docs
weight: 20
url: /th/php-java/password-protected-presentation/
keywords:
- การนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิด
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบความถูกต้องของรหัสผ่านการนำเสนอ
- ตรวจสอบรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบความถูกต้อง, เปิดและถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน PHP ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดจะทำการเข้ารหัสการนำเสนอ จำเป็นต้องใช้รหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาของการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ

รหัสผ่านเปิดแตกต่างจากรหัสผ่านการป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหา หรือป้องกันไม่ให้การนำเสนอถูกโหลด เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ให้ดูที่ [Write-Protect Presentations](/slides/th/php-java/write-protected-presentation/).

ขั้นตอนการทำงานด้านล่างใช้ได้กับการนำเสนอทั้งประเภท PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมตามไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิด**

ใช้ [ProtectionManager::encrypt](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#encrypt) เพื่อตั้งรหัสผ่านเปิด แล้วใช้ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัส

ตัวอย่างต่อไปนี้ทำการเข้ารหัสการนำเสนอ PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ทำให้คุณสมบัติเอกสารเป็นสาธารณะ**

ตามค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติเอกสารในการเข้ารหัสการนำเสนอ วิธีการ [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ควบคุมพฤติกรรมนี้แยกจากการเข้ารหัสเนื้อหาในสไลด์ ให้ส่งค่า `false` ก่อนเรียก [ProtectionManager::encrypt](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#encrypt) เมื่อระบบดัชนี การจัดประเภท การค้นหา หรือการจัดการเอกสารต้องอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิด

ตัวอย่างต่อไปนี้สร้างการนำเสนอ PPTX ที่ถูกเข้ารหัสโดยที่คุณสมบัติเอกสารในตัวยังคงเป็นสาธารณะ:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การส่งค่า `false` ไปยัง [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) จะไม่ทำให้สไลด์, มาสเตอร์, เลเอาต์, รูปร่าง, สื่อ หรือเนื้อหาอื่นของการนำเสนอเป็นสาธารณะ มันส่งผลต่อคุณสมบัติเอกสารเท่านั้น หากต้องการอ่านคุณสมบัติเหล่านั้นโดยไม่ต้องโหลดเนื้อหาที่เข้ารหัส ให้ดูที่ [Manage Presentation Properties](/slides/th/php-java/presentation-properties/).

## **โหลดการนำเสนอที่เข้ารหัส**

กำหนด [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) ให้เป็นรหัสผ่านเปิดและส่งตัวเลือกนี้ไปยัง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ขณะโหลดไฟล์ การโหลดจะล้มเหลือหากต้องการรหัสผ่านเปิดแต่ไม่ได้ระบุหรือระบุรหัสผ่านไม่ถูกต้อง

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
} finally {
    $presentation->dispose();
}
```

## **ลบการเข้ารหัสจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิด, เรียก [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#removeEncryption) แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกไว้สามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตรวจสอบรหัสผ่านเปิดก่อนการโหลด**

ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อดึงข้อมูล [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์ของการนำเสนอเต็มรูปแบบ ตรวจสอบ [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#isPasswordProtected) ก่อนขอหรือยืนยันรหัสผ่าน หากมีการป้องกัน ให้ตรวจสอบค่าที่ให้มาด้วย [PresentationInfo::checkPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#checkPassword)

### **กระบวนการทำงานแบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) แล้วโหลดการนำเสนอเต็มรูปแบบ:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **กระบวนการทำงานแบบสตรีม**

การโอเวอร์โหลดแบบสตรีมของ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ให้กระบวนการทำงานเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดการนำเสนอเต็มรูปแบบจากสตรีมนั้น

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **ค่าที่ส่งกลับของ checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#checkPassword) จะคืนค่า `true` ก็ต่อเมื่อการนำเสนอมีรหัสผ่านเปิดและรหัสผ่านที่ให้มาถูกต้อง จะคืนค่า `false` ในแต่ละกรณีดังต่อไปนี้:

- รหัสผ่านไม่ถูกต้อง
- การนำเสนอไม่มีรหัสผ่านเปิด
- รหัสผ่านที่ให้มาคือ `null` หรือว่างเปล่า

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#isEncrypted) เพื่อยืนยันว่าการนำเสนอแหล่งที่มาถูกเข้ารหัส หากต้องการตรวจจับการป้องกันด้วยรหัสผ่านก่อนการโหลด ให้ใช้ [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#isPasswordProtected) ตามที่แสดงข้างต้น

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **คำแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
ห้ามบันทึกรหัสผ่านเปิดในล็อกหรือรวมไว้ในข้อความวินิจฉัย หลีกเลี่ยงการพยายามตรวจสอบหลายครั้งโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเฉพาะเวลาที่จำเป็นเท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อทำการโหลดการนำเสนอทันที

คุณสมบัติเอกสารที่เป็นสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, เรื่อง, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง แม้ว่าข้อมูลการนำเสนอจะถูกเข้ารหัสก็ตาม ควรเข้ารหัสเมตาดาต้าที่สำคัญร่วมกับการนำเสนอ การทำให้คุณสมบัติเป็นสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนและทำเฉพาะเมื่อระบบต้องทำการทำดัชนี การจัดประเภท การค้นหา หรือการจัดการไฟล์โดยไม่มีรหัสผ่านเปิด
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
1. เลือกหรืออัปโหลดการนำเสนอ
1. ใส่รหัสผ่านสำหรับการป้องกันการดู
1. หากต้องการ สามารถใส่รหัสผ่านแยกสำหรับการป้องกันการแก้ไข
1. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**รหัสผ่านเปิดกับรหัสผ่านการป้องกันการเขียนต่างกันอย่างไร?**

รหัสผ่านเปิดจะเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา รหัสผ่านการป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่ทำการเข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ การดึงข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**แอปพลิเคชันสามารถอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิดได้หรือไม่?**

ได้ แต่เฉพาะเมื่อการนำเสนอถูกเข้ารหัสโดยปิดการเข้ารหัสคุณสมบัติเอกสารเท่านั้น แอปพลิเคชันต้องใช้โหมดการโหลดที่อ่านเฉพาะคุณสมบัติเอกสารตามที่อธิบายใน [Manage Presentation Properties](/slides/th/php-java/presentation-properties/).

**กระบวนการตรวจสอบรหัสผ่านสนับสนุนทั้ง PPT และ PPTX หรือไม่?**

ได้ กระบวนการตรวจจับและตรวจสอบรหัสผ่านตามไฟล์พาธและสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอ PPT และ PPTX