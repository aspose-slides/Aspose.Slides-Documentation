---
title: チャート系列
type: docs
url: /androidjava/chart-series/
keywords: "チャート系列, 系列の色, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaにおけるPowerPointプレゼンテーションのチャート系列"
---

系列は、チャートにプロットされた数字の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列の重なりを設定する**

`[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)` プロパティを使用すると、2Dチャート上でバーやカラムがどの程度重なるかを指定できます（範囲：-100から100）。このプロパティは親系列グループのすべての系列に適用されます：これは適切なグループプロパティのプロジェクションです。したがって、このプロパティは読み取り専用です。

`ParentSeriesGroup.Overlap` の読み書き可能プロパティを使用して、`Overlap` の好ましい値を設定します。

1. `[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. スライドにクラスタ化されたコラムチャートを追加します。
1. 最初のチャート系列にアクセスします。
1. チャート系列の `ParentSeriesGroup` にアクセスし、系列の重なりの好ましい値を設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

このJavaコードは、チャート系列の重なりを設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    // チャートを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // 系列の重なりを設定
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // プレゼンテーションファイルをディスクに書き込む
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **系列の色を変更する**
Aspose.Slides for Android via Java を使用すると、次のように系列の色を変更できます：

1. `[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列にアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正されたプレゼンテーションを保存します。

このJavaコードは、系列の色を変更する方法を示しています：

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

## **系列カテゴリーの色を変更する**
Aspose.Slides for Android via Java を使用すると、次のように系列カテゴリーの色を変更できます：

1. `[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列カテゴリーにアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正されたプレゼンテーションを保存します。

このJavaコードは、系列カテゴリーの色を変更する方法を示しています：

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

## **系列の名前を変更する**

デフォルトでは、チャートの凡例名はデータの各列または行の上のセルの内容です。

例えば、サンプル画像において、

* 列は *系列 1, 系列 2,* および *系列 3*;
* 行は *カテゴリー 1, カテゴリー 2, カテゴリー 3,* および *カテゴリー 4* です。

Aspose.Slides for Android via Java を使用すると、チャートデータおよび凡例で系列名を更新または変更できます。

このJavaコードは、チャートデータの `ChartDataWorkbook` における系列名を変更する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("新しい名前");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

このJavaコードは、`Series` を通じて凡例の系列名を変更する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("新しい名前");
} finally {
    if (pres != null) pres.dispose();
}
```

## **チャート系列の塗りつぶし色を設定する**

Aspose.Slides for Android via Java を使用すると、プロットエリア内のチャート系列に対して自動的な塗りつぶし色を設定できます：

1. `[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 好みのタイプに基づいてデフォルトデータでチャートを追加します（下記の例では `ChartType.ClusteredColumn` を使用しました）。
4. チャート系列にアクセスし、塗りつぶし色を自動に設定します。
5. プレゼンテーションをPPTXファイルに保存します。

このJavaコードは、チャート系列の自動的な塗りつぶし色を設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    // クラスタ化されたコラムチャートを作成
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // 系列の塗りつぶしフォーマットを自動に設定
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

## **チャート系列の反転塗りつぶし色を設定する**
Aspose.Slides を使用すると、チャート系列のプロットエリア内の反転塗りつぶし色を次のように設定できます：

1. `[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 好みのタイプに基づいてデフォルトデータでチャートを追加します（以下の例では `ChartType.ClusteredColumn` を使用しました）。
4. チャート系列にアクセスし、塗りつぶし色を反転に設定します。
5. プレゼンテーションをPPTXファイルに保存します。

このJavaコードは、操作を示しています：

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しい系列とカテゴリーを追加
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "系列 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "カテゴリー 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "カテゴリー 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "カテゴリー 3"));

    // 最初のチャート系列を取得し、その系列データを埋め込みます。
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

## **負の値のときに系列を反転させる**
Aspose.Slides では、`IChartDataPoint.InvertIfNegative` および `ChartDataPoint.InvertIfNegative` プロパティを通じて反転を設定可能です。プロパティを使用して反転を設定すると、データポイントは負の値を取ると色を反転させます。

このJavaコードは、操作を示しています：

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

## **特定のデータポイントのデータをクリアする**
Aspose.Slides for Android via Java を使用すると、特定のチャート系列に対して `DataPoints` データをクリアすることができます：

1. `[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. インデックスを使用してチャートの参照を取得します。
4. すべてのチャートの `DataPoints` を反復処理し、`XValue` と `YValue` を null に設定します。
5. 特定のチャート系列のすべての `DataPoints` をクリアします。
6. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

このJavaコードは、操作を示しています：

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
Aspose.Slides for Android via Java を使用すると、**`GapWidth`** プロパティを通じて系列のギャップ幅を設定できます：

1. `[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)` クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. 任意のチャート系列にアクセスします。
5. `GapWidth` プロパティを設定します。
6. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

このJavaコードは、系列のギャップ幅を設定する方法を示しています：

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
    
    // チャートのデータワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 系列を追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.getType());
    
    // カテゴリーを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "カテゴリー 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "カテゴリー 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "カテゴリー 3"));
    
    // 2番目のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 系列データを埋めます
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ギャップ幅の値を設定
    series.getParentSeriesGroup().setGapWidth(50);
    
    // プレゼンテーションをディスクに保存
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```