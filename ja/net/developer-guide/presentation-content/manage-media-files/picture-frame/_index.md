---
title: ".NET のプレゼンテーションで画像フレームを管理する"
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
description: "Aspose.Slides for .NET を使用して PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---
## **概要**

画像フレームは画像を含むシェイプです—フレーム内の画像のようなものです。  
スライドに画像を画像フレーム経由で追加できます。これにより、画像フレームを整形することで画像を整形できます。

{{% alert  title="Tip" color="info" %}} 
Aspose は無料コンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)—を提供しており、画像からプレゼンテーションを迅速に作成できます。 
{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation ](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage) オブジェクトを作成します。これは、プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) に画像を追加して、シェイプの塗りつぶしに使用されます。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この C# コードは、画像フレームの作成方法を示しています：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = pres.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加します
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
画像フレームを使用すると、画像に基づいたプレゼンテーションスライドを迅速に作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像のフォーマット変換などの入出力操作を操作できます。以下のページもご参照ください：[image to JPG](https://products.aspose.com/slides/ja/net/conversion/image-to-jpg/) を変換、[JPG to image](https://products.aspose.com/slides/ja/net/conversion/jpg-to-image/) を変換、[JPG to PNG](https://products.aspose.com/slides/ja/net/conversion/jpg-to-png/) を変換、[PNG to JPG](https://products.aspose.com/slides/ja/net/conversion/png-to-jpg/) を変換、[PNG to SVG](https://products.aspose.com/slides/ja/net/conversion/png-to-svg/) を変換、[SVG to PNG](https://products.aspose.com/slides/ja/net/conversion/svg-to-png/) を変換。 
{{% /alert %}} 

## **相対スケールで画像フレームを作成**

画像の相対スケーリングを変更すると、より複雑な画像フレームを作成できます。  

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage) オブジェクトを作成します。これは、プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) に画像を追加して、シェイプの塗りつぶしに使用されます。  
5. 画像の相対的な幅と高さを画像フレーム内で指定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この C# コードは、相対スケールで画像フレームを作成する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
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

## **画像フレームからラスター画像を抽出**

[PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント "sample.pptx" から画像を抽出し、PNG 形式で保存する方法を示しています。

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **画像フレームから SVG 画像を抽出**

プレゼンテーションに [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) シェイプ内に配置された SVG グラフィックが含まれる場合、Aspose.Slides for .NET は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査することで各 [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

以下のコード例は、画像フレームから SVG 画像を抽出する方法を示しています：

```cs
using Aspose.Slides;

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

## **画像の透明度を取得**

Aspose.Slides は画像に適用された透明度効果を取得できます。この C# コードは操作を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

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

## **画像の明るさとコントラストを取得**

Aspose.Slides は画像に適用された明るさとコントラスト効果を取得できます。[ILuminance](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/iluminance/) インターフェイスはこの画像変換効果を表します。

この C# コードは、画像フレームから明るさとコントラスト設定を取得する方法を示しています：

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

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

{{% alert color="info" %}} 
画像に適用されたすべての効果は [Aspose.Slides.Effects](https://reference.aspose.com/slides/ja/net/aspose.slides.effects/) で確認できます。 
{{% /alert %}}

## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて変更できます。

1. [Presentation](http://www.aspose.com/api/net/slides/ja/aspose.slides/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage) オブジェクトを作成します。これは、プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) に画像を追加して、シェイプの塗りつぶしに使用されます。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapes](http://www.aspose.com/api/net/slides/ja/aspose.slides/ishapecollection) オブジェクトが提供する [AddPictureFrame](http://www.aspose.com/api/net/slides/ja/aspose.slides/ishapecollection/methods/addpictureframe) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線の色を設定します。  
8. 画像フレームの線の幅を設定します。  
9. 正の値または負の値を指定して画像フレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この C# コードは画像フレームの書式設定プロセスを示しています：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = presentation.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像と同等の高さと幅の画像フレームを追加します
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

{{% alert color="info" %}}

Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/ja/collage) を開発しました。JPG/JPEG または PNG 画像の結合、写真からグリッド作成などが必要な場合はこのサービスをご利用ください。 
{{% /alert %}}

## **画像をリンクとして追加**

プレゼンテーションのサイズが大きくなるのを防ぐため、ファイルを直接埋め込む代わりにリンク経由で画像（または動画）を追加できます。この C# コードはプレースホルダーに画像と動画を追加する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // 新しい画像オブジェクトを作成します
    IImage image = Images.FromFile("aspose-logo.jpg");
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

## **画像フレームのトリミング領域を削除**

フレーム内に含まれる画像のトリミング領域を削除したい場合は、[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元の画像を、トリミングが必要な場合はトリミング後の画像を返します。

この C# コードは操作を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // PictureFrame 画像のトリミング領域を削除し、トリミング後の画像を返します
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 結果を保存します
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) のみで使用されている場合、この設定によりプレゼンテーションのサイズが縮小します。そうでない場合、結果のプレゼンテーション内の画像数が増加します。

このメソッドはトリミング処理中に WMF/EMF メタファイルをラスター PNG 画像に変換します。 
{{% /alert %}}

## **画像の圧縮**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/compressimage/) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。このメソッドはシェイプのサイズと指定された解像度に基づいて画像のサイズを縮小し、必要に応じてトリミング領域を削除します。

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の C# 例は、ターゲット解像度を指定し、オプションでトリミング領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を 150 DPI（ウェブ解像度）の目標解像度で圧縮し、トリミング領域を削除します。
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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を150 DPI（ウェブ解像度）に圧縮し、トリミング領域を削除します。
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

このメソッドはシェイプのサイズと提供された DPI に基づいて画像を低解像度に変換します。トリミング領域も削除してファイルサイズを最適化できます。画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて保持またはわずかに低下し、PowerPoint が高解像度 JPEG を扱う方法と同様です。 
{{% /alert %}}

## **アスペクト比の固定**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合は、[IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframelock/aspectratiolocked/) プロパティを使用して *Lock Aspect Ratio* 設定を行います。

この C# コードはシェイプのアスペクト比をロックする方法を示しています：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 形状がリサイズ時にアスペクト比を保持するように設定します
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

この *Lock Aspect Ratio* 設定はシェイプのアスペクト比のみを保持し、シェイプ内の画像自体のアスペクト比は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsetright) および [StretchOffsetBottom](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) プロパティを使用して、塗りつぶし矩形を指定できます。

画像のストレッチが指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを示します。

1. [Presentation](http://www.aspose.com/api/net/slides/ja/aspose.slides/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. 塗りつぶし用に画像を設定します。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この C# コードは StretchOff プロパティを使用したプロセスを示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // シェイプの内部で画像を各側から伸ばすように設定します
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### PictureFrame がサポートする画像形式はどのように確認できますか？

Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じて、ラスター画像（PNG、JPEG、BMP、GIF など）とベクター画像（例：SVG）の両方をサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

### 大量の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが引き続きアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供し、ファイルサイズ削減に役立ちます。

### 画像オブジェクトが誤って移動/リサイズされないようにロックするには？

[PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/pictureframelock/) を使用できます（例：移動やリサイズを無効化）。ロック機構は別の記事の [保護に関する記事](/slides/ja/net/applying-protection-to-presentation/) で説明されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

### プレゼンテーションを PDF/画像にエクスポートする際、SVG ベクトルの忠実度は保持されますか？

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) から元のベクトルとして SVG を抽出できます。PDF やラスター形式へのエクスポート時、エクスポート設定に応じて結果がラスター化されることがありますが、抽出動作により元の SVG がベクトルとして保持されていることが確認できます。