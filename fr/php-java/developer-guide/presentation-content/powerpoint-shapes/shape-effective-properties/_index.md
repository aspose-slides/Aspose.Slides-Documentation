---
title: Obtenir les propriétés effectives des formes à partir des présentations en PHP
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/php-java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- système d'éclairage
- forme à biseau
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for PHP via Java calcule et applique les propriétés effectives des formes pour un rendu précis de PowerPoint."
---

Dans ce sujet, nous aborderons les propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de la portion sur la diapositive de la portion;
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou maître (si la forme du cadre de texte de la portion en possède une);
1. Dans les paramètres de texte globaux de la présentation;

ces valeurs sont appelées valeurs **locales**. À n’importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsqu’une application doit savoir à quoi la portion doit ressembler, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** du format local.

Ce code d’exemple montre comment obtenir les valeurs effectives :
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


## **Obtenir les propriétés effectives d’une caméra**
Aspose.Slides for PHP via Java permet aux développeurs d’obtenir les propriétés effectives de la caméra. À cet effet, l’interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) a été ajoutée à Aspose.Slides. L’interface [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) représente un objet immutable contenant les propriétés effectives de la caméra. Une instance de l’interface [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) est utilisée dans le cadre de l’interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Ce code d’exemple montre comment obtenir les propriétés effectives pour la caméra :
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir les propriétés effectives d’un Light Rig**
Aspose.Slides for PHP via Java permet aux développeurs d’obtenir les propriétés effectives du Light Rig. À cet effet, l’interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) a été ajoutée à Aspose.Slides. L’interface [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) représente un objet immutable contenant les propriétés effectives du Light Rig. Une instance de l’interface [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) est utilisée dans le cadre de l’interface [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Ce code d’exemple montre comment obtenir les propriétés effectives du Light Rig :
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir les propriétés effectives d’une forme à biseau**
Aspose.Slides for PHP via Java permet aux développeurs d’obtenir les propriétés effectives de la forme à biseau. À cet effet, l’interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) a été ajoutée à Aspose.Slides. L’interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) représente un objet immutable contenant les propriétés de relief de la face de la forme. Une instance de l’interface [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) est utilisée dans le cadre de l’interface [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)), qui est une paire de [valeurs effectives](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Ce code d’exemple montre comment obtenir les propriétés effectives pour la forme à biseau :
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir les propriétés effectives d’un cadre de texte**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir les propriétés effectives d’un cadre de texte. À cet effet, l’interface [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de formatage effectif du cadre de texte.

Ce code d’exemple montre comment obtenir les propriétés de formatage effectif du cadre de texte :
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir les propriétés effectives d’un style de texte**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir les propriétés effectives du style de texte. À cet effet, l’interface [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de style de texte effectives.

Ce code d’exemple montre comment obtenir les propriétés de style de texte effectives :
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir la valeur de hauteur de police effective**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir les propriétés effectives de la hauteur de police. Ici, nous présentons un code qui montre la valeur de hauteur de police effective d’une portion qui change après que des valeurs locales de hauteur de police aient été définies à différents niveaux de la structure de la présentation :
```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir le format de remplissage effectif pour un tableau**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques d’un tableau. À cet effet, l’interface [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) a été ajoutée à Aspose.Slides. Elle contient les propriétés de format de remplissage effectif. Veuillez noter ceci : le format de cellule a toujours la priorité sur le format de ligne ; la ligne a la priorité sur la colonne ; et la colonne a la priorité sur le tableau entier.
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


## **FAQ**

**Comment puis‑je savoir que j’ai obtenu un « instantané » plutôt qu’un « objet vivant », et quand devrais‑je relire les propriétés effectives ?**

Les objets EffectiveData sont des instantanés immutables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**La modification de la diapositive de mise en page/maître affecte‑t‑elle les propriétés effectives déjà récupérées ?**

Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour ; il faut le demander à nouveau après avoir changé la mise en page ou le maître.

**Puis‑je modifier les valeurs via EffectiveData ?**

Non. EffectiveData est en lecture seule. Apportez les modifications dans les objets de formatage locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives si nécessaire.

**Que se passe‑t‑il si une propriété n’est définie ni au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut (valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue fait partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je savoir quel niveau a fourni la taille ou la police ?**

Pas directement. EffectiveData renvoie la valeur finale. Pour en connaître la source, examinez les valeurs locales au niveau de la portion/paragraph/texte et les styles de texte au niveau de la mise en page/maître/présentation afin de voir où apparaît la première définition explicite.

**Pourquoi les valeurs EffectiveData sont‑elles parfois identiques aux valeurs locales ?**

Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’a été nécessaire). Dans ce cas, la valeur effective correspond à la valeur locale.

**Quand devrais‑je utiliser les propriétés effectives, et quand travailler uniquement avec les propriétés locales ?**

Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il sera rendu » après toutes les héritages (par ex. pour aligner les couleurs, retraits ou tailles). Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si besoin, relisez EffectiveData pour vérifier le résultat.