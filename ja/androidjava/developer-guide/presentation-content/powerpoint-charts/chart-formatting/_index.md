---
title: チャートのフォーマット
type: docs
weight: 60
url: /androidjava/chart-formatting/
---

## **チャートエンティティのフォーマット**
Aspose.Slides for Android via Javaを使用すると、開発者はスライドにカスタムチャートをゼロから追加できます。この記事では、チャートカテゴリおよび値軸を含むさまざまなチャートエンティティをフォーマットする方法を説明します。

Aspose.Slides for Android via Javaは、さまざまなチャートエンティティを管理し、カスタム値を使用してフォーマットするためのシンプルなAPIを提供します：

1. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスによってスライドの参照を取得します。
1. デフォルトデータを持つ任意の希望するタイプのチャートを追加します（この例ではChartType.LineWithMarkersを使用します）。
1. チャートの値軸にアクセスして、次のプロパティを設定します：
   1. 値軸の主要グリッド線の**ラインフォーマット**を設定
   1. 値軸のマイナーグリッド線の**ラインフォーマット**を設定
   1. 値軸の**数字フォーマット**を設定
   1. 値軸の**最小、最大、主要およびマイナー単位**を設定
   1. 値軸データの**テキストプロパティ**を設定
   1. 値軸の**タイトル**を設定
   1. 値軸の**ラインフォーマット**を設定
1. チャートのカテゴリ軸にアクセスして、次のプロパティを設定します：
   1. カテゴリ軸の主要グリッド線の**ラインフォーマット**を設定
   1. カテゴリ軸のマイナーグリッド線の**ラインフォーマット**を設定
   1. カテゴリ軸データの**テキストプロパティ**を設定
   1. カテゴリ軸の**タイトル**を設定
   1. カテゴリ軸の**ラベル位置**を設定
   1. カテゴリ軸ラベルの**回転角度**を設定
1. チャートの凡例にアクセスし、それらの**テキストプロパティ**を設定します。
1. チャートと重ならないようにチャート凡例を表示します。
1. チャートの**セカンダリ値軸**にアクセスして、次のプロパティを設定します：
   1. セカンダリ**値軸**を有効にします。
   1. セカンダリ値軸の**ラインフォーマット**を設定します。
   1. セカンダリ値軸の**数字フォーマット**を設定します。
   1. セカンダリ値軸の**最小、最大、主要およびマイナー単位**を設定します。
1. 次に、セカンダリ値軸に最初のチャート系列をプロットします。
1. チャートのバックウォールの塗りつぶし色を設定します。
1. チャートのプロットエリアの塗りつぶし色を設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // サンプルチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // チャートタイトルの設定
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("サンプルチャート");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 値軸の主要グリッド線フォーマットの設定
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // 値軸のマイナーグリッド線フォーマットの設定
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 値軸の数字フォーマットの設定
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大、最小値設定
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // 値軸テキストプロパティの設定
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // 値軸タイトルの設定
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("プライマリー軸");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // カテゴリ軸の主要グリッド線フォーマットの設定
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // カテゴリ軸のマイナーグリッド線フォーマットの設定
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // カテゴリ軸テキストプロパティの設定
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // カテゴリタイトルの設定
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("サンプルカテゴリ");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // カテゴリ軸ラベル位置の設定
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // カテゴリ軸ラベル回転角度の設定
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // 凡例のテキストプロパティの設定
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // チャートと重ならないようにチャート凡例を表示

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // セカンダリ値軸の設定
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // セカンダリ値軸の数字フォーマットの設定
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大、最小値設定
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // チャートバックウォールの色を設定
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // プロットエリアの色設定
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // プレゼンテーションを保存
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **チャートのフォントプロパティを設定**
Aspose.Slides for Android via Javaは、チャートのフォント関連のプロパティを設定するサポートを提供します。以下の手順に従って、チャートのフォントプロパティを設定してください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 修正されたプレゼンテーションを保存します。

以下のサンプル例が示されています。

```java
// Presentationクラスのインスタンスを作成
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
Aspose.Slides for Android via Javaは、チャートデータフォーマットを管理するためのシンプルなAPIを提供します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスによってスライドの参照を取得します。
1. デフォルトデータを持つ任意の希望するタイプのチャートを追加します（この例では**ChartType.ClusteredColumn**を使用します）。
1. 使用可能なプリセット値からプリセット数字フォーマットを設定します。
1. 各チャート系列のチャートデータセルをトラバースし、チャートデータ数字フォーマットを設定します。
1. プレゼンテーションを保存します。
1. カスタム数字フォーマットを設定します。
1. 各チャート系列内のチャートデータセルをトラバースし、異なるチャートデータ数字フォーマットを設定します。
1. プレゼンテーションを保存します。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のプレゼンテーションスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのクラスター化されたカラムチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // チャート系列コレクションにアクセス
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // 各チャート系列をトラバース
    for (IChartSeries ser : series) 
    {
        // 各系列のデータセルをトラバース
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // 数字フォーマットの設定
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // プレゼンテーションの保存
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

使用可能なプリセット数字フォーマット値と、そのプリセットインデックスは以下の通りです：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;赤$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;赤$-#,##0.00|
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
|**38**|#,##0;赤-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;赤-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **チャートエリアの丸みを帯びた境界を設定**
Aspose.Slides for Android via Javaは、チャートエリアを設定するサポートを提供します。メソッド [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) と [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) が [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) インターフェイスと [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart) クラスに追加されました。 

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
1. 丸角プロパティをTrueに設定します。
1. 修正されたプレゼンテーションを保存します。

以下のサンプル例が示されています。

```java
// Presentationクラスのインスタンスを作成
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