---
title: Diapositive de mise en page
type: docs
weight: 20
url: /fr/androidjava/examples/elements/layout-slide/
keywords:
- exemple de code
- diapositive de mise en page
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Maîtrisez les diapositives de mise en page dans Aspose.Slides pour Android : choisissez, appliquez et personnalisez les mises en page des diapositives, les espaces réservés et les masques avec des exemples Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment travailler avec **Layout Slides** dans Aspose.Slides pour Android via Java. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, cloner et supprimer des diapositives de mise en page, ainsi que nettoyer celles inutilisées pour réduire la taille de la présentation.

## **Ajouter une diapositive de mise en page**

Vous pouvez créer une diapositive de mise en page personnalisée pour définir un formatage réutilisable. Par exemple, vous pouvez ajouter une zone de texte qui apparaît sur toutes les diapositives utilisant cette mise en page.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Créez une diapositive de mise en page avec un type de mise en page vierge et un nom personnalisé.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Ajoutez une zone de texte à la diapositive de mise en page.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Ajoutez deux diapositives en utilisant cette mise en page ; les deux hériteront du texte de la mise en page.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Remarque 1 :** Les diapositives de mise en page servent de modèles pour les diapositives individuelles. Vous pouvez définir des éléments communs une fois et les réutiliser sur de nombreuses diapositives.  
> 💡 **Remarque 2 :** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page afficheront automatiquement ce contenu partagé.  
> La capture d’écran ci‑dessous montre deux diapositives, chacune héritant d’une zone de texte de la même diapositive de mise en page.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Accéder à une diapositive de mise en page**

Les diapositives de mise en page peuvent être accessibles par index ou par type de mise en page (par exemple, `Blank`, `Title`, `SectionHeader`, etc.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Accédez à une diapositive de mise en page par indice.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Accédez à une diapositive de mise en page par type.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une diapositive de mise en page**

Vous pouvez supprimer une diapositive de mise en page spécifique si elle n’est plus nécessaire.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Obtenez une diapositive de mise en page par type et supprimez-la.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer les diapositives de mise en page inutilisées**

Pour réduire la taille de la présentation, vous pouvez vouloir supprimer les diapositives de mise en page qui ne sont utilisées par aucune diapositive normale.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Supprime automatiquement toutes les diapositives de mise en page non référencées par aucune diapositive.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Cloner une diapositive de mise en page**

Vous pouvez dupliquer une diapositive de mise en page en utilisant la méthode `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Obtenez une diapositive de mise en page existante par type.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Clonez la diapositive de mise en page à la fin de la collection de diapositives de mise en page.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Résumé :** Les diapositives de mise en page sont des outils puissants pour gérer un formatage cohérent à travers les diapositives. Aspose.Slides permet un contrôle complet sur la création, la gestion et l’optimisation des diapositives de mise en page.