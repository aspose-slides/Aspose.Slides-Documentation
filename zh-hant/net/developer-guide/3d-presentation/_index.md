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
- 3D 擠壓
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 套用並渲染 PowerPoint 圖形與文字的 3D 效果。設定相機、光源、材質、擠壓、填色與 3D 文字。"
---
## **概觀**

Aspose.Slides for .NET 可以建立、編輯、保留與呈現類似 PowerPoint 的 3D 格式設定，適用於圖形與文字。本文說明 3D 效果，如旋轉、擠壓、倒角、光源、材質、漸層或圖片填色，以及 3D 文字。

{{% alert color="primary" %}}
本文討論的是 PowerPoint 圖形與文字的 3D 格式效果，並不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染為匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式概念**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/threedformat) 屬性可對圖形套用 3D 格式。此屬性會公開 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat)，用於控制該圖形的 3D 場景。

對於文字，請使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/threedformat) 屬性。此屬性會將 3D 格式套用到文字框，而非圖形本體。

以下屬性最為重要：

| 屬性 | 控制項目 | 使用時機 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/camera) | 檢視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或符合 PowerPoint 的 3D 旋轉預設設定。 |
| [LightRig](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/lightrig) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上亮點與陰影的呈現方式。 |
| [Material](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/material) | 表面材質，例如平面、霧面、塑膠或金屬。 | 使相同的幾何形狀看起來更平坦、柔和、光亮或金屬感。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusionheight) | 圖形從前表面向後延伸的距離。 | 將平面圖形變為可見的厚實 3D 物件。 |
| [ExtrusionColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 擠壓側面的顏色。 | 使深度可見或將側面顏色與前景填色協調。 |
| [Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 格式使用的額外 3D 深度。 | 微調圖形或文字的深度，尤其與倒角與材質設定一起使用時。 |
| [BevelTop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/beveltop) 和 [BevelBottom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/bevelbottom) | 前後表面的凸起或圓角邊緣。 | 加入柔和或模具化的邊緣，而非銳利的平面。 |
| [ContourColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/contourcolor) 和 [ContourWidth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 物件的輪廓線。 | 在渲染結果中強調物件邊界。 |

## **建立 3D 圖形**

圖形在呈現逼真的 3D 效果前，通常需要四種設定：

- 相機設定，因為預設的正面視圖可能會隱藏擠壓效果。
- 光源設定，因為光照會讓各面與側邊更易辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，在其正面加入文字，套用 3D 格式，將簡報存為 PPTX，並將投影片渲染為 PNG 圖像。

```csharp
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

渲染出的投影片影像顯示矩形為厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3-D 旋轉」面板設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D 旋轉面板，標示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/camera) 設定相機類型與旋轉：

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

當需要變更觀眾觀看物件的角度時使用相機。它不會更改投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **加入擠壓與深度**

擠壓會透過將圖形延伸至正面之後，使其看起來更厚。在 PowerPoint 中，深度控制設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應至擠壓顏色與擠壓高度屬性](img_02_02.png)

設定 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusionheight) 以控制厚度，並設定 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusioncolor) 以設定側面顏色：

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

當需要直接操作 PowerPoint 的深度值，或將深度與倒角、材質與文字效果結合時，請使用 [IThreeDFormat.Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/depth)。在許多圖形情況下，`ExtrusionHeight` 更為直觀，因為它直接表示可見的擠壓高度。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式獨立於圖形填色。您可以對正面套用純色、漸層、圖案或圖片填色，同時仍使用相同的相機、光源、材質與擠壓設定。

以下範例將漸層填色套用到圖形，同時將較深的擠壓顏色套用到側面：

```csharp
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

渲染結果保留正面的漸層，同時分別渲染擠壓側面：

![渲染的 3D 矩形，藍至橙漸層填色與橙色擠壓](img_02_03.png)

若要改用圖片填色，請將圖像加入簡報並指派給圖形填色：

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

圖片會渲染於正面，而擠壓則作為 3D 側面表面渲染：

![渲染的 3D 矩形，正面使用照片填色與橙色擠壓](img_02_04.png)

## **將 3D 格式套用於文字**

圖形的 3D 格式會影響圖形本體。文字的 3D 格式會影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠壓、材質、光源與相機設定。

以下範例建立帶有圖案填色的文字，套用 WordArt 變形，並在 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat) 上配置 3D 設定：

```csharp
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

文字會以彎曲且擠壓的 3D 文字呈現：

![渲染的 3D 文字，帶拱形 WordArt 變形、橙色圖案填色與深色擠壓](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這在將投影片渲染為 [PNG](/slides/zh-hant/net/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/net/convert-powerpoint-to-video/) 的影格時皆適用。

- 匯出的圖像與 PDF 不是互動式的，匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠壓、填色與投影片縮放的組合。
- 如果需要檢查繼承或主題基礎的格式值，請閱讀 [有效圖形屬性](/slides/zh-hant/net/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會為圖形與文字建立並渲染 PowerPoint 的 3D 效果。它不會使匯出的圖像、PDF 或 HTML 頁面成為觀眾可旋轉的互動式 3D 場景。在 PPTX 中，若格式支援，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報中的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式設定，如旋轉、擠壓、倒角、光源與材質。本文說明的是 3D 效果。

**哪些設定是顯示可見 3D 圖形所必須的？**

最低限度需要設定相機旋轉，以及擠壓或深度之一。實務上，還應設定光源與材質，使渲染出的表面具有明顯的亮點與陰影。

**我可以同時將 3D 效果套用於圖形與文字嗎？**

可以。對圖形本體使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/threedformat)，對文字則使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/threedformat)。

**匯出為圖像、PDF、HTML 或影片影格時，會顯示 3D 效果嗎？**

會。Aspose.Slides 在產生投影片圖像、PDF 輸出、HTML 輸出以及用於影片轉換的影格時，皆會渲染 3D 效果。匯出的結果包含已渲染的外觀，而非可編輯的 3D 物件。

**我可以在繼承與主題設定套用後讀取最終的 3D 值嗎？**

可以。使用在 [有效圖形屬性](/slides/zh-hant/net/shape-effective-properties/) 中描述的有效格式 API，即可讀取最終的相機、光源、倒角與相關 3D 值。