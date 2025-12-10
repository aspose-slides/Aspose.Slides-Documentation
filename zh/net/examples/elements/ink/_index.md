---
title: Ink
type: docs
weight: 180
url: /zh/net/examples/elements/ink/
keywords:
- 墨迹示例
- 访问墨迹
- 删除墨迹
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 C# 中使用 Aspose.Slides 处理幻灯片上的数字墨迹：添加笔画、编辑路径、设置颜色和宽度，并将结果导出为 PowerPoint 和 OpenDocument。"
---

提供了使用 **Aspose.Slides for .NET** 访问现有墨迹形状并将其删除的示例。

> ❗ **注意：** 墨迹形状代表来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的墨迹笔画，但您可以读取并修改现有的墨迹。

## **访问 Ink**

读取幻灯片上第一个墨迹形状的标签。
```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // 根据需要使用 tagName
        }
    }
}
```


## **删除 Ink**

如果存在，则从幻灯片中删除墨迹形状。
```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
