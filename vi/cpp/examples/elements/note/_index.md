---
title: "Ghi chú"
type: docs
weight: 240
url: /vi/cpp/examples/elements/note/
keywords:
- "ví dụ mã"
- "ghi chú"
- PowerPoint
- OpenDocument
- "bài thuyết trình"
- C++
- Aspose.Slides
description: "Làm việc với ghi chú slide trong Aspose.Slides for C++: thêm, đọc, chỉnh sửa và xuất ghi chú người thuyết trình ở định dạng PPT, PPTX và ODP bằng các ví dụ C++ rõ ràng."
---
Bài viết này trình bày cách thêm, đọc, xóa và cập nhật các slide ghi chú bằng **Aspose.Slides for C++**.

## **Thêm Slide Ghi chú**

Tạo một slide ghi chú và gán văn bản cho nó.

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **Truy cập Slide Ghi chú**

Đọc văn bản từ một slide ghi chú hiện có.

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **Xóa Slide Ghi chú**

Xóa slide ghi chú liên kết với một slide.

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **Cập nhật Văn bản Ghi chú**

Thay đổi văn bản của một slide ghi chú.

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```