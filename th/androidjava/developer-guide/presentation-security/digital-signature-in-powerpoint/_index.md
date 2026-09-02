---
title: เพิ่มลายเซ็นดิจิทัลในพรีเซนเทชันบน Android
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
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของพรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเซ็นพรีเซนเทชัน PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อตรวจสอบหรือเอาลายเซ็นดิจิทัลออก."
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยให้ผู้รับระบุได้ว่าใครเป็นผู้เซ็นเอกสารพรีเซนเทชันและเนื้อหาที่เซ็นได้มีการเปลี่ยนแปลงหรือไม่

มีแนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญในส่วนนี้:

- **ใบรับรองดิจิทัล** เป็นข้อมูลรับรองอิเล็กทรอนิกส์ที่เชื่อมโยงตัวตนกับกุญแจสาธารณะ. หน่วยงานออกใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรสามารถใช้ใบรับรองที่ลงลายเซ็นด้วยตนเองสำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** ถูกสร้างจากเนื้อหาในพรีเซนเทชันและกุญแจส่วนตัวของผู้ถือใบรับรอง. กุญแจสาธารณะของใบรับรองจึงสามารถใช้ตรวจสอบลายเซ็นได้. ลายเซ็นให้หลักฐานของแหล่งที่มและความสมบูรณ์; แต่ไม่ได้ทำการเข้ารหัสพรีเซนเทชัน
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขพรีเซนเทชันได้หรือไม่. มันแยกจากการเซ็นดิจิทัลและได้อธิบายไว้ใน [การป้องกันด้วยรหัสผ่าน](/androidjava/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** ใต้เมนู **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

หลังจากเปิดพรีเซนเทชันที่เซ็นแล้ว PowerPoint สามารถแสดงการแจ้งเตือนสถานะลายเซ็นได้

![การแจ้งเตือนของ PowerPoint ระบุว่าพรีเซนเทชันมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), ซึ่งจะคืนค่า [IDigitalSignatureCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignaturecollection/) รายการของคอลเลกชันใช้ [IDigitalSignature](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/). พรีเซนเทชันสามารถมีลายเซ็นหลายรายการได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX, หรือที่รู้จักในชื่อไฟล์ PKCS#12 และมักมีนามสกุล `.pfx` หรือ `.p12`, สามารถบรรจุใบรับรอง X.509, กุญแจส่วนตัวของใบรับรอง, และห่วงโซ่ใบรับรอง. กุญแจส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้. ใบรับรองที่ไม่มีการเข้าถึงกุญแจส่วนตัวไม่สามารถใช้เซ็นพรีเซนเทชันได้

รหัสผ่าน PFX ปกป้องแพคเกจใบรับรองและกุญแจส่วนตัว. **ไม่ได้** เป็นรหัสผ่านสำหรับเปิดหรือแก้ไขพรีเซนเทชัน. อย่าคอมมิตไฟล์ PFX หรือรหัสผ่านของไฟล์เหล่านี้เข้าสู่ระบบควบคุมเวอร์ชัน. ในสภาพแวดล้อมการผลิต ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง. ตัวอย่างด้านล่างใช้งานตัวแปรสภาพแวดล้อมเท่านั้นเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในพรีเซนเทชัน**

เพื่อเซ็นพรีเซนเทชันจริง, โหลดไฟล์ PPTX ที่มีอยู่, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นลงในคอลเลกชันของพรีเซนเทชัน, แล้วบันทึกเป็นไฟล์ PPTX

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

การบันทึกผลลัพธ์ด้วยชื่อใหม่ช่วยรักษาไฟล์ต้นฉบับที่ยังไม่ได้เซ็นไว้. ค่าที่ตั้งโดย [IDigitalSignature.setComments](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) อธิบายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่เซ็นแล้ว, ตรวจสอบแต่ละรายการที่คืนมาจาก [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). วิธีการ [IDigitalSignature.isValid](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/#isValid--) จะบ่งชี้ว่าลายเซ็นที่ฝังอยู่ยังคงถูกต้องสำหรับเนื้อหาปัจจุบันของพรีเซนเทชันหรือไม่

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

ผลลัพธ์ที่ไม่ถูกต้องมักหมายถึงเนื้อหาพรีเซนเทชันหรือข้อมูลลายเซ็นได้มีการเปลี่ยนแปลงหลังจากเซ็น, หรือไฟล์ได้รับความเสียหาย. การลบลายเซ็นทั้งหมดทำให้พรีเซนเทชันเป็นเวอร์ชันที่ไม่มีลายเซ็น, ดังนั้นการตรวจสอบเพียงความถูกต้องของรายการแต่ละรายการจึงไม่เพียงพอ: กระบวนการที่ต้องใส่ใจด้านความปลอดภัยต้องตรวจสอบด้วยว่าจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้เซ็นที่คาดหวังมีครบหรือไม่

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจเชื่อถือใบรับรองโดยสมบูรณ์. ขึ้นอยู่กับนโยบายความปลอดภัยของคุณ, แอปพลิเคชันอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบช่วงวันที่ใช้งานและสถานะการเพิกถอน, ยืนยันหัวเรื่องหรือค่า thumbprint ที่คาดหวัง, ตรวจสอบการใช้กุญแจ, และประเมินการประทับเวลาแบบเชื่อถือได้. ค่าที่คืนจาก [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) เพียงอย่างเดียวไม่ถือว่าเป็นหลักฐานจากหน่วยงานประทับเวลาที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นทำให้สถานะความปลอดภัยของพรีเซนเทชันเปลี่ยนแปลง. ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่เซ็น, ลบลายเซ็นทั้งหมดด้วย [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), แล้วบันทึกสำเนาที่ไม่มีลายเซ็น

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลบเฉพาะลายเซ็นเดียว, เรียกใช้ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) พร้อมดัชนีเริ่มจากศูนย์. บันทึกเป็นไฟล์ใหม่เว้นแต่การเขียนทับไฟล์ต้นฉบับที่เซ็นเป็นส่วนที่ระบุไว้ชัดเจนในกระบวนการของคุณ

## **ข้อควรพิจารณาในการแก้ไขและรูปแบบ**

- ลายเซ็นไม่ได้ทำให้พรีเซนเทชันเป็นแบบอ่านอย่างเดียว. ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้, แต่การเปลี่ยนแปลงเนื้อหาที่เซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดที่ต้องการให้เสร็จก่อนการเซ็น. หากต้องเปลี่ยนพรีเซนเทชัน, ให้บันทึกเวอร์ชันที่แก้ไขแล้วและเซ็นเวอร์ชันนั้นอีกครั้ง
- เก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX. การแปลงพรีเซนเทชันที่เซ็นเป็นรูปแบบอื่นจะไม่ถ่ายทอดลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือกุญแจส่วนตัวของใบรับรองเป็นข้อมูลสำคัญ. ใครที่ได้มีกุญแจส่วนตัวและรหัสผ่านอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- เก็บไฟล์ต้นฉบับที่ไม่มีลายเซ็นหรือสำเนาที่ควบคุมไว้เมื่อแนวนโยบายการเก็บเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสพรีเซนเทชันหรือไม่?**

ไม่. ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับแหล่งที่มและความสมบูรณ์, แต่เนื้อหาพรีเซนเทชันยังคงสามารถอ่านได้หากไม่ได้ใช้การเข้ารหัสแยกต่างหาก. ใช้ [การป้องกันด้วยรหัสผ่าน](/androidjava/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX คือรหัสผ่านของพรีเซนเทชันหรือไม่?**

ไม่. รหัสผ่าน PFX เปิดกุญแจส่วนตัวที่เก็บอยู่ในแพคเกจใบรับรอง. มันไม่ได้ควบคุมว่าใครสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**ฉันสามารถใช้ใบรับรองที่ลงลายเซ็นด้วยตนเองได้หรือไม่?**

เทคนิคแล้วสามารถใช้ใบรับรองที่ลงลายเซ็นด้วยตนเองได้เมื่อรวมกุญแจส่วนตัวที่เข้าถึงได้. ผู้รับจะไม่เชื่อถือโดยอัตโนมัติเว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนเข้าไปในสภาพแวดล้อมที่เชื่อถือได้ของพวกเขา. กระบวนการสาธารณะหรือข้ามองค์กรมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นไม่ถูกต้อง?**

การเปลี่ยนแปลงเนื้อหาพรีเซนเทชันที่เซ็นหรือข้อมูลลายเซ็นหลังจากเซ็นจะทำให้ลายเซ็นไม่ถูกต้อง. การเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลวได้. หากลบลายเซ็นทั้งหมด, พรีเซนเทชันจะกลายเป็นเวอร์ชันที่ไม่มีลายเซ็นแทนที่จะเป็นไฟล์ที่มีลายเซ็นไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าฉันควรเชื่อถือผู้เซ็นหรือไม่?**

ไม่โดยตัวมันเอง. ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้เซ็นเป็นการตัดสินใจที่แยกกัน. นโยบายการตรวจสอบในสภาพแวดล้อมการผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ช่วงเวลาที่ใช้งาน, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้กุญแจ, และข้อกำหนดของการประทับเวลาที่เชื่อถือได้

**เกิดอะไรขึ้นเมื่อใบรับรองหมดอายุ?**

การหมดอายุของใบรับรองไม่ได้เปลี่ยนไบต์ของพรีเซนเทชัน, แต่มีผลต่อการประเมินความเชื่อถือของใบรับรอง. การที่ลายเซ็นยังคงยอมรับได้หรือไม่ขึ้นกับนโยบายของคุณและว่ามีการประทับเวลาที่เชื่อถือได้แสดงว่าการเซ็นเกิดขึ้นขณะใบรับรองยังใช้ได้หรือไม่. อย่าอ้างอิงเฉพาะเวลาที่แสดงบนลายเซ็นเป็นการประทับเวลาที่เชื่อถือได้

**พรีเซนเทชันที่มีลายเซ็นยังสามารถแก้ไขได้หรือไม่?**

ได้. การเซ็นไม่ได้ล็อกไฟล์. การแก้ไขเนื้อหาที่เซ็นโดยทั่วไปทำให้ลายเซ็นเดิมไม่ถูกต้อง, ดังนั้นให้ทำการแก้ไขให้เสร็จก่อนและเซ็นเวอร์ชันสุดท้าย

**พรีเซนเทชันสามารถมีลายเซ็นมากกว่าหนึ่งรายการได้หรือไม่?**

ได้. เพิ่มลายเซ็นแต่ละรายการลงในคอลเลกชันที่คืนจาก [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) ก่อนบันทึก. ในขั้นตอนการตรวจสอบ, ตรวจสอบลายเซ็นทุกรายการและยืนยันว่าผู้เซ็นที่จำเป็นทั้งหมดปรากฏอยู่

**ฟอร์แมตพรีเซนเทชันใดบ้างที่สนับสนุนการทำงานเหล่านี้?**

Aspose.Slides รองรับการทำงานด้านลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX. ฟอร์แมต PPT และ OpenDocument ไม่ได้รับการสนับสนุนโดย API นี้

**ฉันสามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้. คุณสามารถลบลายเซ็นหนึ่งรายการหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกพรีเซนเทชัน. เนื้อหาในสไลด์จะยังคงอยู่, แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว.