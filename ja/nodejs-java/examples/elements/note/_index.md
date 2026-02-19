---
title: ノート
type: docs
weight: 240
url: /ja/nodejs-java/examples/elements/note/
keywords:
- コード例
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でスライドノートを操作します。追加、読み取り、編集、および PPT、PPTX、ODP 形式でスピーカーノートをエクスポートする方法を、明確な JavaScript の例を使用して説明します。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用して、ノート スライドの追加、読み取り、削除、更新方法を示します。

## **ノート スライドの追加**

ノート スライドを作成し、テキストを割り当てます。

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

## **ノート スライドへのアクセス**

既存のノート スライドからテキストを読み取ります。

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

## **ノート スライドの削除**

スライドに関連付けられたノート スライドを削除します。

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

## **ノート テキストの更新**

ノート スライドのテキストを変更します。

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