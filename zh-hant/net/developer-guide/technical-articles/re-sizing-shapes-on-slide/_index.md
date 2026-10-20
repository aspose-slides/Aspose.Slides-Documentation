---
title: 在 .NET 中調整簡報投影片上的形狀大小
type: docs
weight: 130
url: /zh-hant/net/resizing-shapes-on-slide/
aliases:
  - /zh-hant/net/re-sizing-shapes-on-slide/
  /net/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀大小
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面配置調整，提升工作效率。"
---
## **概述**

當您變更簡報的投影片大小時，可能還需要調整其形狀的大小與位置，以符合新尺寸。本文章說明如何手動縮放形狀以及如何處理投影片、母片與版面配置上的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。再將相對的高度比例套用於其垂直座標與高度。

第一個範例會載入投影片中不含表格的簡報，將投影片大小變更為 A4，並儲存結果。它使用 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 搭配 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) 以便之後的迴圈自行控制縮放。比例是無單位的；形狀的位置與尺寸以點 (point) 為單位。不同的寬度與高度比例會使形狀變形，且變更形狀的尺寸不會同步縮放字型大小。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 計算獨立的水平與垂直縮放係數。
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
表格需要單獨處理：須縮放其欄寬與列高，而不是直接設定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會大於要求的高度。
{{% /alert %}}

第二個範例支援表格，並在儲存調整過尺寸的簡報之前，處理母片、版面配置以及個別投影片上的形狀。它的輔助程式會針對每個 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 透過縮放 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) 與 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) 來處理。之後再縮放表格的位置，而不會另外縮放其整體尺寸。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 計算獨立的水平與垂直縮放係數。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// 調整在母片與版面配置以及個別投影片上定義的形狀。
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
            // 表格尺寸由欄寬與列高控制。
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

**為何調整投影片大小後形狀會變形或被裁切？**

如果在變更投影片大小時未同時縮放形狀，形狀會保留原始位置與尺寸，可能會超出投影片範圍。以不同的比例縮放寬度與高度也會導致形狀變形。

**提供的程式碼能適用於所有形狀類型嗎？**

第一個範例直接變更形狀邊界，適用於未包含表格的投影片。第二個範例則會單獨處理表格。請檢查最終的版面配置，特別是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片大小時，如何調整表格的尺寸？**

依照寬度比例縮放欄寬，依照高度比例縮放最小列高，最後再縮放表格的位置，如第二個範例所示。

**此調整是否同樣適用於母片與版面配置投影片？**

會。第二個範例會遍歷 [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) 以及每個母片的 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/)，對其形狀套用相同的調整邏輯。

**我可以在調整尺寸的同時變更投影片的方向（直向/橫向）嗎？**

可以。請在變更投影片大小之後、讀取目標尺寸之前設定 [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/)，如此縮放比例會依最終方向計算。

**我可以設定的投影片大小是否有限制？**

您可以使用 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 來指定自訂的投影片尺寸。支援的尺寸亦取決於簡報格式與開啟檔案的應用程式。

**如何避免具有固定長寬比的形狀被拉伸變形？**

請對寬度與高度使用相同的縮放係數。若要讓原始版面配置符合新投影片尺寸，可同時使用寬度與高度比例中較小的那個作為縮放係數，套用於尺寸與位置。此方式會保留比例，但可能在某一邊留下未使用的空間。