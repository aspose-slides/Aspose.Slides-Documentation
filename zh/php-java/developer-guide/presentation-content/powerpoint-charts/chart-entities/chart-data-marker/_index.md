---
title: 图表数据标记
type: docs
url: /php-java/chart-data-marker/
---

## **设置图表标记选项**
可以在特定系列中的图表数据点上设置标记。为了设置图表标记选项，请按照以下步骤进行操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新数据点。
- 将演示文稿写入磁盘。

在下面给出的示例中，我们在数据点级别上设置了图表标记选项。

```php
  # 创建空演示文稿
  $pres = new Presentation();
  try {
    # 访问第一个幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 创建默认图表
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # 获取默认图表数据工作表索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 删除演示系列
    $chart->getChartData()->getSeries()->clear();
    # 添加新系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "系列 1"), $chart->getType());
    # 加载图片 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # 加载图片 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # 获取第一个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 在此添加新点（1:3）。
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # 更改图表系列标记
    $series->getMarker()->setSize(15);
    # 保存包含图表的演示文稿
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```