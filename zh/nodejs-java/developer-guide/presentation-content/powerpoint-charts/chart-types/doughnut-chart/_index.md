---
title: 环形图
type: docs
weight: 30
url: /zh/nodejs-java/doughnut-chart/
---

## **更改环形图的中心间隙**
{{% alert color="primary" %}} 
Aspose.Slides for Node.js via Java 现在支持在环形图中指定孔的大小。本文将通过示例演示如何指定环形图中孔的大小。
{{% /alert %}} 

要指定环形图中孔的大小，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 对象。  
1. 在幻灯片上添加环形图。  
1. 指定环形图中孔的大小。  
1. 将演示文稿写入磁盘。  

下面的示例中，我们已经设置了环形图中孔的大小。  
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // 将演示文稿写入磁盘
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以创建具有多个环的多层环形图吗？**

是的。向单个环形图添加多个系列——每个系列都会成为一个独立的环。环的顺序由系列在集合中的顺序决定。

**是否支持“炸开”的环形图（切片分离）？**

是的。存在一种“炸开环形图”[chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)以及数据点的爆炸属性；您可以分离单个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

图表是一种形状；您可以将其渲染为[光栅图像](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)或将图表导出为[SVG 图像](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)。