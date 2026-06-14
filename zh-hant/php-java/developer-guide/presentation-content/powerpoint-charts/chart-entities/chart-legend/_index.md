---
title: 使用 PHP 在簡報中自訂圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/php-java/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 客製化圖表圖例，以量身打造的圖例格式優化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本篇說明如何設定圖例的位置與大小、為整個圖例設定字型大小，以及對單一圖例項目套用格式。  
它亦在 FAQ 中涵蓋多項相關行為，包括使用非覆疊模式讓圖表區域為圖例留出空間、允許長圖例標籤自動換行或使用換行符號，以及在未設定明確文字與填滿時，讓圖例的格式繼承簡報主題的配色。

## **圖例定位**
為了設定圖例屬性，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 取得投影片的參考。
- 在投影片上加入圖表。
- 設定圖例的屬性。
- 將簡報寫入為 PPTX 檔案。

在以下範例中，我們已設定圖表圖例的位置與大小。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 取得投影片的參考
    $slide = $pres->getSlides()->get_Item(0);
    # 在投影片上新增叢集柱狀圖
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # 設定圖例屬性
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # 將簡報寫入磁碟
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定圖例的字型大小**
Aspose.Slides for PHP via Java 允許開發人員設定圖例的字型大小。請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 建立預設圖表。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定單一圖例項目的字型大小**
Aspose.Slides for PHP via Java 允許開發人員設定單一圖例項目的字型大小。請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 建立預設圖表。
- 取得圖例項目。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問答**

**我可以啟用圖例，讓圖表自動為其分配空間而不是覆疊嗎？**  
可以。使用非覆疊模式（[setOverlay(false)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/legend/setoverlay/)）；此時，圖表區域會縮小以容納圖例。

**我可以製作多行圖例標籤嗎？**  
可以。當空間不足時，長標籤會自動換行；亦支援在系列名稱中使用換行字元強制換行。

**如何讓圖例遵循簡報主題的配色方案？**  
不要為圖例或其文字設定明確的顏色、填滿或字型。這樣它們會繼承自主題，並在設計變更時正確更新。