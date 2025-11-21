---
title: .NET のプレゼンテーションでバブルチャートをカスタマイズ
linktitle: バブルチャート
type: docs
url: /ja/net/bubble-chart/
keywords:
- バブルチャート
- バブルサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint で強力なバブルチャートを作成およびカスタマイズし、データの可視化を簡単に強化します。"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for .NET はバブルチャートのサイズスケーリングをサポートしています。Aspose.Slides for .NET では **IChartSeries.BubbleSizeScale** および **IChartSeriesGroup.BubbleSizeScale** プロパティが追加されました。以下にサンプル例を示します。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```





## **データをバブルチャートのサイズとして表す**
IChartSeries、IChartSeriesGroup インターフェイスおよび関連クラスに **BubbleSizeRepresentation** プロパティが追加されました。**BubbleSizeRepresentation** はバブルチャートでバブルサイズの値をどのように表すかを指定します。可能な値は **BubbleSizeRepresentationType.Area** と **BubbleSizeRepresentationType.Width** です。これに伴い、データをバブルチャートのサイズとして表すための可能な方法を指定する **BubbleSizeRepresentationType** 列挙体が追加されました。以下にサンプルコードを示します。

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**「3-D 効果付きバブルチャート」はサポートされていますか？通常のものとどのように異なりますか？**

はい。別個のチャートタイプとして「Bubble with 3-D」が用意されています。バブルに 3-D スタイルが適用されますが、追加の軸はありません。データは X‑Y‑S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で利用可能です。

**バブルチャートのシリーズ数やポイント数に制限はありますか？**

API レベルでのハードな制限はありません。制約はパフォーマンスと対象となる PowerPoint バージョンによって決まります。可読性と描画速度を考慮し、ポイント数は適切に抑えることを推奨します。

**エクスポート（PDF、画像など）はバブルチャートの外観にどのように影響しますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが行います。ラスター／ベクタ形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されるため、印刷用途では十分な DPI を選択してください。