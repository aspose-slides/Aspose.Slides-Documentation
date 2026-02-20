---
title: SmartArt
type: docs
weight: 140
url: /fr/php-java/examples/elements/smartart/
keywords:
- SmartArt
- ajouter SmartArt
- accéder à SmartArt
- supprimer SmartArt
- mise en page SmartArt
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créez et modifiez SmartArt en PHP avec Aspose.Slides : ajoutez des nœuds, changez les mises en page et les styles, convertissez en formes avec précision, et exportez vers PPT, PPTX et ODP."
---
Présente comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les mises en page en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter SmartArt**

Insérez un graphique SmartArt en utilisant l'une des mises en page intégrées.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à SmartArt**

Récupérez le premier objet SmartArt sur une diapositive.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au premier SmartArt de la diapositive.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer SmartArt**

Supprimez une forme SmartArt de la diapositive.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme sur la diapositive est un SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Modifier la mise en page SmartArt**

Mettez à jour le type de mise en page d'un graphique SmartArt existant.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme sur la diapositive est un SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Changer la mise en page du SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```