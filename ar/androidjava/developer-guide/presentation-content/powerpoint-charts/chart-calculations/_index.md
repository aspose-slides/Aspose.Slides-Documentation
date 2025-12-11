---
title: تحسين حسابات المخطط للعروض التقديمية على Android
linktitle: حسابات المخطط
type: docs
weight: 50
url: /ar/androidjava/chart-calculations/
keywords:
  - حسابات المخطط
  - عناصر المخطط
  - موضع العنصر
  - الموضع الفعلي
  - العنصر الفرعي
  - العنصر الرئيسي
  - قيم المخطط
  - القيمة الفعلية
  - PowerPoint
  - العرض التقديمي
  - Android
  - Java
  - Aspose.Slides
description: "فهم حسابات المخطط وتحديثات البيانات والتحكم في الدقة في Aspose.Slides لنظام Android للـ PPT و PPTX، مع أمثلة عملية على كود Java."
---

## **حساب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides for Android عبر Java API بسيط للحصول على هذه الخصائص. توفر خصائص واجهة [IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) معلومات حول الموقع الفعلي لعناصر المخطط المحورية ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--),[IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--),[IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--),[IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--),[IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--),[IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **حساب الموقع الفعلي لعناصر المخطط الأب**
توفر Aspose.Slides for Android عبر Java API بسيط للحصول على هذه الخصائص. خصائص واجهة [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) توفر معلومات حول الموقع الفعلي لعناصر المخطط الأب ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--),[IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--),[IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--),[IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **إخفاء عناصر المخطط**
هذا الموضوع يساعدك على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for Android عبر Java يمكنك إخفاء **العنوان، المحور الرأسي، المحور الأفقي** و **خطوط الشبكة** من المخطط. مثال الشيفرة أدناه يوضح كيفية استخدام هذه الخصائص.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //إخفاء عنوان المخطط
    chart.setTitle(false);

    ///إخفاء محور القيم
    chart.getAxes().getVerticalAxis().setVisible(false);

    //إخفاء محور الفئات
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //إخفاء وسيلة الإيضاح
    chart.setLegend(false);

    //إخفاء خطوط الشبكة الرئيسية
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


## **الأسئلة المتداولة**

**هل تعمل دفاتر Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**
نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال أو تحديث المصدر الخارجي، تُؤخذ الصيغ والقيم من ذلك الدفتر، ويظهر المخطط التحديثات أثناء عمليات الفتح/التعديل. تتيح لك الواجهة البرمجية [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**
نعم. [خطوط الاتجاه](/slides/ar/androidjava/trend-line/) (خطية، أسية، وغيرها) تُضاف وتُحدَّث بواسطة Aspose.Slides؛ يتم إعادة حساب معلماتها من بيانات السلسلة تلقائيًا، لذا لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة بروابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**
نعم. يمكن لكل مخطط الإشارة إلى [دفتر عمل خارجي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) خاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.