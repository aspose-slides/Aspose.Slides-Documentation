---
title: 使用 C++ 管理簡報中的投影片區段
linktitle: 投影片區段
type: docs
weight: 100
url: /zh-hant/cpp/slide-section/
keywords:
- 建立區段
- 新增區段
- 編輯區段
- 變更區段
- 區段名稱
- 擷取區段投影片
- 處理區段投影片
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 管理投影片區段：在 PPTX 簡報中建立、重新命名、重新排序、擷取與處理區段投影片。"
---
## **簡介**

Sections 會將連續的投影片組織成具名的群組，且不會更改投影片內容。使用 Aspose.Slides for C++，您可以透過 [Presentation::get_Sections](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_sections/) 方法建立、重新排序、重新命名、檢查與移除節。

Sections 在以下情況特別有用：

- 大型簡報需要分割成邏輯主題或章節；
- 不同的投影片群組指派給不同的協作者；
- 投影片需要以群組方式處理、搬移或合併。

請選擇能說明所組合投影片目的的簡潔節名稱。因為節是簡報結構的一部份，請使用節的 API 來判斷所屬關係，而不要根據投影片位置推算。

## **建立與管理節**

使用 [ISectionCollection::AddSection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectioncollection/addsection/) 依名稱與起始投影片建立節。Aspose.Slides 從簡報目前的節結構判斷哪些投影片屬於該節。

相同的 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectioncollection/) 也允許您：

- 使用 [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) 搬移節與其投影片；
- 只使用 [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectioncollection/removesection/) 移除節定義，保留其投影片；
- 使用 [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectioncollection/removesectionwithslides/) 移除節及其投影片；
- 使用 [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectioncollection/appendemptysection/) 在最後新增空白節。

以下範例建立兩個節、搬移其中一個、將其與投影片一起移除，並在最後新增一個空白節：

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

執行這些操作後，簡報包含帶有投影片的 `Introduction` 節以及空的 `Appendix` 節。`Results` 節及其投影片已被移除。

## **重新命名節**

若要重新命名節，請呼叫 [ISection::set_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/set_name/)。節的投影片與位置保持不變。

以下範例建立一個節並變更其名稱：

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

## **從節中擷取投影片**

[Presentation::get_Sections](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_sections/) 方法會回傳可列舉的 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectioncollection/)。對每個 [ISection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/)，呼叫 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/getslideslistofsection/) 以取得目前屬於該節的投影片。此方法回傳 [ISectionSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectionslidecollection/)，提供計數、索引存取與列舉功能。

以下範例建立兩個已填充的節與一個空白節，然後印出每個節的 [name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/get_name/)、[identifier](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/get_sectionid/)、[starting slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/get_startedfromslide/)、投影片計數與投影片編號。它使用索引存取讀取第一張投影片，並以基於範圍的 `for` 迴圈處理每張投影片。對於空白節，回傳的集合計數為零，未使用索引存取，列舉亦不會執行任何迭代。

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

節的成員關係由簡報的節結構決定。請勿自行從 [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/get_startedfromslide/)、投影片索引以及下一節的起始投影片計算節的範圍。

結構性編輯可能會同時變更某節回傳的投影片與其投影片編號。這包括重新排序投影片、將投影片複製到節、搬移帶有投影片的節、移除投影片與移除節。下一個範例在每次此類變更後呼叫 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/getslideslistofsection/)，而非保留對先前範圍的假設。

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

每當投影片或節被重新排序、複製、搬移或移除時，請再次呼叫 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/getslideslistofsection/)。這可確保後續處理與目前的簡報結構保持一致。

PPT（PowerPoint 97–2003）格式不會保留節的中繼資料。請在支援節的格式（如 PPTX）下使用此工作流程；轉換為 PPT 會移除後續列舉所需的節結構。

## **常見問題**

**將簡報儲存為 PPT（PowerPoint 97–2003）格式時，是否會保留節？**

不會。PPT 格式不支援節的中繼資料，儲存為 .ppt 時會失去節的分組。

**整個節可以被「隱藏」嗎？**

不行。節本身沒有可見性狀態。若要隱藏其內容，需對該節中的每張投影片呼叫 [ISlide::set_Hidden](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/set_hidden/)。

**如何找出包含特定投影片的節？**

列舉 [Presentation::get_Sections](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_sections/)，對每個節呼叫 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/getslideslistofsection/)，並將回傳的投影片與目標投影片比較。對於非空白節，[ISection::get_StartedFromSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isection/get_startedfromslide/) 會回傳其第一張投影片；對於空白節，則回傳 `nullptr`。