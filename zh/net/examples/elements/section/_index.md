---
title: 章节
type: docs
weight: 90
url: /zh/net/examples/elements/section/
keywords:
- 章节示例
- 幻灯片章节
- 添加章节
- 访问章节
- 删除章节
- 重命名章节
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 C# 中使用 Aspose.Slides 管理幻灯片章节：轻松创建、重命名、重新排序，移动幻灯片到不同章节，并控制 PPT、PPTX 和 ODP 的可见性。"
---

使用 **Aspose.Slides for .NET** 以编程方式管理演示文稿章节——添加、访问、删除和重命名的示例。

## 添加章节

创建一个从特定幻灯片开始的章节。
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // 指定标记章节开始的幻灯片
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## 访问章节

读取演示文稿中的章节信息。
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // 通过索引访问章节
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## 删除章节

删除之前添加的章节。
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // 删除第一章节
    pres.Sections.RemoveSection(section);
}
```


## 重命名章节

更改现有章节的名称。
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
