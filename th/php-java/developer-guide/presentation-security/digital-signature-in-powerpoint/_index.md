---
title: เพิ่มลายเซ็นดิจิทัลในงานนำเสนอด้วย PHP
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
- ความปลอดภัยของงานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการลงลายเซ็นในงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อตรวจสอบหรือลบลายเซ็นดิจิทัล."
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยให้ผู้รับสามารถกำหนดได้ว่าใครเป็นผู้ลงลายเซ็นในงานนำเสนอและเนื้อหาในงานนำเสนอที่ลงลายเซ็นนั้นมีการเปลี่ยนแปลงหรือไม่ มีแนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญดังนี้:

- **ใบรับรองดิจิทัล** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงอัตลักษณ์กับคีย์สาธารณะ หน่วยงานออกใบรับรอง (CA) ที่เชื่อถือได้สามารถออกใบรับรอง หรือองค์กรสามารถใช้ใบรับรองที่สร้างด้วยตนเองสำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** ถูกสร้างจากเนื้อหาของงานนำเสนอและคีย์ส่วนตัวของผู้ถือใบรับรอง หลังจากนั้นคีย์สาธารณะของใบรับรองสามารถใช้ในการตรวจสอบลายเซ็นได้ ลายเซ็นให้หลักฐานของที่มและความสมบูรณ์; ไม่ได้เข้ารหัสงานนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขงานนำเสนอได้หรือไม่ ซึ่งแยกต่างหากจากการลงลายเซ็นดิจิทัลและอธิบายเพิ่มเติมใน [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/)

PowerPoint มีคำสั่ง **เพิ่มลายเซ็นดิจิทัล** อยู่ใน **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint ที่ไฮไลต์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

เมื่อเปิดงานนำเสนอที่มีลายเซ็น PowerPoint สามารถแสดงการแจ้งเตือนสถานะลายเซ็นได้

![การแจ้งเตือนของ PowerPoint ที่บ่งชี้ว่ามีลายเซ็นที่ถูกต้องในงานนำเสนอ](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDigitalSignatures) ซึ่งคืนค่า [DigitalSignatureCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/) ที่ประกอบด้วยอ็อบเจกต์ [DigitalSignature](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/) งานนำเสนอสามารถมีลายเซ็นหลายชุดได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX หรือที่รู้จักในชื่อไฟล์ PKCS#12 มีสกุล `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, คีย์ส่วนตัวของใบรับรองและโซ่ใบรับรอง คีย์ส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีคีย์ส่วนตัวที่เข้าถึงได้ไม่สามารถใช้ในการลงลายเซ็นงานนำเสนอได้

รหัสผ่านของ PFX ปกป้องแพคเกจใบรับรองและคีย์ส่วนตัว **ไม่ใช่** รหัสผ่านสำหรับการเปิดหรือแก้ไขงานนำเสนอ อย่าเช็คอินไฟล์ PFX หรือรหัสผ่านของมันลงในระบบควบคุมเวอร์ชัน ในสภาพแวดล้อมการผลิต ให้จำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในการนำเสนอ**

เพื่อทำขั้นตอนการลงลายเซ็นในงานนำเสนอจริง ให้โหลดไฟล์ PPTX ที่มีอยู่, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นลงในคอลเลกชันของงานนำเสนอ และบันทึกเป็นไฟล์ PPTX

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

การบันทึกผลลัพธ์เป็นชื่อไฟล์ใหม่ช่วยรักษาไฟล์ต้นฉบับที่ไม่มีลายเซ็นไว้ ค่าเดียวที่ตั้งโดย [DigitalSignature::setComments](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/setcomments/) อธิบายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบความถูกต้องของลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่มีลายเซ็น ตรวจสอบรายการที่คืนจาก [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDigitalSignatures) ทุกรายการ วิธี [DigitalSignature::isValid](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/isvalid/) จะบ่งชี้ว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาของงานนำเสนอในปัจจุบันหรือไม่

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

ผลลัพธ์ที่ไม่ถูกต้องมักหมายถึงเนื้อหาในงานนำเสนอหรือข้อมูลลายเซ็นถูกเปลี่ยนแปลงหลังจากลงลายเซ็น, หรือไฟล์นั้นเสียหาย การลบลายเซ็นทุกอันทำให้ได้งานนำเสนอที่ไม่มีลายเซ็น ดังนั้นการตรวจสอบความถูกต้องของรายการเพียงอย่างเดียวไม่พอ: กระบวนการที่ต้องคำนึงถึงความปลอดภัยควรตรวจสอบให้แน่ใจว่าจำนวนลายเซ็นที่คาดไว้และอัตลักษณ์ของผู้ลงลายเซ็นที่คาดหวังมีอยู่จริง

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจเรื่องความเชื่อมั่นของใบรับรองอย่างสมบูรณ์ ตามนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอนของใบรับรอง, ยืนยันหัวข้อหรือThumbprint ที่คาดหวัง, ตรวจสอบการใช้คีย์, และประเมิน timestamp ที่เชื่อถือได้ ค่า [DigitalSignature::getSignTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignature/getsigntime/) เพียงอย่างเดียวไม่ได้เป็นหลักฐานจากผู้ให้บริการ timestamp ที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสถานะความปลอดภัยของงานนำเสนอ ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่มีลายเซ็น, ลบลายเซ็นทั้งหมดด้วย [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/clear/), แล้วบันทึกสำเนาที่ไม่มีลายเซ็น

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการลบลายเซ็นเพียงอันเดียว ให้เรียก [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/removeat/) พร้อมดัชนีเริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่เว้นแต่คุณต้องการเขียนทับไฟล์ต้นฉบับที่มีลายเซ็นโดยเจตนา

## **ข้อควรพิจารณาในการแก้ไขและรูปแบบ**

- ลายเซ็นไม่ได้ทำให้ไฟล์งานนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังคงสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นจะทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดก่อนลงลายเซ็น หากต้องการเปลี่ยนแปลงงานนำเสนอ ให้บันทึกงานนำเสนอที่แก้ไขแล้วและลงลายเซ็นในฉบับนั้นอีกครั้ง
- เก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงงานนำเสนอที่ลงลายเซ็นเป็นรูปแบบอื่นจะไม่ถ่ายทอดลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือคีย์ส่วนตัวของใบรับรองเป็นข้อมูลที่ละเอียดอ่อน ผู้ที่ได้มาซึ่งคีย์ส่วนตัวและรหัสผ่านอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- รักษาไฟล์ต้นฉบับที่ไม่มีลายเซ็นหรือสำเนาที่ควบคุมไว้เมื่อแนวนโยบายการเก็บรักษาเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสงานนำเสนอหรือไม่?**

ไม่ ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับที่มาและความสมบูรณ์ แต่เนื้อหางานนำเสนอยังคงสามารถอ่านได้ เว้นแต่จะมีการเข้ารหัสแยกต่างหาก ใช้ [การป้องกันด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX กับรหัสผ่านของงานนำเสนอเป็นอย่างเดียวกันหรือไม่?**

ไม่ รหัสผ่าน PFX ใช้เพื่อปลดล็อกคีย์ส่วนตัวที่เก็บอยู่ในแพคเกจใบรับรอง ไม่ได้ควบคุมว่าใครสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองที่สร้างด้วยตนเองได้หรือไม่?**

ทางเทคนิค สามารถใช้ใบรับรองที่สร้างด้วยตนเองได้เมื่อมีคีย์ส่วนตัวที่เข้าถึงได้ ผู้รับอาจไม่เชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ งานไหลที่เป็นสาธารณะหรือข้ามองค์กรมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นไม่ถูกต้อง?**

การเปลี่ยนเนื้อหาที่ลงลายเซ็นหรือข้อมูลลายเซ็นหลังจากลงลายเซ็นจะทำให้ลายเซ็นไม่ถูกต้อง การเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด งานนำเสนอจะกลายเป็นไม่มีลายเซ็น ไม่ใช่ไฟล์ที่มีลายเซ็นที่ไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าควรเชื่อถือผู้ลงลายเซ็นหรือไม่?**

ไม่โดยตัวมันเอง ความสมบูรณ์ของลายเซ็นและความเชื่อมั่นต่อผู้ลงลายเซ็นเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบการผลิตควรตรวจสอบโซ่ใบรับรอง, ระยะเวลาที่ใบรับรองใช้ได้, สถานะการเพิกถอน, อัตลักษณ์ที่คาดหวัง, การใช้คีย์, และข้อกำหนดของ timestamp ที่เชื่อถือได้

**เมื่อใบรับรองหมดอายุ จะเกิดอะไรขึ้น?**

การหมดอายุของใบรับรองไม่ทำให้ไบต์ของงานนำเปลี่ยนแปลง แต่มีผลต่อการประเมินความเชื่อมั่นของใบรับรองว่า ลายเซ็นยังคงยอมรับได้หรือไม่ ขึ้นอยู่กับนโยบายของคุณและว่ามี timestamp ที่เชื่อถือได้แสดงว่าการลงลายเซ็นทำในช่วงที่ใบรับรองยังใช้งานได้หรือไม่ อย่าพึ่งพาเวลาแสดงผลของลายเซ็นอย่างเดียวเป็น timestamp ที่เชื่อถือได้

**งานนำเสนอที่ลงลายเซ็นยังสามารถแก้ไขได้หรือไม่?**

ได้ การลงลายเซ็นไม่ได้ทำให้ไฟล์ล็อก การแก้ไขเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง ดังนั้นควรเสร็จสิ้นการแก้ไขและลงลายเซ็นฉบับสุดท้ายก่อนบันทึก

**งานนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งอันได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละอันลงในคอลเลกชันที่คืนจาก [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDigitalSignatures) ก่อนบันทึก ระหว่างการตรวจสอบ ให้ตรวจสอบลายเซ็นทุกอันและยืนยันว่ามีผู้ลงลายเซ็นที่ต้องการครบถ้วน

**รูปแบบงานนำเสนอใดบ้างที่รองรับการดำเนินการเหล่านี้?**

Aspose.Slides รองรับการทำงานกับลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX; ไม่รองรับรูปแบบ PPT หรือ OpenDocument ใน API นี้

**สามารถลบลายเซ็นโดยไม่กระทบสไลด์ได้หรือไม่?**

ได้ คุณสามารถลบลายเซ็นหนึ่งอันหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกงานนำเสนอ เนื้อหาสไลด์จะยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว