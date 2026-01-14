---
title: Gérer les lignes et les colonnes des tableaux PowerPoint à l'aide de PHP
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/php-java/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en-tête du tableau
- cloner une ligne
- cloner une colonne
- copier une ligne
- copier une colonne
- supprimer une ligne
- supprimer une colonne
- mise en forme du texte de la ligne
- mise en forme du texte de la colonne
- style de tableau
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérez les lignes et les colonnes des tableaux PowerPoint avec Aspose.Slides pour PHP via Java et accélérez l'édition des présentations ainsi que les mises à jour de données."
---

Pour vous permettre de gérer les lignes et les colonnes d’un tableau dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) et de nombreux autres types.

## **Définir la première ligne comme en‑tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation.  
2. Obtenez la référence d’une diapositive via son indice.  
3. Créez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) et définissez‑le sur null.  
4. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pour trouver le tableau correspondant.  
5. Définissez la première ligne du tableau comme en‑tête.  

Ce code PHP vous montre comment définir la première ligne d’un tableau comme en‑tête :
```php
  # Instancie la classe Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Initialise le TableEx à null
    $tbl = null;
    # Parcourt les formes et définit une référence au tableau
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Définit la première ligne du tableau comme en‑tête
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


## **Cloner une ligne ou une colonne de tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Définissez un tableau `columnWidth`.  
4. Définissez un tableau `rowHeight`.  
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
6. Clonez la ligne du tableau.  
7. Clonez la colonne du tableau.  
8. Enregistrez la présentation modifiée.  

Ce code PHP vous montre comment cloner la ligne ou la colonne d’un tableau PowerPoint :
```php
  # Instancie la classe Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Ajoute une forme de tableau à la diapositive
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ajoute du texte à la cellule 1 de la ligne 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Ajoute du texte à la cellule 2 de la ligne 1
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Clone la ligne 1 à la fin du tableau
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Ajoute du texte à la cellule 1 de la ligne 2
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Ajoute du texte à la cellule 2 de la ligne 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Clone la ligne 2 comme quatrième ligne du tableau
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Clone la première colonne à la fin
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Clone la deuxième colonne à l'index de la quatrième colonne
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Enregistre la présentation sur le disque
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Supprimer une ligne ou une colonne d’un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Définissez un tableau `columnWidth`.  
4. Définissez un tableau `rowHeight`.  
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
6. Supprimez la ligne du tableau.  
7. Supprimez la colonne du tableau.  
8. Enregistrez la présentation modifiée.  

Ce code PHP vous montre comment supprimer une ligne ou une colonne d’un tableau :
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


## **Appliquer un format de texte au niveau des lignes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Accédez à l’objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) concerné depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première ligne avec [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Définissez l’alignement et la marge droite des cellules de la première ligne avec [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) et [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Définissez le type de texte vertical des cellules de la deuxième ligne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Enregistrez la présentation modifiée.  

Ce code PHP illustre l’opération.
```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Supposons que la première forme sur la première diapositive soit un tableau
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
    # Définit le type de texte vertical des cellules de la deuxième ligne
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


## **Appliquer un format de texte au niveau des colonnes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation,  
2. Obtenez la référence d’une diapositive via son indice.  
3. Accédez à l’objet [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) concerné depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première colonne avec [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Définissez l’alignement et la marge droite des cellules de la première colonne avec [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) et [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Définissez le type de texte vertical des cellules de la deuxième colonne avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Enregistrez la présentation modifiée.  

Ce code PHP illustre l’opération :
```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Supposons que la première forme de la première diapositive soit un tableau
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
    # Définit le type de texte vertical des cellules de la deuxième colonne
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


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin de les réutiliser pour un autre tableau ou ailleurs. Ce code PHP montre comment obtenir les propriétés de style d’un style de tableau prédéfini :
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// modifie le thème du style prédéfini par défaut

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis‑je appliquer les thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive/de la disposition/du maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs de texte par‑dessus.

**Puis‑je trier les lignes d’un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides ne disposent pas de fonction de tri ou de filtres intégrée. Triez d’abord vos données en mémoire, puis repopulez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques par un format local ; le format au niveau de la cellule l’emporte sur le style du tableau.