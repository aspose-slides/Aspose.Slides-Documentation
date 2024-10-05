---
title: プレースホルダーの管理
type: docs
weight: 10
url: /php-java/manage-placeholder/
description: PHPを使用してPowerPointスライドのプレースホルダー内のテキストを変更します。PHPを使用してPowerPointスライドのプレースホルダーにプロンプトテキストを設定します。
---

## **プレースホルダー内のテキストを変更する**
[Aspose.Slides for PHP via Java](/slides/php-java/)を使用して、プレゼンテーションのスライド上でプレースホルダーを見つけて修正できます。Aspose.Slidesを使うことで、プレースホルダー内のテキストを変更できます。

**前提条件**: プレースホルダーを含むプレゼンテーションが必要です。このようなプレゼンテーションは、標準のMicrosoft PowerPointアプリで作成できます。

これは、プレゼンテーション内のプレースホルダーのテキストを置き換えるためのAspose.Slidesの使用方法です：

1. [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスをインスタンス化し、プレゼンテーションを引数として渡します。
2. インデックスを通じてスライドの参照を取得します。
3. シェイプをループしてプレースホルダーを見つけます。
4. プレースホルダーシェイプを[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)に関連付けられた[`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)を使ってテキストを変更します。
5. 修正されたプレゼンテーションを保存します。

このPHPコードは、プレースホルダー内のテキストを変更する方法を示しています：

```php
  # Presentationクラスをインスタンス化します
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # プレースホルダーを見つけるためにシェイプをループします
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # 各プレースホルダーのテキストを変更します
        $shp->getTextFrame()->setText("これはプレースホルダーです");
      }
    }
    # プレゼンテーションをディスクに保存します
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、***タイトルを追加するにはクリック***や***サブタイトルを追加するにはクリック***などのプレースホルダープロンプトテキストが含まれています。Aspose.Slidesを使用すると、希望するプロンプトテキストをプレースホルダーレイアウトに挿入できます。

このPHPコードは、プレースホルダーにプロンプトテキストを設定する方法を示しています：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # スライドをループします
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPointは「タイトルを追加するにはクリック」と表示します
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "タイトルを追加";
        } else // サブタイトルを追加します
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "サブタイトルを追加";
        }
        $shape->getTextFrame()->setText($text);
        echo("テキストがあるプレースホルダー: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **プレースホルダー画像の透明度を設定する**

Aspose.Slidesを使用すると、テキストプレースホルダー内の背景画像の透明度を設定できます。このようなフレーム内の画像の透明度を調整することで、テキストや画像を際立たせることができます（テキストと画像の色に応じて）。

このPHPコードは、シェイプ内の画像背景の透明度を設定する方法を示しています：

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("現在の透明度の値: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```