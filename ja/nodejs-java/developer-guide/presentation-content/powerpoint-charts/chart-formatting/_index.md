---
title: チャート書式設定
type: docs
weight: 60
url: /ja/nodejs-java/chart-formatting/
---

## **チャートエンティティの書式設定**

Aspose.Slides for Node.js via Java では、開発者はスライドにカスタムチャートをゼロから追加できます。本記事では、チャートのカテゴリ軸と値軸を含むさまざまなチャートエンティティの書式設定方法を説明します。

Aspose.Slides for Node.js via Java は、さまざまなチャートエンティティを管理し、カスタム値で書式設定するためのシンプルな API を提供します。

1. **Presentation** クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルト データと任意のタイプ（この例では ChartType.LineWithMarkers）でチャートを追加します。
4. チャートの 値軸 にアクセスし、次のプロパティを設定します。
   1. 値軸 主グリッド線の **Line format** を設定
   2. 値軸 副グリッド線の **Line format** を設定
   3. 値軸の **Number Format** を設定
   4. 値軸の **Min, Max, Major and Minor units** を設定
   5. 値軸データの **Text Properties** を設定
   6. 値軸の **Title** を設定
   7. 値軸の **Line Format** を設定
5. チャートの カテゴリ軸 にアクセスし、次のプロパティを設定します。
   1. カテゴリ軸 主グリッド線の **Line format** を設定
   2. カテゴリ軸 副グリッド線の **Line format** を設定
   3. カテゴリ軸データの **Text Properties** を設定
   4. カテゴリ軸の **Title** を設定
   5. カテゴリ軸の **Label Positioning** を設定
   6. カテゴリ軸ラベルの **Rotation Angle** を設定
6. チャートの 凡例 にアクセスし、**Text Properties** を設定します。
7. 凡例が重ならないようにチャート凡例の表示を設定します。
8. チャートの **Secondary Value Axis** にアクセスし、次のプロパティを設定します。
   1. 二次 **Value Axis** を有効化
   2. 二次値軸の **Line Format** を設定
   3. 二次値軸の **Number Format** を設定
   4. 二次値軸の **Min, Max, Major and Minor units** を設定
9. 最初のチャート シリーズを二次値軸にプロットします。
10. チャートの背面壁の塗りつぶし色を設定します。
11. チャートのプロット領域の塗りつぶし色を設定します。
12. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```javascript
    // Presentation クラスのインスタンスを作成
    var pres = new aspose.slides.Presentation();
    try {
        // 最初のスライドにアクセス
        var slide = pres.getSlides().get_Item(0);
        // サンプルチャートを追加
        var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
        // チャートのタイトルを設定
        chart.hasTitle();
        chart.getChartTitle().addTextFrameForOverriding("");
        var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
        chartTitle.setText("Sample Chart");
        chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        chartTitle.getPortionFormat().setFontHeight(20);
        chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // 値軸の主要グリッド線の書式を設定
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
        // 値軸の副グリッド線の書式を設定
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
        // 値軸の数値書式を設定
        chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
        chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
        chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
        // チャートの最大値・最小値を設定
        chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
        chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
        chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
        chart.getAxes().getVerticalAxis().isAutomaticMinValue();
        chart.getAxes().getVerticalAxis().setMaxValue(15.0);
        chart.getAxes().getVerticalAxis().setMinValue(-2.0);
        chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
        chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
        // 値軸のテキストプロパティを設定
        var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
        txtVal.setFontBold(aspose.slides.NullableBool.True);
        txtVal.setFontHeight(16);
        txtVal.setFontItalic(aspose.slides.NullableBool.True);
        txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
        txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        // 値軸のタイトルを設定
        chart.getAxes().getVerticalAxis().hasTitle();
        chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
        var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
        valtitle.setText("Primary Axis");
        valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        valtitle.getPortionFormat().setFontHeight(20);
        valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // カテゴリ軸の主要グリッド線の書式を設定
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
        // カテゴリ軸の副グリッド線の書式を設定
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
        // カテゴリ軸のテキストプロパティを設定
        var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
        txtCat.setFontBold(aspose.slides.NullableBool.True);
        txtCat.setFontHeight(16);
        txtCat.setFontItalic(aspose.slides.NullableBool.True);
        txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
        // カテゴリのタイトルを設定
        chart.getAxes().getHorizontalAxis().hasTitle();
        chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
        var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
        catTitle.setText("Sample Category");
        catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        catTitle.getPortionFormat().setFontHeight(20);
        catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // カテゴリ軸ラベルの位置を設定
        chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
        // カテゴリ軸ラベルの回転角度を設定
        chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
        // 凡例のテキストプロパティを設定
        var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
        txtleg.setFontBold(aspose.slides.NullableBool.True);
        txtleg.setFontHeight(16);
        txtleg.setFontItalic(aspose.slides.NullableBool.True);
        txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
        // チャートが重ならないように凡例を表示設定
        chart.getLegend().setOverlay(true);
        // chart.ChartData.Series[0].PlotOnSecondAxis=true;
        chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
        // 二次値軸を設定
        chart.getAxes().getSecondaryVerticalAxis().isVisible();
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
        // 二次値軸の数値書式を設定
        chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
        chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
        chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
        // チャートの最大値・最小値を設定
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
        chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
        chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
        chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
        chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
        // チャートの背面壁の色を設定
        chart.getBackWall().setThickness(1);
        chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
        chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
        // プロット領域の色を設定
        chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
        // プレゼンテーションを保存
        pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **チャートのフォント プロパティを設定**

Aspose.Slides for Node.js via Java は、チャートのフォント関連プロパティを設定する機能を提供します。以下の手順に従ってチャートのフォント プロパティを設定してください。

- **Presentation** クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **数値の書式設定**

Aspose.Slides for Node.js via Java は、チャート データの書式を管理するシンプルな API を提供します。

1. **Presentation** クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルト データと任意のタイプ（この例では **ChartType.ClusteredColumn**）でチャートを追加します。
4. 可能なプリセット値から事前設定の数値書式を設定します。
5. 各チャート シリーズのデータセルを走査し、チャート データの数値書式を設定します。
6. プレゼンテーションを保存します。
7. カスタム数値書式を設定します。
8. 各チャート シリーズ内のデータセルを走査し、異なる数値書式を設定します。
9. プレゼンテーションを保存します。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のプレゼンテーション スライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // デフォルトのクラスター カラム チャートを追加
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // チャートのシリーズ コレクションにアクセス
    var series = chart.getChartData().getSeries();
    // すべてのチャート シリーズを走査
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // シリーズ内のすべてのデータ セルを走査
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // 数値書式を設定
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // プレゼンテーションを保存
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


使用できる可能なプリセット数値書式値とそのインデックスは以下のとおりです。

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

## **チャート領域の角丸枠を設定**

Aspose.Slides for Node.js via Java は、チャート領域の設定をサポートします。メソッド **hasRoundedCorners** と **setRoundedCorners** が **Chart** クラスに追加されました。

1. **Presentation** クラスのオブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
4. 角丸プロパティを **True** に設定します。
5. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**列/領域に半透明塗りつぶしを設定し、枠線は不透明に保つことはできますか？**

はい。塗りつぶしの透明度と輪郭は別々に設定できます。これにより、グリッドやデータが密集した可視化において読みやすさが向上します。

**ラベルが重なったときの対処方法は？**

フォントサイズを小さくする、重要でないラベル要素（例: カテゴリ）を無効にする、ラベルのオフセット/位置を設定する、必要に応じて選択したポイントのみラベルを表示する、または「値 + 凡例」形式に切り替えるなどの方法があります。

**系列にグラデーションまたはパターン塗りつぶしを適用できますか？**

はい。単色塗りつぶしと同様に、グラデーションやパターン塗りつぶしも利用可能です。実務ではグラデーションの使用は控えめにし、グリッドやテキストとのコントラストが低下しない組み合わせを避けてください。