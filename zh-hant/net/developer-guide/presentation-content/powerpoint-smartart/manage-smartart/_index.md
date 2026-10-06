---
title: 在 .NET 中管理 PowerPoint 簡報的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/net/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面配置類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習使用 Aspose.Slides for .NET 以及清晰的 C# 程式碼範例，快速建立與編輯 PowerPoint SmartArt，加速投影片設計與自動化。"
---
## **概觀**

SmartArt 是一個由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for .NET，您可以建立 SmartArt、從其節點讀取文字、變更版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **從 SmartArt 物件取得文字**

SmartArt 節點可以包含一個或多個形狀。要從節點形狀讀取文字，遍歷 [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/)，然後讀取由 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) 回傳的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。

此範例需要一個至少包含一張投影片且第一個形狀為 SmartArt 物件的簡報。它會將每個可用的文字框印出至主控台。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 版面配置決定節點的排列與連接方式。以下範例建立一個 SmartArt 物件，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) 的 `BasicBlockList` 值，將其變更為 `BasicProcess` 值，並儲存簡報。傳遞給 [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) 的位置與大小以點為單位。設定 [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) 以變更版面配置。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **檢查 SmartArt 節點是否為隱藏**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) 表示該節點在 SmartArt 資料模型中是否為隱藏。即使所選版面配置未將其顯示為可見圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件新增一個節點，並檢查該新增節點的隱藏狀態。若節點為隱藏，會印出訊息並儲存圖表。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/)，將子節點懸掛在左側、右側或兩側。

以下範例建立一個組織圖，並將第一個節點的版面配置設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 會選取第一個頂層節點；其子節點會使用所選的排列方式。最後會儲存已修改的簡報。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **建立圖片組織圖**

圖片組織圖是為包含圖像佔位符之階層圖表設計的 SmartArt 版面配置。將 SmartArt 物件新增至投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 值。本範例會儲存包含圖像佔位符的圖表，但不會將圖像填入佔位符。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **將舊版圖表轉換為形狀群組**

在現代化既有簡報時，您可能需要更新最初於 PowerPoint 97–2003 建立的組織圖。Aspose.Slides 會將這些舊版圖表表示為 [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) 物件。使用 [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) 可將圖表轉換為形狀群組，以便編輯個別視覺元素。詳情請參閱 [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/)。

轉換會在形狀集合中新增一個群組，而不會移除原始圖表。成功轉換後，使用 [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) 移除原始圖表，以避免內容重複。請先將舊版圖表收集到陣列中，再進行轉換，以免在新增或移除形狀時中斷迭代。

以下範例開啟一個簡報，搜尋每張投影片，將圖表轉換為形狀群組，並將更新後的簡報儲存為 PPTX。

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

儲存的簡報會在原本的舊版圖表位置以可編輯的形狀群組取代，且不會留下原始圖表。於 PowerPoint 開啟 PPTX 後，即可編輯每個群組內的個別元素，例如文字、填色或位置。

## **常見問題**

**SmartArt 是否支援 RTL 語言的鏡像或反轉？**

是的。當所選 SmartArt 版面配置支援反轉時， [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) 屬性會將圖表方向由左至右切換為右至左，或反之。

**如何在保留格式的情況下，將 SmartArt 複製到同一投影片或其他簡報？**

您可以使用 [clone the SmartArt shape](/slides/zh-hant/net/shape-manipulations/) 搭配 [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)，或 [clone the whole slide](/slides/zh-hant/net/clone-slides/) 來複製包含 SmartArt 的投影片。兩種方式均會保留大小、位置與格式。

**如何將 SmartArt 呈現為點陣圖以供預覽或網頁匯出？**

[Render the slide](/slides/zh-hant/net/convert-powerpoint-to-png/) 或將整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部份被渲染。

**如果有多個 SmartArt 物件，如何在投影片上找到特定的 SmartArt 物件？**

在 SmartArt 形狀上設定獨特的 [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) 或 [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) 值，於 [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 中搜尋該值，然後確認匹配的形狀是 [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/)。