---
title: 画像フレーム
type: docs
weight: 10
url: /ja/net/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- 画像をトリミング
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 画像効果
- アスペクト比
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションに画像フレームを追加"
---

画像フレームは画像を含む形状で、フレーム内の写真のようなものです。

画像フレームを使用してスライドに画像を追加できます。この方法では、画像フレームの書式設定により画像の書式設定が行えます。

{{% alert  title="Tip" color="primary" %}} 
Asposeは無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)と[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーション オブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加して[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。 
4. 画像の幅と高さを指定します。 
5. 参照されたスライドに関連付けられたシェイプ オブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) を作成します。 
6. スライドに画像フレーム（画像を含む）を追加します。 
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

```c#
// PPTX ファイルを表す Presentation クラスをインスタンス化します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = pres.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 同じ高さと幅で画像フレームを追加します
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 画像フレームにいくつかの書式設定を適用します
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションを PPTX ファイルに保存します
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" %}} 
画像フレームを使用すると、画像に基づくプレゼンテーション スライドを迅速に作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像形式の変換など入出力操作を操作できます。以下のページも参考になるでしょう: 変換 [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 
{{% /alert %}}

## **相対スケール付き画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションの画像コレクションに画像を追加します。 
4. プレゼンテーション オブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加して[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。 
5. 画像フレーム内で画像の相対的な幅と高さを指定します。 
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

```c#
// PPTX ファイルを表す Presentation クラスをインスタンス化します
using (Presentation presentation = new Presentation())
{
    // 画像を読み込み、プレゼンテーションの画像コレクションに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // スライドに画像フレームを追加します
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 相対スケールの幅と高さを設定します
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // プレゼンテーションを保存します
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```


## **画像フレームからラスタ画像を抽出する**

画像フレーム([PictureFrame])オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出して PNG 形式で保存する方法を示しています。  
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


## **画像フレームから SVG 画像を抽出する**

プレゼンテーションに [PictureFrame] シェイプ内に配置された SVG グラフィックが含まれる場合、Aspose.Slides for .NET は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査して各[PictureFrame] を特定し、基になる[IPPImage] が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。  

```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```


## **画像の透明度を取得する**

Aspose.Slides では、画像に適用された透明度効果を取得できます。この C# コードはその操作を示しています。  
```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```


{{% alert color="primary" %}} 
画像に適用されたすべてのエフェクトは [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/) で確認できます。 
{{% /alert %}}

## **画像フレームの書式設定**

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーション オブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加して[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。 
4. 画像の幅と高さを指定します。 
5. 参照されたスライドに関連付けられた[IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) オブジェクトが提供する[AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。 
6. スライドに画像フレーム（画像を含む）を追加します。 
7. 画像フレームの線の色を設定します。 
8. 画像フレームの線幅を設定します。 
9. 正の値または負の値を指定して画像フレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。 
10. スライドに画像フレーム（画像を含む）を再度追加します。 
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

```c#
// PPTX ファイルを表す Presentation クラスをインスタンス化します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = presentation.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像と同じ高さと幅で画像フレームを追加します
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 画像フレームにいくつかの書式設定を適用します
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションを PPTX ファイルに書き出します
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を提供開始しました。JPG/JPEG もしくは PNG 画像を結合したり、写真からグリッドを作成したりしたい場合はこのサービスをご利用ください。 
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込むのではなくリンク経由で画像（またはビデオ）を追加できます。この C# コードはプレースホルダーに画像とビデオを追加する方法を示しています。  
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


## **画像のトリミング**

この C# コードはスライド上の既存画像をトリミングする方法を示しています。  
```c#
using (Presentation presentation = new Presentation())
{
    // 新しい画像オブジェクトを作成します
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // スライドに PictureFrame を追加します
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // 画像をトリミングします（パーセンテージ値）
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // 結果を保存します
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```


## **画像フレームのトリミング領域を削除する**

画像フレーム内のトリミングされた領域を削除したい場合は、[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元の画像を、トリミングが必要な場合はトリミングされた画像を返します。  
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // PictureFrame 画像のトリミング領域を削除し、トリミングされた画像を返します
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 結果を保存します
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。対象の [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) のみで画像が使用されている場合、この設定によりプレゼンテーションのサイズが削減されます。そうでない場合は、結果のプレゼンテーションの画像数が増加します。

このメソッドはトリミング処理で WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **画像を圧縮する**

[`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) メソッドを使用してプレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいて画像サイズを縮小し、必要に応じてトリミング領域を削除します。

PowerPoint の **図の書式 → 画像の圧縮 → 解像度** 機能と同様に、画像のサイズと解像度を調整します。

以下の C# 例は、対象解像度を指定し、オプションでトリミング領域を削除して画像を圧縮する方法を示しています。  
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // スライドから PictureFrame を取得します
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を 150 DPI（Web 解像度）のターゲット解像度で圧縮し、トリミング領域を削除します
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // 圧縮の結果を確認します
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }
}
```


またはカスタム DPI 値を直接指定する場合:  
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を 150 DPI（Web 解像度）に圧縮し、トリミング領域を削除します
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 
このメソッドはシェイプのサイズと提供された DPI に基づき画像を低解像度に変換します。トリミング領域も削除してファイルサイズを最適化できます。画像がメタファイル (WMF/EMF) または SVG の場合は圧縮は適用されません。JPEG は解像度に応じて品質が維持または若干低下します。 
{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのサイズ変更後もアスペクト比を保持したい場合は、[IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) プロパティを使用して「アスペクト比をロック」設定を行います。 

この C# コードはシェイプのアスペクト比をロックする方法を示しています。  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // リサイズ時に形状のアスペクト比を保持するように設定します
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 
この「アスペクト比をロック」設定はシェイプのアスペクト比のみを保持し、内部の画像自体の比率は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) および [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) プロパティを [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) クラスで使用すると、塗りつぶし矩形を指定できます。

画像にストレッチ指定がある場合、ソース矩形は指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. 四角形 `AutoShape` を追加します。 
4. 画像を作成します。 
5. シェイプの塗りつぶしタイプを設定します。 
6. シェイプの画像塗りつぶしモードを設定します。 
7. 塗りつぶしに使用する画像を設定します。 
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。 
9. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

この C# コードは StretchOff プロパティを使用したプロセスを示しています:  
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // シェイプ本体の各側面から画像が伸びるように設定します
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**画像フレームでサポートされている画像形式はどのように確認できますか？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じて、ラスタ画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）をサポートしています。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能とほぼ一致します。

**多数の大容量画像を追加すると PPTX のサイズとパフォーマンスはどう影響しますか？**  
画像を埋め込むとファイルサイズとメモリ使用量が増加します。リンクで画像を追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが利用可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供し、ファイルサイズ削減に役立ちます。

**画像オブジェクトの誤操作による移動やサイズ変更を防ぐには？**  
[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 用の[shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) を使用します（例: 移動やサイズ変更を無効化）。ロック機構の詳細は、別の[保護に関する記事](/slides/ja/net/applying-protection-to-presentation/) に記載されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

**SVG ベクターの忠実度は PDF/画像へのエクスポート時に保持されますか？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF（/slides/net/convert-powerpoint-to-pdf/）やラスタ形式（/slides/net/convert-powerpoint-to-png/）へのエクスポート時は、エクスポート設定に応じてラスタ化される場合がありますが、抽出動作により元の SVG がベクターとして保持されていることが確認できます。