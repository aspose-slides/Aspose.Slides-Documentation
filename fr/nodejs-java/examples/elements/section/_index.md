---
title: Section
type: docs
weight: 90
url: /fr/nodejs-java/examples/elements/section/
keywords:
- exemple de code
- section
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérez les sections de diapositives dans Aspose.Slides pour Node.js via Java : créez, renommez, réorganisez et regroupez des diapositives avec des exemples JavaScript pour PPT, PPTX et ODP."
---
Exemples de gestion des sections de présentation — ajout, accès, suppression et renommage programmatiques à l'aide de **Aspose.Slides for Node.js via Java**.

## **Ajouter une section**
Créez une section qui commence à une diapositive spécifique.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Spécifiez la diapositive qui marque le début de la section.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une section**
Lisez les informations de la section à partir d'une présentation.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accédez à une section par indice.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une section**
Supprimez une section précédemment ajoutée.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supprimez la première section.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Renommer une section**
Modifiez le nom d'une section existante.

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