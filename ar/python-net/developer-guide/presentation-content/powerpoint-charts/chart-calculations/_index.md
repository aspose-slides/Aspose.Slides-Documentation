---
title: تحسين حسابات المخطط للعرض التقديمي باستخدام Python
linktitle: حسابات المخطط
type: docs
weight: 50
url: /ar/python-net/chart-calculations/
keywords:
- حسابات المخطط
- عناصر المخطط
- موضع العنصر
- الموضع الفعلي
- العنصر الفرعي
- العنصر الأصلي
- قيم المخطط
- القيمة الفعلية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "فهم حسابات المخطط، تحديثات البيانات، والتحكم في الدقة في Aspose.Slides للغة Python عبر .NET لملفات PPT و PPTX و ODP، مع أمثلة شيفرة عملية."
---

## **حساب القيم الفعلية لعناصر المخطط**
Aspose.Slides for Python عبر .NET توفر واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. سيساعدك ذلك في حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) والقيم الفعلية للمحاور (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```


## **حساب الموضع الفعلي لعناصر المخطط الأصلية**
Aspose.Slides for Python عبر .NET توفر واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص IActualLayout معلومات حول الموضع الفعلي للعنصر الأصل للمخطط. من الضروري استدعاء الطريقة IChart.ValidateChartLayout() مسبقًا لملء الخصائص بالقيم الفعلية.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```


## **إخفاء المعلومات من المخطط**
هذا الموضوع يساعدك على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for Python عبر .NET يمكنك إخفاء **العنوان، المحور الرأسي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يوضح مثال الشيفرة أدناه كيفية استخدام هذه الخصائص.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # إخفاء عنوان المخطط
    chart.has_title = False

    # إخفاء محور القيم
    chart.axes.vertical_axis.is_visible = False

    # إظهار محور الفئات
    chart.axes.horizontal_axis.is_visible = False

    # إخفاء مفتاح الرسم
    chart.has_legend = False

    # إخفاء خطوط الشبكة الرئيسية
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # تعيين لون خط السلسلة
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**هل تعمل دفاتر العمل الخارجية لبرنامج Excel كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال أو تحديث المصدر الخارجي، تُؤخذ الصيغ والقيم من ذلك الدفتر، ويعكس المخطط التحديثات أثناء عمليات الفتح/التحرير. تتيح لك الواجهة البرمجية [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) والمسار وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. [خطوط الاتجاه](/slides/ar/python-net/trend-line/) (خطية، أسية، وغيرها) يتم إضافتها وتحديثها بواسطة Aspose.Slides؛ تُعاد حساب معلماتها من بيانات السلسلة تلقائيًا، لذا لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة مع روابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر عمل خارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.