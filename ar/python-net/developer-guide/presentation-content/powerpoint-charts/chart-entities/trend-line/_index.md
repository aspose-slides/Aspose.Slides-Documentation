---
title: خط الاتجاه
type: docs
url: /python-net/trend-line/
keywords: "خط الاتجاه، خط مخصص عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إضافة خط اتجاه وخط مخصص إلى عروض PowerPoint في بايثون"
---

## **إضافة خط اتجاه**
توفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في المخططات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة مخطط مع بيانات افتراضية إلى جانب أي نوع مرغوب (هذا المثال يستخدم ChartType.CLUSTERED_COLUMN).
1. إضافة خط اتجاه أسي لسلسلة المخطط 1.
1. إضافة خط اتجاه خطي لسلسلة المخطط 1.
1. إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2.
1. إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2.
1. إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3.
1. إضافة خط اتجاه قوى لسلسلة المخطط 3.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

الكود التالي يستخدم لإنشاء مخطط مع خطوط الاتجاه.

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
    tredLineLog.add_text_frame_for_overriding("خط الاتجاه اللوغاريتمي الجديد")

    # إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "اسم خط الاتجاه الجديد"

    # إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # إضافة خط اتجاه قوى لسلسلة المخطط 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # حفظ العرض التقديمي
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **إضافة خط مخصص**
توفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في مخطط. لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع شريحة باستخدام فهرسها
- إنشاء مخطط جديد باستخدام طريقة AddChart المعروضة بواسطة كائن Shapes
- إضافة شكل أوتوماتيكي من نوع خط باستخدام طريقة AddAutoShape المعروضة بواسطة كائن Shapes
- تعيين لون شكل الخطوط.
- كتابة العرض التقديمي المعدل كملف PPTX

الكود التالي يستخدم لإنشاء مخطط مع خطوط مخصصة.

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