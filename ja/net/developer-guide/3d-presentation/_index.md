---
title: .NET を使用したプレゼンテーションでの 3D 効果の作成
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/net/3d-presentation/
keywords:
- PowerPoint の 3D
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
description: "Aspose.Slides を使用して .NET で PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for .NET は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、3D テキストなどの 3D 効果について説明します。

{{% alert color="primary" %}}
この記事は PowerPoint のシェイプやテキストに対する 3D 書式設定効果についてです。スタンドアロンの 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/threedformat) プロパティを使用します。このプロパティはシェイプの 3D シーンを制御する [IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat) を公開します。

テキストの場合は、[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/threedformat) プロパティを使用します。これはシェイプ本体ではなくテキスト フレームに 3D 書式設定を適用します。

最も重要なプロパティは次のとおりです。

| プロパティ | 制御内容 | 使用シーン |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/camera) | 視点、プリセット カメラ タイプ、回転、ズーム、遠近感 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせる |
| [LightRig](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/lightrig) | ライトのプリセット、方向、回転 | 3D 表面上のハイライトと影の見え方を変更する |
| [Material](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/material) | 平坦、マット、プラスチック、金属などの表面素材 | 同じジオメトリをフラット、柔らかい、光沢のある、金属的に見せる |
| [ExtrusionHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusionheight) | 前面からどれだけ後方へ伸ばすか | 平面シェイプを厚みのある 3D オブジェクトに変える |
| [ExtrusionColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 押し出し側面の色 | 奥行きを視覚化したり、前面の塗りと色を合わせたりする |
| [Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint の 3D 書式で使用される追加奥行き | ベベルや素材設定と組み合わせてシェイプやテキストの奥行きを微調整する |
| [BevelTop](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/beveltop) と [BevelBottom](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/bevelbottom) | 前面と背面のエッジを持ち上げたり丸めたりする | 鋭い平面ではなく、柔らかく成形されたエッジを付加する |
| [ContourColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/contourcolor) と [ContourWidth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D オブジェクトのアウトライン | レンダリング結果でオブジェクトの境界を強調する |

## **3D シェイプの作成**

シェイプが自然な 3D に見えるようにするには、通常以下の 4 種類の設定が必要です。

- カメラ設定（デフォルトの正面ビューでは押し出しが見えにくいため）
- ライト設定（照明により面や側面が見やすくなるため）
- 素材設定（表面が光をどう反射するかが変わるため）
- 押し出しまたは奥行き設定（平面シェイプに厚みを持たせるため）

次のサンプルは長方形を作成し、前面にテキストを配置し、3D 書式設定を適用して PPTX として保存し、スライドを PNG 画像としてレンダリングします。

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます。

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では、3-D 回転ペインで回転を設定します。X、Y、Z の回転値はカメラ API を通じて設定する回転に対応しています。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/camera) を使用してカメラ タイプと回転を設定します。

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。スライド上の 2D シェイプ ジオメトリは変わりませんが、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

## **押し出しと奥行きの追加**

押し出しはシェイプの前面から後方へ拡張することで厚みを与えます。PowerPoint の奥行きコントロールはこの可視的な厚みを設定し、色コントロールは側面の色を決定します。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

厚みは [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusionheight) で、側面の色は [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/extrusioncolor) で設定します。

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

PowerPoint の奥行き値を直接操作したい、または奥行きをベベル、素材、テキスト効果と組み合わせたい場合は [IThreeDFormat.Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/properties/depth) を使用します。多くのシナリオでは、`ExtrusionHeight` の方が可視的な押し出し厚さを直接示すため分かりやすいです。

## **グラデーションまたは画像塗りつぶしと 3D 効果の併用**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しつつ、同じカメラ、ライト、素材、押し出し設定を使用できます。

次の例はシェイプにグラデーション塗りつぶしを適用し、側面に暗めの押し出し色を設定します。

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

レンダリング結果は前面のグラデーションを保持し、押し出しは別個に描画されます。

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

画像塗りつぶしを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りつぶしとして割り当てます。

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

画像は前面に描画され、押し出しは 3D 側面として描画されます。

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキスト フレームに影響します。これは文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt 風効果に便利です。

次のサンプルはパターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[ITextFrameFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat) に 3D 設定を構成します。

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

テキストは曲線状に押し出された 3D レタリングとしてレンダリングされます。

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **エクスポートとレンダリングの挙動**

Aspose.Slides は PPTX などの PowerPoint 形式で 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートすると、3D シーンはラスタライズまたは 2D 結果として描画されます。これはスライドを [PNG](/slides/ja/net/convert-powerpoint-to-png/)、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、または [ビデオ変換](/slides/ja/net/convert-powerpoint-to-video/) 用のフレームに変換するときに適用されます。

留意点は次のとおりです。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライト リグ、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承されたまたはテーマベースの書式設定値を確認したい場合は、[effective shape properties](/slides/ja/net/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的結果がレンダリングされ、編集可能な 3D 設定は保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンに変えることはできません。PPTX では、フォーマットがサポートしている限り 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入する別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプまたはテキストに適用する書式設定で、回転、押し出し、ベベル、照明、素材などがあります。本記事は 3D 効果について扱っています。

**可視的な 3D シェイプに必要な設定は何ですか？**

最低でもカメラの回転と押し出しまたは奥行きを設定します。実務では、ハイライトと影をはっきりさせるためにライト リグと素材も設定します。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [IShape.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/threedformat) を、テキストには [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/threedformat) を使用します。

**画像、PDF、HTML、ビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF、HTML、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリング済みの外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承およびテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライト リグ、ベベル、その他 3D 値を取得するには、[Shape Effective Properties](/slides/ja/net/shape-effective-properties/) に記載されている有効書式 API を使用してください。