---
title: Android でプレゼンテーション チャートの書式設定
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/androidjava/chart-formatting/
keywords:
- チャートの書式設定
- チャートの書式設定
- チャート エンティティ
- チャート プロパティ
- チャート 設定
- チャート オプション
- フォント プロパティ
- 角丸境界
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java におけるチャートの書式設定を学び、プロフェッショナルで目を引くスタイリングにより PowerPoint プレゼンテーションを向上させましょう。"
---

## **チャートエンティティの書式設定**
Aspose.Slides for Android via Java を使用すると、開発者は最初からスライドにカスタムチャートを追加できます。本記事では、チャートのカテゴリ軸や値軸を含むさまざまなチャートエンティティの書式設定方法を説明します。

Aspose.Slides for Android via Java は、さまざまなチャートエンティティを管理し、カスタム値で書式設定するためのシンプルな API を提供します。

1. [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと任意のタイプのチャートを追加します（この例では ChartType.LineWithMarkers を使用します）。
1. チャートの値軸にアクセスし、次のプロパティを設定します：
   1. 値軸の主要グリッド線の**ライン形式**を設定します。
   1. 値軸の補助グリッド線の**ライン形式**を設定します。
   1. 値軸の**数値形式**を設定します。
   1. 値軸の**最小、最大、主要および補助単位**を設定します。
   1. 値軸データの**テキストプロパティ**を設定します。
   1. 値軸の**タイトル**を設定します。
   1. 値軸の**ライン形式**を設定します。
1. チャートのカテゴリ軸にアクセスし、次のプロパティを設定します：
   1. カテゴリ軸の主要グリッド線の**ライン形式**を設定します。
   1. カテゴリ軸の補助グリッド線の**ライン形式**を設定します。
   1. カテゴリ軸データの**テキストプロパティ**を設定します。
   1. カテゴリ軸の**タイトル**を設定します。
   1. カテゴリ軸の**ラベル位置**を設定します。
   1. カテゴリ軸ラベルの**回転角度**を設定します。
1. チャートの凡例にアクセスし、**テキストプロパティ**を設定します。
1. チャートが重ならないように凡例を表示します。
1. チャートの**二次値軸**にアクセスし、次のプロパティを設定します：
   1. 二次 **値軸** を有効にします。
   1. 二次値軸の**ライン形式**を設定します。
   1. 二次値軸の**数値形式**を設定します。
   1. 二次値軸の**最小、最大、主要および補助単位**を設定します。
1. 二次値軸に最初の系列をプロットします。
1. チャートの背面壁の塗りつぶし色を設定します。
1. チャートのプロット領域の塗りつぶし色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // サンプルチャートを追加する
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // チャートのタイトルを設定する
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 値軸の主要グリッド線の書式を設定する
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // 値軸の補助グリッド線の書式を設定する
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 値軸の数値形式を設定する
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大・最小値を設定する
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // 値軸のテキストプロパティを設定する
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // 値軸のタイトルを設定する
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // カテゴリ軸の主要グリッド線の書式を設定する
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // カテゴリ軸の補助グリッド線の書式を設定する
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // カテゴリ軸のテキストプロパティを設定する
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // カテゴリのタイトルを設定する
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // カテゴリ軸のラベル位置を設定する
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // カテゴリ軸のラベル回転角度を設定する
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // 凡例のテキストプロパティを設定する
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // チャートが重ならないように凡例を表示する
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 二次値軸を設定する
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // 二次値軸の数値形式を設定する
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大・最小値を設定する
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // チャートの背面壁の色を設定する
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // プロット領域の色を設定する
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // プレゼンテーションを保存する
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートのフォントプロパティの設定**
Aspose.Slides for Android via Java は、チャートのフォント関連プロパティを設定する機能を提供します。以下の手順でチャートのフォントプロパティを設定してください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。
```java
// Presentation クラスのインスタンスを作成する
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


## **数値形式の設定**
Aspose.Slides for Android via Java は、チャートデータ形式を管理するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと任意のタイプのチャートを追加します（この例では **ChartType.ClusteredColumn** を使用します）。
1. 可能なプリセット値から事前定義された数値形式を設定します。
1. 各シリーズのチャートデータセルを走査し、チャートデータの数値形式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値形式を設定します。
1. 各シリーズ内のチャートデータセルを走査し、異なる数値形式を設定します。
1. プレゼンテーションを保存します。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のプレゼンテーションスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのクラスター化された列チャートを追加する
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // チャートシリーズコレクションにアクセスする
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // すべてのチャートシリーズを走査する
    for (IChartSeries ser : series) 
    {
        // シリーズ内のすべてのデータセルを走査する
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // 数値形式を設定する
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // プレゼンテーションを保存する
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


以下に、使用できる可能なプリセット数値形式の値とそれぞれのインデックスを示します。

|**0**|General|
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

## **チャート領域の角丸境界の設定**
Aspose.Slides for Android via Java は、チャート領域の設定をサポートします。インターフェイス [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) とクラス [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart) に **hasRoundedCorners** と **setRoundedCorners** メソッドが追加されました。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
1. 角丸プロパティを True に設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。
```java
// Presentation クラスのインスタンスを作成する
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


## **FAQ**

**列や領域に半透明の塗りつぶしを設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度と輪郭は別々に設定できます。これにより、密集した可視化でグリッドやデータの可読性を向上させることができます。

**ラベルが重なった場合、どのように対処できますか？**

フォントサイズを小さくする、不要なラベル要素（例: カテゴリ）を非表示にする、ラベルのオフセット／位置を設定する、必要に応じて選択されたポイントのみラベルを表示する、または形式を「値＋凡例」に切り替えることができます。

**系列にグラデーションやパターンの塗りつぶしを適用できますか？**

はい。単色塗りつぶしだけでなく、グラデーションやパターン塗りつぶしも通常利用可能です。実際には、グラデーションは節度を持って使用し、グリッドやテキストとのコントラストが低下する組み合わせは避けてください。