---
title: Propriétés Efficaces de la Forme
type: docs
weight: 50
url: /fr/php-java/shape-effective-properties/
---

Dans ce sujet, nous allons discuter des propriétés **efficaces** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion ;
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou de modèle (si la forme du cadre de texte de la portion en a un) ;
1. Dans les paramètres de texte globaux de la présentation ;

ces valeurs sont appelées valeurs **locales**. À n'importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais quand une application a besoin de savoir à quoi devrait ressembler la portion, elle utilise des valeurs **efficaces**. Vous pouvez obtenir des valeurs efficaces en utilisant la méthode **getEffective()** du format local.

Ce code d'exemple vous montre comment obtenir des valeurs efficaces :

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtention des Propriétés Efficaces de la Caméra**
Aspose.Slides pour PHP via Java permet aux développeurs d'obtenir des propriétés efficaces de la caméra. Pour cela, l'interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) a été ajoutée à Aspose.Slides. L'interface [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) représente un objet immuable qui contient les propriétés efficaces de la caméra. Une instance de l'interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Ce code d'exemple vous montre comment obtenir des propriétés efficaces pour la caméra :

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Propriétés efficaces de la caméra =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Champ de vision: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtention des Propriétés Efficaces de Light Rig**
Aspose.Slides pour PHP via Java permet aux développeurs d'obtenir des propriétés efficaces de Light Rig. Pour cela, l'interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) a été ajoutée à Aspose.Slides. L'interface [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) représente un objet immuable qui contient les propriétés efficaces du Light Rig. Une instance de l'interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Ce code d'exemple vous montre comment obtenir des propriétés efficaces de Light Rig :

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Propriétés efficaces de Light Rig =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtention des Propriétés Efficaces de la Forme Biseau**
Aspose.Slides pour PHP via Java permet aux développeurs d'obtenir des propriétés efficaces de la forme biseau. Pour cela, l'interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) a été ajoutée à Aspose.Slides. L'interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) représente un objet immuable qui contient les propriétés de relief de la face efficace de la forme. Une instance de l'interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) est utilisée dans le cadre de l'interface [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)), qui est une paire de [valeurs efficaces](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Ce code d'exemple vous montre comment obtenir des propriétés efficaces pour la forme biseau :

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Propriétés efficaces de la face supérieure de la forme =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Largeur: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Hauteur: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtention des Propriétés Efficaces d'un Cadre de Texte**
En utilisant Aspose.Slides pour PHP via Java, vous pouvez obtenir des propriétés efficaces d'un cadre de texte. Pour cela, l'interface [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de formatage efficaces du cadre de texte.

Ce code d'exemple vous montre comment obtenir des propriétés de formatage efficaces du cadre de texte :

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Type d'ancrage: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Type d'ajustement automatique: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Type de texte vertical: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Marges");
    echo("   Gauche: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Haut: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Droit: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bas: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtention des Propriétés Efficaces d'un Style de Texte**
En utilisant Aspose.Slides pour PHP via Java, vous pouvez obtenir des propriétés efficaces d'un style de texte. Pour cela, l'interface [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) a été ajoutée à Aspose.Slides. Elle contient des propriétés de style de texte efficaces.

Ce code d'exemple vous montre comment obtenir des propriétés de style de texte efficaces :

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Formatage de paragraphe efficace pour le niveau de style #" . $i . " =");
      echo("Profondeur: " . $effectiveStyleLevel->getDepth());
      echo("Indentation: " . $effectiveStyleLevel->getIndent());
      echo("Alignement: " . $effectiveStyleLevel->getAlignment());
      echo("Alignement de la police: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtention de la Valeur de Hauteur de Police Efficace**
En utilisant Aspose.Slides pour PHP via Java, vous pouvez obtenir des propriétés efficaces de la hauteur de police. Ici, nous fournissons un code qui montre la valeur efficace de la hauteur de police de la portion changeant après que des valeurs de hauteur de police locales aient été définies à différents niveaux de structure de présentation :

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Texte d'exemple avec première portion");
    $portion1 = new Portion(" et deuxième portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Hauteur de police efficace juste après création :");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Hauteur de police efficace après réglage de la hauteur de police par défaut de la présentation :");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Hauteur de police efficace après réglage de la hauteur de police par défaut du paragraphe :");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Hauteur de police efficace après réglage de la hauteur de police de la portion #0 :");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Hauteur de police efficace après réglage de la hauteur de police de la portion #1 :");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtention du Format de Remplissage Efficace pour un Tableau**
En utilisant Aspose.Slides pour PHP via Java, vous pouvez obtenir un formatage de remplissage efficace pour différentes parties logiques du tableau. Pour cela, l'interface [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) a été ajoutée dans Aspose.Slides. Elle contient des propriétés de formatage de remplissage efficaces. Veuillez noter ceci : le formatage des cellules obtient toujours la priorité sur le formatage des lignes ; les lignes obtiennent la priorité sur les colonnes ; et les colonnes obtiennent la priorité sur l'ensemble du tableau.

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```