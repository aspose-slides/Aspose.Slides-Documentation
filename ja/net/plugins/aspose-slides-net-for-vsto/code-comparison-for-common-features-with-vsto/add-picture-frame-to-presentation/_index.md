---
title: プレゼンテーションに画像フレームを追加
type: docs
weight: 50
url: /ja/net/add-picture-frame-to-presentation/
---

## **VSTO**
以下は VSTO プレゼンテーションに画像を追加するコードです：

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
スライドにシンプルな画像フレームを追加するには、以下の手順に従ってください：

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shape を塗りつぶすために使用する、Presentation オブジェクトに関連付けられた Images コレクションに画像を追加して Image オブジェクトを作成します。
1. 画像の幅と高さを計算します。
1. 参照されたスライドに関連付けられた Shapes オブジェクトが提供する AddPictureFrame メソッドを使用して、画像の幅と高さに合わせた PictureFrame を作成します。
1. 画像を含む PictureFrame をスライドに追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

上記の手順は、以下の例で実装されています。

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **実行コードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)