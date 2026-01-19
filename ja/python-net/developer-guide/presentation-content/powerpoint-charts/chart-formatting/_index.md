---
title: Python を使用したプレゼンテーションのチャートの書式設定
linktitle: チャート書式設定
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
- 丸みを帯びた境界線
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して .NET でチャートの書式設定を学び、PowerPoint または OpenDocument のプレゼンテーションをプロフェッショナルで目を引くスタイルに向上させます。"
---

## **概要**

このガイドでは、Aspose.Slides for Python を使用して PowerPoint のチャートをフォーマットする方法を示します。カテゴリ軸と値軸、グリッド線、ラベル、タイトル、凡例、二次軸などのコア チャート エンティティのカスタマイズ手順を説明し、フォント、数値形式、塗りつぶし、アウトライン、プロット領域と背面壁の色、丸みを帯びたチャート コーナーを簡潔で実行可能なコード サンプルで制御する方法を示します。ステップバイステップの例に従うことで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、チャートを追加・設定し、正確なビジュアルおよびタイポグラフィ設定を適用したまま PPTX に保存できます。

## **チャート要素の書式設定**

Aspose.Slides for Python は、開発者がスライドにカスタム チャートを最初から追加できるようにします。このセクションでは、カテゴリ軸と値軸を含むさまざまなチャート要素の書式設定方法を説明します。

Aspose.Slides は、チャート要素を管理しカスタム書式を適用するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 目的の型のデフォルト データでチャートを追加します（この例では `ChartType.LINE_WITH_MARKERS`）。
1. チャートの値軸にアクセスし、以下を設定します。
   1. 値軸の主グリッド線の **line format** を設定します。
   1. 値軸の副グリッド線の **line format** を設定します。
   1. 値軸の **number format** を設定します。
   1. 値軸の **min、max、major、minor units** を設定します。
   1. 値軸ラベルの **text properties** を設定します。
   1. 値軸の **title** を設定します。
   1. 値軸の **line format** を設定します。
1. チャートのカテゴリ軸にアクセスし、以下を設定します。
   1. カテゴリ軸の主グリッド線の **line format** を設定します。
   1. カテゴリ軸の副グリッド線の **line format** を設定します。
   1. カテゴリ軸ラベルの **text properties** を設定します。
   1. カテゴリ軸の **title** を設定します。
   1. カテゴリ軸の **label positioning** を設定します。
   1. カテゴリ軸ラベルの **rotation angle** を設定します。
1. チャートの凡例にアクセスし、その **text properties** を設定します。
1. チャートと重ならないように凡例を表示します。
1. チャートの **secondary value axis** にアクセスし、以下を設定します。
   1. 二次 **value axis** を有効にします。
   1. 二次値軸の **line format** を設定します。
   1. 二次値軸の **number format** を設定します。
   1. 二次値軸の **min、max、major、minor units** を設定します。
1. 最初のチャート系列を二次値軸にプロットします。
1. チャートの背面壁の塗りつぶし色を設定します。
1. チャートのプロット領域の塗りつぶし色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # サンプルチャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # チャートのタイトルを設定します。
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # 値軸の主グリッド線の書式を設定します。
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 値軸の副グリッド線の書式を設定します。
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 値軸の数値形式を設定します。
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # 値軸の最大値、最小値、主単位、および副単位を設定します。
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # 値軸のテキストプロパティを設定します。
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # 値軸のタイトルを設定します。
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # カテゴリ軸の主グリッド線の書式を設定します。
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # カテゴリ軸の副グリッド線の書式を設定します。
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # カテゴリ軸のテキストプロパティを設定します。
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # カテゴリ軸のタイトルを設定します。
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # カテゴリ軸のラベル位置を設定します。
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # カテゴリ軸のラベル回転角度を設定します。
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 凡例のテキストプロパティを設定します。
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # チャートに重なるように凡例を表示します。
    chart.legend.overlay = True
                
    # チャートの背面壁の色を設定します。
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # プロット領域の色を設定します。
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # プレゼンテーションを保存します。
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **チャートのフォント プロパティの設定**

Aspose.Slides for Python は、チャートのフォント関連プロパティの設定をサポートします。以下の手順に従ってチャートのフォント プロパティを構成します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル コードを示します。
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


## **数値形式の設定**

Aspose.Slides for Python は、チャート データ形式を管理するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 任意の型のデフォルト データでチャートを追加します。
1. 利用可能なプリセット値から事前設定された数値形式を設定します。
1. 各系列のチャート データ セルを走査し、数値形式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値形式を設定します。
1. 各系列のチャート データ セルを走査し、別の数値形式を設定します。
1. プレゼンテーションを保存します。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルトの集合縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # 事前設定された数値形式を設定します。
    # 各チャート系列を走査します。
    for series in chart.chart_data.series:
        # 系列内の各データポイントを走査します。
        for cell in series.data_points:
            # 数値形式を設定します。
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # プレゼンテーションを保存します。
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```


利用可能なプリセット数値形式と対応するインデックスは以下に示します。

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

## **チャート領域の丸みを帯びた境界線の設定**

Aspose.Slides for Python は、`Chart.has_rounded_corners` プロパティを使用してチャート領域の設定をサポートします。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
4. rounded-corners プロパティを `True` に設定します。
5. 変更されたプレゼンテーションを保存します。

以下にサンプルを示します。
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

**列/領域の半透明の塗りつぶしを設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度と輪郭は別々に設定できます。これは、密集した可視化におけるグリッドやデータの可読性を向上させるのに役立ちます。

**データ ラベルが重なる場合、どう対処すればよいですか？**

フォント サイズを小さくし、不要なラベル要素（例：カテゴリ）を無効にし、ラベルのオフセット/位置を設定し、必要に応じて選択したポイントだけにラベルを表示するか、形式を「value + legend」に切り替えてください。

**系列にグラデーションやパターンの塗りつぶしを適用できますか？**

はい。通常、単色塗りつぶしとグラデーション/パターン塗りつぶしの両方が利用可能です。実際には、グラデーションは控えめに使用し、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。