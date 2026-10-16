---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از C++
linktitle: برچسب داده
type: docs
url: /fa/cpp/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای C++، نحوه افزودن و قالب‌بندی برچسب‌های داده نمودار در ارائه‌های PowerPoint را برای اسلایدهای جذاب‌تر بیاموزید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ تک‌تکه نشان می‌دهند و به خوانندگان کمک می‌کنند مقادیر را شناسایی و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنید، درصدها را نمایش دهید، متن برچسب را بخوانید، برچسب‌ها را فراتر از حداکثر محور کنترل کنید، فاصلهٔ برچسب‌های محور دسته‌بندی را تنظیم کنید و موقعیت برچسب‌های نمودار دایره‌ای را تعیین کنید.

## **تنظیم دقت داده در برچسب‌های دادهٔ نمودار**

از [set_NumberFormatOfValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_numberformatofvalues/) برای قالب‌بندی مقادیر سری استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌سازد. قالب `#,##0.00` جداساز هزارها و دو رقم اعشار را نمایش می‌دهد بدون اینکه مقادیر زیرین تغییر کنند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);
chart->set_HasDataTable(true);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->set_NumberFormatOfValues(u"#,##0.00");
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
```

## **نمایش درصد به عنوان برچسب‌ها**

برای یک نمودار ستون انباشته، هر مقدار را به عنوان درصدی از مجموع دستهٔ خود حساب کنید و متن را به فریم متنی 반환 شده توسط [get_TextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/) اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم 8 نقطه‌ای نمایش می‌دهد. دسته‌هایی که مجموع آنها صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر داده‌های نمودار تغییر کنند متن برچسب سفارشی را مجدداً محاسبه کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Portion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <system/convert.h>
#include <vector>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20, 20, 400, 400);

auto categoryTotals = std::vector<double>(chart->get_ChartData()->get_Categories()->get_Count(), 0.0);
for (auto k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
{
    for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
    {
        auto series = chart->get_ChartData()->get_Series()->idx_get(i);
        auto pointValue = Convert::ToDouble(series->get_DataPoint(k)->get_Value()->get_Data());
        categoryTotals[k] += pointValue;
    }
}

for (auto x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(x);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto label = series->get_DataPoint(j)->get_Label();
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        auto pointValue = Convert::ToDouble(series->get_DataPoint(j)->get_Value()->get_Data());
        auto dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        auto portion = MakeObject<Portion>();
        portion->set_Text(String::Format(u"{0:F2} %", dataPointPercent));
        portion->get_PortionFormat()->set_FontHeight(8.0f);

        label->get_TextFrameForOverriding()->set_Text(u"");

        auto paragraph = label->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
        paragraph->get_Portions()->Add(portion);

        label->get_DataLabelFormat()->set_ShowValue(true);
        label->get_DataLabelFormat()->set_ShowSeriesName(false);
        label->get_DataLabelFormat()->set_ShowPercentage(false);
        label->get_DataLabelFormat()->set_ShowLegendKey(false);
        label->get_DataLabelFormat()->set_ShowCategoryName(false);
        label->get_DataLabelFormat()->set_ShowBubbleSize(false);
    }
}

presentation->Save(u"DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
```

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**

زمانی که مقادیر به صورت کسر ذخیره شوند، از [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب به طور مستقل از سلول‌های منبع، `false` را به [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) پاس بدهید.

این مثال یک نمودار ستون 100٪ انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار مجموعاً برابر 1 است. قالب برچسب `0.0%` مقدار 0.30 را به عنوان 30.0٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید، 10 نقطه‌ای استفاده می‌کنند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
for (auto i = 0; i < 4; i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, ObjectExt::Box(String::Format(u"Category {0}", i + 1)));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

String seriesNames[] = { u"Reds", u"Blues" };
Color seriesColors[] = { Color::get_Red(), Color::get_Blue() };
double values[2][4] = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (auto i = 0; i < 2; i++)
{
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, i + 1, ObjectExt::Box(seriesNames[i]));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());
    for (auto j = 0; j < 4; j++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, j + 1, i + 1, ObjectExt::Box(values[i][j]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
    series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColors[i]);

    auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(false);
    labelFormat->set_NumberFormat(u"0.0%");
    labelFormat->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());
}

presentation->Save(u"SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
```

## **خواندن متن واقعی برچسب‌های داده**

از [GetActualLabelText](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) برای بازیابی متنی که تنظیمات یک برچسب داده تولید می‌کند، استفاده کنید. این کار هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتویات ارائه یا اعتبارسنجی نمودارهای تولید شده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/) هر نام دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به عنوان درصد قالب‌بندی می‌کند و دیگری از متن سفارشی برگرفته از [get_TextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/) استفاده می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto firstCategoryCell = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Q1"));
chart->get_ChartData()->get_Categories()->Add(firstCategoryCell);
auto secondCategoryCell = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Q2"));
chart->get_ChartData()->get_Categories()->Add(secondCategoryCell);

auto northSeriesCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"North"));
auto north = chart->get_ChartData()->get_Series()->Add(northSeriesCell, chart->get_Type());
auto northFirstValueCell = workbook->GetCell(0, 1, 1, ObjectExt::Box(0.25));
north->get_DataPoints()->AddDataPointForBarSeries(northFirstValueCell);
auto northSecondValueCell = workbook->GetCell(0, 2, 1, ObjectExt::Box(0.75));
north->get_DataPoints()->AddDataPointForBarSeries(northSecondValueCell);

auto southSeriesCell = workbook->GetCell(0, 0, 2, ObjectExt::Box<String>(u"South"));
auto south = chart->get_ChartData()->get_Series()->Add(southSeriesCell, chart->get_Type());
auto southFirstValueCell = workbook->GetCell(0, 1, 2, ObjectExt::Box(0.40));
south->get_DataPoints()->AddDataPointForBarSeries(southFirstValueCell);
auto southSecondValueCell = workbook->GetCell(0, 2, 2, ObjectExt::Box(0.60));
south->get_DataPoints()->AddDataPointForBarSeries(southSecondValueCell);

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    auto format = series->get_Labels()->get_DefaultDataLabelFormat();
    format->set_ShowCategoryName(true);
    format->set_ShowSeriesName(true);
    format->set_ShowValue(true);
}

north->get_Label(1)->get_DataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
north->get_Label(1)->get_DataLabelFormat()->set_NumberFormat(u"0%");
south->get_Label(0)->get_TextFrameForOverriding()->set_Text(u"Reviewed");

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto point = series->get_DataPoint(j);
        auto label = point->get_Label();
        if (!label->get_IsVisible())
        {
            continue;
        }

        Console::WriteLine(String::Format(u"Value: {0}; label: {1}", point->get_Value()->get_Data(), label->GetActualLabelText()));
    }
}
```

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` می‌ماند، حتی وقتی برچسب آن `75%` به همراه نام‌های دسته و سری نشان می‌دهد. متن سفارشی متن تولید‌شده برچسب را جایگزین می‌کند. [GetActualLabelText](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. همان‌طور که در بالا نشان داده شد، برای استخراج تنها برچسب‌های قابل مشاهده، [get_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/get_isvisible/) را جداگانه بررسی کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که محدودهٔ محور را به صورت دستی محدود می‌کنید، برخی نقاط داده ممکن است از حداکثر آن فراتر بروند. از [set_ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_showdatalabelsovermaximum/) برای کنترل اینکه آیا برچسب‌های دادهٔ آنها نمایش داده شوند یا نه، استفاده کنید. این تنظیم تنها قابلیت نمایش برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر زیرین داده را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای دو‌بعدی با مقادیر 60 و 120 ایجاد می‌کند. برای محور عمودی، [set_IsAutomaticMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticmaxvalue/) را روی `false` و [set_MaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_maxvalue/) را روی 100 تنظیم می‌کند. اسلاید اول اجازه می‌دهد برچسب‌ها فراتر از حداکثر باشند؛ کپی آن اسلاید این امکان را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) فعال کنید. این تنظیم در سطح نمودار به تنهایی نمایش مقدار را فعال نمی‌کند و برچسب‌های منفردی که نمایش مقدارشان غیرفعال است را بازنویسی نمی‌کند. این مثال مقادیر را برای کل سری فعال می‌کند و با [set_Position](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_position/) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

auto firstCategory = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Within range"));
auto secondCategory = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Above maximum"));

chart->get_ChartData()->get_Categories()->Add(firstCategory);
chart->get_ChartData()->get_Categories()->Add(secondCategory);

auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Values"));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());

auto firstValue = workbook->GetCell(0, 1, 1, ObjectExt::Box(60));
auto secondValue = workbook->GetCell(0, 2, 1, ObjectExt::Box(120));

series->get_DataPoints()->AddDataPointForBarSeries(firstValue);
series->get_DataPoints()->AddDataPointForBarSeries(secondValue);

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_Labels()->get_DefaultDataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);

chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(100);
chart->set_ShowDataLabelsOverMaximum(true);

auto secondSlide = presentation->get_Slides()->AddClone(slide);
auto secondChart = ExplicitCast<IChart>(secondSlide->get_Shape(0));
secondChart->set_ShowDataLabelsOverMaximum(false);

presentation->Save(u"DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
```

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با `true`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با `false`، مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطه دوم داده در هر دو حالت **120** است.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی دو‌بعدی با محور مقدار استفاده می‌کند. نمودارهای بدون محور مقدار، مانند نمودارهای دایره‌ای و دونات، حداکثر محور برای محدود کردن به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصلهٔ برچسب از محور**

از [set_LabelOffset](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_labeloffset/) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار به درصد حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را روی 500 تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط دادهٔ تک‌تکه.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

presentation->Save(u"SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
```

## **تنظیم موقعیت برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فواصل تنظیم کنید و جایگاهی برای خطوط اتصال (leader lines) فراهم کنید.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را خارج از برش قرار می‌دهد و با استفاده از [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) و [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) جابه‌جایی‌های آن را تنظیم می‌کند. این جابه‌جایی‌ها به ترتیب نسبت به عرض و ارتفاع نمودار هستند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 200, 200);
auto series = chart->get_ChartData()->get_Series();

auto label = series->idx_get(0)->get_Label(0);
label->get_DataLabelFormat()->set_ShowValue(true);
label->get_DataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

![نمودار دایره‌ای با موقعیت برچسب داده تنظیم‌شده](pie-chart-adjusted-label.png)

## **قالب‌بندی خطوط اتصال**

هنگامی که برچسب‌های نمودار دایره‌ای در بیرون برش‌ها قرار می‌گیرند، خطوط اتصال به خواننده کمک می‌کنند تا هر مقدار را با برش مناسب مطابقت دهد. رنگ متضاد و خط کمی ضخیم می‌توانند این ارتباط را واضح‌تر کنند، در حالی که شفافیت و سبک نقطه‌دار خطوط را کم‌رنگ و نامحسوس می‌سازند.

از [get_LeaderLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelcollection/get_leaderlinesformat/) برای قالب‌بندی خطوط اتصال در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات موجود در `series->get_Labels()->get_LeaderLinesFormat()->get_Line()` به کل مجموعه اعمال می‌شود نه به یک برچسب منفرد.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، مقادیر را بیرون برش‌ها نمایش می‌دهد و خطوط اتصال را با [set_ShowLeaderLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showleaderlines/) فعال می‌کند. دو برچسب را با استفاده از جابه‌جایی‌های [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) و [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) بیشتر از برش‌های خود دور می‌کند؛ این مقادیر به صورت کسری از عرض و ارتفاع نمودار بیان می‌شوند. ارائه ورودی نیازی نیست.

فرمت پر شدن برگرفته از [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) برای تنظیم رنگ آبی صلب با مقدار آلفای 191 از 255 استفاده می‌شود که حدود 25٪ شفافیت می‌دهد. [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) ضخامت را به 2 نقطه تنظیم می‌کند و [set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) خط را نقطه‌دار می‌سازد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/LineDashStyle.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 80, 50, 560, 400);
chart->set_HasLegend(false);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
labelFormat->set_ShowValue(true);
labelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
labelFormat->set_ShowLeaderLines(true);

// دو برچسب را از برش‌های خود دورتر حرکت دهید.
series->get_Label(0)->set_X(0.10f);
series->get_Label(0)->set_Y(-0.05f);
series->get_Label(1)->set_X(-0.10f);
series->get_Label(1)->set_Y(0.05f);

auto line = series->get_Labels()->get_LeaderLinesFormat()->get_Line();
line->get_FillFormat()->set_FillType(FillType::Solid);
line->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(191, 30, 90, 160));
line->set_Width(2);
line->set_DashStyle(LineDashStyle::Dash);

presentation->Save(u"FormattedLeaderLines.pptx", SaveFormat::Pptx);
```

فعال‌سازی خطوط اتصال تضمین نمی‌کند که برای هر برچسب یک خط ظاهر شود. قابلیت مشاهده به جایگذاری برچسب و رفتار چیدمان نمودار بستگی دارد. در این مثال، دو برچسب جابجا شده خطوط اتصال قابل مشاهده دارند؛ برچسب‌هایی که نزدیک برش‌های خود می‌مانند نیازی به خطوط ندارند.

تصویر زیر فایل `FormattedLeaderLines.pptx` ذخیره‌شده را که با Aspose.Slides رندر شده نشان می‌دهد:

![نمودار دایره‌ای با خطوط اتصال آبی، نیمه‌شفاف، نقطه‌دار که دو برچسب بیرونی را به برش‌هایشان متصل می‌کند](formatted-leader-lines.png)

## **افزودن ردیف‌های متعدد برچسب داده بالای نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ ترسیم ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نشان می‌دهد، در حالی که سری‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آنها با حذف پر و خط خارجی مخفی می‌شوند. روش [set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) تمام سه سری را با مراکز دسته‌ای یکسان هم‌تراز می‌کند.

تنظیمات [get_PlotArea](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_plotarea/) فضای مورد نیاز برای ردیف‌های برچسب راReserve می‌کند. پس از محاسبه موقعیت‌های پیش‌فرض توسط [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/)، [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) و [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) هم‌ترازی افقی را حفظ کرده و جابه‌جایی‌های عمودی را برای ترتیب برچسب‌ها در دو ردیف اعمال می‌کند. اعداد همچنان برچسب‌های داده مرتبط با مقادیر سری هستند؛ فقط سرعنوان ردیف‌ها به‌صورت شکل‌های متنی جداگانه هستند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPlotArea.h>
#include <DOM/Chart/LayoutTargetType.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
chart->set_HasTitle(false);
chart->set_HasLegend(false);
chart->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

String categories[] = { u"North", u"South", u"East", u"West" };
String seriesNames[] = { u"Series A", u"Series B", u"Series C" };
double seriesValues[3][4] = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
{
    auto categoryCell = workbook->GetCell(0, categoryIndex + 1, 0, ObjectExt::Box(categories[categoryIndex]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 3; seriesIndex++)
{
    auto seriesCell = workbook->GetCell(0, 0, seriesIndex + 1, ObjectExt::Box(seriesNames[seriesIndex]));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, ChartType::ClusteredColumn);

    for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(0, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(seriesValues[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // ستون‌های B و C را مخفی کنید، اما برچسب‌های داده آن‌ها را نگه دارید.
        series->get_Format()->get_Fill()->set_FillType(FillType::NoFill);
        series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
        auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
        labelFormat->set_ShowValue(true);
        labelFormat->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
        auto labelFill = labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat();
        labelFill->set_FillType(FillType::Solid);
        labelFill->get_SolidFillColor()->set_Color(Color::get_Black());
        labelFormat->set_Position(LegendDataLabelPosition::InsideBase);
    }
}

// تمام سه سری را با مراکز دسته‌ای یکسان تراز کنید.
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(100);

// برای این مثال فشرده از خطوط شبکه کمتر استفاده کنید.
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_MajorUnit(10);

// فضای بالای ناحیه‌نمودار را برای دو ردیف برچسب داده رزرو کنید.
chart->get_PlotArea()->set_LayoutTargetType(LayoutTargetType::Inner);
chart->get_PlotArea()->set_X(0.15f);
chart->get_PlotArea()->set_Y(0.32f);
chart->get_PlotArea()->set_Width(0.80f);
chart->get_PlotArea()->set_Height(0.48f);
chart->ValidateChartLayout();

for (auto seriesIndex = 1; seriesIndex < 3; seriesIndex++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(seriesIndex);
    auto rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
    {
        auto dataLabel = series->get_DataPoint(categoryIndex)->get_Label();
        // موقعیت افقی پیش‌فرض را حفظ کنید. مقدار Y یک جابجایی از
        // موقعیت پیش‌فرض برچسب است که به صورت کسری از ارتفاع نمودار بیان می‌شود.
        dataLabel->set_X(0);
        dataLabel->set_Y(rowTop - dataLabel->get_ActualY() / chart->get_Height());
    }

    // فقط سرفصل ردیف یک شکل متنی جداگانه است.
    auto rowHeading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, chart->get_X(), chart->get_Y() + rowTop * chart->get_Height(), 85, 18);
    rowHeading->get_FillFormat()->set_FillType(FillType::NoFill);
    rowHeading->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    rowHeading->AddTextFrame(seriesNames[seriesIndex]);
    rowHeading->get_TextFrame()->get_TextFrameFormat()->set_MarginTop(0);
    rowHeading->get_TextFrame()->get_TextFrameFormat()->set_MarginBottom(0);
    auto headingFormat = rowHeading->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
    headingFormat->set_FontHeight(12);
    headingFormat->get_FillFormat()->set_FillType(FillType::Solid);
    headingFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
}

presentation->Save(u"multiple-rows-of-labels.pptx", SaveFormat::Pptx);
```

![نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ ترسیم](multiple-rows-of-labels.png)

## **سؤالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای شلوغ جلوگیری کنم؟**

از جایگذاری خودکار برچسب، خطوط اتصال و کاهش اندازهٔ قلم استفاده کنید؛ در صورت لزوم برخی فیلدها (مثلاً دسته) را مخفی کنید یا برچسب‌ها را تنها برای مقادیر انتهایی یا نقاط کلیدی نشان دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

قبل از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش را برای مقادیر 0، مقادیر منفی یا مقادیر گمشده بر اساس قاعده‌ای تعریف‌شده خاموش کنید.

**چگونه می‌توانم استایل برچسب را به‌صورت ثابت هنگام خروجی به PDF/تصاویر حفظ کنم؟**

به‌طور صریح خانواده و اندازهٔ قلم را تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفادهٔ جایگزین جلوگیری شود.