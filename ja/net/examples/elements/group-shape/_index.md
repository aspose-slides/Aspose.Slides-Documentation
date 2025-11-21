---
title: グループシェイプ
type: docs
weight: 170
url: /ja/net/examples/elements/group-shape/
keywords:
- グループの例
- グループシェイプの追加
- グループシェイプへのアクセス
- グループシェイプの削除
- シェイプのグループ解除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してグループシェイプを操作します。作成とグループ解除、子シェイプの並び替え、PowerPoint と OpenDocument 間での変換と境界の設定を行います。"
---

**Aspose.Slides for .NET** を使用した形状のグループ作成、アクセス、グループ解除、削除の例。

## Add a Group Shape

2つの基本シェイプを含むグループを作成します。
```csharp
static void Add_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```


## Access a Group Shape

スライドから最初のグループ シェイプを取得します。
```csharp
static void Access_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```


## Remove a Group Shape

スライドからグループ シェイプを削除します。
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## Ungroup Shapes

シェイプをグループ コンテナから外に移動します。
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // グループからシェイプを移動する
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
