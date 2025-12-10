---
title: C++でプレゼンテーションのチャート計算を最適化する
linktitle: チャート計算
type: docs
weight: 50
url: /ja/cpp/chart-calculations/
keywords:
- チャート計算
- チャート要素
- 要素の位置
- 実際の位置
- 子要素
- 親要素
- チャート値
- 実際の値
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で PPT および PPTX のチャート計算、データ更新、精度制御を理解し、実用的な C++ コード例で学びます。"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for C++ は、これらのプロパティを取得するためのシンプルな API を提供します。これにより、チャート要素の実際の値を計算できます。実際の値には、IActualLayout インターフェイスを実装する要素の位置 (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) と、実際の軸の値 (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()) が含まれます。
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
Aspose.Slides for C++ は、これらのプロパティを取得するためのシンプルな API を提供します。IActualLayout のメソッドは、親チャート要素の実際の位置に関する情報を提供します。実際の値でプロパティを埋めるために、事前に IChart::ValidateChartLayout() メソッドを呼び出す必要があります。
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


## **チャート要素を非表示にする**
このトピックでは、チャートから情報を非表示にする方法を説明します。Aspose.Slides for C++ を使用すると、**タイトル、縦軸、横軸** および **グリッド線** をチャートから非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **チャートのデータ範囲を設定する**
Aspose.Slides for C++ は、チャートのデータ範囲を最も簡単な方法で設定できるシンプルな API を提供します。チャートのデータ範囲を設定する手順は次のとおりです。

- チャートを含む Presentation クラスのインスタンスを開く。  
- インデックスを使用してスライドへの参照を取得する。  
- すべてのシェイプを走査して目的のチャートを見つける。  
- チャートデータにアクセスし、範囲を設定する。  
- 変更したプレゼンテーションを PPTX ファイルとして保存する。

以下のコード例は、チャートを更新する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**外部 Excel ワークブックをデータ ソースとして使用できますか？また、再計算にどのように影響しますか？**

はい。チャートは外部ワークブックを参照できます。外部ソースに接続または更新すると、数式と値がそのワークブックから取得され、チャートは開く・編集する操作中に更新を反映します。API では、外部ワークブックのパスを[specify the external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/)で指定し、リンクされたデータを管理できます。

**回帰分析を自分で実装せずにトレンドラインを計算・表示できますか？**

はい。[Trendlines](/slides/ja/cpp/trend-line/)（線形、指数など）は Aspose.Slides によって追加・更新され、系列データからパラメータが自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンク付きの複数のチャートがある場合、各チャートが使用するワークブックを個別に制御できますか？**

はい。各チャートはそれぞれの[external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/)を指すことができ、またチャートごとに外部ワークブックを作成・置換して他のチャートとは独立して管理できます。