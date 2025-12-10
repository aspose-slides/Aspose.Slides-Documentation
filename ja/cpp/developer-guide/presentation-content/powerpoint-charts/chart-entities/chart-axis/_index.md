---
title: C++ を使用したプレゼンテーションのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/cpp/chart-axis/
keywords:
- チャート軸
- 縦軸
- 横軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸のプロパティ
- 最大値
- 最小値
- 軸線
- 日付形式
- 軸タイトル
- 軸の位置
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "レポートや可視化のための PowerPoint プレゼンテーションで、Aspose.Slides for C++ を使用してチャート軸をカスタマイズする方法をご紹介します。"
---

## **縦軸の最大値を取得する**
Aspose.Slides for C++ を使用すると、縦軸の最小値と最大値を取得できます。以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 軸上の実際の最大値を取得します。
1. 軸上の実際の最小値を取得します。
1. 軸の実際の主単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

以下のサンプルコードは、上記手順の実装例で、C++ で必要な値を取得する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// プレゼンテーションを保存します
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```


## **軸間のデータを入れ替える**
Aspose.Slides を使用すると、軸間のデータをすばやく入れ替えることができます。縦軸 (y 軸) のデータが横軸 (x 軸) に、横軸のデータが縦軸に移動します。

この C++ コードは、チャートの軸間でデータを入れ替える方法を示しています:
``` cpp
// 空のプレゼンテーションを作成します
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// 行と列を入れ替えます
chart->get_ChartData()->SwitchRowColumn();

// プレゼンテーションを保存します
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```


## **折れ線グラフの縦軸を無効にする**
この C++ コードは、折れ線グラフの縦軸を非表示にする方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **折れ線グラフの横軸を無効にする**
このコードは、折れ線グラフの横軸を非表示にする方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **カテゴリ軸を変更する**
**set_CategoryAxisType()** メソッドを使用すると、希望するカテゴリ軸タイプ（**date** または **text**）を指定できます。この C++ コードは操作例を示しています:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```


## **カテゴリ軸値の日付形式を設定する**
Aspose.Slides for C++ を使用すると、カテゴリ軸値の日付形式を設定できます。操作は以下の C++ コードで示されています:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **軸タイトルの回転角度を設定する**
Aspose.Slides for C++ を使用すると、チャート軸タイトルの回転角度を設定できます。以下の C++ コードが操作例です:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **カテゴリ軸または値軸の位置を設定する**
Aspose.Slides for C++ を使用すると、カテゴリ軸または値軸の位置を設定できます。操作は以下の C++ コードで確認できます:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```


## **チャート値軸に表示単位ラベルを有効にする**
Aspose.Slides for C++ を使用すると、チャートの値軸に単位ラベルを表示するよう構成できます。以下の C++ コードが操作例です:
``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **FAQ**

**軸が他方の軸と交差する位置（軸の交差点）を設定するにはどうすればよいですか？**

軸は[交差設定](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/)を提供します。ゼロ、最大カテゴリ/値、または特定の数値で交差させることができます。これにより X 軸を上下にシフトしたり、基準線を強調したりできます。

**目盛りラベルを軸に対してどの位置に配置できますか（側面、外側、内側）？**

[label position](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) を "cross"、"outside"、"inside" に設定します。可読性に影響し、特に小さなチャートでスペースを節約するのに役立ちます。