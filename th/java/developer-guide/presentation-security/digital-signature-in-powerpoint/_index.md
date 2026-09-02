---
title: เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอใน Java
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
- ความปลอดภัยของงานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีลงลายเซ็นในงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Java เพื่อตรวจสอบหรือเอาลายเซ็นดิจิทัลออก"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับระบุว่าใครเป็นผู้ลงนามงานนำเสนอและเนื้อหาที่ลงนามมีการเปลี่ยนแปลงหรือไม่ แนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามข้อสำคัญดังนี้:

- **ใบรับรองดิจิทัล** เป็นข้อมูลรับรองอิเล็กทรอนิกส์ที่เชื่อมโยงตัวตนกับกุญแจสาธารณะ หน่วยงานออกใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองเซลฟ์‑ไซน์สำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** สร้างจากเนื้อหางานนำเสนอและกุญแจส่วนตัวของผู้ถือใบรับรอง จากนั้นกุญแจสาธารณะของใบรับรองจะใช้เพื่อตรวจสอบลายเซ็น ลายเซ็นให้หลักฐานของที่มและความสมบูรณ์; ไม่ได้เข้ารหัสงานนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขงานนำเสนอได้หรือไม่ แยกจากการลงลายเซ็นและอธิบายใน [การป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** อยู่ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

เมื่อเปิดงานนำเสนอที่มีลายเซ็นแล้ว PowerPoint สามารถแสดงการแจ้งสถานะลายเซ็น

![การแจ้งเตือนของ PowerPoint ระบุว่ามีลายเซ็นที่ถูกต้องในงานนำเสนอ](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) ซึ่งส่งคืน [IDigitalSignatureCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignaturecollection/) ที่มีรายการที่ทำตาม [IDigitalSignature](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/) งานนำเสนอสามารถมีลายเซ็นหลายรายการได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX หรือที่รู้จักกันในชื่อไฟล์ PKCS#12 ที่มักมีนามสกุล `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, กุญแจส่วนตัว, และห่วงโซ่ใบรับรอง กุญแจส่วนตัวเป็นสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีการเข้าถึงกุญแจส่วนตัวจะไม่สามารถใช้ลงลายเซ็นงานนำเสนอได้

รหัสผ่าน PFX ปกป้องแพ็กเกจใบรับรองและกุญแจส่วนตัว **ไม่ใช่** รหัสผ่านสำหรับเปิดหรือแก้ไขงานนำเสนอ อย่าคอมมิทไฟล์ PFX หรือรหัสผ่านของมันเข้าไปในระบบควบคุมเวอร์ชัน ในการผลิต ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพียงอย่างเดียวเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ**

เพื่อทำขั้นตอนการลงลายเซ็นในงานนำเสนอจริง ให้โหลดไฟล์ PPTX ที่มีอยู่ สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/java/com.aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน แล้วเพิ่มลายเซ็นลงในคอลเลกชันของงานนำเสนอ และบันทึกเป็นไฟล์ PPTX

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

การบันทึกผลลัพธ์ด้วยชื่อใหม่จะรักษาไฟล์แหล่งที่ไม่มีลายเซ็นอยู่ ค่าโดยใช้ [IDigitalSignature.setComments](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) จะอธิบายวัตถุประสงค์ของลายเซ็น; ไม่ใช่การควบคุมความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่ลงลายเซ็นแล้ว ให้ตรวจสอบแต่ละรายการที่คืนค่ามาจาก [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) วิธี [IDigitalSignature.isValid](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/#isValid--) จะบ่งชี้ว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหางานนำเสนอปัจจุบันหรือไม่

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

ผลลัพธ์ที่ไม่ถูกต้องมักหมายความว่าเนื้อหาที่ลงลายเซ็นหรือข้อมูลลายเซ็นได้เปลี่ยนแปลงหลังการลงลายเซ็น หรือไฟล์เสียหาย การลบลายเซ็นทั้งหมดทำให้งานนำเสนอไม่มีลายเซ็น ดังนั้นการตรวจสอบความถูกต้องของรายการอย่างเดียวไม่พอ: กระบวนการที่ต้องคำนึงถึงความปลอดภัยต้องตรวจสอบจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้ลงลายเซ็นด้วย

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจเต็มรูปแบบเกี่ยวกับความเชื่อถือของใบรับรอง ขึ้นกับนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจจำเป็นต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอน, ยืนยันหัวข้อหรือยอดลายนิ้วมือที่คาดหวัง, ตรวจสอบการใช้กุญแจ, และประเมินการทำ timestamp ที่เชื่อถือได้ ค่า [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignature/#getSignTime--) เพียงอย่างเดียวไม่ใช่หลักฐานจากหน่วยงาน timestamp ที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสถานะความปลอดภัยของงานนำเสนอ ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่ลงลายเซ็นแล้วลบลายเซ็นทั้งหมดด้วย [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignaturecollection/#clear--) แล้วบันทึกสำเนาที่ไม่มีลายเซ็น

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบลายเซ็นเพียงอันเดียว ให้เรียก [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) พร้อมดัชนีที่เริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ที่มีลายเซ็นเดิมโดยตรง

## **ข้อควรพิจารณาในการแก้ไขและรูปแบบ**

- ลายเซ็นไม่ได้ทำให้งานนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังคงแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดให้เสร็จก่อนลงลายเซ็น หากต้องแก้ไขงานนำเสนออีกครั้ง ให้บันทึกงานนำเสนอที่แก้ไขแล้วและลงลายเซ็นเวอร์ชันนั้นใหม่
- ควรเก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงงานนำเสนอที่ลงลายเซ็นเป็นรูปแบบอื่นจะไม่ทำให้ลายเซ็นของไฟล์ PPTX ดั้งเดิมกลายเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ปฏิบัติกับกุญแจส่วนตัวของใบรับรองเป็นข้อมูลที่ละเอียดอ่อน ผู้ใดที่ได้กุญแจส่วนตัวและรหัสผ่านของมันอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- เก็บไฟล์แหล่งที่ไม่มีลายเซ็นหรือสำเนาที่ควบคุมไว้เมื่อแนวนโยบายการเก็บเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสงานนำเสนอหรือไม่?**

ไม่ ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับที่มาและความสมบูรณ์ แต่เนื้อหางานนำเสนอยังคงอ่านได้ เว้นแต่จะมีการเข้ารหัสแยกจากนั้น ใช้ [การป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX คือรหัสผ่านของงานนำเสนอหรือไม่?**

ไม่ รหัสผ่าน PFX ใช้ปลดล็อกกุญแจส่วนตัวที่เก็บอยู่ในแพ็กเกจใบรับรอง ไม่ได้ควบคุมการเปิดหรือแก้ไขไฟล์ PPTX

**ฉันสามารถใช้ใบรับรองเซลฟ์‑ไซน์ได้หรือไม่?**

ทางเทคนิคสามารถใช้ใบรับรองเซลฟ์‑ไซน์ได้เมื่อมีการเข้าถึงกุญแจส่วนตัว ผู้รับจะไม่เชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ งานที่ทำข้ามองค์กรหรือข้ามองค์กรทั่วไปมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นไม่ถูกต้อง?**

การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นหรือข้อมูลลายเซ็นหลังการลงลายเซ็นจะทำให้ลายเซ็นไม่ถูกต้อง การเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด งานนำเสนอจะไม่มีลายเซ็น ไม่ได้เป็นไฟล์ที่มีลายเซ็นไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้ลงลายเซ็นหรือไม่?**

ไม่โดยตัวมันเอง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้ลงลายเซ็นเป็นการตัดสินใจที่แยกกัน นโยบายการตรวจสอบในระบบผลิตควรตรวจสอบห่วงโซ่ใบรับรอง ระยะเวลาที่ใช้ได้ สถานะการเพิกถอน ตัวตนที่คาดหวัง การใช้กุญแจ และข้อกำหนดของ timestamp ที่เชื่อถือได้ด้วย

**เมื่อใบรับรองหมดอายุจะเกิดอะไรขึ้น?**

การหมดอายุของใบรับรองไม่ได้เปลี่ยนแปลงไบต์ของงานนำเสนอ แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรอง การที่ลายเซ็นยังคงยอมรับได้หรือไม่ขึ้นกับนโยบายของคุณและว่ามี timestamp ที่เชื่อถือได้แสดงว่าการลงลายเซ็นเกิดขึ้นขณะใบรับรองยังใช้ได้หรือไม่ อย่าพึ่งพาเวลาแสดงผลของลายเซ็นอย่างเดียวเป็น timestamp ที่เชื่อถือได้

**งานนำเสนอที่ลงลายเซ็นยังสามารถแก้ไขได้หรือไม่?**

ได้ การลงลายเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง ดังนั้นควรทำการแก้ไขให้ครบก่อนลงลายเซ็นเวอร์ชันสุดท้าย

**งานนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งอันได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละอันลงในคอลเลกชันที่ได้จาก [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) ก่อนบันทึก ระหว่างการตรวจสอบให้ตรวจสอบทุกลายเซ็นและยืนยันว่าผู้ลงลายเซ็นที่ต้องการทั้งหมดปรากฏอยู่

**รูปแบบงานนำเสนอใดบ้างที่สนับสนุนการทำงานเหล่านี้?**

Aspose.Slides รองรับการทำงานกับลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX; ไม่รองรับรูปแบบ PPT และ OpenDocument สำหรับ API นี้

**ฉันสามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้ คุณสามารถลบลายเซ็นอันเดียวหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกงานนำเสนอ เนื้อหาในสไลด์ยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานของลายเซ็นที่ถูกลบไว้แล้ว