---
title: 在 C++ 中格式化簡報圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/cpp/chart-formatting/
keywords:
- 格式化圖表
- 圖表格式化
- 圖表實體
- 圖表屬性
- 圖表設定
- 圖表選項
- 字型屬性
- 圓角邊框
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解在 Aspose.Slides for C++ 中的圖表格式化，並透過自訂座標軸、字型、數字格式與圓角圖表邊框，提升您的 PowerPoint 簡報。"
---
## **概觀**

本文說明如何在 PowerPoint 簡報中使用 Aspose.Slides 來格式化圖表。它展示了如何自訂關鍵圖表元素，如座標軸、格線、標題、圖例、繪圖區域以及牆壁填充，以提升圖表資料的外觀與可讀性。

它還示範了如何設定圖表文字的字型屬性、將預設數值格式套用到圖表資料，以及啟用圖表區域的圓角。這些範例共同展示了如何同時控制簡報中圖表的視覺樣式與資料呈現。

若要在上升與下降區間設定不同的填充與輪廓，請參考 [股票圖表示例](/slides/zh-hant/cpp/create-chart/#create-stock-charts)。

## **格式化圖表實體**

使用 [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) 來格式化圖表標題、座標軸、格線、圖例以及繪圖區域。本範例建立一個具有標記和預設資料的折線圖，然後對其值軸與類別軸套用不同的文字與線條樣式。字型大小和線寬以點為單位指定；類別標籤旋轉 45 度。

值軸使用 [get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/)，其設定與來源儲存格無關。其刻度範圍從 -2 到 15，主間隔為 2，次間隔為 0.5。範例亦結合百分比格式與將 [get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/) 設為千位的設定，請依據資料的意義與量級調整這些設定。圖例因為 [get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/) 被停用而保持在繪圖區域外。背牆與底板的填充透過 [get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) 與 [get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) 設定，但這些表面僅在 3D 圖表中可見。

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

## **設定圖表的字型屬性**

透過 [Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/) 設定圖表文字的預設字型大小。範例建立一個叢集柱狀圖，使用 20 點字型，並透過 [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) 為第一個系列啟用值標籤。具備自行明確字型設定的文字元素可以覆寫圖表的預設值。

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

## **重新使用文字框格式於圖表圖例**

為了讓圖例與投影片標題相匹配，請透過 [get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) 設定第一段落的預設部分格式的字型。使用 [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iformattedtextcontainer/get_textformat/) 取得圖例的文字格式，然後以標題的文字框呼叫 [CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyfrom/)。這會複製文字框設定、第一段落的格式，以及該段落的預設字型屬性。直接套用於個別部分或之後段落的格式會保留在來源本身。

範例使用粗體、26 點 Calibri 字型、海軍藍色的標題作為範本。為圖例設定樣式後，使用 [CopyTo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyto/) 將相同的格式套用到另一個說明文字。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/StyleType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/LegendPositionType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto heading = shapes->AddAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
auto sourceTextFrame = heading->AddTextFrame(u"Quarterly sales");
auto font = sourceTextFrame->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
font->set_LatinFont(MakeObject<FontData>(u"Calibri"));
font->set_FontHeight(26);
font->set_FontBold(NullableBool::True);
font->get_FillFormat()->set_FillType(FillType::Solid);
font->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::FromArgb(32, 64, 96));

auto chart = shapes->AddChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
chart->set_Style(StyleType::Style3);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Retail"));
workbook->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Online"));
workbook->GetCell(0, 0, 3, ObjectExt::Box<String>(u"Wholesale"));
for (auto quarter = 1; quarter <= 4; ++quarter)
{
    auto label = String::Format(u"Q{0}", quarter);
    workbook->GetCell(0, quarter, 0, ObjectExt::Box<String>(label));
}

chart->set_HasLegend(true);
auto legend = chart->get_Legend();
legend->set_Position(LegendPositionType::Bottom);
auto legendTextFormat = legend->get_TextFormat();
legendTextFormat->CopyFrom(sourceTextFrame);

auto caption = shapes->AddAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
auto captionTextFrame = caption->AddTextFrame(u"Sales in millions of dollars");
legendTextFormat->CopyTo(captionTextFrame);

presentation->Save(u"legend-formatting.pptx", SaveFormat::Pptx);
```

在已儲存的簡報中，圖例與說明文字在大小、粗細與顏色上與標題相匹配。圖例仍會顯示系列名稱，說明文字保留其原始文字。若說明文字中的某個部分已設定明確的字型大小，該大小會優先於複製的段落預設值。

| 複製前 | 複製後 |
| --- | --- |
| ![季度銷售圖表，圖例標籤為普通黑色，說明文字為黑色](legend-formatting-before.png) | ![相同圖表，圖例標籤較大且為粗體海軍藍，說明文字相匹配](legend-formatting.png) |

## **設定數字格式**

使用 [IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) 為圖表工作表儲存格套用內建的數字格式。此範例建立一個預設使用儲存格資料的叢集柱狀圖，並將格式索引 10 (`0.00%`) 套用到每個系列的值儲存格。這會改變工作表中值的顯示方式而不改變實際數字；例如，0.25 會顯示為 25.00%。座標軸與資料標籤的格式可分別設定。

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

下表列出內建的數字格式索引，並以英文（美國）地區的 Excel 格式作為範例。實際的格式字串與顯示方式可能會因應用程式與地區不同而有所差異，特別是貨幣與日期。某些 Excel 格式亦與 OOXML 標準的預設不同，詳情請參閱 [Microsoft 的數字格式實作說明](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)。

| 索引 | 格式 |
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

## **設定圖表區域的圓角邊框**

啟用 [IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/) 可將圖表區域的角落設為圓角。範例建立一個叢集柱狀圖，並使用 [get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) 為其輪廓設定實心灰色且為單線樣式，之後儲存簡報。

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

## **編輯現有圖表註釋**

圖表可以包含自訂形狀，例如說明報告狀態的文字註釋。可透過 [IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/) 取得這些形狀，該方法亦在 Chart API 參考文件的 [Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/) 中列出。其 [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) 集合包含圖表擁有的形狀。

放置於圖表上方的普通文字方塊屬於投影片，即使看起來像是圖表的一部份。遍歷 [Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) 會找到圖表以及普通投影片形狀，但不會列舉圖表內的個別形狀。圖表標題與資料標籤是獨立的圖表元素，並非此集合中的自訂註釋。

下載 [chart-annotations.pptx](chart-annotations.pptx) 並放置於應用程式的工作目錄。其第一張投影片包含一個圖表，圖表上有未群組的註釋「Preliminary results」、圖表擁有的線條，以及普通投影片文字方塊「Slide overlay」。範例在該投影片上找出第一個圖表，並在報告準備發佈時將註釋改為「Final results」。它會檢查集合是否為空，僅編輯具有非空 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) 且文字符合預期的 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。

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

線條與投影片文字方塊保持不變。以下圖示顯示輸入與已儲存、重新開啟的結果：

| 編輯前 | 編輯後 |
| --- | --- |
| ![圖表註釋顯示「初步結果」](chart-annotations-before.png) | ![圖表註釋顯示「最終結果」](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
範例僅檢查最上層的圖表擁有的形狀。如果註釋位於 [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/) 之中，亦需檢查該群組的 [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) 集合。對於巢狀群組，請以遞迴方式重複此動作，並對其子形狀套用相同的文字檢查。群組本身是一個容器；請勿將其視為文字方塊。
{{% /alert %}}

## **常見問題**

**我可以為柱狀/區域設定半透明填充，同時保持邊框不透明嗎？**

可以。填充透明度與輪廓是分別設定的。這在提升密集視覺化圖表中格線與資料的可讀性時非常有用。

**當資料標籤重疊時，我該如何處理？**

縮小字型、停用非必要的標籤元件（例如類別）、調整標籤位置、必要時僅顯示選取點的標籤，或改為使用「值 + 圖例」格式。

**我可以對系列套用漸層或圖案填充嗎？**

可以。系列支援實心、漸層與圖案填充。實務上，應適度使用漸層，並避免與格線和文字的對比度降低的組合。