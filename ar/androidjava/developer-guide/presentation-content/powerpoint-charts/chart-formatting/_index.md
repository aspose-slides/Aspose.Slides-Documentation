---
title: تنسيق المخططات
type: docs
weight: 60
url: /androidjava/chart-formatting/
---

## **تنسيق كيانات المخطط**
تتيح Aspose.Slides لـ Android عبر Java للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. تشرح هذه المقالة كيفية تنسيق كيانات المخطط المختلفة بما في ذلك فئة المخطط ومحور القيم.

تقدم Aspose.Slides لـ Android عبر Java واجهة برمجة تطبيقات بسيطة لإدارة كيانات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء مثيل من [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) فئة.
1. الحصول على مرجع الشريحة بواسطة فهرسها.
1. إضافة مخطط مع بيانات افتراضية مع أي نوع مرغوب (في هذا المثال سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيم في المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور القيم
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور القيم
   1. تعيين **تنسيق الأرقام** لمحور القيم
   1. تعيين **الوحدات الدنيا والقصوى والرئيسية والثانوية** لمحور القيم
   1. تعيين **خصائص النص** لبيانات محور القيم
   1. تعيين **عنوان** لمحور القيم
   1. تعيين **تنسيق الخط** لمحور القيم
1. الوصول إلى محور الفئات في المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور الفئات
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور الفئات
   1. تعيين **خصائص النص** لبيانات محور الفئات
   1. تعيين **عنوان** لمحور الفئات
   1. تعيين **موضع التسمية** لمحور الفئات
   1. تعيين **زاوية الدوران** لتسميات محور الفئات
1. الوصول إلى أسطورة المخطط وتعيين **خصائص النص** لها
1. تعيين عرض الأساطير في المخطط دون تداخل
1. الوصول إلى **محور القيم الثانوي** في المخطط وتعيين الخصائص التالية:
   1. تفعيل **محور القيم الثانوي**
   1. تعيين **تنسيق الخط** لمحور القيم الثانوي
   1. تعيين **تنسيق الأرقام** لمحور القيم الثانوي
   1. تعيين **الوحدات الدنيا والقصوى والرئيسية والثانوية** لمحور القيم الثانوي
1. الآن رسم سلسلة المخطط الأولى على محور القيم الثانوي
1. تعيين لون ملء الجدار الخلفي للمخطط
1. تعيين لون ملء منطقة الرسم للمخطط
1. كتابة العرض المعدل إلى ملف PPTX

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة المخطط التجريبي
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // تعيين عنوان المخطط
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("مخطط تجريبي");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين تنسيق خطوط الشبكة الرئيسية لمحور القيم
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // تعيين تنسيق خطوط الشبكة الثانوية لمحور القيم
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // تعيين تنسيق الأرقام لمحور القيم
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

    // تعيين خصائص نص محور القيم
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // تعيين عنوان محور القيم
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("المحور الرئيسي");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئات
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // تعيين تنسيق خطوط الشبكة الثانوية لمحور الفئات
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // تعيين خصائص نص محور الفئات
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
    catTitle.setText("فئة تجريبية");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين موضع تسمية محور الفئات
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // تعيين زاوية دوران تسمية محور الفئات
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // تعيين خصائص نص الأساطير
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // تعيين عرض الأساطير دون تداخل المخطط

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // تعيين محور القيم الثانوي
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // تعيين تنسيق الأرقام لمحور القيم الثانوي
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
تتيح Aspose.Slides لـ Android عبر Java دعم تعيين الخصائص المتعلقة بالخط للمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء مثيل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) كائن.
- إضافة مخطط على الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض المعدل.

إليك مثال توضيحي أدناه.

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

## **تعيين تنسيق الأرقام**
تتيح Aspose.Slides لـ Android عبر Java واجهة برمجة تطبيقات بسيطة لإدارة تنسيق بيانات المخطط:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) فئة.
1. الحصول على مرجع الشريحة بواسطة فهرسها.
1. إضافة مخطط مع بيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. تعيين تنسيق الأرقام المسبق من القيم المسبقة الممكنة.
1. التنقل خلال خلية بيانات المخطط في كل سلسلة مخطط وتعيين تنسيق أرقام المخطط.
1. حفظ العرض.
1. تعيين تنسيق الأرقام المخصص.
1. التنقل خلال خلية بيانات المخطط داخل كل سلسلة مخطط وتعيين تنسيق أرقام مختلف للمخطط.
1. حفظ العرض.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى للعروض التقديمية
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة مخطط عمود مجمع افتراضي
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // الوصول إلى مجموعة سلسلة المخطط
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // التنقل خلال كل سلسلة مخطط
    for (IChartSeries ser : series) 
    {
        // التنقل خلال كل خلية بيانات في السلسلة
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // تعيين تنسيق الأرقام
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // حفظ العرض
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

قائمة القيم الممكنة لتنسيق الأرقام المسبق مع فهرسها المسبق والتي يمكن استخدامها أدناه:

|**0**|عام|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|م/ي/ي|
|**15**|ي-ش‑ش|
|**16**|ي-ش|
|**17**|ش-ي|
|**18**|س:د ص/م|
|**19**|س:د:ث ص/م|
|**20**|س:د|
|**21**|س:د:ث|
|**22**|م/ي/ي س:د|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|د:ث|
|**46**|س :د:ث|
|**47**|[د:ث.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين الزوايا المدورة لمنطقة المخطط**
تتيح Aspose.Slides لـ Android عبر Java دعم تعيين منطقة المخطط. لقد تمت إضافة طرق [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) و [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) إلى واجهة [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) وفئة [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart). 

1. إنشاء مثيل [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) كائن.
1. إضافة مخطط على الشريحة.
1. تعيين نوع الملء ولون الملء للمخطط
1. تعيين خاصية الزوايا المدورة إلى True.
1. حفظ العرض المعدل.

إليك مثال توضيحي أدناه. 

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