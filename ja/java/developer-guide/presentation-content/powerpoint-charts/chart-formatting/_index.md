---
title: チャートのフォーマット
type: docs
weight: 60
url: /java/chart-formatting/
---

## **チャートエンティティのフォーマット**
Aspose.Slides for Javaは、開発者がスライドにカスタムチャートを一から追加できるようにします。この記事では、チャートカテゴリと値軸を含む、さまざまなチャートエンティティのフォーマット方法を説明します。

Aspose.Slides for Javaは、さまざまなチャートエンティティを管理し、カスタム値を使用してフォーマットするためのシンプルなAPIを提供します：

1. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、任意の希望のタイプを指定します（この例ではChartType.LineWithMarkersを使用します）。
1. チャートの値軸にアクセスし、以下のプロパティを設定します：
   1. 値軸の主要なグリッドラインの**ラインフォーマット**を設定
   1. 値軸の小グリッドラインの**ラインフォーマット**を設定
   1. 値軸の**数値フォーマット**を設定
   1. 値軸の**最小、最大、主要および小単位**を設定
   1. 値軸データの**テキストプロパティ**を設定
   1. 値軸の**タイトル**を設定
   1. 値軸の**ラインフォーマット**を設定
1. チャートのカテゴリ軸にアクセスし、以下のプロパティを設定します：
   1. カテゴリ軸の主要なグリッドラインの**ラインフォーマット**を設定
   1. カテゴリ軸の小グリッドラインの**ラインフォーマット**を設定
   1. カテゴリ軸データの**テキストプロパティ**を設定
   1. カテゴリ軸の**タイトル**を設定
   1. カテゴリ軸の**ラベル位置**を設定
   1. カテゴリ軸ラベルの**回転角度**を設定
1. チャートの凡例にアクセスし、それらの**テキストプロパティ**を設定
1. チャートが重ならずに凡例を表示するよう設定
1. チャートの**二次値軸**にアクセスし、以下のプロパティを設定します：
   1. 二次**値軸**を有効にする
   1. 二次値軸の**ラインフォーマット**を設定
   1. 二次値軸の**数値フォーマット**を設定
   1. 二次値軸の**最小、最大、主要および小単位**を設定
1. それから、二次値軸に最初のチャートシリーズをプロットします
1. チャートの背面壁の塗りつぶし色を設定
1. チャートプロットエリアの塗りつぶし色を設定
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます

```java
// プレゼンテーションクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // サンプルチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // チャートタイトルを設定
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("サンプルチャート");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 値軸の主要なグリッドラインのフォーマットを設定
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // 値軸の小グリッドラインのフォーマットを設定
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 値軸の数値フォーマットを設定
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大値、最小値を設定
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // 値軸のテキストプロパティを設定
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // 値軸のタイトルを設定
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("プライマリー軸");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // カテゴリ軸の主要なグリッドラインのフォーマットを設定
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // カテゴリ軸の小グリッドラインのフォーマットを設定
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // カテゴリ軸のテキストプロパティを設定
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // カテゴリタイトルを設定
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("サンプルカテゴリ");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // カテゴリ軸ラベルの位置を設定
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // カテゴリ軸ラベルの回転角度を設定
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // 凡例のテキストプロパティを設定
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // チャートが重ならずに凡例を表示するよう設定

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 二次値軸を設定
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // 二次値軸の数値フォーマットを設定
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大値、最小値を設定
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // チャート背面壁の色を設定
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // プロットエリアの色を設定
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // プレゼンテーションを保存
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **チャートのフォントプロパティを設定**
Aspose.Slides for Javaは、チャートのフォント関連プロパティを設定するためのサポートを提供します。以下の手順に従って、チャートのフォントプロパティを設定してください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 修正されたプレゼンテーションを保存します。

以下のサンプル例が与えられています。

```java
// プレゼンテーションクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **数値のフォーマットを設定**
Aspose.Slides for Javaは、チャートデータフォーマットを管理するためのシンプルなAPIを提供します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、任意の希望のタイプを指定します（この例では**ChartType.ClusteredColumn**を使用します）。
1. 利用可能なプリセット値からプリセット数値フォーマットを設定します。
1. 各チャートシリーズ内のチャートデータセルをトラバースし、チャートデータ数値フォーマットを設定します。
1. プレゼンテーションを保存します。
1. カスタム数値フォーマットを設定します。
1. 各チャートシリーズ内のチャートデータセルをトラバースし、異なるチャートデータ数値フォーマットを設定します。
1. プレゼンテーションを保存します。

```java
// プレゼンテーションクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のプレゼンテーションスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのクラスタ化コラムチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // チャートシリーズコレクションにアクセス
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // 各チャートシリーズをトラバース
    for (IChartSeries ser : series) 
    {
        // シリーズ内の各データセルをトラバース
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // 数値フォーマットを設定
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // プレゼンテーションを保存
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

利用可能なプリセット数値フォーマット値とそのプリセットインデックスは以下の通りです：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **チャートエリアの角を丸く設定**
Aspose.Slides for Javaは、チャートエリアの設定をサポートします。メソッド[**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--)と[**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-)が[IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart)インターフェースと[Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart)クラスに追加されました。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗り方と塗りつぶし色を設定します
1. 角を丸くするプロパティをTrueに設定します。
1. 修正されたプレゼンテーションを保存します。

以下のサンプル例が与えられています。 

```java
// プレゼンテーションクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```