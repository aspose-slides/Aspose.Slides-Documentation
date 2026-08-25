---
title: 使用 C++ 在演示文稿中管理幻灯片章节
linktitle: 幻灯片章节
type: docs
weight: 100
url: /zh/cpp/slide-section/
keywords:
- 创建章节
- 添加章节
- 编辑章节
- 更改章节
- 章节名称
- 检索章节幻灯片
- 处理章节幻灯片
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 管理幻灯片章节：在 PPTX 演示文稿中创建、重命名、重新排序、检索和处理章节幻灯片。"
---
## **介绍**

章节将连续幻灯片组织成具有名称的组，而不会更改幻灯片内容。使用 Aspose.Slides for C++，您可以通过 [Presentation::get_Sections](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sections/) 方法创建、重新排序、重命名、检查和删除章节。

当以下情况时，章节尤为有用：

- 需要将大型演示文稿划分为逻辑主题或章节；
- 不同的幻灯片组分配给不同的协作者；
- 需要对幻灯片进行分组处理、移动或合并。

请选择简洁的章节名称，以描述分组幻灯片的用途。由于章节是演示文稿结构的一部分，请使用章节 API 来确定所属关系，而不是根据幻灯片位置推断。

## **创建和管理章节**

使用 [ISectionCollection::AddSection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectioncollection/addsection/) 通过指定名称和起始幻灯片来创建章节。Aspose.Slides 根据演示文稿当前的章节结构确定哪些幻灯片属于该章节。

相同的 [ISectionCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectioncollection/) 还可以让您：

- 使用 [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) 将章节及其幻灯片一起移动；
- 使用 [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectioncollection/removesection/) 仅删除章节定义，保留其幻灯片；
- 使用 [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectioncollection/removesectionwithslides/) 删除章节及其幻灯片；
- 使用 [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectioncollection/appendemptysection/) 在末尾添加空章节。

以下示例创建两个章节，移动其中一个，将其连同幻灯片一起删除，并追加一个空章节：

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

这些操作完成后，演示文稿包含带有幻灯片的 `Introduction` 章节和一个空的 `Appendix` 章节。`Results` 章节及其幻灯片已被删除。

## **重命名章节**

要重命名章节，请调用 [ISection::set_Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/set_name/)。章节的幻灯片和位置保持不变。

以下示例创建一个章节并更改其名称：

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

## **从章节检索幻灯片**

[Presentation::get_Sections](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sections/) 方法返回一个可枚举的 [ISectionCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectioncollection/)。对于每个 [ISection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/)，调用 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/getslideslistofsection/) 以获取当前属于该章节的幻灯片。该方法返回一个 [ISectionSlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectionslidecollection/)，提供计数、索引访问和枚举功能。

以下示例创建两个已填充的章节和一个空章节，然后打印每个章节的 [name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/get_name/)、[identifier](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/get_sectionid/)、[starting slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/get_startedfromslide/)、幻灯片计数和幻灯片编号。它使用索引访问读取第一张幻灯片，并使用基于范围的 `for` 循环处理每张幻灯片。对于空章节，返回的集合计数为零，不使用索引访问，枚举不执行任何迭代。

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

章节的所属关系由演示文稿的章节结构决定。不要手动根据 [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/get_startedfromslide/)、幻灯片索引以及下一个章节的起始幻灯片来计算章节范围。

结构性编辑可能会更改章节返回的幻灯片以及它们的幻灯片编号。这包括重新排序幻灯片、将幻灯片克隆到章节、移动章节及其幻灯片、删除幻灯片以及删除章节。下一个示例在每次此类更改后调用 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/getslideslistofsection/)，而不是保留对章节先前边界的假设。

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

每当幻灯片或章节被重新排序、克隆、移动或删除时，请再次调用 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/getslideslistofsection/)。这可确保后续处理与当前演示文稿结构保持一致。

PPT（PowerPoint 97–2003）格式不保留章节元数据。请使用支持章节的格式（例如 PPTX）进行此工作流；转换为 PPT 会移除后续枚举所需的章节结构。

## **常见问题**

**将演示文稿保存为 PPT（PowerPoint 97–2003）格式时，章节会被保留吗？**

不会。PPT 格式不支持章节元数据，因此在保存为 .ppt 时章节分组会丢失。

**可以将整个章节“隐藏”吗？**

不能。章节没有可见性状态。要隐藏其内容，请对章节中的每张幻灯片调用 [ISlide::set_Hidden](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/set_hidden/)。

**如何找到包含某张幻灯片的章节？**

枚举 [Presentation::get_Sections](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sections/)，对每个章节调用 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/getslideslistofsection/)，并将返回的幻灯片与目标幻灯片进行比较。对于非空章节，[ISection::get_StartedFromSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/get_startedfromslide/) 返回其第一张幻灯片；对于空章节，则返回 `nullptr`。