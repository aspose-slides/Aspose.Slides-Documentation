---
title: 使用 PHP 管理演示文稿中的图表数据标记
linktitle: 数据标记
type: docs
url: /zh/php-java/chart-data-marker/
keywords:
- 图表
- 数据点
- 标记
- 标记选项
- 标记大小
- 填充类型
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP 中自定义图表数据标记，通过清晰的代码示例提升 PPT 和 PPTX 格式演示文稿的效果。"
---

## **设置图表标记选项**
可以在特定系列的图表数据点上设置标记。要设置图表标记选项，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新数据点。
- 将演示文稿写入磁盘。

在下面的示例中，我们已在数据点级别设置了图表标记选项。
```php
  # 创建空演示文稿
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 创建默认图表
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # 获取默认图表数据工作表索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 删除示例系列
    $chart->getChartData()->getSeries()->clear();
    # 添加新系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # 加载图片 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # 加载图片 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # 获取第一个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 在此处添加新数据点 (1:3)。
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
    # 保存带有图表的演示文稿
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**开箱即用的标记形状有哪些？**

标准形状可用（圆形、方形、菱形、三角形等）；该列表由 [MarkerStyleType](https://reference.aspose.com/slides/php-java/aspose.slides/markerstyletype/) 类定义。如果需要非标准形状，可使用带图片填充的标记来模拟自定义视觉效果。

**将图表导出为图像或 SVG 时，标记会被保留吗？**

是的。在将图表渲染为 [光栅格式](/slides/zh/php-java/convert-powerpoint-to-png/) 或保存 [形状为 SVG](/slides/zh/php-java/render-a-slide-as-an-svg-image/) 时，标记会保留其外观和设置，包括大小、填充和轮廓。