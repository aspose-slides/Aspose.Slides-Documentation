---
title: Python を使用したプレゼンテーションのバブルチャートのカスタマイズ
linktitle: バブルチャート
type: docs
url: /ja/python-net/bubble-chart/
keywords:
- バブルチャート
- バブルサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument で強力なバブルチャートを作成およびカスタマイズし、データ可視化を簡単に強化します。"
---

## **バブルチャートのサイズスケーリング**

Aspose.Slides for Python via .NET はバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for Python via .NET の **ChartSeries.bubble_size_scale** および **ChartSeriesGroup.bubble_size_scale** プロパティが追加されました。以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **データをバブルチャートのサイズとして表現**

ChartSeries、ChartSeriesGroup クラスに **bubble_size_representation** プロパティが追加されました。**bubble_size_representation** はバブルサイズの値がバブルチャートでどのように表現されるかを指定します。可能な値は **BubbleSizeRepresentationType.AREA** と **BubbleSizeRepresentationType.WIDTH** です。したがって、データをバブルチャートのサイズとして表現する方法を指定する **BubbleSizeRepresentationType** 列挙体が追加されました。サンプルコードは以下の通りです。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**「3D 効果付きバブルチャート」はサポートされていますか？通常のバブルチャートと何が違うのですか？**

はい。別個のチャートタイプとして「Bubble with 3-D」が用意されています。バブルに 3D スタイルが適用されますが、追加の軸は付加されません。データは X‑Y‑S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で利用できます。

**バブルチャートの系列数やデータポイント数に制限はありますか？**

API レベルでのハードな制限はありません。制限はパフォーマンスや対象となる PowerPoint のバージョンによって決まります。可読性と描画速度を考慮し、ポイント数は適切な範囲に抑えることを推奨します。

**エクスポート（PDF、画像など）はバブルチャートの外観にどのように影響しますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが実行します。ラスタ/ベクタ形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されるため、印刷用には十分な DPI を選択してください。