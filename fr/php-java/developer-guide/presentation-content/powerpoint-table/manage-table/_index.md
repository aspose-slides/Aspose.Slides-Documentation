---
title: Gérer les tables de présentation en PHP
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/php-java/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- rapport d'aspect
- aligner le texte
- formatage du texte
- style de tableau
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour PHP via Java. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tables."
---

Un tableau dans PowerPoint est un moyen efficace d'afficher et de présenter des informations. Les informations dans une grille de cellules (disposées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table), la classe [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans toutes sortes de présentations.

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) pour appliquer un formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) d'une [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

```php
  # Instancie une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Ajoute une forme de tableau à la diapositive
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
    # Fusionne les cellules 1 et 2 de la ligne 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Ajoute du texte à la cellule fusionnée
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Enregistre la présentation sur le disque
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numérotation dans un tableau standard**

Dans un tableau standard, la numérotation des cellules est simple et basée sur zéro. La première cellule d'un tableau est indexée comme 0,0 (colonne 0, ligne 0).

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code PHP vous montre comment spécifier la numérotation des cellules dans un tableau :
```php
  # Instancie une classe Presentation qui représente un fichier PPTX
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
    # Enregistre la présentation sur le disque
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Accéder à un tableau existant**

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Obtenez une référence à la diapositive contenant le tableau via son index.
3. Créez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) et définissez-le sur null.
4. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) jusqu'à ce que le tableau soit trouvé.

   Si vous pensez que la diapositive que vous examinez ne contient qu'un seul tableau, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsqu'une forme est identifiée comme un tableau, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). Mais si la diapositive que vous examinez contient plusieurs tableaux, il est préférable de rechercher le tableau dont vous avez besoin via sa méthode [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/).

5. Utilisez l'objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) pour travailler avec le tableau. Dans l'exemple ci‑dessous, nous avons ajouté une nouvelle ligne au tableau.
6. Enregistrez la présentation modifiée.

```php
  # Instancie la classe Presentation qui représente un fichier PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Initialise TableEx à null
    $tbl = null;
    # Parcourt les formes et définit une référence vers le tableau trouvé
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Définit le texte pour la première colonne de la deuxième ligne
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Enregistre la présentation modifiée sur le disque
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Aligner le texte dans un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) à la diapositive.
4. Accédez à un objet [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) depuis le tableau.
5. Accédez au [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Ajoute la forme de tableau à la diapositive
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
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Aligne le texte verticalement
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Enregistre la présentation sur le disque
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir le formatage du texte au niveau du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Accédez à un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) depuis la diapositive.
4. Définissez la méthode [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pour le texte.
5. Définissez les méthodes [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) et [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Définissez la méthode [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Enregistrez la présentation modifiée.

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Supposons que la première forme de la première diapositive est un tableau
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit la hauteur de police des cellules du tableau
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Définit l'alignement du texte des cellules du tableau et la marge droite en un seul appel
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Définit le type vertical du texte des cellules du tableau
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


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin que vous puissiez utiliser ces informations pour un autre tableau ou ailleurs. Ce code PHP vous montre comment obtenir les propriétés de style à partir d'un style prédéfini de tableau :
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// modifier le thème de style prédéfini par défaut

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Verrouiller le rapport d'aspect d'un tableau**

Le rapport d'aspect d'une forme géométrique est le rapport de ses dimensions dans différentes directions. Aspose.Slides propose la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) pour vous permettre de verrouiller le réglage du rapport d'aspect des tableaux et d'autres formes.

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// inverser

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte dans ses cellules ?**

Oui. Le tableau expose une méthode [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), et les paragraphes possèdent [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). L'utilisation des deux garantit le bon ordre RTL et le rendu correct à l'intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou redimensionner un tableau dans le fichier final ?**

Utilisez les [verrouillages de forme](/slides/fr/php-java/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L'insertion d'une image à l'intérieur d'une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [remplissage d'image](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).