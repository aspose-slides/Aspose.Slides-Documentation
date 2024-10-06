---
title: Gérer les cellules
type: docs
weight: 30
url: /php-java/manage-cells/
keywords: "Table, cellules fusionnées, cellules divisées, image dans la cellule de table, Java, Aspose.Slides pour PHP via Java"
description: "Cellules de table dans les présentations PowerPoint"
---


## **Identifier une cellule de table fusionnée**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la table de la première diapositive.
3. Itérez à travers les lignes et les colonnes de la table pour trouver les cellules fusionnées.
4. Imprimez un message lorsque des cellules fusionnées sont trouvées.

Ce code PHP montre comment identifier les cellules de table fusionnées dans une présentation :

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// supposant que Slide#0.Shape#0 est une table

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("La cellule %d;%d fait partie d'une cellule fusionnée avec RowSpan=%d et ColSpan=%d commençant à partir de la cellule %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer la bordure des cellules de la table**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de diapositive par son index.
3. Définissez un tableau de colonnes avec largeur.
4. Définissez un tableau de lignes avec hauteur.
5. Ajoutez une table à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Itérez à travers chaque cellule pour effacer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP montre comment supprimer les bordures des cellules de table :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Ajoute une forme de table à la diapositive
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
    # Écrit le PPTX sur le disque
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numérotation dans les cellules fusionnées**
Si nous fusionnons 2 paires de cellules (1, 1) x (2, 1) et (1, 2) x (2, 2), la table résultante sera numérotée. Ce code PHP démontre le processus :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Ajoute une forme de table à la diapositive
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

Nous fusionnons ensuite davantage les cellules en fusionnant (1, 1) et (1, 2). Le résultat est une table contenant une grande cellule fusionnée au centre :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Ajoute une forme de table à la diapositive
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
    # Écrit le fichier PPTX sur le disque
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numérotation dans la cellule divisée**
Dans les exemples précédents, lorsque les cellules de table ont été fusionnées, la numérotation ou le système de numérotation dans d'autres cellules n'a pas changé.

Cette fois, nous prenons une table ordinaire (une table sans cellules fusionnées) puis essayons de diviser la cellule (1,1) pour obtenir une table spéciale. Vous voudrez peut-être faire attention à la numérotation de cette table, qui peut sembler étrange. Cependant, c'est ainsi que Microsoft PowerPoint numérote les cellules de la table et Aspose.Slides fait la même chose.

Ce code PHP démontre le processus que nous avons décrit :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Ajoute une forme de table à la diapositive
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
    # Écrit le fichier PPTX sur le disque
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Changer la couleur de fond d'une cellule de table**

Ce code PHP montre comment changer la couleur de fond d'une cellule de table :

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # crée une nouvelle table
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # définit la couleur de fond pour une cellule
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

## **Ajouter une image à l'intérieur d'une cellule de table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de diapositive par son index.
3. Définissez un tableau de colonnes avec largeur.
4. Définissez un tableau de lignes avec hauteur.
5. Ajoutez une table à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Créez un objet `Images` pour contenir le fichier image.
7. Ajoutez l'image `IImage` à l'objet `IPPImage`.
8. Définissez le `FillFormat` pour la cellule de table sur `Picture`.
9. Ajoutez l'image à la première cellule de la table.
10. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP montre comment placer une image dans une cellule de table lors de la création d'une table :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $islide = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Ajoute une forme de table à la diapositive
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
    # Ajoute l'image à la première cellule de la table
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