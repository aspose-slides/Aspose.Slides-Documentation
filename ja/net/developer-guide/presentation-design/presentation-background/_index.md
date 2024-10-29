---
title: プレゼンテーションの背景
type: docs
weight: 20
url: /ja/net/presentation-background/
keywords:
- PowerPoint 背景
- 背景を設定
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションの背景を設定"
---

単色、グラデーションカラー、そして画像は、スライドの背景画像としてよく使われます。背景は、**通常のスライド**（単一スライド）または**マスタースライド**（複数スライド）に設定できます。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **通常のスライドの背景に単色を設定する**

Aspose.Slidesを使用すると、プレゼンテーション内の特定のスライドの背景を単色に設定することができます（そのプレゼンテーションにマスタースライドが含まれていても）。背景の変更は、選択されたスライドにのみ影響します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. スライド背景の[FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/)列挙型を`Solid`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/)によって公開される[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/)プロパティを使用して、背景用の単色を指定します。
5. 修正されたプレゼンテーションを保存します。

このC#コードは、通常のスライドの背景に単色（青色）を設定する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のISlideの背景色を青に設定
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
    
    // プレゼンテーションをディスクに書き込む
    pres.Save("ContentBG_out.pptx", SaveFormat.Pptx);
}
```

## **マスタースライドの背景に単色を設定する**

Aspose.Slidesを使用すると、プレゼンテーション内のマスタースライドの背景を単色に設定することができます。マスタースライドは、すべてのスライドの書式設定設定を含むテンプレートとして機能します。したがって、マスタースライドの背景として単色を選択すると、その新しい背景はすべてのスライドに使用されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. マスタースライド（`Masters`）の[BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. マスタースライド背景の[FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/)列挙型を`Solid`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/)によって公開される[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/)プロパティを使用して、背景用の単色を指定します。
5. 修正されたプレゼンテーションを保存します。

このC#コードは、プレゼンテーションのマスタースライドの背景に単色（フォレストグリーン）を設定する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // マスターISlideの背景色をフォレストグリーンに設定
    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
    pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // プレゼンテーションをディスクに書き込む
    pres.Save("SetSlideBackgroundMaster_out.pptx", SaveFormat.Pptx);

}
```

## **スライドの背景にグラデーションカラーを設定する**

グラデーションは、色の徐々な変化に基づくグラフィカルな効果です。スライドの背景としてグラデーションカラーを使用すると、プレゼンテーションが芸術的でプロフェッショナルに見えます。Aspose.Slidesを使用すると、プレゼンテーション内のスライドの背景としてグラデーションカラーを設定することができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. マスタースライド背景の[FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/)列挙型を`Gradient`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/)によって公開される[GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/)プロパティを使用して、好みのグラデーション設定を指定します。
5. 修正されたプレゼンテーションを保存します。

このC#コードは、スライドの背景にグラデーションカラーを設定する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成
using (Presentation pres = new Presentation("SetBackgroundToGradient.pptx"))
{

    // 背景にグラデーション効果を適用
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
    pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // プレゼンテーションをディスクに書き込む
    pres.Save("ContentBG_Grad_out.pptx", SaveFormat.Pptx);
}
```

## **スライドの背景に画像を設定する**

単色やグラデーションカラーの他に、Aspose.Slidesを使用すると、プレゼンテーション内のスライドの背景として画像を設定することもできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. マスタースライド背景の[FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/)列挙型を`Picture`に設定します。
4. スライド背景に使用したい画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/)によって公開される[PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/)プロパティを使用して、画像を背景として設定します。
7. 修正されたプレゼンテーションを保存します。

このC#コードは、スライドの背景に画像を設定する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成
using (Presentation pres = new Presentation("SetImageAsBackground.pptx"))
{
    // 背景画像の条件を設定
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
    pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // 画像をロードし、プレゼンテーションの画像コレクションに追加
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // プレゼンテーションをディスクに書き込む
    pres.Save("ContentBG_Img_out.pptx", SaveFormat.Pptx);
}
```

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を目立たせることができます。このC#コードは、スライドの背景画像の透明度を変更する方法を示しています：

```c#
var transparencyValue = 30; // 例えば

// 画像変換操作のコレクションを取得
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// 固定のパーセンテージでの透明度効果を見つける。
var transparencyOperation = null as AlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is AlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// 新しい透明度の値を設定する。
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **スライドの背景の値を取得する**

Aspose.Slidesは、スライド背景の効果的な値を取得するために[IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/)インターフェースを提供しています。このインターフェースには、効果的な[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat)と効果的な[EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/)に関する情報が含まれています。

[BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/)クラスの[Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/background/)プロパティを使用して、スライド背景の効果的な値を取得できます。

このC#コードは、スライドの効果的な背景値を取得する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成
Presentation pres = new Presentation("SamplePresentation.pptx");

IBackgroundEffectiveData effBackground = pres.Slides[0].Background.GetEffective();

if (effBackground.FillFormat.FillType == FillType.Solid)
    Console.WriteLine("塗りつぶし色: " + effBackground.FillFormat.SolidFillColor);
else
    Console.WriteLine("塗りつぶしタイプ: " + effBackground.FillFormat.FillType);
```