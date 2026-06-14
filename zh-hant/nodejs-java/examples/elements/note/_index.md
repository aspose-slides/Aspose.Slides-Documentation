---
title: 註解
type: docs
weight: 240
url: /zh-hant/nodejs-java/examples/elements/note/
keywords:
- 程式碼範例
- 註解
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 處理投影片註解：使用清晰的 JavaScript 範例新增、讀取、編輯以及匯出 PPT、PPTX 與 ODP 的講者註解。"
---
本文示範如何使用 **Aspose.Slides for Node.js via Java** 新增、讀取、刪除和更新註解投影片。

## **Add a Notes Slide**
## **新增註解投影片**

Create a notes slide and assign text to it.
建立註解投影片並為其指定文字。

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

## **Access a Notes Slide**
## **存取註解投影片**

Read text from an existing notes slide.
從現有的註解投影片讀取文字。

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

## **Remove a Notes Slide**
## **移除註解投影片**

Remove the notes slide associated with a slide.
移除與投影片相關聯的註解投影片。

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

## **Update Notes Text**
## **更新註解文字**

Change the text of a notes slide.
變更註解投影片的文字。

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