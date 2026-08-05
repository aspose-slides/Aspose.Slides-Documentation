---
title: C++ でプレゼンテーション チャートのプロット領域をカスタマイズ
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションのチャート プロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを簡単に向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides のチャートのプロット領域の操作方法を示します。チャートのレイアウトを検証し、その後 X、Y、幅、高さの値を取得することで、プロット領域の実際の位置とサイズを取得する方法を説明します。

また、レイアウトを手動で設定する場合に、`LayoutTargetType` を使用してプロット領域を内部領域だけで計算するか、軸と軸ラベルを含む外部領域で計算するかを定義し、プロット領域のレイアウトモードを構成する方法も示します。

## **チャートのプロット領域の幅と高さの取得**
Aspose.Slides for C++ はシンプルな API を提供します。  

1. Presentation クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. 実際の値を取得するために、IChart::ValidateChartLayout() メソッドを呼び出します。
5. チャート要素の実際の X 座標（左）を、チャートの左上隅からの相対位置として取得します。
6. チャート要素の実際の上位置を、チャートの左上隅からの相対位置として取得します。
7. チャート要素の実際の幅を取得します。
8. チャート要素の実際の高さを取得します。

``` cpp
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

## **チャートのプロット領域のレイアウトモードの設定**
Aspose.Slides for C++ はチャートのプロット領域のレイアウトモードを設定するためのシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** と **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティはプロット領域を内部（軸と軸ラベルを除く）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体で定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** – プロット領域のサイズが、目盛りや軸ラベルを含めずにプロット領域のサイズを決定することを指定します。
- **LayoutTargetType.Outer** – プロット領域のサイズが、目盛りと軸ラベルも含めてプロット領域のサイズを決定することを指定します。

以下にサンプルコードを示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **よくある質問**

**ActualX、ActualY、ActualWidth、ActualHeight はどの単位で返されますか？**  
ポイント単位です。1 インチ = 72 ポイントです。これらは Aspose.Slides の座標単位です。

**プロット領域はコンテンツ的にチャート領域とどのように違いますか？**  
プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。一方、チャート領域はタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域は壁・床および軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**  
それらはチャート全体サイズに対する割合（0〜1）として解釈されます。このモードでは自動位置決めが無効になり、設定した割合が使用されます。

**凡例を追加または移動した後、プロット領域の位置が変わったのはなぜですか？**  
凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトと利用可能なスペースに影響を与えるため、auto‑positioning が有効な場合はプロット領域が移動することがあります。（これは PowerPoint のチャートの標準動作です。）