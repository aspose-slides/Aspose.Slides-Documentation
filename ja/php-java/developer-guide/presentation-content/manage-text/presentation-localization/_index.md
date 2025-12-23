---
title: PHPでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーションのローカリゼーション
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
description: "Aspose.Slides for PHP（Java経由）を使用して、PowerPoint と OpenDocument のスライドローカリゼーションを自動化し、実用的なコードサンプルとヒントでグローバル展開を迅速化します。"
---

## **プレゼンテーションとシェイプテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) を追加します。
- TextFrame にテキストを追加します。
- テキストに [Setting Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) を設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装例は以下のサンプルで示しています。
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


## **よくある質問**

**言語 ID は自動的にテキスト翻訳をトリガーしますか？**

いいえ。 [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) はスペルチェックと文法校正のための言語を保持しますが、テキスト内容を翻訳したり変更したりはしません。PowerPoint が校正用に理解するメタデータです。

**言語 ID は描画時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) は校正用です。ハイフネーションの品質と改行は主に [proper fonts](/slides/ja/php-java/powerpoint-fonts/) の有無と、書字システム向けのレイアウト/改行設定に依存します。正しく描画するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/php-java/font-substitution/) を設定するか、プレゼンテーションに [embed fonts](/slides/ja/php-java/embedded-font/) を埋め込んでください。

**単一の段落内で異なる言語を設定できますか？**

はい。[Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) はテキストの個々の部分に適用されるため、単一の段落内で複数の言語を混在させ、個別の校正設定を使用できます。