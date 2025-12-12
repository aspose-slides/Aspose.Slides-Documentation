---
title: Android のプレゼンテーションでチャート データ ラベルを管理
linktitle: データ ラベル
type: docs
url: /ja/androidjava/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル 距離
- ラベル 位置
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides via Java を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、スライドをより魅力的にする方法を学びます。"
---

チャートのデータ ラベルは、チャートのデータ系列や個々のデータ ポイントに関する詳細を示します。読者がデータ系列をすばやく識別でき、チャートの理解もしやすくなります。

## **チャート データ ラベルのデータ精度を設定**

この Java コードは、チャート データ ラベルのデータ精度を設定する方法を示します。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **パーセンテージをラベルとして表示**

Aspose.Slides for Android via Java を使用すると、表示されたチャートにパーセンテージ ラベルを設定できます。この Java コードはその操作を示します。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // チャートを含むプレゼンテーションを保存します
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャート データ ラベルにパーセンテージ記号を設定**

この Java コードは、チャート データ ラベルのパーセンテージ記号を設定する方法を示します。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // インデックスを使用してスライドの参照を取得します
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライド上に PercentsStackedColumn チャートを作成します
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // NumberFormatLinkedToSource を false に設定します
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // チャート データのワークシートを取得します
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // 新しい系列を追加します
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // LabelFormat のプロパティを設定します
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // 新しい系列を追加します
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // 塗りつぶしタイプと色を設定します
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // プレゼンテーションをディスクに保存します
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **軸からラベルの距離を設定**

この Java コードは、軸からプロットされたチャートでカテゴリ軸からラベルの距離を設定する方法を示します。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // スライドの参照を取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // スライド上にチャートを作成します
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // 軸からラベルの距離を設定します
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // プレゼンテーションをディスクに保存します
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ラベル位置の調整**

円グラフのように軸に依存しないチャートを作成する場合、チャートのデータ ラベルがエッジに近すぎることがあります。そのような場合、リーダーラインがはっきり表示されるようにデータ ラベルの位置を調整する必要があります。

この Java コードは、円グラフのラベル位置を調整する方法を示します。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**密集したチャートでデータ ラベルが重なるのを防ぐには？**

自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせます。必要に応じて、一部のフィールド（例: カテゴリ）を非表示にするか、極端または重要なポイントのラベルのみを表示します。

**ゼロ、負、または空の値に対してのみラベルを無効にするには？**

ラベルを有効にする前にデータポイントをフィルタリングし、0、負の値、または欠損値に対しては定義されたルールに従って表示をオフにします。

**PDF/画像にエクスポートする際にラベルスタイルの一貫性を確保するには？**

フォント（ファミリ、サイズ）を明示的に設定し、レンダリング側でフォントが利用可能であることを確認してフォールバックを防止します。