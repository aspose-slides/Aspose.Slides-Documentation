---
title: Python を使用したプレゼンテーションでのバブルチャートのカスタマイズ
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument に強力なバブルチャートを作成・カスタマイズし、データ可視化を簡単に向上させます。"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for Python via .NET はバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for Python via .NET では **ChartSeries.bubble_size_scale** および **ChartSeriesGroup.bubble_size_scale** プロパティが追加されました。以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **データをバブルチャートのサイズとして表現**
**bubble_size_representation** プロパティが ChartSeries、ChartSeriesGroup クラスに追加されました。**bubble_size_representation** はバブルチャートでバブルサイズの値をどのように表現するかを指定します。可能な値は **BubbleSizeRepresentationType.AREA** と **BubbleSizeRepresentationType.WIDTH** です。これに合わせて、データをバブルチャートのサイズとして表現する方法を示す **BubbleSizeRepresentationType** 列挙型が追加されました。以下にサンプルコードを示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**「3-D 効果付きバブルチャート」はサポートされていますか？通常のバブルチャートと何が違いますか？**

はい、別のチャートタイプとして「Bubble with 3-D」が用意されています。このタイプはバブルに 3-D スタイルを適用しますが、追加の軸はありません。データは X‑Y‑S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で利用できます。

**バブルチャートの系列数やデータポイント数に制限はありますか？**

API レベルでのハードな制限はありません。制限はパフォーマンスや対象となる PowerPoint バージョンによって決まります。可読性と描画速度を考慮し、ポイント数は適切に抑えることを推奨します。

**エクスポート（PDF、画像など）するとバブルチャートの外観はどう変わりますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンによって行われます。ラスター／ベクター形式では一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されるため、印刷用には十分な DPI を選択してください。