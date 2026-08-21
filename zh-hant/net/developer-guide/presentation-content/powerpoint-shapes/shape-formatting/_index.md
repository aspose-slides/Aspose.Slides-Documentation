---
title: 在 .NET 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/net/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 草圖效果
- 草圖圖形線條
- 格式化接合樣式
- 漸層填色
- 圖樣填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 黑白圖形呈現
- 灰階圖形呈現
- 旋轉圖形
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何在 C# 中使用 Aspose.Slides 格式化 PowerPoint 圖形——精確且完整控制 PPT 與 PPTX 檔案的填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上加入圖形。由於圖形是由線條組成，您可以透過修改或套用效果來格式化它們的輪廓。此外，您還可以透過指定設定來控制圖形內部的填充方式，從而格式化圖形。

![PowerPoint 中的圖形格式化](format-shape-powerpoint.png)

Aspose.Slides for .NET 提供介面與屬性，讓您能使用與 PowerPoint 中相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明了此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C# 程式碼示範如何格式化矩形 `AutoShape`：

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

    // 設定矩形圖形的填充顏色。
    shape.FillFormat.FillType = FillType.NoFill;

    // 套用格式至矩形的線條。
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // 設定矩形線條的顏色。
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

結果：

![已格式化的投影片線條](formatted-lines.png)

## **套用草圖效果於圖形線條**

草圖效果會使圖形線條顯示為手繪風格。使用 [IShape.LineFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/lineformat/) 取得線條設定，使用 [ILineFormat.SketchFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformat/sketchformat/) 取得草圖設定，並使用 [ISketchFormat.SketchType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isketchformat/sketchtype/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linesketchtype/) 列舉中選取值。

以下 C# 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linesketchtype/) 移除效果：

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

`ISketchFormat.SketchType` 回傳的值代表直接指派給圖形的設定。若線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformat/geteffective/)，存取 [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformateffectivedata/sketchformat/)，並讀取 [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isketchformateffectivedata/sketchtype/)。此有效值反映繼承解析後實際套用的格式：

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

以下是三種接合類型選項：

* Round
* Miter
* Bevel

預設情況下，PowerPoint 在以角度（例如圖形的角落）連接兩條線時，會使用 **Round** 設定。然而，如果您繪製的是銳角圖形，可能會偏好 **Miter** 選項。

![投影片中的接合樣式](join-style-powerpoint.png)

以下 C# 程式碼示範如何使用 Miter、Bevel 和 Round 接合類型設定建立圖中所示的三個矩形：

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

    // 為每個矩形圖形設定填充顏色。
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

## **漸層填色**

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您將連續的顏色混合套用至圖形。例如，您可以使用兩種或多種顏色，使其中一種逐漸淡入另一種。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igradientformat/) 介面提供的漸層停止集合的 `Add` 方法，加入兩個您偏好的顏色與其定位。
1. 將修改後的簡報儲存為 PPTX 檔案。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個橢圓形類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 對橢圓形套用漸層格式化。
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // 設定漸層的方向。
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // 新增兩個漸層停止點。
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

![帶有漸層填色的橢圓形](gradient-fill.png)

## **圖樣填色**

在 PowerPoint 中，圖樣填色是一種格式化選項，讓您能將兩種顏色的設計（例如點、條紋、交叉線或格子）套用至圖形。您可以為圖樣的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義的圖樣樣式，您可以套用於圖形以提升簡報的視覺吸引力。即使選擇了預定義的圖樣，仍可指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖樣填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選擇圖樣樣式。
1. 設定圖樣的 [Background Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipatternformat/backcolor/)。
1. 設定圖樣的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipatternformat/forecolor/)。
1. 將修改後的簡報儲存為 PPTX 檔案。

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

    // 設定填充類型為圖樣。
    shape.FillFormat.FillType = FillType.Pattern;

    // 設定圖樣樣式。
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // 設定圖樣的背景色與前景色。
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![帶有圖樣填色的矩形](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，可讓您在圖形內插入影像——實際上將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填色模式設定為 `Tile`（或其他偏好模式）。
1. 從欲使用的影像建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件。
1. 將此影像指派給圖形的 `Picture.Image` 屬性（即其 PictureFillFormat）。
1. 將簡報儲存為 PPTX 檔案。

![蓮花圖片](lotus.png)

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

    // 設定填充類型為圖片。
    shape.FillFormat.FillType = FillType.Picture;

    // 設定圖片填充模式。
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

![帶有圖片填色的圖形](picture-fill.png)

### **將圖片平鋪作為紋理**

如果您想將平鋪的圖片設為紋理並自訂平鋪行為，可使用以下 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/) 類別的屬性：

- [PictureFillMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/picturefillmode/)：設定圖片填色模式—`Tile` 或 `Stretch`。
- [TileAlignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tilealignment/)：指定平鋪在圖形內的對齊方式。
- [TileFlip](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tileflip/)：控制平鋪是否水平、垂直或同時翻轉。
- [TileOffsetX](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tileoffsetx/)：設定平鋪相對於圖形原點的水平位移（單位為點）。
- [TileOffsetY](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tileoffsety/)：設定平鋪相對於圖形原點的垂直位移（單位為點）。
- [TileScaleX](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tilescalex/)：定義平鋪的水平比例（百分比）。
- [TileScaleY](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tilescaley/)：定義平鋪的垂直比例（百分比）。

以下程式碼範例示範如何加入一個具有平鋪圖片填色的矩形圖形並設定平鋪選項：

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

    // 設定圖形的填充類型為圖片。
    shape.FillFormat.FillType = FillType.Picture;

    // 載入影像並將其加入簡報資源。
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // 將影像指派給圖形。
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // 設定圖片填充模式與平鋪屬性。
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

![平鋪選項](tile-options.png)

## **純色填色**

在 PowerPoint 中，純色填色是一種格式化選項，會以單一、均一的顏色填滿圖形。此純粹的背景顏色不會帶有任何漸層、紋理或圖樣。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指定您偏好的填色。
1. 將修改後的簡報儲存為 PPTX 檔案。

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

    // 設定填充類型為純色。
    shape.FillFormat.FillType = FillType.Solid;

    // 設定填充顏色。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![帶有純色填色的圖形](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對圖形套用純色、漸層、圖片或紋理填色時，也可以設定透明度等級以控制填色的不透明度。較高的透明度值會使圖形更加透視，允許背景或底層物件部分可見。

Aspose.Slides 允許您透過調整用於填色的顏色之 alpha 值來設定透明度等級。以下說明如何操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color.FromArgb(alpha, baseColor)` 定義具透明度的顏色（alpha 元件控制透明度）。
1. 儲存簡報。

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

![透明的圖形](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求的視覺元素定位時非常有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將圖形的 `Rotation` 屬性設定為所需的角度。
1. 儲存簡報。

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

![圖形旋轉](shape-rotation.png)

## **加入 3D 倒角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 屬性，為圖形套用 3D 倒角效果。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 以定義倒角設定。
1. 儲存簡報。

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

![3D 倒角效果](3D-bevel-effect.png)

## **加入 3D 旋轉效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 設定圖形的 [CameraType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icamera/cameratype/) 與 [LightType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilightrig/lighttype/) 以定義 3D 旋轉。
1. 儲存簡報。

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

![3D 旋轉效果](3D-rotation-effect.png)

## **控制圖形的黑白呈現**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/blackwhitemode/) 屬性指定在以黑白模式檢視或處理簡報時，個別圖形的呈現方式。它本身不會啟用黑白顯示，也不會在正常彩色模式下更改圖形的填色、線條或其他格式設定。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/blackwhitemode/) 列舉的值來選擇所需的行為。例如，`Automatic` 讓呈現應用程式自行決定轉換，`Gray` 與 `LightGray` 使用灰色，`BlackWhite` 只使用黑與白，`Black` 與 `White` 強制為單一顏色，`Color` 保留正常著色，`Hidden` 在黑白模式下隱藏圖形。`NotDefined` 表示未指派圖形層級的模式。

以下 C# 程式碼建立一個彩色圖形，並在黑白顯示模式下使其呈現為灰色：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// 在彩色模式下保留橙色填充，但在黑白模式下以灰色渲染圖形。
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

在正常彩色模式下，矩形保留其橙色填色。在黑白顯示工作流程中，因其模式設定為 `Gray`，會以灰色呈現。這讓您在保留完整彩色投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式化**

以下 C# 程式碼顯示如何重設投影片的格式化，並將所有佔位符圖形在 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutslide/) 上的位置、大小與格式恢復為預設設定：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 重置投影片上在版面上具有佔位符的每個圖形。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

只會略微影響。嵌入的圖像與媒體佔用大部分檔案空間，而形狀參數如顏色、效果與漸層僅以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的圖形以便將其分組？**

比對每個圖形的關鍵格式屬性——填色、線條與效果設定。若所有對應值相同，即視為樣式相同，並在邏輯上將這些圖形分組，這樣可簡化之後的樣式管理。

**我可以將一組自訂圖形樣式儲存至獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例圖形存放於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式圖形，並在需要的地方重新套用其格式。