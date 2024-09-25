---
title: Bubble Chart
type: docs
url: /nodejs-java/bubble-chart/
---

## **Bubble Chart Size Scaling**
Aspose.Slides for Node.js via Java provides support for Bubble chart size scaling. In Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) and [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) methods have been added. Below sample example is given. 

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
        chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
        pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Represent Data as Bubble Chart Sizes**
Methods [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) and [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) have been added to [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup) interfaces, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) and [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Accordingly, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType) enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
        chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
        pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
