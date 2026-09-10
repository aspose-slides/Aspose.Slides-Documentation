---
title: تنسيق مخططات العرض التقديمي في Python
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/python-java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخططات
- كائن المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مستدير
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides for Python via Java وارتقِ بعرض PowerPoint التقديمي باستخدام أنماط احترافية وجذابة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. توضح كيفية تخصيص عناصر المخطط الأساسية مثل المحاور وخطوط الشبكة والعناوين والوسائط ومنطقة الرسم وتعبئات الجدران لتحسين مظهر وقراءة بيانات المخطط.

كما تُظهر كيفية تعيين خصائص الخط للنص داخل المخطط، وتطبيق تنسيقات رقمية مسبقة أو مخصصة على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. تجمع هذه الأمثلة بين التحكم في النمط البصري وعرض البيانات للمخططات في العرض التقديمي.

## **تنسيق كائنات المخطط**
يتيح Aspose.Slides for Python via Java للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. توضح هذه المقالة كيفية تنسيق كائنات المخطط المختلفة بما في ذلك محوري الفئة والقيمة.

يوفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات بسيطة لإدارة كائنات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الوصول إلى شريحة باستخدام فهرسها.
3. إضافة مخطط من النوع المطلوب مع البيانات الافتراضية (هذا المثال يستخدم [ChartType.LineWithMarkers](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#LineWithMarkers)).
4. الوصول إلى محور قيمة المخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور القيمة.
   1. تعيين **Line format** لخطوط الشبكة الفرعية لمحور القيمة.
   1. تعيين **Number Format** لمحور القيمة.
   1. تعيين **minimum, maximum, major, and minor units** لمحور القيمة.
   1. تعيين **Text Properties** لبيانات محور القيمة.
   1. تعيين **Title** لمحور القيمة.
5. الوصول إلى محور فئة المخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور الفئة.
   1. تعيين **Line format** لخطوط الشبكة الفرعية لمحور الفئة.
   1. تعيين **Text Properties** لبيانات محور الفئة.
   1. تعيين **Title** لمحور الفئة.
   1. تعيين **Label Positioning** لمحور الفئة.
   1. تعيين **Rotation Angle** لتسميات محور الفئة.
6. الوصول إلى وسيلة إيضاح المخطط وتعيين **text properties** لها.
7. إظهار وسيلة إيضاح المخطط دون تداخلها مع المخطط.
8. الوصول إلى **secondary value axis** للمخطط وتعيين الخصائص التالية:
   1. تمكين **value axis** الثانوي.
   1. تعيين **Line Format** لمحور القيمة الثانوي.
   1. تعيين **Number Format** لمحور القيمة الثانوي.
   1. تعيين **minimum, maximum, major, and minor units** لمحور القيمة الثانوي.
9. رسم سلسلة المخطط الأولى على محور القيمة الثانوي.
10. تعيين لون تعبئة الجدار الخلفي للمخطط.
11. تعيين لون تعبئة منطقة الرسم للمخطط.
12. حفظ العرض التقديمي المعدل إلى ملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# إنشاء نسخة من فئة Presentation
presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # إضافة المخطط التجريبي
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # تعيين عنوان المخطط
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # تعيين تنسيق خطوط الشبكة الرئيسية لمحور القيمة
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # تعيين تنسيق خطوط الشبكة الفرعية لمحور القيمة
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # تعيين تنسيق الرقم لمحور القيمة
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # تعيين القيم القصوى والحد الأدنى للمخطط
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # تعيين خصائص النص لمحور القيمة
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # تعيين عنوان محور القيمة
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئة
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # تعيين تنسيق خطوط الشبكة الفرعية لمحور الفئة
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # تعيين خصائص النص لمحور الفئة
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # تعيين عنوان الفئة
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # تعيين موضع تسمية محور الفئة
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # تعيين زاوية دوران تسمية محور الفئة
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # تعيين خصائص النص للوسائط
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # إظهار وسيلة إيضاح المخطط دون تداخلها مع المخطط

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # تعيين محور القيمة الثانوي
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # تعيين تنسيق الرقم لمحور القيمة الثانوي
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # تعيين القيم القصوى والحد الأدنى للمخطط
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # تعيين لون الجدار الخلفي للمخطط
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # تعيين لون منطقة الرسم
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # حفظ العرض التقديمي
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين خصائص الخط للمخطط**
يدعم Aspose.Slides for Python via Java تعيين خصائص الخط للمخططات. اتبع الخطوات التالية لتعيين خصائص الخط:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
- إضافة مخطط إلى الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض التقديمي المعدل.

المثال التالي يوضح هذه الخطوات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين التنسيق الرقمي**
يوفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات بسيطة لإدارة تنسيقات بيانات المخطط:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الوصول إلى شريحة باستخدام فهرسها.
3. إضافة مخطط من النوع المطلوب مع البيانات الافتراضية (هذا المثال يستخدم [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. تعيين تنسيق الرقم المسبق من القيم المسبقة المتاحة.
5. iterating عبر خلايا البيانات في كل سلسلة مخطط وتعيين تنسيق الرقم لها.
6. حفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation
presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى في العرض التقديمي
    slide = presentation.getSlides().get_Item(0)

    # إضافة مخطط عمود مجمع افتراضي
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # الوصول إلى مجموعة سلاسل المخطط
    chart_series_collection = chart.getChartData().getSeries()

    # التكرار عبر كل سلسلة مخطط
    for chart_series in chart_series_collection:
        # التكرار عبر كل نقطة بيانات في السلسلة
        for data_point in chart_series.getDataPoints():
            # تعيين تنسيق الرقم
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%
    
    # حفظ العرض التقديمي
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

التنسيقات الرقمية المسبقة المتاحة ومؤشراتها موضح أدناه:

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
يدعم Aspose.Slides for Python via Java الزوايا المستديرة لمنطقة المخطط عبر الطريقتين [hasRoundedCorners](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#hasRoundedCorners) و [setRoundedCorners](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setRoundedCorners) في فئة [Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/) .

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إضافة مخطط إلى الشريحة.
3. تعيين نوع التعبئة ونمط خط حد المخطط.
4. تمكين الزوايا المستديرة.
5. حفظ العرض التقديمي المعدل.

المثال التالي يوضح هذه الخطوات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتداولة**

**هل يمكنني تعيين تعبئة شبه شفافة للأعمدة/المناطق مع الحفاظ على حد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والحد بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثل الفئات)، اضبط إزاحة/موضع التسمية، اعرض التسميات للنقاط المختارة فقط إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الوسيلة".

**هل يمكنني تطبيق تعبئة تدرجية أو نمطية على السلاسل؟**

نعم. تتوفر عادةً كل من التعبئات الصلبة وتعبئات التدرج/النمط. في التطبيق العملي، استخدم التدرجات بحذر وتجنب الجمع بينهما بحيث يقلل التباين مع الشبكة والنص.