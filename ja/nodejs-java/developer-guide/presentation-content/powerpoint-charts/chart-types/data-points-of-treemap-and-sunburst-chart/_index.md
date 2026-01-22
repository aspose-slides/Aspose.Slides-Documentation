---
title: JavaScript を使用した Treemap と Sunburst チャートのデータポイントのカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ツリーマップ チャート
- サンバースト チャート
- データポイント
- ラベルの色
- 枝の色
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js via Java を使用して、PowerPoint 形式と互換性のある Treemap および Sunburst チャートのデータポイントの管理方法を学びます。"
---

PowerPoint の他のチャートタイプの中で、階層型のチャートは **Treemap** と **Sunburst** の 2 種類があります（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、Multi Level Pie Chart とも呼ばれます）。これらのチャートは、ツリー構造として階層データを表示します—葉（リーフ）から枝の先頭まで。葉はシリーズのデータポイントで定義され、以降のネストされたグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for Node.js via Java は、JavaScript で Sunburst チャートと Treemap のデータポイントの書式設定を可能にします。

以下は Sunburst チャートです。Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します：
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加することから始めましょう：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="参考" %}} 
- [**JavaScript で PowerPoint プレゼンテーションのチャートを作成または更新**](/slides/ja/nodejs-java/create-chart/)
{{% /alert %}}

チャートのデータポイントを書式設定する必要がある場合は、以下を使用します：

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager)、[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) クラスと [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) メソッドは、Treemap と Sunburst チャートのデータポイントの書式設定へのアクセスを提供します。  
[**ChartDataPointLevelsManager**] は複数レベルのカテゴリにアクセスするために使用され、[**ChartDataPointLevel**] オブジェクトのコンテナを表します。  
基本的に、データポイントに固有のプロパティが追加された [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) のラッパーです。  
[**ChartDataPointLevel**] クラスは、[**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) と [**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) の 2 つのメソッドを持ち、対応する設定へのアクセスを提供します。

## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**
「Branch 1」データラベルをカテゴリ名の代わりにシリーズ名（「Series1」）を表示するように設定し、テキスト色を黄色に設定します：
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントの枝の色を設定**
「Steam 4」枝の色を変更します：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **よくある質問**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**

いいえ。PowerPoint はセグメントを自動的に並べ替えます（通常は値の降順、時計回り）。Aspose.Slides も同様の動作を行い、直接順序を変更することはできません。データを事前に処理することで実現します。

**プレゼンテーションのテーマはセグメントおよびラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/nodejs-java/presentation-theme/)を継承します。一定の結果を得るには、必要なレベルで実体の塗りつぶしとテキスト書式を固定してください。

**PDF/PNG へのエクスポートはカスタム枝の色やラベル設定を保持しますか？**

はい。プレゼンテーションをエクスポートする際、チャートの設定（塗りつぶし、ラベル）は出力形式に保持されます。これは、Aspose.Slides がチャートの書式設定を適用した状態でレンダリングするためです。

**ラベルや要素の実際の座標を計算し、チャート上にカスタムオーバーレイを配置できますか？**

はい。チャートのレイアウトが検証された後、要素（例として [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)）には実際の X および実際の Y が利用可能となり、オーバーレイの正確な位置決めに役立ちます。