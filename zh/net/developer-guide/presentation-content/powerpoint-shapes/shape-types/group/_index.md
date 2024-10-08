---
title: 组
type: docs
weight: 40
url: /net/group/
keywords: "组形状, PowerPoint形状, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在C#或.NET中将组形状添加到PowerPoint演示文稿"
---

## **添加组形状**
Aspose.Slides支持在幻灯片上处理组形状。此功能帮助开发人员支持更丰富的演示文稿。Aspose.Slides for .NET支持添加或访问组形状。可以向添加的组形状中添加形状以填充它或访问组形状的任何属性。使用Aspose.Slides for .NET将组形状添加到幻灯片：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 将组形状添加到幻灯片。
1. 向添加的组形状中添加形状。
1. 将修改后的演示文稿保存为PPTX文件。

下面的示例将组形状添加到幻灯片。

```c#
// 实例化Presentation类 
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片 
    ISlide sld = pres.Slides[0];

    // 访问幻灯片的形状集合 
    IShapeCollection slideShapes = sld.Shapes;

    // 向幻灯片添加组形状 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // 在添加的组形状内部添加形状 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 添加组形状框架 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // 将PPTX文件写入磁盘 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **访问AltText属性**
本主题展示了附带代码示例的简单步骤，旨在添加组形状并访问幻灯片上组形状的AltText属性。使用Aspose.Slides for .NET访问幻灯片中组形状的AltText：

1. 实例化表示PPTX文件的`Presentation`类。
1. 通过使用其索引获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组形状。
1. 访问AltText属性。

下面的示例访问组形状的替代文本。

```c#
// 实例化表示PPTX文件的Presentation类
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
            // 访问AltText属性
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```