---
title: 使用 .NET 建立簡報的 3D 效果
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
description: "在 .NET 中使用 Aspose.Slides 為 PowerPoint 圖形與文字套用並呈現 3D 效果。設定相機、光照、材質、擠出、填充以及 3D 文字。"
---
## **概觀**

Aspose.Slides for .NET 可以建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式化，適用於圖形與文字。本篇文章說明 3D 效果，例如旋轉、擠出、斜面、光照、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="注意" %}}
本文討論的是 PowerPoint 圖形與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖片、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/threedformat) 屬性為圖形套用 3D 格式化。此屬性會公開 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat)，用於控制該圖形的 3D 場景。

對於文字，使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/threedformat) 屬性。此屬性會將 3D 格式化套用到文字框，而非圖形本體。

最重要的屬性如下：

| 屬性 | 它控制什麼 | 何時使用 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/camera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或套用 PowerPoint 的 3D 旋轉預設。 |
| [LightRig](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/lightrig) | 光源預設、方向與光源旋轉。 | 調整 3D 表面的高光與陰影外觀。 |
| [Material](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/material) | 表面材質，例如平面、霧面、塑膠或金屬。 | 使相同幾何形狀呈現較平坦、柔和、光亮或金屬感。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusionheight) | 圖形從前表面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [ExtrusionColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 擠出側面的顏色。 | 讓深度可見或使側面顏色與前景填充協調。 |
| [Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 格式化使用的額外深度。 | 微調圖形或文字的深度，特別是與斜面與材質設定一起使用時。 |
| [BevelTop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/beveltop) 與 [BevelBottom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/bevelbottom) | 前後表面的提升或圓角邊緣。 | 為平面表面加入柔和或模鑄的邊緣，而非銳利的平面。 |
| [ContourColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/contourcolor) 與 [ContourWidth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 物件的輪廓線條。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形在看起來像真實 3D 之前，通常需要四種設定：

- 相機設定，因為預設的正視圖可能隱藏擠出效果。
- 光源設定，因為光照讓面與側面可被辨識。
- 材質設定，因為表面影響光線的呈現方式。
- 擠出或深度設定，因為平面圖形需要厚度。

以下範例會建立一個矩形，在其前表面加入文字，並套用 3D 格式化。相機旋轉值以度為單位，擠出高度為 100 點。範例會將投影片渲染為 PNG 圖片（尺寸為預設的兩倍），並將簡報儲存為 PPTX。

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

渲染出的投影片圖像顯示矩形為厚實的 3D 方塊：

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3‑D 旋轉」窗格設定。X、Y、Z 旋轉值對應到您透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/camera) 取得相機。此範例建立一個矩形，選取正投影前視圖，並分別將 X、Y、Z 旋轉設為 20、30、40 度。它會在記憶體中設定圖形，且不會寫入檔案：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

當您需要變更觀者看到物件的方式時使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **加入擠出與深度**

擠出會讓圖形因在前表面後方延伸而看起來更厚。在 PowerPoint 中，深度控制決定此可見厚度，顏色控制決定側面的顏色。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

設定 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusionheight) 以決定厚度，並設定 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusioncolor) 以決定側面顏色。此範例為矩形設定 100 點的擠出，側面為紫色，並旋轉相機以展示其厚度。它在記憶體中設定圖形，且不會寫入檔案：

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

[IThreeDFormat.Depth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/depth) 屬性設定 3D 圖形的深度。[ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/properties/extrusionheight) 屬性則控制擠出效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式化與圖形填充相互獨立。您可以對前表面套用實色、漸層、圖樣或圖片填充，同時使用相同的相機、光源、材質與擠出設定。

此範例為前表面套用藍至橙的漸層，並為 150 點的擠出設定深橙色。漸層停點 0 與 100 分別表示漸層的開始與結束。相機旋轉值以度為單位。投影片會以 PNG 圖片渲染（尺寸為預設的兩倍）：

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

渲染結果保留前表面的漸層，並分別渲染擠出側面：

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

若要使用圖片填充，先將影像加入簡報，並指定為圖形填充。此範例需要工作目錄中已有名為 "image.jpg" 的檔案。它會將圖片拉伸填滿矩形，套用 150 點的擠出，並以度為單位設定相機旋轉。圖形同樣在記憶體中設定，且不會寫入或渲染檔案：

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

圖片會在前表面渲染，擠出則作為 3D 側面表面渲染：

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **將 3D 格式化套用到文字**

圖形的 3D 格式化會影響圖形本體；文字的 3D 格式化則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立帶有橙白格線圖樣的文字，套用向上拱形，並透過 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/threedformat) 設定 3D 參數。擠出高度與深度以點為單位，光源旋轉以度為單位。隱藏圖形填充與輪廓，使僅顯示文字。範例會將投影片渲染為 PNG（尺寸為預設的兩倍），並將簡報儲存為 PPTX：

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

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **在 3D 圖形上保持文字平面顯示**

若要在保留圖形 3D 外觀的同時讓文字易於閱讀，請透過 [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/keeptextflat/) 設定 [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/textframeformat/)。當值為 `true` 時，文字不會參與 3D 場景；當值為 `false` 時，文字會隨 3D 場景一起旋轉。

此設定不會移除圖形的 3D 格式化：相機、光源、材質與擠出仍透過 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/threedformat/) 進行設定。它也與普通旋轉不同。`[IShape.Rotation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/rotation/)` 會在投影片平面內旋轉圖形，而 `[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/rotationangle/)` 控制文字在其邊界盒內的自訂旋轉。將文字排除於 3D 場景外不會重設這兩個角度。

以下獨立範例會建立一個藍色矩形並加入文字，然後在原圖旁邊複製一個。兩個圖形皆使用相同的 3D 格式化，僅文字設定不同：左側 `false`、右側 `true`。相機角度以度為單位，擠出高度為 40 點。範例會將簡報儲存為 PPTX，並將比較投影片渲染為 PNG（尺寸為預設的兩倍）。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

左側的文字會跟隨 3D 方向；右側的文字保持平面且較易閱讀。兩個矩形保留相同的可見擠出與 3D 方向。

![Side-by-side 3D rectangles: KeepTextFlat is false on the left and true on the right](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/net/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)，或產生用於 [影片轉換](/slides/zh-hant/net/convert-powerpoint-to-video/) 的影格。

請留意以下要點：

- 匯出的圖像與 PDF 並非互動式。匯出後，觀者無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠出、填充與投影片縮放的組合。
- 若需檢查繼承或主題基礎的格式化值，請閱讀 [有效圖形屬性](/slides/zh-hant/net/shape-effective-properties/)。
- 某些輸出格式無法存儲可編輯的 PowerPoint 3D 格式化。在這些格式中，會以渲染後的視覺結果呈現，而非保留可編輯的 3D 設定。

## **常見問答**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 圖形與文字的 3D 效果，但不會讓匯出的圖像、PDF 或 HTML 頁面成為可由觀者旋轉的互動式 3D 場景。於 PPTX 中，若格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用在一般 PowerPoint 圖形或文字上的格式化，例如旋轉、擠出、斜面、光照與材質。本文僅討論 3D 效果。

**要讓 3D 圖形可見，需要哪些設定？**

最低需求是設定相機旋轉以及擠出或深度。實務上亦建議設定光源與材質，以確保渲染的面具有明顯的高光與陰影。

**我可以同時對圖形與文字套用 3D 效果嗎？**

可以。使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/properties/threedformat) 針對圖形本體，使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/properties/threedformat) 針對文字。

**匯出為圖像、PDF、HTML 或影片影格時會出現 3D 效果嗎？**

會。Aspose.Slides 會在產生投影片圖像、PDF、HTML 以及影片轉換的影格時渲染 3D 效果。匯出的結果為渲染後的外觀，而非可編輯的 3D 物件。

**我可以在考慮繼承與主題設定後讀取最終的 3D 值嗎？**

可以。使用在 [圖形有效屬性](/slides/zh-hant/net/shape-effective-properties/) 中描述的有效格式化 API，即可讀取最終的相機、光源、斜面與相關 3D 值。