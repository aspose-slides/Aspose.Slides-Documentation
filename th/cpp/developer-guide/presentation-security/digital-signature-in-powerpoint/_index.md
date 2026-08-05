---
title: เพิ่มลายเซ็นดิจิทัลในงานนำเสนอด้วย C++
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/cpp/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยออกใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีลงลายเซ็นดิจิทัลในงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ C++ เพื่อตรวจสอบหรือกำจัดลายเซ็นดิจิทัล"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับกำหนดว่าใครเป็นผู้ลงนามในงานนำเสนอและเนื้อหาที่ลงนามมีการเปลี่ยนแปลงหรือไม่ แนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการมีความสำคัญที่นี่:

- **ใบรับรองดิจิทัล** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงอัตลักษณ์กับคีย์สาธารณะ ผู้ให้บริการใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่ลงนามด้วยตนเองสำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** ถูกสร้างจากเนื้อหาในงานนำเสนอและคีย์ส่วนตัวของผู้ถือใบรับรอง คีย์สาธารณะของใบรับรองนั้นจะใช้เพื่อตรวจสอบลายเซ็น ลายเซ็นให้หลักฐานของที่มและความสมบูรณ์; ไม่ได้เข้ารหัสงานนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขงานนำเสนอได้หรือไม่ แยกจากการลงนามดิจิทัลและอธิบายไว้ใน **[งานนำเสนอที่ป้องกันด้วยรหัสผ่าน](/cpp/password-protected-presentation/)**

PowerPoint มีคำสั่ง **Add a Digital Signature** ภายใต้ **File > Info > Protect Presentation**.

![เมนูปกป้องการนำเสนอของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

หลังจากเปิดงานนำเสนอที่มีลายเซ็นแล้ว PowerPoint สามารถแสดงการแจ้งสถานะลายเซ็นได้

![การแจ้งของ PowerPoint ระบุว่าการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน **[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_digitalsignatures/)** ซึ่งจะคืนค่า **[IDigitalSignatureCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignaturecollection/)** ที่รายการต่าง ๆ ของมันใช้ **[IDigitalSignature](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/)** การนำเสนอสามารถมีลายเซ็นหลายรายการได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX หรือที่รู้จักในชื่อไฟล์ PKCS#12 พร้อมนามสกุล `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, คีย์ส่วนตัวของมัน, และห่วงโซ่ใบรับรอง คีย์ส่วนตัวเป็นสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีคีย์ส่วนตัวที่เข้าถึงได้ไม่สามารถใช้เพื่อลงนามงานนำเสนอได้

รหัสผ่าน PFX ปกป้องแพ็คเกจใบรับรองและคีย์ส่วนตัว **ไม่ใช่** รหัสผ่านสำหรับเปิดหรือแก้ไขงานนำเสนอ อย่าใส่ไฟล์ PFX หรือรหัสผ่านของมันลงในระบบควบคุมรุ่น ในการผลิต ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอ**

เพื่อทำการลงนามในกระบวนการทำงานของงานนำเสนอจริง ให้โหลดไฟล์ PPTX ที่มีอยู่, สร้าง **[DigitalSignature](https://reference.aspose.com/slides/th/cpp/aspose.slides/digitalsignature/)** จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นลงในคอลเลกชันของงานนำเสนอ, และบันทึกเป็นไฟล์ PPTX

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การบันทึกผลลัพธ์ภายใต้ชื่อใหม่จะรักษาไฟล์ต้นฉบับที่ไม่ได้ลงนามไว้ **[IDigitalSignature::set_Comments](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/set_comments/)** ใช้เพื่ออธิบายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบความถูกต้องของลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่มีลายเซ็น, ตรวจสอบแต่ละรายการที่คืนโดย **[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_digitalsignatures/)** วิธี **[IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/get_isvalid/)** แสดงว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาปัจจุบันของงานนำเสนอหรือไม่

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

ผลลัพธ์ที่ไม่ถูกต้องมักหมายความว่าเนื้อหาที่ลงนามหรือข้อมูลลายเซ็นมีการเปลี่ยนแปลงหลังจากลงนาม, หรือไฟล์เสียหาย การลบลายเซ็นทั้งหมดทำให้ได้งานนำเสนอที่ไม่ได้ลงนาม ดังนั้นการตรวจสอบเพียงความถูกต้องของรายการไม่เพียงพอ: กระบวนการทำงานที่ต้องคำนึงถึงความปลอดภัยต้องตรวจสอบด้วยว่าจำนวนลายเซ็นและอัตลักษณ์ของผู้ลงนามตามที่คาดหวังมีอยู่หรือไม่

ผลลัพธ์ความถูกต้องนี้ไม่ควรพิจารณาเป็นการตัดสินใจในระดับความเชื่อถือของใบรับรองอย่างสมบูรณ์ ตามนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, เช็ควันที่มีผลของใบรับรองและสถานะการเพิกถอน, ยืนยันหัวเรื่องหรือบันทัต/thumbprint ที่คาดหวัง, ตรวจสอบการใช้คีย์, และประเมินการประทับเวลาที่เชื่อถือได้ ค่า **[IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/get_signtime/)** ด้วยตัวมันเองไม่ใช่หลักฐานจากหน่วยงานประทับเวลากลาง  

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นทำให้สถานะความปลอดภัยของงานนำเปลี่ยนไป ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่มีลายเซ็น, ลบลายเซ็นทั้งหมดด้วย **[IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignaturecollection/clear/)** และบันทึกสำเนาที่ไม่ได้ลงนาม

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากต้องการลบเพียงลายเซ็นเดียว ให้เรียก **[IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignaturecollection/removeat/)** พร้อมดัชนีศูนย์‑ฐานของมัน บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ต้นฉบับที่ลงนามเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ

## **ข้อพิจารณาการแก้ไขและรูปแบบ**

- ลายเซ็นไม่ได้ทำให้งานนำเสนอเป็นแบบอ่าน‑อย่างเดียว ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงนามมักทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดที่ต้องการให้เสร็จก่อนลงนาม หากต้องเปลี่ยนงานนำเสนอ ให้บันทึกงานนำเสนอที่แก้ไขแล้วและลงนามฉบับนั้นอีกครั้ง
- เก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงงานนำเสนอที่ลงนามเป็นรูปแบบอื่นจะไม่ถ่ายโอนลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ปฏิบัติต่อคีย์ส่วนตัวของใบรับรองเป็นข้อมูลลับ ใครที่ได้คีย์ส่วนตัวและรหัสผ่านของมันอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้น
- รักษาไฟล์ต้นฉบับที่ไม่ได้ลงนามหรือสำเนาที่ควบคุมอย่างเข้มงวดเมื่อกรอบเวลาการเก็บเอกสารของคุณกำหนดไว้

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสงานนำเสนอหรือไม่?**

ไม่. ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับที่มาและความสมบูรณ์, แต่เนื้อหาของงานนำเสนอยังคงอ่านได้หากไม่มีการเข้ารหัสแยกต่างหาก ใช้ **[การป้องกันด้วยรหัสผ่าน](/cpp/password-protected-presentation/)** เมื่อต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX กับรหัสผ่านของงานนำเสนอเป็นอย่างเดียวกันหรือไม่?**

ไม่. รหัสผ่าน PFX ใช้เพื่อปลดล็อกคีย์ส่วนตัวที่เก็บไว้ในแพ็คเกจใบรับรอง ไม่ได้ควบคุมว่าใครสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้หรือไม่?**

ในเชิงเทคนิคสามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้หากมีคีย์ส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่เชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มลงในสภาพแวดล้อมที่เชื่อถืออย่างชัดเจน การทำงานระหว่างองค์กรทั่วไปมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นเป็นโมฆะ?**

การเปลี่ยนแปลงเนื้อหาที่ลงนามหรือข้อมูลลายเซ็นหลังจากลงนามทำให้ลายเซ็นโมฆะ ไฟล์ที่เสียหายก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด งานนำเสนอจะกลายเป็นงานที่ไม่ได้ลงนาม ไม่ใช่ไฟล์ที่มีลายเซ็นโมฆะ

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้ลงนามหรือไม่?**

ไม่ได้โดยตัวมันเอง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้ลงนามเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบในผลิตภัณฑ์ควรตรวจสอบห่วงโซ่ใบรับรอง, ช่วงเวลาที่มีผล, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้คีย์, และข้อกำหนดของการประทับเวลาที่เชื่อถือได้

**ถ้าใบรับรองหมดอายุจะเกิดอะไรขึ้น?**

การหมดอายุของใบรับรองไม่ทำให้ไบต์ของงานนำเปลี่ยนแปลง แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรองว่า ยังรับรองลายเซ็นได้หรือไม่ การที่ลายเซ็นยังคงยอมรับได้ขึ้นอยู่กับนโยบายของคุณและว่ามีการประทับเวลาที่เชื่อถือได้แสดงว่าการลงนามเกิดขึ้นขณะใบรับรองยังมีอายุหรือไม่ อย่าพึ่งพาเวลาแสดงผลการลงนามอย่างเดียวเป็นการประทับเวลาที่เชื่อถือได้

**งานนำเสนอที่ลงนามยังสามารถแก้ไขได้หรือไม่?**

ได้ การลงนามไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่ลงนามมักทำให้ลายเซ็นเดิมไม่ถูกต้อง ดังนั้นให้ทำการแก้ไขให้เสร็จก่อนและลงนามฉบับแก้ไขสุดท้าย

**งานนำเสนอสามารถมีลายเซ็นหลายรายการได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละรายการลงในคอลเลกชันที่ **[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_digitalsignatures/)** ก่อนบันทึก ระหว่างการตรวจสอบให้ตรวจสอบลายเซ็นทุกรายการและยืนยันว่าผู้ลงนามที่ต้องการทั้งหมดปรากฏอยู่

**รูปแบบงานนำเสนอใดบ้างที่รองรับการทำงานเหล่านี้?**

Aspose.Slides รองรับการดำเนินการลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX; รูปแบบ PPT และ OpenDocument จะไม่ได้รับการสนับสนุนโดย API นี้

**สามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้ คุณสามารถลบลายเซ็นหนึ่งรายการหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกงานนำเสนอ เนื้อหาของสไลด์จะยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว