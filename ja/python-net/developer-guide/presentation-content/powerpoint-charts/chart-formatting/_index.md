---
title: Python を使用したプレゼンテーションでのチャートの書式設定
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
- 角丸境界
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python の .NET を介したチャート書式設定を学び、PowerPoint または OpenDocument プレゼンテーションをプロフェッショナルで目を引くスタイリングで向上させましょう。"
---

## **概要**

このガイドでは、Aspose.Slides for Python を使用して PowerPoint のチャートをフォーマットする方法を示します。カテゴリ軸や値軸、グリッドライン、ラベル、タイトル、凡例、二次軸などのコアチャート要素のカスタマイズ手順を解説し、フォント、数値形式、塗りつぶし、アウトライン、プロット領域と背面壁の色、丸みを帯びたチャートコーナーを簡潔な実行可能サンプルコードで制御する方法を示します。ステップバイステップの例に従うことで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、チャートを追加・設定し、PPTX に保存して、正確な視覚的およびタイポグラフィ設定を適用できます。

## **チャート要素の書式設定**

Aspose.Slides for Python は、開発者がスライドにカスタムチャートを最初から追加できるようにします。このセクションでは、カテゴリ軸と値軸を含むさまざまなチャート要素の書式設定方法を説明します。

Aspose.Slides は、チャート要素の管理とカスタム書式設定用のシンプルな API を提供します。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 目的のタイプのデフォルトデータでチャートを追加します（この例では `ChartType.LINE_WITH_MARKERS`）。
1. チャートの値軸にアクセスし、以下を設定します。
   1. 値軸メジャーグリッドラインの**線の書式**を設定します。
   1. 値軸マイナーグリッドラインの**線の書式**を設定します。
   1. 値軸の**数値形式**を設定します。
   1. 値軸の**最小、最大、メジャー、マイナー単位**を設定します。
   1. 値軸ラベルの**テキストプロパティ**を設定します。
   1. 値軸の**タイトル**を設定します。
   1. 値軸の**線の書式**を設定します。
1. チャートのカテゴリ軸にアクセスし、以下を設定します。
   1. カテゴリ軸メジャーグリッドラインの**線の書式**を設定します。
   1. カテゴリ軸マイナーグリッドラインの**線の書式**を設定します。
   1. カテゴリ軸ラベルの**テキストプロパティ**を設定します。
   1. カテゴリ軸の**タイトル**を設定します。
   1. カテゴリ軸の**ラベル位置**を設定します。
   1. カテゴリ軸ラベルの**回転角度**を設定します。
1. チャートの凡例にアクセスし、**テキストプロパティ**を設定します。
1. チャートと重ならないように凡例を表示します。
1. チャートの**二次値軸**にアクセスし、以下を設定します。
   1. 二次**値軸**を有効にします。
   1. 二次値軸の**線の書式**を設定します。
   1. 二次値軸の**数値形式**を設定します。
   1. 二次値軸の**最小、最大、メジャー、マイナー単位**を設定します。
1. 最初のチャート系列を二次値軸にプロットします。
1. チャートの背面壁の塗りつぶし色を設定します。
1. チャートのプロット領域の塗りつぶし色を設定します。
1. 変更されたプレゼンテーションを書き込み、PPTX ファイルとして保存します。
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

        # 値軸の数値形式を設定します。
        chart.axes.vertical_axis.is_number_format_linked_to_source = False
        chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
        chart.axes.vertical_axis.number_format = "0.0%"

        # 値軸の最大値、最小値、主単位、そして副単位を設定します。
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

        # チャートに凡例が重なるように表示します。
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


## **チャートのフォントプロパティの設定**

Aspose.Slides for Python は、チャートのフォント関連プロパティの設定をサポートします。以下の手順に従ってチャートのフォントプロパティを構成してください。

1. Presentation オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

サンプルコードは以下に示されています。
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

Aspose.Slides for Python は、チャートデータ形式の管理用にシンプルな API を提供します。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 任意のタイプのデフォルト データでチャートを追加します。
1. 利用可能なプリセット値から数値形式のプリセットを設定します。
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

    # デフォルトのクラスター化縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # プリセットの数値形式を設定します。
    # 各チャート系列を走査します。
    for series in chart.chart_data.series:
        # 系列内の各データポイントを走査します。
        for cell in series.data_points:
            # 数値形式を設定します。
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # プレゼンテーションを保存します。
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```


利用可能なプリセット数値形式と対応するインデックスは以下の通りです。

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

## **チャート領域の角丸境界の設定**

Aspose.Slides for Python は、`Chart.has_rounded_corners` プロパティを使用してチャート領域の構成をサポートします。

1. Presentation オブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
4. `True` に設定して角丸プロパティを有効にします。
5. 変更されたプレゼンテーションを保存します。

サンプルは以下に示されています。
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


## **よくある質問**

**列/エリアの塗りつぶしを半透明にし、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度とアウトラインは別々に設定できます。これは、グリッドとデータが密集した可視化で可読性を向上させるのに役立ちます。

**ラベルが重なる場合、どう対処できますか？**

フォントサイズを小さくする、不要なラベル要素（例: カテゴリ）を無効にする、ラベルのオフセット/位置を設定する、必要に応じて選択ポイントのみラベルを表示する、または形式を「値 + 凡例」に切り替えることができます。

**系列にグラデーションやパターン塗りつぶしを適用できますか？**

はい。単色塗りつぶしと同様に、グラデーションやパターン塗りつぶしも利用可能です。実務では、グラデーションは控えめに使用し、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。
---
title: Python を使用したプレゼンテーションでのチャートの書式設定
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
- 角丸境界
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python の .NET を介したチャート書式設定を学び、PowerPoint または OpenDocument プレゼンテーションをプロフェッショナルで目を引くスタイリングで向上させましょう。"
---
