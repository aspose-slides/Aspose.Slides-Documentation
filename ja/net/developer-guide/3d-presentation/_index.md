---
title: 3Dプレゼンテーション
type: docs
weight: 232
url: /net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3Dプレゼンテーション
- 3D回転
- 3D深さ
- 3D押出し
- 3Dグラデーション
- 3Dテキスト
- PowerPointプレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでの3D PowerPointプレゼンテーション"
---

## 概要
通常、どのように3D PowerPointプレゼンテーションを作成しますか？
Microsoft PowerPointでは、3Dモデルを追加したり、形状に3D効果を適用したり、3Dテキストを作成したり、プレゼンテーションに3Dグラフィックスをアップロードしたり、PowerPoint 3Dアニメーションを作成したりできます。

3D効果を作成することは、プレゼンテーションを3Dプレゼンテーションに改善する大きな影響を及ぼし、3Dプレゼンテーションの最も簡単な実装になる可能性があります。
Aspose.Slides 20.9バージョン以降、新しい**クロスプラットフォーム3Dエンジン**が追加されました。この新しい3Dエンジンは、3D効果を伴う形状やテキストをエクスポートおよびラスタライズすることを可能にします。以前のバージョンでは、3D効果が適用されたスライドの形状は平面でレンダリングされていました。しかし、今では**本格的な3D**で形状をレンダリングすることが可能です。
さらに、現在ではSlidesの公開APIを介して3D効果を持つ形状を作成することも可能です。

Aspose.Slides APIでは、形状をPowerPoint 3D形状にするために、[IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat)プロパティを使用します。これは、[IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat)インターフェースの機能を継承しています：
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
および [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): 形状にベベルを設定し、ベベルタイプ（例：角度、円、ソフトラウンド）を定義し、ベベルの高さと幅を定義します。
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): 物体の周りのカメラの動きを模倣するために使用されます。言い換えれば、カメラの回転、ズーム、その他のプロパティを設定することで、あなたの形状をPowerPointの3Dモデルとして楽しむことができます。
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
および [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): 形状を3D PowerPoint形状のように見せるために輪郭プロパティを設定します。
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
および [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): これらは、2D形状を3D形状に変換するために使用され、形状の深さを設定したり押し出したりします。
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): 3D形状に光の効果を作成できます。このプロパティのロジックはカメラに似ており、3D形状に対して光の回転を設定し、光のタイプを選択できます。
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): 3D形状の材料のタイプを設定することで、より生き生きとした効果をもたらすことができます。このプロパティは、金属、プラスチック、粉末、マットなどの定義済み材料のセットを提供します。

すべての3D機能は、形状とテキストの両方に適用できます。上記のプロパティにアクセスする方法を見て、それらを段階的に詳しく見ていきましょう：
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

## 3D回転
PowerPointの3D形状を3D平面で回転させることが可能で、よりインタラクティブになります。PowerPointで3D形状を回転させるには、通常次のメニューを使用します：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides APIでは、3D形状の回転は、[IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera)プロパティを使用して管理できます：

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... その他の3Dシーンパラメータを設定

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

## 3D深さと押出し
形状に3D形状の第三の次元をもたらすために、[IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
および [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor)プロパティを使用します：

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... その他の3Dシーンパラメータを設定

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

通常、PowerPointでDepthメニューを使用してPowerPoint 3D形状のDepthを設定します：

![todo:image_alt_text](img_02_02.png)

## 3Dグラデーション
グラデーションを使用してPowerPoint 3D形状の色を塗りつぶすことができます。グラデーション塗りつぶしの色の形状を作成し、3D効果を適用してみましょう：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3Dグラデーション";
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

こちらが結果です：

![todo:image_alt_text](img_02_03.png)

グラデーション塗りつぶしの色を除いて、画像で形状を塗りつぶすことも可能です：
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... 3Dを設定：shape.ThreeDFormat.Camera、shape.ThreeDFormat.LightRig、shape.ThreeDFormat.Extrusion*プロパティ

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

それは次のように見えます：

![todo:image_alt_text](img_02_04.png)

## 3Dテキスト（WordArt）
Aspose.Slidesでは、テキストにも3Dを適用することができます。3Dテキストを作成するためには、WordArt変換効果を使用できます：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3Dテキスト";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // "アーチアップ" WordArt変換効果を設定
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

こちらが結果です：

![todo:image_alt_text](img_02_05.png)

## サポートされていない - 近日公開
次のPowerPoint 3D機能はまだサポートされていません： 
- ベベル
- 材料
- 輪郭
- 照明

私たちは3Dエンジンの改善を続けており、これらの機能は今後の実装の対象となります。