---
title: حسابات المخططات
type: docs
weight: 50
url: /ar/python-net/chart-calculations/
keywords: "حسابات المخططات، عناصر المخطط، موضع العنصر، قيم المخطط بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "حسابات وقيم المخطط في PowerPoint باستخدام بايثون"
---

## **احسب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides لـ بايثون عبر .NET واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. سيساعدك هذا على حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout.ActualX، IActualLayout.ActualY، IActualLayout.ActualWidth، IActualLayout.ActualHeight) والقيم الفعلية للمحاور (IAxis.ActualMaxValue، IAxis.ActualMinValue، IAxis.ActualMajorUnit، IAxis.ActualMinorUnit، IAxis.ActualMajorUnitScale، IAxis.ActualMinorUnitScale).

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



## **احسب الموضع الفعلي لعناصر المخطط الأب**
توفر Aspose.Slides لـ بايثون عبر .NET واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص IActualLayout معلومات حول الموضع الفعلي لعنصر المخطط الأب. من الضروري استدعاء طريقة IChart.ValidateChartLayout() مسبقًا لتعبئة الخصائص بالقيم الفعلية.

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



## **اخفِ المعلومات من المخطط**
تساعدك هذه الفقرة على فهم كيفية اخفاء المعلومات من المخطط. باستخدام Aspose.Slides لـ بايثون عبر .NET يمكنك اخفاء **العنوان، المحور العمودي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يوضح مثال الكود أدناه كيفية استخدام هذه الخصائص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # اخفاء عنوان المخطط
    chart.has_title = False

    # اخفاء قيم المحور
    chart.axes.vertical_axis.is_visible = False

    # رؤية المحور الفئوي
    chart.axes.horizontal_axis.is_visible = False

    # اخفاء الجدول التفسيري
    chart.has_legend = False

    # اخفاء خطوط الشبكة الرئيسية
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # ضبط لون خط السلسلة
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```