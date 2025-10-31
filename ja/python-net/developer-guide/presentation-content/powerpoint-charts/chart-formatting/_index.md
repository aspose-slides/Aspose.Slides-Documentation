---
title: Python を使用したプレゼンテーションでのチャートの書式設定
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
- 角丸境界
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET 経由）でのチャート書式設定を学び、PowerPoint または OpenDocument プレゼンテーションをプロフェッショナルで目を引くスタイルに向上させましょう。"
---

## **概要**

このガイドでは、Aspose.Slides for Python を使用して PowerPoint のチャートを書式設定する方法を示します。カテゴリ軸や値軸、グリッドライン、ラベル、タイトル、凡例、二次軸などのコアチャート要素のカスタマイズ手順を説明し、フォント、数値書式、塗りつぶし、輪郭、プロット領域と背面壁の色、角丸のチャートコーナーを簡潔な実行可能コードサンプルで制御する方法をデモンストレーションします。ステップバイステップの例に従うことで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、チャートを追加・構成し、正確な視覚的およびタイポグラフィ設定を適用したうえで PPTX に保存できます。

## **チャート要素の書式設定**

Aspose.Slides for Python を使用すると、開発者はスライドにカスタムチャートをゼロから追加できます。このセクションでは、カテゴリ軸と値軸を含むさまざまなチャート要素の書式設定方法を説明します。

Aspose.Slides は、チャート要素の管理とカスタム書式設定のためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 目的の種類のデフォルトデータでチャートを追加します（この例では `ChartType.LINE_WITH_MARKERS`）。
1. チャートの値軸にアクセスし、次を設定します：
   1. 値軸の主グリッドラインの **線書式** を設定します。
   1. 値軸の副グリッドラインの **線書式** を設定します。
   1. 値軸の **数値書式** を設定します。
   1. 値軸の **最小、最大、主単位、副単位** を設定します。
   1. 値軸ラベルの **テキストプロパティ** を設定します。
   1. 値軸の **タイトル** を設定します。
   1. 値軸の **線書式** を設定します。
1. チャートのカテゴリ軸にアクセスし、次を設定します：
   1. カテゴリ軸の主グリッドラインの **線書式** を設定します。
   1. カテゴリ軸の副グリッドラインの **線書式** を設定します。
   1. カテゴリ軸ラベルの **テキストプロパティ** を設定します。
   1. カテゴリ軸の **タイトル** を設定します。
   1. カテゴリ軸の **ラベル位置** を設定します。
   1. カテゴリ軸ラベルの **回転角度** を設定します。
1. チャート凡例にアクセスし、**テキストプロパティ** を設定します。
1. チャートと重ならないように凡例を表示します。
1. チャートの **二次値軸** にアクセスし、次を設定します：
   1. 二次 **値軸** を有効にします。
   1. 二次値軸の **線書式** を設定します。
   1. 二次値軸の **数値書式** を設定します。
   1. 二次値軸の **最小、最大、主単位、副単位** を設定します。
1. 最初のチャート系列を二次値軸にプロットします。
1. チャート背面壁の塗りつぶし色を設定します。
1. チャートプロット領域の塗りつぶし色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。

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

    # 値軸の主グリッドラインの書式を設定します。
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 値軸の副グリッドラインの書式を設定します。
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 値軸の数値書式を設定します。
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # 値軸の最大値、最小値、主単位、副単位を設定します。
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

    # カテゴリ軸の主グリッドラインの書式を設定します。
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # カテゴリ軸の副グリッドラインの書式を設定します。
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

    # カテゴリ軸ラベルの位置を設定します。
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # カテゴリ軸ラベルの回転角度を設定します。
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 凡例のテキストプロパティを設定します。
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # チャートと重なるように凡例を表示します。
    chart.legend.overlay = True
                
    # チャート背面壁の色を設定します。
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

## **チャート フォント プロパティの設定**

Aspose.Slides for Python は、チャートのフォント関連プロパティの設定をサポートしています。以下の手順でチャートのフォントプロパティを構成してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. フォント高さを設定します。
1. 変更したプレゼンテーションを保存します。

サンプルコードは以下の通りです。

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

Aspose.Slides for Python は、チャートデータ書式を管理するシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 任意の種類のデフォルトデータでチャートを追加します。
1. 利用可能なプリセットから数値書式を設定します。
1. 各シリーズのチャートデータセルを走査し、数値書式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値書式を設定します。
1. 各シリーズのチャートデータセルを走査し、別の数値書式を設定します。
1. プレゼンテーションを保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルトのクラスター化縦棒チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # 事前設定された数値書式を設定します。
    # 各チャートシリーズを走査します。
    for series in chart.chart_data.series:
        # シリーズ内の各データポイントを走査します。
        for cell in series.data_points:
            # 数値書式を設定します。
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # プレゼンテーションを保存します。
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

利用可能なプリセット数値書式とその対応インデックスは以下の通りです。

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

## **チャート エリアの角丸境界の設定**

Aspose.Slides for Python は、`Chart.has_rounded_corners` プロパティを使用してチャートエリアの角丸設定を構成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
4. `has_rounded_corners` プロパティを `True` に設定します。
5. 変更したプレゼンテーションを保存します。

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

**列/エリアに半透明の塗りつぶしを設定しつつ、境界線を不透明に保つことはできますか？**

はい。塗りつぶしの透明度と輪郭は別々に構成できます。これにより、密集したビジュアル化においてグリッドやデータの可読性を向上させることができます。

**ラベルが重なった場合、どう対処すればよいですか？**

フォントサイズを縮小する、不要なラベル要素（例：カテゴリ）を無効にする、ラベルのオフセット/位置を調整する、必要に応じて選択ポイントのラベルのみ表示する、またはフォーマットを「値＋凡例」に切り替えるといった方法があります。

**系列にグラデーションやパターン塗りつぶしを適用できますか？**

はい。単色だけでなく、グラデーションやパターン塗りつぶしも通常利用可能です。実務では、グラデーションの使用は控えめにし、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。