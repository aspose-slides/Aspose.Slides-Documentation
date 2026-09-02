---
title: "จัดการส่วนสไลด์ในงานนำเสนอด้วย C++"
linktitle: "ส่วนสไลด์"
type: docs
weight: 100
url: /th/cpp/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ของส่วน
- ประมวลผลสไลด์ของส่วน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides สำหรับ C++: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่, ดึง, และประมวลผลสไลด์ของส่วนในงานนำเสนอ PPTX."
---
## **บทนำ**

Sections จัดสไลด์ต่อเนื่องให้เป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนแปลงเนื้อหาของสไลด์. ด้วย Aspose.Slides for C++ คุณสามารถสร้าง, จัดลำดับใหม่, เปลี่ยนชื่อ, ตรวจสอบ และลบส่วนผ่านเมธอด [Presentation::get_Sections](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sections/)  

Sections มีประโยชน์เป็นพิเศษเมื่อ:

- การนำเสนอขนาดใหญ่ต้องแบ่งเป็นหัวข้อหรือบทที่มีความสัมพันธ์กัน;
- กลุ่มสไลด์ต่าง ๆ ถูกมอบหมายให้กับผู้ร่วมงานคนต่างกัน;
- ต้องการประมวลผล, ย้าย หรือรวมสไลด์เป็นกลุ่ม.

เลือกชื่อตัวส่วนที่กระชับและอธิบายวัตถุประสงค์ของสไลด์ที่จัดเป็นกลุ่มกัน. เนื่องจากส่วนเป็นส่วนหนึ่งของโครงสร้างการนำเสนอ, ให้ใช้ API ส่วนเพื่อกำหนดสมาชิกแทนการสรุปจากตำแหน่งสไลด์.

## **สร้างและจัดการส่วน**

ใช้ [ISectionCollection::AddSection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectioncollection/addsection/) เพื่อสร้างส่วนโดยระบุชื่อและสไลด์เริ่มต้น. Aspose.Slides กำหนดสไลด์ที่เป็นของส่วนจากโครงสร้างส่วนปัจจุบันของการนำเสนอ.

[ISectionCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectioncollection/) เดียวกันยังทำให้คุณได้:

- ย้ายส่วนพร้อมกับสไลด์ของมันโดยใช้ [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- ลบเฉพาะคำนิยามส่วนด้วย [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectioncollection/removesection/), ซึ่งจะคงสไลด์ไว้;
- ลบส่วนและสไลด์ของมันด้วย [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- เพิ่มส่วนว่างที่ส่วนท้ายด้วย [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectioncollection/appendemptysection/).

ตัวอย่างต่อไปนี้สร้างสองส่วน, ย้ายหนึ่งส่วน, ลบส่วนนั้นพร้อมกับสไลด์ของมัน, และเพิ่มส่วนว่างที่ส่วนท้าย:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

หลังจากการดำเนินการเหล่านี้ การนำเสนอจะมีส่วน `Introduction` พร้อมสไลด์ของมันและส่วน `Appendix` ว่าง. ส่วน `Results` และสไลด์ของมันถูกลบออกไป.

## **เปลี่ยนชื่อส่วน**

เพื่อเปลี่ยนชื่อส่วน, เรียก [ISection::set_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/set_name/). สไลด์และตำแหน่งของส่วนจะคงเดิม.

ตัวอย่างต่อไปนี้สร้างส่วนและเปลี่ยนชื่อของมัน:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **ดึงสไลด์จากส่วน**

เมธอด [Presentation::get_Sections](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sections/) คืนค่าชุด [ISectionCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectioncollection/) ที่คุณสามารถวนลูปได้. สำหรับแต่ละ [ISection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/), เรียก [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/getslideslistofsection/) เพื่อรับสไลด์ที่ปัจจุบันเป็นของส่วนนั้น. เมธอดนี้คืนค่า [ISectionSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectionslidecollection/), ซึ่งมีการนับจำนวน, การเข้าถึงแบบดัชนี, และการวนลูป.

ตัวอย่างต่อไปนี้สร้างสองส่วนที่เต็มด้วยสไลด์และหนึ่งส่วนว่าง, แล้วพิมพ์ [name](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/get_name/), [identifier](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/get_sectionid/), [starting slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/get_startedfromslide/), จำนวนสไลด์, และหมายเลขสไลด์ของแต่ละส่วน. ตัวอย่างใช้การเข้าถึงแบบดัชนีเพื่ออ่านสไลด์แรกและลูป `for` แบบ range‑based เพื่อประมวลผลทุกสไลด์. สำหรับส่วนว่าง, คอลเลกชันที่คืนค่ามีจำนวนเป็นศูนย์, ไม่ได้ใช้การเข้าถึงแบบดัชนี, และการวนลูปจะไม่มีการทำซ้ำ.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

การเป็นสมาชิกของส่วนกำหนดโดยโครงสร้างส่วนของการนำเสนอ. อย่าคำนวณช่วงของส่วนด้วยตนเองจาก [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/get_startedfromslide/), ดัชนีสไลด์, และสไลด์เริ่มต้นของส่วนถัดไป.

การแก้ไขเชิงโครงสร้างสามารถเปลี่ยนทั้งสไลด์ที่คืนค่ามาสำหรับส่วนและหมายเลขสไลด์ของมัน. สิ่งนี้รวมถึงการจัดลำดับสไลด์ใหม่, การคล cloning สไลด์เข้าไปในส่วน, การย้ายส่วนพร้อมสไลด์, การลบสไลด์, และการลบส่วน. ตัวอย่างถัดไปเรียก [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/getslideslistofsection/) หลังจากการเปลี่ยนแปลงทุกอย่างแทนการถือสมมติฐานเกี่ยวกับขอบเขตเดิมของส่วน.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

เรียก [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/getslideslistofsection/) อีกครั้งเมื่อใดก็ตามที่สไลด์หรือส่วนถูกจัดลำดับใหม่, คัดลอก, ย้าย, หรือถูกลบ. การทำเช่นนี้ช่วยให้การประมวลผลต่อมาสอดคล้องกับโครงสร้างการนำเสนอปัจจุบัน.

รูปแบบ PPT (PowerPoint 97–2003) ไม่คง metadata ของส่วน. ใช้กระบวนการนี้กับรูปแบบที่สนับสนุนส่วน, เช่น PPTX; การแปลงเป็น PPT จะลบโครงสร้างส่วนที่จำเป็นสำหรับการวนลูปต่อไป.

## **คำถามที่พบบ่อย**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**  

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**  

No. A section has no visibility state. To hide its contents, call [ISlide::set_Hidden](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/set_hidden/) for each slide in the section.

**How can I find the section that contains a slide?**  

Enumerate [Presentation::get_Sections](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sections/), call [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/getslideslistofsection/) for each section, and compare the returned slides with the target slide. For a non‑empty section, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/get_startedfromslide/) returns its first slide; for an empty section, it returns `nullptr`.