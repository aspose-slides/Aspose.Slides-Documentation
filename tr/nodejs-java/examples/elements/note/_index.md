---
title: Not
type: docs
weight: 240
url: /tr/nodejs-java/examples/elements/note/
keywords:
- kod örneği
- not
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde slayt notlarıyla çalışın: PPT, PPTX ve ODP formatlarında konuşmacı notlarını ekleyin, okuyun, düzenleyin ve dışa aktarın, net JavaScript örnekleriyle."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak not slaytlarını ekleme, okuma, kaldırma ve güncelleme işlemlerini göstermektedir.

## **Not Slaytı Ekle**

Bir not slaytı oluşturun ve ona metin atayın.

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

## **Not Slaytına Eriş**

Mevcut bir not slaytından metni okuyun.

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

## **Not Slaytı Kaldır**

Bir slaytla ilişkili not slaytını kaldırın.

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

## **Not Metnini Güncelle**

Bir not slaytının metnini değiştirin.

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