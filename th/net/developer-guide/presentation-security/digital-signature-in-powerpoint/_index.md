---
title: เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอใน .NET
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/net/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยงานออกใบรับรอง
- ใบรับรอง PFX
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการลงลายเซ็นดิจิทัลในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET. ปกป้องสไลด์ของคุณในไม่กี่วินาทีด้วยตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

**ใบรับรองดิจิทัล** ถูกใช้เพื่อสร้างงานนำเสนอ PowerPoint ที่มีการป้องกันด้วยรหัสผ่าน โดยระบุว่าถูกสร้างโดยองค์กรหรือบุคคลเฉพาะ ใบรับรองดิจิทัลสามารถได้รับโดยการติดต่อองค์กรที่ได้รับอนุญาต – หน่วยงานออกใบรับรอง หลังจากติดตั้งใบรับรองดิจิทัลลงในระบบแล้ว สามารถใช้เพื่อเพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอผ่านเมนู File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

งานนำเสนออาจมีลายเซ็นดิจิทัลมากกว่าหนึ่งรายการ หลังจากเพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ ข้อความพิเศษจะปรากฏใน PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

เพื่อทำการลงลายเซ็นในงานนำเสนอหรือเพื่อตรวจสอบความถูกต้องของลายเซ็นงานนำเสนอ, **Aspose.Slides API** มีให้ใช้ [**IDigitalSignature**](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignature) interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/th/net/aspose.slides/IDigitalSignatureCollection) interface และ[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/properties/digitalsignatures) property. ปัจจุบัน, ลายเซ็นดิจิทัลสนับสนุนเฉพาะรูปแบบ PPTX เท่านั้น.

## **เพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX**

ตัวอย่างโค้ดด้านล่างจะแสดงวิธีการเพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX:

1. เปิดไฟล์ PFX แล้วส่งรหัสผ่าน PFX ไปยังวัตถุ [**DigitalSignature**](https://reference.aspose.com/slides/th/net/aspose.slides/digitalsignature) .
1. เพิ่มลายเซ็นที่สร้างขึ้นไปยังวัตถุ presentation.

```c#
using (Presentation pres = new Presentation())
{
    // สร้างอ็อบเจกต์ DigitalSignature ด้วยไฟล์ PFX และรหัสผ่าน PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // คอมเมนต์ลายเซ็นดิจิทัลใหม่
    signature.Comments = "Aspose.Slides digital signing test.";

    // เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ
    pres.DigitalSignatures.Add(signature);

    // บันทึกงานนำเสนอ
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

ตอนนี้สามารถตรวจสอบได้ว่าผลงานนำเสนอถูกลงลายเซ็นดิจิทัลและไม่ได้ถูกแก้ไขหรือไม่:

```c#
 // เปิดงานนำเสนอ
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // ตรวจสอบว่าลายเซ็นดิจิทัลทั้งหมดเป็นที่ถูกต้องหรือไม่
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถลบลายเซ็นที่มีอยู่จากไฟล์ได้หรือไม่?**

ใช่. คอลเลกชันลายเซ็นดิจิทัลสนับสนุนการ [removing individual items](https://reference.aspose.com/slides/th/net/aspose.slides/digitalsignaturecollection/removeat/) และการ [clearing it entirely](https://reference.aspose.com/slides/th/net/aspose.slides/digitalsignaturecollection/clear/); หลังจากคุณบันทึกไฟล์ งานนำเสนอจะไม่มีลายเซ็นใด ๆ.

**ไฟล์จะกลายเป็น “อ่านอย่างเดียว” หลังจากลงลายเซ็นหรือไม่?**

ไม่. ลายเซ็นทำหน้าที่รักษาความสมบูรณ์และผู้เขียนไว้แต่ไม่ได้บล็อกการแก้ไข เพื่อจำกัดการแก้ไข ให้ผสานกับ ["Read-only" or a password](/slides/th/net/password-protected-presentation/).

**ลายเซ็นจะแสดงผลอย่างถูกต้องในเวอร์ชันต่าง ๆ ของ PowerPoint หรือไม่?**

ลายเซ็นถูกสร้างสำหรับคอนเทนเนอร์ OOXML (PPTX) เวอร์ชันสมัยใหม่ของ PowerPoint ที่รองรับลายเซ็น OOXML จะแสดงสถานะของลายเซ็นเหล่านี้อย่างถูกต้อง.