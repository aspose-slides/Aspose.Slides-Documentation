---
title: เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอใน C++
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/cpp/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยงานออกใบรับรอง
- ใบรับรอง PFX
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการเซ็นดิจิทัลไฟล์ PowerPoint & OpenDocument ด้วย Aspose.Slides สำหรับ C++ ปกป้องสไลด์ของคุณในไม่กี่วินาทีด้วยตัวอย่างโค้ดที่ชัดเจน"
---
## **บทนำ**

**Digital certificate** ใช้เพื่อสร้างการนำเสนอ PowerPoint ที่มีการป้องกันด้วยรหัสผ่าน, ระบุว่าถูกสร้างโดยองค์กรหรือบุคคลเฉพาะ. สามารถขอรับ Digital certificate ได้โดยติดต่อกับองค์กรที่ได้รับอนุญาต – ผู้ให้บริการใบรับรอง. หลังจากติดตั้ง Digital certificate ลงในระบบแล้ว สามารถใช้เพิ่มลายเซ็นดิจิทัลลงในการนำเสนอผ่านเมนู File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

การนำเสนออาจมีลายเซ็นดิจิทัลมากกว่าหนึ่งรายการ. หลังจากเพิ่มลายเซ็นดิจิทัลลงในการนำเสนอ ข้อความพิเศษจะปรากฏใน PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

เพื่อทำการเซ็นการนำเสนอหรือเพื่อตรวจสอบความถูกต้องของลายเซ็นการนำเสนอ, **Aspose.Slides API** ให้บริการ [**IDigitalSignature**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_digital_signature) interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_digital_signature_collection) interface และ [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) method. ปัจจุบันลายเซ็นดิจิทัลรองรับเฉพาะรูปแบบ PPTX เท่านั้น.
## **เพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX**
ตัวอย่างโค้ดด้านล่างแสดงวิธีเพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX:

1. เปิดไฟล์ PFX และส่งรหัสผ่านของ PFX ไปยังอ็อบเจกต์ [**DigitalSignature**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.digital_signature).
1. เพิ่มลายเซ็นที่สร้างขึ้นไปยังอ็อบเจกต์การนำเสนอ.

``` cpp
auto pres = System::MakeObject<Presentation>();

// สร้างอ็อบเจกต์ DigitalSignature ด้วยไฟล์ PFX และรหัสผ่าน PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// คอมเมนต์ลายเซ็นดิจิทัลใหม่
signature->set_Comments(u"Aspose.Slides digital signing test.");

// เพิ่มลายเซ็นดิจิทัลลงในการนำเสนอ
pres->get_DigitalSignatures()->Add(signature);

// บันทึกการนำเสนอ
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

ตอนนี้สามารถตรวจสอบได้ว่าการนำเสนอได้รับการเซ็นดิจิทัลและไม่ได้ถูกแก้ไขหรือไม่:

``` cpp
// เปิดการนำเสนอ
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // ตรวจสอบว่าลายเซ็นดิจิทัลทั้งหมดมีความถูกต้องหรือไม่
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถลบลายเซ็นที่มีอยู่จากไฟล์ได้หรือไม่?**

ใช่. คอลเล็กชันของลายเซ็นดิจิทัลรองรับการ [removing individual items](https://reference.aspose.com/slides/th/cpp/aspose.slides/digitalsignaturecollection/removeat/) และการ [clearing it entirely](https://reference.aspose.com/slides/th/cpp/aspose.slides/digitalsignaturecollection/clear/); หลังจากบันทึกไฟล์ การนำเสนอจะไม่มีลายเซ็นใดๆ

**ไฟล์จะกลายเป็น “อ่านอย่างเดียว” หลังจากการเซ็นหรือไม่?**

ไม่. ลายเซ็นคงความสมบูรณ์และผู้เขียนไว้แต่ไม่ได้บล็อกการแก้ไข. หากต้องการจำกัดการแก้ไข ให้ผสานกับ ["Read-only" or a password](/slides/th/cpp/password-protected-presentation/).

**ลายเซ็นจะแสดงอย่างถูกต้องในเวอร์ชันต่าง ๆ ของ PowerPoint หรือไม่?**

ลายเซ็นถูกสร้างสำหรับคอนเทนเนอร์ OOXML (PPTX). เวอร์ชันสมัยใหม่ของ PowerPoint ที่รองรับลายเซ็น OOXML จะแสดงสถานะของลายเซ็นเหล่านั้นอย่างถูกต้อง.