---
title: Python でプレゼンテーションのチャートデータマーカーを管理する
linktitle: データマーカー
type: docs
url: /ja/python-net/chart-data-marker/
keywords:
- チャート
- データポイント
- マーカー
- マーカーオプション
- マーカーサイズ
- 塗りつぶしタイプ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides でチャートデータマーカーをカスタマイズする方法を学び、明確なコード例で PPT、PPTX、ODP 形式のプレゼンテーション効果を高めましょう。"
---

## **チャートマーカーオプションを設定する**
マーカーは特定の系列内のチャートデータポイントに設定できます。チャートマーカーオプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # デフォルトのチャートを作成
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # デフォルトのチャートデータワークシートインデックスを取得
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # デモシリーズを削除
    chart.chart_data.series.clear()

    # 新しい系列を追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "シリーズ 1"), chart.type)
            
    # 画像を設定
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # 画像を設定
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # 最初のチャート系列を取得
    series = chart.chart_data.series[0]

    # （1:3）に新しいポイントを追加
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # チャート系列マーカーを変更
    series.marker.size = 15

    # プレゼンテーションをディスクに書き込む
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```