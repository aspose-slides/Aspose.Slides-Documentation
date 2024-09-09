---
title: Chart Data Table
type: docs
url: /java/chart-data-table/
---

## **Set Font Properties for Chart Data Table**
Aspose.Slides for Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

 Below sample example is given. 

```javascript
    // Creating empty presentation
    var pres = new  com.aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(com.aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
        chart.setDataTable(true);
        chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(com.aspose.slides.NullableBool.True);
        chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
        pres.save("output.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
