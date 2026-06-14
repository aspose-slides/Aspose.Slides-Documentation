---
title: 分節
type: docs
weight: 90
url: /zh-hant/net/examples/elements/section/
keywords:
- 分節
- 投影片分節
- 新增分節
- 存取分節
- 移除分節
- 重新命名分節
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理投影片分節：建立、重新命名、重新排序及分組投影片，並提供針對 PPT、PPTX 與 ODP 的 C# 範例。"
---
使用 **Aspose.Slides for .NET** 以程式方式管理簡報分節——新增、存取、移除與重新命名的範例。

## **新增分節**

建立一個從特定投影片開始的分節。

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 指定標示此分節開始的投影片。
    presentation.Sections.AddSection("New Section", slide);
}
```

## **存取分節**

從簡報中讀取分節資訊。

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // 依索引存取分節。
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **移除分節**

刪除先前新增的分節。

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // 移除第一個分節。
    presentation.Sections.RemoveSection(section);
}
```

## **重新命名分節**

變更現有分節的名稱。

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