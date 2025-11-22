---
title: Mise en forme des formes PowerPoint en JavaScript
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/nodejs-java/shape-formatting/
keywords:
- mise en forme de forme
- mise en forme de ligne
- mise en forme du style de jointure
- remplissage dégradé
- remplissage de motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser la mise en forme
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en JavaScript avec Aspose.Slides - définissez les styles de remplissage, de ligne et d'effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---

## **Aperçu**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont constituées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en précisant des paramètres qui contrôlent le remplissage de leurs intérieurs.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java fournit des classes et des méthodes qui vous permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Mise en forme des lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [style de ligne](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [style de tiret](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Le code suivant montre comment mettre en forme un `AutoShape` rectangle :
```js
// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Définir la couleur de remplissage pour la forme rectangle.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Appliquer le formatage aux lignes du rectangle.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Mise en forme des styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsqu PowerPoint joint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles aigus, vous préférerez peut‑être l’option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Le code JavaScript suivant montre comment trois rectangles (comme illustré sur l’image ci‑dessus) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :
```js
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


## **Remplissage dégradé**

Dans PowerPoint, le remplissage dégradé est une option de mise en forme qui vous permet d’appliquer un dégradé continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies en utilisant les méthodes `add` de la collection de points d’arrêt du dégradé exposée par la classe [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/).
1. Enregistrez la présentation modifiée au format PPTX.

Le code JavaScript suivant montre comment appliquer un effet de remplissage dégradé à une ellipse :
```js
// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquer le formatage en dégradé à l'ellipse.
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


Le résultat :

![The ellipse with gradient fill](gradient-fill.png)

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de mise en forme qui vous permet d’appliquer un motif à deux couleurs—par exemple des points, des rayures, des hachures croisées ou des damiers—à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours préciser les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [couleur d’arrière‑plan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) du motif.
1. Définissez la [couleur de premier plan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) du motif.
1. Enregistrez la présentation modifiée au format PPTX.

Le code JavaScript suivant montre comment appliquer un remplissage de motif à un rectangle :
```js
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


Le résultat :

![The rectangle with pattern fill](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme—utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage d’image sur `Tile` (ou tout autre mode souhaité).
1. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) à partir de l’image que vous souhaitez utiliser.
1. Transmettez l’image à la méthode `ISlidesPicture.setImage`.
1. Enregistrez la présentation modifiée au format PPTX.

Supposons que nous ayons un fichier « lotus.png » avec l’image suivante :

![The lotus picture](lotus.png)

Le code JavaScript suivant montre comment remplir une forme avec l’image :
```js
// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Définir le type de remplissage sur Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Définir le mode de remplissage d'image.
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


Le résultat :

![The shape with picture fill](picture-fill.png)

### **Utiliser l’image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les méthodes suivantes de la classe [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) : définit le mode de remplissage d’image—`Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment) : spécifie l’alignement des carreaux à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip) : contrôle si le carreau est retourné horizontalement, verticalement ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX) : définit le décalage horizontal du carreau (en points) depuis l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY) : définit le décalage vertical du carreau (en points) depuis l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX) : définit l’échelle horizontale du carreau en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY) : définit l’échelle verticale du carreau en pourcentage.

L’exemple de code suivant montre comment ajouter une forme rectangle avec un remplissage d’image en mosaïque et configurer les options de carrelage :
```js
// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Définir le type de remplissage de la forme sur Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Charger l'image et l'ajouter aux ressources de la présentation.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Affecter l'image à la forme.
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


Le résultat :

![The tile options](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de mise en forme qui remplit une forme avec une couleur unique et uniforme. Cette couleur d’arrière‑plan simple est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuez à la forme la couleur de remplissage souhaitée.
1. Enregistrez la présentation modifiée au format PPTX.

Le code JavaScript suivant montre comment appliquer un remplissage de couleur unie à un rectangle dans une diapositive PowerPoint :
```js
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


Le résultat :

![The shape with solid color fill](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage de couleur unie, dégradé, image ou texture aux formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, laissant le fond ou les objets sous‑jacent partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

Le code JavaScript suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :
```js
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


Le résultat :

![The transparent shape](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile lors du placement d’éléments visuels requérant un alignement ou un design spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Définissez la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrez la présentation.

Le code JavaScript suivant montre comment faire pivoter une forme de 5 degrés :
```js
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


Le résultat :

![The shape rotation](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

Le code JavaScript suivant montre comment appliquer des effets de biseau 3D à une forme :
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

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Utilisez les méthodes [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) et [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) pour définir la rotation 3D.
1. Enregistrez la présentation.

Le code JavaScript suivant montre comment appliquer des effets de rotation 3D à une forme :
```js
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


Le résultat :

![The 3D rotation effect](3D-rotation-effect.png)

## **Réinitialiser la mise en forme**

Le code Java suivant montre comment réinitialiser la mise en forme d’une diapositive et restaurer la position, la taille et la mise en forme de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) à leurs paramètres par défaut :
```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Réinitialiser chaque forme de la diapositive qui possède un espace réservé sur la mise en page.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Le formatage des formes influence-t‑il la taille finale du fichier de présentation ?**

Seulement de manière minimale. Les images et les médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes d’une diapositive qui partagent exactement le même formatage afin de les regrouper ?**

Comparez les principales propriétés de formatage de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion des styles ultérieurement.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Conservez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur mise en forme là où cela est requis.