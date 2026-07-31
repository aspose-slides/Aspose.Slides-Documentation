---
title: C++ を使用してプレゼンテーションのチャートワークブックを管理する
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
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を発見：PowerPoint および OpenDocument 形式でチャートワークブックを簡単に管理し、プレゼンテーションデータを効率化します。"
---
## **概要**

本記事では Aspose.Slides でチャートワークブックを操作する方法を説明します。ワークブックストリームを介してチャートデータを読み書きする方法、ワークブックセルをチャートデータラベルとして使用する方法、ワークシートコレクションにアクセスする方法、およびチャート値のデータソースタイプを指定する方法を示します。

また、外部ワークブックをチャートデータソースとして使用する方法についても取り上げています。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、そしてワークブックが利用可能な場合にチャートデータを編集する方法を示しています。

## **ワークブックからチャートデータを読み書きする**

Aspose.Slides は、チャートデータワークブック（Aspose.Cells で編集されたチャートデータを含む）を読み書きできる [ReadWorkbookStream](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) と [WriteWorkbookStream](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) メソッドを提供します。**注意**：チャートデータは同様の方法で整理されているか、ソースと同様の構造を持っている必要があります。

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

この C++ コードは、チャートデータワークブックを設定する操作を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **WorkBook セルをチャートデータラベルとして設定する**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. いくつかのデータを使用してバブルチャートを追加します。
1. チャートシリーズにアクセスします。
1. ワークブックセルをデータラベルとして設定します。
1. プレゼンテーションを保存します。

この C++ コードは、ワークブックセルをチャートデータラベルとして設定する方法を示しています：

``` cpp
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

## **ワークシートを管理する**

この C++ コードは、[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) メソッドを使用してワークシートコレクションにアクセスする操作を示しています：

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **データソースタイプを指定する**

この C++ コードは、データソースのタイプを指定する方法を示しています：

```c++
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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリワークブック（.xlsb）形式をサポートしていません。サポートされていない形式を検出して該当チャートをスキップするには、[IChartData](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdata/) の `get_EmbeddedWorkbookType` メソッドと [WorkbookType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて使用できます。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // 埋め込みワークブックは .xlsb 形式で、サポートされていません。
        continue;
    }

    // ここでチャートのワークブックデータを読み取ったり変更したりします。
}
```

## **外部ワークブック**

{{% alert color="primary" %}} 
[Aspose.Slides](https://releases.aspose.com/slides/ja/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 では、チャートのデータソースとして外部ワークブックをサポートするように実装しました。
{{% /alert %}} 

### **外部ワークブックを作成する**

**`ReadWorkbookStream`** と **`SetExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部に変換することができます。

この C++ コードは、外部ワークブック作成プロセスを示しています：

```c++
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

### **外部ワークブックを設定する**

**`IChartData::SetExternalWorkbook`** メソッドを使用すると、外部ワークブックをチャートのデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）にパスを更新するためにも使用できます。

リモートロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、依然として外部データソースとして使用できます。外部ワークブックの相対パスが指定された場合、自動的にフルパスに変換されます。

この C++ コードは、外部ワークブックを設定する方法を示しています：

```c++
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

`SetExternalWorkbook` メソッドの `updateChartData` パラメーターは、Excel ワークブックをロードするかどうかを指定するために使用されます。

* `updateChartData` の値が `false` に設定されている場合、ワークブックのパスだけが更新されます。チャートデータは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用することがあります。
* `updateChartData` の値が `true` に設定されている場合、対象ワークブックからチャートデータが更新されます。

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **チャートの外部データソースワークブック パスを取得する**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. チャートシェイプのオブジェクトを作成します。
1. `ChartDataSourceType` ソースタイプを表すオブジェクトを作成します。
1. ソースタイプが外部ワークブックのデータソースタイプと同じであることに基づき、関連する条件を指定します。

この C++ コードは、操作を示しています：

```c++
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

### **チャートデータを編集する**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この C++ コードは、上記プロセスの実装例です：

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているかどうかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) と [外部ワークブックへのパス](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) があり、ソースが外部ワークブックである場合、外部ファイルが使用されていることを確認するためにフルパスを読み取ることができます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、プレゼンテーションは PPTX ファイルに絶対パスを保存することに注意してください。

**ネットワークリソース/共有上にあるワークブックを使用できますか？**

はい、そのようなワークブックは外部データソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**Aspose.Slides はプレゼンテーションを保存する際に外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) を保存し、データ読み取りに使用します。プレゼンテーションを保存しても外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、復号化されたコピー（例: [Aspose.Cells](/cells/cpp/) を使用）を作成してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保存します。すべてが同じファイルを指している場合、そのファイルを更新すると、次回データがロードされた際に各チャートに反映されます。