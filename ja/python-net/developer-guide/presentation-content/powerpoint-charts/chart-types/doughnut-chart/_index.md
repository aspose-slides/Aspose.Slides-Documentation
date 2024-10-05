---
title: ドーナツチャート
type: docs
weight: 30
url: /python-net/doughnut-chart/
keywords: "ドーナツチャート, 中央の隙間, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでのPowerPointプレゼンテーションにおけるドーナツチャートの中央の隙間を指定します"
---

## **ドーナツチャートの中央の隙間を指定する**
ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- スライドにドーナツチャートを追加します。
- ドーナツチャートの穴のサイズを指定します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツチャートの穴のサイズを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentationクラスのインスタンスを作成します
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # プレゼンテーションをディスクに書き込みます
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```