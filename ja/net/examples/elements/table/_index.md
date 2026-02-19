---
title: テーブル
type: docs
weight: 120
url: /ja/net/examples/elements/table/
keywords:
- テーブル
- テーブルを追加
- テーブルにアクセス
- テーブルを削除
- セルを結合
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でテーブルを操作します：作成、書式設定、セルの結合、スタイルの適用、データのインポート、そして PPT、PPTX、ODP 用の C# サンプルでエクスポートします。"
---
**Aspose.Slides for .NET** を使用したテーブルの追加、アクセス、削除、セル結合の例です。

## **テーブルの追加**

2 行 2 列のシンプルなテーブルを作成します。

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **テーブルにアクセス**

スライド上の最初のテーブル シェイプを取得します。

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // スライド上の最初のテーブルにアクセスします。
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **テーブルの削除**

スライドからテーブルを削除します。

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **テーブルセルの結合**

テーブルの隣接するセルを 1 つのセルに結合します。

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```