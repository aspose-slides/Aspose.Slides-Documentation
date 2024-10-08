---
title: 圆环图
type: docs
weight: 30
url: /androidjava/doughnut-chart/
---

## **更改圆环图中的中心孔大小**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 现在支持指定圆环图中孔的大小。在本主题中，我们将通过示例查看如何指定圆环图中孔的大小。

{{% /alert %}} 

要指定圆环图中孔的大小，请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 对象。
1. 在幻灯片上添加圆环图。
1. 指定圆环图中孔的大小。
1. 将演示文稿写入磁盘。

在下面给出的示例中，我们设置了圆环图中孔的大小。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // 将演示文稿写入磁盘
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```