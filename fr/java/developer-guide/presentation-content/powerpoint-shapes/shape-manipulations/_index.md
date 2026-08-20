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
- trouver une forme
- cloner une forme
- supprimer une forme
- masquer une forme
- modifier l'ordre des formes
- obtenir l'ID de forme interop
- texte alternatif de la forme
- formats de mise en page de la forme
- forme en SVG
- forme vers SVG
- aligner une forme
- retourner une forme
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à identifier, cloner, supprimer, masquer, réordonner, exporter, aligner et retourner les formes de présentation avec Aspose.Slides for Java."
---
## **Vue d'ensemble**

Aspose.Slides for Java représente les formes d’une diapositive comme une [IShapeCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/) ordonnée. La collection est à la fois le lieu où vous trouvez et modifiez les formes et la source de leur ordre d'empilement : l’indice `0` correspond à la forme la plus arrière, tandis que le dernier indice correspond à la forme la plus avant.

Cet article suit ce modèle. Il explique d’abord comment identifier une forme de manière fiable, puis montre comment cloner, supprimer, masquer et réordonner les formes. Les sections finales couvrent le formatage au niveau de la disposition, l’exportation SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, de sorte que vous ne puissiez utiliser que les opérations requises par votre flux de travail.

## **Identifier et trouver des formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réordonner une forme peut changer son index. Choisissez un identifiant selon la façon dont la présentation est créée et maintenue :

- [Name](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getName--) est utile pour les modèles contrôlés par les développeurs et est facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis uniques, il faut donc établir une convention de nommage si le code en dépend.
- [AlternativeText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getAlternativeText--) est utile lorsqu’une description d’accessibilité ou une balise fournie par l’auteur identifie déjà la forme. Elle est visible des utilisateurs, peut être localisée ou réécrite pour l’accessibilité, et n’est pas garantie unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) est un identifiant en lecture seule unique au sein d’une diapositive et correspondant à l’ID de forme utilisé par l’interop PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou lorsque vous avez besoin d’une référence non ambiguë pendant la durée de vie d’une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La méthode [getUniqueId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getUniqueId--) associée retourne un identifiant à portée de présentation, mais cet identifiant est destiné aux compléments et peut être réassigné. Il ne doit pas être considéré comme une clé externe permanente. Si une identité à long terme est essentielle, conservez le mappage dans les données de l’application et validez que la forme attendue existe toujours.

L’exemple suivant recherche par nom avec une comparaison exacte et renvoie l’ID interop à portée de diapositive. Lorsque le modèle ne contient pas la forme attendue, le code signale ce résultat au lieu de poursuivre avec l’objet incorrect.

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

Lorsqu’une opération est spécifique à un type de forme, vérifiez l’interface avant d’utiliser des membres spécifiques au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/).

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

## **Modifier la collection de formes**

Les méthodes d’ajout, de clonage, de suppression et de réordonnancement s’appliquent immédiatement à la collection. Si une opération modifie le nombre ou l’ordre des formes, ne continuez pas à vous fier aux index capturés avant cette opération.

### **Cloner une forme**

[addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) crée une copie indépendante et l’ajoute à la collection cible. [insertClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) crée également une copie mais la place à un index d’ordre z spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent le redimensionner également.

L’exemple crée une diapositive de destination, clone un rectangle étiqueté vers l’avant, et insère un second clone à l’arrière. Les modifications de chaque clone n’affectent pas la forme source.

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

### **Supprimer des formes**

[remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection depuis la fin afin que chaque index restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit la forme à l’index actuel, pas un élément de collection fixe, et il ne cast pas inutilement la forme.

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

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que des index sauvegardés. Pensez également aux connecteurs, aux animations et à d’autres caractéristiques de la présentation qui peuvent référencer l’objet supprimé ; la suppression d’une forme visible peut modifier plus que l’apparence de la diapositive.

### **Masquer une forme**

Définir [Hidden](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#setHidden-boolean-) à `true` conserve la forme dans la collection mais empêche son affichage dans le diaporama normal. Son index, son formatage et son contenu restent accessibles au code, ainsi masquer est approprié pour les éléments optionnels qui peuvent être restaurés ultérieurement.

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

Masquer n’est pas une suppression ni une mesure de sécurité. L’objet peut encore être découvert et rendu visible à nouveau par un utilisateur ou par du code, et il reste une partie du fichier de présentation.

### **Modifier l’ordre Z**

Les formes qui se chevauchent sont peintes dans l’ordre de la collection. [reorder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) déplace une forme existante vers un index cible sans la cloner. L’indice `0` correspond à l’arrière ; `size() - 1` correspond à l’avant.

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

Le rectangle est créé d’abord et se trouve initialement derrière l’ellipse. Le déplacer vers l’index final le place à l’avant. Finalisez l’ordre z après avoir ajouté ou cloné toutes les formes associées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Inspecter les formes sur les diapositives de mise en page**

Les diapositives normales, les diapositives de mise en page et les diapositives maîtres ont des collections de formes distinctes. Une forme dans une collection de mise en page n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Inspectez les formes de mise en page lorsque vous devez comprendre ou modifier le formatage fourni par une mise en page.

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

Modifier une mise en page peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de mise en page, déterminez si une diapositive normale hérite de l’objet ou contient un remplacement local, et testez chaque diapositive qui utilise cette mise en page.

## **Exporter une forme au format SVG**

[writeAsSvg](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) écrit le contenu rendu d’une forme dans un flux. Le résultat contient la forme, pas l’arrière‑plan complet de la diapositive ou les formes voisines.

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

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme et des ressources telles que les polices et les images. Si vous avez besoin de l’ensemble de la composition, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le fermer.

## **Aligner des formes**

La surcharge [SlideUtil.alignShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) aligne soit toutes les formes, soit les index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Définissez `alignToSlide` à `true` pour utiliser les bords de la diapositive ; à `false` pour aligner les formes sélectionnées les unes par rapport aux autres.

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

L’alignement modifie les positions, pas l’ordre Z. L’alignement relatif nécessite normalement au moins deux formes, tandis que la distribution horizontale ou verticale demande suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retourner une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `getFlipH` et `getFlipV` utilisent [NullableBool](https://reference.aspose.com/slides/fr/java/com.aspose.slides/nullablebool/) : `True` active le retournement, `False` le désactive, et `NotDefined` conserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![The shape before flipping](shape_to_be_flipped.png)

L’exemple conserve toutes les autres valeurs du cadre et ne remplace que les deux paramètres de retournement. Cela est important car l’attribution d’un nouveau [Frame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) remplace le cadre complet.

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

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Seulement pour un traitement de courte durée lorsque la collection ne changera pas avant l’utilisation de l’index. Privilégiez une convention validée `Name` ou `AlternativeText` pour les modèles créés, ou `OfficeInteropShapeId` pour les travaux d’interop à portée de diapositive.

**Masquer une forme la supprime‑t‑elle de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être retrouvée, réordonnée, éditée ou rendue visible à nouveau.

**Pourquoi une forme clonée apparaît‑elle devant une autre forme ?**

`addClone` ajoute le clone à la fin de la collection, ce qui correspond à l’avant de l’ordre Z. Utilisez `insertClone` pour choisir l’index initial ou `reorder` après que toutes les formes aient été ajoutées.