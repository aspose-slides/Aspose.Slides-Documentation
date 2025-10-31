---
title: إدارة علامات بيانات الرسم البياني في العروض التقديمية باستخدام بايثون
linktitle: علامة البيانات
type: docs
url: /ar/python-net/chart-data-marker/
keywords:
- رسم بياني
- نقطة بيانات
- علامة
- خيارات العلامة
- حجم العلامة
- نوع التعبئة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية تخصيص علامات بيانات الرسم البياني في Aspose.Slides، مما يعزز تأثير العرض التقديمي عبر صيغ PPT و PPTX و ODP مع أمثلة شيفرة واضحة."
---

## **تعيين خيارات علامة الرسم البياني**
يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلاسل معينة. لتعيين خيارات علامة الرسم البياني، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ السلسلة الأولى للرسم البياني.
- إضافة نقطة بيانات جديدة.
- حفظ العرض التقديمي إلى القرص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # إنشاء الرسم البياني الافتراضي
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # الحصول على فهرس ورقة عمل بيانات الرسم البياني الافتراضية
    defaultWorksheetIndex = 0

    # الحصول على ورقة عمل بيانات الرسم البياني
    fact = chart.chart_data.chart_data_workbook

    # حذف السلسلة التجريبية
    chart.chart_data.series.clear()

    # إضافة سلسلة جديدة
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # تعيين الصورة
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # تعيين الصورة
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # أخذ السلسلة الأولى للرسم البياني
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

    # حفظ العرض التقديمي إلى القرص
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**ما هي أشكال العلامات المتوفرة بشكل افتراضي؟**

الأشكال القياسية متوفرة (دائرة، مربع، معين، مثلث، إلخ)؛ القائمة معرفة بواسطة تعداد [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/). إذا كنت بحاجة إلى شكل غير قياسي، استخدم علامة بملء صورة لمحاكاة رسومات مخصصة.

**هل يتم الحفاظ على العلامات عند تصدير الرسم البياني إلى صورة أو SVG؟**

نعم. عند تصيير الرسوم البيانية إلى [تنسيقات نقطية](/slides/ar/python-net/convert-powerpoint-to-png/) أو حفظ [الأشكال كـ SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم، والتعبئة، والحدود.