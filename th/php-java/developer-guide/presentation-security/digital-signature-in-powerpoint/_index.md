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
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการลงลายเซ็นดิจิทัลบนไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ปกป้องสไลด์ของคุณภายในไม่กี่วินาทีด้วยตัวอย่างโค้ดที่ชัดเจน"
---
## **คำนำ**

**ใบรับรองดิจิทัล** ถูกใช้เพื่อสร้างการนำเสนอ PowerPoint ที่ป้องกันด้วยรหัสผ่าน โดยระบุว่าถูกสร้างโดยองค์กรหรือบุคคลเฉพาะ ใบรับรองดิจิทัลสามารถรับได้โดยติดต่อองค์กรที่ได้รับอำนาจ – หน่วยงานออกใบรับรอง หลังจากติดตั้งใบรับรองดิจิทัลลงในระบบแล้ว สามารถใช้เพื่อเพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอได้ผ่าน File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

การนำเสนออาจมีลายเซ็นดิจิทัลมากกว่าหนึ่งรายการ หลังจากลายเซ็นดิจิทัลถูกเพิ่มลงในการนำเสนอ จะมีข้อความพิเศษปรากฏใน PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

เพื่อทำการลงลายเซ็นบนการนำเสนอหรือเพื่อตรวจสอบความแท้ของลายเซ็นการนำเสนอ **Aspose.Slides API** มีคลาส [**DigitalSignature**](https://reference.aspose.com/slides/th/php-java/aspose.slides/DigitalSignature) , คลาส [**DigitalSignatureCollection**](https://reference.aspose.com/slides/th/php-java/aspose.slides/DigitalSignatureCollection) และเมธอด [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getDigitalSignatures) ปัจจุบันลายเซ็นดิจิทัลรองรับเฉพาะรูปแบบ PPTX เท่านั้น

## **เพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX**

ตัวอย่างโค้ดด้านล่างแสดงวิธีเพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX:

1. เปิดไฟล์ PFX และส่งรหัสผ่าน PFX ไปยังอ็อบเจ็กต์ [**DigitalSignature**](https://reference.aspose.com/slides/th/php-java/aspose.slides/DigitalSignature) .
1. เพิ่มลายเซ็นที่สร้างขึ้นไปยังอ็อบเจ็กต์การนำเสนอ

```php
  # เปิดไฟล์การนำเสนอ
  $pres = new Presentation();
  try {
    # สร้างอ็อบเจ็กต์ DigitalSignature ด้วยไฟล์ PFX และรหัสผ่าน PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # คอมเมนต์ลายเซ็นดิจิทัลใหม่
    $signature->setComments("Aspose.Slides digital signing test.");
    # เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอ
    $pres->getDigitalSignatures()->add($signature);
    # บันทึกการนำเสนอ
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

ตอนนี้สามารถตรวจสอบได้ว่าการนำเสนอได้รับการลงลายเซ็นดิจิทัลและไม่ถูกแก้ไขหรือไม่:

```php
  # เปิดการนำเสนอ
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # ตรวจสอบว่าลายเซ็นดิจิทัลทั้งหมดเป็นที่ถูกต้องหรือไม่
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถลบลายเซ็นที่มีอยู่ในไฟล์ได้หรือไม่?**

ได้. คอลเล็กชันลายเซ็นดิจิทัลรองรับการ [removing individual items](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/removeat/) และการ [clearing it entirely](https://reference.aspose.com/slides/th/php-java/aspose.slides/digitalsignaturecollection/clear/); หลังจากที่คุณบันทึกไฟล์ การนำเสนอจะไม่มีลายเซ็นใด ๆ

**ไฟล์จะกลายเป็นแบบ "อ่านอย่างเดียว" หลังจากลงลายเซ็นหรือไม่?**

ไม่. ลายเซ็นช่วยรักษาความสมบูรณ์และความเป็นผู้เขียนไว้ แต่ไม่ได้บล็อกการแก้ไข เพื่อจำกัดการแก้ไข ให้ใช้ร่วมกับ ["Read-only" หรือรหัสผ่าน](/slides/th/php-java/password-protected-presentation/).

**ลายเซ็นจะแสดงอย่างถูกต้องในเวอร์ชันต่าง ๆ ของ PowerPoint หรือไม่?**

ลายเซ็นถูกสร้างสำหรับคอนเทนเนอร์ OOXML (PPTX) เวอร์ชันสมัยใหม่ของ PowerPoint ที่รองรับลายเซ็น OOXML จะแสดงสถานะของลายเซ็นเหล่านั้นอย่างถูกต้อง