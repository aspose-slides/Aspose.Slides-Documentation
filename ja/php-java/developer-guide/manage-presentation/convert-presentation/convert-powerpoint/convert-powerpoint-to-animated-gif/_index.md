---
title: PowerPointをアニメーションGIFに変換
type: docs
weight: 65
url: /ja/php-java/convert-powerpoint-to-animated-gif/
keywords: "PowerPointをアニメーションGIFに変換, PPTからGIF, PPTXからGIF"
description: "PowerPointをアニメーションGIFに変換: PPTからGIF, PPTXからGIF, Aspose.Slides APIを使用しています。"
---

## デフォルト設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##

このサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

アニメーションGIFはデフォルトのパラメータで作成されます。 

{{% alert title="ヒント" color="primary" %}} 

GIFのパラメータをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions)クラスを使用できます。以下のサンプルコードを参照してください。

{{% /alert %}} 

## カスタム設定を使用したプレゼンテーションのアニメーションGIFへの変換 ##
このサンプルコードは、カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// 結果のGIFのサイズ

    $gifOptions->setDefaultDelay(2000);// 各スライドが次のスライドに切り替わるまでの表示時間

    $gifOptions->setTransitionFps(35);// 画質を向上させるためのFPSの増加

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="情報" color="info" %}}

Asposeが開発した無料の[テキストからGIF](https://products.aspose.app/slides/text-to-gif)変換ツールをチェックしてみてください。 

{{% /alert %}}