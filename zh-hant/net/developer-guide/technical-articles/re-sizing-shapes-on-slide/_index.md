---
title: 在 .NET 中調整簡報投影片上的形狀大小
type: docs
weight: 130
url: /zh-hant/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /zh-hant/net/re-sizing-shapes-on-slide/
keywords:
  - 調整形狀大小
  - 更改形狀尺寸
  - PowerPoint
  - OpenDocument
  - 簡報
  - .NET
  - C#
  - Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提高生產力。"
---
## **概述**

當您更改簡報的投影片大小時，可能還需要調整其形狀的大小與位置，以符合新的尺寸。本文說明如何手動縮放形狀以及如何處理投影片、母片與版面的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，請將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。對其垂直座標與高度則套用相對的高度比例。

第一個範例載入一個投影片中不包含表格的簡報，將投影片尺寸變更為 A4，並儲存結果。它使用 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 搭配 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) 以便在後續的迴圈中自行控制縮放。比例是無單位的；形狀的位置與尺寸以點 (point) 為單位測量。不同的寬度與高度比例會導致形狀變形，且變更形狀尺寸不會縮放其字型大小。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 計算獨立的水平和垂直縮放因子。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
表格需要另外處理：調整其欄寬與列高，而不是設定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會維持大於要求的大小。
{{% /alert %}}

第二個範例支援表格，且在儲存調整大小後的簡報之前，會處理母片、版面以及個別投影片上的形狀。它的輔助程式會透過縮放每個 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 來調整 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) 與 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/)。之後再縮放表格的位置，而不另外縮放其整體尺寸。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 計算獨立的水平和垂直縮放因子。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// 調整在母片、版面以及個別投影片上已定義的形狀大小。
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // 表格尺寸由欄寬和列高控制。
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **常見問題**

**為什麼在調整投影片大小後形狀會變形或被截斷？**  
如果在變更投影片大小時未同步縮放形狀，形狀會保留原本的位置與尺寸，可能會超出投影片範圍。以不同的比例同時縮放寬度與高度也會導致形狀變形。

**提供的程式碼能適用於所有形狀類型嗎？**  
第一個範例直接變更形狀的邊界，適用於不含表格的投影片。第二個範例則另行處理表格。請檢查產生的版面，特別是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片大小時，該如何調整表格大小？**  
如第二個範例所示，先以寬度比例縮放欄寬、以高度比例縮放最小列高，再縮放表格的位置。

**此調整大小會適用於母片與版面投影片嗎？**  
會。第二個範例會遍歷 [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) 以及每個母片的 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) 並對其形狀套用相同的調整大小邏輯。

**我可以在調整大小的同時變更投影片的方向（直向/橫向）嗎？**  
可以。請在變更投影片大小後、讀取目標尺寸前設定 [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/)，如此縮放係數會反映最終的方向。

**設定投影片大小是否有上限？**  
您可使用 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 來指定自訂的投影片尺寸。支援的尺寸亦取決於簡報格式與開啟檔案的應用程式。

**如何避免具有固定長寬比的形狀被扭曲？**  
對寬度與高度使用相同的縮放係數。若要讓原始版面在新投影片尺寸內保持適配，可同時以寬度與高度比例中較小的那一個作為兩者的縮放係數與位置。此做法可保留比例，但可能在某一邊留下未使用的空間。