---
title: 使用 PHP 定制演示文稿中的环形图
linktitle: 环形图
type: docs
weight: 30
url: /zh/php-java/doughnut-chart/
keywords:
- 环形图
- 中心空隙
- 孔径
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中创建并自定义环形图，支持 PowerPoint 格式的动态演示文稿。"
---

## **指定环形图的中心空隙**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 现在支持指定环形图中孔的大小。在本主题中，我们将通过示例展示如何指定环形图中孔的大小。

{{% /alert %}} 

为指定环形图中孔的大小，请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 对象。
1. 在幻灯片上添加环形图。
1. 指定环形图中孔的大小。
1. 将演示文稿写入磁盘。

在下面的示例中，我们已经设置了环形图中孔的大小。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # 将演示文稿写入磁盘
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**我可以创建具有多个环的多层环形图吗？**

是的。向单个环形图添加多个系列——每个系列都会成为单独的环。环的顺序由系列在集合中的顺序决定。

**是否支持“分裂”环形图（分离的切片）？**

是的。有一个 Exploded Doughnut [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 以及数据点的 explosion 属性；您可以分离各个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

图表是一种形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) 或将图表导出为 [SVG image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg)。