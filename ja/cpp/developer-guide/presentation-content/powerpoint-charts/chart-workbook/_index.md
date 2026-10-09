---
title: C++ を使用したプレゼンテーションでのチャート ワークブックの管理
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
description: "Aspose.Slides for C++ を発見し、PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理して、プレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行い、ワークブック セルをチャート データ ラベルとして使用し、ワークシート コレクションにアクセスし、チャート値のデータ ソースの種類を指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法を示します。

欠損データを表すワークブック セルについては、[空のセルの表示を制御](/slides/ja/cpp/chart-series/) を参照し、空のセルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示行と列のデータを含める**

[IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) を使用して、非表示のワークシート 行・列からデータをプロットするかどうかを制御できます。`true` に設定すると表示されているセルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシート の行や列を非表示または表示にするものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` のソース範囲は `A1:C4` です。行 3 と列 C は非表示ですが、セルには値が格納されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) でソース セルにアクセスし、[IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) で非表示状態を確認します。このプロパティは読み取り専用です。この例では、B2 は表示、B3 は非表示行に属し、C2 は非表示列に属します。出力はそれぞれ `False`、`True`、`True` となります。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みワークブックは [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) で取得し、[WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データやカテゴリ ラベルは更新されません。

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

この例は、表示されている小売値 (10 と 20) のみを含むバージョンと、すべての 6 つの値を含むバージョンの 2 つのプレゼンテーションを保存します。下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示されているセルのみ: 1月と3月の小売値10と20](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売と卸売の値](hidden_cells_False.png) |

値を保持した非表示セルは空のセルとは異なります。[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) は欠損値の表示方法を制御しますが、非表示ソース データの含める・除外は行いません。[空のセルの表示を制御](/slides/ja/cpp/chart-series/#control-the-display-of-empty-cells) に例があります。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルのソース範囲を確認します。[IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) は現在のデータ範囲をワークシート限定の数式で返します。例: `Sheet1!$A$1:$D$5`。ここで `Sheet1` はワークシート名、`!` がセル範囲と区切り、`$A$1:$D$5` が絶対参照のセル範囲です。

このメソッドはチャートやワークブックを変更せずに現在の範囲を取得します。チャートがワークブックをデータ ソースとして使用していない場合は、[System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) がスローされます。詳細は [ChartData API リファレンス](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライドのシェイプを直接走査してチャートを検出します。チャート名とソース範囲を出力し、ワークブックを使用していないチャートはメッセージを表示して次へ進みます。

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

Aspose.Slides for C++ は、[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック (Aspose.Cells で編集されたデータを含む) の読み取りと書き込みが可能です。**注**: チャート データは同じ構造で編成するか、ソースに類似した構造である必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートを含むプレゼンテーションを使用します。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

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

埋め込みワークブックを編集済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不整合により、[IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプとしてチャートを使用します。コメントはワークブック 編集が行われる位置を示しており、実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

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

    // ここでワークブック ストリームを変更します。例として、Aspose.Cells を使用します。

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

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに対して必要な系列およびカテゴリのマッピングを再構築してからチャートを使用してください。

## **ワークブック セルをチャート データ ラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにバブル チャートを追加し、デフォルト データを使用します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セル ラベルを有効にして、更新されたプレゼンテーションを保存します。

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

## **データ ソースの種類を指定する**

この例はデフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

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

## **埋め込みワークブックの非対応形式を検出する**

Aspose.Slides は、一部のチャートに埋め込める Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) の [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) メソッドと [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、非対応形式を検出し、そのチャートをスキップできます。この例は既存のプレゼンテーションの最初のスライド上のシェイプを走査し、非チャート シェイプを除外し、.xlsb 埋め込みワークブックを持つ各チャートに対して診断メッセージを出力します。

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

    // ここでサポートされているチャートワークブック データを読み取りまたは変更します。
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャート のデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) と [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。出力ストリームを閉じてから外部ワークブックをチャート データ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックのパスが変更された場合にも使用できます (ワークブックが移動された場合など)。

リモート ロケーションやリソースに保存されたワークブックのデータは編集できませんが、外部データ ソースとして使用できます。相対パスが指定された場合は、自動的にフルパスに変換されます。

この例は、ワークシート `Sheet1` に B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が格納された外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) で A1:B4 を 1 系列と 3 カテゴリにマップします。リンクされたチャートを含むプレゼンテーションを保存します。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) の `updateChartData` パラメータは、ワークブックを読み込むかどうかを制御します。

* `updateChartData` が `false` の場合、ワークブック パスのみが更新されます。チャート データはターゲット ワークブックから読み込まれず、ワークブックが利用できなくても構いません。
* `updateChartData` が `true` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例は、`updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データは保持され、利用できないワークブックをロードせずにプレゼンテーションが保存されます。

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

### **チャートの外部データ ソース ワークブック パスを取得する**

チャートにリンクされているワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は、外部ワークブックにリンクされたプレゼンテーションの最初のスライドの最初のシェイプを検査します。外部ワークブックにリンクされたチャートであれば、[get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプとして存在し、アクセス可能な外部ワークブックにリンクされたチャートを使用します。最初の系列の最初のデータ ポイントのセルバック 値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

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

チャートが存在しない、または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) を作成し、[set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) で構成し、[ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) を `true` に設定してからプレゼンテーションを開きます。

以下の C++ 例は、利用できない外部ワークブックを参照する最初のスライドの最初のシェイプとしてのチャートのワークブック データを復元します。復元されたデータは [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) および [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) で取得します。

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

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) をスローします。キャッシュされたチャート データの使用が許容できる場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートは [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) を持ちます。外部ワークブックであれば、フルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？どうやって保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい。そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) を保存します。セルバック のチャート データを編集すると、リンクされたローカル XLSX ファイルも更新されます。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすべきですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/cpp/) などで復号化したコピーを用意してからリンクしてください。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指す場合、そのファイルを更新すると次回データがロードされるときに各チャートに反映されます。