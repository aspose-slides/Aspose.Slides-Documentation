---
title: .NET を使用したプレゼンテーションでの 3D エフェクトの作成
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
description: "Aspose.Slides を使用して .NET で PowerPoint のシェイプとテキストに 3D エフェクトを適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for .NET は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像塗りつぶし、そして 3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は、PowerPoint のシェイプとテキストに対する 3D 書式設定効果について説明しています。単体の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/threedformat) プロパティを使用します。このプロパティは [IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat) を公開し、シェイプの 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/threedformat) プロパティを使用します。これによりシェイプ本体ではなくテキスト フレームに 3D 書式設定が適用されます。

最も重要なプロパティは次のとおりです。

| プロパティ | 制御内容 | 使用する場面 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/camera) | 視点、プリセット カメラの種類、回転、ズーム、パースペクティブ。 | 3D 空間でオブジェクトを回転させるか、PowerPoint の 3D 回転プリセットに合わせます。 |
| [LightRig](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/lightrig) | 光のプリセット、方向、光の回転。 | 3D 表面上のハイライトと影の見え方を変更します。 |
| [Material](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/material) | 表面素材（フラット、マット、プラスチック、金属など）。 | 同じジオメトリをより平坦に、柔らかく、光沢のある、または金属的に見せます。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusionheight) | シェイプが前面からどれだけ後方に伸びるか。 | 平坦なシェイプを見た目に厚い 3D オブジェクトに変換します。 |
| [ExtrusionColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 押し出された側面の色。 | 奥行きを見えるようにしたり、側面の色を前面の塗りつぶしと合わせたりします。 |
| [Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | シェイプやテキストの奥行きを微調整します。特にベベルやマテリアル設定と組み合わせて使用します。 |
| [BevelTop](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/beveltop) と [BevelBottom](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/bevelbottom) | 前面と背面の上げられた、または丸められたエッジ。 | 鋭い平面の代わりに、柔らかく成形されたエッジを追加します。 |
| [ContourColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/contourcolor) と [ContourWidth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調します。 |

## **3D シェイプの作成**

シェイプが納得のいく 3D に見えるためには、通常、以下の 4 種類の設定が必要です：

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- 照明設定：光によって面や側面が見やすくなるため。
- マテリアル設定：表面が光の当たり方に影響するため。
- 押し出しまたは奥行き設定：平坦なシェイプに厚みを持たせるため。

次の例は長方形を作成し、前面にテキストを追加して 3D 書式設定を適用します。カメラの回転値は度単位で、押し出し高さは 100 ポイントです。例ではスライドを PNG 画像としてデフォルトサイズの 2 倍でレンダリングし、プレゼンテーションを PPTX として保存します。

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

レンダリングされたスライド画像は、長方形が厚い 3D ブロックとして表示されます：

![前面に白い 3D テキストがある、青い 3D 長方形のレンダリング結果](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3D 回転は「3-D 回転」ペインで設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![PowerPoint の 3-D 回転ペインで X、Y、Z の回転値がハイライトされている様子](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/camera) を介してカメラにアクセスします。この例は長方形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ上でシェイプを構成します：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

オブジェクトの見え方を変更したいときにカメラを使用します。スライド上の 2D シェイプジオメトリは変更されません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

## **押し出しと奥行きの追加**

押し出しはシェイプを前面から後方に伸ばすことで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しの色と押し出し高さプロパティに対応している様子](img_02_02.png)

厚さには [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusionheight) を、側面の色には [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusioncolor) を設定します。この例は長方形に 100 ポイントの押し出しと紫色の側面を与え、カメラを回転させて厚さを見せます。ファイルを保存せずにメモリ上でシェイプを構成します：

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/depth) プロパティは 3D シェイプの奥行きを設定します。[ExtrusionHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusionheight) プロパティは押し出し効果の高さを制御します（この例を参照）。

## **3D 効果とともにグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しつつ、同じカメラ、照明、マテリアル、押し出し設定を使用できます。

この例は前面に青からオレンジへのグラデーションを、150 ポイントの押し出しには濃いオレンジ色を適用します。グラデーションの停止点は 0 と 100 が開始と終了を示します。カメラの回転値は度単位です。スライドはデフォルトサイズの 2 倍で PNG 画像としてレンダリングされます：

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

レンダリングされた出力は前面のグラデーションを保持し、押し出しは別個にレンダリングされます：

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 長方形のレンダリング結果](img_02_03.png)

画像塗りつぶしを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに「image.jpg」という既存ファイルがあることを前提としています。画像を長方形全体に伸ばし、150 ポイントの押し出しを適用し、カメラの回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ上でシェイプを構成します：

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

画像は前面にレンダリングされ、押し出しは 3D 側面としてレンダリングされます：

![前面に写真塗りつぶし、オレンジの押し出しを持つ 3D 長方形のレンダリング結果](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響します。テキストの 3D 書式設定はテキスト フレームに影響します。文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はオレンジと白のグリッド パターンでテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/threedformat) を通じて 3D 設定を構成します。押し出し高さと奥行きはポイント単位、光の回転は度単位です。シェイプの塗りつぶしと輪郭は非表示にしてテキストだけが見えるようにしています。例ではスライドをデフォルトサイズの 2 倍で PNG 画像としてレンダリングし、プレゼンテーションを PPTX として保存します：

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

テキストは曲線状に押し出された 3D 文字としてレンダリングされます：

![アーチ状に変形された WordArt 風の 3D テキスト、オレンジのパターン塗りつぶし、暗い押し出しのレンダリング結果](img_02_05.png)

## **3D シェイプ上でテキストを平面のまま保つ**

テキストを 3D シーンから除外して可読性を保ちつつシェイプの 3D 外観を維持するには、[ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/keeptextflat/) を [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/textframeformat/) を通じて設定します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプ自体の 3D 書式設定（カメラ、照明、マテリアル、押し出し）を削除しません。また、通常の回転とは異なります。[IShape.Rotation](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/rotation/) はスライド平面内でシェイプを回転させ、[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/rotationangle/) はテキストのバウンディングボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外してもこれらの角度はリセットされません。

以下の自己完結型サンプルは、青い長方形にテキストを付け、元の隣にクローンを作成します。両方のシェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。プレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍で PNG にレンダリングします。

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

左側はテキストが 3D の向きに従い、右側は平面のままで読みやすくなります。両方の長方形は同じ可視的な押し出しと 3D 向きを保持しています。

![左側が KeepTextFlat が false、右側が true の 3D 長方形の比較画像](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズまたは 2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/net/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/net/convert-powerpoint-to-html/) にエクスポートする場合、または [video conversion](/slides/ja/net/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

以下の点に留意してください：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後に閲覧者がオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、マテリアル、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承された設定やテーマに基づく書式設定値を確認する必要がある場合は、[effective shape properties](/slides/ja/net/shape-effective-properties/) を参照してください。
- 一部の出力形式では、編集可能な PowerPoint の 3D 書式設定を保存できません。そのような形式では、視覚結果がレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページを閲覧者が回転できるインタラクティブな 3D シーンにすることはできません。PPTX 形式では、対応する場合に PowerPoint 上で 3D 書式設定が編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに適用される書式設定で、回転、押し出し、ベベル、照明、マテリアルなどが含まれます。本記事は 3D 効果について扱います。

**見える 3D シェイプを作成するために必要な設定は何ですか？**

最低でもカメラの回転と押し出しまたは奥行きを設定する必要があります。実務上は、ハイライトと影を明確にするためにライトリグとマテリアルも設定するとよいでしょう。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [IShape.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/threedformat) を、テキストには [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/threedformat) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートするときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[Shape Effective Properties](/slides/ja/net/shape-effective-properties/) で説明されている有効な書式設定 API を使用して、最終的なカメラ、ライトリグ、ベベル、関連する 3D 値を取得できます。