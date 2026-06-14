---
title: 在 .NET 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/net/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 格式化交接樣式
- 漸層填色
- 圖樣填色
- 圖片填色
- 紋理填色
- 實心色彩填色
- 圖形透明度
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 於 C# 中格式化 PowerPoint 圖形——精確且完整控制 PPT 與 PPTX 檔案的填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增圖形。由於圖形是由線條構成，您可以透過修改或套用外框效果來格式化它們。另外，您也可以透過指定內部填充的設定來格式化圖形。

![format-shape-powerpoint](格式化圖形-PowerPoint.png)

Aspose.Slides for .NET 提供介面與屬性，讓您使用 PowerPoint 中相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何格式化矩形 `AutoShape`：

```c#
// 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個 Rectangle 類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定矩形圖形的填色。
    shape.FillFormat.FillType = FillType.NoFill;

    // 套用矩形線條的格式化設定。
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

![formatted-lines.png](投影片中格式化的線條.png)

## **格式化交接樣式**

以下是三種交接類型選項：

* Round
* Miter
* Bevel

預設情況下，PowerPoint 在以角度（例如圖形的角落）連接兩條線時，使用 **Round** 設定。若您繪製的圖形具有銳角，可能會較喜歡 **Miter** 選項。

![join-style-powerpoint.png](投影片中的交接樣式.png)

以下 C# 程式碼示範如何使用 Miter、Bevel 與 Round 交接類型設定建立圖中的三個矩形：

```c#
    // 建立代表簡報檔案的 Presentation 類別實例。
    using (Presentation presentation = new Presentation())
    {
        // 取得第一張投影片。
        ISlide slide = presentation.Slides[0];

        // 新增三個 Rectangle 類型的自動圖形。
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

        // 設定線條寬度。
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

        // 設定交接樣式。
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

在 PowerPoint 中，漸層填色是一種格式化選項，允許您將持續的顏色混合套用到圖形。例如，您可以以一種顏色逐漸淡化成另一種顏色的方式，應用兩種或更多顏色。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Gradient`。
1. 透過 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igradientformat/) 介面所公開的漸層停止集合的 `Add` 方法，依定義的位置加入您偏好的兩種顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何為橢圓套用漸層填色效果：

```c#
// 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個 Ellipse 類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 為橢圓套用漸層格式化。
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

結果：

![gradient-fill.png](具有漸層填色的橢圓.png)

## **圖樣填色**

在 PowerPoint 中，圖樣填色是一種格式化選項，讓您能將兩色設計（例如點、條紋、交叉陰影或格子）套用到圖形。您可以為圖樣的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義的圖樣樣式，您可以將其套用到圖形，以提升簡報的視覺效果。即使在選取預定義圖樣後，仍可指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖樣填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選擇圖樣樣式。
1. 設定圖樣的 [Background Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipatternformat/backcolor/)。
1. 設定圖樣的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipatternformat/forecolor/)。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何為矩形套用圖樣填色：

```c#
// 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個 Rectangle 類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 將填充類型設定為 Pattern。
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

結果：

![pattern-fill.png](具有圖樣填色的矩形.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在圖形內插入影像——實質上將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填色模式設定為 `Tile`（或其他您偏好的模式）。
1. 從欲使用的影像建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件。
1. 將此影像指派給圖形的 `Picture.Image` 屬性（屬於 `PictureFillFormat`）。
1. 將修改後的簡報另存為 PPTX 檔案。

以下為「lotus.png」檔案的示例圖片：

![lotus.png](蓮花圖片.png)

以下 C# 程式碼示範如何以圖片填滿圖形：

```c#
// 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個 Rectangle 類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // 將填充類型設定為 Picture。
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

結果：

![picture-fill.png](具有圖片填色的圖形.png)

### **將圖片平鋪為紋理**

如果您想將平鋪圖片作為紋理，並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/) 類別的以下屬性：

- [PictureFillMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/picturefillmode/)：設定圖片填色模式，`Tile` 或 `Stretch`。
- [TileAlignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tilealignment/)：指定平鋪在圖形內的對齊方式。
- [TileFlip](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tileflip/)：控制平鋪是否水平、垂直或同時翻轉。
- [TileOffsetX](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tileoffsetx/)：設定平鋪相對於圖形原點的水平位移（點數）。
- [TileOffsetY](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tileoffsety/)：設定平鋪相對於圖形原點的垂直位移（點數）。
- [TileScaleX](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tilescalex/)：以百分比定義水平比例。
- [TileScaleY](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/tilescaley/)：以百分比定義垂直比例。

以下程式碼範例示範如何加入一個平鋪圖片填色的矩形，並設定平鋪選項：

```c#
// 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide firstSlide = presentation.Slides[0];

    // 新增一個矩形自動圖形。
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 將圖形的填充類型設定為 Picture。
    shape.FillFormat.FillType = FillType.Picture;

    // 載入影像並將其加入簡報資源。
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // 指定影像給圖形。
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

結果：

![tile-options.png](平鋪選項.png)

## **實心色彩填色**

在 PowerPoint 中，實心色彩填色是一種格式化選項，會以單一、均勻的顏色填滿圖形。此純色背景不含任何漸層、紋理或圖樣。

使用 Aspose.Slides 為圖形套用實心色彩填色，請依下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
1. 將您偏好的填色指定給圖形。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何在 PowerPoint 投影片的矩形上套用實心色彩填色：

```c#
// 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個 Rectangle 類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 將填充類型設定為 Solid。
    shape.FillFormat.FillType = FillType.Solid;

    // 設定填充顏色。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

結果：

![solid-color-fill.png](具有實心色彩填色的圖形.png)

## **設定透明度**

在 PowerPoint 中，當您為圖形套用實心色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的不透明程度。較高的透明度值會讓圖形更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色顏色的 Alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color.FromArgb(alpha, baseColor)` 定義具有透明度的顏色（`alpha` 元素控制透明度）。
1. 儲存簡報。

以下 C# 程式碼示範如何為矩形套用透明填色：

```c#
const int alpha = 128;

// 建立代表簡報檔案的 Presentation 類別實例。
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

![shape-transparency.png](具有透明度的圖形.png)

## **旋轉圖形**

Aspose.Slides 讓您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求的視覺元素定位時非常有用。

要在投影片上旋轉圖形，請依下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 將圖形的 `Rotation` 屬性設定為所需角度。
1. 儲存簡報。

以下 C# 程式碼示範如何將圖形旋轉 5 度：

```c#
// 建立代表簡報檔案的 Presentation 類別實例。
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個 Rectangle 類型的自動圖形。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 將圖形旋轉 5 度。
    shape.Rotation = 5;

    // 將 PPTX 檔案儲存至磁碟。
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

結果：

![shape-rotation.png](圖形旋轉.png)

## **新增 3D 斜角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 屬性，將 3D 斜角效果套用於圖形。

要為圖形新增 3D 斜角效果，請依下列步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 C# 程式碼顯示如何為圖形套用 3D 斜角效果：

```c#
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

![3D-bevel-effect.png](3D 斜角效果.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 屬性，將 3D 旋轉效果套用於圖形。

要為圖形套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 新增至投影片。
1. 設定圖形的 [CameraType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icamera/cameratype/) 與 [LightType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilightrig/lighttype/) 以定義 3D 旋轉。
1. 儲存簡報。

以下 C# 程式碼示範如何為圖形套用 3D 旋轉效果：

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

結果：

![3D-rotation-effect.png](3D 旋轉效果.png)

## **重設格式**

以下 C# 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutslide/) 上所有佔位符圖形的位置、大小與格式恢復為預設設定：

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 重設投影片上具有版面配置佔位符的每個圖形。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與媒體占用了大部分檔案空間，而圖形參數（如顏色、效果與漸層）以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性——填色、線條與效果設定。如果所有對應值相符，即視為樣式相同，便可在邏輯上將這些圖形分組，簡化後續的樣式管理。

**我可以將一組自訂圖形樣式儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將具有所需樣式的範例圖形儲存於範本投影片組或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的已樣式化圖形，並在需要的地方重新套用其格式。