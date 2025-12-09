---
title: チャートシリーズ
type: docs
url: /ja/nodejs-java/chart-series/
keywords: "チャートシリーズ, シリーズカラー, PowerPointプレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScriptでのPowerPointプレゼンテーションにおけるチャートシリーズ"
---

シリーズとは、チャートにプロットされた数値の行または列のことです。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズの重なりの設定**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) メソッドを使用すると、2D チャートでバーや列がどの程度重なるかを指定できます（範囲: -100 から 100）。このプロパティは親シリーズグループのすべてのシリーズに適用されます: 適切なグループプロパティの投影です。そのため、このプロパティは読み取り専用です。

`ParentSeriesGroup.getOverlap` の読み書き可能なプロパティを使用して、`Overlap` の希望の値を設定します。 

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. スライドにクラスタ化列チャートを追加します。  
1. 最初のチャートシリーズにアクセスします。  
1. チャートシリーズの `ParentSeriesGroup` にアクセスし、シリーズの希望の重なり値を設定します。  
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // チャートを追加します
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // シリーズの重なりを設定します
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // プレゼンテーションファイルを書き込みます
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シリーズの色の変更**

Aspose.Slides for Node.js via Java を使用すると、シリーズの色を次のように変更できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. スライドにチャートを追加します。  
1. 色を変更したいシリーズにアクセスします。  
1. 任意の塗りつぶしタイプと塗りつぶし色を設定します。  
1. 変更されたプレゼンテーションを保存します。  

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シリーズカテゴリの色の変更**

Aspose.Slides for Node.js via Java を使用すると、シリーズカテゴリの色を次のように変更できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. スライドにチャートを追加します。  
1. 色を変更したいシリーズカテゴリにアクセスします。  
1. 任意の塗りつぶしタイプと塗りつぶし色を設定します。  
1. 変更されたプレゼンテーションを保存します。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シリーズ名の変更**

デフォルトでは、チャートの凡例名は各列または行の上にあるセルの内容です。

サンプル画像の例では、  
* 列は *Series 1, Series 2,* と *Series 3* です；  
* 行は *Category 1, Category 2, Category 3,* と *Category 4* です。  

Aspose.Slides for Node.js via Java を使用すると、チャートデータおよび凡例内のシリーズ名を更新または変更できます。

この JavaScript コードは、チャートデータ `ChartDataWorkbook` 内のシリーズ名を変更する方法を示しています：  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


この JavaScript コードは、`Series` を介して凡例内のシリーズ名を変更する方法を示しています：  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **チャートシリーズの塗りつぶし色の設定**

Aspose.Slides for Node.js via Java を使用すると、プロット領域内のチャートシリーズの自動塗りつぶし色を次のように設定できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. 好みのタイプに基づくデフォルトデータでチャートを追加します（例では `ChartType.ClusteredColumn` を使用）。  
1. チャートシリーズにアクセスし、塗りつぶし色を Automatic に設定します。  
1. プレゼンテーションを PPTX ファイルに保存します。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // クラスタ化列チャートを作成します
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // シリーズの塗りつぶし形式を自動に設定します
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // プレゼンテーションファイルを書き込みます
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **チャートシリーズの反転塗りつぶし色の設定**

Aspose.Slides を使用すると、プロット領域内のチャートシリーズの反転塗りつぶし色を次のように設定できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. 好みのタイプに基づくデフォルトデータでチャートを追加します（例では `ChartType.ClusteredColumn` を使用）。  
1. チャートシリーズにアクセスし、塗りつぶし色を invert に設定します。  
1. プレゼンテーションを PPTX ファイルに保存します。  

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 新しいシリーズとカテゴリを追加します
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // 最初のチャートシリーズを取得し、シリーズデータを設定します。
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **値が負の場合にシリーズを反転させる設定**

Aspose.Slides は `ChartDataPoint.setInvertIfNegative` メソッドを通じて反転を設定できます。プロパティを使用して反転を設定すると、データポイントが負の値を取ったときに色が反転します。  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **特定のデータポイントのデータをクリア**

Aspose.Slides for Node.js via Java を使用すると、特定のチャートシリーズの `DataPoints` データを次のようにクリアできます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. インデックスでチャートの参照を取得します。  
4. すべてのチャート `DataPoints` を反復処理し、`XValue` と `YValue` を null に設定します。  
5. 特定のチャートシリーズのすべての`DataPoints`をクリアします。  
6. 変更されたプレゼンテーションを PPTX ファイルに書き出します。  

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シリーズのギャップ幅の設定**

Aspose.Slides for Node.js via Java を使用すると、**`GapWidth`** プロパティを介してシリーズのギャップ幅を次のように設定できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. 最初のスライドにアクセスします。  
1. デフォルトデータでチャートを追加します。  
1. 任意のチャートシリーズにアクセスします。  
1. `GapWidth` プロパティを設定します。  
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。  

```javascript
// 空のプレゼンテーションを作成します
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションの最初のスライドにアクセスします
    var slide = pres.getSlides().get_Item(0);
    // デフォルトデータでチャートを追加します
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // チャートデータシートのインデックスを設定します
    var defaultWorksheetIndex = 0;
    // チャートデータワークシートを取得します
    var fact = chart.getChartData().getChartDataWorkbook();
    // シリーズを追加します
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // カテゴリを追加します
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 2番目のチャートシリーズを取得します
    var series = chart.getChartData().getSeries().get_Item(1);
    // シリーズのデータを設定します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // GapWidth の値を設定します
    series.getParentSeriesGroup().setGapWidth(50);
    // プレゼンテーションをディスクに保存します
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**単一のチャートが保持できるシリーズ数に上限はありますか？**

Aspose.Slides にはシリーズ数の固定上限はありません。実際の上限はチャートの可読性と、アプリケーションで利用可能なメモリによって決まります。

**クラスタ内の列が近すぎる、または離れすぎる場合はどうすればよいですか？**

そのシリーズ（または親シリーズグループ）のギャップ幅設定を調整します。値を大きくすると列間のスペースが広がり、値を小さくすると列が近づきます。  