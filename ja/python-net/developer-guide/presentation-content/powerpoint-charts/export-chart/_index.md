---
title: チャートのエクスポート
type: docs
weight: 90
url: /ja/python-net/export-chart/
keywords:
- チャート
- チャート画像
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides for Python
description: "PythonでPowerPointプレゼンテーションからチャート画像を取得する"
---

## **チャート画像の取得**
Aspose.Slides for Python via .NETは特定のチャートの画像を抽出するサポートを提供します。以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```