---
title: تحسين حسابات المخطط للعروض التقديمية في Java
linktitle: حسابات المخطط
type: docs
weight: 50
url: /ar/java/chart-calculations/
keywords:
- حسابات المخطط
- عناصر المخطط
- موضع العنصر
- الموضع الفعلي
- عنصر فرعي
- العنصر الأصلي
- قيم المخطط
- القيمة الفعلية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "فهم حسابات المخطط وتحديثات البيانات والتحكم في الدقة في Aspose.Slides for Java لملفات PPT و PPTX، مع أمثلة عملية على شفرة Java."
---

## **حساب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص واجهة [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) معلومات حول الموضع الفعلي لعنصر محور المخطط ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--)، [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--)، [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--)، [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **حساب الموضع الفعلي لعناصر المخطط الأصلية**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص واجهة [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) معلومات حول الموضع الفعلي لعنصر المخطط الأصل ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--)، [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--)، [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--)، [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **إخفاء المعلومات من المخطط**
هذا الموضوع يساعدك على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for Java يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يوضح مثال الشفرة أدناه كيفية استخدام هذه الخصائص.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //إخفاء عنوان المخطط
    chart.setTitle(false);

    ///إخفاء محور القيم
    chart.getAxes().getVerticalAxis().setVisible(false);

    //إظهار محور الفئة
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

    //إعداد لون خط السلسلة
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل تعمل دفاتر Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عندما تقوم بالاتصال أو تحديث المصدر الخارجي، يتم أخذ الصيغ والقيم من ذلك الدفتر، ويعكس المخطّط التحديثات خلال عمليات الفتح/التحرير. تسمح لك الواجهة البرمجية [specify the external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) بتحديد مسار دفتر العمل الخارجي وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. يتم إضافة وتحديث [Trendlines](/slides/ar/java/trend-line/) (خطية، أسية، وغيرها) بواسطة Aspose.Slides؛ يتم إعادة حساب معلماتها من بيانات السلسلة تلقائيًا، لذلك لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة مع روابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) الخاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.