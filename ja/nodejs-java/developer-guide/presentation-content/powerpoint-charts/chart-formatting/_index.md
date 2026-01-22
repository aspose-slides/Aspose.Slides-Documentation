---
title: JavaScriptでプレゼンテーションチャートをフォーマットする
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/nodejs-java/chart-formatting/
keywords:
- チャートの書式設定
- チャート書式設定
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸ボーダー
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js 用 Aspose.Slides の JavaScript でのチャート書式設定を学び、プロフェッショナルで目を引くスタイリングにより PowerPoint プレゼンテーションを向上させましょう。"
---

## **チャートエンティティの書式設定**

Aspose.Slides for Node.js via Java を使用すると、開発者はスライドにカスタムチャートをゼロから追加できます。この記事では、チャートのカテゴリ軸と値軸を含むさまざまなチャートエンティティの書式設定方法を説明します。

Aspose.Slides for Node.js via Java は、さまざまなチャートエンティティを管理し、カスタム値を使用して書式設定するためのシンプルな API を提供します。

1. [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと任意のタイプ（この例では ChartType.LineWithMarkers を使用）でチャートを追加します。
4. チャートの値軸にアクセスし、以下のプロパティを設定します。
   1. 値軸の主要グリッド線の **Line format** を設定します。
   2. 値軸の副次グリッド線の **Line format** を設定します。
   3. 値軸の **Number Format** を設定します。
   4. 値軸の **Min, Max, Major and Minor units** を設定します。
   5. 値軸データの **Text Properties** を設定します。
   6. 値軸の **Title** を設定します。
   7. 値軸の **Line Format** を設定します。
5. チャートのカテゴリ軸にアクセスし、以下のプロパティを設定します。
   1. カテゴリ軸の主要グリッド線の **Line format** を設定します。
   2. カテゴリ軸の副次グリッド線の **Line format** を設定します。
   3. カテゴリ軸データの **Text Properties** を設定します。
   4. カテゴリ軸の **Title** を設定します。
   5. カテゴリ軸の **Label Positioning** を設定します。
   6. カテゴリ軸ラベルの **Rotation Angle** を設定します。
6. チャートの凡例にアクセスし、**Text Properties** を設定します。
7. チャートが重ならないように凡例の表示を設定します。
8. チャートの **Secondary Value Axis** にアクセスし、以下のプロパティを設定します。
   1. セカンダリ **Value Axis** を有効にします。
   2. セカンダリ値軸の **Line Format** を設定します。
   3. セカンダリ値軸の **Number Format** を設定します。
   4. セカンダリ値軸の **Min, Max, Major and Minor units** を設定します。
9. まず、最初のチャート系列をセカンダリ値軸にプロットします。
10. チャートの背面壁の塗りつぶし色を設定します。
11. チャートのプロット領域の塗りつぶし色を設定します。
12. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。
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
    // 値軸の主グリッド線の書式を設定
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
    // チャートの最大・最小値を設定
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
    // カテゴリ軸の主グリッド線の書式を設定
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
    // カテゴリタイトルを設定
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // カテゴリ軸ラベル位置を設定
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
    // チャートが重ならないように凡例を表示
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
    // チャートの最大・最小値を設定
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


## **チャートのフォントプロパティの設定**

Aspose.Slides for Node.js via Java は、チャートのフォント関連プロパティを設定する機能を提供します。以下の手順に従ってチャートのフォントプロパティを設定してください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 変更したプレゼンテーションを保存します。

以下にサンプル例を示します。
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

Aspose.Slides for Node.js via Java は、チャートデータの書式を管理するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと任意のタイプ（この例では **ChartType.ClusteredColumn** を使用）でチャートを追加します。
4. 可能なプリセット値から既定の数値書式を設定します。
5. 各チャート系列のチャートデータセルを走査し、チャートデータの数値書式を設定します。
6. プレゼンテーションを保存します。
7. カスタム数値書式を設定します。
8. 各チャート系列のチャートデータセルを走査し、異なる数値書式を設定します。
9. プレゼンテーションを保存します。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のプレゼンテーションスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // デフォルトのクラスター化列チャートを追加
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // チャート系列コレクションにアクセス
    var series = chart.getChartData().getSeries();
    // 各チャート系列を走査
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // 系列内のすべてのデータセルを走査
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


使用できる可能なプリセット数値書式とそのインデックスは以下の通りです。

|**0**|標準|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **チャートエリアの角丸設定**

Aspose.Slides for Node.js via Java は、チャートエリアの設定をサポートします。[**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) と [**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) メソッドが [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart) クラスに追加されました。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのオブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
4. 角丸プロパティを True に設定します。
5. 変更したプレゼンテーションを保存します。

以下にサンプル例を示します。  
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

**列やエリアの半透明塗りつぶしを設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度とアウトラインは別々に設定できます。これは、密集したビジュアライゼーションにおいてグリッドとデータの可読性を向上させるのに役立ちます。

**ラベルが重なった場合、どのように対処できますか？**

フォントサイズを小さくする、不要なラベル要素（例: カテゴリ）を無効にする、ラベルのオフセット/位置を設定する、必要に応じて選択されたポイントだけラベルを表示する、または「値 + 凡例」の形式に切り替える、といった方法があります。

**系列に対してグラデーションやパターン塗りつぶしを適用できますか？**

はい。通常、単色塗りつぶしとグラデーション/パターン塗りつぶしの両方が利用可能です。実務では、グラデーションは控えめに使用し、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。