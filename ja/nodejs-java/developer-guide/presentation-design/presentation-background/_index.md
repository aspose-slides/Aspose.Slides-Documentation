---
title: JavaScript でプレゼンテーションの背景を管理する
linktitle: スライド背景
type: docs
weight: 20
url: /ja/nodejs-java/presentation-background/
keywords:
- プレゼンテーション背景
- スライド背景
- 単色
- グラデーションカラー
- 画像背景
- 背景の透明性
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint と OpenDocument ファイルの動的な背景設定方法を学び、プレゼンテーションを強化するコードヒントを提供します。"
---

## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**通常スライド**（単一スライド）または**マスタースライド**（複数のスライドに同時に適用）に背景を設定できます。

![PowerPoint の背景](powerpoint-background.png)

## **通常スライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドの背景として単色を設定できます（プレゼンテーションがマスタースライドを使用している場合でも）。この変更は選択したスライドにのみ適用されます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) の [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) メソッドを使用して、単色背景の色を指定します。
5. 変更されたプレゼンテーションを保存します。

以下の JavaScript の例は、通常スライドの背景に青い単色を設定する方法を示しています：
```js
// Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // スライドの背景色を青に設定します。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // プレゼンテーションをディスクに保存します。
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **マスタースライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景として単色を設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. マスタースライドの [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/)（`getMasters` 経由）を `OwnBackground` に設定します。
3. マスタースライドの背景の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
4. [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) メソッドを使用して、単色背景の色を指定します。
5. 変更されたプレゼンテーションを保存します。

以下の JavaScript の例は、マスタースライドの背景に緑の単色を設定する方法を示しています：
```js
// Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // マスタースライドの背景色をフォレストグリーンに設定します。
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // プレゼンテーションをディスクに保存します。
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **スライドのグラデーション背景の設定**

グラデーションは、色の徐々の変化によって作られるグラフィック効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景としてグラデーションカラーを設定できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) の [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) メソッドを使用して、希望するグラデーション設定を構成します。
5. 変更されたプレゼンテーションを保存します。

以下の JavaScript の例は、スライドの背景にグラデーションカラーを設定する方法を示しています：
```js
// Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 背景にグラデーション効果を適用します。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // プレゼンテーションをディスクに保存します。
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **画像をスライドの背景として設定**

単色およびグラデーションの塗りつぶしに加えて、Aspose.Slides では画像をスライドの背景として使用できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Picture` に設定します。
4. スライドの背景として使用する画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) の [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) メソッドを使用して、画像を背景として割り当てます。
7. 変更されたプレゼンテーションを保存します。

以下の JavaScript の例は、スライドの背景に画像を設定する方法を示しています：
```js
// Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 背景画像のプロパティを設定します。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // 画像をロードします。
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // 画像をプレゼンテーションの画像コレクションに追加します。
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // プレゼンテーションをディスクに保存します。
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


以下のコードサンプルは、背景の塗りつぶしタイプをタイル化された画像に設定し、タイルのプロパティを変更する方法を示しています：
```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // 背景塗りつぶしに使用する画像を設定します。
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // 画像塗りつぶしモードをタイルに設定し、タイルのプロパティを調整します。
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
詳しく読む: [**タイル画像をテクスチャとして使用**](/slides/ja/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **背景画像の透明度の変更**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたい場合があります。以下の JavaScript コードは、スライド背景画像の透明度を変更する方法を示しています：
```js
var transparencyValue = 30; // 例として。

// ピクチャー変換操作のコレクションを取得します。
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 既存の固定パーセンテージ透明度効果を探します。
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// 新しい透明度の値を設定します。
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **スライド背景の値を取得**

Aspose.Slides は、スライドの実効的な背景値を取得するための `BackgroundEffectiveData` クラスを提供します。このクラスは実効的な [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) と [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/) クラスの `getBackground` メソッドを使用すると、スライドの実効的な背景を取得できます。

以下の JavaScript の例は、スライドの実効的な背景値を取得する方法を示しています：
```js
// Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // マスター、レイアウト、テーマを考慮した実効的な背景を取得します。
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **FAQ**

**カスタム背景をリセットしてテーマ/レイアウトの背景を復元できますか？**

はい。スライドのカスタム塗りつぶしを削除すると、背景は対応する [layout](/slides/ja/nodejs-java/slide-layout/)/[master](/slides/ja/nodejs-java/slide-master/) スライド（すなわち [theme background](/slides/ja/nodejs-java/presentation-theme/)）から再び継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドが独自の塗りつぶしを持っている場合、背景は変更されません。背景が [layout](/slides/ja/nodejs-java/slide-layout/)/[master](/slides/ja/nodejs-java/slide-master/) から継承されている場合、[new theme](/slides/ja/nodejs-java/presentation-theme/) に合わせて更新されます。