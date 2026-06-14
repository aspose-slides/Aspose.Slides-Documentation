---
title: 在 .NET 中建立簡報形狀的縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/net/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀影像
- 轉譯形狀
- 形狀渲染
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 從 PowerPoint 投影片產生高品質的形狀縮圖 ── 輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for .NET 用於建立每頁為投影片的簡報檔案。這些投影片可透過使用 Microsoft PowerPoint 開啟簡報檔案來檢視。但有時開發人員可能需要在影像檢視器中單獨查看形狀的圖像。在此情況下，Aspose.Slides for .NET 可協助您產生投影片形狀的縮圖影像。本文說明了如何使用此功能。  
本文說明了以不同方式產生投影片縮圖的做法：

- 在投影片內產生形狀縮圖。
- 依使用者自訂尺寸產生投影片形狀的縮圖。
- 在形狀外觀的範圍內產生形狀縮圖。

## **從投影片產生形狀縮圖**

使用 Aspose.Slides for .NET 從任何投影片產生形狀縮圖的方法如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
1. 取得任意投影片的參照，可使用其 ID 或索引。
1. 在預設比例下取得參照投影片的形狀縮圖影像。
1. 將縮圖影像儲存為任意所需的影像格式。

以下範例示範產生形狀縮圖。

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **產生使用者自訂縮放比例的縮圖**

使用 Aspose.Slides for .NET 產生任意投影片形狀的縮圖的方法如下：

1. 建立 `Presentation` 類別的執行個體。
1. 取得任意投影片的參照，可使用其 ID 或索引。
1. 取得參照投影片的形狀範圍縮圖影像。
1. 將縮圖影像儲存為任意所需的影像格式。

以下範例示範使用使用者自訂縮放比例產生縮圖。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // 沿 X 和 Y 軸的縮放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **建立基於範圍的形狀外觀縮圖**

此產生形狀縮圖的方法允許開發人員在形狀外觀的範圍內產生縮圖。它會考慮所有形狀效果。產生的形狀縮圖會受到投影片範圍的限制。若要在外觀範圍內產生任意投影片形狀的縮圖，請使用以下示範程式碼：

1. 建立 `Presentation` 類別的執行個體。
1. 取得任意投影片的參照，可使用其 ID 或索引。
1. 取得參照投影片的形狀範圍（作為外觀）的縮圖影像。
1. 將縮圖影像儲存為任意所需的影像格式。

以下範例示範建立基於外觀範圍的形狀縮圖。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // 沿 X 和 Y 軸的縮放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **常見問題**

**儲存形狀縮圖時可使用哪些影像格式？**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/)，等其他格式。形狀也可以透過將形狀內容儲存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時，Shape 與 Appearance 範圍有何差異？**  
`Shape` 使用形狀的幾何結構；`Appearance` 會考慮[視覺效果](/slides/zh-hant/net/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼情況？它仍會被渲染為縮圖嗎？**  
隱藏的形狀仍屬於模型的一部份，仍可被渲染；隱藏旗標只影響投影片放映的顯示，並不會阻止產生形狀的影像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**  
是。任何以[Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/) 表示的物件（包括[GroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/)和[SmartArt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartart/)），皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**  
會。您應該[提供必要的字型](/slides/zh-hant/net/custom-font/)（或[設定字型替代](/slides/zh-hant/net/font-substitution/)），以避免不必要的回退與文字重排。