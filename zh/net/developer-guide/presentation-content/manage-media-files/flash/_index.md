---
title: Flash
type: docs
weight: 10
url: /net/flash/
keywords: "提取 Flash, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中从 PowerPoint 演示文稿中提取 Flash 对象"
---

## **从演示文稿中提取 Flash 对象**
Aspose.Slides for .NET 提供了一种从演示文稿中提取 Flash 对象的功能。您可以通过名称访问 Flash 控件并将其从演示文稿中提取，包括存储 SWF 对象数据。

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