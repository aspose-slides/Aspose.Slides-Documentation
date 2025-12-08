---
title: 组
type: docs
weight: 40
url: /zh/net/group/
keywords: "组合形状, PowerPoint 形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中将组合形状添加到 PowerPoint 演示文稿"
---

## **添加组合形状**
Aspose.Slides 支持在幻灯片上使用组合形状。此功能帮助开发者创建更丰富的演示文稿。Aspose.Slides for .NET 支持添加或访问组合形状。可以向已添加的组合形状中添加形状以填充它，或访问组合形状的任何属性。使用 Aspose.Slides for .NET 将组合形状添加到幻灯片的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加组合形状。
1. 向已添加的组合形状中加入形状。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加了一个组合形状。
```c#
// 实例化 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 访问幻灯片的形状集合
    IShapeCollection slideShapes = sld.Shapes;

    // 向幻灯片添加组形状
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // 向已添加的组形状中添加形状
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 添加组形状框架
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // 将 PPTX 文件写入磁盘
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **访问 AltText 属性**
本主题展示了添加组形状并访问幻灯片上组形状的 AltText 属性的简单步骤和代码示例。要使用 Aspose.Slides for .NET 在幻灯片中访问组形状的 AltText：


## **访问 AltText 属性**
本章节展示了添加组合形状并访问幻灯片上组合形状的 AltText 属性的简要步骤和代码示例。使用 Aspose.Slides for .NET 在幻灯片中访问组合形状的 AltText 的步骤如下：

1. 实例化表示 PPTX 文件的 `Presentation` 类。
1. 通过索引获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组合形状。
1. 访问 AltText 属性。

下面的示例获取了组合形状的替代文本。
```c#
 // 实例化表示 PPTX 文件的 Presentation 类
 Presentation pres = new Presentation("AltText.pptx");

 // 获取第一张幻灯片
 ISlide sld = pres.Slides[0];

 for (int i = 0; i < sld.Shapes.Count; i++)
 {
     // 访问幻灯片的形状集合
     IShape shape = sld.Shapes[i];

     if (shape is GroupShape)
     {
         // 访问组形状。
         IGroupShape grphShape = (IGroupShape)shape;
         for (int j = 0; j < grphShape.Shapes.Count; j++)
         {
             IShape shape2 = grphShape.Shapes[j];
             // 访问 AltText 属性
             Console.WriteLine(shape2.AlternativeText);
         }
     }
 }
```


## **FAQ**

**是否支持嵌套分组（组内再包含组）？**

是的。[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) 具有 [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) 属性，直接表明支持层级结构（一个组可以是另一个组的子组）。

**如何控制组相对于幻灯片上其他对象的 Z 顺序？**

使用 [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) 的 [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) 属性可检查其在显示堆栈中的位置。

**是否可以防止移动/编辑/取消分组？**

可以。组的锁定部分通过 [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/) 暴露，您可以限制对该对象的操作。
