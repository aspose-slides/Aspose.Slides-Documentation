---
title: チャート軸
type: docs
url: /ja/nodejs-java/chart-axis/
keywords: "PowerPoint チャート軸, プレゼンテーション チャート, Java, チャート軸の操作, チャート データ"
description: "JavaScript で PowerPoint のチャート軸を編集する方法"
---

## **チャートの縦軸の最大値の取得**

Aspose.Slides for Node.js via Java を使用すると、縦軸の最小値と最大値を取得できます。次の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 軸上の実際の最大値を取得します。
1. 軸上の実際の最小値を取得します。
1. 軸の実際の主要単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主要単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

このサンプルコード（上記手順の実装）は、JavaScript で必要な値を取得する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // プレゼンテーションを保存します
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **軸間のデータの入れ替え**

Aspose.Slides を使用すると、軸間のデータを簡単に入れ替えることができます。縦軸（y 軸）のデータが横軸（x 軸）に移動し、その逆も同様です。

この JavaScript コードは、チャートの軸間でデータの入れ替えを実行する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // 行と列を入れ替えます
    chart.getChartData().switchRowColumn();
    // プレゼンテーションを保存します
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **折れ線グラフの縦軸を無効化**

この JavaScript コードは、折れ線グラフの縦軸を非表示にする方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **折れ線グラフの横軸を無効化**

このコードは、折れ線グラフの横軸を非表示にする方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カテゴリ軸の変更**

**CategoryAxisType** プロパティを使用すると、希望するカテゴリ軸のタイプ（**date** または **text**）を指定できます。この JavaScript のコードは、その操作を示しています： 
```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **カテゴリ軸値の日付形式の設定**

Aspose.Slides for Node.js via Java を使用すると、カテゴリ軸の値の日付形式を設定できます。この操作は、以下の JavaScript コードで示されています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```


## **チャート軸タイトルの回転角度の設定**

Aspose.Slides for Node.js via Java を使用すると、チャート軸タイトルの回転角度を設定できます。この JavaScript コードは、その操作を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カテゴリ軸または値軸での位置軸の設定**

Aspose.Slides for Node.js via Java を使用すると、カテゴリ軸または値軸で位置軸を設定できます。この JavaScript コードは、タスクの実行方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **チャート値軸に表示単位ラベルを有効化**

Aspose.Slides for Node.js via Java を使用すると、チャートの値軸に単位ラベルを表示するよう構成できます。この JavaScript コードは、その操作を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**軸が他方と交差する位置（軸交差）を設定するにはどうすればよいですか？**

軸は [crossing setting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) を提供しており、0、最大カテゴリ/値、または特定の数値で交差させることができます。これは X 軸を上下に移動したり、ベースラインを強調したりするのに便利です。

**目盛ラベルを軸に対してどの位置に配置できますか（横、外側、内側）？**

[label position](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) を "cross"、"outside"、または "inside" に設定します。これにより可読性が向上し、特に小さなチャートでスペースの節約に役立ちます。