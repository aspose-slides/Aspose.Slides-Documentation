---
title: チャートのワークブック
type: docs
weight: 70
url: /cpp/chart-workbook/
keywords: "チャートのワークブック, チャートデータ, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++におけるPowerPointプレゼンテーションのチャートのワークブック"
---

## **ワークブックからチャートデータを設定する**

Aspose.Slidesは、チャートデータワークブック（Aspose.Cellsで編集されたチャートデータを含む）を読み書きするための[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a1bc3d9eaafc86814336b6c23bffd8e2e)および[WriteWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a3f42c5e16bf1fd1d4e69579bffc6ce8e)メソッドを提供しています。**注意**：チャートデータは、元のものと同様の方法で整理する必要があります。

```cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

このC++コードは、チャートデータワークブックを設定する操作を示しています：

```cpp
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

## **ワークブックのセルをチャートデータラベルとして設定する**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. データを含むバブルチャートを追加します。
1. チャートシリーズにアクセスします。
1. ワークブックのセルをデータラベルとして設定します。
1. プレゼンテーションを保存します。

このC++コードは、ワークブックのセルをチャートデータラベルとして設定する方法を示しています：

```cpp
System::String lbl0 = u"ラベル 0 セルの値";
System::String lbl1 = u"ラベル 1 セルの値";
System::String lbl2 = u"ラベル 2 セルの値";

// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
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

このC++コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook#a8a5bfd5f6d389c497fe0d9ff4037d928)プロパティを使用してワークシートコレクションにアクセスする操作を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **データソースタイプを指定する**

このC++コードは、データソースのタイプを指定する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"リテラル文字列"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **外部ワークブック**

{{% alert color="primary" %}} 
[Aspose.Slides](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-19-4-release-notes/) 19.4では、チャートのデータソースとして外部ワークブックのサポートを実装しました。
{{% /alert %}} 

### **外部ワークブックを作成する**

**`ReadWorkbookStream`**および**`SetExternalWorkbook`**メソッドを使用して、外部ワークブックをゼロから作成するか、内部ワークブックを外部にすることができます。

このC++コードは、外部ワークブック作成プロセスを示しています：

```cpp
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

**`IChartData.SetExternalWorkbook`**メソッドを使用すると、チャートに外部ワークブックをデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合にも使用できます。

リモートロケーションまたはリソースに格納されたワークブックのデータを編集することはできませんが、そのようなワークブックを外部データソースとして使用できます。外部ワークブックの相対パスが提供されると、自動的にフルパスに変換されます。

このC++コードは、外部ワークブックの設定方法を示しています：

```cpp
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

`SetExternalWorkbook`メソッドの`updateChartData`パラメータは、Excelワークブックが読み込まれるかどうかを指定するために使用されます。 

* `updateChartData`の値が`false`に設定されると、ワークブックのパスだけが更新され、チャートデータはターゲットワークブックからロードまたは更新されません。この設定は、ターゲットワークブックが存在しないか利用できない状況で使用することがあります。
* `updateChartData`の値が`true`に設定されると、チャートデータはターゲットワークブックから更新されます。

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **チャート外部データソースワークブックパスを取得する**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. チャートシェイプのオブジェクトを作成します。
1. チャートのデータソースを表すソース（`ChartDataSourceType`）タイプのオブジェクトを作成します。
1. ソースタイプが外部ワークブックデータソースタイプと同じであることに基づいて、関連する条件を指定します。

このC++コードは、操作を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// プレゼンテーションを保存
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **チャートデータを編集する**

外部ワークブック内のデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックが読み込めない場合は、例外がスローされます。

このC++コードは、前述のプロセスの実装です：

```cpp
const String templatePath = u"../templates/presentation.pptx";
const String outPath = u"../out/presentation-out.pptx";

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());

chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```