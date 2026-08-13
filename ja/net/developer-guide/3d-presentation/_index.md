---
title: .NET を使用したプレゼンテーションの 3D 効果の作成
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
description: ".NET と Aspose.Slides を使用して PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **概要**

Aspose.Slides for .NET は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、そして 3D テキストといった 3D 効果について説明します。

{{% alert color="info" %}}
この記事は PowerPoint シェイプとテキストに対する 3D 書式設定効果についてです。スタンドアロンの 3D モデルファイルの挿入や編集については扱いません。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/threedformat) プロパティを使用します。このプロパティは [IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat) を公開し、シェイプの 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/threedformat) プロパティを使用します。これによりシェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

主なプロパティは次のとおりです。

| プロパティ | 制御内容 | 使用タイミング |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/camera) | 視点、プリセットカメラタイプ、回転、ズーム、遠近法。 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせるとき。 |
| [LightRig](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/lightrig) | 光のプリセット、方向、光の回転。 | 3D 表面のハイライトや影の表示方法を変更する。 |
| [Material](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/material) | 平面、マット、プラスチック、金属などの表面素材。 | 同じジオメトリをより平坦、柔らか、光沢、金属的に見せたいとき。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusionheight) | 形状が前面からどれだけ後方に伸びるか。 | 平面の形状を厚みのある 3D オブジェクトに変えるとき。 |
| [ExtrusionColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 押し出し側面の色。 | 奥行きを見せたり、側面の色を前面の塗りと合わせたりする。 |
| [Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint の 3D 書式設定で使用される追加の奥行き。 | シェイプやテキストの奥行きを微調整する際、特にベベルや素材設定と組み合わせるとき。 |
| [BevelTop](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/beveltop) と [BevelBottom](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/bevelbottom) | 前面と背面のエッジが隆起または丸められる。 | 鋭利な平面の代わりに、柔らかく成形されたエッジを追加したいとき。 |
| [ContourColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/contourcolor) と [ContourWidth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D オブジェクトの輪郭。 | レンダリング出力でオブジェクトの境界を強調したいとき。 |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるまでに通常は次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れることがあるため。
- ライト設定：照明により面や側面が見やすくなるため。
- 素材設定：表面が光の当たり方に影響するため。
- 押し出しまたは奥行き設定：平面のシェイプに厚みを持たせるため。

以下の例は矩形を作成し、前面にテキストを追加し、3D 書式設定を適用してプレゼンテーションを PPTX として保存し、スライドを PNG 画像にレンダリングします。

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

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます。

![前面に白い 3D テキストがある、青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転**

PowerPoint では 3-D Rotation ペインで回転が設定されます。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![X、Y、Z 回転値がハイライトされた PowerPoint の 3D 回転パネル](img_02_01.png)

Aspose.Slides では [IThreeDFormat.Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/camera) を使ってカメラタイプと回転を設定します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

カメラはビューアがオブジェクトを見る角度を変更したいときに使用します。スライド上の 2D シェイプジオメトリは変わりませんが、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

## **押し出しと奥行きの追加**

押し出しはシェイプの前面から後方へ伸ばすことで厚みを表現します。PowerPoint では深さコントロールがこの可視厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しカラーと押し出し高さプロパティに対応している](img_02_02.png)

厚さは [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusionheight) で、側面の色は [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusioncolor) で設定します。

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

PowerPoint の深さ値を直接操作したい場合や、深さをベベル、素材、テキスト効果と組み合わせたい場合は [IThreeDFormat.Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/depth) を使用します。多くのシェイプシナリオでは、`ExtrusionHeight` の方が可視的な押し出しを直接表現できるため分かりやすいです。

## **3D 効果でグラデーションまたは画像塗りつぶしを使用**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、ライト、素材、押し出し設定を使用できます。

以下の例はシェイプにグラデーション塗りつぶしを適用し、側面に暗めの押し出しカラーを設定します。

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

レンダリング結果は前面にグラデーションが残り、押し出しは別個に描画されます。

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 長方形のレンダリング](img_02_03.png)

画像塗りつぶしを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。

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

画像は前面に描画され、押し出しは 3D 側面としてレンダリングされます。

![前面に写真塗りつぶし、オレンジの押し出しを持つ 3D 長方形のレンダリング](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はパターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[ITextFrameFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat) に 3D 設定を構成します。

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

テキストは曲線状に押し出された 3D 文字としてレンダリングされます。

![アーチ状の WordArt 変形、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式へ保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D の結果として出力に描画されます。これはスライドを [PNG](/slides/ja/net/convert-powerpoint-to-png/) にレンダリングする、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/) にエクスポートする、[HTML](/slides/ja/net/convert-powerpoint-to-html/) にエクスポートする、または [video conversion](/slides/ja/net/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

留意点：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承された設定やテーマベースの書式設定値を確認したい場合は、[effective shape properties](/slides/ja/net/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚結果が編集可能な 3D 設定としてではなく、レンダリングされた画像として保存されます。

## **よくある質問**

### Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX 形式では、対応する PowerPoint の機能により 3D 書式設定は編集可能なまま残ります。

### 3D モデルと 3D 効果の違いは何ですか？

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、素材など、通常の PowerPoint シェイプやテキストに適用される書式設定です。本記事は 3D 効果について扱っています。

### 視覚的に確認できる 3D シェイプに必要な設定は何ですか？

最低でもカメラの回転と押し出しまたは奥行きを設定する必要があります。実務では、レンダリングされた面に明確なハイライトと影を付けるためにライトリグと素材も設定します。

### シェイプとテキストの両方に 3D 効果を適用できますか？

はい。シェイプ本体には [IShape.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/threedformat) を、テキストには [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/threedformat) を使用します。

### 画像、PDF、HTML、動画フレームにエクスポートしたときに 3D 効果は表示されますか？

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、動画変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

### 継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？

はい。最終的なカメラ、ライトリグ、ベベル、その他の 3D 値を取得するには、[Shape Effective Properties](/slides/ja/net/shape-effective-properties/) に記載されている有効書式設定 API を使用してください。