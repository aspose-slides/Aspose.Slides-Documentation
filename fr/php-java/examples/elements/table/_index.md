---
title: Tableau
type: docs
weight: 120
url: /fr/php-java/examples/elements/table/
keywords:
- tableau
- ajouter un tableau
- accéder à un tableau
- supprimer un tableau
- fusionner des cellules
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créer et mettre en forme des tableaux en PHP avec Aspose.Slides : insérer des données, fusionner des cellules, styliser les bordures, aligner le contenu et importer/exporter pour PPT, PPTX et ODP."
---
Exemples d'ajout de tableaux, d'accès à ceux-ci, de suppression et de fusion de cellules en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter un tableau**

Créez un tableau simple avec deux lignes et deux colonnes.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à un tableau**

Récupérez la première forme de tableau sur la diapositive.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au premier tableau sur la diapositive.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer un tableau**

Supprimez un tableau d'une diapositive.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que le tableau est la première forme sur la diapositive.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Fusionner les cellules du tableau**

Fusionnez les cellules adjacentes d'un tableau en une seule cellule.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que le tableau est la première forme sur la diapositive.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```