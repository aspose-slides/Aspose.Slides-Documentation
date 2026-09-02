---
title: 在 .NET 中管理簡報的投影片區段
linktitle: 投影片區段
type: docs
weight: 100
url: /zh-hant/net/slide-section/
keywords:
- 建立區段
- 新增區段
- 編輯區段
- 變更區段
- 區段名稱
- 取得區段投影片
- 處理區段投影片
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理投影片區段：在 PPTX 簡報中建立、重新命名、重新排序、取得與處理區段投影片。"
---
## **簡介**

區段將連續的投影片組織成具名稱的群組，且不會改變投影片內容。使用 Aspose.Slides for .NET，您可以透過 [Presentation.Sections](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sections/) 屬性建立、重新排序、重新命名、檢查以及移除區段。

區段在以下情況特別有用：

- 大型簡報需要依邏輯主題或章節劃分；
- 不同的投影片群組指派給不同的協作者；
- 投影片需要以群組方式處理、移動或合併。

選擇簡潔的區段名稱以描述所分組投影片的目的。由於區段屬於簡報結構的一部份，請使用區段 API 來判斷所屬關係，而非依據投影片位置推斷。

## **建立與管理區段**

使用 [ISectionCollection.AddSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sectioncollection/addsection/) 透過指定名稱與起始投影片來建立區段。Aspose.Slides 會根據簡報目前的區段結構判定哪些投影片屬於該區段。

相同的 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isectioncollection/) 亦可讓您：

- 使用 [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sectioncollection/reordersectionwithslides/) 搬移區段及其投影片；
- 僅使用 [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sectioncollection/removesection/) 移除區段定義，保留其投影片；
- 使用 [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sectioncollection/removesectionwithslides/) 移除區段及其投影片；
- 使用 [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sectioncollection/appendemptysection/) 在末端新增空白區段。

以下範例建立兩個區段，搬移其中一個，將其與投影片一起移除，並在末端附加一個空白區段：

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

執行上述操作後，簡報會包含具有投影片的 `Introduction` 區段以及空的 `Appendix` 區段。`Results` 區段及其投影片已被移除。

## **重新命名區段**

若要重新命名區段，請設定其 [ISection.Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/name/) 屬性。區段的投影片與位置不會改變。

以下範例建立一個區段並變更其名稱：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **從區段取得投影片**

[Presentation.Sections](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sections/) 屬性會回傳一個可列舉的 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isectioncollection/)。對於每個 [ISection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/)，呼叫 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/getslideslistofsection/) 即可取得目前屬於該區段的投影片。此方法會回傳 [ISectionSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isectionslidecollection/)，提供計數、索引存取與列舉功能。

以下範例建立兩個已填充的區段與一個空白區段，然後輸出每個區段的 [name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/name/)、[identifier](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/sectionid/)、[starting slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/startedfromslide/)、投影片計數與投影片編號。它使用集合的索引子來讀取第一張投影片，並以 `foreach` 處理每一張投影片。對於空白區段，回傳的集合計數為零，索引子不會被存取，列舉也不會執行任何迭代。

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

區段的成員關係由簡報的區段結構決定。請勿自行根據 [ISection.StartedFromSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/startedfromslide/)、投影片索引以及下一個區段的起始投影片手動計算區段範圍。

結構編輯可能會變更區段回傳的投影片以及其投影片編號。這包括重新排序投影片、將投影片複製到區段、搬移區段及其投影片、移除投影片，以及移除區段。以下範例在每一次此類變更後呼叫 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/getslideslistofsection/)，而非保留對區段先前邊界的假設。

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

每當投影片或區段被重新排序、複製、搬移或移除時，請再次呼叫 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/getslideslistofsection/)。這可確保後續處理與目前的簡報結構保持一致。

PPT（PowerPoint 97–2003）格式無法保留區段的中繼資料。請使用支援區段的格式（例如 PPTX）進行此工作流程；轉換為 PPT 會移除後續列舉所需的區段結構。

## **常見問題**

**將簡報儲存為 PPT（PowerPoint 97–2003）格式時，區段會被保留嗎？**

不會。PPT 格式不支援區段的中繼資料，因而在儲存為 .ppt 時會失去區段分組。

**整個區段可以被「隱藏」嗎？**

不可以。區段本身沒有可見性狀態。若要隱藏其內容，請為該區段內的每張投影片設定 [ISlide.Hidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/hidden/) 屬性。

**如何找出包含特定投影片的區段？**

列舉 [Presentation.Sections](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sections/)，對每個區段呼叫 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/getslideslistofsection/)，並將回傳的投影片與目標投影片比較。對於非空的區段，[ISection.StartedFromSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isection/startedfromslide/) 會回傳其第一張投影片；對於空的區段，則回傳 `null`。