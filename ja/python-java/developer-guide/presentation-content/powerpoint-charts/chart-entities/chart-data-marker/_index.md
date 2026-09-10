---
title: Python を使用したプレゼンテーションでのチャート データ マーカーの管理
linktitle: データ マーカー
type: docs
url: /ja/python-java/chart-data-marker/
keywords:
- チャート
- データ ポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶしタイプ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python 用 Aspose.Slides でチャート データ マーカーをカスタマイズする方法を学び、Java 経由で PPT および PPTX 形式のプレゼンテーション効果を高める、分かりやすい Python コード例をご紹介します。"
---
## **概要**

この記事では、Aspose.Slides でチャート データ マーカーを操作する方法を説明します。チャートの作成、シリーズとそのデータ ポイントへのアクセス、データポイントレベルでマーカーに画像塗りを適用、マーカー サイズの調整、更新されたプレゼンテーションの保存方法を示します。また、標準のマーカー形状は[MarkerStyleType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markerstyletype/)列挙型で利用でき、チャートをラスタ形式や SVG にエクスポートする際にマーカーの外観が保持されることにも言及しています。

## **チャート マーカー オプションの設定**
マーカーは特定のシリーズ内のチャート データ ポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順を実行します：

- [Presentation] クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート シリーズにアクセスします。
- 新しいデータ ポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例はデータポイントレベルでチャート マーカー オプションを設定します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

    # 空のプレゼンテーションを作成します。
presentation = Presentation()
try:
    # 最初のスライドにアクセス
    slide = presentation.getSlides().get_Item(0)

    # デフォルトのチャートを作成
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # デフォルトのチャート データ ワークシート インデックスを取得。
    default_worksheet_index = 0

    # チャート データのワークブックを取得。
    workbook = chart.getChartData().getChartDataWorkbook()

    # デモシリーズを削除
    chart.getChartData().getSeries().clear()

    # 新しいシリーズを追加
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # 最初の画像を読み込む。
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # 2 番目の画像を読み込む。
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # 最初のチャートシリーズにアクセス。
    series = chart.getChartData().getSeries().get_Item(0)

    # データ ポイントを追加。
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # チャートシリーズのマーカー サイズを変更。
    series.getMarker().setSize(15)

    # チャート付きプレゼンテーションを保存。
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**標準で利用可能なマーカー形状は何ですか？**

標準形状（円、正方形、ダイヤモンド、三角形など）が利用可能で、一覧は[MarkerStyleType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markerstyletype/)クラスで定義されています。標準外の形状が必要な場合は、画像塗りのマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**チャートを画像または SVG にエクスポートする際にマーカーは保持されますか？**

はい。チャートを[ラスタ形式](/slides/ja/python-java/convert-powerpoint-to-png/)にレンダリングする場合や、[SVG としてのシェイプ](/slides/ja/python-java/render-a-slide-as-an-svg-image/)を保存する場合、マーカーはサイズ、塗り、アウトラインなどの外観と設定を保持します。