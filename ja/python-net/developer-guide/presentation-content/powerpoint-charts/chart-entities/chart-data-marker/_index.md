---
title: Python でプレゼンテーションのチャート データ マーカーを管理
linktitle: データ マーカー
type: docs
url: /ja/python-net/chart-data-marker/
keywords:
- チャート
- データ ポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶしタイプ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides でチャート データ マーカーをカスタマイズする方法を学び、PPT、PPTX、ODP 形式のプレゼンテーションにインパクトを与える明確なコード例を提供します。"
---

## **チャート マーカー オプションの設定**
特定の系列内のチャート データ ポイントにマーカーを設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータ ポイントを追加します。
- プレゼンテーションをディスクに保存します。

以下の例では、データ ポイント レベルでチャート マーカー オプションを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # デフォルトのチャートを作成
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # デフォルトのチャート データ ワークシート インデックスを取得
    defaultWorksheetIndex = 0

    # チャート データ ワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # デモ 系列を削除
    chart.chart_data.series.clear()

    # 新しい系列を追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # 画像を設定
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # 画像を設定
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # 最初のチャート系列を取得
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

    # チャート 系列マーカーを変更
    series.marker.size = 15

    # プレゼンテーションをディスクに保存
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**標準で利用できるマーカー形状は何ですか？**

標準形状（円、正方形、ダイヤモンド、三角形など）が利用可能です。リストは [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/) 列挙体で定義されています。標準外の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタム ビジュアルをエミュレートできます。

**チャートを画像や SVG にエクスポートするときにマーカーは保持されますか？**

はい。チャートを [ラスタ形式](/slides/ja/python-net/convert-powerpoint-to-png/) にレンダリングしたり、[SVG としてシェイプを保存](/slides/ja/python-net/render-a-slide-as-an-svg-image/) したりする場合、マーカーは外観と設定（サイズ、塗りつぶし、アウトライン）を保持します。