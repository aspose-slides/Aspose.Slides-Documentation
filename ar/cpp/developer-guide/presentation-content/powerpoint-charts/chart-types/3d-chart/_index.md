---
title: تخصيص مخططات ثلاثية الأبعاد في العروض التقديمية باستخدام C++
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/cpp/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides for C++. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل مع أمثلة C++."
---
## **نظرة عامة**

Aspose.Slides for C++ يتيح لك تخصيص عرض مخطط ثلاثي الأبعاد من خلال [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). يوضح هذا المقال طريقة تعديل الدوران، نسب الارتفاع، العمق، المحاور القائمة على الزاوية القائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بصيغة PPTX.

## **ضبط الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ويستخدم [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاث قيم. فهرس ورقة العمل `0` يحدد ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

الطرق [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) و[set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) تضبط دوران المخطط إلى 40 و270 درجة على التوالي. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) يحدد عمقه إلى 150 % من عرضه، بينما [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) يفعّل المحاور القائمة بدلاً من المنظور. العرض التقديمي الناتج يحتوي على المخطط المملوء بهذه إعدادات العرض الثلاثي الأبعاد.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) لضبط ارتفاع المخطط الثلاثي الأبعاد كنسبة مئوية من عرضه. يغير ذلك نسب المشهد الثلاثي الأبعاد دون تغيير حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخطط [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاثة عروض تقديمية بنسب ارتفاع 50 %، 100 %، و200 %. يبقى موضع المخطط وعرضه وارتفاعه ثابتين. البيانات، الدوران، العمق، مسافة السلاسل، والتنسيق هي نفسها في الملفات الثلاثة؛ فقط نسبة الارتفاع تتغير.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

الصورة التالية من مثال .NET المكافئ تم تصديرها باستخدام Microsoft PowerPoint وتوضح نفس إعدادات الارتفاع. النسبة الصغيرة تنتج مشهداً أكثر تسطحاً، بينما النسبة الكبيرة تنتج مشهداً أعلى داخل نفس كائن المخطط. قد يقوم PowerPoint أيضاً بضبط فواصل علامات المحور ووضع التسميات لتناسب المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 50 % من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 100 % من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 200 % من عرضه](height_percent_200.png) |

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | ارتفاع المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | ارتفاع كائن المخطط على الشريحة، بوحدة النقاط. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | عمق المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

إعداد الارتفاع يؤثر على المخططات العمودية والشريطية الثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية، المساحية، الفطيرة، والسطحية الثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع المؤكد `Column3D`. لا يغير الإعداد مظهر مخطط `ClusteredColumn` الثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء تعداد [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). للحصول على إعدادات مظهر أخرى للمخطط، راجع [Chart Formatting](/slides/ar/cpp/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) للتحكم بالمسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. القيم من **0 إلى 500** شاملًا: `0` يزيل الفجوة، بينما القيم الأكبر تزيد المسافة. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرفع على محور العمق.

الوصول إلى المجموعة يتم عبر [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). الإعداد يطبق على كل السلاسل في تلك المجموعة، ليس فقط السلسلة المستخدمة للوصول إليها. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) يُعيد إعداد المجموعة الأصل.

هذا الإعداد يؤثر على المخططات العمودية والشريطية الثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية والمساحية الثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، أو متق clustered، أو مكدسة. للمقارنة الواضحة بين الفجوات بين السلاسل المنفصلة، استخدم `ChartType::Column3D` من تعداد [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | المسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | العمق الكلي للمخطط، كنسبة مئوية من عرض المخطط. |

المثال التالي المستقل يستخدم بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض فجوة، وعمق مخطط متماثلة؛ فقط عمق الفجوة يتغير.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

الصورة التالية من مثال .NET المكافئ تم تصديرها باستخدام Microsoft PowerPoint وتوضح نفس إعدادات عمق الفجوة.

| عمق الفجوة: 0% | عمق الفجوة: 500% |
| --- | --- |
| ![مخطط عمود ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمود ثلاثي الأبعاد بفجوة 500 % بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة الثلاثية الأبعاد وشكل العمود**

في مخطط أسطوانة مجموعة، يبدأ السلسلة الأولى بأعمدة أسطوانية. يقرأ المثال [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) و[IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) قبل وبعد كل تغيير.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| التغيير للسلسلة الأولى | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| استدعاء [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) بـ `ClusteredCone` | `ClusteredCone` | `Cone` |
| استدعاء [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) بـ `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان الكود يتفرع بناءً على نوع السلسلة، استدعِ `series->get_Type()` بعد تغيير الشكل. القيمة المخزنة مسبقًا قبل التغيير لا تزال تُعيد فرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم الوضع الثلاثي الأبعاد في Aspose.Slides؟**

Aspose.Slides يدعم المتغيرات الثلاثية الأبعاد من المخططات العمودية، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100 % Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد ذات الصلة المعروضة عبر تعداد [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكن الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) أو [تصيّر الشريحة بالكامل](/slides/ar/cpp/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات تحكم، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

الأداء يعتمد على حجم البيانات وتعقيد العرض المرئي. للحصول على أفضل النتائج، حافظ على الحد الأدنى من المؤثرات الثلاثية الأبعاد، تجنّب القوام الثقيلة على الجدران ومناطق الرسم، حدّ من عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وصوّر بدقة تناسب العرض المستهدف أو احتياجات الطباعة.