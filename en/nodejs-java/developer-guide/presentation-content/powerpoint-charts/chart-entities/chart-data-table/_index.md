---
title: Chart Data Table
type: docs
url: /nodejs-java/chart-data-table/
---

## **Set Font Properties for Chart Data Table**

Aspose.Slides for Node.js via Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

 Below sample example is given. 

```javascript
// Creating empty presentation
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

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Yes. The data table supports [legend keys](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/), and you can turn them on or off.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart as part of the slide, so the exported [PDF](/slides/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/nodejs-java/convert-powerpoint-to-png/) includes the chart with its data table.

**Are data tables supported for charts that come from a template file?**

Yes. For any chart loaded from an existing presentation or template, you can check and change whether a data table [is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) using the chart’s properties.

**How can I quickly find which charts in a file have the data table enabled?**

Inspect each chart’s property that indicates whether the data table [is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) and iterate through the slides to identify the charts where it is enabled.
