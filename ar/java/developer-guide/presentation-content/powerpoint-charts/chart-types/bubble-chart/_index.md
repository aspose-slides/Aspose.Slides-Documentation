---
title: مخطط الفقاعات
type: docs
url: /java/bubble-chart/
---

## **تغيير حجم مخطط الفقاعات**
توفر Aspose.Slides لـ Java دعمًا لتغيير حجم مخطط الفقاعات. تم إضافة طرق [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--)، [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) و [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-). أدناه مثال توضيحي.

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
تمت إضافة طرق [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) و [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) إلى واجهات [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries) و [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup) والفئات المتعلقة بها. **BubbleSizeRepresentation** يحدد كيفية تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Area) و [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Width). وبناءً على ذلك، تمت إضافة تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType) لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. الكود النموذجي مذكور أدناه.

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