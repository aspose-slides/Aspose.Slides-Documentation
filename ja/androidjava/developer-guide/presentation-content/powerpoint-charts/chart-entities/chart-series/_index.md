---
title: Android のプレゼンテーションでチャートデータ系列を管理する
linktitle: データ系列
type: docs
url: /ja/androidjava/chart-series/
keywords:
- チャート系列
- 系列の重なり
- 系列の色
- カテゴリの色
- 系列名
- データポイント
- 系列のギャップ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "実用的な Java コード例とベストプラクティスを使用して、PowerPoint（PPT/PPTX）向けの Android でチャート系列を管理し、データプレゼンテーションを強化する方法を学びます。"
---

系列は、チャートにプロットされた数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定する**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) メソッドを使用すると、2D チャートで棒や列がどれだけ重なり合うか（範囲: -100 から 100）を決定できます。このプロパティは親系列グループのすべての系列に適用され、対応するグループプロパティの投影です。そのため、このプロパティは読み取り専用です。

`getParentSeriesGroup().setOverlap()` 書き込みメソッドを使用して、オーバーラップの希望値を設定します。

1. Presentation クラスのインスタンスを作成します。
1. スライドにクラスター化列チャートを追加します。
1. 最初のチャート系列にアクセスします。
1. チャート系列の ParentSeriesGroup にアクセスし、系列の希望するオーバーラップ値を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

この Java コードは、チャート系列のオーバーラップを設定する方法を示しています:
```java
Presentation pres = new Presentation();
try {
    // チャートを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // 系列のオーバーラップを設定
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // プレゼンテーションファイルをディスクに保存
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **系列の色を変更する**

Aspose.Slides for Android via Java では、系列の色を次のように変更できます。

1. Presentation クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列にアクセスします。
1. 希望する塗りタイプと塗り色を設定します。
1. 変更したプレゼンテーションを保存します。

この Java コードは、系列の色を変更する方法を示しています:
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


## **系列カテゴリの色を変更する**

Aspose.Slides for Android via Java では、系列カテゴリの色を次のように変更できます。

1. Presentation クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列カテゴリにアクセスします。
1. 希望する塗りタイプと塗り色を設定します。
1. 変更したプレゼンテーションを保存します。

この Java コードは、系列カテゴリの色を変更する方法を示しています:
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


## **系列名を変更する**

デフォルトでは、チャートの凡例名は各列または行のデータ上部のセルの内容です。

サンプル画像の例では、

* 列は *Series 1, Series 2,* および *Series 3*;
* 行は *Category 1, Category 2, Category 3,* および *Category 4* です。

Aspose.Slides for Android via Java では、チャート データおよび凡例内の系列名を更新または変更できます。

この Java コードは、ChartDataWorkbook を使用して系列名を変更する方法を示しています:
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


この Java コードは、Series を介して凡例の系列名を変更する方法を示しています:
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


## **チャート系列の塗り色を設定する**

Aspose.Slides for Android via Java では、プロット領域内のチャート系列の自動塗り色を次のように設定できます。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 好みのタイプに基づくデフォルト データでチャートを追加します（以下の例では `ChartType.ClusteredColumn` を使用）。
1. チャート系列にアクセスし、塗り色を Automatic に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この Java コードは、チャート系列の自動塗り色を設定する方法を示しています:
```java
Presentation pres = new Presentation();
try {
    // クラスタ化列チャートを作成
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // 系列の塗り形式を自動に設定
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


## **チャート系列の反転塗り色を設定する**

Aspose.Slides では、プロット領域内のチャート系列の反転塗り色を次のように設定できます。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 好みのタイプに基づくデフォルト データでチャートを追加します（以下の例では `ChartType.ClusteredColumn` を使用）。
1. チャート系列にアクセスし、塗り色を反転に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この Java コードは、操作を示しています:
```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しい系列とカテゴリを追加
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // 最初のチャート系列を取得し、その系列データを設定
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


## **値が負の場合に系列を反転させる**

Aspose.Slides では、`IChartDataPoint.InvertIfNegative` および `ChartDataPoint.InvertIfNegative` プロパティを使用して系列の反転を設定できます。これらのプロパティで反転を設定すると、データポイントは負の値を取得したときに色が反転します。

この Java コードは、操作を示しています:
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


## **特定のポイント データをクリアする**

Aspose.Slides for Android via Java では、特定のチャート系列の `DataPoints` データを次のようにクリアできます。

1. Presentation クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. インデックスでチャートの参照を取得します。
4. すべてのチャート `DataPoints` を反復処理し、`XValue` と `YValue` を null に設定します。
5. 特定のチャート系列のすべての `DataPoints` をクリアします。
6. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

この Java コードは、操作を示しています:
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


## **系列のギャップ幅を設定する**

Aspose.Slides for Android via Java では、**`GapWidth`** プロパティを使用して系列のギャップ幅を次のように設定できます。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. 任意のチャート系列にアクセスします。
1. `GapWidth` プロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

この Java コードは、系列のギャップ幅を設定する方法を示しています:
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
    
    // 系列を追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // カテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 2番目のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 系列データを設定
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

**単一のチャートが保持できる系列の数に制限はありますか？**

Aspose.Slides には系列数の固定上限はありません。実用的な上限は、チャートの可読性とアプリケーションで利用可能なメモリによって決まります。

**クラスター内の列が互いに近すぎる、または離れすぎている場合はどうすればよいですか？**

その系列（または親系列グループ）の `GapWidth` 設定を調整します。値を大きくすると列間のスペースが広がり、値を小さくすると列が近づきます。