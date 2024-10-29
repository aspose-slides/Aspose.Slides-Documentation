---
title: حسابات المخطط
type: docs
weight: 50
url: /ar/java/chart-calculations/
---

## **حساب القيم الفعلية لعناصر المخطط**
يوفر Aspose.Slides لـ Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. تقدم خصائص واجهة [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) معلومات حول الموقع الفعلي لعنصر مخطط المحور ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--)، [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--)، [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--)، [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--)، [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--)، [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **حساب الموقع الفعلي لعناصر المخطط الأم**
يوفر Aspose.Slides لـ Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. تقدم خصائص واجهة [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) معلومات حول الموقع الفعلي لعنصر المخطط الأم ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--)، [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--)، [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--)، [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **إخفاء المعلومات عن المخطط**
يساعدك هذا الموضوع على فهم كيفية إخفاء المعلومات عن المخطط. باستخدام Aspose.Slides لـ Java يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و**خطوط الشبكة** من المخطط. يوضح مثال الكود أدناه كيفية استخدام هذه الخصائص.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //إخفاء عنوان المخطط
    chart.setTitle(false);

    ///إخفاء محور القيم
    chart.getAxes().getVerticalAxis().setVisible(false);

    //رؤية محور الفئة
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //إخفاء الأسطورة
    chart.setLegend(false);

    //إخفاء MajorGridLines
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //تعيين لون خط السلسلة
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```