---
title: .NET でプレゼンテーションの画像フレームを管理
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/net/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスター画像
- ベクター画像
- 画像のトリミング
- トリミング領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加できます。ワークフローを効率化し、スライド デザインを向上させましょう。"
---
## **概要**

Picture Frame は画像を含む形状です—フレーム内の写真のようなものです。

スライドに画像を追加するには Picture Frame を使用します。これにより、Picture Frame の書式設定を行うことで画像の書式設定ができます。

{{% alert  title="ヒント" color="primary" %}} 
Aspose は無料のコンバータ―、[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) を提供しており、画像からプレゼンテーションを迅速に作成できます。 
{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーション オブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage) オブジェクトを作成し、シェイプの塗りつぶしに使用します。 
4. 画像の幅と高さを指定します。 
5. 参照スライドに関連付けられたシェイプ オブジェクトが公開する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe) を作成します。 
6. スライドに画像を含む Picture Frame を追加します。 
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。 

この C# コードは Picture Frame の作成方法を示しています：

```c#
// PPTX ファイルを表す Presentation クラスをインスタンス化
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide slide = pres.Slides[0];

    // 画像をロードし、プレゼンテーションの画像コレクションに追加
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 同じ高さと幅の画像フレームを追加
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 画像フレームに書式設定を適用
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションを PPTX ファイルに保存
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Picture Frame を使用すると、画像を元にしたプレゼンテーション スライドをすばやく