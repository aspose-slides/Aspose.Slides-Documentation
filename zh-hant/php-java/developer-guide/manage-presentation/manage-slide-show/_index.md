---
title: 在 PHP 中管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/php-java/manage-slide-show/
keywords:
- 放映類型
- 由講者示範
- 由個人瀏覽
- 在 kiosk 中瀏覽
- 放映選項
- 持續循環
- 無旁白放映
- 無動畫放映
- 筆跡顏色
- 顯示投影片
- 自訂放映
- 自動換頁
- 手動
- 使用計時
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何透過 Java 在 Aspose.Slides for PHP 中管理投影片放映。輕鬆控制 PPT、PPTX 與 ODP 格式的投影片切換、計時等功能。"
---
## **簡介**

在 Microsoft PowerPoint 中，**Slide Show** 設定是準備與呈現專業簡報的關鍵工具。本節最重要的功能之一是 **Set Up Show**，它允許您根據特定條件與受眾調整簡報，確保彈性與便利。透過此功能，您可以選擇放映類型（例如由講者示範、由個人瀏覽或在 kiosk 中瀏覽）、啟用或停用循環、指定要顯示的特定投影片，以及使用計時。這一步驟對於提升簡報的有效性與專業度至關重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的方法，傳回類型為 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowsettings/) 的物件，讓您管理 PowerPoint 簡報中的投影片放映設定。本文將說明如何使用此方法來設定與控制投影片放映的各種屬性。

## **選取放映類型**

`SlideShowSettings->setSlideShowType` 定義投影片放映的類型，可接受以下類別的實例：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/browsedatkiosk/)。使用此方法可讓簡報依不同使用情境調整，例如自動 kiosk 或手動展示。

以下程式碼範例建立新簡報，並將放映類型設為「Browsed by an individual」且不顯示捲軸。

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **啟用放映選項**

`SlideShowSettings->setLoop` 決定投影片放映是否持續循環直至手動停止。這對需要不間斷執行的自動化簡報非常有用。`SlideShowSettings->setShowNarration` 決定是否在放映時播放語音解說，適用於含有語音導引的自動化簡報。`SlideShowSettings->setShowAnimation` 決定是否播放投影片物件上的動畫，以完整呈現簡報的視覺效果。

以下程式碼範例建立新簡報，並使投影片放映循環。

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **選取要放映的投影片**

`SlideShowSettings->setSlides` 方法允許您指定在簡報期間要顯示的投影片範圍。當只需展示簡報的部分內容而非全部投影片時，此功能相當實用。以下程式碼範例建立新簡報，並將顯示範圍設定為第 `2` 張至第 `9` 張投影片。

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **使用自動換頁**

`SlideShowSettings->setUseTimings` 方法允許您啟用或停用預先設定的每張投影片計時。這對於依預設播放時間自動切換投影片的情境非常有用。以下程式碼範例建立新簡報，並停用計時功能。

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **顯示媒體控制項**

`SlideShowSettings->setShowMediaControls` 方法決定在播放多媒體內容（例如影片或音訊）時，是否在投影片放映期間顯示媒體控制項（如播放、暫停、停止）。當您希望在簡報中讓主持人控制媒體播放時，此功能相當實用。

以下程式碼範例建立新簡報，並啟用媒體控制項的顯示。

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **常見問題**

**我可以將簡報儲存為直接以投影片放映模式開啟嗎？**

可以。將檔案儲存為 PPSX 或 PPSM；這兩種格式在 PowerPoint 中開啟時會直接進入投影片放映模式。在 Aspose.Slides 中，於[匯出](/slides/zh-hant/php-java/save-presentation/)時選擇相對應的儲存格式。

**我可以在不刪除投影片的情況下將個別投影片排除於放映之外嗎？**

可以。將投影片設為[hidden](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/sethidden/)。隱藏的投影片仍會保留在簡報中，但不會在投影片放映時顯示。

**Aspose.Slides 能否播放投影片放映或在螢幕上即時控制簡報？**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案，實際的播放需由如 PowerPoint 等檢視器應用程式處理。