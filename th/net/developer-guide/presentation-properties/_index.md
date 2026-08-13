---
title: จัดการคุณสมบัติการนำเสนอใน .NET
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/net/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาทาเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการพิสูจน์อักษร
- ภาษาที่กำหนดโดยค่าเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides for .NET และเพิ่มประสิทธิภาพการค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณ"
---
## **บทนำ**

Aspose.Slides for .NET รองรับคุณสมบัติเบื้องต้นสองประเภท: **Built-in** และ **Custom** คุณสมบัติทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายด้วย Aspose.Slides for .NET API

Aspose.Slides ให้คุณทำงานกับคุณสมบัติของไฟล์การนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกคืนค่าโดยคุณสมบัติ [Presentation.DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" %}} 

โปรดทราบว่าฟิลด์ **Application** และ **Producer** ไม่สามารถแก้ไขได้ เนื่องจากฟิลด์เหล่านี้จะแสดงผลเสมอเป็น "Aspose Ltd." และ "Aspose.Slides for .NET x.x.x"

{{% /alert %}} 

## **จัดการคุณสมบัติการนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์สำหรับเพิ่มคุณสมบัติให้กับไฟล์การนำเสนอ คุณสมบัติของเอกสารเหล่านี้ช่วยให้ข้อมูลที่เป็นประโยชน์ถูกเก็บไว้พร้อมกับไฟล์ มีสองประเภทของคุณสมบัติเอกสาร:

- คุณสมบัติที่ระบบกำหนดไว้ (built-in)
- คุณสมบัติที่ผู้ใช้กำหนดเอง (custom)

คุณสมบัติ **Built-in** เก็บข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเรื่องของเอกสาร, ชื่อผู้เขียน, สถิติของเอกสาร, และอื่นๆ

คุณสมบัติ **Custom** ถูกกำหนดโดยผู้ใช้เป็นคู่ **Name/Value** โดยทั้งชื่อและค่าจะถูกผู้ใช้ระบุเอง

ด้วย Aspose.Slides for .NET นักพัฒนาสามารถเข้าถึงและแก้ไขทั้งคุณสมบัติ built-in และ custom ได้

Microsoft PowerPoint ให้ผู้ใช้จัดการคุณสมบัติของเอกสารโดยคลิกไอคอน Office แล้วเลือก **File → Info → Properties** หลังจากเลือก **Advanced Properties** จะปรากฏไดอะล็อกที่คุณสามารถจัดการคุณสมบัติทั้งหมดของไฟล์การนำเสนอ

ในไดอะล็อก **Properties** มีหลายแท็บ เช่น **General**, **Summary**, **Statistics**, **Contents**, และ **Custom** แท็บแต่ละอันให้ตัวเลือกสำหรับกำหนดค่าประเภทข้อมูลที่เกี่ยวข้องกับไฟล์ PowerPoint **Custom** แท็บใช้สำหรับจัดการคุณสมบัติที่ผู้ใช้กำหนดเอง

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) ประกอบด้วย: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (บ่งบอกว่าเอกสารถูกแชร์ระหว่างผู้ผลิตหลายคน), **PresentationFormat**, **Subject**, **Title** และอื่นๆ

```cs
using Aspose.Slides;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// รับอ้างอิงไปยังอ็อบเจกต์ประเภท IDocumentProperties ที่เชื่อมโยงกับการนำเสนอ
IDocumentProperties documentProperties = presentation.DocumentProperties;

// แสดงคุณสมบัติ Built-in
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **แก้ไขคุณสมบัติ Built-in**

การแก้ไขคุณสมบัติ built-in ของไฟล์การนำเสนอทำได้ง่ายเท่ากับการเข้าถึง เพียงกำหนดค่าเป็นสตริงให้กับคุณสมบัติที่ต้องการ ค่าใหม่จะถูกอัปเดต ในตัวอย่างด้านล่างจะแสดงวิธีแก้ไขคุณสมบัติเอกสาร built-in ของไฟล์การนำเสนอ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Set the Built-in properties.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **เพิ่มคุณสมบัติการนำเสนอแบบ Custom**

คุณสมบัติการนำเสนอแบบ Custom ช่วยให้นักพัฒนาสามารถจัดเก็บเมตาดาต้าเพิ่มเติมหรือข้อมูลเฉพาะภายในไฟล์การนำเสนอ Aspose.Slides ทำให้การสร้างและจัดการคุณสมบัติแบบ Custom ผ่านโค้ดเป็นเรื่องง่าย ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มคุณสมบัติแบบ Custom ให้กับการนำเสนอของคุณ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation.
using Presentation presentation = new Presentation();

// รับอ้างอิงไปยังอ็อบเจกต์ประเภท IDocumentProperties ที่เชื่อมโยงกับการนำเสนอ.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// เพิ่มคุณสมบัติกำหนดเอง.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// บันทึกการนำเสนอไปยังไฟล์.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides ยังอนุญาตให้นักพัฒนาสามารถเข้าถึงคุณสมบัติ Custom ที่มีอยู่และแก้ไขค่าของมันได้อย่างง่ายดาย ฟีเจอร์นี้ช่วยรักษาเมตาดาต้าที่แม่นยำและรองรับการอัปเดตแบบไดนามิกตามข้อมูลอินพุตของผู้ใช้หรือตรรกะธุรกิจ ตัวอย่างด้านล่างแสดงวิธีดึงค่าและอัปเดตค่าคุณสมบัติ Custom ภายในการนำเสนอ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// รับอ้างอิงไปยังอ็อบเจกต์ประเภท IDocumentProperties ที่เชื่อมโยงกับการนำเสนอ.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // แสดงชื่อและค่าของคุณสมบัติกำหนดเอง.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // แก้ไขค่าของคุณสมบัติกำหนดเอง.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// บันทึกการนำเสนอไปยังไฟล์.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารด้วย Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

### ฉันจะลบคุณสมบัติ built-in ออกจากการนำเสนอได้อย่างไร?

คุณสมบัติ built-in เป็นส่วนสำคัญของการนำเสนอและไม่สามารถลบออกได้โดยสมบูรณ์ อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

### ถ้าฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้วจะเกิดอะไรขึ้น?

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้วค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ Aspose.Slides จะอัปเดตค่าโดยอัตโนมัติ ไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน

### ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอเต็มรูปแบบหรือไม่?

ได้ คุณสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดเต็มรูปแบบได้โดยใช้เมธอด `GetPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `ReadDocumentProperties` ของอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ช่วยประหยัดหน่วยความจำและเพิ่มประสิทธิภาพการทำงาน