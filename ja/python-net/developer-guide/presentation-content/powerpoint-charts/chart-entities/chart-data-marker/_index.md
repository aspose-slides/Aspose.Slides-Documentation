---
title: Pythonでプレゼンテーションのチャート データ マーカーを管理
linktitle: データ マーカー
type: docs
url: /ja/python-net/chart-data-marker/
keywords:
- チャート
- データポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶし タイプ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides でチャート データ マーカーをカスタマイズし、PPT、PPTX、ODP 形式のプレゼンテーションのインパクトを高める明確なコード例をご紹介します。"
---

## **チャートマーカーオプションの設定**
マーカーは特定のシリーズ内のチャートデータポイントに設定できます。チャートマーカーオプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャートシリーズを取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き出します。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しています。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # デフォルトのチャートを作成
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # デフォルトのチャート データワークシート インデックスを取得
    defaultWorksheetIndex = 0

    # チャート データ ワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # デモ シリーズを削除
    chart.chart_data.series.clear()

    # 新しいシリーズを追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # 画像を設定
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # 画像を設定
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # 最初のチャートシリーズを取得
    series = chart.chart_data.series[0]

    # そこに新しいポイント (1:3) を追加
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

    # チャートシリーズのマーカーを変更
    series.marker.size = 15

    # プレゼンテーションをディスクに保存
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**利用できるマーカー形状は何ですか？**

標準の形状（円、正方形、菱形、三角形など）が利用可能で、一覧は [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/) 列挙体で定義されています。非標準の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタムビジュアルをエミュレートしてください。

**チャートを画像や SVG にエクスポートした場合、マーカーは保持されますか？**

はい。チャートを [raster formats](/slides/ja/python-net/convert-powerpoint-to-png/) にレンダリングしたり、[shapes as SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/) として保存したりすると、マーカーは外観や設定（サイズ、塗りつぶし、アウトライン）を保持します。