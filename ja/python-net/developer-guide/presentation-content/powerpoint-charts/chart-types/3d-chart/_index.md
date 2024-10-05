---
title: 3Dチャート
type: docs
url: /python-net/3d-chart/
keywords: "3dチャート, rotationX, rotationY, depthpercent, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションの3DチャートのためにrotationX、rotationY、およびdepthpercentsを設定します"
---

## **3DチャートのRotationX、RotationYおよびDepthPercentsプロパティを設定する**
Aspose.Slides for Python via .NETは、これらのプロパティを設定するためのシンプルなAPIを提供します。この次の記事では、X、Y回転、**DepthPercents**などの異なるプロパティを設定する方法を説明します。サンプルコードでは、上記のプロパティを設定する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. Rotation3Dプロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
            
    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # デフォルトデータでチャートを追加
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # チャートデータシートのインデックスを設定
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # シリーズを追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "シリーズ 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "シリーズ 2"), chart.type)

    # カテゴリを追加
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "カテゴリ 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "カテゴリ 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "カテゴリ 3"))

    # Rotation3Dプロパティを設定
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # 2番目のチャートシリーズを取得
    series = chart.chart_data.series[1]

    # シリーズデータを入力
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # OverLap値を設定
    series.parent_series_group.overlap = 100         

    # プレゼンテーションをディスクに書き込む
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```