---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอใน .NET
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
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET รวมถึงการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบ, และลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลเฉพาะงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือเป็นส่วน XML กำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วนส่วน XML กำหนดเองสามารถเก็บเมตาดาต้าโครงสร้างและ payload XML ที่เฉพาะแอปพลิเคชันได้

Aspose.Slides มี API สำหรับเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบ, และลบส่วน XML กำหนดเองในระดับงานนำเสนอ, สไลด์, และรูปร่าง ส่วน XML กำหนดเองเป็นประโยชน์สำหรับการรวมที่ต้องเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร, สถานะของ workflow, เมตาดาต้าการปฏิบัติตาม, ข้อมูลการเชื่อมโยงเทมเพลต, หรือข้อมูลแอปพลิเคชันโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีส่วนขยาย `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้เก็บเนื้อหางานนำเสนอและข้อมูลที่เกี่ยวข้อง

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะบรรจุเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์โดยตรงกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเองสามารถจัดเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/net/aspose.slides/itagcollection)) หรือส่วน XML กำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection)) ทั้งสองแบบสามารถเข้าถึงได้ผ่านอินเตอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomdata/) 

{{% alert color="primary" %}}
แท็กจัดเก็บเป็นคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วนส่วน XML กำหนดเองจัดเก็บข้อมูล XML โครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์, หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

คุณสมบัติ [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomdata/customxmlparts/) คืนค่าคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับออบเจกต์งานนำเสนอเฉพาะ ตัวอย่างเช่น

- `presentation.CustomData.CustomXmlParts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide.CustomData.CustomXmlParts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape.CustomData.CustomXmlParts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปร่างเฉพาะ

ใช้ [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/allcustomxmlparts/) เมื่อคุณต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอโดยไม่สนใจว่ามันเชื่อมโยงกับออบเจกต์ใด

### **เพิ่มส่วน XML กำหนดเองลงในงานนำเสนอ**

ใช้ [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/add/) เพื่อเพิ่มข้อมูล XML ลงในคอลเลกชันส่วน XML กำหนดเอง XML จะต้องเป็นที่ถูกต้องและไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมตาดาต้าโครงสร้างลงในคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:

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

เมธอด `Add` ยังสามารถรับ XML เป็นอาร์เรย์ไบต์หรือสตรีม ซึ่งเป็นประโยชน์เมื่อเนื้อหา XML มีอยู่ในรูปแบบไบนารีแล้ว

### **เพิ่มส่วน XML กำหนดเองลงในสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถผูกกับสไลด์หรือรูปร่างเฉพาะแทนจะผูกกับงานนำเสนอทั้งหมด ซึ่งเหมาะเมื่อเมตาดาต้าอธิบายเพียงออบเจกต์เดียว เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก, หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนลงในสไลด์และอีกหนึ่งส่วนลงในรูปร่าง:

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

ระดับที่ส่วนถูกเพิ่มจะกำหนดคอลเลกชัน `CustomData.CustomXmlParts` ของออบเจกต์ใดที่มีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะสำหรับเมตาดาต้าในระดับเอกสารทั้งหมด, ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์นั้น, และข้อมูลระดับรูปร่างสำหรับเมตาดาต้าที่ผูกกับรูปร่างเดียว

### **แสดงรายการและตรวจสอบส่วน XML กำหนดทั้งหมด**

ใช้ [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดทั้งหมดจากงานนำเสนอ แต่ละออบเจกต์ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/) จะเผยให้เห็นตัวระบุ, เนื้อหา XML, และสคีมเนมสเปซที่เกี่ยวข้อง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดทั้งหมดพร้อมสคีมเนมสเปซ:

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

`[ICustomXmlPart.NamespaceSchemas](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/namespaceschemas/)` คืนค่าสกิม XML ที่เชื่อมโยงกับส่วน XML กำหนดนั้น ข้อมูลนี้อาจเป็นประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/xmlasstring/) เพื่อทำงานกับ XML ในรูปแบบสตริง UTF‑8 หรือใช้ [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/xmldata/) เพื่อทำงานกับไบต์ XML ดิบ ทั้งสองคุณสมบัติสามารถอ่านและอัปเดตได้

คุณสมบัติ [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/itemid/) มี GUID ที่ระบุตัวส่วน XML กำหนดในเอกสาร Office Open XML สามารถเปลี่ยนค่าได้เมื่อต้องการตัวระบุใหม่สำหรับการเชื่อมต่อ

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

เมื่อกำหนดค่า `XmlAsString` หรือ `XmlData` ให้ใส่ XML ที่ถูกต้องและไม่ว่างเปล่า ใช้แบบใดแบบหนึ่งตามที่แอปพลิเคชันทำงานกับสตริงหรือไบต์เป็นหลัก

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides ให้วิธีการหลายแบบในการลบข้อมูล XML กำหนดเอง:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpart/remove/) ลบส่วน XML กำหนดจากงานนำเสนอ
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/remove/) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML กำหนด
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/removeat/) ลบส่วนที่ตำแหน่งดัชนีที่ระบุในคอลเลกชัน
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/th/net/aspose.slides/icustomxmlpartcollection/clear/) ลบส่วนทั้งหมดจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML กำหนดระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

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

หากคุณมีออบเจกต์ `ICustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากงานนำเสนอโดยไม่ต้องระบุคอลเลกชัน ให้เรียก `customXmlPart.Remove()`  

คุณยังสามารถลบรายการโดยใช้ดัชนีได้เช่นกัน:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **ล้างส่วน XML กำหนดทั้งหมดจากคอลเลกชัน**

ใช้ `Clear` เมื่อส่วน XML กำหนดทั้งหมดที่เชื่อมโยงกับออบเจกต์งานนำเสนอใด ๆ ควรถูกลบ

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` มีผลต่อคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปร่าง

เพื่อเอาส่วน XML กำหนดทั้งหมดในงานนำเสนอออก ให้วนลูปผ่าน `AllCustomXmlParts` แล้วลบแต่ละส่วน:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **จัดการส่วน XML กำหนดที่เชื่อมโยงหรือใช้ร่วมกัน**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเดียวอาจถูกอ้างอิงจากออบเจกต์งานนำเสนอหลาย ๆ ตัว ตัวอย่างเช่น ไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากสไลด์หรือรูปร่างหลาย ๆ ตัวไปยังส่วน XML กำหนดเดียวกัน

ส่วนที่ใช้ร่วมกันควรถือเป็นออบเจกต์ข้อมูลเดียวที่มีหลายการอ้างอิง:

- การอัปเดต `XmlAsString`, `XmlData`, หรือ `ItemId` จะเปลี่ยนส่วน XML กำหนดพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `ItemId` สามารถใช้ระบุส่วน XML กำหนดเดียวกันในระหว่างการตรวจสอบคอลเลกชันระดับออบเจกต์
- การลบส่วนจากคอลเลกชัน `CustomXmlParts` เฉพาะจะลบออกจากคอลเลกชันนั้น ใช้ `ICustomXmlPart.Remove()` เมื่อส่วนนั้นควรถูกลบออกจากงานนำเสนอทั้งหมด
- ก่อนลบหรือแทนที่ส่วนที่ใช้ร่วมกัน ให้ตรวจสอบคอลเลกชันระดับออบเจกต์เพื่อดูว่ามีสไลด์หรือรูปร่างอื่นยังอ้างอิงหรือไม่

เมธอด `Add` สร้างส่วน XML กำหนดใหม่จากเนื้อหา XML; มันไม่รับ `ICustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่ใช้ร่วมกันมักพบเมื่อโหลดงานนำเสนอที่มีส่วนเหล่านั้นอยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์, และรูปร่างโดยใช้ `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายตำแหน่ง:

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

การตรวจสอบลักษณะนี้มีประโยชน์ก่อนทำการแก้ไขหรือการลบข้อมูล XML กำหนดในงานนำเสนอที่สร้างจากระบบภายนอก เนื่องจากส่วนเมตาดาต้าเดียวอาจมีส่วนร่วมในหลายความสัมพันธ์

## **ดึงค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับคุณสมบัติ `IDocumentProperties.Keywords` ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for .NET สำหรับ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **เพิ่มแท็กลงในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กลงในงานนำเสนอ แท็กทั่วไปประกอบด้วยสองส่วน:

- ชื่อของพร็อพเพอร์ตีกำหนดเอง เช่น `MyTag`;
- ค่าของพร็อพเพอร์ตีกำหนดเอง เช่น `My Tag Value`

หากต้องการจำแนกงานนำเสนอโดยใช้กฎหรือพร็อพเพอร์ตีเฉพาะ คุณสามารถเพิ่มแท็กเพื่อจุดประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจัดประเภทงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็ก “NorthAmerican” แล้วกำหนดค่าชื่อประเทศที่เกี่ยวข้องเป็นค่าแท็ก

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กลงใน [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ด้วย Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

แท็กสามารถตั้งค่าให้กับ [Slide](https://reference.aspose.com/slides/th/net/aspose.slides/slide) ได้เช่นกัน:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

หรือให้กับ [Shape](https://reference.aspose.com/slides/th/net/aspose.slides/shape) รายบุคคล:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `CustomData.Tags` จะถูกจัดเก็บไว้ในไฟล์ PowerPoint เท่านั้น **ไม่ได้** ถูกโอนย้ายไปยังโครงสร้างแท็กของ PDF เมื่อส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุที่กำหนดเป็นแท็กไม่สามารถเรียกคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองใน **Alt Text** ของออบเจกต์ (เช่น `shape.AlternativeText = "MyId"`). หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในขั้นตอนเดียวได้หรือไม่?**

ได้. คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/) รองรับการดำเนินการ [Clear](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/clear/) ที่ลบคีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดียวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้ [Remove(name)](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/) เพื่อ删除แท็กตามคีย์

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้ [GetNamesOfTags](https://reference.aspose.com/slides/th/net/aspose.slides/tagcollection/getnamesoftags/) บนคอลเลกชันแท็ก; มันจะคืนอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML กำหนดทั้งหมดโดยไม่คำนึงว่ามันถูกจัดเก็บที่ไหน?**

ใช้ [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดทั้งหมดในงานนำเสนอ

**ฉันควรใช้ `XmlAsString` หรือ `XmlData` เพื่ออัปเดตส่วน XML กำหนด?**

ใช้ `XmlAsString` เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF‑8 ใช้ `XmlData` เมื่อ XML มีอยู่แล้วในรูปแบบอาร์เรย์ไบต์หรือเมื่อการประมวลผลแบบไบนารีสะดวกกว่า ทั้งสองคุณสมบัติตัวแทนเนื้อหา XML ของส่วนเดียวกัน