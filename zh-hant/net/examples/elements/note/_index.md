---
title: 備註
type: docs
weight: 240
url: /zh-hant/net/examples/elements/note/
keywords:
- 備註
- 新增備註投影片
- 存取備註投影片
- 移除備註投影片
- 更新備註文字
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 處理投影片備註：新增、讀取、編輯，並以清晰的 C# 範例匯出 PPT、PPTX 和 ODP 格式的演講者備註。"
---
本文示範如何使用 **Aspose.Slides for .NET** 新增、讀取、移除與更新備註投影片。

## **新增備註投影片**

建立備註投影片並為其指定文字。

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **存取備註投影片**

從現有的備註投影片讀取文字。

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **移除備註投影片**

移除與投影片關聯的備註投影片。

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **更新備註文字**

變更備註投影片的文字。

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