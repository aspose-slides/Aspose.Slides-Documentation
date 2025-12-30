---
title: 在 PHP 中为演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/php-java/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 快速在 PowerPoint 图表中添加和自定义趋势线——一个帮助您吸引观众的实用指南。"
---

## **添加趋势线**
Aspose.Slides for PHP via Java 提供了一个简易 API，用于管理不同图表的趋势线：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表，并指定所需类型（本示例使用 ChartType::ClusteredColumn）。
4. 为图表系列 1 添加指数趋势线。
5. 为图表系列 1 添加线性趋势线。
6. 为图表系列 2 添加对数趋势线。
7. 为图表系列 2 添加移动平均趋势线。
8. 为图表系列 3 添加多项式趋势线。
9. 为图表系列 3 添加幂趋势线。
10. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带有趋势线的图表。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 创建聚簇柱形图
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # 为图表系列 1 添加指数趋势线
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # 为图表系列 1 添加线性趋势线
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 为图表系列 2 添加对数趋势线
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # 为图表系列 2 添加移动平均趋势线
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # 为图表系列 3 添加多项式趋势线
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # 为图表系列 3 添加幂趋势线
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # 保存演示文稿
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **添加自定义线**
Aspose.Slides for PHP via Java 提供了一个简易 API，用于在图表中添加自定义线。要在演示文稿的选定幻灯片上添加一条普通直线，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例
- 使用其 Index 获取幻灯片的引用
- 使用 Shapes 对象提供的 AddChart 方法创建新图表
- 使用 Shapes 对象提供的 AddAutoShape 方法添加线类型的 AutoShape
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带有自定义线的图表。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**趋势线的“forward”和“backward”是什么意思？**

它们是趋势线向前/向后投射的长度：对于散点 (XY) 图表——以坐标轴单位计；对于非散点图表——以类别数量计。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

是的。Aspose.Slides 将演示文稿转换为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/php-java/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。同时还提供了将图表本身[导出为图像](/slides/zh/php-java/create-shape-thumbnails/)的方法。