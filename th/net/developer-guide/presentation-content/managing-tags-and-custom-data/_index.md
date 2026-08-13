---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย .NET
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/net/managing-tags-and-custom-data/
keywords:
- คุณสมบัติเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- XML กำหนดเอง
- ส่วน XML กำหนดเอง
- เมตาดาต้า XML
- ItemId
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET รวมถึงการเพิ่ม การอ่าน การอัปเดต การตรวจสอบ และการลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลที่เฉพาะเจาะจงต่อการนำเสนอสามารถเก็บเป็นแท็กหรือส่วน XML กำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงง่าย ๆ ในขณะที่ส่วน XML กำหนดเองสามารถเก็บเมตาดาต้าที่มีโครงสร้างและ payload XML เฉพาะแอปพลิเคชันได้

Aspose.Slides มี API สำหรับเพิ่ม อ่าน ปรับปรุง ตรวจสอบ และลบส่วน XML กำหนดเองในระดับการนำเสนอ สไลด์ และรูปร่าง ส่วน XML กำหนดเองเป็นประโยชน์สำหรับการบูรณาการที่ต้องเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร สถานะเวิร์กโฟลว์ เมตาดาต้าการปฏิบัติตามกฎ ข้อมูลการผูกเทมเพลต หรือข้อมูลแอปพลิเคชันที่มีโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์การนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีส่วนขยาย `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML. Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้เก็บเนื้อหาการนำเสนอและข้อมูลที่เกี่ยวข้อง

การนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะมีเนื้อหาของสไลด์เดี่ยวหนึ่งสไลด์และอาจมีความสัมพันธ์ที่ชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเองสามารถเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/net/aspose.slides/itagcollection)) หรือส่วน XML กำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection)) ทั้งสองอย่างนี้สามารถเข้าถึงได้ผ่านอินเทอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomdata/)  

{{% alert color="info" %}}
แท็กเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วน XML กำหนดเองเก็บข้อมูล XML ที่มีโครงสร้างและสามารถเชื่อมโยงกับการนำเสนอ สไลด์ หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

คุณสมบัติ [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomdata/customxmlparts/) จะคืนค่าคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์การนำเสนอใดอ็อบเจ็กต์หนึ่ง ตัวอย่างเช่น:

- `presentation.CustomData.CustomXmlParts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับการนำเสนอเอง
- `slide.CustomData.CustomXmlParts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape.CustomData.CustomXmlParts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปทรงเฉพาะ

ใช้ [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/allcustomxmlparts/) เมื่อคุณต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่ามันเชื่อมโยงกับอ็อบเจ็กต์ใด

### **เพิ่มส่วน XML กำหนดเองไปยังการนำเสนอ**

ใช้ [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/add/) เพื่อเพิ่มข้อมูล XML ไปยังคอลเลกชันส่วน XML กำหนดเอง XML ต้องเป็นไฟล์ที่สมบูรณ์และไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมตาดาต้าที่มีโครงสร้างไปยังคอลเลกชันข้อมูลกำหนดเองระดับการนำเสนอ:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add กำหนดตัวระบุโดยอัตโนมัติ ตั้งค่า GUID เฉพาะเมื่อจำเป็นเท่านั้น.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

เมธอด `Add` ยังสามารถรับ XML เป็นอาร์เรย์ไบต์หรือสตรีมได้ ซึ่งเป็นประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบนารี

### **เพิ่มส่วน XML กำหนดเองไปยังสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปร่างเฉพาะแทนการเชื่อมโยงกับการนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อเมตาดาต้อธิบายเฉพาะอ็อบเจ็กต์หนึ่ง เช่น คีย์เทมเพลต ตัวระบุบันทึกภายนอก หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนไปยังสไลด์และอีกส่วนหนึ่งไปยังรูปร่าง:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

ระดับที่เพิ่มส่วนจะกำหนดว่าคอลเลกชัน `CustomData.CustomXmlParts` ของอ็อบเจ็กต์ใดบ้างที่มีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับการนำเสนอเหมาะกับเมตาดาต้าทั้งเอกสาร ข้อมูลระดับสไลด์เหมาะกับข้อมูลที่เป็นของสไลด์เฉพาะ และข้อมูลระดับรูปร่างเหมาะกับเมตาดาต้าที่ผูกกับรูปร่างบุคคลหนึ่ง

### **แสดงรายการและตรวจสอบส่วน XML กำหนดเองทั้งหมด**

ใช้ [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดจากการนำเสนอ แต่ละอ็อบเจ็กต์ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/) จะเปิดเผยตัวระบุ เนื้อหา XML และสคีมเนมสเปสที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดเองทั้งหมดและสคีมเนมสเปสของพวกมัน:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/namespaceschemas/) จะคืนค่าสคีม XML ที่เชื่อมโยงกับส่วน XML กำหนดเอง ข้อมูลนี้อาจเป็นประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/xmlasstring/) เพื่อทำงานกับ XML ในรูปแบบสตริง UTF‑8 หรือใช้ [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/xmldata/) เพื่อทำงานกับไบต์ XML ดิบ ทั้งสองคุณสมบัติสามารถอ่านและอัปเดตได้

คุณสมบัติ [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/itemid/) มี GUID ที่ระบุส่วน XML กำหนดเองในเอกสาร Office Open XML สามารถเปลี่ยนแปลงได้เมื่อต้องการตัวระบุใหม่สำหรับการบูรณาการ

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// อ่าน XML ปัจจุบันเป็นข้อความ.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// อัปเดต XML เป็นสตริง UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData ให้เนื้อหา XML เดียวกันเป็นไบต์ดิบ.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// แทนที่ตัวระบุเมื่อการบูรณาการต้องการ.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

เมื่อกำหนดค่า `XmlAsString` หรือ `XmlData` ให้ใช้ XML ที่สมบูรณ์และไม่ว่างเปล่า ใช้แบบใดแบบหนึ่งตามที่แอปพลิเคชันของคุณทำงานกับสตริงหรือไบต์เป็นหลัก

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides มีวิธีลบข้อมูล XML กำหนดเองหลายวิธี:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/remove/) ลบส่วน XML กำหนดเองจากการนำเสนอ
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/remove/) ลบส่วนที่ระบุจากคอลเลกชันส่วน XML กำหนดเอง
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/removeat/) ลบส่วนที่ตำแหน่งดัชนีที่กำหนด
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/clear/) ลบส่วนทั้งหมดจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML กำหนดเองระดับการนำเสนอหนึ่งส่วนโดยอ้างอิง:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

หากคุณมีอ็อบเจ็กต์ `ICustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากการนำเสนอโดยไม่ต้องอ้างอิงคอลเลกชันใด ๆ ให้เรียก `customXmlPart.Remove()`  

คุณยังสามารถลบรายการโดยใช้ดัชนีได้เช่นกัน:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **ล้างส่วน XML กำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `Clear` เมื่อส่วน XML กำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์การนำเสนอใด ๆ ควรถูกลบ

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` มีผลต่อคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับการนำเสนอหรือระดับรูปร่าง

เพื่อให้ลบส่วน XML กำหนดเองทุกส่วนในงานนำเสนอ ให้วนลูปผ่าน `AllCustomXmlParts` และลบแต่ละส่วน:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **จัดการส่วน XML กำหนดเองที่เชื่อมโยงหรือแชร์**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเองเดียวกันอาจถูกอ้างอิงจากหลายอ็อบเจ็กต์การนำเสนอ ตัวอย่างเช่น ไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML กำหนดเองเดียวกัน

ส่วนที่แชร์ควรถือเป็นออบเจ็กต์ข้อมูลเดียวกับหลายการอ้างอิง:

- การอัปเดต `XmlAsString` `XmlData` หรือ `ItemId` จะเปลี่ยนส่วน XML กำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `ItemId` สามารถใช้ระบุส่วน XML กำหนดเองเดียวกันเมื่อทำการตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `CustomXmlParts` เฉพาะจะลบออกจากคอลเลกชันนั้น ใช้ `ICustomXmlPart.Remove()` เมื่อต้องการลบส่วนนั้นออกจากการนำเสนอทั้งหมด
- ก่อนลบหรือแทนที่ส่วนที่แชร์ ให้ตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่าสไลด์หรือรูปร่างอื่นยังอ้างอิงส่วนนั้นอยู่หรือไม่

เมธอด `Add` สร้างส่วน XML กำหนดเองใหม่จากเนื้อหา XML; ไม่รับ `ICustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่แชร์มักพบเมื่อต้องโหลดงานนำเสนอที่มีส่วนเหล่านี้อยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับการนำเสนอ‑สไลด์‑รูปร่างโดย `ItemId` และรายงานส่วนที่อ้างอิงจากมากกว่าหนึ่งตำแหน่ง:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

การตรวจสอบประเภทนี้มีประโยชน์ก่อนแก้ไขหรือคัดลบข้อมูล XML กำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมตาดาต้าเดียวกันอาจมีส่วนร่วมในความสัมพันธ์มากกว่าหนึ่งที่

## **ดึงค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับคุณสมบัติ `IDocumentProperties.Keywords` ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for .NET สำหรับ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **เพิ่มแท็กไปยังการนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กไปยังการนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติกำหนดเอง เช่น `MyTag`
- ค่าของคุณสมบัติกำหนดเอง เช่น `My Tag Value`

หากคุณต้องการจัดประเภทการนำเสนอตามกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อวัตถุประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจัดกลุ่มการนำเสนอจากประเทศในอเมริกาเหนือ คุณอาจสร้างแท็ก NorthAmerican แล้วกำหนดค่าของแท็กเป็นชื่อประเทศที่เกี่ยวข้อง

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กไปยัง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ด้วย Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

คุณสามารถตั้งค่าแท็กสำหรับ [Slide](https://reference.aspose.com/slides/th/net/aspose.slides/slide) ได้เช่นกัน:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/net/aspose.slides/shape) รายบุคคล:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `CustomData.Tags` จะถูกเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น ไม่ได้ถูกถ่ายทอดไปยังโครงสร้างแท็กของ PDF เมื่อส่งออกการนำเสนอเป็น PDF ดังนั้น ตัวระบุกำหนดเองที่เก็บเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `shape.AlternativeText = "MyId"`). หลังจากส่งออกเป็น PDF, Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากการนำเสนอ สไลด์ หรือรูปร่างในหนึ่งการดำเนินการได้หรือไม่?**

ได้. คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/) รองรับการดำเนินการ [Clear](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/clear/) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดียวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้ [Remove(name)](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/) เพื่อลบแท็กตามคีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้ [GetNamesOfTags](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/getnamesoftags/) บน [tag collection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/); จะคืนอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML กำหนดเองทั้งหมดโดยไม่คำนึงว่ามันเก็บอยู่ที่ไหนได้อย่างไร?**

ใช้ [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ

**ควรใช้ `XmlAsString` หรือ `XmlData` เพื่ออัปเดตส่วน XML กำหนดเอง?**

ใช้ `XmlAsString` เมื่อแอปพลิเคชันทำงานกับข้อความ XML UTF‑8 ใช้ `XmlData` เมื่อ XML มีอยู่แล้วเป็นอาร์เรย์ไบต์หรือเมื่อการประมวลผลแบบไบต์สะดวกกว่า ทั้งสองคุณสมบัติแทนเนื้อหา XML ของส่วน XML กำหนดเองเดียวกัน