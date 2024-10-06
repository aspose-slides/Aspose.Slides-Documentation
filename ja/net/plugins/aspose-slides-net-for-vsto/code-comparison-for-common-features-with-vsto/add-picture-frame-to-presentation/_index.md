---
title: プレゼンテーションに画像枠を追加する
type: docs
weight: 50
url: /ja/net/add-picture-frame-to-presentation/
---

## **VSTO**
以下は、VSTOプレゼンテーションに画像を追加するためのコードです：

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
スライドにシンプルな画像枠を追加するには、以下の手順に従ってください：

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Presentationオブジェクトに関連付けられたImagesコレクションに画像を追加してImageオブジェクトを作成します。このオブジェクトはShapeを填充するために使用されます。
1. 画像の幅と高さを計算します。
1. 参照されたスライドに関連付けられたShapesオブジェクトによって公開されたAddPictureFrameメソッドを使用して、画像の幅と高さに従ってPictureFrameを作成します。
1. スライドに画像を含む画像枠を追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記の手順は、以下の例で実装されています。

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //PPTXを表すPresentationクラスをインスタンス化

  Presentation pres = new Presentation();

  //最初のスライドを取得

  ISlide sld = pres.Slides[0];

  //ImageExクラスをインスタンス化

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //画像と同じ高さと幅の画像枠を追加

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **ダウンロード実行コード**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **ダウンロードサンプルコード**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Add Picture Frame/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)