---
title: เพิ่มลายเซ็นดิจิทัลในพรีเซนเทชันด้วย C++
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/cpp/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยรับรองใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของพรีเซนเทชัน
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเซ็นพรีเซนเทชัน PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ C++ เพื่อตรวจสอบหรือกำจัดลายเซ็นดิจิทัล"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับระบุว่าใครเป็นผู้เซ็นพรีเซนเทชันและเนื้อหาที่เซ็นมีการเปลี่ยนแปลงหรือไม่ มีแนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญดังนี้

- **ใบรับรองดิจิทัล** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงอัตลักษณ์กับคีย์สาธารณะ หน่วยรับรองใบรับรองที่น่าเชื่อถือ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่เซ็นด้วยตนเองสำหรับการทำงานภายใน
- **ลายเซ็นดิจิทัล** สร้างจากเนื้อหาในพรีเซนเทชันและคีย์ส่วนตัวของผู้ถือใบรับรอง คีย์สาธารณะของใบรับรองจะถูกใช้เพื่อตรวจสอบลายเซ็น ลายเซ็นเป็นหลักฐานของต้นทางและความสมบูรณ์ ไม่ได้เข้ารหัสพรีเซนเทชัน
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขพรีเซนเทชันได้หรือไม่ ซึ่งแยกจากการลงลายเซ็นดิจิทัล และอธิบายเพิ่มเติมใน [Password-Protected Presentations](/slides/th/cpp/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** ภายใต้ **File > Info > Protect Presentation**

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

หลังจากเปิดพรีเซนเทชันที่มีลายเซ็น PowerPoint จะสามารถแสดงการแจ้งเตือนสถานะลายเซ็น

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_digitalsignatures/), ซึ่งคืนค่าเป็น [IDigitalSignatureCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignaturecollection/) ที่รายการของมันทำตาม [IDigitalSignature](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/). พรีเซนเทชันสามารถมีลายเซ็นหลายรายการได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX (หรือที่รู้จักในชื่อไฟล์ PKCS#12) ซึ่งมักมีนามสกุล `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, คีย์ส่วนตัวของมัน, และห่วงโซ่ใบรับรอง คีย์ส่วนตัวเป็นสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีคีย์ส่วนตัวที่เข้าถึงได้จะไม่สามารถใช้เซ็นพรีเซนเทชันได้

รหัสผ่าน PFX ปกป้องแพคเกจใบรับรองและคีย์ส่วนตัว **ไม่ได้** เป็นรหัสผ่านสำหรับเปิดหรือแก้ไขพรีเซนเทชัน อย่า commit ไฟล์ PFX หรือรหัสผ่านของมันลงใน source control ในการใช้งานจริง ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างต่อไปนี้ใช้ตัวแปรสภาพแวดล้อมเพียงอย่างเดียวเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในพรีเซนเทชัน**

เพื่อทำงานเซ็นพรีเซนเทชันจริง โหลดไฟล์ PPTX ที่มีอยู่แล้ว, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/cpp/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นลงในคอลเลกชันของพรีเซนเทชัน, แล้วบันทึกเป็นไฟล์ PPTX

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

การบันทึกผลลัพธ์ด้วยชื่อใหม่จะรักษาไฟล์ต้นฉบับที่ยังไม่ได้เซ็นไว้ ค่าของ [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/set_comments/) อธิบายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อนำเข้าไฟล์ PPTX ที่มีลายเซ็น, ตรวจสอบแต่ละรายการที่คืนค่าจาก [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_digitalsignatures/). วิธี [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/get_isvalid/) จะบอกว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาพรีเซนเทชันปัจจุบันหรือไม่

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

ผลลัพธ์ที่ไม่ถูกต้องมักหมายถึงว่าเนื้อหาในพรีเซนเทชันที่เซ็นหรือข้อมูลลายเซ็นมีการเปลี่ยนแปลงหลังจากเซ็น, หรือไฟล์เสีย การลบลายเซ็นทั้งหมดจะทำให้พรีเซนเทชันเป็นเวอร์ชันที่ไม่ได้เซ็น ดังนั้นการตรวจสอบเพียงความถูกต้องของรายการไม่เพียงพอ: กระบวนการที่เกี่ยวกับความปลอดภัยต้องตรวจสอบว่าจำนวนลายเซ็นที่คาดหวังและอัตลักษณ์ของผู้เซ็นที่คาดไว้มีอยู่ครบหรือไม่

ผลลัพธ์ความถูกต้องนี้ไม่ควรใช้เป็นการตัดสินใจเชื่อมั่นใบรับรองอย่างสมบูรณ์ ตามนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอนของใบรับรอง, ยืนยันหัวข้อหรือรหัสประจำตัวที่คาดหวัง, ตรวจสอบการใช้คีย์, และประเมิน timestamp ที่เชื่อถือได้ ค่า [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignature/get_signtime/) เพียงอย่างเดียวไม่ถือเป็นหลักฐานจากผู้ให้บริการ timestamp ที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสภาวะความปลอดภัยของพรีเซนเทชัน ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่เซ็นแล้ว, ลบลายเซ็นทั้งหมดด้วย [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignaturecollection/clear/), แล้วบันทึกเป็นสำเนาที่ไม่ได้เซ็น

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากต้องการลบลายเซ็นเพียงหนึ่งรายการ ให้เรียก [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/idigitalsignaturecollection/removeat/) ด้วยตำแหน่งดัชนีที่เริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ต้นฉบับที่เซ็นไว้โดยตรง

## **การแก้ไขและข้อพิจารณาเรื่องรูปแบบ**

- ลายเซ็นไม่ได้ทำให้พรีเซนเทชันเป็นไฟล์อ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังคงแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่เซ็นจะทำให้ลายเซ็นเดิมหมดความถูกต้อง
- ควรทำการแก้ไขทั้งหมดก่อนเซ็น หากต้องการแก้ไขพรีเซนเทชันอีกครั้ง ให้บันทึกรุ่นที่แก้ไขแล้วและเซ็นรุ่นนั้นใหม่อีกครั้ง
- เก็บผลลัพธ์สุดท้ายเป็นรูปแบบ PPTX การแปลงพรีเซนเทชันที่เซ็นแล้วเป็นรูปแบบอื่นจะไม่ได้ย้ายลายเซ็น PPTX ดั้งเดิมไปเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลง
- ปฏิบัติตามคีย์ส่วนตัวของใบรับรองเป็นข้อมูลที่อ่อนไหว ผู้ที่ได้คีย์ส่วนตัวและรหัสผ่านอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- เก็บไฟล์ต้นฉบับที่ไม่ได้เซ็นหรือสำเนาที่ควบคุมไว้ เมื่อนโยบายการเก็บรักษาเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลทำให้พรีเซนเทชันถูกเข้ารหัสหรือไม่?**

ไม่ ลายเซ็นดิจิทัลเป็นหลักฐานของต้นทางและความสมบูรณ์เท่านั้น เนื้อหาพรีเซนเทชันยังคงอ่านได้ถ้าไม่ได้ทำการเข้ารหัสแยกกัน ใช้ [password protection](/slides/th/cpp/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX เป็นรหัสผ่านของพรีเซนเทชันหรือไม่?**

ไม่ รหัสผ่าน PFX ใช้เพื่อปลดล็อกคีย์ส่วนตัวที่เก็บอยู่ในแพคเกจใบรับรอง ไม่ได้ควบคุมว่าผู้ใดสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองแบบเซ็นด้วยตนเองได้หรือไม่?**

ในเชิงเทคนิคสามารถใช้ใบรับรองที่เซ็นด้วยตนเองได้หากมีคีย์ส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่เชื่อมั่นโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ งานที่เกี่ยวข้องกับหลายองค์กรมักใช้ใบรับรองจาก CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นเป็นโมฆะ?**

การเปลี่ยนแปลงเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นหลังจากเซ็นจะทำให้ลายเซ็นโมฆะ ไฟล์เสียก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด พรีเซนเทชันจะกลายเป็นเวอร์ชันที่ไม่ได้เซ็น ไม่ใช่ไฟล์ที่มีลายเซ็นโมฆะ

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้เซ็นหรือไม่?**

ไม่โดยตรง ความสมบูรณ์ของลายเซ็นและความเชื่อมั่นต่อผู้เซ็นเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบในสภาพแวดล้อมการผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ระยะเวลาที่มีผล, สถานะการเพิกถอน, อัตลักษณ์ที่คาดหวัง, การใช้คีย์ และข้อกำหนดของ timestamp ที่เชื่อถือได้ด้วย

**หากใบรับรองหมดอายุจะเกิดอะไรขึ้น?**

การหมดอายุของใบรับรองไม่เปลี่ยนแปลงไบต์ของพรีเซนเทชัน แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรอง การที่ลายเซ็นยังคงยอมรับได้หรือไม่ขึ้นอยู่กับนโยบายของคุณและว่ามี timestamp ที่เชื่อถือได้แสดงว่าการเซ็นเกิดขึ้นในช่วงที่ใบรับรองยังมีอายุหรือไม่ อย่าพึ่งพาเวลาเซ็นที่แสดงบนหน้าจอเป็น timestamp ที่เชื่อถือได้อย่างเดียว

**พรีเซนเทชันที่เซ็นแล้วยังสามารถแก้ไขได้หรือไม่?**

ได้ การเซ็นไม่ได้ล็อคไฟล์ การแก้ไขเนื้อหาที่เซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง ดังนั้นให้ทำการแก้ไขให้เสร็จก่อนแล้วจึงเซ็นเวอร์ชันสุดท้าย

**พรีเซนเทชันสามารถมีลายเซ็นได้มากกว่าหนึ่งรายการหรือไม่?**

ได้ ให้เพิ่มแต่ละลายเซ็นลงในคอลเลกชันที่คืนค่าจาก [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_digitalsignatures/) ก่อนบันทึก ในระหว่างการตรวจสอบ ตรวจสอบทุกลายเซ็นและยืนยันว่าผู้เซ็นที่ต้องการทั้งหมดมีอยู่

**ฟอร์แมตพรีเซนเทชันใดบ้างที่รองรับการดำเนินการเหล่านี้?**

Aspose.Slides รองรับการดำเนินการลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX ฟอร์แมต PPT และ OpenDocument ไม่รองรับโดย API นี้

**สามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้ สามารถลบลายเซ็นหนึ่งรายการหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกพรีเซนเทชัน เนื้อหาสไลด์ยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว