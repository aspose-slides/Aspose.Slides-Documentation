---
title: Encre
type: docs
weight: 180
url: /fr/nodejs-java/examples/elements/ink/
keywords:
- exemple de code
- encre
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Travaillez avec l'encre dans Aspose.Slides for Node.js : dessinez, importez et modifiez les traits, ajustez la couleur et la largeur, et exportez vers PPT, PPTX et ODP à l'aide d'exemples."
---
Cet article fournit des exemples d'accès aux formes d'encre existantes et de leur suppression à l'aide de **Aspose.Slides for Node.js via Java**.

> ❗ **Note :** Les formes d'encre représentent les saisies utilisateur provenant d'appareils spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre de manière programmatique, mais vous pouvez lire et modifier l'encre existante.

## **Accéder à l'encre**
Récupérez la première forme d'encre sur une diapositive.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer l'encre**
Supprimez une forme d'encre de la diapositive.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supposant que la forme d'encre est la première forme de la diapositive.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```