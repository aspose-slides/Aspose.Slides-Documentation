---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في بايثون
linktitle: خط الاتجاه
type: docs
url: /ar/python-net/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه للمتوسط المتحرك
- خط الاتجاه متعدد الحدود
- خط الاتجاه القوة
- خط الاتجاه المخصص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "أضف خطوط الاتجاه وقم بتخصيصها بسرعة في مخططات PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET — دليل عملي وأمثلة شفرة لتحسين دقة التنبؤ وجذب جمهورك."
---

## **إضافة خط الاتجاه**
توفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة للمخططات:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم ChartType.CLUSTERED_COLUMN).
4. إضافة خط اتجاه أسي لسلسلة المخطط 1.
5. إضافة خط اتجاه خطي لسلسلة المخطط 1.
6. إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2.
7. إضافة خط اتجاه للمتوسط المتحرك لسلسلة المخطط 2.
8. إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3.
9. إضافة خط اتجاه قوة لسلسلة المخطط 3.
10. حفظ العرض المعدل إلى ملف PPTX.

الشفرة التالية تُستخدم لإنشاء مخطط مع خطوط الاتجاه.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء عرض تقديمي فارغ
with slides.Presentation() as pres:

    # إنشاء مخطط عمودي مجمع
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # إضافة خط اتجاه أسي لسلسلة المخطط 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # إضافة خط اتجاه خطي لسلسلة المخطط 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # إضافة خط اتجاه قوة لسلسلة المخطط 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # حفظ العرض التقديمي
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة خط مخصص**
توفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في مخطط. لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة Presentation
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها
- إنشاء مخطط جديد باستخدام طريقة AddChart المتاحة من كائن Shapes
- إضافة AutoShape من نوع الخط باستخدام طريقة AddAutoShape المتاحة من كائن Shapes
- تعيين لون خطوط الشكل
- حفظ العرض المعدل كملف PPTX

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ماذا يعني 'forward' و 'backward' لخط الاتجاه؟**

إنهما طول خط الاتجاه الممدود إلى الأمام أو الخلف: بالنسبة للمخططات النقطية (XY) — بوحدات المحور؛ بالنسبة للمخططات غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السلبية.

**هل سيظل خط الاتجاه محفوظًا عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/) وتقوم برسم المخططات كصورة؛ يبقى خط الاتجاه، كجزء من المخطط، محفوظًا خلال هذه العمليات. كما تتوفر طريقة لـ [تصدير صورة للمخطط](/slides/ar/python-net/create-shape-thumbnails/) نفسه.