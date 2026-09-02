---
title: ป้องกันการเขียนการนำเสนอใน PHP
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/php-java/write-protected-presentation/
keywords:
- การป้องกันการเขียน
- PowerPoint ป้องกันการเขียน
- รหัสผ่านสำหรับแก้ไข
- จำกัดการแก้ไขการนำเสนอ
- ลบการป้องกันการเขียน
- ตรวจสอบรหัสผ่านการแก้ไข
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ตั้งค่า ตรวจจับ ตรวจสอบ และลบรหัสผ่านการป้องกันการเขียนในการนำเสนอ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ PHP."
---
## **บทนำ**

รหัสผ่านการป้องกันการเขียนจะจำกัดการแก้ไขการนำเสนอ แต่ไม่ได้เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูการนำเสนอที่ป้องกันการเขียนโดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน พวกเขาอาจแก้ไขเนื้อหาและบันทึกเป็นชื่ออื่นได้ ดังนั้นการป้องกันการเขียนไม่ควรถูกมองว่าเป็นกลไกการรักษาความลับ

รหัสผ่านการเปิดใช้งานทำหน้าที่ต่างออกไป: มันเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา หากต้องการเข้ารหัสการนำเสนอหรือตรวจสอบรหัสผ่านการเปิดใช้งาน ดูที่ [Password-Protect Presentations](/slides/th/php-java/password-protected-presentation/).

กระบวนการทำงานในบทความนี้ใช้ได้กับการนำเสนอทั้งรูปแบบ PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX; เมื่อบันทึกเป็น PPT ให้ใช้ส่วนต่อท้าย `.ppt` และรูปแบบการบันทึก PPT ที่สอดคล้องกัน

## **ตั้งค่าการป้องกันการเขียนบนการนำเสนอ**

ใช้ [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#setWriteProtection) เพื่อตั้งรหัสผ่านสำหรับการแก้ไขการนำเสนอ การบันทึกการนำเสนอจะคงการตั้งค่าการป้องกันไว้

ตัวอย่างต่อไปนี้ตั้งค่าการป้องกันการเขียนบนการนำเสนอ PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **โหลดการนำเสนอที่ป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่ได้เข้ารหัสเนื้อหาการนำเสนอ ไม่จำเป็นต้องใช้รหัสผ่านในการโหลดการนำเสนอ รหัสผ่านมีความสำคัญเฉพาะเมื่อทำการตรวจสอบสิทธิ์การแก้ไขการนำเสนอที่ได้รับการป้องกันเท่านั้น

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

อย่าใส่รหัสผ่านการป้องกันการเขียนลงใน [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) เมธอดนี้รับรหัสผ่านการเปิดใช้งานสำหรับเนื้อหาที่เข้ารหัส หากการนำเสนอมีการป้องกันทั้งสองประเภท ให้ส่งรหัสผ่านการเปิดใช้งานเพื่อโหลดและจัดการรหัสผ่านการป้องกันการเขียนแยกกัน

## **ลบการป้องกันการเขียนจากการนำเสนอ**

ใช้ [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#removeWriteProtection) เพื่อลบการจำกัดการแก้ไข แล้วบันทึกการนำเสนอ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่สมบูรณ์ ให้เรียก [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) แล้วตรวจสอบ [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#isWriteProtected) เมธอดนี้ใช้ [NullableBool](https://reference.aspose.com/slides/th/php-java/aspose.slides/nullablebool/) และคืนค่า `NullableBool::True` เมื่อพบการป้องกันการเขียน

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

รูปแบบ overload ที่รับสตรีมของ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ให้ข้อมูลเดียวกันสำหรับการนำเสนอที่ส่งเป็นสตรีม

## **ตรวจสอบรหัสผ่านการป้องกันการเขียน**

ใช้ [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#checkWriteProtection) เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดการนำเสนอเต็ม ตรวจสอบ [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#isWriteProtected) ก่อน เพื่อให้แอปพลิเคชันร้องขอหรือยืนยันรหัสผ่านเฉพาะเมื่อมีการป้องกันการเขียน

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#checkWriteProtection) ตรวจสอบเฉพาะรหัสผ่านการป้องกันการเขียน ไม่ได้ตรวจสอบรหัสผ่านการเปิดหรือกำหนดว่าข้อมูลที่เข้ารหัสสามารถโหลดได้หรือไม่ ในทางกลับกัน [PresentationInfo::checkPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#checkPassword) ตรวจสอบเฉพาะรหัสผ่านการเปิด หากการนำเสนอเต็มได้โหลดแล้ว [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#checkWriteProtection) ให้การตรวจสอบการป้องกันการเขียนที่เทียบเท่าผ่านผู้จัดการการป้องกันของมัน

ในแอปพลิเคชันที่ใช้งานจริง อย่าเก็บบันทึกรหัสผ่านหรือใส่ไว้ในข้อความการวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำที่ไม่จำเป็น และเก็บรหัสผ่านในหน่วยความจำเฉพาะระยะเวลาที่ต้องการเท่านั้น

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [การป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/)
- [การนำเสนอแบบอ่านอย่างเดียว](/slides/th/php-java/read-only-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนเข้ารหัสการนำเสนอหรือไม่?**

ไม่. มันจำกัดการแก้ไขแต่ทำให้เนื้อหาการนำเสนอสามารถโหลดและดูได้

**จำเป็นต้องใช้รหัสผ่านการป้องกันการเขียนเพื่อเปิดการนำเสนอหรือไม่?**

ไม่. มีเพียงรหัสผ่านการเปิดใช้งานที่จำเป็นเพื่อโหลดเนื้อหาการนำเสนอที่เข้ารหัส

**การนำเสนอสามารถมีรหัสผ่านการเปิดและรหัสผ่านการป้องกันการเขียนพร้อมกันได้หรือไม่?**

ได้. ให้รหัสผ่านการเปิดผ่านตัวเลือกการโหลดเพื่อเปิดการนำเสนอที่เข้ารหัส และตรวจสอบรหัสผ่านการป้องกันการเขียนแยกต่างหากเมื่อจำเป็นต้องได้รับอนุญาตการแก้ไข