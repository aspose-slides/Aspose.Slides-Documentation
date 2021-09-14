---
title: Chart Data Table
type: docs
url: /java/chart-data-table/
---

## **Set Font Properties for Chart Data Table**
Aspose.Slides for Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

 Below sample example is given. 

```php
// Creating empty presentation
$pres = new Java("com.aspose.slides.Presentation");
try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(Java("com.aspose.slides.ChartType")->ClusteredColumn, 50, 50, 600, 400);

    $chart->setDataTable(true);

    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(Java("com.aspose.slides.NullableBool")->True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);

    $pres->save("output.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```