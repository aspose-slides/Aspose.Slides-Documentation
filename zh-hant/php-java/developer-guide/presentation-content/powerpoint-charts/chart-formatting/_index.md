---
title: 在 PHP 中格式化簡報圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/php-java/chart-formatting/
keywords:
- 格式化圖表
- 圖表格式化
- 圖表實體
- 圖表屬性
- 圖表設定
- 圖表選項
- 字型屬性
- 圓角邊框
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習在 Aspose.Slides for PHP via Java 中的圖表格式化，並以專業且吸睛的風格提升您的 PowerPoint 簡報。"
---
## **概述**

本文章說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它展示了如何自訂關鍵圖表元素，如座標軸、格線、標題、圖例、繪圖區域和牆面填充，以提升圖表資料的外觀與可讀性。  
它還示範了如何設定圖表文字的字型屬性、將預設與自訂數字格式套用至圖表資料，以及啟用圖表區域的圓角。這些範例共同說明了如何在簡報中同時控制圖表的視覺樣式與資料呈現。

## **格式化圖表實體**
Aspose.Slides for PHP via Java 讓開發人員能從頭開始在投影片中新增自訂圖表。本文說明如何格式化不同的圖表實體，包括圖表類別軸與數值軸。  

Aspose.Slides for PHP via Java 提供簡易的 API，以管理不同的圖表實體並使用自訂值進行格式化：

1. 建立 [**Presentation**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依照索引取得投影片的參考。
1. 新增具有預設資料的圖表，並選擇任意所需類型（此範例使用 ChartType::LineWithMarkers）。
1. 存取圖表的數值軸，並設定以下屬性：
   1. 為數值軸主要格線設定 **Line format**
   1. 為數值軸次要格線設定 **Line format**
   1. 為數值軸設定 **Number Format**
   1. 為數值軸設定 **Min, Max, Major and Minor units**
   1. 為數值軸資料設定 **Text Properties**
   1. 為數值軸設定 **Title**
   1. 為數值軸設定 **Line Format**
1. 存取圖表的類別軸，並設定以下屬性：
   1. 為類別軸主要格線設定 **Line format**
   1. 為類別軸次要格線設定 **Line format**
   1. 為類別軸資料設定 **Text Properties**
   1. 為類別軸設定 **Title**
   1. 為類別軸設定 **Label Positioning**
   1. 為類別軸標籤設定 **Rotation Angle**
1. 存取圖表圖例，並為其設定 **Text Properties**
1. 設定顯示圖表圖例且不與圖表重疊
1. 存取圖表的 **Secondary Value Axis**，並設定以下屬性：
   1. 啟用次要 **Value Axis**
   1. 為次要數值軸設定 **Line Format**
   1. 為次要數值軸設定 **Number Format**
   1. 為次要數值軸設定 **Min, Max, Major and Minor units**
1. 現在在次要數值軸上繪製第一個圖表系列
1. 設定圖表背牆填色
1. 設定圖表繪圖區域填色
1. 將修改後的簡報寫入 PPTX 檔案

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 存取第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 加入範例圖表
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # 設定圖表標題
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # 設定數值軸主要格線格式
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # 設定數值軸次要格線格式
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # 設定數值軸數字格式
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # 設定圖表最大值與最小值
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # 設定數值軸文字屬性
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # 設定數值軸標題
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # 設定類別軸主要格線格式
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # 設定類別軸次要格線格式
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # 設定類別軸文字屬性
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # 設定類別軸標題
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # 設定類別軸標籤位置
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # 設定類別軸標籤旋轉角度
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # 設定圖例文字屬性
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # 設定顯示圖例而不與圖表重疊
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # 設定次要數值軸
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # 設定次要數值軸數字格式
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # 設定圖表最大值與最小值
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # 設定圖表背牆顏色
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 設定繪圖區域顏色
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # 儲存簡報
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定圖表的字型屬性**
Aspose.Slides for PHP via Java 提供設定圖表字型相關屬性的支援。請依照以下步驟設定圖表的字型屬性。

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別物件。
- 在投影片上新增圖表。
- 設定字型高度。
- 儲存修改後的簡報。

以下提供範例。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定數值格式**
Aspose.Slides for PHP via Java 提供簡易的 API 以管理圖表資料格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 依索引取得投影片的參考。
1. 新增具有預設資料的圖表，並選擇任意所需類型（此範例使用 **ChartType::ClusteredColumn**）。
1. 從可能的預設值中設定預設數字格式。
1. 遍歷每個圖表系列的圖表資料儲存格，並設定圖表資料的數字格式。
1. 儲存簡報。
1. 設定自訂數字格式。
1. 在每個圖表系列的圖表資料儲存格中遍歷，設定不同的圖表資料數字格式。
1. 儲存簡報。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 存取第一張簡報投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增預設的叢集柱狀圖表
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # 取用圖表系列集合
    $series = $chart->getChartData()->getSeries();
    # 遍歷每個圖表系列
    foreach($series as $ser) {
      # 遍歷系列中的每個資料儲存格
      foreach($ser->getDataPoints() as $cell) {
        # 設定數字格式
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%
      }
    }
    # 儲存簡報
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

下表列出了可用的預設數字格式值及其對應的索引：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **設定圖表區域圓角邊框**
Aspose.Slides for PHP via Java 提供設定圖表區域的支援。已在 [Chart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Chart) 類別中加入方法 [**hasRoundedCorners**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/hasroundedcorners/) 和 [**setRoundedCorners**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/setroundedcorners/)。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別物件。
1. 在投影片上新增圖表。
1. 設定圖表的填充類型與填充顏色
1. 將圓角屬性設為 True。
1. 儲存修改後的簡報。

以下提供範例。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以為柱狀圖/區域設定半透明填充，同時保持邊框不透明嗎？**

可以。填充透明度與輪廓是分別設定的。這在密集視覺化中有助於提升格線與資料的可讀性。

**當資料標籤重疊時，我該如何處理？**

縮小字型大小、停用非必要的標籤組件（例如類別）、設定標籤的偏移/位置、必要時僅顯示選取資料點的標籤，或將格式改為「值 + 圖例」。

**我可以對系列套用漸層或圖案填充嗎？**

可以。通常都提供實色與漸層/圖案填充。實務上請節制使用漸層，並避免與格線和文字的對比度降低的組合。