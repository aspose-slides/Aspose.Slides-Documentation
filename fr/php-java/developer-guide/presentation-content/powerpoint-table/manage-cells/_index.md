---
title: Gérer les cellules de tableau dans les présentations avec PHP
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/php-java/manage-cells/
keywords:
- cellule de tableau
- fusion de cellules
- supprimer la bordure
- scinder la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérez facilement les cellules de tableau dans PowerPoint avec Aspose.Slides pour PHP. Maîtrisez l'accès, la modification et le style des cellules rapidement pour une automatisation fluide des diapositives."
---

## **Identifier une cellule de tableau fusionnée**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenir le tableau de la première diapositive.
3. Parcourir les lignes et colonnes du tableau pour trouver les cellules fusionnées.
4. Afficher un message lorsqu’une cellule fusionnée est trouvée.

Ce code PHP montre comment identifier les cellules de tableau fusionnées dans une présentation :
```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// en supposant que Slide#0.Shape#0 est un tableau

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Supprimer les bordures des cellules de tableau**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenir la référence d’une diapositive via son indice.
3. Définir un tableau de colonnes avec la largeur.
4. Définir un tableau de lignes avec la hauteur.
5. Ajouter un tableau à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable).
6. Parcourir chaque cellule pour effacer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrer la présentation modifiée en tant que fichier PPTX.

Ce code PHP montre comment supprimer les bordures des cellules de tableau :
```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Ajoute la forme de tableau à la diapositive
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Définit le format de bordure pour chaque cellule
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Enregistre le PPTX sur le disque
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numérotation dans les cellules fusionnées**
Si nous fusionnons deux paires de cellules (1, 1) x (2, 1) et (1, 2) x (2, 2), le tableau résultant sera numéroté. Ce code PHP illustre le processus :
```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Ajoute une forme de tableau à la diapositive
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Définit le format de bordure pour chaque cellule
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Fusionne les cellules (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fusionne les cellules (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Nous fusionnons ensuite les cellules en fusionnant (1, 1) et (1, 2). Le résultat est un tableau contenant une grande cellule fusionnée au centre :
```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Ajoute une forme de tableau à la diapositive
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Définit le format de bordure pour chaque cellule
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Fusionne les cellules (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fusionne les cellules (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Fusionne les cellules (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numérotation dans une cellule divisée**
Dans les exemples précédents, lorsque des cellules de tableau étaient fusionnées, la numérotation ou le système de numérotation des autres cellules ne changeait pas.

Cette fois‑ci, nous prenons un tableau normal (un tableau sans cellules fusionnées) puis nous essayons de diviser la cellule (1, 1) pour obtenir un tableau spécial. Vous souhaiterez peut‑être prêter attention à la numérotation de ce tableau, qui peut sembler étrange. Cependant, c’est ainsi que Microsoft PowerPoint numérote les cellules de tableau et Aspose.Slides fait de même.

Ce code PHP montre le processus décrit :
```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Ajoute une forme de tableau à la diapositive
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Définit le format de bordure pour chaque cellule
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Fusionne les cellules (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fusionne les cellules (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Divise la cellule (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modifier la couleur d’arrière‑plan d’une cellule de tableau**
Ce code PHP montre comment changer la couleur d’arrière‑plan d’une cellule de tableau :
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # crée un nouveau tableau
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # définir la couleur d'arrière-plan d'une cellule
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Ajouter une image dans une cellule de tableau**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenir la référence d’une diapositive via son indice.
3. Définir un tableau de colonnes avec la largeur.
4. Définir un tableau de lignes avec la hauteur.
5. Ajouter un tableau à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable).
6. Créer un objet `Images` pour contenir le fichier image.
7. Ajouter l’image `IImage` à l’objet `IPPImage`.
8. Définir le `FillFormat` de la cellule du tableau sur `Picture`.
9. Ajouter l’image à la première cellule du tableau.
10. Enregistrer la présentation modifiée en tant que fichier PPTX.

Ce code PHP montre comment placer une image dans une cellule de tableau lors de la création d’un tableau :
```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $islide = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Ajoute une forme de tableau à la diapositive
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Crée un objet IPPImage à partir du fichier image
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajoute l'image à la première cellule du tableau
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis‑je définir des épaisseurs et des styles de ligne différents pour chaque côté d’une même cellule ?**

Oui. Les bordures [supérieure](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[inférieure](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[gauche](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[droite](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) possèdent des propriétés distinctes, de sorte que l’épaisseur et le style de chaque côté peuvent différer. Cela découle logiquement du contrôle des bordures par côté pour une cellule présenté dans l’article.

**Que se passe‑t‑il pour l’image si je modifie la taille de la colonne ou de la ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [mode de remplissage](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (étirement/tuile). En mode étirement, l’image s’ajuste à la nouvelle cellule ; en mode tuile, les tuiles sont recalculées. L’article évoque les modes d’affichage d’image dans une cellule.

**Puis‑je attribuer un hyperlien à tout le contenu d’une cellule ?**

[Hyperlinks](/slides/fr/php-java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre texte de la cellule ou au niveau de l’ensemble du tableau/forme. En pratique, vous attribuez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je définir des polices différentes au sein d’une même cellule ?**

Oui. Le cadre texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (segments) avec un formatage indépendant—famille de police, style, taille et couleur.