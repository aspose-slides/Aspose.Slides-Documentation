---
title: 在 PHP 中變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/php-java/slide-size/
keywords:
- 投影片大小
- 長寬比
- 標準
- 寬螢幕
- 4:3
- 16:9
- 設定投影片大小
- 變更投影片大小
- 自訂投影片大小
- 特殊投影片大小
- 獨特投影片大小
- 完整尺寸投影片
- 螢幕類型
- 不縮放
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 PHP 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，為任何螢幕優化簡報且不失真。"
---
## **Introduction**

Aspose.Slides 提供了完整的工具，用於調整 PowerPoint 簡報的投影片大小和長寬比，對於列印與螢幕顯示皆相當重要。

常見的投影片大小與比例：

- **Standard (4:3 Aspect Ratio)**：適用於較舊的螢幕與裝置。
- **Widescreen (16:9 Aspect Ratio)**：建議用於現代投影機與顯示器。

確保整個簡報的一致性，因為單一的投影片大小與長寬比會套用到所有投影片。為取得最佳效果，請在建立簡報的早期階段設定投影片尺寸，以免產生複雜問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **Change the Slide Size in Presentations**

此範例程式碼示範如何使用 Aspose.Slides 變更簡報的投影片大小：

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Specify Custom Slide Sizes in Presentations**

如果您發現常見的投影片大小（4:3 與 16:9）不符合您的需求，您可以選擇使用特定或自訂的投影片大小。例如，若您打算在自訂頁面布局上列印完整尺寸的投影片，或是希望在特定類型的螢幕上顯示簡報，使用自訂大小設定將對您有幫助。

以下範例程式碼示範如何透過 Java 使用 Aspose.Slides for PHP 為簡報指定自訂投影片大小：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4 紙張尺寸

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Handle Slide Content After Resizing**

在變更簡報的投影片大小後，投影片的內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新投影片大小。然而，在變更簡報的投影片大小時，您可以指定一個設定，決定 Aspose.Slides 如何處理投影片上的內容。

依據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`

  如果您 **不** 想要調整投影片上物件的大小，請使用此設定。

- `EnsureFit`

  如果您想縮小投影片尺寸，且需要 Aspose.Slides 將投影片物件向下縮放以確保它們全部適合投影片（以免遺失內容），請使用此設定。

- `Maximize`

  如果您想放大投影片尺寸，且需要 Aspose.Slides 將投影片物件放大，使其與新投影片大小成比例，請使用此設定。

以下範例程式碼示範在變更簡報投影片大小時如何使用 `Maximize` 設定：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**我可以使用除英寸之外的單位（例如點或毫米）來設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用點（point）作為單位，1 點等於 1/72 英吋。您可以將任何單位（例如毫米或公分）轉換為點，並使用轉換後的值來定義投影片的寬度與高度。

**非常大的自訂投影片大小會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）搭配較高的渲染比例會導致記憶體使用量增加與處理時間變長。請選擇實用的投影片尺寸，僅在需要時調整渲染比例以達到所需的輸出品質。

**我可以定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片嗎？**

在投影片尺寸不同的情況下，您無法[合併簡報](/slides/zh-hant/php-java/merge-presentation/)。必須先將其中一個簡報的尺寸調整至與另一個相同。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesizescaletype/)選項指定如何處理現有內容。尺寸對齊後，即可在保留格式的前提下合併投影片。

**我可以為單一圖形或投影片的特定區域產生縮圖，且它們會遵循新的投影片大小嗎？**

可以。Aspose.Slides 能夠產生[整張投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage)與[選取圖形](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)的縮圖。產生的影像會反映目前的投影片大小與長寬比，確保框架與幾何形狀的一致性。