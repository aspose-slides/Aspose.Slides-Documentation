---
title: จัดการป้ายความอ่อนไหวในงานนำเสนอ PowerPoint ด้วย C++
linktitle: ป้ายความอ่อนไหว
type: docs
weight: 50
url: /th/cpp/sensitivity-labels/
keywords:
- ป้ายความอ่อนไหว
- Microsoft Purview
- การปกป้องข้อมูลของ Microsoft
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การควบคุมเอกสาร
- PowerPoint
- PPTX
- การรักษาความปลอดภัยของงานนำเสนอ
- C++
- Aspose.Slides
description: "อ่าน, เพิ่ม, อัปเดต, ลบ, และโอนย้ายป้ายความอ่อนไหวของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรจำแนกและจัดการเอกสารได้ สำหรับการประมวลผลพรีเซนเทชันอัตโนมัติ แอปพลิเคชันอาจต้องรักษาป้ายที่มีอยู่ไว้ ใช้ป้ายที่เลือกโดยนโยบาย อัปเดตสถานะของป้าย หรือโอนย้ายเมตาดาต้าป้ายที่บันทึกโดยเวิร์กฟลอว์ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides เปิดเผยเมตาดาต้าป้ายความอ่อนไหวสมัยใหม่ผ่าน [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). วิธีนี้จะส่งคืน [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกพรีเซนเทชันเป็น PPTX.

{{% alert color="info" title="หมายเหตุ" %}}

ตัวระบุป้ายความอ่อนไหวและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบการใช้ป้ายและข้อกำหนดของนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือโอนย้ายเมตาดาต้า ค่า [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) บรรยายการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย; ค่าเหล่านี้ไม่ได้สร้างข้อความหรือรูปร่างที่มองเห็นได้บนสไลด์โดยตรง.

{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติของป้ายความอ่อนไหว**

แต่ละ [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/) มีเมตาดาต้าดังต่อไปนี้:

| ตัวเข้าถึง | จุดประสงค์ |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_id/) | ระบุป้ายความอ่อนไหวในนโยบาย Purview |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_siteid/) | ระบุไซต์ที่เชื่อมโยงกับนโยบายป้าย |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | ระบุว่าป้ายถูกเปิดใช้งานหรือไม่ |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | ระบุว่าป้ายถูกลบออกแล้ว ตั้งค่าเป็น `true` เมื่อต้องเก็บสถานะการลบไว้ในเมตาดาต้า |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | ระบุว่าป้ายถูกนำไปใช้แบบอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้ |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | แสดงรายการประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย |

Enumeration [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelassignmenttype/) บรรยายวิธีการมอบป้าย:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelassignmenttype/) แทนค่าป้ายเริ่มต้นหรือป้ายที่ถูกนำไปใช้โดยอัตโนมัติ
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelassignmenttype/) แทนค่าป้ายที่ถูกนำไปใช้ผ่านการตัดสินใจของผู้ใช้ รวมถึงป้ายที่นำไปใช้ด้วยตนเอง แนะนำ และบังคับใช้

Enumeration [SensitivityLabelContentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) ระบุการทำเครื่องหมายที่เชื่อมโยงกับป้าย:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | ป้ายถูกนำมาใช้เป็นค่าเริ่มต้นหรือโดยอัตโนมัติ |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Header เชื่อมโยงกับป้าย |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Footer เชื่อมโยงกับป้าย |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Watermark เชื่อมโยงกับป้าย |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/th/cpp/aspose.slides/sensitivitylabelcontenttype/) | การป้องกันด้วยการเข้ารหัสเชื่อมโยงกับป้าย |

หลายประเภทการทำเครื่องหมายสามารถเชื่อมโยงกับป้ายเดียวได้

## **แสดงรายการป้ายความอ่อนไหวที่มีอยู่**

อ่านคอลเลคชันป้ายสมัยใหม่จาก [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) แล้วทำการวนลูป ตัวอย่างต่อไปนี้แสดงทุกคุณสมบัติและการทำเครื่องหมายเนื้อหาที่จัดเก็บไว้สำหรับแต่ละป้าย:

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

## **เพิ่มป้ายความอ่อนไหวพร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/add/) พร้อมตัวระบุป้าย ตัวระบุไซต์ สถานะเปิดใช้งาน และวิธีการมอบหมาย หลังจากเมธอดคืนค่า [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/) ใหม่ ให้เพิ่มค่าการทำเครื่องหมายที่จำเป็นผ่าน [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/)

ตัวอย่างต่อไปนี้เพิ่มป้ายที่เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมาย Footer และ Watermark แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดตป้ายความอ่อนไหว**

ค่าใน [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/) สามารถอ่าน/เขียนได้ผ่านเมธอด getter และ setter ยกเว้นคอลเลคชันที่คืนจาก [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) จะต้องแก้ไขผ่านการดำเนินการของรายการ หลังจากค้นหาป้ายที่ต้องการ คุณสามารถอัปเดตตัวระบุไซต์ สถานะเปิดใช้งาน วิธีการมอบหมาย สถานะการลบ และประเภทการทำเครื่องหมายเนื้อหา แล้วบันทึกพรีเซนเทชันเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการมอบหมายของป้ายแรก:

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

## **ทำเครื่องหมายป้ายความอ่อนไหวว่าเป็นการลบ**

เพื่อเก็บข้อมูลว่าป้ายถูกลบออก ให้ค้นหาป้ายแล้วเรียก [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isremoved/) ด้วย `true` วิธีนี้จะรักษาเรคคอร์ดป้ายไว้พร้อมบันทึกสถานะการลบ หากต้องการลบรายการจากคอลเลคชันสมัยใหม่ ให้ใช้ [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/removeat/) หรือใช้ [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/clear/) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายเฉพาะเป็นการลบแล้วบันทึกพรีเซนเทชันที่อัปเดต:

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

## **อ่านและโอนย้ายป้ายความอ่อนไหว MIP รุ่นเก่า**

เวิร์กฟลอว์ที่ใช้ MIP รุ่นเก่าสามารถเก็บเมตาดาต้าป้ายความอ่อนไหวในคุณสมบัติเจ้าของเอกสารแบบกำหนดเองแทนคอลเลคชันสมัยใหม่ อ่านเมตาดาต้านั้นด้วย [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). เมธอดจะวิเคราะห์คุณสมบัติกำหนดเองแบบเก่าและคืนอาเรย์ของวัตถุ [ISensitivityLabel](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/)

เพื่อโอนย้ายเมตาดาต้า ให้เพิ่มแต่ละป้ายที่คืนจากเมธอดไปยัง [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/) สมัยใหม่ผ่าน [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/add/). เนื่องจากการเพิ่มป้ายที่มีตัวระบุซ้ำจะทำให้เกิดข้อยกเว้น ตัวอย่างตรวจสอบคอลเลคชันปลายทางก่อนคัดลอปป้ายแต่ละรายการ คุณยังสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าป้ายเก่ายังคงมีอยู่ในนโยบาย Purview ปัจจุบันหรือไม่

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

การโอนย้ายจะคัดลอกวัตถุป้ายที่วิเคราะห์แล้วเข้าสู่คอลเลคชันสมัยใหม่ ไม่จำเป็นต้องลบคุณสมบัติเจ้าของเอกสารทั้งหมด ดังนั้นเมตาดาต้าเอกสารอื่น ๆ จะคงอยู่ ใช้ [IPresentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) พร้อม [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) เพื่อเขียนเมตาดาต้าป้ายสมัยใหม่ลงในไฟล์ PPTX

## **FAQ**

**Adding a content marking type create a visible header, footer, or watermark on slides?**  
No. Values added through [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) describe the markings associated with the sensitivity label. They do not create visible text or shapes in the presentation. Add the corresponding slide content separately if your workflow must render those markings.  
**คำตอบ:** ไม่ ค่าเหล่านี้เพียงบรรยายการทำเครื่องหมายที่เชื่อมโยงกับป้ายความอ่อนไหว ไม่ได้สร้างข้อความหรือรูปร่างที่มองเห็นได้ในพรีเซนเทชัน หากต้องการแสดงเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาในสไลด์แยกต่างหากตามขั้นตอนของคุณ

**What is the difference between marking a label as removed and deleting it from the collection?**  
Calling [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/set_isremoved/) with `true` keeps the label entry and records its removed state. Calling [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/removeat/) deletes the entry from the modern collection. Choose the operation that matches your organization's metadata retention requirements.  
**คำตอบ:** การตั้งค่า `true` ผ่าน `set_IsRemoved` จะเก็บบันทึกป้ายไว้พร้อมบันทึกสถานะการลบ ส่วน `RemoveAt` จะลบรายการออกจากคอลเลคชันสมัยใหม่ เลือกวิธีที่สอดคล้องกับนโยบายการรักษาเมตาดาต้าขององค์กร

**Can a presentation contain both legacy MIP metadata and modern sensitivity labels?**  
Yes. Legacy labels can remain in custom document properties while modern labels are available through [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Use [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) to read the legacy metadata and migrate only the valid labels that are not already present in the modern collection.  
**คำตอบ:** ได้ ป้ายรุ่นเก่าสามารถอยู่ในคุณสมบัติเข้าเอกสารแบบกำหนดเองได้พร้อมกับป้ายสมัยใหม่ที่เข้าถึงผ่าน `IPresentation::get_SensitivityLabels` ใช้ `IDocumentProperties::GetSensitivityLabels` เพื่ออ่านเมตาดาต้าเก่าแล้วโอนย้ายเฉพาะป้ายที่ยังไม่มีในคอลเลคชันสมัยใหม่

**What happens when a label with the same identifier is added more than once?**  
[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabelcollection/add/) throws an argument exception when the collection already contains a label with the same identifier. Check existing [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides/isensitivitylabel/get_id/) values before adding or migrating labels.  
**คำตอบ:** เมธอด `Add` จะขว้างข้อยกเว้นเมื่อคอลเลคชันมีป้ายที่มีตัวระบุเดียวกันอยู่แล้ว ควรตรวจสอบค่าที่ได้จาก `get_Id` ก่อนทำการเพิ่มหรือโอนย้าย

**Which output format should be used to preserve updated sensitivity labels?**  
Save the presentation as PPTX by calling [IPresentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) with [SaveFormat::Pptx](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/), as shown in the examples above.  
**คำตอบ:** ควรบันทึกเป็นรูปแบบ PPTX ด้วยการเรียก `IPresentation::Save` พร้อมพารามิเตอร์ `SaveFormat::Pptx` ตามตัวอย่างที่ให้ไว้.