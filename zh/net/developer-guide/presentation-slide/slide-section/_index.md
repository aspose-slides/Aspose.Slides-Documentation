---
title: 在 .NET 中管理演示文稿的幻灯片节
linktitle: 幻灯片节
type: docs
weight: 100
url: /zh/net/slide-section/
keywords:
- 创建节
- 添加节
- 编辑节
- 更改节
- 节名称
- 检索节幻灯片
- 处理节幻灯片
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理幻灯片节：在 PPTX 演示文稿中创建、重命名、重新排序、检索和处理节幻灯片。"
---
## **简介**

节将连续的幻灯片组织成具有名称的组，而不会更改幻灯片内容。使用 Aspose.Slides for .NET，您可以通过 [Presentation.Sections](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sections/) 属性创建、重新排序、重命名、检查和删除节。

在以下情况下，节尤其有用：

- 大型演示文稿需要划分为逻辑主题或章节；
- 不同的幻灯片组分配给不同的协作者；
- 需要将幻灯片以组的形式进行处理、移动或合并。

请选择简洁的节名称，以描述分组幻灯片的用途。由于节是演示文稿结构的一部分，请使用节 API 来确定成员关系，而不是根据幻灯片位置推断。

## **创建和管理节**

使用 [ISectionCollection.AddSection](https://reference.aspose.com/slides/zh/net/aspose.slides/sectioncollection/addsection/) 创建节，指定其名称和起始幻灯片。Aspose.Slides 根据演示文稿当前的节结构确定哪些幻灯片属于该节。

相同的 [ISectionCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/isectioncollection/) 还允许您：

- 使用 [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/sectioncollection/reordersectionwithslides/) 将节及其幻灯片一起移动；
- 仅使用 [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/zh/net/aspose.slides/sectioncollection/removesection/) 删除节定义，保留其幻灯片；
- 使用 [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/sectioncollection/removesectionwithslides/) 删除节及其幻灯片；
- 使用 [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/zh/net/aspose.slides/sectioncollection/appendemptysection/) 在末尾添加一个空节。

以下示例创建了两个节，移动其中一个，连同其幻灯片一起删除，并追加一个空节：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

执行这些操作后，演示文稿包含带有幻灯片的 `Introduction` 节以及一个空的 `Appendix` 节。`Results` 节及其幻灯片已被删除。

## **重命名节**

要重命名节，请设置其 [ISection.Name](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/name/) 属性。节的幻灯片和位置保持不变。

以下示例创建一个节并更改其名称：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **从节中检索幻灯片**

[Presentation.Sections](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sections/) 属性返回一个可枚举的 [ISectionCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/isectioncollection/)。对于每个 [ISection](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/)，调用 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/getslideslistofsection/) 以获取当前属于该节的幻灯片。该方法返回一个 [ISectionSlideCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/isectionslidecollection/)，提供计数、索引访问和枚举功能。

以下示例创建了两个已填充的节和一个空节，然后打印每个节的 [name](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/name/)、[identifier](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/sectionid/)、[starting slide](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/startedfromslide/)、幻灯片计数和幻灯片编号。它使用集合索引器读取第一张幻灯片，并使用 `foreach` 处理每张幻灯片。对于空节，返回的集合计数为零，不会访问索引器，枚举也不执行任何迭代。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

节成员资格由演示文稿的节结构决定。不要手动根据 [ISection.StartedFromSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/startedfromslide/)、幻灯片索引以及下一个节的起始幻灯片来计算节的范围。

结构编辑可能会更改返回给某个节的幻灯片以及它们的幻灯片编号。这包括重新排序幻灯片、将幻灯片克隆到节中、连同幻灯片一起移动节、删除幻灯片以及删除节。下面的示例在每次此类更改后调用 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/getslideslistofsection/)，而不是保留对节先前边界的假设。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

每当幻灯片或节被重新排序、克隆、移动或删除时，请再次调用 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/getslideslistofsection/)。这样可确保后续处理与当前的演示文稿结构保持一致。

PPT（PowerPoint 97–2003）格式不保留节元数据。请在支持节的格式（如 PPTX）中使用此工作流；转换为 PPT 会移除后续枚举所需的节结构。

## **常见问题**

**将节在保存为 PPT（PowerPoint 97–2003）格式时会被保留吗？**

不会。PPT 格式不支持节元数据，因此在保存为 .ppt 时会丢失节分组。

**整个节可以“隐藏”吗？**

不会。节没有可见性状态。若要隐藏其内容，请为该节中的每张幻灯片设置 [ISlide.Hidden](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/hidden/) 属性。

**如何查找包含某张幻灯片的节？**

枚举 [Presentation.Sections](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sections/)，对每个节调用 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/getslideslistofsection/) 并将返回的幻灯片与目标幻灯片进行比较。对于非空节，[ISection.StartedFromSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/isection/startedfromslide/) 返回其第一张幻灯片；对于空节，则返回 `null`。