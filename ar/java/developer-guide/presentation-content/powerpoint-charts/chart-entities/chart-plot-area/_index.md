---
title: منطقة رسم المخطط
type: docs
url: /java/chart-plot-area/
---


## **الحصول على عرض وارتفاع منطقة رسم المخطط**
تقدم Aspose.Slides لجافا واجهة برمجة تطبيقات بسيطة لـ . 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. استدعاء طريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) قبل الحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي لـ X (اليسار) لعنصر المخطط بالنسبة للزاوية اليسرى العلوية للمخطط.
1. الحصول على الجزء العلوي الفعلي لعنصر المخطط بالنسبة للزاوية اليسرى العلوية للمخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين وضع تخطيط منطقة رسم المخطط**
تقدم Aspose.Slides لجافا واجهة برمجة تطبيقات بسيطة لتعيين وضع تخطيط منطقة رسم المخطط. تمت إضافة الطريقتين [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) إلى فئة [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) وواجهة [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). إذا تم تعريف تخطيط منطقة الرسم يدويًا، فإن هذه الخاصية تحدد ما إذا كان يجب تخطيط منطقة الرسم من الداخل (لا تشمل المحاور وعناوين المحاور) أو من الخارج (تشمل المحاور وعناوين المحاور). هناك قيمتان محتملتان تم تعريفهما في تعداد [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - تحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم، دون تضمين علامات التTick وأسماء المحاور.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - تحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم، وعلامات التTick، وأسماء المحاور.

تم تقديم كود نموذج أدناه.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```