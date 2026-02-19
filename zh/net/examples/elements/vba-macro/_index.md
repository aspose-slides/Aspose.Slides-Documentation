---
title: VBA 宏
type: docs
weight: 150
url: /zh/net/examples/elements/vba-macro/
keywords:
- VBA 宏
- 添加 VBA 宏
- 访问 VBA 宏
- 删除 VBA 宏
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自动化演示文稿：通过清晰的 C# 示例创建、运行、导入并保护 PPT、PPTX 和 ODP 中的 VBA 宏。"
---
本文演示如何使用 **Aspose.Slides for .NET** 添加、访问和删除 VBA 宏。

## **添加 VBA 宏**

创建一个包含 VBA 项目和简单宏模块的演示文稿。

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **访问 VBA 宏**

从 VBA 项目中检索第一个模块。

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **删除 VBA 宏**

从 VBA 项目中删除一个模块。

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```