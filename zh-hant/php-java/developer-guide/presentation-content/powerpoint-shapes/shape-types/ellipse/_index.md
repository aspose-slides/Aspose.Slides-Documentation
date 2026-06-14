---
title: 在 PHP 中向簡報新增橢圓形
linktitle: 橢圓形
type: docs
weight: 30
url: /zh-hant/php-java/ellipse/
keywords:
- 橢圓形
- 圖形
- 新增橢圓形
- 建立橢圓形
- 繪製橢圓形
- 已格式化的橢圓形
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP（透過 Java）中於 PPT 與 PPTX 簡報中建立、格式化與操控橢圓形圖形 — 附帶程式碼範例。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中新增橢圓形。內容涵蓋建立簡單橢圓形、建立格式化橢圓形，並將更新後的簡報儲存為 PPTX 檔案。亦會提及相關問題，例如處理橢圓形的位置與大小、控制堆疊順序，以及套用動畫效果。

## **建立橢圓形**
若要在簡報的選定投影片中新增簡單橢圓形，請遵循以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
- 使用其 Index 取得投影片的參考。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，新增類型為 Ellipse 的 AutoShape。
- 將修改後的簡報寫入 PPTX 檔案。

以下範例中，我們已將橢圓形新增至第一張投影片
```php
  # 建立表示 PPTX 的 Presentation 類別實例
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增類型為橢圓形的 AutoShape
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **建立格式化橢圓形**
若要在投影片中新增格式較佳的橢圓形，請遵循以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
- 使用其 Index 取得投影片的參考。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，新增類型為 Ellipse 的 AutoShape。
- 將橢圓形的填充類型設定為實色 (Solid)。
- 使用 `SolidFillColor::setColor` 方法（由 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 物件所公開）設定橢圓形的色彩，該 [FillFormat] 物件與 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 物件相關聯。
- 設定橢圓形線條的顏色。
- 設定橢圓形線條的寬度。
- 將修改後的簡報寫入 PPTX 檔案。

以下範例中，我們已將格式化的橢圓形新增至簡報的第一張投影片。
```php
  # 建立表示 PPTX 的 Presentation 類別實例
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增類型為橢圓形的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 對橢圓形套用一些格式設定
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # 對橢圓形的線條套用一些格式設定
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**如何以投影片單位設定橢圓形的精確位置與大小？**

座標與尺寸通常以 **點** 為單位指定。為獲得可預測的結果，請以投影片大小為基礎，並在賦值前將所需的公釐或英吋換算為點。

**如何將橢圓形置於其他物件之上或之下（控制堆疊順序）？**

透過將物件移到最前或最底來調整繪圖順序。這樣即可讓橢圓形覆蓋其他物件，或顯示其下方的物件。

**如何為橢圓形設定外觀或強調的動畫？**

對形狀套用 [Apply](/slides/zh-hant/php-java/shape-animation/) 進入、強調或退出效果，並配置觸發條件與時間設定，以安排動畫的播放時機與方式。