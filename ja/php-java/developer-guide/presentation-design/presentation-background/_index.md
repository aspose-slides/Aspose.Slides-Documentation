---
title: PHPでプレゼンテーションの背景を管理する
linktitle: スライド背景
type: docs
weight: 20
url: /ja/php-java/presentation-background/
keywords:
- プレゼンテーション背景
- スライド背景
- 単色
- グラデーション色
- 画像背景
- 背景の透明度
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument ファイルの動的な背景を設定する方法を学び、プレゼンテーションを強化するコードヒントを提供します。"
---

## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**通常スライド**（単一スライド）または**マスタースライド**（複数のスライドに一度に適用）に対して背景を設定できます。

![PowerPoint background](powerpoint-background.png)

## **通常スライドの単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドに単色の背景を設定できます（プレゼンテーションがマスタースライドを使用している場合でも）。変更は選択したスライドのみに適用されます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライド背景の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Solid` に設定します。
4. 単色の背景色を指定するために、[FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 上の [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) メソッドを使用します。
5. 変更したプレゼンテーションを保存します。

以下の PHP サンプルは、通常スライドの背景を青の単色に設定する方法を示しています：
```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // スライドの背景色を青に設定します。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // プレゼンテーションをディスクに保存します。
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **マスタースライドの単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドに単色の背景を設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [getMasters] を介して取得したマスタースライドの [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. マスタースライド背景の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Solid` に設定します。
4. 単色の背景色を指定するために、[getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) メソッドを使用します。
5. 変更したプレゼンテーションを保存します。

以下の PHP サンプルは、マスタースライドの背景を緑の単色に設定する方法を示しています：
```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // マスタースライドの背景色をフォレストグリーンに設定します。
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // プレゼンテーションをディスクに保存します。
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **スライドにグラデーション背景を設定する**

グラデーションは、色が徐々に変化することで作られる視覚的効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景にグラデーション色を設定できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライド背景の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Gradient` に設定します。
4. 好みのグラデーション設定を構成するために、[FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 上の [getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) メソッドを使用します。
5. 変更したプレゼンテーションを保存します。

以下の PHP サンプルは、スライドの背景をグラデーション色に設定する方法を示しています：
```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 背景にグラデーション効果を適用します。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // プレゼンテーションをディスクに保存します。
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **スライドの背景に画像を設定する**

単色やグラデーションの塗りつぶしに加えて、Aspose.Slides では画像をスライドの背景として使用できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライド背景の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Picture` に設定します。
4. スライドの背景として使用したい画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. 背景として画像を割り当てるために、[FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 上の [getPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat) メソッドを使用します。
7. 変更したプレゼンテーションを保存します。

以下の PHP サンプルは、スライドの背景に画像を設定する方法を示しています：
```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 背景画像のプロパティを設定します。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // 画像をロードします。
    $image = Images::fromFile("Tulips.jpg");
    // 画像をプレゼンテーションの画像コレクションに追加します。
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // プレゼンテーションをディスクに保存します。
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


以下のコードサンプルは、背景の塗りつぶしタイプをタイル状の画像に設定し、タイルのプロパティを変更する方法を示しています：
```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // 背景塗りつぶしに使用する画像を設定します。
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // ピクチャーフィルモードをタイルに設定し、タイルのプロパティを調整します。
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert color="primary" %}}
続きはこちら: [**テクスチャとしてのタイル画像**](/slides/ja/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたい場合があります。以下の PHP コードは、スライド背景画像の透明度を変更する方法を示しています：
```php
$transparencyValue = 30; // 例として。

// 画像変換操作のコレクションを取得します。
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// 既存の固定パーセンテージ透明度効果を見つけます。
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// 新しい透明度の値を設定します。
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```


## **スライド背景の値を取得する**

Aspose.Slides は、スライドの有効な背景値を取得するための `BackgroundEffectiveData` クラスを提供します。このクラスは有効な [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) と [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) クラスの `getBackground` メソッドを使用すると、スライドの有効な背景を取得できます。

以下の PHP サンプルは、スライドの有効な背景値を取得する方法を示しています：
```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // マスタ、レイアウト、テーマを考慮した有効な背景を取得します。
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**カスタム背景をリセットしてテーマ/レイアウトの背景に戻すことはできますか？**

はい。スライドのカスタム塗りつぶしを削除すると、背景は対応する[レイアウト](/slides/ja/php-java/slide-layout/)/[マスター](/slides/ja/php-java/slide-master/)スライド（すなわち[テーマ背景](/slides/ja/php-java/presentation-theme/)）から再度継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドが独自の塗りつぶしを持っている場合は変更されません。背景が[レイアウト](/slides/ja/php-java/slide-layout/)/[マスター](/slides/ja/php-java/slide-master/)から継承されている場合は、新しいテーマに合わせて更新されます。