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
description: "Aspose.Slides for .NET を使用して PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---

Picture Frame（画像フレーム）は、画像を含むシェイプです—フレームに入った写真のようなものです。  

Picture Frame を使用してスライドに画像を追加できます。この方法で、Picture Frame を書式設定することで画像の書式設定が行えます。  

{{% alert  title="ヒント" color="primary" %}} 
Aspose は無料コンバータ—[JPEG を PowerPoint に変換](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG を PowerPoint に変換](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、画像から迅速にプレゼンテーションを作成できます。  
{{% /alert %}} 

## **Picture Frame の作成**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドのインデックスから参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C# のコード例は、画像フレームの作成方法を示しています:  
```c#
 // PPTX ファイルを表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide slide = pres.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 同じ高さと幅で画像フレームを追加
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 画像フレームにいくつかの書式設定を適用
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // プレゼンテーションを PPTX ファイルに保存
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" %}} 
画像フレームを使用すると、画像を元にプレゼンテーションスライドを迅速に作成できます。Picture Frame と Aspose.Slides の保存オプションを組み合わせることで、画像の入出力操作を操作し、フォーマット間の変換が可能になります。以下のページも参考になるでしょう：変換 [画像を JPG に](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；変換 [JPG を画像に](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；変換 [JPG を PNG に](https://products.aspose.com/slides/net/conversion/jpg-to-png/)；変換 [PNG を JPG に](https://products.aspose.com/slides/net/conversion/png-to-jpg/)；変換 [PNG を SVG に](https://products.aspose.com/slides/net/conversion/png-to-svg/)；変換 [SVG を PNG に](https://products.aspose.com/slides/net/conversion/svg-to-png/)。  
{{% /alert %}}

## **相対スケール付き Picture Frame の作成**

画像の相対スケールを変更することで、より複雑な画像フレームを作成できます。  

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドのインデックスから参照を取得します。  
3. プレゼンテーションの画像コレクションに画像を追加します。  
4. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。  
5. 画像フレーム内で画像の相対的な幅と高さを指定します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C# のコード例は、相対スケール付き画像フレームの作成方法を示しています:  
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

[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。  
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

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for .NET は元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) を特定し、基になる [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存します。  

以下のコード例は、Picture Frame から SVG 画像を抽出する方法を示しています:  
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

Aspose.Slides は画像に適用された透明度効果を取得できます。この C# のコードはその操作を示しています:  
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


{{% alert title="ヒント" color="primary" %}} 
画像に適用されたすべての効果は [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/) で確認できます。  
{{% /alert %}}

## **Picture Frame の書式設定**

Aspose.Slides は Picture Frame に適用できる多くの書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて Picture Frame を変更できます。  

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。  
2. スライドのインデックスから参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) に画像を追加して、[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) オブジェクトを作成します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられた [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) オブジェクトが提供する [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) メソッドを使用して、画像の幅と高さに基づく `PictureFrame` を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 画像フレームの線色を設定します。  
8. 画像フレームの線幅を設定します。  
9. 正の値または負の値を指定して画像フレームを回転させます。  
   * 正の値は画像を時計回りに回転させます。  
   * 負の値は画像を反時計回りに回転させます。  
10. 画像フレーム（画像を含む）をスライドに追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C# のコードは、Picture Frame の書式設定プロセスを示しています:  
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = presentation.Slides[0];

    // 画像を読み込み、プレゼンテーションの画像コレクションに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像と同等の高さと幅で画像フレームを追加します
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


{{% alert title="ヒント" color="primary" %}} 
Aspose は最近、[無料 Collage Maker](https://products.aspose.app/slides/collage) を開発しました。JPG/JPEG や PNG 画像の結合、写真からのグリッド作成が必要な場合はこのサービスをご利用ください。  
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションのサイズを抑えるために、画像（またはビデオ）を埋め込むのではなく、リンクとして追加できます。この C# のコードは、プレースホルダーに画像とビデオを追加する方法を示しています:  
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


## **画像をトリミングする**

この C# のコードは、スライド上の既存画像をトリミングする方法を示しています:  
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

フレーム内の画像のトリミング領域を削除したい場合は、[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドを使用できます。このメソッドは、トリミングが不要な場合は元の画像を返します。  

この C# のコードは、その操作をデモンストレーションしています:  
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のスライドから PictureFrame を取得します
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // PictureFrame の画像のトリミング領域を削除し、トリミングされた画像を返します
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 結果を保存します
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="注" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) メソッドは、トリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理対象の [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) のみで使用されている場合、プレゼンテーションサイズの削減につながります。そうでない場合、結果のプレゼンテーション内の画像数が増加します。  

このメソッドは、トリミング操作中に WMF/EMF メタファイルをラスタ PNG 画像に変換します。  
{{% /alert %}}

## **画像を圧縮する**

[`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。  
このメソッドは、シェイプのサイズと指定された解像度に基づいて画像サイズを縮小し、必要に応じてトリミング領域を削除します。  

PowerPoint の **[画像の書式設定] → [画像の圧縮] → [解像度]** 機能と同様の動作を行います。  

以下の C# の例は、対象の解像度を指定して画像を圧縮し、必要に応じてトリミング領域を削除する方法を示しています:  
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // スライドから PictureFrame を取得します
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 目標解像度 150 DPI（Web 解像度）で画像を圧縮し、トリミング領域を削除します
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


または、カスタム DPI 値を直接指定する場合:  
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPPictureFrame;

    // 画像を 150 DPI（ウェブ解像度）に圧縮し、トリミング領域を削除します
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="注" color="warning" %}} 
このメソッドは、シェイプのサイズと提供された DPI に基づき、画像を低解像度に変換します。トリミング領域は削除可能です。  
画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。JPEG は解像度に応じて品質が若干低下することがありますが、PowerPoint と同様の挙動です。  
{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのサイズを変更してもアスペクト比を維持したい場合は、[IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) プロパティを使用して *ロック アスペクト比* 設定を行えます。  

この C# のコードは、シェイプのアスペクト比をロックする方法を示しています:  
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


{{% alert title="注" color="warning" %}} 
この *ロック アスペクト比* 設定は、シェイプのアスペクト比のみを保持し、シェイプ内の画像自体のアスペクト比は変更しません。  
{{% /alert %}}

## **StretchOff プロパティを使用する**

[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) クラスの [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright)、[StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) プロパティを使用すると、塗りつぶし矩形を指定できます。  

画像の伸縮が指定されると、ソース矩形が指定された塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。  

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。  
2. スライドのインデックスから参照を取得します。  
3. 四角形 `AutoShape` を追加します。  
4. 画像を作成します。  
5. シェイプの塗りつぶしタイプを設定します。  
6. シェイプの画像塗りつぶしモードを設定します。  
7. 画像を設定してシェイプを塗りつぶします。  
8. 画像のオフセットをシェイプのバウンディングボックスの対応する辺から指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。  

この C# のコードは、StretchOff プロパティを使用したプロセスを示しています:  
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // シェイプ本体の各側から画像を伸ばすように設定
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**PictureFrame がサポートする画像フォーマットはどれですか？**  
Aspose.Slides は、[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じて、ラスター画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）をサポートします。サポートされるフォーマットの一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスはどうなりますか？**  
画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供しており、ファイルサイズ削減に役立ちます。

**画像オブジェクトを誤って移動/サイズ変更されないようにロックするには？**  
[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) を使用できます（例: 移動やサイズ変更を無効化）。ロック機能の詳細は別の記事「[プレゼンテーションへの保護の適用](/slides/ja/net/applying-protection-to-presentation/)」をご参照ください。さまざまなシェイプタイプでサポートされています。

**SVG ベクターの忠実度は PDF/画像へのエクスポート時に保持されますか？**  
Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) から元のベクター SVG を抽出できます。PDF やラスタ形式へのエクスポート時、設定に応じてラスタライズされることがありますが、抽出時にはベクターデータが保持されます。  