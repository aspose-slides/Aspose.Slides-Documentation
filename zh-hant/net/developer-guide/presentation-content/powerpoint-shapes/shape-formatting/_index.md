---
title: 在 .NET 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/net/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填滿
- 圖案填滿
- 圖片填滿
- 紋理填滿
- 純色填滿
- 形狀透明度
- 旋轉形狀
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何使用 C# 與 Aspose.Slides 在 PowerPoint 中格式化形狀——精確且完整控制 PPT 與 PPTX 檔案的填滿、線條與效果樣式。"
---
## **簡介**

In PowerPoint，您可以在投影片中加入形狀。由於形狀由線條組成，您可以透過修改或套用效果於其輪廓來格式化它們。另外，您也可以透過指定控制內部填充方式的設定來格式化形狀。

![PowerPoint 中的形狀格式化](format-shape-powerpoint.png)

Aspose.Slides for .NET 提供介面與屬性，使您能夠使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂線條樣式。以下步驟說明了此流程：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linedashstyle/)。
1. 為形狀設定線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C# 程式碼示範如何格式化矩形 `AutoShape`：

```c#
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動形狀。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定矩形形狀的填色。
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

![簡報中已格式化的線條](formatted-lines.png)

## **將草圖效果套用至形狀線條**

草圖效果會讓形狀的線條看起來像手繪。使用 [IShape.LineFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/lineformat/) 取得線條設定，使用 [ILineFormat.SketchFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformat/sketchformat/) 取得草圖設定，並使用 [ISketchFormat.SketchType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isketchformat/sketchtype/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linesketchtype/) 列舉中選取值。

以下 C# 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linesketchtype/) 效果，讀取明確指派的值，並使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linesketchtype/) 移除該效果：

```csharp
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

`ISketchFormat.SketchType` 回傳的值代表直接指派給形狀的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformat/geteffective/)，存取 [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformateffectivedata/sketchformat/)，並讀取 [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isketchformateffectivedata/sketchtype/)。有效值反映在繼承解析後實際套用的格式：

```csharp
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

預設情況下，PowerPoint 在以角度（例如形狀的角落）連接兩條線時，會使用 **Round** 設定。然而，如果您繪製的是銳角形狀，可能會偏好 **Miter** 選項。

![簡報中的接合樣式](join-style-powerpoint.png)

以下 C# 程式碼示範如何使用 Miter、Bevel 與 Round 接合類型設定建立如上圖所示的三個矩形：

```c#
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增三個矩形類型的自動形狀。
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 設定每個矩形形狀的填色。
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

    // 設定每個矩形線條的顏色。
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

In PowerPoint，Gradient Fill 是一種格式化選項，可讓您對形狀套用連續的顏色漸變。例如，您可以以逐漸淡出方式套用兩種或多種顏色。

以下說明如何使用 Aspose.Slides 對形狀套用漸層填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igradientformat/) 介面所提供的漸層停止集合的 `Add` 方法，依指定的位置加入您選擇的兩種顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C# 程式碼示範如何對橢圓套用漸層填滿效果：

```c#
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個橢圓類型的自動形狀。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 套用漸層格式至橢圓。
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

![具有漸層填滿的橢圓](gradient-fill.png)

## **圖案填滿**

In PowerPoint，Pattern Fill 是一種格式化選項，允許您對形狀套用兩色的設計（例如點、條紋、交叉線或格子），並可自訂圖案的前景色與背景色。

Aspose.Slides 提供超過 45 種預定義的圖案樣式，您可將其套用至形狀以提升簡報的視覺效果。即使選擇了預設圖案，仍可自行指定其使用的顏色。

以下說明如何使用 Aspose.Slides 對形狀套用圖案填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義的選項中選取圖案樣式。
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipatternformat/backcolor/)。
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipatternformat/forecolor/)。
1. 將修改後的簡報儲存為 PPTX 檔案。

```c#
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動形狀。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Pattern。
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

![具有圖案填滿的矩形](pattern-fill.png)

## **圖片填滿**

In PowerPoint，Picture Fill 是一種格式化選項，可讓您在形狀內插入圖片，實質上將圖片作為形狀的背景。

以下說明如何使用 Aspose.Slides 對形狀套用圖片填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填滿模式設定為 `Tile`（或其他您偏好的模式）。
1. 從您要使用的圖片建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件。
1. 將此圖片指派給形狀的 `PictureFillFormat` 中的 `Picture.Image` 屬性。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，其圖片如下：

![蓮花圖片](lotus.png)

以下 C# 程式碼示範如何使用圖片填滿形狀：

```c#
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動形狀。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // 設定填充類型為 Picture。
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

![具有圖片填滿的形狀](picture-fill.png)

### **將圖片平鋪為紋理**

如果您想將平鋪的圖片作為紋理並自訂平鋪行為，可使用以下 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/) 類別的屬性：

- PictureFillMode：設定圖片填滿模式，為 `Tile` 或 `Stretch`。
- TileAlignment：指定圖片在形狀內的對齊方式。
- TileFlip：控制平鋪圖案是否水平、垂直或同時翻轉。
- TileOffsetX：設定平鋪圖案相對於形狀原點的水平偏移（以點為單位）。
- TileOffsetY：設定平鋪圖案相對於形狀原點的垂直偏移（以點為單位）。
- TileScaleX：以百分比定義平鋪圖案的水平縮放。
- TileScaleY：以百分比定義平鋪圖案的垂直縮放。

以下程式碼範例示範如何新增帶有平鋪圖片填滿的矩形形狀，並設定平鋪選項：

```c#
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide firstSlide = presentation.Slides[0];

    // 新增一個矩形自動形狀。
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定形狀的填充類型為 Picture。
    shape.FillFormat.FillType = FillType.Picture;

    // 載入影像並將其加入簡報資源。
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // 將影像指派給形狀。
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

## **純色填滿**

In PowerPoint，Solid Color Fill 是一種格式化選項，可使用單一且一致的顏色填滿形狀。此純色背景不含任何漸層、紋理或圖案。

要使用 Aspose.Slides 為形狀套用純色填滿，請依以下步驟執行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
1. 為形狀指派您偏好的填色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C# 程式碼示範如何在 PowerPoint 投影片的矩形上套用純色填滿：

```c#
using (Presentation presentation = new Presentation())
{
    // 實例化代表簡報檔案的 Presentation 類別。
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個矩形類型的自動形狀。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Solid。
    shape.FillFormat.FillType = FillType.Solid;

    // 設定填充顏色。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![具有純色填滿的形狀](solid-color-fill.png)

## **設定透明度**

In PowerPoint，當您為形狀套用純色、漸層、圖片或紋理填滿時，亦可設定透明度以控制填滿的不透明度。較高的透明度值會使形狀更透明，讓背景或底層物件部分可見。

Aspose.Slides 允許您通過調整填滿顏色的 Alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color.FromArgb(alpha, baseColor)` 定義具有透明度的顏色（`alpha` 元件控制透明度）。
1. 儲存簡報。

以下 C# 程式碼示範如何對矩形套用透明填色：

```c#
const int alpha = 128;

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個實心矩形自動形狀。
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心形狀上新增一個透明的矩形自動形狀。
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

![具有透明度的形狀](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 讓您在 PowerPoint 簡報中旋轉形狀。這在需要特定對齊或設計需求時相當實用。

要在投影片上旋轉形狀，請依以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 將形狀的 `Rotation` 屬性設為所需的角度。
1. 儲存簡報。

以下 C# 程式碼示範如何將形狀旋轉 5 度：

```c#
 // 實例化代表簡報檔案的 Presentation 類別。
 using (Presentation presentation = new Presentation())
 {
     // 取得第一張投影片。
     ISlide slide = presentation.Slides[0];

     // 新增一個矩形類型的自動形狀。
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // 將形狀旋轉 5 度。
     shape.Rotation = 5;

     // 將 PPTX 檔案儲存至磁碟。
     presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
 }
```

![形狀旋轉](shape-rotation.png)

## **新增 3D 斜角效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 屬性，將 3D 斜角效果套用至形狀。

要為形狀新增 3D 斜角效果，請依以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 C# 程式碼顯示如何對形狀套用 3D 斜角效果：

```c#
// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 在投影片上新增形狀。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // 設定形狀的 ThreeDFormat 屬性。
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

![3D 斜角效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 屬性，將 3D 旋轉效果套用至形狀。

要對形狀套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 設定形狀的 [CameraType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icamera/cameratype/) 與 [LightType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilightrig/lighttype/) 以定義 3D 旋轉。
1. 儲存簡報。

以下 C# 程式碼示範如何對形狀套用 3D 旋轉效果：

```c#
// 建立 Presentation 類別的實例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // 將簡報儲存為 PPTX 檔案。
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

![3D 旋轉效果](3D-rotation-effect.png)

## **重設格式**

以下 C# 程式碼示範如何重設投影片的格式，並將 [LayoutSlide] 上所有帶有占位符的形狀的位移、大小與格式還原為預設設定：

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 重設投影片上在版面配置中具有佔位符的每個形狀。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

僅有極小的影響。嵌入的圖片與媒體佔用大部分檔案空間，而形狀的參數如顏色、效果與漸層僅以中繼資料形式儲存，幾乎不增加額外大小。

**如何偵測投影片上具有相同格式的形狀以便將其分組？**

比較每個形狀的關鍵格式屬性——填滿、線條與效果設定。若所有對應的值皆相同，即可視為樣式相同，並在邏輯上將這些形狀分組，這樣後續的樣式管理會更簡易。

**我能否將自訂形狀樣式儲存至獨立檔案，以便在其他簡報中重複使用？**

可以。將具備所需樣式的範例形狀存放在範本投影片或 .POTX 範本檔中。建立新簡報時，開啟該範本，複製所需的樣式形狀，並在需要的地方重新套用其格式。