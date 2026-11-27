---
title: Python でプレゼンテーションのチャートをフォーマットする
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/python-java/chart-formatting/
keywords:
- チャートの書式設定
- チャート書式設定
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸境界線
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Java 経由で Python 用 Aspose.Slides のチャート書式設定を学び、カスタム軸、フォント、数値形式、角丸チャート境界線で PowerPoint プレゼンテーションを向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションのチャートの書式設定方法を説明します。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなどの主要なチャート要素をカスタマイズし、チャートデータの外観と可読性を向上させる方法を示します。

さらに、チャートテキストのフォントプロパティの設定、チャートデータへの事前設定数値形式の適用、チャート領域の角丸化の有効化方法も示します。これらの例は、プレゼンテーション内のチャートの視覚的スタイルとデータ表示の両方を制御する方法を示しています。

上昇および下降区間の塗りつぶしとアウトラインを別々に設定する方法については、[株価チャート例](/slides/ja/python-java/create-chart/#create-stock-charts)をご覧ください。

## **チャート要素の書式設定**

チャートのタイトル、軸、グリッド線、凡例、プロット領域の書式設定には、[Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) を使用します。この例では、マーカー付きの折れ線グラフをデフォルトデータで作成し、値軸とカテゴリ軸に別々のテキストおよび線のスタイルを適用します。フォントサイズと線幅はポイントで指定され、カテゴリラベルは 45 度回転します。

値軸はソースセルに依存せず [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) を使用します。目盛りは -2 から 15 までで、メジャー間隔が 2、マイナー間隔が 0.5 です。また、例ではパーセンテージ書式と [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) を千単位に設定した組み合わせも示していますので、データの意味と規模に合わせて設定を調整してください。凡例は [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) を `False` で呼び出すためプロット領域の外側に表示されます。バックウォールとフロアの塗りつぶしはそれぞれ [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) と [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) で構成されますが、これらの面は 3D チャートでのみ表示されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャートのフォントプロパティの設定**

チャートテキストの既定フォントサイズは [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) を介して設定します。この例では、20 ポイント フォントのクラスター化された縦棒グラフを作成し、最初の系列に対して [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) を使用して値ラベルを有効にします。独自の明示的なフォント設定を持つテキスト要素は、チャートの既定設定を上書きできます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート凡例のテキストフレーム書式の再利用**

凡例をスライドの見出しに合わせるには、最初の段落の [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) で見出しのフォントを設定します。凡例の [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) が返す書式に対して [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) を呼び出します。これによりテキストフレーム設定、最初の段落の書式、およびその段落の既定フォントプロパティがコピーされます。個々の部分や後続の段落に直接適用された書式は、ソースにローカルに残ります。

例では、太字・26 ポイントの Calibri 見出し（ネイビー）をテンプレートとして使用しています。凡例を装飾した後、[copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) を呼び出して別のキャプションにも同じ書式を適用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存されたプレゼンテーションでは、凡例とキャプションが見出しとサイズ、太さ、色で一致しています。凡例は依然として系列名を表示し、キャプションは独自のテキストを保持します。キャプション内の部分に明示的なフォントサイズが設定されている場合、そのサイズがコピーされた段落の既定よりも優先されます。

| コピー前 | コピー後 |
| --- | --- |
| ![四半期別売上チャート（黒い凡例ラベルと黒いキャプション）](legend-formatting-before.png) | ![同じチャート（大きく太字のネイビー凡例ラベルと一致するキャプション）](legend-formatting.png) |

## **数値形式の設定**

[ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) を使用して、チャートワークブックセルに組み込みの数値形式を適用します。この例では、デフォルトのセルベースデータを持つクラスター化された縦棒グラフを作成し、各系列の値セルに書式インデックス 10 (`0.00%`) を適用します。この設定はワークブック内の表示方法を変更しますが、元の数値は変更されません。たとえば、0.25 は 25.00% と表示されます。軸とデータラベルの書式は別々に構成できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下の表は、英語（米国）ロケール向けの代表的な Excel 書式とともに組み込み数値形式インデックスを一覧化したものです。正確な書式文字列と表示はアプリケーションやロケールによって異なる場合があり、特に通貨や日付では差異が生じます。一部の Excel 書式は OOXML 標準の既定と異なることがあり、詳細は [Microsoft の数値形式実装ノート](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) に記載されています。

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **チャート領域の角丸境界線の設定**

[Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) に `True` を指定して、チャート領域の角を丸めます。この例では、クラスター化された縦棒グラフを作成し、[getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) を使用して輪郭に単色のグレーと単線スタイルを設定した後、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **既存のチャート注釈の編集**

チャートには、レポートの状態を説明するテキスト注釈などのカスタム形状を含めることができます。これらの形状は [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes) を介して取得します。 [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) が返すコレクションには、チャートが所有する形状が含まれます。

チャート上に配置された普通のテキストボックスはスライドに属し、チャートの一部に見えてもスライドの所有物です。 [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) を反復処理すると、チャートと普通のスライド形状が見つかりますが、チャート内部の個々の形状は列挙されません。チャートタイトルやデータラベルは別個のチャート要素であり、このコレクション内のカスタム注釈ではありません。

[chart-annotations.pptx](chart-annotations.pptx) をダウンロードしてアプリケーションの作業ディレクトリに配置します。最初のスライドには「Preliminary results」という注釈、チャート所有の線、そして「Slide overlay」というテキストボックスが含まれています。例ではそのスライド上の最初のチャートを取得し、レポートが公開準備できたときに注釈を「Final results」に変更します。空コレクションをチェックし、[AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) の [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) が `None` でないテキストフレームを持つ場合にのみ、期待されるテキストと照合して編集します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

線とスライドのテキストボックスは変更されません。以下の画像は入力と保存後に再度開いた結果を示しています。

| 編集前 | 編集後 |
| --- | --- |
| ![「Preliminary results」注釈付きチャート](chart-annotations-before.png) | ![「Final results」注釈付きチャート](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
例はトップレベルのチャート所有形状のみを調べます。注釈が [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) 内にある場合は、そのグループの [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) コレクションも調べてください。入れ子になったグループについては再帰的に同じテキストチェックを子形状に適用します。グループ自体はコンテナであり、テキストボックスとして扱わないでください。
{{% /alert %}}

## **よくある質問**

**列や領域に半透明の塗りつぶしを設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度と輪郭は個別に設定できます。これにより、密集したビジュアライゼーションでグリッドやデータの可読性を向上させることができます。

**データラベルが重なった場合、どう対処すればよいですか？**

フォントサイズを縮小する、不要なラベル要素（たとえばカテゴリ）を無効にする、ラベル位置を調整する、必要に応じて選択ポイントのみラベルを表示する、またはフォーマットを「値 + 凡例」に切り替える方法があります。

**系列にグラデーションやパターン塗りつぶしを適用できますか？**

はい。系列は単色、グラデーション、パターン塗りつぶしをサポートします。実務ではグラデーションは控えめに使用し、グリッドやテキストとのコントラストを損なう組み合わせは避けてください。