---
title: 墨迹
type: docs
weight: 180
url: /zh/net/examples/elements/ink/
keywords:
- 墨迹
- 访问墨迹
- 删除墨迹
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用墨迹：绘制、导入和编辑笔划，调整颜色和宽度，并使用 C# 示例导出为 PPT、PPTX 和 ODP。"
---
本文提供了使用 **Aspose.Slides for .NET** 访问现有墨迹形状并将其删除的示例。

> ❗ **注意：** 墨迹形状表示来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的墨迹笔划，但您可以读取和修改现有的墨迹。

## **访问墨迹**

读取幻灯片上第一个墨迹形状的标签。

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // 根据需要使用 tagName。
        }
    }
}
```

## **删除墨迹**

如果存在，则从幻灯片中删除墨迹形状。

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```