---
title: Gérer les formes de présentation en PHP
linktitle: Manipulation des formes
type: docs
weight: 40
url: /fr/php-java/shape-manipulations/
keywords:
- Forme PowerPoint
- Forme de présentation
- Forme sur diapositive
- Trouver forme
- Cloner forme
- Supprimer forme
- Masquer forme
- Modifier l'ordre des formes
- Obtenir l'ID de forme interop
- Texte alternatif de forme
- Point d'ajustement de forme
- Ajustement de forme prédéfini
- Géométrie de forme
- Formats de mise en page de forme
- Forme en SVG
- Forme vers SVG
- Aligner forme
- Retourner forme
- PowerPoint
- Présentation
- PHP
- Aspose.Slides
description: "Apprenez à identifier, ajuster, cloner, supprimer, masquer, réorganiser, exporter, aligner et retourner les formes de présentation avec Aspose.Slides pour PHP via Java."
---
## **Aperçu**

Aspose.Slides for PHP via Java représente les formes sur une diapositive comme une [ShapeCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/) ordonnée. La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d’empilement : l’index `0` correspond à la forme la plus en arrière, tandis que le dernier index correspond à la forme la plus en avant.

Cet article suit ce modèle. Il explique d’abord comment identifier une forme de manière fiable et modifier les points d’ajustement préconfigurés, puis montre comment cloner, supprimer, masquer et réorganiser les formes. Les sections finales couvrent le formatage au niveau de la disposition, l’exportation SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, de sorte que vous pouvez n’utiliser que les opérations requises par votre flux de travail.

## **Identifier et Trouver les Formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réorganiser une forme peut changer son index. Choisissez un identifiant en fonction de la façon dont la présentation est créée et maintenue :

- **[Name](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getname/)** est utile pour les modèles contrôlés par les développeurs et est facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis uniques, il faut donc établir une convention de nommage si le code en dépend.
- **[AlternativeText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getalternativetext/)** est utile lorsqu’une description d’accessibilité ou une étiquette fournie par l’auteur identifie déjà la forme. Elle est visible des utilisateurs, peut être localisée ou réécrite pour l’accessibilité, et n’est pas garantie unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- **[OfficeInteropShapeId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getofficeinteropshapeid/)** est un identifiant en lecture seule qui est unique au sein d’une diapositive et correspond à l’ID de forme utilisé par l’interop PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou lorsque vous avez besoin d’une référence sans ambiguïté pendant la durée de vie d’une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La méthode connexe **[Shape::getUniqueId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getuniqueid/)** renvoie un identifiant à portée de présentation, mais cet identifiant est destiné aux compléments et peut être réaffecté. Il ne doit pas être considéré comme une clé externe permanente. Si une identité à long terme est essentielle, conservez la correspondance dans les données de l’application et vérifiez que la forme attendue existe toujours.

L’exemple suivant recherche par nom avec une comparaison exacte et rapporte l’ID d’interop à portée de diapositive. Lorsque le modèle ne contient pas la forme attendue, le code indique ce résultat au lieu de continuer avec le mauvais objet.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Lorsqu’une opération est spécifique à un type de forme, vérifiez la classe d’exécution avant d’utiliser des membres spécifiques au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un **[AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/)**.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Identifier et Modifier les Ajustements de Formes Préconfigurés**

Les formes à géométrie préconfigurée peuvent exposer des points d’ajustement qui contrôlent des propriétés telles que la taille des coins, les proportions des flèches ou les angles d’arcs. Accédez‑y via la collection en lecture seule **[GeometryShape::getAdjustments](https://reference.aspose.com/slides/fr/php-java/aspose.slides/geometryshape/#getAdjustments)**. La collection elle‑même est fournie par la forme, mais chaque **[AdjustValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/adjustvalue/)** contient une valeur qui peut être modifiée.

Ne vous fiez pas uniquement à un index de collection fixe. Parcourez les ajustements et inspectez la méthode en lecture seule **[AdjustValue::getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/adjustvalue/#getType)**, dont la valeur **[ShapeAdjustmentType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapeadjustmenttype/)** décrit ce que contrôle l’ajustement. La méthode en lecture seule **[AdjustValue::getName](https://reference.aspose.com/slides/fr/php-java/aspose.slides/adjustvalue/getname/)** fournit des informations d’identification supplémentaires et est particulièrement utile lorsqu’un préconfiguré contient plusieurs ajustements du même type sémantique.

Utilisez la méthode de valeur qui correspond à la signification de l’ajustement :

| Type d’ajustement | Objectif | Valeur à modifier |
|---|---|---|
| `CornerSize` | Taille des coins arrondis | [setRawValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Épaisseur de la queue d’une flèche | `setRawValue` |
| `ArrowheadLength` | Longueur d’une pointe de flèche | `setRawValue` |
| `ArrowheadWidth` | Largeur d’une pointe de flèche | `setRawValue` |
| `StartAngle` | Angle de départ d’un secteur ou d’un arc | [setAngleValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Angle de fin d’un secteur ou d’un arc | `setAngleValue` |

`getType` et `getName` renvoient des informations en lecture seule. `getRawValue` et `setRawValue` travaillent avec un entier dans les unités géométriques natives du préconfiguré, tandis que `getAngleValue` et `setAngleValue` travaillent avec un angle en degrés. Le nombre, l’ordre, la signification et la plage valide des ajustements dépendent du préconfiguré **[GeometryShape::getShapeType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/geometryshape/#getShapeType)**. Une valeur valide pour un préconfiguré peut être invalide ou avoir un effet différent pour un autre.

Lorsque `getType` renvoie **`ShapeAdjustmentType::Custom`**, l’API ne reconnaît pas de signification sémantique standard. Inspectez `getName`, le type du préconfiguré et la valeur existante, et laissez l’ajustement inchangé sauf si la signification et la plage attendues sont connues. Même pour les types reconnus, vérifiez si le même type apparaît plusieurs fois avant de choisir une valeur. L’article **[Connector](/slides/fr/php-java/connector/)** montre cette situation avec les ajustements de courbure des connecteurs.

L’exemple complet suivant crée des versions par défaut et modifiées de trois formes préconfigurées. Il parcourt chaque ajustement, rapporte son nom et son type, modifie les valeurs liées à la taille via `setRawValue`, modifie les angles via `setAngleValue`, puis enregistre le résultat. La colonne de gauche conserve la géométrie par défaut ; la colonne de droite montre le rectangle arrondi, la flèche à quatre pointes et le secteur ajustés.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter des en-têtes pour les colonnes des formes par défaut et ajustées.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Vérifier le type sémantique avant de changer une valeur rend le code explicite quant à son intention et évite de supposer qu’un index de collection particulier a la même signification entre différents préconfigurés.

## **Modifier la Collection de Formes**

Les méthodes d’ajout, de clonage, de suppression et de réorganisation agissent immédiatement sur la collection. Si une opération modifie le nombre ou l’ordre des formes, ne continuez pas à vous fier à des index capturés avant cette opération.

### **Cloner une Forme**

**[ShapeCollection::addClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addclone/)** crée une copie indépendante et l’ajoute à la fin de la collection cible. **[ShapeCollection::insertClone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/insertclone/)** crée également une copie mais la place à un index de z‑order spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent le redimensionner également.

L’exemple crée une diapositive de destination, clone un rectangle étiqueté vers l’avant, et insère un second clone à l’arrière. Les modifications apportées à l’un ou l’autre clone ne modifient pas la forme source.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le clonage copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Assignez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des Formes**

**[ShapeCollection::remove](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/remove/)** supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection à l’envers afin que chaque index restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit la forme à l’index courant, pas un élément de collection fixe, et il ne cast pas la forme inutilement.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que les index enregistrés. Pensez également aux connecteurs, aux animations et à d’autres fonctions de la présentation qui peuvent référencer l’objet supprimé ; la suppression d’une forme visible peut modifier plus que l’aspect de la diapositive.

### **Masquer une Forme**

Définir **[Shape::setHidden](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/sethidden/)** à `true` garde la forme dans la collection mais empêche son affichage lors du diaporama normal. Son index, son formatage et son contenu restent accessibles au code, de sorte que masquer convient aux éléments optionnels pouvant être restaurés ultérieurement.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Masquer n’est pas une suppression ni une mesure de sécurité. L’objet peut toujours être découvert et rendu visible à nouveau par un utilisateur ou par du code, et il demeure partie du fichier de présentation.

### **Modifier l’Ordre Z**

Les formes qui se chevauchent sont peintes dans l’ordre de la collection. **[ShapeCollection::reorder](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/reorder/)** déplace une forme existante vers un index cible sans la cloner. L’index `0` est l’arrière ; `size() - 1` est l’avant.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le rectangle est créé en premier et se trouve initialement derrière l’ellipse. Le déplacer vers l’index final le place devant. Finalisez l’ordre Z après avoir ajouté ou cloné toutes les formes concernées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Inspecter les Formes sur les Diapositives de Disposition**

Les diapositives normales, les diapositives de disposition et les diapositives maîtres possèdent des collections de formes distinctes. Une forme dans une collection de disposition n’est pas le même objet qu’une forme positionnée de manière similaire sur une diapositive normale. Inspectez les formes de disposition lorsque vous devez comprendre ou modifier le formatage fourni par une disposition.

L’exemple suivant lit le **[FillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getfillformat/)** et le **[LineFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/getlineformat/)** de chaque forme de disposition sans supposer que chaque forme est une `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Modifier une disposition peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de disposition, déterminez si une diapositive normale hérite de l’objet ou contient une substitution locale, et testez chaque diapositive qui utilise cette disposition.

## **Exporter une Forme au Format SVG**

**[Shape::writeAsSvg](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/writeassvg/)** écrit le contenu rendu d’une forme dans un flux. Le résultat contient la forme, pas l’arrière‑plan complet de la diapositive ni les formes adjacentes.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme et des ressources telles que les polices et les images. Si vous avez besoin de la composition entière, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le fermer.

## **Aligner des Formes**

Les surcharges de **[SlideUtil::alignShapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/alignshapes/)** alignent soit toutes les formes, soit des index de collection sélectionnés. **[ShapesAlignmentType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapesalignmenttype/)** spécifie le bord, la ligne centrale ou le mode de distribution. Définissez `alignToSlide` à `true` pour s’appuyer sur les bords de la diapositive ; à `false` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Les références aux formes retournées sont converties en leurs index actuels immédiatement avant l’alignement.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L’alignement modifie les positions, pas l’ordre Z. L’alignement relatif nécessite normalement au moins deux formes, tandis que la distribution horizontale ou verticale requiert suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retourner une Forme**

La classe **[ShapeFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapeframe/)** stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `getFlipH` et `getFlipV` utilisent **[NullableBool](https://reference.aspose.com/slides/fr/php-java/aspose.slides/nullablebool/)** : `True` active le retournement, `False` le désactive, et `NotDefined` préserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![La forme avant retournement](shape_to_be_flipped.png)

L’exemple préserve chaque autre valeur du cadre et ne remplace que les deux paramètres de retournement. C’est important car l’attribution d’un nouveau **[Frame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/setframe/)** remplace le cadre complet.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La forme enregistrée est miroir horizontalement et verticalement tout en conservant sa position, sa taille et sa rotation.

![La forme après retournement](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Seulement pour un traitement de courte durée lorsque la collection ne changera pas avant l’utilisation de l’index. Privilégiez une convention validée `Name` ou `AlternativeText` pour les modèles créés, ou `OfficeInteropShapeId` pour le travail d’interop à portée de diapositive.

**Le masquage d’une forme la retire‑t‑il de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être trouvée, réordonnée, modifiée ou rendue visible à nouveau.

**Pourquoi une forme clonée apparaît‑elle devant une autre forme ?**

`addClone` ajoute le clone à la fin de la collection, qui correspond à l’avant de l’ordre Z. Utilisez `insertClone` pour choisir l’index initial ou `reorder` après avoir ajouté toutes les formes.

**Puis‑je utiliser un index fixe pour identifier un ajustement de forme préconfiguré ?**

Seulement après avoir validé le préconfiguré exact et la disposition de la collection. Privilégiez l’itération via `GeometryShape::getAdjustments` et la vérification de `AdjustValue::getType` ; utilisez `AdjustValue::getName` comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.