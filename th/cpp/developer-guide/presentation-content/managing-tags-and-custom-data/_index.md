---
title: การจัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย C++
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/cpp/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- XML กำหนดเอง
- ส่วน XML กำหนดเอง
- เมทาดาต้า XML
- ItemId
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++ รวมถึงการเพิ่ม, การอ่าน, การอัปเดต, การตรวจสอบและการลบส่วน XML กำหนดเอง"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลเฉพาะของงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML กำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงธรรมดา ในขณะที่ส่วน XML กำหนดเองสามารถเก็บเมทาดาต้าแบบโครงสร้างและ payload XML เฉพาะแอปพลิเคชันได้

Aspose.Slides ให้ API สำหรับการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบและลบส่วน XML กำหนดเองในระดับงานนำเสนอ, สไลด์และรูปร่าง ส่วน XML กำหนดเองมีประโยชน์สำหรับการรวมที่ต้องจัดเก็บข้อมูลเช่น รหัสระบุตัวเอกสาร, สถานะ workflow, เมทาดาต้า compliance, ข้อมูลผูกเทมเพลต หรือข้อมูลแอปพลิเคชันแบบโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้เก็บเนื้อหาและข้อมูลที่เกี่ยวข้องของงานนำเสนอ

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะมีเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์ที่ชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเองสามารถจัดเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/itagcollection/)) หรือส่วน XML กำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/)) ทั้งสองแบบสามารถเข้าถึงได้ผ่านอินเทอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomdata/)

{{% alert color="info" %}}
แท็กเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วน XML กำหนดเองเก็บข้อมูล XML แบบโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์ หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

เมธอด [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomdata/get_customxmlparts/) จะคืนคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุ ตัวอย่าง:

- `presentation->get_CustomData()->get_CustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide->get_CustomData()->get_CustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape->get_CustomData()->get_CustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปร่างเฉพาะ

ใช้เมธอด [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_allcustomxmlparts/) เมื่อคุณต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่ามันเชื่อมโยงกับที่ใด

### **เพิ่มส่วน XML กำหนดเองลงในงานนำเสนอ**

ใช้เมธอด [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/add/) เพื่อเพิ่มข้อมูล XML ลงในคอลเลกชันส่วน XML กำหนดเอง XML ต้องเป็นข้อมูลที่ถูกต้องและไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมทาดาต้าแบบโครงสร้างลงในคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add กำหนดตัวระบุโดยอัตโนมัติ ตั้งค่า GUID เฉพาะเมื่อจำเป็น
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

เมธอด `Add` ยังรับ XML เป็นอาร์เรย์ไบต์หรือสตรีมได้ ซึ่งเป็นประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบนารี

### **เพิ่มส่วน XML กำหนดเองลงในสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปร่างเฉพาะแทนที่จะเป็นทั้งงานนำเสนอ ซึ่งเป็นประโยชน์เมื่อเมทาดาต้าอธิบายเพียงอ็อบเจ็กต์เดียว เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก, หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนลงในสไลด์และอีกส่วนหนึ่งลงในรูปร่าง:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าอ็อบเจ็กต์ใดที่มีคอลเลกชัน `get_CustomData()->get_CustomXmlParts()` มีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเหมาะกับเมทาดาต้าทั่วทั้งเอกสาร, ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์นั้น, และข้อมูลระดับรูปร่างสำหรับเมทาดาต้าที่ผูกกับรูปร่างแต่ละอัน

### **รายชื่อและตรวจสอบส่วน XML กำหนดเองทั้งหมด**

ใช้เมธอด [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดจากงานนำเสนอ แต่ละ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/) จะเปิดเผยตัวระบุ, เนื้อหา XML, และสคีมเนมสเปซที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดเองทั้งหมดพร้อมสคีมเนมสเปซ:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

เมธอด [`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) จะคืนสคีม XML ที่เชื่อมโยงกับส่วน XML กำหนดเอง ข้อมูลนี้เป็นประโยชน์เมื่อตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้เมธอด [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) และ `set_XmlAsString` เพื่อทำงานกับ XML เป็นสตริง UTF‑8 หรือใช้เมธอด [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_xmldata/) และ `set_XmlData` เพื่อทำงานกับไบต์ XML ดิบ ทั้งสองรูปแบบสามารถอ่านและอัปเดตได้

เมธอด [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_itemid/) จะคืนค่า GUID ที่ระบุส่วน XML กำหนดเองในเอกสาร Office Open XML ตัวระบุนี้ยังสามารถเปลี่ยนได้ด้วย `set_ItemId` เมื่อการรวมต้องการตัวระบุใหม่

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// อ่าน XML ปัจจุบันเป็นข้อความ.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// อัปเดต XML เป็นสตริง UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData ให้เนื้อหา XML เดียวกันเป็นไบต์ดิบ.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// เปลี่ยนตัวระบุเมื่อการรวมต้องการ.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

เมื่อกำหนดค่า XML ด้วย `set_XmlAsString` หรือ `set_XmlData` ให้ใช้ XML ที่ถูกต้องและไม่ว่างเปล่า เลือกรูปแบบใดรูปแบบหนึ่งตามที่แอปพลิเคชันทำงานกับสตริงหรือไบต์เป็นหลัก

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides มีวิธีหลายวิธีในการลบข้อมูล XML กำหนดเอง:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/remove/) ลบส่วน XML กำหนดเองจากงานนำเสนอ
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/remove/) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML กำหนดเอง
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/removeat/) ลบส่วนที่ตำแหน่งดัชนีที่กำหนดในคอลเลกชัน
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/clear/) ลบส่วนทั้งหมดจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML กำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

หากคุณมีอ็อบเจ็กต์ `ICustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากงานนำเสนอแทนการอ้างอิงคอลเลกชัน ให้เรียก `customXmlPart->Remove()`  

คุณยังสามารถลบรายการโดยดัชนีได้:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **ล้างส่วน XML กำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `Clear` เมื่อส่วน XML กำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอใด ๆ ต้องการถูกลบ

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` มีผลกับคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปร่าง

หากต้องการลบส่วน XML กำหนดเองทุกส่วนในงานนำเสนอ ให้วนรอบ `get_AllCustomXmlParts()` แล้วลบแต่ละส่วน:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **จัดการส่วน XML กำหนดเองที่ลิงก์หรือแชร์กัน**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเองเดียวกันอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอหลายแห่ง ตัวอย่างเช่น ไฟล์ที่มีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML กำหนดเองเดียวกัน

ส่วนที่แชร์ควรถือเป็นอ็อบเจ็กต์ข้อมูลหนึ่งเดียวที่มีหลายการอ้างอิง:

- การอัปเดตด้วย `set_XmlAsString`, `set_XmlData` หรือ `set_ItemId` จะเปลี่ยนส่วน XML กำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `get_ItemId()` สามารถใช้เพื่อระบุส่วน XML กำหนดเองเดียวกันขณะตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `get_CustomXmlParts()` เฉพาะจะลบส่วนออกจากคอลเลกชันนั้น ใช้ `ICustomXmlPart::Remove()` เมื่อส่วนนั้นเองต้องการถูกลบจากงานนำเสนอทั้งหมด
- ก่อนลบหรือเปลี่ยนส่วนที่แชร์ ให้ตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่าสไลด์หรือรูปร่างอื่นยังอ้างอิงส่วนนั้นอยู่หรือไม่

โอเวรโหลด `Add` สร้างส่วน XML กำหนดเองใหม่จากเนื้อหา XML; ไม่รับ `ICustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่แชร์มักพบเมื่อต้องโหลดงานนำเสนอที่มีส่วนเหล่านี้อยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์และรูปร่างโดย `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายที่:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

การตรวจสอบแบบนี้มีประโยชน์ก่อนที่จะปรับเปลี่ยนหรือ删除ข้อมูล XML กำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมทาดาต้าเดียวกันอาจมีส่วนร่วมในหลายความสัมพันธ์

## **ดึงค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับคุณสมบัติ `IDocumentProperties::get_Keywords` ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for C++ สำหรับ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **เพิ่มแท็กลงในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กลงในงานนำเสนอ แท็กทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติกำหนดเอง เช่น `MyTag`
- ค่าของคุณสมบัติกำหนดเอง เช่น `My Tag Value`

หากต้องการจัดประเภทงานนำเสนอตามกฎหรือคุณสมบัติใด ๆ คุณสามารถเพิ่มแท็กเพื่อวัตถุประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจำแนกงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็ก “NorthAmerican” แล้วกำหนดค่าของประเทศที่เกี่ยวข้องให้เป็นค่าแท็ก

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กลงใน [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ด้วย Aspose.Slides for C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

สามารถตั้งค่าแท็กสำหรับ [Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/) ได้เช่นกัน:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/) ส่วนบุคคล:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `get_CustomData()->get_Tags()` จะถูกเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น ซึ่ง **ไม่** ถูกโอนย้ายไปยังโครงสร้างแท็กของ PDF เมื่อส่งออกงานนำเสนอเป็น PDF ดังนั้น ตัวระบุกำหนดเองที่ตั้งเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองไว้ใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `shape->set_AlternativeText(u"MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **FAQ**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในหนึ่งขั้นตอนได้หรือไม่?**

ได้ คอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/)) รองรับการทำงาน `Clear` ([Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/clear/)) ที่ลบคู่คีย์‑ค่าทั้งหมดในครั้งเดียว

**ฉันจะลบแท็กเดี่ยวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้ `Remove(name)` บน [TagCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/) เพื่อ删除แท็กตามคีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดเพื่อทำการวิเคราะห์หรือกรองได้อย่างไร?**

ใช้ `GetNamesOfTags` บนคอลเลกชันแท็ก; มันจะคืนอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML กำหนดเองทั้งหมดไม่ว่าเก็บที่ไหน?**

ใช้ [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ

**ฉันควรใช้ `get_XmlAsString`/`set_XmlAsString` หรือ `get_XmlData`/`set_XmlData` เพื่ออัปเดตส่วน XML กำหนดเอง?**

เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF‑8 ให้ใช้ `get_XmlAsString` และ `set_XmlAsString` หาก XML มีอยู่แล้วในรูปแบบอาร์เรย์ไบต์หรือการประมวลผลแบบไบนารีเป็นหลัก ให้ใช้ `get_XmlData` และ `set_XmlData` ทั้งสองรูปแบบอ้างอิงถึงเนื้อหา XML ของส่วน XML กำหนดเองเดียวกัน