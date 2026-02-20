---
title: Diapositive de mise en page
type: docs
weight: 20
url: /fr/php-java/examples/elements/layout-slide/
keywords:
- diapositive de mise en page
- ajouter une diapositive de mise en page
- accéder à la diapositive de mise en page
- supprimer diapositive de mise en page
- diapositive de mise en page inutilisée
- cloner diapositive de mise en page
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Utilisez PHP pour gérer les diapositives de mise en page avec Aspose.Slides : créez, appliquez, clonez, renommez et personnalisez les espaces réservés et les thèmes dans les présentations pour PPT, PPTX et ODP."
---
Cet article montre comment travailler avec les **diapositives de mise en page** dans Aspose.Slides pour PHP via Java. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, cloner et supprimer des diapositives de mise en page, ainsi que nettoyer celles qui ne sont pas utilisées pour réduire la taille de la présentation.

## **Ajouter une diapositive de mise en page**

Vous pouvez créer une diapositive de mise en page personnalisée pour définir un formatage réutilisable. Par exemple, vous pouvez ajouter une zone de texte qui apparaît sur toutes les diapositives utilisant cette mise en page.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Créer une diapositive de mise en page avec un type de mise en page vierge et un nom personnalisé.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Les diapositives de mise en page servent de modèles pour les diapositives individuelles. Vous pouvez définir des éléments communs une fois et les réutiliser sur de nombreuses diapositives.
> 💡 **Tip 2:** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page afficheront ce contenu partagé automatiquement.
> La capture d'ecran ci-dessous montre deux diapositives, chacune heritant d'une zone de texte de la même diapositive de mise en page.

![Diapositives héritant du contenu de la mise en page](layout-slide-result.png)

## **Accéder à une diapositive de mise en page**

Les diapositives de mise en page peuvent être accédées par indice ou par type de mise en page (par exemple, `Blank`, `Title`, `SectionHeader`, etc.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Accéder par indice.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Accéder par type de mise en page.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer une diapositive de mise en page**

Vous pouvez supprimer une diapositive de mise en page spécifique si elle n’est plus nécessaire.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Obtenir une diapositive de mise en page par type et la supprimer.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer les diapositives de mise en page inutilisées**

Pour réduire la taille de la présentation, vous pouvez souhaiter supprimer les diapositives de mise en page qui ne sont utilisées par aucune diapositive normale.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Supprime automatiquement toutes les diapositives de mise en page qui ne sont référencées par aucune diapositive.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cloner une diapositive de mise en page**

Vous pouvez dupliquer une diapositive de mise en page en utilisant la méthode `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Obtenir une diapositive de mise en page existante par type.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Cloner la diapositive de mise en page à la fin de la collection de diapositives de mise en page.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Résumé :** Les diapositives de mise en page sont des outils puissants pour gérer un formatage cohérent sur l’ensemble des diapositives. Aspose.Slides offre un contrôle complet sur la création, la gestion et l’optimisation des diapositives de mise en page.