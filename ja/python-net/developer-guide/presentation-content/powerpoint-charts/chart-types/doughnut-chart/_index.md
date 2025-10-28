---
title: Python を使用したプレゼンテーションでのドーナツ グラフのカスタマイズ
linktitle: ドーナツ グラフ
type: docs
weight: 30
url: /ja/python-net/doughnut-chart/
keywords:
- ドーナツ グラフ
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument 形式に対応した動的なプレゼンテーション向けに、ドーナツ グラフの作成とカスタマイズ方法をご紹介します。
---

## **ドーナツ グラフの中心ギャップを指定する**
ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
- スライドにドーナツ グラフを追加します。
- ドーナツ グラフの穴のサイズを指定します。
- プレゼンテーションをディスクに保存します。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Write presentation to disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**複数のリングを持つマルチレベルのドーナツを作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序はコレクション内の系列の順序で決まります。

**「エクスプローデッド」ドーナツ（スライスが分離されたもの）はサポートされていますか？**

はい。Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) があり、データポイントに爆発プロパティがあるので、個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するにはどうすればよいですか？**

グラフはシェイプです。[ラスタ画像](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) にレンダリングするか、[SVG 画像](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) としてエクスポートできます。