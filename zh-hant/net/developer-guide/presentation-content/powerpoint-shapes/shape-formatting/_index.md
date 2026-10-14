---
title: 在 .NET 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/net/shape-formatting/
keywords:
- 圖形格式化
- 線條格式化
- 素描效果
- 素描圖形線條
- 接合樣式格式化
- 漸層填滿
- 圖案填滿
- 圖片填滿
- 紋理填滿
- 純色填滿
- 圖形透明度
- 黑白圖形呈現
- 灰階圖形呈現
- 圖形旋轉
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 C# 及 Aspose.Slides 在 PowerPoint 中格式化圖形——精確且完整地設定 PPT 與 PPTX 檔案的填滿、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增圖形。由於圖形是由線條組成，您可以透過修改或套用效果來格式化其輪廓。此外，您也可以透過設定內部填滿方式來格式化圖形。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET 提供介面和屬性，讓您使用 PowerPoint 中相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明操作流程：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/)。
1. 為圖形設定線條顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何格式化矩形 `AutoShape`：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

//    實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    //    取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    //    新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    //    設定矩形圖形的填色。
    shape.FillFormat.FillType = FillType.NoFill;

    //    套用矩形線條的格式化。
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    //    設定矩形線條的顏色。
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    //    將 PPTX 檔案儲存至磁碟。
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

結果：

![The formatted lines in the presentation](formatted-lines.png)

## **將草圖效果套用於圖形線條**

草圖效果會讓圖形線條呈現手繪的外觀。使用 [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 取得線條設定，使用 [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) 取得草圖設定，並使用 [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) 從 [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 列舉中選取值。

以下 C# 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 移除效果：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

`ISketchFormat.SketchType` 回傳的值代表直接指派給圖形的設定。若線條格式可從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)，存取 [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)，並讀取 [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/)。有效值反映在解決繼承後實際套用的格式：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **格式化接合樣式**

以下是三種接合類型的選項：

* 圓角
* 斜接
* 斜角

預設情況下，PowerPoint 在以角度連接兩條線（例如圖形的角落）時使用 **圓角** 設定。然而，若您繪製的是銳角圖形，可能較偏好 **斜接** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 C# 程式碼示範如何使用 Miter、Bevel 與 Round 接合樣式建立三個矩形（如上圖所示）：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增三個矩形類型的自動圖形。
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 為每個矩形圖形設定填色。
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // 設定線寬。
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // 為每個矩形的線條設定顏色。
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 設定接合樣式。
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // 為每個矩形加入文字。
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **漸層填滿**

在 PowerPoint 中，漸層填滿是一種格式化選項，可讓您將連續的顏色混合套用到圖形。例如，您可以以兩種或多種顏色的方式，使一種顏色逐漸淡出成另一種顏色。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填滿：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) 介面所公開的漸層停止集合的 `Add` 方法，依定義的位置加入您偏好的兩種顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何為橢圓套用漸層填滿效果：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個橢圓類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 為橢圓套用漸層格式。
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // 設定漸層方向。
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // 新增兩個漸層停止點。
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

結果：

![The ellipse with gradient fill](gradient-fill.png)

如果在匯出的影像中漸層與 PowerPoint 中顯示不同，請參閱 [Choose a Gradient Rendering Style](/slides/zh-hant/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改簡報內部儲存的漸層填滿的情況下選擇渲染樣式。

## **圖案填滿**

在 PowerPoint 中，圖案填滿是一種格式化選項，可讓您以兩色設計（例如點、條紋、交叉陰影或格子）套用到圖形。您可以為圖案的前景色和背景色自行選擇顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可將其套用至圖形以提升簡報的視覺效果。即使選取了預定義圖案，仍然可以自行指定要使用的精確顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖案填滿：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/)。
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/)。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何為矩形套用圖案填滿：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填滿類型為 Pattern。
    shape.FillFormat.FillType = FillType.Pattern;

    // 設定圖案樣式。
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // 設定圖案的背景色與前景色。
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

結果：

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填滿**

在 PowerPoint 中，圖片填滿是一種格式化選項，允許您將影像插入圖形內部——實質上是將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填滿：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填滿模式設為 `Tile`（或其他偏好模式）。
1. 從欲使用的影像建立 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 物件。
1. 將此影像指派給圖形的 `Picture.Image` 屬性（屬於 `PictureFillFormat`）。
1. 將修改後的簡報另存為 PPTX 檔案。

以下示範「lotus.png」影像：

![The lotus picture](lotus.png)

以下 C# 程式碼示範如何以圖片填滿圖形：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // 設定填滿類型為 Picture。
    shape.FillFormat.FillType = FillType.Picture;

    // 設定圖片填滿模式。
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // 載入影像並將其加入簡報資源。
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 設定圖片。
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

結果：

![The shape with picture fill](picture-fill.png)

### **將圖片以圖塊方式作為紋理**

若要將平鋪圖片作為紋理並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) 類別的以下屬性：

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/)：設定圖片填滿模式—`Tile` 或 `Stretch`。
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/)：指定圖塊在圖形內的對齊方式。
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/)：控制圖塊水平、垂直或同時翻轉。
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/)：設定圖塊相對於圖形原點的水平位移（點）。
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/)：設定圖塊相對於圖形原點的垂直位移（點）。
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/)：以百分比定義圖塊的水平縮放。
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/)：以百分比定義圖塊的垂直縮放。

以下程式碼範例示範如何新增帶有平鋪圖片填滿的矩形，並設定圖塊選項：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide firstSlide = presentation.Slides[0];

    // 新增一個矩形自動圖形。
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定圖形的填充類型為 Picture。
    shape.FillFormat.FillType = FillType.Picture;

    // 載入影像並將其加入簡報資源。
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // 將影像指派給圖形。
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // 設定圖片填充模式和鋪排屬性。
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

結果：

![The tile options](tile-options.png)

## **單色填滿**

在 PowerPoint 中，單色填滿是一種格式化選項，可將圖形填滿單一均勻的顏色。此純色背景不含任何漸層、紋理或圖案。

使用 Aspose.Slides 為圖形套用單色填滿的步驟如下：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指定您偏好的填滿顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何在 PowerPoint 投影片中的矩形套用單色填滿：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填滿類型為 Solid。
    shape.FillFormat.FillType = FillType.Solid;

    // 設定填滿顏色。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

結果：

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您為圖形套用單色、漸層、圖片或紋理填滿時，也可以設定透明度，以控制填滿的不透明程度。較高的透明度會讓圖形更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填滿顏色的 Alpha 值來設定透明度。操作方式如下：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color.FromArgb(alpha, baseColor)` 定義具透明度的顏色（`alpha` 參數控制透明度）。
1. 儲存簡報。

以下 C# 程式碼示範如何為矩形套用透明填色：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個實心矩形自動圖形。
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心圖形上方新增一個透明矩形自動圖形。
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

結果：

![The transparent shape](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 讓您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求的視覺元素定位時相當實用。

要在投影片上旋轉圖形，請遵循以下步驟：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 `Rotation` 屬性設定為所需角度。
1. 儲存簡報。

以下 C# 程式碼示範如何將圖形旋轉 5 度：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 將圖形旋轉 5 度。
    shape.Rotation = 5;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 斜角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) 屬性，為圖形套用 3D 斜角效果。

要為圖形新增 3D 斜角效果，請依下列步驟操作：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 C# 程式碼示範如何為圖形套用 3D 斜角效果：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 在投影片上新增圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // 設定圖形的 ThreeDFormat 屬性。
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // 將簡報儲存為 PPTX 檔案。
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

結果：

![The 3D bevel effect](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

要為圖形套用 3D 旋轉：

1. 建立 [簡報](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 新增至投影片。
1. 設定圖形的 [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) 與 [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) 以定義 3D 旋轉。
1. 儲存簡報。

以下 C# 程式碼示範如何為圖形套用 3D 旋轉效果：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // 將簡報儲存為 PPTX 檔案。
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

結果：

![The 3D rotation effect](3D-rotation-effect.png)

## **控制圖形的黑白顯示模式**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) 屬性指定在以黑白模式檢視或處理簡報時，個別圖形的呈現方式。此屬性本身不會啟用黑白顯示，也不會在正常彩色模式下改變圖形的填滿、線條或其他格式。

請使用 [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) 列舉中的值來選擇所需行為。例如，`Automatic` 讓呈現應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階顏色，`BlackWhite` 僅使用黑白，`Black` 與 `White` 強制單色，`Color` 保留正常上色，`Hidden` 在黑白模式下隱藏圖形，`NotDefined` 表示未指定圖形層級的模式。

以下 C# 程式碼建立一個有顏色的圖形，並在黑白顯示模式下讓其呈現為灰色：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// 在彩色模式下保留橙色填滿，但在黑白模式下以灰色呈現圖形。
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

在正常彩色模式下，矩形保持橙色填滿；在黑白顯示工作流程中，因模式設定為 `Gray`，故使用灰色呈現。這讓您在保留全彩投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

以下 C# 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) 上所有具占位符的圖形的位置、大小與格式還原為預設設定：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 重設投影片上在版面配置中具有占位符的每個圖形。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的圖像與媒體佔用大部分檔案空間，而圖形參數（如顏色、效果、漸層）以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性——填滿、線條與效果設定。若所有對應值相同，視為樣式相同，並在邏輯上將這些圖形分組，從而簡化後續的樣式管理。

**是否可以將一組自訂圖形樣式儲存為獨立檔案，以便在其他簡報中重複使用？**

可以。將具備所需樣式的範例圖形存於模板投影片或 *.POTX* 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式圖形，並在需要的地方重新套用其格式。