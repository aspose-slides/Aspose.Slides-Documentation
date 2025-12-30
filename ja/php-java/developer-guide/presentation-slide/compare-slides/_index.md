---
title: PHPでプレゼンテーション スライドを比較
linktitle: スライドを比較
type: docs
weight: 50
url: /ja/php-java/compare-slides/
keywords:
- スライドを比較
- スライド比較
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java を介して PHP 用 Aspose.Slides で PowerPoint および OpenDocument プレゼンテーションをプログラム的に比較します。コード内でスライドの違いをすばやく特定できます。"
---

## **2つのスライドを比較**
Equals メソッドが [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) インターフェイスと [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) クラスに追加されました。構造と静的コンテンツが同一であるスライド/レイアウトおよびマスタースライドに対して true を返します。

すべてのシェイプ、スタイル、テキスト、アニメーションおよびその他の設定等が等しい場合、2つのスライドは等しいとみなされます。比較では、SlideId などのユニーク識別子や、日付プレースホルダーの現在の日付値などの動的コンテンツは考慮されません。
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

[Hidden status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) はプレゼンテーション/再生レベルのプロパティであり、視覚的コンテンツではありません。2つの特定スライドの等価性はその構造と静的コンテンツによって決まります。スライドが非表示であるという事実だけでスライドが異なるとはみなされません。

**ハイパーリンクとそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL やハイパーリンクのアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて行われます。外部データ ソースは比較時に一般的に読み取られず、スライドの構造と静的状態に存在するものだけが考慮されます。