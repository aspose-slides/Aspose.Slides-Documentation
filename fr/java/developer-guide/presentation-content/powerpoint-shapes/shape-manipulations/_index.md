---
title: Gérer les formes de présentation en Java
linktitle: Manipulation des formes
type: docs
weight: 40
url: /fr/java/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- rechercher forme
- cloner forme
- supprimer forme
- masquer forme
- changer l'ordre des formes
- obtenir ID de forme interop
- texte alternatif de forme
- point d'ajustement de forme
- ajustement predéfini de forme
- geometrie de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner forme
- retourner forme
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment identifier, ajuster, cloner, supprimer, masquer, reordonner, exporter, aligner et retourner les formes d'une présentation avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Aspose.Slides for Java représente les formes d’une diapositive comme une [IShapeCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/). La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d’empilement : l’index `0` correspond à la forme la plus en arrière, tandis que le dernier index correspond à la forme la plus en avant.

Cet article suit ce modèle. Il explique d’abord comment identifier une forme de façon fiable et modifier les points d’ajustement prédéfinis, puis montre comment cloner, supprimer, masquer et réorganiser les formes. Les sections finales couvrent le formatage au niveau des mises en page, l’export SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, de sorte que vous ne devez utiliser que les opérations dont votre flux de travail a besoin.

## **Identifier et Trouver des Formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réorganiser une forme peut modifier son index. Choisissez un identifiant en fonction de la façon dont la présentation est créée et maintenue :

- [Name](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getName--) est utile pour les modèles contrôlés par les développeurs et est facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être édités et ne sont pas garantis uniques, il faut donc établir une convention de nommage si le code en dépend.
- [AlternativeText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getAlternativeText--) est utile lorsqu’une description d’accessibilité ou une balise fournie par l’auteur identifie déjà la forme. Elle est visible des utilisateurs, peut être localisée ou réécrite pour l’accessibilité, et n’est pas garantie unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) est un identifiant en lecture seule qui est unique au sein d’une diapositive et correspond à l’ID de forme utilisé par l’interop PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou quand vous avez besoin d’une référence sans ambiguïté pendant la durée de vie d’une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La méthode [getUniqueId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getUniqueId--) associée renvoie un identifiant à portée de présentation, mais cet identifiant est destiné aux add‑ins et peut être réassigné. Il ne doit pas être considéré comme une clé externe permanente. Si une identité à long terme est essentielle, conservez le mapping dans les données de l’application et validez que la forme attendue existe toujours.

L’exemple suivant recherche par nom avec une comparaison exacte et indique l’ID d’interop à portée de diapositive. Lorsque le modèle ne contient pas la forme attendue, le code indique ce résultat plutôt que de poursuivre avec le mauvais objet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Lorsqu’une opération est spécifique à un type de forme, vérifiez l’interface avant d’utiliser des membres spécifiques au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identifier et Modifier les Ajustements de Formes Prédéfinies**

Les formes de géométrie prédéfinie peuvent exposer des points d’ajustement qui contrôlent des caractéristiques telles que la taille des coins, les proportions des flèches ou les angles d’arc. Accédez‑les via la collection en lecture seule [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igeometryshape/#getAdjustments--) . La collection elle‑même est fournie par la forme, mais chaque [IAdjustValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/) contient une valeur qui peut être modifiée.

Ne vous fiez pas uniquement à un index de collection fixe. Parcourez les ajustements et inspectez la méthode en lecture seule [getType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#getType--) , dont la valeur [ShapeAdjustmentType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapeadjustmenttype/) décrit ce que contrôle l’ajustement. La méthode en lecture seule [getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#getName--) fournit des informations d’identification supplémentaires et est particulièrement utile lorsqu’un prédéfini contient plusieurs ajustements du même type sémantique.

Utilisez la méthode de valeur correspondant à la signification de l’ajustement :

| Type d'ajustement | Objectif | Valeur à modifier |
|---|---|---|
| `CornerSize` | Taille des coins arrondis | [setRawValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Épaisseur de la queue d’une flèche | `setRawValue` |
| `ArrowheadLength` | Longueur d’une pointe de flèche | `setRawValue` |
| `ArrowheadWidth` | Largeur d’une pointe de flèche | `setRawValue` |
| `StartAngle` | Angle de départ d’un secteur ou d’un arc | [setAngleValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Angle de fin d’un secteur ou d’un arc | `setAngleValue` |

`getType` et `getName` renvoient des informations en lecture seule. `getRawValue` et `setRawValue` travaillent avec un entier dans les unités de géométrie natives du prédéfini, tandis que `getAngleValue` et `setAngleValue` travaillent avec un angle en degrés. Le nombre, l’ordre, la signification et la plage valide des ajustements dépendent du [ShapeType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igeometryshape/#getShapeType--) du prédéfini. Une valeur valide pour un prédéfini peut être invalide ou avoir un effet différent pour un autre.

Lorsque `getType` renvoie `ShapeAdjustmentType.Custom`, l’API ne reconnaît pas de signification sémantique standard. Inspectez `getName`, le type du prédéfini et la valeur existante, et laissez l’ajustement inchangé sauf si la signification et la plage attendues sont connues. Même pour les types reconnus, vérifiez si le même type apparaît plusieurs fois avant de sélectionner une valeur. L’article [Connector](/slides/fr/java/connector/) montre cette situation avec les ajustements de courbure des connecteurs.

L’exemple complet suivant crée des versions par défaut et modifiées de trois formes prédéfinies. Il parcourt chaque ajustement, indique son nom et son type, modifie les valeurs liées à la taille via `setRawValue`, modifie les angles via `setAngleValue` et sauvegarde le résultat. La colonne de gauche conserve la géométrie par défaut ; la colonne de droite montre le rectangle arrondi, la flèche à quatre pointes et le secteur ajustés.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoute les en-têtes pour les colonnes de formes par défaut et ajustées.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vérifier le type sémantique avant de changer une valeur rend le code explicite quant à son intention et évite de supposer qu’un index de collection particulier a la même signification entre différents prédéfinis.

## **Modifier la Collection de Formes**

Les méthodes d’ajout, de clonage, de suppression et de réorganisation opèrent immédiatement sur la collection. Si une opération modifie le nombre ou l’ordre des formes, ne continuez pas à vous fier aux index capturés avant cette opération.

### **Cloner une Forme**

[addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) crée une copie indépendante et l’ajoute à la collection cible. [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) crée également une copie mais la place à un index z‑order spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent le redimensionner également.

L’exemple crée une diapositive de destination, clone un rectangle étiqueté vers l’avant, et insère un second clone à l’arrière. Les modifications de l’un ou l’autre clone n’affectent pas la forme source.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le clonage copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Attribuez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des Formes**

[remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection à l’envers afin que chaque index restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit la forme à l’index courant, pas un élément de collection fixe, et il ne cast pas la forme inutilement.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que des index enregistrés. Pensez également aux connecteurs, aux animations et à d’autres fonctionnalités de la présentation qui peuvent faire référence à l’objet supprimé ; supprimer une forme visible peut changer plus que l’apparence de la diapositive.

### **Masquer une Forme**

Définir [Hidden](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#setHidden-boolean-) à `true` conserve la forme dans la collection mais l’empêche d’apparaître dans le diaporama normal. Son index, son formatage et son contenu restent disponibles au code, de sorte que masquer convient aux éléments optionnels pouvant être restaurés plus tard.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Masquer n’est pas une suppression ni une mesure de sécurité. L’objet peut toujours être découvert et démasqué par un utilisateur ou par du code, et il reste partie intégrante du fichier de présentation.

### **Modifier l'ordre Z**

Les formes qui se chevauchent sont rendues selon l’ordre de la collection. [reorder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) déplace une forme existante vers un index cible sans la cloner. L’index `0` est l’arrière ; `size() - 1` est l’avant.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le rectangle est créé d’abord et se trouve initialement derrière l’ellipse. Le déplacer vers l’index final le place devant. Finalisez l’ordre Z après avoir ajouté ou cloné toutes les formes concernées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Inspecter les Formes sur les Diapositives de Mise en Page**

Les diapositives normales, les diapositives de mise en page et les diapositives maîtres possèdent des collections de formes distinctes. Une forme dans une collection de mise en page n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Inspectez les formes de mise en page lorsque vous devez comprendre ou modifier le formatage fourni par une mise en page.

L’exemple suivant lit le [FillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getFillFormat--) et le [LineFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getLineFormat--) de chaque forme de mise en page sans supposer que chaque forme est une `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Modifier une mise en page peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de mise en page, déterminez si une diapositive normale hérite de l’objet ou possède une surcharge locale, et testez chaque diapositive utilisant cette mise en page.

## **Exporter une Forme vers SVG**

[writeAsSvg](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) écrit le contenu rendu d’une forme dans un flux. Le résultat ne contient que la forme, pas l’arrière‑plan complet de la diapositive ni les formes adjacentes.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme et des ressources telles que polices et images. Si vous avez besoin de la composition entière, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le fermer.

## **Aligner les Formes**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) propose des surcharges qui alignent soit toutes les formes, soit des index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Réglez `alignToSlide` à `true` pour utiliser les bords de la diapositive ; réglez‑le à `false` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Les références de formes retournées sont converties en leurs index actuels immédiatement avant l’alignement.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’alignement modifie les positions, pas l’ordre Z. Un alignement relatif nécessite généralement au moins deux formes, tandis que la distribution horizontale ou verticale requiert suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retourner une Forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `getFlipH` et `getFlipV` utilisent [NullableBool](https://reference.aspose.com/slides/fr/java/com.aspose.slides/nullablebool/) : `True` active le retournement, `False` le désactive, et `NotDefined` préserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![La forme avant le retournement](shape_to_be_flipped.png)

L’exemple préserve chaque autre valeur du cadre et ne remplace que les deux paramètres de retournement. C’est important car l’affectation d’un nouveau [Frame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) remplace le cadre complet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forme enregistrée est reflétée horizontalement et verticalement tout en conservant sa position, sa taille et sa rotation.

![La forme après le retournement](flipped_shape.png)

## **FAQ**

**Dois-je utiliser un index de collection comme identifiant de forme ?**

Seulement pour un traitement de courte durée lorsque la collection ne changera pas avant l’utilisation de l’index. Privilégiez une convention validée `Name` ou `AlternativeText` pour les modèles créés, ou `OfficeInteropShapeId` pour les travaux d’interop à portée de diapositive.

**Masquer une forme la supprime‑t‑elle de l'ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être retrouvée, réordonnée, modifiée ou rendue à nouveau visible.

**Pourquoi une forme clonée est‑elle apparue devant une autre forme ?**

`addClone` ajoute le clone à la fin de la collection, ce qui correspond à l’avant de l’ordre Z. Utilisez `insertClone` pour choisir l’index initial ou `reorder` après avoir ajouté toutes les formes.

**Puis‑je utiliser un index fixe pour identifier un ajustement de forme prédéfini ?**

Seulement après avoir validé le prédéfini exact et la disposition de la collection. Privilégiez l’itération via `IGeometryShape.getAdjustments` et la vérification de `IAdjustValue.getType` ; utilisez `IAdjustValue.getName` comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.