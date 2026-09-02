---
title: ป้องกันการเข้าถึงงานนำเสนอด้วยรหัสผ่านใน .NET
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/net/password-protected-presentation/
keywords:
- งานนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิดไฟล์
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบรหัสผ่านงานนำเสนอ
- ตรวจรหัสผ่านงานนำเสนอ
- เปิดงานนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิด, และถอดรหัสงานนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน C# ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

รหัสผ่านเปิดไฟล์จะทำการเข้ารหัสงานนำเสนอ รหัสผ่านที่ถูกต้องจำเป็นต้องใช้เพื่อโหลดและดูเนื้อหาของงานนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับของข้อมูล

รหัสผ่านเปิดไฟล์แตกต่างจากรหัสผ่านการป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหา หรือป้องกันไม่ให้โหลดงานนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขงานนำเสนอ ดูที่ [Write‑Protect Presentations](/slides/th/net/write-protected-presentation/)

การทำงานด้านล่างนี้ใช้ได้กับงานนำเสนอทั้งในรูปแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมตามไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสงานนำเสนอด้วยรหัสผ่านเปิดไฟล์**

ใช้ [IProtectionManager.Encrypt](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/encrypt/) เพื่อกำหนดรหัสผ่านเปิดไฟล์ แล้วใช้ [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) เพื่อบันทึกงานนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้เข้ารหัสงานนำเสนอ PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **โหลดงานนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) เป็นรหัสผ่านเปิดไฟล์และส่งตัวเลือกนี้ไปยัง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เมื่อโหลดไฟล์ การโหลดจะล้มเหลือเมื่อมีการต้องการรหัสผ่านเปิดไฟล์แต่ไม่มีหรือรหัสผ่านที่ให้มาผิด

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว.
```

## **ลบการเข้ารหัสจากงานนำเสนอ**

โหลดงานนำเสนอพร้อมด้วยรหัสผ่านเปิดไฟล์, เรียกใช้ [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/removeencryption/), แล้วบันทึกผล งานนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **ตรวจสอบรหัสผ่านเปิดไฟล์ก่อนการโหลด**

ใช้ [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อรับ [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์งานนำเสนอเต็มรูปแบบ ตรวจสอบ [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/ispasswordprotected/) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกันอยู่ให้ตรวจสอบค่าที่ให้มาด้วย [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/checkpassword/)

### **ขั้นตอนทำงานด้วยไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดไฟล์สำหรับไฟล์ PPTX, ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/), แล้วโหลดงานนำเสนอเต็มรูปแบบ:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **ขั้นตอนทำงานด้วยสตรีม**

การ overload ของสตรีมสำหรับ [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationfactory/getpresentationinfo/) ให้ขั้นตอนเดียวกัน ตั้งตำแหน่งของสตรีมที่สามารถเลื่อนตำแหน่งได้ใหม่ก่อนโหลดงานนำเสนอเต็มรูปแบบจากสตรีมนั้น

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **ค่าที่คืนจาก CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/checkpassword/) จะคืนค่า `true` ก็ต่อเมื่องานนำมีรหัสผ่านเปิดไฟล์และรหัสผ่านที่ให้มาถูกต้อง จะคืนค่า `false` ในกรณีต่อไปนี้

- รหัสผ่านไม่ถูกต้อง
- งานนำเสนอไม่มีรหัสผ่านเปิดไฟล์
- รหัสผ่านที่ให้มาเป็น `null` หรือว่างเปล่า

พฤติกรรมนี้เหมือนกันสำหรับงานนำเสนอ PPT และ PPTX

## **ตรวจสอบว่างานนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดงานนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/isencrypted/) เพื่อยืนยันว่าต้นฉบับงานนำเสนอถูกเข้ารหัส เพื่อตรวจจับการป้องกันด้วยรหัสผ่านเปิดไฟล์ก่อนการโหลด ให้ใช้ `IPresentationInfo.IsPasswordProtected` ตามที่แสดงข้างต้น

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **คำแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
อย่าบันทึกรหัสผ่านเปิดไฟล์หรือใส่ในข้อความ diagnostics หลีกเลี่ยงการตรวจสอบรหัสผ่านซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเฉพาะเวลาที่ต้องใช้เท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อโหลดงานนำเสนอโดยทันที
{{% /alert %}}

## **ตั้งค่าการป้องกันด้วยรหัสผ่านให้กับงานนำเสนอออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดงานนำเสนอ
3. ป้อนรหัสผ่านเพื่อป้องกันการดู
4. ป้อนรหัสผ่านแยกต่างหากเพื่อป้องกันการแก้ไข (ถ้าต้องการ)
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write‑Protect Presentations](/slides/th/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รหัสผ่านเปิดไฟล์กับรหัสผ่านการป้องกันการเขียนต่างกันอย่างไร?**

รหัสผ่านเปิดไฟล์จะเข้ารหัสงานนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา รหัสผ่านการป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดไฟล์โดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ทำได้ ให้รับข้อมูลงานนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดไฟล์หรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์งานนำเสนอเต็มรูปแบบ

**ขั้นตอนการตรวจสอบรหัสผ่านทำงานได้กับทั้ง PPT และ PPTX หรือไม่?**

ทำได้ ทั้งการตรวจจับและตรวจสอบรหัสผ่านตามพาธไฟล์และสตรีมทำงานเหมือนกันสำหรับงานนำเสนอ PPT และ PPTX