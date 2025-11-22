---
title: バブルチャート
type: docs
url: /ja/net/bubble-chart/
keywords: "バブルチャート, チャートサイズ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET での PowerPoint プレゼンテーションにおけるバブルチャートサイズ"
---

## **バブル チャートのサイズスケーリング**
Aspose.Slides for .NET はバブル チャートのサイズスケーリングをサポートします。Aspose.Slides for .NET の **IChartSeries.BubbleSizeScale** および **IChartSeriesGroup.BubbleSizeScale** プロパティが追加されました。以下にサンプル例を示します。
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **バブル チャート サイズとしてデータを表現**
IChartSeries、IChartSeriesGroup インターフェイス、および関連クラスに **BubbleSizeRepresentation** プロパティが追加されました。**BubbleSizeRepresentation** はバブル チャートでバブルサイズの値をどのように表すかを指定します。使用できる値は **BubbleSizeRepresentationType.Area** と **BubbleSizeRepresentationType.Width** です。それに応じて、データをバブル チャートのサイズとして表す方法を指定するための **BubbleSizeRepresentationType** 列挙体が追加されました。以下にサンプルコードを示します。
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **よくある質問**

**「3-D 効果付きバブル チャート」はサポートされていますか、また通常のものとどのように異なりますか？**

はい。別個のチャートタイプとして「Bubble with 3-D」があります。バブルに 3-D スタイルが適用されますが、追加の軸は追加されません。データは X-Y-S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で利用可能です。

**バブル チャートの系列数やポイント数に制限はありますか？**

API レベルでの明確な上限はありません。制約はパフォーマンスや対象の PowerPoint バージョンによって決まります。可読性とレンダリング速度の観点から、ポイント数は適切な範囲に抑えることが推奨されます。

**エクスポート時にバブル チャートの外観 (PDF、画像) はどのように変わりますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが実行します。ラスタ/ベクタ形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されるため、印刷時には十分な DPI を選択してください。