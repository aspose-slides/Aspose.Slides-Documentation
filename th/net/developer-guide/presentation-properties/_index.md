---
title: จัดการคุณสมบัติการนำเสนอใน .NET
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/net/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัตินำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติตัวใน
- คุณสมบัติกำหนดเอง
- คุณสมบัติเพิ่มเติม
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการตรวจสอบ
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ .NET และทำให้การค้นหา, การสร้างแบรนด์ และเวิร์กฟลว์ในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระบบระเบียบยิ่งขึ้น."
---
## **บทนำ**

Aspose.Slides for .NET รองรับคุณสมบัติเ�เอกสาร **ในตัว** และ **กำหนดเอง** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตข้อมูลเมตาของการนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่ผู้ใช้กำหนด

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเ�เอกสารการนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) ตัวอย่างของอินเทอร์เฟซนี้จะถูกคืนค่าโดย [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}

Aspose.Slides จัดการข้อมูลเมตาของแอปพลิเคชันและผู้ผลิตเมื่อบันทึกการนำเสนอ; ฟิลด์เหล่านี้บ่งบอกซอฟต์แวร์ที่สร้างผลลัพธ์

{{% /alert %}}

## **จัดการคุณสมบัติการนำเสนอ**

คุณสมบัติเ�เอกสารเก็บข้อมูลเชิงพรรณนาข้างเนื้อหาการนำเสนอ แบ่งออกเป็นสองประเภท:

- **คุณสมบัติในตัว** มีข้อมูลเมตามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติเอกสาร
- **คุณสมบัติกำหนดเอง** เก็บคู่ชื่อ/ค่าแบบที่ผู้ใช้กำหนด

Aspose.Slides for .NET ให้เข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **ไฟล์ → ข้อมูล → คุณสมบัติ → คุณสมบัติขั้นสูง** เพื่อดูข้อมูลเมตาของเอกสาร กล่องโต้ตอบจะแบ่งข้อมูลเป็นแท็บเช่น **สรุป**, **สถิติ**, **เนื้อหา**, และ **กำหนดเอง** ใช้แท็บ **กำหนดเอง** เพื่อจัดการคุณสมบัติกำหนดผู้ใช้

## **อ่านคุณสมบัติสาธารณะจากการนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดปกติจะแสดงการป้องกันทั้งเนื้อหาและคุณสมบัติเขียนเอกสาร เมื่อการนำเสนอถูกเข้ารหัสด้วย [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ตั้งค่าเป็น `false` คุณสมบัติเขียนเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถตั้งค่า [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) เป็น `true` แล้วอ่านข้อมูลเมตสาธารณะโดยไม่ต้องให้รหัสผ่านเปิด

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ควบคุมสิ่งที่ Aspose.Slides โหลด; ไม่ได้ทำการถอดรหัสใด ๆ หากคุณสมบัติเ�ถูกรวมไว้ในการเข้ารหัส การโหลดโดยไม่ใช้รหัสผ่านจะล้มเหลว หากการนำเสนอไม่ได้เข้ารหัส ตัวเลือกนี้จะถูกละเลยและการนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างต้องการการนำเสนอที่เข้ารหัสซึ่งคุณสมบัติเขียนเอกสารถูกปล่อยให้เป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) แล้วอ่านคุณสมบัติตัวในผ่าน [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) :

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

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และออบเจ็กต์การนำเสนออื่น ๆ จะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) ก่อนทำงานที่ต้องการโมเดลออบเจ็กต์การนำเสนอครบถ้วน

{{% alert color="warning" title="Security" %}}
ข้อมูลเมตสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, เรื่อง, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่ากำหนดเอง ให้เข้ารหัสคุณสมบัติที่สำคัญพร้อมกับการนำเสนอ ปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบการจัดทำดัชนี, การจำแนก, การค้นหา, หรือระบบจัดการเอกสารมีความต้องการเฉพาะในการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของการนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส การนำเสนอที่โหลดด้วย [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) มีจุดประสงค์เพื่ออ่านข้อมูลเมตสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากออบเจ็กต์ที่มีเพียงเมตข้อมูลสาธารณะได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในการนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดที่ถูกต้องและการโหลดแบบเต็ม

ตัวอย่างต้องการการนำเสนอ PPTX ที่เข้ารหัสซึ่งคุณสมบัติเขียนเอกสารเป็นสาธารณะและมีรหัสผ่านเปิดที่ทราบ มันเปิดการนำเสนอเต็มด้วย [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), อัปเดตคุณสมบัติตัวในสาธารณะ, แล้วบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดข้อมูลเมตสาธารณะโดยไม่ใช้รหัสผ่านเพื่อยืนยันค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาการนำเสนอ มันต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่านอย่างเดียว

## **เข้าถึงคุณสมบัติตัวใน**

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) เปิดเผยเมตาดาต้าตัวในผ่านคุณสมบัติแบบชนิดที่กำหนดไว้ รวมถึง [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), และ [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) ตัวอย่างนี้เปิดการนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่เก็บไว้ลงคอนโซล ค่าเหล่านี้ขึ้นกับการนำเข้าของการนำเสนอ; ฟิลด์บางอย่างอาจว่าง

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

### **รายงานหมายเลขเวอร์ชันและเวลาแก้ไข**

เพื่อรายงานแถวเดียวสำหรับแต่ละไฟล์ PPTX ในโฟลเดอร์ `presentations` ให้เรียก [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่อดึง [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) โดยไม่ต้องโหลดสไลด์สำหรับแก้ไข รูปแบบ `c` มาตรฐานสำหรับ `TimeSpan` รวมจำนวนวันเมื่อระยะเวลาถึง 24 ชั่วโมง

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

ตัวอย่างผลลัพธ์สำหรับการนำเสนอที่บันทึกเวลาแก้ไข 1 วัน, 2 ชั่วโมง, และ 5 นาที:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) เป็นเมตาดาต้าที่ยังเขียนได้ ค่าเดียวของมันไม่สามารถบ่งบอกว่าไฟล์ถูกบันทึกกี่ครั้งหรือสร้างประวัติเวอร์ชันอย่างไรได้

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) คือระยะเวลาแก้ไขที่บันทึกในไฟล์ ค่า `00:00:00` หมายถึงระยะเวลาที่บันทึกเป็นศูนย์ มันไม่ได้พิสูจน์ว่าไม่มีคนใดแก้ไขการนำเสนอ

## **แก้ไขคุณสมบัติตัวใน**

เพื่ออัปเดตเมตาดาต้าตัวใน ให้กำหนดค่าให้กับคุณสมบัติที่เขียนได้ที่เปิดเผยโดย [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) ตัวอย่างนี้เปิดการนำเสนอที่มีอยู่ ตั้งค่า [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), และ [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), แล้วบันทึกการนำเสนอที่อัปเดตด้วย [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ไฟล์ PPTX ที่บันทึกแล้วจะมีเมตาดาต้าใหม่

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

## **จัดการฐานของ Hyperlink**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) เก็บฐานระดับเอกสารสำหรับลิงก์แบบ relative วิธีนี้มีประโยชน์เมื่อย้ายการนำเสนอและไฟล์ที่ลิงก์ไปยังตำแหน่งอื่น มันแยกจาก [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) ของแต่ละลิงก์: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่จัดเก็บหรือเปลี่ยนปลายทางแบบ absolute

ตัวอย่างนี้ต้องการการนำเสนอที่มีลิงก์ relative เช่น `target.html` และลิงก์ absolute เช่น `https://example.org/absolute.html` มันอ่านฐานที่มีอยู่, ตั้งค่าฐานใหม่, แล้วบันทึกและเปิดการนำเสนออีกครั้งเพื่อตรวจสอบค่า จากนั้นล้างฐานด้วย `string.Empty` และตรวจสอบค่าที่ว่างในไฟล์บันทึกแยกต่างหาก แทนที่ฐานตัวอย่างด้วยตำแหน่งของไฟล์ที่ลิงก์ของคุณ

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

ข้อความตรวจสอบสองข้อความควรพิมพ์ `True` การล้างฐานจะไม่กระทบที่อยู่ลิงก์บุคคล

ลิงก์ relative ไปยัง `target.pptx` เปิด `old/target.pptx` เมื่ ฐานชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new` บันทึกและเปิดการนำเสนออีกครั้ง ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์ absolute ยังคงเปิดไฟล์เดิม ทดสอบลิงก์ relative ของคุณใน PowerPoint ก่อนและหลังการย้ายการนำเสนอหรือการเปลี่ยนฐาน

## **เพิ่มคุณสมบัติกำหนดเองให้กับการนำเสนอ**

คุณสมบัติกำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ตัวในที่สอดคล้องกัน [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างการนำเสนอ, เพิ่มค่า teks สองค่าและค่ารุ่นจำนวนเต็ม, แล้วบันทึกการนำเสนอด้วย [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) การกำหนดค่าให้กับชื่อที่มีอยู่แล้วจะทับค่าของคุณสมบัตินั้น

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

ตัวอย่างนี้เปิดการนำเสนอที่มีคุณสมบัติกำหนดเองและใช้ [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) เพื่อวนลูปผ่านพวกมัน [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) รับดัชนีฐานศูนย์และคืนชื่อที่ใช้โดย [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลข regardless of its original type, and saves the changes. If there are no custom properties, the loop makes no changes.

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

## **ตัวอย่างแบบเรียลไทม์**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเขียนเอกสารโดยใช้ Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติตัวในจากการนำเสนอได้อย่างไร?**

คุณสมบัติตัวในเป็นส่วนหนึ่งของการนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้ถ้าคุณสมบัตินั้นอนุญาต

**ถ้าฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว จะเกิดอะไรขึ้น?**

ถ้าคุณเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่ต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่โหลดการนำเสนอทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) แล้วตามด้วย [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ดูตัวอย่างการสร้างรายงานน้ำหนักเบาใน [Build a Lightweight Presentation Inventory](/slides/th/net/examine-presentation/) เพื่อดูตัวอย่างการรายงานครบถ้วนและข้อจำกัดตามรูปแบบ

**ฉันสามารถอ่านคุณสมบัติสาธารณะของการนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดได้หรือไม่?**

ได้ การนำเสนอจะต้องถูกเข้ารหัสด้วย [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ตั้งค่าเป็น `false` และต้องถูกโหลดด้วย [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ตั้งค่าเป็น `true`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมดโหลดเฉพาะคุณสมบัติเขียนเอกสารได้หรือไม่?**

ไม่ได้ คุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดการนำเสนอเต็มด้วยรหัสผ่านเปิดที่ถูกต้อง