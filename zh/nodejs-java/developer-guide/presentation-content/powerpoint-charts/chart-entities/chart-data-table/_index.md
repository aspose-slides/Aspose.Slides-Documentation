---
title: 图表数据表
type: docs
url: /zh/nodejs-java/chart-data-table/
---

## **设置图表数据表的字体属性**

Aspose.Slides for Node.js via Java 提供了更改系列颜色中类别颜色的支持。

1. 实例化[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类对象。
1. 在幻灯片上添加图表。
1. 设置图表数据表。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出示例。  
```javascript
// 创建空的演示文稿
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以在图表数据表的数值旁显示小的图例键吗？**

是的。数据表支持[legend keys](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/)，您可以打开或关闭它们。

**在将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

是的。Aspose.Slides 将图表呈现为幻灯片的一部分，因此导出的[PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/zh/nodejs-java/convert-powerpoint-to-png/)包含带有数据表的图表。

**来自模板文件的图表是否支持数据表？**

是的。对于从现有演示文稿或模板加载的任何图表，您可以使用图表的属性检查并更改数据表是否[is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/)。

**如何快速查找文件中哪些图表启用了数据表？**

检查每个图表的属性，以确定数据表是否[is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/)，并遍历幻灯片以识别启用了该功能的图表。