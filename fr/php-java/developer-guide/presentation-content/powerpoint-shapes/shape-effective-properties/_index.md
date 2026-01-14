---
title: Obtenir les propriétés effectives de forme à partir des présentations en PHP
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/php-java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de la caméra
- systeme d'eclairage
- forme biseau
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for PHP via Java calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---

Dans ce sujet, nous allons discuter des propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion ;
1. Dans le style de texte de la forme prototype sur la diapositive de mise en page ou maîtresse (si la forme du cadre de texte de la portion en possède une) ;
1. Dans les paramètres de texte globaux de la présentation ;

Ces valeurs sont appelées valeurs **locales**. À n’importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais lorsqu’une application doit savoir à quoi la portion doit ressembler, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** du format local.

Ce code d’exemple vous montre comment obtenir des valeurs effectives :
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


## **Obtenir les propriétés effectives d'une caméra**
Aspose.Slides for PHP via Java permet aux développeurs d’obtenir les propriétés effectives de la caméra. À cet effet, la classe `ICameraEffectiveData` a été ajoutée à Aspose.Slides. La classe `ICameraEffectiveData` représente un objet immuable qui contient les propriétés effectives de la caméra. Une instance de la classe `ICameraEffectiveData` est utilisée dans la classe `IThreeDFormatEffectiveData`, qui constitue une paire de [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Ce code d’exemple vous montre comment obtenir les propriétés effectives de la caméra :
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


## **Obtenir les propriétés effectives d'un Light Rig**
Aspose.Slides for PHP via Java permet aux développeurs d’obtenir les propriétés effectives du Light Rig. À cet effet, la classe `ILightRigEffectiveData` a été ajoutée à Aspose.Slides. La classe `ILightRigEffectiveData` représente un objet immuable qui contient les propriétés effectives du Light Rig. Une instance de la classe `ILightRigEffectiveData` est utilisée dans la classe `IThreeDFormatEffectiveData`, qui constitue une paire de [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Ce code d’exemple vous montre comment obtenir les propriétés effectives du Light Rig :
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


## **Obtenir les propriétés effectives d'une Bevel Shape**
Aspose.Slides for PHP via Java permet aux développeurs d’obtenir les propriétés effectives d’une Bevel Shape. À cet effet, la classe `IShapeBevelEffectiveData` a été ajoutée à Aspose.Slides. La classe `IShapeBevelEffectiveData` représente un objet immuable qui contient les propriétés de relief de face de la forme. Une instance de la classe `IShapeBevelEffectiveData` est utilisée dans la classe `IThreeDFormatEffectiveData`, qui constitue une paire de [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) pour la classe [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Ce code d’exemple vous montre comment obtenir les propriétés effectives de la Bevel Shape :
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


## **Obtenir les propriétés effectives d'un Text Frame**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir les propriétés effectives d’un Text Frame. À cet effet, la classe `ITextFrameFormatEffectiveData` a été ajoutée à Aspose.Slides. Elle contient les propriétés effectives de mise en forme du cadre de texte.

Ce code d’exemple vous montre comment obtenir les propriétés effectives de mise en forme du cadre de texte :
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


## **Obtenir les propriétés effectives d'un Text Style**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir les propriétés effectives d’un Text Style. À cet effet, la classe `ITextStyleEffectiveData` a été ajoutée à Aspose.Slides. Elle contient les propriétés effectives du style de texte.

Ce code d’exemple vous montre comment obtenir les propriétés effectives du style de texte :
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


## **Obtenir la valeur effective de la hauteur de police**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir les propriétés effectives de la hauteur de police. Ici, nous fournissons un code qui montre la valeur effective de la hauteur de police d’une portion changer après que des valeurs locales de hauteur de police aient été définies à différents niveaux de la structure de la présentation :
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


## **Obtenir le format de remplissage effectif d’un tableau**
En utilisant Aspose.Slides for PHP via Java, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques d’un tableau. À cet effet, la classe `ICellFormatEffectiveData` a été ajoutée à Aspose.Slides. Elle contient les propriétés effectives du format de remplissage. Veuillez noter : le format de cellule a toujours la priorité sur le format de ligne ; la ligne a la priorité sur la colonne ; et la colonne a la priorité sur l’ensemble du tableau.
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

**Comment savoir si j’ai obtenu un « instantané » plutôt qu’un « objet vivant », et quand devrais‑je relire les propriétés effectives ?**  
Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**La modification de la diapositive de mise en page/maîtresse affecte‑t‑elle les propriétés effectives déjà récupérées ?**  
Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour automatiquement — il faut le demander à nouveau après avoir modifié la mise en page ou le maître.

**Puis‑je modifier des valeurs via EffectiveData ?**  
Non. EffectiveData est en lecture seule. Apportez les modifications dans les objets de formatage locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est définie ni au niveau de la forme, ni dans la mise en page/maîtresse, ni dans les paramètres globaux ?**  
La valeur effective est déterminée par le mécanisme par défaut (les valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue devient partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je déterminer quel niveau a fourni la taille ou la police ?**  
Pas directement. EffectiveData renvoie la valeur finale. Pour identifier la source, examinez les valeurs locales au niveau de la portion/du paragraphe/du cadre de texte et les styles de texte au niveau de la mise en page/du maître/de la présentation pour voir où apparaît la première définition explicite.

**Pourquoi les valeurs EffectiveData sont parfois identiques aux valeurs locales ?**  
Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’était nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand devrais‑je utiliser les propriétés effectives, et quand travailler uniquement avec les propriétés locales ?**  
Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il est rendu » après l’application de tous les héritages (par ex., pour aligner les couleurs, les retraits ou les tailles). Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales et, si nécessaire, relisez EffectiveData pour vérifier le résultat.