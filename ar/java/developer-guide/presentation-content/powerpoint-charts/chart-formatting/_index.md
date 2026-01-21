---
title: "تنسيق مخططات العرض التقديمي في جافا"
linktitle: "تنسيق المخطط"
type: docs
weight: 60
url: /ar/java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حدود مستديرة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلّم تنسيق المخطط في Aspose.Slides for Java وارتقِ بعرض PowerPoint التقديمي الخاص بك باستخدام تنسيق احترافي وجذاب."
---

## **تنسيق كيانات المخطط**
Aspose.Slides for Java يتيح للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. يشرح هذا المقال كيفية تنسيق كيانات المخطط المختلفة بما في ذلك محور الفئة ومحور القيم.

Aspose.Slides for Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة كيانات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء مثيل من الفئة [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الحصول على مرجع شريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (في هذا المثال سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيم للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور القيم
   1. تعيين **Line format** لخطوط الشبكة الثانوية لمحور القيم
   1. تعيين **Number Format** لمحور القيم
   1. تعيين **Min, Max, Major and Minor units** لمحور القيم
   1. تعيين **Text Properties** لبيانات محور القيم
   1. تعيين **Title** لمحور القيم
   1. تعيين **Line Format** لمحور القيم
1. الوصول إلى محور الفئة للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور الفئة
   1. تعيين **Line format** لخطوط الشبكة الثانوية لمحور الفئة
   1. تعيين **Text Properties** لبيانات محور الفئة
   1. تعيين **Title** لمحور الفئة
   1. تعيين **Label Positioning** لمحور الفئة
   1. تعيين **Rotation Angle** لتسميات محور الفئة
1. الوصول إلى وسيلة إيضاح المخطط وتعيين **Text Properties** لها
1. ضبط إظهار وسيلة إيضاح المخطط دون تداخلها مع المخطط
1. الوصول إلى **Secondary Value Axis** للمخطط وتعيين الخصائص التالية:
   1. تمكين **Value Axis** الثانوي
   1. تعيين **Line Format** للمحور القيمي الثانوي
   1. تعيين **Number Format** للمحور القيمي الثانوي
   1. تعيين **Min, Max, Major and Minor units** للمحور القيمي الثانوي
1. الآن رسم أول سلسلة مخطط على المحور القيمي الثانوي
1. تعيين لون تعبئة الجدار الخلفي للمخطط
1. تعيين لون تعبئة منطقة رسم المخطط
1. كتابة العرض التقديمي المعدل إلى ملف PPTX
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
    chartTitle.setText("Sample Chart");
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

    // تعيين القيم القصوى والحد الأدنى للمخطط
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
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئة
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // تعيين تنسيق خطوط الشبكة الثانوية لمحور الفئة
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
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تعيين موضع تسمية محور الفئة
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // تعيين زاوية تدوير تسمية محور الفئة
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // تعيين خصائص نص وسيلة الإيضاح
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // ضبط إظهار وسيلة الإيضاح للمخطط دون تداخل مع المخطط

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

    // تعيين القيم القصوى والحد الأدنى للمخطط
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // تعيين لون جدار خلفية المخطط
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // تعيين لون مساحة الرسم
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // حفظ العرض التقديمي
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين خصائص الخط للمخطط**
Aspose.Slides for Java يوفر دعمًا لتعيين خصائص الخط المتعلقة بالمخطط. يرجى اتباع الخطوات التالية لتعيين خصائص الخط للمخطط.

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
- إضافة مخطط إلى الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض التقديمي المعدل.

المثال التالي موضح.
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
Aspose.Slides for Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة تنسيق بيانات المخطط:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الحصول على مرجع شريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. تعيين تنسيق الرقم المسبق من القيم المسبقة المتاحة.
1. المرور عبر خلايا بيانات المخطط في كل سلسلة وتعيين تنسيق الرقم لبيانات المخطط.
1. حفظ العرض التقديمي.
1. تعيين تنسيق رقم مخصص.
1. المرور عبر خلايا بيانات المخطط داخل كل سلسلة وتعيين تنسيق رقم مختلف لبيانات المخطط.
1. حفظ العرض التقديمي.
```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى للعرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة مخطط عمود متجّم افتراضي
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // الوصول إلى مجموعة سلاسل المخطط
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // التجول عبر كل سلسلة مخطط
    for (IChartSeries ser : series) 
    {
        // التجول عبر كل خلية بيانات في السلسلة
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // تعيين تنسيق الرقم
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // حفظ العرض التقديمي
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


القيم المسبقة لتنسيق الأرقام المتاحة مع الفهرس الخاص بكل منها هي كما يلي:

|**0**|General|
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
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين حدود مستديرة لمنطقة المخطط**
Aspose.Slides for Java يوفر دعمًا لتعيين منطقة المخطط. تمت إضافة الطريقتين [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) و [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) إلى الواجهة [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) والفئة [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart).

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. إضافة مخطط إلى الشريحة.
1. تعيين نوع التعبئة ولون التعبئة للمخطط
1. تعيين الخاصية round corner إلى True.
1. حفظ العرض التقديمي المعدل.

المثال التالي موضح. 
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


## **الأسئلة الشائعة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. وهذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، أو عطل مكونات التسمية غير الضرورية (مثل الفئات)، أو اضبط إزاحة/موضع التسمية، أو اعرض التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر الصياغة إلى "القيمة + المفتاح".

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية على السلاسل؟**

نعم. تتوفر عادةً كل من التعبئات الصلبة والتدرجية/النمطية. في الممارسة العملية، استخدم التدرجات بصورة معتدلة وتجنب الجمع بينها إذا كان ذلك يقلل من التباين مع الشبكة والنص.