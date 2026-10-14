---
title: Mise en forme des formes PowerPoint en JavaScript
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/nodejs-java/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet esquisse
- ligne de forme esquissée
- format du style de jointure
- remplissage en dégradé
- remplissage à motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de la forme
- rendu noir et blanc de la forme
- rendu en niveaux de gris de la forme
- rotation de la forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser la mise en forme
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Mettez en forme les formes PowerPoint en JavaScript avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et un contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Puisque les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java fournit des classes et des méthodes qui vous permettent de mettre en forme les formes en utilisant les mêmes options que celles disponibles dans PowerPoint.

## **Format des lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) de la ligne.
1. Définir la couleur de ligne pour la forme.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Le code suivant montre comment formater un `AutoShape` rectangle :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Supprimer le remplissage de la forme rectangle.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Appliquer la mise en forme aux lignes du rectangle.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Définir la couleur de la ligne du rectangle.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Appliquer des effets d’esquisse aux lignes de forme**

Un effet d’esquisse donne à la ligne d’une forme un aspect dessiné à la main. Utilisez [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) pour accéder aux paramètres de ligne, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) pour accéder aux paramètres d’esquisse, et [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Le code JavaScript suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) , lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Accéder au format de ligne de la forme et à son format d'esquisse.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Appliquer un effet d'esquisse.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Lire l'effet d'esquisse assigné directement à la forme.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Supprimer l'effet d'esquisse.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

La valeur renvoyée par [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) représente le paramètre assigné directement à la forme. Si la mise en forme de la ligne peut être héritée d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), appelez `getSketchFormat` sur l’objet retourné, puis appelez sa méthode `getSketchType`. La valeur effective reflète la mise en forme réellement appliquée après la résolution de l’héritage :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles aigus, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code JavaScript suivant montre comment trois rectangles (comme illustré sur l’image ci‑dessus) ont été créés en utilisant les paramètres de type de jointure Miter, Bevel et Round :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter trois formes automatiques de type Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Définir la couleur de remplissage pour chaque forme rectangle.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Définir la largeur de la ligne.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Définir la couleur de la ligne de chaque rectangle.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Définir le style de jointure.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Ajouter du texte à chaque rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de mise en forme qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies en utilisant les méthodes `add` de la collection d’arrêts de dégradé exposée par la classe [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/).
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquer le format de dégradé à l'ellipse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Définir la direction du dégradé.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Ajouter deux arrêts de dégradé.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’ellipse avec remplissage en dégradé :

![L’ellipse avec remplissage en dégradé](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choisir un style de rendu de dégradé](/slides/fr/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le remplissage en dégradé stocké dans la présentation.

## **Remplissage à motif**

Dans PowerPoint, le remplissage à motif est une option de mise en forme qui vous permet d’appliquer un dessin bicolore — tel que des points, des rayures, des hachures croisées ou des damiers — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motifs prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage à motif à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Set the [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) of the pattern.
1. Set the [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) of the pattern.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Définir le style du motif.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Définir les couleurs d'arrière-plan et de premier plan du motif.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le rectangle avec remplissage à motif :

![Le rectangle avec remplissage à motif](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme — utilisant effectivement l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définir le mode de remplissage d’image sur `Tile` (ou un autre mode préféré).
1. Créer un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) à partir de l’image que vous souhaitez utiliser.
1. Passer l’image à la méthode `ISlidesPicture.setImage`.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Supposons que nous ayons un fichier « lotus.png » avec l’image suivante :

![L’image lotus](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Définir le type de remplissage sur Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Définir le mode de remplissage de l'image.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Charger une image et l'ajouter aux ressources de la présentation.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Définir l'image.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forme avec remplissage d’image :

![La forme avec remplissage d’image](picture-fill.png)

### **Carreler l’image comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les méthodes suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) : Définit le mode de remplissage d’image — soit `Tile` soit `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment) : Spécifie l’alignement des tuiles au sein de la forme.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip) : Contrôle si la tuile est retournée horizontalement, verticalement, ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX) : Définit le décalage horizontal de la tuile (en points) depuis l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY) : Définit le décalage vertical de la tuile (en points) depuis l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX) : Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY) : Définit l’échelle verticale de la tuile en pourcentage.

Le code d’exemple suivant montre comment ajouter une forme rectangle avec un remplissage d’image en mosaïque et configurer les options de tuile :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Définir le type de remplissage de la forme sur Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Charger l'image et l'ajouter aux ressources de la présentation.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Assigner l'image à la forme.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurer le mode de remplissage d'image et les propriétés de carrelage.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les options de tuile :

![Les options de tuile](tile-options.png)

## **Remplissage couleur unie**

Dans PowerPoint, le remplissage couleur unie est une option de mise en forme qui remplit une forme d’une couleur unique et uniforme. Cette couleur d’arrière‑plan simple est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Solid`.
1. Assigner votre couleur de remplissage préférée à la forme.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Définir la couleur de remplissage.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forme avec remplissage couleur unie :

![La forme avec remplissage couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage couleur unie, dégradé, image ou texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, laissant le fond ou les objets sous‑jacent partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) sur `Solid`.
1. Utiliser `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrer la présentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto rectangle solide.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ajouter une forme auto rectangle transparente au-dessus de la forme solide.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forme transparente :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des besoins d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrer la présentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Faire pivoter la forme de 5 degrés.
    shape.setRotation(5);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rotation de la forme :

![Rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) .

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrer la présentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Créer une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme à la diapositive.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Définir les propriétés ThreeDFormat de la forme.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Enregistrer la présentation au format PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’effet de biseau 3D :

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) .

Pour appliquer une rotation 3D à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Utiliser [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) et [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) pour définir la rotation 3D.
1. Enregistrer la présentation.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Créer une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Enregistrer la présentation au format PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’effet de rotation 3D :

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc pour les formes**

La méthode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage en noir et blanc en soi, et ne modifie pas le remplissage, la ligne ou toute autre mise en forme de la forme en mode couleur normal.

Utilisez une valeur de l’énumération [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent des nuances de gris, `BlackWhite` n’utilise que le noir et le blanc, `Black` et `White` forcent une couleur unique, `Color` préserve les couleurs normales, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est assigné.

Le code JavaScript suivant crée une forme colorée et la fait apparaître en gris en mode d’affichage noir et blanc :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Conserver le remplissage orange en mode couleur, mais rendre la forme en gris en mode noir et blanc.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En mode couleur normal, le rectangle conserve son remplissage orange. En mode d’affichage noir et blanc, il utilise une coloration grise parce que son mode est défini sur `Gray`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, la prévisualisation ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser la mise en forme**

Le code JavaScript suivant montre comment réinitialiser la mise en forme d’une diapositive et restaurer la position, la taille et la mise en forme de toutes les formes avec des espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) à leurs paramètres par défaut :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Réinitialiser chaque forme de la diapositive qui possède un espace réservé dans la mise en page.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement légèrement. Les images et médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres des formes tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent une mise en forme identique afin de les regrouper ?**

Comparez les propriétés de mise en forme clés de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion des styles ultérieure.

**Puis-je enregistrer un ensemble de styles de formes personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur mise en forme partout où cela est requis.