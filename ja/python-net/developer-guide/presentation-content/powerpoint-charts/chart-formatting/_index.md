---
title: Python を使用したプレゼンテーションでのチャートの書式設定
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/python-net/chart-formatting/
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
description: "Aspose.Slides for Python（.NET 経由）でのチャート書式設定を学び、カスタム軸、フォント、数値書式、角丸チャート境界線を使用して PowerPoint プレゼンテーションを向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションのチャートを書式設定する方法を説明しています。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなどの主要なチャート要素をカスタマイズし、チャートデータの外観と可読性を向上させる方法を示します。

また、チャートテキストのフォントプロパティの設定、チャートデータへのプリセット数値書式の適用、チャート領域の角丸の有効化方法も示します。これらの例は、プレゼンテーション内のチャートの視覚的スタイルとデータの提示の両方を制御する方法を示しています。

上昇および下降間隔で個別の塗りと枠線を設定する場合は、[株価チャートの例](/slides/ja/python-net/create-chart/#create-stock-charts)をご覧ください。

## **チャートエンティティの書式設定**

チャートのタイトル、軸、グリッド線、凡例、プロット領域をフォーマットするには、[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) を使用します。この例では、マーカー付きの折れ線グラフをデフォルトデータで作成し、値軸とカテゴリ軸にそれぞれ別々のテキストと線のスタイルを適用します。フォントサイズと線幅はポイントで指定され、カテゴリラベルは 45 度回転します。

値軸は、ソースセルとは独立して [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) を使用します。スケールは -2 から 15 までで、主要間隔が 2、副間隔が 0.5 です。この例では、パーセンテージ書式と [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) を千単位に設定した組み合わせも示していますので、データの意味と大きさに合わせて設定を調整してください。凡例は [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) が無効になっているため、プロット領域の外側に配置されます。背面壁と床の塗りは、[back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) と [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) で設定されますが、これらの面は 3D チャートでのみ表示されます。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートのフォントプロパティを設定する**

[Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) を使用してチャートテキストのデフォルトフォントサイズを設定します。この例では、20 ポイントのフォントでクラスター化された縦棒グラフを作成し、[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) によって最初の系列の値ラベルを有効にしています。個別に明示されたフォント設定を持つテキスト要素は、チャートのデフォルトを上書きできます。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート凡例にテキストフレームの書式設定を再利用する**

凡例をスライドの見出しに合わせるには、見出しの最初の段落の [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) でフォントを設定します。凡例の [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) に対して [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) を呼び出します。これにより、テキストフレームの設定、最初の段落の書式、およびその段落のデフォルトフォントプロパティがコピーされます。個々の部分や後続の段落に直接適用された書式は、元のソースにローカルなままです。

この例では、太字でネイビーブルー、26 ポイントの Calibri の見出しをテンプレートとして使用します。凡例のスタイリング後、[copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) を使用して同じ書式を別のキャプションに適用します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

保存されたプレゼンテーションでは、凡例とキャプションはサイズ、太さ、色が見出しと一致します。凡例は依然として系列名を表示し、キャプションは独自のテキストを保持します。キャプション内の部分に明示的なフォントサイズが既に設定されている場合、そのサイズがコピーされた段落のデフォルトよりも優先されます。

| コピー前 | コピー後 |
| --- | --- |
| ![四半期売上チャート（標準の黒い凡例ラベルと黒いキャプション）](legend-formatting-before.png) | ![同じチャート（大きく太字のネイビー凡例ラベルと一致するキャプション）](legend-formatting.png) |

## **数値書式を設定する**

[ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) を使用して、チャートのワークブックセルに組み込みの数値書式を適用します。この例では、デフォルトのセルベースデータでクラスター化された縦棒グラフを作成し、各系列の値セルに書式インデックス 10（`0.00%`）を適用しています。これにより、基になる数値は変更せずにワークブック上での表示が変わります。たとえば、0.25 は 25.00% と表示されます。軸とデータラベルの書式は個別に設定できます。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

以下の表は、英語（米国）ロケール向けの代表的な Excel 書式とともに、組み込みの数値書式インデックスを一覧にしています。正確な書式文字列と表示は、アプリケーションやロケールによって変わる場合があり、特に通貨や日付で顕著です。一部の Excel 書式は、[Microsoft の数値書式実装ノート](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) に記載されているように、OOXML 標準のデフォルトとは異なることがあります。

| インデックス | 書式 |
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

## **チャート領域の角丸境界線を設定する**

[Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) を有効にして、チャート領域の角を丸めます。この例では、クラスター化された縦棒グラフを作成し、[line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) を使用してアウトラインに単色のグレーとシングルラインスタイルを設定し、プレゼンテーションを保存します。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **既存のチャート注釈を編集する**

チャートには、レポートのステータスを説明するテキスト注釈などのカスタム シェイプを含めることができます。これらのシェイプは、[Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) を介して取得します。その [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) コレクションには、チャートが所有するシェイプが含まれます。

チャート上に配置された通常のテキスト ボックスは、見た目がチャートの一部であってもスライドに属します。[Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) を反復処理すると、チャートと通常のスライドシェイプが見つかりますが、チャート内の個々のシェイプは列挙されません。チャートのタイトルとデータ ラベルは、別個のチャート要素であり、このコレクション内のカスタム注釈ではありません。

[chart-annotations.pptx](chart-annotations.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには、"Preliminary results"（暫定結果）というグループ化されていない注釈と、チャートが所有する線、そして "Slide overlay"（スライドオーバーレイ）というテキスト ボックスが含まれるチャートがあります。この例では、そのスライド上の最初のチャートを見つけ、レポートの公開準備ができたときに注釈を "Final results"（最終結果）に変更します。空のコレクションを確認し、`None` でなく期待されるテキストを含む [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) を持つ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) のみを編集します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

線とスライドのテキスト ボックスは変更されません。以下の画像は、入力と保存後に再度開いた結果を示しています。

| 編集前 | 編集後 |
| --- | --- |
| ![「Preliminary results」と記載されたチャート注釈](chart-annotations-before.png) | ![「Final results」と記載されたチャート注釈](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
この例では、最上位レベルのチャート所有シェイプのみを検査します。注釈が [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 内にある場合、そのグループの [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) コレクションも検査してください。入れ子になったグループについては再帰的に繰り返し、子シェイプに対して同じテキストチェックを適用します。グループ自体はコンテナであり、テキスト ボックスとして扱わないでください。
{{% /alert %}}

## **FAQ**

**列/領域の塗りつぶしを半透明に設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度と枠線は別々に設定できます。これは、密集した可視化においてグリッドとデータの可読性を向上させるのに役立ちます。

**データ ラベルが重なる場合、どう対処すればよいですか？**

フォントサイズを小さくする、重要でないラベル要素（例：カテゴリ）を無効にする、ラベル位置を調整する、必要に応じて選択したポイントのラベルのみ表示する、または書式を「値 + 凡例」に切り替えるなどの方法があります。

**系列にグラデーションやパターンの塗りつぶしを適用できますか？**

はい。系列は単色、グラデーション、パターンの塗りつぶしをサポートします。実際には、グラデーションは必要最小限に使用し、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。