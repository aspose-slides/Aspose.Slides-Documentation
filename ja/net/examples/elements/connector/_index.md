---
title: コネクタ
type: docs
weight: 190
url: /ja/net/examples/elements/connector/
keywords:
- コネクタ
- コネクタの追加
- コネクタへのアクセス
- コネクタの削除
- シェイプの再接続
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してシェイプ間にコネクタを追加、ルーティング、スタイル設定する方法を学びます。C# の例で PPT、PPTX、ODP プレゼンテーションを対象としています。"
---
この記事では、**Aspose.Slides for .NET** を使用して、シェイプをコネクタで接続し、ターゲットを変更する方法を示します。

## **コネクタを追加**

スライド上の2点間にコネクタシェイプを挿入します。

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **コネクタにアクセス**

スライドに追加された最初のコネクタシェイプを取得します。

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **コネクタを削除**

スライドからコネクタを削除します。

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **シェイプを再接続**

開始対象と終了対象を割り当てて、コネクタを2つのシェイプに接続します。

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```