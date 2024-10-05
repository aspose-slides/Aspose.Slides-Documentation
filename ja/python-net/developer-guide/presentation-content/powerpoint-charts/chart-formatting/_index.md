---
title: チャートの書式設定
type: docs
weight: 60
url: /python-net/chart-formatting/
keywords: "チャートエンティティ、チャートプロパティ、PowerPointプレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションのチャートエンティティを整形する"
---

## **チャートエンティティの書式設定**
Aspose.Slides for Python via .NETを使用すると、開発者はスライドにカスタムチャートをゼロから追加できます。この記事では、チャートカテゴリおよび値軸を含むさまざまなチャートエンティティの書式設定方法を説明します。

Aspose.Slides for Python via .NETは、さまざまなチャートエンティティを管理し、カスタム値を使用して書式設定するためのシンプルなAPIを提供します。

1. **Presentation**クラスのインスタンスを作成します。
1. インデックスからスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、必要なタイプのいずれかを選択します（この例ではChartType.LineWithMarkersを使用します）。
1. チャートの値軸にアクセスし、以下のプロパティを設定します：
   1. 値軸主グリッド線の**線の書式設定**を設定します
   1. 値軸副グリッド線の**線の書式設定**を設定します
   1. 値軸の**数値書式**を設定します
   1. 値軸の**最小、最大、主要および副単位**を設定します
   1. 値軸データの**テキストプロパティ**を設定します
   1. 値軸の**タイトル**を設定します
   1. 値軸の**線の書式**を設定します
1. チャートのカテゴリ軸にアクセスし、以下のプロパティを設定します：
   1. カテゴリ軸主グリッド線の**線の書式設定**を設定します
   1. カテゴリ軸副グリッド線の**線の書式設定**を設定します
   1. カテゴリ軸データの**テキストプロパティ**を設定します
   1. カテゴリ軸の**タイトル**を設定します
   1. カテゴリ軸の**ラベル位置**を設定します
   1. カテゴリ軸ラベルの**回転角度**を設定します
1. チャートの凡例にアクセスし、それらの**テキストプロパティ**を設定します
1. チャートが重ならないようにチャート凡例を表示します
1. チャートの**セカンダリ値軸**にアクセスし、以下のプロパティを設定します：
   1. セカンダリ**値軸**を有効にします
   1. セカンダリ値軸の**線の書式**を設定します
   1. セカンダリ値軸の**数値書式**を設定します
   1. セカンダリ値軸の**最小、最大、主要および副単位**を設定します
1. まず、セカンダリ値軸に最初のチャート系列をプロットします
1. チャートのバックウォールの塗りつぶし色を設定します
1. チャートのプロットエリアの塗りつぶし色を設定します
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションのインスタンス化
with slides.Presentation() as pres:

    # 最初のスライドにアクセス
    slide = pres.slides[0]

    # サンプルチャートの追加
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # チャートタイトルの設定
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "サンプルチャート"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # 値軸の主グリッド線の書式設定
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 値軸の副グリッド線の書式設定
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 値軸の数値書式を設定
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # チャートの最大、最小値を設定
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # 値軸のテキストプロパティを設定
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # 値軸タイトルを設定
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "主軸"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # カテゴリ軸の主グリッド線の書式設定
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # カテゴリ軸の副グリッド線の書式設定
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # カテゴリ軸のテキストプロパティを設定
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # カテゴリタイトルを設定
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "サンプルカテゴリ"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # カテゴリ軸ラベル位置を設定
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # カテゴリ軸ラベルの回転角度を設定
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 凡例のテキストプロパティを設定
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # チャートの重なりがないように凡例を表示する

    chart.legend.overlay = True
                
    # チャートバックウォールの色を設定
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # プロットエリアの色を設定
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # プレゼンテーションを保存
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **チャートのフォントプロパティを設定**
Aspose.Slides for Python via .NETは、チャートのフォント関連プロパティを設定するサポートを提供します。以下の手順に従って、チャートのフォントプロパティを設定してください。

- **Presentation**クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```




## **数値の書式設定を行う**
Aspose.Slides for Python via .NETは、チャートデータの書式設定を管理するためのシンプルなAPIを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスからスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、必要なタイプのいずれかを選択します（この例では**ChartType.ClusteredColumn**を使用します）。
1. 使用可能なプリセット値から設定された数値の書式を設定します。
1. 各チャート系列のチャートデータセルをトラバースして、チャートデータ数値書式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値書式を設定します。
1. 各チャート系列内のチャートデータセルをトラバースし、異なるチャートデータ数値書式を設定します。
1. プレゼンテーションを保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# プレゼンテーションをインスタンス化
with slides.Presentation() as pres:
    # 最初のプレゼンテーションスライドにアクセス
    slide = pres.slides[0]

    # デフォルトの集合列チャートを追加
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # チャート系列コレクションにアクセス
    series = chart.chart_data.series

    # プリセット数値書式を設定
    # 各チャート系列をトラバース
    for ser in series:
        # 系列内のすべてのデータセルをトラバース
        for cell in ser.data_points:
            # 数値書式を設定
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # プレゼンテーションを保存
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

以下に、使用可能なプリセット数値書式の値とそのインデックスを示します。

|**0**|一般|
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
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **チャートエリアの丸みを設定**
Aspose.Slides for Python via .NETは、チャートエリアの設定をサポートしています。**IChart.HasRoundedCorners**および**Chart.HasRoundedCorners**プロパティがAspose.Slidesに追加されました。

1. **Presentation**クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
1. ラウンドコーナーのプロパティをTrueに設定します。
1. 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```