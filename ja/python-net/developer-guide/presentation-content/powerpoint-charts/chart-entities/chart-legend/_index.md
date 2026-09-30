---
title: Python でプレゼンテーションのチャート凡例をカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/python-net/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してチャート凡例をカスタマイズし、カスタマイズされた凡例の書式設定で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for Python via .NET は、PowerPoint プレゼンテーション内のチャート凡例をカスタマイズするオプションを提供します。この記事では、凡例の位置とサイズの設定、凡例全体のフォントサイズの設定、個々の凡例項目の書式設定、選択した項目の非表示または復元方法を示します。

FAQ では、凡例の領域確保、複数行ラベルの表示、プレゼンテーションテーマからの書式継承など、関連する動作について説明しています。

## **凡例の位置設定**

凡例の [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) プロパティを使用して、チャートのサイズに対する比率で位置とサイズを指定します。

この例では、プレゼンテーションを作成し、デフォルトデータのクラスター化された縦棒グラフを最初のスライドに追加します。凡例のオフセットとサイズをチャートの幅と高さで割ることで、相対値に変換します。凡例はチャートの左上隅から 50 ポイントオフセットされ、サイズは 100 x 100 ポイントになります。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # チャートに対して凡例の位置とサイズを相対的に指定します。
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **凡例のフォントサイズの設定**

凡例の [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) を使用してテキスト書式にアクセスし、[font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) をポイント単位で設定します。

この例では、デフォルトデータのチャートを作成し、凡例テキストを 20 ポイントに設定します。また、縦軸の自動範囲設定を無効にし、範囲を -5 から 10 に設定します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **個別の凡例項目のフォントサイズの設定**

凡例の [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) コレクションを使用して特定の項目の書式にアクセスします。エントリのインデックスはゼロベースで、インデックス `1` は2番目の項目を指します。

この例では、デフォルトデータに少なくとも2系列が含まれるクラスター化縦棒グラフを作成します。2番目の凡例項目を太字・斜体・20ポイントの青色テキストで書式設定します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **個別の凡例項目を非表示にする**

データは表示したまま補助系列を凡例から除外するには、[ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) を `True` に設定し、[IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/) を通じて行います。これにより選択した凡例項目のみが非表示になり、系列やデータポイントは削除されません。対照的に、[IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) を `False` に設定すると、凡例全体が非表示になります。

以下の例では、デフォルトデータを使用して複数系列のクラスター化縦棒グラフを作成します。2番目の系列の凡例項目（インデックス `1`）を非表示にしてプレゼンテーションを保存します。その後、[hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) を `False` に設定して項目を復元し、2つ目のコピーを保存します。両方のファイルで列は引き続き表示されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # データを変更せずに同じ項目を復元します。
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

下の比較では、すべての項目が表示されたチャートと、凡例からシリーズ2が非表示になったチャートの比較を示しています。2番目の系列の列は変わりません。

![全ての凡例項目が表示されたチャートと、凡例からシリーズ2が非表示になったチャートの比較。すべての列は表示されたままです。](hide-legend-entry.png)

縦棒・横棒・折れ線チャートでは、凡例項目は系列を識別します。円グラフの場合、凡例項目は個々のデータポイント（スライス）を識別するため、選択したスライスに対して [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) を使用します。API はこのデータポイントプロパティを `PIE`、`PIE3D`、`EXPLODED_PIE`、`EXPLODED_PIE3D`、`PIE_OF_PIE`、`BAR_OF_PIE` のチャートタイプに対して文書化しています。ドーナツチャートには適用されないことに注意してください。

## **FAQ**

**チャートが凡例の上に重ねるのではなく、凡例用の領域を確保するようにできますか？**

はい。[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) を `False` に設定すると、プロット領域と重なるのを防ぎ、凡例用の領域を確保します。

**凡例ラベルを複数行にできますか？**

はい。利用可能な幅が不足している場合、長いラベルは自動的に折り返されます。また、系列名に改行文字を入れることで改行を指示することも可能です。

**凡例をプレゼンテーションテーマのカラースキームに合わせるにはどうすればよいですか？**

凡例の色、塗りつぶし、フォントを設定しないままにしておくと、テーマの書式設定を継承します。明示的に書式設定した場合は、対応するテーマ設定を上書きします。