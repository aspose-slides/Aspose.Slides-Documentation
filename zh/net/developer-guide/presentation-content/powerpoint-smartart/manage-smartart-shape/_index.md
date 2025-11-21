---
title: 在 .NET 中管理演示文稿中的 SmartArt 图形
linktitle: SmartArt 图形
type: docs
weight: 20
url: /zh/net/manage-smartart-shape/
keywords:
- SmartArt 对象
- SmartArt 图形
- SmartArt 样式
- SmartArt 颜色
- 创建 SmartArt
- 添加 SmartArt
- 编辑 SmartArt
- 更改 SmartArt
- 访问 SmartArt
- SmartArt 布局类型
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中自动化 PowerPoint SmartArt 的创建、编辑和样式设置，提供简洁的代码示例和注重性能的指导。"
---

## **创建 SmartArt 形状**
Aspose.Slides for .NET 现在可以从头在幻灯片中添加自定义 SmartArt 形状。Aspose.Slides for .NET 提供了最简洁的 API，以最容易的方式创建 SmartArt 形状。要在幻灯片中创建 SmartArt 形状，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 使用其 Index 获取幻灯片的引用。
- 通过设置 LayoutType 添加 SmartArt 形状。
- 将修改后的演示文稿写入 PPTX 文件。
```c#
// 实例化演示文稿
using (Presentation pres = new Presentation())
{

    // 访问演示文稿幻灯片
    ISlide slide = pres.Slides[0];

    // 添加 Smart Art 形状
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // 保存演示文稿
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **访问幻灯片中的 SmartArt 形状**
下面的代码将用于访问演示文稿幻灯片中添加的 SmartArt 形状。在示例代码中，我们会遍历幻灯片中的每个形状，并检查它是否为 SmartArt 形状。如果是 SmartArt 类型，则将其强制转换为 SmartArt 实例。
```c#
// 加载所需的演示文稿
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // 遍历第一张幻灯片中的每个形状
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **使用特定布局类型访问 SmartArt 形状**
下面的示例代码将帮助访问具有特定 LayoutType 的 SmartArt 形状。请注意，SmartArt 的 LayoutType 为只读，且仅在添加 SmartArt 形状时设置，无法更改。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用其 Index 获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选中的形状强制转换为 SmartArt。
- 检查具有特定 LayoutType 的 SmartArt 形状，并在之后执行所需操作。
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍历第一张幻灯片中的每个形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // 检查 SmartArt 布局
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```


## **更改 SmartArt 形状样式**
下面的示例代码将帮助访问具有特定 LayoutType 的 SmartArt 形状。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用其 Index 获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选中的形状强制转换为 SmartArt。
- 查找具有特定样式的 SmartArt 形状。
- 为 SmartArt 形状设置新的样式。
- 保存演示文稿。
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍历第一张幻灯片中的每个形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
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
在本示例中，我们将学习如何更改任意 SmartArt 形状的颜色样式。下面的示例代码将访问具有特定颜色样式的 SmartArt 形状并更改其样式。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用其 Index 获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选中的形状强制转换为 SmartArt。
- 查找具有特定颜色样式的 SmartArt 形状。
- 为 SmartArt 形状设置新的颜色样式。
- 保存演示文稿。
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍历第一张幻灯片中的每个形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
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


## **常见问题**

**我可以将 SmartArt 作为单个对象进行动画吗？**

是的。SmartArt 是一种形状，因此您可以通过动画 API（入场、退出、强调、运动路径）像对其他形状一样应用[标准动画](/slides/zh/net/powerpoint-animation/)。

**如果我不知道内部 ID，如何在幻灯片上找到特定的 SmartArt？**

设置并使用替代文本（AltText），然后按该值搜索形状——这是定位目标形状的推荐方法。

**我可以将 SmartArt 与其他形状分组吗？**

是的。您可以将 SmartArt 与其他形状（图片、表格等）分组，然后[操作该组](/slides/zh/net/group/)。

**如何获取特定 SmartArt 的图像（例如用于预览或报告）？**

导出形状的缩略图/图像；库可以将[单个形状渲染](/slides/zh/net/create-shape-thumbnails/)为栅格文件（PNG/JPG/TIFF）。

**将整个演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

是的。渲染引擎针对[PDF导出](/slides/zh/net/convert-powerpoint-to-pdf/)实现高保真度，并提供多种质量和兼容性选项。