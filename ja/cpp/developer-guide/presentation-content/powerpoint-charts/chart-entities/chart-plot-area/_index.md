---
title: C++でプレゼンテーションチャートのプロット領域をカスタマイズ
linktitle: プロット領域
type: docs
url: /ja/cpp/chart-plot-area/
keywords:
- チャート
- プロット領域
- プロット領域の幅
- プロット領域の高さ
- プロット領域のサイズ
- レイアウトモード
- PowerPoint
- プレゼンテーション
- С++
- Aspose.Slides
description: "PowerPoint プレゼンテーションでチャートのプロット領域を Aspose.Slides for С++ を使用してカスタマイズする方法をご紹介します。スライドのビジュアルを簡単に改善できます。"
---

## **チャート プロット領域の幅と高さを取得する**
Aspose.Slides for C++ はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルト データでチャートを追加します。
4. 実際の値を取得するために IChart::ValidateChartLayout() メソッドを呼び出します。
5. チャート要素の左上隅を基準とした実際の X 位置（左）を取得します。
6. チャート要素の左上隅を基準とした実際の上位置を取得します。
7. チャート要素の実際の幅を取得します。
8. チャート要素の実際の高さを取得します。
```cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// チャート付きのプレゼンテーションを保存
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **チャート プロット領域のレイアウトモードを設定する**
Aspose.Slides for C++ はチャート プロット領域のレイアウトモードを設定するためのシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** と **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは領域を内部（軸と軸ラベルを除く）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体で定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** - プロット領域のサイズが領域のサイズを決定し、目盛りと軸ラベルは含まれません。
- **LayoutTargetType.Outer** - プロット領域のサイズが領域のサイズ、目盛り、軸ラベルを決定します。

以下にサンプルコードを示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**ActualX、ActualY、ActualWidth、ActualHeight はどの単位で返されますか？**

ポイント単位です。1 インチ = 72 ポイントです。これは Aspose.Slides の座標単位です。

**プロット領域はコンテンツの面でチャート領域とどのように異なりますか？**

プロット領域はデータ描画領域（系列、グリッド線、トレンドライン等）です。チャート領域はそれに加えてタイトルや凡例などの周囲の要素を含みます。3D チャートの場合、プロット領域には壁/床および軸も含まれます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**

それらはチャート全体サイズに対する比率（0〜1）で表されます。このモードでは自動配置が無効になり、設定した比率が使用されます。

**凡例を追加/移動した後、プロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側、チャート領域に配置されますが、レイアウトや利用可能なスペースに影響するため、自動配置が有効な場合はプロット領域が移動することがあります。（これは PowerPoint のチャートの標準的な動作です。）