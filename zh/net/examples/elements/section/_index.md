---
title: 章节
type: docs
weight: 90
url: /zh/net/examples/elements/section/
keywords:
- 章节
- 幻灯片章节
- 添加章节
- 访问章节
- 删除章节
- 重命名章节
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理幻灯片章节：创建、重命名、重新排序并对幻灯片进行分组，提供针对 PPT、PPTX 和 ODP 的 C# 示例。"
---
示例展示如何使用 **Aspose.Slides for .NET** 通过编程方式管理演示文稿的章节——添加、访问、删除和重命名。

## **添加章节**

创建一个从特定幻灯片开始的章节。

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 指定标记章节开头的幻灯片。
    presentation.Sections.AddSection("New Section", slide);
}
```

## **访问章节**

读取演示文稿中的章节信息。

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // 通过索引访问章节。
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **删除章节**

删除之前添加的章节。

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // 删除第一个章节。
    presentation.Sections.RemoveSection(section);
}
```

## **重命名章节**

更改现有章节的名称。

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```