---
title: การป้องกันการนำเสนอด้วยรหัสผ่านใน PHP
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
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบความถูกต้อง, เปิด และถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน PHP ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดจะเข้ารหัสการนำเสนอ จำเป็นต้องมีรหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความเป็นส่วนตัว

รหัสผ่านเปิดแตกต่างจากรหัสผ่านการป้องกันการเขียน การป้องกันการเขียนจะจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหาหรือป้องกันการโหลดการนำเสนอ หากต้องการจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดูที่ [Write-Protect Presentations](/slides/th/php-java/write-protected-presentation/)

เวิร์กโฟลว์ด้านล่างใช้ได้กับการนำเสนอทั้งรูปแบบ PPT และ PPTX ตัวอย่างใช้รูปแบบทั้งสองเมื่อพฤติกรรมแบบไฟล์และสตรีมเป็นสิ่งสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิด**

ใช้ [ProtectionManager::encrypt](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#encrypt) เพื่อตั้งค่ารหัสผ่านเปิด แล้วใช้ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อบันทึกการนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้จะแสดงการเข้ารหัสการนำเสนอ PPTX:

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

## **โหลดการนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) ให้เป็นรหัสผ่านเปิดและส่งตัวเลือกเหล่านั้นไปยัง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ขณะโหลดไฟล์ การโหลดจะล้มเหลือเมื่อต้องการรหัสผ่านเปิดแต่ไม่มีรหัสผ่านที่ให้หรือรหัสผ่านไม่ถูกต้อง

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

## **ลบการเข้ารหัสออกจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิดของมัน เรียก [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#removeEncryption) แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกแล้วจึงสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

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

## **ตรวจสอบรหัสผ่านเปิดก่อนโหลด**

ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อรับ [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูป ตรวจสอบ [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#isPasswordProtected) ก่อนขอหรือทำการตรวจสอบรหัสผ่าน เมื่อมีการป้องกัน ให้ตรวจสอบค่าที่ให้ด้วย [PresentationInfo::checkPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#checkPassword)

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

การ overload แบบสตรีมของ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ให้กระบวนการทำงานเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดการนำเสนอเต็มรูปจากสตรีมนั้น

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

### **ค่า Return ของ checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#checkPassword) จะคืนค่า `true` ก็ต่อเมื่อการนำเสนอมีรหัสผ่านเปิดและรหัสผ่านที่ให้ถูกต้อง จะคืนค่า `false` ในกรณีต่อไปนี้:
- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิด.
- รหัสผ่านที่ให้เป็น `null` หรือเป็นค่าว่าง.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอรูปแบบ PPT และ PPTX

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ตรวจสอบ [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#isEncrypted) เพื่อยืนยันว่าการนำเสนอเดิมถูกเข้ารหัส หากต้องการตรวจจับการป้องกันด้วยรหัสผ่านเปิดก่อนโหลด ให้ใช้ [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#isPasswordProtected) ตามที่แสดงข้างต้น

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

{{% alert color="warning" title="ความปลอดภัย" %}}
ห้ามบันทึกรหัสผ่านเปิดหรือใส่ลงในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเฉพาะช่วงที่ต้องการเท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อโหลดการนำเสนอโดยทันที
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
1. เลือกหรืออัปโหลดการนำเสนอ
1. ใส่รหัสผ่านเพื่อป้องกันการดู
1. หากต้องการสามารถใส่รหัสผ่านแยกต่างหากเพื่อป้องกันการแก้ไข
1. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [ป้องกันการเขียนของการนำเสนอ](/slides/th/php-java/write-protected-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รหัสผ่านเปิดต่างจากรหัสผ่านการป้องกันการเขียนอย่างไร?**

รหัสผ่านเปิดจะเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา การป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่ทำการเข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ สามารถรับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**ขั้นตอนการตรวจสอบรหัสผ่านรองรับการทำงานกับ PPT และ PPTX หรือไม่?**

รองรับ ทั้งการตรวจจับและตรวจสอบรหัสผ่านแบบไฟล์พาธและแบบสตรีมทำงานเหมือนกันสำหรับการนำเสนอรูปแบบ PPT และ PPTX