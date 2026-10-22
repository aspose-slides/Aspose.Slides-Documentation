---
title: C++ を使用したプレゼンテーション内のチャート ワークブックの管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/cpp/chart-workbook/
keywords:
- チャート ワークブック
- チャート データ
- ワークブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部ワークブック
- 外部データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を発見: PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でのチャート ワークブックの扱い方を説明します。ワークブック ストリームを介してチャート データの読み書き方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、チャート 値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャートのデータ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、およびワークブックが利用可能な場合のチャート データ編集方法を示します。

欠損データを表すワークブック セルについては、[空のセルの表示制御](/slides/ja/cpp/chart-series/) を参照し、空のセルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示行および列からデータを含める**

[IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) を使用して、チャートが非表示のワークシート行や列のデータをプロットするかどうかを制御します。`true` に設定すると表示セルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示または表示にするものではありません。

[サンプルプレゼンテーション](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` にはソース範囲 `A1:C4` が設定されています。行 3 と列 C は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) でソースセルにアクセスし、[IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) で非表示ステータスを確認します。このプロパティは読み取り専用です。この例では、B2 は表示、B3 は非表示行に属し、C2 は非表示列に属するため、`False`、`True`、`True` がそれぞれ出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みワークブックは [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) で保持し、[WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // 埋め込みワークブックからチャート データを更新します。
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 非表示カテゴリを含む完全なソース範囲を復元します。
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

例では、表示セルのみ（10 と 20）の小売値だけを含むバージョンと、全部の 6 つの値を含むバージョンの 2 つのプレゼンテーションを保存します。下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売値.](hidden_cells_False.png) |

値を含む非表示セルは空のセルとは異なります。[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) は欠損値の表示方法を制御しますが、非表示のソース データを含めたり除外したりはしません。例については [空のセルの表示制御](/slides/ja/cpp/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルのソース範囲を確認します。[IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) メソッドは、`Sheet1!$A$1:$D$5` のようにワークシート限定の数式として現在のデータ範囲を返します。ここで `Sheet1` はワークシート名、`!` がセル範囲との区切り、`$A$1:$D$5` が絶対参照のセル範囲を示します。

このメソッドはチャートやそのワークブックを変更せずに現在の範囲を読み取ります。チャートがワークブックをデータ ソースとして使用していない場合は、[System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) がスローされます。詳細は [ChartData API リファレンス](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライドのシェイプを直接走査してチャートを検出します。各チャートの名前とソース範囲を出力し、ワークブックを使用していないチャートはメッセージを出力して次のチャートへ進みます。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for C++ は、[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたデータを含む）を読み書きできます。**注**：チャート データは同様の構造で編成されている必要があります。

この例は最初のスライドの最初のシェイプとしてチャートを含むプレゼンテーションを使用します。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ内に残り、プレゼンテーションは保存されません。

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **ワークブック変更後のチャート レイアウトの検証**

埋め込みワークブックを変更したワークブックに置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不整合により [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプとしてチャートを使用します。コメントはワークブック編集が行われる場所を示し、実行可能な例は元のワークブックを書き戻してメモリ内でレイアウトを検証します。

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // ここでワークブックストリームを変更します。たとえば Aspose.Cells を使用します。

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が削除されます。更新されたワークブックに合わせて必要な系列とカテゴリのマッピングを再構築してからチャートを使用してください。

## **ワークブック セルのカスタム数値形式を設定する**

[IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) を使用して、チャートの埋め込みワークブック内の数値の表示形式を制御できます。たとえば、レポートで変換率を小数点以下 4 桁のパーセンテージで、係数を小数点以下 5 桁で表示したい場合があります。両方の値は数値のままにしておくことで、計算やチャート プロットに利用できます。

数値形式は表示を変更するだけで、格納値は変更されません。形式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、格納数値は `12.5` に置き換わりません。同様に `0.00000` は `0.1234567` を `0.12346` と表示しますが、格納値は丸められません。カスタム形式が空文字列 (`""`) の場合は、[set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) で設定された形式が使用されます。

以下の例は列グラフを作成し、[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) でセルにアクセスします。ワークシート 0 の B2 に変換率、C2 に係数が格納されており、両方のセルがチャート値として使用されます。例ではソース形式にリンクした値ラベルも有効にしています。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

ワークブック セル形式は、チャート軸やデータ ラベルに直接設定された形式とは別です。この例では、[set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) を `true` に設定し、[set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) を `true` に設定しているため、各ラベルはソースセルの数値形式に従います。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) で `0.00` の形式が割り当てられ、[set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) が `false` になっています。

データ ラベルを個別に書式設定するには、ソースリンク フラグを `false` に設定し、[set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) で形式を割り当てます。これによりワークブック セルの形式は変更されません。たとえば、独立したラベル形式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` を表示します。詳細は [Chart Data Labels](/slides/ja/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

![ソースリンクラベルが 12.5000% と 0.12346 を表示し、独立書式設定された数値軸を持つ列グラフ.](custom-cell-formats.png)

## **ワークブック セルをチャート データ ラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにデフォルト データのバブル グラフを追加し、ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして更新されたプレゼンテーションを保存します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **ワークシートの管理**

[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) メソッドは、チャート ワークブック内のワークシートへのアクセスを提供します。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **データ ソース タイプを指定する**

系列ポイントの値は数値リテラルとして直接格納することもできます。リテラルを使用して保存および読み取る完全な例については、[Set Series Values Using Numeric Literals](/slides/ja/cpp/chart-series/#set-series-values-using-numeric-literals) を参照してください。ポイント値のソース タイプはチャートの内部または外部ワークブック構成とは別であり、数値リテラルを使用しただけで埋め込みワークブックが削除されるわけではありません。

この例はデフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込まれる可能性のある Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) の [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) メソッドと [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例は既存のプレゼンテーションの最初のスライドのシェイプを調べ、非チャート シェイプをスキップし、埋め込み .xlsb ワークブックを持つ各チャートに診断メッセージを出力します。

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // ここでサポートされているチャート ワークブック データを読み取りまたは変更します。
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャート のデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) と [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、その外部ワークブックにチャートをリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。外部ワークブックをデータ ソースとして割り当てる前に出力ストリームを閉じ、リンクされたプレゼンテーションを保存します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **外部ワークブックの設定**

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（ファイルが移動された場合）にも更新に使用できます。

リモート ロケーションやリソースに格納されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合、自動的に完全パスに変換されます。

この例は、ワークシート名 `Sheet1` に B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値を持つ外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) で A1:B4 を 1 系列と 3 カテゴリにマッピングします。リンクされたチャートを含むプレゼンテーションを保存します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) の `updateChartData` パラメータは、ワークブックをロードするかどうかを制御します。

* `updateChartData` が `false` の場合、ワークブック パスだけが更新されます。チャート データはターゲット ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。
* `updateChartData` が `true` の場合、チャート データはターゲット ワークブックから更新されます。

次の例はプレースホルダー URL を割り当て、`updateChartData` を `false` に設定しています。円グラフのデフォルト データを保持したまま、利用できないワークブックをロードせずにプレゼンテーションを保存します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **チャートの外部データソース ワークブック パスの取得**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は外部ワークブックにリンクされたプレゼンテーションの最初のスライドの最初のシェイプを調べ、外部ワークブックにリンクされたチャートであれば、[get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックと同様の方法で編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この例は最初のスライドの最初のシェイプとして存在し、利用可能な外部ワークブックにリンクされたチャートを使用します。最初の系列の最初のデータ ポイントのセル バック値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値を編集するとリンクされた外部 XLSX ファイルが更新されるため、元のワークブックを保持したい場合はコピーを使用してください。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
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

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **チャート キャッシュからワークブックを復元する**

チャートが欠落または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) を作成し、[set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) で構成し、[ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) を `true` に設定してからプレゼンテーションを開きます。

次の C++ 例は、最初のスライドの最初のシェイプとして存在し、利用不可の外部ワークブックを参照するチャートのワークブック データを復元します。復元されたデータは [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) と [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) を介してアクセスされます。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // ここで復元されたワークブック データを読み取りまたは変更します。
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには外部ワークブックが最後にプレゼンテーションが更新された後に行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックのどちらにリンクされているか判断できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) があり、外部ワークブックである場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされており、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) を保存します。セル バックされたチャート データを編集すると、リンクされたローカル XLSX ファイルも更新されます。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対処法は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/cpp/) などで復号化したコピーを作成してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指していれば、そのファイルを更新することで次回データがロードされる際にすべてのチャートに反映されます。