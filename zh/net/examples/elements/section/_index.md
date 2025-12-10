---
title: 节
type: docs
weight: 90
url: /zh/net/examples/elements/section/
keywords:
- 节 示例
- 幻灯片 节
- 添加 节
- 访问 节
- 删除 节
- 重命名 节
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中管理幻灯片节：轻松创建、重命名、重新排序，跨节移动幻灯片，并控制 PPT、PPTX 和 ODP 的可见性。"
---

示例展示使用 **Aspose.Slides for .NET** 以编程方式管理演示文稿的节——添加、访问、删除和重命名。

## **添加节**

在特定幻灯片处创建一个节。
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // 指定标记章节起始的幻灯片
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## **访问节**

读取演示文稿中的节信息。
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // 通过索引访问节
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## **删除节**

删除先前添加的节。
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // 删除第一个节
    pres.Sections.RemoveSection(section);
}
```


## **重命名节**

更改已有节的名称。
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
