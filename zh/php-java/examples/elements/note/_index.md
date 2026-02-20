---
title: 备注
type: docs
weight: 240
url: /zh/php-java/examples/elements/note/
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
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 添加、读取、编辑和导出演讲者备注：格式化文本、按幻灯片管理备注，并在 PowerPoint 和 OpenDocument 中控制可见性。"
---
展示如何使用 **Aspose.Slides for PHP via Java** 添加、读取、移除和更新备注幻灯片。

## **添加备注幻灯片**

创建备注幻灯片并为其分配文本。

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

## **访问备注幻灯片**

读取现有备注幻灯片中的文本。

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

## **移除备注幻灯片**

移除与幻灯片关联的备注幻灯片。

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

## **更新备注文本**

更改备注幻灯片的文本。

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