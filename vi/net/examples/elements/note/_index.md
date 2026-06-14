---
title: Ghi chú
type: docs
weight: 240
url: /vi/net/examples/elements/note/
keywords:
- ghi chú
- thêm slide ghi chú
- truy cập slide ghi chú
- xóa slide ghi chú
- cập nhật văn bản ghi chú
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Làm việc với ghi chú slide trong Aspose.Slides cho .NET: thêm, đọc, chỉnh sửa và xuất ghi chú người nói trong PPT, PPTX và ODP bằng các ví dụ C# rõ ràng."
---
Bài viết này trình bày cách thêm, đọc, xóa và cập nhật các slide ghi chú bằng **Aspose.Slides for .NET**.

## **Thêm một Slide Ghi chú**

Tạo một slide ghi chú và gán văn bản cho nó.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Truy cập một Slide Ghi chú**

Đọc văn bản từ một slide ghi chú hiện có.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Xóa một Slide Ghi chú**

Xóa slide ghi chú liên kết với một slide.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Cập nhật Văn bản Ghi chú**

Thay đổi văn bản của một slide ghi chú.

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