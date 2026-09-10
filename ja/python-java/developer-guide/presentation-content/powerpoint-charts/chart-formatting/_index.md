---
title: Python でプレゼンテーションのチャートをフォーマット
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/python-java/chart-formatting/
keywords:
- チャートの書式設定
- チャートフォーマット
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸ボーダー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java でチャートの書式設定を学び、プロフェッショナルで目を引くスタイリングで PowerPoint プレゼンテーションを向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションのチャートを書式設定する方法を説明します。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなどの主要なチャート要素をカスタマイズして、チャートデータの外観と可読性を向上させる方法を示します。

また、チャートテキストのフォントプロパティの設定、チャートデータへのプリセットおよびカスタム数値形式の適用、チャート領域の角を丸める有効化方法も示します。これらの例を通じて、プレゼンテーション内のチャートのビジュアルスタイルとデータ表示の両方を制御する方法が分かります。

## **チャートエンティティの書式設定**
Aspose.Slides for Python via Java を使用すると、開発者はスライドにカスタムチャートをゼロから追加できます。この記事では、カテゴリ軸と値軸を含むさまざまなチャートエンティティの書式設定方法を説明します。

Aspose.Slides for Python via Java は、さまざまなチャートエンティティを管理し、カスタム値を使用して書式設定するためのシンプルな API を提供します：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドにアクセスします。
1. デフォルトデータで目的のタイプのチャートを追加します（この例では [ChartType.LineWithMarkers](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/#LineWithMarkers) を使用）。
1. チャートの値軸にアクセスし、以下のプロパティを設定します：
   1. **Line format** を値軸の主グリッド線に設定します。
   1. **Line format** を値軸の副グリッド線に設定します。
   1. **Number Format** を値軸に設定します。
   1. **minimum, maximum, major, and minor units** を値軸に設定します。
   1. **Text Properties** を値軸データに設定します。
   1. **Title** を値軸に設定します。
1. チャートのカテゴリ軸にアクセスし、以下のプロパティを設定します：
   1. **Line format** をカテゴリ軸の主グリッド線に設定します。
   1. **Line format** をカテゴリ軸の副グリッド線に設定します。
   1. **Text Properties** をカテゴリ軸データに設定します。
   1. **Title** をカテゴリ軸に設定します。
   1. **Label Positioning** をカテゴリ軸に設定します。
   1. **Rotation Angle** をカテゴリ軸ラベルに設定します。
1. チャートの凡例にアクセスし、**text properties** を設定します。
1. チャートと重ならないように凡例を表示します。
1. チャートの **secondary value axis** にアクセスし、以下のプロパティを設定します：
   1. **value axis** の二次軸を有効にします。
   1. **Line Format** を二次値軸に設定します。
   1. **Number Format** を二次値軸に設定します。
   1. **minimum, maximum, major, and minor units** を二次値軸に設定します。
1. 二次値軸上に最初のチャートシリーズをプロットします。
1. チャートの背面壁の塗りつぶし色を設定します。
1. チャートのプロット領域の塗りつぶし色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Presentation クラスのインスタンスを作成します
presentation = Presentation()
try:
    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # サンプルチャートを追加します
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # チャートのタイトルを設定します
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # 値軸の主グリッド線の書式を設定します
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # 値軸の副グリッド線の書式を設定します
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # 値軸の数値形式を設定します
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # チャートの最大値・最小値を設定します
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # 値軸のテキストプロパティを設定します
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # 値軸のタイトルを設定します
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # カテゴリ軸の主グリッド線の書式を設定します
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # カテゴリ軸の副グリッド線の書式を設定します
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # カテゴリ軸のテキストプロパティを設定します
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # カテゴリのタイトルを設定します
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # カテゴリ軸のラベル位置を設定します
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # カテゴリ軸のラベル回転角度を設定します
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # 凡例のテキストプロパティを設定します
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # チャートと重ならないように凡例を表示します

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # 二次値軸を設定します
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # 二次値軸の数値形式を設定します
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # チャートの最大値・最小値を設定します
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # チャートの背面壁の色を設定します
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # プロット領域の色を設定します
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # プレゼンテーションを保存します
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャートのフォントプロパティの設定**
Aspose.Slides for Python via Java は、チャートのフォントプロパティの設定をサポートします。以下の手順に従ってフォントプロパティを設定してください：

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 変更したプレゼンテーションを保存します。

以下の例はこれらの手順を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **数値形式の設定**
Aspose.Slides for Python via Java は、チャートデータ形式の管理のためのシンプルな API を提供します：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドにアクセスします。
1. デフォルトデータで目的のタイプのチャートを追加します（この例では [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/#ClusteredColumn) を使用）。
1. 利用可能なプリセット値から数値形式を設定します。
1. すべてのチャートシリーズのデータセルを繰り返し処理し、数値形式を設定します。
1. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します
presentation = Presentation()
try:
    # 最初のプレゼンテーション スライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # デフォルトのクラスタ化列チャートを追加します
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # チャートのシリーズコレクションにアクセスします
    chart_series_collection = chart.getChartData().getSeries()

    # すべてのチャートシリーズを反復処理します
    for chart_series in chart_series_collection:
        # シリーズ内のすべてのデータポイントを反復処理します
        for data_point in chart_series.getDataPoints():
            # 数値形式を設定します
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # プレゼンテーションを保存します
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

利用可能なプリセット数値形式とそのインデックスは以下の通りです：

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

## **チャート領域の角丸ボーダーの設定**
Aspose.Slides for Python via Java は、[Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/) クラスの [hasRoundedCorners](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#hasRoundedCorners) と [setRoundedCorners](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setRoundedCorners) メソッドを使用して、チャート領域の角丸をサポートします。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. チャートの枠線の塗りつぶしタイプとスタイルを設定します。
1. 角丸を有効にします。
1. 変更したプレゼンテーションを保存します。

以下の例はこれらの手順を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**列や領域の塗りつぶしを半透明にしつつ、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度とアウトラインは別々に設定できます。これは、密集した可視化においてグリッドとデータの可読性を向上させるのに役立ちます。

**ラベルが重なった場合、どう対処すればよいですか？**

フォントサイズを小さくする、不要なラベル要素（例：カテゴリ）を非表示にする、ラベルのオフセット/位置を調整する、必要に応じて選択されたポイントのみラベルを表示する、または形式を「値＋凡例」に切り替えるなどの方法があります。

**シリーズにグラデーションやパターン塗りつぶしを適用できますか？**

はい。単色塗りつぶしに加えて、グラデーションやパターン塗りつぶしも通常利用可能です。実務ではグラデーションは控えめに使用し、グリッドやテキストとのコントラストが低下しないよう組み合わせを避けてください。