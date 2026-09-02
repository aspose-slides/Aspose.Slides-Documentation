---
title: เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอใน Java
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "เรียนรู้วิธีลงลายเซ็นในงานนำเสนอ PPTX ที่มีอยู่โดยใช้ใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Java เพื่อตรวจสอบหรือถอนลายเซ็นดิจิทัล."
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับระบุได้ว่าใครเป็นผู้ลงนามการนำเสนอและเนื้อหาที่ลงนามเปลี่ยนแปลงหรือไม่ มีแนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญดังนี้:

- **ใบรับรองดิจิทัล** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงตัวตนกับกุญแจสาธารณะ หน่วยงานออกใบรับรองที่น่าเชื่อถือ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่ลงนามด้วยตนเองสำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** ถูกสร้างจากเนื้อหาการนำเสนอและกุญแจส่วนตัวของผู้ถือใบรับรอง หลังจากนั้นกุญแจสาธารณะของใบรับรองสามารถใช้ตรวจสอบลายเซ็นได้ ลายเซ็นให้หลักฐานเกี่ยวกับต้นกำเนิดและความสมบูรณ์; มันไม่ได้เข้ารหัสการนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขการนำเสนอได้หรือไม่ แยกจากการลงลายเซ็นดิจิทัลและอธิบายเพิ่มเติมใน [การป้องกันด้วยรหัสผ่าน](/java/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** อยู่ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

เมื่อเปิดการนำเสนอที่ลงลายเซ็นแล้ว PowerPoint สามารถแสดงการแจ้งสถานะลายเซ็นได้

![การแจ้งของ PowerPoint ระบุว่าการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), ซึ่งคืนค่า [IDigitalSignatureCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignaturecollection/) ที่รายการของมันทำหน้าที่เป็น [IDigitalSignature](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/). การนำเสนอสามารถมีหลายลายเซ็นได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX หรือที่รู้จักกันในชื่อไฟล์ PKCS#12 ซึ่งโดยทั่วไปใช้ส่วนขยาย `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, กุญแจส่วนตัวของมัน, และห่วงโซ่ใบรับรอง กุญแจส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีการเข้าถึงกุญแจส่วนตัวไม่สามารถใช้ลงนามการนำเสนอได้

รหัสผ่านของ PFX ปกป้องแพ็กเกจใบรับรองและกุญแจส่วนตัว **ไม่** เป็นรหัสผ่านสำหรับการเปิดหรือแก้ไขการนำเสนอ อย่าเก็บไฟล์ PFX หรือรหัสผ่านของมันลงในระบบควบคุมเวอร์ชัน ในสภาพแวดล้อมการผลิต ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพื่อตัวอย่างเท่านั้น ไม่ได้ฝังรหัสผ่านไว้ในโค้ด

## **เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอ**

เพื่อทำงานลงลายเซ็นการนำเสนอจริง ให้โหลดไฟล์ PPTX ที่มีอยู่, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/java/com.aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นเข้าไปในคอลเลกชันของการนำเสนอ, แล้วบันทึกเป็นไฟล์ PPTX

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การบันทึกผลลัพธ์ด้วยชื่อใหม่ช่วยรักษาไฟล์ต้นฉบับที่ยังไม่ลงลายเซ็น ค่าที่ตั้งโดย [IDigitalSignature.setComments](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) บรรยายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อโหลดไฟล์ PPTX ที่ลงลายเซ็นแล้ว ให้ตรวจสอบทุกรายการที่คืนโดย [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). วิธีการ [IDigitalSignature.isValid](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/#isValid--) แสดงว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาการนำเสนอปัจจุบันหรือไม่

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ที่ไม่ถูกต้องมักหมายถึงเนื้อหาการนำเสนอหรือข้อมูลลายเซ็นเปลี่ยนแปลงหลังจากลงนาม, หรือไฟล์เสียหาย การลบลายเซ็นทั้งหมดทำให้การนำเสนอไม่มีลายเซ็น, ดังนั้นการตรวจสอบแค่ความถูกต้องของรายการไม่เพียงพอ: กระบวนการที่ต้องคำนึงถึงความปลอดภัยต้องตรวจสอบจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้ลงนามที่คาดว่าจะมีอยู่

ผลลัพธ์ด้านความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจสุดท้ายเกี่ยวกับความเชื่อถือของใบรับรอง ตามนโยบายความปลอดภัยของคุณ อาจจำเป็นต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอน, ยืนยันหัวข้อหรือรหัสประจำตัวที่คาดหวัง, ตรวจสอบการใช้กุญแจ, และประเมินการลงลายเซ็นด้วยเวลาประทับที่เชื่อถือได้ ค่า [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/#getSignTime--) เพียงอย่างเดียวไม่ถือว่ามาจากหน่วยงานให้เวลาประทับที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นทำให้สถานะความปลอดภัยของการนำเสนอเปลี่ยนแปลง ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่ลงลายเซ็น, ลบลายเซ็นทั้งหมดด้วย [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignaturecollection/#clear--), แล้วบันทึกสำเนาที่ไม่มีลายเซ็น

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบลายเซ็นเพียงหนึ่งรายการ ให้เรียก [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) พร้อมดัชนีที่เริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่เว้นแต่คุณต้องการเขียนทับไฟล์ต้นฉบับที่ลงลายเซ็นโดยเจตนา

## **ข้อควรพิจารณาเรื่องการแก้ไขและรูปแบบไฟล์**

- ลายเซ็นไม่ได้ทำให้การนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังคงแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดก่อนทำการลงลายเซ็น หากต้องการเปลี่ยนแปลงการนำเสนอ ให้บันทึกการนำเสนอที่แก้ไขแล้วและลงลายเซ็นเวอร์ชันนั้นอีกครั้ง
- ควรเก็บผลลัพธ์สุดท้ายเป็นรูปแบบ PPTX การแปลงการนำเสนอที่ลงลายเซ็นเป็นรูปแบบอื่นจะไม่ถ่ายโอนลายเซ็น PPTX ดั้งเดิมให้เป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือกุญแจส่วนตัวของใบรับรองเป็นข้อมูลที่สำคัญ ผู้ที่ได้กุญแจส่วนตัวและรหัสผ่านอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้น
- เก็บไฟล์ต้นฉบับที่ยังไม่ลงลายเซ็นหรือสำเนาที่ควบคุมไว้เมื่อแนวทางการเก็บเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสการนำเสนอหรือไม่?**

ไม่. ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับต้นกำเนิดและความสมบูรณ์, แต่เนื้อหาการนำเสนอยังคงอ่านได้ เว้นแต่จะมีการเข้ารหัสแยกต่างหาก ใช้ [การป้องกันด้วยรหัสผ่าน](/java/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX เป็นรหัสผ่านของการนำเสนอหรือไม่?**

ไม่. รหัสผ่าน PFX ใช้ปลดล็อกกุญแจส่วนตัวที่เก็บอยู่ในแพ็กเกจใบรับรอง ไม่ได้ควบคุมว่าผู้ใดสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้หรือไม่?**

ตามเทคนิคแล้ว ใบรับรองที่ลงนามด้วยตนเองสามารถใช้ได้หากมีการเข้าถึงกุญแจส่วนตัว ผู้รับจะไม่เชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ งานที่ครอบคลุมหลายองค์กรมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**ทำให้ลายเซ็นไม่ถูกต้องคืออะไร?**

การเปลี่ยนแปลงเนื้อหาการนำเสนอที่ลงลายเซ็นหรือข้อมูลลายเซ็นหลังจากลงนามทำให้ลายเซ็นไม่ถูกต้อง การเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด การนำเสนอจะไม่มีลายเซ็นแทนที่จะมีลายเซ็นที่ไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้ลงนามหรือไม่?**

ไม่โดยตนเอง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้ลงนามเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบในสภาพแวดล้อมการผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ช่วงเวลาที่ใช้งาน, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้กุญแจ, และข้อกำหนดเกี่ยวกับเวลาประทับที่เชื่อถือได้

**เกิดอะไรขึ้นเมื่อใบรับรองหมดอายุ?**

การหมดอายุของใบรับรองไม่ได้เปลี่ยนแปลงไบต์ของการนำเสนอ แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรอง ว่าลายเซ็นยังคงยอมรับได้หรือไม่ขึ้นกับนโยบายของคุณและว่ามีเวลาประทับที่เชื่อถือได้ที่แสดงว่าการลงนามเกิดขึ้นในขณะที่ใบรับรองยังใช้งานอยู่หรือไม่ อย่าพึ่งพาเวลาเซ็นที่แสดงบนหน้าจอเป็นเวลาประทับที่เชื่อถือได้เพียงอย่างเดียว

**การนำเสนอที่ลงลายเซ็นสามารถแก้ไขได้หรือไม่?**

ได้. การลงลายเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง ดังนั้นควรทำการแก้ไขให้เสร็จสิ้นก่อนลงลายเซ็นเวอร์ชันสุดท้าย

**การนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งรายการได้หรือไม่?**

ได้. เพิ่มลายเซ็นแต่ละรายการลงในคอลเลกชันที่คืนจาก [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) ก่อนบันทึก ระหว่างการตรวจสอบ ให้ตรวจสอบลายเซ็นทุกรายการและยืนยันว่าผู้ลงนามที่ต้องการทั้งหมดมีอยู่

**รูปแบบการนำเสนอใดบ้างที่รองรับการดำเนินการเหล่านี้?**

Aspose.Slides รองรับการดำเนินการเกี่ยวกับลายเซ็นดิจิทัลที่อธิบายไว้ในบทนี้เฉพาะสำหรับ PPTX เท่านั้น รูปแบบ PPT และ OpenDocument ไม่ได้รับการสนับสนุนโดย API นี้

**สามารถลบลายเซ็นโดยไม่กระทบสไลด์ได้หรือไม่?**

ได้. คุณสามารถลบลายเซ็นหนึ่งรายการหรือทำความสะอาดคอลเลกชันทั้งหมดแล้วบันทึกการนำเสนอ เนื้อหาของสไลด์จะคงเหลืออยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว