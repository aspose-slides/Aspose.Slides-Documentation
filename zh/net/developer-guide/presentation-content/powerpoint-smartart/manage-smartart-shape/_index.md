---
title: 管理 SmartArt 形状
type: docs
weight: 20
url: /zh/net/manage-smartart-shape/
keywords: "SmartArt 形状, SmartArt 形状样式, SmartArt 形状颜色样式, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中管理 PowerPoint 演示文稿中的 SmartArt"
---

## **创建 SmartArt 形状**
Aspose.Slides for .NET 现在使用户能够从零开始在幻灯片中添加自定义 SmartArt 形状。Aspose.Slides for .NET 提供了最简单的 API，以最便捷的方式创建 SmartArt 形状。要在幻灯片中创建 SmartArt 形状，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 通过设置其 LayoutType 添加 SmartArt 形状。
- 将修改后的演示文稿写入 PPTX 文件。

```c#
// 实例化演示文稿
using (Presentation pres = new Presentation())
{

    // 访问演示文稿幻灯片
    ISlide slide = pres.Slides[0];

    // 添加 SmartArt 形状
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // 保存演示文稿
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **访问幻灯片中的 SmartArt 形状**
以下代码将用于访问添加到演示文稿幻灯片中的 SmartArt 形状。在示例代码中，我们将遍历幻灯片中的每个形状，并检查它是否是 SmartArt 形状。如果形状是 SmartArt 类型，则将其转换为 SmartArt 实例。

```c#
// 加载所需的演示文稿
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // 遍历第一个幻灯片中的每个形状
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("形状名称:" + smart.Name);

        }
    }
}
```



## **使用特定布局类型访问 SmartArt 形状**
以下示例代码将有助于访问具有特定 LayoutType 的 SmartArt 形状。请注意，您无法更改 SmartArt 的 LayoutType，因为它是只读的，仅在添加 SmartArt 形状时设置。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状转换为 SmartArt。
- 检查具有特定 LayoutType 的 SmartArt 形状，并执行后续所需的操作。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍历第一个幻灯片中的每个形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状转换为 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // 检查 SmartArt 布局
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("在这里做一些事情....");
            }
        }
    }
}
```



## **更改 SmartArt 形状样式**
以下示例代码将有助于访问具有特定 LayoutType 的 SmartArt 形状。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状转换为 SmartArt。
- 查找具有特定样式的 SmartArt 形状。
- 为 SmartArt 形状设置新样式。
- 保存演示文稿。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍历第一个幻灯片中的每个形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // 检查 SmartArt 样式
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // 更改 SmartArt 样式
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // 保存演示文稿
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **更改 SmartArt 形状颜色样式**
在本例中，我们将学习如何更改任何 SmartArt 形状的颜色样式。在以下示例代码中，将访问具有特定颜色样式的 SmartArt 形状，并更改其样式。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状转换为 SmartArt。
- 查找具有特定颜色样式的 SmartArt 形状。
- 为 SmartArt 形状设置新颜色样式。
- 保存演示文稿。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍历第一个幻灯片中的每个形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // 检查 SmartArt 颜色类型
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // 更改 SmartArt 颜色类型
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // 保存演示文稿
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```