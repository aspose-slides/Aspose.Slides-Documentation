---
title: Mise en forme des formes PowerPoint en JavaScript
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/nodejs-java/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme en croquis
- format du style de jointure
- remplissage en dégradé
- remplissage de motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rotation de forme
- effet de biseautage 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Mettez en forme les formes PowerPoint en JavaScript avec Aspose.Slides — définissez les styles de remplissage, de ligne et d'effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Étant donné que les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java fournit des classes et des méthodes qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

En utilisant Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [line style](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [dash style](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/linedashstyle/) de la ligne.
1. Définir la couleur de la ligne pour la forme.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Le code suivant montre comment formater un `AutoShape` rectangle :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtiens la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Définit la couleur de remplissage pour la forme rectangle.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Applique le formatage aux lignes du rectangle.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Définit la couleur de la ligne du rectangle.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The formatted lines in the presentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à une ligne de forme l’apparence d’un tracé à main levée. Utilisez [Shape.getLineFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) pour accéder aux paramètres de ligne, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/lineformat/) pour accéder aux paramètres de croquis, et [SketchFormat.setSketchType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sketchformat/) pour choisir une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/linesketchtype/).

Le code JavaScript suivant montre comment appliquer l’effet [LineSketchType.Curved](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/linesketchtype/), lire la valeur assignée explicitement, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/linesketchtype/) :

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Accéder au format de ligne de la forme et à son format de croquis.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Appliquer un effet de croquis.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Lire l'effet de croquis attribué directement à la forme.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Supprimer l'effet de croquis.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

La valeur renvoyée par [SketchFormat.getSketchType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sketchformat/) représente le paramètre assigné directement à la forme. Si le formatage de la ligne peut être hérité d’un thème, d’une diapositive maître ou d’une diapositive de disposition, utilisez [LineFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/lineformat/), appelez `getSketchFormat` sur l’objet retourné, puis appelez sa méthode `getSketchType`. La valeur effective reflète le formatage réellement appliqué après résolution de l’héritage :

```js
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

* Arrondi
* Biseau
* Biseauté

Par défaut, lorsque PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Arrondi**. Cependant, si vous dessinez une forme avec des angles nets, vous préférerez peut‑être l’option **Biseau**.

![The join style in the presentation](join-style-powerpoint.png)

Le code JavaScript suivant montre comment trois rectangles (comme illustré sur l’image ci‑dessus) ont été créés en utilisant les paramètres de jointure Biseau, Biseauté et Arrondi :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute trois formes automatiques de type Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Définit la couleur de remplissage pour chaque forme rectangle.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Définit la largeur de la ligne.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Définit la couleur de la ligne de chaque rectangle.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Définit le style de jointure.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Ajoute du texte à chaque rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de formatage qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une se fonde progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajouter vos deux couleurs préférées avec des positions définies en utilisant les méthodes `add` de la collection de points d’arrêt de dégradé exposée par la classe [GradientFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/gradientformat/).
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Le code JavaScript suivant montre comment appliquer un effet de remplissage en dégradé à une ellipse :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique de type Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Applique le formatage en dégradé à l'ellipse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Définit la direction du dégradé.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Ajoute deux arrêts de dégradé.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The ellipse with gradient fill](gradient-fill.png)

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de formatage qui vous permet d’appliquer un motif à deux couleurs—tel que des points, des bandes, des hachures ou des carreaux—à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez préciser les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Définir la [Background Color](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/patternformat/#getBackColor--) du motif.
1. Définir la [Foreground Color](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/patternformat/#getForeColor--) du motif.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Le code JavaScript suivant montre comment appliquer un remplissage de motif à un rectangle :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Définit le type de remplissage sur Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Définit le style de motif.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Définit les couleurs d'arrière-plan et de premier plan du motif.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The rectangle with pattern fill](pattern-fill.png)

## **Remplissage d'image**

Dans PowerPoint, le remplissage d'image est une option de formatage qui vous permet d’insérer une image à l’intérieur d’une forme—utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d'image à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définir le mode de remplissage d’image sur `Tile` (ou un autre mode souhaité).
1. Créer un objet [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) à partir de l’image que vous souhaitez utiliser.
1. Passer l’image à la méthode `ISlidesPicture.setImage`.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Supposons que nous ayons un fichier **lotus.png** avec l’image suivante :

![The lotus picture](lotus.png)

Le code JavaScript suivant montre comment remplir une forme avec l’image :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Définit le type de remplissage sur Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Définit le mode de remplissage d'image.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Charge une image et l'ajoute aux ressources de la présentation.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Définit l'image.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The shape with picture fill](picture-fill.png)

### **Carreler l'image comme texture**

Si vous souhaitez définir une image carrelée comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les méthodes suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) : définit le mode de remplissage d’image—`Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment) : spécifie l’alignement des carreaux dans la forme.
- [setTileFlip](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#setTileFlip) : contrôle le retournement horizontal, vertical ou les deux du carreau.
- [setTileOffsetX](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX) : définit le déplacement horizontal du carreau (en points) par rapport à l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY) : définit le déplacement vertical du carreau (en points) par rapport à l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX) : définit l’échelle horizontale du carreau en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY) : définit l’échelle verticale du carreau en pourcentage.

Le fragment de code suivant montre comment ajouter une forme rectangle avec un remplissage d’image carrelée et configurer les options de carrelage :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Définit le type de remplissage de la forme sur Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Charge l'image et l'ajoute aux ressources de la présentation.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Assigne l'image à la forme.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configure le mode de remplissage d'image et les propriétés de carrelage.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The tile options](tile-options.png)

## **Remplissage couleur unie**

Dans PowerPoint, le remplissage couleur unie est une option de formatage qui remplit une forme avec une couleur unique et uniforme. Ce fond plat est appliqué sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuer la couleur de remplissage souhaitée à la forme.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Le code JavaScript suivant montre comment appliquer un remplissage couleur unie à un rectangle dans une diapositive PowerPoint :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Définit le type de remplissage sur Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Définit la couleur de remplissage.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The shape with solid color fill](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez une couleur unie, un dégradé, une image ou une texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus transparente, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/) sur `Solid`.
1. Utiliser `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrer la présentation.

Le code JavaScript suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique rectangle solide.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ajoute une forme automatique rectangle transparente au dessus de la forme solide.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The transparent shape](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définir la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrer la présentation.

Le code JavaScript suivant montre comment faire pivoter une forme de 5 degrés :

```js
// Instancie la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajoute une forme automatique de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Fait pivoter la forme de 5 degrés.
    shape.setRotation(5);

    // Enregistre le fichier PPTX sur le disque.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The shape rotation](shape-rotation.png)

## **Ajouter des effets de biseautage 3D**

Aspose.Slides vous permet d’appliquer des effets de biseautage 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/).

Pour ajouter des effets de biseautage 3D à une forme, suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseautage.
1. Enregistrer la présentation.

Le code JavaScript suivant montre comment appliquer des effets de biseautage 3D à une forme :

```js
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

Le résultat :

![The 3D bevel effect](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Utiliser [setCameraType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/camera/#setCameraType) et [setLightType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/lightrig/#setLightType) pour définir la rotation 3D.
1. Enregistrer la présentation.

Le code JavaScript suivant montre comment appliquer des effets de rotation 3D à une forme :

```js
// Créez une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Enregistrez la présentation au format PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The 3D rotation effect](3D-rotation-effect.png)

## **Réinitialiser le formatage**

Le code Java suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/) à leurs valeurs par défaut :

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Réinitialiser chaque forme sur la diapositive qui possède un espace réservé dans la disposition.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement très peu. Les images et les médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres des formes tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucun poids supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les principales propriétés de formatage de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, traitez leurs styles comme équivalents et regroupez logiquement ces formes, ce qui simplifie la gestion des styles ultérieure.

**Puis-je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d'autres présentations ?**

Oui. Enregistrez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.