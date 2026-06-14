---
title: Ghi chú
type: docs
weight: 240
url: /vi/nodejs-java/examples/elements/note/
keywords:
- ví dụ mã
- ghi chú
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Làm việc với ghi chú slide trong Aspose.Slides cho Node.js: thêm, đọc, chỉnh sửa và xuất ghi chú người thuyết trình ở định dạng PPT, PPTX và ODP bằng các ví dụ JavaScript rõ ràng."
---
Bài viết này trình bày cách thêm, đọc, xóa và cập nhật các slide ghi chú bằng **Aspose.Slides for Node.js via Java**.

## **Thêm một Slide Ghi chú**

Tạo một slide ghi chú và gán văn bản cho nó.

```js
function addNote() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().addNotesSlide();
        notesSlide.getNotesTextFrame().setText("My note");

        presentation.save("note.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một Slide Ghi chú**

Đọc văn bản từ một slide ghi chú hiện có.

```js
function accessNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();

        let notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Slide Ghi chú**

Xóa slide ghi chú liên kết với một slide.

```js
function removeNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getNotesSlideManager().removeNotesSlide();

        presentation.save("note_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật Văn bản Ghi chú**

Thay đổi văn bản của một slide ghi chú.

```js
function updateNoteText() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();
        notesSlide.getNotesTextFrame().setText("Updated");

        presentation.save("note_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```