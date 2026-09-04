---
title: ปกป้องงานนำเสนอด้วยรหัสผ่านใน .NET
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/net/password-protected-presentation/
keywords:
- งานนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิดใช้งาน
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

รหัสผ่านสำหรับการเปิดใช้งานจะทำการเข้ารหัสงานนำเสนอ จำเป็นต้องใช้รหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาของงานนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ

รหัสผ่านสำหรับการเปิดใช้งานแตกต่างจากรหัสผ่านป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหา หรือป้องกันการโหลดงานนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขงานนำเสนอ ดูที่ [Write-Protect Presentations](/slides/th/net/write-protected-presentation/).

กระบวนการทำงานด้านล่างนี้ใช้ได้กับงานนำเสนอทั้งแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมแบบไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสงานนำเสนอด้วยรหัสผ่านเปิดใช้งาน**

ใช้ [IProtectionManager.Encrypt](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/encrypt/) เพื่อกำหนดรหัสผ่านเปิดใช้งาน จากนั้นใช้ [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) เพื่อบันทึกงานนำเสนอที่เข้ารหัสไว้

ตัวอย่างต่อไปนี้ทำการเข้ารหัสงานนำเสนอ PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **ทำให้คุณสมบัติเอกสารเป็นสาธารณะ**

โดยค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติเอกสารในการเข้ารหัสงานนำเสนอ คุณสมบัติ [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ควบคุมพฤติกรรมนี้โดยแยกจากการเข้ารหัสเนื้อหาสไลด์ ตั้งค่าเป็น `false` ก่อนเรียกใช้ [IProtectionManager.Encrypt](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/encrypt/) เมื่อระบบจัดทำดัชนี การจำแนก การค้นหา หรือการจัดการเอกสารต้องอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน

ตัวอย่างต่อไปนี้สร้างงานนำเสนอ PPTX ที่เข้ารหัสโดยยังคงคุณสมบัติเอกสารในตัวเป็นสาธารณะ:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

การตั้งค่า `EncryptDocumentProperties` เป็น `false` ไม่ได้ทำให้สไลด์ มาสเตอร์ เลย์เอาต์ รูปร่าง สื่อ หรือเนื้อหางานนำเสนออื่น ๆ เป็นสาธารณะ มันมีผลเฉพาะกับคุณสมบัติเอกสารเท่านั้น หากต้องการอ่านคุณสมบัติเหล่านั้นโดยไม่ต้องโหลดเนื้อหาที่เข้ารหัส ให้ดูที่ [Manage Presentation Properties](/slides/th/net/presentation-properties/).

## **โหลดงานนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) เป็นรหัสผ่านเปิดใช้งานและส่งตัวเลือกไปยัง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เมื่อโหลดไฟล์ หากรหัสผ่านเปิดใช้งานจำเป็นแต่ไม่ได้ระบุหรือระบุไม่ถูกต้อง การโหลดจะล้มเหลว

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว.
```

## **ลบการเข้ารหัสออกจากงานนำเสนอ**

โหลดงานนำเสนอพร้อมรหัสผ่านเปิดใช้งาน เรียกใช้ [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/removeencryption/) แล้วบันทึกผลงาน งานนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **ตรวจสอบรหัสผ่านเปิดใช้งานก่อนการโหลด**

ใช้ [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อดึง [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์งานนำเสนอเต็มรูปแบบ ตรวจสอบ [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/ispasswordprotected/) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกัน ให้ยืนยันค่าที่ระบุด้วย [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/checkpassword/).

### **กระบวนการทำงานแบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ทำการตรวจสอบรหัสผ่านเปิดใช้งานสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) แล้วโหลดงานนำเสนอเต็มรูปแบบ:

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

### **กระบวนการทำงานแบบสตรีม**

อิ่มโหลดแบบสตรีมของ [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationfactory/getpresentationinfo/) ให้กระบวนการทำงานเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดงานนำเสนอเต็มรูปแบบจากสตรีมนั้น

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

### **ค่าที่ส่งกลับของ CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/checkpassword/) จะคืนค่า `true` เฉพาะเมื่องานนำเสนอมีรหัสผ่านเปิดใช้งานและรหัสผ่านที่ให้มาถูกต้อง จะคืนค่า `false` ในแต่ละกรณีต่อไปนี้:
- รหัสผ่านไม่ถูกต้อง.
- งานนำเสนอไม่มีรหัสผ่านเปิดใช้งาน.
- รหัสผ่านที่ให้เป็น `null` หรือว่าง.

พฤติกรรมนี้เหมือนกันสำหรับงานนำเสนอ PPT และ PPTX

## **ตรวจสอบว่างานนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดงานนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/isencrypted/) เพื่อยืนยันว่างานนำแหล่งที่มาถูกเข้ารหัส เพื่อค้นหาการป้องกันด้วยรหัสผ่านเปิดใช้งานก่อนการโหลด ให้ใช้ `IPresentationInfo.IsPasswordProtected` ตามที่แสดงข้างต้น

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
ห้ามบันทึกรหัสผ่านเปิดใช้งานหรือใส่มันในข้อความวินิจฉัย อย่าทำการตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเท่าที่ต้องการเท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อโหลดงานนำเสนอโดยทันที

คุณสมบัติเอกสารสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่ากำหนดเอง แม้งานนำเสนอถูกเข้ารหัสก็ตาม ควรเข้ารหัสเมตาดาต้าที่เป็นความลับพร้อมกับงานนำเสนอ การทำให้คุณสมบัติสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนและทำเฉพาะเมื่อระบบจำเป็นต้องทำดัชนี, จำแนก, ค้นหา หรือจัดการไฟล์โดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน
{{% /alert %}}

## **ปกป้องรหัสผ่านงานนำเสนอออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
1. เลือกหรืออัปโหลดงานนำเสนอ
1. ป้อนรหัสผ่านสำหรับการป้องกันการดู
1. หากต้องการ สามารถป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข
1. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [ป้องกันการเขียนงานนำเสนอ](/slides/th/net/write-protected-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**รหัสผ่านเปิดใช้งานกับรหัสผ่านป้องกันการเขียนแตกต่างกันอย่างไร?**

รหัสผ่านเปิดใช้งานจะเข้ารหัสงานนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา ส่วนรหัสผ่านป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดใช้งานโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ การดึงข้อมูลงานนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้งานหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์งานนำเสนอเต็มรูปแบบ

**แอปพลิเคชันสามารถอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิดใช้งานได้หรือไม่?**

ได้ แต่เฉพาะเมื่อการเข้ารหัสงานนำเสนอทำด้วย `EncryptDocumentProperties` ตั้งเป็น `false` แอปพลิเคชันต้องใช้โหมดการโหลดเฉพาะคุณสมบัติเอกสารที่อธิบายไว้ใน [Manage Presentation Properties](/slides/th/net/presentation-properties/).

**กระบวนการตรวจสอบรหัสผ่านรองรับทั้ง PPT และ PPTX หรือไม่?**

ใช่ กระบวนการตรวจจับและตรวจสอบรหัสผ่านแบบไฟล์พาธและสตรีมทำงานเช่นเดียวกันสำหรับงานนำเสนอ PPT และ PPTX