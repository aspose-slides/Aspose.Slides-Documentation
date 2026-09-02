---
title: จัดการคุณสมบัติงานนำเสนอใน .NET
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/net/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติที่มีอยู่ในระบบ
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบ
- ภาษามาตรฐาน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ .NET และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระเบียบง่ายขึ้น"
---
## **บทนำ**

Aspose.Slides for .NET รองรับสองประเภทของคุณสมบัติเอกสาร: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ API ของ Aspose.Slides for .NET.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเอกสารงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกคืนค่าผ่านคุณสมบัติ [Presentation.DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน แก้ไข และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
กรุณาทราบว่า ฟิลด์ **Application** และ **Producer** ไม่สามารถแก้ไขได้ เนื่องจากฟิลด์เหล่านี้จะแสดงเสมอว่า "Aspose Ltd." และ "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **จัดการคุณสมบัติงานนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์สำหรับเพิ่มคุณสมบัติให้กับไฟล์งานนำเสนอ คุณสมบัติเอกสารเหล่านี้อนุญาตให้จัดเก็บข้อมูลที่เป็นประโยชน์พร้อมกับไฟล์ มีสองประเภทของคุณสมบัติเอกสาร:

- คุณสมบัติที่กำหนดโดยระบบ (built-in)
- คุณสมบัติที่กำหนดโดยผู้ใช้ (custom)

คุณสมบัติ **Built-in** มีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเอกสาร ชื่อผู้เขียน สถิติเอกสาร และอื่น ๆ

คุณสมบัติ **Custom** ถูกกำหนดโดยผู้ใช้เป็นคู่ **Name/Value** โดยทั้งชื่อและค่าถูกระบุโดยผู้ใช้

โดยใช้ Aspose.Slides for .NET นักพัฒนาสามารถเข้าถึงและแก้ไขคุณสมบัติทั้ง built-in และ custom ได้

Microsoft PowerPoint อนุญาตให้ผู้ใช้จัดการคุณสมบัติเอกสารโดยคลิกไอคอน Office แล้วเลือก **File → Info → Properties** หลังจากเลือก **Advanced Properties** จะปรากฏหน้าต่างที่คุณสามารถจัดการคุณสมบัติเอกสารทั้งหมดของไฟล์งานนำเสนอได้

ในหน้าต่าง **Properties** มีหลายแท็บ เช่น **General**, **Summary**, **Statistics**, **Contents**, และ **Custom** แต่ละแท็บให้ตัวเลือกในการกำหนดค่าประเภทข้อมูลเฉพาะที่เกี่ยวข้องกับไฟล์ PowerPoint แท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติที่กำหนดโดยผู้ใช้

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ ตามที่ได้เปิดเผยโดยอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) รวมถึง: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ล่าสุด), **LastModifiedBy**, **SharedDoc** (บ่งชี้ว่าเอกสารถูกแชร์ระหว่างผู้สร้างต่าง ๆ), **PresentationFormat**, **Subject**, **Title**, และอื่น ๆ

```cs
using Aspose.Slides;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

การแก้ไขคุณสมบัติ built-in ของไฟล์งานนำเสนอเป็นเรื่องง่ายเท่ากับการเข้าถึงคุณสมบัติ คุณสามารถกำหนดค่า string ให้กับคุณสมบัติใดก็ได้ที่ต้องการและค่าของคุณสมบัตินั้นจะถูกอัปเดต ในตัวอย่างด้านล่าง เราจะแสดงวิธีการแก้ไขคุณสมบัติเอกสาร built-in ของไฟล์งานนำเสนอ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// รับการอ้างอิงถึงอ็อบเจ็กต์ประเภท IDocumentProperties ที่เชื่อมโยงกับงานนำเสนอ
IDocumentProperties documentProperties = presentation.DocumentProperties;

// กำหนดคุณสมบัติ Built-in
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// บันทึกงานนำเสนอเป็นไฟล์
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **เพิ่มคุณสมบัติ Custom ของงานนำเสนอ**

คุณสมบัติ Custom ของงานนำเสนอช่วยให้นักพัฒนาสามารถเก็บข้อมูลเมตาเพิ่มเติมหรือข้อมูลเฉพาะภายในไฟล์งานนำเสนอ Aspose.Slides ทำให้การสร้างและจัดการคุณสมบัติเช่นนี้โดยโปรแกรมเป็นเรื่องง่าย ตัวอย่างต่อไปนี้จะแสดงวิธีการเพิ่มคุณสมบัติ custom ให้กับงานนำเสนอของคุณ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation.
using Presentation presentation = new Presentation();

// รับการอ้างอิงถึงอ็อบเจ็กต์ประเภท IDocumentProperties ที่เชื่อมโยงกับงานนำเสนอ.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// เพิ่มคุณสมบัติแบบกำหนดเอง.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// บันทึกงานนำเสนอเป็นไฟล์.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides ยังอนุญาตให้นักพัฒนาสามารถเข้าถึงคุณสมบัติ custom ที่มีอยู่และแก้ไขค่าของมันได้อย่างง่ายดาย ฟังก์ชันนี้ช่วยให้รักษาความแม่นยำของเมตาเดต้าและรองรับการอัปเดตแบบไดนามิกตามข้อมูลจากผู้ใช้หรือโลจิกของธุรกิจ ตัวอย่างด้านล่างแสดงวิธีการดึงและอัปเดตค่าคุณสมบัติ custom ภายในงานนำเสนอ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// รับการอ้างอิงถึงอ็อบเจ็กต์ประเภท IDocumentProperties ที่เชื่อมโยงกับงานนำเสนอ.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // แก้ไขค่าของคุณสมบัติแบบกำหนดเอง.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// บันทึกงานนำเสนอเป็นไฟล์.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **ตัวอย่างสด**

ลองใช้งานแอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีการทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in จากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่าเหล่านั้นหรือกำหนดให้เป็นค่าว่างได้ถ้าคุณสมบัตินั้นอนุญาต

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอได้โดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบหรือไม่?**

ได้. ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) แล้วตามด้วย [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาเดต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ดูที่ [Build a Lightweight Presentation Inventory](/slides/th/net/examine-presentation/) สำหรับตัวอย่างการรายงานที่สมบรูณ์และข้อจำกัดของรูปแบบ