---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام بايثون
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/python-net/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides for Python عبر .NET، مع دعم ملفات PPT و PPTX و ODP — عزّز عروضك التقديمية اليوم."
---

## **ضبط خصائص RotationX، RotationY و DepthPercents للمخطط ثلاثي الأبعاد**
يوفر Aspose.Slides for Python عبر .NET واجهة برمجة تطبيقات بسيطة لضبط هذه الخصائص. سيساعدك هذا المقال التالي على ضبط خصائص مختلفة مثل دوران X, Y، **DepthPercents** وغيرها. يطبق الكود النموذجي ضبط الخصائص المذكورة أعلاه.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. ضبط خصائص Rotation3D.
5. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:
            
    # الوصول إلى الشريحة الأولى
    slide = presentation.slides[0]

    # إضافة مخطط ببيانات افتراضية
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # ضبط فهرس ورقة بيانات المخطط
    defaultWorksheetIndex = 0

    # الحصول على ورقة عمل بيانات المخطط
    fact = chart.chart_data.chart_data_workbook

    # إضافة سلسلة
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # إضافة الفئات
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # ضبط خصائص Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # أخذ السلسلة الثانية للمخطط
    series = chart.chart_data.series[1]

    # الآن تعبئة بيانات السلسلة
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # ضبط قيمة OverLap
    series.parent_series_group.overlap = 100         

    # كتابة العرض التقديمي إلى القرص
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides إصدارات ثلاثية الأبعاد من المخططات العمودية، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، بالإضافة إلى الأنواع ثلاثية الأبعاد ذات الصلة التي تُعرض من خلال تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) أو [تصدير الشريحة بالكامل](/slides/ar/python-net/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بيكسلية أو ترغب في تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض مخططات 3D الكبيرة؟**

تعتمد الأداء على حجم البيانات وتعقيد الشكل البصري. للحصول على أفضل النتائج، احتفظ بتأثيرات 3D إلى الحد الأدنى، تجنب القوام الثقيلة على الجدران ومناطق الرسم، قلل عدد نقاط البيانات لكل سلسلة قدر الإمكان، وقم بالعرض إلى مخرجات بالحجم المناسب (الدقة والأبعاد) لتتناسب مع شاشة العرض أو احتياجات الطباعة المستهدفة.