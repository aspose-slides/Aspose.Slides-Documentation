---
title: Gérer les formes de présentation en JavaScript
linktitle: Manipulation de formes
type: docs
weight: 40
url: /fr/nodejs-java/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- rechercher forme
- dupliquer forme
- supprimer forme
- masquer forme
- changer l'ordre des formes
- obtenir l'ID de forme interop
- texte alternatif de forme
- point d'ajustement de forme
- ajustement de forme prédéfini
- géométrie de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner forme
- retourner forme
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment identifier, ajuster, dupliquer, supprimer, masquer, réorganiser, exporter, aligner et retourner les formes de présentation avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java représente les formes d’une diapositive comme une [ShapeCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/) ordonnée. La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d’empilement : l’indice `0` correspond à la forme la plus en arrière, tandis que le dernier indice correspond à la forme la plus en avant.

Cet article suit ce modèle. Il explique d’abord comment identifier une forme de manière fiable et modifier les points d’ajustement prédéfinis, puis montre comment dupliquer, supprimer, masquer et réordonner les formes. Les sections finales couvrent le formatage au niveau de la mise en page, l’export SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, de sorte que vous ne puissiez utiliser que les opérations dont votre flux de travail a besoin.

## **Identifier et trouver des formes**

Les indices de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réordonner une forme peut modifier son indice. Choisissez un identifiant selon la façon dont la présentation est créée et maintenue :

- [Name](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getname/) est utile pour les modèles contrôlés par le développeur et facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis d’être uniques, donc établissez une convention de nommage si le code en dépend.
- [AlternativeText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getalternativetext/) est utile lorsqu’une description d’accessibilité ou une étiquette fournie par l’auteur identifie déjà la forme. Elle est visible pour les utilisateurs, peut être localisée ou réécrite pour l’accessibilité, et n’est pas garantie d’être unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) est un identifiant en lecture seule unique au sein d’une diapositive et correspond à l’ID de forme utilisé par l’interopérabilité PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou lorsque vous avez besoin d’une référence non ambiguë pendant la durée de vie d’une forme. Une forme dupliquée ou recréée est une forme différente et reçoit son propre ID.

La méthode liée [getUniqueId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getuniqueid/) renvoie un identifiant à portée de présentation, mais cet identifiant est destiné aux compléments et peut être réassigné. Il ne doit pas être considéré comme une clé externe permanente. Si une identité à long terme est essentielle, conservez le mappage dans les données de l’application et validez que la forme attendue existe toujours.

L’exemple suivant recherche par nom avec une comparaison exacte et indique l’ID d’interopérabilité scoped à la diapositive. Lorsque le modèle ne contient pas la forme attendue, le code signale ce résultat au lieu de poursuivre avec le mauvais objet.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Lorsqu’une opération est spécifique à un type de forme, vérifiez la classe d’exécution avant d’utiliser des membres propres au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identifier et modifier les ajustements de forme prédéfinis**

Les formes à géométrie prédéfinie peuvent exposer des points d’ajustement qui contrôlent des caractéristiques telles que la taille des coins, les proportions des flèches ou les angles d’arc. Accédez‑y via la collection en lecture seule [GeometryShape.getAdjustments](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/geometryshape/). La collection elle‑même est fournie par la forme, mais chaque [AdjustValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/) contient une valeur qui peut être modifiée.

Ne vous fiez pas uniquement à un indice de collection fixe. Parcourez les ajustements et inspectez la méthode en lecture seule [getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/) dont la valeur [ShapeAdjustmentType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapeadjustmenttype/) décrit ce que contrôle l’ajustement. La méthode en lecture seule [getName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/getname/) fournit des informations d’identification supplémentaires et est particulièrement utile lorsqu’un préréglage contient plusieurs ajustements du même type sémantique.

Utilisez la méthode de valeur correspondant à la signification de l’ajustement :

| Type d'ajustement | Objectif | Valeur à modifier |
|---|---|---|
| `CornerSize` | Taille des coins arrondis | [setRawValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Épaisseur de la queue d’une flèche | `setRawValue` |
| `ArrowheadLength` | Longueur d’une pointe de flèche | `setRawValue` |
| `ArrowheadWidth` | Largeur d’une pointe de flèche | `setRawValue` |
| `StartAngle` | Angle de départ d’une part ou d’un arc | [setAngleValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Angle de fin d’une part ou d’un arc | `setAngleValue` |

`getType` et `getName` renvoient des informations en lecture seule. `getRawValue` et `setRawValue` travaillent avec un entier dans les unités géométriques natives du préréglage, tandis que `getAngleValue` et `setAngleValue` travaillent avec un angle en degrés. Le nombre, l’ordre, la signification et la plage valide des ajustements dépendent du préréglage [GeometryShape.getShapeType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/geometryshape/). Une valeur valable pour un préréglage peut être invalide ou avoir un effet différent pour un autre.

Lorsque `getType` renvoie `ShapeAdjustmentType.Custom`, l’API ne reconnaît pas de signification sémantique standard. Inspectez `getName`, le type de préréglage et la valeur existante, et laissez l’ajustement inchangé à moins que la signification et la plage attendues soient connues. Même pour les types reconnus, vérifiez si le même type apparaît plusieurs fois avant de choisir une valeur. L’article [Connector](/slides/fr/nodejs-java/connector/) montre cette situation avec les ajustements de courbure des connecteurs.

L’exemple complet suivant crée des versions par défaut et modifiées de trois formes prédéfinies. Il parcourt chaque ajustement, indique son nom et son type, modifie les valeurs liées à la taille via `setRawValue`, modifie les angles via `setAngleValue` et enregistre le résultat. La colonne de gauche conserve la géométrie par défaut ; la colonne de droite montre le rectangle arrondi, la flèche à quatre pointes et la part ajustés.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Ajoute des en-têtes pour les colonnes de formes par défaut et ajustées.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vérifier le type sémantique avant de changer une valeur rend le code explicite quant à son intention et évite de supposer qu’un indice de collection particulier a la même signification entre différents préréglages de forme.

## **Modifier la collection de formes**

Les méthodes d’ajout, de duplication, de suppression et de réordonnancement agissent immédiatement sur la collection. Si une opération modifie le nombre ou l’ordre des formes, ne continuez pas à vous fier aux indices capturés avant cette opération.

### **Dupliquer une forme**

[addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/addclone/) crée une copie indépendante et l’ajoute à la collection cible. [insertClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/insertclone/) crée également une copie mais la place à un indice d’ordre z spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent le redimensionner également.

L’exemple crée une diapositive de destination, duplique un rectangle étiqueté en avant‑plan, et insère un second clone à l’arrière. Les modifications de l’un ou l’autre clone n’affectent pas la forme source.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La duplication copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Attribuez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des formes**

[remove](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/remove/) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection depuis la fin afin que chaque indice restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit la forme à l’indice actuel et ne suppose pas de type de forme spécifique.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Après la suppression, le nombre de formes et les indices des formes suivantes changent. Les références aux formes non affectées restent plus fiables que les indices sauvegardés. Envisagez également les connecteurs, les animations et d’autres fonctionnalités de la présentation qui peuvent faire référence à l’objet supprimé ; supprimer une forme visible peut modifier plus que l’apparence de la diapositive.

### **Masquer une forme**

Définir [Hidden](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/sethidden/) à `true` conserve la forme dans la collection mais l’empêche d’apparaître dans le diaporama normal. Son indice, son formatage et son contenu restent disponibles pour le code, donc masquer est approprié pour des éléments optionnels qui peuvent être restaurés plus tard.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Masquer n’est pas une suppression ni une mesure de sécurité. L’objet peut encore être découvert et rendu visible par un utilisateur ou par du code, et il reste partie du fichier de présentation.

### **Modifier l’ordre Z**

Les formes superposées sont peintes dans l’ordre de la collection. [reorder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/reorder/) déplace une forme existante vers un indice cible sans la dupliquer. L’indice `0` est l’arrière ; `size() - 1` est l’avant.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le rectangle est créé en premier et se situe initialement derrière l’ellipse. Le déplacer vers l’indice final le place en avant. Finalisez l’ordre Z après avoir ajouté ou dupliqué toutes les formes connexes, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Inspecter les formes sur les diapositives de mise en page**

Les diapositives normales, les diapositives de mise en page et les diapositives maîtres possèdent des collections de formes distinctes. Une forme dans une collection de mise en page n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Inspectez les formes de mise en page lorsque vous devez comprendre ou modifier le formatage fourni par une mise en page.

L’exemple suivant lit le [FillFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getfillformat/) et le [LineFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getlineformat/) de chaque forme de mise en page sans supposer que chaque forme est une `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Modifier une mise en page peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de mise en page, déterminez si une diapositive normale hérite de l’objet ou contient une surcharge locale, et testez chaque diapositive qui utilise cette mise en page.

## **Exporter une forme en SVG**

[writeAsSvg](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/writeassvg/) écrit le contenu rendu d’une forme dans un flux. Le résultat contient la forme, pas l’arrière‑plan complet de la diapositive ni les formes voisines.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme et des ressources telles que les polices et les images. Si vous avez besoin de la composition entière, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le fermer.

## **Aligner les formes**

Les surcharges [SlideUtil.alignShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideutil/alignshapes/) alignent soit toutes les formes, soit les indices sélectionnés de la collection. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Définissez `alignToSlide` à `true` pour utiliser les bords de la diapositive ; à `false` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Les références de forme retournées sont converties en leurs indices actuels immédiatement avant l’alignement.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’alignement modifie les positions, pas l’ordre Z. L’alignement relatif nécessite normalement au moins deux formes, tandis que la distribution horizontale ou verticale nécessite suffisamment de formes pour définir l’espacement. Recalculez les indices si vous modifiez la collection avant d’appeler la méthode.

## **Retourner une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `getFlipH` et `getFlipV` utilisent [NullableBool](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/nullablebool/) : `True` active le retournement, `False` le désactive, et `NotDefined` conserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![La forme avant retournement](shape_to_be_flipped.png)

L’exemple conserve toutes les autres valeurs du cadre et ne remplace que les deux paramètres de retournement. Ceci est important car l’affectation d’un nouveau [Frame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/setframe/) remplace le cadre complet.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forme enregistrée est miroir horizontalement et verticalement tout en conservant sa position, sa taille et sa rotation.

![La forme après retournement](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un indice de collection comme identifiant de forme ?**

Uniquement pour un traitement de courte durée lorsque la collection ne changera pas avant l’utilisation de l’indice. Privilégiez une convention validée `Name` ou `AlternativeText` pour les modèles créés, ou `OfficeInteropShapeId` pour le travail d’interopérabilité scoped à la diapositive.

**Masquer une forme la supprime‑t‑elle de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même indice. Elle peut être retrouvée, réordonnée, éditée ou rendue à nouveau visible.

**Pourquoi une forme dupliquée apparaît‑elle devant une autre forme ?**

`addClone` ajoute le clone à la fin de la collection, ce qui correspond à l’avant de l’ordre Z. Utilisez `insertClone` pour choisir l’indice initial ou `reorder` après que toutes les formes aient été ajoutées.

**Puis‑je utiliser un indice fixe pour identifier un ajustement de forme prédéfini ?**

Seulement après avoir validé le préréglage exact et la disposition de la collection. Préférez parcourir `GeometryShape.getAdjustments` et vérifier `AdjustValue.getType` ; utilisez `AdjustValue.getName` comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.