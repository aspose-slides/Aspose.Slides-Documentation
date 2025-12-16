---
title: Android でプレゼンテーションの背景を管理する
linktitle: スライド背景
type: docs
weight: 20
url: /ja/androidjava/presentation-background/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で利用し、PowerPoint および OpenDocument ファイルに動的な背景を設定する方法を学び、プレゼンテーションを向上させるコードのヒントをご紹介します。"
---

## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**通常スライド**（単一スライド）または**マスタースライド**（複数のスライドに同時に適用）に背景を設定できます。

![PowerPoint の背景](powerpoint-background.png)

## **通常スライドに単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドの背景として単色を設定できます（プレゼンテーションがマスタースライドを使用している場合でも）。この変更は選択したスライドのみに適用されます。

1. Presentation クラスのインスタンスを作成します。
2. スライドの BackgroundType を `OwnBackground` に設定します。
3. スライドの背景 FillType を `Solid` に設定します。
4. FillFormat の [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) メソッドを使用して単色背景色を指定します。
5. 変更したプレゼンテーションを保存します。

以下の Java の例は、通常スライドの背景に青の単色を設定する方法を示しています。
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


## **マスタースライドに単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景として単色を設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. Presentation クラスのインスタンスを作成します。
2. master スライドの BackgroundType（`getMasters` 経由）を `OwnBackground` に設定します。
3. master スライドの背景 FillType を `Solid` に設定します。
4. [getSolidFillColor] メソッドを使用して単色背景色を指定します。
5. 変更したプレゼンテーションを保存します。

以下の Java の例は、マスタースライドの背景に単色（緑）を設定する方法を示しています。
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


## **スライドにグラデーション背景を設定する**

グラデーションは、色が徐々に変化することで作成されるグラフィック効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景としてグラデーション色を設定できます。

1. Presentation クラスのインスタンスを作成します。
2. スライドの BackgroundType を `OwnBackground` に設定します。
3. スライドの背景 FillType を `Gradient` に設定します。
4. FillFormat の [getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) メソッドを使用して、希望するグラデーション設定を構成します。
5. 変更したプレゼンテーションを保存します。

以下の Java の例は、スライドの背景にグラデーション色を設定する方法を示しています。
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


## **スライド背景に画像を設定する**

単色やグラデーションの塗りつぶしに加えて、Aspose.Slides では画像をスライドの背景として使用できます。

1. Presentation クラスのインスタンスを作成します。
2. スライドの BackgroundType を `OwnBackground` に設定します。
3. スライドの背景 FillType を `Picture` に設定します。
4. スライドの背景として使用したい画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. FillFormat の [getPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) メソッドを使用して、画像を背景として割り当てます。
7. 変更したプレゼンテーションを保存します。

以下の Java の例は、スライドの背景に画像を設定する方法を示しています。
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 背景画像のプロパティを設定します。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // 画像をロードします。
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


以下のコードサンプルは、背景の塗りつぶしタイプをタイル状の画像に設定し、タイルのプロパティを変更する方法を示しています。
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

    // 背景の塗りつぶしに使用する画像を設定します。
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
さらに読む: [**タイル画像をテクスチャとして**](/slides/ja/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたい場合があります。以下の Java コードは、スライド背景画像の透明度を変更する方法を示しています。
```java
int transparencyValue = 30; // 例として。

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **スライドの背景値を取得する**

Aspose.Slides は、スライドの実際の背景値を取得するための [IBackgroundEffectiveData] インターフェイスを提供します。このインターフェイスは、実際の [FillFormat] と [EffectFormat] を公開します。

[BaseSlide] クラスの `getBackground` メソッドを使用して、スライドの実際の背景を取得できます。

以下の Java の例は、スライドの実際の背景値を取得する方法を示しています。
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

**カスタム背景をリセットしてテーマ/レイアウトの背景を復元できますか？**

はい。スライドのカスタム塗りつぶしを削除すると、背景は対応する [layout](/slides/ja/androidjava/slide-layout/)/[master](/slides/ja/androidjava/slide-master/) スライド（つまり [theme background](/slides/ja/androidjava/presentation-theme/)）から再び継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドが独自の塗りつぶしを持っている場合は、変更されません。背景が [layout](/slides/ja/androidjava/slide-layout/)/[master](/slides/ja/androidjava/slide-master/) から継承されている場合は、[new theme](/slides/ja/androidjava/presentation-theme/) に合わせて更新されます。