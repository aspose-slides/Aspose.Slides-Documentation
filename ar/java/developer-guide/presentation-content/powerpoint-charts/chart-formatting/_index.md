---
title: تنسيق المخطط
type: docs
weight: 60
url: /java/chart-formatting/
---

## **تنسيق كيان المخطط**
تتيح Aspose.Slides لـ Java للمطورين إضافة مخططات مخصصة إلى شرائحهم من الصفر. تشرح هذه المقالة كيفية تنسيق مختلف كيانات المخطط بما في ذلك محور الفئة ومحور القيمة.

توفر Aspose.Slides لـ Java واجهة برمجة تطبيقات بسيطة لإدارة كيانات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء مثيل من [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) فئة.
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (سوف نستخدم في هذا المثال ChartType.LineWithMarkers).
1. الوصول إلى المحور قيمة المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور القيمة
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور القيمة
   1. تعيين **التنسيق الرقمي** لمحور القيمة
   1. تعيين **الوحدات الصغرى والكبرى والحد الأدنى والحد الأقصى** لمحور القيمة
   1. تعيين **خصائص النص** لبيانات محور القيمة
   1. تعيين **العنوان** لمحور القيمة
   1. تعيين **تنسيق الخط** لمحور القيمة
1. الوصول إلى محور الفئة في المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور الفئة
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور الفئة
   1. تعيين **خصائص النص** لبيانات محور الفئة
   1. تعيين **العنوان** لمحور الفئة
   1. تعيين **موضع التسمية** لمحور الفئة
   1. تعيين **زاوية الدوران** لتسميات محور الفئة
1. الوصول إلى أسطورة المخطط وتعيين **خصائص النص** لها
1. تعيين إظهار أساطير المخطط بدون تداخل المخطط
1. الوصول إلى **محور القيمة الثانوية** للمخطط وتعيين الخصائص التالية:
   1. تفعيل **محور القيمة الثانوية**
   1. تعيين **تنسيق الخط** لمحور القيمة الثانوية
   1. تعيين **التنسيق الرقمي** لمحور القيمة الثانوية
   1. تعيين **الوحدات الصغرى والكبرى والحد الأدنى والحد الأقصى** لمحور القيمة الثانوية
1. الآن قم برسم سلسلة المخطط الأولى على محور القيمة الثانوية
1. تعيين لون ملء الجدار الخلفي للمخطط
1. تعيين لون ملء منطقة الرسم للمخطط
1. كتابة العرض المعدل إلى ملف PPTX

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة المخطط النموذجي
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // تعيين عنوان المخطط
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("مخطط نموذجي");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين تنسيق الخطوط الرئيسية لمحور القيمة
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // تعيين تنسيق الخطوط الثانوية لمحور القيمة
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // تعيين تنسيق رقم محور القيمة
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // تعيين القيم القصوى والدنيا للمخطط
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // تعيين خصائص نص محور القيمة
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // تعيين عنوان محور القيمة
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("المحور الأساسي");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين تنسيق الخطوط الرئيسية لمحور الفئة
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // تعيين تنسيق الخطوط الثانوية لمحور الفئة
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // تعيين خصائص نص محور الفئة
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // تعيين عنوان الفئة
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("فئة نموذجية");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين موضع علامة محور الفئة
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // تعيين زاوية دوران علامة محور الفئة
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // تعيين خصائص نص الأساطير
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // تعيين إظهار أساطير المخطط بدون تداخل المخطط

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // تعيين محور القيمة الثانوية
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // تعيين تنسيق الرقم لمحور القيمة الثانوية
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // تعيين القيم القصوى والدنيا للمخطط
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // تعيين لون الجدار الخلفي للمخطط
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // تعيين لون منطقة الرسم
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // حفظ العرض
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين خصائص الخط للمخطط**
توفر Aspose.Slides لـ Java الدعم لتعيين الخصائص المتعلقة بالخط للمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) فئة.
- إضافة مخطط على الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض المعدل.

تم تقديم المثال النموذجي أدناه.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تنسيق للأرقام**
تقدم Aspose.Slides لـ Java واجهة برمجة تطبيقات بسيطة لإدارة تنسيق بيانات المخطط:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) فئة.
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (يستخدم هذا المثال **ChartType.ClusteredColumn**).
1. تعيين التنسيق الرقمي المتاح من القيم المتاحة.
1. التنقل عبر خلية بيانات المخطط في كل سلسلة مخطط وتعيين تنسيق الرقم لبيانات المخطط.
1. حفظ العرض.
1. تعيين التنسيق الرقمي المخصص.
1. التنقل عبر خلية بيانات المخطط داخل كل سلسلة مخطط وتعيين تنسيق رقم مختلف لبيانات المخطط.
1. حفظ العرض.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة مخطط عمودي متجمع افتراضي
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // الوصول إلى مجموعة سلسلة المخطط
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // التنقل عبر كل سلسلة مخطط
    for (IChartSeries ser : series) 
    {
        // التنقل عبر كل خلية بيانات في السلسلة
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // تعيين تنسيق رقم
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // حفظ العرض
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

تتضمن القيم الممكنة لتنسيق الأرقام المسبقة مع فهرسها المسبق التي يمكن استخدامها ما يلي:

|**0**|عام|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;أحمر$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;أحمر$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;أحمر-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;أحمر-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين زوايا حدود منطقة المخطط**
توفر Aspose.Slides لـ Java الدعم لتعيين منطقة المخطط. تم إضافة طرق [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) و [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) إلى واجهة [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) وفئة [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart).

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) فئة.
1. إضافة مخطط على الشريحة.
1. تعيين نوع المليء ولون المليء للمخطط
1. تعيين خاصية الزاوية المستديرة True.
1. حفظ العرض المعدل.

تم تقديم المثال النموذجي أدناه.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```