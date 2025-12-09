---
title: ".NET で 3D プレゼンテーションを作成する"
linktitle: "3D プレゼンテーション"
type: docs
weight: 232
url: /ja/net/3d-presentation/
keywords:
- "3D PowerPoint"
- "3D プレゼンテーション"
- "3D 回転"
- "3D 奥行き"
- "3D 押し出し"
- "3D グラデーション"
- "3D テキスト"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides を使用して .NET でインタラクティブな 3D プレゼンテーションを簡単に作成します。PowerPoint や OpenDocument 形式へ迅速にエクスポートし、さまざまな用途に活用できます。"
---

## **概要**
PowerPointの3Dプレゼンテーションは通常どのように作成しますか？
Microsoft PowerPointは、3Dモデルを追加したり、図形に3D効果を適用したり、3Dテキストを作成したり、プレゼンテーションに3Dグラフィックをアップロードしたり、PowerPointの3Dアニメーションを作成したりすることで、3Dプレゼンテーションを作成できるようにします。

3D効果を作成すると、プレゼンテーションを3Dに変える大きなインパクトが得られ、3Dプレゼンテーションの最も簡単な実装になることもあります。
Aspose.Slides 20.9 バージョン以降、**クロスプラットフォーム3Dエンジン**が追加されました。新しい3Dエンジンにより、3D効果を持つ図形やテキストをエクスポートおよびラスタライズできるようになりました。以前のバージョンでは、3D効果が適用されたSlidesの図形は平面に描画されていましたが、現在は**本格的な3D**で図形を描画できるようになりました。
さらに、Slidesの公開APIを使用して3D効果付きの図形を作成できるようになりました。

Aspose.Slides APIで、図形をPowerPointの3D図形にするには、[IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) プロパティを使用します。このプロパティは[IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) インターフェイスの機能を継承しています:
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) と [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop)：図形にベベルを設定し、ベベルの種類（例: Angle、Circle、SoftRound）や高さ・幅を定義します。
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera)：オブジェクトの周りを回るカメラの動きを模倣します。回転、ズーム、その他のプロパティを設定することで、PowerPoint の 3D モデルのように図形を操作できます。
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) と [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth)：輪郭のプロパティを設定し、図形を 3D PowerPoint 図形のように見せます。
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)、[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) および [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight)：図形に厚みを付けて 3 次元化します。つまり、2D 図形を 3D 図形に変換するために深さを設定したり押し出したりします。
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig)：3D 図形に光効果を作成できます。このプロパティは Camera に似ており、光の回転を 3D 図形に対して設定し、光の種類を選択できます。
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material)：3D 図形の素材タイプを設定すると、よりリアルな効果が得られます。このプロパティは Metal、Plastic、Powder、Matte などの事前定義された素材を提供します。

すべての 3D 機能は図形とテキストの両方に適用できます。上記のプロパティへのアクセス方法を確認し、次にステップバイステップで詳細を見ていきましょう:
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


レンダリングされたサムネイルは次のようになります:

![todo:image_alt_text](img_01_01.png)

## **3D 回転**
PowerPoint の 3D 図形を 3D 平面で回転させることができ、インタラクティブ性が向上します。PowerPoint で 3D 図形を回転させるには、通常次のメニューを使用します:

![todo:image_alt_text](img_02_01.png)

Aspose.Slides API では、[IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) プロパティを使用して 3D 図形の回転を管理できます:
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... 他の 3D シーン パラメータを設定

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **3D 奥行きと押し出し**
図形に第 3 の次元を追加して 3D 図形にするには、[IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) と [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) プロパティを使用します:
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


通常、PowerPoint の Depth メニューを使用して PowerPoint 3D 図形の Depth を設定します:

![todo:image_alt_text](img_02_02.png)


## **3D グラデーション**
グラデーションは PowerPoint 3D 図形の塗りつぶし色に使用できます。グラデーション塗りつぶし色の図形を作成し、3D 効果を適用してみましょう:
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


結果は次のとおりです:

![todo:image_alt_text](img_02_03.png)

グラデーション塗りつぶし色に加えて、画像で図形を塗りつぶすことも可能です:
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


表示は次のようになります:

![todo:image_alt_text](img_02_04.png)

## **3D テキスト (WordArt)**
Aspose.Slides ではテキストにも 3D を適用できます。3D テキストを作成するには、WordArt 変形効果を使用します:
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
    // "Arch Up" のWordArt変形効果を設定
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


結果は次のとおりです:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**プレゼンテーションを画像/PDF/HTML にエクスポートするとき、3D 効果は保持されますか？**

はい。Slides の 3D エンジンは、サポートされている形式（[images](/slides/ja/net/convert-powerpoint-to-png/)、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/) など）へのエクスポート時に 3D 効果をレンダリングします。

**テーマや継承などを考慮した「実効」(最終) の 3D パラメータ値を取得できますか？**

はい。Slides は [実効値を読み取る](/slides/ja/net/shape-effective-properties/) API を提供しており（3D の照明、ベベルなどを含む）最終的に適用された設定を確認できます。

**プレゼンテーションをビデオに変換するとき、3D 効果は機能しますか？**

はい。[ビデオ用フレームを生成](/slides/ja/net/convert-powerpoint-to-video/)する際、3D 効果は [エクスポートされた画像](/slides/ja/net/convert-powerpoint-to-png/) と同様にレンダリングされます。