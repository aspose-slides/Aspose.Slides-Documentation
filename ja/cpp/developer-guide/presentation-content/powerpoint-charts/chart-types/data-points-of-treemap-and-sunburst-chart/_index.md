---
title: C++ を使用した Treemap および Sunburst チャートのデータポイントのカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- ツリーマップ チャート
- サンバースト チャート
- データポイント
- ラベルカラー
- ブランチカラー
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint 形式に対応した Treemap および Sunburst チャートのデータポイントを管理する方法を学びます。"
---
## **Introduction**

PowerPoint の他のチャートタイプの中で、階層型のものが 2 つあります ― **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）。これらのチャートは、ツリー構造で整理された階層データを、葉から枝の上部へと表示します。葉は系列のデータポイントで定義され、各次の入れ子になったグループレベルは対応するカテゴリで定義されます。Aspose.Slides for C++ は、C++ で Sunburst Chart と Treemap のデータポイントの書式設定を可能にします。

以下は Sunburst Chart の例です。Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します。

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

新しい Sunburst チャートをプレゼンテーションに追加してみましょう：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="See also" %}} 
- [**Sunburst チャートの作成**](/slides/ja/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、次のものを使用します。

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)、 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevel/) クラス と [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) メソッドは、Treemap および Sunburst チャートのデータポイントの書式設定へのアクセスを提供します。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) はマルチレベルカテゴリにアクセスするために使用され、[**IChartDataPointLevel**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevel/) オブジェクトのコンテナを表します。実質的には、データポイント固有のプロパティが追加された [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) のラッパーです。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevel/) クラスは、対応する設定にアクセスできる 2 つのメソッド、[**get_Format()**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) と [**get_Label()**](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) を提供します。

## **Show a Data Point Value**
「Leaf 4」データポイントの値を表示する：

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Set a Data Point Label and Color**
「Branch 1」データラベルをカテゴリ名の代わりに系列名（「Series1」）を表示するように設定し、テキストの色を黄色に設定します：

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Set the Data Point Branch Color**
「Stem 4」ブランチの色を変更する：

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

## **FAQ**

**Can I change the order (sorting) of segments in Sunburst/Treemap?**

いいえ。PowerPoint はセグメントを自動的に並べ替えます（通常は降順で時計回り）。Aspose.Slides も同じ動作を踏襲しており、直接順序を変更することはできません。データを事前に加工することで実現します。

**How does the presentation theme affect the colors of segments and labels?**

チャートの色はプレゼンテーションの [theme/palette](/slides/ja/cpp/presentation-theme/) を継承します。明示的に塗りつぶしやフォントを設定しない限り、テーマの影響を受けます。一貫した結果を得るには、必要なレベルで実線の塗りつぶしとテキスト書式をロックしてください。

**Will export to PDF/PNG preserve custom branch colors and label settings?**

はい。プレゼンテーションをエクスポートすると、チャートの設定（塗りつぶし、ラベルなど）が出力形式に保持されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**Can I compute the actual coordinates of a label/element for custom overlay placement on top of the chart?**

はい。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/datalabel/)）の actual X と actual Y が取得可能です。これにより、オーバーレイの正確な位置決めが可能になります。