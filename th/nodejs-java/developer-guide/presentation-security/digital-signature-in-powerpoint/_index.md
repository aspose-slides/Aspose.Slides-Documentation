---
title: เพิ่มลายเซ็นดิจิทัลลงในพรีเซนเทชันด้วย JavaScript
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
- ความปลอดภัยของพรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีลงนามพรีเซนเทชัน PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อยืนยันหรือเอาลายเซ็นดิจิทัลออก"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยให้ผู้รับตรวจสอบได้ว่าใครเป็นผู้ลงนามพรีเซนเทชันและเนื้อหาที่ลงนามได้มีการเปลี่ยนแปลงหรือไม่ มีแนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญ:

- **ใบรับรองดิจิทัล** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงตัวตนกับกุญแจสาธารณะ หน่วยงานออกใบรับรองที่ได้รับความน่าเชื่อถือ (CA) สามารถออกใบรับรองได้ หรือองค์กรสามารถใช้ใบรับรองที่ลงนามด้วยตนเองสำหรับกระบวนการทำงานภายใน
- **ลายเซ็นดิจิทัล** ถูกสร้างจากเนื้อหาพรีเซนเทชันและกุญแจส่วนตัวของผู้ถือใบรับรอง แล้วจึงใช้กุญแจสาธารณะของใบรับรองเพื่อตรวจสอบลายเซ็น ลายเซ็นให้หลักฐานเกี่ยวกับแหล่งที่มาและความสมบูรณ์; มันไม่ได้เข้ารหัสพรีเซนเทชัน
- **การปกป้องด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขพรีเซนเทชันได้หรือไม่ แยกจากการเซ็นดิจิทัลและอธิบายไว้ใน [การปกป้องด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** อยู่ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

หลังจากเปิดพรีเซนเทชันที่ลงนามแล้ว PowerPoint สามารถแสดงการแจ้งเตือนสถานะลายเซ็นได้

![การแจ้งเตือนของ PowerPoint ระบุว่าพรีเซนเทชันมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides ทำให้สามารถเข้าถึงลายเซ็นผ่าน [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), ซึ่งจะคืนค่าเป็น [DigitalSignatureCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/) ที่บรรจุออบเจ็กต์ [DigitalSignature](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) พรีเซนเทชันสามารถมีลายเซ็นหลายรายการได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX ซึ่งเป็นที่รู้จักในชื่อไฟล์ PKCS#12 และมักมีส่วนขยาย `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, กุญแจส่วนตัวของมัน, และห่วงโซ่ใบรับรอง กุญแจส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีการเข้าถึงกุญแจส่วนตัวไม่สามารถใช้ลงนามพรีเซนเทชันได้

รหัสผ่าน PFX ปกป้องแพคเกจใบรับรองและกุญแจส่วนตัว **ไม่ใช่** รหัสผ่านสำหรับเปิดหรือแก้ไขพรีเซนเทชัน อย่าเพิ่มไฟล์ PFX หรือรหัสผ่านของมันลงในระบบควบคุมเวอร์ชัน ในสภาพแวดล้อมการผลิต ให้จำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสิ่งแวดล้อมเท่านั้นเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในพรีเซนเทชัน**

เพื่อทำงานลงนามพรีเซนเทชันจริง ให้โหลดไฟล์ PPTX ที่มีอยู่ สร้างออบเจ็กต์ [DigitalSignature](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) จากใบรับรอง PFX พร้อมรหัสผ่านของมัน เพิ่มลายเซ็นเข้าไปในคอลเลกชันของพรีเซนเทชัน แล้วบันทึกเป็นไฟล์ PPTX

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

การบันทึกผลลัพธ์ภายใต้ชื่อใหม่ช่วยรักษาไฟล์ต้นฉบับที่ยังไม่ได้ลงนามไว้ ค่าที่ตั้งโดย [DigitalSignature.setComments](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) อธิบายวัตถุประสงค์ของลายเซ็น; มันไม่ใช่การควบคุมความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่ลงนามแล้ว ให้ตรวจสอบแต่ละรายการที่คืนมาจาก [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) วิธีการ [DigitalSignature.isValid](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) แสดงว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาพรีเซนเทชันปัจจุบันหรือไม่

ตัวอย่างต่อไปนี้ยังใช้คลาส `X509Certificate` ของ Node.js เพื่ออ่านชื่อเรื่องจากแต่ละใบรับรองที่ฝังอยู่

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

ผลลัพธ์ไม่ถูกต้องมักหมายความว่าเนื้อหาที่ลงนามหรือข้อมูลลายเซ็นมีการเปลี่ยนแปลงหลังจากลงนาม หรือไฟล์เสียหาย การลบลายเซ็นทั้งหมดทำให้พรีเซนเทชันกลายเป็นแบบที่ไม่ได้ลงนาม ดังนั้นการตรวจสอบความถูกต้องของรายการเพียงอย่างเดียวไม่พอ: กระบวนการที่ต้องคำนึงถึงความปลอดภัยต้องตรวจสอบจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้ลงนามที่คาดหวังด้วย

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจเชื่อถือใบรับรองอย่างสมบูรณ์ ขึ้นอยู่กับนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอนของใบรับรอง, ยืนยันหัวข้อหรือรหัสลายเซ็นที่คาดหวัง, ตรวจสอบการใช้กุญแจ, และประเมินตราประทับเวลาที่เชื่อถือได้ ค่า [DigitalSignature.getSignTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignature/) เพียงอย่างเดียวไม่ถือเป็นหลักฐานจากหน่วยงานเวลาที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นทำให้สถานะความปลอดภัยของพรีเซนเทชันเปลี่ยนไป ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่ลงนามแล้ว ลบลายเซ็นทั้งหมดด้วย [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) และบันทึกสำเนาที่ไม่ได้ลงนาม

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

หากต้องการลบเฉพาะลายเซ็นหนึ่งรายการ ให้เรียก [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) พร้อมด้วยดัชนีฐานศูนย์ของมัน บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ต้นฉบับที่ลงนามซึ่งเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ

## **การแก้ไขและข้อพิจารณาด้านรูปแบบ**

- ลายเซ็นไม่ได้ทำให้พรีเซนเทชันเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังคงแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงนามมักทำให้ลายเซ็นที่มีอยู่ไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดก่อนลงนาม หากพรีเซนเทชันต้องมีการเปลี่ยนแปลง ให้บันทึกพรีเซนเทชันที่แก้ไขแล้วและลงนามการแก้ไขนั้นอีกครั้ง
- เก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงพรีเซนเทชันที่ลงนามเป็นรูปแบบอื่นจะไม่ถ่ายทอดลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือกุญแจส่วนตัวของใบรับรองว่าเป็นข้อมูลที่อ่อนไหว ผู้ที่ได้กุญแจส่วนตัวและรหัสผ่านของมันอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- รักษาไฟล์ต้นฉบับที่ยังไม่ได้ลงนามหรือสำเนาที่ควบคุมได้เมื่อ นโยบายการเก็บรักษาเอกสารของคุณต้องการ

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสพรีเซนเทชันหรือไม่?**

ไม่. ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับแหล่งที่มาและความสมบูรณ์ แต่เนื้อหาพรีเซนเทชันยังคงอ่านได้ หากไม่มีการเข้ารหัสแยก ใช้ [การปกป้องด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX เป็นรหัสผ่านของพรีเซนเทชันหรือไม่?**

ไม่. รหัสผ่าน PFX ใช้ปลดล็อกกุญแจส่วนตัวที่เก็บอยู่ในแพคเกจใบรับรอง ไม่ได้ควบคุมว่าใครสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้หรือไม่?**

โดยเทคนิคแล้ว สามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้หากมีการเข้าถึงกุญแจส่วนตัว ผู้รับจะไม่ได้รับความเชื่อถือโดยอัตโนมัติเว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ งานที่ทำข้ามองค์กรหรือสาธารณะมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นไม่ถูกต้อง?**

การเปลี่ยนแปลงเนื้อหาพรีเซนเทชันที่ลงนามหรือข้อมูลลายเซ็นหลังจากลงนามจะทำให้ลายเซ็นไม่ถูกต้อง ความเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด พรีเซนเทชันจะกลายเป็นแบบที่ไม่ได้ลงนาม ไม่ใช่ไฟล์ที่มีลายเซ็นไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้ลงนามหรือไม่?**

ไม่โดยตรง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้ลงนามเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบการผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ช่วงเวลาที่ใช้ได้, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้กุญแจ, และข้อกำหนดของตราประทับเวลาที่เชื่อถือได้

**หากใบรับรองหมดอายุจะเกิดอะไรขึ้น?**

การหมดอายุของใบรับรองไม่เปลี่ยนแปลงไบต์ของพรีเซนเทชัน แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรอง การที่ลายเซ็นยังคงใช้ได้หรือไม่ขึ้นกับนโยบายของคุณและว่ามีตราประทับเวลาเชื่อถือได้ที่พิสูจน์ว่าการลงนามเกิดขึ้นในช่วงที่ใบรับรองยังมีผลหรือไม่ อย่าอาศัยเวลาแสดงการลงนามอย่างเดียวเป็นตราประทับเวลาที่เชื่อถือได้

**พรีเซนเทชันที่ลงนามยังสามารถแก้ไขได้หรือไม่?**

ได้ การลงนามไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่ลงนามมักทำให้ลายเซ็นที่มีอยู่ไม่ถูกต้อง ดังนั้นควรทำการแก้ไขให้เสร็จก่อนแล้วจึงลงนามเวอร์ชันสุดท้าย

**พรีเซนเทชันสามารถมีลายเซ็นมากกว่าหนึ่งรายการได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละรายการลงในคอลเลกชันที่คืนโดย [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) ก่อนบันทึก ในขั้นตอนการตรวจสอบให้ตรวจสอบลายเซ็นทั้งหมดและยืนยันว่าผู้ลงนามที่จำเป็นทั้งหมดอยู่

**รูปแบบพรีเซนเทชันใดบ้างที่รองรับการดำเนินการเหล่านี้?**

Aspose.Slides รองรับการดำเนินการลายเซ็นดิจิทัลตามที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX รูปแบบ PPT และ OpenDocument ไม่ได้รับการสนับสนุนโดย API นี้

**สามารถลบลายเซ็นโดยไม่ส่งผลต่อสไลด์ได้หรือไม่?**

ได้ คุณสามารถลบลายเซ็นหนึ่งรายการหรือทำความสะอาดคอลเลกชันทั้งหมดแล้วบันทึกพรีเซนเทชัน เนื้อหาสไลด์จะยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว