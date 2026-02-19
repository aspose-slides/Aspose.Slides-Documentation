---
title: チャート
type: docs
weight: 60
url: /ja/net/examples/elements/chart/
keywords:
- チャート
- チャートの追加
- チャートへのアクセス
- チャートの削除
- チャートの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してチャートをマスター: C# の例で PPT、PPTX、ODP にチャートを作成、書式設定、データバインド、エクスポートする方法。"
---
**Aspose.Slides for .NET** を使用して、さまざまなチャートタイプの追加、取得、削除、および更新の例です。以下のスニペットは基本的なチャート操作を示しています。

## **チャートの追加**

このメソッドは、最初のスライドにシンプルなエリアチャートを追加します。

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 最初のスライドにシンプルなエリアチャートを追加します。
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **チャートの取得**

チャートを作成した後、シェイプコレクションから取得できます。

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // スライド上の最初のチャートにアクセスします。
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **チャートの削除**

次のコードはスライドからチャートを削除します。

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // チャートを削除します。
    slide.Shapes.Remove(chart);
}
```

## **チャート データの更新**

タイトルなどのチャート プロパティを変更できます。

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // チャートのタイトルを変更します。
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```