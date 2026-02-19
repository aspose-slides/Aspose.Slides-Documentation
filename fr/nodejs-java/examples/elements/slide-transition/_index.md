---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/nodejs-java/examples/elements/slide-transition/
keywords:
- exemple de code
- transition de diapositive
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Maîtrisez les transitions de diapositives dans Aspose.Slides pour Node.js: ajoutez, personnalisez et séquencez les effets et les durées avec des exemples pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment appliquer des effets de transition de diapositives et des minuteries avec **Aspose.Slides for Node.js via Java**.

## **Ajouter une transition de diapositive**

Appliquer un effet de transition en fondu à la première diapositive.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Appliquer une transition en fondu.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une transition de diapositive**

Lire le type de transition actuellement attribué à une diapositive.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accéder au type de transition.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une transition de diapositive**

Effacer tout effet de transition en définissant le type sur `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supprimer la transition en définissant None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir la durée de la transition**

Spécifier la durée pendant laquelle la diapositive est affichée avant de passer automatiquement à la suivante.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // en millisecondes.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```