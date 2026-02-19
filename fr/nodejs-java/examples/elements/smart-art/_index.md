---
title: SmartArt
type: docs
weight: 140
url: /fr/nodejs-java/examples/elements/smart-art/
keywords:
- exemple de code
- SmartArt
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Travaillez avec SmartArt dans Aspose.Slides pour Node.js : créez, modifiez, convertissez et stylisez des diagrammes avec JavaScript pour les présentations PowerPoint et OpenDocument."
---
Cet article montre comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les dispositions en utilisant **Aspose.Slides for Node.js via Java**.

## **Ajouter SmartArt**

Insérez un graphique SmartArt en utilisant l’une des mises en page intégrées.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à SmartArt**

Récupérez le premier objet SmartArt d’une diapositive.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer SmartArt**

Supprimez une forme SmartArt de la diapositive.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supposant que la première forme est SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Modifier la mise en page SmartArt**

Mettez à jour le type de mise en page d’un graphique SmartArt existant.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supposant que la première forme est SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```