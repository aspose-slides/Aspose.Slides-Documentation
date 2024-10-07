---
title: نقاط بيانات خريطة الشجرة ورسم الشمس
type: docs
url: /python-net/data-points-of-treemap-and-sunburst-chart/
keywords: "رسم الشمس، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إضافة رسم الشمس في عرض PowerPoint باستخدام بايثون"
---

من بين أنواع الرسوم البيانية في PowerPoint الأخرى، هناك نوعان "هرميان" - **خريطة الشجرة** و **رسم الشمس** (المعروف أيضًا باسم رسم الشمس، مخطط الشمس، الرسم الشعاعي أو مخطط الفطيرة متعدد المستويات). تعرض هذه الرسوم البيانية بيانات هرمية منظمة كشجرة - من الأوراق إلى قمة الفرع. يتم تعريف الأوراق بواسطة نقاط بيانات السلسلة، وكل مستوى تجميع متداخل لاحق يتم تعريفه بواسطة الفئة المقابلة. يسمح Aspose.Slides لبايثون عبر .NET بتنسيق نقاط بيانات رسم الشمس وخريطة الشجرة في بايثون.

إليك رسم شمس، حيث تحدد البيانات في عمود Series1 العقدة الورقية، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة رسم شمس جديد إلى العرض:



```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [**إنشاء رسم شمس**](/slides/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


إذا كانت هناك حاجة لتنسيق نقاط بيانات الرسم، يجب علينا استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/)، 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) الصفوف 
و [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/) الخاصية 
تقدم الوصول لتنسيق نقاط بيانات خريطة الشجرة ورسم الشمس. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
تستخدم للوصول إلى الفئات متعددة المستويات - يمثل الحاوية لـ 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) الكائنات. 
بشكل أساسي هي غلاف لـ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/) مع 
الخصائص المضافة المحددة لنقاط البيانات. 
لدى [**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) صفان: [**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) و 
[**DataLabel** ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) والتي 
تقدم الوصول إلى الإعدادات المقابلة.
## **عرض قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "Leaf 4":



```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **تعيين تسمية نقطة البيانات واللون**
تعيين تسمية البيانات "Branch 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم تعيين لون النص إلى الأصفر:



```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **تعيين لون فرع نقطة البيانات**

تغيير لون فرع "Stem 4":

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)
