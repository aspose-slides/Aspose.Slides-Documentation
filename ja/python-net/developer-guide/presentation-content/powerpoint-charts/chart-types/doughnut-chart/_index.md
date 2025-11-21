---
title: Python を使用したプレゼンテーションのドーナツチャートのカスタマイズ
linktitle: ドーナツチャート
type: docs
weight: 30
url: /ja/python-net/doughnut-chart/
keywords:
- ドーナツチャート
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument 形式の動的プレゼンテーションに対応したドーナツチャートの作成とカスタマイズ方法を学びます。"
---

## **ドーナツチャートの中心ギャップを指定する**
ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化します。
- スライドにドーナツチャートを追加します。
- ドーナツチャートの穴のサイズを指定します。
- プレゼンテーションをディスクに書き出します。

以下の例では、ドーナツチャートの穴のサイズを設定しています。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation クラスのインスタンスを作成する
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # プレゼンテーションをディスクに保存する
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**複数のリングを持つマルチレベルのドーナツを作成できますか？**

はい。単一のドーナツチャートに複数のシリーズを追加すると、各シリーズが別々のリングになります。リングの順序はコレクション内のシリーズの順序で決まります。

**「エクスプローデッド」ドーナツ（スライスが分離されたもの）はサポートされていますか？**

はい。Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) があり、データポイントに爆発プロパティがあるため、個々のスライスを分離できます。

**レポート用にドーナツチャートの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。[raster image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) にレンダリングするか、[SVG image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) にエクスポートできます。