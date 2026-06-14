---
title: 使用 PHP 自訂簡報中的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/php-java/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中建立並自訂 3-D 圖表，支援 PPT 與 PPTX 檔案 — 立即提升您的簡報效果。"
---
## **概觀**

本文說明如何透過設定 `Rotation3D`（例如 `RotationX`、`RotationY`、`DepthPercents` 與 `RightAngleAxes`）來自訂 Aspose.Slides 中的 3D 圖表。內容涵蓋建立簡報、加入預設資料的 3D 圖表、套用必要的 3D 觀察設定，並將修改後的簡報另存為 PPTX 檔案的步驟。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**

Aspose.Slides for PHP via Java 提供簡易的 API 以設定這些屬性。以下說明將協助您設定 **X、Y 旋轉、DepthPercents** 等不同屬性。範例程式碼示範了上述屬性的設定方式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 取得第一張投影片。  
3. 新增含預設資料的圖表。  
4. 設定 Rotation3D 屬性。  
5. 將修改後的簡報寫入 PPTX 檔案。

```php
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 加入預設資料的圖表
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # 設定圖表資料工作表的索引
    $defaultWorksheetIndex = 0;
    # 取得圖表資料工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 新增資料系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # 新增類別
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # 設定 Rotation3D 屬性
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # 取得第二個圖表系列
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 現在填入系列資料
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # 設定 Overlap 值
    $series->getParentSeriesGroup()->setOverlap(100);
    # 將簡報寫入磁碟
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援多種 3D 柱狀圖，包括 Column 3D、Clustered Column 3D、Stacked Column 3D、以及 100% Stacked Column 3D，並可透過 [ChartType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/charttype/) 類別取得相關的 3D 類型。欲取得最新且完整的清單，請參考您所安裝版本的 API 參考文件中 [ChartType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖（raster image）用於報告或網頁嗎？**

可以。您可以使用 [chart API](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage) 將圖表匯出為影像，或將整張投影片[轉換為 PNG 或 JPEG](/slides/zh-hant/php-java/convert-powerpoint-to-png/)。這在需要像素級預覽或將圖表嵌入文件、儀表板或網頁而不需 PowerPoint 時非常有用。

**建立與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳表現，建議盡量減少 3D 效果、避免在牆面與圖表區域使用大量紋理、在可能的情況下限制每個資料系列的資料點數量，並依目標顯示或列印需求，將輸出解析度與尺寸設定為適當大小。