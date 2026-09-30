---
title: 使用 C++ 在簡報中自訂圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/cpp/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自訂圖表圖例，透過量身打造的圖例格式化，最佳化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides for C++ 提供在 PowerPoint 簡報中自訂圖例的選項。本文說明如何定位與調整圖例大小、設定整個圖例的字型大小、格式化單一圖例項目，以及隱藏或復原選取的項目。

常見問題包含相關行為，例如為圖例保留空間、顯示多行標籤，以及從簡報主題繼承格式設定。

## **圖例定位**

使用圖例的 [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/)、[set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/)、[set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) 與 [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) 方法，以圖表尺寸的比例指定其位置與大小。

此範例建立簡報，並在第一張投影片加入預設資料的叢集柱狀圖。將欲設定的圖例偏移與尺寸除以圖表的寬度與高度，即可轉換為相對值：圖例相對於圖表左上角向下、向右各偏移 50 點，大小設定為 100 × 100 點。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// 表示圖例相對於圖表的位置與大小。
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **設定圖例的字型大小**

使用圖例的 [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) 取得文字格式，再使用 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 以點數設定字型大小。

此範例建立預設資料的圖表，並將圖例文字設定為 20 點。範例同時停用垂直軸的自動邊界，並將其範圍設為 -5 到 10。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **設定單一圖例項目的字型大小**

使用圖例的 [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) 方法回傳的集合，取得特定項目的格式。項目索引採零基制，所以索引 `1` 代表第二個項目。

此範例建立包含至少兩個系列的叢集柱狀圖，並將第二個圖例項目格式化為粗體、斜體、20 點藍色文字。

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **隱藏單一圖例項目**

若要在圖例中排除輔助系列同時保留其資料顯示，請透過 [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) 取得圖例項目，然後以 `true` 呼叫 [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/)。此方式僅隱藏選取的圖例項目，並不會移除系列或其資料點。相較之下，將 [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) 設為 `false` 則會隱藏整個圖例。

下面的範例建立包含多個系列的叢集柱狀圖（使用預設資料），將第二個系列的圖例項目（索引 `1`）隱藏，並儲存簡報。之後再以 `false` 呼叫 `set_Hide` 復原該項目，並儲存第二份副本。兩個檔案的柱狀仍保持可見。

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// 復原相同的項目而不更改圖表資料。
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

下方比較顯示相同的圖表在全部圖例項目可見與第二個項目被隱藏的情況。第二系列的柱狀未受影響。

![比較圖例全部可見與隱藏第二項目的圖表；所有柱狀仍保持可見。](hide-legend-entry.png)

在直條圖、橫條圖與折線圖中，圖例項目用來辨識系列。對圓餅圖而言，圖例項目辨識個別資料點（切片），因此請改用 [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) 取得所選切片的圖例項目。此 API 針對 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 與 `BarOfPie` 類型有說明，不適用於甜甜圈圖表。

## **常見問題**

**我可以讓圖表為圖例保留空間，而不是覆蓋它嗎？**

可以。將 [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) 設為 `false`，即可為圖例保留空間，而不是讓它覆蓋繪圖區。

**我可以建立多行圖例標籤嗎？**

可以。當可用寬度不足時，長標籤會自動換行。亦可在系列名稱中加入換行字元，以強制斷行。

**我該如何讓圖例遵循簡報主題的配色方案？**

請保持圖例的顏色、填充與字型未設定，讓它繼承主題格式。若自行設定格式，將會覆寫相應的主題設定。