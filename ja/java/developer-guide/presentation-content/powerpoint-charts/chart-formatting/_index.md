---
title: Javaでプレゼンテーションのチャートをフォーマットする
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/java/chart-formatting/
keywords:
- チャートのフォーマット
- チャートの書式設定
- チャートエンティティ
- チャート プロパティ
- チャート設定
- チャートオプション
- フォント プロパティ
- 丸みを帯びた境界線
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java におけるチャートの書式設定を学び、プロフェッショナルで目を引くスタイリングで PowerPoint プレゼンテーションを向上させましょう。"
---

## **チャート エンティティの書式設定**
Aspose.Slides for Java を使用すると、開発者はスライドにカスタムチャートを最初から追加できます。この記事では、チャートのカテゴリ軸や値軸を含むさまざまなチャートエンティティの書式設定方法を説明します。

Aspose.Slides for Java は、さまざまなチャートエンティティを管理し、カスタム値を使用して書式設定するためのシンプルな API を提供します。

1. [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータを持つチャートを、任意のタイプで追加します（この例では ChartType.LineWithMarkers を使用します）。
1. チャートの値軸にアクセスし、以下のプロパティを設定します：
   1. 値軸の主要グリッド線の **Line format** を設定します
   1. 値軸の副グリッド線の **Line format** を設定します
   1. 値軸の **Number Format** を設定します
   1. 値軸の **Min, Max, Major and Minor units** を設定します
   1. 値軸データの **Text Properties** を設定します
   1. 値軸の **Title** を設定します
   1. 値軸の **Line Format** を設定します
1. チャートのカテゴリ軸にアクセスし、以下のプロパティを設定します：
   1. カテゴリ軸の主要グリッド線の **Line format** を設定します
   1. カテゴリ軸の副グリッド線の **Line format** を設定します
   1. カテゴリ軸データの **Text Properties** を設定します
   1. カテゴリ軸の **Title** を設定します
   1. カテゴリ軸の **Label Positioning** を設定します
   1. カテゴリ軸ラベルの **Rotation Angle** を設定します
1. チャートの凡例にアクセスし、**Text Properties** を設定します
1. チャートと重ならないように凡例を表示します
1. チャートの **Secondary Value Axis** にアクセスし、以下のプロパティを設定します：
   1. セカンダリ **Value Axis** を有効にします
   1. セカンダリ値軸の **Line Format** を設定します
   1. セカンダリ値軸の **Number Format** を設定します
   1. セカンダリ値軸の **Min, Max, Major and Minor units** を設定します
1. セカンダリ値軸上に最初のチャート系列をプロットします
1. チャートの背面壁の塗りつぶし色を設定します
1. チャートのプロット領域の塗りつぶし色を設定します
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // サンプルチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // チャートのタイトルを設定
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 値軸の主要グリッド線の書式を設定
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // 値軸の副グリッド線の書式を設定
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 値軸の数値書式を設定
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大・最小値を設定
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
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // カテゴリ軸の主要グリッド線の書式を設定
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // カテゴリ軸の副グリッド線の書式を設定
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

    // カテゴリのタイトルを設定
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
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

    // チャートと重ならないように凡例を表示
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 副値軸を設定
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // 副値軸の数値書式を設定
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // チャートの最大・最小値を設定
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // チャートの背面壁の色を設定
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // プロット領域の色を設定
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // プレゼンテーションを保存
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **チャートのフォント プロパティの設定**
Aspose.Slides for Java は、チャートのフォント関連プロパティの設定をサポートしています。以下の手順に従ってチャートのフォントプロパティを設定してください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 変更したプレゼンテーションを保存します。

以下にサンプル例が示されています。
```java
// Presentation クラスのインスタンスを作成
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


## **数値フォーマットの設定**
Aspose.Slides for Java は、チャートデータのフォーマットを管理するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータを持つチャートを任意のタイプで追加します（この例では **ChartType.ClusteredColumn** を使用します）。
1. 利用可能なプリセット値からプリセット番号フォーマットを設定します。
1. すべてのチャート系列のチャートデータセルを走査し、チャートデータの番号フォーマットを設定します。
1. プレゼンテーションを保存します。
1. カスタム番号フォーマットを設定します。
1. すべてのチャート系列のチャートデータセルを走査し、異なる番号フォーマットを設定します。
1. プレゼンテーションを保存します。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のプレゼンテーションスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのクラスター化された縦棒グラフを追加
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // チャートの系列コレクションにアクセス
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // すべてのチャート系列を走査
    for (IChartSeries ser : series) 
    {
        // 系列内のすべてのデータセルを走査
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // 数値書式を設定
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // プレゼンテーションを保存
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


以下に、使用できる可能なプリセット番号フォーマットとそのインデックスを示します。

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

## **チャートエリアの丸みを帯びた境界線の設定**
Aspose.Slides for Java は、チャートエリアの設定をサポートしています。メソッド [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) と [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) が、[IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) インターフェイスと [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart) クラスに追加されました。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗りつぶしタイプと塗りつぶし色を設定します
1. 丸みのあるコーナー プロパティを True に設定します。
1. 変更したプレゼンテーションを保存します。

以下にサンプル例が示されています。  
```java
// Presentation クラスのインスタンスを作成
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


## **よくある質問**

**列/エリアの塗りつぶしを半透明に設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度とアウトラインは個別に設定できます。これは、密集した可視化においてグリッドとデータの可読性を向上させるのに有用です。

**データラベルが重なった場合、どう対処すればよいですか？**

フォントサイズを小さくする、不要なラベル要素（例: カテゴリ）を無効にする、ラベルのオフセット/位置を設定する、必要に応じて選択したポイントのみラベルを表示する、またはフォーマットを「値 + 凡例」に切り替えるといった方法があります。

**系列にグラデーションやパターン塗りつぶしを適用できますか？**

はい。通常、単色塗りつぶしとグラデーション/パターン塗りつぶしの両方が利用可能です。実際には、グラデーションは控えめに使用し、グリッドやテキストとのコントラストが低下する組み合わせは避けてください。