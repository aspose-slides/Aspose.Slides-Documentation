---
title: 在 PHP 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/php-java/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡軌跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件 — 使用 Aspose.Slides for PHP via Java 建立、編輯與樣式化數位墨跡。取得軌跡、筆刷顏色與大小的程式碼範例。"
---
## **簡介**

PowerPoint 提供了墨跡功能，讓您能夠繪製非標準圖形，可用於突顯其他物件、展示連接與流程，並將注意力聚焦於投影片上的特定項目。

Aspose.Slides 提供了所有 Ink 類型（例如[Ink](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ink/) 類別），讓您能夠建立與管理墨跡物件。

## **常規物件與墨跡物件的差異**

PowerPoint 投影片上的物件通常以形狀物件表示。形狀物件在最簡單的形式下是一個容器，用來定義物件本身的區域（其框架）以及相關屬性。後者包括容器區域大小、容器形狀、容器背景等。相關資訊請參閱[Shape Layout Format](https://docs.aspose.com/slides/zh-hant/php-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略物件框架（容器）的所有屬性，僅保留其大小。容器區域的大小由標準的 `width` 與 `height` 值決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡形狀追蹤**

Trace 是用來記錄使用者以筆寫入數位墨跡時筆跡軌跡的基本元素或標準。Trace 為描述連續點序列的錄製。

最簡單的編碼形式指定每個取樣點的 X 與 Y 座標。當所有連接點被繪製時，會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

您可以使用筆刷繪製連接追蹤元素點的線條。筆刷具有自己的顏色與大小，分別對應 `Brush.Color` 與 `Brush.Size` 屬性。

### **設定墨跡筆刷顏色**

以下 PHP 程式碼示範如何設定筆刷的顏色：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **設定墨跡筆刷大小**

以下 PHP 程式碼示範如何設定筆刷的大小：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

通常筆刷的寬度與高度不相同，PowerPoint 因此不會顯示筆刷大小（資料區段為灰色）。但當筆刷的寬度與高度相同時，PowerPoint 會以以下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明，我們將墨跡物件的高度提升，並檢視重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條的粗細為零（見最後一張圖）。

因此，要確定整個墨跡物件的可見區域，必須考慮追蹤物件的筆刷大小。此處，目標物件（手寫文字追蹤物件）已被縮放至容器（框架）大小。當容器（框架）尺寸變化時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在處理文字時也會呈現相同的行為：

![ink_powerpoint6](ink_powerpoint6.png)

**進一步閱讀**

* 若要了解一般形狀，請參閱[PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/php-java/powerpoint-shapes/) 章節。  
* 若需取得有效值的更多資訊，請參閱[Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/php-java/shape-effective-properties/#getting-effective-font-height-value)。