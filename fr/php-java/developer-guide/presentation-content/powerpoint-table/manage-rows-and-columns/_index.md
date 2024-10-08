---
title: Gérer les lignes et colonnes
type: docs
weight: 20
url: /fr/php-java/manage-rows-and-columns/
keywords: "Table, lignes et colonnes de table, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Gérer les lignes et colonnes des tableaux dans les présentations PowerPoint"
---

Pour vous permettre de gérer les lignes et les colonnes d'un tableau dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) et de nombreux autres types.

## **Définir la première ligne comme en-tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation.
2. Obtenez la référence d'une diapositive par son index. 
3. Créez un objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) et définissez-le sur null.
4. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) pour trouver le tableau pertinent.
5. Définissez la première ligne du tableau comme son en-tête.

Ce code PHP vous montre comment définir la première ligne d'un tableau comme son en-tête :

```php
  # Instancie la classe Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Initialise le TableEx null
    $tbl = null;
    # Itère à travers les formes et définit une référence au tableau
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Définit la première ligne d'un tableau comme son en-tête
        $tbl->setFirstRow(true);
      }
    }
    # Enregistre la présentation sur le disque
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cloner la ligne ou la colonne d'un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation.
2. Obtenez la référence d'une diapositive par son index. 
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Clonez la ligne du tableau.
7. Clonez la colonne du tableau.
8. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment cloner une ligne ou une colonne d'un tableau PowerPoint :

```php
  # Instancie la classe Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit des colonnes avec des largeurs et des lignes avec des hauteurs
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Ajoute une forme de tableau à la diapositive
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ajoute du texte à la cellule 1 de la ligne 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Cellule 1 de la ligne 1");
    # Ajoute du texte à la cellule 2 de la ligne 1
    $table->get_Item(1, 0)->getTextFrame()->setText("Cellule 2 de la ligne 1");
    # Clone la ligne 1 à la fin du tableau
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Ajoute du texte à la cellule 1 de la ligne 2
    $table->get_Item(0, 1)->getTextFrame()->setText("Cellule 1 de la ligne 2");
    # Ajoute du texte à la cellule 2 de la ligne 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Cellule 2 de la ligne 2");
    # Clone la ligne 2 en tant que 4ème ligne du tableau
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Clone la première colonne à la fin
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Clone la 2ème colonne à l'index de la 4ème colonne
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Enregistre la présentation sur le disque
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer une ligne ou une colonne d'un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation.
2. Obtenez la référence d'une diapositive par son index. 
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Supprimez la ligne du tableau.
7. Supprimez la colonne du tableau.
8. Enregistrez la présentation modifiée. 

Ce code PHP vous montre comment supprimer une ligne ou une colonne d'un tableau :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir le formatage du texte au niveau de la ligne du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation.
2. Obtenez la référence d'une diapositive par son index. 
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) pertinent depuis la diapositive.
4. Définissez la hauteur de police des cellules de la première ligne [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Définissez l'alignement [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) et la marge droite [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) des cellules de la première ligne.
6. Définissez le type vertical du texte des cellules de la deuxième ligne [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée.

Ce code PHP démontre l'opération.

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Supposons que la première forme sur la première diapositive est un tableau
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit la hauteur de police des cellules de la première ligne
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Définit l'alignement du texte et la marge droite des cellules de la première ligne
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Définit le type vertical du texte des cellules de la deuxième ligne
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Enregistre la présentation sur le disque
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir le formatage du texte au niveau de la colonne du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation.
2. Obtenez la référence d'une diapositive par son index. 
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) pertinent depuis la diapositive.
4. Définissez la hauteur de police des cellules de la première colonne [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Définissez l'alignement [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) et la marge droite [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) des cellules de la première colonne.
6. Définissez le type vertical du texte des cellules de la deuxième colonne [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée. 

Ce code PHP démontre l'opération :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Supposons que la première forme sur la première diapositive est un tableau
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit la hauteur de police des cellules de la première colonne
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Définit l'alignement du texte et la marge droite des cellules de la première colonne en un seul appel
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Définit le type vertical du texte des cellules de la deuxième colonne
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir les propriétés de style d'un tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin que vous puissiez utiliser ces détails pour un autre tableau ou ailleurs. Ce code PHP vous montre comment obtenir les propriétés de style à partir d'un style de tableau prédéfini :

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// change le style par défaut prédéfini

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```