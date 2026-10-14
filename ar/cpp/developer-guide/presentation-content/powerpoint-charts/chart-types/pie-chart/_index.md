---
title: تخصيص مخططات الفطيرة في العروض التقديمية باستخدام C++
linktitle: مخطط الفطيرة
type: docs
url: /ar/cpp/pie-chart/
keywords:
- مخطط فطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص مخططات الفطيرة في C++ باستخدام Aspose.Slides. تكوين المخططات الثانوية، عرض تسميات البيانات، وتطبيق ألوان شرائح تلقائية في PowerPoint."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع مخططات الفطيرة في Aspose.Slides. تُظهر كيفية تكوين خيارات المخطط الثانوي لمخططات فطيرة داخل فطيرة وشريط فطيرة، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط الفطيرة القياسي.

تركز الأمثلة على مهام تخصيص المخطط مثل إضافة مخطط إلى شريحة، وضبط إعدادات السلاسل والملصقات، واستبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات المخطط الثانوي لمخططات فطيرة داخل فطيرة وشريط فطيرة**

يدعم Aspose.Slides للغة C++ خيارات المخطط الثانوي لمخططات فطيرة داخل فطيرة وشريط فطيرة. تتحكم هذه الخيارات في حجم المخطط الثانوي وكيفية تقسيم نقاط البيانات بين المخططين.

المثال التالي يُنشئ مخطط فطيرة داخل فطيرة في عرض تقديمي جديد ويعرض قيم نقاط البيانات كملصقات. طريقة [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) تُحدد حجم المخطط الثانوي بنسبة 149 % من المخطط الرئيسي. طريقة [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) تختار التقسيم القائم على النسبة المئوية، وطريقة [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) تُحدد العتبة إلى 53 %.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **تحديد الفئات للمخطط الثانوي**

استخدم التقسيم المخصص عندما تريد تجميع فئات معينة في المخطط الثانوي بغض النظر عن قيم النسب المئوية الخاصة بها. على سبيل المثال، قد يُظهر تقرير المبيعات القنوات “Online” و“Events” معًا حتى يتمكن القارئ من مقارنة هاتين القناتين، على الرغم من أنهما تمثلان 35 % و10 % من إجمالي المبيعات.

استدعِ طريقة [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) مع [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) وحدد النقاط عبر [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/). طريقة مجموعة [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) تقبل فهرسًا يبدأ من الصفر في السلسلة. في هذا المثال، الفهرس 1 يختار “Online”، والفهرس 3 يختار “Events”. تتم إضافة “Partners” مؤقتًا، ثم تُستثنى باستخدام طريقة [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// استبدال البيانات الافتراضية بمبيعات حسب القناة.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// اختيار Online وEvents وفقًا لمؤشراتهما الصفرية في السلسلة.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// استبعاد Partners من الاختيار دون حذف بيانات المصدر الخاصة به.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

تظهر “Online” (35) و“Events” (10) كشرائح منفصلة في المخطط الثانوي. وفي المخطط الرئيسي، يتم تمثيلهما بشريحة مشتركة بقيمة 45، إلى جانب “Retail” (40) و“Partners” (15). إزالة “Partners” من الاختيار المخصص يبقيها في المخطط الرئيسي؛ لا يتم حذف الفئة أو قيمتها من بيانات المصدر للمخطط.

الصورة التالية تُظهر العرض التقديمي المحفوظ في PowerPoint:

![مخطط فطيرة داخل فطيرة مع Online وEvents في المخطط الثانوي والقيمة المجمعة 45 في المخطط الرئيسي](pie_of_pie_custom.png)

## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**

يمكن لـ Aspose.Slides للغة C++ تعيين ألوان مختلفة تلقائيًا لشرائح مخطط الفطيرة. المثال التالي يُنشئ مخطط فطيرة بعنوان مركزي ويستبدل البيانات الافتراضية بثلاث فئات ربع سنوية وقيمها. طريقة [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) تعرض القيم 20 و50 و30 كملصقات، بينما تُفعّل طريقة [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) لونًا مميزًا لكل شريحة.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// إضافة عنوان مخطط مركّز.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Replace the default data using the first worksheet.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// Show values and assign different colors to the slices.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **الأسئلة المتداولة**

**هل تُدعَم أشكال فطيرة داخل فطيرة وشريط فطيرة؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) مخططًا ثانويًا لمخططات الفطيرة، بما في ذلك نوعي فطيرة داخل فطيرة وشريط فطيرة.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (مثل PNG) دون تصدير العرض التقديمي بأكمله.