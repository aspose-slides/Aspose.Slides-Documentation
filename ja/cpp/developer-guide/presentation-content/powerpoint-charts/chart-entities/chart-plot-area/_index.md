---
title: チャートプロットエリア
type: docs
url: /cpp/chart-plot-area/
---

## **チャートプロットエリアの幅と高さを取得する**
Aspose.Slides for C++はシンプルなAPIを提供します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを使ってチャートを追加します。
1. 実際の値を取得する前に、IChart::ValidateChartLayout() メソッドを呼び出します。
1. チャートの左上隅に対するチャート要素の実際のX位置（左）を取得します。
1. チャートの左上隅に対するチャート要素の実際の上端を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// チャート付きプレゼンテーションを保存
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **チャートプロットエリアのレイアウトモードを設定する**
Aspose.Slides for C++は、チャートプロットエリアのレイアウトモードを設定するためのシンプルなAPIを提供します。プロパティ**LayoutTargetType**は**ChartPlotArea**および**IChartPlotArea**クラスに追加されています。プロットエリアのレイアウトが手動で定義されている場合、このプロパティはプロットエリアを内側（軸や軸ラベルを含まない）または外側（軸や軸ラベルを含む）でレイアウトするかどうかを指定します。**LayoutTargetType**列挙型で定義された2つの可能な値があります。

- **LayoutTargetType.Inner** - プロットエリアサイズが、目盛りと軸ラベルを含まないプロットエリアのサイズを決定することを指定します。
- **LayoutTargetType.Outer** - プロットエリアサイズが、目盛りおよび軸ラベルを含むプロットエリアのサイズを決定することを指定します。

サンプルコードは以下の通りです。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}