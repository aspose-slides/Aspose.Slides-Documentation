---
title: PHPでPowerPointテキストにアニメーションを付ける
linktitle: アニメーションテキスト
type: docs
weight: 60
url: /ja/php-java/animated-text/
keywords:
- アニメーションテキスト
- テキストアニメーション
- アニメーション段落
- 段落アニメーション
- アニメーション効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションに動的なアニメーションテキストを作成し、わかりやすく最適化されたコード例を提供します。"
---

## **段落にアニメーション効果を追加する**

私たちは [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) メソッドを [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) と [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence) クラスに追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # エフェクトを追加する段落を選択
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # 選択した段落に Fly アニメーション効果を追加
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **段落のアニメーション効果を取得する**

段落に追加されたアニメーション効果を取得したい場合があります。たとえば、あるシナリオでは、別の段落やシェイプにその効果を適用するために、段落内のアニメーション効果を取得したいと考えることがあります。

Aspose.Slides for PHP via Java を使用すると、テキストフレーム（シェイプ）内に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落のアニメーション効果を取得する方法を示しています:
```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **FAQ**

**テキストアニメーションはスライドの切り替えとどのように異なり、組み合わせることはできますか？**

テキストアニメーションはスライド上でオブジェクトの動作を時間軸で制御し、[transitions](/slides/ja/php-java/slide-transition/) はスライドの切り替え方法を制御します。これらは独立しており、同時に使用できます。再生順序はアニメーションのタイムラインとトランジション設定によって決まります。

**PDFや画像にエクスポートするときにテキストアニメーションは保持されますか？**

いいえ。PDFやラスタ画像は静的であるため、スライドの単一の状態しか表示されず、動きはありません。動きを保持したい場合は、[video](/slides/ja/php-java/convert-powerpoint-to-video/) または [HTML](/slides/ja/php-java/export-to-html5/) エクスポートを使用してください。

**テキストアニメーションはレイアウトやスライドマスターでも機能しますか？**

レイアウトやマスターオブジェクトに適用された効果はスライドに継承されますが、そのタイミングやスライドレベルのアニメーションとの相互作用は、スライド上の最終的なシーケンスに依存します。