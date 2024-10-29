---
title: チャート計算
type: docs
weight: 50
url: /ja/cpp/chart-calculations/
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for C++は、これらのプロパティを取得するための簡単なAPIを提供します。これにより、チャート要素の実際の値を計算することができます。実際の値には、IActualLayoutインターフェイスを実装する要素の位置（IActualLayout::get_ActualX()、IActualLayout::get_ActualY()、IActualLayout::get_ActualWidth()、IActualLayout::get_ActualHeight()）と実際の軸の値（IAxis::get_ActualMaxValue()、IAxis::get_ActualMinValue()、IAxis::get_ActualMajorUnit()、IAxis::get_ActualMinorUnit()、IAxis::get_ActualMajorUnitScale()、IAxis::get_ActualMinorUnitScale()）が含まれます。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// プレゼンテーションを保存
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **親チャート要素の実際の位置を計算する**
Aspose.Slides for C++は、これらのプロパティを取得するための簡単なAPIを提供します。IActualLayoutのメソッドは、親チャート要素の実際の位置に関する情報を提供します。プロパティに実際の値を設定するには、IChart::ValidateChartLayout()メソッドを事前に呼び出す必要があります。

``` cpp
// 空のプレゼンテーションを作成
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **チャートから情報を非表示にする**
このトピックは、チャートから情報を非表示にする方法を理解するのに役立ちます。Aspose.Slides for C++を使用すると、チャートから**タイトル、縦軸、横軸**、および**グリッド線**を非表示にすることができます。以下のコード例は、これらのプロパティを使用する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **チャートのデータ範囲を設定する**
Aspose.Slides for C++は、チャートのデータ範囲を最も簡単な方法で設定するためのシンプルなAPIを提供しています。チャートのデータ範囲を設定するには：

- チャートを含むPresentationクラスのインスタンスを開きます。
- インデックスを使用してスライドの参照を取得します。
- すべての図形を巡回して、目的のチャートを見つけます。
- チャートデータにアクセスして範囲を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下のコード例は、チャートを更新する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}