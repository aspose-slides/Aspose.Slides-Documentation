---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย C++
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
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++ รวมถึงการเพิ่ม อ่าน อัปเดต ตรวจสอบ และลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลเฉพาะของงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML กำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วนส่วน XML กำหนดเองสามารถเก็บเมทาดาต้าแบบโครงสร้างและข้อมูล XML ที่เฉพาะแอปพลิเคชันได้  

Aspose.Slides มี API สำหรับเพิ่ม อ่าน อัปเดต ตรวจสอบ และลบส่วน XML กำหนดเองในระดับงานนำเสนอ สไลด์ และรูปร่าง ส่วน XML กำหนดเองมีประโยชน์สำหรับการบูรณาการที่จัดเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร สถานะกระบวนการทำงาน เมทาดาต้าการปฏิบัติตาม กำหนดข้อมูลการผูกเทมเพลต หรือข้อมูลแอปพลิเคชันโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีส่วนขยาย `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML. Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้ในการจัดเก็บเนื้อหางานนำเสนอและข้อมูลที่เกี่ยวข้อง  

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะบรรจุเนื้อหาของสไลด์หนึ่งสไลด์และสามารถมีความสัมพันธ์โดยตรงกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500  

ข้อมูลกำหนดเองสามารถจัดเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/itagcollection/)) หรือส่วน XML กำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/)) ทั้งสองอย่างสามารถเข้าถึงได้ผ่านอินเทอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomdata/)

{{% alert color="primary" %}}
แท็กเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วนส่วน XML กำหนดเองเก็บข้อมูล XML แบบโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ สไลด์ หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomdata/get_customxmlparts/) คืนค่าคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุ ตัวอย่างเช่น:

- `presentation->get_CustomData()->get_CustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide->get_CustomData()->get_CustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape->get_CustomData()->get_CustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปร่างเฉพาะ

ใช้ [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_allcustomxmlparts/) เมื่อต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่ามันเชื่อมโยงไว้ที่ไหน

### **เพิ่มส่วน XML กำหนดเองในงานนำเสนอ**

ใช้ [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/add/) เพื่อเพิ่มข้อมูล XML ลงในคอลเลกชันส่วน XML กำหนดเอง XML ต้องเป็นรูปแบบที่ถูกต้องและไม่ว่าง  

ตัวอย่างต่อไปนี้เพิ่มเมทาดาต้าแบบโครงสร้างไปยังคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:
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

// Add กำหนดตัวระบุโดยอัตโนมัติ. ตั้งค่า GUID เฉพาะเมื่อจำเป็นเท่านั้น.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

เมธอด `Add` ยังสามารถรับ XML เป็นอาเรย์ไบต์หรือสตรีม ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่ในรูปแบบไบต์แล้ว

### **เพิ่มส่วน XML กำหนดเองในสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปร่างเฉพาะแทนที่จะเป็นงานนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อเมทาดาต้าอธิบายเพียงอ็อบเจ็กต์เดียว เช่น คีย์เทมเพลต ตัวระบุบันทึกภายนอก หรือข้อมูลการผูก  

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนในสไลด์และอีกส่วนในรูปร่าง:
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

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน `get_CustomData()->get_CustomXmlParts()` ของอ็อบเจ็กต์ใดบรรจุความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะสำหรับเมทาดาต้าทั่วเอกสาร ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์เฉพาะ และข้อมูลระดับรูปร่างสำหรับเมทาดาต้าที่ผูกกับรูปร่างหนึ่ง ๆ

### **แสดงรายการและตรวจสอบส่วน XML กำหนดเองทั้งหมด**

ใช้ [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดจากงานนำเสนอ แต่ละ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/) จะเปิดเผยตัวระบุ เนื้อหา XML และสกีมเนมสเปซที่เชื่อมโยง  

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดเองทั้งหมดและสกีมเนมสเปซของมัน:
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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) คืนค่า XML schemas ที่เชื่อมโยงกับส่วน XML กำหนดเอง ข้อมูลนี้อาจเป็นประโยชน์เมื่อตรวจสอบงานนำเสนอที่มี XML ที่สร้างโดยระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) และ `set_XmlAsString` เพื่อทำงานกับ XML ในรูปแบบสตริง UTF‑8 หรือใช้ [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_xmldata/) และ `set_XmlData` เพื่อทำงานกับไบต์ XML ดิบ ทั้งสองรูปแบบสามารถอ่านและอัปเดตได้  

`[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/get_itemid/)` ส่งกลับค่า GUID ที่ระบุส่วน XML กำหนดเองในเอกสาร Office Open XML ตัวระบุสามารถเปลี่ยนได้ด้วย `set_ItemId` เมื่อการบูรณาการต้องการตัวระบุใหม่  

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

// XmlData ให้เนื้อหา XML เดียวกันในรูปแบบไบต์ดิบ.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// แทนที่ตัวระบุเมื่อการบูรณาการต้องการ.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

เมื่อกำหนดค่า XML ด้วย `set_XmlAsString` หรือ `set_XmlData` ให้ใช้ XML ที่ถูกต้องและไม่ว่างเปล่า เลือกใช้รูปแบบใดรูปแบบหนึ่งตามว่าตัวแอปพลิเคชันทำงานกับสตริงหรือข้อมูลไบต์เป็นหลัก

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides มีวิธีหลายวิธีในการลบข้อมูล XML กำหนดเอง:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpart/remove/) ลบส่วน XML กำหนดเองออกจากงานนำเสนอ
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/remove/) ลบส่วนที่ระบุออกจากคอลเลกชันส่วน XML กำหนดเอง
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/removeat/) ลบส่วนที่ตำแหน่งอินเด็กซ์ที่ระบุในคอลเลกชัน
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/th/cpp/aspose.slides/icustomxmlpartcollection/clear/) ลบทุกส่วนจากคอลเลกชันที่ระบุ  

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

หากคุณมี `ICustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นออกจากงานนำเสนอแทนการอ้างอิงคอลเลกชันเฉพาะ ให้เรียก `customXmlPart->Remove()`  

คุณยังสามารถลบรายการโดยใช้ดัชนีได้:
```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **ลบส่วน XML กำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `Clear` เมื่อจำเป็นต้องลบส่วน XML กำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุ
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

`Clear` มีผลต่อเพียงคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปร่าง  

หากต้องการลบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ ให้วนลูปผ่าน `get_AllCustomXmlParts()` และลบแต่ละส่วน:
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

### **จัดการส่วน XML กำหนดเองที่เชื่อมโยงหรือใช้ร่วมกัน**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเองเดียวกันอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอหลาย ๆ ตัว ตัวอย่างเช่น ไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML กำหนดเองพื้นฐานเดียวกัน  

การใช้ส่วนที่แชร์ควรถือเป็นวัตถุข้อมูลหนึ่งเดียวที่มีหลายการอ้างอิง:

- การอัปเดตด้วย `set_XmlAsString`, `set_XmlData` หรือ `set_ItemId` จะเปลี่ยนส่วน XML กำหนดเองพื้นฐาน ทำให้การเปลี่ยนแปลงส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `get_ItemId()` สามารถใช้ระบุส่วน XML กำหนดเองเดียวกันเมื่อทำการตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `get_CustomXmlParts()` เฉพาะจะลบออกจากคอลเลกชันนั้น ใช้ `ICustomXmlPart::Remove()` เมื่อส่วนเองควรถูกลบออกจากงานนำเสนอ
- ก่อนทำการลบหรือเปลี่ยนส่วนที่ใช้ร่วมกัน ควรตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่ายังมีสไลด์หรือรูปร่างอื่นที่อ้างอิงอยู่หรือไม่  

เมธอด `Add` แบบหลายรูปแบบจะสร้างส่วน XML กำหนดเองใหม่จากเนื้อหา XML; พวกมันไม่รับ `ICustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่ใช้ร่วมกันมักพบเมื่อโหลดงานนำเสนอที่มีส่วนเหล่านั้นอยู่แล้ว  

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ สไลด์ และรูปร่างโดยใช้ `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายตำแหน่ง:
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

การตรวจสอบประเภทนี้มีประโยชน์ก่อนทำการแก้ไขหรือทำลายข้อมูล XML กำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมทาดาต้าเดียวกันอาจมีส่วนร่วมในหลายความสัมพันธ์

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

Aspose.Slides ให้คุณเพิ่มแท็กลงในงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติกำหนดเอง เช่น `MyTag`;
- ค่าของคุณสมบัติกำหนดเอง เช่น `My Tag Value`.

หากคุณต้องการจัดประเภทงานนำเสนอตามกฎหรือคุณสมบัติเฉพาะ สามารถเพิ่มแท็กเพื่อวัตถุประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจัดประเภทงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็กอเมริกาเหนือและกำหนดค่าประเทศที่เกี่ยวข้องเป็นค่าแท็ก  

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

แท็กยังสามารถตั้งค่าสำหรับ [Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/) ได้เช่นกัน:
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

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/) รายบุคคล:
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

แท็กที่เพิ่มผ่านคอลเลกชัน `get_CustomData()->get_Tags()` จะถูกจัดเก็บเฉพาะในไฟล์ PowerPoint เท่านั้น ไม่ได้ถูกโอนย้ายไปยังโครงสร้างแท็กของ PDF เมื่อส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้  

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `shape->set_AlternativeText(u"MyId")`) หลังจากส่งออกเป็น PDF, Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ สไลด์ หรือรูปร่างในหนึ่งการดำเนินการได้หรือไม่?**  
ได้. คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/) รองรับการดำเนินการ [Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/clear/) ซึ่งจะลบคู่คีย์‑ค่าทั้งหมดในครั้งเดียว  

**ฉันจะลบแท็กเดียวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**  
ใช้ [Remove(name)](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/) เพื่อทำการลบแท็กตามคีย์ของมัน  

**ฉันจะดึงรายชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**  
ใช้ [GetNamesOfTags](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/getnamesoftags/) บน [tag collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/tagcollection/); มันจะคืนค่าอาร์เรย์ของชื่อแท็กทั้งหมด  

**ฉันจะค้นหาส่วน XML กำหนดเองทั้งหมดโดยไม่คำนึงว่ามันถูกเก็บไว้ที่ไหนได้อย่างไร?**  
ใช้ [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_allcustomxmlparts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ  

**ฉันควรใช้ `get_XmlAsString`/`set_XmlAsString` หรือ `get_XmlData`/`set_XmlData` เพื่ออัปเดตส่วน XML กำหนดเอง?**  
ใช้ `get_XmlAsString` และ `set_XmlAsString` เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF‑8 ใช้ `get_XmlData` และ `set_XmlData` เมื่อ XML มีอยู่ในรูปแบบอาเรย์ไบต์หรือเมื่อการประมวลผลแบบไบต์สะดวกกว่า ทั้งสองรูปแบบอ้างอิงถึงเนื้อหา XML ของส่วน XML กำหนดเดียวกัน