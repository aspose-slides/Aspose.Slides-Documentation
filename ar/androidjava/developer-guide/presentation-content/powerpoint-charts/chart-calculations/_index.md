---
title: حسابات الرسم البياني
type: docs
weight: 50
url: /androidjava/chart-calculations/
---

## **حساب القيم الفعلية لعناصر الرسم البياني**
تقدم Aspose.Slides لـ Android عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص واجهة [IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) معلومات عن الوضع الفعلي لعناصر الرسم البياني المحور ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--)، [IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--)، [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--)، [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--)، [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--)، [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.

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

## **حساب الوضع الفعلي لعناصر الرسم البياني الأب**
تقدم Aspose.Slides لـ Android عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص واجهة [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) معلومات عن الوضع الفعلي لعناصر الرسم البياني الأب ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--)، [IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--)، [IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--)، [IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.

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

## **إخفاء المعلومات من الرسم البياني**
تساعدك هذه الموضوعات على فهم كيفية إخفاء المعلومات من الرسم البياني. باستخدام Aspose.Slides لـ Android عبر Java يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و **خطوط الشبكة** من الرسم البياني. يظهر المثال البرمجي أدناه كيفية استخدام هذه الخصائص.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //إخفاء عنوان الرسم البياني
    chart.setTitle(false);

    ///إخفاء محور القيم
    chart.getAxes().getVerticalAxis().setVisible(false);

    //رؤية المحور الفئوي
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //إخفاء التفسير
    chart.setLegend(false);

    //إخفاء الخطوط الرئيسية للشبكة
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