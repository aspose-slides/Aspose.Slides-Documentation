---
title: Diapositive
type: docs
weight: 10
url: /fr/php-java/examples/elements/slide/
keywords:
- diapositive
- ajouter diapositive
- accéder à la diapositive
- indice de diapositive
- dupliquer diapositive
- réorganiser diapositives
- supprimer diapositive
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les diapositives en PHP avec Aspose.Slides : créez, dupliquez, réorganisez, masquez, définissez les arrière-plans et la taille, appliquez des transitions et exportez vers PowerPoint et OpenDocument."
---
Cet article fournit une série d'exemples qui démontrent comment travailler avec les diapositives en utilisant **Aspose.Slides for PHP via Java**. Vous apprendrez comment ajouter, accéder, dupliquer, réorganiser et supprimer des diapositives à l'aide de la classe `Presentation`.

Chaque exemple ci-dessous comprend une brève explication suivie d'un extrait de code en PHP.

## **Ajouter une diapositive**

Pour ajouter une nouvelle diapositive, vous devez d'abord sélectionner une disposition. Dans cet exemple, nous utilisons la disposition `Blank` et ajoutons une diapositive vide à la présentation.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Chaque diapositive est basée sur une disposition, qui elle‑même repose sur une diapositive maître.
        // Utilisez la disposition Blank pour créer une nouvelle diapositive.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Ajoutez une nouvelle diapositive vide en utilisant la disposition sélectionnée.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Conseil :** Chaque disposition de diapositive est dérivée d'une diapositive maître, qui définit la conception globale et la structure des espaces réservés. L'image ci-dessous illustre comment les diapositives maîtres et leurs dispositions associées sont organisées dans PowerPoint.

![Relations maître et disposition](master-layout-slide.png)

## **Accéder aux diapositives par indice**

Vous pouvez accéder aux diapositives en utilisant leur indice.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Accéder à une diapositive par indice.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dupliquer une diapositive**

Cet exemple montre comment dupliquer une diapositive existante. La diapositive dupliquée est automatiquement ajoutée à la fin de la collection de diapositives.

```php
function cloneSlide() {
    // Par défaut, la présentation contient une diapositive vide.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dupliquer la première diapositive; elle sera ajoutée à la fin de la présentation.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // L'index de la diapositive dupliquée est 1 (deuxième diapositive de la présentation).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Réorganiser les diapositives**

Vous pouvez changer l'ordre des diapositives en déplaçant une diapositive vers un nouvel indice. Dans ce cas, nous déplaçons une diapositive à la première position.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Déplacer la diapositive à la première position (les autres se décalent vers le bas).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer une diapositive**

Pour supprimer une diapositive, faites simplement référence à celle-ci et appelez `remove`. Cet exemple supprime les diapositives par indice et par référence.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Supprimer une diapositive par indice.
        $presentation->getSlides()->removeAt(0);

        // Supprimer une diapositive par référence.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```