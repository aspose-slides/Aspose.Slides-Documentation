---
title: 在 PHP 中导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/php-java/export-chart/
keywords:
- 图表
- 图表转图像
- 图表为图像
- 提取图表图像
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 导出演示文稿图表，支持 PPT 和 PPTX 格式，并将报告流畅集成到任何工作流中。"
---

## **获取图表图像**
Aspose.Slides for PHP via Java 提供了提取特定图表图像的支持。下面给出示例代码。  
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以将图表导出为矢量（SVG）而不是光栅图像吗？**

是的。图表是一个形状，其内容可以使用[shape-to-SVG保存方法](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)保存为SVG。

**我如何以像素为单位设置导出图表的精确尺寸？**

使用允许指定大小或比例的图像渲染重载——库支持使用给定的尺寸/比例渲染对象。

**如果在导出后标签和图例中的字体显示不正确，我该怎么办？**

[加载所需字体](/slides/zh/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) ，以便图表渲染保留度量和文本外观。

**导出是否遵循 PowerPoint 的主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式（主题、样式、填充、效果），因此图表的外观得以保留。

**我在哪里可以找到除图表图像之外的可用渲染/导出功能？**

请参阅[API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[文档](/slides/zh/php-java/convert-powerpoint/)了解输出目标（[PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/php-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/php-java/convert-powerpoint-to-html/)、等）以及相关的渲染选项。