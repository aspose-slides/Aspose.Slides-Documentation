---
title: 在 .NET 中管理 PowerPoint 簡報的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/net/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習使用 Aspose.Slides for .NET 及清晰的 C# 程式碼範例，快速建立與編輯 PowerPoint SmartArt，以加速投影片設計與自動化。"
---
## **概觀**

SmartArt 是由節點、節點形狀與版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for .NET，您可以建立 SmartArt、從其節點讀取文字、變更版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **取得 SmartArt 物件的文字**

SmartArt 節點可以包含一個或多個形狀。若要讀取可見文字，請遍歷[ISmartArt.AllNodes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartart/allnodes/)，然後讀取由[ISmartArtShape.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartartshape/textframe/)回傳的[ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)。
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 版面配置決定節點的排列與連接方式。以下範例建立一個使用[SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。
```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **檢查 SmartArt 節點是否為隱藏**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartartnode/ishidden/) 表示該節點在 SmartArt 資料模型中是否為隱藏。即使所選的版面配置未將其顯示為圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用[SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件新增節點，並檢查該節點的隱藏狀態。
```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) 定義子節點在父節點下的排列方式。例如，您可以依照所選的[OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/organizationchartlayouttype/)，將子節點掛在左側、右側或兩側。

以下範例建立一個組織圖，並將第一個節點的版面配置設定為[OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 值。
```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **建立圖片組織圖**

圖片組織圖是為包含影像佔位符的階層圖表設計的 SmartArt 版面配置。將 SmartArt 物件加入投影片時，使用[SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 值。
```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**SmartArt 是否支援針對 RTL 語言的鏡像或反轉？**

是的。當所選的 SmartArt 版面配置支援反轉時，[IsReversed](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartart/isreversed/) 屬性可以將圖表方向從從左至右切換為從右至左，或回復。

**如何在同一張投影片或其他簡報中複製 SmartArt，且保留格式？**

您可以使用[ShapeCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapecollection/addclone/) [clone the SmartArt shape](/slides/zh-hant/net/shape-manipulations/)，或[clone the whole slide](/slides/zh-hant/net/clone-slides/) 來複製包含 SmartArt 的投影片。兩種方法皆會保留大小、位置與格式。

**如何將 SmartArt 轉換為點陣圖以供預覽或網頁匯出？**

[Render the slide](/slides/zh-hant/net/convert-powerpoint-to-png/) 或將整個簡報轉為 PNG 或 JPEG。SmartArt 會作為投影片的一部分被渲染。

**如果投影片上有多個 SmartArt，如何找出特定的 SmartArt 物件？**

在 SmartArt 形狀上設定唯一的[AlternativeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/alternativetext/)或[Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/name/)值，於[Slide.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslide/shapes/) 中搜尋該值，然後確認符合的形狀是[ISmartArt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartart/)。