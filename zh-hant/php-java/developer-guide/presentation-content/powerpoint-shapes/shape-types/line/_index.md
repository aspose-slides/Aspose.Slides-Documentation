---
title: 在 PHP 中向簡報新增線條形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/php-java/line/
keywords:
- 線條
- 建立線條
- 新增線條
- 純線條
- 設定線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中操作線條格式設定。探索屬性、方法與範例。"
---
## **概觀**

Aspose.Slides 讓您能以程式方式在 PowerPoint 投影片中新增線條形狀。本篇說明如何建立簡單的線條以及如何將線條自訂為箭頭形狀。

您將學會如何將線條形狀加入投影片、調整其外觀，並將更新後的簡報儲存。範例著重於實用的線條格式設定，例如樣式、寬度、虛線模式、箭頭樣式以及填色。

## **建立純線條**

要在簡報的特定投影片上加入一條簡單的純線條，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 以索引取得投影片的參考。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，加入類型為 Line 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們在簡報的第一張投影片加入了一條線條。

```php
  # 實例化代表 PPTX 檔案的 PresentationEx 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增類型為 line 的 AutoShape
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 將 PPTX 寫入磁碟
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **建立箭頭形狀線條**

Aspose.Slides for PHP via Java 也允許開發者設定線條的多項屬性，使其外觀更具吸引力。以下示範如何設定線條屬性，使其呈現為箭頭。請依照下列步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 以索引取得投影片的參考。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，加入類型為 Line 的 AutoShape。
- 將 [Line Style](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LineStyle) 設為 Aspose.Slides for PHP via Java 所提供的樣式之一。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LineDashStyle) 設為 Aspose.Slides for PHP via Java 所提供的樣式之一。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LineArrowheadLength)。
- 設定線條終點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LineArrowheadLength)。
- 將修改後的簡報寫入為 PPTX 檔案。

```php
  # 實例化代表 PPTX 檔案的 PresentationEx 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增類型為 line 的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 對線條套用一些格式設定
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # 將 PPTX 寫入磁碟
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我能將一般線條轉換為連接線，使其「自動吸附」到圖形嗎？**

不能。一般線條（屬於 type 為 [Line](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)）不會自動變成連接線。若要讓線條吸附到圖形，請使用專門的 [Connector](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/) 類型，並使用 [相應的 API](/slides/zh-hant/php-java/connector/) 進行連接。

**如果線條的屬性是從佈景主題繼承而來，且難以確定最終值，我該怎麼辦？**

請透過 `LineFormatEffectiveData`/`LineFillFormatEffectiveData` 讀取[有效屬性](/slides/zh-hant/php-java/shape-effective-properties/)，這些資料已經考慮了繼承與佈景主題樣式。

**我可以鎖定線條，使其無法編輯（移動、調整大小）嗎？**

可以。形狀提供了[鎖定物件](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/getautoshapelock/)，讓您禁止編輯操作。