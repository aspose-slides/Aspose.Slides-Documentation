---
title: PHPでPowerPointテキストをアニメーション化
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションで動的なアニメーションテキストを作成し、分かりやすく最適化されたコード例を提供します。"
---

## **段落にアニメーション効果を追加する**

We added the [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) method to the [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) class. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # エフェクトを追加する段落を選択
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # 選択した段落にFlyアニメーション効果を追加
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **段落のアニメーション効果を取得する**

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for PHP via Java allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:
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

**How do text animations differ from slide transitions, and can they be combined?**

Text animations control object behavior over time on a slide, while [transitions](/slides/ja/php-java/slide-transition/) control how slides change. They’re independent and can be used together; playback order is governed by the animation timeline and the transition settings.

**Are text animations preserved when exporting to PDF or images?**

No. PDF and raster images are static, so you’ll see a single state of the slide without motion. To keep movement, use [video](/slides/ja/php-java/convert-powerpoint-to-video/) or [HTML](/slides/ja/php-java/export-to-html5/) export.

**Do text animations work in layouts and the slide master?**

Effects applied to layout/master objects are inherited by slides, but their timing and interaction with slide-level animations depend on the final sequence on the slide.