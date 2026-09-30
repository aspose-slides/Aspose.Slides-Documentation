---
title: JavaScript を使用してプレゼンテーションのチャート凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/nodejs-java/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用してチャートの凡例をカスタマイズし、適切な凡例書式で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、PowerPoint プレゼンテーションにおけるチャート凡例のカスタマイズオプションを提供します。本記事では、凡例の位置とサイズの設定、凡例全体のフォントサイズの設定、個別の凡例エントリの書式設定、選択したエントリの非表示または復元方法を示します。

FAQ では、凡例用のスペースを確保することや、複数行ラベルの表示、プレゼンテーションテーマからの書式継承など、関連する動作について説明します。

## **凡例の位置指定**

凡例の位置とサイズをチャートの寸法の割合として指定するには、凡例の [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), および [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) メソッドを使用します。

この例では、プレゼンテーションを作成し、デフォルトデータを持つクラスター化された縦棒グラフを最初のスライドに追加します。凡例のオフセットとサイズをチャートの幅と高さで割ることで相対値に変換します。凡例はチャートの左上隅から 50 ポイントオフセットされ、サイズは 100 x 100 ポイントになります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // チャートに対して凡例の位置とサイズを相対的に指定します。
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **凡例のフォントサイズの設定**

凡例のテキスト書式にアクセスするには [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) を使用し、ポイント単位でフォントサイズを設定するには [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) を使用します。

この例では、デフォルトデータでチャートを作成し、凡例のテキストを 20 ポイントに設定します。また、縦軸の自動範囲を無効にし、範囲を -5 から 10 に設定します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **個別の凡例エントリのフォントサイズの設定**

凡例の [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) メソッドが返すコレクションを使用して、特定のエントリの書式設定にアクセスします。エントリのインデックスはゼロベースなので、インデックス `1` は2番目のエントリを指します。

この例では、デフォルトデータに少なくとも 2 つのシリーズが含まれるクラスター化された縦棒グラフを作成します。2 番目の凡例エントリを太字、斜体、20 ポイントの青色テキストで書式設定します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **個別の凡例エントリを非表示にする**

データは表示したまま補助シリーズを凡例から除外するには、[LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) を `true` で呼び出し、[ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) を通じて設定します。これにより選択した凡例エントリだけが非表示になり、シリーズやデータポイントは削除されません。対照的に、[Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) を `false` で呼び出すと、凡例全体が非表示になります。

以下の例では、デフォルトデータを使用して複数のシリーズを持つクラスター化された縦棒グラフを作成します。2 番目のシリーズの凡例エントリ（インデックス `1`）を非表示にし、プレゼンテーションを保存します。その後、[setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) を `false` で呼び出してエントリを復元し、2 番目のコピーを保存します。両方のファイルで列は表示されたままです。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // チャート データを変更せずに同じエントリを復元する。
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較では、すべてのエントリが表示された状態と、2 番目のエントリが非表示になった状態の同じチャートを示します。2 番目のシリーズの列は変わりません。

![すべての凡例エントリが表示された状態と、Series 2 が凡例から非表示になった状態のチャート比較; すべての列は表示されたまま。](hide-legend-entry.png)

縦棒、横棒、折れ線チャートでは、凡例エントリはシリーズを識別します。円グラフの場合、個々のデータポイント（スライス）を識別するため、選択したスライスに対して [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) を使用します。API はこのデータポイントメソッドを `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie`、`BarOfPie` のチャートタイプについて文書化しています。このリストに含まれないドーナツチャートには適用されないと考えてください。

## **FAQ**

**チャートが凡例の上に重ねるのではなく、凡例用にスペースを確保することはできますか？**  
はい。`false` を指定して [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) を呼び出すと、プロット領域に重なるのを防ぎ、凡例用にスペースが確保されます。

**凡例ラベルを複数行にすることはできますか？**  
はい。利用可能な幅が不足している場合、長いラベルは自動的に折り返されます。また、シリーズ名に改行文字を入れることで改行を要求することもできます。

**凡例をプレゼンテーションテーマの配色設定に従わせるにはどうすればよいですか？**  
凡例の色、塗りつぶし、フォントを設定せずに残すことで、テーマの書式を継承させます。明示的に設定した書式は、対応するテーマ設定を上書きします。