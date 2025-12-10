---
title: Java を使用してプレゼンテーションのチャート軸をカスタマイズする
linktitle: チャート軸
type: docs
url: /ja/java/chart-axis/
keywords:
- チャート軸
- 縦軸
- 横軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸プロパティ
- 最大値
- 最小値
- 軸線
- 日付形式
- 軸タイトル
- 軸の位置
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "レポートや可視化のために、PowerPoint プレゼンテーションのチャート軸をカスタマイズする方法を Aspose.Slides for Java を使用して学びましょう。"
---

## **チャートの縦軸の最大値を取得**
Aspose.Slides for Java は、縦軸の最小値と最大値を取得できます。以下の手順を実行してください：

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Access the first slide.
3. Add a chart with default data.
4. Get the actual maximum value on the axis.
5. Get the actual minimum value on the axis.
6. Get the actual major unit of the axis.
7. Get the actual minor unit of the axis.
8. Get the actual major unit scale of the axis.
9. Get the actual minor unit scale of the axis.

このサンプルコード（上記手順の実装）は、Java で必要な値を取得する方法を示しています：
```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// プレゼンテーションを保存します
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **軸間のデータを入れ替える**
Aspose.Slides を使用すると、軸間のデータを簡単に入れ替えることができます。縦軸（y 軸）のデータが横軸（x 軸）に、逆も同様に移動します。

この Java コードは、チャートの軸間でデータを入れ替える方法を示しています：
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//行と列を入れ替えます
	chart.getChartData().switchRowColumn();

	// プレゼンテーションを保存します
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **折れ線グラフの縦軸を無効にする**

この Java コードは、折れ線グラフの縦軸を非表示にする方法を示しています：
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **折れ線グラフの横軸を無効にする**

このコードは、折れ線グラフの横軸を非表示にする方法を示しています：
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **カテゴリ軸を変更する**

**CategoryAxisType** プロパティを使用すると、希望するカテゴリ軸タイプ（**date** または **text**）を指定できます。以下の Java コードはこの操作を示しています： 
```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```


## **カテゴリ軸値の日時形式を設定する**
Aspose.Slides for Java は、カテゴリ軸の値に対して日時形式を設定できます。この操作は以下の Java コードで示されています：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```


## **チャート軸タイトルの回転角度を設定する**
Aspose.Slides for Java は、チャート軸タイトルの回転角度を設定できます。この Java コードはその操作を示しています：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```


## **カテゴリ軸または値軸の位置を設定する**
Aspose.Slides for Java は、カテゴリ軸または値軸の位置を設定できます。この Java コードはその手順を示しています：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートの値軸にディスプレイ単位ラベルを有効にする**
Aspose.Slides for Java は、チャートの値軸に単位ラベルを表示するよう設定できます。この Java コードはその操作を示しています：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**軸が他の軸と交差する値（軸の交差点）を設定するにはどうすればよいですか？**

軸には [crossing setting](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) が用意されており、0、最大カテゴリ/値、または特定の数値で交差させるかを選択できます。これにより、X 軸を上下にシフトしたり、基準線を強調したりするのに便利です。

**軸ラベル（目盛ラベル）を軸に対してどの位置に配置できますか（横、外側、内側）？**

[label position](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) を「cross」「outside」「inside」のいずれかに設定します。これにより可読性が向上し、特に小さなチャートではスペースを節約できます。