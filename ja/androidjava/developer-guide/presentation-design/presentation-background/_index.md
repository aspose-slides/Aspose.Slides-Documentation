---
title: Android でプレゼンテーションの背景を管理
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
- 背景透過性
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用し、PowerPoint および OpenDocument ファイルに動的な背景を設定する方法を学び、プレゼンテーションを向上させるコードのヒントをご紹介します。"
---
## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。背景は **通常のスライド**（1枚のスライド）または **マスタースライド**（複数のスライドに同時に適用）に設定できます。

![PowerPoint background](powerpoint-background.png)

## **通常のスライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドの背景に単色を設定できます。プレゼンテーションがマスタースライドを使用している場合でも、変更は選択したスライドのみに適用されます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) の [getSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) メソッドを使用して単色の背景色を指定します。
5. 変更されたプレゼンテーションを保存します。

以下の Java の例は、通常のスライドの背景に青色の単色を設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **マスタースライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景に単色を設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. `getMasters` 経由で取得したマスタースライドの [BackgroundType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. マスタースライドの背景の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) の [getSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) メソッドを使用して単色の背景色を指定します。
5. 変更されたプレゼンテーションを保存します。

以下の Java の例は、マスタースライドの背景に緑色の単色を設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // マスタースライドの背景色を緑に設定します。
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // プレゼンテーションをディスクに保存します。
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スライドのグラデーション背景の設定**

グラデーションは、色が徐々に変化することで作られる視覚効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景にグラデーション色を設定できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) の [getGradientFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) メソッドを使用して、希望するグラデーション設定を構成します。
5. 変更されたプレゼンテーションを保存します。

以下の Java の例は、スライドの背景にグラデーション色を設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // 背景にグラデーション効果を適用します。
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // グラデーションの色を追加します。グラデーションストップがない場合、背景はデフォルトの黒から白へのランプにフォールバックします。
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // プレゼンテーションをディスクに保存します。
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スライドの背景画像の設定**

単色やグラデーションだけでなく、Aspose.Slides では画像をスライドの背景として使用することもできます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Picture` に設定します。
4. スライドの背景に使用したい画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) の [getPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) メソッドを使用して、画像を背景として割り当てます。
7. 変更されたプレゼンテーションを保存します。

以下の Java の例は、スライドの背景に画像を設定する方法を示しています。

```java
import com.aspose.slides.*;

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

以下のコードサンプルは、背景塗りつぶしタイプをタイル状の画像に設定し、タイルプロパティを変更する方法を示しています。

```java
import com.aspose.slides.*;

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

    // ピクチャーフィルモードを Tile に設定し、タイルプロパティを調整します。
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

{{% alert color="info" %}}
詳しくは：[**テクスチャとしてタイル画像**](/slides/ja/androidjava/shape-formatting/#tile-picture-as-texture) をご覧ください。
{{% /alert %}}

### **背景画像の透過性の変更**

スライドの背景画像の透過性を調整して、スライドの内容を際立たせたい場合があります。以下の Java コードは、スライド背景画像の透過性を変更する方法を示しています。

```java
import com.aspose.slides.*;

int transparencyValue = 30; // 例として。

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 画像変換操作のコレクションを取得します。
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // 既存の固定パーセンテージ透明度エフェクトを探します。
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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スライドの背景値の取得**

Aspose.Slides は、スライドの有効な背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibackgroundeffectivedata/) インターフェイスを提供します。このインターフェイスは、有効な [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) と [EffectFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) を公開します。

[BaseSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslide/) クラスの `getBackground` メソッドを使用すると、スライドの有効な背景を取得できます。

以下の Java の例は、スライドの有効な背景値を取得する方法を示しています。

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // マスタ、レイアウト、テーマを考慮した有効な背景を取得します。
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

### カスタム背景をリセットしてテーマ/レイアウトの背景に戻すことはできますか？

はい。スライドのカスタム塗りつぶしを削除すると、背景は対応する [layout](/slides/ja/androidjava/slide-layout/)/[master](/slides/ja/androidjava/slide-master/) スライド（すなわち [theme background](/slides/ja/androidjava/presentation-theme/)）から再び継承されます。

### 後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？

スライドが独自の塗りつぶしを持っている場合は、そのまま変更されません。背景が [layout](/slides/ja/androidjava/slide-layout/)/[master](/slides/ja/androidjava/slide-master/) から継承されている場合は、新しいテーマに合わせて更新されます。