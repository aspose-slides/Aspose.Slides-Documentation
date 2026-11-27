---
title: JavaScriptでプレゼンテーションチャートをフォーマット
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/nodejs-java/chart-formatting/
keywords:
- チャートの書式設定
- チャート書式設定
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸ボーダー
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Java を通じて Node.js 用 Aspose.Slides のチャート書式設定を学び、カスタム軸、フォント、数値書式、角丸チャート境界線で PowerPoint プレゼンテーションを強化しましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションのチャートの書式設定方法を説明します。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなどの重要なチャート要素をカスタマイズして、チャートデータの外観と可読性を向上させる方法を示します。

また、チャート テキストのフォント プロパティを設定し、チャート データにプリセット数値書式を適用し、チャート領域の角を丸める方法も示します。これらの例を組み合わせることで、プレゼンテーション内のチャートのビジュアル スタイルとデータ表示の両方を制御できます。

上昇・下降区間の塗りつぶしとアウトラインを別々に設定する方法については、[株価チャートの例](/slides/ja/nodejs-java/create-chart/#create-stock-charts)をご覧ください。

## **チャートエンティティの書式設定**

[チャート](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) を使用して、チャート タイトル、軸、グリッド線、凡例、プロット領域の書式設定を行います。この例では、マーカー付きの折れ線グラフをデフォルト データで作成し、値軸とカテゴリ軸に別々のテキストと線のスタイルを適用します。フォント サイズと線幅はポイントで指定され、カテゴリ ラベルは 45 度回転します。

値軸はソース セルとは独立して [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) を使用します。そのスケールは -2 から 15 までで、メジャー間隔は 2、マイナー間隔は 0.5 です。この例では、パーセンテージ書式と [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) を千単位に設定した組み合わせも示しています。データの意味と規模に合わせてこれらの設定を調整してください。凡例は [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) を `false` で呼び出すため、プロット領域の外側に配置されます。背面壁とフロアの塗りつぶしは [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) と [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor) で構成できますが、これらのサーフェスは 3D チャートでのみ表示されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャートのフォント プロパティを設定する**

[Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat) を使用して、チャート テキストの既定フォント サイズを設定します。この例では、20 ポイントのフォントを使用したクラスター化縦棒グラフを作成し、[setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) を使用して最初の系列の値ラベルを有効にしています。独自のフォント設定を持つテキスト要素は、チャートの既定設定を上書きできます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャート凡例のテキスト フレーム書式設定を再利用する**

スライドの見出しに合わせて凡例のフォントを設定するには、最初の段落で [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用します。凡例の [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat) が返す書式に対して [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) を呼び出すと、テキスト フレーム設定、最初の段落の書式、およびその段落の既定フォント プロパティがコピーされます。個々の部分や後続の段落に直接適用された書式は、ソースにローカルなままです。

この例では、ネイビーの太字 26 ポイント Calibri 見出しをテンプレートとして使用しています。凡例のスタイリング後、[copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) を呼び出して、同じ書式を別のキャプションに適用します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたプレゼンテーションでは、凡例とキャプションは見出しとサイズ、太さ、色が一致しています。凡例は系列名を表示し続け、キャプションは独自のテキストを保持します。キャプション内の部分に既に明示的なフォント サイズが設定されている場合、そのサイズがコピーされた段落の既定よりも優先されます。

| コピー前 | コピー後 |
| --- | --- |
| ![四半期売上チャート（通常の黒い凡例ラベルと黒いキャプション）](legend-formatting-before.png) | ![同じチャート（大きく太字のネイビー凡例ラベルと一致するキャプション）](legend-formatting.png) |

## **数値書式を設定する**

[ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) を使用して、チャート ワークブック セルに組み込み数値書式を適用します。この例では、既定のセル バック データを持つクラスター化縦棒グラフを作成し、各系列値セルに書式インデックス 10（`0.00%`）を適用しています。これにより、基になる数値は変更せずにワークブック内の表示が変わります。たとえば、0.25 は 25.00% と表示されます。軸とデータ ラベルの書式は個別に構成できます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の表は、英語（米国）ロケール向けの代表的な Excel 書式とともに組み込み数値書式インデックスを一覧にしたものです。正確な書式文字列と表示は、アプリケーションやロケールにより異なる場合があります。特に通貨や日付の書式は、[Microsoft の数値書式実装ノート](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) で説明されているように、OOXML 標準の既定とは異なることがあります。

| インデックス | 形式 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **チャート領域の角丸ボーダーを設定する**

[Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) に `true` を渡して、チャート領域の角を丸めます。この例では、クラスター化縦棒グラフを作成し、[getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) を使用してアウトラインに単色の灰色と単一線スタイルを設定した後、プレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **既存のチャート注釈を編集する**

チャートには、レポートのステータスを説明するテキスト 注釈などのカスタム シェイプを含めることができます。これらのシェイプは [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes) を介して取得します。[getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) が返すコレクションには、チャートが所有するシェイプが含まれます。

チャート上に配置された普通のテキスト ボックスはスライドに所属し、たとえチャートの一部のように見えても同様です。[Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) を反復処理すると、チャートと通常のスライド シェイプが見つかりますが、チャート内部の個別シェイプは列挙されません。チャート タイトルやデータ ラベルは別個のチャート要素であり、このコレクション内のカスタム 注釈ではありません。

[chart-annotations.pptx](chart-annotations.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには、"Preliminary results" という未グループ化の注釈、チャートが所有する線、"Slide overlay" という普通のスライド テキスト ボックスが含まれています。例では、そのスライド上の最初のチャートを見つけ、レポートが公開準備完了したときに注釈を "Final results" に変更します。空のコレクションをチェックし、[getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) が非 null のテキスト フレームを返す [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) のみを編集し、期待されるテキストかどうかを確認します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

線とスライドのテキスト ボックスは変更されません。以下の画像は入力と保存後に再度開いた結果を示しています。

| 編集前 | 編集後 |
| --- | --- |
| ![「Preliminary results」と表示されたチャート注釈](chart-annotations-before.png) | ![「Final results」と表示されたチャート注釈](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
この例はトップレベルのチャート所有シェイプのみを調査します。注釈が [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) 内にある場合は、そのグループの [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) コレクションも調べてください。入れ子になったグループについても同様に再帰的に処理し、子シェイプのテキスト チェックを適用します。グループ自体はコンテナであり、テキスト ボックスとして扱わないでください。
{{% /alert %}}

## **FAQ**

**列/エリアの塗りつぶしを半透明にし、境界線を不透明に設定できますか？**

はい。塗りつぶしの透明度とアウトラインは別々に構成できます。これは、密集したビジュアル化においてグリッドとデータの可読性を向上させる際に便利です。

**ラベルが重なったときの対処方法は？**

フォント サイズを小さくする、不要なラベル要素（例：カテゴリ）を無効にする、ラベル位置を調整する、必要に応じて選択ポイントのみラベルを表示する、またはフォーマットを「値 + 凡例」に切り替えるなどの方法があります。

**系列にグラデーションやパターンの塗りつぶしを適用できますか？**

はい。系列は単色、グラデーション、パターンの塗りつぶしをサポートします。実務ではグラデーションは控えめに使用し、グリッドやテキストとのコントラストが低下する組み合わせは避けてください。