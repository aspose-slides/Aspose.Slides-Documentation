---
title: เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอใน JavaScript
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/nodejs-java/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยงานออกใบรับรอง
- ใบรับรอง PFX
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการเซ็นไฟล์ PowerPoint และ OpenDocument อย่างดิจิทัลด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. ปกป้องสไลด์ของคุณในไม่กี่วินาทีด้วยตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

**ใบรับรองดิจิทัล** ใช้เพื่อสร้างการนำเสนอ PowerPoint ที่มีการป้องกันด้วยรหัสผ่าน ซึ่งระบุว่าได้สร้างโดยองค์กรหรือบุคคลเฉพาะ ใบรับรองดิจิทัลสามารถได้รับโดยการติดต่อองค์กรที่ได้รับอนุญาต – หน่วยงานออกใบรับรอง หลังจากติดตั้งใบรับรองดิจิทัลลงในระบบแล้ว สามารถใช้เพื่อเพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอผ่านเมนู File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

งานนำเสนออาจมีลายเซ็นดิจิทัลมากกว่าหนึ่งรายการ หลังจากที่เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอแล้ว ข้อความพิเศษจะปรากฏใน PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

เพื่อเซ็นงานนำเสนอหรือตรวจสอบความแท้ของลายเซ็นในงานนำเสนอ, **Aspose.Slides API** ให้คลาส [**DigitalSignature**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/DigitalSignature) , คลาส [**DigitalSignatureCollection**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/DigitalSignatureCollection) และเมธอด [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) ปัจจุบันลายเซ็นดิจิทัลรองรับเฉพาะรูปแบบ PPTX เท่านั้น.

## **เพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX**

ตัวอย่างโค้ดด้านล่างแสดงวิธีการเพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX:

1. เปิดไฟล์ PFX และส่งรหัสผ่าน PFX ไปยังอ็อบเจ็กต์ **DigitalSignature**.
1. เพิ่มลายเซ็นที่สร้างขึ้นไปยังอ็อบเจ็กต์งานนำเสนอ.

```javascript
// กำลังเปิดไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation();
try {
    // สร้างอ็อบเจ็กต์ DigitalSignature ด้วยไฟล์ PFX และรหัสผ่าน PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // แสดงความคิดเห็นลายเซ็นดิจิทัลใหม่
    signature.setComments("Aspose.Slides digital signing test.");
    // เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ
    pres.getDigitalSignatures().add(signature);
    // บันทึกงานนำเสนอ
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

ตอนนี้สามารถตรวจสอบได้ว่าการนำเสนอได้ถูกเซ็นดิจิทัลแล้วและไม่ได้ถูกแก้ไขหรือไม่:

```javascript
// เปิดงานนำเสนอ
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // ตรวจสอบว่าลายเซ็นดิจิทัลทั้งหมดเป็นที่ถูกต้องหรือไม่
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถลบลายเซ็นที่มีอยู่จากไฟล์ได้หรือไม่?**

ใช่. คอลเลกชันลายเซ็นดิจิทัลรองรับการ [removing individual items](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) และการ [clearing it entirely](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); หลังจากบันทึกไฟล์ งานนำเสนอจะไม่มีลายเซ็นใดๆ.

**ไฟล์จะกลายเป็นแบบ “อ่านอย่างเดียว” หลังจากเซ็นหรือไม่?**

ไม่. ลายเซ็นช่วยรักษาความสมบูรณ์และความเป็นผู้เขียนไว้แต่ไม่ได้บล็อกการแก้ไข เพื่อจำกัดการแก้ไข ให้ผสมกับ ["Read-only" or a password](/slides/th/nodejs-java/password-protected-presentation/).

**ลายเซ็นจะแสดงผลอย่างถูกต้องในเวอร์ชันต่างๆ ของ PowerPoint หรือไม่?**

ลายเซ็นถูกสร้างสำหรับคอนเทนเนอร์ OOXML (PPTX) เวอร์ชันสมัยใหม่ของ PowerPoint ที่รองรับลายเซ็น OOXML จะแสดงสถานะของลายเซ็นเหล่านี้อย่างถูกต้อง.