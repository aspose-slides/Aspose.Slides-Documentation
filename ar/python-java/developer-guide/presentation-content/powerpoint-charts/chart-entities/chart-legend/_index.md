---
title: تخصيص أساطير المخططات في العروض التقديمية باستخدام Python
linktitle: أسطورة المخطط
type: docs
url: /ar/python-java/chart-legend/
keywords:
- أسطورة المخطط
- موضع الأسطورة
- حجم الخط
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "قم بتخصيص أساطير المخططات باستخدام Aspose.Slides للبايثون عبر جافا لتحسين عروض PowerPoint مع تنسيق أسطورة مخصص."
---
## **نظرة عامة**

توفر Aspose.Slides for Python via Java خيارات لتخصيص أساطير المخططات في عروض PowerPoint. يوضح هذا المقال كيفية تحديد موضع وحجم الأسطورة، ضبط حجم الخط لكامل الأسطورة، تنسيق مدخل أسطورة منفرد، وإخفاء أو استعادة المدخلات المحددة.

تغطي الأسئلة الشائعة السلوكيات المتعلقة، بما في ذلك حجز مساحة للأسطورة، عرض علامات متعددة الأسطر، ووراثة التنسيق من سمة العرض التقديمي.

## **تحديد موضع الأسطورة**

استخدم طرق [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX)، [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY)، [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) و[setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) لتحديد موضعها وحجمها كنسب من أبعاد المخطط.

هذا المثال ينشئ عرض تقديمي ويضيف مخطط عمود متجمع ببيانات افتراضية إلى الشريحة الأولى. تحويل إزاحات الأسطورة وأبعادها المطلوبة إلى نسب يتم بقسمة القيم على عرض وارتفاع المخطط: تكون الأسطورة إزاحتها 50 نقطة من الزاوية العلوية اليسرى للمخطط وحجمها 100×100 نقطة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # عبّر عن موضع الأسطورة وحجمها بالنسبة للمخطط.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين حجم الخط للأسطورة**

استخدم [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) للوصول إلى تنسيق النص الخاص بالأسطورة واستخدم [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) لتعيين حجم الخط بالنقاط.

هذا المثال ينشئ مخططًا ببيانات افتراضية ويضبط نص الأسطورة إلى 20 نقطة. كما يعطل الحدود التلقائية للمحور الرأسي ويضبط نطاقه من -5 إلى 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين حجم الخط لمدخل أسطورة فردي**

استخدم المجموعة التي تُرجعها طريقة [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) للوسيلة للوصول إلى تنسيق مدخل معين. مؤشرات المدخلات تبدأ من الصفر، لذا فإن الفهرس `1` يشير إلى المدخل الثاني.

هذا المثال ينشئ مخطط عمود متجمع يحتوي على بيانات افتراضية تشمل على الأقل سلسلتين. يقوم بتنسيق المدخل الثاني للوسيلة بخط عريض، مائل، ونص أزرق بحجم 20 نقطة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إخفاء مدخلات الأسطورة الفردية**

لإستبعاد سلسلة مساعدة من الأسطورة مع إبقاء بياناتها مرئية، استدعِ [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) مع `True` عبر [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). يقوم هذا بإخفاء المدخل المحدد فقط؛ لا يزيل السلسلة أو نقاط بياناتها. استدعاء [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) مع `False`، بالمقابل، يخفي الأسطورة بالكامل.

المثال أدناه ينشئ مخطط عمود متجمع بعدة سلاسل باستخدام البيانات الافتراضية. يخفِى مدخل الأسطورة للسلسلة الثانية (الفهرس `1`) ويحفظ العرض التقديمي. ثم يستعيد المدخل عبر استدعاء [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) مع `False` ويحفظ نسخة ثانية. تظل الأعمدة مرئية في كلا الملفين.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # استعادة نفس المدخل دون تغيير بيانات المخطط.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![مقارنة مخطط مع جميع مدخلات الأسطورة مرئية ومع إخفاء السلسلة 2 من الأسطورة؛ جميع الأعمدة تظل مرئية.](hide-legend-entry.png)

في مخططات العمود والشريط والخط، تحدد مدخلات الأسطورة السلاسل. في مخططات الفطيرة، تحدد المدخلات نقاط البيانات الفردية (الشرائح)، لذا استخدم [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) على الشريحة المحددة بدلاً من ذلك. توثّق API هذه الطريقة لنقاط البيانات لأنواع المخططات `Pie`، `Pie3D`، `ExplodedPie`، `ExplodedPie3D`، `PieOfPie` و`BarOfPie`. لا تفترض أنها تنطبق على مخططات الدونت، التي ليست مدرجة في تلك القائمة.

## **الأسئلة الشائعة**

**هل يمكنني جعل المخطط يخصص مساحة للأسطورة بدلاً من تغطيتها؟**

نعم. استدعِ [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) مع `False` لحجز مساحة للأسطورة بدلاً من السماح لها بتغطية منطقة الرسم.

**هل يمكنني إنشاء تسميات أسطورة متعددة الأسطر؟**

نعم. يمكن للملصقات الطويلة الالتفاف عندما يكون العرض المتاح غير كافٍ. يمكنك أيضًا استخدام أحرف السطر الجديد في أسماء السلاسل لطلب فواصل أسطر.

**كيف أجعل الأسطورة تتبع مخطط ألوان سمة العرض التقديمي؟**

اترك ألوان الأسطورة، التعبئات، والخطوط غير مضبوطة بحيث يمكنها وراثة تنسيق السمة. التنسيق الصريح يتجاوز إعدادات السمة المقابلة.