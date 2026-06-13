---
title: नोट
type: docs
weight: 240
url: /hi/nodejs-java/examples/elements/note/
keywords:
- कोड उदाहरण
- नोट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में स्लाइड नोट्स के साथ काम करें: स्पष्ट जावास्क्रिप्ट उदाहरणों का उपयोग करके PPT, PPTX, और ODP में स्पीकर नोट्स को जोड़ें, पढ़ें, संपादित करें और निर्यात करें।"
---
यह लेख **Aspose.Slides for Node.js via Java** का उपयोग करके नोट्स स्लाइड को जोड़ने, पढ़ने, हटाने और अपडेट करने का प्रदर्शन करता है।

## **नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएं और उसमें टेक्स्ट असाइन करें।

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

## **नोट्स स्लाइड तक पहुँचें**

एक मौजूदा नोट्स स्लाइड से टेक्स्ट पढ़ें।

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

## **नोट्स स्लाइड हटाएँ**

स्लाइड से जुड़े नोट्स स्लाइड को हटा दें।

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

## **नोट्स टेक्स्ट अपडेट करें**

नोट्स स्लाइड का टेक्स्ट बदलें।

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