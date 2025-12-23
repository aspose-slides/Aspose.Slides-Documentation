---
title: 使用 PHP 在演示文稿中自定义图表数据表
linktitle: 数据表
type: docs
url: /zh/php-java/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 为 PPT 和 PPTX 自定义图表数据表，提高演示文稿的效率和吸引力。"
---

## **设置图表数据表的字体属性**
Aspose.Slides for PHP via Java 提供了更改系列中类别颜色的支持。

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表数据表。
1. 设置字体高度。
1. 保存已修改的演示文稿。

下面给出示例。
```php
  # 创建空演示文稿
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以在图表数据表的数值旁显示小图例键吗？**

可以。数据表支持 [legend keys](https://reference.aspose.com/slides/php-java/aspose.slides/datatable/setshowlegendkey/)，您可以打开或关闭它们。

**导出演示文稿为 PDF、HTML 或图像时，数据表会被保留吗？**

可以。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/php-java/convert-powerpoint-to-html/)/[image](/slides/zh/php-java/convert-powerpoint-to-png/) 包含带有数据表的图表。

**从模板文件中加载的图表是否支持数据表？**

可以。对于从现有演示文稿或模板加载的任何图表，您可以使用图表属性检查并更改数据表是否[显示](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/)。

**如何快速查找文件中哪些图表启用了数据表？**

检查每个图表的属性，以指示数据表是否[显示](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/)，并遍历幻灯片以识别已启用数据表的图表。