---
title: チャートシリーズ
type: docs
url: /ja/java/chart-series/
keywords: "チャートシリーズ, シリーズカラー, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaにおけるPowerPointプレゼンテーションのチャートシリーズ"
---

シリーズは、チャートにプロットされた数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズの重なりを設定**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)プロパティを使用すると、2Dチャート上でバーや列がどのくらい重なるべきかを指定できます（範囲：-100から100）。このプロパティは親シリーズグループのすべてのシリーズに適用されます：これは適切なグループプロパティの投影です。したがって、このプロパティは読み取り専用です。

`ParentSeriesGroup.Overlap`読み取り/書き込みプロパティを使用して、`Overlap`の好みの値を設定します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドにクラスター化された縦棒グラフを追加します。
1. 最初のチャートシリーズにアクセスします。
1. チャートシリーズの`ParentSeriesGroup`にアクセスし、シリーズの好みの重なりの値を設定します。
1. 変更されたプレゼンテーションをPPTXファイルに書き込みます。

このJavaコードは、チャートシリーズの重なりを設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    // チャートを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // シリーズの重なりを設定
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // プレゼンテーションファイルをディスクに書き込む
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **シリーズの色を変更**
Aspose.Slides for Javaでは、次のようにシリーズの色を変更できます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズにアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 変更されたプレゼンテーションを保存します。

このJavaコードは、シリーズの色を変更する方法を示しています：

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
Aspose.Slides for Javaでは、次のようにシリーズカテゴリの色を変更できます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズカテゴリにアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 変更されたプレゼンテーションを保存します。

このJavaコードは、シリーズカテゴリの色を変更する方法を示しています：

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

## **シリーズの名前を変更** 

デフォルトでは、チャートの凡例名は各列または行のデータの上にあるセルの内容です。

私たちの例で（サンプル画像）、

* 列は *シリーズ1、シリーズ2、シリーズ3*です；
* 行は *カテゴリ1、カテゴリ2、カテゴリ3、およびカテゴリ4*です。 

Aspose.Slides for Javaでは、チャートデータと凡例でシリーズ名を更新または変更できます。

このJavaコードは、チャートデータ`ChartDataWorkbook`内のシリーズ名を変更する方法を示しています：

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

このJavaコードは、`Series`を通じて凡例内のシリーズ名を変更する方法を示しています：

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

## **チャートシリーズの塗りつぶし色を設定**

Aspose.Slides for Javaでは、次のようにチャートシリーズ内のプロット領域の自動塗りつぶし色を設定できます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. お好みのタイプに基づいて、デフォルトデータでチャートを追加します（以下の例では、`ChartType.ClusteredColumn`を使用しました）。
1. チャートシリーズにアクセスし、塗りつぶし色を自動的に設定します。
1. プレゼンテーションをPPTXファイルに保存します。

このJavaコードは、チャートシリーズの自動塗りつぶし色を設定する方法を示しています：

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
Aspose.Slidesでは、次のようにチャートシリーズ内のプロット領域の反転塗りつぶし色を設定できます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. お好みのタイプに基づいて、デフォルトデータでチャートを追加します（以下の例では、`ChartType.ClusteredColumn`を使用しました）。
1. チャートシリーズにアクセスし、塗りつぶし色を反転します。
1. プレゼンテーションをPPTXファイルに保存します。

このJavaコードは、操作を示しています：

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しいシリーズとカテゴリを追加
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "シリーズ1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "カテゴリ1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "カテゴリ2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "カテゴリ3"));

    // 最初のチャートシリーズを取得し、そのシリーズデータを補充します。
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

## **値が負のときにシリーズを反転させる**
Aspose.Slidesでは、`IChartDataPoint.InvertIfNegative`と`ChartDataPoint.InvertIfNegative`プロパティを通じて反転を設定できます。プロパティを使用して反転を設定すると、データポイントは負の値を持つときにその色を反転します。

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

## **特定のデータポイントのデータをクリア**
Aspose.Slides for Javaでは、特定のチャートシリーズの`DataPoints`データをクリアできます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. インデックスを通じてチャートの参照を取得します。
4. すべてのチャート`DataPoints`を反復処理し、`XValue`と`YValue`をnullに設定します。
5. 特定のチャートシリーズのすべての`DataPoints`をクリアします。
6. 変更されたプレゼンテーションをPPTXファイルに書き込みます。

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

## **シリーズの間隔幅を設定**
Aspose.Slides for Javaでは、**`GapWidth`**プロパティを通じてシリーズの間隔幅を設定できます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを持つチャートを追加します。
1. 任意のチャートシリーズにアクセスします。
1. `GapWidth`プロパティを設定します。
1. 変更されたプレゼンテーションをPPTXファイルに書き込みます。

このJavaコードは、シリーズの間隔幅を設定する方法を示しています：

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
    
    // チャートデータワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // シリーズを追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "シリーズ1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "シリーズ2"), chart.getType());
    
    // カテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "カテゴリ1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "カテゴリ2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "カテゴリ3"));
    
    // 二番目のチャートシリーズを取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // シリーズデータを補充
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // GapWidthの値を設定
    series.getParentSeriesGroup().setGapWidth(50);
    
    // ディスクにプレゼンテーションを保存
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```