---
title: 高效合并 C++ 中的演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/cpp/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- C++
- Aspose.Slides
description: "了解如何在 C++ 中通过克隆幻灯片、控制母版和布局、调整幻灯片内容大小、保留章节，以及处理受保护或大型文件，来合并 PowerPoint 和 OpenDocument 演示文稿。"
---
## **概述**

Aspose.Slides for C++ 通过从一个[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)克隆幻灯片到另一个来合并演示文稿。主要操作是[ISlideCollection::AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/)，它可以保留源幻灯片的格式，或将克隆的幻灯片附加到目标演示文稿的母版或布局。

本文覆盖最常见的合并工作流：

- 合并所有幻灯片并保留其源格式；
- 合并选定的幻灯片；
- 使用目标演示文稿的母版；
- 使用目标演示文稿的特定布局；
- 在合并前规范不同的幻灯片大小；
- 将克隆的幻灯片添加到章节；
- 在一个端到端的工作流中合并多个演示文稿；
- 处理母版、资源、备注、批注、媒体、字体、密码、大文件和多线程相关问题。

## **幻灯片克隆对母版和布局的影响**

幻灯片的大部分外观继承自其布局和母版。因此，所选择的克隆重载决定了合并的幻灯片如何集成到目标演示文稿中。

以以下方式使用[ISlideCollection::AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/)：

- `AddClone(sourceSlide)` — 保留源幻灯片的布局和格式。必要时，源母版会自动克隆到目标演示文稿中。Aspose.Slides 会跟踪自动克隆的母版，以防重复使用相同源母版的幻灯片时再次克隆该母版。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 将克隆的幻灯片附加到特定的目标[IMasterSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslide/)。Aspose.Slides 会根据布局类型或名称在该母版下查找匹配的布局。
- `AddClone(sourceSlide, destinationLayout)` — 将克隆的幻灯片直接附加到特定的目标[ILayoutSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/)。

传递给 `AddClone` 重载的母版或布局必须属于**目标**演示文稿，而非源演示文稿。

## **合并整个演示文稿并保留源格式**

最简单的合并方式是将源演示文稿的每一张幻灯片复制到目标演示文稿中。当导入的幻灯片应保持其原始主题、母版和布局关系时，这是一种合适的选择。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

当源和目标使用不同设计时，生成的演示文稿可能包含多个母版。这在有意保留源格式时是预期的行为。

## **合并选定的幻灯片**

并不必须克隆每一张幻灯片。以下示例仅从源演示文稿导入选定的幻灯片索引。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

在克隆之前验证幻灯片索引，特别是当它们来自用户输入或外部配置时。

## **使用目标母版合并幻灯片**

当导入的幻灯片应遵循已经属于目标演示文稿的母版时，使用[AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 重载。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides 会通过匹配源布局的类型或名称，在指定的母版下选择合适的布局。如果不存在合适的布局且 `allowCloneMissingLayout` 为 `true`，则会克隆源布局以便添加幻灯片；如果为 `false`，则会抛出[PptxEditException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/details_pptxeditexception/)。

当你希望合并失败而不是向目标母版中引入额外布局时，请使用 `false`。

## **使用特定目标布局合并幻灯片**

当你明确知道导入的幻灯片应使用哪个目标布局时，使用[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 重载。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

应用目标布局会更改继承的布局关系；它不会重新设计源幻灯片的内容。如果源布局和目标布局的占位符结构不同，请检查结果以确认继承的格式和占位符行为是否合适。

## **合并具有不同幻灯片尺寸的演示文稿**

尺寸不同的演示文稿可以合并，但将幻灯片克隆到尺寸不同的演示文稿时，内容不会自动为新的画布重新设计。因此形状可能出现偏移、意外缩放或超出可见幻灯片区域。

一种实用方法是在克隆之前调整源演示文稿的尺寸。[SlideSize::SetSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidesize/setsize/) 方法可以在更改幻灯片尺寸的同时缩放现有内容。[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidesizescaletype/) 会将内容缩放到请求的尺寸范围内。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

重新尺寸会在内存中更改源演示文稿对象。如果你需要保持原始源演示文稿以供其他操作，建议为合并打开一个单独的实例。

## **将幻灯片合并到演示文稿章节**

基本的克隆循环不会重新创建源演示文稿的章节层次结构。如果章节在输出中很重要，需要在目标演示文稿中创建或选择章节，并使用[AddClone(ISlide, ISection)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 将幻灯片显式克隆进去。

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

克隆的幻灯片会追加到指定的目标章节。若要保留多个源章节，可枚举[Presentation::get_Sections](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sections/)，使用[ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isection/getslideslistofsection/) 获取每个源章节的幻灯片列表，在目标中重新创建章节，并将每张返回的幻灯片克隆到对应的目标章节。完整的章节枚举示例请参见[Manage Slide Sections](/slides/zh/cpp/slide-section/)，包括空章节和结构变更。

## **安全地合并多个演示文稿**

下面的端到端示例使用第一个演示文稿作为目标，规范每个额外源的幻灯片尺寸，仅在需要复制时打开源，并在最后一次保存文件。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

这是在保留导入幻灯片源格式的基础上提供的有用基线。如果输出必须使用单一的目标主题，请将简单的 `AddClone(slide)` 调用替换为前面示例中的目标母版或目标布局重载。

## **实际注意事项**

### **母版、布局及格式保真度**

默认的幻灯片克隆可以自动将所需的源母版带入目标演示文稿。Aspose.Slides 为自动克隆的母版维护内部注册表，以避免重复克隆同一母版。手动克隆的母版不受该注册表跟踪，因此除非需要对母版结构进行显式控制，否则避免预先克隆母版。

不要假设名称相同的两个母版或布局在视觉上等价。如果企业模板必须控制最终外观，请显式选择目标母版或布局，并在合并后验证结果。

### **备注和批注**

演讲者备注和幻灯片批注与幻灯片内容关联，克隆幻灯片时会一起复制。Aspose.Slides 还提供专用的 API 用于[演示文稿备注](/slides/zh/cpp/presentation-notes/)和[演示文稿批注](/slides/zh/cpp/presentation-comments/)。

如果备注页的格式很重要，请验证合并后的演示文稿，因为备注母版是演示文稿级别的对象，可能在源文件之间存在差异。对于评审工作流，还需在合并不同作者或模板的文件后验证批注作者和线程批注。

### **图像、音频、视频、OLE 对象和外部链接**

幻灯片可以引用演示文稿级别的资源，如图像、嵌入的音频、嵌入的视频和 OLE 数据。请克隆整个幻灯片而不是仅复制可见形状，以便 Aspose.Slides 能维护幻灯片与其资源的关系。

嵌入的资源和链接的资源应区别对待。链接的音频、视频、OLE 对象或超链接仍依赖于外部目标；克隆幻灯片不会将外部链接转换为嵌入内容。请在最终打开合并演示文稿的环境中测试链接资源的路径和 URL。

Aspose.Slides 明确跟踪自动克隆的母版，但这不应被视为对来自不同源演示文稿的相同二进制资源始终去重的通用保证。如果输出文件大小重要，请检查合并后的包并测量结果，而不是依赖隐式去重。

### **嵌入字体和字体可用性**

字体在演示文稿级别管理。如果排版必须在不同机器上保持一致，不要假设仅克隆幻灯片就能保证所有必需字体在目标环境中可用。可以使用[FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/getembeddedfonts/) 检查嵌入的字体，并按照[在演示文稿中嵌入字体](/slides/zh/cpp/embedded-font/) 中的说明显式管理嵌入。

同时请确认你有权嵌入源文件使用的字体。字体许可证可能限制嵌入。

### **受密码保护的演示文稿**

在克隆幻灯片之前，必须成功打开受密码保护的源文件。通过[LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/) 提供密码。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

打开加密的源文件并不会自动将相同的保护应用到目标演示文稿。需要时请单独配置输出的保护。

### **大演示文稿和内存使用**

包含高分辨率图像、音频、视频或其他大型二进制对象的大演示文稿可能消耗大量内存。[LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) 提供对 BLOB 处理和临时文件使用的控制。请参阅[管理演示文稿 BLOB](/slides/zh/cpp/manage-blob/) 了解大文件策略。

对于大文件，尽可能使用文件路径加载，合并完成后立即释放每个源演示文稿，并避免频繁保存中间结果，除非工作流需要检查点。

### **线程安全**

不要在多个线程中并发加载、修改、保存或克隆同一个[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例。每个演示文稿实例应仅用于一次合并操作。如果并行处理独立任务，请使用独立的演示文稿实例并遵循[Aspose.Slides 多线程指南](/slides/zh/cpp/multithreading/)。

## **常见问题解答**

**如何保留每个源演示文稿的原始设计？**

使用不提供目标母版或布局的[AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/)。当导入的幻灯片需要母版时，Aspose.Slides 会自动克隆源母版。

**如何使导入的幻灯片使用目标主题？**

使用接受目标母版的重载。传入目标演示文稿中的母版，而不是源演示文稿的母版。Aspose.Slides 将尝试为每个源幻灯片映射到该母版下的合适布局。

**何时应使用特定的目标布局而不是目标母版？**

当每个导入的幻灯片都应使用同一已知布局时使用特定布局；当希望 Aspose.Slides 根据源布局的类型或名称在该母版的布局中进行选择时使用母版。

**不同幻灯片尺寸的演示文稿可以合并吗？**

可以，但幻灯片内容不会自动为目标尺寸重新设计。需要确定位置时，请先使用[SlideSize::SetSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidesize/setsize/) 和[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidesizescaletype/) 调整源演示文稿的尺寸。

**我可以将 PPT、PPTX 和 ODP 演示文稿合并为一个文件吗？**

可以。加载每个源演示文稿，将所需幻灯片克隆到同一目标中，并以受支持的输出格式保存。由于演示文稿格式的功能集不完全相同，跨格式合并后请验证复杂内容。参见[受支持的文件格式](/slides/zh/cpp/supported-file-formats/)。

**源章节会自动保留吗？**

基本的仅克隆幻灯片的循环不会。需要时请在目标中重新创建章节，并在需要保留章节结构时使用[AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 的章节重载。

**演讲者备注和批注会被保留吗？**

它们会随克隆的幻灯片一起复制。对于依赖备注母版样式、批注作者或线程审阅数据的工作流，请在合并后验证结果，因为这些场景涉及演示文稿级别结构以及幻灯片级别内容。

**音频、视频、OLE 对象和超链接会怎样处理？**

嵌入的内容会作为克隆幻灯片资源关系的一部分被携带。外部链接仍保持外部状态，合并后仍需确保其目标文件或 URL 可用。

**所有源的嵌入字体都保证在合并后可用吗？**

不要仅依赖幻灯片克隆来部署字体。请检查目标的嵌入字体，并在排版重要时显式管理字体嵌入或外部字体可用性。

**如何合并受密码保护的文件？**

使用正确的[LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/) 打开，然后正常克隆其幻灯片。输出的保护需另行配置。

**该如何处理非常大的演示文稿？**

当大型二进制对象主导内存使用时，请使用 BLOB 管理，尽量使用文件路径加载极大文件，及时释放源演示文稿，并仅在必要时保存最终结果。

**我可以从多个线程合并幻灯片吗？**

不要在多个线程中并发使用同一个[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例。每个合并操作应使用独立的演示文稿实例。