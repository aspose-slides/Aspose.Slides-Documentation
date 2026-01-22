---
title: تنسيق مخططات العرض التقديمي في JavaScript
linktitle: تنسيق المخططات
type: docs
weight: 60
url: /ar/nodejs-java/chart-formatting/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ Node.js باستخدام JavaScript وارتقِ بعرض PowerPoint التقديمي إلى مستوى احترافي مع أنماط جذابة بصريًا."
---

## **تنسيق كائنات المخطط**

Aspose.Slides for Node.js via Java يتيح للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. يشرح هذا المقال كيفية تنسيق كائنات المخطط المختلفة بما في ذلك محور الفئات ومحور القيم.

Aspose.Slides for Node.js عبر Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة كائنات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء نسخة من الفئة [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (في هذا المثال سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيم للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط شبكة المحور القيمي الرئيسية
   1. تعيين **Line format** لخطوط شبكة المحور القيمي الثانوية
   1. تعيين **Number Format** للمحور القيمي
   1. تعيين **Min, Max, Major and Minor units** للمحور القيمي
   1. تعيين **Text Properties** لبيانات المحور القيمي
   1. تعيين **Title** للمحور القيمي
   1. تعيين **Line Format** للمحور القيمي
1. الوصول إلى محور الفئات للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط شبكة محور الفئات الرئيسية
   1. تعيين **Line format** لخطوط شبكة محور الفئات الثانوية
   1. تعيين **Text Properties** لبيانات محور الفئات
   1. تعيين **Title** لمحور الفئات
   1. تعيين **Label Positioning** لمحور الفئات
   1. تعيين **Rotation Angle** لتسميات محور الفئات
1. الوصول إلى مفتاح المخطط وتعيين **Text Properties** له
1. تعيين إظهار مفاتيح المخطط دون تداخل مع المخطط
1. الوصول إلى **Secondary Value Axis** للمخطط وتعيين الخصائص التالية:
   1. تمكين **Value Axis** الثانوي
   1. تعيين **Line Format** للمحور القيمي الثانوي
   1. تعيين **Number Format** للمحور القيمي الثانوي
   1. تعيين **Min, Max, Major and Minor units** للمحور القيمي الثانوي
1. الآن رسم السلسلة الأولى للمخطط على المحور القيمي الثانوي
1. تعيين لون تعبئة الجدار الخلفي للمخطط
1. تعيين لون تعبئة منطقة الرسم للمخطط
1. كتابة العرض التقديمي المعدل إلى ملف PPTX
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة المخطط النموذجي
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // تعيين عنوان المخطط
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تعيين تنسيق خطوط الشبكة الرئيسية للمحور القيمي
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // تعيين تنسيق خطوط الشبكة الثانوية للمحور القيمي
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // تعيين تنسيق رقم المحور القيمي
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // تعيين قيم الحد الأقصى والحد الأدنى للمحور القيمي
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // تعيين خصائص نص محور القيم
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // تعيين عنوان محور القيم
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئات
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // تعيين تنسيق خطوط الشبكة الثانوية لمحور الفئات
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // تعيين خصائص نص محور الفئات
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // تعيين عنوان الفئات
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تعيين موضع تسمية محور الفئات
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // تعيين زاوية دوران تسمية محور الفئات
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // تعيين خصائص نص وسيلة الإيضاح
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // تعيين إظهار وسيلة إيضاح المخطط دون تداخل مع المخطط
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // تعيين محور القيم الثانوي
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // تعيين تنسيق رقم محور القيم الثانوي
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // تعيين قيم الحد الأقصى والحد الأدنى للمحور الثانوي
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // تعيين لون جدار الخلفية للمخطط
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // تعيين لون منطقة الرسم
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // حفظ العرض التقديمي
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين خصائص الخط للمخطط**

Aspose.Slides for Node.js عبر Java يوفر دعمًا لتعيين خصائص الخط المتعلقة بالمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
- إضافة مخطط إلى الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض التقديمي المعدل.

مثال العينة أدناه.
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين تنسيق الأرقام**

Aspose.Slides for Node.js عبر Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة تنسيق بيانات المخطط:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. تعيين تنسيق الرقم المسبق من القيم المسبقة المتاحة.
1. استعراض خلايا بيانات المخطط في كل سلسلة وتعيين تنسيق رقم البيانات.
1. حفظ العرض التقديمي.
1. تعيين تنسيق رقم مخصص.
1. استعراض خلايا بيانات المخطط داخل كل سلسلة وتعيين تنسيق رقم مختلف.
1. حفظ العرض التقديمي.
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى للعرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // إضافة مخطط عمودي متجمع افتراضي
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // الوصول إلى مجموعة سلاسل المخطط
    var series = chart.getChartData().getSeries();
    // التجول عبر كل سلسلة مخطط
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // التجول عبر كل خلية بيانات في السلسلة
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // تعيين تنسيق الرقم
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // حفظ العرض التقديمي
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


القيم المسبقة لتنسيق الأرقام الممكنة مع فهرسها والتي يمكن استخدامها موضحة أدناه:

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

Aspose.Slides for Node.js عبر Java يوفر دعمًا لتعيين منطقة المخطط. تم إضافة الطريقتين [**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) و[**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) إلى فئة [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart).

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. إضافة مخطط إلى الشريحة.
1. تعيين نوع التعبئة ولون التعبئة للمخطط
1. تعيين الخاصية round corner إلى True.
1. حفظ العرض التقديمي المعدل.

مثال العينة أدناه. 
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والمحيط بشكل منفصل. هذا مفيد لتحسين وضوح الشبكة والبيانات في الرسوم البيانية الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل المكونات غير الأساسية للتسمية (مثل الفئات)، اضبط إزاحة/موضع التسمية، أظهر التسميات فقط للنقاط المحددة إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + المفتاح".

**هل يمكنني تطبيق تعبئات متدرجة أو بنمط على السلاسل؟**

نعم. عادةً ما تكون التعبئات الصلبة والمتدرجة/النمطية متاحة. في الممارسة العملية، استخدم التدرجات بحذر وتجنب الجمع بينها إذا كان ذلك يقلل من التباين مع الشبكة والنص.