---
title: Flash
type: docs
weight: 10
url: /zh/net/flash/
keywords: "提取 flash, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中从 PowerPoint 演示文稿提取 flash 对象"
---

## **从演示文稿中提取 Flash 对象**
Aspose.Slides for .NET 提供了从演示文稿中提取 Flash 对象的功能。您可以按名称访问 Flash 控件并将其从演示文稿中提取出来，包括存储 SWF 对象数据。

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```


## **常见问题**

**在提取 Flash 内容时支持哪些演示文稿格式？**

[Aspose.Slides 支持](/slides/zh/net/supported-file-formats/)主要的 PowerPoint 格式，如 PPT 和 PPTX，因为它能够加载这些容器并访问其中的控件，包括与 Flash 相关的 ActiveX 元素。

**我能将包含 Flash 的演示文稿转换为 HTML5 并保留 Flash 交互性吗？**

不。Aspose.Slides 不会执行 SWF 内容或转换其交互性。虽然支持导出到 [HTML](/slides/zh/net/convert-powerpoint-to-html/)/[HTML5](/slides/zh/net/export-to-html5/)，但由于浏览器已停止支持，Flash 在现代浏览器中无法播放。推荐的做法是在导出之前将 Flash 替换为视频或 HTML5 动画等替代方案。

**从安全角度来看，Aspose.Slides 在读取演示文稿时会执行 SWF 文件吗？**

不。Aspose.Slides 将 Flash 视为嵌入文件中的二进制数据，在处理过程中不会执行 SWF 内容。

**我应该如何处理同时包含 Flash 和其他通过 OLE 嵌入的文件的演示文稿？**

Aspose.Slides 支持[提取嵌入的 OLE 对象](/slides/zh/net/manage-ole/)，因此您可以一次性处理所有相关的嵌入内容，统一处理 Flash 控件和其他 OLE 嵌入的文档。