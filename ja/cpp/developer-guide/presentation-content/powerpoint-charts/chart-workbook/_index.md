---
title: C++ を使用したプレゼンテーションのチャートワークブック管理
linktitle: チャートワークブック
type: docs
weight: 70
url: /ja/cpp/chart-workbook/
keywords:
- チャートワークブック
- チャートデータ
- ワークブックセル
- データラベル
- ワークシート
- データソース
- 外部ワークブック
- 外部データ
- チャートキャッシュ
- ワークブック復元
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を発見: PowerPoint と OpenDocument 形式でチャートワークブックを簡単に管理し、プレゼンテーション データを合理化します。"
---
## **概要**

この記事では、Aspose.Slides でチャートワークブックを操作する方法を説明します。ワークブックストリームを介してチャートデータを読み書きする方法、ワークブックセルをチャートデータラベルとして使用する方法、ワークシートコレクションにアクセスする方法、およびチャート値のデータソースタイプを指定する方法を示します。

また、外部ワークブックをチャートのデータソースとして使用する方法も取り上げます。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、ワークブックが利用可能な場合にチャートデータを編集する方法を示します。

ワークブックセルが欠損データを表す場合は、[空セルの表示制御](/slides/ja/cpp/chart-series/) を参照し、空セルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **ワークブックからチャートデータを読み書きする**

Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供し、チャートデータワークブック（Aspose.Cells で編集されたチャートデータを含む）を読み書きできます。**注**：チャートデータは元の構造と同じ形式で編成されている必要があります。

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **ワークブックの変更後にチャートレイアウトを検証する**

埋め込みワークブックを変更済みのものに差し替えると、チャートは元の系列とカテゴリコレクションを保持したままになります。この不一致により、[IChart::ValidateChartLayout](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。

```cpp
// ワークブックストリームを変更した後（例: Aspose.Cells を使用）
auto updatedWorkbook = chartData->ReadWorkbookStream();

// 既存のデータ参照をクリアします。
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

コレクションをクリアすることで、チャートデータ構造が新しいワークブックと一致し、`ValidateChartLayout` がエラーなしで完了できるようになります。

## **ワークブックセルをチャートデータラベルとして設定する**

1. **[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/)** クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. データを含むバブルチャートを追加します。  
4. チャート系列にアクセスします。  
5. ワークブックセルをデータラベルとして設定します。  
6. プレゼンテーションを保存します。

この C++ コードは、ワークブックセルをチャートデータラベルとして設定する方法を示しています：

``` cpp
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **ワークシートの管理**

この C++ コードは、[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) メソッドを使用してワークシートコレクションにアクセスする操作を示しています：

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **データソースタイプの指定**

この C++ コードは、データソースのタイプを指定する方法を示しています：

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、いくつかのチャートに埋め込むことができる Excel バイナリワークブック（.xlsb）形式をサポートしていません。`get_EmbeddedWorkbookType` メソッドを **[IChartData](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdata/)** と組み合わせ、[WorkbookType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/workbooktype/) 列挙体を使用して、サポートされていない形式を検出し、該当チャートをスキップできます。

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // 埋め込みワークブックは .xlsb 形式であり、サポートされていません。
        continue;
    }

    // ここでチャートワークブック データを読み取りまたは変更します。
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータソースとして使用することをサポートします。

### **外部ワークブックの作成**

**`ReadWorkbookStream`** と **`SetExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部化することができます。

この C++ コードは、外部ワークブックの作成手順を示しています：

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **外部ワークブックの設定**

**`IChartData::SetExternalWorkbook`** メソッドを使用して、外部ワークブックをチャートのデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合にも更新に利用できます。

リモート場所やリソースに保存されているワークブックのデータを直接編集することはできませんが、外部データソースとして使用することは可能です。相対パスが指定された場合、フルパスに自動変換されます。

この C++ コードは、外部ワークブックを設定する方法を示しています：

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

`SetExternalWorkbook` メソッドの **`updateChartData`** パラメータは、Excel ワークブックを読み込むかどうかを指定します。

* `updateChartData` が `false` に設定されている場合、ワークブックのパスのみが更新され、チャートデータはターゲットワークブックから読み込まれません。ターゲットワークブックが存在しない、または利用できない状況でこの設定を使用します。  
* `updateChartData` が `true` に設定されている場合、チャートデータがターゲットワークブックから更新されます。

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **チャートの外部データソースワークブックパスの取得**

1. **[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/)** クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. チャートシェイプのオブジェクトを作成します。  
4. チャートのデータソースを表す **`ChartDataSourceType`** オブジェクトを作成します。  
5. 外部ワークブックデータソースタイプと同じであることを条件として指定します。

この C++ コードは、操作を示しています：

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// プレゼンテーションを保存します
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **チャートデータの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックを読み込めない場合は例外がスローされます。

この C++ コードは、上記プロセスの実装例です：

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **チャートキャッシュからワークブックを復元する**

チャートが存在しないまたは利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャートワークブックを再構築できます。**LoadOptions** を作成し、**set_SpreadsheetOptions** で設定し、プレゼンテーションを開く前に **ISpreadsheetOptions::set_RecoverWorkbookFromChartCache** を `true` に設定してください。

以下の C++ 例は、利用できない外部ワークブックを参照しているプレゼンテーションを開き、[IChart::get_ChartData](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/get_chartdata/) と [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) を通じて復元されたデータにアクセスする方法を示します：

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は `System::InvalidOperationException` をスローします。キャッシュされたチャートデータをフォールバックとして使用できる場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) があり、外部ワークブックがソースである場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、PPTX ファイル内には絶対パスが保存されることに注意してください。

**ネットワークリソース／共有上にあるワークブックを使用できますか？**

はい、これらのワークブックは外部データソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされておらず、ソースとしてのみ利用できます。

**プレゼンテーション保存時に外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは外部ファイルへの **link** を保存し、データ読み取り時に使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワード保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](/cells/cpp/) などで復号化したコピーを用意してそのコピーにリンクしてください。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは個別にリンクを保持します。すべてが同一ファイルを指す場合、そのファイルを更新すると次回データが読み込まれる際にすべてのチャートに反映されます。