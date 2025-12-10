---
title: グループシェイプ
type: docs
weight: 170
url: /ja/net/examples/elements/group-shape/
keywords:
- グループ例
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
description: "Aspose.Slides を使用して C# でグループシェイプを操作します。作成やグループ解除、子シェイプの並び替え、変形と境界の設定を PowerPoint と OpenDocument の両方で行えます。"
---

**Aspose.Slides for .NET** を使用して、シェイプのグループ作成、アクセス、グループ解除、削除の例を示します。

## **グループ シェイプの追加**

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


## **グループ シェイプへのアクセス**

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


## **グループ シェイプの削除**

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


## **シェイプのグループ解除**

シェイプをグループ コンテナから取り出します。
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // シェイプをグループから外す
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
