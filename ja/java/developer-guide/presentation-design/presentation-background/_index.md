---
title: プレゼンテーションの背景
type: docs
weight: 20
url: /ja/java/presentation-background/
keywords: "PowerPoint 背景, Javaで背景を設定"
description: "JavaでPowerPointプレゼンテーションの背景を設定"
---

スライドの背景画像には、単色、グラデーションカラー、および画像がよく使用されます。**通常のスライド**（単一スライド）または**マスタースライド**（複数のスライドを一度に）用に背景を設定できます。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **通常のスライドに単色の背景を設定する**

Aspose.Slidesを使用すると、プレゼンテーションの特定のスライドに単色を背景として設定できます（たとえそのプレゼンテーションにマスタースライドが含まれていても）。背景の変更は選択したスライドのみに影響します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. スライドの背景の[FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)列挙型を`Solid`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/)によって公開される[SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--)プロパティを使用して、背景の単色を指定します。
5. 修正したプレゼンテーションを保存します。

このJavaコードは、通常のスライドの背景に単色（青）を設定する方法を示しています：

```java
// Presentationクラスのインスタンスを作成します
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // 最初のISlideの背景色を青に設定します
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // プレゼンテーションをディスクに保存します
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **マスタースライドに単色の背景を設定する**

Aspose.Slidesを使用すると、プレゼンテーションのマスタースライドに単色を背景として設定できます。マスタースライドは、すべてのスライドのフォーマット設定を含み、制御するテンプレートとして機能します。したがって、マスタースライドの背景に単色を選択すると、その新しい背景がすべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. マスタースライド（`Masters`）の[BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. マスタースライドの背景の[FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)列挙型を`Solid`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/)によって公開される[SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--)プロパティを使用して、背景の単色を指定します。
5. 修正したプレゼンテーションを保存します。

このJavaコードは、プレゼンテーションのマスタースライドの背景に単色（フォレストグリーン）を設定する方法を示しています：

```java
// Presentationクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // マスターISlideの背景色をフォレストグリーンに設定します
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // プレゼンテーションをディスクに保存します
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドにグラデーションカラーの背景を設定する**

グラデーションは、色の徐々な変化に基づくグラフィカルな効果です。スライドの背景として使用されるグラデーションカラーは、プレゼンテーションを芸術的かつプロフェッショナルに見せます。Aspose.Slidesでは、プレゼンテーションのスライドにグラデーションカラーを背景として設定できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. マスタースライドの背景の[FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)列挙型を`Gradient`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/)によって公開される[GradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--)プロパティを使用して、好みのグラデーション設定を指定します。
5. 修正したプレゼンテーションを保存します。

このJavaコードは、スライドの背景にグラデーションカラーを設定する方法を示しています：

```java
// Presentationクラスのインスタンスを作成します
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // 背景にグラデーション効果を適用します
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // プレゼンテーションをディスクに保存します
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドに画像を背景として設定する**

単色やグラデーションカラーの背景のほかに、Aspose.Slidesでは、プレゼンテーションのスライドに画像を背景として設定することもできます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/)列挙型を`OwnBackground`に設定します。
3. マスタースライドの背景の[FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)列挙型を`Picture`に設定します。
4. スライド背景として使用したい画像を読み込みます。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/)によって公開される[PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--)プロパティを使用して、画像を背景として設定します。
7. 修正したプレゼンテーションを保存します。

このJavaコードは、スライドの背景に画像を設定する方法を示しています：

```java
// Presentationクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 背景画像の条件を設定します
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // 画像を読み込みます
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // プレゼンテーションの画像コレクションに画像を追加します
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // プレゼンテーションをディスクに保存します
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を目立たせたい場合があります。このJavaコードは、スライドの背景画像の透明度を変更する方法を示しています：

```java
int transparencyValue = 30; // 例えば

// 画像変換操作のコレクションを取得します
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 固定のパーセンテージの透明効果を見つけます。
AlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparencyOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// 新しい透明度の値を設定します。
if (transparencyOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **スライドの背景の値を取得する**

Aspose.Slidesは、スライドの背景の有効な値を取得できる[IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/)インターフェースを提供します。このインターフェースには、有効な[FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--)や有効な[EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--)に関する情報が含まれています。

[BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/)クラスの[Background](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getBackground--)プロパティを使用して、スライドの背景の有効な値を取得できます。

このJavaコードは、スライドの有効な背景値を取得する方法を示しています：

```java
// Presentationクラスのインスタンスを作成します
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("塗りつぶしの色: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("塗りつぶしのタイプ: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```