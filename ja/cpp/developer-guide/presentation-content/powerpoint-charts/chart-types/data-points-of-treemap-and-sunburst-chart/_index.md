---
title: C++ を使用したツリーマップおよびサンバーストチャートのデータポイントのカスタマイズ
linktitle: ツリーマップとサンバーストチャートのデータポイント
type: docs
url: /ja/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- ツリーマップチャート
- サンバーストチャート
- データポイント
- ラベルカラー
- ブランチカラー
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint 形式に対応したツリーマップおよびサンバーストチャートのデータポイントを管理する方法を学びます。"
---

その他のPowerPointチャートのタイプの中で、2つの「階層」タイプがあります - **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、または Multi Level Pie Chart とも呼ばれます）。これらのチャートは、葉から枝のトップまでツリーとして組織された階層データを表示します。葉は系列データポイントによって定義され、各 subsequent nested grouping level は対応するカテゴリによって定義されます。Aspose.Slides for C++ は、C++ で Sunburst Chart と Treemap のデータポイントをフォーマットすることを可能にします。

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:

以下は Sunburst Chart で、Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Let’s start with adding a new Sunburst chart to the presentation:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```


{{% alert color="primary" title="関連項目" %}} 
- [**Sunburst Chart の作成**](/slides/ja/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、以下を使用する必要があります:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) classes 
and [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) method 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 
is used for accessing multi-level categories - it represents the container of 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) objects. 
Basically it is a wrapper for 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) with 
the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) class has 
two methods: [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) and 
[**get_Label()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25)which 
provide access to corresponding settings.
## **データポイントの値を表示**
"Leaf 4" データポイントの値を表示:
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **データポイントのラベルと色を設定**
"Branch 1" データラベルをカテゴリ名ではなく系列名 ("Series1") を表示するように設定します。その後、テキスト色を黄色に設定します:
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **データポイントのブランチ色を設定**

"Stem 4" ブランチの色を変更します:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **よくある質問**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**

いいえ。PowerPoint はセグメントを自動的にソートします（通常は値の降順、時計回り）。Aspose.Slides はこの動作をそのまま反映します：順序を直接変更することはできず、データを事前処理することで実現します。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[theme/palette](/slides/ja/cpp/presentation-theme/) を継承します。一定の結果を得るためには、必要なレベルで実体塗りつぶしとテキスト書式設定をロックしてください。

**PDF/PNG へのエクスポートはカスタムブランチ色やラベル設定を保持しますか？**

はい。プレゼンテーションをエクスポートすると、チャート設定（塗りつぶし、ラベル）は出力フォーマットに保持されます。これは Aspose.Slides がチャートの書式設定を適用した状態でレンダリングするためです。

**チャート上にカスタムオーバーレイを配置するために、ラベル/要素の実際の座標を計算できますか？**

はい。チャートのレイアウトが検証された後、要素（例: [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)) の実際の X と実際の Y が利用可能になり、オーバーレイの正確な位置決めに役立ちます。