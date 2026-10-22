---
title: قالب‌بندی نمودارهای ارائه در C++
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/cpp/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- مرز گرد
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یادگیری قالب‌بندی نمودارها در Aspose.Slides برای C++ و ارتقاء ارائه PowerPoint خود با محورها، قلم‌ها، قالب‌های عددی سفارشی و مرزهای گرد نمودار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنیم. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه ترسیم و پرکردن دیوارها را برای بهبود ظاهر و خوانایی داده‌های نمودار سفارشی‌سازی کنیم.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌تنظیم‌شده به داده‌های نمودار و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار را نشان می‌دهد. این مثال‌ها به‌طور ترکیبی نشان می‌دهند چگونه می‌توان سبک بصری و ارائه داده‌های نمودارها را در یک ارائه کنترل کرد.

## **قالب‌بندی موجودیت‌های نمودار**

از [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، افسانه‌ها و ناحیه ترسیم استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند و سپس سبک‌های متن و خطی جداگانه‌ای را به محورهاى مقدار و دسته‌بندی آن اعمال می‌سازد. اندازه‌های قلم و عرض خطوط بر حسب پوینت مشخص می‌شوند؛ برچسب‌های دسته‌بندی به‌صورت 45 درجه چرخانده می‌شوند.

محور مقدار از [get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/) مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -2 تا 15 است، با فواصل بزرگ 2 و فواصل کوچک 0.5. این مثال همچنین قالب‌بندی درصدی را با [get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/) تنظیم‌شده بر روی هزارها ترکیب می‌کند، بنابراین این تنظیمات را بر حسب معنا و اندازه داده‌های خود تنظیم کنید. افسانه به‌دلیل غیرفعال بودن [get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/) در خارج از ناحیه ترسیم می‌ماند. پرکردن دیوار پس‌زمینه و کف از طریق [get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) و [get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) پیکربندی می‌شود، اما این سطوح تنها در نمودارهای سه‌بعدی قابل مشاهده‌اند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <drawing/color.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortion.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/DisplayUnitType.h>
#include <DOM/Chart/TickLabelPositionType.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IChartPlotArea.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"");
auto chartTitle = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
chartTitle->set_Text(u"Sample Chart");
chartTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
chartTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
chartTitle->get_PortionFormat()->set_FontHeight(20);
chartTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
chartTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->set_Width(5);
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->set_Width(3);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Thousands);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.0%");

chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);

chart->get_Axes()->get_VerticalAxis()->set_MaxValue(15.0f);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-2.0f);
chart->get_Axes()->get_VerticalAxis()->set_MinorUnit(0.5f);
chart->get_Axes()->get_VerticalAxis()->set_MajorUnit(2.0f);

auto valueAxisText = chart->get_Axes()->get_VerticalAxis()->get_TextFormat()->get_PortionFormat();
valueAxisText->set_FontBold(NullableBool::True);
valueAxisText->set_FontHeight(16);
valueAxisText->set_FontItalic(NullableBool::True);
valueAxisText->get_FillFormat()->set_FillType(FillType::Solid);
valueAxisText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkGreen());
auto valueAxisFont = System::MakeObject<FontData>(u"Times New Roman");
valueAxisText->set_LatinFont(valueAxisFont);

chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"");
auto valueAxisTitle = chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
valueAxisTitle->set_Text(u"Primary Axis");
valueAxisTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
valueAxisTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
valueAxisTitle->get_PortionFormat()->set_FontHeight(20);
valueAxisTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
valueAxisTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->set_Width(5);

chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->set_Width(3);

auto categoryAxisText = chart->get_Axes()->get_HorizontalAxis()->get_TextFormat()->get_PortionFormat();
categoryAxisText->set_FontBold(NullableBool::True);
categoryAxisText->set_FontHeight(16);
categoryAxisText->set_FontItalic(NullableBool::True);
categoryAxisText->get_FillFormat()->set_FillType(FillType::Solid);
categoryAxisText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
auto categoryAxisFont = System::MakeObject<FontData>(u"Arial");
categoryAxisText->set_LatinFont(categoryAxisFont);

chart->get_Axes()->get_HorizontalAxis()->set_HasTitle(true);
chart->get_Axes()->get_HorizontalAxis()->get_Title()->AddTextFrameForOverriding(u"");

auto categoryAxisTitle = chart->get_Axes()->get_HorizontalAxis()->get_Title()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
categoryAxisTitle->set_Text(u"Sample Category");
categoryAxisTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
categoryAxisTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
categoryAxisTitle->get_PortionFormat()->set_FontHeight(20);
categoryAxisTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
categoryAxisTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_HorizontalAxis()->set_TickLabelPosition(TickLabelPositionType::Low);
chart->get_Axes()->get_HorizontalAxis()->set_TickLabelRotationAngle(45);

auto legendText = chart->get_Legend()->get_TextFormat()->get_PortionFormat();
legendText->set_FontBold(NullableBool::True);
legendText->set_FontHeight(16);
legendText->set_FontItalic(NullableBool::True);
legendText->get_FillFormat()->set_FillType(FillType::Solid);
legendText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkRed());

chart->get_Legend()->set_Overlay(false);

chart->get_BackWall()->set_Thickness(1);
chart->get_BackWall()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_BackWall()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Orange());

chart->get_Floor()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_Floor()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

chart->get_PlotArea()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_PlotArea()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_LightCyan());

presentation->Save(u"FormattedChart_out.pptx", SaveFormat::Pptx);
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم 20 پوینت ایجاد می‌کند و برچسب‌های مقدار را برای سری اول از طریق [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) فعال می‌سازد. عناصر متنی با تنظیمات قلم صریح خود می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
chart->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_ChartData()->get_Series()->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"FontPropertiesForChart.pptx", SaveFormat::Pptx);
```

## **تنظیم قالب عددی**

از [IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) برای اعمال یک قالب عددی داخلی به سلول‌های کارپرت نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض، بر پایه سلول، ایجاد می‌کند و اندیس قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر را در کارپرت بدون تغییر عددهای پایه تغییر می‌دهد؛ به‌عنوان مثال 0.25 به‌صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند به‌صورت جداگانه پیکربندی شوند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IChartDataCell.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series();

for (auto chartSeries : series)
{
    for (auto dataPoint : chartSeries->get_DataPoints())
    {
        dataPoint->get_Value()->get_AsCell()->set_PresetNumberFormat(10); // 0.00%
    }
}

presentation->Save(u"PresetNumberFormat_out.pptx", SaveFormat::Pptx);
```

جدول زیر فهرست اندیس‌های قالب عددی داخلی به همراه قالب‌های متعارف Excel برای محل‌گذاری انگلیسی (ایالات متحده) را نشان می‌دهد. رشته‌های قالب دقیق و نحوه نمایش آنها می‌تواند بسته به برنامه و محل‌گذاری متفاوت باشد، به‌ویژه برای ارز و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| شاخص | قالب |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تنظیم مرزهای گرد ناحیه نمودار**

از [IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/) برای گرد کردن گوشه‌های ناحیه نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) برای دادن یک رنگ خاکستری ثابت و سبک خط تک به حاشیه آن استفاده می‌کند قبل از ذخیره ارائه.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <drawing/color.h>
#include <DOM/FillType.h>
#include <DOM/LineStyle.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
chart->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
chart->get_LineFormat()->set_Style(LineStyle::Single);
chart->set_HasRoundedCorners(true);

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند اشکال سفارشی، مانند یک حاشیه‌نویسی متنی که وضعیت یک گزارش را توضیح می‌دهد، داشته باشد. به این اشکال از طریق [IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/) دسترسی پیدا کنید، که همچنین تحت [Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/) در مرجع API نمودار فهرست شده است. مجموعه [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) آن شامل اشکال متعلق به نمودار می‌شود.

یک جعبه متن عادی که روی نمودار قرار می‌گیرد به اسلاید تعلق دارد، حتی اگر به‌نظر برسد بخشی از نمودار است. مرور [Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) نمودار و اشکال عادی اسلاید را پیدا می‌کند، اما اشکال فردی داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای هستند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

بارگیری [chart-annotations.pptx](chart-annotations.pptx) و آن را در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک نمودار با حاشیه‌نویسی بدون گروه «نتایج مقدماتی»، یک خط متعلق به نمودار و یک جعبه متن اسلاید عادی «پوشش اسلاید» است. مثال اولین نمودار در آن اسلاید را پیدا می‌کند و حاشیه‌نویسی را به «نتایج نهایی» تغییر می‌دهد وقتی گزارش آماده انتشار باشد. این مثال بررسی می‌کند که آیا مجموعه خالی است یا نه و فقط یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) با [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) غیر‌تهی و متن مورد انتظار را ویرایش می‌کند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <DOM/IGroupShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"chart-annotations.pptx");
auto slide = presentation->get_Slide(0);

System::SharedPtr<IChart> chart;
for (auto shape : slide->get_Shapes())
{
    auto candidate = System::DynamicCast<IChart>(shape);
    if (candidate != nullptr)
    {
        chart = candidate;
        break;
    }
}

if (chart == nullptr || chart->get_UserShapes()->get_Shapes()->get_Count() == 0)
{
    System::Console::WriteLine(u"No chart or chart-owned shapes found.");
    return;
}

auto updated = false;
for (auto shape : chart->get_UserShapes()->get_Shapes())
{
    auto annotation = System::DynamicCast<IAutoShape>(shape);
    if (annotation != nullptr &&
        annotation->get_TextFrame() != nullptr &&
        annotation->get_TextFrame()->get_Text() == u"Preliminary results")
    {
        annotation->get_TextFrame()->set_Text(u"Final results");
        updated = true;
        break;
    }
}

if (updated)
{
    presentation->Save(u"chart-annotations-updated.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"No matching text annotation found.");
}
```

خط و جعبه متن اسلاید بدون تغییر می‌مانند. تصاویر زیر ورودی و نتیجه ذخیره‌شده و باز شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط به اشکال سطح‑بالای متعلق به نمودار نگاه می‌کند. اگر یک حاشیه‌نویسی داخل یک [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/) باشد، مجموعه [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و همان بررسی‌های متنی را روی اشکال فرزند اعمال کنید. یک گروه خود یک مخزن است؛ آن را به‌عنوان جعبه متن در نظر نگیرید.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم پرکردن‌های نیمه‌شفاف برای ستون‌ها/نااحیه‌ها تنظیم کنم در حالی که حاشیه را اپاک من نگه دارم؟**

بله. شفافیت پرکردن و خط حاشیه به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایش‌های پرجزئی مفید است.

**چگونه می‌توانم با برچسب‌های داده که هم‌پوشانی دارند مقابله کنم؟**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برای نقاط انتخابی برچسب نمایش دهید، یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توانم پرکردن‌های گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکردن‌های صیقلی، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌صورت متعادل استفاده کنید و ترکیب‌هایی که کنتراست با شبکه و متن را کاهش می‌دهند، پرهیز کنید.