---
title: Diapositive
type: docs
weight: 10
url: /fr/java/examples/elements/slide/
keywords:
- exemple de code
- diapositive
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Contrôlez les diapositives dans Aspose.Slides for Java : créez, dupliquez, réorganisez, redimensionnez, définissez les arrière-plans et appliquez des transitions avec Java pour les présentations PPT, PPTX et ODP."
---
Cet article propose une série d'exemples illustrant comment travailler avec les diapositives à l'aide d'**Aspose.Slides for Java**. Vous apprendrez à ajouter, accéder, dupliquer, réorganiser et supprimer des diapositives en utilisant la classe `Presentation`.

Chaque exemple ci-dessous comprend une brève explication suivie d'un extrait de code en Java.

## **Ajouter une diapositive**

Pour ajouter une nouvelle diapositive, vous devez d'abord sélectionner une mise en page. Dans cet exemple, nous utilisons la mise en page `Blank` et ajoutons une diapositive vide à la présentation.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Remarque :** Chaque mise en page de diapositive est dérivée d'une diapositive maître, qui définit la conception globale et la structure des espaces réservés. L’image ci-dessous illustre comment les diapositives maîtres et leurs mises en page associées sont organisées dans PowerPoint.

![Relation maître et mise en page](master-layout-slide.png)

## **Accéder aux diapositives par indice**

Vous pouvez accéder aux diapositives en utilisant leur indice, ou trouver l’indice d’une diapositive à partir d’une référence. Cela est utile pour parcourir ou modifier des diapositives spécifiques.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Ajouter une autre diapositive vide.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Accéder aux diapositives par indice.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Obtenir l'indice de la diapositive à partir d'une référence, puis y accéder par indice.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Dupliquer une diapositive**

Cet exemple montre comment dupliquer une diapositive existante. La diapositive dupliquée est automatiquement ajoutée à la fin de la collection de diapositives.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Réorganiser les diapositives**

Vous pouvez modifier l'ordre des diapositives en déplaçant l'une d'elles vers un nouvel indice. Dans ce cas, nous déplaçons une diapositive dupliquée à la première position.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une diapositive**

Pour supprimer une diapositive, il suffit de la référencer et d'appeler `remove`. Cet exemple ajoute une deuxième diapositive puis supprime l'originelle, ne laissant que la nouvelle.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```