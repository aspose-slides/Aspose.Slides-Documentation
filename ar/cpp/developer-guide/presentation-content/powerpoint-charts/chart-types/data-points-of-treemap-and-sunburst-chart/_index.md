---
title: نقاط البيانات لمخطط الشجرة والمخطط الشمسي
type: docs
url: /ar/cpp/data-points-of-treemap-and-sunburst-chart/
keywords: "مخطط شمسي"
description: "مخطط شمسي، رسم بياني شمسي، مخطط شمسي، رسم بياني دائري، رسم بياني دائري أو مخطط دائري متعدد المستويات باستخدام Aspose.Slides."
---

من بين أنواع مخططات PowerPoint الأخرى، هناك نوعان "هرميان" - **مخطط شجرة** و **مخطط شمسي** (المعروف أيضًا باسم الرسم البياني الشمسي، الرسم البياني الشمسي، الرسم البياني الدائري، الرسم البياني الدائري أو المخطط الدائري متعدد المستويات). تعرض هذه المخططات بيانات هرمية منظمة على شكل شجرة - من الأوراق إلى قمة الفرع. يتم تعريف الأوراق بواسطة نقاط البيانات السلسلة، وكل مستوى تجميع متداخل لاحق يتم تعريفه بواسطة الفئة المعنية. يسمح Aspose.Slides لـ C++ بتنسيق نقاط البيانات لمخطط الشمسي ومخطط الشجرة في C++.

إليك مخطط شمسي، حيث تعرف البيانات في عمود Series1 العقد الورقية، بينما تعرف الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط شمسي جديد إلى العرض التقديمي:



``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [**إنشاء مخطط شمسي**](/slides/ar/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

إذا كانت هناك حاجة لتنسيق نقاط البيانات للمخطط، يجب علينا استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager)، 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) الفصول 
و [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) الطريقة 
تقدم الوصول لتنسيق نقاط البيانات لمخططات الشجرة والمخطط الشمسي. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 
يستخدم للوصول إلى الفئات متعددة المستويات - يمثل الحاوية لـ 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) كائنات. 
بشكل أساسي هو غلاف لـ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) مع 
الخصائص المضافة الخاصة بنقاط البيانات. 
فصل [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) لديه 
طريقتان: [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) و 
[**get_Label()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25)التي 
تقدم الوصول إلى الإعدادات المعنية.
## **عرض قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "ورقة 4":



``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **تعيين تسمية ونقطة بيانات اللون**
تعيين تسمية نقطة بيانات "فرع 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم تعيين لون النص إلى الأصفر:



``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **تعيين لون فرع نقطة البيانات**

تغيير لون فرع "ساق 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)