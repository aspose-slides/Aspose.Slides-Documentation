---
title: PHP で PowerPoint プレゼンテーションをアニメーション GIF に変換
linktitle: PowerPoint から GIF へ
type: docs
weight: 65
url: /ja/php-java/convert-powerpoint-to-animated-gif/
keywords:
- アニメーション GIF
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から GIF
- プレゼンテーションから GIF
- スライドから GIF
- PPT から GIF
- PPTX から GIF
- PPT を GIF として保存
- PPTX を GIF として保存
- PPT を GIF にエクスポート
- PPTX を GIF にエクスポート
- デフォルト設定
- カスタム設定
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーション (PPT、PPTX) をアニメーション GIF に簡単に変換できます。高速で高品質な結果を実現します。"
---

## **デフォルト設定でプレゼンテーションをアニメーションGIFに変換する**

このサンプルコードは、標準設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します。
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


アニメーションGIFはデフォルトのパラメーターで作成されます。

{{%  alert  title="TIP"  color="primary"  %}} 
GIF のパラメーターをカスタマイズしたい場合は、[GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions) クラスを使用できます。以下のサンプルコードをご参照ください。
{{% /alert %}} 

## **カスタム設定でプレゼンテーションをアニメーションGIFに変換する**
このサンプルコードは、カスタム設定を使用してプレゼンテーションをアニメーションGIFに変換する方法を示します。
```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// 生成された GIF のサイズ

    $gifOptions->setDefaultDelay(2000);// 各スライドが次へ切り替わるまでの表示時間

    $gifOptions->setTransitionFps(35);// トランジションアニメーションの品質を向上させるために FPS を増やす

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Info" color="info" %}}
Aspose が開発した無料の [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバーターをご利用いただけます。
{{% /alert %}}

## **FAQ**

**プレゼンテーションで使用されているフォントがシステムにインストールされていない場合はどうなりますか？**

不足しているフォントをインストールするか、[フォントのフォールバックを設定](/slides/ja/php-java/powerpoint-fonts/)してください。Aspose.Slides が代替しますが、外観が異なる場合があります。ブランディングのためには、必要なフォントが確実に利用可能であることを常に確認してください。

**GIF フレームに透かしを重ねることはできますか？**

はい。エクスポート前にマスタースライドまたは個々のスライドに[半透明のオブジェクト/ロゴ](/slides/ja/php-java/watermark/)を追加すると、透かしがすべてのフレームに表示されます。