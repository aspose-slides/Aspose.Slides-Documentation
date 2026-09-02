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
- forme chanfreinée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à utiliser Aspose.Slides for PHP via Java pour distinguer la mise en forme locale, héritée et effective des formes dans les présentations PowerPoint."
---
## **Comprendre les propriétés locales, héritées et effectives**

La mise en forme PowerPoint peut provenir de plusieurs sources. La valeur stockée directement sur un objet est sa **valeur locale**. Si cette valeur n'est pas définie, PowerPoint examine les sources de mise en forme parentes, comme le paramètre par défaut d'un paragraphe, un style de texte, une disposition ou une diapositive maître, un thème ou les paramètres par défaut au niveau de la présentation. Ces valeurs sont des **valeurs héritées**. La valeur qui reste après la résolution de toute la hiérarchie est la **valeur effective** – la valeur utilisée pour rendre l'objet.

Par exemple, une portion de texte peut ne pas définir sa propre hauteur de police. Sa valeur locale [getFontHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/) est alors `NAN`, ce qui signifie « non définie ici ». La portion peut hériter d'une hauteur provenant de son paragraphe, du style de texte par défaut de la présentation, ou d'une autre source applicable. Appeler [getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/geteffective/) sur le format de la portion renvoie la hauteur résolue finale.

Utilisez les deux types de données de mise en forme à des fins différentes :

- Lire ou modifier un objet de format local, tel que [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/), lorsque vous devez contrôler où une valeur est définie.
- Lire un objet de données effectives, tel que les [données renvoyées par PortionFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/geteffective/), lorsque vous avez besoin du résultat final rendu. Les données effectives sont en lecture seule.

Avant d'exécuter les exemples, [installez Aspose.Slides for PHP via Java](/slides/fr/php-java/installation/).

## **Comparer les valeurs locales, héritées et effectives**

L'exemple complet suivant crée une forme et applique des hauteurs de police aux niveaux de la présentation, du paragraphe et de la portion. Chaque étape affiche les valeurs définies à ces niveaux ainsi que la valeur effective résultante pour la même portion de texte. Il montre également pourquoi les données effectives doivent être relues après des modifications de mise en forme.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Lire les données effectives après les modifications précédentes.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Définir les valeurs héritées à deux niveaux différents.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Une valeur locale sur la portion remplace les deux valeurs héritées.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Modifier une valeur héritée ne remplace pas une valeur locale existante.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Effacer la valeur locale. La portion hérite maintenant du paragraphe à nouveau.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Effacer la valeur du paragraphe. Le paramètre par défaut de la présentation fournit maintenant le résultat.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La priorité dans cet exemple est la mise en forme locale de la portion, puis la mise en forme du paragraphe, puis le paramètre par défaut de la présentation. D'autres objets peuvent avoir des chaînes d'héritage différentes, mais le principe est le même : une valeur explicite plus spécifique l'emporte, et [getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/geteffective/) renvoie le résultat final.

## **Obtenir les propriétés de texte effectives**

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/geteffective/) résout les propriétés du cadre de texte telles que les marges, l'ancrage, le redimensionnement automatique et la direction du texte vertical.
- [TextStyle.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textstyle/geteffective/) résout la mise en forme des paragraphes pour chaque niveau de style de texte.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/geteffective/) résout les propriétés des paragraphes telles que l'alignement, l'indentation et les puces.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/geteffective/) résout les propriétés des caractères telles que la hauteur de police, la police, la couleur, le gras et l'italique.

Pour l'exemple suivant, `text-formatting.pptx` doit contenir au moins une diapositive et une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) avec un cadre de texte non vide. L'AutoShape peut se trouver à n'importe quelle position dans la collection de formes ; le code recherche un objet approprié et le valide avant utilisation.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Obtenir les propriétés 3D effectives**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/) renvoie un objet de données effectives qui regroupe tous les paramètres 3D résolus. Ses méthodes [getCamera](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/) et [getBevelBottom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/geteffective/) exposent les données effectives correspondantes. Lire ces paramètres associés ensemble facilite la compréhension de l'apparence 3D finale d'une forme.

Pour cet exemple, `shape-3d.pptx` doit contenir au moins une forme sur sa première diapositive. Appliquez des paramètres de caméra 3D, d'éclairage ou de chanfrein à cette forme si vous souhaitez que la sortie contienne des valeurs autres que les valeurs par défaut.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtenir le format de tableau effectif**

La mise en forme d'un tableau peut provenir du style de tableau et des formats appliqués à l'ensemble du tableau, à une colonne, à une ligne ou à une cellule individuelle. En cas de conflits entre les remplissages explicitement définis, la priorité est cellule, ligne, colonne, puis tableau complet. Le format effectif d'une cellule est le format final utilisé pour dessiner cette cellule.

Pour cet exemple, `table-formatting.pptx` doit contenir au moins un tableau sur sa première diapositive. Le tableau doit comporter au moins une ligne et une colonne. Le code recherche une [Table](https://reference.aspose.com/slides/fr/php-java/aspose.slides/table/) au lieu de supposer que `getShapes()->get_Item(0)` est un tableau.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Si vous avez besoin de la couleur plutôt que seulement du type de remplissage, vérifiez d'abord la valeur effective de [getFillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/geteffective/) , puis lisez la méthode correspondant à ce type—par exemple, [getSolidFillColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fillformat/geteffective/) pour un remplissage plein.

## **Relire les données effectives après des modifications**

Les données effectives décrivent la hiérarchie de mise en forme au moment où elles sont résolues. Appelez `getEffective` à nouveau après avoir modifié quoi que ce soit pouvant participer à cette hiérarchie, notamment :

- la mise en forme locale de l'objet ;
- les paramètres par défaut du paragraphe ou du cadre de texte ;
- un style de tableau, un tableau, une colonne, une ligne ou un format de cellule ;
- la mise en forme de la disposition ou de la diapositive maître ;
- les données de thème ou les paramètres par défaut au niveau de la présentation ;
- la disposition ou le maître assigné à une diapositive.

Ne conservez pas un objet de données effectives comme une capture d'écran permanente. Aspose.Slides peut mettre en cache certaines données effectives en interne, et un appel ultérieur à `getEffective` peut rafraîchir ces données. Si vous devez comparer les valeurs avant et après une modification, copiez les valeurs scalaires dont vous avez besoin—par exemple, une hauteur de police, une couleur, un alignement ou une largeur de chanfrein—dans vos propres variables avant d'effectuer la modification.

Pour modifier une valeur, mettez à jour l'objet de format local approprié puis appelez `getEffective` pour vérifier le résultat. Les objets de données effectives eux‑mêmes sont en lecture seule.

## **FAQ**

**Comment savoir quel niveau a fourni une valeur effective ?**

Les données effectives contiennent la valeur finale, pas sa source. Inspectez les objets locaux applicables du niveau le plus spécifique vers l'extérieur. Pour le texte, cela peut inclure la portion, le paragraphe, le cadre de texte, la disposition, le maître, le thème et les paramètres par défaut de la présentation. Les valeurs non définies telles que `NAN` ou `null` indiquent que la recherche continue à un autre niveau.

**Que se passe-t-il lorsqu'aucun niveau ne définit une propriété ?**

Aspose.Slides résout la valeur par défaut appropriée de PowerPoint ou de la bibliothèque. Cette valeur résolue apparaît dans les données effectives même si aucun objet local ne la définit explicitement.

**Pourquoi une valeur effective correspond parfois à la valeur locale ?**

La valeur locale a remporté le calcul d'héritage. Ceci est attendu lorsque la propriété est explicitement définie sur l'objet et qu'aucune règle plus spécifique ne la surcharge.

**Quand dois‑je utiliser les données locales au lieu des données effectives ?**

Utilisez les données locales pour inspecter ou modifier un niveau de mise en forme spécifique. Utilisez les données effectives lorsque vous avez besoin de l'apparence finale après l'héritage, les règles de thème et les styles applicables ont été résolus. L'[exemple complet de comparaison](#compare-local-inherited-and-effective-values) montre les deux dans le même flux de travail.