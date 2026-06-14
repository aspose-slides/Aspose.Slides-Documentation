---
title: 使用 PHP 管理簡報中的文字片段
linktitle: 文字片段
type: docs
weight: 70
url: /zh-hant/php-java/portion/
keywords:
- 文字片段
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中管理文字片段，以提升效能與自訂能力。"
---
## **簡介**

文字片段代表段落內的特定文字片段，並允許您獨立於周圍內容對該片段進行操作。 在 Aspose.Slides 中，當您需要取得文字片段的位置、僅對段落的一部分套用格式，或在更細緻的層級控制文字行為時，可使用片段。

## **取得文字片段的座標**
[**getCoordinates()**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/getcoordinates/) 方法已添加至 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 類別，可取得片段起始位置的座標。

```php
  # 實例化代表 PPTX 的 Prseetation 類別
  $pres = new Presentation();
  try {
    # 重新塑造簡報的上下文
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以僅對單一段落內的部分文字套用超連結嗎？**

是的，您可以將 [指派超連結](/slides/zh-hant/php-java/manage-hyperlinks/) 套用至單一片段；只有該片段會變成可點擊，而不是整段文字。

**樣式繼承如何運作：Portion 會覆寫哪些屬性，哪些則取自 Paragraph/TextFrame？**

Portion 級別的屬性具有最高優先權。若屬性未在 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 上設定，引擎會從 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 取得；若該處也未設定，則會取自 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/theme/) 樣式。

**如果在目標機器/伺服器上缺少為 Portion 指定的字型，會發生什麼情況？**

會套用 [字型替代規則](/slides/zh-hant/php-java/font-selection-sequence/)。文字可能會重新排版：度量、斷字與寬度可能改變，這會影響精確定位。

**我可以為特定 Portion 設定文字填充透明度或漸層，而不受段落其他部分影響嗎？**

是的，在 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 層級的文字顏色、填充與透明度可以與相鄰的片段不同。