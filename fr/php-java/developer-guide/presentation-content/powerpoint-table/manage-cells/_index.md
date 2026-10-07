---
title: Gérer les cellules de tableau dans les présentations avec PHP
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/php-java/manage-cells/
keywords:
- cellule de tableau
- fusionner les cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérez les cellules de tableau PowerPoint en PHP : identifiez les cellules fusionnées, supprimez les bordures, divisez les cellules et définissez les couleurs d'arrière-plan et les images avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder aux cellules de tableau et de les modifier dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, gérer la numérotation des cellules après fusion ou division, changer la couleur d'arrière‑plan d'une cellule et ajouter une image à l'intérieur d'une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d'une diapositive, mettre à jour le formatage des cellules via les propriétés de cellule, et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices zéro‑basés pour accéder aux cellules du tableau dans l'ordre `(column, row)`.

## **Identifier une cellule de tableau fusionnée**

L'exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est un tableau. Il parcourt ensuite toutes les lignes et colonnes et utilise [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) pour identifier les cellules dans les régions fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l'ordre `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), ainsi que les coordonnées de départ de la région, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) et [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Supprimer les bordures des cellules du tableau**

Créez une [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Les largeurs des colonnes, les hauteurs des lignes et la position du tableau sont spécifiées en points. L'exemple définit les quatre bordures de la cellule sur [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), les rendant invisibles.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Fusionner des cellules de tableau**

Utilisez [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l'intérieur de cette plage.

L'exemple crée un tableau de 4 × 4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s'étend sur deux colonnes et deux lignes, tandis que la grille sous‑jacent du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position supérieure gauche : `$table->get_Item(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent faisant partie de la grille du tableau, de sorte que les indices des cellules en dehors de la plage ne changent pas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Diviser les cellules du tableau**

La fusion des cellules dans l'exemple précédent conserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne de grille et modifier les indices de colonne des cellules à sa droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau de 4 × 4 avec des colonnes et lignes de 70 points et appelle [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est transmise pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `$table->get_Item(1, 1)` et `$table->get_Item(2, 1)`. La grille du tableau possède maintenant cinq colonnes : les cellules initialement dans les colonnes 2 et 3 se déplacent respectivement vers les colonnes 3 et 4. Les indices de lignes restent inchangés. Utilisez ces indices de colonne mis à jour lors de l'accès aux cellules après la division.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) pour diviser le long d'une frontière de ligne existante, ou [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) pour diviser le long d'une frontière de colonne.

L'argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Division de ligne : `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Division de colonne : `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

L'exemple suppose qu'une présentation possède un tableau comme première forme sur la première diapositive, avec `(1, 2)` et `(1, 3)` fusionnés verticalement. En partant de la position inférieure, il utilise [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) et [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) pour localiser l'origine et vérifie les deux étendues. `splitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produit. Pour une fusion horizontale de deux colonnes, utilisez `splitByColSpan(1)` à la place.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Récupérer les cellules résultantes du tableau après la division.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) affiche `false`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de cellule tel que le remplissage, les bordures et les marges. Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient des cellules distinctes "Product A" et "Product B" avec le formatage des cellules du modèle conservé. Consultez la [Référence de l'API Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) pour plus de détails.

## **Modifier la couleur d'arrière-plan d'une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) pour sélectionner un remplissage uni et définit la couleur renvoyée par [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) sur rouge pour la cellule `(2, 3)`, située dans la troisième colonne et la quatrième ligne.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ajouter une image à l'intérieur d'une cellule de tableau**

Placez l'image d'entrée dans le répertoire de travail avant d'exécuter cet exemple. Elle charge l'image avec [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) puis l'ajoute à la collection d'images de la présentation avec [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Elle assigne ensuite l'image au remplissage image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) étire l'image pour remplir la cellule, ce qui peut modifier son ratio d'aspect. Les largeurs des colonnes et les hauteurs des lignes sont en points. L'image chargée est libérée dans un bloc `finally` après avoir été ajoutée à la présentation.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Puis-je définir des épaisseurs et des styles de ligne différents pour les différentes bordures d'une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) possèdent des propriétés séparées, de sorte que l'épaisseur et le style de chaque côté peuvent différer.

**Que se passe-t-il pour l'image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [mode de remplissage](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Avec l'étirement, l'image s'ajuste à la nouvelle cellule ; avec le carrelage, les tuiles sont recalculées.

**Puis-je attribuer un hyperlien à tout le contenu d'une cellule ?**

[Hyperliens](/slides/fr/php-java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l'intérieur du cadre texte de la cellule ou au niveau du tableau/forme entier. En pratique, vous assignez le lien à une portion ou à tout le texte de la cellule.

**Puis-je définir différentes polices au sein d'une même cellule ?**

Oui. Le cadre texte d'une cellule prend en charge les [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) avec un formatage indépendant : famille de police, style, taille et couleur.