---
title: 使用 .NET 在簡報中建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 簡報
- 3D 旋轉
- 3D 深度
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 為 PowerPoint 圖形與文字套用與渲染 3D 效果。設定相機、光源、材質、擠出、填充與 3D 文字。"
---
## **概觀**

Aspose.Slides for .NET 能夠建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式設定，適用於圖形和文字。本文涵蓋旋轉、擠出、斜角、光照、材質、漸層或圖片填充以及 3D 文字等 3D 效果。

{{% alert color="info" %}}
本文說明的是 PowerPoint 圖形與文字的 3D 格式化效果，並非插入或編輯獨立 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式概念**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/threedformat) 屬性為圖形套用 3D 格式。此屬性會公開 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat)，用來控制該圖形的 3D 場景。

對於文字，使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/threedformat) 屬性。這會將 3D 格式套用到文字框，而不是圖形本體。

最重要的屬性如下：

| 屬性 | 控制項目 | 使用時機 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/camera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設。 |
| [LightRig](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/lightrig) | 光源預設、方向與光線旋轉。 | 更改 3D 表面的高光與陰影呈現方式。 |
| [Material](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/material) | 表面材質，例如平面、啞光、塑膠或金屬。 | 使相同的幾何形狀呈現更平坦、柔和、光亮或金屬感。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusionheight) | 圖形從正面延伸向後的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [ExtrusionColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 擠出側面的顏色。 | 使深度可見或將側面顏色與正面填色協調。 |
| [Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 格式使用的額外深度。 | 在圖形或文字上微調深度，特別是結合斜角與材質設定時。 |
| [BevelTop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/beveltop) 和 [BevelBottom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/bevelbottom) | 正面與背面的凸起或圓角邊緣。 | 為平面加入柔和或模具式的邊緣，而非尖銳的平面。 |
| [ContourColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/contourcolor) 和 [ContourWidth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/contourwidth) | 繞於 3D 物件周圍的輪廓。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 形狀**

在圖形看起來具有可信的 3D 效果之前，通常需要四種設定：

- 相機設定，因為預設的正面視圖可能會隱藏擠出效果。  
- 光源設定，因為光照會使面與側面易於辨識。  
- 材質設定，因為表面會影響光線的呈現方式。  
- 擠出或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於正面加入文字，套用 3D 格式，將簡報儲存為 PPTX，並將投影片渲染為 PNG 影像。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

渲染後的投影片影像顯示矩形為一個厚實的 3D 方塊：

![已渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」窗格設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 視窗格，強調 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/camera) 設定相機類型與旋轉：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

當您需要變更檢視者看到物件的方式時使用相機。它不會改變投影片上 2D 圖形的幾何形狀，而是改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 視點。

## **加入擠出與深度**

擠出會讓圖形看起來變厚，方式是延伸至正面背後。PowerPoint 中的深度控制決定此可見厚度，顏色控制則決定側面的顏色。

![PowerPoint 深度控制對映到擠出顏色與擠出高度屬性](img_02_02.png)

設定 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusionheight) 以決定厚度，並使用 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusioncolor) 設定側面顏色：

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

當需要直接操作 PowerPoint 的深度值，或將深度與斜角、材質與文字效果結合時，使用 [IThreeDFormat.Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/depth)。在多數圖形情境下，`ExtrusionHeight` 是較直觀的設定，因為它直接表達可見的擠出程度。

## **使用漸層或圖片填充搭配 3D 效果**

3D 格式與圖形填充是獨立的。您可以對正面套用單色、漸層、圖樣或圖片填充，同時使用相同的相機、光源、材質與擠出設定。

以下範例對圖形套用漸層填充，並將側面顏色設為較深的擠出色：

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

渲染結果保留正面的漸層，同時單獨繪製擠出：

![已渲染的 3D 矩形，藍至橙漸層填充，橙色擠出側面](img_02_03.png)

若要改用圖片填充，先將圖像加入簡報，然後指派給圖形的填充：

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

圖片會渲染在正面，而擠出則作為 3D 側面表面渲染：

![已渲染的 3D 矩形，正面使用照片填充，橙色擠出側面](img_02_04.png)

## **將 3D 格式套用於文字**

圖形的 3D 格式影響圖形本體；文字的 3D 格式則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立帶圖樣填充的文字，套用 WordArt 變形，並在 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat) 上設定 3D 參數：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

文字會以彎曲、擠出的 3D 形式呈現：

![已渲染的 3D 文字，拱形 WordArt 變形、橙色圖樣填充與深色擠出](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/net/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/net/convert-powerpoint-to-video/) 的影格。

請留意以下要點：

- 匯出的影像與 PDF 不是互動式的。匯出後使用者無法旋轉物件。  
- 最終外觀取決於相機、光源、材質、擠出、填充與投影片縮放的組合。  
- 若需要檢查繼承或佈景主題所套用的格式值，請讀取 [effective shape properties](/slides/zh-hant/net/shape-effective-properties/)。  
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問答**

### Aspose.Slides 能否建立互動式 3D 簡報？

Aspose.Slides 會建立並渲染 PowerPoint 對圖形與文字的 3D 效果。它不會讓匯出的圖像、PDF 或 HTML 頁面變成可讓檢視者旋轉的互動式 3D 場景。在 PPTX 中，只要格式支援，3D 格式仍可在 PowerPoint 中編輯。

### 3D 模型與 3D 效果有何差異？

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式，包含旋轉、擠出、斜角、光照與材質等。本文僅討論 3D 效果。

### 要呈現可見的 3D 圖形，需要哪些設定？

最低需求是設定相機旋轉，並同時設定擠出或深度。實務上，還應設定光源與材質，以確保渲染出的面具有明顯的高光與陰影。

### 我可以同時對圖形與文字套用 3D 效果嗎？

可以。對圖形本體使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/threedformat)，對文字使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/threedformat)。

### 匯出為圖像、PDF、HTML 或影片影格時，3D 效果會出現嗎？

會。Aspose.Slides 在產生投影片圖像、PDF、HTML 以及影片轉換的影格時，都會渲染 3D 效果。匯出的結果包含渲染後的外觀，而非可編輯的 3D 物件。

### 我可以在套用佈景主題與繼承後讀取最終的 3D 值嗎？

可以。使用在 [Shape Effective Properties](/slides/zh-hant/net/shape-effective-properties/) 中描述的有效格式 API，即可讀取最終的相機、光源、斜角與相關 3D 值。