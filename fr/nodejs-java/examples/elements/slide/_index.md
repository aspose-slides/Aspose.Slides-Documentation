---
title: Diapositive
type: docs
weight: 10
url: /fr/nodejs-java/examples/elements/slide/
keywords:
- exemple de code
- diapositive
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Contrôlez les diapositives dans Aspose.Slides pour Node.js : créez, dupliquez, réorganisez, redimensionnez, définissez les arrière-plans et appliquez des transitions pour les présentations PPT, PPTX et ODP."
---
Cet article propose une série d'exemples montrant comment travailler avec des diapositives à l'aide de **Aspose.Slides for Node.js via Java**. Vous apprendrez comment ajouter, accéder, dupliquer, réorganiser et supprimer des diapositives en utilisant la classe `Presentation`.

Chaque exemple ci‑dessus comprend une brève explication suivie d'un extrait de code en JavaScript.

## **Ajouter une diapositive**

Pour ajouter une nouvelle diapositive, vous devez d'abord sélectionner une disposition. Dans cet exemple, nous utilisons la disposition `Blank` et ajoutons une diapositive vide à la présentation.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note :** Chaque disposition de diapositive est dérivée d'une diapositive maître, qui définit la conception globale et la structure des espaces réservés. L'image ci‑dessous illustre comment les diapositives maîtres et leurs dispositions associées sont organisées dans PowerPoint.

![Relation maître et disposition](master-layout-slide.png)

## **Accéder aux diapositives par indice**

Vous pouvez accéder aux diapositives en utilisant leur indice. Cela est utile pour parcourir ou modifier des diapositives spécifiques.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Accéder à une diapositive par indice.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Dupliquer une diapositive**

Cet exemple montre comment dupliquer une diapositive existante. La diapositive dupliquée est automatiquement ajoutée à la fin de la collection de diapositives.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Réorganiser les diapositives**

Vous pouvez modifier l'ordre des diapositives en déplaçant une diapositive vers un nouvel indice. Dans ce cas, nous déplaçons une diapositive vers la première position.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Réorganiser les diapositives en déplaçant la deuxième diapositive à la première position.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une diapositive**

Pour supprimer une diapositive, il suffit d’y faire référence et d’appeler `remove`. Cet exemple ajoute une deuxième diapositive puis supprime l'originale, ne laissant que la nouvelle.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```