---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst باستخدام С++
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط Treemap
- مخطط Sunburst
- نقطة بيانات
- لون التسمية
- لون الفرع
- PowerPoint
- عرض تقديمي
- С++
- Aspose.Slides
description: "تعلم كيفية إدارة نقاط البيانات في مخططات Treemap و Sunburst باستخدام Aspose.Slides للغة С++، المتوافقة مع صيغ PowerPoint."
---

من بين الأنواع الأخرى لمخططات PowerPoint، هناك نوعان "هرميان" - **Treemap** و **Sunburst** (المعروفة أيضًا باسم Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi Level Pie Chart). تعرض هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى قمة الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، وكل مستوى تجميع متداخل لاحق يُحدد بالفئة المقابلة. يتيح Aspose.Slides for C++ تنسيق نقاط بيانات مخطط Sunburst و Treemap في C++.

فيما يلي مخطط Sunburst، حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [**Creating Sunburst Chart**](/slides/ar/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط بيانات المخطط، يجب استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager)، 
[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) الفئات 
و[**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) الطريقة 
توفر الوصول لتنسيق نقاط بيانات مخطط Treemap و Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) يُستخدم للوصول إلى الفئات متعددة المستويات - وهو يمثل الحاوية لـ [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) الكائنات. أساسًا هو غلاف لـ [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) مع الخصائص المضافة الخاصة بنقاط البيانات. فئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) تحتوي على طريقتين: [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) و[**get_Label()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25) التي توفر الوصول إلى الإعدادات المقابلة.

## **عرض قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "Leaf 4":
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تحديد تسمية ولون نقطة البيانات**
اضبط تسمية البيانات لـ "Branch 1" لتظهر اسم السلسلة ("Series1") بدلًا من اسم الفئة. ثم اضبط لون النص إلى الأصفر:
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تحديد لون فرع نقطة البيانات**
غيّر لون فرع "Stem 4":
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

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (الفرز) القطاعات في مخطط Sunburst/Treemap؟**  
لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً حسب القيم المتناقصة، باتجاه عقارب الساعة). ينسخ Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ بل تقوم بذلك عبر معالجة البيانات مسبقًا.

**كيف يؤثر موضوع العرض التقديمي على ألوان القطاعات والتسميات؟**  
تورث ألوان المخطط [الموضوع/لوحة الألوان](/slides/ar/cpp/presentation-theme/) من العرض التقديمي ما لم تقم بضبط التعبئات/الخطوط صراحة. للحصول على نتائج متسقة، احصر التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**  
نعم. عند تصدير العرض التقديمي، يتم الحفاظ على إعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بالتصيير مع تطبيق تنسيق المخطط.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر من أجل وضع طبقة مخصصة فوق المخطط؟**  
نعم. بعد التحقق من صحة تخطيط المخطط، تكون قيم X و Y الفعلية متاحة للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/))، مما يساعد في تحديد موضع الطبقات بدقة.