---
title: مخطط الفقاعات
type: docs
url: /androidjava/bubble-chart/
---

## **تغيير حجم مخطط الفقاعات**
توفر Aspose.Slides لنظام Android عبر Java دعم تغيير حجم مخطط الفقاعات. تم إضافة الطرق [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--)، [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) و [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-). فيما يلي مثال على ذلك.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تمثيل البيانات كأحجام مخطط الفقاعات**
تمت إضافة الطريقتين [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) و [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) إلى واجهات [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries) و [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) والفئات ذات الصلة. **BubbleSizeRepresentation** يحدد كيفية تمثيل قيم حجم الفقاعة في مخطط الفقاعات. القيم الممكنة هي: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) و [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). وبناءً عليه، تم إضافة تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. إليك مثال على الكود.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```