---
title: チャート
type: docs
weight: 60
url: /ja/net/examples/elements/chart/
keywords:
- チャート例
- チャートの追加
- チャートへのアクセス
- チャートの削除
- チャートの更新
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してチャートを作成およびカスタマイズします：データの追加、シリーズ・軸・ラベルの書式設定、種類の変更、そしてエクスポートが可能です。PPT、PPTX、ODP に対応しています。"
---

**Aspose.Slides for .NET** を使用した、さまざまなチャートタイプの追加、アクセス、削除、更新の例です。以下のスニペットは基本的なチャート操作を示しています。

## **チャートの追加**

このメソッドは、最初のスライドにシンプルなエリアチャートを追加します。
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // 最初のスライドにシンプルな列チャートを追加
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## **チャートへのアクセス**

チャートを作成した後、シェイプコレクションから取得できます。
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // スライド上の最初のチャートにアクセス
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## **チャートの削除**

次のコードはスライドからチャートを削除します。
```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // チャートを削除
    slide.Shapes.Remove(chart);
}
```


## **チャート データの更新**

タイトルなどのチャートプロパティを変更できます。
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // チャートのタイトルを変更
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
