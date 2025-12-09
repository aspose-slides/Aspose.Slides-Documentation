---
title: 错误棒
type: docs
url: /zh/nodejs-java/error-bar/
---

## **添加误差棒**

Aspose.Slides for Node.js via Java 提供了一个用于管理误差棒值的简单 API。当使用自定义值类型时适用示例代码。要指定值，请使用系列的 [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 在所需幻灯片上添加气泡图。  
1. 访问第一个图表系列并设置误差棒 X 格式。  
1. 访问第一个图表系列并设置误差棒 Y 格式。  
1. 设置误差棒的值和格式。  
1. 将修改后的演示文稿写入 PPTX 文件。  
```javascript
// 创建 Presentation 类实例
    var pres = new aspose.slides.Presentation();
    try {
        // 创建气泡图
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
        // 添加误差棒并设置其格式
        var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
        var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
        errBarX.isVisible();
        errBarY.isVisible();
        errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
        errBarX.setValue(0.1);
        errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
        errBarY.setValue(5);
        errBarX.setType(aspose.slides.ErrorBarType.Plus);
        errBarY.getFormat().getLine().setWidth(2.0);
        errBarX.hasEndCap();
        // 保存演示文稿
        pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **添加自定义误差棒值**

Aspose.Slides for Node.js via Java 提供了一个用于管理自定义误差棒值的简单 API。当 [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) 属性等于 **Custom** 时适用示例代码。要指定值，请使用系列的 [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 在所需幻灯片上添加气泡图。  
1. 访问第一个图表系列并设置误差棒 X 格式。  
1. 访问第一个图表系列并设置误差棒 Y 格式。  
1. 访问图表系列的各个数据点并为单个系列数据点设置误差棒值。  
1. 设置误差棒的值和格式。  
1. 将修改后的演示文稿写入 PPTX 文件。  
```javascript
// 创建 Presentation 类实例
var pres = new aspose.slides.Presentation();
try {
    // 创建气泡图
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // 添加自定义误差棒并设置其格式
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // 访问图表系列数据点并为其设置误差棒值用于
    // 单个数据点
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // 为图表系列点设置误差棒
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // 保存演示文稿
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**将演示文稿导出为 PDF 或图像时误差棒会怎么样？**

它们作为图表的一部分进行渲染，并在转换过程中与图表的其余格式一起保留下来，前提是使用兼容的版本或渲染器。

**误差棒可以与标记和数据标签组合使用吗？**

可以。误差棒是独立的元素，且与标记和数据标签兼容；如果元素重叠，可能需要调整格式。

**在哪里可以找到用于操作误差棒的属性和枚举列表？**

在 API 参考中：[ErrorBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarsformat/) 类以及相关枚举 [ErrorBarType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarvaluetype/)。