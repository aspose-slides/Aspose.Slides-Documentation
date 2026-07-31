---
title: C++ を使用してプレゼンテーション内のチャートデータシリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/cpp/chart-series/
keywords:
- チャートシリーズ
- シリーズのオーバーラップ
- シリーズの色
- カテゴリの色
- シリーズ名
- データポイント
- シリーズのギャップ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) 用に C++ でチャートシリーズを管理する方法を、実用的なコード例とベストプラクティスとともに学び、データプレゼンテーションを強化しましょう。"
---
## **概要**

この記事では、Aspose.Slides における [ChartSeries](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts.chartseries/) の役割について、プレゼンテーション内でデータがどのように構成され視覚化されるかに焦点を当てて説明します。これらのオブジェクトは、チャート内のデータ ポイント、カテゴリ、外観パラメータの個別セットを定義する基礎要素を提供します。[ChartSeries](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts.chartseries/) を使用することで、開発者は基になるデータ ソースをシームレスに統合し、情報の表示方法を完全に制御でき、洞察と分析を明確に伝える動的なデータ駆動型プレゼンテーションを実現できます。

シリーズは、チャートにプロットされる数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **データシリーズのオーバーラップを設定する**

この [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) メソッドを使用すると、2D チャート上で棒や列がどの程度重なるか（範囲: -100〜100）を指定できます。このプロパティは親シリーズ グループのすべてのシリーズに適用されます。これは該当するグループ プロパティの投影です。

`get_ParentSeriesGroup()::set_Overlap()` メソッドを使用して、`Overlap` の希望値を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
1. スライドにクラスター化された縦棒チャートを追加します。  
1. 最初のチャートシリーズにアクセスします。  
1. チャートシリーズの `ParentSeriesGroup` にアクセスし、シリーズの希望するオーバーラップ値を設定します。  
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。  

この C++ コードは、チャートシリーズのオーバーラップを設定する方法を示しています:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// チャートを追加
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // シリーズのオーバーラップを設定
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// プレゼンテーションファイルをディスクに保存
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **データシリーズの色を変更する**

Aspose.Slides for C++ では、シリーズの色を次のように変更できます:

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
1. スライドにチャートを追加します。  
1. 色を変更したいシリーズにアクセスします。  
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。  
1. 変更したプレゼンテーションを保存します。  

この C++コードは、シリーズの色を変更する方法を示しています:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **データシリーズカテゴリの色を変更する**

Aspose.Slides for C++ では、シリーズカテゴリの色を次のように変更できます:

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
1. スライドにチャートを追加します。  
1. 色を変更したいシリーズカテゴリにアクセスします。  
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。  
1. 変更したプレゼンテーションを保存します。  

この C++コードは、シリーズカテゴリの色を変更する方法を示しています:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **データシリーズの名前を変更する** 

デフォルトでは、チャートの凡例名は各列または行の上にあるセルの内容です。

例（サンプル画像）では、

* 列は *Series 1, Series 2,* と *Series 3* です。  
* 行は *Category 1, Category 2, Category 3,* と *Category 4* です。  

Aspose.Slides for C++ では、チャートデータおよび凡例内のシリーズ名を更新または変更できます。  

この C++コードは、チャートデータ `ChartDataWorkbook` 内のシリーズ名を変更する方法を示しています:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

この C++コードは、`Series` を通じて凡例内のシリーズ名を変更する方法を示しています:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **データシリーズの塗りつぶし色を設定する**

Aspose.Slides for C++ では、プロット領域内のチャートシリーズの自動塗りつぶし色を次のように設定できます:

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. 好みのタイプに基づくデフォルトデータでチャートを追加します（下の例では `ChartType::ClusteredColumn` を使用しました）。  
1. チャートシリーズにアクセスし、塗りつぶし色を Automatic に設定します。  
1. プレゼンテーションを PPTX ファイルに保存します。  

この C++コードは、チャートシリーズの自動塗りつぶし色を設定する方法を示しています:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// クラスター化された縦棒チャートを作成
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// シリーズの塗りつぶし形式を自動に設定
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// プレゼンテーションファイルをディスクに書き込む
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **データシリーズの反転塗りつぶし色を設定する**

Aspose.Slides では、プロット領域内のチャートシリーズの反転塗りつぶし色を次のように設定できます:

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. 好みのタイプに基づくデフォルトデータでチャートを追加します（下の例では `ChartType::ClusteredColumn` を使用しました）。  
1. チャートシリーズにアクセスし、塗りつぶし色を invert に設定します。  
1. プレゼンテーションを PPTX ファイルに保存します。  

この C++コードは操作を示しています:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **チャートシリーズの反転塗りつぶし色を設定する**

Aspose.Slides は、`IChartDataPoint::set_InvertIfNegative()` および `ChartDataPoint.set_InvertIfNegative()` メソッドを使用して反転を設定できます。これらのメソッドで反転が設定されると、データ ポイントが負の値を取得したときに色が反転します。  

この C++コードは操作を示しています:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **特定のデータポイントの値をクリアする**

Aspose.Slides for C++ では、特定のチャートシリーズの `DataPoints` データを次のようにクリアできます:

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. インデックスでチャートの参照を取得します。  
4. すべてのチャート `DataPoints` を反復処理し、`XValue` と `YValue` を null に設定します。  
5. 特定のチャートシリーズのすべての `DataPoints` をクリアします。  
6. 変更したプレゼンテーションを PPTX ファイルに書き出します。  

この C++コードは操作を示しています:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **データシリーズのギャップ幅を設定する**

Aspose.Slides for C++ では、**`set_GapWidth()`** メソッドを使用してシリーズのギャップ幅を次のように設定できます:

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
1. 最初のスライドにアクセスします。  
1. デフォルトデータでチャートを追加します。  
1. 任意のチャートシリーズにアクセスします。  
1. `GapWidth` プロパティを設定します。  
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。  

この C++コードは、シリーズのギャップ幅を設定する方法を示しています:

```cpp
// 空のプレゼンテーションを作成
auto presentation = System::MakeObject<Presentation>();

// プレゼンテーションの最初のスライドにアクセス
auto slide = presentation->get_Slides()->idx_get(0);

// デフォルトデータでチャートを追加
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// チャートデータシートのインデックスを設定
int32_t worksheetIndex = 0;

// チャートデータワークシートを取得
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// シリーズを追加
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// カテゴリを追加
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// 2番目のチャートシリーズを取得
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// シリーズデータを入力
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// GapWidth の値を設定
series->get_ParentSeriesGroup()->set_GapWidth(50);

// プレゼンテーションをディスクに保存
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **よくある質問**

**1つのチャートに含められるシリーズの数に上限はありますか？**

Aspose.Slides では、追加できるシリーズ数に固定された上限はありません。実務上の上限は、チャートの可読性とアプリケーションが利用できるメモリ量によって決まります。

**クラスター内の列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

対象のシリーズ（またはその親シリーズ グループ）のギャップ幅設定を調整します。値を大きくすると列間のスペースが広がり、値を小さくすると列がより近くなります。