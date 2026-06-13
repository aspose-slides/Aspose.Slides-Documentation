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
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเซ็นไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java อย่างปลอดภัยในไม่กี่วินาทีด้วยตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

**ใบรับรองดิจิทัล** ใช้เพื่อสร้างงานนำเสนอ PowerPoint ที่ป้องกันด้วยรหัสผ่าน, ระบุว่าเป็นการสร้างโดยองค์กรหรือบุคคลเฉพาะ. สามารถขอใบรับรองดิจิทัลได้โดยติดต่อกับองค์กรที่ได้รับอณุมัติ – หน่วยงานออกใบรับรอง. หลังจากติดตั้งใบรับรองดิจิทัลลงในระบบ, สามารถใช้เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอผ่าน File->Info->Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

งานนำเสนออาจมีลายเซ็นดิจิทัลมากกว่าหนึ่งรายการ. หลังจากเพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ, ข้อความพิเศษจะปรากฏใน PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

เพื่อทำการเซ็นงานนำเสนอหรือเพื่อตรวจสอบความถูกต้องของลายเซ็นในงานนำเสนอ, **Aspose.Slides API** มีอินเทอร์เฟซ [**IDigitalSignature**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IDigitalSignature), [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IDigitalSignatureCollection) และเมธอด [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . ปัจจุบัน ลายเซ็นดิจิทัลรองรับเฉพาะรูปแบบ PPTX เท่านั้น.
## **เพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX**
ตัวอย่างโค้ดด้านล่างแสดงวิธีเพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX:

1. เปิดไฟล์ PFX และส่งรหัสผ่าน PFX ให้กับอ็อบเจ็กต์ [**DigitalSignature**](https://reference.aspose.com/slides/th/java/com.aspose.slides/DigitalSignature).
2. เพิ่มลายเซ็นที่สร้างขึ้นไปยังอ็อบเจ็กต์ presentation.

```java
// กำลังเปิดไฟล์งานนำเสนอ
Presentation pres = new Presentation();
try {
    // สร้างอ็อบเจ็กต์ DigitalSignature ด้วยไฟล์ PFX และรหัสผ่าน PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // ใส่ความคิดเห็นให้ลายเซ็นดิจิทัลใหม่
    signature.setComments("Aspose.Slides digital signing test.");

    // เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ
    pres.getDigitalSignatures().add(signature);

    // บันทึกงานนำเสนอ
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

ตอนนี้สามารถตรวจสอบได้ว่าผลงานนำเสนอได้รับการเซ็นดิจิทัลและไม่มีการแก้ไขหรือไม่:

```java
// เปิดงานนำเสนอ
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // ตรวจสอบว่าลายเซ็นดิจิทัลทั้งหมดถูกต้องหรือไม่
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**สามารถลบลายเซ็นที่มีอยู่ในไฟล์ได้หรือไม่?**

ใช่. คอลเลกชันลายเซ็นดิจิทัลสนับสนุนการ [removing individual items](https://reference.aspose.com/slides/th/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) และการ [clearing it entirely](https://reference.aspose.com/slides/th/java/com.aspose.slides/digitalsignaturecollection/#clear--); หลังจากคุณบันทึกไฟล์, งานนำเสนอจะไม่มีลายเซ็นใด ๆ.

**ไฟล์จะกลายเป็น "อ่านอย่างเดียว" หลังจากเซ็นหรือไม่?**

ไม่. ลายเซ็นช่วยรักษาความสมบูรณ์และความเป็นผู้เขียน แต่ไม่ได้บล็อกการแก้ไข. หากต้องการจำกัดการแก้ไข, ให้รวมกับ ["Read-only" or a password](/slides/th/java/password-protected-presentation/).

**ลายเซ็นจะแสดงผลอย่างถูกต้องในเวอร์ชันต่าง ๆ ของ PowerPoint หรือไม่?**

ลายเซ็นถูกสร้างสำหรับคอนเทนเนอร์ OOXML (PPTX). เวอร์ชันล่าสุดของ PowerPoint ที่สนับสนุนลายเซ็น OOXML จะแสดงสถานะของลายเซ็นเหล่านั้นอย่างถูกต้อง.