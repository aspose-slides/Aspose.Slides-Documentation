---
title: เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอใน PHP
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/php-java/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยงานออกใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการลงลายเซ็นบนการนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อตรวจสอบหรือเอาลายเซ็นดิจิทัลออก."
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับกำหนดได้ว่าใครเป็นผู้ลงลายเซ็นบนการนำเสนอและเนื้อหาที่ลงลายเซ็นมีการเปลี่ยนแปลงหรือไม่ แนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญที่นี่:
- A **digital certificate** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงอัตลักษณ์กับกุญแจสาธารณะ หน่วยงานออกใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่ลงนามด้วยตนเองสำหรับกระบวนการทำงานภายใน
- A **digital signature** ถูกสร้างจากเนื้อหาการนำเสนอและกุญแจส่วนตัวของผู้ถือใบรับรอง จากนั้นกุญแจสาธารณะของใบรับรองสามารถใช้เพื่อตรวจสอบลายเซ็นได้ ลายเซ็นให้หลักฐานของแหล่งที่มและความครบถ้วน; มันไม่ได้เข้ารหัสการนำเสนอ
- **Password protection** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขการนำเสนอได้หรือไม่ มันแยกจากการลงลายเซ็นดิจิทัลและอธิบายไว้ใน [การป้องกันด้วยรหัสผ่าน](/php-java/password-protected-presentation/).

PowerPoint มีคำสั่ง **Add a Digital Signature** อยู่ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint ที่ไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

หลังจากเปิดการนำเสนอที่ลงลายเซ็น PowerPoint สามารถแสดงการแจ้งเตือนสถานะลายเซ็นได้.

![การแจ้งเตือนของ PowerPoint ระบุว่าการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDigitalSignatures) ซึ่งจะคืนค่า [DigitalSignatureCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/) ที่มีรายการเป็นวัตถุ [DigitalSignature](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/) การนำเสนอสามารถมีลายเซ็นหลายรายการได้.

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX ซึ่งรู้จักกันในชื่อไฟล์ PKCS#12 และโดยทั่วไปมีนามสกุล `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, กุญแจส่วนตัวของมัน, และห่วงโซ่ของใบรับรอง กุญแจส่วนตัวเป็นสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีกุญแจส่วนตัวที่เข้าถึงได้ไม่สามารถใช้ลงลายเซ็นบนการนำเสนอได้.

รหัสผ่าน PFX ปกป้องแพ็กเกจใบรับรองและกุญแจส่วนตัว มัน **ไม่** ใช้เป็นรหัสผ่านสำหรับการเปิดหรือแก้ไขการนำเสนอ อย่าส่งไฟล์ PFX หรือรหัสผ่านของมันไปยังระบบควบคุมเวอร์ชัน ในการผลิต ควรจำกัดการเข้าถึงไฟล์ใบรับรองและรับรหัสผ่านจากที่เก็บความลับหรือแหล่งการตั้งค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเท่านั้นเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด.

## **เพิ่มลายเซ็นดิจิทัลลงในการนำเสนอ**

เพื่อทำการลงลายเซ็นบนกระบวนการทำงานการนำเสนอจริง ให้โหลดไฟล์ PPTX ที่มีอยู่, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นลงในคอลเลกชันของการนำเสนอ, และบันทึกเป็นไฟล์ PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การบันทึกผลลัพธ์ด้วยชื่อใหม่จะรักษาไฟล์ต้นฉบับที่ไม่ได้ลงลายเซ็นไว้ ค่าที่ตั้งโดย [DigitalSignature::setComments](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/setcomments/) อธิบายวัตถุประสงค์ของลายเซ็น; มันไม่ใช่การควบคุมด้านความปลอดภัย.

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่ลงลายเซ็น, ตรวจสอบแต่ละรายการที่คืนค่าจาก [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDigitalSignatures) วิธีการ [DigitalSignature::isValid](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/isvalid/) ระบุว่าลายเซ็นที่ฝังอยู่เป็นที่ถูกต้องสำหรับเนื้อหาการนำเสนอปัจจุบันหรือไม่.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ที่ไม่ถูกต้องมักหมายความว่าเนื้อหาการนำเสนอที่ลงลายเซ็นหรือข้อมูลลายเซ็นได้มีการเปลี่ยนแปลงหลังการลงลายเซ็น, หรือไฟล์เสีย การลบลายเซ็นทั้งหมดทำให้ได้การนำเสนอที่ไม่ลงลายเซ็น ดังนั้นการตรวจสอบเพียงความถูกต้องของรายการไม่เพียงพอ: กระบวนการทำงานที่ต้องคำนึงถึงความปลอดภัยต้องตรวจสอบด้วยว่ามีจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้ลงลายเซ็นที่คาดหวังอยู่หรือไม่.

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจความเชื่อถือใบรับรองทั้งหมด ขึ้นอยู่กับนโยบายความปลอดภัยของคุณ แอปพลิเคชันของคุณอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบวันที่มีผลของใบรับรองและสถานะการเพิกถอน, ยืนยันหัวข้อหรือรหัสลายนิ้วมือที่คาดหวัง, ตรวจสอบการใช้กุญแจ, และประเมินตราประทับเวลาที่เชื่อถือได้ ค่า [DigitalSignature::getSignTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/getsigntime/) ด้วยตัวเองไม่ได้เป็นหลักฐานจากผู้ให้บริการตราประทับเวลาที่เชื่อถือได้.

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสถานะความปลอดภัยของการนำเสนอ ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่ลงลายเซ็น, ลบลายเซ็นทั้งหมดด้วย [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/clear/), และบันทึกสำเนาที่ไม่ได้ลงลายเซ็น.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการลบลายเซ็นเพียงหนึ่งรายการ, ให้เรียก [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/removeat/) พร้อมกับดัชนีตั้งแต่ศูนย์ บันทึกเป็นไฟล์ใหม่ ยกเว้นกรณีที่การเขียนทับไฟล์ต้นฉบับที่ลงลายเซ็นเป็นส่วนที่กำหนดอย่างชัดเจนของกระบวนการทำงานของคุณ.

## **การแก้ไขและพิจารณาเรื่องรูปแบบ**

- ลายเซ็นไม่ได้ทำให้การนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง.
- ทำการแก้ไขทั้งหมดที่ต้องการเสร็จสิ้นก่อนการลงลายเซ็น หากการนำเสนอจำเป็นต้องมีการเปลี่ยนแปลง ให้บันทึกการนำเสนอที่แก้ไขแล้วและลงลายเซ็นในเวอร์ชันนั้นอีกครั้ง.
- ควรเก็บผลลัพธ์ขั้นสุดท้ายในรูปแบบ PPTX การแปลงการนำเสนอที่ลงลายเซ็นเป็นรูปแบบอื่นจะไม่ถ่ายโอนลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว.
- ถือว่ากุญแจส่วนตัวของใบรับรองเป็นข้อมูลที่สำคัญ ใครก็ตามที่ได้มาซึ่งกุญแจส่วนตัวและรหัสผ่านของมันอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้น.
- เก็บรักษาแหล่งที่มาที่ไม่ได้ลงลายเซ็นหรือสำเนาที่ควบคุมอื่นไว้เมื่อนโยบายการเก็บเอกสารของคุณต้องการเช่นนั้น.

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสการนำเสนอหรือไม่?**

ไม่. ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับแหล่งที่มและความครบถ้วน, แต่เนื้อหาการนำทำยังคงอ่านได้หากไม่มีการเข้ารหัสเพิ่มเติม ใช้ [การป้องกันด้วยรหัสผ่าน](/php-java/password-protected-presentation/) เมื่อการเข้าถึงเนื้อหาต้องจำกัด.

**รหัสผ่าน PFX เป็นรหัสผ่านของการนำเสนอหรือไม่?**

ไม่. รหัสผ่าน PFX ใช้เพื่อปลดล็อกกุญแจส่วนตัวที่เก็บในแพ็กเกจใบรับรอง มันไม่ได้ควบคุมว่าผู้ใดสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้.

**ฉันสามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้หรือไม่?**

โดยหลักการ ใบรับรองที่ลงนามด้วยตนเองสามารถใช้ได้เมื่อมีการรวมกุญแจส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่ได้รับความเชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มลงในสภาพแวดล้อมที่เชื่อถืออย่างชัดเจน การทำงานสาธารณะหรือข้ามองค์กรมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้.

**อะไรทำให้ลายเซ็นไม่ถูกต้อง?**

การเปลี่ยนแปลงเนื้อหาการนำเสนอที่ลงลายเซ็นหรือข้อมูลลายเซ็นหลังการลงลายเซ็นสามารถทำให้ลายเซ็นไม่ถูกต้องได้ การเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด การนำเสนอจะไม่มีลายเซ็น แทนที่จะเป็นไฟล์ที่มีลายเซ็นไม่ถูกต้อง.

**ลายเซ็นที่ถูกต้องหมายความว่าฉันควรเชื่อถือผู้ลงลายเซ็นหรือไม่?**

ไม่ได้โดยตัวมันเอง ความครบถ้วนของลายเซ็นและความเชื่อถือผู้ลงลายเซ็นเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบในการผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ระยะเวลามีผล, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้กุญแจ, และความต้องการของตราประทับเวลาที่เชื่อถือได้.

**จะเกิดอะไรขึ้นเมื่อใบรับรองหมดอายุ?**

การหมดอายุของใบรับรองไม่ได้ทำให้ไบต์ของการนำเปลี่ยนแปลง แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรองว่าลายเซ็นยังคงยอมรับได้หรือไม่ขึ้นอยู่กับนโยบายของคุณและว่ามีตราประทับเวลาที่เชื่อถือได้และเป็นที่ถูกต้องแสดงให้เห็นว่าการลงลายเซ็นเกิดขึ้นขณะใบรับรองยังมีอายุหรือไม่ อย่าเชื่อถือเวลาแสดงผลของการลงลายเซ็นเพียงอย่างเดียวเป็นตราประทับเวลาที่เชื่อถือได้.

**การนำเสนอที่ลงลายเซ็นยังสามารถแก้ไขได้หรือไม่?**

ได้. การลงลายเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง ดังนั้นควรทำการนำเสนอให้เสร็จก่อนและลงลายเซ็นในฉบับสุดท้าย.

**การนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งรายการได้หรือไม่?**

ได้. เพิ่มลายเซ็นแต่ละรายการเข้าไปในคอลเลกชันที่ได้จาก [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDigitalSignatures) ก่อนบันทึก ในระหว่างการตรวจสอบ ให้ตรวจสอบลายเซ็นแต่ละรายการและยืนยันว่าผู้ลงลายเซ็นที่จำเป็นทั้งหมดปรากฏอยู่.

**รูปแบบการนำเสนอใดบ้างที่รองรับการดำเนินการเหล่านี้?**

Aspose.Slides รองรับการดำเนินการลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX เท่านั้น รูปแบบ PPT และ OpenDocument ของการนำเสนอไม่รองรับโดยขั้นตอนการทำงาน API นี้.

**ฉันสามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้. คุณสามารถลบลายเซ็นหนึ่งรายการหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกการนำเสนอ เนื้อหาสไลด์ยังคงอยู่ แต่ไฟล์ที่บันทึกจะไม่มีหลักฐานของลายเซ็มที่ถูกลบแล้ว.