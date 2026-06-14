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
- 全尺寸投影片
- 螢幕類型
- 不縮放
- 確保合適
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
descriptions: "了解如何使用 PHP 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案中的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具來調整 PowerPoint 簡報中的投影片大小與長寬比，這對於列印與螢幕顯示皆相當重要。

常見投影片尺寸與比例：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕與裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機與顯示器。

確保整個簡報的一致性，因為單一的投影片大小與長寬比會套用至所有投影片。為獲得最佳效果，請在建立簡報的初期即設定投影片尺寸，以免日後產生問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更投影片大小於簡報中**

此範例程式碼示範如何使用 Aspose.Slides 變更簡報中的投影片大小：

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

## **在簡報中指定自訂投影片大小**

如果常見的投影片尺寸（4:3 與 16:9）無法符合您的需求，您可以使用特定或獨特的投影片大小。例如，若您打算在自訂版面上列印全尺寸投影片，或是要在特定螢幕類型上顯示簡報，使用自訂大小設定將會非常有幫助。

此範例程式碼示範如何透過 Java 使用 Aspose.Slides for PHP 來為簡報指定自訂投影片大小：

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

## **調整大小後處理投影片內容**

變更簡報的投影片大小後，投影片內容（例如影像或物件）可能會出現變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定一個設定，來決定 Aspose.Slides 如何處理投影片上的內容。

依據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`

  若您 **不** 想讓投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  若您想縮小投影片並需要 Aspose.Slides 縮小投影片物件，使其全部適合投影片（以免遺失內容），請使用此設定。

- `Maximize`

  若您想放大投影片並需要 Aspose.Slides 放大投影片物件，使其與新的投影片大小成比例，請使用此設定。

此範例程式碼示範如何在變更簡報投影片大小時使用 `Maximize` 設定：

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

## **常見問題**

**我可以使用除英吋之外的單位（例如點或毫米）設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（如毫米或公分）轉換成點，並使用轉換後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片大小會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點計）加上較高的渲染比例會導致記憶體使用量提升與處理時間變長。請以實用的投影片大小為目標，僅在需要提升輸出品質時調整渲染比例。

**我可以定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片嗎？**

在不同投影片大小的情況下，無法直接[合併簡報](/slides/zh-hant/php-java/merge-presentation/)。必須先將其中一個簡報的尺寸調整為與另一個相同。變更投影片大小時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesizescaletype/)選項決定既有內容的處理方式。尺寸對齊後，即可合併投影片且保留格式。

**我可以為單一形狀或投影片的特定區域產生縮圖，且它們會遵循新投影片大小嗎？**

可以。Aspose.Slides 能夠為[整張投影片](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage)以及[選取的形狀](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)產生縮圖。產生的圖像會反映目前的投影片大小與長寬比，確保框架與幾何形狀的一致性。