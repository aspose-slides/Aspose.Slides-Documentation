---
title: Python を使用したプレゼンテーションのチャートの書式設定
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/python-net/chart-formatting/
keywords:
- チャートの書式設定
- チャートの書式設定
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 丸みを帯びた枠線
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETでチャートの書式設定を学び、PowerPointまたはOpenDocumentプレゼンテーションをプロフェッショナルで目を引くスタイリングで向上させましょう。"
---

## **概要**

このガイドでは、Aspose.Slides for Python を使用して PowerPoint のチャートを書式設定する方法を示します。カテゴリ軸や値軸、グリッドライン、ラベル、タイトル、凡例、二次軸など、コアとなるチャート要素のカスタマイズ方法を解説し、フォント、数値書式、塗りつぶし、線種、プロット領域と背面の色、丸みを帯びたチャートの角丸などを簡潔で実行可能なコードサンプルで示します。ステップバイステップの例に従うことで、[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、チャートを追加・構成し、PPTX として保存しながら、視覚的かつタイポグラフィ的な設定を正確に適用できます。

## **チャート要素の書式設定**

Aspose.Slides for Python では、開発者が最初からスライドにカスタムチャートを追加できます。このセクションでは、カテゴリ軸や値軸を含むさまざまなチャート要素の書式設定方法を説明します。

Aspose.Slides は、チャート要素を管理しカスタム書式を適用するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. 任意のタイプのデフォルトデータでチャートを追加します（この例では `ChartType.LINE_WITH_MARKERS`）。  
4. チャートの値軸にアクセスし、以下を設定します。  
   1. 値軸メジャー グリッドラインの **線の書式** を設定。  
   2. 値軸マイナー グリッドラインの **線の書式** を設定。  
   3. 値軸の **数値書式** を設定。  
   4. 値軸の **最小・最大・メジャー・マイナー ユニット** を設定。  
   5. 値軸ラベルの **テキストプロパティ** を設定。  
   6. 値軸の **タイトル** を設定。  
   7. 値軸の **線の書式** を設定。  
5. チャートのカテゴリ軸にアクセスし、以下を設定します。  
   1. カテゴリ軸メジャー グリッドラインの **線の書式** を設定。  
   2. カテゴリ軸マイナー グリッドラインの **線の書式** を設定。  
   3. カテゴリ軸ラベルの **テキストプロパティ** を設定。  
   4. カテゴリ軸の **タイトル** を設定。  
   5. カテゴリ軸の **ラベル位置** を設定。  
   6. カテゴリ軸ラベルの **回転角度** を設定。  
6. チャート凡例にアクセスし、**テキストプロパティ** を設定。  
7. チャート凡例がチャートと重ならないように表示。  
8. チャートの **二次値軸** にアクセスし、以下を設定。  
   1. 二次 **値軸** を有効化。  
   2. 二次値軸の **線の書式** を設定。  
   3. 二次値軸の **数値書式** を設定。  
   4. 二次値軸の **最小・最大・メジャー・マイナー ユニット** を設定。  
9. 最初のチャート系列を二次値軸にプロット。  
10. チャート背面壁の塗りつぶし色を設定。  
11. チャートプロット領域の塗りつぶし色を設定。  
12. 修正したプレゼンテーションを PPTX ファイルに書き出し。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンス化。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセス。
    slide = presentation.slides[0]

    # サンプルチャートを追加。
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # チャートタイトルを設定。
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # 値軸のメジャー グリッドライン書式を設定。
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 値軸のマイナー グリッドライン書式を設定。
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 値軸の数値書式を設定。
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # 値軸の最大・最小・メジャー・マイナー ユニットを設定。
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # 値軸テキストプロパティを設定。
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # 値軸タイトルを設定。
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # カテゴリ軸のメジャー グリッドライン書式を設定。
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # カテゴリ軸のマイナー グリッドライン書式を設定。
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # カテゴリ軸テキストプロパティを設定。
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # カテゴリ軸タイトルを設定。
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # カテゴリ軸ラベル位置を設定。
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # カテゴリ軸ラベルの回転角度を設定。
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 凡例テキストプロパティを設定。
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # チャート凡例をチャートと重ならないように表示。
    chart.legend.overlay = True
                
    # チャート背面壁の色を設定。
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # プロット領域の色を設定。
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # プレゼンテーションを保存。
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートフォントプロパティの設定**

Aspose.Slides for Python は、チャートのフォントに関するプロパティ設定をサポートしています。以下の手順に従ってチャートのフォントプロパティを構成してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトをインスタンス化。  
2. スライドにチャートを追加。  
3. フォントの高さを設定。  
4. 修正したプレゼンテーションを保存。

サンプルコードは次のとおりです。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **数値書式の設定**

Aspose.Slides for Python は、チャートデータの書式管理用にシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成。  
2. インデックスでスライドへの参照を取得。  
3. 任意のタイプのデフォルトデータでチャートを追加。  
4. 利用可能なプリセット値から数値書式を設定。  
5. 各系列のデータセルを走査し、数値書式を設定。  
6. プレゼンテーションを保存。  
7. カスタム数値書式を設定。  
8. 各系列のデータセルを走査し、別の数値書式を設定。  
9. プレゼンテーションを保存。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation クラスのインスタンス化。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセス。
    slide = presentation.slides[0]

    # デフォルトのクラスター化縦棒チャートを追加。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # プリセット数値書式を設定。
    # 各系列を走査。
    for series in chart.chart_data.series:
        # 系列内の各データポイントを走査。
        for cell in series.data_points:
            # 数値書式を設定。
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # プレゼンテーションを保存。
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

利用可能なプリセット数値書式とそれに対応するインデックスは以下のとおりです。

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **チャート領域の丸みを帯びた枠線の設定**

Aspose.Slides for Python は、`Chart.has_rounded_corners` プロパティを使用してチャート領域の丸みを設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトをインスタンス化。  
2. スライドにチャートを追加。  
3. チャートの塗りつぶしタイプと塗りつぶし色を設定。  
4. `has_rounded_corners` プロパティを `True` に設定。  
5. 修正したプレゼンテーションを保存。

サンプルは以下の通りです。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**列やエリアの塗りつぶしを半透明に設定し、枠線は不透明のままにできますか？**  
はい。塗りつぶしの透明度とアウトラインは別々に設定できます。これは、密集した可視化でグリッドやデータの可読性を向上させるのに役立ちます。

**データラベルが重なったときはどう対処すればよいですか？**  
フォントサイズを減らす、不要なラベル要素（例: カテゴリ）を無効化する、ラベルのオフセットや位置を設定する、必要に応じて選択ポイントのみラベルを表示する、または「値 + 凡例」の形式に切り替えるといった方法があります。

**系列にグラデーションやパターン塗りつぶしを適用できますか？**  
はい。単色塗りつぶしだけでなく、グラデーションやパターン塗りつぶしも通常利用可能です。実務ではグラデーションの使用は控えめにし、グリッドやテキストとのコントラストが低下しないように組み合わせを避けてください。