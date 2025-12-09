---
title: .NET で 3D プレゼンテーションを作成
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
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でインタラクティブな 3D プレゼンテーションを簡単に生成します。PowerPoint および OpenDocument 形式へすばやくエクスポートでき、さまざまな用途に活用できます。"
---

## **概要**
通常、3D PowerPoint プレゼンテーションはどのように作成しますか？

Microsoft PowerPoint では、3D モデルを追加したり、図形に 3D 効果を適用したり、3D テキストを作成したり、プレゼンテーションに 3D グラフィックスをアップロードしたり、PowerPoint の 3D アニメーションを作成したりして、3D プレゼンテーションを作成できます。

3D 効果を作成することで、プレゼンテーションを 3D に変える大きなインパクトが得られ、3D プレゼンテーションを実装する最も簡単な方法となる場合があります。

Aspose.Slides 20.9 バージョン以降、新しい **クロスプラットフォーム 3D エンジン** が追加されました。この新しい 3D エンジンは、3D 効果を持つ図形やテキストをエクスポートおよびラスター化できるようにします。以前のバージョンでは、3D 効果が適用された Slides の図形は平面的にレンダリングされていました。しかし、現在は **本格的な 3D** で図形をレンダリングできるようになりました。

さらに、Slides の公開 API を介して 3D 効果を持つ図形を作成できるようになりました。

Aspose.Slides API では、図形を PowerPoint の 3D 図形にするために [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) プロパティを使用します。このプロパティは [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) インターフェイスの機能を継承しています。

- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) と [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): 図形にベベルを設定し、ベベルの種類（例: Angle、Circle、SoftRound）や高さと幅を定義します。
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): オブジェクトの周囲でのカメラの動きを模倣するために使用されます。つまり、回転、ズーム、その他のプロパティを設定することで、PowerPoint の 3D モデルのように図形を操作できます。
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) と [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): 図形が 3D PowerPoint 図形のように見えるように輪郭のプロパティを設定します。
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)、[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) および [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): 図形を三次元化するために使用されます。つまり、深さを設定したり押し出したりして、2D 図形を 3D 図形に変換します。
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): 3D 図形に光効果を作成できます。このプロパティのロジックは Camera に似ており、光の回転を 3D 図形に対して設定し、光の種類を選択できます。
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): 3D 図形の素材タイプを設定すると、よりリアルな効果を得られます。このプロパティは Metal、Plastic、Powder、Matte などの事前定義された素材のセットを提供します。

すべての 3D 機能は図形とテキストの両方に適用できます。上記のプロパティへのアクセス方法を見て、ステップバイステップで詳細を確認しましょう。
``` csharp 
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Flat;
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }

    presentation.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```


レンダリングされたサムネイルは次のようになります：

![todo:image_alt_text](img_01_01.png)

## **3D 回転**
PowerPoint の 3D 図形は 3D 平面で回転させることができ、インタラクティブ性が向上します。PowerPoint で 3D 図形を回転させるには、通常以下のメニューを使用します：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides API では、3D 図形の回転は [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) プロパティを使用して管理できます：
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... 他の 3D シーン パラメータを設定

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **3D 深度と押し出し**
図形に第3の次元を加えて 3D 図形にするには、[IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) と [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) プロパティを使用します：
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... 他の 3D シーン パラメータを設定

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


通常、PowerPoint の Depth メニューを使用して PowerPoint 3D 図形の深さを設定します：

![todo:image_alt_text](img_02_02.png)

## **3D グラデーション**
グラデーションは PowerPoint の 3D 図形の色を塗りつぶすために使用できます。ここでは、グラデーション塗りつぶしの図形を作成し、3D 効果を適用してみましょう：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Gradient";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
    shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
    
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.ExtrusionHeight = 150;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }
}
```


結果は以下の通りです：

![todo:image_alt_text](img_02_03.png)

グラデーション塗りつぶしに加えて、画像で図形を塗りつぶすことも可能です：

``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    // ... 3D を設定: shape.ThreeDFormat.Camera、shape.ThreeDFormat.LightRig、shape.ThreeDFormat.Extrusion* プロパティ

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


以下のようになります：

![todo:image_alt_text](img_02_04.png)

## **3D テキスト (WordArt)**
Aspose.Slides ではテキストにも 3D を適用できます。3D テキストを作成するには、WordArt の変形効果を使用できます：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Text";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // "Arch Up" の WordArt 変形効果を設定
    textFrameFormat.Transform = TextShapeType.ArchUp;

    textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrameFormat.ThreeDFormat.Depth = 3;
    textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("text3d.png");
    }

    presentation.Save("text3d.pptx", SaveFormat.Pptx);
}
```


結果は以下の通りです：

![todo:image_alt_text](img_02_05.png)

## **よくある質問**

**プレゼンテーションを画像/PDF/HTML にエクスポートする際に、3D 効果は保持されますか？**

はい。Slides の 3D エンジンは、対応フォーマットへエクスポートする際に 3D 効果をレンダリングします（[images](/slides/ja/net/convert-powerpoint-to-png/)、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/) など）。

**テーマや継承などを考慮した「実効的」な（最終的な）3D パラメータ値を取得できますか？**

はい。Slides は [実効値の読み取り](/slides/ja/net/shape-effective-properties/) 用の API を提供しており（3D の照明やベベルなどを含む）、最終的に適用された設定を確認できます。

**プレゼンテーションをビデオに変換する際に、3D 効果は機能しますか？**

はい。[ビデオ用フレームを生成](/slides/ja/net/convert-powerpoint-to-video/)する際、3D 効果は [エクスポートされた画像](/slides/ja/net/convert-powerpoint-to-png/) と同様にレンダリングされます。