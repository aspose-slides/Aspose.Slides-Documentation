---
title: 获取 .NET 中字体替换的警告回调
type: docs
weight: 120
url: /zh/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回调
- 字体替换
- 渲染过程
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中获取字体替换的警告回调，并准确呈现 PowerPoint 和 OpenDocument 演示文稿。"
---

## **概览**

Aspose.Slides for .NET 允许您在渲染期间当所需字体在机器上不可用时接收字体替换的警告回调。这些回调有助于诊断缺少或不可访问字体的问题。

## **启用警告回调**

Aspose.Slides for .NET 提供了简便的 API 来在渲染演示文稿幻灯片时接收警告回调。按照以下步骤配置警告回调：

1. 创建一个实现[IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/)接口的自定义回调类以处理警告。
1. 使用诸如[RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/)、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)等选项类设置警告回调。
1. 加载一个使用了目标机器上不可用字体的演示文稿。
1. 生成幻灯片缩略图或导出演示文稿以观察效果。

**自定义警告回调类：**
```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// 示例输出：
//
// 字体将从 XYZ 替换为 {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```


**生成幻灯片缩略图：**
```c#
// 设置警告回调，以在幻灯片渲染期间处理与字体相关的警告。
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// 从指定的文件路径加载演示文稿。
using var presentation = new Presentation("sample.pptx");

// 为演示文稿中的每个幻灯片生成缩略图。
foreach (var slide in presentation.Slides)
{
    // 使用指定的渲染选项获取幻灯片的缩略图。
    using var image = slide.GetImage(options);
    // ...
}
```


**导出为 PDF 格式：**
```c#
// 设置警告回调，以在 PDF 导出期间处理与字体相关的警告。
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// 从指定的文件路径加载演示文稿。
using var presentation = new Presentation("sample.pptx");

// 将演示文稿导出为 PDF。
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```


**导出为 HTML 格式：**
```c#
// 设置警告回调，以在 HTML 导出期间处理与字体相关的警告。
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// 从指定的文件路径加载演示文稿。
using var presentation = new Presentation("sample.pptx");

// 将演示文稿以 HTML 格式导出。
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```
