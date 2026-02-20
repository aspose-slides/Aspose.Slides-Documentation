---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/php-java/examples/elements/slide-transition/
keywords:
- transition de diapositive
- ajouter transition de diapositive
- accéder à la transition de diapositive
- supprimer transition de diapositive
- durée de transition
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Contrôlez les transitions de diapositives en PHP avec Aspose.Slides : choisissez les types, la vitesse, le son et le timing pour peaufiner vos présentations au format PPT, PPTX et ODP."
---
Démontre l'application d'effets de transition de diapositive et des temporisations avec **Aspose.Slides for PHP via Java**.

## **Ajouter une transition de diapositive**

Appliquer un effet de transition en fondu à la première diapositive.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Appliquer une transition en fondu.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à une transition de diapositive**

Lire le type de transition assigné à une diapositive.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au type de transition.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer une transition de diapositive**

Supprimer tout effet de transition en définissant le type sur `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supprimer la transition en la définissant sur none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Définir la durée de la transition**

Spécifier la durée d'affichage de la diapositive avant de passer automatiquement à la suivante.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // en millisecondes.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```