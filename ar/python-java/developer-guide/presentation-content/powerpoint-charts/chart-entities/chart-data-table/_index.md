---
title: تخصيص جداول بيانات المخططات في العروض التقديمية باستخدام Python
linktitle: جدول البيانات
type: docs
url: /ar/python-java/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تخصيص خطوط جدول بيانات المخطط، والحدود، ومفاتيح الوسيلة في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة Python عبر Java."
---
## **نظرة عامة**

تتيح لك Aspose.Slides for Python via Java عرض جدول بيانات المخطط وتخصيص تنسيق النص والحدود ومفاتيح الوسيلة. يشرح هذا المقال كيفية تمكين الجدول، تنسيق النص، التحكم في كل نوع من الحدود، وإظهار أو إخفاء مفاتيح الوسيلة. تقوم الأمثلة بحفظ المخططات المكوّنة في ملفات PPTX.

## **تعيين خصائص الخط**

لعرض جدول بيانات المخطط، مرّر `True` إلى [setDataTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setDataTable). استخدم [getChartDataTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#getChartDataTable) للوصول إلى الجدول وتكوين تنسيق النص الخاص به.

1. قم بتحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. أضف مخطط أعمدة متجمع إلى الشريحة الأولى.
1. فعّل جدول بيانات المخطط.
1. فعّل النص العريض باستخدام [setFontBold](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setFontBold) ومرّر `20` إلى [setFontHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setFontHeight) للحصول على نص بحجم 20 نقطة.
1. احفظ العرض التقديمي المعدل.

المثال التالي يتطلب وجود `test.pptx` في دليل العمل مع شريحة واحدة على الأقل. يضيف مخططًا بالبيانات الافتراضية في الموضع (50, 50) بعرض 600 نقطة وارتفاع 400 نقطة. يحتوي ملف `output.pptx` المحفوظ على المخطط مع تمكين جدول البيانات وتطبيق إعدادات الخط المحددة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تخصيص حدود جدول البيانات**

فعّل الجدول باستخدام [Chart.setDataTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setDataTable) وابدأ الوصول إليه عبر [Chart.getChartDataTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#getChartDataTable). يمكنك التحكم في ثلاثة أنواع من الحدود بصورة مستقلة:

- [setBorderHorizontal](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datatable/#setBorderHorizontal) يتحكم في حدود الخلايا الأفقية.
- [setBorderVertical](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datatable/#setBorderVertical) يتحكم في حدود الخلايا العمودية.
- [setBorderOutline](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datatable/#setBorderOutline) يتحكم في الحد الخارجي للجدول.

مرّر `True` إلى كل طريقة لعرض حدودها أو `False` لإخفائها. المثال التالي ينشئ مخطط أعمدة متجمع بالبيانات الافتراضية، يعرض الحدود الأفقية والحد الخارجي، ويخفي الحدود العمودية. لا يتطلب ملف إدخال. يتم تحديد موضع المخطط وحجمه بالنقاط.

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
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المقارنة أدناه تستخدم نفس بيانات المخطط وإعداد مفتاح الوسيلة في جميع الحالات الأربعة. بدءًا من تمكين جميع الحدود، كل تغيير متبقٍ يعطّل إعداد حد واحد فقط. يتطابق المتغيّر السفلي الأيسر مع إعدادات الحدود في المثال.

![جداول بيانات المخطط مع تمكين جميع الحدود، بدون حدود أفقية، بدون حدود عمودية، وبدون الحد الخارجي](data-table-borders.png)

## **إظهار أو إخفاء مفاتيح الوسيلة**

مفاتيح الوسيلة هي علامات ملونة صغيرة بجانب أسماء السلاسل في جدول البيانات. تساعد القراء على مطابقة كل صف في الجدول مع سلسلة المخطط. مرّر `True` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datatable/#setShowLegendKey) لإظهار هذه العلامات أو `False` لإخفائها.

يتم التحكم في وسيلة المخطط المنفصلة عبر [Chart.setLegend](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setLegend). هذه الإعدادات مستقلة: إخفاء الوسيلة المنفصلة لا يخفى المفاتيح داخل جدول البيانات، وإخفاء مفاتيح الجدول لا يخفى الوسيلة المنفصلة.

المثال التالي ينشئ مخططًا بالبيانات الافتراضية، يفعّل جدول بياناته، ويظهر مفاتيح الوسيلة داخله مع إخفاء الوسيلة المنفصلة. تم تمكين جميع حدود الجدول صراحةً. لا يلزم عرض تقديمي كمدخل. لإخفاء مفاتيح الجدول فقط، مرّر `False` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datatable/#setShowLegendKey).

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
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المقارنة أدناه تعرض نفس الجدول مع تمكين وإيقاف مفاتيح الوسيلة. تبقى جميع الحدود مفعلة، وتكون وسيلة المخطط المنفصلة مخفية في الحالتين.

![جداول بيانات المخطط مع مفاتيح الوسيلة معروضة على اليسار ومخفية على اليمين](data-table-legend-keys.png)

## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح الوسيلة في جدول بيانات المخطط؟**

نعم. مرّر `True` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datatable/#setShowLegendKey) لعرض مفاتيح الوسيلة أو `False` لإخفائها.

**هل سيُحافظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides بتصيير المخطط وجدول البيانات المعروض كجزء من الشريحة عند التصدير إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، أو [images](/slides/ar/python-java/convert-powerpoint-to-png/).

**هل يمكنني العمل مع جداول البيانات في المخططات التي تم تحميلها من قالب؟**

نعم. بالنسبة لمخطط تم تحميله من عرض تقديمي أو قالب موجود، استخدم [hasDataTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#hasDataTable) و[setDataTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setDataTable) للتحقق أو تعديل ما إذا كان جدول البيانات معروضًا.

**كيف يمكنني العثور على المخططات التي تم تمكين جدول البيانات لها؟**

قم بالتكرار عبر الأشكال في كل شريحة، حدد المخططات، واستدعِ طريقة [hasDataTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#hasDataTable). قيمة `True` تشير إلى أن جدول البيانات مفعَّل.