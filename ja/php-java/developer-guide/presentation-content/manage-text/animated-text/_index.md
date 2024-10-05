---
title: アニメーションテキスト
type: docs
weight: 60
url: /php-java/animated-text/
keywords: "PowerPoint のアニメーションテキスト"
description: "Java を使用した PowerPoint のアニメーションテキスト"
---

## 段落にアニメーション効果を追加する

[**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) メソッドが [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) と [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence) クラスに追加されました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています。

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # 効果を追加する段落を選択
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # 選択した段落にフライアニメーション効果を追加
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## 段落のアニメーション効果を取得する

段落に追加されたアニメーション効果を確認することを決定する場合があります。たとえば、あるシナリオでは、別の段落またはシェイプにそれらの効果を適用する予定があるため、段落のアニメーション効果を取得したいと考えています。

Aspose.Slides for PHP via Java を使用すると、テキストフレーム（シェイプ）に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落のアニメーション効果を取得する方法を示しています。

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("段落 \"" . $paragraph->getText() . "\" には " . $effects[0]->getType() . " 効果があります。");
      }
    }
  } finally {
    $pres->dispose();
  }
```