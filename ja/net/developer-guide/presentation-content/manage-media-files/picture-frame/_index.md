---
title: .NET のプレゼンテーションで画像フレームを管理する
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
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---

Picture frame は画像を含む形状で、フレーム内の写真のようなものです。 

スライドに画像を Picture frame を介して追加できます。この方法では、Picture frame の書式設定により画像をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ―を提供しています—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—これにより画像からプレゼンテーションを素早く作成できます。 
{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class のインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。 
4. 画像の幅と高さを指定します。 
5. 参照スライドに関連付けられた shape オブジェクトが公開する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) を作成します。 
6. スライドに画像を含む Picture frame を追加します。 
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

この C# コードは Picture frame の作成方法を示しています:
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
Picture frame を使用すると、画像に基づいたプレゼンテーションスライドをすばやく作成できます。Picture frame と Aspose.Slides の保存オプションを組み合わせることで、画像のフォーマット変換など入力/出力操作を操作できます。以下のページも参照してください: 変換 [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)、変換 [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)、変換 [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。 
{{% /alert %}}

## **相対スケールを使用した Picture Frame の作成**

画像の相対スケーリングを変更することで、より複雑な Picture frame を作成できます。 

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションの画像コレクションに画像を追加します。 
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。 
5. Picture frame 内で画像の相対的な幅と高さを指定します。 
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

この C# コードは相対スケールを使用した Picture frame の作成方法を示しています:
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


## **Picture Frame からラスター画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。
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


## **Picture Frame から SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for .NET は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査して各 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) が SVG コンテンツを保持しているかを確認し、ネイティブ SVG 形式でディスクまたはストリームに保存します。

以下のコード例は Picture frame から SVG 画像を抽出する方法を示しています:
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

Aspose.Slides を使用すると、画像に適用された透明度効果を取得できます。この C# コードはその操作を示しています:
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
画像に適用可能なすべての効果は [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/) で確認できます。 
{{% /alert %}}

## **Picture Frame の書式設定**

Aspose.Slides は Picture frame に適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて Picture frame を変更できます。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加し、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。 
4. 画像の幅と高さを指定します。 
5. 参照スライドに関連付けられた [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) オブジェクトが公開する [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。 
6. スライドに画像を含む Picture frame を追加します。 
7. Picture frame の線色を設定します。 
8. Picture frame の線幅を設定します。 
9. 正の値または負の値を指定して Picture frame を回転させます。 
   * 正の値は画像を時計回りに回転させます。 
   * 負の値は画像を反時計回りに回転させます。 
10. Picture frame（画像を含む）をスライドに再度追加します。 
11. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

この C# コードは Picture frame の書式設定プロセスを示しています:
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

    // 画像と同じ高さと幅で画像フレームを追加します
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 画像フレームにいくつかの書式設定を適用します
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションを書き出します
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像を [結合](https://products.aspose.app/slides/collage/jpg) したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid) したりしたい場合に、このサービスをご利用ください。 
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズが大きくなるのを防ぐため、画像（または動画）をファイルとして埋め込む代わりにリンクで追加できます。この C# コードはプレースホルダーに画像と動画を追加する方法を示しています:
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


## **画像のクロップ**

この C# コードはスライド上の既存画像をクロップする方法を示しています:
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


## **Picture のクロップ領域を削除する**

フレームに含まれる画像のクロップ領域を削除したい場合は、[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドは、クロップが不要な場合は元の画像を、クロップが必要な場合はクロップ後の画像を返します。

この C# コードはその操作を示しています:
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // PictureFrame の画像のトリミングされた領域を削除し、トリミングされた画像を返します
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 結果を保存します
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドはクロップされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理対象の [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) のみで使用されている場合、これによりプレゼンテーションのサイズを削減できます。そうでない場合は、結果として生成されるプレゼンテーション内の画像数が増加します。

このメソッドはクロップ処理中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。 
{{% /alert %}}

## **画像の圧縮**

[`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。このメソッドは、シェイプサイズと指定された解像度に基づき画像サイズを縮小し、必要に応じてクロップ領域を削除するオプションを提供します。

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の C# 例は、対象解像度を指定し、必要に応じてクロップ領域を削除してプレゼンテーション内の画像を圧縮する方法を示しています:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // スライドから PictureFrame を取得します
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を 150 DPI（ウェブ解像度）のターゲット解像度で圧縮し、トリミング領域を削除します
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


またはカスタム DPI 値を直接使用する例:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 画像を 150 DPI（ウェブ解像度）に圧縮し、トリミング領域を削除します
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 
このメソッドはシェイプサイズと指定された DPI に基づき画像を低解像度に変換します。クロップ領域も削除してファイルサイズを最適化できます。画像がメタファイル（WMF/EMF）または SVG の場合は圧縮は適用されません。また、JPEG の品質は解像度に応じて保持またはわずかに低下します（PowerPoint の動作と同様）。 
{{% /alert %}}

## **アスペクト比のロック**

画像を含むシェイプのサイズを変更してもアスペクト比を保持したい場合、[IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) プロパティを使用して *Lock Aspect Ratio* 設定を有効にできます。 

この C# コードはシェイプのアスペクト比をロックする方法を示しています:
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
この *Lock Aspect Ratio* 設定はシェイプ自体のアスペクト比のみを保持し、シェイプ内の画像のアスペクト比は保持しません。 
{{% /alert %}}

## **StretchOff プロパティの使用**

[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright)、[StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) プロパティを使用すると、塗りつぶし矩形を指定できます。

画像が伸縮指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。 
2. インデックスを使用してスライドの参照を取得します。 
3. 長方形 `AutoShape` を追加します。 
4. 画像を作成します。 
5. シェイプの塗りつぶしタイプを設定します。 
6. シェイプの画像塗りつぶしモードを設定します。 
7. シェイプを塗りつぶす画像を設定します。 
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

    // シェイプ本体の各側から画像を伸縮させるように設定します
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**How can I find out which image formats are supported for PictureFrame?**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じて、ラスター画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）の両方をサポートしています。サポートされるフォーマットの一覧は、スライドおよび画像変換エンジンの機能と概ね一致します。

**How will adding dozens of large images affect PPTX size and performance?**  
大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが利用可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供し、ファイルサイズ削減に役立ちます。

**How can I lock an image object from accidental moving/resizing?**  
[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) に対して [shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) を使用できます（例: 移動やリサイズの無効化）。ロック機構は別記事の [protection article](/slides/ja/net/applying-protection-to-presentation/) に記載されており、PictureFrame を含むさまざまなシェイプタイプでサポートされています。

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) から元のベクトルとして SVG を抽出できます。PDF やラスタ形式へのエクスポート時は、エクスポート設定に応じてラスタライズされることがありますが、抽出時の動作により元の SVG がベクトルとして保持されていることが確認できます。