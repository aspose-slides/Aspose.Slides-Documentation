---
title: プレゼンテーションの背景
type: docs
weight: 20
url: /ja/androidjava/presentation-background/
keywords: "PowerPoint 背景, Javaで背景を設定"
description: "JavaでPowerPointプレゼンテーションの背景を設定"
---

スライドの背景画像として、単色、グラデーションカラー、および画像がよく使用されます。背景は、**通常のスライド**（単一のスライド）または**マスター スライド**（複数のスライドを一度に）に設定できます。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **通常のスライドの背景として単色を設定**

Aspose.Slidesを使用すると、プレゼンテーション内の特定のスライドの背景に単色を設定できます（たとえそのプレゼンテーションにマスター スライドが含まれていても）。背景の変更は、選択したスライドにのみ影響します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 列挙型を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) によって公開される [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) プロパティを使用して、背景に単色を指定します。
5. 修正されたプレゼンテーションを保存します。

このJavaコードは、通常のスライドの背景として単色（青）を設定する方法を示しています：

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // 最初の ISlide の背景色を青に設定
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // プレゼンテーションをディスクに保存
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **マスター スライドの背景として単色を設定**

Aspose.Slidesを使用すると、プレゼンテーションのマスター スライドの背景に単色を設定できます。マスター スライドは、すべてのスライドの書式設定設定を含めて制御するテンプレートとして機能します。そのため、マスター スライドの背景として単色を選択すると、その新しい背景がすべてのスライドに使用されます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. マスター スライド（`Masters`）の [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. マスター スライドの背景の [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 列挙型を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) によって公開される [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) プロパティを使用して、背景に単色を指定します。
5. 修正されたプレゼンテーションを保存します。

このJavaコードは、プレゼンテーションのマスター スライドの背景として単色（フォレストグリーン）を設定する方法を示しています：

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // マスター ISlide の背景色をフォレスト グリーンに設定
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // プレゼンテーションをディスクに保存
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドの背景としてグラデーションカラーを設定**

グラデーションは、色の徐々に変化するグラフィカルな効果です。スライドの背景としてグラデーションカラーを使用すると、プレゼンテーションが芸術的でプロフェッショナルに見えます。Aspose.Slidesを使用すると、プレゼンテーションのスライドにグラデーションカラーを背景として設定できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. マスター スライドの背景の [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 列挙型を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) によって公開される [GradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) プロパティを使用して、お好みのグラデーション設定を指定します。
5. 修正されたプレゼンテーションを保存します。

このJavaコードは、スライドの背景としてグラデーションカラーを設定する方法を示しています：

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // 背景にグラデーション効果を適用
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // プレゼンテーションをディスクに保存
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドの背景として画像を設定**

単色やグラデーションカラーに加えて、Aspose.Slidesではプレゼンテーションのスライドの背景として画像を設定することもできます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. マスター スライドの背景の [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 列挙型を `Picture` に設定します。
4. スライドの背景に使用する画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) によって公開される [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) プロパティを使用して、画像を背景として設定します。
7. 修正されたプレゼンテーションを保存します。

このJavaコードは、スライドの背景として画像を設定する方法を示しています：

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 背景画像の条件を設定
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // 画像をロード
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // 画像をプレゼンテーションの画像コレクションに追加
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // プレゼンテーションをディスクに保存
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **背景画像の透過性を変更**

スライドの背景画像の透明度を調整して、スライドの内容が目立つようにする場合があります。このJavaコードは、スライドの背景画像の透明度を変更する方法を示しています：

```java
int transparencyValue = 30; // 例えば

// 画像変換操作のコレクションを取得
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 固定割合の透明度効果を見つける
AlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparencyOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// 新しい透明度値を設定
if (transparencyOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **スライド背景の値を取得**

Aspose.Slidesは、スライドの背景の有効な値を取得するために [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) インターフェースを提供します。このインターフェースは、効果的な [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) および効果的な [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) に関する情報を含んでいます。

[BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/) クラスからの [Background](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getBackground--) プロパティを使用して、スライドの背景の有効な値を取得できます。

このJavaコードは、スライドの有効な背景値を取得する方法を示しています：

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("塗りつぶし色: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("塗りつぶしタイプ: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```