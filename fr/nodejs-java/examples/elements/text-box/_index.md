---
title: Zone de texte
type: docs
weight: 40
url: /fr/nodejs-java/examples/elements/text-box/
keywords:
- exemple de code
- zone de texte
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Travaillez avec les zones de texte dans Aspose.Slides pour Node.js : ajoutez, formatez, alignez, enveloppez, ajustez automatiquement et stylisez le texte en JavaScript pour les présentations PPT, PPTX et ODP."
---
En Aspose.Slides, une **zone de texte** est représentée par un `AutoShape`. Pratiquement n'importe quelle forme peut contenir du texte, mais une zone de texte typique n'a ni remplissage ni bordure et n'affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte par programmation.

## **Ajouter une zone de texte**

Une zone de texte est simplement un `AutoShape` sans remplissage ni bordure et contenant du texte formaté. Voici comment en créer une :

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Créer une forme rectangulaire (remplie par défaut avec une bordure et sans texte).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Supprimer le remplissage et la bordure pour qu'il ressemble à une zone de texte typique.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Définir le formatage du texte.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Attribuer le contenu texte réel.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Remarque :** Tout `AutoShape` qui contient un `TextFrame` non vide peut fonctionner comme une zone de texte.

## **Accéder à une zone de texte**

Récupérez la première zone de texte de la diapositive.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Seules les AutoShapes peuvent contenir du texte modifiable.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer les zones de texte par contenu**

Cet exemple trouve et supprime toutes les zones de texte de la première diapositive qui contiennent un mot‑clé spécifique :

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Astuce :** Créez toujours une copie de la collection de formes avant de la modifier pendant l'itération afin d'éviter les erreurs de modification de collection.