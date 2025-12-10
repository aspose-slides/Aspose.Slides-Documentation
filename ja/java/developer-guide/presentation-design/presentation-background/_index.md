---
title: Javaでプレゼンテーションの背景を管理する
linktitle: スライド背景
type: docs
weight: 20
url: /ja/java/presentation-background/
keywords:
- プレゼンテーションの背景
- スライド背景
- 単色
- グラデーションカラー
- 画像背景
- 背景の透明度
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint および OpenDocument ファイルの動的背景を設定する方法を学び、プレゼンテーションを強化するコードヒントをご紹介します。"
---

## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**標準スライド**（単一スライド）または**マスタースライド**（複数のスライドに一括適用）に背景を設定できます。

![PowerPoint 背景](powerpoint-background.png)

## **標準スライドの単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドに単色の背景を設定できます（プレゼンテーションがマスタースライドを使用している場合でも）。この変更は選択したスライドのみに適用されます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) の [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) メソッドを使用して単色の背景色を指定します。
5. 変更後のプレゼンテーションを保存します。

以下の Java サンプルは、標準スライドの背景を青の単色に設定する方法を示しています:
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドの背景色を青に設定します。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // プレゼンテーションをディスクに保存します。
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **マスタースライドの単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドに単色の背景を設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. `getMasters` を介して取得したマスタースライドの [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. マスタースライドの背景 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Solid` に設定します。
4. [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) メソッドを使用して単色の背景色を指定します。
5. 変更後のプレゼンテーションを保存します。

以下の Java サンプルは、マスタースライドの背景を緑の単色に設定する方法を示しています:
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // マスタースライドの背景色をフォレストグリーンに設定します。
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // プレゼンテーションをディスクに保存します。
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **スライドのグラデーション背景を設定する**

グラデーションは、色が徐々に変化することで作られる視覚効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的かつプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景にグラデーションカラーを設定できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) の [getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) メソッドを使用して好みのグラデーション設定を構成します。
5. 変更後のプレゼンテーションを保存します。

以下の Java サンプルは、スライドの背景をグラデーションカラーに設定する方法を示しています:
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // 背景にグラデーション効果を適用します。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // プレゼンテーションをディスクに保存します。
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **画像をスライド背景に設定する**

単色やグラデーションに加えて、Aspose.Slides は画像をスライド背景として使用することも可能です。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Picture` に設定します。
4. 背景として使用する画像を読み込みます。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) の [getPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) メソッドを使用して画像を背景として割り当てます。
7. 変更後のプレゼンテーションを保存します。

以下の Java サンプルは、スライドの背景に画像を設定する方法を示しています:
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 背景画像のプロパティを設定します。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // 画像を読み込みます。
    IImage image = Images.fromFile("Tulips.jpg");
    // 画像をプレゼンテーションの画像コレクションに追加します。
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // プレゼンテーションをディスクに保存します。
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


以下のコードサンプルは、背景の塗りつぶしタイプをタイル化された画像に設定し、タイルプロパティを変更する方法を示しています:
```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // 背景塗りつぶしに使用する画像を設定します。
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // ピクチャーフィルモードをタイルに設定し、タイルプロパティを調整します。
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
詳しく読む: [**テクスチャとしてタイル画像**](/slides/ja/java/shape-formatting/#tile-picture-as-texture)
{{% /alert %}}

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドのコンテンツを際立たせたい場合があります。以下の Java コードは、スライド背景画像の透明度を変更する方法を示しています:
```java
int transparencyValue = 30; // 例として。

// 画像変換操作のコレクションを取得します。
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 既存の固定パーセンテージ透明度効果を探します。
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// 新しい透明度の値を設定します。
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **スライド背景の値を取得する**

Aspose.Slides は、スライドの実効背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/) インターフェイスを提供します。このインターフェイスは、実効 [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) と [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) を公開します。

[BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/) クラスの `getBackground` メソッドを使用すると、スライドの実効背景を取得できます。

以下の Java サンプルは、スライドの実効背景値を取得する方法を示しています:
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // マスター、レイアウト、テーマを考慮した実効背景を取得します。
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **FAQ**

**カスタム背景をリセットしてテーマ/レイアウトの背景に戻すことはできますか？**

はい。スライドのカスタム塗りを削除すると、対応する [layout](/slides/ja/java/slide-layout/)/[master](/slides/ja/java/slide-master/) スライド（つまり [theme background](/slides/ja/java/presentation-theme/)）から背景が再び継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドが独自の塗りを持っている場合は変更されません。背景が [layout](/slides/ja/java/slide-layout/)/[master](/slides/ja/java/slide-master/) から継承されている場合、[new theme](/slides/ja/java/presentation-theme/) に合わせて更新されます。