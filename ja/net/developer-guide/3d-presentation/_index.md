---
title: .NET を使用したプレゼンテーションで 3D エフェクトを作成する
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 奥行き
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint のシェイプとテキストに 3D エフェクトを適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for .NET は、シェイプやテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像の塗りつぶし、3D テキストなどの 3D エフェクトについて説明します。

{{% alert color="info" title="Note" %}}
この項目は、PowerPoint のシェイプとテキストに対する 3D 書式設定エフェクトについてです。スタンドアロンの 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はこれらの 3D エフェクトをエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) プロパティを使用します。このプロパティは[IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) を公開し、シェイプの 3D シーンを制御します。

テキストには、[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) プロパティを使用します。これによりシェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要なプロパティは次のとおりです：

| プロパティ | 制御内容 | 使用タイミング |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | 視点、プリセット カメラタイプ、回転、ズーム、遠近感 | オブジェクトを 3D 空間で回転させるか、PowerPoint の 3D 回転プリセットに合わせる |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | 光のプリセット、方向、光の回転 | 3D 表面のハイライトと影の表示方法を変更する |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | 平坦、マット、プラスチック、金属などの表面素材 | 同じ形状をより平らに、柔らかく、光沢のある、または金属的に見せる |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | シェイプが前面からどれだけ後方に伸びるか | 平面のシェイプを目に見える厚みのある 3D オブジェクトに変える |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 押し出された側面の色 | 奥行きを可視化するか、側面の色を前面の塗りつぶしと合わせる |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint の 3D 書式設定で使用される追加の奥行き | シェイプやテキストの奥行きを微調整する、特にベベルや素材設定と組み合わせて |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) と [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | 前面と背面のエッジが高くなったり丸くなったりする | 鋭い平坦な面の代わりに、柔らかく成形されたエッジを追加する |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) と [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D オブジェクトの周囲の輪郭 | レンダリングされた出力でオブジェクトの境界を強調する |

## **3D シェイプの作成**

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- ライト設定：照明により面と側面が見やすくなるため。
- 素材設定：表面が光のレンダリングに影響するため。
- 押し出しまたは奥行き設定：平面のシェイプに厚みが必要なため。

次の例は矩形を作成し、前面にテキストを追加し、3D 書式設定を適用します。カメラの回転値は度単位で、押し出し高さは 100 ポイントです。この例はスライドをデフォルトサイズの2倍の PNG 画像にレンダリングし、プレゼンテーションを PPTX として保存します。

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

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます：

![前面に白い 3D テキストがある青い 3D 矩形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3D 回転は「3-D 回転」パネルで設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3-D 回転パネル](img_02_01.png)

Aspose.Slides では [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) を通じてカメラにアクセスします。この例は矩形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ上でシェイプを構成します：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。スライド上の 2D シェイプのジオメトリは変更されません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

### **テンプレートシェイプからカメラの向きをコピーする**

テンプレート内のシェイプと合わせるには、その [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) プリセットをコピーし、[GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) で角度を取得します。この例は `template.pptx` を開き、最初のスライドの最初のシェイプからカメラを読み取り、2 番目のシェイプにその向きを適用します。両シェイプは既に 3D 照明が設定されており、2 番目のシェイプには明示的なカメラ回転がありません。

角度は度単位です。インデックス `0` が緯度、`1` が経度、`2` が回転です。その順序で [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) に渡します。ソースが `null` を返す場合、明示的な回転がないことを意味するので、2 番目のシェイプの角度は設定しません。`(0, 0, 0)` の明示的な回転は 0 が 3 つ返され、コピーすべきです。

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

`camera-copy.pptx` を再度開くと、2 つのシェイプは同じカメラプリセットと回転を持ちます。PowerPoint では、右側の矢印が左側の矩形からコピーされたカメラの向きを使用しています。両シェイプは同じ照明と押し出しの奥行きを使用します。

![上方および右側から見た、カメラの向きが一致した青い 3D 矩形と右向き矢印](camera-orientation.png)

## **押し出しと奥行きの追加**

押し出しは、シェイプの前面の裏側に拡張することで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しの色と押し出し高さプロパティに対応](img_02_02.png)

厚さには [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) を、側面の色には [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) を設定します。この例は矩形に 100 ポイントの押し出しと紫の側面を与え、カメラを回転させて厚みを表示します。ファイルを保存せずにメモリ上でシェイプを構成します：

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) プロパティは 3D シェイプの奥行きを設定します。[ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) プロパティは押し出し効果の高さを制御します。この例で示されています。

## **3D エフェクトとグラデーションまたは画像塗りつぶしの使用**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、画像塗りつぶしのいずれかを適用しつつ、同じカメラ、光、素材、押し出し設定を使用できます。

この例では、前面に青からオレンジへのグラデーションを、150 ポイントの押し出しに暗いオレンジ色を適用します。グラデーションは 0 と 100 の位置で開始と終了を示します。カメラの回転値は度単位です。スライドはデフォルトサイズの2倍の PNG 画像にレンダリングされます：

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

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_03.png)

画像塗りつぶしを使用するには、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに "image.jpg" というファイルが存在することが前提です。画像を矩形全体に伸ばし、150 ポイントの押し出しを適用し、カメラの回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ上でシェイプを構成します：

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

![前面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のようなエフェクトに便利です。

次の例は、オレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) を通じて 3D 設定を構成します。押し出し高さと奥行きはポイント単位、光の回転は度単位です。シェイプの塗りつぶしと輪郭は非表示にし、テキストのみが表示されます。例はデフォルトスライドサイズの2倍の PNG 画像をレンダリングし、プレゼンテーションを PPTX として保存します：

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

![アーチ状の WordArt 変形、オレンジのパターン塗り、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **3D シェイプ上でテキストを平坦に保つ**

シェイプの 3D 外観を保ちつつテキストを読みやすくするには、[ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) を通じて [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) を設定します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプの 3D 書式設定（カメラ、照明、素材、押し出し）を削除しません。[IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) で設定されたままです。また、通常の回転とは異なります。[IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) はスライド平面上でシェイプを回転させ、[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) はテキストのバウンディングボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

次の単体実行例は、テキスト付きの青い矩形を作成し、元の横にクローンします。両シェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。この例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの2倍の PNG にレンダリングします。

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

![並列表示された 3D 矩形：左側は KeepTextFlat が false、右側は true](keep_text_flat.png)

## **エクスポートとレンダリングの挙動**

Aspose.Slides は PPTX などの PowerPoint 形式に保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/net/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/net/convert-powerpoint-to-html/) にエクスポートする場合、または [ビデオ変換](/slides/ja/net/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。オブジェクトはエクスポート後にビューアで回転できません。
- 最終的な外観はカメラ、光源、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承やテーマ設定が適用された最終的な値を確認する必要がある場合は、[有効なシェイププロパティ](/slides/ja/net/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保持できません。そのような形式では、視覚的結果がレンダリングされ、編集可能な 3D 設定としては保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D エフェクトを作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはありません。PPTX では、形式がサポートしている場合、PowerPoint で 3D 書式設定は編集可能なまま残ります。

**3D モデルと 3D エフェクトの違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D エフェクトは、シェイプやテキストに対して適用される書式設定（回転、押し出し、ベベル、照明、素材など）です。本記事は 3D エフェクトについて説明します。

**見える 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定する必要があります。実際には、レンダリングされた面に明確なハイライトと影が出るように、光源と素材も設定します。

**シェイプとテキストの両方に 3D エフェクトを適用できますか？**

はい。シェイプ本体には [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) を、テキストには [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) を使用します。

**画像、PDF、HTML、ビデオフレームにエクスポートしたときに 3D エフェクトは表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用のフレームを生成する際に 3D エフェクトをレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[シェイプの有効プロパティ](/slides/ja/net/shape-effective-properties/) で説明されている有効な書式設定 API を使用して、最終的なカメラ、光源、ベベル、および関連する 3D 値を取得してください。