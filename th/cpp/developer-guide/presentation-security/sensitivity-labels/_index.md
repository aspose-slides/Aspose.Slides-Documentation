---
title: จัดการป้ายกำกับระดับความละเอียดอ่อนในงานนำเสนอ PowerPoint ด้วย C++
linktitle: ป้ายกำกับระดับความละเอียดอ่อน
type: docs
weight: 50
url: /th/cpp/sensitivity-labels/
keywords:
- ป้ายกำกับระดับความละเอียดอ่อน
- Microsoft Purview
- Microsoft Information Protection
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- C++
- Aspose.Slides
description: "อ่าน, เพิ่ม, อัปเดต, ลบ, และย้ายป้ายกำกับระดับความละเอียดอ่อนของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรสามารถจัดประเภทและจัดการเอกสารได้ ในระหว่างการประมวลผลงานนำเสนอแบบอัตโนมัติ แอปพลิเคชันอาจต้องรักษาป้ายกำกับที่มีอยู่ไว้, ใช้ป้ายกำกับที่นโยบายเลือก, ปรับปรุงสถานะของมัน, หรือย้ายข้อมูลเมตาป้ายกำกับที่เขียนโดยเวิร์กโฟลว์ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides เปิดเผยเมตาดาต้าป้ายกำกับระดับความละเอียดอ่อนสมัยใหม่ผ่าน [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). วิธีนี้จะคืนค่า [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/) ซึ่งสามารถตรวจสอบและแก้ไขก่อนบันทึกงานนำเสนอเป็น PPTX

{{% alert color="primary" title="Note" %}}
ตัวระบุป้ายกำกับระดับความละเอียดอ่อนและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมของป้ายกำกับและข้อกำหนดของนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือย้ายเมตาดาต้า ค่าของ [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) อธิบายการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้ายกำกับ; ค่าดังกล่าวไม่ได้สร้างข้อความหรือรูปทรงที่มองเห็นได้บนสไลด์ด้วยตนเอง
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติของป้ายกำกับระดับความละเอียดอ่อน**

แต่ละ [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/) มีเมตาดาต้าต่อไปนี้:

| ตัวเข้าถึง | วัตถุประสงค์ |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_id/) | ระบุป้ายกำกับระดับความละเอียดอ่อนในนโยบาย Purview |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_siteid/) | ระบุไซต์ที่เชื่อมโยงกับนโยบายป้ายกำกับ |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | แสดงว่าป้ายกำกับเปิดใช้งานหรือไม่ |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | แสดงว่าป้ายกำกับถูกลบออกแล้ว ตั้งค่าเป็น `true` เมื่อต้องเก็บสถานะการลบไว้ในเมตาดาต้า |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | ระบุว่าป้ายกำกับถูกนำไปใช้โดยอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้ |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | แสดงรายการประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้ายกำกับ |

enum [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelassignmenttype/) อธิบายวิธีการมอบหมายป้ายกำกับ:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายกำกับเริ่มต้นหรือที่ถูกนำไปใช้โดยอัตโนมัติ
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายกำกับที่นำไปใช้ผ่านการตัดสินใจของผู้ใช้ รวมถึงป้ายกำกับที่ทำด้วยตนเอง, แนะนำ, และบังคับใช้

enum [SensitivityLabelContentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) ระบุการทำเครื่องหมายที่เชื่อมโยงกับป้ายกำกับ:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | ป้ายกำกับถูกนำไปใช้โดยค่าเริ่มต้นหรืออัตโนมัติ |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาหัวเรื่องเชื่อมโยงกับป้ายกำกับ |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาท้ายกระดาษเชื่อมโยงกับป้ายกำกับ |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาลายน้ำเชื่อมโยงกับป้ายกำกับ |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การปกป้องด้วยการเข้ารหัสเชื่อมโยงกับป้ายกำกับ |

หลายประเภทของการทำเครื่องหมายสามารถเชื่อมโยงกับป้ายกำกับเดียวได้

## **แสดงรายการป้ายกำกับระดับความละเอียดอ่อนที่มีอยู่**

อ่านคอลเลกชันป้ายกำกับสมัยใหม่จาก [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) แล้ววนลูป ตัวอย่างต่อไปนี้แสดงทุกคุณสมบัติและการทำเครื่องหมายเนื้อหาที่จัดเก็บไว้สำหรับแต่ละป้ายกำกับ:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **เพิ่มป้ายกำกับระดับความละเอียดอ่อนพร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/add/) โดยระบุตัวระบุป้ายกำกับ, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการมอบหมาย หลังจากเมธอดคืนค่า [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/) ใหม่ ให้เพิ่มค่าการทำเครื่องหมายที่จำเป็นผ่าน [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/)

ตัวอย่างต่อไปนี้เพิ่มป้ายกำกับที่ผู้ใช้เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมายท้ายกระดาษและลายน้ำ แล้วบันทึกผลลัพธ์เป็น PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **อัปเดตป้ายกำกับระดับความละเอียดอ่อน**

ค่าของ [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/) สามารถอ่าน/เขียนได้ผ่านเมธอด getter และ setter ยกเว้นคอลเลกชันที่คืนค่าจาก [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) จะถูกแก้ไขผ่านการดำเนินการรายการ หลังจากค้นหาป้ายกำกับที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการมอบหมาย, สถานะการลบ, และประเภทการทำเครื่องหมายเนื้อหา แล้วบันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการมอบหมายของป้ายกำกับแรก:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ทำเครื่องหมายป้ายกำกับระดับความละเอียดอ่อนว่าได้ถูกลบ**

เพื่อรักษาข้อเท็จจริงว่าป้ายกำกับถูกลบ ให้ค้นหาป้ายกำกับนั้นและเรียก [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isremoved/) ด้วยค่า `true` วิธีนี้ทำให้บันทึกข้อมูลป้ายกำกับไว้พร้อมบันทึกสถานะการลบ หากต้องการลบรายการออกจากคอลเลกชันสมัยใหม่ ให้ใช้ [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/removeat/) หรือใช้ [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/clear/) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายกำกับเฉพาะเป็นการลบแล้วบันทึกงานนำเสนอที่อัปเดต:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **อ่านและย้ายป้ายกำกับระดับความละเอียดอ่อนแบบ Legacy ของ MIP**

เวิร์กโฟลว์ที่อาศัย MIP รุ่นเก่าสามารถเก็บเมตาดาต้าป้ายกำกับในคุณสมบัติเอกสารแบบกำหนดเองแทนคอลเลกชันสมัยใหม่ อ่านเมตาดาต้านั้นด้วย [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) เมธอดจะวิเคราะห์คุณสมบัติแบบกำหนดเองแบบ Legacy แล้วคืนอาเรย์ของออบเจ็กต์ [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/)

เพื่อย้ายเมตาดาต้า ให้เพิ่มแต่ละป้ายกำกับที่ได้รับกลับไปยัง [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/) สมัยใหม่ผ่าน [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/add/) เนื่องจากการเพิ่มป้ายกำกับที่มีตัวระบุซ้ำจะทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันเป้าหมายก่อนคัดลอกแต่ละป้ายกำกับ คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าป้ายกำกับ Legacy แต่ละรายการยังคงมีอยู่ในนโยบาย Purview ปัจจุบัน

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การย้ายจะคัดลอกออบเจ็กต์ป้ายกำกับที่วิเคราะห์แล้วไปยังคอลเลกชันสมัยใหม่ ไม่จำเป็นต้องล้างคุณสมบัติเอกสารแบบกำหนดเองทั้งหมด ดังนั้นเมตาดาต้าอื่นของเอกสารจะคงอยู่ ใช้ [IPresentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) พร้อม [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) เพื่อเขียนเมตาดาต้าป้ายกำกับสมัยใหม่ลงในไฟล์ PPTX

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหา ทำให้หัวเรื่อง, ท้ายกระดาษ หรือ ลายน้ำ ปรากฏบนสไลด์หรือไม่?**

ไม่ ค่าที่เพิ่มผ่าน [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) อธิบายการทำเครื่องหมายที่เชื่อมโยงกับป้ายกำกับ ระดับความละเอียดอ่อน ไม่ได้สร้างข้อความหรือรูปทรงที่มองเห็นได้ในงานนำเสนอ หากกระบวนการของคุณต้องการแสดงการทำเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาในสไลด์แยกต่างหาก

**ความแตกต่างระหว่างการทำเครื่องหมายป้ายกำกับว่าได้ถูกลบและการลบออกจากคอลเลกชันคืออะไร?**

การเรียก [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isremoved/) ด้วยค่า `true` จะทำให้บันทึกข้อมูลป้ายกำกับไว้และบันทึกสถานะการลบ ส่วนการเรียก [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/removeat/) จะลบรายการนั้นออกจากคอลเลกชันสมัยใหม่โดยสมบูรณ์ เลือกวิธีการที่สอดคล้องกับข้อกำหนดการเก็บรักษาเมตาดาต้าขององค์กรคุณ

**งานนำเสนอสามารถมีเมตาดาต้า MIP แบบ Legacy และป้ายกำกับระดับความละเอียดอ่อนสมัยใหม่พร้อมกันได้หรือไม่?**

ได้ ป้ายกำกับ Legacy สามารถคงอยู่ในคุณสมบัติเอกสารแบบกำหนดเอง ในขณะที่ป้ายกำกับสมัยใหม่สามารถเข้าถึงได้ผ่าน [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) ใช้ [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) เพื่ออ่านเมตาดาต้า Legacy และย้ายเฉพาะป้ายกำกับที่ยังไม่มีในคอลเลกชันสมัยใหม่

**จะเกิดอะไรขึ้นเมื่อเพิ่มป้ายกำกับที่มีตัวระบุเดียวกันหลายครั้ง?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/add/) จะโยนข้อยกเว้นเมื่อคอลเลกชันมีป้ายกำกับที่มีตัวระบุเดียวกันอยู่แล้ว ควรตรวจสอบค่า [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_id/) ก่อนทำการเพิ่มหรือย้ายป้ายกำกับ

**ควรใช้รูปแบบไฟล์ใดเพื่อรักษาป้ายกำกับระดับความละเอียดอ่อนที่อัปเดต?**

บันทึกงานนำเสนอเป็น PPTX โดยเรียก [IPresentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) พร้อม [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) ตามที่แสดงในตัวอย่างด้านบน