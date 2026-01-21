---
title: C++ を使用したツリーマップおよびサンバースト チャートのデータ ポイントのカスタマイズ
linktitle: ツリーマップおよびサンバースト チャートのデータ ポイント
type: docs
url: /ja/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- ツリーマップ チャート
- サンバースト チャート
- データ ポイント
- ラベル色
- ブランチ色
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint フォーマットに対応したツリーマップおよびサンバースト チャートのデータ ポイントの管理方法を学びます。"
---

PowerPoint の他のチャートタイプの中で、2 つの「階層」タイプがあります - **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、または Multi Level Pie Chart とも呼ばれます）。これらのチャートは、ツリー構造として編成された階層データを表示します - 葉から枝のトップまで。葉はシリーズのデータポイントで定義され、各後続のネストされたグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for C++ は、C++ で Sunburst Chart と Treemap のデータポイントの書式設定を可能にします。

以下は Sunburst Chart です。Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加することから始めましょう：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```


{{% alert color="primary" title="関連項目" %}} 
- [**Sunburst Chart の作成**](/slides/ja/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、以下を使用します。

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)、[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) クラスと、[**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) メソッドは、Treemap と Sunburst チャートのデータポイントの書式設定にアクセスする手段を提供します。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) は、マルチレベルカテゴリにアクセスするために使用され、[**IChartDataPointLevel**] オブジェクトのコンテナを表します。  
基本的には、データポイント固有のプロパティが追加された [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) のラッパーです。  
[**IChartDataPointLevel**] クラスには、[**get_Format()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) と [**get_Label()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) の 2 つのメソッドがあり、対応する設定にアクセスできます。

## **データポイントの値を表示**
"Leaf 4" データポイントの値を表示:
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**
"Branch 1" のデータラベルをカテゴリ名の代わりにシリーズ名（"Series1"）で表示するように設定します。その後、テキストの色を黄色に設定します:
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントのブランチ色を設定**
"Stem 4" ブランチの色を変更:
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
いいえ。PowerPoint はセグメントを自動的にソートします（通常は降順で時計回り）。Aspose.Slides も同様の動作を行い、直接順序を変更することはできません。データを前処理して実現してください。

**プレゼンテーションのテーマはセグメントとラベルの色にどのように影響しますか？**  
チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/cpp/presentation-theme/)を継承します。一定の結果を得るには、必要なレベルで実線の塗りつぶしとテキスト書式を固定してください。

**PDF/PNG へのエクスポートはカスタムブランチ色やラベル設定を保持しますか？**  
はい。プレゼンテーションをエクスポートすると、チャートの設定（塗りつぶし、ラベル）が出力フォーマットに保持されます。これは Aspose.Slides がチャートの書式設定を適用した状態でレンダリングするためです。

**チャート上にカスタムオーバーレイを配置するために、ラベルや要素の実際の座標を計算できますか？**  
はい。チャートのレイアウトが検証された後、要素（例として [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)）の実際の X と実際の Y が取得可能となり、オーバーレイの正確な位置決めに役立ちます。