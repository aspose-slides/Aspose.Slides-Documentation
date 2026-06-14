---
title: 在 PHP 中為 PowerPoint 文字加入動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/php-java/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，提供易於理解且最佳化的程式碼範例。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用動畫文字，透過對個別段落套用動畫效果以及取得已指派給文字框中段落的效果。重點在於用於在簡報中新增段落層級動畫與檢查現有段落動畫效果的 API 方法。

## **為段落加入動畫效果**

我們在 [**Sequence**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Sequence) 類別中加入了 [**addEffect()**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 方法。此方法讓您能夠對單一段落加入動畫效果。以下範例程式碼示範如何對單一段落加入動畫效果：

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # 選擇段落以新增效果
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # 為選取的段落新增 Fly 動畫效果
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **取得段落的動畫效果**

您可能想要找出已加入段落的動畫效果，例如在某個情境下，您想取得段落中的動畫效果，以便將這些效果套用到另一個段落或形狀。

Aspose.Slides for PHP via Java 允許您取得套用於文字框（形狀）中段落的所有動畫效果。以下範例程式碼示範如何取得段落中的動畫效果：

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

**文字動畫與投影片切換有何不同，且可以同時使用嗎？**

文字動畫控制物件在投影片上隨時間的行為，而[transitions](/slides/zh-hant/php-java/slide-transition/)控制投影片之間的切換方式。兩者是獨立的，且可一起使用；播放順序由動畫時間軸與切換設定決定。

**將文字動畫匯出為 PDF 或影像時會保留嗎？**

不會。PDF 與點陣圖影像為靜態的，您只能看到投影片的單一狀態，沒有動作。如需保留動態效果，請使用[video](/slides/zh-hant/php-java/convert-powerpoint-to-video/)或[HTML](/slides/zh-hant/php-java/export-to-html5/)匯出。

**文字動畫在版面配置與投影片母片中有效嗎？**

套用於版面或母片物件的效果會被投影片繼承，但它們的時機與與投影片層級動畫的互動取決於投影片上最終的順序。