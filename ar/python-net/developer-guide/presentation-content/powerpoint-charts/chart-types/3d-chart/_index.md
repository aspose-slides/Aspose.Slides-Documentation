---
title: الرسم البياني ثلاثي الأبعاد
type: docs
url: /ar/python-net/3d-chart/
keywords: "رسم بياني ثلاثي الأبعاد, rotationX, rotationY, depthpercent, عرض PowerPoint, Python, Aspose.Slides لـ Python عبر .NET"
description: "تعيين rotationX و rotationY و depthpercents للرسم البياني ثلاثي الأبعاد في عرض PowerPoint في Python"
---

## **تعيين الخصائص RotationX و RotationY و DepthPercents للرسم البياني ثلاثي الأبعاد**
توفر Aspose.Slides لـ Python عبر .NET واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. ستساعدك المقالة التالية على كيفية تعيين خصائص مختلفة مثل دوران X و Y و **DepthPercents** وما إلى ذلك. يقوم الكود النموذجي بتطبيق الإعدادات المذكورة أعلاه.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني مع بيانات افتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض المعدل إلى ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:
            
    # Access first slide
    slide = presentation.slides[0]

    # Add chart with default data
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Setting the index of chart data sheet
    defaultWorksheetIndex = 0

    # Getting the chart data worksheet
    fact = chart.chart_data.chart_data_workbook

    # Add series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Add Catrgories
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Set Rotation3D properties
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Take second chart series
    series = chart.chart_data.series[1]

    # Now populating series data
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Set OverLap value
    series.parent_series_group.overlap = 100         

    # Write presentation to disk
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```