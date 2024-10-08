---
title: شريط الخطأ
type: docs
url: /ar/python-net/error-bar/
keywords: "شريط الخطأ، قيم شريط الخطأ، عرض تقديمي على PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إضافة شريط خطأ إلى عروض PowerPoint التقديمية في بايثون"
---

## **إضافة شريط خطأ**
توفر Aspose.Slides لـ بايثون عبر .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم شريط الخطأ. يتم تطبيق كود العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** للسلاسل:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. أضف مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الشريط والتنسيق.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء عرض تقديمي فارغ
with slides.Presentation() as presentation:
    # إنشاء مخطط فقاعي
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # إضافة شرائط الخطأ وتعيين تنسيقها
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



## **إضافة قيمة شريط خطأ مخصص**
توفر Aspose.Slides لـ بايثون عبر .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم شريط الخطأ المخصصة. يتم تطبيق كود العينة عندما تكون خاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** للسلاسل:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. أضف مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم شريط الخطأ لنقطة البيانات الفردية.
1. تعيين قيم الشريط والتنسيق.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء عرض تقديمي فارغ
with slides.Presentation() as presentation:
    # إنشاء مخطط فقاعي
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # إضافة شرائط خطأ مخصصة وتعيين تنسيقها
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # الوصول إلى نقاط بيانات سلسلة المخطط وتعيين قيم شرائط الخطأ لنقاط البيانات الفردية
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # تعيين شرائط الخطأ لنقاط سلسلة المخطط
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # حفظ العرض التقديمي
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```