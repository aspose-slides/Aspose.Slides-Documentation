---
title: Pythonでプレゼンテーションのバブルチャートをカスタマイズ
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument で強力なバブルチャートを作成・カスタマイズし、データ視覚化を簡単に強化します。"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for Python via .NETはバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for Python via .NETでは**ChartSeries.bubble_size_scale**および**ChartSeriesGroup.bubble_size_scale**プロパティが追加されました。以下にサンプル例を示します。  
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```


## **バブルチャートサイズとしてデータを表す**
ChartSeries および ChartSeriesGroup クラスに **bubble_size_representation** プロパティが追加されました。**bubble_size_representation** はバブルチャートでバブルサイズの値をどのように表すかを指定します。可能な値は **BubbleSizeRepresentationType.AREA** と **BubbleSizeRepresentationType.WIDTH** です。これに伴い、データをバブルチャートのサイズとして表す方法を示す **BubbleSizeRepresentationType** 列挙体が追加されました。以下にサンプルコードを示します。  
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**「3-D 効果付きバブルチャート」はサポートされていますか、通常のものとどう違いますか？**  
はい。別個のチャートタイプ「Bubble with 3-D」があります。バブルに 3-D スタイルを適用しますが、追加の軸は追加されません。データは X-Y-S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で利用可能です。

**バブルチャートのシリーズ数やデータ点の数に制限はありますか？**  
API レベルでの明確な上限はありません。制約はパフォーマンスと対象となる PowerPoint バージョンに依存します。可読性とレンダリング速度を考慮し、データ点の数は適切に抑えることを推奨します。

**エクスポート時にバブルチャートの外観はどのように変わりますか（PDF、画像）？**  
サポートされている形式へエクスポートすると、チャートの外観は保持されます。レンダリングは Aspose.Slides エンジンが行います。ラスタ/ベクタ形式の場合、一般的なチャート描画の規則（解像度、アンチエイリアスなど）が適用されるため、印刷時は十分な DPI を選択してください。