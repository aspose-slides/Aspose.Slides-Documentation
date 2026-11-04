---
title: Formater les formes PowerPoint en PHP
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/php-java/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme esquisse
- format du style de jointure
- remplissage en dégradé
- remplissage en motif
- remplissage d’image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rendu en noir et blanc de forme
- rendu en niveaux de gris de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en PHP à l’aide d’Aspose.Slides—définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT et PPTX avec précision et contrôle total."
---
## **Introduction**

Formatez les formes dans PowerPoint en ajustant leurs contours, remplissages et effets. Aspose.Slides for PHP via Java vous permet de contrôler ces réglages par programme, y compris la transparence, la rotation et le formatage 3D.

![Shape formatting options in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java fournit des classes et des méthodes qui permettent de formater les formes en utilisant les mêmes options que dans PowerPoint.

## **Format Lines**

Utilisez [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) pour contrôler le contour d’une forme. Cet exemple crée un rectangle non rempli avec un contour bleu en pointillés. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) sélectionne une ligne composée épaisse‑fine, tandis que [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) définit sa largeur à 7 points et [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) choisit le motif de tirets.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The formatted lines in the presentation](formatted-lines.png)

### **Set Custom Line Dash Patterns**

Utilisez [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) lorsque les styles de ligne prédéfinis ne fournissent pas les longueurs de tirets et d’intervalles dont vous avez besoin, par exemple pour des contours de marque ou des diagrammes techniques. L’attribution d’un motif change automatiquement le style de tiret de ligne en [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Les entrées du tableau alternent entre longueurs de tiret et d’écart, en commençant par un tiret. Chaque valeur est un multiple de la largeur de ligne : `[4, 2]` avec une largeur de 3 points produit un tiret de 12 points suivi d’un intervalle de 6 points. Utilisez des paires de valeurs finies et non négatives pour définir des segments complets de tiret‑et‑intervalle. L’exemple utilise des valeurs positives pour que chaque tiret et intervalle soient visibles.

Cet exemple crée cinq lignes bleues de même longueur avec des extrémités plates. Les trois premières comparent les motifs à une largeur de 3 points. La quatrième répète le premier motif à deux fois la largeur, doublant ainsi les longueurs du tiret et de l’intervalle. La cinquième passe d’un motif personnalisé à une ligne pleine.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Retourner la dernière ligne à un style plein.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour revenir à un style de tiret prédéfini, passez [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) à [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Le style sélectionné contrôle l’apparence de la ligne.

Le résultat dans PowerPoint, de haut en bas : **{4, 2}, 3 pt** ; **{1, 2}, 3 pt** ; **{6, 2, 1, 2}, 3 pt** ; **{4, 2}, 6 pt** ; et **Solid, 3 pt**.

![Three custom dash patterns, a wider line using the first pattern, and a solid line in PowerPoint](custom-dash-patterns.png)

### **Set Line Caps**

Utilisez [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) pour définir les extrémités d’une ligne ouverte. La classe [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) propose trois styles de borne explicites :

- `Flat` : le tracé s’arrête au point final.
- `Round` : une borne semi‑circulaire dépasse le point final de la moitié de la largeur de ligne.
- `Square` : une borne carrée dépasse le point final de la moitié de la largeur de ligne.

La classe comprend également `NotDefined`, qui signifie qu’aucun style de borne n’est explicitement attribué.

Les capuchons sont différents des pointes de flèche, qui ajoutent des symboles aux extrémités de la ligne, et des jointures, qui contrôlent les coins entre les segments de ligne. Cet exemple désactive les pointes de flèche via [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) et [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) afin que seules les formes de capuchon soient comparées.

L’exemple suivant crée trois lignes horizontales autrement identiques, d’une largeur de 20 points. De haut en bas, elles utilisent respectivement les capuchons plat, rond et carré. Leurs points finaux partagent les mêmes coordonnées horizontales ; les capuchons rond et carré dépassent de 10 points chaque extrémité.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat dans PowerPoint, de haut en bas : **Flat**, **Round** et **Square**.

![Flat, round, and square caps on identical thick lines in PowerPoint](line-caps.png)

## **Apply Sketch Effects to Shape Lines**

Un effet de croquis donne à la ligne d’une forme un aspect dessiné à la main. Utilisez [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) pour accéder aux paramètres de ligne, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) pour accéder aux paramètres de croquis, et [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) pour sélectionner une valeur de la classe [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Le code PHP suivant montre comment appliquer un effet [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), lire la valeur explicitement attribuée et supprimer l’effet avec [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) :

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

La valeur renvoyée par [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) représente le réglage assigné directement à la forme. Si le formatage de la ligne peut être hérité d’un thème, d’une diapositive maître ou d’une diapositive de mise en page, utilisez [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), accédez à la méthode `getSketchFormat` de l’objet retourné, et lisez sa valeur `getSketchType`. La valeur effective reflète le formatage réellement appliqué après résolution de l’héritage. Cet exemple nécessite une présentation existante contenant au moins une forme sur la première diapositive et affiche les deux valeurs :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Format Join Styles**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Le style de jointure contrôle la façon dont deux segments de contour se rejoignent à un coin. Utilisez **Round** pour des coins arrondis, **Miter** pour des coins aigus, ou **Bevel** pour des coins aplatis.

![The join style in the presentation](join-style-powerpoint.png)

Cet exemple crée trois rectangles noirs avec des contours bleus de 15 points de large. Il définit [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) sur les valeurs miter, bevel et round de [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), respectivement, afin de comparer le rendu des coins.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Limit Miter Joins at Sharp Corners**

Utilisez [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) avec [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) réglé sur [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) pour limiter la distance à laquelle un coin aigu peut s’étendre.

La limite est le rapport entre la distance des coins interne et externe de la jointure et la largeur de ligne. Par exemple, une valeur de `8` autorise une longueur de pointe jusqu’à huit fois la largeur de ligne ; il ne s’agit pas d’une mesure en points. Si le coin devait dépasser cette limite, PowerPoint utilise une jointure biseautée à ce coin. Une limite plus grande permet des pointes plus aiguës. Ce réglage n’affecte que les jointures en pointe et ne produit aucun effet visible lorsque le coin reste dans les deux limites.

Cet exemple crée deux triangles non remplis identiques avec des contours de 20 points de large. Le triangle de gauche utilise une limite de `2`, et celui de droite `8`. Chaque triangle mesure 80 points de large et 160 points de haut, ce qui donne à son coin supérieur un rapport longueur‑de‑pointe‑à‑largeur de ligne d’environ `4,12`. Ainsi, PowerPoint biseaute l’apex gauche et conserve l’apex droit.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat dans PowerPoint : **Miter limit 2** à gauche et **miter limit 8** à droite.

![A beveled apex with miter limit 2 and a pointed apex with miter limit 8 in PowerPoint](miter-limits.png)

## **Gradient Fill**

Un remplissage en dégradé mélange des couleurs à travers une forme. Cet exemple remplit une ellipse avec un dégradé linéaire à 45 degrés du rouge au violet en utilisant [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). La méthode [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) place les arrêts de couleur aux positions 0 et 1, au début et à la fin du dégradé. Effacer les arrêts existants garantit que seules ces deux couleurs sont utilisées.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The ellipse with gradient fill](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choose a Gradient Rendering Style](/slides/fr/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le dégradé stocké dans la présentation.

### **Set the Linear Gradient Angle**

Utilisez [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) pour contrôler l’orientation d’un remplissage [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). L’angle est exprimé en degrés et augmente dans le sens des aiguilles d’une montre : `0` va de gauche à droite, `90` de haut en bas, `180` de droite à gauche, et `270` de bas en haut. Les angles fractionnaires sont pris en charge. Les angles finis en dehors de l’intervalle `[0, 360)` sont normalisés à une rotation complète ; par exemple, `-45` devient `315` et `360` devient `0`.

Cet exemple crée six rectangles avec des arrêts de couleur rouge, vert et bleu aux positions `0`, `0.5` et `1`. Le mode d’échelle est désactivé afin que l’angle puisse être comparé indépendamment des proportions des rectangles. Les angles, de gauche à droite, sont `0`, `45` et `90` dans la première rangée, et `135`, `180` et `270` dans la seconde.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat dans PowerPoint :

![Linear gradients at 0, 45, and 90 degrees in the top row, and 135, 180, and 270 degrees in the bottom row](linear-gradient-angles.png)

### **Scale a Linear Gradient with the Shape**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) accepte une valeur [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Réglez‑la explicitement sur `False` pour conserver l’angle géométrique du dégradé lorsque les proportions de la forme changent, ou sur `True` pour mettre à l’échelle le dégradé avec la largeur et la hauteur de la forme. Avec l’échelle activée, l’angle visible peut différer de l’angle assigné sur une forme non carrée.

L’exemple suivant utilise un angle de `45` degrés et les mêmes arrêts de couleur que pour la comparaison d’angles. La colonne de gauche utilise `False` ; la colonne de droite utilise `True`. Chaque colonne contient un rectangle large au-dessus d’un rectangle haut. Les deux commencent avec les mêmes dimensions larges ; modifier la largeur et la hauteur du second rectangle montre comment le remplissage réagit au redimensionnement sans changer les paramètres du dégradé.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat dans PowerPoint, avec l’échelle désactivée à gauche et activée à droite :

![Wide and tall rectangles with a 45-degree gradient, comparing LinearGradientScaled False on the left with True on the right](linear-gradient-scaling.png)

Avec l’échelle désactivée, les bandes de couleur diagonales conservent la même orientation dans les deux rectangles. Avec l’échelle activée, les bandes s’étirent avec les proportions de la forme. Cela permet de reproduire le dégradé d’un modèle lorsqu’on adapte une forme à une taille différente. Sur un carré, activer l’échelle ne modifie pas l’apparence de ce dégradé à `45` degrés.

Les réglages d’angle et d’échelle s’appliquent aux dégradés linéaires. Ils ne contrôlent pas les remplissages [GradientShape::Radial ou GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Combine the Angle with Gradient Direction**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) sélectionne un style de dégradé parmi la classe [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); ce n’est pas un substitut à un angle numérique. Pour un dégradé linéaire, les styles de coin peuvent modifier la zone de répartition des couleurs sans changer l’angle assigné via [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Conservez la direction inchangée lors de la comparaison des angles ou de l’échelle.

L’exemple suivant applique les mêmes réglages dans des ordres opposés. Les deux rectangles ont la même apparence : assigner la direction avant ou après l’angle ne change pas le résultat.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Pattern Fill**

Un remplissage de motif applique un dessin bicolore, tel que des points, des bandes ou des carreaux. Cet exemple utilise [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) pour sélectionner un motif treillis. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) fournit le fond gris clair, et [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) fournit la couleur jaune du motif.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

Un remplissage d’image utilise une image à l’intérieur d’une forme. Cet exemple nécessite une image locale et utilise [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) pour la charger dans la collection d’images de la présentation. Le réglage de [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) sur le mode mosaïque répète l’image à l’intérieur du rectangle. L’image source utilisée ici est affichée ci‑dessous :

![The lotus picture](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les méthodes suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) : définit le mode de remplissage d’image – soit `Tile` soit `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment) : spécifie l’alignement des tuiles dans la forme.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip) : contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX) : définit le décalage horizontal de la tuile (en points) depuis l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY) : définit le décalage vertical de la tuile (en points) depuis l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX) : définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY) : définit l’échelle verticale de la tuile en pourcentage.

Cet exemple nécessite une image locale et configure [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) pour la répéter à 50 % de sa taille d’origine. Des décalages de −32 points déplacent les tuiles horizontalement et verticalement ; l’alignement en bas à droite et le retournement dans les deux directions déterminent l’arrangement de la texture répétée.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The tile options](tile-options.png)

## **Solid Color Fill**

Un remplissage uni donne à une forme une couleur unique et uniforme. Cet exemple définit [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) sur le mode de remplissage plein et attribue le jaune via [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), puis enregistre le rectangle dans une présentation.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The shape with solid color fill](solid-color-fill.png)

## **Use the Slide Background as a Shape Fill**

Utilisez [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) lorsqu’une forme doit correspondre à l’arrière‑plan de la diapositive, par exemple dans un modèle de présentation. Définissez d’abord [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) sur [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) pour supprimer tout remplissage explicite. Avec cette combinaison, la forme utilise l’arrière‑plan de la diapositive au lieu de son propre style de remplissage. Activer simplement le drapeau ne supprime pas un remplissage explicite existant.

Cela diffère de [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) : le remplissage d’arrière‑plan couvre les objets derrière la forme avec la zone correspondante de l’arrière‑plan de la diapositive, tandis que « No Fill » laisse ces objets visibles. Un dégradé reste aligné avec la diapositive plutôt que de redémarrer à l’intérieur de chaque forme.

L’exemple suivant crée un arrière‑plan maître hérité par la diapositive et place une bande magenta derrière trois rectangles. Le rectangle de gauche utilise l’arrière‑plan, le rectangle du milieu n’a aucun remplissage, et le rectangle de droite passe du remplissage d’arrière‑plan à un remplissage orange explicite.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Hériter du dégradé du maître.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Ajouter cet objet en premier afin qu’il apparaisse derrière les rectangles.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Désactiver le remplissage d’arrière‑plan avant d’appliquer un remplissage explicite.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat, de gauche à droite : **background fill**, **no fill** et **explicit fill**. La bande magenta est masquée par les rectangles gauche et droit mais reste visible à travers le rectangle du milieu.

![Background fill, no fill, and explicit orange fill over a magenta band](background-fill.png)

Le même comportement s’applique à un arrière‑plan défini directement sur la diapositive ou hérité d’une mise en page. La forme utilise l’arrière‑plan résolu de la diapositive ; l’exemple laisse les arrière‑plans de la diapositive et de la mise en page indéfinis afin que le maître le fournisse.

## **Set Transparency**

Pour un remplissage plein, le composant alpha de la couleur contrôle l’opacité : 0 est totalement transparent et 255 totalement opaque. Cet exemple utilise une valeur alpha de 128 pour un rectangle jaune, le rendant approximativement à 50 % transparent afin que le rectangle en dessous reste visible. La couleur est attribuée via [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The transparent shape](shape-transparency.png)

## **Rotate Shapes**

Utilisez [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) pour faire pivoter une forme dans le plan de la diapositive. L’angle est mesuré en degrés ; cet exemple tourne un rectangle de 5 degrés dans le sens des aiguilles d’une montre et enregistre la présentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The shape rotation](shape-rotation.png)

## **Add 3D Bevel Effects**

Utilisez [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) pour donner de la profondeur à une forme et des arêtes biseautées. Cet exemple crée une ellipse verte avec un contour orange, définit [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) à 4 points, et applique un biseau supérieur circulaire d’une largeur et hauteur de 6 points via [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Une caméra orthographique frontale et un éclairage à trois points rendent le biseau visible.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The 3D bevel effect](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

La vue 3D d’une forme est contrôlée par les réglages de sa caméra. Cet exemple utilise [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) avec des angles de latitude, longitude et révolution de 40, 35 et 20 degrés, respectivement. Il sélectionne une caméra isométrique via [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) et un éclairage équilibré via [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), puis enregistre le rectangle formaté.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![The 3D rotation effect](3D-rotation-effect.png)

## **Control Black-and-White Rendering for Shapes**

La méthode [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage noir et blanc en soi, et ne modifie pas le remplissage, le contour ou tout autre formatage de la forme en mode couleur normal.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent une coloration grise, `BlackWhite` n’utilise que le noir et le blanc, `Black` et `White` imposent une couleur unique, `Color` préserve la coloration normale, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode de niveau forme n’est attribué.

Cet exemple crée un rectangle orange et définit [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) sur gris. La forme enregistrée conserve son remplissage orange pour l’affichage couleur normal et demande une coloration gris aux applications qui honorent les paramètres d’affichage noir et blanc :

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

En mode couleur normal, le rectangle conserve son remplissage orange. Dans un flux de travail d’affichage noir et blanc, il utilise la coloration grise parce que son mode est réglé sur `Gray`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, la prévisualisation ou d’autres flux qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Reset Formatting**

Utilisez [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) pour restaurer la position, la taille et le formatage des espaces réservés de diapositive à partir de leurs espaces réservés correspondants de la mise en page. Cet exemple nécessite une présentation existante avec des espaces réservés liés à la mise en page et rétablit chaque diapositive avant l’enregistrement. Les formes sans espaces réservés correspondants dans la mise en page ne sont pas réinitialisées.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Does shape formatting affect the final presentation file size?**

Les couleurs, styles de ligne et paramètres d’effet ajoutent généralement peu de données comparés aux images et médias intégrés. Les remplissages d’image peuvent augmenter la taille du fichier car leurs images sont stockées dans la présentation.

**How can I detect shapes on a slide that share identical formatting so I can group them?**

Comparez les propriétés de formatage clés de chaque forme : remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Can I save a set of custom shape styles to a separate file for reuse in other presentations?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un jeu de diapositives de modèle ou un fichier de modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage partout où cela est requis.