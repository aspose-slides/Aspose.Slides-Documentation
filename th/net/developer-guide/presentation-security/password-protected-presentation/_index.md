---
title: ปกป้องงานนำเสนอด้วยรหัสผ่านใน .NET
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/net/password-protected-presentation/
keywords:
- ล็อก PowerPoint
- ล็อกงานนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกงานนำเสนอ
- ปกป้อง PowerPoint
- ปกป้องงานนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสงานนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสงานนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัย PowerPoint
- ความปลอดภัยของงานนำเสนอ
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดใช้งานรหัสผ่าน
- ปิดใช้งานการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกงานนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านอย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET. ปกป้องงานนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณตั้งรหัสผ่านเพื่อป้องกันการเข้าถึงงานนำเสนอ หมายความว่าคุณกำหนดรหัสผ่านที่บังคับใช้ข้อจำกัดบางประการบนงานนำเสนอ หากต้องการลบข้อจำกัดเหล่านี้ ต้องป้อนรหัสผ่าน งานนำเสนอที่มีการป้องกันด้วยรหัสผ่านถือว่าเป็นงานนำเสนอที่ถูกล็อก

โดยทั่วไปคุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนงานนำเสนอได้:

- **การแก้ไข**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่แก้ไขงานนำเสนอของคุณ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแก้ไข เปลี่ยนแปลง หรือคัดลอกรายการในงานนำเสนอของคุณ เว้นแต่พวกเขาจะให้รหัสผ่าน

  อย่างไรก็ตาม แม้ไม่มีรหัสผ่าน ผู้ใช้ก็ยังสามารถเข้าถึงและเปิดเอกสารของคุณได้ ในโหมดอ่านอย่างเดียวนี้ ผู้ใช้สามารถดูเนื้อหา—including hyperlinks, animations, effects, and other elements—ภายในงานนำเสนอของคุณ แต่ไม่สามารถคัดลอกรายการหรือบันทึกงานนำเสนอได้

- **การเปิดไฟล์**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่เปิดงานนำเสนอของคุณ คุณสามารถตั้งข้อจำกัดการเปิดไฟล์ได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นดูเนื้อหาของงานนำเสนอของคุณ เว้นแต่พวกเขาจะให้รหัสผ่าน

  ในทางเทคนิค ข้อจำกัดการเปิดไฟล์ยังป้องกันไม่ให้ผู้ใช้แก้ไขงานนำเสนอของคุณด้วย — หากคนไม่สามารถเปิดงานนำเสนอได้ พวกเขาก็ไม่สามารถแก้ไขหรือทำการเปลี่ยนแปลงใด ๆ ได้

**หมายเหตุ:** เมื่อคุณตั้งรหัสผ่านเพื่อป้องกันการเปิดไฟล์ ไฟล์งานนำเสนอจะถูกเข้ารหัส

## **การป้องกันด้วยรหัสผ่านใน Aspose.Slides**

**ฟอร์แมตที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการที่คล้ายกันสำหรับงานนำเสนอในฟอร์แมตต่อไปนี้:

- PPTX และ PPT – Microsoft PowerPoint Presentations
- ODP – OpenDocument Presentations
- OTP – OpenDocument Presentation Templates

**การดำเนินการที่รองรับ**

Aspose.Slides ให้คุณใช้การป้องกันด้วยรหัสผ่านบนงานนำเสนอเพื่อป้องกันการแก้ไขในวิธีต่อไปนี้:

- การเข้ารหัสงานนำเสนอ
- การตั้งการป้องกันการเขียนบนงานนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides ให้คุณทำงานเพิ่มเติมที่เกี่ยวกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสได้ตามวิธีต่อไปนี้:

- การถอดรหัสงานนำเสนอ; การเปิดงานนำเสนอที่ถูกเข้ารหัส
- การลบการเข้ารหัส; การปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากงานนำเสนอ
- การดึงข้อมูลคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัส
- การตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่ก่อนโหลด
- การตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่

## **ป้องกันงานนำเสนอด้วยรหัสผ่าน**

คุณสามารถเข้ารหัสงานนำเสนอโดยกำหนดรหัสผ่าน จากนั้นเพื่อแก้ไขงานนำเสนอที่ถูกล็อก ผู้ใช้จะต้องให้รหัสผ่าน

เพื่อเข้ารหัส (หรือป้องกันด้วยรหัสผ่าน) งานนำเสนอ ใช้เมธอด `Encrypt` จาก [ProtectionManager](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager) เพื่อกำหนดรหัสผ่าน ส่งรหัสผ่านให้เมธอด `Encrypt` แล้วใช้เมธอด `Save` เพื่อบันทึกงานนำเสนอที่เพิ่งถูกเข้ารหัส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการเข้ารหัสงานนำเสนอ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **ตั้งการป้องกันการเขียนบนงานนำเสนอ**

คุณสามารถเพิ่มเครื่องหมาย “Do not modify” ลงในงานนำเสนอ ซึ่งจะแจ้งให้ผู้ใช้ทราบว่าคุณไม่ต้องการให้พวกเขาแก้ไขงานนำเสนอ

**หมายเหตุ:** กระบวนการป้องกันการเขียนไม่ทำการเข้ารหัสงานนำเสนอ ดังนั้นผู้ใช้—หากต้องการ—สามารถแก้ไขงานนำเสนอได้ แต่เมื่อบันทึกการเปลี่ยนแปลง จะต้องบันทึกเป็นชื่อไฟล์อื่น

เพื่อตั้งการป้องกันการเขียน ใช้เมธอด `SetWriteProtection` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งการป้องกันการเขียนบนงานนำเสนอ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **โหลดงานนำเสนอที่ถูกเข้ารหัส**

Aspose.Slides ให้คุณโหลดงานนำเสนอที่ถูกเข้ารหัสโดยส่งรหัสผ่านที่ถูกต้อง ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการโหลดงานนำเสนอที่ถูกเข้ารหัส:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว.
}
```

## **ลบการเข้ารหัสจากงานนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านจากงานนำเสนอได้ เพื่อให้ผู้ใช้เข้าถึงหรือแก้ไขได้โดยไม่มีข้อจำกัด

เพื่อทำการลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน ให้เรียกเมธอด [RemoveEncryption](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/methods/removeencryption) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบการเข้ารหัสจากงานนำเสนอ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **ลบการป้องกันการเขียนจากงานนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนจากไฟล์งานนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขได้ตามต้องการ — และจะไม่มีการแจ้งเตือนใด ๆ ขณะทำเช่นนั้น

คุณสามารถลบการป้องกันการเขียนโดยใช้เมธอด [RemoveWriteProtection](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/methods/removewriteprotection) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบการป้องกันการเขียนจากงานนำเสนอ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **ดึงคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัส**

โดยทั่วไปผู้ใช้มักประสบปัญหาในการดึงคุณสมบัติของเอกสารจากงานนำเสนอที่ถูกเข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ทำให้คุณสามารถป้องกันงานนำเสนอด้วยรหัสผ่านพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติได้

**หมายเหตุ:** ตามค่าเริ่มต้นเมื่อ Aspose.Slides เข้ารหัสงานนำเสนอ คุณสมบัติของเอกสารในงานนำเสนอนั้นก็จะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติของเอกสารสามารถเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides อนุญาตให้ทำได้โดยตรง

หากคุณต้องการให้ผู้ใช้ยังคงเข้าถึงคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัส ให้ตั้งค่า `EncryptDocumentProperties` ของ [IProtectionManager](https://reference.aspose.com/slides/th/net/aspose.slides/iprotectionmanager/) เป็น `false` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเข้ารหัสงานนำเสนอพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสาร:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **โหลดเฉพาะคุณสมบัติของเอกสารจากงานนำเสนอที่ถูกเข้ารหัส**

เพื่อสำรวจเมตาดาต้าของงานนำเสนอที่ถูกเข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) และตั้งค่า [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) เป็น `true` ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติของเอกสารที่เปิดเผยต่อสาธารณะ

โค้ดตัวอย่างต่อไปนี้อ่านคุณสมบัติบิลต์‑อินและคุณสมบัติที่กำหนดโดยผู้ใช้ผ่าน [IPresentation.DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/documentproperties/) :

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// อ่านคุณสมบัติเอกสารที่กำหนดไว้ล่วงหน้า.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// อ่านคุณสมบัติเอกสารที่กำหนดเอง.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

กระบวนการทำงานนี้ใช้ได้เฉพาะเมื่อคุณสมบัติของเอกสารถูกทิ้งไว้โดยไม่มีการเข้ารหัส (public) ตอนที่งานนำเสนอถูกเข้ารหัส หากคุณสมบัติของเอกสารถูกเข้ารหัส การตั้งค่า `OnlyLoadDocumentProperties` เป็น `true` จะทำให้เกิดข้อยกเว้น เนื่องจากรหัสผ่านถูกละเว้นในโหมดนี้ หากต้องการเข้าถึงคุณสมบัติที่เข้ารหัสหรือโหลดงานนำเสนอเต็มรูปแบบรวมถึงสไลด์และเนื้อหาอื่น ๆ ให้ระบุค่ารหัสผ่านที่ถูกต้องใน [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) .

## **ตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดงานนำเสนอ คุณอาจต้องการตรวจสอบว่ามันไม่ได้ถูกป้องกันด้วยรหัสผ่าน การทำเช่นนี้ช่วยป้องกันข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อโหลดงานนำเสนอที่ป้องกันด้วยรหัสผ่านโดยไม่ได้ใส่รหัสผ่านที่ถูกต้อง

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบงานนำเสนอว่ามีการป้องกันด้วยรหัสผ่านหรือไม่โดยไม่ต้องโหลดจริง:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **ตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้คุณสมบัติ [IsEncrypted](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/properties/isencrypted) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกเข้ารหัสหรือ `false` หากไม่ถูกเข้ารหัส

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้คุณสมบัติ [IsWriteProtected](https://reference.aspose.com/slides/th/net/aspose.slides/protectionmanager/properties/iswriteprotected) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกป้องกันการเขียนหรือ `false` หากไม่ถูกป้องกัน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **ยืนยันการใช้รหัสผ่านของงานนำเสนอ**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันเอกสารงานนำเสนอหรือไม่ Aspose.Slides มีวิธีให้คุณตรวจสอบความถูกต้องของรหัสผ่าน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตรวจสอบรหัสผ่าน:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // ตรวจสอบว่ารหัสผ่านตรงกันหรือไม่.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

มันจะคืนค่า `true` หากงานนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ; มิฉะนั้นจะคืนค่า `false`.

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [Digital Signature in PowerPoint](/slides/th/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ป้องกันงานนำเสนอด้วยรหัสผ่านออนไลน์**

1. ไปที่หน้า [**Aspose.Slides Lock**](https://products.aspose.app/slides/th/lock) ของเรา  
1. คลิก **Drop or upload your files**  
1. เลือกไฟล์ที่ต้องการตั้งรหัสผ่านบนเครื่องของคุณ  
1. ป้อนรหัสผ่านที่ต้องการสำหรับการป้องกันการแก้ไขและรหัสผ่านที่ต้องการสำหรับการป้องกันการดู  
1. หากคุณต้องการให้ผู้ใช้เห็นงานนำเสนอเป็นสำเนาสุดท้าย ให้ทำเครื่องหมายที่ช่อง **Mark as final**  
1. คลิก **PROTECT NOW.**  
1. คลิก **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Aspose.Slides รองรับวิธีการเข้ารหัสแบบใด?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่รวมถึงอัลกอริทึมแบบ AES เพื่อให้ระดับความปลอดภัยของข้อมูลสูงสำหรับงานนำเสนอของคุณ

**จะเกิดอะไรขึ้นหากป้อนรหัสผ่านไม่ถูกต้องเมื่อพยายามเปิดงานนำเสนอ?**

ระบบจะโยนข้อยกเว้น หากใช้รหัสผ่านผิด จะมีข้อความแจ้งว่าไม่สามารถเข้าถึงงานนำเสนอได้ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาของงานนำเสนอ

**การทำงานกับงานนำเสนอที่ป้องกันด้วยรหัสผ่านมีผลต่อประสิทธิภาพหรือไม่?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดค่าโอเวอร์เฮดเล็กน้อยในระหว่างการเปิดและบันทึก ในส่วนใหญ่ผลกระทบต่อประสิทธิภาพนั้นเล็กและไม่ส่งผลอย่างมีนัยสำคัญต่อเวลาโดยรวมของงานนำเสนอของคุณ