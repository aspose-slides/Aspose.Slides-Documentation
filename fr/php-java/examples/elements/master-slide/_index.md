---
title: Diapositive maître
type: docs
weight: 30
url: /fr/php-java/examples/elements/master-slide/
keywords:
- diapositive maître
- ajouter diapositive maître
- accéder à la diapositive maître
- supprimer diapositive maître
- diapositive maître inutilisée
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérer les diapositives maîtres en PHP avec Aspose.Slides : créer, modifier, dupliquer et formater les thèmes, arrière-plans et espaces réservés pour unifier les diapositives dans PowerPoint et OpenDocument."
---
Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d'héritage des diapositives dans PowerPoint. Une **diapositive maître** définit les éléments de conception communs tels que les arrière-plans, les logos et la mise en forme du texte. Les **diapositives de mise en page** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de mise en page.

Cet article montre comment créer, modifier et gérer les diapositives maîtres à l'aide d'Aspose.Slides for PHP via Java.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en dupliquant celle par défaut.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Cloner la diapositive maître par défaut.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Astuce 1 :** Les diapositives maîtres offrent un moyen d'appliquer une identité visuelle cohérente ou des éléments de conception partagés sur toutes les diapositives. Toute modification apportée à la diapositive maître se reflétera automatiquement sur les mises en page et les diapositives normales dépendantes.

> 💡 **Astuce 2 :** Toutes les formes ou la mise en forme ajoutées à une diapositive maître sont héritées par les diapositives de mise en page et, à leur tour, par toutes les diapositives normales utilisant ces mises en page.

> L'image ci-dessous illustre comment une zone de texte ajoutée sur une diapositive maître est automatiquement rendue sur la diapositive finale.

![Exemple d'héritage de la diapositive maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres en utilisant la méthode `Presentation::getMasters`. Voici comment les récupérer et les manipuler :

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Accéder à la première diapositive maître.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer une diapositive maître**

Les diapositives maîtres peuvent être supprimées soit par index, soit par référence.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Supprimer par index.
        $presentation->getMasters()->removeAt(0);

        // Ou supprimer par référence.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Supprimer ces diapositives peut aider à réduire la taille du fichier.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Supprimer toutes les diapositives maîtres inutilisées (y compris celles marquées comme Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Astuce :** Utilisez `removeUnused(true)` pour nettoyer les diapositives maîtres inutilisées et réduire la taille de la présentation.