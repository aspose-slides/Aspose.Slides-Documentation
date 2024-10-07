---
title: منطقة رسم المخطط
type: docs
url: /androidjava/chart-plot-area/
---

## **احصل على عرض وارتفاع منطقة رسم المخطط**
يوفر Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. أضف مخططًا بالبيانات الافتراضية.
1. استدعاء [method IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) للحصول على القيم الفعلية.
1. الحصول على موقع X الفعلي (اليسار) لعنصر المخطط بالنسبة للزاوية العليا اليسرى من المخطط.
1. الحصول على الجزء العلوي الفعلي لعنصر المخطط بالنسبة للزاوية العليا اليسرى من المخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.

```java
// Create an instance of Presentation class
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
يوفر Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة لتعيين وضع التخطيط لمنطقة رسم المخطط. تم إضافة الطريقتين [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) إلى فئة [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) وواجهة [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea). إذا كان تخطيط منطقة الرسم محددًا يدويًا، فإن هذه الخاصية تحدد ما إذا كان يجب تخطيط منطقة الرسم داخلها (لا تشمل المحاور وعلامات المحاور) أو خارجها (تشمل المحاور وعلامات المحاور). هناك قيمتان ممكنتان تم تحديدهما في تعداد [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - تحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم، دون تضمين علامات الترقيم وعلامات المحاور.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - تحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم، وعلامات الترقيم، وعلامات المحاور.

يتم إعطاء كود عينة أدناه.

```java
// Create an instance of Presentation class
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