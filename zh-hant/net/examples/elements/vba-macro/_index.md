---
title: VBA 巨集
type: docs
weight: 150
url: /zh-hant/net/examples/elements/vba-macro/
keywords:
- VBA 巨集
- 新增 VBA 巨集
- 存取 VBA 巨集
- 移除 VBA 巨集
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自動化簡報：在 PPT、PPTX 與 ODP 中建立、執行、匯入與保護 VBA 巨集，提供清晰的 C# 範例。"
---
本篇文章示範如何使用 **Aspose.Slides for .NET** 來新增、存取與移除 VBA 巨集。

## **新增 VBA 巨集**

建立一個包含 VBA 專案與簡易巨集模組的簡報。

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **存取 VBA 巨集**

從 VBA 專案中取得第一個模組。

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

## **移除 VBA 巨集**

從 VBA 專案中刪除模組。

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