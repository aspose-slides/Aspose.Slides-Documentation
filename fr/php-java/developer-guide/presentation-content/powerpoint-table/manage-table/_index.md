---
title: Gérer les tableaux de présentation en PHP
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/php-java/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- ratio d'aspect
- aligner le texte
- mise en forme du texte
- style de tableau
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour PHP via Java. Découvrez des exemples de code simples pour optimiser vos flux de travail de tableau."
---
## **Introduction**

Les tableaux dans PowerPoint organisent les informations en lignes et colonnes, ce qui facilite la lecture et la comparaison des valeurs.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , la classe [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) et d’autres types pour vous permettre de créer, mettre à jour et gérer les tableaux dans les présentations.

## **Créer un tableau à partir de zéro**

Créez un tableau en spécifiant sa position, les largeurs des colonnes et les hauteurs des lignes. Après l’avoir ajouté à une diapositive, vous pouvez formater les bordures des cellules, fusionner des cellules et insérer du texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Définissez un tableau des largeurs de colonnes en points.
4. Définissez un tableau des hauteurs de lignes en points.
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez à la cellule fusionnée via sa méthode [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/).
9. Définissez le texte dans la cellule fusionnée.
10. Enregistrez la présentation modifiée.

L’exemple ci‑dessous crée un tableau avec trois colonnes et cinq lignes à (100, 50) points. Il applique des bordures rouges d’une largeur de 5 points, fusionne les deux premières cellules de la première ligne et enregistre le résultat sous `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, les indices des cellules commencent à zéro et utilisent l’ordre (colonne, ligne). La première cellule a l’indice (0, 0).

Par exemple, les cellules d’un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Cet exemple crée le tableau 4 × 4 illustré ci‑dessus, avec des largeurs de colonnes et hauteurs de lignes de 70 points ainsi que des bordures de cellules rouges d’une largeur de 5 points. Les coordonnées illustrent les indices des cellules ; l’exemple laisse les cellules vides et enregistre le tableau sous `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Accéder à un tableau existant**

Les tableaux sont stockés dans la collection de formes d’une diapositive. Parcourez les formes pour localiser un tableau, puis utilisez la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) pour lire ou mettre à jour ses cellules.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive contenant le tableau par son indice.
3. Parcourez les objets [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) et arrêtez‑vous lorsqu’un tableau est trouvé. Si la diapositive contient plusieurs tableaux, utilisez [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) pour identifier celui dont vous avez besoin.
4. Mettez à jour le texte dans la cellule cible.
5. Enregistrez la présentation modifiée.

L’exemple ci‑dessous ouvre `UpdateExistingTable.pptx` et trouve le premier tableau de la première diapositive. Il définit la cellule à la colonne 0, ligne 1 à `New` et enregistre le résultat sous `table1_out.pptx`. L’entrée doit contenir au moins une diapositive, et le premier tableau de cette diapositive doit avoir au moins une colonne et deux lignes.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Pour redimensionner une ligne dans un tableau existant et comprendre pourquoi sa hauteur réelle peut dépasser le minimum demandé, consultez [Contrôler la hauteur des lignes](/slides/fr/php-java/manage-rows-and-columns/#control-row-height).

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement de texte reçoit un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) d’un tableau, utilisez la méthode [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) pour récupérer la [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) propriétaire. Pour un cadre de texte de cellule de tableau, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) renvoie le propriétaire et [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) renvoie `null`, même si le tableau lui‑même est une forme.

Les coordonnées de la cellule sont disponibles via les méthodes en lecture seule [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) et [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/). [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) fournit également une navigation en lecture seule : elle renvoie le propriétaire mais ne modifie pas la propriété. Vérifiez toujours que la cellule renvoyée n’est pas `java_is_null` avant de l’utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, consultez [Recherche et remplacement de texte](/slides/fr/php-java/search-and-replace-text/).

## **Aligner le texte dans un tableau**

Vous pouvez contrôler l’ancrage vertical et la direction du texte de chaque cellule de tableau. L’exemple de cette section centre le texte dans la première cellule et le fait pivoter de 270 degrés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) à la diapositive.
4. Accédez à un objet [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) du tableau.
5. Accédez au premier [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) et définissez son texte et sa couleur.
6. Définissez l’ancrage vertical de la cellule et la direction du texte à l’aide de [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) et [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/).
7. Enregistrez la présentation modifiée.

Cet exemple crée un tableau 4 × 4 avec des largeurs de colonnes de 120 points et des hauteurs de lignes de 100 points. Il met en forme le texte de la cellule (0, 0), ajoute des valeurs aux cellules restantes de la première ligne, et enregistre le résultat sous `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir le format du texte au niveau du tableau**

Utilisez [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) pour appliquer le formatage du texte à toutes les cellules d’un tableau. Ses surcharges acceptent le formatage de portion, de paragraphe et de cadre de texte, de sorte que vous pouvez définir ces propriétés sans parcourir chaque cellule.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) de la diapositive.
4. Définissez la taille de police à l’aide de [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pour le texte.
5. Définissez l’alignement du paragraphe et la marge droite à l’aide de [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) et [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Définissez la direction du texte à l’aide de [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Enregistrez la présentation modifiée.

L’exemple ci‑dessus ouvre `table.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il définit la taille de police à 25 points, aligne à droite les paragraphes avec une marge droite de 20 points, et rend le texte vertical. La présentation formatée est enregistrée sous `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtenir les propriétés de style du tableau**

Utilisez [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) pour lire le style pré‑défini d’un tableau et [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) pour l’attribuer. Cet exemple applique [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) à un tableau, affiche la valeur du style, et attribue le même style à un second tableau. Les deux tableaux sont enregistrés dans `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verrouiller le ratio d’aspect d’un tableau**

Le ratio d’aspect d’un tableau est le rapport de sa largeur à sa hauteur. Utilisez [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) pour verrouiller ce ratio pour un tableau.

L’exemple ci‑dessus ouvre `pres.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il affiche l’état actuel du verrouillage, active le verrouillage du ratio d’aspect, affiche l’état mis à jour (`true`), et enregistre le résultat sous `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Puis‑je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte de ses cellules ?**

Oui. Le tableau expose une méthode [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), et les paragraphes possèdent [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). L’utilisation des deux garantit le bon ordre RTL et le rendu correct à l’intérieur des cellules.

**Comment puis‑je empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L’insertion d’une image à l’intérieur d’une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).