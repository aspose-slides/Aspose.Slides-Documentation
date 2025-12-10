---
title: テーブル
type: docs
weight: 120
url: /ja/net/examples/elements/table/
keywords:
- テーブル例
- テーブル追加
- テーブルアクセス
- テーブル削除
- セル結合
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してテーブルを作成および書式設定します。データの挿入、セルの結合、罫線のスタイル設定、コンテンツの配置、PPT、PPTX、ODP へのインポート/エクスポートが可能です。"
---

**Aspose.Slides for .NET** を使用したテーブルの追加、アクセス、削除、セル結合の例。

## **テーブルの追加**

2 行 2 列のシンプルなテーブルを作成します。
```csharp
static void Add_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```


## **テーブルへのアクセス**

スライド上の最初のテーブルシェイプを取得します。
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // スライド上の最初のテーブルにアクセス
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## **テーブルの削除**

スライドからテーブルを削除します。
```csharp
static void Remove_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```


## **テーブルセルの結合**

テーブルの隣接するセルを 1 つのセルに結合します。
```csharp
static void Merge_Table_Cells()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```
