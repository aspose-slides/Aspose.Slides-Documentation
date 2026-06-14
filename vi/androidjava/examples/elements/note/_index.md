---
title: Ghi chú
type: docs
weight: 240
url: /vi/androidjava/examples/elements/note/
keywords:
- ví dụ mã
- ghi chú
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Làm việc với ghi chú slide trong Aspose.Slides cho Android: thêm, đọc, chỉnh sửa và xuất ghi chú người thuyết trình ở định dạng PPT, PPTX và ODP bằng các ví dụ Java rõ ràng."
---
Bài viết này trình bày cách thêm, đọc, xóa và cập nhật các slide ghi chú bằng **Aspose.Slides for Android via Java**.

## **Thêm slide ghi chú**

Tạo một slide ghi chú và gán văn bản cho nó.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập slide ghi chú**

Đọc văn bản từ một slide ghi chú hiện có.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa slide ghi chú**

Xóa slide ghi chú liên kết với một slide.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật văn bản ghi chú**

Thay đổi văn bản của một slide ghi chú.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```