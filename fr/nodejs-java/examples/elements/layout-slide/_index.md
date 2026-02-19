---
title: Diapositive de mise en page
type: docs
weight: 20
url: /fr/nodejs-java/examples/elements/layout-slide/
keywords:
- exemple de code
- diapositive de mise en page
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Maîtrisez les diapositives de mise en page dans Aspose.Slides pour Node.js : choisissez, appliquez et personnalisez les mises en page des diapositives, les espaces réservés et les maîtres avec des exemples pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment travailler avec **Layout Slides** dans Aspose.Slides pour Node.js via Java. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, cloner et supprimer des diapositives de mise en page, ainsi que nettoyer celles qui ne sont pas utilisées afin de réduire la taille de la présentation.

## **Ajouter une diapositive de mise en page**

Vous pouvez créer une diapositive de mise en page personnalisée pour définir un formatage réutilisable.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Créer une diapositive de mise en page avec un type de mise en page vierge et un nom personnalisé.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1 :** Les diapositives de mise en page agissent comme des modèles pour les diapositives individuelles. Vous pouvez définir des éléments communs une fois et les réutiliser sur de nombreuses diapositives.

> 💡 **Note 2 :** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page afficheront automatiquement ce contenu partagé.  
> La capture d'écran ci‑dessous montre deux diapositives, chacune héritant d'une zone de texte de la même diapositive de mise en page.

![Diapositives héritant du contenu de la mise en page](layout-slide-result.png)

## **Accéder à une diapositive de mise en page**

Les diapositives de mise en page peuvent être accessibles par indice ou par type de mise en page (par ex., `Blank`, `Title`, `SectionHeader`, etc.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Accéder à une diapositive de mise en page par index.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Accéder à une diapositive de mise en page par type.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une diapositive de mise en page**

Vous pouvez supprimer une diapositive de mise en page spécifique si elle n'est plus nécessaire.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Obtenir une diapositive de mise en page par type et la supprimer.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer les diapositives de mise en page inutilisées**

Pour réduire la taille de la présentation, vous pouvez vouloir supprimer les diapositives de mise en page qui ne sont utilisées par aucune diapositive normale.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Supprime automatiquement toutes les diapositives de mise en page qui ne sont référencées par aucune diapositive.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Cloner une diapositive de mise en page**

Vous pouvez dupliquer une diapositive de mise en page en utilisant la méthode `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Obtenir une diapositive de mise en page existante par type.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Cloner la diapositive de mise en page à la fin de la collection de diapositives de mise en page.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Résumé :** Les diapositives de mise en page sont des outils puissants pour gérer un formatage cohérent sur l’ensemble des diapositives. Aspose.Slides offre un contrôle complet sur la création, la gestion et l’optimisation des diapositives de mise en page.