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
description: "Gérer les cellules de tableau PowerPoint en PHP : identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d'arrière‑plan et les images avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder et de modifier les cellules de tableau dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, gérer la numérotation des cellules après une fusion ou une division, changer la couleur d'arrière‑plan d'une cellule et ajouter une image à l'intérieur d'une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d’une diapositive, mettre à jour le formatage des cellules via leurs propriétés et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices de base zéro pour accéder aux cellules de tableau dans l’ordre `(colonne, ligne)`.

## **Identifier une cellule de tableau fusionnée**

L’exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est bien un tableau. Il parcourt ensuite toutes les lignes et colonnes et utilise [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) pour identifier les cellules appartenant à des régions fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule au format `ligne;colonne`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), ainsi que les coordonnées de début de la région, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) et [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

Créez une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Les largeurs de colonne, hauteurs de ligne et la position du tableau sont spécifiées en points. L’exemple définit les quatre bordures de la cellule sur [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), les rendant invisibles.

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

## **Ajouter des bordures diagonales aux cellules**

Utilisez [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) pour tracer une ligne du coin supérieur gauche au coin inférieur droit, et [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) pour tracer une ligne du coin inférieur gauche au coin supérieur droit. Une diagonale peut marquer un en‑tête d’angle ; les deux diagonales peuvent former un X pour indiquer qu’une cellule n’est pas applicable.

Chaque diagonale possède son propre [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). Dans son [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/), utilisez [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) pour sélectionner [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) et choisissez une couleur via [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Définissez la largeur de la ligne en points avec [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

L’exemple crée trois cellules dans une même ligne : une diagonale descendante rouge, une diagonale ascendante bleue et les deux diagonales. Les bordures supérieure, inférieure, gauche et droite restent inchangées.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Une diagonale ne change que le formatage de la cellule. Chaque cellule conserve un seul cadre de texte, accessible via [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). Les zones de part et d’autre d’une diagonale ne peuvent pas être modifiées indépendamment.

Le tableau enregistré, rendu dans Microsoft PowerPoint :

![Trois cellules de tableau montrant une diagonale rouge du coin supérieur gauche au coin inférieur droit, une diagonale bleue du coin inférieur gauche au coin supérieur droit, et les deux diagonales formant un X.](diagonal-cell-borders.png)

*De gauche à droite : diagonale descendante (rouge, 3 pt), diagonale ascendante (bleu, 5 pt) et les deux diagonales.*

## **Fusionner les cellules du tableau**

Utilisez [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l’intérieur de cette plage.

L’exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante occupe deux colonnes et deux lignes, tandis que la grille sous‑jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position supérieure gauche : `$table->get_Item(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent parties de la grille du tableau, de sorte que les indices des cellules en dehors de la plage ne changent pas.

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

La fusion des cellules dans l’exemple précédent conserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne de grille et modifier les indices de colonne des cellules situées à sa droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points et appelle [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est passée pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `$table->get_Item(1, 1)` et `$table->get_Item(2, 1)`. La grille du tableau possède maintenant cinq colonnes : les cellules initialement en colonnes 2 et 3 passent aux colonnes 3 et 4, respectivement. Les indices de ligne restent inchangés. Utilisez ces indices de colonne mis à jour lors de l’accès aux cellules après la division.

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

<!-- visual-explanation:manage-cells:start -->
[![Une cellule non fusionnée de 70 points se divise en deux cellules de 35 points, ajoutant une cinquième colonne de grille et décalant les indices à sa droite.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La division de largeur affecte la cellule (1, 1), en utilisant des indices zéro‑based (colonne, ligne). Les autres lignes conservent une cellule s’étendant sur les deux nouvelles positions de colonne.*
<!-- visual-explanation:manage-cells:end -->

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) pour diviser le long d’une bordure de ligne existante, ou [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) pour diviser le long d’une bordure de colonne.

L’argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Division de ligne : `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Division de colonne : `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

L’exemple suppose qu’une présentation possède un tableau comme première forme de la première diapositive, avec `(1, 2)` et `(1, 3)` fusionnés verticalement. En partant de la position inférieure, il utilise [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) et [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) pour localiser l’origine et vérifie les deux étendues. `splitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produit. Pour une fusion horizontale sur deux colonnes, utilisez `splitByColSpan(1)` à la place.

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

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont des étendues de 1 et [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) renvoie `false`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de la cellule (remplissage, bordures, marges). Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient des cellules séparées « Product A » et « Product B » avec le formatage de cellule du modèle conservé. Consultez la [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) pour plus de détails.

### **Diviser une cellule à une hauteur précise**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) prend la hauteur de la partie supérieure en points. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) prend le nombre de lignes de grille existantes dans la partie supérieure. Pour centrer une cellule de 40 points dans la colonne de droite, soustrayez 40 de la hauteur réelle de la cellule et répartissez l’espace restant également au-dessus et en dessous.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La première division ajoute une ligne de grille et laisse les 90 points inférieurs dans la cellule `(1, 1)`. La deuxième division transforme cette cellule en une cellule centrale de 40 points et une cellule inférieure de 50 points. La colonne de droite possède désormais trois cellules avec des hauteurs de 50, 40 et 50 points de haut en bas. La cellule de gauche s’étend sur les trois lignes et conserve sa hauteur originale de 140 points.

![La cellule de gauche s’étend sur toute la hauteur du tableau à côté de trois cellules avec « Middle » au centre.](split-by-height.png)

## **Modifier la couleur d’arrière‑plan d’une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) pour sélectionner un remplissage plein et définit la couleur renvoyée par [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) sur rouge pour la cellule `(2, 3)`, située dans la troisième colonne et la quatrième ligne.

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

## **Ajouter une image à l’intérieur d’une cellule de tableau**

Placez l’image d’entrée dans le répertoire de travail avant d’exécuter cet exemple. Elle charge l’image avec [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) et l’ajoute à la collection d’images de la présentation avec [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Elle affecte ensuite l’image au remplissage image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) étire l’image pour remplir la cellule, ce qui peut modifier son ratio d’aspect. Les largeurs de colonne et hauteurs de ligne sont exprimées en points. L’image chargée est libérée dans un bloc `finally` après son ajout à la présentation.

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

**Puis‑je définir des épaisseurs et des styles de trait différents pour chaque côté d’une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) disposent de propriétés séparées, de sorte que l’épaisseur et le style de chaque côté peuvent différer.

**Que se passe‑t‑il avec l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’ajuste à la nouvelle cellule ; avec le carrelage, les tuiles sont recalculées.

**Puis‑je associer un hyperlien à tout le contenu d’une cellule ?**

[Hyperlinks](/slides/fr/php-java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre de texte de la cellule ou au niveau de l’ensemble du tableau/forme. En pratique, vous affectez le lien à une portion ou à l’ensemble du texte de la cellule.

**Puis‑je appliquer des polices différentes au sein d’une même cellule ?**

Oui. Le cadre de texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) avec un formatage indépendant — famille de police, style, taille et couleur.