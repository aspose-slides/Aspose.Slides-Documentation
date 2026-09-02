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
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีลงลายเซ็นบนการนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อตรวจสอบหรือเอาลายเซ็นดิจิทัลออก"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับระบุว่าใครเป็นผู้ลงนามการนำเสนอและเนื้อหาที่ลงนามเปลี่ยนแปลงหรือไม่ แนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการมีความสำคัญที่นี่:

- **digital certificate** คือใบรับรองอิเล็กทรอนิกส์ที่เชื่อมต่อข้อมูลระบุตัวตนกับกุญแจสาธารณะ หน่วยงานออกใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองเซลฟ์‑ซายน์สำหรับกระบวนการทำงานภายใน
- **digital signature** ถูกสร้างจากเนื้อหาการนำเสนอและกุญแจส่วนตัวของผู้ถือใบรับรอง จากนั้นกุญแจสาธารณะของใบรับรองสามารถใช้ตรวจสอบลายเซ็นได้ ลายเซ็นให้หลักฐานของต้นฉบับและความสมบูรณ์; ไม่ได้เข้ารหัสการนำเสนอ
- **Password protection** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขการนำเสนอได้หรือไม่ สิ่งนี้แยกออกจากการลงลายเซ็นดิจิทัลและอธิบายไว้ใน [Password-Protected Presentations](/nodejs-java/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

หลังจากเปิดการนำเสนอที่ลงลายเซ็น PowerPoint สามารถแสดงการแจ้งสถานะลายเซ็นได้

![การแจ้งเตือนของ PowerPoint บอกว่าการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) ซึ่งส่งคืน [DigitalSignatureCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/) ที่บรรจุอ็อบเจกต์ [DigitalSignature](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) การนำเสนอสามารถมีหลายลายเซ็นได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX หรือที่รู้จักในชื่อไฟล์ PKCS#12 ซึ่งมักมีส่วนขยาย `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, กุญแจส่วนตัวของมัน, และห่วงโซ่ใบรับรอง กุญแจส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีการเข้าถึงกุญแจส่วนตัวไม่สามารถใช้ลงลายเซ็นการนำเสนอได้

รหัสผ่าน PFX ปกป้องแพ็คเกจใบรับรองและกุญแจส่วนตัว **ไม่** ใช้เป็นรหัสผ่านสำหรับเปิดหรือแก้ไขการนำเสนอ อย่า commit ไฟล์ PFX หรือรหัสผ่านของมันเข้าสู่ระบบควบคุมเวอร์ชัน ในสภาพการผลิต ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการป้องกัน ตัวอย่างต่อไปนี้ใช้ตัวแปรสภาพแวดล้อมเฉพาะเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในการนำเสนอ**

เพื่อทำงานลงลายเซ็นบนการนำเสนอที่แท้จริง ให้โหลดไฟล์ PPTX ที่มีอยู่แล้ว สร้างอ็อบเจกต์ [DigitalSignature](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน เพิ่มลายเซ็นลงในคอลเลกชันของการนำเสนอ และบันทึกเป็นไฟล์ PPTX

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การบันทึกผลลัพธ์โดยใช้ชื่อใหม่จะรักษาไฟล์ต้นฉบับที่ไม่ได้ลงลายเซ็นไว้ ค่าที่ตั้งโดย [DigitalSignature.setComments](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) อธิบายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่ลงลายเซ็นแล้ว ตรวจสอบแต่ละรายการที่ส่งคืนโดย [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) วิธีการ [DigitalSignature.isValid](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) แสดงว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาการนำเสนอปัจจุบันหรือไม่

ตัวอย่างต่อไปนี้ยังใช้คลาส Node.js `X509Certificate` เพื่ออ่านชื่อผู้ถือจากแต่ละใบรับรองที่ฝังอยู่

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ที่ไม่ถูกต้องมักหมายถึงเนื้อหาการนำเสนอหรือข้อมูลลายเซ็นที่ลงแล้วมีการเปลี่ยนแปลงหลังจากลงลายเซ็น หรือไฟล์เสีย การลบลายเซ็นทั้งหมดทำให้การนำเสนอกลายเป็นไม่มีลายเซ็น ดังนั้นการตรวจสอบแค่ความถูกต้องของรายการไม่เพียงพอ: กระบวนการทำงานที่ต้องคำนึงถึงความปลอดภัยต้องตรวจสอบให้แน่ใจว่าจำนวนลายเซ็นและตัวตนของผู้ลงนามตามที่คาดหวังปรากฏอยู่

ผลลัพธ์ความถูกต้องนี้ไม่ควรถูกมองว่าเป็นการตัดสินใจเชื่อถือใบรับรองอย่างสมบูรณ์ ขึ้นกับนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอนของใบรับรอง, ยืนยันหัวข้อหรือรหัสลายนิ้วมือที่คาดหวัง, ตรวจสอบการใช้กุญแจ, และประเมิน timestamp ที่เชื่อถือได้ ค่า [DigitalSignature.getSignTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) เพียงอย่างเดียวไม่ได้เป็นหลักฐานจากผู้ให้บริการ timestamp ที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสถานะความปลอดภัยของการนำเสนอ ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่ลงลายเซ็น ลบลายเซ็นทั้งหมดด้วย [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) และบันทึกสำเนาที่ไม่มีลายเซ็น

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบลายเซ็นเพียงรายการเดียว ให้เรียก [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) พร้อมดัชนีที่เริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่เว้นแต่การเขียนทับไฟล์ต้นฉบับที่ลงลายเซ็นเป็นส่วนที่ระบุอย่างชัดเจนในกระบวนการของคุณ

## **ข้อพิจารณาการแก้ไขและรูปแบบ**

- ลายเซ็นไม่ได้ทำให้การนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมเป็นค้างอายุ
- ทำการแก้ไขทั้งหมดก่อนลงลายเซ็น หากต้องแก้ไขการนำเสนอ ให้บันทึกการนำเสนอที่แก้ไขแล้วและลงลายเซ็นรุ่นนั้นอีกครั้ง
- รักษาผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงการนำเสนอที่ลงลายเซ็นเป็นรูปแบบอื่นจะไม่ถ่ายโอนลายเซ็น PPTX ดั้งเดิมให้เป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ปฏิบัติกุญแจส่วนตัวของใบรับรองเป็นข้อมูลที่อ่อนไหว ผู้ใดที่ได้มาซึ่งกุญแจส่วนตัวและรหัสผ่านอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้น
- เก็บรักษาไฟล์ต้นฉบับที่ไม่ได้ลงลายเซ็นหรือสำเนาที่ควบคุมไว้เมื่อนโยบายการเก็บเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **FAQ**

**ลายเซ็นดิจิทัลเข้ารหัสการนำเสนอหรือไม่?**

ไม่ ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับต้นฉบับและความสมบูรณ์ แต่เนื้อหาการนำเสนอยังคงอ่านได้ หากต้องการจำกัดการเข้าถึงเนื้อหาให้ใช้ [password protection](/nodejs-java/password-protected-presentation/)

**รหัสผ่าน PFX เป็นรหัสผ่านเดียวกับรหัสผ่านการนำเสนอหรือไม่?**

ไม่ รหัสผ่าน PFX ปลดล็อกกุญแจส่วนตัวที่เก็บอยู่ในแพ็คเกจใบรับรอง ไม่ได้ควบคุมว่าผู้ใดสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองเซลฟ์‑ซายน์ได้หรือไม่?**

ในเชิงเทคนิคสามารถใช้ใบรับรองเซลฟ์‑ซายน์ได้หากมีการเข้าถึงกุญแจส่วนตัว ผู้รับจะไม่เชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ โดยทั่วไปกระบวนการทำงานข้ามองค์กรหรือสาธารณะจะใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นเป็นค้างอายุ?**

การเปลี่ยนแปลงเนื้อหาการนำเสนอที่ลงลายเซ็นหรือข้อมูลลายเซ็นหลังจากลงลายเซ็นแล้วทำให้ลายเซ็นค้างอายุ ไฟล์เสียหายก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด การนำเสนอจะกลายเป็นไม่มีลายเซ็นแทนที่จะเป็นไฟล์ที่มีลายเซ็นค้างอายุ

**ลายเซ็นที่เป็นคาดหมายหมายความว่าต้องเชื่อถือผู้ลงนามหรือไม่?**

ไม่โดยตรง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้ลงนามเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบในสภาพการผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ระยะเวลาที่มีผล, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้กุญแจ, และข้อกำหนดของ timestamp ที่เชื่อถือได้ด้วย

**เมื่อใบรับรองหมดอายุจะเกิดอะไรขึ้น?**

การหมดอายุของใบรับรองไม่ได้เปลี่ยนไบต์ของการนำเสนอ แต่มีผลต่อการประเมินความเชื่อถือของใบรับรองว่าลายเซ็นยังคงยอมรับได้หรือไม่ ขึ้นกับนโยบายของคุณและว่ามี timestamp ที่เชื่อถือได้ยืนยันว่าการลงลายเซ็นทำในขณะที่ใบรับรองยังมีอายุหรือไม่ อย่าพึ่งพาเวลาแสดงบนลายเซ็นอย่างเดียวเป็น timestamp ที่เชื่อถือได้

**การนำเสนอที่ลงลายเซ็นยังสามารถแก้ไขได้หรือไม่?**

ได้ การลงลายเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมค้างอายุ ดังนั้นควรเสร็จสิ้นการแก้ไขแล้วจึงลงลายเซ็นรุ่นสุดท้าย

**การนำเสนอสามารถมีมากกว่าหนึ่งลายเซ็นได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละรายการลงในคอลเลกชันที่ส่งคืนโดย [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) ก่อนบันทึก ในขั้นตอนการตรวจสอบให้ตรวจสอบลายเซ็นทุกรายการและยืนยันว่าผู้ลงนามที่ต้องการทั้งหมดปรากฏอยู่

**รูปแบบการนำเสนอใดสนับสนุนการดำเนินการเหล่านี้?**

Aspose.Slides สนับสนุนการทำงานกับลายเซ็นดิจิทัลตามที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX รูปแบบ PPT และ OpenDocument ไม่ได้รับการสนับสนุนโดย API นี้

**สามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้ สามารถลบลายเซ็นหนึ่งรายการหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกการนำเสนอได้ เนื้อหาสไลด์ยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานของลายเซ็นที่ถูกลบแล้ว