---
title: تخصيص أشرطة الخطأ في مخططات العرض التقديمي باستخدام بايثون
linktitle: شريط الخطأ
type: docs
url: /ar/python-net/error-bar/
keywords:
- شريط الخطأ
- قيمة مخصصة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة وتخصيص أشرطة الخطأ في المخططات باستخدام Aspose.Slides لبايثون عبر .NET - تحسين تصورات البيانات في عروض PowerPoint وOpenDocument."
---

## **إضافة شريط الأخطاء**
توفر Aspose.Slides for Python عبر .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الأخطاء. يطبق الكود النموذجي عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى أول سلسلة في المخطط وتعيين تنسيق شريط الأخطاء X.
1. الوصول إلى أول سلسلة في المخطط وتعيين تنسيق شريط الأخطاء Y.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

    # إنشاء عرض تقديمي فارغ
    with slides.Presentation() as presentation:
        # إنشاء مخطط فقاعة
        chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

        # إضافة أشرطة الأخطاء وتعيين تنسيقها
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

        # حفظ العرض التقديمي
        presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```




## **إضافة قيمة مخصصة لشريط الأخطاء**
توفر Aspose.Slides for Python عبر .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الأخطاء المخصصة. يطبق الكود النموذجي عندما تكون الخاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى أول سلسلة في المخطط وتعيين تنسيق شريط الأخطاء X.
1. الوصول إلى أول سلسلة في المخطط وتعيين تنسيق شريط الأخطاء Y.
1. الوصول إلى نقاط البيانات الفردية في سلسلة المخطط وتعيين قيم شريط الأخطاء لنقطة البيانات الفردية.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء عرض تقديمي فارغ
with slides.Presentation() as presentation:
    # إنشاء مخطط فقاعة
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # إضافة أشرطة الأخطاء المخصصة وتعيين تنسيقها
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الأخطاء للنقطة الفردية
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # تعيين أشرطة الأخطاء لنقاط سلسلة المخطط
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # حفظ العرض التقديمي
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**ماذا يحدث لأشرطة الأخطاء عند تصدير عرض تقديمي إلى PDF أو صور؟**

يتم عرضها كجزء من المخطط ويتم الحفاظ عليها أثناء التحويل مع بقية تنسيق المخطط، بشرط وجود نسخة أو محرك عرض متوافق.

**هل يمكن دمج أشرطة الأخطاء مع العلامات وملصقات البيانات؟**

نعم. أشرطة الأخطاء عنصر منفصل ومتوافق مع العلامات وملصقات البيانات؛ إذا تداخلت العناصر، قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والقيم التعداد (enums) للعمل مع أشرطة الأخطاء في واجهة برمجة التطبيقات؟**

في مرجع واجهة برمجة التطبيقات: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) والعدادات المتعلقة [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).