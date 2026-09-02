---
title: "Formatage des formes PowerPoint en PHP"
linktitle: "Mise en forme des formes"
type: docs
weight: 20
url: /fr/php-java/shape-formatting/
keywords:
- "format de forme"
- "format de ligne"
- "effet de croquis"
- "ligne de forme en croquis"
- "format du style de jointure"
- "remplissage en dégradé"
- "remplissage en motif"
- "remplissage d’image"
- "remplissage de texture"
- "remplissage de couleur unie"
- "transparence de forme"
- "rendu noir et blanc de la forme"
- "rendu en niveaux de gris de la forme"
- "rotation de forme"
- "effet de biseau 3D"
- "effet de rotation 3D"
- "réinitialiser le formatage"
- "PowerPoint"
- "présentation"
- "PHP"
- "Aspose.Slides"
description: "Apprenez à formater les formes PowerPoint en PHP avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont constituées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant les paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-forme-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java fournit des classes et des méthodes qui vous permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

En utilisant Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [style de ligne](https://reference.aspose.com/slides/fr/php-java/aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [style de tirets](https://reference.aspose.com/slides/fr/php-java/aspose.slides/linedashstyle/) de la ligne.
1. Définir la couleur de la ligne pour la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code PHP suivant montre comment formater un `AutoShape` rectangle :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Définir la couleur de remplissage pour la forme rectangle.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Appliquer le formatage aux lignes du rectangle.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Définir la couleur de la ligne du rectangle.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis rend la ligne d’une forme semblable à un dessin à la main. Utilisez [Shape.getLineFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) pour accéder aux paramètres de la ligne, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/lineformat/) pour accéder aux paramètres du croquis, et [SketchFormat.setSketchType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sketchformat/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/linesketchtype/).

Le code PHP suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/fr/php-java/aspose.slides/linesketchtype/) , lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/fr/php-java/aspose.slides/linesketchtype/) :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Accéder au format de ligne de la forme et à son format de croquis.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Appliquer un effet de croquis.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Lire l'effet de croquis assigné directement à la forme.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Supprimer l'effet de croquis.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

La valeur renvoyée par [SketchFormat.getSketchType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sketchformat/) représente le paramètre assigné directement à la forme. Si le format de ligne peut être hérité d’un thème, d’une diapositive maître ou d’une diapositive de mise en page, utilisez [LineFormat.getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/lineformat/), accédez à la méthode `getSketchFormat` de l’objet retourné, et lisez sa valeur `getSketchType`. La valeur effective reflète le format réellement appliqué après résolution de l’héritage :

```php
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

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles aigus, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code PHP suivant montre comment trois rectangles (comme illustré dans l’image ci‑above) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter trois formes auto de type Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Définir la couleur de remplissage pour chaque forme rectangle.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Définir la largeur de la ligne.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Définir la couleur de la ligne de chaque rectangle.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Définir le style de jointure.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Ajouter du texte à chaque rectangle.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de mise en forme qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce qu’une se fonde progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajouter vos deux couleurs préférées avec des positions définies en utilisant les méthodes `add` de la collection de points d’arrêt du dégradé exposée par la classe [GradientFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/gradientformat/).
1. Enregistrer la présentation modifiée au format PPTX.

Le code PHP suivant montre comment appliquer un effet de remplissage en dégradé à une ellipse :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto de type Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Appliquer le format de degrade a l'ellipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Definir la direction du degrade.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Ajouter deux points d'arret du degrade.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L’ellipse avec remplissage en dégradé](gradient-fill.png)

## **Remplissage en motif**

Dans PowerPoint, le remplissage en motif est une option de mise en forme qui vous permet d’appliquer un motif bicolore — tel que des points, des rayures, des hachures croisées ou des damiers — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides fournit plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes qu’il doit utiliser.

Voici comment appliquer un remplissage en motif à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Définir la [Background Color](https://reference.aspose.com/slides/fr/php-java/aspose.slides/patternformat/#getBackColor) du motif.
1. Définir la [Foreground Color](https://reference.aspose.com/slides/fr/php-java/aspose.slides/patternformat/#getForeColor) du motif.
1. Enregistrer la présentation modifiée au format PPTX.

Le code PHP suivant montre comment appliquer un remplissage en motif à un rectangle :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Définir le style du motif.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Définir les couleurs d'arrière-plan et de premier plan du motif.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Le rectangle avec remplissage en motif](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme — utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définir le mode de remplissage d’image sur `Tile` (ou un autre mode préféré).
1. Créer un objet [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) à partir de l’image que vous souhaitez utiliser.
1. Passer l’image à la méthode `SlidesPicture.setImage`.
1. Enregistrer la présentation modifiée au format PPTX.

Supposons que nous ayons un fichier « lotus.png » avec l’image suivante :

![L’image lotus](lotus.png)

Le code PHP suivant montre comment remplir une forme avec l’image :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Définir le type de remplissage sur Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Définir le mode de remplissage d'image.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Charger une image et l'ajouter aux ressources de la présentation.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Définir l'image.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![La forme avec remplissage d’image](picture-fill.png)

### **Image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les méthodes suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#setPictureFillMode) : Définit le mode de remplissage d’image — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#setTileAlignment) : Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#setTileFlip) : Contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#setTileOffsetX) : Définit le décalage horizontal de la tuile (en points) par rapport à l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#setTileOffsetY) : Définit le décalage vertical de la tuile (en points) par rapport à l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#setTileScaleX) : Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picturefillformat/#setTileScaleY) : Définit l’échelle verticale de la tuile en pourcentage.

Le fragment de code suivant montre comment ajouter une forme rectangulaire avec un remplissage d’image en mosaïque et configurer les options de la tuile :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Définir le type de remplissage de la forme sur Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Charger l'image et l'ajouter aux ressources de la présentation.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Assigner l'image à la forme.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Configurer le mode de remplissage d'image et les propriétés de mosaïque.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les options de mosaïque](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de mise en forme qui remplit une forme avec une couleur unique et uniforme. Cette couleur d’arrière‑plan simple est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) de la forme sur `Solid`.
1. Affecter la couleur de remplissage souhaitée à la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code PHP suivant montre comment appliquer un remplissage de couleur unie à un rectangle dans une diapositive PowerPoint :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Définir la couleur de remplissage.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![La forme avec remplissage de couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez une couleur unie, un dégradé, une image ou une texture à des formes, vous pouvez aussi définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus transparente, laissant le fond ou les objets sous‑jacent partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filltype/) sur `Solid`.
1. Utiliser `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrer la présentation.

Le code PHP suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto rectangle solide.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ajouter une forme auto rectangle transparente au dessus de la forme solide.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences spécifiques d’alignement ou de conception.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Définir la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrer la présentation.

Le code PHP suivant montre comment faire pivoter une forme de 5 degrés :

```php
// Instancier la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Faire pivoter la forme de 5 degrés.
    $shape->setRotation(5);

    // Enregistrer le fichier PPTX sur le disque.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/) de la forme pour définir les paramètres du biseau.
1. Enregistrer la présentation.

Le code PHP suivant montre comment appliquer des effets de biseau 3D à une forme :

```php
// Créer une instance de la classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ajouter une forme à la diapositive.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Définir les propriétés ThreeDFormat de la forme.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Enregistrer la présentation au format PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
1. Utiliser [setCameraType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/camera/#setCameraType) et [setLightType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/lightrig/#setLightType) pour définir la rotation 3D.
1. Enregistrer la présentation.

Le code PHP suivant montre comment appliquer des effets de rotation 3D à une forme :

```php
// Créer une instance de la classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Enregistrer la présentation au format PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc des formes**

La méthode [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#setBlackWhiteMode) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas elle‑même l’affichage en noir et blanc et ne modifie pas le remplissage, la ligne ou tout autre formatage de la forme en mode couleur normale.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent des tons de gris, `BlackWhite` n’utilise que le noir et le blanc, `Black` et `White` forcent une couleur unique, `Color` préserve les couleurs normales, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est assigné.

Le code PHP suivant crée une forme colorée et la fait apparaître en gris en mode d’affichage noir et blanc :

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
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Conserver le remplissage orange en mode couleur, mais rendre la forme en gris en mode noir et blanc.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

En mode couleur normal, le rectangle conserve son remplissage orange. En mode d’affichage noir et blanc, il utilise le gris parce que son mode est défini sur `Gray`. Cela vous permet de préserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, l’aperçu ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser le formatage**

Le code Java suivant montre comment réinitialiser le formatage d’une diapositive et ramener la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslide/) à leurs paramètres par défaut :

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Réinitialiser chaque forme sur la diapositive qui possède un espace réservé dans la mise en page.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement légèrement. Les images et les médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés en tant que métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les propriétés de formatage clés de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un diaporama modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, dupliquez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.