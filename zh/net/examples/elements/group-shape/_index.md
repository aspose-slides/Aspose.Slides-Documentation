---
title: 组形状
type: docs
weight: 170
url: /zh/net/examples/elements/group-shape/
keywords:
- 组
- 添加组形状
- 访问组形状
- 删除组形状
- 取消分组形状
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理分组形状：使用 C# 示例在 PPT、PPTX 和 ODP 演示文稿中创建、嵌套、对齐、重新排序和设置分组形状的样式。"
---
使用 **Aspose.Slides for .NET** 创建形状组、访问、取消分组和删除的示例。

## **添加组形状**

创建一个包含两个基本形状的组。

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

## **访问组形状**

从幻灯片中检索第一个组形状。

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

## **删除组形状**

从幻灯片中删除组形状。

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **取消分组形状**

将形状移出组容器。

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // 将形状移出组。
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```