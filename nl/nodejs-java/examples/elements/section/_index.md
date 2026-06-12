---
title: Sectie
type: docs
weight: 90
url: /nl/nodejs-java/examples/elements/section/
keywords:
- codevoorbeeld
- sectie
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer diapresentatiesecties in Aspose.Slides voor Node.js via Java: maak, hernoem, herschik en groepeer dia's met JavaScript-voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het beheren van presentatiesecties—toevoegen, openen, verwijderen en hernoemen via code met **Aspose.Slides for Node.js via Java**.

## **Sectie toevoegen**

Maak een sectie die begint op een specifieke dia.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Geef de dia op die het begin van de sectie aangeeft.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sectie openen**

Lees sectie-informatie uit een presentatie.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Toegang tot een sectie op index.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Sectie verwijderen**

Verwijder een eerder toegevoegde sectie.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Verwijder de eerste sectie.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sectie hernoemen**

Wijzig de naam van een bestaande sectie.

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