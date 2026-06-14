---
title: 取得簡報中整個投影片背景為影像
linktitle: 整個投影片背景
type: docs
weight: 95
url: /zh-hant/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片背景
- 最終背景
- 擷取背景
- 完整背景
- 背景轉影像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，從 PowerPoint 與 OpenDocument 簡報中將整個投影片背景擷取為影像，簡化視覺工作流程。"
---
## **概覽**

在 PowerPoint 簡報中，投影片背景可能由多個元素組成，包括投影片背景圖像、簡報主題、色彩配置以及放置在母片或版面投影片上的物件。

本文說明如何使用 Aspose.Slides 將整個投影片背景擷取為影像。由於此任務沒有單一方法，做法是將選取的投影片複製到暫存簡報中，移除投影片形狀，然後將產生的投影片背景轉換為影像。

## **擷取整個投影片背景**

Aspose.Slides for PHP via Java 未提供直接擷取整個簡報投影片背景為影像的簡易方法，但您可以依照以下步驟執行：
1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入簡報。
1. 從簡報中取得投影片尺寸。
1. 選取投影片。
1. 建立暫存簡報。
1. 在暫存簡報中設定相同的投影片尺寸。
1. 將選取的投影片複製到暫存簡報中。
1. 刪除複製投影片中的形狀。
1. 將複製的投影片轉換為影像。

以下程式碼範例會將整個簡報投影片背景擷取為影像。
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **常見問題**

**從母片的複雜漸層、質感或圖片填充會在最終背景影像中被保留嗎？**

是。Aspose.Slides 會呈現在投影片、版面或母片上定義的漸層、圖片與質感填充。如果您需要將外觀從繼承的母片中分離，請在匯出前於目前投影片[設定自己的背景](/slides/zh-hant/php-java/presentation-background/)。

**我可以在儲存前為最終背景影像加入浮水印嗎？**

是。您可以在工作用的[投影片副本](/slides/zh-hant/php-java/clone-slides/)上[加入浮水印](/slides/zh-hant/php-java/watermark/)形狀或圖像（置於其他內容之後），然後再匯出。這樣即可產生已嵌入浮水印的背景影像。

**我可以取得特定版面或母片的背景，而不必將其綁定到現有投影片上嗎？**

是。存取目標母片或版面，將其套用到具有所需尺寸的[暫存投影片](/slides/zh-hant/php-java/clone-slides/)，然後匯出該投影片即可取得來自該版面或母片的背景。

**是否有授權限制會影響影像匯出？**

具備[有效授權](/slides/zh-hant/php-java/licensing/)即可完整使用渲染功能。評估模式下，輸出可能會有浮水印等限制。請在執行批次匯出前於每個程序啟用授權。