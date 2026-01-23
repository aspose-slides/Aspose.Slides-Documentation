---
title: PHPでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーションローカリゼーション
type: docs
weight: 100
url: /ja/php-java/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- 言語 ID
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java経由でPHP向けAspose.Slidesを使用し、PowerPoint および OpenDocument スライドのローカリゼーションを自動化します。実用的なコードサンプルとヒントにより、グローバル展開を迅速に行えます。"
---

## **プレゼンテーションと図形テキストの言語を変更する**
- [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [矩形](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) タイプの [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
- TextFrame にテキストを追加します。
- テキストに **言語 ID を設定** します。[言語 ID を設定](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)。
- プレゼンテーションを PPTX ファイルとして書き出します。

上記の手順の実装例は以下のとおりです。
```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**言語 ID は自動テキスト翻訳をトリガーしますか？**

いいえ。[言語 ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) はスペルチェックと文法校正のために言語を格納しますが、テキスト内容を翻訳したり変更したりはしません。PowerPoint が校正用メタデータとして理解します。

**言語 ID はハイフネーションおよび改行に影響しますか？**

Aspose.Slides では、[言語 ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) は校正用です。ハイフネーションの品質と改行は主に [適切なフォント](/slides/ja/php-java/powerpoint-fonts/) の利用可能性と、書字システム向けのレイアウト/改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[フォント置換ルール](/slides/ja/php-java/font-substitution/) を構成するか、プレゼンテーションに [フォントを埋め込む](/slides/ja/php-java/embedded-font/) 必要があります。

**1つの段落内で異なる言語を設定できますか？**

はい。[言語 ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) はテキスト部分レベルで適用されるため、単一の段落内で複数の言語を異なる校正設定とともに混在させることができます。