---
title: ツリーマップとサンバーストチャートのデータポイント
type: docs
url: /ja/cpp/data-points-of-treemap-and-sunburst-chart/
keywords: "サンバーストグラフ"
description: "Aspose.Slidesを使用したサンバーストグラフ、サンバーストダイアグラム、サンバーストチャート、半径チャート、半径グラフまたはマルチレベルパイチャート。"
---

他のタイプのPowerPointチャートの中には、2つの「階層的」タイプ - **ツリーマップ** と **サンバースト** チャート（サンバーストグラフ、サンバーストダイアグラム、半径チャート、半径グラフまたはマルチレベルパイチャートとも呼ばれる）があります。これらのチャートは、葉から枝の先端までのツリーとして構成された階層データを表示します。葉は系列データポイントによって定義され、各後続のネストされたグループ化レベルは、対応するカテゴリによって定義されます。Aspose.Slides for C++は、C++でサンバーストチャートとツリーマップのデータポイントをフォーマットすることを可能にします。

以下はサンバーストチャートで、Series1列のデータが葉ノードを定義し、他の列が階層データポイントを定義しています：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しいサンバーストチャートを追加することから始めましょう：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="関連情報" %}} 
- [**サンバーストチャートの作成**](/slides/ja/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、次を使用する必要があります：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager)、 
[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) クラス 
および [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) メソッド 
は、ツリーマップとサンバーストチャートのデータポイントをフォーマットするためのアクセスを提供します。 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 
は、複数のレベルのカテゴリにアクセスするために使用されます - それは 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) オブジェクトのコンテナを表します。 
基本的にそれは 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) のラッパーであり、 
データポイントに特有のプロパティが追加されています。 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) クラスには 
2つのメソッドがあります： [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) と 
[**get_Label()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25) は 
対応する設定にアクセスを提供します。
## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **データポイントのラベルと色を設定**
「Branch 1」データラベルをカテゴリ名の代わりに系列名（「Series1」）を表示するように設定します。次に、テキスト色を黄色に設定します：

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **データポイントの枝の色を設定**

「Stem 4」枝の色を変更します：

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
