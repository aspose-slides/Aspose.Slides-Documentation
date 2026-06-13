---
title: เพิ่มลายเซ็นดิจิทัลในงานนำเสนอบน Android
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/androidjava/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยงานออกใบรับรอง
- ใบรับรอง PFX
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีลงลายเซ็นดิจิทัลในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android. ปกป้องสไลด์ของคุณในไม่กี่วินาทีด้วยตัวอย่างโค้ด Java ที่ชัดเจน."
---
## **บทนำ**

**ใบรับรองดิจิทัล** ใช้สำหรับสร้างงานนำเสนอ PowerPoint ที่มีการป้องกันด้วยรหัสผ่าน โดยระบุว่าได้สร้างโดยองค์กรหรือบุคคลเฉพาะ ใบรับรองดิจิทัลสามารถขอได้โดยติดต่อกับองค์กรที่ได้รับอนุญาต – หน่วยงานออกใบรับรอง หลังจากติดตั้งใบรับรองดิจิทัลลงในระบบแล้ว สามารถใช้เพื่อเพิ่มลายมือดิจิทัลลงในงานนำเสนอผ่านเมนู File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

งานนำเสนออาจมีลายมือดิจิทัลมากกว่าหนึ่งรายการ หลังจากที่เพิ่มลายมือดิจิทัลลงในงานนำเสนอ ข้อความพิเศษจะปรากฏใน PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

เพื่อทำการลงลายมือในงานนำเสนอหรือเพื่อตรวจสอบความถูกต้องของลายมือในงานนำเสนอ, **Aspose.Slides API** มีอินเทอร์เฟซ [**IDigitalSignature**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IDigitalSignature) , อินเทอร์เฟซ [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IDigitalSignatureCollection) และเมธอด [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) ปัจจุบันลายมือดิจิทัลรองรับเฉพาะรูปแบบ PPTX เท่านั้น.
## **เพิ่มลายมือดิจิทัลจากใบรับรอง PFX**
ตัวอย่างโค้ดด้านล่างแสดงวิธีเพิ่มลายมือดิจิทัลจากใบรับรอง PFX:

1. เปิดไฟล์ PFX และส่งรหัสผ่าน PFX ไปยังอ็อบเจกต์ [**DigitalSignature**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/DigitalSignature)
2. เพิ่มลายมือที่สร้างไว้ไปยังอ็อบเจกต์งานนำเสนอ

```java
// กำลังเปิดไฟล์งานนำเสนอ
Presentation pres = new Presentation();
try {
    // สร้างอ็อบเจกต์ DigitalSignature ด้วยไฟล์ PFX และรหัสผ่าน PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // แสดงความคิดเห็นลายเซ็นดิจิทัลใหม่
    signature.setComments("Aspose.Slides digital signing test.");

    // เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ
    pres.getDigitalSignatures().add(signature);

    // บันทึกงานนำเสนอ
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

ตอนนี้สามารถตรวจสอบได้ว่า งานนำเสนอได้รับการลงลายมือดิจิทัลและไม่ได้ถูกแก้ไขหรือไม่:

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

**ฉันสามารถลบลายมือที่มีอยู่จากไฟล์ได้หรือไม่?**

ใช่. คอลเลกชันลายมือดิจิทัลรองรับการ [removing individual items](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) และ [clearing it entirely](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--); หลังจากบันทึกไฟล์ งานนำเสนอจะไม่มีลายมือใด ๆ

**ไฟล์จะกลายเป็น "อ่านอย่างเดียว" หลังจากลงลายมือหรือไม่?**

ไม่. ลายมือทำให้คงความสมบูรณ์และความเป็นผู้เขียนไว้ แต่ไม่ได้บล็อกการแก้ไข เพื่อจำกัดการแก้ไข ให้รวมกับ ["Read-only" or a password](/slides/th/androidjava/password-protected-presentation/).

**ลายมือจะปรากฏอย่างถูกต้องในเวอร์ชันต่าง ๆ ของ PowerPoint หรือไม่?**

ลายมือถูกสร้างสำหรับคอนเทนเนอร์ OOXML (PPTX) เวอร์ชันสมัยใหม่ของ PowerPoint ที่รองรับลายมือ OOXML จะแสดงสถานะของลายมือเหล่านี้ได้อย่างถูกต้อง.