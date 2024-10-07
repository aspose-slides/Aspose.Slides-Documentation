---
title: علامة بيانات الرسم البياني
type: docs
url: /python-net/chart-data-marker/
keywords: "خيارات علامات الرسم البياني، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "تعيين خيارات علامات الرسم البياني في عروض PowerPoint باستخدام Python"
---

## **تعيين خيارات علامات الرسم البياني**
يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلسلة معينة. لتعيين خيارات علامات الرسم البياني، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ السلسلة الأولى من الرسم البياني.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي على القرص.

في المثال المعطى أدناه، قمنا بتعيين خيارات علامات الرسم البياني على مستوى نقاط البيانات.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # إنشاء الرسم البياني الافتراضي
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # الحصول على فهرس ورقة بيانات الرسم البياني الافتراضية
    defaultWorksheetIndex = 0

    # الحصول على ورقة بيانات الرسم البياني
    fact = chart.chart_data.chart_data_workbook

    # حذف السلاسل التجريبية
    chart.chart_data.series.clear()

    # إضافة سلسلة جديدة
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # تعيين الصورة
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # تعيين الصورة
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # أخذ السلسلة الأولى من الرسم البياني
    series = chart.chart_data.series[0]

    # إضافة نقطة جديدة (1:3) هناك.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # تغيير علامة سلسلة الرسم البياني
    series.marker.size = 15

    # كتابة العرض التقديمي على القرص
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```