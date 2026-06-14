---
title: 使用 PHP 管理簡報中的投影片過渡
linktitle: 投影片過渡
type: docs
weight: 80
url: /zh-hant/php-java/slide-transition/
keywords:
- 投影片過渡
- 新增投影片過渡
- 套用投影片過渡
- 進階投影片過渡
- Morph 過渡
- 過渡類型
- 過渡效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "探索如何在 Aspose.Slides for PHP via Java 中自訂投影片過渡，並提供針對 PowerPoint 與 OpenDocument 簡報的逐步說明。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報中管理投影片過渡。它展示了如何將過渡類型套用到投影片、設定過渡行為（例如點擊時前進或在指定時間後前進）、檢查並停用自動前進、使用 Morph 過渡及其類型，以及設定過渡效果選項。範例展示了如何載入或建立簡報、修改選取投影片的過渡設定，並將結果儲存為 PPTX 檔案。本文亦回答了關於過渡速度、過渡音效、將相同過渡套用至多個投影片，以及檢查投影片目前設定的過渡等常見問題。

## **新增投影片過渡**
若要建立簡單的投影片過渡效果，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. 透過 TransitionType 列舉，從 Aspose.Slides for PHP via Java 提供的過渡效果中套用投影片過渡類型。
3. 寫入已修改的簡報檔案。

```php
  # 實例化 Presentation 類別以載入來源簡報檔案
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # 在投影片 1 套用圓形類型過渡
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 在投影片 2 套用梳狀類型過渡
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 將簡報寫入磁碟
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **新增進階投影片過渡**
在上述段落中，我們僅在投影片上套用了簡單的過渡效果。現在，若要使該簡單過渡效果更佳且可控，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. 從 Aspose.Slides for PHP via Java 提供的過渡效果中套用投影片過渡類型。
3. 您也可以將過渡設定為點擊時前進、在特定時間後前進，或兩者同時設定。
4. 如果投影片過渡已啟用點擊時前進，則過渡僅會在使用者點擊滑鼠時前進。此外，若設定了「AdvanceAfterTime」屬性，過渡將在指定的時間過後自動前進。
5. 將已修改的簡報寫入為簡報檔案。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # 在投影片 1 套用圓形類型過渡
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 設定 3 秒的過渡時間
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # 在投影片 2 套用梳狀類型過渡
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 設定 5 秒的過渡時間
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # 在投影片 3 套用縮放類型過渡
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 設定 7 秒的過渡時間
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # 將簡報寫入磁碟
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph 過渡**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 現在支援 [Morph Transition](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/morphtransition/)。它們代表 PowerPoint 2019 中引入的新 Morph 過渡。

{{% /alert %}} 

Morph 過渡允許您在投影片之間動畫化平滑的移動。本文說明了其概念以及如何使用 Morph 過渡。若要有效使用 Morph 過渡，您需要兩張至少有一個共同物件的投影片。最簡單的方法是複製投影片，然後將第二張投影片上的物件移動到其他位置。

以下程式碼片段示範如何將包含文字的投影片副本加入簡報，並為第二張投影片設定 [morph type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/TransitionType) 過渡。

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Morph 過渡類型**
已新增 [TransitionMorphType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/TransitionMorphType) 列舉。它代表不同類型的 Morph 投影片過渡。

TransitionMorphType 列舉有三個成員：

- ByObject：Morph 過渡會將形狀視為不可分割的物件來執行。
- ByWord：Morph 過渡會盡可能以單字為單位傳輸文字。
- ByChar：Morph 過渡會盡可能以字元為單位傳輸文字。

以下程式碼片段示範如何為投影片設定 Morph 過渡並變更 Morph 類型：

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **設定過渡效果**
Aspose.Slides for PHP via Java 支援設定過渡效果，例如從黑色、從左側、從右側等。若要設定過渡效果，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 取得投影片的參考。
- 設定過渡效果。
- 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

在下方範例中，我們已設定過渡效果。

```php
  # 建立 Presentation 類別的實例
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # 設定效果
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # 將簡報寫入磁碟
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **常見問題**

**我可以控制投影片過渡的播放速度嗎？**

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/transitionspeed/) 設定，將過渡的 [speed](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowtransition/setspeed/) 設為慢速、普通或快速等。

**我可以為過渡附加音訊並使其循環播放嗎？**

是的。您可以為過渡嵌入音效，並透過設定如音效模式與循環等來控制行為（例如 [setSound](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowtransition/setsound/)、[setSoundMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowtransition/setsoundmode/)、[setSoundLoop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowtransition/setsoundloop/)，以及 [setSoundIsBuiltIn](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) 和 [setSoundName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowtransition/setsoundname/) 等中繼資料）。

**將相同過渡套用至每張投影片的最快方法是什麼？**

在每張投影片的過渡設定中配置所需的過渡類型；過渡是依投影片儲存的，因此在所有投影片上套用相同類型即可取得一致的結果。

**如何檢查投影片目前設定的過渡是什麼？**

檢查投影片的 [transition settings](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#getSlideShowTransition)，並讀取其 [transition type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideshowtransition/settype/)，即可知道目前套用的效果是什麼。