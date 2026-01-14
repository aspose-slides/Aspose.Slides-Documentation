---
title: PHP でプレゼンテーションスライドを比較
linktitle: スライドを比較
type: docs
weight: 50
url: /ja/php-java/compare-slides/
keywords:
- スライドを比較
- スライドの比較
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーションをプログラムで比較します。コード内でスライドの違いをすばやく特定できます。"
---

## **スライドを比較する**
Equals メソッドが [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) クラスに追加されました。構造と静的コンテンツが同一であるスライド/レイアウトおよびスライド/マスタースライドに対して true を返します。

すべての図形、スタイル、テキスト、アニメーションおよびその他の設定などが等しい場合、2つのスライドは等しいとみなされます。比較では、SlideId などの一意の識別子の値や、日付プレースホルダーの現在の日付値などの動的コンテンツは考慮されません。
```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```


## **よくある質問**

**スライドが非表示であることは、スライド自体の比較に影響しますか？**

[Hidden status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) はプレゼンテーション/再生レベルのプロパティであり、ビジュアルコンテンツではありません。2つの特定のスライドの等価性は、その構造と静的コンテンツによって決まります。スライドが非表示であるという事実だけでスライドが異なるとはみなされません。

**ハイパーリンクおよびそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL またはハイパーリンクアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて実行されます。外部データソースは通常、比較時に読み取られず、スライドの構造と静的状態に存在するものだけが考慮されます。