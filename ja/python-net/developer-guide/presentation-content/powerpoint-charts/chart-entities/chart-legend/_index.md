---
title: チャートの凡例
type: docs
url: /python-net/chart-legend/
keywords: "チャートの凡例, 凡例のフォントサイズ, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでのPowerPointプレゼンテーションにおけるチャートの凡例の位置とフォントサイズを設定します"
---

## **凡例の位置設定**
凡例のプロパティを設定するためには、次の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションをPPTXファイルとして保存します。

以下の例では、チャートの凡例の位置とサイズを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentationクラスのインスタンスを作成します
with slides.Presentation() as presentation:

    # スライドの参照を取得します
    slide = presentation.slides[0]

    # スライドにクラスタ化されたカラムチャートを追加します
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # 凡例のプロパティを設定します
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # プレゼンテーションをディスクに保存します
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```



## **凡例のフォントサイズを設定する**
Aspose.Slides for Python via .NETは、開発者が凡例のフォントサイズを設定できるようにします。次の手順に従ってください：

- `Presentation`クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.legend.text_format.portion_format.font_height = 20
	chart.axes.vertical_axis.is_automatic_min_value = False
	chart.axes.vertical_axis.min_value = -5
	chart.axes.vertical_axis.is_automatic_max_value = False
	chart.axes.vertical_axis.max_value = 10

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **個別の凡例のフォントサイズを設定する**
Aspose.Slides for Python via .NETは、開発者が個別の凡例エントリのフォントサイズを設定できるようにします。次の手順に従ってください：

- `Presentation`クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	tf = chart.legend.entries[1].text_format

	tf.portion_format.font_bold = 1
	tf.portion_format.font_height = 20
	tf.portion_format.font_italic = 1
	tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
	tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```