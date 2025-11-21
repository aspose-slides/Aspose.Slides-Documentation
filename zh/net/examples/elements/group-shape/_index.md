---
title: 组形状
type: docs
weight: 170
url: /zh/net/examples/elements/group-shape/
keywords:
- 分组示例
- 添加组形状
- 访问组形状
- 删除组形状
- 取消组合形状
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中处理组形状：创建和取消组合，重新排序子形状，设置转换和边界，适用于 PowerPoint 和 OpenDocument."
---

使用 **Aspose.Slides for .NET** 创建形状组、访问、取消组合和删除的示例。

## 添加组形状

创建一个包含两个基本形状的组。
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


## 访问组形状

从幻灯片中检索第一个组形状。
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


## 删除组形状

从幻灯片中删除组形状。
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## 取消组合形状

将形状从组容器中移出。
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // 将形状移出组
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
