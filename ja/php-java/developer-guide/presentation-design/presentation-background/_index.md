---
title: プレゼンテーションの背景
type: docs
weight: 20
url: /php-java/presentation-background/
keywords: "PowerPoint 背景, 背景を設定する"
description: "PowerPoint プレゼンテーションの背景を設定する"
---

スライドの背景画像としては、単色、グラデーション、画像がよく使用されます。背景は**通常のスライド**（単一スライド）または**マスタースライド**（複数スライド同時）に設定できます。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **通常のスライドの背景に単色を設定する**

Aspose.Slidesを使用すれば、プレゼンテーション内の特定のスライドの背景に単色を設定することができます（たとえそのプレゼンテーションがマスタースライドを含んでいても）。背景の変更は選択したスライドのみに影響します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 列挙型を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) が公開する [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) プロパティを使用して、背景の単色を指定します。
5. 修正したプレゼンテーションを保存します。

以下のPHPコードは、通常のスライドの背景に単色（青）を設定する方法を示しています：

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("MasterBG.pptx");
  try {
    # 最初の ISlide の背景色を青に設定
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # プレゼンテーションをディスクに書き込む
    $pres->save("ContentBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **マスタースライドの背景に単色を設定する**

Aspose.Slidesを使用すれば、プレゼンテーション内のマスタースライドの背景に単色を設定することができます。マスタースライドは、すべてのスライドのフォーマット設定を含み、制御するテンプレートとして機能します。したがって、マスタースライドの背景に単色を選択すると、その新しい背景がすべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. マスタースライド (`Masters`) の [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. マスタースライドの背景の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 列挙型を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) が公開する [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) プロパティを使用して、背景の単色を指定します。
5. 修正したプレゼンテーションを保存します。

以下のPHPコードは、プレゼンテーション内のマスタースライドの背景に単色（フォレストグリーン）を設定する方法を示しています：

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # Master ISlide の背景色をフォレストグリーンに設定
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # プレゼンテーションをディスクに書き込む
    $pres->save("MasterBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スライドの背景にグラデーションを設定する**

グラデーションは、色の緩やかな変化に基づくグラフィカルな効果です。スライドの背景として使用される場合、グラデーションカラーはプレゼンテーションを芸術的で専門的に見せます。Aspose.Slidesを使用すれば、プレゼンテーション内のスライドの背景にグラデーションカラーを設定することができます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. マスタースライドの背景に対する [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 列挙型を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) が公開する [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) プロパティを使用して、お好みのグラデーション設定を指定します。
5. 修正したプレゼンテーションを保存します。

以下のPHPコードは、スライドの背景にグラデーションカラーを設定する方法を示しています：

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("MasterBG.pptx");
  try {
    # 背景にグラデーション効果を適用
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    # プレゼンテーションをディスクに書き込む
    $pres->save("ContentBG_Grad.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スライドの背景に画像を設定する**

単色やグラデーションの他に、Aspose.Slidesはプレゼンテーション内のスライドの背景に画像を設定することも許可しています。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 列挙型を `OwnBackground` に設定します。
3. マスタースライドの背景に対する [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 列挙型を `Picture` に設定します。
4. スライドの背景として使用したい画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) が公開する [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) プロパティを使用して、背景として画像を設定します。
7. 修正したプレゼンテーションを保存します。

以下のPHPコードは、スライドの背景に画像を設定する方法を示しています：

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 背景画像の条件を設定
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 画像をロード
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # プレゼンテーションの画像コレクションに画像を追加
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    # プレゼンテーションをディスクに書き込む
    $pres->save("ContentBG_Img.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容が際立つようにすることがあります。以下のPHPコードは、スライドの背景画像の透明度を変更する方法を示しています：

```php
  $transparencyValue = 30; // 例えば

  # 画像変換操作のコレクションを取得
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  # 固定パーセンテージの透明度効果を見つける
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  # 新しい透明度値を設定
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **スライドの背景の値を取得する**

Aspose.Slidesは、スライドの背景の有効な値を取得するために [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/) インターフェイスを提供しています。このインターフェイスには、有効な [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) と有効な [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) に関する情報が含まれています。

[BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) クラスの [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) プロパティを使用して、スライドの背景の有効な値を取得できます。

以下のPHPコードは、スライドの有効な背景値を取得する方法を示しています：

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid) {
      echo("塗りつぶし色: " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("塗りつぶしタイプ: " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```