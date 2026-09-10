---
title: تخصيص أشرطة الخطأ في رسوم العروض التقديمية باستخدام بايثون
linktitle: شريط الخطأ
type: docs
url: /ar/python-java/error-bar/
keywords:
- شريط الخطأ
- قيمة مخصصة
- باوربوينت
- عرض تقديمي
- بايثون
- جافا
- Aspose.Slides
description: "تعلم كيفية إضافة وتخصيص أشرطة الخطأ في الرسوم البيانية باستخدام Aspose.Slides for Python via Java—حسن تصور البيانات في عروض باوربوينت."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع أشرطة الخطأ في رسوم العروض التقديمية باستخدام Aspose.Slides. تُظهر كيفية إضافة أشرطة الخطأ إلى سلسلة من الرسم البياني، وتكوين إعدادات أشرطة الخطأ للمحور X و Y، وتطبيق أنواع قيم مختلفة مثل القيم الثابتة والنسبة المئوية والقيم المخصصة.

كما توضح كيفية تعيين قيم أشرطة الخطأ المخصصة لنقاط البيانات الفردية في سلسلة ما باستخدام مجموعة نقاط البيانات المقابلة. بالإضافة إلى ذلك، تتضمن المقالة ملاحظات مختصرة حول سلوك أشرطة الخطأ أثناء التصدير، وتوافقها مع العلامات وتسميات البيانات، وأين يمكن العثور على فئات ومجموعات القيم (enums) الخاصة بواجهة برمجة التطبيقات ذات الصلة.

## **إضافة أشرطة الخطأ**

توفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. يستخدم المثال التالي أنواع القيم الثابتة والنسبة المئوية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إضافة مخطط فقاعات إلى الشريحة المطلوبة.
3. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق أشرطة الخطأ للمحور X.
4. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق أشرطة الخطأ للمحور Y.
5. تعيين قيم أشرطة الخطأ وتنسيقها.
6. حفظ العرض التقديمي المعدل إلى ملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    # إنشاء مخطط فقاعي.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # إضافة أشرطة الخطأ وضبط تنسيقها.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # حفظ العرض التقديمي.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة قيم مخصصة لأشرطة الخطأ**

توفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. ينطبق المثال التالي عندما تُعيد الدالة [getValueType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/errorbarsformat/#getValueType) القيمة [ErrorBarValueType.Custom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/errorbarvaluetype/#Custom). لتحديد قيمة، استخدم الدالة [getErrorBarsCustomValues](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) لنقطة بيانات محددة في المجموعة التي تُعيدها طريقة السلسلة [getDataPoints](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getDataPoints).

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إضافة مخطط فقاعات إلى الشريحة المطلوبة.
3. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق أشرطة الخطأ للمحور X.
4. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق أشرطة الخطأ للمحور Y.
5. الوصول إلى نقاط البيانات الفردية في سلسلة المخطط وتعيين قيم أشرطة الخطأ الخاصة بها.
6. تعيين قيم أشرطة الخطأ وتنسيقها.
7. حفظ العرض التقديمي المعدل إلى ملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    # إنشاء مخطط فقاعي.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # إضافة أشرطة خطأ مخصصة وضبط تنسيقها.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # الوصول إلى نقاط بيانات سلسلة المخطط وتكوين مصادر قيم أشرطة الخطأ الخاصة بها.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # تعيين قيم أشرطة الخطأ لنقاط بيانات سلسلة المخطط.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # حفظ العرض التقديمي.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما يحدث لأشرطة الخطأ عند تصدير العرض التقديمي إلى PDF أو صور؟**

يتم رسمها كجزء من المخطط وتُحفظ أثناء التحويل مع تنسيق المخطط بالكامل، بشرط أن يكون الإصدار أو أداة العرض متوافقة.

**هل يمكن دمج أشرطة الخطأ مع العلامات (markers) وتسميات البيانات؟**

نعم. أشرطة الخطأ عنصر منفصل ومتوافق مع العلامات وتسميات البيانات؛ إذا تداخلت العناصر قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والفئات الخاصة بالتعامل مع أشرطة الخطأ في واجهة برمجة التطبيقات؟**

في مرجع API: فئة [ErrorBarsFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/errorbarsformat/) والفئات المرتبطة [ErrorBarType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/errorbarvaluetype/).