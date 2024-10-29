---
title: ドーナツチャート
type: docs
weight: 30
url: /ja/net/doughnut-chart/
keywords: "ドーナツチャート, 中央の隙間, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションのドーナツチャートの中央の隙間を指定する"
---

## **ドーナツチャートの中央の隙間を指定する**
ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- スライドにドーナツチャートを追加します。
- ドーナツチャートの穴のサイズを指定します。
- プレゼンテーションをディスクに保存します。

以下の例では、ドーナツチャートの穴のサイズを設定しています。

```c#
// Presentationクラスのインスタンスを作成します
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// プレゼンテーションをディスクに保存します
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```