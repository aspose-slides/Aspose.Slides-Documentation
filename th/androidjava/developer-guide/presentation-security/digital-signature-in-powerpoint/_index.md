---
title: เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอบน Android
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/androidjava/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยงานออกใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบความถูกต้องของลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเซ็นงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อตรวจสอบหรือกำจัดลายเซ็นดิจิทัล"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยให้ผู้รับตรวจสอบได้ว่าใครเป็นผู้เซ็นงานนำเสนอและเนื้อหาที่เซ็นถูกเปลี่ยนแปลงหรือไม่ มีแนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญดังนี้:

- **ใบรับรองดิจิทัล** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงตัวตนกับกุญแจสาธารณะ หน่วยงานที่ออกใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่เซ็นด้วยตนเองสำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** สร้างจากเนื้อหาของงานนำเสนอและกุญแจส่วนตัวของผู้ถือใบรับรอง จากนั้นกุญแจสาธารณะของใบรับรองสามารถใช้ตรวจสอบลายเซ็นได้ ลายเซ็นให้หลักฐานของที่มและความสมบูรณ์; ไม่ได้เข้ารหัสงานนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขงานนำเสนอได้หรือไม่ เป็นสิ่งที่แยกจากการเซ็นดิจิทัลและอธิบายไว้ใน [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/androidjava/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** ภายใต้ **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

เมื่อเปิดงานนำเสนอที่เซ็นแล้ว PowerPoint สามารถแสดงการแจ้งเตือนสถานะลายเซ็นได้

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) ซึ่งคืนค่าเป็น [IDigitalSignatureCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignaturecollection/) ที่รายการของมันทำตาม [IDigitalSignature](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/). งานนำเสนอสามารถมีหลายลายเซ็นได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX หรือที่รู้จักในชื่อไฟล์ PKCS#12 และมักมีส่วนขยายเป็น `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, กุญแจส่วนตัว, และโซ่ใบรับรอง กุญแจส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีกุญแจส่วนตัวที่เข้าถึงไม่ได้ไม่สามารถใช้เซ็นงานนำเสนอได้

รหัสผ่าน PFX ปกป้องแพ็กเกจใบรับรองและกุญแจส่วนตัว **ไม่ใช่** รหัสผ่านสำหรับเปิดหรือแก้ไขงานนำเสนอ อย่า commit ไฟล์ PFX หรือรหัสผ่านของมันลงใน source control ในการผลิต ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ปลอดภัย ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพียงเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอ**

เพื่อเซ็นกระบวนการทำงานของงานนำเสนอจริง ให้โหลดไฟล์ PPTX ที่มีอยู่แล้ว สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน เพิ่มลายเซ็นเข้าไปในคอลเลกชันของงานนำเสนอ แล้วบันทึกเป็นไฟล์ PPTX

```java
import com.aspose.slides.*;

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

การบันทึกผลลัพธ์ด้วยชื่อใหม่จะทำให้ไฟล์ต้นฉบับที่ยังไม่ได้เซ็นยังคงอยู่ ค่าที่ตั้งโดย [IDigitalSignature.setComments](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) อธิบายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่เซ็นแล้ว ให้ตรวจสอบแต่ละรายการที่คืนค่าจาก [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) วิธีการ [IDigitalSignature.isValid](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/#isValid--) จะระบุว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาของงานนำเสนอปัจจุบันหรือไม่

```java
import com.aspose.slides.*;

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

ผลลัพธ์ที่ไม่ถูกต้องมักหมายความว่าเนื้อหาของงานนำเสนอที่เซ็นหรือข้อมูลลายเซ็นถูกเปลี่ยนแปลงหลังจากเซ็น หรือไฟล์เสียหาย การลบลายเซ็นทั้งหมดทำให้ได้งานนำเสนอที่ไม่ได้เซ็น ดังนั้นการตรวจสอบเพียงความถูกต้องของรายการจึงไม่เพียงพอ: กระบวนการที่ต้องคำนึงถึงความปลอดภัยต้องตรวจสอบจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้เซ็นด้วย

ผลลัพธ์การตรวจสอบนี้ไม่ควรถือเป็นการตัดสินใจเชื่อถือใบรับรองอย่างสมบูรณ์ ขึ้นกับนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอน, ยืนยันหัวข้อหรือรหัสนิ้วมือที่คาดหวัง, ตรวจสอบการใช้คีย์, และประเมิน timestamp ที่เชื่อถือได้ ค่า [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) เพียงอย่างเดียวไม่ใช่หลักฐานจากหน่วยงาน timestamp ที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสถานะความปลอดภัยของงานนำเสนอ ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่เซ็นแล้ว ลบลายเซ็นทั้งหมดด้วย [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) แล้วบันทึกสำเนาที่ไม่ได้เซ็น

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบเพียงลายเซ็นเดียว ให้เรียก [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) พร้อมด้วยดัชนีเริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ที่เซ็นแล้วโดยตรงเป็นส่วนหนึ่งของกระบวนการของคุณ

## **ข้อควรพิจารณาเรื่องการแก้ไขและรูปแบบไฟล์**

- ลายเซ็นไม่ได้ทำให้งานนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังคงแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่เซ็นจะทำให้ลายเซ็นเดิมไม่เป็นที่ถูกต้อง
- ทำการแก้ไขทั้งหมดก่อนเซ็น หากต้องเปลี่ยนงานนำเสนอ ให้บันทึกงานนำเสนอที่แก้ไขแล้วและเซ็นฉบับนั้นใหม่อีกครั้ง
- เก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงงานนำเสนอที่เซ็นเป็นรูปแบบอื่นจะไม่ถ่ายทอดลายเซ็น PPTX ดั้งเดิมให้เป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือกุญแจส่วนตัวของใบรับรองว่าเป็นข้อมูลสำคัญ ผู้ที่ได้กุญแจส่วนตัวและรหัสผ่านอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- เก็บไฟล์ต้นฉบับที่ไม่ได้เซ็นหรือสำเนาที่ควบคุมไว้เมื่อแนวนโยบายการเก็บเอกสารของคุณกำหนดให้ทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสงานนำเสนอหรือไม่?**

ไม่ ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับที่มาและความสมบูรณ์ แต่เนื้อหางานนำเสนอยังคงอ่านได้หากไม่มีการเข้ารหัสแยกต่างหาก ใช้ [การป้องกันด้วยรหัสผ่าน](/slides/th/androidjava/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX เป็นรหัสผ่านของงานนำเสนอหรือไม่?**

ไม่ รหัสผ่าน PFX ใช้ปลดล็อกกุญแจส่วนตัวที่เก็บอยู่ในแพ็กเกจใบรับรอง ไม่ได้ควบคุมว่าผู้ใดสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**ฉันสามารถใช้ใบรับรองที่เซ็นด้วยตนเองได้ไหม?**

ในเชิงเทคนิคสามารถใช้ใบรับรองที่เซ็นด้วยตนเองได้หากมีกุญแจส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่เชื่อถือโดยอัตโนมัติเว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนเข้าไปในสภาพแวดล้อมที่เชื่อถือได้ เวิร์กโฟลว์สาธารณะหรือข้ามองค์กรมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**ทำให้ลายเซ็นไม่ถูกต้องคืออะไร?**

การเปลี่ยนเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นหลังจากเซ็นทำให้ลายเซ็นไม่ถูกต้อง ไฟล์เสียหายก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด งานนำเสนอจะกลายเป็นงานที่ไม่ได้เซ็น ไม่ใช่ไฟล์ที่มีลายเซ็นไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้เซ็นหรือไม่?**

ไม่โดยตรง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้เซ็นเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบในผลิตภัณฑ์ควรตรวจสอบโซ่ใบรับรอง, ระยะเวลาที่มีผล, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้คีย์, และข้อกำหนดของ timestamp ที่เชื่อถือได้เพิ่มเติม

**จะเกิดอะไรขึ้นเมื่อใบรับรองหมดอายุ?**

การหมดอายุของใบรับรองไม่เปลี่ยนแปลงไบต์ของงานนำเสนอ แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรองว่าลายเซ็นยังคงยอมรับได้หรือไม่ ขึ้นกับนโยบายของคุณและว่ามี timestamp ที่เชื่อถือได้ยืนยันว่าการเซ็นเกิดขึ้นขณะใบรับรองยังมีอายุหรือไม่ อย่าพึ่งพาเวลาเซ็นที่แสดงอยู่เพียงอย่างเดียวเป็น timestamp ที่เชื่อถือได้

**งานนำเสนอที่เซ็นแล้วยังสามารถแก้ไขได้หรือไม่?**

ได้ การเซ็นไม่ทำให้ไฟล์ล็อก การแก้ไขเนื้อหาที่เซ็นมักทำให้ลายเซ็นเดิมไม่เป็นที่ถูกต้อง ดังนั้นให้ทำการแก้ไขเสร็จสิ้นแล้วจึงเซ็นฉบับสุดท้าย

**งานนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งอันได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละอันเข้าไปในคอลเลกชันที่คืนค่าจาก [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) ก่อนบันทึก ระหว่างการตรวจสอบให้ตรวจสอบลายเซ็นทุกอันและยืนยันว่าผู้เซ็นที่ต้องการทั้งหมดปรากฏอยู่

**รูปแบบงานนำเสนอใดบ้างที่รองรับการทำงานเหล่านี้?**

Aspose.Slides รองรับการทำงานของลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX ส่วนรูปแบบ PPT และ OpenDocument ไม่ได้รับการสนับสนุนโดย API นี้

**ฉันสามารถลบลายเซ็นโดยไม่ส่งผลต่อสไลด์ได้หรือไม่?**

ได้ คุณสามารถลบลายเซ็นหนึ่งอันหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกงานนำเสนอได้ เนื้อหาสไลด์จะยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว