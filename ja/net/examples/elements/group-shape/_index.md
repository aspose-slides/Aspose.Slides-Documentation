---
title: グループ シェイプ
type: docs
weight: 170
url: /ja/net/examples/elements/group-shape/
keywords:
- グループ
- グループ シェイプを追加
- グループ シェイプにアクセス
- グループ シェイプを削除
- シェイプのグループ解除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NETでグループ化されたシェイプを管理します：C#の例を使用してPPT、PPTX、ODPプレゼンテーションでグループシェイプを作成、入れ子化、配置、順序変更、スタイル設定します。"
---
**Aspose.Slides for .NET** を使用した、図形のグループ作成、アクセス、グループ解除、削除の例。

## **グループ シェイプを追加**

2つの基本図形を含むグループを作成します。

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **グループ シェイプへのアクセス**

スライドから最初のグループ シェイプを取得します。

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **グループ シェイプの削除**

スライドからグループ シェイプを削除します。

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **シェイプのグループ解除**

シェイプをグループ コンテナから取り出します。

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // グループからシェイプを移動します。
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```