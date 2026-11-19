---
title: 使用 .NET 建立簡報中的 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 簡報
- 3D 旋轉
- 3D 深度
- 3D 拉伸
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 為 PowerPoint 圖形與文字套用並渲染 3D 效果。配置相機、光源、材質、拉伸、填充與 3D 文字。"
---
## **概覽**

Aspose.Slides for .NET 能夠建立、編輯、保存和呈現 PowerPoint 風格的 3D 格式化，用於圖形和文字。本文章涵蓋旋轉、拉伸、倒角、光照、材質、漸層或圖片填充以及 3D 文字等 3D 效果。

{{% alert color="info" title="Note" %}}
本文章說明 PowerPoint 圖形和文字的 3D 格式化效果。它不涉及插入或編輯獨立的 3D 模型檔。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染至匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) 屬性將 3D 格式化套用到圖形。此屬性會公開 [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat)，負責控制該圖形的 3D 場景。

對於文字，使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) 屬性。此屬性將 3D 格式化套用到文字框，而非圖形本體。

最重要的屬性如下：

| 屬性 | 控制項目 | 使用時機 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | 視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或符合 PowerPoint 的 3D 旋轉預設。 |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | 光源預設、方向與光照旋轉。 | 變更 3D 表面的高光與陰影呈現方式。 |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | 表面材質，例如平面、霧面、塑膠或金屬。 | 讓相同幾何形狀呈現較平坦、柔軟、光亮或金屬感。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | 圖形從正面向後延伸的距離。 | 將平面圖形轉換為可見的厚度 3D 物件。 |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 拉伸側面的顏色。 | 使深度可見或將側面顏色與前景填充協調。 |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 格式化所使用的額外深度。 | 微調圖形或文字的深度，特別是與倒角和材質設定一起使用時。 |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | 正面與背面的凸起或圓角邊緣。 | 加入柔化或模具式的邊緣，而非銳利的平面。 |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 物件的輪廓線。 | 在渲染輸出中突顯物件邊界。 |

## **建立 3D 圖形**

- 相機設定，因為預設的前視角可能隱藏拉伸效果。  
- 光源設定，因為光照使各面與側面可辨識。  
- 材質設定，因為表面會影響光線的呈現方式。  
- 拉伸或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於其正面加入文字，並套用 3D 格式化。相機旋轉值以度為單位，拉伸高度為 100 點。此範例將投影片渲染為 PNG 影像，尺寸為預設的兩倍，並將簡報儲存為 PPTX。

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

渲染出的投影片影像顯示矩形為厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3-D 旋轉」面板設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D 旋轉面板，X、Y、Z 旋轉值已標示](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) 取得相機。本範例建立一個矩形，選取正投影前視圖，並分別將 X、Y、Z 旋轉設定為 20、30、40 度。它在記憶體中配置圖形，未儲存檔案：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

當需要變更觀眾觀看物件的角度時，使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 以及 Aspose.Slides 渲染時使用的 3D 觀點。

### **從範本圖形複製相機方向**

若要匹配範本中的圖形，先複製其 [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) 預設，並使用 [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) 讀取其角度。範例開啟 `template.pptx`，從第一張投影片的第一個圖形讀取相機，並將其方向套用到第二個圖形。兩個圖形皆已具備 3D 燈光，而第二個圖形則未設定相機旋轉。

角度以度為單位。索引 `0` 為緯度，`1` 為經度，`2` 為旋轉。依此順序傳遞給 [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/)。如果來源回傳 `null`，代表沒有明確的旋轉，則保持第二個圖形的角度未設定。若明確旋轉為 `(0, 0, 0)`，會回傳三個零，應予以複製。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

當重新開啟 `camera-copy.pptx` 時，兩個圖形具有相同的相機預設與旋轉。於 PowerPoint 中，右側的箭頭使用左側矩形複製的相機方向。兩個圖形皆使用相同的燈光與拉伸深度。

![左側藍色 3D 矩形與右側箭頭，具有相同的相機方向，從上方右側檢視](camera-orientation.png)

## **加入拉伸與深度**

拉伸透過將圖形延伸至正面之後，使其看起來更厚。於 PowerPoint 中，深度控制設定此可見的厚度，而顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應至拉伸顏色與拉伸高度屬性](img_02_02.png)

設定 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 以決定厚度，並設定 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 以決定側面顏色。此範例給矩形 100 點的拉伸，側面為紫色，並旋轉相機以顯示厚度。它在記憶體中配置圖形，未儲存檔案：

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) 屬性設定 3D 圖形的深度。[ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 屬性控制拉伸效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式化與圖形填充互不相干。您可以對正面套用純色、漸層、圖案或圖片填充，同時保留相同的相機、光源、材質與拉伸設定。

此範例對正面套用藍色至橙色的漸層，並將 150 點的拉伸側面設定為深橙色。漸層在 0 與 100 處停止，分別標示漸層的起點與終點。相機旋轉值以度為單位。投影片渲染為 PNG 影像，尺寸為預設的兩倍：

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

渲染的輸出保留正面的漸層，且分別渲染拉伸側面：

![渲染的 3D 矩形，藍至橙漸層填充與橙色拉伸](img_02_03.png)

若要改用圖片填充，先將圖像加入簡報並指派給圖形填充。本範例需要工作目錄中已有名為 "image.jpg" 的檔案。它會將圖片拉伸以填滿矩形，套用 150 點的拉伸，並以度為單位設定相機旋轉。此範例在記憶體中配置圖形，未儲存或渲染檔案：

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

渲染的 3D 矩形，正面使用照片填充與橙色拉伸：

![渲染的 3D 矩形，正面使用照片填充與橙色拉伸](img_02_04.png)

## **將 3D 格式化套用到文字**

圖形的 3D 格式化影響圖形本體。文字的 3D 格式化則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要拉伸、材質、光照與相機設定。

以下範例建立文字，使用橙白格線圖案，套用向上拱形，並透過 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) 設定 3D 參數。拉伸高度與深度以點為單位，光源旋轉以度為單位。圖形填充與輪廓被隱藏，僅顯示文字。此範例渲染 PNG 影像，尺寸為預設的兩倍，並將簡報儲存為 PPTX：

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

渲染的 3D 文字，帶有拱形 WordArt 變形、橙色圖案填充與深色拉伸：

![渲染的 3D 文字，帶有拱形 WordArt 變形、橙色圖案填充與深色拉伸](img_02_05.png)

## **在 3D 圖形上保持文字平面**

若要在保留圖形 3D 外觀的同時保持文字可讀，請透過 [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) 設定 [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/)。當值為 `true` 時，文字保持在 3D 場景之外。當值為 `false` 時，文字會參與場景並跟隨其 3D 方向。

此設定不會移除圖形的 3D 格式化：其相機、光源、材質與拉伸仍透過 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) 設定。它也不同於一般的旋轉。[IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) 會在投影片平面內旋轉圖形；而 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 控制文字在其邊框內的自訂旋轉。將文字保持在 3D 場景之外不會重設這兩個角度。

以下自行完整的範例建立一個藍色矩形並加入文字，然後將其複製至原始圖形旁邊。兩個圖形具備相同的 3D 格式化，唯有文字設定不同：左側為 `false`，右側為 `true`。相機角度以度為單位，拉伸高度為 40 點。範例將簡報儲存為 PPTX，並將比較投影片渲染為 PNG，尺寸為預設的兩倍。

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

左側的文字遵循 3D 方向。右側的文字保持平面，較易閱讀。兩個矩形保留相同的可見拉伸與 3D 方向。

![並排的 3D 矩形：左側 KeepTextFlat 為 false，右側為 true](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被點陣化或繪製成 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/net/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)，或產生供 [video conversion](/slides/zh-hant/net/convert-powerpoint-to-video/) 使用的影格時。

- 匯出的圖像與 PDF 不是互動式的。物件在匯出後無法讓觀眾旋轉。  
- 最終外觀取決於相機、光源、材質、拉伸、填充與投影片縮放的組合。  
- 若需檢視繼承或主題基礎的格式值，請讀取 [effective shape properties](/slides/zh-hant/net/shape-effective-properties/)。  
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。於此類格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **FAQ**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會為圖形與文字建立並渲染 PowerPoint 的 3D 效果。它不會讓匯出的圖像、PDF 或 HTML 頁面成為觀眾可旋轉的互動式 3D 場景。於 PPTX 中，只要格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是對一般 PowerPoint 圖形或文字套用的格式化，如旋轉、拉伸、倒角、光照與材質。本文章僅討論 3D 效果。

**需要哪些設定才能顯示可見的 3D 圖形？**

最低需要設定相機旋轉，並加入拉伸或深度。實務上亦建議設定光源與材質，以確保渲染出的面具有明顯的高光與陰影。

**我可以同時將 3D 效果套用到圖形與文字嗎？**

可以。對圖形本體使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat)，對文字使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat)。

**匯出為影像、PDF、HTML 或影片幀時，會顯示 3D 效果嗎？**

會。Aspose.Slides 於產生投影片圖像、PDF 輸出、HTML 輸出以及用於影片轉換的影格時，皆會渲染 3D 效果。匯出的結果為已渲染的外觀，而非可編輯的 3D 物件。

**在套用繼承與主題設定後，我能讀取最終的 3D 值嗎？**

能。請使用在 [Shape Effective Properties](/slides/zh-hant/net/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光源、倒角與相關 3D 值。