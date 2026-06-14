---
title: Ghi chú
type: docs
weight: 240
url: /vi/php-java/examples/elements/note/
keywords:
- ghi chú
- thêm slide ghi chú
- truy cập slide ghi chú
- xóa slide ghi chú
- cập nhật văn bản ghi chú
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Thêm, đọc, chỉnh sửa và xuất ghi chú người thuyết trình trong PHP với Aspose.Slides: định dạng văn bản, quản lý ghi chú cho mỗi slide và kiểm soát khả năng hiển thị trong PowerPoint và OpenDocument."
---
Hiển thị cách thêm, đọc, xóa và cập nhật các slide ghi chú bằng **Aspose.Slides for PHP via Java**.

## **Thêm một Slide Ghi chú**

Tạo một slide ghi chú và gán văn bản cho nó.

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập một Slide Ghi chú**

Đọc văn bản từ một slide ghi chú hiện có.

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa một Slide Ghi chú**

Xóa slide ghi chú liên kết với một slide.

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cập nhật Văn bản Ghi chú**

Thay đổi văn bản của một slide ghi chú.

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```