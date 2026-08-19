---
title: 高效地在 .NET 中合并演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/net/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 组合 PowerPoint
- 组合 演示文稿
- 组合 幻灯片
- 组合 PPT
- 组合 PPTX
- 组合 ODP
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中通过克隆幻灯片、控制母版和布局、调整幻灯片内容大小、保留章节以及处理受保护或大型文件，来合并 PowerPoint 和 OpenDocument 演示文稿。"
---
## **概述**

Aspose.Slides for .NET 通过克隆幻灯片将一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 的演示文稿合并到另一个中。主要操作是 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/)，它可以保留源幻灯片的格式，或将克隆的幻灯片附加到目标演示文稿的母版或布局。

本文介绍了最常见的合并工作流：

- 合并所有幻灯片并保留其源格式；
- 合并选定的幻灯片；
- 使用目标演示文稿的母版；
- 使用目标演示文稿的特定布局；
- 在合并前统一不同的幻灯片尺寸；
- 将克隆的幻灯片添加到章节；
- 在一个端到端工作流中合并多个演示文稿；
- 处理母版、资源、备注、评论、媒体、字体、密码、大文件和多线程相关问题。

## **幻灯片克隆对母版和布局的影响**

幻灯片的外观在很大程度上继承自其布局和母版。因此，您选择的克隆重载决定了合并后的幻灯片如何嵌入目标演示文稿。

可通过以下方式使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/)：

- `AddClone(sourceSlide)` — 保留源幻灯片的布局和格式。如有需要，源母版会自动克隆到目标演示文稿中。Aspose.Slides 会跟踪自动克隆的母版，以防使用相同源母版的重复幻灯片导致母版被多次克隆。
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 将克隆的幻灯片附加到特定的目标 [IMasterSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/)。Aspose.Slides 会根据布局类型或名称在该母版下查找匹配的布局。
- `AddClone(sourceSlide, destinationLayout)` — 将克隆的幻灯片直接附加到特定的目标 [ILayoutSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/)。

传递给 `AddClone` 重载的母版或布局必须属于 **目标** 演示文稿，而不是源演示文稿。

## **合并整个演示文稿并保留源格式**

最简单的合并方式是将源演示文稿的每张幻灯片复制到目标演示文稿中。当导入的幻灯片应保持其原始主题、母版和布局关系时，这是一种合适的选择。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

如果源和目标使用不同的设计，生成的演示文稿可能包含多个母版。这在有意保留源格式时是预期的行为。

## **合并选定的幻灯片**

您不必克隆每张幻灯片。以下示例只导入源演示文稿中选定的幻灯片索引。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

在克隆之前，请验证幻灯片索引的有效性，特别是当它们来源于用户输入或外部配置时。

## **使用目标母版合并幻灯片**

当导入的幻灯片应使用已属于目标演示文稿的母版时，请使用 [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/) 重载。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides 会通过匹配源布局的类型或名称，在指定的母版下选择相应的布局。如果不存在合适的布局且 `allowCloneMissingLayout` 为 `true`，则会克隆源布局以添加幻灯片。如果为 `false`，则会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxeditexception/)。

当您希望合并失败而不是在目标母版中引入额外布局时，请使用 `false`。

## **使用特定目标布局合并幻灯片**

当您明确知道导入的幻灯片应使用哪个目标布局时，请使用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/) 重载。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

应用目标布局会更改继承的布局关系；但不会重新设计源幻灯片的内容。如果源布局和目标布局的占位符结构不同，请检查结果以确认继承的格式和占位符行为是否合适。

## **合并不同幻灯片尺寸的演示文稿**

不同幻灯片尺寸的演示文稿可以合并，但将幻灯片克隆到尺寸不同的演示文稿时，内容不会自动为新画布重新布局。因此，形状可能出现偏移、意外缩放或超出可视幻灯片区域。

一种实用方法是先调整源演示文稿的尺寸再进行克隆。[SlideSize.SetSize](https://reference.aspose.com/slides/zh/net/aspose.slides/slidesize/setsize/) 方法在更改幻灯片尺寸的同时可以缩放现有内容。[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh/net/aspose.slides/slidesizescaletype/) 会将内容缩放以适应所请求的尺寸。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

调整尺寸会在内存中修改源演示文稿对象。如果需要保持原始源演示文稿不变以用于其他操作，请为合并打开一个单独的实例。

## **将幻灯片合并到演示文稿章节**

基本的幻灯片克隆循环不会重新创建源演示文稿的章节层次结构。如果输出中需要保留章节，请在目标演示文稿中创建或选择章节，并使用 [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/) 将幻灯片显式克隆到这些章节中。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

克隆的幻灯片会追加到指定的目标章节。若要保留多个源章节，请在目标中重新创建这些章节，并将每个源幻灯片映射到相应的目标章节。

## **安全合并多个演示文稿**

以下端到端示例将第一个演示文稿用作目标，对每个后续源演示文稿的幻灯片尺寸进行统一，仅在复制时打开每个源，并一次性保存最终文件。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

这是一种保留导入幻灯片源格式的实用基准。如果输出必须使用单一的目标主题，请将简单的 `AddClone(slide)` 调用替换为前面示例中的适当目标母版或目标布局重载。

## **实际注意事项**

### **母版、布局和格式保真度**

默认的幻灯片克隆会自动将所需的源母版带入目标演示文稿。Aspose.Slides 为自动克隆的母版维护内部注册表，以避免重复克隆同一母版。手动克隆的母版不会被该注册表跟踪，因此除非需要显式控制母版结构，否则请避免预先克隆母版。

不要假设名称相同的两个母版或布局在视觉上等价。如果企业模板必须控制最终外观，请显式选择目标母版或布局，并在合并后验证结果。

### **备注和评论**

演讲者备注和幻灯片评论与幻灯片内容关联，在克隆幻灯片时会被复制。Aspose.Slides 还提供了专用的 API 用于 [presentation notes](https://docs.aspose.com/slides/zh/net/presentation-notes/) 和 [presentation comments](https://docs.aspose.com/slides/zh/net/presentation-comments/)。

如果备注页的格式很重要，请检查合并后的演示文稿，因为备注母版是演示文稿级别的对象，可能在源文件之间有所不同。对于审阅工作流，在合并来自不同作者或模板的文件后，还需验证评论作者和线程化评论。

### **图像、音频、视频、OLE 对象和外部链接**

幻灯片可以引用演示文稿级别的资源，如图像、嵌入式音频、嵌入式视频和 OLE 数据。请克隆整个幻灯片，而不是仅复制可见形状，以便 Aspose.Slides 能维护幻灯片与这些资源的关系。

嵌入式资源和链接资源应区别对待。链接的音频、视频、OLE 对象或超链接仍依赖其外部目标；克隆幻灯片不会把外部链接转换为嵌入内容。请在合并后打开的环境中测试链接资源的路径和 URL。

Aspose.Slides 明确跟踪自动克隆的母版，但这并不意味着来自不相关源演示文稿的相同二进制资源一定会被去重。如果输出文件大小重要，请检查合并后的包并测量结果，而不要依赖隐式去重。

### **嵌入字体和字体可用性**

字体在演示文稿级别进行管理。如果排版必须在不同机器上保持一致，请不要假设仅克隆幻灯片就能保证目标环境中拥有所有必需的字体。您可以使用 [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/getembeddedfonts/) 检查嵌入的字体，并按 [Embed Fonts in Presentations](https://docs.aspose.com/slides/zh/net/embedded-font/) 中的说明显式管理字体嵌入。

还请确认您有权嵌入源文件使用的字体。字体许可可能会限制嵌入。

### **受密码保护的演示文稿**

受密码保护的源文件必须成功打开后才能克隆其幻灯片。请通过 [LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/) 提供密码。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

打开加密的源文件并不会自动对目标演示文稿应用相同的保护。必要时请单独配置输出保护。

### **大型演示文稿和内存使用**

包含高分辨率图像、音频、视频或其他大型二进制对象的大型演示文稿可能会消耗大量内存。[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/blobmanagementoptions/) 提供了 BLOB 处理和临时文件使用的控制。请参阅 [Manage Presentation BLOBs](https://docs.aspose.com/slides/zh/net/manage-blob/) 了解大文件策略。

对于大文件，尽可能使用文件路径加载，合并完毕后立即释放每个源演示文稿，并避免反复保存中间结果，除非工作流需要检查点。

### **线程安全**

不要在多个线程中同时加载、修改、保存或克隆同一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例。每个演示文稿实例应仅用于一次合并操作。如果并行处理独立任务，请使用独立的演示文稿实例并遵循 [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/zh/net/multithreading/)。

## **常见问题**

**如何保留每个源演示文稿的原始设计？**

使用 [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/) 且不提供目标母版或布局。Aspose.Slides 会在导入的幻灯片需要时自动克隆源母版。

**如何让导入的幻灯片使用目标主题？**

使用接受目标母版的重载。传入目标演示文稿中的母版，而不是源演示文稿的母版。Aspose.Slides 将尝试将每个源幻灯片映射到该母版下的适当布局。

**何时应使用特定的目标布局而不是目标母版？**

当每个导入的幻灯片都应使用已知的单一布局时，使用特定布局。若希望 Aspose.Slides 根据源布局的类型或名称在该母版的布局中进行选择，则使用母版。

**不同幻灯片尺寸的演示文稿可以合并吗？**

可以，但幻灯片内容不会自动为目标尺寸重新布局。需要可预测的放置时，请先调整源演示文稿的尺寸，例如使用 [SlideSize.SetSize](https://reference.aspose.com/slides/zh/net/aspose.slides/slidesize/setsize/) 和 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh/net/aspose.slides/slidesizescaletype/)。

**可以将 PPT、PPTX 和 ODP 演示文稿合并为一个文件吗？**

可以。加载每个源演示文稿，将所需幻灯片克隆到同一个目标中，并以受支持的输出格式保存目标。由于各演示文稿格式的功能集并非完全相同，跨格式合并后请验证复杂内容。参见 [Supported File Formats](https://docs.aspose.com/slides/zh/net/supported-file-formats/)。

**源章节会自动保留吗？**

仅克隆幻灯片的基本循环不会自动保留章节。若需保留章节结构，请在目标中重新创建所需章节，并在需要时使用 [AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/) 的章节重载。

**演讲者备注和评论会被保留吗？**

它们会随克隆的幻灯片一起复制。对于依赖备注母版样式、评论作者或线程化审阅数据的工作流，请验证合并结果，因为这些情况涉及演示文稿级别结构以及幻灯片级别内容。

**音频、视频、OLE 对象和超链接会怎样？**

嵌入的内容作为克隆幻灯片资源关系的一部分被保留。外部链接仍保持外部状态，合并后仍需确保其目标文件或 URL 可用。

**每个源的嵌入字体是否保证在合并后可用？**

不要仅依赖幻灯片克隆来部署字体。请检查目标的嵌入字体，并在排版重要时显式管理字体嵌入或外部字体的可用性。

**如何合并受密码保护的文件？**

使用正确的 [LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/) 打开文件，然后正常克隆其幻灯片。输出的保护需单独配置。

**如何处理非常大的演示文稿？**

当大型二进制对象占用大量内存时，请使用 BLOB 管理；对于极大的文件，尽量使用文件路径加载，及时释放源演示文稿，并仅在需要时保存最终结果。

**可以从多个线程合并幻灯片吗？**

不要在多个线程中并发使用同一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例。每次合并操作应使用各自独立的演示文稿实例。