---
title: การป้องกันการเขียนงานนำเสนอใน .NET
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/net/write-protected-presentation/
keywords:
  - การป้องกันการเขียน
  - ป้องกันการเขียน PowerPoint
  - รหัสผ่านเพื่อแก้ไข
  - จำกัดการแก้ไขงานนำเสนอ
  - ลบการป้องกันการเขียน
  - ตรวจสอบรหัสผ่านการแก้ไข
  - PowerPoint
  - งานนำเสนอ
  - .NET
  - C#
  - Aspose.Slides
description: "ตั้งค่า ตรวจจับ ตรวจสอบ และลบรหัสผ่านการป้องกันการเขียนในงานนำเสนอ PowerPoint แบบ PPT และ PPTX โดยใช้ Aspose.Slides สำหรับ .NET."
---
## **บทนำ**

รหัสผ่านป้องกันการเขียนจำกัดการแก้ไขงานนำเสนอแต่ไม่เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูงานนำเสนอที่มีการป้องกันการเขียนได้โดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน ผู้ใช้อาจสามารถแก้ไขเนื้อหาและบันทึกเป็นชื่อใหม่ได้ ดังนั้นการป้องกันการเขียนจึงไม่ควรถือเป็นกลไกความลับ

รหัสผ่านเปิดทำหน้าที่ต่างออกไป: มันเข้ารหัสงานนำเสนอและจำเป็นสำหรับการโหลดเนื้อหา เพื่อเข้ารหัสงานนำเสนอหรือยืนยันรหัสผ่านเปิด ดูที่[การป้องกันด้วยรหัสผ่านในสไลด์](/slides/th/net/password-protected-presentation/)

ขั้นตอนในบทความนี้ใช้ได้กับงานนำเสนอ PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX; เมื่อบันทึกเป็น PPT ให้ใช้ส่วนขยาย`.ppt`และรูปแบบการบันทึก PPT ที่สอดคล้อง

## **ตั้งการป้องกันการเขียนบนงานนำเสนอ**

ใช้[IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/setwriteprotection/)เพื่อกำหนดรหัสผ่านสำหรับแก้ไขงานนำเสนอ การบันทึกงานนำเสนอจะบันทึกการตั้งค่าการป้องกันไว้

ตัวอย่างต่อไปนี้ตั้งการป้องกันการเขียนบนงานนำเสนอ PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **โหลดงานนำเสนอที่มีการป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่ได้เข้ารหัสเนื้อหาของงานนำเสนอ ไม่จำเป็นต้องใช้รหัสผ่านเพื่อโหลดงานนำเสนอ รหัสผ่านมีความสำคัญเฉพาะเมื่อยืนยันสิทธิ์การแก้ไขงานนำเสนอที่ได้รับการป้องกันเท่านั้น

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

อย่าให้รหัสผ่านป้องกันการเขียนกับ[LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/). คุณสมบัตินี้รับรหัสผ่านเปิดสำหรับเนื้อหาที่เข้ารหัส หากงานนำเสนอมีทั้งสองประเภทของการป้องกัน ให้ใช้รหัสผ่านเปิดเพื่อโหลดและจัดการรหัสผ่านป้องกันการเขียนแยกต่างหาก

## **ลบการป้องกันการเขียนจากงานนำเสนอ**

ใช้[IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/removewriteprotection/)เพลิกข้อจำกัดการแก้ไข แล้วบันทึกงานนำเสนอ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

เพื่อสำรวจไฟล์โดยไม่ต้องสร้างอินสแตนซ์[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)แบบสมบูรณ์ ให้เรียก[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationfactory/getpresentationinfo/)และตรวจสอบ[IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/iswriteprotected/). คุณสมบัตินี้ใช้[NullableBool](https://reference.aspose.com/slides/th/net/aspose.slides/nullablebool/)และคืนค่า`NullableBool.True`เมื่อพบการป้องกันการเขียน

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

การ overload แบบสตรีมของ[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationfactory/getpresentationinfo/)ให้ข้อมูลเดียวกันสำหรับงานนำเสนอที่ส่งเป็นสตรีม

## **ตรวจสอบรหัสผ่านป้องกันการเขียน**

ใช้[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/checkwriteprotection/)เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดงานนำเสนอเต็ม ตรวจสอบ[IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/iswriteprotected/)ก่อนเพื่อให้แอปพลิเคชันขอหรือยืนยันรหัสผ่านเฉพาะเมื่อมีการป้องกันการเขียน

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/checkwriteprotection/)ตรวจสอบเฉพาะรหัสผ่านป้องกันการเขียน ไม่ตรวจสอบรหัสผ่านเปิดหรือกำหนดว่าข้อมูลที่เข้ารหัสสามารถโหลดได้หรือไม่ ในทางกลับกัน[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/checkpassword/)ตรวจสอบเฉพาะรหัสผ่านเปิด หากงานนำเสนอเต็มได้ถูกโหลดแล้ว[IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/checkwriteprotection/)ให้การตรวจสอบการป้องกันการเขียนที่เทียบเท่าผ่านผู้จัดการการป้องกัน

ในแอปพลิเคชันผลิตภัณฑ์จริง อย่าเก็บล็อกรหัสผ่านหรือใส่ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น และเก็บรหัสผ่านในหน่วยความจำเพียงระยะเวลาที่จำเป็นเท่านั้น

{{% alert color="info" title="See also" %}}
- [การป้องกันด้วยรหัสผ่านในสไลด์](/slides/th/net/password-protected-presentation/)
- [งานนำเสนอแบบอ่านอย่างเดียว](/slides/th/net/read-only-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนทำให้งานนำเสนอถูกเข้ารหัสหรือไม่?**

ไม่. มันจำกัดการแก้ไขแต่ทำให้เนื้อหาของงานนำเสนอยังคงสามารถโหลดและดูได้

**รหัสผ่านป้องกันการเขียนจำเป็นต้องใช้เพื่อเปิดงานนำเสนอหรือไม่?**

ไม่. จำเป็นต้องใช้รหัสผ่านเปิดเท่านั้นเพื่อโหลดเนื้อหาที่เข้ารหัสของงานนำเสนอ

**งานนำเสนอสามารถมีทั้งรหัสผ่านเปิดและรหัสผ่านป้องกันการเขียนได้หรือไม่?**

ได้. ให้ใส่รหัสผ่านเปิดผ่านตัวเลือกการโหลดเพื่อเปิดงานนำเสนอที่เข้ารหัส และตรวจสอบรหัสผ่านป้องกันการเขียนแยกต่างหากเมื่อจำเป็นต้องมีสิทธิ์แก้ไข