---
title: Java を使用したプレゼンテーションのチャートデータシリーズの管理
linktitle: データシリーズ
type: docs
url: /ja/java/chart-series/
keywords:
- チャートシリーズ
- シリーズのオーバーラップ
- シリーズの色
- カテゴリの色
- シリーズ名
- データポイント
- シリーズのギャップ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint（PPT/PPTX）向けに、実用的なコード例とベストプラクティスを用いて、Javaでチャートシリーズを管理し、データプレゼンテーションを向上させる方法を学びましょう。"
---

シリーズは、チャートにプロットされた数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定**

この[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)プロパティを使用すると、2Dチャート上で棒や列がどの程度重なるか（範囲：-100から100）を指定できます。このプロパティは親シリーズグループのすべてのシリーズに適用されます。つまり、適切なグループプロパティの投影です。そのため、このプロパティは読み取り専用です。

`ParentSeriesGroup.Overlap` の読み書きプロパティを使用して、`Overlap` の希望の値を設定します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドにクラスター化された縦棒グラフを追加します。
1. 最初のチャートシリーズにアクセスします。
1. チャートシリーズの `ParentSeriesGroup` にアクセスし、シリーズの希望するオーバーラップ値を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

この Java コードは、チャートシリーズのオーバーラップを設定する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    // チャートを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // シリーズのオーバーラップを設定
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // プレゼンテーションファイルをディスクに書き込む
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シリーズの色を変更**

Aspose.Slides for Java では、シリーズの色を以下の方法で変更できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズにアクセスします。
1. 希望する塗りタイプと塗り色を設定します。
1. 変更されたプレゼンテーションを保存します。

この Java コードは、シリーズの色を変更する方法を示しています。
```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シリーズカテゴリの色を変更**

Aspose.Slides for Java では、シリーズカテゴリの色を以下の方法で変更できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズカテゴリにアクセスします。
1. 希望する塗りタイプと塗り色を設定します。
1. 変更されたプレゼンテーションを保存します。

この Java コードは、シリーズカテゴリの色を変更する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シリーズ名を変更** 

デフォルトでは、チャートの凡例名は各列または行の上にあるセルの内容になります。

この例（サンプル画像）では、

* 列は *Series 1、Series 2*、*Series 3* です；
* 行は *Category 1、Category 2、Category 3*、*Category 4* です。

Aspose.Slides for Java では、チャートデータおよび凡例内のシリーズ名を更新または変更できます。

この Java コードは、チャートデータ `ChartDataWorkbook` 内のシリーズ名を変更する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この Java コードは、`Series` を通じて凡例内のシリーズ名を変更する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートシリーズの塗りつぶし色を設定**

Aspose.Slides for Java では、プロット領域内のチャートシリーズの自動塗りつぶし色を以下の方法で設定できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 好みのタイプ（以下の例では `ChartType.ClusteredColumn`）に基づいてデフォルトデータでチャートを追加します。
1. チャートシリーズにアクセスし、塗りつぶし色を Automatic に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この Java コードは、チャートシリーズの自動塗りつぶし色を設定する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    // クラスター化された縦棒グラフを作成
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // シリーズの塗りつぶし形式を自動に設定
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // プレゼンテーションファイルをディスクに書き込む
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートシリーズの反転塗りつぶし色を設定**

Aspose.Slides では、プロット領域内のチャートシリーズの反転塗りつぶし色を以下の方法で設定できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 好みのタイプ（以下の例では `ChartType.ClusteredColumn`）に基づいてデフォルトデータでチャートを追加します。
1. チャートシリーズにアクセスし、塗りつぶし色を invert に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この Java コードは操作を示しています。
```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しいシリーズとカテゴリを追加します
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // 最初のチャートシリーズを取得し、そのシリーズデータを設定します。
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **値が負の場合にシリーズを反転させる設定**

Aspose.Slides では、`IChartDataPoint.InvertIfNegative` および `ChartDataPoint.InvertIfNegative` プロパティを使用して反転を設定できます。これらのプロパティで反転を設定すると、データポイントが負の値を取得したときに色が反転します。

この Java コードは操作を示しています。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **特定のポイントデータをクリア**

Aspose.Slides for Java では、特定のチャートシリーズの `DataPoints` データを以下の方法でクリアできます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. インデックスでチャートの参照を取得します。
4. すべてのチャート `DataPoints` を走査し、`XValue` と `YValue` を null に設定します。
5. 特定のチャートシリーズのすべての`DataPoints` をクリアします。
6. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

この Java コードは操作を示しています。
```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シリーズのギャップ幅を設定**

Aspose.Slides for Java では、**`GapWidth`** プロパティを使用してシリーズのギャップ幅を以下の方法で設定できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 任意のチャートシリーズにアクセスします。
1. `GapWidth` プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

この Java コードは、シリーズのギャップ幅を設定する方法を示しています。
```java
// 空のプレゼンテーションを作成 
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // デフォルトデータでチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // チャートデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;
    
    // チャートデータのワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // シリーズを追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // カテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 2番目のチャートシリーズを取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // シリーズのデータを設定
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // GapWidth の値を設定
    series.getParentSeriesGroup().setGapWidth(50);
    
    // プレゼンテーションをディスクに保存
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**単一のチャートが保持できるシリーズ数に上限はありますか？**

Aspose.Slides は追加できるシリーズ数に固定の上限を設けていません。実際の上限はチャートの可読性とアプリケーションで利用可能なメモリによって決まります。

**クラスター内の列が近すぎる、または離れすぎる場合はどうすればよいですか？**

そのシリーズ（または親シリーズグループ）の `GapWidth` 設定を調整します。値を増やすと列間の間隔が広がり、減らすと列が近づきます。