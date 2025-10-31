---
title: تخصيص أشرطة الخطأ في مخططات العرض باستخدام بايثون
linktitle: شريط الخطأ
type: docs
url: /ar/python-net/error-bar/
keywords:
- شريط خطأ
- قيمة مخصصة
- PowerPoint
- OpenDocument
- عرض
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة وتخصيص أشرطة الخطأ في المخططات باستخدام Aspose.Slides for Python via .NET — تحسين العرض البصري للبيانات في عروض PowerPoint وOpenDocument."
---

## **إضافة شريط الخطأ**
Aspose.Slides for Python via .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. ينطبق كود العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** لسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
3. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ X.
4. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ Y.
5. تعيين قيم الأشرطة وتنسيقها.
6. حفظ العرض المعدل في ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء عرض فارغ
with slides.Presentation() as presentation:
    # إنشاء مخطط فقاعة
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # إضافة أشرطة الخطأ وتعيين تنسيقها
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # حفظ العرض
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة قيمة شريط خطأ مخصصة**
Aspose.Slides for Python via .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. ينطبق كود العينة عندما تكون الخاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** لسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
3. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ X.
4. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ Y.
5. الوصول إلى نقاط بيانات سلسلة المخطط وتعيين قيم أشرطة الخطأ لكل نقطة.
6. تعيين قيم الأشرطة وتنسيقها.
7. حفظ العرض المعدل في ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء عرض فارغ
with slides.Presentation() as presentation:
    # إنشاء مخطط فقاعة
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # إضافة أشرطة خطأ مخصصة وتعيين تنسيقها
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الخطأ للنقطة الفردية
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # تعيين أشرطة الخطأ لنقاط سلسلة المخطط
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # حفظ العرض
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**ماذا يحدث لأشرطة الخطأ عند تصدير العرض إلى PDF أو صور؟**

يتم عرضها كجزء من المخطط وتُحفظ أثناء التحويل مع باقي تنسيقات المخطط، بشرط أن يكون الإصدار أو المُعامل متوافقًا.

**هل يمكن دمج أشرطة الخطأ مع العلامات وعلامات البيانات؟**

نعم. أشرطة الخطأ عنصر منفصل ومتوافق مع العلامات وعلامات البيانات؛ إذا تداخلت العناصر قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والعددات (enums) للعمل مع أشرطة الخطأ في الـ API؟**

في مرجع الـ API: فئة [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) والعددات المرتبطة [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).