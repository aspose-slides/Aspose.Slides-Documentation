---
title: Gérer la Table
type: docs
weight: 10
url: /fr/php-java/manage-table/
keywords: "Table, créer table, accéder table, rapport d'aspect de table, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Créer et gérer des tables dans des présentations PowerPoint"
---

Une table dans PowerPoint est un moyen efficace d'afficher et de représenter des informations. Les informations dans une grille de cellules (organisées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table), l'interface [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable), la classe [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) l'interface [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tables dans tous types de présentations.

## **Créer une Table à Partir de Rien**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Itérez à travers chaque [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) pour appliquer un formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne de la table.
8. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) d'une [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment créer une table dans une présentation :

```php
  # Instancie une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit des colonnes avec des largeurs et des lignes avec des hauteurs
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Ajoute une forme de table à la diapositive
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Définit le format de bordure pour chaque cellule
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Fusionne les cellules 1 & 2 de la ligne 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Ajoute du texte à la cellule fusionnée
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Cellules Fusionnées");
    # Sauvegarde la présentation sur le disque
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numérotation dans la Table Standard**

Dans une table standard, la numérotation des cellules est simple et basée sur zéro. La première cellule d'une table est indexée comme 0,0 (colonne 0, ligne 0).

Par exemple, les cellules d'une table avec 4 colonnes et 4 lignes sont numérotées de cette manière :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code PHP vous montre comment spécifier la numérotation pour les cellules dans une table :

```php
  # Instancie une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit des colonnes avec des largeurs et des lignes avec des hauteurs
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
    # Sauvegarde la présentation sur le disque
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accéder à une Table Existante**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).

2. Obtenez une référence à la diapositive contenant la table par son index.

3. Créez un objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) et définissez-le sur null.

4. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) jusqu'à ce que la table soit trouvée.

   Si vous suspectez que la diapositive avec laquelle vous traitez contient une seule table, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsqu'une forme est identifiée comme une table, vous pouvez la caster comme un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). Mais si la diapositive avec laquelle vous traitez contient plusieurs tables, alors il est préférable de rechercher la table dont vous avez besoin via son [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) pour travailler avec la table. Dans l'exemple ci-dessous, nous avons ajouté une nouvelle ligne à la table.

6. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment accéder et travailler avec une table existante :

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Initialise la TableEx à null
    $tbl = null;
    # Itère à travers les formes et définit une référence à la table trouvée
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Définit le texte pour la première colonne de la deuxième ligne
        $tbl->get_Item(0, 1)->getTextFrame()->setText("Nouveau");
      }
    }
    # Sauvegarde la présentation modifiée sur le disque
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aligner le Texte dans la Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) à partir de la table.
5. Accédez à la [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment aligner le texte dans une table :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Définit des colonnes avec des largeurs et des lignes avec des hauteurs
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Ajoute la forme de table à la diapositive
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Accède au cadre de texte
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Crée l'objet Paragraph pour le cadre de texte
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Crée l'objet Portion pour le paragraphe
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Texte ici");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Aligne le texte verticalement
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Sauvegarde la présentation sur le disque
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir le Formatage du Texte au Niveau de la Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) à partir de la diapositive.
4. Définissez le [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) pour le texte.
5. Définissez le [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Définissez le [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment appliquer vos options de formatage préférées au texte dans une table :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Supposons que la première forme de la première diapositive est une table
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit la hauteur de police des cellules de la table
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Définit l'alignement du texte des cellules de la table et la marge droite en un seul appel
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Définit le type de texte vertical des cellules de la table
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir les Propriétés de Style de la Table**

Aspose.Slides vous permet de récupérer les propriétés de style pour une table afin que vous puissiez utiliser ces détails pour une autre table ou ailleurs. Ce code PHP vous montre comment obtenir les propriétés de style d'un style de table prédéfini :

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// change le thème de style prédéfini par défaut

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verrouiller le Rapport d'Aspect de la Table**

Le rapport d'aspect d'une forme géométrique est le rapport de ses tailles dans différentes dimensions. Aspose.Slides a fourni la propriété [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) pour vous permettre de verrouiller le réglage du rapport d'aspect pour les tables et d'autres formes.

Ce code PHP vous montre comment verrouiller le rapport d'aspect d'une table :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Verrouillage du rapport d'aspect réglé : " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// inverse

    echo("Verrouillage du rapport d'aspect réglé : " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```