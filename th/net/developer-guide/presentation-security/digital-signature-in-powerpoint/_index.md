---
title: เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอใน .NET
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/net/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยรับรองใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเซ็นงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ .NET เพื่อตรวจสอบหรือถอนลายเซ็นดิจิทัล."
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับระบุว่าผู้ใดเป็นผู้เซ็นงานนำเสนอและเนื้อหาที่เซ็นได้มีการเปลี่ยนแปลงหรือไม่ แนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญได้แก่:

- **ใบรับรองดิจิทัล** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมต่ออัตลักษณ์กับคีย์สาธารณะ หน่วยรับรองใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองเซลฟ์‑ไซน์สำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** ถูกสร้างจากเนื้อหาของงานนำเสนอและคีย์ส่วนตัวของผู้ถือใบรับรอง คีย์สาธารณะของใบรับรองสามารถใช้ตรวจสอบลายเซ็นได้ ลายเซ็นให้หลักฐานของแหล่งที่มาและความสมบูรณ์; ไม่ได้เข้ารหัสงานนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขงานนำเสนอได้หรือไม่ แยกจากการเซ็นดิจิทัลและอธิบายเพิ่มเติมใน [การป้องกันด้วยรหัสผ่าน](/slides/th/net/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** อยู่ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint ที่ไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

หลังจากเปิดงานนำเสนอที่มีลายเซ็น PowerPoint สามารถแสดงการแจ้งสถานะลายเซ็นได้

![การแจ้งเตือนของ PowerPoint ระบุว่าการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/digitalsignatures/), ซึ่งเป็น [IDigitalSignatureCollection](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignaturecollection/) ที่รายการของมันใช้การทำงานจาก [IDigitalSignature](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignature/). งานนำเสนอสามารถมีหลายลายเซ็นได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX ซึ่งรู้จักกันในชื่อไฟล์ PKCS#12 และมักมีนามสกุล `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, คีย์ส่วนตัวของมัน, และโซ่ใบรับรอง คีย์ส่วนตัวเป็นสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีคีย์ส่วนตัวที่เข้าถึงได้ไม่สามารถใช้เซ็นงานนำเสนอได้

รหัสผ่านของ PFX ปกป้องแพคเกจใบรับรองและคีย์ส่วนตัว **ไม่ใช่** รหัสผ่านสำหรับเปิดหรือแก้ไขงานนำเสนอ อย่า commit ไฟล์ PFX หรือรหัสผ่านของมันลงในระบบควบคุมเวอร์ชัน ในสภาพการผลิต จำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเท่านั้นเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ**

เพื่อทำงานเซ็นงานนำเสนอจริง โหลดไฟล์ PPTX ที่มีอยู่, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/net/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นลงในคอลเลกชันของงานนำเสนอ, แล้วบันทึกเป็นไฟล์ PPTX

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

การบันทึกผลลัพธ์ด้วยชื่อใหม่จะรักษาไฟล์ต้นฉบับที่ยังไม่ได้เซ็นไว้ ค่าของ [DigitalSignature.Comments](https://reference.aspose.com/slides/th/net/aspose.slides/digitalsignature/comments/) อธิบายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่มีลายเซ็น, ตรวจสอบแต่ละรายการใน [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/digitalsignatures/). property [IDigitalSignature.IsValid](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignature/isvalid/) แสดงว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาปัจจุบันของงานนำเสนอหรือไม่

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

ผลลัพธ์ไม่ถูกต้องโดยทั่วไปหมายความว่าเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นถูกเปลี่ยนหลังการเซ็น, หรือไฟล์เสียหาย การลบลายเซ็นทั้งหมดทำให้งานนำเสนอเป็นเวอร์ชันที่ไม่มีลายเซ็น, ดังนั้นการตรวจสอบความถูกต้องของรายการเพียงอย่างเดียวนั้นไม่พอ: กระบวนการที่ต้องคำนึงถึงความปลอดภัยควรตรวจสอบจำนวนลายเซ็นที่คาดหวังและอัตลักษณ์ของผู้เซ็นที่คาดหวังด้วย

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจเชื่อถือใบรับรองโดยสมบูรณ์ ขึ้นอยู่กับนโยบายความปลอดภัยของคุณ, แอปพลิเคชันอาจต้องสร้างและตรวจสอบโซ่ใบรับรอง X.509, ตรวจสอบวันหมดอายุและสถานะการเพิกถอน, ยืนยันหัวข้อหรือรหัสลายนิ้วมือที่คาดหวัง, ตรวจสอบการใช้คีย์, และประเมินการตราประทับเวลาที่เชื่อถือได้ ค่า [IDigitalSignature.SignTime](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignature/signtime/) เพียงอย่างเดียวไม่ถือเป็นหลักฐานจากหน่วยงานที่ออกตราประทับเวลาอย่างเป็นทางการ

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสถานะความปลอดภัยของงานนำเสนอ ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่มีลายเซ็น, ลบลายเซ็นทั้งหมดด้วย [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignaturecollection/clear/), แล้วบันทึกสำเนาที่ไม่มีลายเซ็น

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

หากต้องการลบลายเซ็นเฉพาะรายการหนึ่ง ให้เรียกใช้ [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignaturecollection/removeat/) พร้อมดัชนีเริ่มจากศูนย์ บันทึกลงไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ต้นฉบับที่มีลายเซ็น

## **การแก้ไขและการพิจารณารูปแบบ**

- ลายเซ็นไม่ได้ทำให้งานนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่เซ็นจะทำให้ลายเซ็นเดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดก่อนทำการเซ็น หากต้องแก้ไขงานนำเสนอ ให้บันทึกงานนำเสนอที่แก้ไขแล้วและเซ็นเวอร์ชันนั้นอีกครั้ง
- รักษาเอาต์พุตสุดท้ายในรูปแบบ PPTX การแปลงงานนำเสนอที่มีลายเซ็นเป็นรูปแบบอื่นจะไม่ถ่ายโอนลายเซ็น PPTX ดั้งเดิมให้กลายเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือคีย์ส่วนตัวของใบรับรองเป็นข้อมูลที่อ่อนไหว ผู้ใดที่ได้คีย์ส่วนตัวและรหัสผ่านของมันอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- เก็บไฟล์ต้นฉบับที่ยังไม่ได้เซ็นหรือสำเนาที่ควบคุมไว้เมื่อแนวนโยบายการเก็บเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสงานนำเสนอหรือไม่?**

ไม่. ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับแหล่งที่มาและความสมบูรณ์, แต่เนื้อหางานนำเสนอยังคงอ่านได้หากไม่ได้ใช้การเข้ารหัสแยกต่างหาก ใช้ [การป้องกันด้วยรหัสผ่าน](/slides/th/net/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX คือรหัสผ่านของงานนำเสนอหรือไม่?**

ไม่. รหัสผ่าน PFX ใช้ปลดล็อกคีย์ส่วนตัวที่เก็บอยู่ในแพคเกจใบรับรอง ไม่ได้ควบคุมว่าใครสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองเซลฟ์‑ไซน์ได้หรือไม่?**

โดยเทคนิคแล้วใบรับรองเซลฟ์‑ไซน์สามารถใช้ได้เมื่อมีคีย์ส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่เชื่อถือโดยอัตโนมัติเว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนไปยังสภาพแวดล้อมที่เชื่อถือได้ เวิร์กโฟลว์สาธารณะหรือข้ามองค์กรมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นไม่ถูกต้อง?**

การเปลี่ยนแปลงเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นหลังจากเซ็นทำให้ลายเซ็นไม่ถูกต้อง ความเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด งานนำเสนอจะกลายเป็นเวอร์ชันที่ไม่มีลายเซ็น ไม่ใช่ไฟล์ที่มีลายเซ็นไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าควรเชื่อถือผู้เซ็นหรือไม่?**

ไม่โดยตนเอง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้เซ็นเป็นการตัดสินใจที่แยกจากกัน นโยบายการตรวจสอบในสภาพการผลิตควรตรวจสอบโซ่ใบรับรอง, ช่วงเวลาที่เป็นไปได้, สถานะการเพิกถอน, อัตลักษณ์ที่คาดหวัง, การใช้คีย์, และข้อกำหนดของตราประทับเวลาที่เชื่อถือได้

**เกิดอะไรขึ้นเมื่อใบรับรองหมดอายุ?**

วันหมดอายุของใบรับรองไม่ทำให้ไบต์ของงานนำเปลี่ยนแปลง, แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรอง การที่ลายเซ็นยังคงยอมรับได้หรือไม่ขึ้นอยู่กับนโยบายของคุณและว่ามีตราประทับเวลาที่เชื่อถือได้แสดงว่าการเซ็นเกิดขึ้นขณะใบรับรองยังมีอายุใช้งานหรือไม่ อย่าพึ่งพาเวลาเซ็นที่แสดงเป็นตราประทับเวลาที่เชื่อถือได้เพียงอย่างเดียว

**งานนำเสนอที่เซ็นแล้วยังสามารถแก้ไขได้หรือไม่?**

ได้. การเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่เซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง ดังนั้นควรทำการแก้ไขให้เสร็จสิ้นก่อนแล้วค่อยเซ็นเวอร์ชันสุดท้าย

**งานนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งรายการได้หรือไม่?**

ได้. เพิ่มลายเซ็นแต่ละรายการลงใน [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/digitalsignatures/) ก่อนบันทึก ในระหว่างการตรวจสอบ ตรวจสอบทุกลายเซ็นและยืนยันว่าผู้เซ็นที่จำเป็นทั้งหมดปรากฏอยู่

**รูปแบบงานนำเสนอใดบ้างที่รองรับการทำงานเหล่านี้?**

Aspose.Slides รองรับการดำเนินการลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX เท่านั้น ไม่รองรับรูปแบบ PPT หรือ OpenDocument สำหรับ API นี้

**สามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้. คุณสามารถลบลายเซ็นหนึ่งรายการหรือทำการเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกงานนำเสนอ เนื้อหาสไลด์ยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว