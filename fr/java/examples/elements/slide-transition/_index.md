---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/java/examples/elements/slide-transition/
keywords:
- exemple de code
- transition de diapositive
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Maîtrisez les transitions de diapositives dans Aspose.Slides for Java: ajoutez, personnalisez et séquencez les effets et les durées avec des exemples Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment appliquer des effets de transition de diapositive et des minuteries avec **Aspose.Slides for Java**.

## **Ajouter une transition de diapositive**

Appliquez un effet de transition en fondu à la première diapositive.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Appliquer une transition en fondu.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une transition de diapositive**

Lisez le type de transition actuellement attribué à une diapositive.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Accéder au type de transition.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une transition de diapositive**

Supprimez tout effet de transition en définissant le type sur `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Supprimer la transition en définissant none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir la durée de la transition**

Spécifiez la durée pendant laquelle la diapositive est affichée avant de passer automatiquement à la suivante.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // en millisecondes.
    } finally {
        presentation.dispose();
    }
}
```