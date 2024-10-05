---
title: チャートデータテーブル
type: docs
url: /net/chart-data-table/
keywords: "フォントプロパティ, チャートデータテーブル, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでのPowerPointプレゼンテーションにおけるチャートデータベーステーブルのフォントプロパティを設定する"
---

## **チャートデータテーブルのフォントプロパティを設定する**
Aspose.Slides for .NETは、シリーズカラーのカテゴリの色を変更するサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```