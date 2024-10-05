---
title: チャートシリーズ
type: docs
url: /cpp/chart-series/
---

シリーズは、チャートにプロットされた数字の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定**

[IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb)メソッドを使用すると、2Dチャート上のバーや列がどのくらい重なるかを指定できます（範囲：-100から100）。このプロパティは親シリーズグループのすべてのシリーズに適用されます：これは適切なグループプロパティの投影です。

`get_ParentSeriesGroup()::set_Overlap()`メソッドを使用して、`Overlap`の希望する値を設定します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. スライドにクラスタ化された縦棒グラフを追加します。
1. 最初のチャートシリーズにアクセスします。
1. チャートシリーズの`ParentSeriesGroup`にアクセスし、シリーズの希望するオーバーラップ値を設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

このC++コードは、チャートシリーズのオーバーラップを設定する方法を示しています：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// チャートを追加
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // シリーズオーバーラップを設定
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// プレゼンテーションファイルをディスクに書き込み
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **シリーズの色を変更**
Aspose.Slides for C++を使用すると、次のようにシリーズの色を変更できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズにアクセスします。
1. お好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正されたプレゼンテーションを保存します。

このC++コードは、シリーズの色を変更する方法を示しています：

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

## **シリーズのカテゴリーの色を変更**
Aspose.Slides for C++を使用すると、次のようにシリーズカテゴリーの色を変更できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズカテゴリーにアクセスします。
1. お好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正されたプレゼンテーションを保存します。

このC++コードは、シリーズカテゴリーの色を変更する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **シリーズの名前を変更**

デフォルトでは、チャートの凡例名は、各列またはデータ行の上にあるセルの内容です。

私たちの例（サンプル画像）では、

* 列は*シリーズ1、シリーズ2、シリーズ3*；
* 行は*カテゴリー1、カテゴリー2、カテゴリー3、カテゴリー4*です。

Aspose.Slides for C++を使用すると、チャートデータおよび凡例内でシリーズ名を更新または変更できます。

このC++コードは、チャートデータ`ChartDataWorkbook`内でシリーズ名を変更する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"新しい名前"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

このC++コードは、`Series`を通じて凡例内でシリーズ名を変更する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"新しい名前"));
```

## **チャートシリーズの塗りつぶし色を設定**

Aspose.Slides for C++を使用すると、プロットエリア内のチャートシリーズの自動塗りつぶし色を次のように設定できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. インデックスを指定してスライドの参照を取得します。
1. お好みのタイプに基づいてデフォルトデータのチャートを追加します（以下の例では、`ChartType::ClusteredColumn`を使用しました）。
1. チャートシリーズにアクセスし、塗りつぶし色を自動に設定します。
1. プレゼンテーションをPPTXファイルとして保存します。

このC++コードは、チャートシリーズの自動塗りつぶし色を設定する方法を示しています：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// クラスタ化された縦棒グラフを作成
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// シリーズの塗りつぶしフォーマットを自動に設定
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// プレゼンテーションファイルをディスクに書き込み
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **チャートシリーズの塗りつぶし色を反転設定**
Aspose.Slidesは、プロットエリア内のチャートシリーズの反転塗りつぶし色を次のように設定できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. インデックスを指定してスライドの参照を取得します。
1. お好みのタイプに基づいてデフォルトデータのチャートを追加します（以下の例では、`ChartType::ClusteredColumn`を使用しました）。
1. チャートシリーズにアクセスし、塗りつぶし色を反転に設定します。
1. プレゼンテーションをPPTXファイルとして保存します。

このC++コードは、操作を示しています：

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// 新しいシリーズとカテゴリーを追加
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"シリーズ 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"カテゴリー 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"カテゴリー 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"カテゴリー 3")));

// 最初のチャートシリーズを取得して、そのシリーズデータを設定
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

## **値が負のときに反転するようにシリーズを設定**
Aspose.Slidesは、`IChartDataPoint::set_InvertIfNegative()`および`ChartDataPoint.set_InvertIfNegative()`メソッドを使用して反転を設定できます。メソッドを使用して反転が設定されると、データポイントは負の値を取るとその色を反転します。

このC++コードは、操作を示しています：

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

## **特定のデータポイントのデータをクリア**
Aspose.Slides for C++を使用すると、特定のチャートシリーズの`DataPoints`データをクリアできます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを指定してスライドの参照を取得します。
3. インデックスを指定してチャートの参照を取得します。
4. すべてのチャート`DataPoints`を反復し、`XValue`と`YValue`をnullに設定します。
5. 特定のチャートシリーズのすべての`DataPoints`をクリアします。
6. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

このC++コードは、操作を示しています：

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

## **シリーズのギャップ幅を設定**
Aspose.Slides for C++を使用すると、**`set_GapWidth()`**メソッドを通じてシリーズのギャップ幅を設定できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータ付きのチャートを追加します。
4. 任意のチャートシリーズにアクセスします。
5. `GapWidth`プロパティを設定します。
6. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

このC++コードは、シリーズのギャップ幅を設定する方法を示しています：

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
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"シリーズ 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"シリーズ 2")), chart->get_Type());

// カテゴリーを追加
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"カテゴリー 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"カテゴリー 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"カテゴリー 3")));

// 2番目のチャートシリーズを取得
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// シリーズデータを設定
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// ギャップ幅の値を設定
series->get_ParentSeriesGroup()->set_GapWidth(50);

// プレゼンテーションをディスクに保存
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```