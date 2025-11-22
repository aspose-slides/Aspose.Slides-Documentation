---
title: C# でプレゼンテーションの背景を管理する
linktitle: スライドの背景
type: docs
weight: 20
url: /ja/net/presentation-background/
keywords:
- プレゼンテーション背景
- スライド背景
- 単色
- グラデーションカラー
- 画像背景
- 背景の透明度
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument ファイルに動的な背景を設定する方法を学び、プレゼンテーションを強化するコードヒントをご紹介します。"
---

## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**通常のスライド**（単一のスライド）または**マスタースライド**（複数のスライドに同時に適用）に背景を設定できます。

![PowerPoint 背景](powerpoint-background.png)

## **通常スライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドの背景として単色を設定できます—プレゼンテーションがマスタースライドを使用していても。この変更は選択したスライドのみに適用されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) の [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) プロパティを使用して、単色の背景色を指定します。
5. 変更されたプレゼンテーションを保存します。

以下の C# サンプルは、通常スライドの背景に青色の単色を設定する方法を示します。
```cs
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // スライドの背景色を青に設定します。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // プレゼンテーションをディスクに保存します。
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **マスタースライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景として単色を設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. マスタースライドの [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/)（`masters` 経由）を `OwnBackground` に設定します。
3. マスタースライドの背景の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Solid` に設定します。
4. [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) を使用して、単色の背景色を指定します。
5. 変更されたプレゼンテーションを保存します。

以下の C# サンプルは、マスタースライドの背景に森林緑（forest green）を単色で設定する方法を示します。
```cs
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // マスタースライドの背景色をフォレストグリーンに設定します。
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // プレゼンテーションをディスクに保存します。
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **スライドのグラデーション背景の設定**

グラデーションは、色が徐々に変化することで作成されるグラフィック効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景としてグラデーションカラーを設定できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) の [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) プロパティを使用して、希望のグラデーション設定を構成します。
5. 変更されたプレゼンテーションを保存します。

以下の C# サンプルは、スライドの背景にグラデーションカラーを設定する方法を示します。
```cs
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 背景にグラデーション効果を適用します。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // プレゼンテーションをディスクに保存します。
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **スライドの背景に画像を設定する**

単色やグラデーションだけでなく、Aspose.Slides では画像をスライドの背景として使用できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Picture` に設定します。
4. スライドの背景として使用する画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) の [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) プロパティを使用して、画像を背景として割り当てます。
7. 変更されたプレゼンテーションを保存します。

以下の C# サンプルは、スライドの背景に画像を設定する方法を示します。
```c#
 // Presentation クラスのインスタンスを作成します。
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];

     // 背景画像のプロパティを設定します。
     slide.Background.Type = BackgroundType.OwnBackground;
     slide.Background.FillFormat.FillType = FillType.Picture;
     slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     // 画像をロードします。
     IImage image = Images.FromFile("Tulips.jpg");
     // 画像をプレゼンテーションの画像コレクションに追加します。
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

     // プレゼンテーションをディスクに保存します。
     presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
 }
```


以下のコードサンプルは、背景の塗りつぶしタイプをタイル状画像に設定し、タイルプロパティを変更する方法を示します。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // 背景塗りつぶしに使用する画像を設定します。
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // ピクチャー塗りつぶしモードをタイルに設定し、タイルのプロパティを調整します。
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
Read more: [**テクスチャとしてタイル画像**](/slides/ja/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **背景画像の透過性の変更**

スライドの背景画像の透過性を調整して、スライドのコンテンツを際立たせたい場合があります。以下の C# コードは、スライド背景画像の透過性を変更する方法を示します。
```cs
var transparencyValue = 30; // 例として。

// 画像変換操作のコレクションを取得します。
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **スライドの背景値の取得**

Aspose.Slides は、スライドの有効な背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) インターフェイスを提供します。このインターフェイスは有効な [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) と [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) クラスの `background` プロパティを使用して、スライドの有効な背景を取得できます。

以下の C# サンプルは、スライドの有効な背景値を取得する方法を示します。
```cs
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // マスター、レイアウト、テーマを考慮した有効な背景を取得します。
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **よくある質問**

**カスタム背景をリセットしてテーマ/レイアウトの背景を復元できますか？**

はい。スライドのカスタム塗りつぶしを削除すると、背景は対応する [レイアウト](/slides/ja/net/slide-layout/)/[マスター](/slides/ja/net/slide-master/) スライド（すなわち [テーマ背景](/slides/ja/net/presentation-theme/)）から再び継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドが独自の塗りつぶしを持っている場合、背景は変更されません。背景が [レイアウト](/slides/ja/net/slide-layout/)/[マスター](/slides/ja/net/slide-master/) から継承されている場合は、[新しいテーマ](/slides/ja/net/presentation-theme/) に合わせて更新されます。