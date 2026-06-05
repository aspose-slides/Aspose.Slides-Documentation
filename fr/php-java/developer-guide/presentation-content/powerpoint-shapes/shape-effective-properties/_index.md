---
title: Obtenir les propriétés effectives d'une forme à partir de présentations en PHP
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
description: "Découvrez comment Aspose.Slides pour PHP via Java calcule et applique les propriétés effectives des formes pour un rendu précis de PowerPoint."
---
## **Vue d'ensemble**

Ce sujet explique la différence entre les propriétés **locales** et **effectives**. Les valeurs locales sont des valeurs définies directement à un niveau de formatage spécifique, comme :

1. Propriétés de portion sur une diapositive.  
1. Styles de texte de forme prototype sur une diapositive de mise en page ou maître, lorsque la forme du cadre de texte de la portion en possède un.  
1. Paramètres de texte globaux dans une présentation.  

Les valeurs locales peuvent être définies ou omises à n'importe quel niveau. Lorsque Aspose.Slides a besoin du format final « tel qu'affiché », il résout la chaîne d'héritage et renvoie les valeurs **effectives**. Vous pouvez les obtenir en appelant la méthode `getEffective` sur l'objet de format local.

La démonstration suivante montre comment obtenir les valeurs effectives. Elle suppose que la première forme de la première diapositive est une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) avec un cadre de texte et au moins une portion.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Les données de formatage effectives représentent le format calculé actuel après l'application de l'héritage. Dans l'implémentation actuelle, certains objets de données effectives renvoyés par des méthodes telles que [PortionFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/geteffective/) peuvent être mis en cache en interne. Appeler `getEffective` à nouveau après avoir modifié le format parent ou hérité peut actualiser le cache, et un objet obtenu précédemment peut ne plus représenter l'état antérieur. Si vous devez conserver les valeurs effectives pour une réutilisation ultérieure, copiez les propriétés requises, telles que la hauteur de police, la couleur de remplissage, le style de police ou l'alignement, dans votre propre objet de données.
{{% /alert %}}

## **Obtenir les propriétés effectives d'une caméra**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'une caméra. Les données effectives renvoyées par [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/) contiennent les propriétés finales de la caméra pour un [ThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives de la caméra. Il suppose que la première forme de la première diapositive possède un format 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtenir les propriétés effectives d'un système d'éclairage**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'un système d'éclairage. Les données effectives renvoyées par [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/) contiennent les propriétés finales du système d'éclairage pour un [ThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives du système d'éclairage. Il suppose que la première forme de la première diapositive possède un format 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtenir les propriétés effectives d'une forme à biseau**

Aspose.Slides vous permet d'obtenir les propriétés effectives d'une forme à biseau. Les données effectives renvoyées par [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/) contiennent les propriétés finales de relief de surface pour un [ThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/).

L'exemple de code suivant montre comment obtenir les propriétés effectives du biseau supérieur d'une forme. Il suppose que la première forme de la première diapositive possède un format 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtenir les propriétés effectives d'un cadre de texte**

En utilisant Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un cadre de texte. Les données effectives renvoyées par [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/geteffective/) contiennent les propriétés de formatage du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte. Il suppose que la première forme de la première diapositive est une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) avec un cadre de texte.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtenir les propriétés effectives d'un style de texte**

En utilisant Aspose.Slides, vous pouvez obtenir les propriétés effectives d'un style de texte. Les données effectives renvoyées par [TextStyle.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textstyle/geteffective/) contiennent les propriétés du style de texte.

L'exemple de code suivant montre comment obtenir les propriétés effectives du style de texte. Il suppose que la première forme de la première diapositive est une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) avec un cadre de texte.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Obtenir la valeur effective de la hauteur de police**

En utilisant Aspose.Slides, vous pouvez obtenir la hauteur de police effective. Le code suivant montre comment la hauteur de police effective d'une portion change après que des valeurs locales de hauteur de police ont été définies à différents niveaux de la structure de la présentation.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtenir le format de remplissage effectif d'un tableau**

En utilisant Aspose.Slides, vous pouvez obtenir le format de remplissage effectif pour différentes parties d'un tableau. Les données effectives renvoyées par les objets de format contiennent les propriétés de [FillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/). Le format de cellule a priorité supérieure à celui de ligne, le format de ligne a priorité supérieure à celui de colonne, et le format de colonne a priorité supérieure à celui de l'ensemble du tableau.

En conséquence, les propriétés effectives de [CellFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellformat/) sont utilisées pour dessiner la cellule du tableau. L'exemple de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties du tableau. Il suppose que la première forme de la première diapositive est un [Table](https://reference.aspose.com/slides/fr/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Le `getEffective` renvoie-t-il un instantané ?**

Pas toujours. Les données effectives représentent le format calculé après l'application de l'héritage, mais certains objets de données effectives peuvent être mis en cache en interne. Un appel subséquent à `getEffective` peut recalculer le format et actualiser le cache, de sorte qu'un objet obtenu précédemment ne doit pas être considéré comme un instantané durable.

**Quand dois-je relire les propriétés effectives ?**

Appelez `getEffective` à nouveau après avoir modifié le format local, les styles parents, le format de mise en page, le format maître ou les valeurs par défaut au niveau de la présentation. L'appel suivant réévalue la hiérarchie de formatage et renvoie le résultat effectif actuel.

**Le fait de modifier ou de supprimer une diapositive de mise en page/maître affecte-t-il les propriétés effectives déjà récupérées ?**

Oui, mais le changement ne se reflète qu'à l'appel suivant de `getEffective`. Si une source de formatage parent est modifiée ou supprimée, les données effectives précédemment obtenues peuvent être obsolètes. Dès que `getEffective` est rappelé, Aspose.Slides réévalue l'arbre de formatage et les polices, couleurs, tailles ou autres valeurs peuvent changer.

**Puis-je modifier les valeurs via les objets de données effectives ?**

Non. Les objets de données effectives exposent uniquement les valeurs calculées. Modifiez les objets de formatage locaux, puis obtenez de nouveau les valeurs effectives.

**Que se passe-t-il si une propriété n'est pas définie au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut, qui comprend les valeurs par défaut de PowerPoint et d'Aspose.Slides. Cette valeur résolue devient alors partie des données effectives en cours.

**À partir d'une valeur de police effective, puis-je déterminer quel niveau a fourni la taille ou la police ?**

Pas directement. Les données effectives renvoient la valeur finale. Pour identifier la source, examinez les valeurs locales au niveau de la portion, du paragraphe, du cadre de texte et des styles de texte aux niveaux de la mise en page, du maître et de la présentation afin de voir où apparaît la première définition explicite.

**Pourquoi les valeurs effectives ressemblent parfois aux valeurs locales ?**

Parce que la valeur locale s'est avérée finale (aucun héritage de niveau supérieur n'a été nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand dois‑je utiliser les propriétés effectives et quand ne travailler qu'avec les locales ?**

Utilisez les données effectives lorsque vous avez besoin du résultat « tel qu'affiché » après que toute l'héritance a été appliquée, par exemple pour aligner les couleurs, retraits ou tailles. Si vous devez conserver ces valeurs indépendamment des modifications de formatage ultérieures, copiez les propriétés requises dans votre propre objet. Si vous devez modifier le formatage à un niveau spécifique, ajustez les propriétés locales puis, si nécessaire, relisez les données effectives pour vérifier le résultat.