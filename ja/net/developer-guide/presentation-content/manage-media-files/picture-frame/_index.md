---
title: .NET でプレゼンテーションの画像フレームを管理する
linktitle: 画像フレーム
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
- ラスター画像
- ベクター画像
- 画像をトリミング
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
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---
## **導入**

画像フレームは画像を含むシェイプです—フレーム内の画像のようなものです。

スライドに画像を画像フレームを通して追加できます。このように、画像フレームの書式設定を行うことで画像の書式設定が可能です。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料のコンバータ —[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) および [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) — を提供しており、画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation ](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation)クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage) オブジェクトを作成します。このオブジェクトはシェイプの塗りつぶしに使用されます。 
4. 画像の幅と高さを指定します。 
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe) を作成します。 
6. スライドに画像フレーム（画像を含む）を追加します。 
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。 

この C# コードは画像フレームの作成方法を示しています：

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = pres.Slides[0];

    // 画像をロードし、プレゼンテーションの画像コレクションに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 同じ高さと幅の画像フレームを追加します
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

画像フレームを使用すると、画像に基づいたプレゼンテーションスライドを素早く作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像を別の形式に変換する入出力操作を操作できます。以下のページもご参照ください：[画像を JPG に変換](https://products.aspose.com/slides/ja/net/conversion/image-to-jpg/); [JPG を画像に変換](https://products.aspose.com/slides/ja/net/conversion/jpg-to-image/); [JPG を PNG に変換](https://products.aspose.com/slides/ja/net/conversion/jpg-to-png/), [PNG を JPG に変換](https://products.aspose.com/slides/ja/net/conversion/png-to-jpg/); [PNG を SVG に変換](https://products.aspose.com/slides/ja/net/conversion/png-to-svg/), [SVG を PNG に変換](https://products.aspose.com/slides/ja/net/conversion/svg-to-png/)。 

{{% /alert %}}

## **相対スケールを使用した画像フレームの作成**

画像の相対スケーリングを変更することで、より複雑な画像フレームを作成できます。 

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションの画像コレクションに画像を追加します。 
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage) オブジェクトを作成します。このオブジェクトはシェイプの塗りつぶしに使用されます。 
5. 画像フレーム内の画像の相対幅と相対高さを指定します。 
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。 

この C# コードは相対スケールを使用した画像フレームの作成方法を示しています：

```c#
 // PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 画像をロードし、プレゼンテーションの画像コレクションに追加します
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

## **画像フレームからラスター画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出し、PNG 形式で保存する方法を示しています。

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

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれる場合、Aspose.Slides for .NET は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査することで、各 [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

以下のコード例は、画像フレームから SVG 画像を抽出する方法を示しています：

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

Aspose.Slides を使用すると、画像に適用された透明効果を取得できます。この C# コードはその操作を示しています：

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

## **画像の明るさとコントラストを取得する**

Aspose.Slides を使用すると、画像に適用された明るさとコントラスト効果を取得できます。[ILuminance](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iluminance/) インターフェイスはこの画像変換効果を表します。

この C# コードは、画像フレームから明るさとコントラストの設定を取得する方法を示しています：

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="primary" %}} 
画像に適用されたすべての効果は [Aspose.Slides.Effects](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/) にあります。 
{{% /alert %}}

## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。

1. [Presentation](http://www.aspose.com/api/net/slides/ja/aspose.slides/) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage) オブジェクトを作成します。このオブジェクトはシェイプの塗りつぶしに使用されます。 
4. 画像の幅と高さを指定します。 
5. 参照されたスライドに関連付けられた [IShapes](http://www.aspose.com/api/net/slides/ja/aspose.slides/ishapecollection) オブジェクトが提供する [AddPictureFrame](http://www.aspose.com/api/net/slides/ja/aspose.slides/ishapecollection/methods/addpictureframe) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。 
6. スライドに画像フレーム（画像を含む）を追加します。 
7. 画像フレームの線の色を設定します。 
8. 画像フレームの線幅を設定します。 
9. 正または負の値を指定して画像フレームを回転させます。 
   * 正の値は画像を時計回りに回転させます。 
   * 負の値は画像を反時計回りに回転させます。 
10. スライドに画像フレーム（画像を含む）を追加します。 
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。 

この C# コードは画像フレームの書式設定プロセスを示しています：

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = presentation.Slides[0];

    // 画像をロードし、プレゼンテーションの画像コレクションに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像と同じ高さと幅の画像フレームを追加します
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 画像フレームにいくつかの書式設定を適用します
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションを PPTX ファイルに保存します
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/ja/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/ja/collage/photo-grid) したりする必要がある場合は、このサービスをご利用ください。 

{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンクを介して画像（または動画）を追加できます。この C# コードはプレースホルダーに画像と動画を追加する方法を示しています：

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

この C# コードはスライド上の既存画像をトリミングする方法を示しています：

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

フレーム内に含まれる画像のトリミング領域を削除したい場合は、[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元画像、必要な場合はトリミングされた画像を返します。

この C# コードはその操作を示しています：

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

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションサイズを削減できます。そうでない場合、結果として得られるプレゼンテーションの画像数は増加します。

このメソッドはトリミング操作中に WMF/EMF メタファイルをラスター PNG 画像に変換します。 

{{% /alert %}}

## **画像の圧縮**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/compressimage/) メソッドを使用してプレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいて画像のサイズを縮小し、トリミング領域を削除するオプションも提供します。

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の C# 例は、対象解像度を指定し、必要に応じてトリミング領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています：

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を 150 DPI（Web 解像度）のターゲット解像度で圧縮し、トリミング領域を削除します。
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // 圧縮の結果を確認します。
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

またはカスタム DPI 値を直接使用する場合：

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を 150 DPI（ウェブ解像度）に圧縮し、トリミング領域を削除します。
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

このメソッドはシェイプのサイズと提供された DPI に基づいて画像を低解像度に変換します。トリミング領域も削除してファイルサイズを最適化できます。画像がメタファイル（WMF/EMF）や SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持またはわずかに低下します。これは PowerPoint が高解像度 JPEG を処理する方法と同様です。 

{{% /alert %}}

## **アスペクト比のロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合、[IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframelock/aspectratiolocked/) プロパティを使用して *Lock Aspect Ratio* 設定を行えます。 

この C# コードはシェイプのアスペクト比をロックする方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // リサイズ時に形状がアスペクト比を保持するように設定します
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプ内の画像自体のアスペクト比は保持しません。 

{{% /alert %}}

## **StretchOff プロパティの使用**

[StretchOffsetLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsetright) および [StretchOffsetBottom](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) プロパティは、[IPictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat) クラスで使用でき、塗りつぶし矩形を指定できます。

画像に対してストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせて拡大縮小されます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](http://www.aspose.com/api/net/slides/ja/aspose.slides/) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. 矩形 `AutoShape` を追加します。 
4. 画像を作成します。 
5. シェイプの塗りつぶしタイプを設定します。 
6. シェイプの画像塗りつぶしモードを設定します。 
7. シェイプを塗りつぶす画像を追加します。 
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。 
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。 

この C# コードは StretchOff プロパティを使用したプロセスを示しています：

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 形状本体の各側から画像を伸ばすように設定します
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

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じて、ラスター画像 (PNG、JPEG、BMP、GIF など) とベクター画像 (例: SVG) の両方をサポートしています。サポートされる形式のリストは、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが常にアクセス可能である必要があります。Aspose.Slides はリンクで画像を追加する機能を提供しており、ファイルサイズを削減できます。

**画像オブジェクトが誤って移動・サイズ変更されないようにロックする方法はありますか？**

[PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/pictureframelock/) を使用できます（例: 移動やサイズ変更を無効にする）。このロック機構は、別の記事の [protection article](/slides/ja/net/applying-protection-to-presentation/) で説明されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

**SVG ベクターの忠実度は、プレゼンテーションを PDF/画像にエクスポートする際に保持されますか？**

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) から元のベクターとして SVG を抽出できます。PDF (/slides/ja/net/convert-powerpoint-to-pdf/) やラスター形式 (/slides/ja/net/convert-powerpoint-to-png/) にエクスポートする場合、エクスポート設定に応じてラスタライズされることがありますが、抽出時にベクターが保持されていることが確認できます。