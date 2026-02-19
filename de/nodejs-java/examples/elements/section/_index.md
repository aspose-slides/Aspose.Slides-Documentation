---
title: Abschnitt
type: docs
weight: 90
url: /de/nodejs-java/examples/elements/section/
keywords:
- Codebeispiel
- Abschnitt
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte in Aspose.Slides für Node.js via Java: Erstellen, umbenennen, neu anordnen und gruppieren Sie Folien mit JavaScript-Beispielen für PPT, PPTX und ODP."
---
Beispiele für die Verwaltung von Präsentationsabschnitten - Hinzufügen, Zugreifen, Entfernen und Umbenennen programmgesteuert mit **Aspose.Slides for Node.js via Java**.

## **Abschnitt hinzufügen**

Erstellen Sie einen Abschnitt, der bei einer bestimmten Folie beginnt.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Geben Sie die Folie an, die den Beginn des Abschnitts markiert.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Abschnitt zugreifen**

Lesen Sie Abschnittsinformationen aus einer Präsentation.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zugriff auf einen Abschnitt per Index.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Abschnitt entfernen**

Löschen Sie einen zuvor hinzugefügten Abschnitt.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Entferne den ersten Abschnitt.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Abschnitt umbenennen**

Ändern Sie den Namen eines bestehenden Abschnitts.

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