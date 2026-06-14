---
title: 在 PHP 中向簡報新增矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/php-java/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡單矩形
- 格式化矩形
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "透過 Java 的 Aspose.Slides for PHP，為您的 PowerPoint 簡報新增矩形，輕鬆以程式方式設計與修改形狀。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中新增矩形形狀。內容涵蓋建立簡單矩形、建立格式化矩形，以及將更新後的簡報儲存為 PPTX 檔案。

您還會看到如何套用基本的矩形格式設定，例如純色填充、線條顏色與線寬。此外，本文的 FAQ 亦會指向相關的矩形工作，包括圓角、圖片填充、視覺效果、超連結、形狀鎖定、匯出選項以及有效屬性。

## **將矩形新增至投影片**
- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，新增類型為 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例示範我們在簡報的第一張投影片中新增了一個簡單的矩形。

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增橢圓類型的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將格式化矩形新增至投影片**
- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，新增類型為 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
- 將矩形的 [Fill Type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FillType) 設為 Solid。
- 使用與 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 物件關聯的 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 物件所公開的 [ColorFormat::setColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorformat/#setColor) 方法，設定矩形的顏色。
- 設定矩形線條的顏色。
- 設定矩形線條的寬度。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例實作了上述步驟。

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增橢圓類型的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 對橢圓形狀套用一些格式設定
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # 對橢圓的線條套用一些格式設定
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**如何新增具有圓角的矩形？**

使用圓角 [shape type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapetype/) 並在形狀屬性中調整角半徑；亦可透過幾何調整為各個角設定圓角。

**如何使用圖片（紋理）填充矩形？**

選取圖片 [fill type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/)，提供圖像來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillmode/)。

**矩形可以有陰影和發光效果嗎？**

可以。提供可調整參數的 [Outer/inner shadow, glow, and soft edges](/slides/zh-hant/php-java/shape-effect/) 功能。

**我可以將矩形變成具有超連結的按鈕嗎？**

可以。透過 [Assign a hyperlink](/slides/zh-hant/php-java/manage-hyperlinks/) 為形狀點擊指定超連結（跳轉至投影片、檔案、網址或電子郵件）。

**如何保護矩形不被移動或變更？**

使用形狀鎖定：可禁止移動、調整大小、選取或文字編輯，以維護版面配置。

**我可以將矩形轉換為點陣圖或 SVG 嗎？**

可以。您可以將 [shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage) 以指定尺寸/比例渲染為影像，或 [export it as SVG](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/) 供向量使用。

**如何快速取得考慮佈景主題與繼承的矩形實際（有效）屬性？**

[使用形狀的 effective properties](/slides/zh-hant/php-java/shape-effective-properties/)：API 會回傳考慮佈景主題樣式、版面配置與本地設定的計算值，簡化格式分析。