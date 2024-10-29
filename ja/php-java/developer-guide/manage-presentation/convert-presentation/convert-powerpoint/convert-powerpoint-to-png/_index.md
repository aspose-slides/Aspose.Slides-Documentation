---
title: PowerPointをPNGに変換
type: docs
weight: 30
url: /ja/php-java/convert-powerpoint-to-png/
keywords: PowerPoint to PNG, PPT to PNG, PPTX to PNG, java, Aspose.Slides for PHP via Java
description: PowerPointプレゼンテーションをPNGに変換
---

## **PowerPointをPNGに変換することについて**

PNG（ポータブルネットワークグラフィックス）フォーマットはJPEG（ジョイントフォトグラフィックエクスパートグループ）ほど一般的ではありませんが、それでも非常に人気があります。

**ユースケース:** 複雑な画像があり、サイズが問題でない場合は、PNGはJPEGよりも優れた画像フォーマットです。

{{% alert title="ヒント" color="primary" %}} Asposeの無料**PowerPoint to PNG Converters**をチェックしてみてください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは、このページで説明されているプロセスのライブ実装です。 {{% /alert %}}

## **PowerPointをPNGに変換する**

これらの手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスをインスタンス化します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) メソッドを使用して[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)インターフェイスのコレクションからスライドオブジェクトを取得します。
3. [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)メソッドを使用して、各スライドのサムネイルを取得します。
4. [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))メソッドを使用して、スライドのサムネイルをPNG形式で保存します。

このPHPコードは、PowerPointプレゼンテーションをPNGに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **カスタム寸法でPowerPointをPNGに変換する**

特定のスケールのPNGファイルを取得したい場合は、結果のサムネイルの寸法を決定する`desiredX`と`desiredY`の値を設定できます。

このコードは、前述の操作を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **カスタムサイズでPowerPointをPNGに変換する**

特定のサイズのPNGファイルを取得したい場合は、`ImageSize`のために好みの`width`と`height`の引数を渡すことができます。

このコードは、画像のサイズを指定しながらPowerPointをPNGに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```