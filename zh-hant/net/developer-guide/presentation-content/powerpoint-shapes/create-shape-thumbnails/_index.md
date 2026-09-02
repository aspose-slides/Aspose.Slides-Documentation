---
title: 使用 .NET 建立簡報形狀的縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/net/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀圖像
- 渲染形狀
- 形狀渲染
- 視覺邊界
- 形狀邊界
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 從 PowerPoint 投影片產生高品質的形狀縮圖——輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for .NET 用於建立每個頁面皆為投影片的簡報檔案。這些投影片可透過 Microsoft PowerPoint 開啟檢視。但有時開發人員可能需要在圖像檢視器中單獨查看形狀的圖像。在此情況下，Aspose.Slides for .NET 可協助產生投影片形狀的縮圖圖像。本篇文章說明如何使用此功能。

本文說明了以不同方式產生投影片縮圖的做法：

- 在投影片內產生形狀縮圖。
- 為投影片形狀產生具有使用者自訂尺寸的縮圖。
- 在形狀外觀的邊界內產生形狀縮圖。

## **從投影片產生形狀縮圖**
使用 Aspose.Slides for .NET 從任意投影片產生形狀縮圖的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 以 ID 或索引取得任意投影片的參考。
1. 以預設比例取得參考投影片的形狀縮圖影像。
1. 將縮圖影像儲存為任何所需的圖像格式。

以下範例會產生形狀縮圖。

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
使用 Aspose.Slides for .NET 為任意投影片形狀產生縮圖的步驟：

1. 建立 `Presentation` 類別的實例。
1. 以 ID 或索引取得任意投影片的參考。
1. 取得帶有形狀邊界的參考投影片縮圖影像。
1. 將縮圖影像儲存為任何所需的圖像格式。

以下範例會以使用者自訂縮放比例產生縮圖。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // 沿 X 與 Y 軸的縮放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **建立以邊界為基礎的形狀外觀縮圖**
此方法允許開發人員在形狀外觀的邊界內產生縮圖，並會考慮所有形狀效果。產生的形狀縮圖會受投影片邊界限制。若要在形狀外觀的邊界內產生任意投影片形狀的縮圖，請使用以下範例程式碼：

1. 建立 `Presentation` 類別的實例。
1. 以 ID 或索引取得任意投影片的參考。
1. 以「外觀」作為形狀邊界取得參考投影片的縮圖影像。
1. 將縮圖影像儲存為任何所需的圖像格式。

以下範例會以使用者自訂縮放比例產生縮圖。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // 沿 X 與 Y 軸的縮放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **取得形狀的實際視覺邊界**

[IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 的框架屬性——`X`、`Y`、`Width` 與 `Height`——描述了儲存在簡報模型中的矩形。實際繪製的內容可能會超出該框架或佔用不同的軸對齊矩形。旋轉、輪廓、箭頭頭端、文字版面配置與溢位、產生的 SmartArt 幾何形狀以及其他渲染效果都可能改變佔用區域。

使用 [GetVisualBounds](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getvisualbounds/) 可以在不產生圖像的情況下計算該佔用區域。此方法會回傳以投影片坐標表示的 [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef)。回傳的矩形不會被裁切至投影片範圍，因此當內容超出投影片原點時，其座標可能為負值。

目前 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 介面並未宣告 [GetVisualBounds](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getvisualbounds/)。因此，請將從投影片形狀集合取得的形狀保留為介面類型，僅在呼叫此方法時再進行型別轉換。

以下範例取得並比較框架與視覺邊界：

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

相同的 [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) 可用於將相鄰形狀對齊至其 `Left`、`Right`、`Top` 或 `Bottom` 邊緣；在產生的版面配置中保留足夠空間；或偵測內容是否位於允許的區域之外。視覺邊界對於 SmartArt、文字方塊、箭頭、圖片、旋轉形狀以及群組形狀尤為有用，因為儲存的框架可能無法完整表示實際渲染結果。

當您需要版面配置或驗證的座標且不需要位圖時，請使用 [GetVisualBounds](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getvisualbounds/)。當您需要渲染形狀時，請使用 [IShape.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getimage/)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds.Shape` 會根據形狀邊界（包括輪廓設定）調整圖像大小，而 `ShapeThumbnailBounds.Appearance` 則根據形狀的外觀並限制結果於投影片邊界。相較之下，[GetVisualBounds](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getvisualbounds/) 只回傳計算出的矩形且不會裁切至投影片。

## **常見問答**

**保存形狀縮圖時可以使用哪些圖像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將內容儲存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時，Shape 與 Appearance 邊界有何差異？**

`Shape` 使用形狀的幾何結構；`Appearance` 會考慮[視覺效果](/slides/zh-hant/net/shape-effect/)(陰影、發光等)。

**如果形狀被標記為隱藏，還會產生縮圖嗎？**

隱藏的形狀仍屬於模型的一部份，仍可被渲染；隱藏旗標僅影響投影片放映時的顯示，並不會阻止產生形狀圖像。

**是否支援群組形狀、圖表、SmartArt 及其他複雜物件？**

是的。任何以[Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/) 表示的物件（包括[GroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/)、以及[SmartArt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會。您應該[提供所需的字型](/slides/zh-hant/net/custom-font/)（或[設定字型替代](/slides/zh-hant/net/font-substitution/)），以避免不必要的回退與文字重排。