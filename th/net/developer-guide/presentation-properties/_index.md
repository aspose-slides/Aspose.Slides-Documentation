---
title: จัดการคุณสมบัติงานนำเสนอใน .NET
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/net/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการตรวจทาน
- ภาษามาตรฐาน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอหลักใน Aspose.Slides สำหรับ .NET และทำให้การค้นหา, การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่ายขึ้น."
---
## **Introduction**

Aspose.Slides สำหรับ .NET รองรับคุณสมบัติเอกสาร **built-in** และ **custom**. ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาต้าของงานนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่กำหนดโดยผู้ใช้.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของการนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) อินเทอร์เฟซนี้จะถูกคืนค่าโดย [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์.
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเข้าเอกสารเก็บข้อมูลเชิงพรรณนาควบคู่กับเนื้อหาของงานนำเสนอ. พวกมันแบ่งออกเป็นสองประเภท:

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติของเอกสาร.
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่กำหนดโดยผู้ใช้.

Aspose.Slides สำหรับ .NET ให้การเข้าถึงทั้งสองประเภท. ใน PowerPoint, เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร. กล่องโต้ตอบจัดข้อมูลเป็นแถบต่างๆ เช่น **Summary**, **Statistics**, **Contents**, และ **Custom**. ใช้แถบ **Custom** เพื่อจัดการคุณสมบัติที่กำหนดโดยผู้ใช้.

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดปกติจะปกป้องทั้งเนื้อหาของงานนำเสนอและคุณสมบัติเข้าเอกสาร. เมื่อการนำเสนอถูกเข้ารหัสด้วย [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ตั้งค่าเป็น `false`, คุณสมบัติเข้าเอกสารของมันจะยังคงเป็นสาธารณะ. แอปพลิเคชันสามารถตั้งค่า [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) เป็น `true` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องระบุรหัสผ่านเปิด.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ถอดรหัสอะไรเลย. หากคุณสมบัติเบอร์มอยู่ในกระบวนการเข้ารหัส, การโหลดโดยไม่ใช้รหัสผ่านจะล้มเหลว. หากงานนำเสนอไม่ได้เข้ารหัส, ตัวเลือกจะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด.

ตัวอย่างนี้ต้องการงานนำเสนอที่เข้ารหัสซึ่งคุณสมบัติเข้าเอกสารถูกตั้งให้เป็นสาธารณะ. มันตรวจสอบโหมดการโหลดผ่าน [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) แล้วอ่านคุณสมบัติ built-in ผ่าน [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด. สไลด์, มาสเตอร์, เลเอาท์, รูปร่าง, สื่อ, และวัตถุอื่นๆ ของงานนำเสนอจะไม่พร้อมใช้งาน. แอปพลิเคชันควรตรวจสอบ [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) เสมอ ก่อนทำการดำเนินการที่ต้องใช้โมเดลวัตถุของงานนำเสนอทั้งหมด.

{{% alert color="warning" title="Security" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, คำอธิบาย, และค่ากำหนดเอง. ควรเข้ารหัสคุณสมบัติเชิงลึกพร้อมกับงานนำเสนอ. ให้เปิดเผยเป็นสาธารณะเฉพาะเมื่อระบบการทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบการจัดการเอกสารมีความต้องการเฉพาะในการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน.
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส, งานนำเสนอที่โหลดด้วย [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ. Aspose.Slides ไม่สามารถบันทึกคุณสมบัติที่เปลี่ยนแปลงจากวัตถุที่มีเฉพาะเมตาดาต้านี้ได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส. การอัปเดตจึงต้องใช้รหัสผ่านเปิดที่ถูกต้องและการโหลดเต็มรูปแบบ.

ตัวอย่างนี้ต้องการงานนำเสนอ PPTX ที่เข้ารหัสซึ่งมีคุณสมบัติเข้าเอกสารเป็นสาธารณะและรหัสผ่านเปิดที่ทราบ. มันเปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), อัปเดตคุณสมบัติ built-in สาธารณะ, และบันทึกผลลัพธ์. จากนั้นใช้ [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่ใช้รหัสผ่านเพื่อยืนยันค่าที่ใหม่:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาของงานนำเสนอ, จะต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสว่าเป็นอ่านอย่างเดียว.

## **เข้าถึงคุณสมบัติ Built-in**

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) เปิดเผยเมตาดาต้า built-in ผ่านคุณสมบัติที่มีประเภท, รวมถึง [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), และ [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่จัดเก็บไว้ไปยังคอนโซล. ค่าต่างๆ ขึ้นอยู่กับงานนำเข้าที่ให้; บางฟิลด์อาจว่าง.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **แก้ไขคุณสมบัติ Built-in**

เพื่ออัปเดตเมตาดาต้า built-in, กำหนดค่าให้กับคุณสมบัติที่เขียนได้ที่เปิดเผยโดย [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่, ตั้งค่า [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), และ [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), จากนั้นบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). PPTX ที่บันทึกจะมีเมตาดาต้าใหม่.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **จัดการฐาน Hyperlink**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) เก็บฐานระดับเอกสารสำหรับลิงก์สัมพันธ์. สิ่งนี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งอื่น. มันแยกจาก [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) ของลิงก์แต่ละอัน: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บไว้หรือเปลี่ยนปลายทางแบบสัมบูรณ์.

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์สัมพันธ์, เช่น `target.html`, และลิงก์สัมบูรณ์, เช่น `https://example.org/absolute.html`. มันอ่านฐานที่มีอยู่, กำหนดฐานใหม่, แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อเช็คค่าดังกล่าว. จากนั้นล้างฐานด้วย `string.Empty` และตรวจสอบค่าที่ว่างในไฟล์ที่บันทึกแยกต่างหาก. แทนที่ที่อยู่ฐานของตัวอย่างด้วยตำแหน่งของไฟล์ที่เชื่อมโยงของคุณ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

สองข้อความยืนยันควรพิมพ์ `True`. การล้างฐานจะทำให้ที่อยู่ลิงก์แต่ละอันยังคงอยู่โดยไม่เปลี่ยน.

ลิงก์สัมพันธ์ไปยัง `target.pptx` เปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old`. หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new`, บันทึกและเปิดงานนำเสนอใหม่, ลิงก์เดียวกันเปิด `new/target.pptx`. ลิงก์สัมบูรณ์ยังคงเปิดไฟล์เดียวกัน. ทดสอบลิงก์สัมพันธ์ของคุณใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน.

## **เพิ่มคุณสมบัติงานนำเสนอแบบกำหนดเอง**

คุณสมบัติกำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ built-in ที่สอดคล้อง. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ. ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่าข้อความสองค่าและค่าตัวเลขเวอร์ชัน, และบันทึกงานนำเสนอด้วย [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). การกำหนดค่าที่ชื่อที่มีอยู่แล้วจะแทนที่ค่าของคุณสมบัตินั้น.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติกำหนดเองและใช้ [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) เพื่อวนลูปผ่านมัน. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้โดย [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทุกค่าเป็นสตริงลำดับที่โดยไม่คำนึงถึงประเภทเดิม, และบันทึกการเปลี่ยนแปลง. หากไม่มีคุณสมบัติกำหนดเอง, ลูปจะไม่ทำการเปลี่ยนแปลงใดๆ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **ตัวอย่างสด**

ลองแอปออนไลน์ [**ดูและแก้ไขเมตาดาต้า PowerPoint**](https://products.aspose.app/slides/metadata) เพื่อชมวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in ออกจากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด. อย่างไรก็ตาม, คุณสามารถเปลี่ยนค่าเหล่านั้นหรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต.

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว, ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่. คุณไม่จำเป็นต้องลบหรือเช็กคุณสมบัติก่อน, เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ.

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?**

ใช่. ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) แล้วตามด้วย [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). ดู [Build a Lightweight Presentation Inventory](/slides/th/net/examine-presentation/) สำหรับตัวอย่างการรายงานแบบครบถ้วนและข้อจำกัดตามรูปแบบ.

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดได้หรือไม่?**

ใช่. งานนำเสนอจะต้องถูกเข้ารหัสด้วย [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ตั้งเป็น `false`, และต้องโหลดด้วย [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ตั้งเป็น `true`.

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมดเอกสารคุณสมบัติเพียงอย่างเดียวได้หรือไม่?**

ไม่. ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน, ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบด้วยรหัสผ่านเปิดที่ถูกต้อง.