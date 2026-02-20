---
title: ノート
type: docs
weight: 240
url: /ja/php-java/examples/elements/note/
keywords:
- ノート
- ノートスライドを追加
- ノートスライドにアクセス
- ノートスライドを削除
- ノートテキストを更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用した PHP でスピーカーノートを追加、読み取り、編集、エクスポートします。テキストの書式設定、スライドごとのノート管理、PowerPoint と OpenDocument での表示制御が可能です。"
---
**Aspose.Slides for PHP via Java** を使用して、ノートスライドの追加、読み取り、削除、更新を行う方法を示します。

## **ノート スライドの追加**

ノートスライドを作成し、テキストを割り当てます。

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

## **ノート スライドにアクセス**

既存のノートスライドからテキストを読み取ります。

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

## **ノート スライドの削除**

スライドに関連付けられたノートスライドを削除します。

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

## **ノートテキストの更新**

ノートスライドのテキストを変更します。

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