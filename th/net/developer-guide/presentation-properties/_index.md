---
title: จัดการคุณสมบัตินำเสนอใน .NET
linktitle: คุณสมบัตินำเสนอ
type: docs
weight: 70
url: /th/net/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัตินำเสนอ
- คุณสมบัติด็อกเมนต์
- คุณสมบัติ built-in
- คุณสมบัติ custom
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจทาน
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมคุณสมบัตินำเสนอใน Aspose.Slides สำหรับ .NET และปรับปรุงการค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณ."
---
## **บทนำ**

Aspose.Slides for .NET รองรับสองประเภทของคุณสมบัติด็อกเมนต์: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ API ของ Aspose.Slides for .NET

Aspose.Slides ให้คุณทำงานกับคุณสมบัติด็อกเมนต์ของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกส่งคืนโดยคุณสมบัติ [Presentation.DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/documentproperties/) ตัวอย่างต่อไปนี้แสดงวิธีอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="primary" %}} 
โปรดทราบว่า ฟิลด์ **Application** และ **Producer** ไม่สามารถแก้ไขได้ เนื่องจากฟิลด์เหล่านี้จะแสดงเสมอว่า "Aspose Ltd." และ "Aspose.Slides for .NET x.x.x"
{{% /alert %}} 

## **จัดการคุณสมบัตินำเสนอ**

Microsoft PowerPoint มีฟีเจอร์สำหรับเพิ่มคุณสมบัติลงในไฟล์งานนำเสนอ คุณสมบัติด็อกเมนต์เหล่านี้ทำให้สามารถเก็บข้อมูลที่เป็นประโยชน์ควบคู่กับไฟล์ได้ มีสองประเภทของคุณสมบัติด็อกเมนต์:

- คุณสมบัติกำหนดโดยระบบ (built-in)
- คุณสมบัติกำหนดโดยผู้ใช้ (custom)

**Built-in** คุณสมบัติมีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเรื่องผู้เขียน สถิติของเอกสาร ฯลฯ

**Custom** คุณสมบัตาถูกกำหนดโดยผู้ใช้เป็นคู่ **Name/Value** โดยทั้งชื่อและค่าเป็นที่ผู้ใช้ระบุ

โดยใช้ Aspose.Slides for .NET นักพัฒนาสามารถเข้าถึงและแก้ไขทั้งคุณสมบัติ built-in และ custom ได้

Microsoft PowerPoint อนุญาตให้ผู้ใช้จัดการคุณสมบัติด็อกเมนต์โดยคลิกไอคอน Office แล้วเลือก **File → Info → Properties** หลังจากเลือก **Advanced Properties** จะปรากฏกล่องโต้ตอบที่คุณสามารถจัดการคุณสมบัติด็อกเมนต์ทั้งหมดของไฟล์งานนำเสนอได้

ในกล่องโต้ตอบ **Properties** มีหลายแท็บ เช่น **General**, **Summary**, **Statistics**, **Contents**, และ **Custom** แต่ละแท็บให้ตัวเลือกสำหรับกำหนดประเภทข้อมูลที่เกี่ยวข้องกับไฟล์ PowerPoint **Custom** แท็บใช้สำหรับจัดการคุณสมบัติกำหนดโดยผู้ใช้

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) ได้แก่: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (บ่งบอกว่าเอกสารถูกแชร์ระหว่างผู้ผลิตหลายคนหรือไม่), **PresentationFormat**, **Subject**, **Title** และอื่น ๆ

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
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

การแก้ไขคุณสมบัติ built-in ของไฟล์งานนำเสนอทำได้ง่ายเท่ากับการเข้าถึงคุณสมบัติเหล่านั้น คุณสามารถกำหนดค่าข้อความให้กับคุณสมบัติใดก็ได้ที่ต้องการและค่าจะถูกอัปเดต ตัวอย่างด้านล่างจะแสดงวิธีแก้ไขคุณสมบัติด็อกเมนต์ built-in ของไฟล์งานนำเสนอ

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// รับอ้างอิงไปยังอ็อบเจ็กต์ประเภท IDocumentProperties ที่เชื่อมโยงกับงานนำเสนอ.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// ตั้งค่าคุณสมบัติ Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// บันทึกงานนำเสนอลงไฟล์.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **เพิ่มคุณสมบัตินำเสนอแบบ Custom**

คุณสมบัตินำเสนอแบบ Custom ช่วยให้นักพัฒนาสามารถเก็บเมตาดาต้าเพิ่มเติมหรือข้อมูลเฉพาะภายในไฟล์งานนำเสนอ Aspose.Slides ทำให้สร้างและจัดการคุณสมบัติแบบ Custom ได้ง่ายโดยใช้โค้ด ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มคุณสมบัติแบบ Custom ลงในงานนำเสนอของคุณ

```cs
// สร้างอินสแตนซ์ของคลาส Presentation.
using Presentation presentation = new Presentation();

// รับอ้างอิงไปยังอ็อบเจ็กต์ประเภท IDocumentProperties ที่เชื่อมโยงกับงานนำเสนอ.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// เพิ่มคุณสมบัติ custom.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// บันทึกงานนำเสนอลงไฟล์.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides ยังอนุญาตให้ผู้พัฒนาสามารถเข้าถึงคุณสมบัติ Custom ที่มีอยู่แล้วและแก้ไขค่าของมันได้อย่างง่ายดาย ฟังก์ชันนี้ช่วยให้รักษาเมตาดาต้าที่แม่นยำและสนับสนุนการอัปเดตแบบไดนามิกตามอินพุตของผู้ใช้หรือตรรกะทางธุรกิจ ตัวอย่างด้านล่างแสดงวิธีดึงค่าและอัปเดตคุณสมบัติ Custom ภายในงานนำเสนอ

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// รับอ้างอิงไปยังอ็อบเจ็กต์ประเภท IDocumentProperties ที่เชื่อมโยงกับงานนำเสนอ.
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

// บันทึกงานนำเสนอลงไฟล์.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**ดูและแก้ไขเมตาดาต้า PowerPoint**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติด็อกเมนต์โดยใช้ Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in ออกจากการนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนประกอบสำคัญของการนำเสนอและไม่สามารถลบออกได้อย่างสมบูรณ์ อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างหากคุณสมบัตินั้นอนุญาตให้ทำเช่นนั้นได้

**ถ้าฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้วค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดได้หรือไม่?**

ได้ คุณสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดโดยใช้เมธอด `GetPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `ReadDocumentProperties` ที่ให้โดยอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ช่วยประหยัดหน่วยความจำและเพิ่มประสิทธิภาพการทำงาน