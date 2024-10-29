---
title: 图表数据表
type: docs
url: /zh/php-java/chart-data-table/
---

## **为图表数据表设置字体属性**
Aspose.Slides for PHP via Java支持更改系列颜色中的类别颜色。

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出了示例代码。

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