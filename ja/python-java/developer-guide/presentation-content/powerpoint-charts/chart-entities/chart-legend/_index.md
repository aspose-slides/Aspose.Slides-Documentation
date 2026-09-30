---
title: Python を使用したプレゼンテーションのチャート凡例のカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/python-java/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してチャート凡例をカスタマイズし、調整された凡例書式で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for Python via Java は、PowerPoint プレゼンテーションのチャート凡例をカスタマイズするオプションを提供します。本記事では、凡例の位置とサイズの指定、凡例全体のフォントサイズの設定、個々の凡例エントリの書式設定、選択したエントリの非表示または復元方法を示します。

FAQ では、凡例のためにスペースを確保する、複数行ラベルを表示する、プレゼンテーションテーマから書式を継承する、といった関連動作について説明します。

## **凡例の位置指定**

凡例の位置とサイズをチャートの寸法に対する割合で指定するには、凡例の [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth), および [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) メソッドを使用します。

この例では、プレゼンテーションを作成し、デフォルトデータのクラスター化された縦棒グラフを最初のスライドに追加します。凡例のオフセットとサイズをチャートの幅と高さで割ることで相対値に変換します。凡例はチャートの左上隅から 50 ポイントオフセットされ、サイズは 100×100 ポイントになります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # 凡例の位置とサイズをチャートに対して相対的に指定します。
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **凡例のフォントサイズの設定**

凡例のテキスト書式にアクセスするには legend の [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) を使用し、フォントサイズをポイントで設定するには [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) を使用します。

この例では、デフォルトデータのチャートを作成し、凡例のテキストを 20 ポイントに設定します。また、垂直軸の自動範囲を無効にし、範囲を -5 から 10 に設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **個別の凡例エントリのフォントサイズの設定**

特定のエントリの書式にアクセスするには、凡例の [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) メソッドが返すコレクションを使用します。エントリのインデックスは 0 から始まるため、インデックス `1` は 2 番目のエントリを指します。

この例では、デフォルトデータに少なくとも 2 つの系列が含まれるクラスター化縦棒グラフを作成します。2 番目の凡例エントリを太字、斜体、20 ポイントの青色テキストで書式設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **個別の凡例エントリの非表示**

補助系列をデータは表示したまま凡例から除外するには、[ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry) を介して [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) を `True` に設定します。これにより選択した凡例エントリのみが非表示になり、系列やデータ ポイントは削除されません。[Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) を `False` に設定すると、凡例全体が非表示になる点に注意してください。

以下の例では、デフォルトデータを使用して複数系列のクラスター化縦棒グラフを作成します。2 番目の系列の凡例エントリ (インデックス `1`) を非表示にし、プレゼンテーションを保存します。その後、[setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) を `False` で呼び出してエントリを復元し、2 個目のコピーを保存します。両方のファイルで列は表示されたままです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # チャートデータを変更せずに同じエントリを復元します。
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

下の比較は、すべてのエントリが表示され、シリーズ 2 が凡例から非表示になったチャートの比較; すべての列は表示されたままです。

![すべての凡例エントリが表示され、シリーズ 2 が凡例から非表示になったチャートの比較; すべての列は表示されたまま。](hide-legend-entry.png)

列、棒、折れ線グラフでは、凡例エントリは系列を識別します。円グラフの場合、エントリは個々のデータポイント（スライス）を識別するため、選択したスライスに対して [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) を使用してください。API はこのデータポイント メソッドを `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie`、`BarOfPie` の各チャートタイプでドキュメント化しています。ドーナツ グラフには適用されないことに注意してください。

## **FAQ**

**チャートが凡例の上に重ねるのではなく、凡例のためにスペースを確保するようにできますか？**  
はい。`False` を指定して [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) を呼び出すと、凡例がプロット領域と重なるのを防ぎ、スペースを確保します。

**複数行の凡例ラベルを作成できますか？**  
はい。利用可能な幅が不足している場合、長いラベルは自動的に折り返されます。また、系列名に改行文字を入れることで改行を要求することもできます。

**凡例をプレゼンテーションテーマの配色に合わせるにはどうすればよいですか？**  
凡例の色、塗りつぶし、フォントを設定しないままにしておくと、テーマの書式設定を継承します。明示的に書式設定を行うと、対応するテーマ設定が上書きされます。