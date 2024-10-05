---
title: ピクチャーフレーム
type: docs
weight: 10
url: /net/picture-frame/
keywords: 
- ピクチャーフレームを追加
- ピクチャーフレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- StretchOffプロパティ
- ピクチャーフレームの書式設定
- ピクチャーフレームのプロパティ
- PowerPointプレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションにピクチャーフレームを追加します"
---

ピクチャーフレームは画像を含むシェイプであり、フレームに入った写真のようなものです。

ピクチャーフレームを介してスライドに画像を追加できます。これにより、ピクチャーフレームの書式設定を利用して画像の書式設定ができます。

{{% alert  title="ヒント" color="primary" %}} 

Asposeは、画像から迅速にプレゼンテーションを作成できる無料のコンバーター—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)と[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—を提供しています。

{{% /alert %}} 

## **ピクチャーフレームを作成する**

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection)に画像を追加して[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成します。このオブジェクトはシェイプの塗りつぶしに使用されます。
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連付けられたシェイプオブジェクトによって公開される`AddPictureFrame`メソッドを通じて、画像の幅と高さに基づいて[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe)を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このC#コードは、ピクチャーフレームを作成する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide slide = pres.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 同じ高さと幅のピクチャーフレームを追加
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // ピクチャーフレームにいくつかの書式設定を適用
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションをPPTXファイルとして書き込む
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

ピクチャーフレームを使用すると、画像に基づいてプレゼンテーションスライドを迅速に作成できます。ピクチャーフレームとAspose.Slidesの保存オプションを組み合わせることで、画像を別の形式に変換するための入出力操作を操作できます。これらのページを参照することをお勧めします：画像を[JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/)に変換する; [JPGから画像](https://products.aspose.com/slides/net/conversion/jpg-to-image/)に変換する; [JPGをPNGに](https://products.aspose.com/slides/net/conversion/jpg-to-png/)変換する; [PNGをJPGに](https://products.aspose.com/slides/net/conversion/png-to-jpg/)変換する; [PNGをSVGに](https://products.aspose.com/slides/net/conversion/png-to-svg/)変換する; [SVGをPNGに](https://products.aspose.com/slides/net/conversion/svg-to-png/)変換する。

{{% /alert %}}

## **相対スケールでピクチャーフレームを作成する**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. プレゼンテーションの画像コレクションに画像を追加します。
4. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection)に画像を追加して[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成します。このオブジェクトはシェイプを塗りつぶすのに使用されます。
5. ピクチャーフレーム内の画像の相対的な幅と高さを指定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このC#コードは、相対スケールでピクチャーフレームを作成する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 画像を読み込み、プレゼンテーションの画像コレクションに追加
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // スライドにピクチャーフレームを追加
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 相対スケールの幅と高さを設定
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // プレゼンテーションを保存
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **ピクチャーフレームから画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe)オブジェクトから画像を抽出し、PNG、JPGなどの形式で保存できます。以下のコード例は、"sample.pptx"というドキュメントから画像を抽出し、PNG形式で保存する方法を示しています。

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **画像の透明度を取得する**

Aspose.Slidesを使用すると、画像の透明度を取得できます。このC#コードはその操作を示しています：

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("画像の透明度: " + transparencyValue);
        }
    }
}
```

## **ピクチャーフレームの書式設定**

Aspose.Slidesは、ピクチャーフレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合うようにピクチャーフレームを変更できます。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection)に画像を追加して[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)オブジェクトを作成します。このオブジェクトはシェイプを塗りつぶすのに使用されます。
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連付けられた[IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection)オブジェクトによって公開される[AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe)メソッドを介して、画像の幅と高さに基づいて`PictureFrame`を作成します。
6. スライドにピクチャーフレーム（画像を含む）を追加します。
7. ピクチャーフレームの線の色を設定します。
8. ピクチャーフレームの線の幅を設定します。
9. ピクチャーフレームを回転させます。正の値または負の値を指定します。
   * 正の値は画像を時計回りに回転させます。
   * 負の値は画像を反時計回りに回転させます。
10. スライドにピクチャーフレーム（画像を含む）を再度追加します。
11. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このC#コードは、ピクチャーフレームの書式設定プロセスを示します：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得
    ISlide slide = presentation.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像の等価な高さと幅を持つピクチャーフレームを追加
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // ピクチャーフレームにいくつかの書式設定を適用
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションをPPTXファイルとして書き込む
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Asposeが最近開発した[無料のコラージュメーカー](https://products.aspose.app/slides/collage)があります。JPG/JPEGまたはPNG画像を[マージする](https://products.aspose.app/slides/collage/jpg)や、[写真からグリッドを作成する](https://products.aspose.app/slides/collage/photo-grid)必要がある場合は、このサービスを利用できます。

{{% /alert %}}

## **リンクとして画像を追加**

プレゼンテーションのサイズを大きくしないように、ファイルを直接埋め込むのではなく、リンクを介して画像（または動画）を追加できます。このC#コードは、プレースホルダーに画像と動画を追加する方法を示しています：

```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **画像を切り抜く**

このC#コードは、スライド上の既存の画像を切り抜く方法を示しています：

```c#
using (Presentation presentation = new Presentation())
{
    // 新しい画像オブジェクトを作成
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // スライドにピクチャーフレームを追加
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // 画像を切り抜く（パーセンテージ値）
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // 結果を保存
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## 切り抜いた部分を削除する

フレーム内の画像の切り抜かれた部分を削除したい場合は、[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)メソッドを使用できます。このメソッドは、切り抜かれた画像または切り抜きが不要な場合は元の画像を返します。

このC#コードはその操作を示します：

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のスライドからピクチャーフレームを取得
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ピクチャーフレーム画像の切り抜かれた部分を削除し、切り抜かれた画像を返す
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 結果を保存
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)メソッドは、切り抜かれた画像をプレゼンテーションの画像コレクションに追加します。この画像が処理された[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)内でのみ使用される場合、この設定によりプレゼンテーションのサイズを削減できます。そうでなければ、結果として得られるプレゼンテーション内の画像の数は増加します。

このメソッドはWMF/EMFメタファイルをラスタPNG画像に変換します。

{{% /alert %}}

## **アスペクト比をロックする**

形状が画像を含む場合、画像のサイズを変更してもアスペクト比を保持するには、[IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/)プロパティを使用して*アスペクト比をロック*設定を指定できます。

このC#コードは、形状のアスペクト比をロックする方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // リサイズ時にアスペクト比を保持するようにシェイプを設定
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="注意" color="warning" %}} 

この*アスペクト比をロック*設定は、形状のアスペクト比のみを保持し、含まれる画像のアスペクト比は保持しません。

{{% /alert %}}

## **StretchOffプロパティを使用する**

[StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight,](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright)および[StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom)プロパティを[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat)インターフェースと[PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat)クラスから使用すると、塗りつぶし矩形を指定できます。

画像の拡張が指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプの境界ボックスの対応する辺からのパーセンテージオフセットによって定義されます。正のパーセンテージは内側を指定し、負のパーセンテージは外側を指定します。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 四角形の`AutoShape`を追加します。 
4. 画像を作成します。
5. シェイプの塗りつぶしタイプを設定します。
6. シェイプの画像塗りつぶしモードを設定します。
7. シェイプを塗りつぶすためにセット画像を追加します。
8. シェイプの境界ボックスの対応する辺からの画像オフセットを指定します。
9. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このC#コードは、StretchOffプロパティを使用したプロセスを示しています：

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 形状の内部から各辺に向かって画像を拡張する
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```