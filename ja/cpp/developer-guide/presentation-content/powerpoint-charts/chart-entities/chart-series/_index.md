---
title: C++ でプレゼンテーションのチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/cpp/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ カラー
- カテゴリ カラー
- シリーズ 名称
- データ ポイント
- シリーズ ギャップ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ を使用してプレゼンテーション内のチャート シリーズ、データ ポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートは、プロットされた値をワークブックのセルに保存したり、数値リテラルとして直接保存したりできます。 [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) は関連する値のセットを表し、 各 [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) はそのシリーズ内のポイントを表します。 [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグループ化値を提供します。 デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、およびポイント値はチャートワークブックの [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートの場合、デフォルトワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。 [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) に渡される Worksheet、行、列のインデックスは 0 ベースです。このレイアウトはデフォルトデータでチャートを作成する際に便利ですが、すべての既存チャートがこれを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定には3つの異なるスコープがあります:

- シリーズレベルの設定（例: [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/)）は、1つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データポイントの設定（例: [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/)）は、1つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) を介してグループにアクセスします。

明示的なポイントまたはシリーズの塗りが設定されていない場合、チャートスタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定が両方存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **数値リテラルを使用したシリーズ値の設定**

シリーズの値がアプリケーションデータや計算から来ており、Worksheet のセル参照が不要な場合は数値リテラルを使用します。各ポイントの [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/) で返された値を [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/) で設定する前に、[set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) を [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) と共に呼び出します。

このコレクション設定は、そのシリーズ内のすべてのポイント値のソースタイプを制御します。各ポイントの [IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) が選択されたタイプを報告します。コレクション設定を介して変更します。`Worksheet` を使用する場合は、[get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) で参照セルにアクセスします。`DoubleLiterals` を使用する場合は、[get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) または `set_AsLiteralDouble` で数値を直接読み書きします。

以下の例は、デフォルトのシリーズとカテゴリを持つ縦棒チャートを作成し、最初のシリーズの既存ポイントに 10、20… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

ポイント値のソースタイプは、チャートの内部または外部ワークブック構成を識別する [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/) とは別です。数値リテラルを使用するだけでは埋め込みワークブックは削除されません。この例では、ワークブックはカテゴリラベル、シリーズ名、他のシリーズに引き続き利用可能です。ワークブック管理については、[チャート ワークブック](/slides/ja/cpp/chart-workbook/) を参照してください。

散布図やバブルチャートの場合、[set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) と [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) を呼び出して、[get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) と [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) のソースを選択します。バブルチャートはさらに [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) を使用して [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/) のソースを設定します。各該当ソースを `DoubleLiterals` に設定し、その値の `set_AsLiteralDouble` メソッドで数値を割り当ててください。

## **チャートシリーズのオーバーラップの設定**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) は、2D チャートにおける棒や縦棒のオーバーラップ率（-100〜100％）を報告します。これは親シリーズグループの設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) を呼び出します。このオプションはグループ化された棒や縦棒を表示するチャートタイプに適用され、複合チャートの無関係なシリーズグループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します：

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶしカラーの変更**

[IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) を使用して、シリーズ全体のデフォルト塗りを設定できます。ポイントに明示的な塗りが既に設定されている場合、そのポイントの [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) 設定がシリーズの塗りを上書きします。

以下の例は、最初のシリーズにソリッドブルーの塗りを適用します：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![シリーズの色](series_color.png)

## **シリーズ名の変更**

シリーズ名はチャートデータワークブックに保存され、通常は凡例に表示されます。クラスター化された縦棒チャートのデフォルトワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズの名前が格納されています。以下の例の名前定数はその構造を明示的に示しています：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

既に [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/) で参照されているセルを更新することもできます。このアプローチは既存チャートで特定の行や列を前提としないため安全です：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![シリーズ名](series_name.png)

### **複数のセルから名前を持つシリーズの作成**

製品名と報告期間が別々のワークブックセルに格納されている場合、複合シリーズ名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を組み合わせて、ソースセルへのリンクを保持したまま単一のシリーズ名にできます。

[IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) を使用して名前範囲を取得し、[IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/) にそのコレクションを渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します：`true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲のすべてのセルを含めています。

以下の例は、1 つのシリーズと 2 つのデータポイントを持つプレゼンテーションを作成します。セル B1:C1 がシリーズ名のみを供給し、A2:A3 がカテゴリラベル、B2:B3 が数値を供給します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// これらの 2 つのセルがシリーズ名を提供します。
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// 個別のセルがカテゴリと数値データポイントを提供します。
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果のシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例はこの名前を 2 列の単一エントリとして表示します。以下の画像が結果を示します：

![凡例に合成シリーズ名 Product A 2026 が表示された北と南の値を持つ縦棒チャート](composite_series_name.png)

## **自動シリーズ塗りつぶしカラーの取得**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) は、シリーズインデックスとチャートスタイルから計算されたカラーを返します。これは、シリーズの塗りが明示的に定義されていない場合に使用されるカラーです。メソッドを呼び出すと計算されたカラーが取得され、新しい塗りは設定されません。

以下の例は、各デフォルトシリーズの自動カラーを出力します：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確なカラーはチャートスタイルとテーマに依存します。

## **チャートシリーズの反転塗りつぶしカラーの設定**

棒、縦棒、バブルシリーズの場合、[IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) を使用して負の値を別の塗りで表示できます。通常のシリーズ塗りをソリッドに設定し、反転を有効にして、負の値のカラーを [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) で割り当てます。負の数値はワークブック内では変更されず、表示カラーだけが変わります。

以下の例は、デフォルトのチャートデータを 1 系列に置き換えます。Worksheet の行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が配置されます：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![反転した単色塗りつぶしカラー](inverted_solid_fill_color.png)

[ IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) を使用して 1 ポイントだけ反転を有効にできます。以下の例では、シリーズ全体の反転を無効にし、選択したポイントだけ反転を有効にしています。そのポイントには負の値も割り当てて効果を確認します：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **特定のデータポイント値のクリア**

他のポイントを削除せずに 1 ポイントだけ空にするには、バックエンドのワークブックセルを `nullptr` に設定します。縦棒チャートの場合、プロットされた値は [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートはブランク設定に従ってその値を空として扱います。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

散布図は X と Y のセルが別々に使用され、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。その他のポイントを保持したい場合は、[IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) は呼び出さないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示制御**

値を含む非表示セルは空セルとは別扱いです。非表示の行や列からデータを含めるか除外するかについては、[非表示の行と列からデータを含める](/slides/ja/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルはデータ欠損を表し、`0` を含むセルは既知の数値を表します。`nullptr` を使用して [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) を呼び出すとセルを空にできます。数値ゼロは空セル設定に関係なくゼロのままです。

[IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブックセル自体にゼロや補間値を埋め込むことはありません。

以下の自己完結型例は、1 系列の折れ線チャートを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) は Worksheet 0、列 0 をカテゴリラベル、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Day 3 を実際に空にし、カテゴリとデータポイントを保持します。
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

各出力ファイルは保存前に設定されたモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを一度だけ保存してください。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はどの場合もワークブックで空です：

![同一データの折れ線チャート：Gap は Day 3 で線を切断し、Zero は線をゼロに落とし、Span は Day 2 から Day 4 を接続](display_blanks_as.png)

可視効果はチャートタイプに依存します。折れ線チャートは 3 つのモードすべてを比較しやすくします。棒や縦棒チャートは欠損したカテゴリを結ぶ線がなく、したがって `Span` は上図のような接続セグメントを生成できません。欠損した列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続線がありません。すべてのチャートタイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅の設定**

ギャップ幅は隣接する棒または縦棒クラスター間のスペースで、棒または縦棒幅のパーセンテージで表されます。オーバーラップと同様に、これは個々のシリーズではなく親シリーズグループに属します。グループに対して一度だけ [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) を呼び出します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します：

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![ギャップ幅](gap_width.png)

## **FAQ**

**どのチャートタイプがデータシリーズをサポートしていますか?**

[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャートタイプはデータを使用しますが、シリーズの値構造や設定はすべて同じではありません。たとえば、カテゴリチャートはカテゴリと値を使用し、散布図は X と Y の値を、バブルチャートはバブルサイズを追加で使用します。シリーズタイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャートシリーズグループとは何ですか?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のあるシリーズを含みます。複合チャートは複数のグループを持つことができるため、あるシリーズを介して変更したグループ設定が必ずしもチャート内のすべてのシリーズに影響するわけではありません。

**新しく作成したチャートにはデフォルトデータが含まれますか?**

はい。既定では、[IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタムデータセットを追加する前にシリーズとカテゴリコレクションの両方をクリアできます。オーバーロードを使用してデフォルトデータなしでチャートを作成することも可能です。

**チャートオブジェクトはワークブックセルとどのように接続されていますか?**

シリーズ名、カテゴリラベル、データポイント値は [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタムデータを構築する場合は、カテゴリ行とシリーズ値行を整合させ、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 ポイントだけをクリアするにはどうすればよいですか?**

対象の値セルを `nullptr` に設定して、ポイントのカテゴリ位置は維持したまま空ポイントにします。[IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) は、シリーズ全体のポイントをすべて削除するため、他のポイントを残したいときは使用しないでください。カテゴリも削除する場合は、すべてのシリーズがカテゴリコレクションと整合するように更新してください。

**空のポイントはどのように表示されますか?**

表示結果はチャートタイプと [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションの欠損データの意味に合わせて設定を選択してください。完全な例とビジュアル比較は、[空セルの表示制御](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか?**

棒、縦棒、バブルシリーズでサポートされている場合、[IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) を呼び出し、[IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) でカラーを設定します。個々のポイントに対しては [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) で動作を上書きできます。これらのメソッドは書式設定に影響し、格納された数値には影響しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか?**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。その他のポイントは明示的なシリーズ書式設定（またはシリーズ書式が未定義の場合は自動チャートスタイルとテーマ）を使用し続けます。オーバーラップやギャップ幅などのグループ設定はレイアウトを制御し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか?**

Aspose.Slides には固定のシリーズ数上限は設けられていません。実際には、プレゼンテーションファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合は何を変更すればよいですか?**

適切な親シリーズグループに対して [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) を呼び出します。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近づきます。