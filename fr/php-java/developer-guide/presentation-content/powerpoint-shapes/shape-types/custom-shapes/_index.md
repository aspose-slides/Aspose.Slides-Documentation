---
title: Personnaliser les formes de présentation en PHP
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/php-java/custom-shape/
keywords:
- forme personnalisée
- ajouter une forme
- créer une forme
- modifier une forme
- géométrie de forme
- chemin de géométrie
- points de chemin
- points d'édition
- ajouter un point
- supprimer un point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour PHP via Java : chemins de géométrie, coins arrondis, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie des formes via les points d'édition et les chemins de géométrie. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) pour modifier des formes existantes, effectuer des opérations de base d'édition de chemin, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins arrondis, déterminer si la géométrie d'une forme est fermée, inspecter les éléments de forme, et convertir les contours de texte Java AWT en chemins de géométrie.

## **Modifier une forme à l'aide de points d'édition**

* Deplacer un coin vers l'intérieur ou vers l'extérieur.
* Ajuster la courbure d'un point.
* Ajouter de nouveaux points.

La modification des points vous permet de modifier le contour d'une forme ou d'utiliser une forme existante comme base d'une nouvelle.

## **Conseils pour l'édition de formes**

![overview_image](custom_shape_0.png)

Lorsque vous modifiez des formes PowerPoint, gardez à l'esprit les concepts suivants:

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Le chemin d'une forme est composé de points d'ancrage reliés par des segments.
* Un segment peut être droit ou courbe. Les points d'ancrage et les poignées de contrôle déterminent sa forme.
* Les points d'ancrage existent sous forme de points d'angle, points droits ou points lisses:
  * Dans un point d'angle, les segments adjacents peuvent se rencontrer sous un angle.
  * Dans un point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d'ancrage.
  * Dans un point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d'ancrage.
* Deplacer les points d'ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour modifier les formes PowerPoint via les points d'édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) représente le chemin de géométrie de l'objet [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) depuis l'instance [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), vous pouvez utiliser la méthode [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) d'une forme, vous pouvez utiliser ces méthodes : [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) pour les formes à chemin unique et [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) pour les formes à plusieurs chemins.
* Pour ajouter des segments, vous pouvez utiliser les méthodes de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* En utilisant les méthodes [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) et [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), vous pouvez définir l'apparence d'un chemin de géométrie.
* En utilisant la méthode [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), vous pouvez récupérer le chemin de géométrie d'un [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.
* Pour accéder à d'autres options de personnalisation de la géométrie des formes, vous pouvez lire un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via son [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) et rejouer les segments sur un [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Opérations d'édition simples**

Utilisez les méthodes suivantes pour éditer un chemin de géométrie. Les surcharges qui acceptent un indice insèrent un segment à cette position basée sur zéro dans le tableau de segments du chemin.

| Operation | Method |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Ajouter ou insérer une courbe cubique de Bézier avec deux points de contrôle et un point final. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Ajouter ou insérer une courbe quadratique de Bézier avec un point de contrôle et un point final. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Ajouter un arc elliptique avec les dimensions et angles spécifiés en degrés. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Fermer la figure en connectant son point final à son point de départ. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Définir le point de départ d'une figure. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Supprimer un segment à un indice basé sur zéro. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire en utilisant [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) et applique le chemin modifié avec [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Les coordonnées sont locales à la forme: les deux nouveaux points sont au centre, à 100 points du côté gauche et 50 points du haut. Les indices de segment 1 et 4 les placent sur les bords supérieur et inférieur, tirant ces bords vers l'intérieur.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Supprimer des points d'une forme**

Cet exemple modifie le contour d'une forme en forme de cœur en supprimant le segment à l'indice basé sur zéro 2 avec [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Appliquer le chemin modifié avec [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) met à jour le contour de la forme.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

Cet exemple crée une étoile à cinq branches avec [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent les pointes et les encoches; un pas de 72 degrés espace les cinq pointes de façon égale. Le chemin est fermé avec [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) et appliqué à une forme rectangulaire à l'aide de [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), remplaçant son contour.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Créer une forme composite personnalisée**

Cet exemple définit deux [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) fermés pour le tiers supérieur et le tiers inférieur d'une forme. Appliquer les deux chemins avec [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) crée une forme composite unique avec un espace au milieu du tiers.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec coins incurvés**

Cet exemple combine des segments droits avec [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) pour créer une forme aux coins incurvés vers l'intérieur. Chaque taille de coin définit la largeur et la hauteur de l'arc en points, et le balayage de -90 degrés trace un quart d'ellipse dans le sens inverse des aiguilles d'une montre. Le chemin complet est appliqué avec [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), et la présentation est enregistrée au format PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Déterminer si la géométrie d'une forme est fermée**

L'assistant suivant vérifie si chaque chemin de géométrie non vide se termine par un segment de fermeture. Il lit [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) et compare la [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) du segment final avec [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Il renvoie false lorsqu'il n'y a aucun chemin non vide. Cette vérification examine la commande finale de chaque chemin; elle n'inspecte pas chaque sous-figure au sein d'un chemin. L'exemple imprime `true` pour un rectangle.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Extraire et inspecter les éléments de forme**

Utilisez [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) pour inspecter une forme existante sous forme d'éléments contenant les points de chemin et les types de points. Utilisez chaque [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) retourné pour récupérer les tableaux de points et de types via les méthodes [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) et [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Cette représentation est utile pour l'analyse du contour ou le passage de la géométrie à des outils de dessin personnalisés.

L'exemple ouvre input.pptx, trouve la première forme de géométrie directement sur la première diapositive, et imprime ses segments de chemin. Utilisez une présentation contenant une forme avec des segments droits et incurvés pour voir les deux types de sortie. Il ne recherche pas à l'intérieur des groupes.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Conserver le type de segment, en excluant les drapeaux.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consommer les deux points de contrôle et le point final.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Les tableaux correspondent par indice: `$points[$i]` est un point et `$types[$i]` décrit son rôle. Le type `0` démarre une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment Bézier cubique commence au point final précédent et utilise trois entrées de type `3` consécutives: deux points de contrôle suivis du nouveau point final. La boucle consomme ces trois entrées ensemble et vérifie le point final pour la fermeture.

Les types de point contiennent également des drapeaux. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` séparément pour détecter un sous-chemin fermé. Par exemple, `129` (`0x81`) signifie un point final de ligne qui ferme un sous-chemin, et `131` (`0x83`) signifie un point final de Bézier qui en ferme un. Le pont PHP/Java renvoie le tableau d'octets sous forme de chaîne binaire; le dés-emballage avec "C*" produit des valeurs d'octet non signées. Le masquage conserve les valeurs de bits prévues. Comparer la valeur brute uniquement avec `1` ou `3` manquerait ces cas. D'autres drapeaux, comme le tiret (`0x10`) et le marqueur (`0x20`), ne changent pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 pouce), X augmente vers la droite et Y augmente vers le bas. Pour une forme non groupée, les coordonnées extraites incluent déjà la position renvoyée par [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) et [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourné à `(100, 200)` avec une taille `120 × 80` a des limites de contour `(100, 200)-(220, 280)`. N'ajoutez pas de nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non tourné.

Les points extraits n'appliquent pas la rotation de la forme, renvoyée par [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), ni les retournements horizontaux et verticaux. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations; ne supposez pas que les points extraits sont les coordonnées finales rendues sur la diapositive ou appliquez une translation ou une échelle deux fois s'il est déjà reflété dans le cadre de l'enfant.

**Inspection versus édition.** Les tableaux extraits décrivent le contour; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre code d'analyse ou de dessin a besoin des tableaux point/type. Utilisez [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) quand vous avez besoin des commandes de géométrie dans le système de coordonnées local de la forme ou que vous souhaitez éditer sa géométrie. Appliquez les chemins modifiés via [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ou [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convertir une forme Java AWT en GeometryPath**

Cet exemple combine un contour rectangulaire avec du texte converti en géométrie. La méthode [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) du contour désactive son remplissage. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crée le contour du texte dans un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Son [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fournit des segments de déplacement, ligne, quadratique, cubique et de fermeture, que l'exemple rejoue sur un [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

L'exemple utilise un tableau float Java afin que le pont PHP/Java conserve les coordonnées écrites par l'itérateur. Le texte utilise une police Arial de 40 points. Le contour est décalé de 20 points horizontalement et positionné avec son haut visuel 10 points sous le bord supérieur de la forme. Le chemin du texte est rempli, tandis que le rectangle original reste un contour. Appliquer les deux chemins avec [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) produit une forme unique contenant le rectangle et le texte.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Que se passe-t-il pour le remplissage et le contour après avoir remplacé la géométrie?**

Le style reste avec la forme; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) de la forme; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre de la forme.

**Puis-je convertir une forme personnalisée en image pour "verrouiller" le résultat?**

Oui. Exportez la zone [slide](/slides/fr/php-java/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/php-java/create-shape-thumbnails/) elle-même vers un format raster; cela simplifie le travail ultérieur avec des géométries complexes.