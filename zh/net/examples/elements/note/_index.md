---
title: 备注
type: docs
weight: 240
url: /zh/net/examples/elements/note/
keywords:
- 备注
- 添加备注幻灯片
- 访问备注幻灯片
- 删除备注幻灯片
- 更新备注文本
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中处理幻灯片备注：添加、读取、编辑，并使用清晰的 C# 示例导出 PPT、PPTX 和 ODP 的演讲者备注。"
---
本文演示如何使用 **Aspose.Slides for .NET** 添加、读取、删除和更新备注幻灯片。

## **添加备注幻灯片**

创建一个备注幻灯片并向其分配文本。

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **访问备注幻灯片**

读取现有备注幻灯片中的文本。

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **移除备注幻灯片**

移除与幻灯片关联的备注幻灯片。

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **更新备注文本**

更改备注幻灯片的文本。

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```