---
title: Avsnitt
type: docs
weight: 90
url: /sv/nodejs-java/examples/elements/section/
keywords:
- kodexempel
- avsnitt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera bildavsnitt i Aspose.Slides för Node.js via Java: skapa, byta namn, omordna och gruppera bilder med JavaScript-exempel för PPT, PPTX och ODP."
---
Exempel på hur du hanterar presentationsavsnitt—lägger till, läser, tar bort och byter namn på dem programatiskt med **Aspose.Slides for Node.js via Java**.

## **Lägg till ett avsnitt**

Skapa ett avsnitt som börjar på en specifik bild.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ange bilden som markerar början av avsnittet.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kom åt ett avsnitt**

Läs avsnittsinformation från en presentation.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Åtkomst till ett avsnitt med index.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort ett avsnitt**

Ta bort ett tidigare lagt till avsnitt.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ta bort det första avsnittet.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Byt namn på ett avsnitt**

Ändra namnet på ett befintligt avsnitt.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```