---
title: การรักษาความปลอดภัยของการนำเสนอด้วยรหัสผ่านใน .NET
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/net/password-protected-presentation/
keywords:
- ล็อก PowerPoint
- ล็อกการนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกการนำเสนอ
- ปกป้อง PowerPoint
- ปกป้องการนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสการนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสการนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัยของ PowerPoint
- ความปลอดภัยของการนำเสนอ
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดการใช้งานรหัสผ่าน
- ปิดการใช้งานการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกการนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านอย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET. ปกป้องการนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณตั้งรหัสผ่านป้องกันการนำเสนอ หมายความว่าคุณกำลังกำหนดรหัสผ่านเพื่อบังคับใช้ข้อจำกัดบางอย่างกับการนำเสนอ การลบข้อจำกัดเหล่านี้ต้องป้อนรหัสผ่าน การนำเสนอที่ถูกป้องกันด้วยรหัสผ่านถือว่าเป็นการนำเสนอที่ถูกล็อก

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้กับการนำเสนอได้:

- **การแก้ไข**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไข ข้อจำกัดนี้จะป้องกันไม่ให้บุคคลแก้ไข เปลี่ยนแปลง หรือคัดลอกองค์ประกอบในการนำเสนอของคุณ หากไม่ได้ให้รหัสผ่าน

อย่างไรก็ตาม แม้ไม่มีรหัสผ่าน ผู้ใช้ยังสามารถเข้าถึงและเปิดเอกสารของคุณได้ ในโหมดอ่านอย่างเดียวนี้ ผู้ใช้สามารถดูเนื้อหา รวมถึงลิงก์เชื่อม, แอนิเมชัน, เอฟเฟกต์ และองค์ประกอบอื่น ๆ ภายในการนำเสนอได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกการนำเสนอได้

- **การเปิด**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิด ข้อจำกัดนี้จะป้องกันไม่ให้บุคคลดูเนื้อหาของการนำเสนอหากไม่ได้ให้รหัสผ่าน

จากมุมมองทางเทคนิค ข้อจำกัดการเปิดยังป้องกันไม่ให้ผู้ใช้แก้ไขการนำเสนอของคุณด้วย — หากคนไม่สามารถเปิดการนำเสนอได้ พวกเขาก็ไม่สามารถแก้ไขหรือทำการเปลี่ยนแปลงใด ๆ ได้

**หมายเหตุ:** เมื่อคุณตั้งรหัสผ่านเพื่อป้องกันการเปิดการนำเสนอ ไฟล์การนำเสนอจะถูกเข้ารหัส

## **การป้องกันด้วยรหัสผ่านใน Aspose.Slides**

**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการที่คล้ายคลึงกันสำหรับการนำเสนอในรูปแบบต่อไปนี้:

- PPTX และ PPT – การนำเสนอ Microsoft PowerPoint
- ODP – การนำเสนอ OpenDocument
- OTP – แม่แบบการนำเสนอ OpenDocument

**การดำเนินการที่รองรับ**

Aspose.Slides ให้คุณใช้การป้องกันด้วยรหัสผ่านบนการนำเสนอเพื่อป้องกันการแก้ไขได้หลายวิธี:

- การเข้ารหัสการนำเสนอ
- การตั้งค่าการป้องกันการเขียนบนการนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides ให้คุณทำงานเพิ่มเติมที่เกี่ยวข้องกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสได้หลายวิธี:

- การถอดรหัสการนำเสนอ; การเปิดการนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; ปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากการนำเสนอ
- การดึงคุณสมบัติของการนำเสนอที่เข้ารหัส
- การตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่ก่อนทำการโหลด
- การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่

## **ปกป้องการนำเสนอด้วยรหัสผ่าน**

คุณสามารถเข้ารหัสการนำเสนอโดยตั้งรหัสผ่าน จากนั้นเพื่อแก้ไขการนำเสนอที่ล็อก ผู้ใช้ต้องให้รหัสผ่าน

สำหรับการเข้ารหัส (หรือการป้องกันด้วยรหัสผ่าน) การนำเสนอ ให้ใช้เมธอด `Encrypt` จาก [ProtectionManager](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager) เพื่อกำหนดรหัสผ่าน ส่งรหัสผ่านไปยังเมธอด `Encrypt` แล้วใช้เมธอด `Save` เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัสแล้ว

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเข้ารหัสการนำเสนอ:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าการป้องกันการเขียนบนการนำเสนอ** 

คุณสามารถเพิ่มเครื่องหมาย "ห้ามแก้ไข" ลงในการนำเสนอ ซึ่งจะแจ้งให้ผู้ใช้ทราบว่าคุณไม่ต้องการให้พวกเขาแก้ไขการนำเสนอ

**หมายเหตุ:** กระบวนการป้องกันการเขียนไม่ได้เข้ารหัสการนำเสนอ ดังนั้นผู้ใช้—หากต้องการ—สามารถแก้ไขการนำเสนอได้ แต่เมื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องบันทึกเป็นชื่อไฟล์ใหม่

เพื่อกำหนดการป้องกันการเขียน ให้ใช้เมธอด `SetWriteProtection` โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าการป้องกันการเขียนบนการนำเสนอ:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **โหลดการนำเสนอที่เข้ารหัส**

Aspose.Slides ให้คุณโหลดการนำเสนอที่เข้ารหัสโดยส่งรหัสผ่านที่ถูกต้อง โค้ดตัวอย่างต่อไปนี้แสดงวิธีโหลดการนำเสนอที่เข้ารหัส:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // ทำงานกับการนำเสนอที่ถูกถอดรหัส.
}
```

## **ลบการเข้ารหัสจากการนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านจากการนำเสนอ ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขได้โดยไม่มีข้อจำกัด

เพื่อทำการลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน ให้เรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/methods/removeencryption) โค้ดตัวอย่างต่อไปนี้แสดงวิธีลบการเข้ารหัสจากการนำเสนอ:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **ลบการป้องกันการเขียนจากการนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนออกจากไฟล์การนำเสนอ ทำให้ผู้ใช้สามารถแก้ไขตามต้องการโดยไม่พบคำเตือนใด ๆ

ให้ลบการป้องกันการเขียนโดยใช้เมธอด [RemoveWriteProtection](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/methods/removewriteprotection) โค้ดตัวอย่างต่อไปนี้แสดงวิธีลบการป้องกันการเขียนจากการนำเสนอ:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **ดึงคุณสมบัติของการนำเสนอที่เข้ารหัส**

โดยทั่วไป ผู้ใช้มักประสบปัญหาในการดึงคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัสหรือถูกป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ให้คุณป้องกันการนำเสนอด้วยรหัสผ่านพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้

**หมายเหตุ:** ตามค่าเริ่มต้น เมื่อ Aspose.Slides เข้ารหัสการนำเสนอ คุณสมบัติเ�เอกสารของการนำเสนอจะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติเ�เอกสารเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides อนุญาตให้ทำเช่นนั้นได้

หากคุณต้องการให้ผู้ใช้ยังคงเข้าถึงคุณสมบัติของการนำเสนอที่เข้ารหัส ให้กำหนดคุณสมบัติ `EncryptDocumentProperties` ของ [IProtectionManager](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/) เป็น `false` โค้ดตัวอย่างต่อไปนี้แสดงวิธีเข้ารหัสการนำเสนอพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติเข้ากเอกสารได้:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **โหลดเฉพาะคุณสมบัติเอกสารจากการนำเสนอที่เข้ารหัส**

เพื่อสำรวจเมตาดาต้าของการนำเสนอที่เข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) แล้วกำหนด [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) เป็น `true` ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติเ�เอกสารที่เปิดให้เข้าถึงได้สาธารณะ

โค้ดตัวอย่างต่อไปนี้อ่านคุณสมบัติเข้าแบบ built‑in และแบบกำหนดเองผ่าน [IPresentation.DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

กระบวนการทำงานนี้ทำงานได้เฉพาะเมื่อคุณสมบัติเข้าเอกสารถูกปล่อยให้ไม่เข้ารหัส (สาธารณะ) ขณะการเข้ารหัสการนำเสนอ หากคุณสมบัติเข้าเอกสารถูกเข้ารหัส การตั้งค่า `OnlyLoadDocumentProperties` เป็น `true` จะทำให้เกิดข้อยกเว้น เนื่องจากรหัสผ่านจะถูกละเว้นในโหมดนี้ เพื่อเข้าถึงคุณสมบัติเข้าเอกสารที่เข้ารหัสหรือโหลดการนำเสนอเต็มรูปแบบรวมสไลด์และเนื้อหาอื่น ๆ ให้ระบุค่า `Password` ที่ถูกต้องใน [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) 

## **ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดการนำเสนอ คุณอาจต้องการตรวจสอบว่าไม่ได้รับการป้องกันด้วยรหัสผ่าน สิ่งนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อโหลดการนำเสนอที่ป้องกันด้วยรหัสผ่านโดยไม่ได้ใช้รหัสผ่านที่ถูกต้อง

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบการนำเสนอว่าถูกป้องกันด้วยรหัสผ่านหรือไม่โดยไม่ต้องโหลดจริง:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่ สำหรับงานนี้คุณสามารถใช้คุณสมบัติ [IsEncrypted](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/properties/isencrypted) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัสหรือ `false` หากไม่ถูกเข้ารหัส

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่ สำหรับงานนี้คุณสามารถใช้คุณสมบัติ [IsWriteProtected](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/properties/iswriteprotected) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกป้องกันการเขียนหรือ `false` หากไม่ถูกป้องกัน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **ยืนยันการใช้รหัสผ่านของการนำเสนอ**

คุณอาจต้องการตรวจสอบและยืนยันว่ารหัสผ่านเฉพาะถูกใช้เพื่อป้องกันเอกสารการนำเสนอหรือไม่ Aspose.Slides มีวิธีให้คุณตรวจสอบรหัสผ่าน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบรหัสผ่าน:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // ตรวจสอบว่ารหัสผ่านตรงกันหรือไม่.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

มันจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ; มิฉะนั้นจะคืนค่า `false`

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. ไปที่หน้า [**Aspose.Slides Lock**](https://products.aspose.app/slides/th/lock) ของเรา
1. คลิก **Drop or upload your files**
1. เลือกไฟล์ที่คุณต้องการตั้งรหัสผ่านบนคอมพิวเตอร์ของคุณ
1. ป้อนรหัสผ่านที่คุณต้องการใช้สำหรับการป้องกันการแก้ไขและรหัสผ่านที่คุณต้องการใช้สำหรับการป้องกันการดู
1. หากคุณต้องการให้ผู้ใช้เห็นการนำเสนอของคุณในรูปแบบสำเนาสุดท้าย ให้เลือกช่องทำเครื่องหมาย **Mark as final**
1. คลิก **PROTECT NOW.**
1. คลิก **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับวิธีการเข้ารหัสแบบใดบ้าง?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่รวมถึงอัลกอริธึมที่ใช้ AES ซึ่งรับประกันระดับความปลอดภัยของข้อมูลสูงสำหรับการนำเสนอของคุณ

**จะเกิดอะไรขึ้นหากป้อนรหัสผ่านไม่ถูกต้องเมื่อพยายามเปิดการนำเสนอ?**

ระบบจะโยนข้อยกเว้นหากใช้รหัสผ่านไม่ถูกต้อง ซึ่งจะแจ้งให้คุณทราบว่าการเข้าถึงการนำเสนอถูกปฏิเสธ การทำเช่นนี้ช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาการนำเสนอ

**การทำงานกับการนำเสนอที่ป้องกันด้วยรหัสผ่านส่งผลต่อประสิทธิภาพหรือไม่?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้มีค่าใช้จ่ายเพิ่มขึ้นเล็กน้อยในระหว่างการเปิดและบันทึก ในหลาย ๆ กรณีผลกระทบต่อประสิทธิภาพนั้นเล็กน้อยและไม่ส่งผลอย่างมีนัยสำคัญต่อระยะเวลาการประมวลผลโดยรวมของงานนำเสนอของคุณ