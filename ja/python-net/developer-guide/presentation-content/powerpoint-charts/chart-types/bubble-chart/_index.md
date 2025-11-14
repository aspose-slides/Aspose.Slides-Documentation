---
title: Python でプレゼンテーションのバブル チャートをカスタマイズする
linktitle: バブル チャート
type: docs
url: /ja/python-net/bubble-chart/
keywords:
- バブル チャート
- バブルのサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument で強力なバブル チャートを作成およびカスタマイズし、データ ビジュアライゼーションを簡単に強化する方法をご紹介します。"
---

## **バブルチャートサイズのスケーリング**
Aspose.Slides for Python via .NETはバブルチャートサイズのスケーリングをサポートしています。Aspose.Slides for Python via .NET **ChartSeries.bubble_size_scale**および**ChartSeriesGroup.bubble_size_scale**プロパティが追加されました。以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **バブルチャートサイズとしてデータを表現する**
プロパティ **bubble_size_representation**がChartSeriesとChartSeriesGroupクラスに追加されました。**bubble_size_representation**は、バブルチャートにおけるバブルサイズ値の表現方法を指定します。可能な値は、**BubbleSizeRepresentationType.AREA**および**BubbleSizeRepresentationType.WIDTH**です。それに応じて、**BubbleSizeRepresentationType**列挙型が追加され、データをバブルチャートサイズとして表現するための可能な方法を指定します。サンプルコードは以下に示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```